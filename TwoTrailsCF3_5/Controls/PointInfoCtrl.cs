using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;

namespace TwoTrails.Controls
{
    public partial class PointInfoCtrl : UserControl
    {
        #region Text/Selection/State Changed Events
        private void cbPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPoly_SelectedIndexChanged2(sender, e);
        }

        private void cbMetaDef_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMetaDef_SelectedIndexChanged2(sender, e);
        }

        private void tbPID_TextChanged(object sender, EventArgs e)
        {
            tbPID_TextChanged2(sender, e);
        }

        private void tbComment_TextChanged(object sender, EventArgs e)
        {
            tbComment_TextChanged2(sender, e);
        }

        private void cbOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbOp_SelectedIndexChanged2(sender, e);
        }

        private void chkLocked_CheckStateChanged(object sender, EventArgs e)
        {
            chkLocked_CheckStateChanged2(sender, e);
        }

        private void btnOp_Click(object sender, EventArgs e)
        {
            btnOp_Click2(sender, e);
        }

        private void btnBoundary_Click(object sender, EventArgs e)
        {
            btnBoundary_Click2(sender, e);
        }

        private void PointInfoCtrl_Click(object sender, EventArgs e)
        {
            PointInfoCtrl_Click2(sender, e);
        }

        private void tbPID_GotFocus(object sender, EventArgs e)
        {
            tbPID_GotFocus2(sender, e);
        }

        private void tbComment_GotFocus(object sender, EventArgs e)
        {
            tbComment_GotFocus2(sender, e);
        }

        private void tbPID_LostFocus(object sender, EventArgs e)
        {
            tbPID_LostFocus2(sender, e);
        }

        private void tbComment_LostFocus(object sender, EventArgs e)
        {
            tbComment_LostFocus2(sender, e);
        }

        private void picLinked_Click(object sender, EventArgs e)
        {
            picLinked_Click2(sender, e);
        }
        #endregion
    }
}
