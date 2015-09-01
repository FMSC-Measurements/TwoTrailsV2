using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;

namespace TwoTrails.Forms
{
    public partial class WhereIsForm : Form
    {

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit_Click2(sender, e);
        }

        private void btnNav_Click(object sender, EventArgs e)
        {
            btnNav_Click2(sender, e);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            btnCalc_Click2(sender, e);
        }


        #region Location Controls
        private void radMyLoc_CheckedChanged(object sender, EventArgs e)
        {
            radMyLoc_CheckedChanged2(sender, e);
        }

        private void radFromUTM_CheckedChanged(object sender, EventArgs e)
        {
            radFromUTM_CheckedChanged2(sender, e);
        }

        private void radFromPoint_CheckedChanged(object sender, EventArgs e)
        {
            radFromPoint_CheckedChanged2(sender, e);
        }

        private void txtFromX_TextChanged(object sender, EventArgs e)
        {
            txtFromX_TextChanged2(sender, e);
        }

        private void txtFromY_TextChanged(object sender, EventArgs e)
        {
            txtFromY_TextChanged2(sender, e);
        }

        private void btnFromPoly_Click(object sender, EventArgs e)
        {
            btnFromPoly_Click2(sender, e);
        }

        private void btnFromPoint_Click(object sender, EventArgs e)
        {
            btnFromPoint_Click2(sender, e);
        }

        private void cboFromPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFromPoly_SelectedIndexChanged2(sender, e);
        }

        private void cboFromPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFromPoint_SelectedIndexChanged2(sender, e);
        }

        private void radToUTM_CheckedChanged(object sender, EventArgs e)
        {
            radToUTM_CheckedChanged2(sender, e);
        }

        private void radToPoint_CheckedChanged(object sender, EventArgs e)
        {
            radToPoint_CheckedChanged2(sender, e);
        }

        private void txtToX_TextChanged(object sender, EventArgs e)
        {
            txtToX_TextChanged2(sender, e);
        }

        private void txtToY_TextChanged(object sender, EventArgs e)
        {
            txtToY_TextChanged2(sender, e);
        }

        private void btnToPoly_Click(object sender, EventArgs e)
        {
            btnToPoly_Click2(sender, e);
        }

        private void btnToPoint_Click(object sender, EventArgs e)
        {
            btnToPoint_Click2(sender, e);
        }

        private void cboToPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboToPoly_SelectedIndexChanged2(sender, e);
        }

        private void cboToPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboToPoint_SelectedIndexChanged2(sender, e);
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMeta_SelectedIndexChanged2(sender, e);
        }

        private void btnMeta_Click(object sender, EventArgs e)
        {
            btnMeta_Click2(sender, e);
        }
        #endregion

        private void WhereIsForm_Load(object sender, EventArgs e)
        {
            WhereIsForm_Load2(sender, e);
        }

        private void WhereIsForm_Closing(object sender, CancelEventArgs e)
        {
            WhereIsForm_Closing2(sender, e);
        }

        private void txtFromX_GotFocus(object sender, EventArgs e)
        {
            txtFromX_GotFocus2(sender, e);
        }

        private void txtFromY_GotFocus(object sender, EventArgs e)
        {
            txtFromY_GotFocus2(sender, e);
        }

        private void txtToX_GotFocus(object sender, EventArgs e)
        {
            txtToX_GotFocus2(sender, e);
        }

        private void txtToY_GotFocus(object sender, EventArgs e)
        {
            txtToY_GotFocus2(sender, e);
        }


    }
}