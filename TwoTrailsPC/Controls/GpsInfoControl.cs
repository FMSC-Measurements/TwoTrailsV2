using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Controls
{
    public partial class GpsInfoControl : UserControl
    {

        public GpsInfoControl()
        {
            InitializeComponent();

            _locked = true;

            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            textBoxX_TextChanged2(sender, e);
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            textBoxY_TextChanged2(sender, e);
        }

        private void textBoxZ_TextChanged(object sender, EventArgs e)
        {
            textBoxZ_TextChanged2(sender, e);
        }

        private void btnDelNmea_Click(object sender, EventArgs e)
        {
            btnDelNmea_Click2(sender, e);
        }

        private void btnMisc_Click(object sender, EventArgs e)
        {
            if (MiscClick != null)
                MiscClick();
        }

        private void bindingSourcePoint_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
        
        }

        private void txtManAcc_TextChanged(object sender, EventArgs e)
        {
            txtManAcc_TextChanged2(sender, e);
        }
    }
}
