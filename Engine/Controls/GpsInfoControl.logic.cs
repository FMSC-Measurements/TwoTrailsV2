using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;
using System.ComponentModel;

namespace TwoTrails.Controls
{
    public delegate void MiscClickEvent();

    partial class GpsInfoControl
    {

        /// <summary>
        /// Delete Nmea Data
        /// </summary>
        public delegate void DelNmea_Click(object sender, EventArgs e);

        /// <summary>
        /// Manual Accuracy Changed
        /// </summary>
        public delegate void ManAcc_TextChanged(object sender, EventArgs e);

        /// <summary>
        /// Z Changed
        /// </summary>
        public delegate void Z_TextChanged(object sender, EventArgs e);

        /// <summary>
        /// Y Changed
        /// </summary>
        public delegate void Y_TextChanged(object sender, EventArgs e);

        /// <summary>
        /// X Changed
        /// </summary>
        public delegate void X_TextChanged(object sender, EventArgs e);

        public delegate void GotFocusEvent();

        #region Events/Delegates
        public event X_TextChanged X_OnTextChanged;

        public event Y_TextChanged Y_OnTextChanged;

        public event Z_TextChanged Z_OnTextChanged;

        public event ManAcc_TextChanged ManAcc_OnTextChanged; 

        public event DelNmea_Click DelNmea_OnClick;

        public event GotFocusEvent GotFocused;

        public event MiscClickEvent MiscClick;
        #endregion

        private GpsPoint _current;
#if !(PocketPC || WindowsCE || Mobile)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
#endif
        public GpsPoint CurrentPoint
        {
            get { return _current; }
            set
            {
                _current = value;

                if (_current != null)
                {
                    UnhookEvents();
                    bindingSourcePoint.DataSource = _current;
                    bindingSourcePoint.ResetBindings(false);
                    HookupEvents();
                }
            }
        }

        TtMetaData _meta;
#if !(PocketPC || WindowsCE || Mobile)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
#endif
        public TtMetaData Meta
        {
            get { return _meta; }
            set
            {
                _meta = value;


                if (_meta != null)
                {
                    if (_meta.uomElevation == TwoTrails.Engine.UomElevation.Feet)
                        txtElevation.Text = "(Ft)";
                    else
                        txtElevation.Text = "(M)";
                }
            }
        }

        private bool _locked;
#if !(PocketPC || WindowsCE || Mobile)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
#endif
        public bool Locked
        {
            get { return _locked; }
            set
            {
                _locked = value;

#if (PocketPC || WindowsCE || Mobile)
                textBoxX.ReadOnly = _locked;
                textBoxY.ReadOnly = _locked;
                textBoxZ.ReadOnly = _locked;
                txtManAcc.ReadOnly = _locked;
                btnDelNmea.Enabled = !_locked;

                if (CurrentPoint != null && CurrentPoint.op == TwoTrails.Engine.OpType.WayPoint)
                {
                    btnMisc.Enabled = !_locked;
                }

                if (value)
                {
                    textBoxX.BackColor = System.Drawing.Color.LightGray;
                    textBoxY.BackColor = System.Drawing.Color.LightGray;
                    textBoxZ.BackColor = System.Drawing.Color.LightGray;
                    txtManAcc.BackColor = System.Drawing.Color.LightGray;
                    txtRMSE.BackColor = System.Drawing.Color.LightGray;
                    txtManAcc.BackColor = System.Drawing.Color.LightGray;
                }
                else
                {
                    textBoxX.BackColor = System.Drawing.Color.White;
                    textBoxY.BackColor = System.Drawing.Color.White;
                    textBoxZ.BackColor = System.Drawing.Color.White;
                    txtManAcc.BackColor = System.Drawing.Color.White;
                    txtRMSE.BackColor = System.Drawing.Color.White;
                    txtManAcc.BackColor = System.Drawing.Color.White;
                }
#else

                textBoxX.Enabled = !_locked;
                textBoxY.Enabled = !_locked;
                textBoxZ.Enabled = !_locked;
                txtManAcc.Enabled = !_locked;
                btnDelNmea.Enabled = !_locked;
#endif
            }
        }


        public bool ShowMiscButton
        {
            get { return btnMisc.Visible; }
            set { btnMisc.Visible = value; }
        }


        public string MiscButtonText
        {
            get { return btnMisc.Text; }
            set { btnMisc.Text = value; }
        }

        #region Text Changed Events
        private void textBoxX_TextChanged2(object sender, EventArgs e)
        {
            if (textBoxX.Text.IsDouble())
            {
                _current.UnAdjX = textBoxX.Text.ToDouble();
                //_current.UnAdjX = _current.X;
            }
            else
            {
                _current.UnAdjX = _current.UnAdjX = 0;
            }

            #region Trigger Event
            //Trigger Event
            if (X_OnTextChanged != null)
            {
                X_OnTextChanged(this, e);
            }
            #endregion 
        }

        private void textBoxY_TextChanged2(object sender, EventArgs e)
        {
            if (textBoxY.Text.IsDouble())
            {
                _current.UnAdjY = textBoxY.Text.ToDouble();
                //_current.UnAdjY = _current.Y;
            }
            else
            {
                _current.UnAdjY = _current.UnAdjY = 0;
            }

            #region Trigger Event
            //Trigger Event
            if (Y_OnTextChanged != null)
            {
                Y_OnTextChanged(this, e);
            }
            #endregion 
        }

        private void textBoxZ_TextChanged2(object sender, EventArgs e)
        {
            if (textBoxZ.Text.IsDouble())
            {
                _current.UnAdjZ = textBoxZ.Text.ToDouble();
                //_current.UnAdjZ = _current.Z;
            }
            else
            {
                _current.UnAdjZ = _current.UnAdjZ = 0;
            }

            #region Trigger Event
            //Trigger Event
            if (Z_OnTextChanged != null)
            {
                Z_OnTextChanged(this, e);
            }
            #endregion 
        }

        private void btnDelNmea_Click2(object sender, EventArgs e)
        {
            #region Trigger Event
            //Trigger Event
            if (DelNmea_OnClick != null)
            {
                DelNmea_OnClick(this, e);
            }
            #endregion
        }

        private void txtManAcc_TextChanged2(object sender, EventArgs e)
        {
            if (txtManAcc.Text.IsEmpty())
            {
                CurrentPoint.ManualAccuracy = null;
            }

            #region Trigger Event
            //Trigger Event
            if (ManAcc_OnTextChanged != null)
            {
                ManAcc_OnTextChanged(this, e);
            }
            #endregion 
        }
        #endregion

        #region Focus Events

        private void textBoxX_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, textBoxX);
            if (GotFocused != null)
                GotFocused();
        }

        private void textBoxY_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, textBoxY);
            if (GotFocused != null)
                GotFocused();
        }

        private void textBoxZ_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, textBoxZ);
            if (GotFocused != null)
                GotFocused();
        }

        private void txtManAcc_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtManAcc);
            if (GotFocused != null)
                GotFocused();
        }

        private void textBoxX_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void textBoxY_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void textBoxZ_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtManAcc_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void GpsInfoControl_Click2(object sender, EventArgs e)
        {
            if (GotFocused != null)
                GotFocused();
            Kb.Hide(this);
        }
        #endregion

        #region Event hook up/unhook

        private void UnhookEvents()
        {
            this.textBoxX.TextChanged -= new System.EventHandler(this.textBoxX_TextChanged);
            this.textBoxY.TextChanged -= new System.EventHandler(this.textBoxY_TextChanged);
            this.textBoxZ.TextChanged -= new System.EventHandler(this.textBoxZ_TextChanged);

        }

        private void HookupEvents()
        {
            this.textBoxX.TextChanged += new System.EventHandler(this.textBoxX_TextChanged);
            this.textBoxY.TextChanged += new System.EventHandler(this.textBoxY_TextChanged);
            this.textBoxZ.TextChanged += new System.EventHandler(this.textBoxZ_TextChanged);
        }

        #endregion
    }
}
