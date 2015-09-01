using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.GpsAccess;
using TwoTrails.DataAccess;

namespace TwoTrails.Forms
{
    public partial class CalcGpsPointForm : Form
    {
        public CalcGpsPointForm(List<NmeaBurst> nb, int pn, string cn, DataAccessLayer dal, int currentZone, bool recalc)
        {
            InitializeComponent();

            Init(nb, pn, cn, dal, currentZone, recalc);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            btnCalc_Click2(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk_Click2(sender, e);
        }

        private void cboDOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDOP_SelectedIndexChanged2(sender, e);
        }

        private void txtDOP_TextChanged(object sender, EventArgs e)
        {
            txtDOP_TextChanged2(sender, e);
        }

        private void cboFixType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFixType_SelectedIndexChanged2(sender, e);
        }

        private void txtRange_TextChanged(object sender, EventArgs e)
        {
            txtRange_TextChanged2(sender, e);
        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            txtStart_TextChanged2(sender, e);
        }

        private void txtGroup_TextChanged(object sender, EventArgs e)
        {
            txtGroup_TextChanged2(sender, e);
        }

        private void chkCustom_CheckedChanged(object sender, EventArgs e)
        {
            chkCustom_CheckStateChanged2(sender, e);
        }

        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            chk1_CheckStateChanged2(sender, e);
        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            chk2_CheckStateChanged2(sender, e);
        }

        private void chk3_CheckedChanged(object sender, EventArgs e)
        {
            chk3_CheckStateChanged2(sender, e);
        }

    }
}
