using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Forms
{
    public partial class PlotGridForm : Form
    {
        public PlotGridForm(DataAccess.DataAccessLayer dal)
        {
            DAL = dal;

            if(Engine.Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();

            Init();
        }

        #region Controls
        private void btnPlot_Click(object sender, EventArgs e)
        {
            btnPlot_Click2(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnClose_Click2(sender, e);
        }

        private void txti1_TextChanged(object sender, EventArgs e)
        {
            txti1_TextChanged2(sender, e);
        }

        private void txti2_TextChanged(object sender, EventArgs e)
        {
            txti2_TextChanged2(sender, e);
        }

        private void txti1_GotFocus(object sender, EventArgs e)
        {
            txti1_GotFocus2(sender, e);
        }

        private void txti2_GotFocus(object sender, EventArgs e)
        {
            txti2_GotFocus2(sender, e);
        }

        private void txti1_LostFocus(object sender, EventArgs e)
        {
            txti1_LostFocus2(sender, e);
        }

        private void txti2_LostFocus(object sender, EventArgs e)
        {
            txti2_LostFocus2(sender, e);
        }

        private void txtTilt_TextChanged(object sender, EventArgs e)
        {
            txtTilt_TextChanged2(sender, e);
        }

        private void txtTilt_GotFocus(object sender, EventArgs e)
        {
            txtTilt_GotFocus2(sender, e);
        }

        private void txtTilt_LostFocus(object sender, EventArgs e)
        {
            txtTilt_LostFocus2(sender, e);
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

        private void btnLoc_Click(object sender, EventArgs e)
        {
            btnLoc_Click2(sender, e);
        }

        private void btnPoly_Click(object sender, EventArgs e)
        {
            btnPoly_Click2(sender, e);
        }

        private void btnDist_Click(object sender, EventArgs e)
        {
            btnDist_Click2(sender, e);
        }

        private void chkDelOld_CheckStateChanged(object sender, EventArgs e)
        {
            chkDelOld_CheckStateChanged2(sender, e);
        }

        private void cboStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboStart_SelectedIndexChanged2(sender, e);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart_Click2(sender, e);
        }

        private void cboSample_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSample_SelectedIndexChanged2(sender, e);
        }

        private void txtSample_GotFocus(object sender, EventArgs e)
        {
            txtSample_GotFocus2(sender, e);
        }

        private void txtSample_TextChanged(object sender, EventArgs e)
        {
            txtSample_TextChanged2(sender, e);
        }

        private void txtSample_LostFocus(object sender, EventArgs e)
        {
            txtSample_LostFocus2(sender, e);
        }

        private void chkSample_Click(object sender, EventArgs e)
        {
            chkSample_Click2(sender, e);
        }

        private void btnSample_Click(object sender, EventArgs e)
        {
            btnSample_Click2(sender, e);
        }
        #endregion
    }
}