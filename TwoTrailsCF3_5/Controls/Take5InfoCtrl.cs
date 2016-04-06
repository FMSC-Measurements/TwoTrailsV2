using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Controls
{
    public partial class Take5InfoCtrl : UserControl
    {
        public Take5InfoCtrl()
        {
            InitializeComponent();
            Init();
        }

        private void btnDOP_Click(object sender, EventArgs e)
        {
            btnDOP_Click2(sender, e);
        }

        private void btnFixType_Click(object sender, EventArgs e)
        {
            btnFixType_Click2(sender, e);
        }

        private void cboDOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDOP_SelectedIndexChanged2(sender, e);
        }

        private void cboFixType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFixType_SelectedIndexChanged2(sender, e);
        }

        private void txtDOP_TextChanged(object sender, EventArgs e)
        {
            txtDOP_TextChanged2(sender, e);
        }

        private void txtBursts_TextChanged(object sender, EventArgs e)
        {
            txtBursts_TextChanged2(sender, e);
        }

        private void txtDOP_GotFocus(object sender, EventArgs e)
        {
            txtDOP_GotFocus2(sender, e);
        }

        private void txtBursts_GotFocus(object sender, EventArgs e)
        {
            txtBursts_GotFocus2(sender, e);
        }

        private void txtDOP_LostFocus(object sender, EventArgs e)
        {
            txtDOP_LostFocus2(sender, e);
        }

        private void txtBursts_LostFocus(object sender, EventArgs e)
        {
            txtBursts_LostFocus2(sender, e);
        }

        private void Take5InfoCtrl_Click(object sender, EventArgs e)
        {
            Take5InfoCtrl_Click2(sender, e);
        }

        private void chkIgnoreNmea_CheckStateChanged(object sender, EventArgs e)
        {
            chkIgnoreNmea_CheckStateChanged2(sender, e);
        }

        private void txtIgnore_TextChanged(object sender, EventArgs e)
        {
            txtIgnore_TextChanged2(sender, e);
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            btnHide_Click2(sender, e);
        }

        private void txtIgnore_GotFocus(object sender, EventArgs e)
        {
            txtIgnore_GotFocus2(sender, e);
        }

        private void txtIgnore_LostFocus(object sender, EventArgs e)
        {
            txtIgnore_LostFocus(sender, e);
        }
    }
}
