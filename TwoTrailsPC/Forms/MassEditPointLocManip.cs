using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.Engine;
using TwoTrails.Utilities;
using TwoTrails.DataAccess;

namespace TwoTrails.Forms
{
    public partial class MassEditPointLocManip : Form
    {
        private DataAccessLayer dal;

        private List<TtPoint> _Points;
        private List<TtPoint> _MovePoints;
        private List<TtPoint> _EditedPoints;
        public List<TtPoint> EditedPoints { get { return _EditedPoints; } }
        private List<TtPoint> _AddedPoints;
        public List<TtPoint> AddedPoints { get { return _AddedPoints; } }

        private bool loaded = false;

        private List<TtPolygon> _Polys;

        public MassEditPointLocManip(List<TtPolygon> polys, List<TtPoint> points, List<TtPoint> movePoints,
            bool move, DataAccessLayer d)
        {
            InitializeComponent();
            _Polys = polys;
            _Points = points;
            _MovePoints = movePoints;
            _MovePoints.Sort();

            radMove.Checked = move;
            radQuondam.Checked = !move;

            dal = d;
        }

        private void MassEditPointLocManip_Load(object sender, EventArgs e)
        {
            _EditedPoints = new List<TtPoint>();
            _AddedPoints = new List<TtPoint>();
            cboTargetPoly.DataSource = _Polys;

            radRevFalse.Checked = true;
            radAtEnd.Checked = true;

            if (Values.Settings.DeviceOptions.FormMassEditPointLocManip > -1 &&
                Values.Settings.DeviceOptions.FormMassEditPointLocManip < _Polys.Count)
            {
                cboTargetPoly.SelectedIndex = Values.Settings.DeviceOptions.FormMassEditPointLocManip;
            }

            loaded = true;
        }


        private void btnCommit_Click(object sender, EventArgs e)
        {
            try
            {
                int index;
                TtPolygon targetPoly = cboTargetPoly.SelectedItem as TtPolygon;

                List<TtPoint> targetPointList = _Points.Where(p => p.PolyCN == targetPoly.CN).ToList();
                targetPointList.Sort();

                if (radRevTrue.Checked)
                    _MovePoints.Reverse();

                if (radMove.Checked)
                {
                    #region Move
                    if (targetPointList.Count > 0)
                    {
                        if (radAtEnd.Checked)
                        {
                            index = (int)(targetPointList[targetPointList.Count - 1].Index + 1);

                            TtPoint tmpPoint;
                            foreach (TtPoint point in _MovePoints)
                            {
                                tmpPoint = TtUtils.CopyPoint(point);
                                tmpPoint.Index = index;
                                tmpPoint.PolyCN = targetPoly.CN;
                                tmpPoint.PolyName = targetPoly.Name;
                                index++;

                                _EditedPoints.Add(tmpPoint);
                            }
                        }
                        else if (radBegining.Checked)
                        {
                            index = 0;
                            TtPoint tmpPoint;

                            List<TtPoint> insertPointList = _Points.Where(p => p.PolyCN == targetPoly.CN).ToList();
                            insertPointList.Sort();

                            foreach (TtPoint point in _MovePoints)
                            {
                                tmpPoint = TtUtils.CopyPoint(point);
                                tmpPoint.Index = index;
                                tmpPoint.PolyCN = targetPoly.CN;
                                tmpPoint.PolyName = targetPoly.Name;
                                index++;

                                _EditedPoints.Add(tmpPoint);
                            }

                            foreach (TtPoint point in insertPointList)
                            {
                                tmpPoint = TtUtils.CopyPoint(point);
                                tmpPoint.Index = index;
                                index++;

                                _EditedPoints.Add(tmpPoint);
                            }
                        }
                        else
                        {
                            TtPoint targetIntsertPoint = cboInsertPoint.SelectedItem as TtPoint;
                            index = (int)(targetIntsertPoint.Index);

                            TtPoint tmpPoint;

                            List<TtPoint> insertPointList = _Points.Where(p => p.PolyCN == targetPoly.CN && p.Index > index).ToList();
                            insertPointList.Sort();

                            index++;

                            foreach (TtPoint point in _MovePoints)
                            {
                                tmpPoint = TtUtils.CopyPoint(point);
                                tmpPoint.Index = index;
                                tmpPoint.PolyCN = targetPoly.CN;
                                tmpPoint.PolyName = targetPoly.Name;
                                index++;

                                _EditedPoints.Add(tmpPoint);
                            }

                            foreach (TtPoint point in insertPointList)
                            {
                                tmpPoint = TtUtils.CopyPoint(point);
                                tmpPoint.Index = index;
                                index++;

                                _EditedPoints.Add(tmpPoint);
                            }
                        }
                    }
                    else
                    {
                        index = 0;

                        TtPoint tmpPoint;
                        foreach (TtPoint point in _MovePoints)
                        {
                            tmpPoint = TtUtils.CopyPoint(point);
                            tmpPoint.Index = index;
                            tmpPoint.PolyCN = targetPoly.CN;
                            tmpPoint.PolyName = targetPoly.Name;
                            index++;

                            _EditedPoints.Add(tmpPoint);
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Quondam
                    TtPoint lastPoint;
                    QuondamPoint tmpPoint;
                    TtMetaData meta = dal.GetMetaData()[0];

                    if (targetPointList.Count > 0)
                    {
                        if (radAtEnd.Checked)
                        {
                            lastPoint = targetPointList[targetPointList.Count - 1];
                            index = (int)(lastPoint.Index) + 1;

                            foreach (TtPoint point in _MovePoints)
                            {
                                tmpPoint = CreateQuondam(point, targetPoly, meta);
                                tmpPoint.PID = PointNaming.NamePoint(lastPoint, targetPoly);

                                tmpPoint.Index = index;
                                index++;

                                _AddedPoints.Add(tmpPoint);
                                lastPoint = tmpPoint;
                            }
                        }
                        else if (radBegining.Checked)
                        {
                            index = 0;

                            List<TtPoint> insertPointList = _Points.Where(p => p.PolyCN == targetPoly.CN).ToList();
                            insertPointList.Sort();

                            lastPoint = null;

                            foreach (TtPoint point in _MovePoints)
                            {
                                tmpPoint = CreateQuondam(point, targetPoly, meta);

                                if (index == 0)
                                    tmpPoint.PID = PointNaming.NameFirstPoint(targetPoly);
                                else
                                    tmpPoint.PID = PointNaming.NamePoint(lastPoint, targetPoly);

                                tmpPoint.Index = index;
                                index++;

                                _AddedPoints.Add(tmpPoint);
                                lastPoint = tmpPoint;
                            }

                            TtPoint tmpPoint2;
                            foreach (TtPoint point in insertPointList)
                            {
                                tmpPoint2 = TtUtils.CopyPoint(point);
                                tmpPoint2.Index = index;

                                /*
                                if (index == 0)
                                    tmpPoint2.PID = PointNaming.NameFirstPoint(targetPoly);
                                else
                                    tmpPoint2.PID = PointNaming.NamePoint(lastPoint, targetPoly);
                                */

                                index++;

                                _EditedPoints.Add(tmpPoint2);
                                lastPoint = tmpPoint2;
                            }
                        }
                        else
                        {
                            TtPoint targetIntsertPoint = cboInsertPoint.SelectedItem as TtPoint;
                            index = (int)(targetIntsertPoint.Index);

                            List<TtPoint> insertPointList = _Points.Where(p => p.PolyCN == targetPoly.CN && p.Index >= index).ToList();
                            insertPointList.Sort();

                            lastPoint = insertPointList[0];
                            insertPointList.RemoveAt(0);
                            index++;

                            foreach (TtPoint point in _MovePoints)
                            {
                                tmpPoint = CreateQuondam(point, targetPoly, meta);
                                tmpPoint.PID = PointNaming.NamePoint(lastPoint, targetPoly);

                                tmpPoint.Index = index;
                                index++;

                                _AddedPoints.Add(tmpPoint);
                                lastPoint = tmpPoint;
                            }

                            TtPoint tmpPoint2;
                            foreach (TtPoint point in insertPointList)
                            {
                                tmpPoint2 = TtUtils.CopyPoint(point);
                                tmpPoint2.Index = index;

                                /*
                                if (index == 0)
                                    tmpPoint2.PID = PointNaming.NameFirstPoint(targetPoly);
                                else
                                    tmpPoint2.PID = PointNaming.NamePoint(lastPoint, targetPoly);
                                */

                                index++;
                                _EditedPoints.Add(tmpPoint2);
                                lastPoint = tmpPoint2;
                            }
                        }
                    }
                    else
                    {
                        index = 0;
                        lastPoint = null;

                        foreach (TtPoint point in _MovePoints)
                        {
                            tmpPoint = CreateQuondam(point, targetPoly, meta);

                            if (index == 0)
                                tmpPoint.PID = PointNaming.NameFirstPoint(targetPoly);
                            else
                                tmpPoint.PID = PointNaming.NamePoint(lastPoint, targetPoly);

                            tmpPoint.Index = index;
                            index++;

                            _AddedPoints.Add(tmpPoint);
                            lastPoint = tmpPoint;
                        }
                    }
                    #endregion
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MasseditPointLocManip:Commit", ex.StackTrace);
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cboTargetPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTargetPoly.SelectedIndex > -1)
            {
                string cn = ((TtPolygon)cboTargetPoly.SelectedItem).CN;
                List<TtPoint> tmpPoints = _Points.Where(p => p.PolyCN == cn).ToList();
                tmpPoints.Sort();
                cboInsertPoint.DataSource = tmpPoints;

                if (tmpPoints.Count < 1)
                {
                    radAfter.Enabled = false;
                    cboInsertPoint.Enabled = false;
                    radAtEnd.Checked = true;
                }
                else
                {
                    radAfter.Enabled = true;
                    cboInsertPoint.Enabled = true;
                }

                if (loaded)
                {
                    Values.Settings.DeviceOptions.FormMassEditPointLocManip = cboTargetPoly.SelectedIndex;
                }
            }
        }

        private void radAfter_CheckedChanged(object sender, EventArgs e)
        {
            cboInsertPoint.Enabled = radAfter.Checked;
        }


        private QuondamPoint CreateQuondam(TtPoint parentpoint, TtPolygon poly, TtMetaData meta)
        {
            QuondamPoint tmpPoint = new QuondamPoint();
            tmpPoint.PolyCN = poly.CN;
            tmpPoint.PolyName = poly.Name;
            tmpPoint.MetaDefCN = meta.CN;
            tmpPoint.GroupCN = Values.MainGroup.CN;
            tmpPoint.GroupName = Values.MainGroup.Name;

            if (parentpoint.op == OpType.Quondam)
            {
                tmpPoint.ParentPoint = ((QuondamPoint)parentpoint).ParentPoint;
            }
            else
                tmpPoint.ParentPoint = parentpoint;

            tmpPoint.OnBnd = parentpoint.OnBnd;

            return tmpPoint;
        }
    }
}
