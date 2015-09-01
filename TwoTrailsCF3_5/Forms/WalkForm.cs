using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;

namespace TwoTrails.Forms
{
    public partial class WalkForm : Form
    {
        public WalkForm(TtPolygon poly, DataAccessLayer dal, TtMetaData meta, int currIndex)
        {
            if(Engine.Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();

            Init(poly, dal, meta, currIndex);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk_Click2(sender, e);
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            btnCapture_Click2(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void txtFreq_TextChanged(object sender, EventArgs e)
        {
            txtFreq_TextChanged2(sender, e);
        }

        private void txtAcc_TextChanged(object sender, EventArgs e)
        {
            txtAcc_TextChanged2(sender, e);
        }

        private void btnDOP_Click(object sender, EventArgs e)
        {
            btnDOP_Click2(sender, e);
        }

        private void btnFixType_Click(object sender, EventArgs e)
        {
            btnFixType_Click2(sender, e);
        }

        private void txtDOP_TextChanged(object sender, EventArgs e)
        {
            txtDOP_TextChanged2(sender, e);
        }

        private void cboFixType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFixType_SelectedIndexChanged2(sender, e);
        }

        private void cboDOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDOP_SelectedIndexChanged2(sender, e);
        }

        private void WalkForm_Closing(object sender, CancelEventArgs e)
        {
            CloseForm();
        }

        private void txtIncrement_TextChanged(object sender, EventArgs e)
        {
            txtIncrement_TextChanged2(sender, e);
        }

        private void txtPID_TextChanged(object sender, EventArgs e)
        {
            txtPID_TextChanged2(sender, e);
        }

        private void chkSound_CheckStateChanged(object sender, EventArgs e)
        {
            chkSound_CheckStateChanged2(sender, e);
        }

        private void chkLock_CheckStateChanged(object sender, EventArgs e)
        {
            chkLock_CheckStateChanged2(sender, e);
        }

        private void txtFreq_GotFocus(object sender, EventArgs e)
        {
            txtFreq_GotFocus2(sender, e);
        }

        private void txtAcc_GotFocus(object sender, EventArgs e)
        {
            txtAcc_GotFocus2(sender, e);
        }

        private void txtDOP_GotFocus(object sender, EventArgs e)
        {
            txtDOP_GotFocus2(sender, e);
        }

        private void txtPID_GotFocus(object sender, EventArgs e)
        {
            txtPID_GotFocus2(sender, e);
        }

        private void txtIncrement_GotFocus(object sender, EventArgs e)
        {
            txtIncrement_GotFocus2(sender, e);
        }

        private void gpsInfoAdvCtrl_Click(object sender, EventArgs e)
        {
            gpsInfoAdvCtrl_Click2(sender, e);
        }

        private void WalkForm_Load(object sender, EventArgs e)
        {
            Load2();
        }
    }
}