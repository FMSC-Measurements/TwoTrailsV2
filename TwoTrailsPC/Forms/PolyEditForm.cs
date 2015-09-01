using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Forms
{
    public partial class PolyEditForm : Form
    {

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            textBoxID_TextChanged2(sender, e);
        }

        private void textBoxDesc_TextChanged(object sender, EventArgs e)
        {
            textBoxDesc_TextChanged2(sender, e);
        }

        private void txtPolyAcc_TextChanged(object sender, EventArgs e)
        {
            txtPolyAcc_TextChanged2(sender, e);
        }

        private void txtInc_TextChanged(object sender, EventArgs e)
        {
            txtInc_TextChanged2(sender, e);
        }

        private void txtStartIndex_TextChanged(object sender, EventArgs e)
        {
            txtStartIndex_TextChanged2(sender, e);
        }

        private void chkLock_CheckedChanged(object sender, EventArgs e)
        {
            chkLock_CheckStateChanged2(sender, e);
        }

        private void pointNavigationCtrl1_AlreadyAtBeginning(object sender)
        {
            
        }

        private void pointNavigationCtrl1_AlreadyAtEnd(object sender)
        {

        }

        private void pointNavigationCtrl1_IndexChanged(object sender, TwoTrails.Controls.PointNavigationCtrl.PointNavEventArgs e)
        {
            pointNavigationCtrl1_IndexChanged2(sender, e);
        }

        private void pointNavigationCtrl1_JumpPoint(object sender)
        {
            pointNavigationCtrl1_JumpPoint2(sender);
        }

        private void actionsControlPolygons_New_OnClick(object sender, EventArgs e)
        {
            actionsControlPolygons_NewClicked_OnClick2(sender, e);
        }

        private void actionsControlPolygons_Ok_OnClick(object sender, EventArgs e)
        {
            actionsControlPolygons_OkClicked_OnClick2(sender, e);
        }

        private void actionsControlPolygons_Cancel_OnClick(object sender, EventArgs e)
        {
            actionsControlPolygons_Cancel_OnClick2(sender, e);
        }

        private void actionsControlPolygons_Delete_OnClick(object sender, EventArgs e)
        {
            actionsControlPolygons_DeleteClicked_OnClick2(sender, e);
        }

        private void actionsControlPolygons_Misc_OnClick(object sender, EventArgs e)
        {
            actionsControlPolygons_MiscClicked_OnClick2(sender, e);
        }

        private void PolyEditForm_Load(object sender, EventArgs e)
        {
            PolyEditForm_Load2(sender, e);
        }
    }
}
