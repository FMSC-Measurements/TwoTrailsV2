using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Controls
{
    public partial class PointInfoCtrl : UserControl
    {
        private void tbPID_TextChanged(object sender, EventArgs e)
        {
            tbPID_TextChanged2(sender, e);
        }

        private void cbOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbOp_SelectedIndexChanged2(sender, e);
        }

        private void tbComment_TextChanged(object sender, EventArgs e)
        {
            tbComment_TextChanged2(sender, e);
        }

        private void cbMetaDef_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMetaDef_SelectedIndexChanged2(sender, e);
        }

        private void cbPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPoly_SelectedIndexChanged2(sender, e);
        }

        private void btnBoundary_Click(object sender, EventArgs e)
        {
            btnBoundary_Click2(sender, e);
        }

        private void chkLocked_CheckedChanged(object sender, EventArgs e)
        {
            chkLocked_CheckStateChanged2(sender, e);
        }

        private void picLinked_Click(object sender, EventArgs e)
        {
            picLinked_Click2(sender, e);
        }
    }
}
