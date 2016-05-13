using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;
using TwoTrails.DataAccess;
using TwoTrails.Utilities;
using TwoTrails.BusinessObjects;
using TwoTrails.BusinessLogic;

namespace TwoTrails.Forms
{
    public partial class RenamePointForm : Form
    {
        List<TtPolygon> _Polygons;
        List<List<TtPoint>> _Points;

        DataAccessLayer DAL;

        TtPolygon CurrPoly;
        TtPoint CurrPoint;

        int _currPointIndex;
        bool _init = false;

        int CurrPolyIndex;
        int CurrPointIndex
        {
            get { return _currPointIndex; }
            set
            {
                _currPointIndex = value;

                if (value > -1)
                {
                    CurrPoint = _Points[CurrPolyIndex][_currPointIndex];
                    txtPID.Text = CurrPoint.PID.ToString();
                }
                else
                {
                    CurrPoint = null;
                    txtPID.Text = "";
                }
            }
        }

        bool _dirty;
        bool _recalc;

        public void Init()
        {
            this.Icon = Properties.Resources.Map;
            this.DialogResult = DialogResult.Cancel;
            _dirty = false;
            _recalc = false;

            _Polygons = DAL.GetPolygons();
            _Points = new List<List<TtPoint>>();

            CurrPoint = null;
            CurrPoly = null;
            CurrPointIndex = -1;
            CurrPolyIndex = -1;

#if (PocketPC || WindowsCE || Mobile)
            if (Values.Settings.DeviceOptions.UseSelection)
            {
                btnPoly.Visible = true;
                cboPoly.Visible = false;
            }
            else
            {
                btnPoly.Visible = false;
                cboPoly.Visible = true;
            }
#endif
            if (_Polygons.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _Polygons.Count; i++)
                    {
                        _Points.Add(DAL.GetPointsInPolygon(_Polygons[i].CN));
                        cboPoly.Items.Add(_Polygons[i].Name);
                    }

                    CurrPolyIndex = 0;
                    CurrPoly = _Polygons[CurrPolyIndex];

                    cboPoly.SelectedIndex = CurrPolyIndex;

#if (PocketPC || WindowsCE || Mobile)
                    btnPoly.Text = cboPoly.Text;
#endif
                
                    if (_Points[0].Count > 0)
                    {
                        foreach (TtPoint point in _Points[0])
                        {
                            lstPoints.Items.Add(point.PID);
                        }

                        CurrPointIndex = 0;

                        txtPID.Text = CurrPoint.PID.ToString();
                    }

                    _init = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("No Polygons Available");
                this.DialogResult = DialogResult.Abort;
            }
        }


        private void LoadPolygon()
        {
            lstPoints.Items.Clear();

            foreach (TtPoint point in _Points[CurrPolyIndex])
            {
                lstPoints.Items.Add(point.PID);
            }

            CurrPoly = _Polygons[CurrPolyIndex];

            if (_Points[CurrPolyIndex].Count > 0)
            {
                CurrPointIndex = 0;
            }
            else
            {
                CurrPointIndex = -1;
            }
        }

        #region Controls
        private void txtPID_TextChanged2(object sender, EventArgs e)
        {
            if (CurrPoint != null)
            {
                int pos = txtPID.SelectionStart;

                if (txtPID.Text.IsInteger())
                    CurrPoint.PID = txtPID.Text.ToInteger();
                lstPoints.Items[CurrPointIndex] = CurrPoint.PID;
                txtPID.SelectionStart = pos;
                _recalc = true;
                _dirty = true;
            }
        }

        private void btnCancel_Click2(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            GC.Collect();
        }

        private void btnAuto_Click2(object sender, EventArgs e)
        {
            DialogResult dr;

            if (CurrPoly != null)
            {
                dr = MessageBox.Show("You are about to rename all the points in " + CurrPoly.Name + ".", "Rename Points", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.OK)
                {
                    List<TtPoint> tmp = _Points[CurrPolyIndex];

                    PointNaming.RenamePoints(ref tmp, CurrPoly);

                    _Points[CurrPolyIndex] = tmp;

                    LoadPolygon();
                    _dirty = true;
                    _recalc = true;
                }
            }
        }

        private void btnOk_Click2(object sender, EventArgs e)
        {
            if (_dirty)
            {
                TtUtils.ShowWaitCursor();
                try
                {
                    foreach (List<TtPoint> pointList in _Points)
                    {
                        DAL.SavePoints(pointList);
                    }

                    if (_recalc)
                    {
                        TtUtils.ShowWaitCursor();
                        PolygonAdjuster.Adjust(DAL);
                        TtUtils.HideWaitCursor();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "REnamePointFormLogic:Ok-savepoints", ex.StackTrace);
                }
                TtUtils.HideWaitCursor();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }

            GC.Collect();
        }

        private void btnFirst_Click2(object sender, EventArgs e)
        {
            if (CurrPointIndex > 0)
            {
                for (int i = 0; i < CurrPointIndex; i++)
                {
                    _Points[CurrPolyIndex][i].Index++;
                }

                _Points[CurrPolyIndex][CurrPointIndex].Index = 0;

                _Points[CurrPolyIndex].Insert(0, _Points[CurrPolyIndex][CurrPointIndex]);
                _Points[CurrPolyIndex].RemoveAt(CurrPointIndex + 1);

                LoadPolygon();

                CurrPointIndex = 0;
                _dirty = true;
                _recalc = true;
            }
        }

        private void btnUp_Click2(object sender, EventArgs e)
        {
            if (CurrPointIndex > 0)
            {
                long tempIndex = _Points[CurrPolyIndex][CurrPointIndex - 1].Index;

                _Points[CurrPolyIndex][CurrPointIndex - 1].Index = _Points[CurrPolyIndex][CurrPointIndex].Index;
                _Points[CurrPolyIndex][CurrPointIndex].Index = tempIndex;

                _Points[CurrPolyIndex].Insert(CurrPointIndex - 1, _Points[CurrPolyIndex][CurrPointIndex]);
                _Points[CurrPolyIndex].RemoveAt(CurrPointIndex + 1);

                string tempName = lstPoints.Items[CurrPointIndex -1].ToString();

                lstPoints.Items[CurrPointIndex - 1] = lstPoints.Items[CurrPointIndex];
                lstPoints.Items[CurrPointIndex] = tempName;

                lstPoints.SelectedIndex = CurrPointIndex - 1;
                _dirty = true;
                _recalc = true;
            }
        }

        private void btnDown_Click2(object sender, EventArgs e)
        {
            if (CurrPointIndex < _Points[CurrPolyIndex].Count - 1)
            {
                long tempIndex = _Points[CurrPolyIndex][CurrPointIndex + 1].Index;

                _Points[CurrPolyIndex][CurrPointIndex + 1].Index = _Points[CurrPolyIndex][CurrPointIndex].Index;
                _Points[CurrPolyIndex][CurrPointIndex].Index = tempIndex;

                _Points[CurrPolyIndex].Insert(CurrPointIndex + 2, _Points[CurrPolyIndex][CurrPointIndex]);
                _Points[CurrPolyIndex].RemoveAt(CurrPointIndex);

                string tempName = lstPoints.Items[CurrPointIndex + 1].ToString();

                lstPoints.Items[CurrPointIndex + 1] = lstPoints.Items[CurrPointIndex];
                lstPoints.Items[CurrPointIndex] = tempName;

                lstPoints.SelectedIndex = CurrPointIndex + 1;
                _dirty = true;
                _recalc = true;
            }
        }
        
        private void btnLast_Click2(object sender, EventArgs e)
        {
            int numOfItems = _Points[CurrPolyIndex].Count;

            if (CurrPointIndex < numOfItems - 1)
            {
                for (int i = CurrPointIndex + 1; i < numOfItems; i++)
                {
                    _Points[CurrPolyIndex][i].Index--;
                }

                _Points[CurrPolyIndex][CurrPointIndex].Index = _Points[CurrPolyIndex][numOfItems -1].Index + 1;

                _Points[CurrPolyIndex].Add(_Points[CurrPolyIndex][CurrPointIndex]);
                _Points[CurrPolyIndex].RemoveAt(CurrPointIndex);

                LoadPolygon();

                CurrPointIndex = numOfItems - 1;
                _dirty = true;
                _recalc = true;
            }
        }

        private void lstPoints_SelectedIndexChanged2(object sender, EventArgs e)
        {
            CurrPointIndex = lstPoints.SelectedIndex;
        }

        private void cboPoly_SelectedIndexChanged2(object sender, EventArgs e)
        {
            if (_init)
            {
                CurrPolyIndex = cboPoly.SelectedIndex;
#if (PocketPC || WindowsCE || Mobile)
                btnPoly.Text = cboPoly.Text;
#endif
                LoadPolygon();
            }
        }

#if (PocketPC || WindowsCE || Mobile)
        private void btnPoly_Click2(object sender, EventArgs e)
        {
            List<string> opts = new List<string>();

            foreach(TtPolygon poly in _Polygons)
            {
                opts.Add(poly.Name);
            }

            using (Selection form = new Selection("Select Polygon", opts, cboPoly.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cboPoly.SelectedIndex = form.selection;
                }
            }
        }
#endif

        #endregion
    }
}