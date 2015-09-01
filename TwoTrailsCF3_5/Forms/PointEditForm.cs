using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Utilities;
using TwoTrails.Controls;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Forms
{
    public partial class PointEditForm : Form
    {
        public PointEditForm(DataAccess.DataAccessLayer dal)
        {
            TtUtils.ShowWaitCursor();

            DAL = dal;

            if(Engine.Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();

            TtUtils.HideWaitCursor();
        }

        private void PointEditForm_Closing(object sender, CancelEventArgs e)
        {
            PointEditForm_Closing2(sender, e);
        }

        private void PointEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        #region Action Controls
        private void actionsControl_Cancel_OnClick(object sender, EventArgs e)
        {
            actionsControl_Cancel_OnClick2(sender, e);
        }

        private void actionsControl_Delete_OnClick(object sender, EventArgs e)
        {
            actionsControl_Delete_OnClick2(sender, e);
        }

        private void actionsControl_New_OnClick(object sender, EventArgs e)
        {
            actionsControl_New_OnClick2(sender, e);
        }

        private void actionsControl_Ok_OnClick(object sender, EventArgs e)
        {
            actionsControl_Ok_OnClick2(sender, e);
        }

        private void actionsControl_Misc_OnClick(object sender, EventArgs e)
        {
            actionsControl_Misc_OnClick2(sender, e);
        }
        #endregion

        #region Navigation Controls
        private void pointNavigationCtrl_AlreadyAtBeginning(object sender)
        {
            pointNavigationCtrl_AlreadyAtBeginning2(sender);
        }

        private void pointNavigationCtrl_AlreadyAtEnd(object sender)
        {
            pointNavigationCtrl_AlreadyAtEnd2(sender);
        }

        private void pointNavigationCtrl_IndexChanged(object sender, TwoTrails.Controls.PointNavigationCtrl.PointNavEventArgs e)
        {
            pointNavigationCtrl_IndexChanged2(sender, e);
        }

        private void pointNavigationCtrl_JumpPoint(object sender)
        {
            pointNavigationCtrl_JumpPoint2(sender);
        }

        #endregion

        #region Point Controls

        #region PointInfo Control
        private void pointInfoCtrl_Comment_OnTextChanged(object sender, EventArgs e)
        {
            pointInfoCtrl_Comment_OnTextChanged2(sender, e);
        }

        private void pointInfoCtrl_OnBoundary_Click()
        {
            pointInfoCtrl1_OnBoundary_Click2();
        }

        private void pointInfoCtrl_OnComment_Enter()
        {
            pointInfoCtrl_OnComment_Enter2();
        }

        private void pointInfoCtrl_OnLocked_CheckedChanged(object sender, LockStateEventArgs e)
        {
            pointInfoCtrl_OnLocked_CheckedChanged2(sender, e);
        }

        private void pointInfoCtrl_OnMetaDef_SelectedIndexChanged()
        {
            pointInfoCtrl_OnMetaDef_SelectedIndexChanged2();
        }

        private void pointInfoCtrl_OnOp_SelectedIndexChanged()
        {
            pointInfoCtrl_OnOp_SelectedIndexChanged2();
        }

        private void pointInfoCtrl_OnPID_Enter()
        {
            pointInfoCtrl_OnPID_Enter2();
        }

        private void pointInfoCtrl_OnPoly_SelectedIndexChanged()
        {
            pointInfoCtrl_OnPoly_SelectedIndexChanged2();
        }

        private void pointInfoCtrl_PID_OnTextChanged(object sender, EventArgs e)
        {
            pointInfoCtrl_PID_OnTextChanged2(sender, e);
        }

        private void pointInfoCtrl_LinkedPointClicked()
        {
            pointInfoCtrl_LinkedPointClicked2();
        }
        #endregion

        #region Gps Point

        private void gpsInfoControl1_DelNmea_OnClick(object sender, EventArgs e)
        {
            gpsInfoControl1_DelNmea_OnClick2(sender, e);
        }

        private void gpsInfoControl1_ManAcc_OnTextChanged(object sender, EventArgs e)
        {
            gpsInfoControl1_ManAcc_OnTextChanged2(sender, e);
        }

        private void gpsInfoControl1_X_OnTextChanged(object sender, EventArgs e)
        {
            gpsInfoControl1_X_OnTextChanged2(sender, e);
        }

        private void gpsInfoControl1_Y_OnTextChanged(object sender, EventArgs e)
        {
            gpsInfoControl1_Y_OnTextChanged2(sender, e);
        }

        private void gpsInfoControl1_Z_OnTextChanged(object sender, EventArgs e)
        {
            gpsInfoControl1_Z_OnTextChanged2(sender, e);
        }

        private void gpsInfoControl1_MiscClick()
        {
            gpsInfoControl1_MiscClick2();
        }

        #endregion

        #region Take5 Point

        private void take5InfoCtrl1_BurstAmountChanged()
        {
            take5InfoCtrl1_BurstAmountChanged2();
        }

        private void take5InfoCtrl1_ButtonHide()
        {
            take5InfoCtrl1_ButtonHide2();
        }

        #endregion

        #region Traverse Sideshot Control
        private void travInfoControl1_BAzTextChanged()
        {
            travInfoControl1_BAzTextChanged2();
        }

        private void travInfoControl1_FAzTextChanged()
        {
            travInfoControl1_FAzTextChanged2();
        }

        private void travInfoControl1_SlopeAngleTextChanged()
        {
            travInfoControl1_SlopeAngleTextChanged2();
        }

        private void travInfoControl1_SlopeDistTextChanged()
        {
            travInfoControl1_SlopeDistTextChanged2();
        }

        private void travInfoControl1_ValuesSet()
        {
            travInfoControl1_ValuesSet2();
        }
        #endregion

        #region Quondam Point Control
        private void quondamInfoControl1_Point_OnIndexChanged()
        {
            quondamInfoControl1_Point_OnIndexChanged2();
        }

        private void quondamInfoControl1_Polygon_OnIndexChanged()
        {
            quondamInfoControl1_Polygon_OnIndexChanged2();
        }

        private void quondamInfoControl1_PointConverted()
        {
            quondamInfoControl1_PointConverted2();
        }

        private void quondamInfoControl1_PointsRetraced()
        {
            quondamInfoControl1_PointsRetraced2();
        }
        #endregion


        #region Walk Control

        private void walkInfoCtrl1_DeleteWalk()
        {
            walkInfoCtrl1_DeleteWalk2();
        }

        private void walkInfoCtrl1_EditAccuracy(double acc)
        {
            walkInfoCtrl1_EditAccuracy2(acc);
        }

        private void walkInfoCtrl1_ButtonHide()
        {
            walkInfoCtrl1_ButtonHide2();
        }

        private void walkInfoCtrl1_AddToWalk()
        {
            walkInfoCtrl1_AddToWalk2();
        }
        #endregion


        #endregion

        #region Focus Controls
        private void walkInfoCtrl1_GotFocus(object sender, EventArgs e)
        {
            StopPointFlashing();
        }

        private void travInfoControl1_GotFocused(object sender, EventArgs e)
        {
            StopPointFlashing();
        }

        private void take5InfoCtrl1_GotFocused()
        {
            StopPointFlashing();
        }

        private void quondamInfoControl1_GotFocused(object sender, EventArgs e)
        {
            StopPointFlashing();
        }

        private void pointNavigationCtrl_GotFocus(object sender, EventArgs e)
        {
            StopPointFlashing();
        }

        private void pointInfoCtrl_GotFocus(object sender, EventArgs e)
        {
            StopPointFlashing();
        }

        private void PointEditForm_GotFocus(object sender, EventArgs e)
        {
            StopPointFlashing();
        }

        private void gpsInfoControl1_GotFocus(object sender, EventArgs e)
        {
            StopPointFlashing();
        }

        private void actionsControl_GotFocus(object sender, EventArgs e)
        {
            StopPointFlashing();
        }

        private void gpsInfoControl1_GotFocused()
        {
            StopPointFlashing();
        }
        #endregion

        private void PointEditForm_Load(object sender, EventArgs e)
        {
            PointEditForm_Load2(sender, e);
        }

    }
}