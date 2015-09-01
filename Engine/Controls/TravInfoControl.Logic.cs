using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;
using TwoTrails.Engine;
using TwoTrails.LaserAccess;
using System.Threading;
using TwoTrails.Forms;

namespace TwoTrails.Controls
{
    public partial class TravInfoControl : UserControl
    {

        #region Laser Delegates
        public delegate void DelegateGotData(LaserData ld);
        public delegate void DelegateInvalidLaserString();
        public delegate void DelegateLaserStarted();
        public delegate void DelegateLaserEnded();
        public delegate void DeledateLaserError();

        public DelegateGotData m_DelegateGotData;
        public DelegateInvalidLaserString m_DelegateInvalidLaserString;
        public DelegateLaserStarted m_DelegateLaserStarted;
        public DelegateLaserEnded m_DelegateLaserEnded;
        public DeledateLaserError m_DelegateLaserError;
        #endregion


        public delegate void FAzTextChangedEvent();
        public event FAzTextChangedEvent FAzTextChanged;

        public delegate void BAzTextChangedEvent();
        public event BAzTextChangedEvent BAzTextChanged;

        public delegate void SlopeDistTextChangedEvent();
        public event SlopeDistTextChangedEvent SlopeDistTextChanged;

        public delegate void SlopeAngleTextChangedEvent();
        public event SlopeAngleTextChangedEvent SlopeAngleTextChanged;

        public delegate void GotFocusEvent();
        public event GotFocusEvent GotFocused;

        public delegate void ValuesSetEvent();
        public event ValuesSetEvent ValuesSet;


        public delegate void LaserActiveEvent(bool active);
        public event LaserActiveEvent LaserActive;

        private bool _locked, _lsrDelegatesOpened;
        
        private System.Windows.Forms.Timer _FlashTimer;
        private bool _FlashOn = false;

        public bool FlashAz
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
                            lblDiff.ForeColor = System.Drawing.Color.Red;
                        else
                            lblDiff.ForeColor = System.Drawing.Color.White;
                        _FlashOn = false;
                    }
                }
            }
        }

        public bool LaserAquireOpen { get; set; }


        public void Init()
        {
            _locked = true;

            _FlashTimer = new System.Windows.Forms.Timer();
            _FlashTimer.Interval = 1000;
            _FlashTimer.Tick += new EventHandler(_FlashTimer_Tick);

            m_DelegateGotData = new DelegateGotData(laserReceivingData);
            m_DelegateInvalidLaserString = new DelegateInvalidLaserString(laserReceivingInvalidData);
            m_DelegateLaserStarted = new DelegateLaserStarted(laserStarted);
            m_DelegateLaserEnded = new DelegateLaserEnded(laserEnded);
            m_DelegateLaserError = new DeledateLaserError(laserError);
        }
        private SideShotPoint _current;
#if !(PocketPC || WindowsCE || Mobile)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
#endif
        public SideShotPoint CurrentPoint
        {
            get { return _current; }
            set
            { 
                _current = value;

                SetTextBoxes();
                
                CalcAzDiff();
            }
        }

        TtMetaData _MetaData;
        public TtMetaData MetaData 
        {
            get { return _MetaData; }
            set
            {
                _MetaData = value;

                if (MetaData != null)
                {
                    if (MetaData.magDec != 0)
                        txtMagDecl.Text = MetaData.magDec.ToString();
                    else
                        txtMagDecl.Text = "";
                }
                else
                    txtMagDecl.Text = "";
            }
        }

        private void CalcAzDiff()
        {
            try
            {
                if (textBoxFAz.Text.Length > 0 && textBoxBAz.Text.Length > 0)
                {
                    double fwdAz = Convert.ToDouble(textBoxFAz.Text);
                    double backAz = Convert.ToDouble(textBoxBAz.Text);

                    if (_current.ForwardAz > -1 && _current.BackwardAz > -1)
                    {
                        double diff = TtUtils.AzimuthDiff(fwdAz, backAz);

                        if (diff != 0)
                        {
                            lblDiff.Text = diff.ToString();
                            lblDiff.Visible = true;

                            if (diff > 3 || diff < -3)
                                FlashAz = true;
                            else
                                FlashAz = false;
                        }
                        else
                        {
                            lblDiff.Text = String.Empty;
                            lblDiff.Visible = false;
                            FlashAz = false;
                        }
                    }
                    else
                    {
                        lblDiff.Text = String.Empty;
                        lblDiff.Visible = false;
                        FlashAz = false;
                    }
                }
                else
                {
                    lblDiff.Text = String.Empty;
                    lblDiff.Visible = false;
                    FlashAz = false;
                }
            }
            catch
            {
                lblDiff.Text = String.Empty;
                lblDiff.Visible = false;
            }
        }


        void _FlashTimer_Tick(object sender, EventArgs e)
        {
            if (!this.IsDisposed)
            {
                if (_FlashOn)
                {
                    if (Enabled)
                        lblDiff.ForeColor  = System.Drawing.Color.White;
                    else
                        lblDiff.ForeColor = System.Drawing.Color.Red;
                    _FlashOn = false;
                }
                else
                {
                    lblDiff.ForeColor = System.Drawing.Color.Red;
                    _FlashOn = true;
                }

                
            }
        }

        private void SetTextBoxes()
        {
            if (_current.ForwardAz == null || _current.ForwardAz < 0)
                textBoxFAz.Text = String.Empty;
            else
                textBoxFAz.Text = Math.Round((double)_current.ForwardAz, 3).ToString().Truncate(6);

            if (_current.BackwardAz == null || _current.BackwardAz < 0)
                textBoxBAz.Text = String.Empty;
            else
                textBoxBAz.Text = Math.Round((double)_current.BackwardAz, 3).ToString().Truncate(6);

            if (_MetaData != null)
            {
                lblSlopeUnit.Text = _MetaData.uomSlope.ToString();
                lblDistUnit.Text = _MetaData.uomDistance.ToString();
            }
            else
            {
                lblSlopeUnit.Text = String.Empty;
                lblDistUnit.Text = String.Empty;
            }

            textBoxSlpAng.Text = Math.Round(_current.SlopeAngle, 3).ToString().Truncate(5);

            textBoxSlpDist.Text = Math.Round(_current.SlopeDistance, 3).ToString().Truncate(10);

        }

        #region Controls

        private void textBoxFAz_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                _current.ForwardAz = Convert.ToDouble(textBoxFAz.Text);
            }
            catch
            {
                _current.ForwardAz = null;
            }

            if (FAzTextChanged != null)
            {
                FAzTextChanged();
            }

            CalcAzDiff();
        }

        private void textBoxBAz_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                _current.BackwardAz = Convert.ToDouble(textBoxBAz.Text);
            }
            catch
            {
                _current.BackwardAz = null;
            }

            if (BAzTextChanged != null)
            {
                BAzTextChanged();
            }

            CalcAzDiff();
        }

        private void textBoxSlpDist_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                _current.SlopeDistance = Convert.ToDouble(textBoxSlpDist.Text);
            }
            catch
            {
                _current.SlopeDistance = 0;
            }

            if (SlopeDistTextChanged != null)
            {
                SlopeDistTextChanged();
            }
        }

        private void textBoxSlpAng_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                _current.SlopeAngle = Convert.ToDouble(textBoxSlpAng.Text);
            }
            catch
            {
                _current.SlopeAngle = 0;
            }

            if (SlopeAngleTextChanged != null)
            {
                SlopeAngleTextChanged();
            }
        }


        #region Focus

        private void textBoxFAz_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, textBoxFAz);
            textBoxFAz.SelectAllViaInvoke();

            if (GotFocused != null)
                GotFocused();
        }

        private void textBoxSlpDist_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, textBoxFAz);
            textBoxSlpDist.SelectAllViaInvoke();
            if (GotFocused != null)
                GotFocused();
        }

        private void textBoxBAz_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, textBoxBAz);
            textBoxBAz.SelectAllViaInvoke();
            if (GotFocused != null)
                GotFocused();
        }

        private void textBoxSlpAng_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, textBoxSlpAng);
            textBoxSlpAng.SelectAllViaInvoke();
            if (GotFocused != null)
                GotFocused();
        }

        private void textBoxFAz_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void textBoxBAz_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void textBoxSlpDist_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void textBoxSlpAng_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void TravInfoControl_Click2(object sender, EventArgs e)
        {
            if (GotFocused != null)
                GotFocused();
            Kb.Hide(this);
        }
        #endregion
        #endregion

        public bool Locked
        {
            get { return _locked; }
            set
            {
                _locked = value;

                radBA.Enabled = !_locked;
                radFA.Enabled = !_locked;

#if (PocketPC || WindowsCE || Mobile)
                textBoxBAz.ReadOnly = _locked;
                textBoxFAz.ReadOnly = _locked;
                textBoxSlpAng.ReadOnly = _locked;
                textBoxSlpDist.ReadOnly = _locked;

                if (value)
                {
                    textBoxBAz.BackColor = System.Drawing.Color.LightGray;
                    textBoxFAz.BackColor = System.Drawing.Color.LightGray;
                    textBoxSlpAng.BackColor = System.Drawing.Color.LightGray;
                    textBoxSlpDist.BackColor = System.Drawing.Color.LightGray;
                }
                else
                {
                    textBoxBAz.BackColor = System.Drawing.Color.White;
                    textBoxFAz.BackColor = System.Drawing.Color.White;
                    textBoxSlpAng.BackColor = System.Drawing.Color.White;
                    textBoxSlpDist.BackColor = System.Drawing.Color.White;
                }
#else
                textBoxBAz.Enabled = !_locked;
                textBoxFAz.Enabled = !_locked;
                textBoxSlpAng.Enabled = !_locked;
                textBoxSlpDist.Enabled = !_locked;
#endif
            }
        }

        bool _UseLaser = true;
        public bool UseLaser
        {
            get
            {
                return _UseLaser;
            }

            set
            {
                _UseLaser = value;
                lblLaser.Visible = radFA.Visible = radBA.Visible = _UseLaser;
            }
        }



        public void Aquire()
        {
            if (!_lsrDelegatesOpened)
            {
                Values.LaserA.LaserEnded += new LaserAccess.LaserAccess.DelegateLaserEnded(LASERA_laserEnded);
                Values.LaserA.LaserStarted += new LaserAccess.LaserAccess.DelegateLaserStarted(LASERA_laserStarted);
                Values.LaserA.LaserError += new LaserAccess.LaserAccess.DelegateLaserError(LASERA_laserError);
                Values.LaserA.InvalidStringFound += new LaserAccess.LaserAccess.DelegateInvalidStringFound(LASERA_laserReceivingInvalidData);
                Values.LaserA.DataReceived += new LaserAccess.LaserAccess.DelegateDeliverData(LASERA_laserReceivingData);
                _lsrDelegatesOpened = true;

                if (!Values.LaserA.IsBusy)
                    Values.LaserA.OpenLaser(Values.Settings.DeviceOptions.LaserComPort, Values.Settings.DeviceOptions.LaserBaud);

                OnLaserActive(true);
            }

            LaserAquireOpen = true;
        }


        #region Laser Functions

        private void OnLaserActive(bool active)
        {
            if (LaserActive != null)
            {
                LaserActive(false);
            }

            if (active)
            {
                lblLaserActive.Text = "Active";
                lblLaserActive.ForeColor = Color.Red;
            }
            else
            {
                lblLaserActive.Text = "Not Active";
                lblLaserActive.ForeColor = SystemColors.ControlText;
            }
        }

        private void laserReceivingData(LaserData ld)
        {
            if (LaserAquireOpen)
            {
                try
                {
                    if (radFA.Checked)
                    {
                        _current.ForwardAz = ld._azimuth;
                    }
                    else
                    {
                        _current.BackwardAz = ld._azimuth;
                    }

                    _current.SlopeAngle = ld._inclination;
                    _current.SlopeDistance = TtUtils.ConvertDistance(ld._slope, _MetaData.uomDistance, TtUtils.UnitToUomDistance(ld._slope_unit));
                    
                    
                    SetTextBoxes();

                    if (ValuesSet != null)
                    {
                        ValuesSet();
                    }
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "TravInfoCtrl:laserReceivingData");
                }

                LaserAquireOpen = false;
            }
        }

        private void laserReceivingInvalidData()
        {
            MessageBox.Show("Laser Received Invalid Data.");
        }

        private void laserStarted()
        {
            //
        }

        private void laserEnded()
        {
            if (Values.LaserA.IsBusy)
                Values.LaserA.CloseLaser();

            if (_lsrDelegatesOpened)
            {
                Values.LaserA.LaserEnded -= new LaserAccess.LaserAccess.DelegateLaserEnded(LASERA_laserEnded);
                Values.LaserA.LaserStarted -= new LaserAccess.LaserAccess.DelegateLaserStarted(LASERA_laserStarted);
                Values.LaserA.LaserError -= new LaserAccess.LaserAccess.DelegateLaserError(LASERA_laserError);
                Values.LaserA.InvalidStringFound -= new LaserAccess.LaserAccess.DelegateInvalidStringFound(LASERA_laserReceivingInvalidData);
                Values.LaserA.DataReceived -= new LaserAccess.LaserAccess.DelegateDeliverData(LASERA_laserReceivingData);
                _lsrDelegatesOpened = false;

                OnLaserActive(false);
            }
        }

        private void laserError()
        {
            //remove delegates
            laserEnded();

            //resolve current error
            switch (Values.LaserA.Error)
            {
                case LaserErrorType.ComNotExist:
                    {
                        if (MessageBox.Show("The Laser is not connected to this COM port. Would you like to set up the Laser now?", "Invalid COM Port", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            using (DeviceSetupForm form = new DeviceSetupForm())
                            {
                                form.ShowDialog();
                            }
                        }
                        break;
                    }
                case LaserErrorType.LaserTimeout:



                    break;
                case LaserErrorType.NoError:
                    break;
                case LaserErrorType.UnknownError:
                default:
                    {
                        MessageBox.Show("An unknown error has occurred.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        break;
                    }
            }

            LaserAquireOpen = false;
        }

        #region Laser Delegates
        private void LASERA_laserReceivingData(LaserData ld)
        {
            this.Invoke(m_DelegateGotData, ld);
        }

        private void LASERA_laserReceivingInvalidData()
        {
            this.Invoke(m_DelegateInvalidLaserString);
        }

        private void LASERA_laserStarted()
        {
            this.Invoke(m_DelegateLaserStarted);
        }

        private void LASERA_laserEnded()
        {
            this.Invoke(m_DelegateLaserEnded);
        }

        private void LASERA_laserError()
        {
            this.Invoke(m_DelegateLaserError);
        }
        #endregion
        #endregion

    }
}
