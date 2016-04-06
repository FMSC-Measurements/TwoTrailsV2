using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Forms;
using TwoTrails.Engine;
using TwoTrails.Utilities;

namespace TwoTrails.Controls
{
    public partial class Take5InfoCtrl : UserControl
    {
        public delegate void BurstAmountChangedEvent();
        public event BurstAmountChangedEvent BurstAmountChanged;
        public delegate void ButtonHideEvent();
        public event ButtonHideEvent ButtonHide;
        public delegate void GotFocusEvent();
        public event GotFocusEvent GotFocused;

        private bool _locked;

        public void Init()
        {
            if (Values.Settings.DeviceOptions.Filter_T5_DOP_TYPE == 0)
            {
#if (PocketPC || WindowsCE || Mobile)
                btnDOP.Text = "PDOP";
#endif
                cboDOP.SelectedIndex = 0;
            }
            else
            {
#if (PocketPC || WindowsCE || Mobile)
                btnDOP.Text = "HDOP";
#endif
                cboDOP.SelectedIndex = 1;
            }

            cboFixType.SelectedIndex = Values.Settings.DeviceOptions.Filter_T5_FixType;

            txtIgnore.Text = Values.Settings.DeviceOptions.IgnoreFirstX.ToString();
            chkIgnoreNmea.Checked = Values.Settings.DeviceOptions.IgnoreFirst;

#if (PocketPC || WindowsCE || Mobile)
            btnFixType.Text = cboFixType.Text;

            if (Values.Settings.DeviceOptions.UseSelection)
            {
                btnDOP.Visible = true;
                btnFixType.Visible = true;
                cboDOP.Visible = false;
                cboFixType.Visible = false;
            }
            else
            {
                btnDOP.Visible = false;
                btnFixType.Visible = false;
                cboDOP.Visible = true;
                cboFixType.Visible = true;
            }
#endif

            txtDOP.Text = Values.Settings.DeviceOptions.Filter_T5_DOP_VALUE.ToString();
            txtBursts.Text = Values.Settings.DeviceOptions.Take5NmeaAmount.ToString();

            _locked = true;
        }

        #region Controls

#if (PocketPC || WindowsCE || Mobile)
        private void btnDOP_Click2(object sender, EventArgs e)
        {
            List<string> cboItems = new List<string>();

            foreach (object item in cboDOP.Items)
            {
                cboItems.Add(item.ToString());
            }

            using (Selection form = new Selection("Dilution of Precision", cboItems, cboDOP.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    btnDOP.Text = cboItems[form.selection].ToString();
                    cboDOP.SelectedIndex = form.selection;

                    Values.Settings.DeviceOptions.Filter_T5_DOP_TYPE = form.selection;
                }
            }

        }

        private void btnFixType_Click2(object sender, EventArgs e)
        {
            List<string> cboItems = new List<string>();

            foreach (object item in cboFixType.Items)
            {
                cboItems.Add(item.ToString());
            }

            using (Selection form = new Selection("Fix Type", cboItems, cboFixType.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    btnFixType.Text = cboItems[form.selection].ToString();
                    cboFixType.SelectedIndex = form.selection;

                    Values.Settings.DeviceOptions.Filter_T5_FixType = form.selection;
                }
            }

        }
#endif

        private void cboDOP_SelectedIndexChanged2(object sender, EventArgs e)
        {
#if (PocketPC || WindowsCE || Mobile)
            btnDOP.Text = cboDOP.Text;
#endif
            Values.Settings.DeviceOptions.Filter_T5_DOP_TYPE = cboDOP.SelectedIndex;
        }
        
        private void cboFixType_SelectedIndexChanged2(object sender, EventArgs e)
        {
#if (PocketPC || WindowsCE || Mobile)
            btnFixType.Text = cboFixType.Text;
#endif

            Values.Settings.DeviceOptions.Filter_T5_FixType = cboFixType.SelectedIndex;
        }


        private void txtDOP_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                Values.Settings.DeviceOptions.Filter_T5_DOP_VALUE = Convert.ToInt32(txtDOP.Text);

                if (Values.Settings.DeviceOptions.Filter_T5_DOP_VALUE < 0)
                {
                    Values.Settings.DeviceOptions.Filter_T5_DOP_VALUE = Values.Settings.DeviceOptions.DEFAULT_T5_DOP_TYPE;
                }
            }
            catch
            {
                //Filter_DOP_VALUE stays the same
            }
        }

        private void txtBursts_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                Values.Settings.DeviceOptions.Take5NmeaAmount = Convert.ToInt32(txtBursts.Text);

                if (Values.Settings.DeviceOptions.Take5NmeaAmount < 1)
                {
                    Values.Settings.DeviceOptions.Take5NmeaAmount = Values.Settings.DeviceOptions.DEFAULT_NMEA_AMOUNT;
                }

                if (BurstAmountChanged != null)
                {
                    BurstAmountChanged();
                }
            }
            catch
            {
                //Take5NmeaAmount stays the same
            }
        }

        private void txtIgnore_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                Values.Settings.DeviceOptions.IgnoreFirstX = Convert.ToInt32(txtIgnore.Text);

                if (Values.Settings.DeviceOptions.IgnoreFirstX < 0)
                {
                    Values.Settings.DeviceOptions.IgnoreFirstX = Values.Settings.DeviceOptions.DEFAULT_IGNORE_AMOUNT;
                }
            }
            catch
            {

            }
        }

        private void chkIgnoreNmea_CheckStateChanged2(object sender, EventArgs e)
        {
            Values.Settings.DeviceOptions.IgnoreFirst = chkIgnoreNmea.Checked;

            txtIgnore.Enabled = Values.Settings.DeviceOptions.IgnoreFirst;
        }

        private void btnHide_Click2(object sender, EventArgs e)
        {
            if (ButtonHide != null)
                ButtonHide();
        }

        #region Focus
        private void ControlsFocused()
        {
            if (GotFocused != null)
                GotFocused();
        }

        private void txtDOP_GotFocus2(object sender, EventArgs e)
        {
            ControlsFocused();
            Kb.ShowNumeric(this, txtDOP);
        }

        private void txtBursts_GotFocus2(object sender, EventArgs e)
        {
            ControlsFocused();
            Kb.ShowNumeric(this, txtBursts);
        }

        private void txtIgnore_GotFocus2(object sender, EventArgs e)
        {
            ControlsFocused();
            Kb.ShowNumeric(this, txtBursts);
        }

        private void txtDOP_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtBursts_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtIgnore_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void Take5InfoCtrl_Click2(object sender, EventArgs e)
        {
            ControlsFocused();
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

                cboDOP.Enabled = !_locked;
#if (PocketPC || WindowsCE || Mobile)
                btnDOP.Enabled = !_locked;
                btnFixType.Enabled = !_locked;
#endif
                cboFixType.Enabled = !_locked;
                txtDOP.Enabled = !_locked;
                txtBursts.Enabled = !_locked;
            }
        }
    }
}
