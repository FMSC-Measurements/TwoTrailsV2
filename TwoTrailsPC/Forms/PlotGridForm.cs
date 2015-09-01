using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;

namespace TwoTrails.Forms
{
    public partial class PlotGridForm : Form
    {
        public PlotGridForm(DataAccessLayer d)
        {
            DAL = d;
            InitializeComponent();
            Init();
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLoc_SelectedIndexChanged2(sender, e);
        }

        private void cboPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPoly_SelectedIndexChanged2(sender, e);
        }

        private void cboDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDist_SelectedIndexChanged2(sender, e);
        }

        private void cboStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboStart_SelectedIndexChanged2(sender, e);
        }

        private void txti1_TextChanged(object sender, EventArgs e)
        {
            txti1_TextChanged2(sender, e);
        }

        private void txti2_TextChanged(object sender, EventArgs e)
        {
            txti2_TextChanged2(sender, e);
        }

        private void txtTilt_TextChanged(object sender, EventArgs e)
        {
            txtTilt_TextChanged2(sender, e);
        }

        private void cboSample_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSample_SelectedIndexChanged2(sender, e);
        }

        private void txtSample_TextChanged(object sender, EventArgs e)
        {
            txtSample_TextChanged2(sender, e);
        }

        private void chkDelOld_CheckedChanged(object sender, EventArgs e)
        {
            chkDelOld_CheckStateChanged2(sender, e);
        }

        private void chkSample_CheckedChanged(object sender, EventArgs e)
        {
            chkSample_Click2(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnClose_Click2(sender, e);
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            btnPlot_Click2(sender, e);
        }
    }
}
