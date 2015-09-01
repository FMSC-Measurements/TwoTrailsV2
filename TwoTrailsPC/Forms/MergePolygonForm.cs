using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.Utilities;
using TwoTrails.BusinessObjects;
using TwoTrails.BusinessLogic;
using TwoTrails.Engine;

namespace TwoTrails.Forms
{
    public partial class MergePolygonForm : Form
    {
        DataAccessLayer dal;

        TtPolygon _Poly1, _Poly2, _NewPoly;
        List<TtPolygon> _Polys = new List<TtPolygon>(), _AllPolys;
        BindingList<TtPolygon> polys1, polys2;
        BindingList<TtPoint> point1StartList, point1EndList, point2StartList, point2EndList;
        List<TtPoint> newPoints;
        TtMetaData _Meta;

        int lastPolyIndex1, lastPolyIndex2, lastPoint1StartIndex, lastPoint1EndIndex,
            lastPoint2StartIndex, lastPoint2EndIndex;

        bool init = false, ignorePolyChange = false, polyCreated = false;

        public MergePolygonForm(DataAccessLayer d)
        {
            InitializeComponent();
            dal = d;
        }

        public bool Setup()
        {
            _AllPolys = dal.GetPolygons();

            for (int i = 0; i < _AllPolys.Count; i++)
            {
                if (dal.GetNumberOfPointsinPolygon(_AllPolys[i].CN) > 2)
                {
                    _Polys.Add(_AllPolys[i]);
                }
            }

            try
            {
                _Meta = dal.GetMetaData()[0];
            }
            catch
            {
                return false;
            }


            if (_Polys.Count < 2)
                return false;

            return true;
        }

        private void MergePolygonForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;

            polys1 = new BindingList<TtPolygon>(_Polys);
            cboPoly1.DataSource = polys1;
            cboPoly1.SelectedIndex = 0;
            _Poly1 = _Polys[0];
            lastPolyIndex1 = 0;

            polys2 = new BindingList<TtPolygon>(_Polys);
            cboPoly2.DataSource = polys2;
            cboPoly2.SelectedIndex = 1;
            _Poly2 = _Polys[1];
            lastPolyIndex1 = 1;

            point1StartList = new BindingList<TtPoint>(dal.GetPointsInPolygon(_Poly1.CN));
            point1EndList = new BindingList<TtPoint>(dal.GetPointsInPolygon(_Poly1.CN));
            point2StartList = new BindingList<TtPoint>(dal.GetPointsInPolygon(_Poly2.CN));
            point2EndList = new BindingList<TtPoint>(dal.GetPointsInPolygon(_Poly2.CN));

            cboStartPointPoly1.DataSource = point1StartList;
            cboStartPointPoly1.SelectedIndex = 0;
            cboStartPointPoly1.DisplayMember = "PID";

            cboEndPointPoly1.DataSource = point1EndList;
            cboEndPointPoly1.SelectedIndex = point1EndList.Count - 1;
            cboEndPointPoly1.DisplayMember = "PID";

            cboStartPointPoly2.DataSource = point2StartList;
            cboStartPointPoly2.SelectedIndex = 0;
            cboStartPointPoly2.DisplayMember = "PID";

            cboEndPointPoly2.DataSource = point2EndList;
            cboEndPointPoly2.SelectedIndex = point2EndList.Count - 1;
            cboEndPointPoly2.DisplayMember = "PID";

            txtNewPolyName.Text = String.Format("Poly {0}", _AllPolys.Count + 1);

            init = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (!txtNewPolyName.Text.IsEmpty())
            {
                if (_AllPolys.Where(p => p.Name == txtNewPolyName.Text).Count() < 1)
                {
                    Merge(radPointsQndm.Checked);
                }
                else
                {
                    //poly name exists
                }
            }
            else
            {
                //no poly name
            }
        }

        private void MergePolygonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(polyCreated)
            {
                e.Cancel = true;
                this.DialogResult = DialogResult.OK;
                PolygonAdjuster.Adjust(dal, this);
            }
            else
                this.DialogResult = DialogResult.Cancel;
        }



        private void Merge(bool link)
        {
            int index = 0;
            newPoints = new List<TtPoint>();
            _NewPoly = new TtPolygon();

            _NewPoly.Name = txtNewPolyName.Text;

            if (radPoly1CW.Checked)
            {
                for (int i = cboStartPointPoly1.SelectedIndex; i <= cboEndPointPoly1.SelectedIndex; i++)
                {
                    newPoints.Add(MakePoint(point1StartList[i], _NewPoly, link, index));
                    index++;
                }
            }
            else
            {
                for (int i = cboEndPointPoly1.SelectedIndex; i >= cboStartPointPoly1.SelectedIndex; i--)
                {
                    newPoints.Add(MakePoint(point1StartList[i], _NewPoly, link, index));
                    index++;
                }
            }

            if (radPoly2CW.Checked)
            {
                for (int i = cboStartPointPoly2.SelectedIndex; i <= cboEndPointPoly2.SelectedIndex; i++)
                {
                    newPoints.Add(MakePoint(point2StartList[i], _NewPoly, link, index));
                    index++;
                }
            }
            else
            {
                for (int i = cboEndPointPoly2.SelectedIndex; i <= cboStartPointPoly2.SelectedIndex; i--)
                {
                    newPoints.Add(MakePoint(point2StartList[i], _NewPoly, link, index));
                    index++;
                }
            }

            Values.GroupManager.Groups[Values.MainGroup.CN].AddPointsToGroup(newPoints);
                
            dal.InsertPolygon(_NewPoly);
            dal.InsertPoints(newPoints);

            _AllPolys.Add(_NewPoly);
            _Polys.Add(_NewPoly);
            polys1.Add(_NewPoly);
            polys2.Add(_NewPoly);
        }

        private TtPoint MakePoint(TtPoint point, TtPolygon poly, bool link, int index)
        {
            if (link)
                point = new QuondamPoint() { ParentPoint = point };
            else
                point = TtUtils.ClonePoint(point);

            if (index == 0)
                point.PID = PointNaming.NameFirstPoint( _NewPoly);
            else
                point.PID = PointNaming.NamePoint(newPoints[ newPoints.Count - 1], _NewPoly);

            point.Index = index;
            point.MetaDefCN = _Meta.CN;

            return point;
        }


        private void cboPoly1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init)
            {
                if (cboPoly1.SelectedIndex == cboPoly2.SelectedIndex)
                {
                    MessageBox.Show("You cannot merge to the same polygon.");
                    ignorePolyChange = true;
                    cboPoly1.SelectedIndex = lastPolyIndex1;
                }
                else
                {
                    lastPolyIndex1 = cboPoly1.SelectedIndex;

                    if (ignorePolyChange)
                    {
                        _Poly1 = _Polys[lastPolyIndex1];
                        point1StartList = new BindingList<TtPoint>(dal.GetPointsInPolygon(_Poly1.CN));
                        point1EndList = new BindingList<TtPoint>(dal.GetPointsInPolygon(_Poly1.CN));
                        cboStartPointPoly1.DataSource = point1StartList;
                        cboEndPointPoly1.DataSource = point1EndList;
                        cboEndPointPoly1.SelectedIndex = point1EndList.Count - 1;
                        ignorePolyChange = false;
                    }
                }
            }
        }

        private void cboPoly2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init)
            {
                if (cboPoly1.SelectedIndex == cboPoly2.SelectedIndex)
                {
                    MessageBox.Show("You cannot merge to the same polygon.");
                    ignorePolyChange = true;
                    cboPoly2.SelectedIndex = lastPolyIndex2;
                }
                else
                {
                    lastPolyIndex2 = cboPoly2.SelectedIndex;

                    if (ignorePolyChange)
                    {
                        _Poly2 = _Polys[lastPolyIndex2];
                        point1StartList = new BindingList<TtPoint>(dal.GetPointsInPolygon(_Poly2.CN));
                        point1EndList = new BindingList<TtPoint>(dal.GetPointsInPolygon(_Poly2.CN));
                        cboStartPointPoly2.DataSource = point2StartList;
                        cboEndPointPoly2.DataSource = point2EndList;
                        cboEndPointPoly2.SelectedIndex = point2EndList.Count - 1;
                        ignorePolyChange = false;
                    }
                }
            }
        }

        private void cboStartPointPoly1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init)
            {
                if (cboStartPointPoly1.SelectedIndex == cboEndPointPoly1.SelectedIndex)
                {
                    MessageBox.Show("You cannot start and end on the same point.");
                    cboStartPointPoly1.SelectedIndex = lastPoint1StartIndex;
                }
                else
                    lastPoint1StartIndex = cboStartPointPoly1.SelectedIndex;
            }
        }

        private void cboEndPointPoly1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init)
            {
                if (cboStartPointPoly1.SelectedIndex == cboEndPointPoly1.SelectedIndex)
                {
                    MessageBox.Show("You cannot start and end on the same point.");
                    cboEndPointPoly1.SelectedIndex = lastPoint1EndIndex;
                }
                else
                    lastPoint1EndIndex = cboEndPointPoly1.SelectedIndex;
            }
        }

        private void cboStartPointPoly2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init)
            {
                if (cboStartPointPoly2.SelectedIndex == cboEndPointPoly2.SelectedIndex)
                {
                    MessageBox.Show("You cannot start and end on the same point.");
                    cboStartPointPoly2.SelectedIndex = lastPoint2StartIndex;
                }
                else
                    lastPoint2StartIndex = cboStartPointPoly2.SelectedIndex;
            }
        }

        private void cboEndPointPoly2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init)
            {
                if (cboStartPointPoly2.SelectedIndex == cboEndPointPoly2.SelectedIndex)
                {
                    MessageBox.Show("You cannot start and end on the same point.");
                    cboEndPointPoly2.SelectedIndex = lastPoint2EndIndex;
                }
                else
                    lastPoint2EndIndex = cboEndPointPoly2.SelectedIndex;
            }
        }
    }
}
