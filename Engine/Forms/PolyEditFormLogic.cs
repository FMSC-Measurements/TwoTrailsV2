using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;
using TwoTrails.BusinessLogic;
using TwoTrails.Engine;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class PolyEditForm : Form
    {
        private DataAccessLayer DAL { get; set; }

        private TtPolygon CurrentPolygon { get; set; }
        private List<string> CNs { get; set; }

        private TtPolygon UpdatedPolygon
        {
            get
            {
                return _updatedPolygon;
            }
            set
            {
                _updatedPolygon = value;
                if (value != null)
                {
                    chkLock.Enabled = true;
                    textBoxDesc.Text = _updatedPolygon.Description;
                    textBoxID.Text = _updatedPolygon.Name;
                    txtPerimMet.Text = _updatedPolygon.Perimeter.ToString("0.###    ");
                    txtPerimFt.Text = TtUtils.ConvertToFeetTenths(_updatedPolygon.Perimeter, Unit.METERS).ToString("0.###");
                    txtAreaHA.Text = TtUtils.ConvertMeters2ToHa(_updatedPolygon.Area).ToString("0.#####");
                    txtAreaAC.Text = TtUtils.ConvertMeters2ToAcres(_updatedPolygon.Area).ToString("0.#####");
                    txtInc.Text = _updatedPolygon.IncrementBy.ToString();
                    txtStartIndex.Text = _updatedPolygon.PointStartIndex.ToString();

                    //dependent
                    if (_updatedPolygon.PolyAccu == null || _updatedPolygon.PolyAccu < 0)
                        txtPolyAcc.Text = "";
                    else
                        txtPolyAcc.Text = _updatedPolygon.PolyAccu.ToString();
                }
                else
                {
                    _locked = true;
                    chkLock.Enabled = false;
                    textBoxDesc.Text = "";
                    textBoxID.Text = "";
                    txtPerimMet.Text = "";
                    txtPerimFt.Text = "";
                    txtAreaHA.Text = "";
                    txtAreaAC.Text = "";
                    txtPolyAcc.Text = "";
                    txtInc.Text = "";
                    txtStartIndex.Text = "";
                }

            }
        }
        private List<TtPolygon> Polygons { get; set; }

        bool _ignoreStateChange, _ignoreMakeDirty = false, _locked;

        #region members
        private bool _dirty, _recalc;
        private TtPolygon _updatedPolygon;
        #endregion

        public PolyEditForm(DataAccessLayer data)
        {
            DAL = data;

#if (PocketPC || WindowsCE || Mobile)
            if(Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();
#else
            InitializeComponent();
#endif

            actionsControlPolygons.MiscButtonEnabled = false;
            actionsControlPolygons.MiscButtonText = "Dup";

            _dirty = false;
            _recalc = false;
        }

        private void LoadPolys()
        {
            Polygons = DAL.GetPolygons();
            CNs = new List<string>();
            int index = Polygons.Count - 1;

            if (Polygons != null && Polygons.Count > 0)
            {
                CurrentPolygon = Polygons[index];
                UpdatedPolygon = new TtPolygon(CurrentPolygon);
                _dirty = false;

                for (int i = 0; i < Polygons.Count; i++)
                {
                    CNs.Add(Polygons[i].CN);
                }

                actionsControlPolygons.MiscButtonEnabled = true;
            }
            else
            {
                CurrentPolygon = null;
                UpdatedPolygon = null;
                _dirty = false;
                Lock(true);
            }

            pointNavigationCtrl1.UpdatePointList(CNs, index);
            AdjustNavControls(index);

            Lock(true);
        }

        private void AdjustNavControls(int index)
        {
            pointNavigationCtrl1.UpdateIndex(index);

            if (index > 0 && CNs.Count > 1)
            {
                pointNavigationCtrl1.BackwardButtons = true;
            }
            else
            {
                pointNavigationCtrl1.BackwardButtons = false;
            }

            if (index < CNs.Count - 1 && CNs.Count > 1)
            {
                pointNavigationCtrl1.ForwardButtons = true;
            }
            else
            {
                pointNavigationCtrl1.ForwardButtons = false;
            }
        }

        #region actionsControl Click Events

        private void actionsControlPolygons_Cancel_OnClick2(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void actionsControlPolygons_DeleteClicked_OnClick2(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to delete this polygon. All points associated with this polygon will be deleted. All Quondams associated with points in this polygon with be converted to their parent values. Do you want to delete?",
                "Delete Polygon", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                TtUtils.ShowWaitCursor();
                try
                {
                    List<TtPoint> PolyPoints = DAL.GetPointsInPolygon(UpdatedPolygon);

                    foreach (TtPoint point in PolyPoints)
                    {
                        TtPoint EditPoint, OldPoint, TargetPoint;

                        if (point.op == OpType.Quondam)
                        {
                            EditPoint = DAL.GetPoint(((QuondamPoint)point).ParentCN);
                            if (EditPoint != null)
                            {
                                OldPoint = TtUtils.CopyPoint(EditPoint);

                                EditPoint.RemoveQuondamLink(point.CN);
                                DAL.SavePoint(OldPoint, EditPoint);
                            }
                        }

                        if (point.HasQuondamLinks)
                        {
                            foreach (string childCN in point.LinkedPoints)
                            {
                                EditPoint = DAL.GetPoint(childCN);

                                if (EditPoint != null)
                                {
                                    if (point.op == OpType.Quondam)
                                    {
                                        TargetPoint = (QuondamPoint)(TtUtils.CopyPoint(point));
                                        while (TargetPoint.op == OpType.Quondam)
                                        {
                                            TargetPoint = DAL.GetPoint(((QuondamPoint)TargetPoint).ParentCN);

                                            if (TargetPoint == null)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        TargetPoint = TtUtils.CopyPoint(point);
                                    }

                                    if (TargetPoint != null)
                                    {
                                        TargetPoint.CopyInfo(EditPoint);
                                        DAL.SavePoint(EditPoint, TargetPoint);
                                    }
                                }
                            }
                        }

                        DAL.DeletePoint(point);
                    }

                    DAL.DeletePolygon(UpdatedPolygon.CN);

                    LoadPolys();
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "PolyEditForm:Delete", ex.StackTrace);
                    MessageBox.Show("Error Deleteing Polygon.");
                }

                TtUtils.HideWaitCursor();
                _recalc = true;
            }
        }

        private void actionsControlPolygons_MiscClicked_OnClick2(object sender, EventArgs e)
        {
            if (CurrentPolygon != null &&
                MessageBox.Show("Would you like to duplicate this Polygon?", "Duplicate Polygon",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SaveCurrentPolygon();

                TtPolygon p = new TtPolygon();

                int num = 0;
                if (Polygons.Count > 0)
                {
                    try
                    {
                        num = (int)TtUtils.GetEndingNumber(Polygons.Last().Name);
                    }
                    catch
                    {
                        num = Polygons.Count;
                    }

                    num++;
                    p.Name = string.Format("{0} Copy", CurrentPolygon.Name);

                    TtPolygon lastPoly = Polygons[Polygons.Count - 1];

                    int numInLastPoly = DAL.GetNumberOfPointsinPolygon(lastPoly.CN);

                    p.PointStartIndex = (((numInLastPoly * lastPoly.IncrementBy) / 1000) * 1000) + num * 1000 + 10;
                }

                p.PolyAccu = CurrentPolygon.PolyAccu;

                CNs.Add(p.CN);
                Polygons.Add(p);

                TtPolygon oldPoly = CurrentPolygon;
                DAL.InsertPolygon(p);
                UpdatedPolygon = null;
                CurrentPolygon = p;

                List<TtPoint> points = new List<TtPoint>();
                TtPoint newPoint, oldPoint = null;
                foreach (TtPoint point in DAL.GetPointsInPolygon(oldPoly))
                {
                    newPoint = TtUtils.ClonePoint(point);
                    newPoint.PID = PointNaming.NamePoint(oldPoint, CurrentPolygon);
                    newPoint.PolyCN = CurrentPolygon.CN;
                    newPoint.PolyName = CurrentPolygon.Name;
                    points.Add(newPoint);
                    oldPoint = newPoint;
                }

                DAL.InsertPoints(points);

                LoadPolys();
                Lock(false);
                _recalc = true;
            }
        }

        private void actionsControlPolygons_NewClicked_OnClick2(object sender, EventArgs e)
        {
            SaveCurrentPolygon();

            TtPolygon p = new TtPolygon();
            CurrentPolygon = null; 

            int num = 0;
            if (Polygons.Count > 0)
            {
                //try
                //{
                //    num = (int)TtUtils.GetEndingNumber(Polygons.Last().Name);
                //}
                //catch
                //{
                //    num = Polygons.Count;
                //}

                //num++;
                num = Polygons.Count + 1;

                p.Name = string.Format("Poly {0}", num);

                TtPolygon lastPoly = Polygons[Polygons.Count - 1];

                int numInLastPoly = DAL.GetNumberOfPointsinPolygon(lastPoly.CN);

                p.PointStartIndex = (((numInLastPoly * lastPoly.IncrementBy) / 1000) * 1000) + num * 1000 + 10;
            }
            else
            {
                p.Name = "Poly 1";
                p.PointStartIndex = 1010;
            }

            p.PolyAccu = Values.Settings.DeviceOptions.DEFAULT_POINT_ACCURACY;

            UpdatedPolygon = p;

            CNs.Add(p.CN);
            Polygons.Add(p);

            pointNavigationCtrl1.UpdatePointList(CNs, CNs.Count - 1);
            AdjustNavControls(CNs.Count - 1);
            Lock(false);
            _recalc = true;
        }

        private void SaveCurrentPolygon()
        {
            if (UpdatedPolygon != null && _dirty)
            {
                if (UpdatedPolygon.Name == null || UpdatedPolygon.Name == "")
                {
                    UpdatedPolygon.Name = UpdatedPolygon.CN;
                }

                DAL.SavePolygon(CurrentPolygon, UpdatedPolygon);

                _dirty = false;
#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusText("Polygon Saved");
#endif
            }
        }

        private void actionsControlPolygons_OkClicked_OnClick2(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SaveCurrentPolygon();

            if (_recalc)
            {
                TtUtils.ShowWaitCursor();
                PolygonAdjuster.Adjust(DAL, true);
                TtUtils.HideWaitCursor();
            }

            this.Close();
        }
        #endregion

        private void PolyEditForm_Load2(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;
            LoadPolys();
        }

        #region DAL edited
        private void textBoxID_TextChanged2(object sender, EventArgs e)
        {
            if (!textBoxID.Text.IsEmpty())
            {
                UpdatedPolygon.Name = textBoxID.Text;
            }

            MarkDirty();
        }

        private void textBoxDesc_TextChanged2(object sender, EventArgs e)
        {
            if (!textBoxDesc.Text.IsEmpty())
            {
                UpdatedPolygon.Description = textBoxDesc.Text;
            }

            MarkDirty();
        }

        private void txtPolyAcc_TextChanged2(object sender, EventArgs e)
        {
            double acc = -1;

            try
            {
                if (txtPolyAcc.Text.IsEmpty())
                    _updatedPolygon.PolyAccu = null;
                else
                {
                    if (txtPolyAcc.Text.IsDouble())
                    {
                        acc = txtPolyAcc.Text.ToDouble();

                        if (acc >= 0)
                        {
                            _updatedPolygon.PolyAccu = acc;
                            _dirty = true;
                        }
                        else
                            MessageBox.Show("Accuracy must be a positive number.");
                    }
                    else
                        txtPolyAcc.Text = _updatedPolygon.PolyAccu.ToString();
                }
            }
            catch
            {
                //
            }
        }

        private void txtInc_TextChanged2(object sender, EventArgs e)
        {
            if (!txtInc.Text.IsEmpty())
            {
                if (txtInc.Text.IsInteger())
                {
                    _updatedPolygon.IncrementBy = Convert.ToInt32(txtInc.Text);

                    MarkDirty();
                }
                else
                    txtInc.Text = UpdatedPolygon.IncrementBy.ToString();
            }
        }

        private void txtStartIndex_TextChanged2(object sender, EventArgs e)
        {
            if (!txtStartIndex.Text.IsEmpty() && txtStartIndex.Text.IsInteger())
            {
                int ib = Convert.ToInt32(txtStartIndex.Text);

                if (ib >= 0)
                {
                    _updatedPolygon.PointStartIndex = ib;

                    MarkDirty();
                }
            }

            MarkDirty();
        }

        private void MarkDirty()
        {
            if (!_ignoreMakeDirty)
            {
                _dirty = true;
                _recalc = true;
            }
        }
        #endregion


        private void Lock(bool lockControls)
        {
            _locked = lockControls;
            _ignoreStateChange = true;

#if (PocketPC || WindowsCE || Mobile)
            textBoxDesc.ReadOnly = lockControls;
            textBoxID.ReadOnly = lockControls;
            txtPolyAcc.ReadOnly = lockControls;
            txtStartIndex.ReadOnly = lockControls;
            txtInc.ReadOnly = lockControls;
            chkLock.Checked = lockControls;
#else
            textBoxDesc.Enabled = !lockControls;
            textBoxID.Enabled = !lockControls;
            txtPolyAcc.Enabled = !lockControls;
            txtStartIndex.Enabled = !lockControls;
            txtInc.Enabled = !lockControls;
            chkLock.Checked = lockControls;
#endif
            actionsControlPolygons.DeleteEnabled = !lockControls;

            _ignoreStateChange = false;
        }

        #region Controls
        private void bindingSourcePoly_CurrentChanged2(object sender, EventArgs e)
        {

        }

        private void textBoxID_GotFocus2(object sender, EventArgs e)
        {
            if (!_locked)
                Kb.ShowRegular(this, textBoxID);
        }

        private void textBoxID_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void textBoxDesc_GotFocus2(object sender, EventArgs e)
        {
            if (!_locked)
                Kb.ShowRegular(this, textBoxDesc);
        }

        private void textBoxDesc_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void PolyEditForm_GotFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtPolyAcc_GotFocus2(object sender, EventArgs e)
        {
            if (!_locked)
                Kb.ShowRegular(this, txtPolyAcc);
        }

        private void txtPolyAcc_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtInc_GotFocus2(object sender, EventArgs e)
        {
            if (!_locked)
                Kb.ShowNumeric(this, txtInc);
        }

        private void txtInc_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtStartIndex_GotFocus2(object sender, EventArgs e)
        {
            if (!_locked)
                Kb.ShowRegular(this, txtStartIndex);
        }

        private void txtStartIndex_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void chkLock_CheckStateChanged2(object sender, EventArgs e)
        {
            if(!_ignoreStateChange && UpdatedPolygon != null)
                Lock(chkLock.Checked);
        }
        #endregion


        private void pointNavigationCtrl1_IndexChanged2(object sender, TwoTrails.Controls.PointNavigationCtrl.PointNavEventArgs e)
        {
            SaveCurrentPolygon();

            _ignoreMakeDirty = true;

            int index = CNs.IndexOf(e.NextPointCN);

            if (index > -1 && index < Polygons.Count)
            {
                CurrentPolygon = Polygons[index];
                UpdatedPolygon = CurrentPolygon;
                AdjustNavControls(index);
                actionsControlPolygons.MiscButtonEnabled = true;
            }
            else
            {
                actionsControlPolygons.MiscButtonEnabled = false;
            }

            Lock(true);

            Kb.Hide(this);

            _ignoreMakeDirty = false;
        }

        private void pointNavigationCtrl1_JumpPoint2(object sender)
        {
            //
        }
    }
}
