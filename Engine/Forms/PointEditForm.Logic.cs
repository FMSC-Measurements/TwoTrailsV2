using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.BusinessLogic;
using TwoTrails.Utilities;
using TwoTrails.DataAccess;
using TwoTrails.Engine;
using TwoTrails.LaserAccess;
using TwoTrails.Controls;

namespace TwoTrails.Forms
{
    public partial class PointEditForm : Form
    {
        #region Vars

        private DataAccessLayer DAL;

        private List<TtPolygon> _Polygons;
        private List<TtPoint> _Points;
        private List<string> _PointCNs;
        private List<TtMetaData> _Meta;
        private List<string> _MetaCNs;
        private Dictionary<string, TtGroup> _Groups;

        private int _NumOfPoly;

        TtMetaData CurrMeta;

        private TtPolygon CurrPoly;
        private string CurrPolyCN;

        private TtPoint CurrPoint;
        private int CurrPointIndex;

        private TtPoint _UpdatedPoint;
        private TtPoint UpdatedPoint
        {
            get { return _UpdatedPoint; }
            set
            {
                _UpdatedPoint = value;
                if (_UpdatedPoint == null)
                {
                    LockControls(true);
                    CurrMeta = _Meta[0];
                }
                else
                {
                    int pos = -1;
                    pos = _MetaCNs.IndexOf(_UpdatedPoint.MetaDefCN);

                    if (pos > -1)
                        CurrMeta = _Meta[pos];
                    else
                        CurrMeta = _Meta[0];
                }
            }
        }

        private bool _adjust, dirty, reloadQuondamList, loaded = false, _closing = false;

        private bool _dirty
        {
            get { return dirty; }
            set
            {
                if (_init)
                {
                    dirty = value;
                    _adjust = true;
                    reloadQuondamList = true;
                }
            }
        }

        private bool _init, _saving = false;

        #endregion

        public void UpdateDAL(DataAccessLayer dal)
        {
            if (dal == null)
                throw new Exception("Null DAL");
            DAL = dal;
        }

        public void Init()
        {
            TtUtils.ShowWaitCursor();

            loaded =  _saving = _closing = false;
            _adjust = dirty = reloadQuondamList = false;

            _init = false;

            _Groups = DAL.GetGroups().ToDictionary(g => g.CN, g => g);
            _Polygons = DAL.GetPolygons();
            _NumOfPoly = _Polygons.Count;

            _Points = new List<TtPoint>();
            _PointCNs = new List<string>();
            _Meta = new List<TtMetaData>();
            _MetaCNs = new List<string>();

            pointInfoCtrl.ReadOnly = true;

            if (_NumOfPoly > 0)
            {
                //Setup Point Info Control with the Polygon List
                pointInfoCtrl.SetPolygons(_Polygons);

                //Set Current Polygon
                CurrPoly = _Polygons[0];
                CurrPolyCN = CurrPoly.CN;

                _Meta = DAL.GetMetaData();
                foreach (TtMetaData m in _Meta)
                {
                    _MetaCNs.Add(m.CN);
                }
                pointInfoCtrl.SetMetaDefs(_Meta);
                CurrMeta = _Meta[0];

                CurrPointIndex = -1;
                CurrPoint = null;
                UpdatedPoint = null;
                CurrPointIndex = -1;

                //Load Points, move to last one then update the navigation control with that info
                _init = true;
                ChangePolygon();
                LoadPoints();
                MoveToLastPoint();
                pointNavigationCtrl.UpdatePointList(_PointCNs, CurrPointIndex);

                //setup Quondam Control
                quondamInfoControl1.DAL = DAL;
                quondamInfoControl1.Polygons = _Polygons;

                //Show correct Point Control
                DisplayPointCtrl();
                actionsControl.NewEnabled = true;
            }
            else
            {
                CurrPointIndex = -1;
                pointInfoCtrl.CheckLockEnabled = false;

                //dont create new points if no polygons
                actionsControl.MiscButtonEnabled = false;
                actionsControl.DeleteEnabled = false;
                actionsControl.NewEnabled = false;
            }

            _dirty = false;
            _adjust = false;
            reloadQuondamList = false;

            gpsInfoControl1.Visible = false;
            quondamInfoControl1.Visible = false;
            travInfoControl1.Visible = false;
            walkInfoCtrl1.Visible = false;
            take5InfoCtrl1.Visible = false;

            TtUtils.HideWaitCursor();
        }

        private void LoadPoints()
        {
            if (_init)
            {
                _Points = DAL.GetPointsInPolygon(CurrPolyCN);
                _PointCNs.Clear();

                for (int i = 0; i < _Points.Count; i++)
                {
                    _PointCNs.Add(_Points[i].CN);
                }
            }
        }

        private bool Save()
        {
            if (_adjust && !_saving)
            {
                if (PolygonAdjuster.CanAdjust(DAL))
                {
                    TtUtils.ShowWaitCursor();
                    _saving = true;
#if (PocketPC || WindowsCE || Mobile)
                    AutoClosingMessageBox.Show("Adjusting Polygons", "Data Adjustments", 500);
#endif
                    PolygonAdjuster.Adjust(DAL, true, this);
                    return true;
                }
                else
                {
                    AutoClosingMessageBox.Show("Polygons can not adjust. Please see error log for details.", "Can't Adjust", 3000);
                }
            }

            return false;
        }

        private void PointEditForm_Closing2(object sender, CancelEventArgs e)
        {
            if(Values.LaserA.IsBusy)
                Values.LaserA.CloseLaser();

            Values.LastEditedPolygonCN = CurrPolyCN;

            _closing = true;

            GC.Collect();
        }

        private void PointEditForm_Load2(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;

            /*
            if (_Polygons.Count < 1)
            {
                MessageBox.Show("There are no Polygons in this project. Please go to the Polygon form to create a new polygon.");
                this.Close();
            }
            else
            {
                */
                if (!Values.LastEditedPolygonCN.IsEmpty())
                {
                    for (int i = 0; i < _Polygons.Count; i++)
                    {
                        if (_Polygons[i].CN == Values.LastEditedPolygonCN)
                        {
                            ChangePolygon(Values.LastEditedPolygonCN);
                            break;
                        }
                    }
                }
            //}
            loaded = true;

            //Adjust the Navigation controls for the position of the current point
            DisplayPointCtrl();
            AdjustNavControls();

            LockControls(true);

            _saving = false;
        }

        #region Save/Create/Copy/Delete Points

        private bool SavePoint()
        {
            return SavePoint(false);
        }

        private bool SavePoint(bool ovrride)
        {
            bool _saved = false;

            if (UpdatedPoint != null && _init)
            {
                bool phv = TtUtils.PointHasValue(UpdatedPoint);

                if ((_dirty && phv) || ovrride) // there is a point to save
                {
                    try
                    {
                        TtPoint SavePoint = TtUtils.CopyPoint(_UpdatedPoint);

                        SaveConversion(ref SavePoint);

                        if (SavePoint.op != OpType.Quondam)
                        {
                            TtPolygon p = CurrPoly;
                            SavePoint.PolyCN = p.CN;
                            SavePoint.PolyName = p.Name;

                            DAL.SavePoint(CurrPoint, SavePoint);

                            if (_Points.Count > CurrPointIndex)
                            {
                                _Points[CurrPointIndex] = TtUtils.CopyPoint(SavePoint);
                            }

                            CurrPoint = TtUtils.CopyPoint(SavePoint);

                            _saved = true;
                        }
                        else if (SavePoint.op == OpType.Quondam && ((QuondamPoint)SavePoint).ParentPoint != null)
                        {
                            TtPoint parent = ((QuondamPoint)SavePoint).ParentPoint;

                            if (parent != null)
                            {
                                SavePoint.UnAdjX = parent.UnAdjX;
                                SavePoint.UnAdjY = parent.UnAdjY;
                                SavePoint.UnAdjZ = parent.UnAdjZ;
                            }

                            TtPolygon p = CurrPoly;
                            SavePoint.PolyCN = p.CN;
                            SavePoint.PolyName = p.Name;

                            DAL.SavePoint(CurrPoint, SavePoint);

                            //remove old link if in same poly
                            if (CurrPoint != null && CurrPoint.op == UpdatedPoint.op &&
                                ((QuondamPoint)CurrPoint).ParentCN != ((QuondamPoint)SavePoint).ParentCN && ((QuondamPoint)CurrPoint).ParentPoly == CurrPoly.Name)
                            {
                                _Points[_PointCNs.IndexOf(((QuondamPoint)CurrPoint).ParentCN)] = DAL.GetPoint(((QuondamPoint)CurrPoint).ParentCN);
                            }

                            //add new link if in same poly
                            if (((QuondamPoint)SavePoint).ParentPoly == CurrPoly.Name)
                            {
                                _Points[_PointCNs.IndexOf(((QuondamPoint)SavePoint).ParentCN)] = DAL.GetPoint(((QuondamPoint)SavePoint).ParentCN);
                            }

                            if (CurrPointIndex > -1 && CurrPointIndex < _Points.Count)
                                _Points[CurrPointIndex] = TtUtils.CopyPoint(SavePoint);

                            CurrPoint = TtUtils.CopyPoint(SavePoint);

                            _saved = true;
                        }
                        else if (CurrPoint != null)
                        {
                            //dont delete the point, just dont save it either
                            _saved = true;
                        }
                        else
                        {
                            DeletePoint();
                            MessageBox.Show("Quondam Not Saved. No point was selected.", "Point Not Saved",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            _saved = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        TtUtils.WriteError(ex.Message, "PointEditFormLogic:SavePoint");
                        MessageBox.Show("Point Save Error.", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (!phv && UpdatedPoint.IsTravType() && !_closing && CurrPoint != null)
                {
                    SideShotPoint sp = UpdatedPoint as SideShotPoint;
                    if (sp.ForwardAz == null && sp.BackwardAz == null)
                    {
                        MessageBox.Show("Foward Azimuth and/or Backward Azimuth must contain a value.");
                    }
                    else if (sp.SlopeDistance <= 0)
                    {
                       MessageBox.Show("Slope Distance must contain a value greater than 0.");
                    }
                }
            }

            return _saved;
        }

        private void CreateNewPoint()
        {
            OpType currentOp;

            if (UpdatedPoint == null)
                currentOp = OpType.GPS;
            else
                currentOp = UpdatedPoint.op;

            CreateNewPoint(currentOp, true);
        }

        private void CreateNewPoint(OpType currentOp, bool updateScreen)
        {
            CreateNewPoint(currentOp, updateScreen, false);
        }

        private void CreateNewPoint(OpType currentOp, bool updateScreen, bool silentOverride)
        {
            bool phv = TtUtils.PointHasValue(UpdatedPoint);

            if(UpdatedPoint != null)
            {
                if (_dirty && !SavePoint())
                {
                    //failed to save
                    LockControls(false);
                    return;
                }
                else if(!phv)
                {
                    if (!silentOverride)
                    {
                        if (Values.Settings.ProjectOptions.DropZero)
                        {
                            MessageBox.Show("This point has no value. It will not be saved.", "Point has no value.");
                            LockControls(false);
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show("This point has no value. Are you sure you want to create a new point?", "Point has no value.",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                LockControls(false);
                                return;
                            }
                            else
                            {
                                SavePoint(true);
                            }
                        }
                    }
                }
            }

            TtMetaData meta = CurrMeta;
            bool isOnBnd = true;

            if (UpdatedPoint != null)
                isOnBnd = UpdatedPoint.OnBnd;

            CurrPoint = null;

            UpdatedPoint = DAL.GetNewPointByOpType(currentOp);

            UpdatedPoint.CN = Guid.NewGuid().ToString();
            UpdatedPoint.OnBnd = isOnBnd;
            UpdatedPoint.PolyCN = CurrPolyCN;
            UpdatedPoint.PolyName = CurrPoly.Name;
            UpdatedPoint.GroupCN = Values.MainGroup.CN;
            UpdatedPoint.GroupName = Values.MainGroup.Name;

            if (meta != null)
                UpdatedPoint.MetaDefCN = meta.CN;
            else
                UpdatedPoint.MetaDefCN = _Meta[0].CN;

            CurrPointIndex++;
            UpdatedPoint.Index = CurrPointIndex;

            if (CurrPointIndex == _Points.Count)
            {
                if (_Points.Count > 0)
                {
                    UpdatedPoint.PID = PointNaming.NamePoint(_Points[CurrPointIndex - 1], CurrPoly);
                }
                else
                {
                    UpdatedPoint.PID = PointNaming.NameFirstPoint(CurrPoly);
                }

                _PointCNs.Add(UpdatedPoint.CN);
                _Points.Add(UpdatedPoint);
            }
            else
            {

                UpdatedPoint.PID = PointNaming.NameInsertPoint(_Points[CurrPointIndex - 1]);

                //insert point and cn
                _PointCNs.Insert(CurrPointIndex, UpdatedPoint.CN);
                _Points.Insert(CurrPointIndex, UpdatedPoint);
                _dirty = true;

                if (_UpdatedPoint.op == OpType.Quondam)
                {
                    ((QuondamPoint)_UpdatedPoint).ParentPoint = _Points[0];
                }

                SavePoint(true);

                string cCN = UpdatedPoint.CN;
                //for every point after the inserted point, raise the index by 1
                try
                {
                    List<TtPoint> reIndexedPoints = new List<TtPoint>();
                    for (int i = CurrPointIndex + 1; i < _Points.Count; i++)
                    {
                        _Points[i].Index++;

                        reIndexedPoints.Add(_Points[i]);
                    }

                    _adjust = true;
                    DAL.SavePoints(reIndexedPoints);
                    ChangePolygon(false);
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "PointFormEditLogc:CreateNewPoint-Update indexes");
                }
            }

            _dirty = true;

            if (updateScreen)
            {
                reloadQuondamList = true;
                DisplayPointCtrl();
                pointNavigationCtrl.UpdatePointList(_PointCNs, CurrPointIndex);
                AdjustNavControls();
                LockControls(false);
            }

            pointInfoCtrl.FlashPoint = true;
        }

        private void DeletePoint()
        {
            if (CurrPoint != null)
            {
                if (CurrPoint.HasQuondamLinks)
                {
                    if (MessageBox.Show("This point has quondams linked to it. Would you like to convert those quondams into this point?", "Point Quondamed",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        foreach (string childCN in CurrPoint.LinkedPoints)
                        {
                            TtPoint NewPoint, TargetPoint = DAL.GetPoint(childCN);

                            if (TargetPoint != null)
                            {
                                if (UpdatedPoint.op == OpType.Quondam)
                                {
                                    NewPoint = TtUtils.CopyPoint(TargetPoint);
                                    ((QuondamPoint)NewPoint).ParentPoint = ((QuondamPoint)UpdatedPoint).ParentPoint;
                                }
                                else
                                {
                                    NewPoint = TtUtils.CopyPoint(UpdatedPoint);
                                    NewPoint.CopyInfo(TargetPoint);
                                }

                                if (TargetPoint.PolyCN == CurrPolyCN)
                                {
                                    int pointIndex = _PointCNs.IndexOf(TargetPoint.CN);
                                    _Points[pointIndex] = TtUtils.CopyPoint(NewPoint);
                                }

                                DAL.SavePoint(TargetPoint, NewPoint);
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                DAL.DeletePoint(CurrPoint);

                if (CurrPoint.op == OpType.Quondam && TtUtils.PointHasValue(CurrPoint) && ((QuondamPoint)CurrPoint).ParentPoly == CurrPoly.Name)
                {
                    _Points[_PointCNs.IndexOf(((QuondamPoint)CurrPoint).ParentCN)] = DAL.GetPoint(((QuondamPoint)CurrPoint).ParentCN);
                }
            }

            _dirty = false;
            _Points.RemoveAt(CurrPointIndex);
            _PointCNs.RemoveAt(CurrPointIndex);

            if (_Points.Count > 0)
            {
                CurrPoint = null;
                UpdatedPoint = null;

                if (CurrPointIndex == _Points.Count)
                    CurrPointIndex--;

                ChangePoint(CurrPointIndex);
            }
            else
            {
                CurrPointIndex = -1;
                CurrPoint = null;
                UpdatedPoint = null;
            }

            reloadQuondamList = true;
        }
        #endregion

        #region Change Point/Polygon - Adjust Controls

        private void ChangePolygon()
        {
            ChangePolygon(null, true);
        }

        private void ChangePolygon(bool move)
        {
            if(!_closing)
                ChangePolygon(null, move);
        }

        private bool ChangePolygon(string cn)
        {
            if (!_closing)
                return ChangePolygon(cn, true);
            return false;
        }

        private bool ChangePolygon(string cn, bool move)
        {
            if (_closing)
                return false;

            if (_init)
            {
                string temp = null;
                int i = 0;

                if (cn != null)
                {
                    for (i = 0; i < _Polygons.Count; i++)
                    {
                        if (_Polygons[i].CN == cn)
                        {
                            temp = cn;
                            break;
                        }
                    }

                    if (temp == null)
                        return false;
                }
                else
                {
                    temp = pointInfoCtrl.Polygon.CN;
                }


                if (CurrPolyCN != temp)
                {
                    bool movePoint = false;

                    /* Point Can No Longer switch polys in PointEditForm
                    if (!pointInfoCtrl.ReadOnly && TtUtils.PointHasValue(UpdatedPoint))
                    {
                        if (MessageBox.Show("You are about to move this point into another polygon. Would you like to move the point?", "Move Point to new Polygon",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            movePoint = true;
                            SavePoint();
                        }
                        else
                        {
                            MessageBox.Show("Tip: When switching between polygons keep the point locked to prevent moving the point to the new polygon.");
                        }
                    }
                    else
                        */
                        SavePoint();

                    if (cn == null)
                    {
                        CurrPoly = pointInfoCtrl.Polygon;   //set new polygon
                    }
                    else
                    {
                        CurrPoly = _Polygons[i];
                        pointInfoCtrl.SetPolyIndex(i);
                    }

                    CurrPolyCN = CurrPoly.CN;
                    
                    LoadPoints();

                    if (movePoint)
                    {
                        if (_Points.Count > 0)
                        {
                            CurrPointIndex = _Points.Count - 1;
                            UpdatedPoint.Index = _Points[CurrPointIndex].Index + 1;
                        }
                        else
                        {
                            CurrPointIndex = 0;
                            UpdatedPoint.Index = CurrPointIndex;
                        }

                        UpdatedPoint.PolyName = CurrPoly.Name;
                        UpdatedPoint.PolyCN = CurrPoly.CN;
                        _dirty = true;

                        SavePoint();

                        _Points.Add(UpdatedPoint);
                        _PointCNs.Add(UpdatedPoint.CN);
                    }
                    else
                    {
                        _UpdatedPoint = null;
                    }
                }
                else
                {
                    if(move)
                        SavePoint();
                    LoadPoints();
                }

                if (move)
                    MoveToLastPoint();
            }
            else
                return false;

            return true;
        }


        private void DisplayPointCtrl()
        {
            pointInfoCtrl.CurrentPoint = UpdatedPoint;

            if (UpdatedPoint == null)
            {
                pointInfoCtrl.ReadOnly = true;
                DispalyNone();
                return;
            }

            switch (UpdatedPoint.op)
            {
                case OpType.GPS:
                case OpType.WayPoint:
                    {
                        DisplayGPS((GpsPoint)UpdatedPoint);
                        break;
                    }
                case OpType.Traverse:
                case OpType.SideShot:
                    {
                        DisplayTrav((SideShotPoint)UpdatedPoint);
                        break;
                    }
                case OpType.Quondam:
                    {
                        DisplayQuondam((QuondamPoint)UpdatedPoint);
                        break;
                    }
                case OpType.Walk:
                    {
                        DisplayWalk((WalkPoint)UpdatedPoint);
                        break;
                    }
                case OpType.Take5:
                    {
                        DisplayTake5((Take5Point)UpdatedPoint); 

                        break;
                    }
            }

            _dirty = false;
        }

        private void AdjustNavControls()
        {
            pointNavigationCtrl.UpdateIndex(CurrPointIndex);

            if (CurrPointIndex > 0 && _PointCNs.Count > 1)
            {
                pointNavigationCtrl.BackwardButtons = true;
            }
            else
            {
                pointNavigationCtrl.BackwardButtons = false;
            }

            if (CurrPointIndex < _Points.Count - 1 && _PointCNs.Count > 1)
            {
                pointNavigationCtrl.ForwardButtons = true;
            }
            else
            {
                pointNavigationCtrl.ForwardButtons = false;
            }

            if (_Points.Count > 0)
            {
                actionsControl.DeleteEnabled = true;
            }
            else
            {
                actionsControl.DeleteEnabled = false;
            }

        }

        private void MoveToLastPoint()
        {
            if (_Points.Count > 0)
            {
                int pos = -1;
                pos = (_Points.Count - 1);

                if (pos > -1)
                {
                    SavePoint();
                    CurrPoint = TtUtils.CopyPoint(_Points[pos]);
                    pointInfoCtrl.CurrentPoint = TtUtils.CopyPoint(CurrPoint);
                    CurrPointIndex = pos;
                    UpdatedPoint = TtUtils.CopyPoint(CurrPoint);

                    //convert meta
                    GetConversion(ref _UpdatedPoint);
                }
            }
            else
            {
                CurrPoint = null;
                UpdatedPoint = null;
                CurrPointIndex = -1;
            }

            DisplayPointCtrl();
            AdjustNavControls();
        }

        private void LockControls(bool l)
        {
            gpsInfoControl1.Locked = l;
            take5InfoCtrl1.Locked = l;
            travInfoControl1.Locked = l;
            quondamInfoControl1.Locked = l;
            walkInfoCtrl1.Locked = l;
            pointInfoCtrl.ReadOnly = l;
            actionsControl.DeleteEnabled = !l;

            if (l)
            {
                actionsControl.MiscButtonEnabled = false;
            }
            else
            {
                if (UpdatedPoint != null && UpdatedPoint.op != OpType.Quondam)
                    actionsControl.MiscButtonEnabled = true;
            }
        }


        private void ChangePoint(string cn)
        {
            if (_Points.Count > 0)
            {
                int pos = -1;

                pos = _PointCNs.IndexOf(cn);

                if (pos > -1)
                {
                    if(!TtUtils.PointHasValue(UpdatedPoint))
                    {
                        if (UpdatedPoint.IsTravType())
                        {
                            SideShotPoint sp = UpdatedPoint as SideShotPoint;
                            if (sp.ForwardAz == null && sp.BackwardAz == null || sp.SlopeDistance <= 0)
                            {
                                if (MessageBox.Show(@"Foward Azimuth and/or Backward Azimuth must contain a value and 
Slope Distacne must contain a value greater than 0. Are you want to save this point?", "Point has no value.",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                {
                                    DeletePoint();
                                    return;
                                }
                                else
                                {
                                    ((SideShotPoint)UpdatedPoint).ForwardAz = 0;
                                    SavePoint(true);
                                }
                            }
                        }
                        else if (Values.Settings.ProjectOptions.DropZero)
                        {
                            DeletePoint();
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show("This point has no value. Do you want to save this point?", "Point has no value.",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {

                                DeletePoint();
                                return;
                            }
                            else
                            {
                                SavePoint(true);
                            }
                        }
                    }
                    else
                    {
                        SavePoint();
                    }

                    CurrPoint = TtUtils.CopyPoint(_Points[pos]);
                    CurrPointIndex = pos;
                    UpdatedPoint = TtUtils.CopyPoint(CurrPoint);

                    //convert meta
                    GetConversion(ref _UpdatedPoint);

                    DisplayPointCtrl();
                    LockControls(true);
                }
            }
            else
            {
                CurrPoint = null;
                UpdatedPoint = null;
                CurrPointIndex = -1;
            }

            AdjustNavControls();
        }

        private void ChangePoint(int pos)
        {
            if (_Points.Count > 0)
            {
                if (pos > -1)
                {
                    SavePoint();
                    CurrPoint = TtUtils.CopyPoint(_Points[pos]);
                    CurrPointIndex = pos;
                    UpdatedPoint = TtUtils.CopyPoint(CurrPoint);

                    //convert meta
                    GetConversion(ref _UpdatedPoint);

                    DisplayPointCtrl();
                    LockControls(true);
                }
            }
            else
            {
                CurrPoint = null;
                UpdatedPoint = null;
                CurrPointIndex = -1;
            }

            AdjustNavControls();
        }


        private void ChangeMeta()
        {
            if (_UpdatedPoint != null)
            {
                _UpdatedPoint.MetaDefCN = pointInfoCtrl.MetaDefCN;

                CurrMeta = _Meta[_MetaCNs.IndexOf(_UpdatedPoint.MetaDefCN)];

                int pos = -1;
                TtMetaData metaFrom;
                pos = _MetaCNs.IndexOf(UpdatedPoint.MetaDefCN);

                if (pos > -1)
                    metaFrom = _Meta[pos];
                else
                    return;


                if (UpdatedPoint.IsTravType())
                {
                    ((SideShotPoint)_UpdatedPoint).SlopeDistance = TtUtils.ConvertDistance(((SideShotPoint)_UpdatedPoint).SlopeDistance, CurrMeta.uomDistance, metaFrom.uomDistance);
                    ((SideShotPoint)_UpdatedPoint).SlopeAngle = TtUtils.ConvertAngle(((SideShotPoint)_UpdatedPoint).SlopeAngle, CurrMeta.uomSlope, metaFrom.uomSlope);
                    travInfoControl1.CurrentPoint = (SideShotPoint)UpdatedPoint;
                }
                else if (UpdatedPoint.IsGpsType())
                {
                    _UpdatedPoint = TtUtils.RecalcPoint(UpdatedPoint, CurrMeta.Zone, metaFrom.Zone, DAL);
                    gpsInfoControl1.CurrentPoint = (GpsPoint)UpdatedPoint;
                }

                travInfoControl1.MetaData = CurrMeta;
                gpsInfoControl1.Meta = CurrMeta;
                _dirty = true;

                SavePoint();
            }
        }

        private void StopPointFlashing()
        {
            pointInfoCtrl.FlashPoint = false;
        }
        #endregion

        #region Action Controls
        private void actionsControl_Cancel_OnClick2(object sender, EventArgs e)
        {
            _closing = true;

            if (_saving)
            {
                Values.GlobalCancelToken = true;
            }
            else
            {
                if (_dirty && MessageBox.Show("Are you sure you want to cancel without saving?", "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    _closing = false;
                    return;
                }

                try
                {
                    if (_dirty && !TtUtils.PointHasValue(UpdatedPoint))
                    {
                        DeletePoint();
                    }
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "PointEditFormLogic");
                }
            }

            Save();

            pointInfoCtrl.FlashPoint = false;
            this.Close();
        }

        private void actionsControl_Delete_OnClick2(object sender, EventArgs e)
        {
            pointInfoCtrl.FlashPoint = false;

            if (MessageBox.Show(String.Format("Are you sure you want to delete point {0}?", UpdatedPoint.PID), "Delete Point",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DeletePoint();

                pointInfoCtrl.CurrentPoint = CurrPoint;
                pointNavigationCtrl.UpdatePointList(_PointCNs, CurrPointIndex);

                DisplayPointCtrl();
                LockControls(true);
            }
        }

        private void actionsControl_New_OnClick2(object sender, EventArgs e)
        {
            CreateNewPoint();
        }

        private void actionsControl_Ok_OnClick2(object sender, EventArgs e)
        {
            _closing = true;
            pointInfoCtrl.FlashPoint = false;

            if (_Points.Count < 1)
                this.Close();
            else
            {
                SavePoint();

                if (!Save())
                    _closing = false;
            }
        }

        private void actionsControl_Misc_OnClick2(object sender, EventArgs e)
        {
            pointInfoCtrl.FlashPoint = false;

            switch (pointInfoCtrl.Op)
            {
                case OpType.GPS:
                case OpType.WayPoint:
                    {
                        gpsWayInputCtrl1_OnAcquire();
                        break;
                    }
                case OpType.Traverse:
                case OpType.SideShot:
                    {
                        TravSideshotAcquire();
                        break;
                    }
                case OpType.Quondam:
                    {
                        break;
                    }
                case OpType.Take5:
                    {
                        Take5Setup();
                        break;
                    }
                case OpType.Walk:
                    {
                        WalkSetup();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        #endregion

        #region Navigation Controls

        private void pointNavigationCtrl_AlreadyAtBeginning2(object sender)
        {
        }

        private void pointNavigationCtrl_AlreadyAtEnd2(object sender)
        {
        }

        private void pointNavigationCtrl_IndexChanged2(object sender, TwoTrails.Controls.PointNavigationCtrl.PointNavEventArgs e)
        {
            pointInfoCtrl.FlashPoint = false;

            ChangePoint(e.NextPointCN);
            LockControls(true);
        }

        private void pointNavigationCtrl_JumpPoint2(object sender)
        {
            pointInfoCtrl.FlashPoint = false;

            List<string> opts = new List<string>();
            foreach (TtPoint p in _Points)
            {
                opts.Add(p.PID.ToString());
            }

            using (Selection form = new Selection("Points", opts, CurrPointIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ChangePoint(_PointCNs[form.selection]);
                    pointNavigationCtrl.UpdateIndex(form.selection);
                    LockControls(true);
                }
            }
        }

        #endregion

        #region Point Controls

        #region PointInfo Control

        private void pointInfoCtrl1_Comment_OnTextChanged2(object sender, EventArgs e)
        {
            if(loaded)
                _dirty = true;
        }

        private void pointInfoCtrl_PID_OnTextChanged2(object sender, EventArgs e)
        {
            if (loaded)
                _dirty = true;
        }

        private void pointInfoCtrl_OnPID_Enter2()
        {
            if (loaded)
                _dirty = true;
        }

        private void pointInfoCtrl1_OnBoundary_Click2()
        {
            if (loaded)
                _dirty = true;
        }

        private void pointInfoCtrl_OnMetaDef_SelectedIndexChanged2()
        {
            if (_closing)
                return;

            _dirty = true;
            ChangeMeta();
        }

        private void pointInfoCtrl_OnOp_SelectedIndexChanged2()
        {
            if (_closing)
                return;

            if (_init)
            {
                if (UpdatedPoint.HasQuondamLinks && pointInfoCtrl.Op == OpType.WayPoint)
                {
                    MessageBox.Show("Quondams can not be linked to WayPoints.");
                    pointInfoCtrl.CurrentPoint = UpdatedPoint;
                    return;
                }

                try
                {
                    DialogResult dr = DialogResult.Cancel;

                    if (TtUtils.PointHasValue(UpdatedPoint))
                    {
                        dr = MessageBox.Show("This Point has a value. Do you sure you want to convert it to a different point type?", "Convert Point Type",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
                    }
                    else
                    {
                        dr = DialogResult.Yes;
                    }

                    if (dr == DialogResult.Yes)
                    {
                        if (UpdatedPoint != null && UpdatedPoint.op == OpType.Quondam)
                        {
                            string ParentCN = ((QuondamPoint)UpdatedPoint).ParentCN;

                            UpdatedPoint = DAL.GetNewPointByOpType(pointInfoCtrl.Op, UpdatedPoint);
                            pointInfoCtrl.CurrentPoint = UpdatedPoint;

                            if (UpdatedPoint.op != OpType.Quondam)
                            {
                                int pos = -1;
                                pos = _PointCNs.IndexOf(ParentCN);

                                if (pos > -1)
                                    _Points[pos].RemoveQuondamLink(UpdatedPoint.CN);
                            }

                            DisplayPointCtrl();
                            _dirty = true;
                        }
                        else
                        {
                            UpdatedPoint = DAL.GetNewPointByOpType(pointInfoCtrl.Op, UpdatedPoint);
                            pointInfoCtrl.CurrentPoint = UpdatedPoint;
                            DisplayPointCtrl();
                            _dirty = true;
                        }
                    }
                    else
                    {
                        pointInfoCtrl.CurrentPoint = UpdatedPoint;
                    }
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "PointEditFormLogic:PointInfoCtrl-changeOp");
                    MessageBox.Show("Point conversion error.");
                }
            }
        }

        private void pointInfoCtrl_Comment_OnTextChanged2(object sender, EventArgs e)
        {
            _dirty = true;
        }

        private void pointInfoCtrl_OnComment_Enter2()
        {
            _dirty = true;
        }

        private void pointInfoCtrl_OnLocked_CheckedChanged2(object sender, LockStateEventArgs e)
        {
            LockControls(e.Locked);
        }

        private void pointInfoCtrl_OnPoly_SelectedIndexChanged2()
        {
            ChangePolygon();
        }

        private void pointInfoCtrl_LinkedPointClicked2()
        {
            if (_closing)
                return;

            List<TtPoint> points = DAL.getPointsByPointCNs(_UpdatedPoint.LinkedPoints);

            if (points.Count > 0)
            {
                using(LinkedPointForm form = new LinkedPointForm(points))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.SelectedPoint != null)
                        {
                            pointInfoCtrl.ReadOnly = true;
                            LockControls(true);

                            if (ChangePolygon(form.SelectedPoint.PolyCN))
                            {
                                ChangePoint(form.SelectedPoint.CN);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Take5 Point Control

        private void take5InfoCtrl1_BurstAmountChanged2()
        {
            actionsControl.MiscButtonText = "Take " + Values.Settings.DeviceOptions.Take5NmeaAmount.ToString();
        }

        private void take5InfoCtrl1_ButtonHide2()
        {
            take5InfoCtrl1.Visible = false;
            gpsInfoControl1.Visible = true;
        }
        #endregion

        #region GPS Point Type Control
        private void gpsInfoControl1_DelNmea_OnClick2(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will Delete All Nmea data associated with this point", "Delete NMEA",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                try
                {
                    if (UpdatedPoint != null && UpdatedPoint.CN != "")
                    {
                        DAL.DeleteNmeaBursts(UpdatedPoint.CN);
                    }

                    ((GpsPoint)UpdatedPoint).RMSEr = null;
                    ((GpsPoint)UpdatedPoint).ManualAccuracy = null;

                    gpsInfoControl1.CurrentPoint = (GpsPoint)UpdatedPoint;
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "PointEditFormLogic:DelNmea");
                }

            }
        }

        private void gpsInfoControl1_ManAcc_OnTextChanged2(object sender, EventArgs e)
        {
            if (loaded)
            {
                ((GpsPoint)UpdatedPoint).ManualAccuracy = gpsInfoControl1.CurrentPoint.ManualAccuracy;
                _dirty = true;
            }
        }

        private void gpsInfoControl1_X_OnTextChanged2(object sender, EventArgs e)
        {
            if (loaded)
            {
                UpdatedPoint.UnAdjX = gpsInfoControl1.CurrentPoint.UnAdjX;
                //((GpsPoint)UpdatedPoint).X = gpsInfoControl1.CurrentPoint.X;
                _dirty = true;
            }
        }

        private void gpsInfoControl1_Y_OnTextChanged2(object sender, EventArgs e)
        {
            if (loaded)
            {
                UpdatedPoint.UnAdjY = gpsInfoControl1.CurrentPoint.UnAdjY;
                //((GpsPoint)UpdatedPoint).Y = gpsInfoControl1.CurrentPoint.Y;
                _dirty = true;
            }
        }

        private void gpsInfoControl1_Z_OnTextChanged2(object sender, EventArgs e)
        {
            if (loaded)
            {
                UpdatedPoint.UnAdjZ = gpsInfoControl1.CurrentPoint.UnAdjZ;
                //((GpsPoint)UpdatedPoint).Z = gpsInfoControl1.CurrentPoint.Z;
                _dirty = true;
            }
        }

        private void gpsWayInputCtrl1_OnAcquire()
        {
            try
            {
                if (loaded && UpdatedPoint != null)
                {
                    if (Values.Settings.DeviceOptions.GpsConfigured)    //if gps is configured
                    {
                        try
                        {
                            using (AcquireGpsForm form = new AcquireGpsForm(UpdatedPoint, CurrMeta.Zone, DAL))
                            {
                                List<GpsAccess.NmeaBurst> currNmea = DAL.GetNmeaBurstsByPointCN(UpdatedPoint.CN);

                                if (currNmea.Count > 0)
                                {
                                    DialogResult dr = MessageBox.Show("This Point already has Nmea data. Would you like to add to this data?", "Add to Nmea",
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                                    if (dr == DialogResult.Yes)
                                        form.AddToNmea(currNmea);
                                    else if (dr == DialogResult.Cancel)
                                    {
                                        form.Dispose();
                                        return;
                                    }
                                }

                                form.ShowDialog();

                                if (form.IsCalc) //if form gathered data and calculated a point
                                {
                                    GpsPoint gpsPoint = form._GpsPoint;

                                    GpsPoint up = ((GpsPoint)UpdatedPoint);

                                    up.Time = DateTime.Now;
                                    up.UnAdjX = gpsPoint.UnAdjX;
                                    up.UnAdjY = gpsPoint.UnAdjY;
                                    up.UnAdjZ = gpsPoint.UnAdjZ;
                                    //up.X = gpsPoint.X;
                                    //up.Y = gpsPoint.Y;
                                    //up.Z = gpsPoint.Z;
                                    up.RMSEr = gpsPoint.RMSEr;

                                    GetConversion(ref _UpdatedPoint);

                                    gpsInfoControl1.CurrentPoint = (GpsPoint)UpdatedPoint;
                                    _dirty = true;
                                }

                                LockControls(true);
                            }
                        }
                        catch (Exception ex)
                        {
                            TtUtils.WriteError(ex.Message, "PointEditFormLogic");
                            MessageBox.Show("Aquire GPS Form error.");
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("GPS is not currently configured. Would you like to configure now?", "Configure GPS",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.Yes)
                        {
                            using (DeviceSetupForm form = new DeviceSetupForm())
                            {
                                form.ShowDialog();
                            }

                            gpsWayInputCtrl1_OnAcquire();
                        }
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("There is no point selected. Would you like to create a new point?", "No Point Selected",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                    {
                        CreateNewPoint();
                    }
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message);
            }
        }

        private void gpsInfoControl1_MiscClick2()
        {
            if (pointInfoCtrl.Op == OpType.Take5)
            {
                take5InfoCtrl1.Visible = true;
                gpsInfoControl1.Visible = false;
            }
            else if(pointInfoCtrl.Op == OpType.Walk)
            {
                walkInfoCtrl1.Visible = true;
                gpsInfoControl1.Visible = false;
            }
            else if (pointInfoCtrl.Op == OpType.GPS)
            {
                if (UpdatedPoint != null && TtUtils.PointHasValue(UpdatedPoint))
                {
                    List<GpsAccess.NmeaBurst> bursts = DAL.GetNmeaBurstsByPointCN(UpdatedPoint.CN);

                    if (bursts.Count > 0)
                    {
                        using (CalcGpsPointForm form = new CalcGpsPointForm(bursts, UpdatedPoint.PID, UpdatedPoint.CN, DAL, CurrMeta.Zone, true))
                        {
                            form.ShowDialog();

                            if (form.IsCalaculated && !form.Canceled)
                            {
                                GpsPoint gpsPoint = form._GpsPoint;
                                GpsPoint currGps = new GpsPoint(UpdatedPoint);

                                currGps.Time = DateTime.Now;
                                currGps.UnAdjX = gpsPoint.UnAdjX;
                                currGps.UnAdjY = gpsPoint.UnAdjY;
                                currGps.UnAdjZ = gpsPoint.UnAdjZ;
                                ////currGps.X = gpsPoint.X;
                                ////currGps.Y = gpsPoint.Y;
                                ////currGps.Z = gpsPoint.Z;
                                currGps.RMSEr = gpsPoint.RMSEr;

                                _UpdatedPoint = currGps;
                                GetConversion(ref _UpdatedPoint);

                                gpsInfoControl1.CurrentPoint = (GpsPoint)UpdatedPoint;
                                _dirty = true;

                                LockControls(true);
                            }
                        }
                    }
                    else
                    {
                        AutoClosingMessageBox.Show("No NMEA data associated with point.", "No NMEA", 1000);
                    }
                }
            }
        }
        #endregion

        #region Traverse / SideShot Control

        private void TravSideshotAcquire()
        {
            travInfoControl1.Aquire();
        }

        #endregion

        #region Quondam Point Control
        private void quondamInfoControl1_Point_OnIndexChanged2()
        {
            if(loaded)
                _dirty = true;
        }

        private void quondamInfoControl1_Polygon_OnIndexChanged2()
        {
            if (loaded)
                _dirty = true;
        }

        private void quondamInfoControl1_PointConverted2()
        {
            if (MessageBox.Show("You are about to Convert this Point from a quondam into its parent point. Would you like to continue?", "Convert Quondam",
                MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                UpdatedPoint = ConvertQuondam();

                if(UpdatedPoint != null)
                {
                    DisplayPointCtrl();
                    _dirty = true;
                }
                else
                {
                    MessageBox.Show("Quondam convert Failed.");
                }
            }

        }

        private void quondamInfoControl1_PointsRetraced2()
        {
            SavePoint();

            using (QuondamRetraceForm form = new QuondamRetraceForm(DAL, quondamInfoControl1.PointListIndex, quondamInfoControl1.PolyListIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    TtGroup qg = new TtGroup();
                    qg.SetGroupName(String.Format("Quondams_{0}", qg.CN.Truncate(8)), null);

                    DAL.InsertGroup(qg);
                    //Values.GroupManager.AddGroup(qg, DAL);

                    foreach(TtPoint p in form.FinalPoints)
                    {

                        p.GroupCN = qg.CN;
                        p.GroupName = qg.Name;
                        //qg.AddPointToGroup(p);
                        CreateNewPoint(OpType.Quondam, false, true);

                        ((QuondamPoint)_UpdatedPoint).ParentPoint = p;
                        _dirty = true;
                    }

                    //Values.GroupManager.SaveGroup(qg.CN, DAL);

                    ChangePolygon();
                }
            }
        }
        #endregion

        #region Walk Control
        private void walkInfoCtrl1_DeleteWalk2()
        {
            if (!UpdatedPoint.GroupCN.IsEmpty())
            {
                if (MessageBox.Show("Are you sure you want to delete all the points in this walk?", "Delete Walk",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    TtUtils.ShowWaitCursor();

                    DAL.DeletePointsInGroup(UpdatedPoint.GroupCN);
                    DAL.DeleteGroup(UpdatedPoint.GroupCN);
                    //Values.GroupManager.DeleteGroup(UpdatedPoint.GroupCN, DAL, true);

                    ChangePolygon();
                    TtUtils.HideWaitCursor();
                    AutoClosingMessageBox.Show("Walk Deleted", "*__", 500);
                }
            }
            else
            {
                TtUtils.WriteError("Failed to obtain Group ID", "PointEditFormLogic:walkinfo-delete");
                AutoClosingMessageBox.Show("Failed to obtain Group ID", "Group ID", 1000);
            }
        }

        private void walkInfoCtrl1_EditAccuracy2(double acc)
        {
            TtUtils.ShowWaitCursor();
            int index = CurrPointIndex;


            _Groups[UpdatedPoint.GroupCN].SetGroupManualAccuracy(acc, DAL);
            //Values.GroupManager.Groups[UpdatedPoint.GroupCN].SetGroupManualAccuracy(acc, DAL);

            ChangePolygon();
            ChangePoint(CurrPointIndex);
            TtUtils.HideWaitCursor();
            MessageBox.Show("Walk Accuracy Set.");
        }

        private void walkInfoCtrl1_AddToWalk2()
        {

            List<string> groups = new List<string>();
            List<string> gcns = new List<string>();
            //Values.GroupManager.Groups.Values.Select(group => group.Name);

            //foreach (TtGroup group in Values.GroupManager.Groups.Values)
            foreach (TtGroup group in _Groups.Values)
            {
                groups.Add(group.Name);
                gcns.Add(group.CN);
            }

            using (Selection form = new Selection("Groups", groups, 0))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdatedPoint.GroupName = groups[form.selection];
                    UpdatedPoint.GroupCN = gcns[form.selection];
                    _dirty = true;
                    SavePoint();
                    ChangePolygon();
                    ChangePoint(CurrPointIndex);
                }
            }
        }

        private void walkInfoCtrl1_ButtonHide2()
        {
            walkInfoCtrl1.Visible = false;
            gpsInfoControl1.Visible = true;
        }
        #endregion

        #endregion

        #region Point Events

        #region Take5 Point Events

        private void Take5Setup()
        {
            if (Values.Settings.DeviceOptions.GpsConfigured)    //if gps is configured
            {
                try
                {
                    using (Take5Form form = new Take5Form(pointInfoCtrl.Polygon, DAL, CurrMeta, (int)UpdatedPoint.Index))
                    {
                        form.ShowDialog();
                        LoadPoints();
                        _dirty = false;
                        MoveToLastPoint();
                        pointNavigationCtrl.UpdatePointList(_PointCNs, CurrPointIndex);
                        AdjustNavControls();
                        _adjust = true;
                        LockControls(true);
                        TtUtils.HideWaitCursor();

                        GC.Collect();
                    }
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "PointEditLogic:Take5Setup");
                    MessageBox.Show("Take5 Form Error");
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("GPS is not currently configured. Would you like to configure now?", "Configure GPS",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    using (DeviceSetupForm form = new DeviceSetupForm())
                    {
                        form.ShowDialog();
                    }

                    Take5Setup();
                }
            }
        }

        #endregion

        #region Walk Events

        private void WalkSetup()
        {
            if (Values.Settings.DeviceOptions.GpsConfigured)
            {
                try
                {
                    using (WalkForm form = new WalkForm(pointInfoCtrl.Polygon, DAL, CurrMeta, (int)UpdatedPoint.Index))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadPoints();
                            MoveToLastPoint();
                            pointNavigationCtrl.UpdatePointList(_PointCNs, CurrPointIndex);
                            AdjustNavControls();
                            TtUtils.HideWaitCursor();
                            LockControls(true);
                        }
                    }

                    GC.Collect();
                }
                catch (Exception ex)
                {
                    TtUtils.HideWaitCursor();
                    TtUtils.WriteError(ex.Message, "PointEditLogic:WalkSetup");
                    MessageBox.Show("Walk Form Error");
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("GPS is not currently configured. Would you like to configure now?", "Configure GPS",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    using (DeviceSetupForm form = new DeviceSetupForm())
                    {
                        form.ShowDialog();
                    }

                    WalkSetup();
                }
            }
        }

        #endregion

        #region Traverse Sideshot Control
        private void travInfoControl1_BAzTextChanged2()
        {
            _dirty = true;
        }

        private void travInfoControl1_FAzTextChanged2()
        {
            _dirty = true;
        }

        private void travInfoControl1_SlopeAngleTextChanged2()
        {
            _dirty = true;
        }

        private void travInfoControl1_SlopeDistTextChanged2()
        {
            _dirty = true;
        }

        private void travInfoControl1_ValuesSet2()
        {
            _dirty = true;
        }
        #endregion

        #region Quondam

        private TtPoint ConvertQuondam()
        {
            return ConvertQuondam(UpdatedPoint);
        }

        private TtPoint ConvertQuondam(TtPoint ttpoint)
        {
            pointInfoCtrl.FlashPoint = false;

            if (UpdatedPoint.op == OpType.Quondam)
            {
                QuondamPoint qp = (QuondamPoint)ttpoint;
                TtPoint Parent = qp.ParentPoint;

                while (true)
                {
                    if (Parent != null)
                    {
                        if (Parent.op == OpType.Quondam)
                        {
                            Parent = ((QuondamPoint)Parent).ParentPoint;
                        }
                        else
                        {
                            TtPoint NewPoint = TtUtils.CopyPoint(Parent);

                            NewPoint.CopyInfo(qp);

                            NewPoint.RemoveQuondamLink(qp.CN);  //remove quondam that that linked to the point

                            if (!qp.Comment.IsEmpty())
                            {
                                NewPoint.Comment = qp.Comment;
                            }

                            TtPoint tmpPoint;

                            if (Parent.PolyCN == CurrPolyCN)
                            {
                                int parentindex = -1;
                                parentindex = _PointCNs.IndexOf(qp.ParentCN);
                                if(parentindex > -1)
                                {
                                    tmpPoint = TtUtils.CopyPoint(_Points[parentindex]);
                                    tmpPoint.RemoveQuondamLink(qp.CN);
                                    DAL.SavePoint(_Points[parentindex], tmpPoint);
                                    _Points[parentindex] = TtUtils.CopyPoint(tmpPoint);
                                }
                            }
                            else
                            {
                                tmpPoint = DAL.GetPoint(qp.ParentCN);
                                TtPoint tmpPoint2 = TtUtils.CopyPoint(tmpPoint);
                                if (tmpPoint != null)
                                {
                                    tmpPoint.RemoveQuondamLink(qp.CN);
                                    DAL.SavePoint(tmpPoint2, tmpPoint);
                                }
                            }

                            if (NewPoint.IsGpsType())
                            {
                                List<GpsAccess.NmeaBurst> nmea = DAL.GetNmeaBurstsByPointCN(Parent.CN);
                                DAL.SaveNmeaBursts(nmea, NewPoint.CN);
                            }

                            return TtUtils.CopyPoint(NewPoint);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Current Point is not a Quondam");
            }

            return null;
        }

        #endregion

        #endregion

        #region Display by Point type functions

        private void DisplayQuondam(QuondamPoint quondamPoint)
        {
            walkInfoCtrl1.Visible = false;
            take5InfoCtrl1.Visible = false;
            gpsInfoControl1.Visible = false;
            gpsInfoControl1.ShowMiscButton = false;
            travInfoControl1.Visible = false;
            if (reloadQuondamList)
            {
                quondamInfoControl1.LoadListboxes();
            }
            quondamInfoControl1.CurrentPoint = quondamPoint;
            quondamInfoControl1.Visible = true;
            actionsControl.MiscButtonText = "";
            actionsControl.MiscButtonEnabled = false;
        }

        private void DisplayTrav(SideShotPoint travPoint)
        {
            walkInfoCtrl1.Visible = false;
            take5InfoCtrl1.Visible = false;
            gpsInfoControl1.Visible = false;
            gpsInfoControl1.ShowMiscButton = false;
            travInfoControl1.Visible = true;
            travInfoControl1.CurrentPoint = travPoint;
            travInfoControl1.MetaData = CurrMeta;
            quondamInfoControl1.Visible = false;
            actionsControl.MiscButtonText = "Aquire";
            actionsControl.MiscButtonEnabled = true;
        }

        private void DisplayGPS(GpsPoint gpsPoint)
        {
            walkInfoCtrl1.Visible = false;
            take5InfoCtrl1.Visible = false;
            gpsInfoControl1.Visible = true;
            gpsInfoControl1.CurrentPoint = gpsPoint;
            gpsInfoControl1.MiscButtonText = "ReCalc";
            gpsInfoControl1.ShowMiscButton = true;
            gpsInfoControl1.Meta = CurrMeta;
            travInfoControl1.Visible = false;
            quondamInfoControl1.Visible = false;
            actionsControl.MiscButtonText = "Aquire";
            actionsControl.MiscButtonEnabled = true;
        }

        private void DisplayTake5(Take5Point point)
        {
            walkInfoCtrl1.Visible = false;
            take5InfoCtrl1.Visible = false;     //use button to open
            gpsInfoControl1.MiscButtonText = "Take 5 Setup";
            gpsInfoControl1.ShowMiscButton = true;
            gpsInfoControl1.Visible = true;
            gpsInfoControl1.CurrentPoint = point;
            gpsInfoControl1.Meta = CurrMeta;
            travInfoControl1.Visible = false;
            quondamInfoControl1.Visible = false;
            actionsControl.MiscButtonText = "Take " + Values.Settings.DeviceOptions.Take5NmeaAmount.ToString();
            actionsControl.MiscButtonEnabled = true;
        }

        private void DisplayWalk(WalkPoint point)
        {
            walkInfoCtrl1.SetPoint(point);
            walkInfoCtrl1.Visible = false;
            take5InfoCtrl1.Visible = false;
            gpsInfoControl1.Visible = true;
            gpsInfoControl1.MiscButtonText = "Edit Walk";
            gpsInfoControl1.ShowMiscButton = true;
            gpsInfoControl1.CurrentPoint = point;
            gpsInfoControl1.Meta = CurrMeta;
            travInfoControl1.Visible = false;
            quondamInfoControl1.Visible = false;
            actionsControl.MiscButtonText = "Walk";
            actionsControl.MiscButtonEnabled = true;
        }

        private void DispalyNone()
        {
            walkInfoCtrl1.Visible = false;
            take5InfoCtrl1.Visible = false;
            gpsInfoControl1.Visible = false;
            gpsInfoControl1.ShowMiscButton = false;
            travInfoControl1.Visible = false;
            quondamInfoControl1.Visible = false;
            actionsControl.MiscButtonEnabled = false;
        }

        #endregion

        #region Meta Point Conversions

        private void SaveConversion(ref TtPoint p)
        {
            int pos = -1;
            TtMetaData meta;
            pos = _MetaCNs.IndexOf(_UpdatedPoint.MetaDefCN);

            if (pos > -1)
                meta = _Meta[pos];
            else
                meta = _Meta[0];
            p = TtUtils.SaveConversion(p, meta);
        }

        private void GetConversion(ref TtPoint p)
        {
            int pos = -1;
            TtMetaData meta;
            pos = _MetaCNs.IndexOf(_UpdatedPoint.MetaDefCN);

            if (pos > -1)
                meta = _Meta[pos];
            else
                meta = _Meta[0];

            p = TtUtils.GetConversion(p, meta);
        }


        #endregion


        


        //override ShowDialog(), runs Init and fallback for CF3.5 bug
        public new System.Windows.Forms.DialogResult ShowDialog()
        {
            Init();

            if (_Polygons.Count < 1)
            {
                MessageBox.Show("There are no Polygons in this project. Please go to the Polygon form to create a new polygon.");
                return DialogResult.Abort;
            }
            else
            {

#if (PocketPC || WindowsCE || Mobile)
                DialogResult dr = base.ShowDialog();

                //if form does not display try again
                if (dr == DialogResult.None)
                    dr = base.ShowDialog();

                return dr;
#else
                return base.ShowDialog();
#endif
            }
        }
    }
}