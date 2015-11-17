using System;
using System.Collections.Generic;
using System.Text;
using TwoTrails.Engine;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;
using TwoTrails.Forms;
using System.Windows.Forms;
using System.ComponentModel;

namespace TwoTrails.Controls
{
    partial class PointInfoCtrl : UserControl
    {
        #region Events/Delegates

        /// <summary>
        /// PID text box gets focus
        /// </summary>
        public delegate void PID_Enter();
        public event PID_Enter OnPID_Enter;

        /// <summary>
        /// Comment text box gets focus
        /// </summary>
        public delegate void Comment_Enter();
        public event Comment_Enter OnComment_Enter;

        /// <summary>
        /// Boundary Button is clicked
        /// </summary>
        public delegate void Boundary_Click();
        public event Boundary_Click OnBoundary_Click;

        /// <summary>
        /// Op selection changed
        /// </summary>
        public delegate void Op_SelectedIndexChanged();
        public event Op_SelectedIndexChanged OnOp_SelectedIndexChanged;

        /// <summary>
        /// Polygon selection changed
        /// </summary>
        public delegate void Poly_SelectedIndexChanged();
        public event Poly_SelectedIndexChanged OnPoly_SelectedIndexChanged;

        /// <summary>
        /// Metadata definition selection changed
        /// </summary>
        public delegate void MetaDef_SelectedIndexChanged();
        public event MetaDef_SelectedIndexChanged OnMetaDef_SelectedIndexChanged;

        /// <summary>
        /// Check state of the locked checkbox changed
        /// </summary>
        public delegate void Locked_CheckedChanged(object sender, LockStateEventArgs e);
        public event Locked_CheckedChanged OnLocked_CheckedChanged;

        /// <summary>
        /// Comment Text changed
        /// </summary>
        public delegate void Comment_TextChanged(object sender, EventArgs e);
        public event Comment_TextChanged Comment_OnTextChanged;

        /// <summary>
        /// PID Text Changed
        /// </summary>
        public delegate void PID_TextChanged(object sender, EventArgs e);
        public event PID_TextChanged PID_OnTextChanged;

        /// <summary>
        /// Linked Image Clicked
        /// </summary>
        public delegate void LinkedPointClickedEvent();
        public event LinkedPointClickedEvent LinkedPointClicked;

        #endregion


        #region members
        private TtPoint _currentPoint;
        [NonSerialized()]
        private List<TtPolygon> _polygons;
        private List<TtMetaData> _metaDefs;
        private List<string> MetaDefCNs;
        private List<OpType> _ops;

        private Timer _FlashTimer;
        private bool _FlashOn = false;

        #endregion

        #region Properties
#if !(PocketPC || WindowsCE || Mobile)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
#endif
        public string Comment
        {
            get
            {
                if (tbComment != null)
                    return tbComment.Text;
                else
                    return String.Empty;
            }
            set { tbComment.Text = value; }
        }
#if !(PocketPC || WindowsCE || Mobile)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
#endif
        public string PID
        {
            get
            {
                if (tbPID != null)
                    return tbPID.Text;
                else
                    return String.Empty; ;
            }
            set
            {
                if(tbPID != null)
                    tbPID.Text = value;
            }
        }
#if !(PocketPC || WindowsCE || Mobile)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
#endif
        public string PolyID
        {
            get
            {
                if (cbPoly != null)
                {
                    if (cbPoly.SelectedIndex == -1)
                        return String.Empty;
                    return ((TtPolygon)cbPoly.SelectedItem).Name;
                }
                return String.Empty;
            }
            set
            {
                int index = cbPoly.FindString((string)value);
                if (index > -1)
                    cbPoly.SelectedIndex = index;
            }
        }
#if !(PocketPC || WindowsCE || Mobile)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
#endif
        public TtPolygon Polygon
        {
            get
            {
                if (cbPoly != null)
                {
                    if (cbPoly.SelectedIndex == -1)
                        return new TtPolygon();
                    return (TtPolygon)cbPoly.SelectedItem;
                }
                return null;
            }
        }
#if !(PocketPC || WindowsCE || Mobile)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
#endif
        public string MetaDefCN
        {
            get
            {
                if (MetaDefCNs != null && MetaDefCNs.Count > 0 && cbMetaDef != null)
                    return MetaDefCNs[cbMetaDef.SelectedIndex];
                else
                    return String.Empty;
            }
            set
            {
                if (MetaDefCNs != null)
                    cbMetaDef.SelectedIndex = MetaDefCNs.IndexOf(value);
            }
        }

#if !(PocketPC || WindowsCE || Mobile)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
#endif
        public bool OnBoundary
        {
            get
            {
                if (btnBoundary != null)
                    return (btnBoundary.Text == Values.On);
                return false;
            }
            set
            {
                UpdateBoundaryButton(value);
            }
        }
#if !(PocketPC || WindowsCE || Mobile)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
#endif
        public OpType Op
        {
            get
            {
                if (cbOp != null)
                {
                    if (cbOp.SelectedIndex == -1)
                        return OpType.GPS;
                    else
                        //return (TwoTrails.Engine.OpType)Enum.Parse(typeof(TwoTrails.Engine.OpType), (string)cbOp.SelectedItem, true);
                        return (TwoTrails.Engine.OpType)cbOp.SelectedItem;
                }
                return OpType.GPS;
            }
            set
            {
                int index = cbOp.FindStringExact(value.ToString());
                if (index != -1)
                {
                    cbOp.SelectedIndex = index;
#if (PocketPC || WindowsCE || Mobile)
                    btnOp.Text = cbOp.Text;
#endif
                }
            }
        }

        public void SetPolygons(List<TtPolygon> polys)
        {
            _polygons = polys;
            bindingSourcePolys.DataSource = _polygons;
            bindingSourcePolys.ResetBindings(false);
        }

        public void SetMetaDefs(List<TtMetaData> metas)
        {
            if (_metaDefs == null)
                _metaDefs = new List<TtMetaData>();

            if (MetaDefCNs == null)
                MetaDefCNs = new List<string>();

            _metaDefs = metas;

            cbMetaDef.Items.Clear();
            MetaDefCNs.Clear();

            foreach (TtMetaData m in _metaDefs)
            {
                cbMetaDef.Items.Add(m.Name);
                MetaDefCNs.Add(m.CN);
            }

            bindingSourceMetaDefs.DataSource = MetaDefCNs;
            bindingSourceMetaDefs.ResetBindings(false);
        }

        public void SetOps(List<OpType> ops)
        {
            _ops = ops;
        }
#if !(PocketPC || WindowsCE || Mobile)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
#endif
        public TtPoint CurrentPoint
        {
            get { return _currentPoint; }
            set
            {
                if (value == null)
                {
                    bindingSourcePoint.DataSource = new TtPoint();// typeof(TwoTrails.BusinessObjects.TtPoint);
                    _currentPoint = null;
                    chkLocked.Enabled = false;
                }
                else
                {
                    UnhookEvents();
                    _currentPoint = value;
                    bindingSourcePoint.DataSource = value;
                    bindingSourcePoint.ResetBindings(false);

                    if (_currentPoint != null && _currentPoint.HasQuondamLinks)
                        picLinked.Visible = true;
                    else
                        picLinked.Visible = false;

                    UpdateBoundaryButton(_currentPoint.OnBnd);
                    Op = _currentPoint.op;
                    PolyID = _currentPoint.PolyName;
                    MetaDefCN = _currentPoint.MetaDefCN;

                    HookupEvents();
                    chkLocked.Enabled = true;
                }
            }
        }

        private bool _ReadOnly;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;

                if (chkLocked == null || chkLocked.IsDisposed)
                    return;

                chkLocked.Checked = _ReadOnly;
                cbMetaDef.Enabled = !_ReadOnly;
                cbOp.Enabled = !_ReadOnly;

#if (PocketPC || WindowsCE || Mobile)
                btnOp.Enabled = !_ReadOnly;
                tbComment.ReadOnly = _ReadOnly;
                tbPID.ReadOnly = _ReadOnly;
                if (_ReadOnly)
                {
                    tbPID.BackColor = System.Drawing.Color.LightGray;
                    tbComment.BackColor = System.Drawing.Color.LightGray;
                }
                else
                {
                    tbPID.BackColor = System.Drawing.Color.White;
                    tbComment.BackColor = System.Drawing.Color.White;
                }
#else
                tbComment.Enabled = !_ReadOnly;
                tbPID.Enabled = !_ReadOnly;
#endif
                btnBoundary.Enabled = !_ReadOnly;
            }
        }

        public bool CheckLockEnabled
        {
            get { return chkLocked.Enabled; }
            set { chkLocked.Enabled = value; }
        }

        public bool FlashPoint
        {
            get { return _FlashTimer.Enabled; }
            set
            {
                if (value)
                {
                    if (!_FlashTimer.Enabled)
                        _FlashTimer.Enabled = true;
                }
                else
                {
                    if (_FlashTimer.Enabled)
                    {
                        _FlashTimer.Enabled = false;
                        if (Enabled)
                            tbPID.ForeColor = System.Drawing.Color.Black;
                        else
                            tbPID.ForeColor = System.Drawing.Color.Gray;
                        _FlashOn = false;
                    }
                }
            }
        }

        #endregion


        public PointInfoCtrl()
        {
            InitializeComponent();

            try
            {
                picLinked.Image = Properties.Resources.ChainLink_512;
            }
            catch
            {
                TwoTrails.Utilities.TtUtils.WriteError("Failed to assign image to picLinked.", "PointInfoCtrl:Constructor");
            }

            _FlashTimer = new Timer();
            _FlashTimer.Interval = 1000;
            _FlashTimer.Tick += new EventHandler(_FlashTimer_Tick);

            if (_polygons == null)
                _polygons = new List<TtPolygon>();
            bindingSourcePolys.DataSource = _polygons;
            if (_ops == null)
            {
                _ops = new List<OpType>();
                _ops.Add(OpType.GPS);
                _ops.Add(OpType.SideShot);
                _ops.Add(OpType.Take5);
                _ops.Add(OpType.Walk);
                _ops.Add(OpType.Traverse);
                _ops.Add(OpType.Quondam);
                _ops.Add(OpType.WayPoint);
            }
            bindingSourceOps.DataSource = _ops;
            cbOp.DataSource = bindingSourceOps;
            bindingSourceOps.ResetBindings(false);

            if (_metaDefs == null)
                _metaDefs = new List<TtMetaData>();
            bindingSourceMetaDefs.DataSource = _metaDefs;

            MetaDefCNs = new List<string>();


            //Switch between comboBox and a selection form

#if (PocketPC || WindowsCE || Mobile)
            btnOp.Text = cbOp.Text;
            if (Values.Settings.DeviceOptions.UseSelection)
            {
                cbOp.Visible = false;
                btnOp.Visible = true;
            }
            else
            {
                cbOp.Visible = true;
                btnOp.Visible = false;
            }
#else
            cbOp.Visible = true;
#endif
        }

        void _FlashTimer_Tick(object sender, EventArgs e)
        {
            if (!this.IsDisposed)
            {
                if (_FlashOn)
                {
                    if (Enabled)
                        tbPID.ForeColor = System.Drawing.Color.Black;
                    else
                        tbPID.ForeColor = System.Drawing.Color.Gray;
                    _FlashOn = false;
                }
                else
                {
                    tbPID.ForeColor = System.Drawing.Color.Red;
                    _FlashOn = true;
                }
            }
        }


        public void SetPolyIndex(int index)
        {
            cbPoly.SelectedIndex = index;
        }

        #region Events
        private void cbPoly_SelectedIndexChanged2(object sender, EventArgs e)
        {
            FlashPoint = false;

            TtPolygon p = (TtPolygon)cbPoly.SelectedItem;
            if (p != null)
            {
                if (CurrentPoint != null)
                {
                    UnhookEvents();
                    bindingSourcePoint.DataSource = CurrentPoint;
                    HookupEvents();
                }
            }
            #region Trigger Event
            if (OnPoly_SelectedIndexChanged != null)
            {
                OnPoly_SelectedIndexChanged();
            }
            #endregion

        }

        private void cbMetaDef_SelectedIndexChanged2(object sender, EventArgs e)
        {
            FlashPoint = false;

            string m = MetaDefCNs[cbMetaDef.SelectedIndex];
            if (m != null)
            {
                CurrentPoint.MetaDefCN = m;
            }
            #region Trigger Event
            if (OnMetaDef_SelectedIndexChanged != null)
            {
                OnMetaDef_SelectedIndexChanged();
            }
            #endregion
        }

        private void tbPID_Enter(object sender, EventArgs e)
        {
            FlashPoint = false;

            #region Trigger Event
            //Trigger Event
            if (OnPID_Enter != null)
            {
                OnPID_Enter();
            }
            #endregion
        }

        private void btnBoundary_Click2(object sender, EventArgs e)
        {
            FlashPoint = false;

            UpdateBoundaryButton(btnBoundary.Text != Values.On);

            #region Trigger Event
            //Trigger Event
            if (OnBoundary_Click != null)
            {
                OnBoundary_Click();
            }
            #endregion
        }

        private void UpdateBoundaryButton(bool onBndry)
        {
            FlashPoint = false;

            switch (onBndry)
            {
                case true:
                    {
                        btnBoundary.Text = Values.On;
                        if (_currentPoint != null)
                            _currentPoint.OnBnd = true;
                        break;
                    }
                default:
                    {
                        btnBoundary.Text = Values.Off;
                        if (_currentPoint != null)
                            _currentPoint.OnBnd = false;
                        break;
                    }
            }
        }

        private void cbOp_SelectedIndexChanged2(object sender, EventArgs e)
        {
            FlashPoint = false;

            #region Trigger Event
            //Trigger Event
            if (OnOp_SelectedIndexChanged != null)
            {
                OnOp_SelectedIndexChanged();
            }
            #endregion
        }

        private void tbComment_Enter(object sender, EventArgs e)
        {
            FlashPoint = false;

            #region Trigger Event
            //Trigger Event
            if (OnComment_Enter != null)
            {
                OnComment_Enter();
            }
            #endregion
        }

        private void chkLocked_CheckStateChanged2(object sender, EventArgs e)
        {
            FlashPoint = false;

            if (_currentPoint != null)
            {
                ReadOnly = chkLocked.Checked;

                #region Trigger Event
                //Trigger Event
                if (OnLocked_CheckedChanged != null)
                {
                    LockStateEventArgs e2 = new LockStateEventArgs();
                    e2.Locked = chkLocked.Checked;
                    OnLocked_CheckedChanged(this, e2);
                }
                #endregion
            }
        }

        private void tbPID_TextChanged2(object sender, EventArgs e)
        {
            FlashPoint = false;

            if (!tbPID.Text.IsEmpty())
            {
                #region Trigger Event
                //Trigger Event
                if (PID_OnTextChanged != null)
                {
                    PID_OnTextChanged(this, e);
                }
                #endregion

                if (tbPID.Text.IsInteger())
                    CurrentPoint.PID = Convert.ToInt32(tbPID.Text);
            }
        }

        private void tbComment_TextChanged2(object sender, EventArgs e)
        {
            FlashPoint = false;

            #region Trigger Event
            //Trigger Event
            if (Comment_OnTextChanged != null)
            {
                Comment_OnTextChanged(this, e);
            }
            #endregion
            CurrentPoint.Comment = tbComment.Text;
        }

#if (PocketPC || WindowsCE || Mobile)
        private void btnOp_Click2(object sender, EventArgs e)
        {
            FlashPoint = false;

            List<string> _ops = new List<string>();

            _ops.Add("GPS");
            _ops.Add("SideShot");
            _ops.Add("Take5");
            _ops.Add("Walk");
            _ops.Add("Traverse");
            _ops.Add("Quondam");
            _ops.Add("WayPoint");

            using (Selection f = new Selection("Operations", _ops, cbOp.SelectedIndex))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    cbOp.SelectedIndex = f.selection;
                    btnOp.Text = cbOp.Text;
                }
            }
        }
#endif
        private void picLinked_Click2(object sender, EventArgs e)
        {
            FlashPoint = false;

            if (LinkedPointClicked != null)
            {
                LinkedPointClicked();
            }
        }

        #region Focus
        private void PointInfoCtrl_Click2(object sender, EventArgs e)
        {
            FlashPoint = false;

            Kb.Hide(this);
        }

        private void tbPID_GotFocus2(object sender, EventArgs e)
        {
            FlashPoint = false;

            if (!tbPID.ReadOnly)
                Kb.ShowNumeric(this, tbPID);
        }

        private void tbComment_GotFocus2(object sender, EventArgs e)
        {
            FlashPoint = false;

            if (!tbComment.ReadOnly)
                Kb.ShowRegular(this, tbComment);
        }

        private void tbPID_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void tbComment_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }
        #endregion
        #endregion

        #region Event hook up/unhook
        private void UnhookEvents()
        {
            this.cbPoly.SelectedIndexChanged -= new System.EventHandler(this.cbPoly_SelectedIndexChanged);
            this.cbOp.SelectedIndexChanged -= new System.EventHandler(this.cbOp_SelectedIndexChanged);
            this.tbComment.TextChanged -= new System.EventHandler(this.tbComment_TextChanged);
            this.tbPID.TextChanged -= new System.EventHandler(this.tbPID_TextChanged);
            this.cbMetaDef.SelectedIndexChanged -= new System.EventHandler(this.cbMetaDef_SelectedIndexChanged);

        }

        private void HookupEvents()
        {
            this.cbPoly.SelectedIndexChanged += new System.EventHandler(this.cbPoly_SelectedIndexChanged);
            this.cbOp.SelectedIndexChanged += new System.EventHandler(this.cbOp_SelectedIndexChanged);
            this.tbComment.TextChanged += new System.EventHandler(this.tbComment_TextChanged);
            this.tbPID.TextChanged += new System.EventHandler(this.tbPID_TextChanged);
            this.cbMetaDef.SelectedIndexChanged += new System.EventHandler(this.cbMetaDef_SelectedIndexChanged);

        }
        #endregion
    }

    public class LockStateEventArgs : EventArgs
    {
        public bool Locked { get; set; }
    }
}
