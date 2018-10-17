using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;
using TwoTrails.BusinessLogic;
using TwoTrails.Engine;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class PolyEditForm : Form
    {
        #region actionsControl Click Events

        private void actionsControlPolygons_Cancel_OnClick(object sender, EventArgs e)
        {
            actionsControlPolygons_Cancel_OnClick2(sender, e);
        }

        private void actionsControlPolygons_DeleteClicked_OnClick(object sender, EventArgs e)
        {
            actionsControlPolygons_DeleteClicked_OnClick2(sender, e);
        }

        private void actionsControlPolygons_MiscClicked_OnClick(object sender, EventArgs e)
        {
            actionsControlPolygons_MiscClicked_OnClick2(sender, e);
        }

        private void actionsControlPolygons_NewClicked_OnClick(object sender, EventArgs e)
        {
            actionsControlPolygons_NewClicked_OnClick2(sender, e);
        }

        private void actionsControlPolygons_OkClicked_OnClick(object sender, EventArgs e)
        {
            actionsControlPolygons_OkClicked_OnClick2(sender, e);
        }
        #endregion

        private void PolyEditForm_Load(object sender, EventArgs e)
        {
            PolyEditForm_Load2(sender, e);
        }

        #region DAL edited
        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            textBoxID_TextChanged2(sender, e);
        }
        
        private void textBoxDesc_TextChanged(object sender, EventArgs e)
        {
            textBoxDesc_TextChanged2(sender, e);
        }
        #endregion

        #region Controls
        private void textBoxID_GotFocus(object sender, EventArgs e)
        {
            textBoxID_GotFocus2(sender, e);
        }

        private void textBoxID_LostFocus(object sender, EventArgs e)
        {
            textBoxID_LostFocus2(sender, e);
        }

        private void textBoxDesc_GotFocus(object sender, EventArgs e)
        {
            textBoxDesc_GotFocus2(sender, e);
        }

        private void textBoxDesc_LostFocus(object sender, EventArgs e)
        {
            textBoxDesc_LostFocus2(sender, e);
        }

        private void PolyEditForm_GotFocus(object sender, EventArgs e)
        {
            PolyEditForm_GotFocus2(sender, e);
        }

        private void txtPolyAcc_TextChanged(object sender, EventArgs e)
        {
            txtPolyAcc_TextChanged2(sender, e);
        }

        private void txtPolyAcc_GotFocus(object sender, EventArgs e)
        {
            txtPolyAcc_GotFocus2(sender, e);
        }

        private void txtPolyAcc_LostFocus(object sender, EventArgs e)
        {
            txtPolyAcc_LostFocus2(sender, e);
        }
        #endregion


        private void pointNavigationCtrl1_IndexChanged(object sender, TwoTrails.Controls.PointNavigationCtrl.PointNavEventArgs e)
        {
            pointNavigationCtrl1_IndexChanged2(sender, e);
        }

        private void pointNavigationCtrl1_JumpPoint(object sender)
        {
            pointNavigationCtrl1_JumpPoint2(sender);
        }

        private void txtInc_TextChanged(object sender, EventArgs e)
        {
            txtInc_TextChanged2(sender, e);
        }

        private void txtInc_GotFocus(object sender, EventArgs e)
        {
            txtInc_GotFocus2(sender, e);
        }

        private void txtInc_LostFocus(object sender, EventArgs e)
        {
            txtInc_LostFocus2(sender, e);
        }

        private void txtStartIndex_TextChanged(object sender, EventArgs e)
        {
            txtStartIndex_TextChanged2(sender, e);
        }

        private void txtStartIndex_GotFocus(object sender, EventArgs e)
        {
            txtStartIndex_GotFocus2(sender, e);
        }

        private void txtStartIndex_LostFocus(object sender, EventArgs e)
        {
            txtStartIndex_LostFocus2(sender, e);
        }

        private void chkLock_CheckStateChanged(object sender, EventArgs e)
        {
            chkLock_CheckStateChanged2(sender, e);
        }
    }
}