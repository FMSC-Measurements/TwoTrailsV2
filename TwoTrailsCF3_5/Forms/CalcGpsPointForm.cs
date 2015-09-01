using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;
using TwoTrails.GpsAccess;
using TwoTrails.DataAccess;

namespace TwoTrails.Forms
{
    public partial class CalcGpsPointForm : Form
    {
        public CalcGpsPointForm(List<NmeaBurst> nb, int pn, string cn, DataAccessLayer dal, int currentZone, bool recalc)
        {
            if(Engine.Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();

            Init(nb, pn, cn, dal, currentZone, recalc);
        }

        #region Controls

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

        private void chkCustom_CheckStateChanged(object sender, EventArgs e)
        {
            chkCustom_CheckStateChanged2(sender, e);
        }

        private void chk1_CheckStateChanged(object sender, EventArgs e)
        {
            chk1_CheckStateChanged2(sender, e);
        }

        private void chk2_CheckStateChanged(object sender, EventArgs e)
        {
            chk2_CheckStateChanged2(sender, e);
        }

        private void chk3_CheckStateChanged(object sender, EventArgs e)
        {
            chk3_CheckStateChanged2(sender, e);
        }

        private void txtDOP_TextChanged(object sender, EventArgs e)
        {
            txtDOP_TextChanged2(sender, e);
        }

        private void txtGroup_TextChanged(object sender, EventArgs e)
        {
            txtGroup_TextChanged2(sender, e);
        }

        private void txtRange_TextChanged(object sender, EventArgs e)
        {
            txtRange_TextChanged2(sender, e);
        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            txtStart_TextChanged2(sender, e);
        }

        #endregion

        #region Focus
        private void txtDOP_GotFocus(object sender, EventArgs e)
        {
            txtDOP_GotFocus2(sender, e);
        }

        private void txtDOP_LostFocus(object sender, EventArgs e)
        {
            txtDOP_LostFocus2(sender, e);
        }

        private void txtGroup_GotFocus(object sender, EventArgs e)
        {
            txtGroup_GotFocus2(sender, e);
        }

        private void txtGroup_LostFocus(object sender, EventArgs e)
        {
            txtGroup_LostFocus2(sender, e);
        }

        private void txtRange_GotFocus(object sender, EventArgs e)
        {
            txtRange_GotFocus2(sender, e);
        }

        private void txtRange_LostFocus(object sender, EventArgs e)
        {
            txtRange_LostFocus2(sender, e);
        }

        private void txtStart_GotFocus(object sender, EventArgs e)
        {
            txtStart_GotFocus2(sender, e);
        }

        private void txtStart_LostFocus(object sender, EventArgs e)
        {
            txtStart_LostFocus2(sender, e);
        }
        #endregion
    }
}