using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;

namespace TwoTrails.Forms
{
    public partial class WalkForm : Form
    {
        public WalkForm(TtPolygon poly, DataAccessLayer dal, TtMetaData meta, int cIndex, bool isInsert)
        {
            InitializeComponent();

            Init(poly, dal, meta, cIndex, isInsert);
        }

        private void txtFreq_TextChanged(object sender, EventArgs e)
        {
            txtFreq_TextChanged2(sender, e);
        }

        private void txtAcc_TextChanged(object sender, EventArgs e)
        {
            txtAcc_TextChanged2(sender, e);
        }

        private void txtDOP_TextChanged(object sender, EventArgs e)
        {
            txtDOP_TextChanged2(sender, e);
        }

        private void txtPID_TextChanged(object sender, EventArgs e)
        {
            txtPID_TextChanged2(sender, e);
        }

        private void txtIncrement_TextChanged(object sender, EventArgs e)
        {
            txtIncrement_TextChanged2(sender, e);
        }

        private void cboDOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDOP_SelectedIndexChanged2(sender, e);
        }

        private void cboFixType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFixType_SelectedIndexChanged2(sender, e);
        }

        private void chkLock_CheckedChanged(object sender, EventArgs e)
        {
            chkLock_CheckStateChanged2(sender, e);
        }

        private void chkSound_CheckedChanged(object sender, EventArgs e)
        {
            chkSound_CheckStateChanged2(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            btnCapture_Click2(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk_Click2(sender, e);
        }

        private void WalkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm();
        }

        private void WalkForm_Load(object sender, EventArgs e)
        {
            Load2();
        }

    }
}
