using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;
using TwoTrails.Utilities;
using TwoTrails.Engine;

namespace TwoTrails.Controls
{
    public partial class QuondamInfoControl : UserControl
    {
        #region Events/Delegates
        /// <summary>
        /// Point Changed
        /// </summary>
        public delegate void SelectedPointChanged();
        public event SelectedPointChanged Point_OnIndexChanged;

        /// <summary>
        /// Polygon Changed
        /// </summary>
        public delegate void SelectedPolygonChanged();
        public event SelectedPolygonChanged Polygon_OnIndexChanged;

        /// <summary>
        /// Retraced
        /// </summary>
        public delegate void PointsRetracedEvent();
        public event PointsRetracedEvent PointsRetraced;

        /// <summary>
        /// Converted Point
        /// </summary>
        public delegate void PointConvertedEvent();
        public event PointConvertedEvent PointConverted;

        public delegate void GotFocusEvent();
        public event GotFocusEvent GotFocused;

        #endregion

        private bool _locked;
        private DataAccessLayer _dal;
        private QuondamPoint _current;
        private List<TtPolygon> _polygons;
        private List<TtPoint> _points;
        public List<TtPolygon> Polygons
        {
            get
            {
                return _polygons;
            }
            set
            {
                _polygons = value;

                if (_polygons != null)
                {
                    UnhookEvents();
                    ttPolygonBindingSource.DataSource = _polygons;
                    HookupEvents();

                    LoadListboxes();

                    if (_polygons.Count > 0)
                        listBoxPolygon.SelectedIndex = 0;
                }

            }
        }
        public DataAccessLayer DAL {
            get
            {
                return _dal;
            }

            set
            {
                _dal = value;
                if (_polygons != null && _polygons.Count > 0)
                {
                    LoadListboxes(_polygons[listBoxPolygon.SelectedIndex]);
                }
            }
        }

        public void Init()
        {
            _locked = true;
            _points = new List<TtPoint>();
            _polygons = new List<TtPolygon>();
            _current = null;
        }

        public QuondamPoint CurrentPoint
        {
            get { return _current; }
            set
            {
                _current = value;
                bindingSource1.DataSource = value;
                //listBoxPolygon.SelectedItem = _current;
                TtPoint parent = _current.ParentPoint;


                if (parent != null && parent.PolyCN != null && parent.PolyCN != "")
                {
                    for (int i = 0; i < _polygons.Count; i++)
                    {
                        if (_polygons[i].CN == parent.PolyCN)
                        {
                            listBoxPolygon.SelectedIndex = i;
                            break;
                        }
                    }


                    if (Polygons.Count > 0)
                    {
                        if (listBoxPID.Items.Count == 0)
                        {
                            LoadListboxes(Polygons.Where(p => p.CN == parent.PolyCN).First());
                        }

                        for (int j = 0; j < _points.Count; j++)
                        {
                            if (_points[j].CN == parent.CN)
                            {
                                listBoxPID.SelectedIndex = j;
                                break;
                            }
                        }
                    }
                }
            }
        }

        #region Controls
        private void ControlFocused()
        {
            if (GotFocused != null)
                GotFocused();
        }

        public void LoadListboxes()
        {
            if (listBoxPolygon.SelectedIndex < _polygons.Count && listBoxPolygon.SelectedIndex > -1)
                LoadListboxes(_polygons[listBoxPolygon.SelectedIndex]);
            else if (_polygons.Count > 0)
                LoadListboxes(_polygons[0]);
        }

        private void LoadListboxes(TtPolygon poly)
        {
            if (poly == null)
            {
                listBoxPID.Items.Clear();
            }
            else
            {
                if (DAL != null)
                {
                    try
                    {
                        _points = DAL.GetPointsInPolygon(poly.CN).Where(p => p.op != OpType.WayPoint && p.op != OpType.Quondam).ToList();

                        #region Trigger Event
                        if (Polygon_OnIndexChanged != null)
                        {
                            Polygon_OnIndexChanged();
                        }
                        #endregion

                        if (_current != null)
                        {
                            TtPointBindingSource.DataSource = _points;

                            if (_current.ParentPoint == null)
                            {
#if !(PocketPC || WindowsCE || Mobile)
                                listBoxPID.ClearSelected();
#else
                                listBoxPID.SelectedItem = null;
#endif
                            }
                            else
                            {
                                listBoxPID.SelectedItem = _current;
                            }
                        }
                        else
                        {
                            listBoxPID.Items.Clear();
                        }
                    }
                    catch
                    {
                        
                    }
                }
            }
        }

        private void listBoxPolygon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlFocused();
            TtPolygon selected = (TtPolygon)listBoxPolygon.SelectedItem;
            LoadListboxes(selected);
        }

        private void listBoxPID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_current == null || listBoxPID.SelectedItem == null)
                return;

            ControlFocused();
            TtPoint selected = (TtPoint)listBoxPID.SelectedItem;

            if (selected.CN == _current.CN)
            {
                CurrentPoint.ParentPoint = null;
                MessageBox.Show("You cannot link a point to itself.");
            }
            else
            {
                if (selected.op == TwoTrails.Engine.OpType.Quondam)
                {
                    TtPoint tmpPoint = selected;
                    while (tmpPoint != null && tmpPoint.op == TwoTrails.Engine.OpType.Quondam)
                    {
                        tmpPoint = ((QuondamPoint)tmpPoint).ParentPoint;
                    }

                    CurrentPoint.ParentPoint = tmpPoint;
                }
                else
                    CurrentPoint.ParentPoint = selected;
            }

            #region Trigger Event
            if (Point_OnIndexChanged != null)
            {
                Point_OnIndexChanged();
            }
            #endregion
        }

        private void btnRetrace_Click2(object sender, EventArgs e)
        {
            ControlFocused();
            if (PointsRetraced != null)
            {
                PointsRetraced();
            }
        }

        private void btnConvert_Click2(object sender, EventArgs e)
        {
            ControlFocused();
            if (PointConverted != null)
            {
                PointConverted();
            }
        }
        #endregion

        #region Event hook up/unhook
        private void UnhookEvents()
        {
            this.listBoxPolygon.SelectedIndexChanged -= new System.EventHandler(this.listBoxPolygon_SelectedIndexChanged);
        }

        private void HookupEvents()
        {
            this.listBoxPolygon.SelectedIndexChanged += new System.EventHandler(this.listBoxPolygon_SelectedIndexChanged);
        }
        #endregion

        public int PointListIndex
        { get { return listBoxPID.SelectedIndex; } }

        public int PolyListIndex
        { get { return listBoxPolygon.SelectedIndex; } }

        public bool Locked
        {
            get { return _locked; }
            set
            {
                _locked = value;

                listBoxPID.Enabled = !_locked;
                listBoxPolygon.Enabled = !_locked;
                btnRetrace.Enabled = !_locked;
                btnConvert.Enabled = !_locked;
            }
        }
    }
}
