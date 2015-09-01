using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class PointEditForm : Form
    {
        public PointEditForm(DataAccessLayer d)
        {
            InitializeComponent();

            DAL = d;

            Init();

            TtUtils.HideWaitCursor();
        }

        private void gpsInfoControl_X_OnTextChanged(object sender, EventArgs e)
        {
            gpsInfoControl1_X_OnTextChanged2(sender, e);
        }

        private void gpsInfoControl_Y_OnTextChanged(object sender, EventArgs e)
        {
            gpsInfoControl1_Y_OnTextChanged2(sender, e);
        }

        private void gpsInfoControl_Z_OnTextChanged(object sender, EventArgs e)
        {
            gpsInfoControl1_Z_OnTextChanged2(sender, e);
        }

        private void gpsInfoControl_ManAcc_OnTextChanged(object sender, EventArgs e)
        {
            gpsInfoControl1_ManAcc_OnTextChanged2(sender, e);
        }

        private void gpsInfoControl_DelNmea_OnClick(object sender, EventArgs e)
        {
            gpsInfoControl1_DelNmea_OnClick2(sender, e);
        }

        private void gpsInfoControl_MiscClick()
        {
            gpsInfoControl1_MiscClick2();
        }

        private void pointInfoCtrl1_OnBoundary_Click()
        {
            pointInfoCtrl1_OnBoundary_Click2();
        }

        private void pointInfoCtrl1_OnLocked_CheckedChanged(object sender, TwoTrails.Controls.LockStateEventArgs e)
        {
            pointInfoCtrl_OnLocked_CheckedChanged2(sender, e);
        }

        private void pointInfoCtrl1_OnMetaDef_SelectedIndexChanged()
        {
            pointInfoCtrl_OnMetaDef_SelectedIndexChanged2();
        }

        private void pointInfoCtrl1_OnOp_SelectedIndexChanged()
        {
            pointInfoCtrl_OnOp_SelectedIndexChanged2();
        }

        private void pointInfoCtrl1_OnPID_Enter()
        {
            pointInfoCtrl_OnPID_Enter2();
        }

        private void pointInfoCtrl1_OnPoly_SelectedIndexChanged()
        {
            pointInfoCtrl_OnPoly_SelectedIndexChanged2();
        }

        private void quondamInfoControl_Point_OnIndexChanged()
        {
            quondamInfoControl1_Point_OnIndexChanged2();
        }

        private void quondamInfoControl_Polygon_OnIndexChanged()
        {
            quondamInfoControl1_Polygon_OnIndexChanged2();
        }

        private void quondamInfoControl_PointsRetraced()
        {
            quondamInfoControl1_PointsRetraced2();
        }

        private void quondamInfoControl_PointConverted()
        {
            quondamInfoControl1_PointConverted2();
        }

        private void walkInfoCtrl_AddToWalk()
        {
            StopPointFlashing();
            walkInfoCtrl1_AddToWalk2();
        }

        private void walkInfoCtrl_DeleteWalk()
        {
            StopPointFlashing();
            walkInfoCtrl1_DeleteWalk2();
        }

        private void walkInfoCtrl_ButtonHide()
        {
            StopPointFlashing();
            walkInfoCtrl1_ButtonHide2();
        }

        private void walkInfoCtrl_EditAccuracy(double acc)
        {
            StopPointFlashing();
            walkInfoCtrl1_EditAccuracy2(acc);
        }

        private void travInfoControl_FAzTextChanged()
        {
            travInfoControl1_FAzTextChanged2();
        }

        private void travInfoControl_BAzTextChanged()
        {
            travInfoControl1_BAzTextChanged2();
        }

        private void travInfoControl_SlopeAngleTextChanged()
        {
            travInfoControl1_SlopeAngleTextChanged2();
        }

        private void travInfoControl_SlopeDistTextChanged()
        {
            travInfoControl1_SlopeDistTextChanged2();
        }

        private void take5InfoCtrl1_ButtonHide()
        {
            take5InfoCtrl1_ButtonHide2();
        }

        private void take5InfoCtrl1_BurstAmountChanged()
        {
            take5InfoCtrl1_BurstAmountChanged2();
        }

        private void pointNavigationCtrl_AlreadyAtBeginning(object sender)
        {
            StopPointFlashing();
            pointNavigationCtrl_AlreadyAtBeginning2(sender);
        }

        private void pointNavigationCtrl_AlreadyAtEnd(object sender)
        {
            StopPointFlashing();
            pointNavigationCtrl_AlreadyAtEnd2(sender);
        }

        private void pointNavigationCtrl_IndexChanged(object sender, TwoTrails.Controls.PointNavigationCtrl.PointNavEventArgs e)
        {
            StopPointFlashing();
            pointNavigationCtrl_IndexChanged2(sender, e);
        }

        private void pointNavigationCtrl_JumpPoint(object sender)
        {
            StopPointFlashing();
            pointNavigationCtrl_JumpPoint2(sender);
        }

        private void PointEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PointEditForm_Closing2(sender, e);
        }

        private void actionsControl_Delete_OnClick(object sender, EventArgs e)
        {
            actionsControl_Delete_OnClick2(sender, e);
        }

        private void actionsControl_Misc_OnClick(object sender, EventArgs e)
        {
            actionsControl_Misc_OnClick2(sender, e);
        }

        private void actionsControl_New_OnClick(object sender, EventArgs e)
        {
            actionsControl_New_OnClick2(sender, e);
        }

        private void actionsControl_Ok_OnClick(object sender, EventArgs e)
        {
            actionsControl_Ok_OnClick2(sender, e);
        }

        private void actionsControl_Cancel_OnClick(object sender, EventArgs e)
        {
            actionsControl_Cancel_OnClick2(sender, e);
        }

        private void pointInfoCtrl_Comment_OnTextChanged(object sender, EventArgs e)
        {
            StopPointFlashing();
            pointInfoCtrl1_Comment_OnTextChanged2(sender, e);
        }

        private void take5InfoCtrl1_GotFocused()
        {
            StopPointFlashing();
        }

        private void gpsInfoControl1_GotFocused()
        {
            StopPointFlashing();
        }

        private void quondamInfoControl1_GotFocused()
        {
            StopPointFlashing();
        }

        private void travInfoControl1_GotFocused()
        {
            StopPointFlashing();
        }

        private void PointEditForm_Load(object sender, EventArgs e)
        {
            PointEditForm_Load2(sender, e);
        }
    }
}
