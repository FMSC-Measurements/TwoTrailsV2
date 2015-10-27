using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessLogic;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;
using TwoTrails.Engine;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class MassEditForm : Form
    {
        private DataAccessLayer DAL;

        private TtPolygon CurrPoly;

        private Dictionary<string, TtPolygon> Polygons;
        private Dictionary<string, string> PolyNames;
        private Dictionary<string, Dictionary<string, TtPoint>> Points;
        private Dictionary<string, Dictionary<string, TtPoint>> OldPoints;
        private List<string> _DeleteNmea;   //delete these nmea on exit without save
        private bool onBnd;

        bool _recalc;

        public void Init(DataAccessLayer dal)
        {
            this.DialogResult = DialogResult.Abort;

            DAL = dal;
            _recalc = false;

            List<TtPolygon> polys = DAL.GetPolygons();

            if (polys.Count < 1)
            {
                MessageBox.Show("There are no Polygons to edit from.");
                return;
            }

            Polygons = new Dictionary<string, TtPolygon>();
            PolyNames = new Dictionary<string, string>();
            Points = new Dictionary<string, Dictionary<string, TtPoint>>();
            OldPoints = new Dictionary<string, Dictionary<string, TtPoint>>();

            _DeleteNmea = new List<string>();

            try
            {
                foreach (TtPolygon poly in polys)
                {
                    Polygons.Add(poly.CN, poly);
                    PolyNames.Add(poly.Name, poly.CN);
                    Points.Add(poly.CN, new Dictionary<string, TtPoint>());
                    OldPoints.Add(poly.CN, new Dictionary<string, TtPoint>());
                    foreach (TtPoint point in DAL.GetPointsInPolygon(poly.CN))
                    {
                        Points[poly.CN].Add(point.CN, point);
                        OldPoints[poly.CN].Add(point.CN, point);
                    }

                    cboPoly.Items.Add(poly.Name);
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MassEditFormLogic:Init");
                return;
            }

            if (Values.Settings.DeviceOptions.UseSelection)
            {
                cboPoly.Visible = false;

                btnPolygon.Visible = true;
            }
            else
            {
                cboPoly.Visible = true;

                btnPolygon.Visible = false;
            }

            CurrPoly = Polygons.First().Value;
            btnPolygon.Text = CurrPoly.Name;

            lstPoints.Columns.Add("Point", 70, HorizontalAlignment.Left);
            lstPoints.Columns.Add("Polygon", 70, HorizontalAlignment.Left);
            lstPoints.Columns.Add("Type", 70, HorizontalAlignment.Left);
            lstPoints.Columns.Add("OnBound", 50, HorizontalAlignment.Left);
            lstPoints.Columns.Add("CN", 180, HorizontalAlignment.Left);

            LoadPolygon();

            btnBnd.Text = "On";
            onBnd = true;

            this.DialogResult = DialogResult.Cancel;
        }


        private void LoadPolygon()
        {
            LoadPolygon(CurrPoly.CN);
        }

        private void LoadPolygon(string cn)
        {
            lstPoints.Items.Clear();

            if (Points[CurrPoly.CN].Values != null && Points[CurrPoly.CN].Values.Count > 0)
            {
                foreach(TtPoint point in Points[CurrPoly.CN].Values)
                {
                    ListViewItem l = new ListViewItem(point.PID.ToString());
                    l.SubItems.Add(point.PolyName);
                    l.SubItems.Add(point.op.ToString());
                    l.SubItems.Add((point.OnBnd) ? "On" : "Off");
                    l.SubItems.Add(point.CN);
                    lstPoints.Items.Add(l);
                }
            }

            lstPoints.CheckBoxes = true;
            chkAll.Checked = false;
        }

        private void ChangePolygon(string cn)
        {
            CurrPoly = Polygons[cn];

            cboPoly.SelectedItem = CurrPoly.Name;
            btnPolygon.Text = CurrPoly.Name;

            LoadPolygon(CurrPoly.CN);
        }


        #region Controls
        private void cboPoly_SelectedIndexChanged2(object sender, EventArgs e)
        {
            ChangePolygon(PolyNames[cboPoly.SelectedItem.ToString()]);
        }

        private void btnPolygon_Click2(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            items = PolyNames.Keys.ToList();

            using (Selection form = new Selection("Select Polygon", items, items.IndexOf(CurrPoly.Name)))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ChangePolygon(PolyNames[items[form.selection]]);
                }
            }
        }

        private void btnSwitchPoly_Click2(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            items = PolyNames.Keys.ToList();

            using (Selection form = new Selection("Select Polygon", items, items.IndexOf(CurrPoly.Name)))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string polySwitchCN = PolyNames[items[form.selection]];
                    string polySwitchName = items[form.selection];

                    foreach (ListViewItem item in lstPoints.Items)
                    {
                        if (item.Checked)
                        {
                            string pointCN = item.SubItems[4].Text;
                            TtPoint point = Points[CurrPoly.CN][pointCN];

                            point.PolyCN = polySwitchCN;
                            point.PolyName = polySwitchName;

                            Points[polySwitchCN].Add(point.CN, point);
                            Points[CurrPoly.CN].Remove(point.CN);
                        }
                    }

                    LoadPolygon();
                    _recalc = true;
                }
            }
        }

        private void btnConvert_Click2(object sender, EventArgs e)
        {
            if (MessageBox.Show("Convert these quondams into their parent points?", "Convert Quondams", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                TtUtils.ShowWaitCursor();
                try
                {
                    foreach (ListViewItem item in lstPoints.Items)
                    {
                        bool removeFirstLink = false;

                        if (item.Checked)
                        {
                            string pointCN = item.SubItems[4].Text;
                            TtPoint point = Points[CurrPoly.CN][pointCN];

                            if (point.op == OpType.Quondam)
                            {
                                QuondamPoint qp = (QuondamPoint)point;
                                TtPoint Parent = qp.ParentPoint;

                                while (true)
                                {
                                    if (Parent != null)
                                    {
                                        if (Parent.op == OpType.Quondam)
                                        {
                                            if (!removeFirstLink)
                                            {
                                                Points[Parent.PolyCN][Parent.CN].RemoveQuondamLink(qp.CN);
                                                removeFirstLink = true;
                                            }

                                            Parent = ((QuondamPoint)Parent).ParentPoint;
                                        }
                                        else
                                        {
                                            TtPoint NewPoint = TtUtils.CopyPoint(Parent);

                                            NewPoint.CopyInfo(qp);

                                            NewPoint.RemoveQuondamLink(qp.CN);  //remove quondam that that linked to the point

                                            if (qp.Comment != null && qp.Comment != "")
                                            {
                                                NewPoint.Comment = qp.Comment;
                                            }

                                            if (!removeFirstLink)
                                            {
                                                if (Parent.PolyCN == CurrPoly.CN)
                                                    Points[CurrPoly.CN][Parent.CN].RemoveQuondamLink(qp.CN);
                                                else
                                                    Points[Parent.PolyCN][Parent.CN].RemoveQuondamLink(qp.CN);

                                                removeFirstLink = true;
                                            }

                                            Points[CurrPoly.CN][pointCN] = TtUtils.CopyPoint(NewPoint);

                                            if (NewPoint.IsGpsType())
                                            {
                                                List<GpsAccess.NmeaBurst> nmea = DAL.GetNmeaBurstsByPointCN(Parent.CN);
                                                DAL.SaveNmeaBursts(nmea, NewPoint.CN);
                                            }

                                            _DeleteNmea.Add(NewPoint.CN);
                                            break;
                                        }


                                    }
                                    else
                                    {
                                        //parent null
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "MassEditFormLogic:Convert");
                    MessageBox.Show("Quondam Conversion Error");
                }
                TtUtils.HideWaitCursor();

                LoadPolygon();
                _recalc = true;
            }
        }

        private void btnSave_Click2(object sender, EventArgs e)
        {
            if (MessageBox.Show("Points will automaticly be renamed before saving. Continue?",
                "Auto Renaming", MessageBoxButtons.YesNo, MessageBoxIcon.Hand,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                TtUtils.ShowWaitCursor();
                try
                {
                    foreach (string polyCN in Points.Keys)
                    {

                        List<TtPoint> points = Points[polyCN].Values.ToList();
                        List<TtPoint> oldPoints = OldPoints[polyCN].Values.ToList();

                        for (int i = 0; i < points.Count; i++)
                        {
                            points[i].Index = i;
                        }

                        if (points.Count > 0)
                        {
                            PointNaming.RenamePoints(ref points, Polygons[polyCN]);
                        }

                        DAL.SavePoints(oldPoints, points);
                    }

                    this.DialogResult = DialogResult.OK;

                    _DeleteNmea = new List<string>();
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "MassEditFormLogic:Save");
                    this.DialogResult = DialogResult.Cancel;
                }
                TtUtils.HideWaitCursor();

                if (_recalc)
                {
                    TtUtils.ShowWaitCursor();
                    PolygonAdjuster.Adjust(DAL);
                    TtUtils.HideWaitCursor();
                }
            }

            this.Close();
        }

        private void btnExit_Click2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAll_CheckStateChanged2(object sender, EventArgs e)
        {
            bool check = chkAll.Checked;

            foreach (ListViewItem item in lstPoints.Items)
            {
                item.Checked = check;
            }
        }

        private void btnDel_Click2(object sender, EventArgs e)
        {
            List<string> items = new List<string>();

            if (MessageBox.Show("You are about to delete points. Continue?", "Delete Points", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                TtUtils.ShowWaitCursor();
                foreach (ListViewItem item in lstPoints.Items)
                {
                    if (item.Checked)
                    {
                        items.Add(item.SubItems[4].Text);
                    }
                }

                if (items.Count > 0)
                {
                    foreach (string item in items)
                    {
                        try
                        {
                            if (Points[CurrPoly.CN].ContainsKey(item))
                            {
                                TtPoint point = Points[CurrPoly.CN][item];

                                point.CN = Values.MainGroup.CN;
                                point.GroupName = Values.MainGroup.Name;

                                /*
                                if (!point.GroupCN.IsEmpty())
                                {
                                    Values.GroupManager.Groups[point.GroupCN].RemovePointFromGroup(point);
                                }
                                */

                                DAL.DeletePoint(point);
                            }
                        }
                        catch (Exception ex)
                        {
                            TtUtils.WriteError(ex.Message, "MassEditFormLogic:Delete");
                        }
                    }

                    Init(DAL);
                    _recalc = true;
                }
                TtUtils.HideWaitCursor();
            }
        }

        private void btnBnd_Click2(object sender, EventArgs e)
        {
            string strOn;

            onBnd = !onBnd;
            if(onBnd)
            {
                strOn = "On";
            }
            else
            {
                strOn = "Off";
            }

            btnBnd.Text = strOn;

            foreach (ListViewItem item in lstPoints.Items)
            {
                if (item.Checked)
                {
                    string pointCN = item.SubItems[4].Text;
                    TtPoint point = Points[CurrPoly.CN][pointCN];

                    Points[CurrPoly.CN][pointCN].OnBnd = onBnd;
                    item.SubItems[3].Text = strOn;
                }
            }

            _recalc = true;
        }
        #endregion

    }
}