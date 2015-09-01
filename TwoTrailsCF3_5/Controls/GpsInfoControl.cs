using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using System.Runtime.InteropServices;
using TwoTrails.Utilities;

namespace TwoTrails.Controls
{

    public partial class GpsInfoControl : UserControl
    {
        public GpsInfoControl()
        {
            if(Engine.Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();

            btnMisc.MakeMultiline();
            _locked = true;
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        #region Text changed events
        private void textBoxZ_TextChanged(object sender, EventArgs e)
        {
            textBoxZ_TextChanged2(sender, e);
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            textBoxY_TextChanged2(sender, e);
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            textBoxX_TextChanged2(sender, e);
        }

        private void btnDelNmea_Click(object sender, EventArgs e)
        {
            btnDelNmea_Click2(sender, e);
        }

        private void txtManAcc_TextChanged(object sender, EventArgs e)
        {
            txtManAcc_TextChanged2(sender, e);
        }
        #endregion



        #region Focus Events

        private void textBoxZ_GotFocus(object sender, EventArgs e)
        {
            textBoxZ_GotFocus2(sender, e);
        }

        private void textBoxY_GotFocus(object sender, EventArgs e)
        {
            textBoxY_GotFocus2(sender, e);
        }

        private void textBoxX_GotFocus(object sender, EventArgs e)
        {
            textBoxX_GotFocus2(sender, e);
        }

        private void txtManAcc_GotFocus(object sender, EventArgs e)
        {
            txtManAcc_GotFocus2(sender, e);
        }

        private void textBoxX_LostFocus(object sender, EventArgs e)
        {
            textBoxX_LostFocus2(sender, e);
        }

        private void textBoxY_LostFocus(object sender, EventArgs e)
        {
            textBoxY_LostFocus2(sender, e);
        }

        private void textBoxZ_LostFocus(object sender, EventArgs e)
        {
            textBoxZ_LostFocus2(sender, e);
        }

        private void txtManAcc_LostFocus(object sender, EventArgs e)
        {
            txtManAcc_LostFocus2(sender, e);
        }

        private void GpsInfoControl_Click(object sender, EventArgs e)
        {
            GpsInfoControl_Click2(sender, e);
        }
        #endregion

        private void btnMisc_Click(object sender, EventArgs e)
        {
            if(MiscClick != null)
                MiscClick();
        }

        private void bindingSourcePoint_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {

        }

    }
}
