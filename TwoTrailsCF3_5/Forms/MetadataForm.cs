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
    public partial class MetadataForm : Form
    {
        public MetadataForm(DataAccessLayer d)
        {
            _init = false;
            DAL = d;

            if(Engine.Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();

            Init();
        }

        #region Metadata

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName_TextChanged2(sender, e);
        }

        private void txtZone_TextChanged(object sender, EventArgs e)
        {
            txtZone_TextChanged2(sender, e);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            btnHelp_Click2(sender, e);
        }

        private void cboDatum_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDatum_SelectedIndexChanged2(sender, e);
        }

        private void cboMapProj_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMapProj_SelectedIndexChanged2(sender, e);
        }

        private void cboDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDist_SelectedIndexChanged2(sender, e);
        }

        private void cboElev_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboElev_SelectedIndexChanged2(sender, e);
        }

        private void cboSlope_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSlope_SelectedIndexChanged2(sender, e);
        }

        private void cboMagDec_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMagDec_SelectedIndexChanged2(sender, e);
        }

        private void txtMagDec_TextChanged(object sender, EventArgs e)
        {
            txtMagDec_TextChanged2(sender, e);
        }

        private void chkLock1_CheckStateChanged(object sender, EventArgs e)
        {
            chkLock1_CheckStateChanged2(sender, e);
        }

        #endregion

        #region Dev & Proj

        private void txtGPS_TextChanged(object sender, EventArgs e)
        {
            txtGPS_TextChanged2(sender, e);
        }

        private void txtLaser_TextChanged(object sender, EventArgs e)
        {
            txtLaser_TextChanged2(sender, e);
        }

        private void txtCompass_TextChanged(object sender, EventArgs e)
        {
            txtCompass_TextChanged2(sender, e);
        }

        private void txtCrew_TextChanged(object sender, EventArgs e)
        {
            txtCrew_TextChanged2(sender, e);
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            txtComment_TextChanged2(sender, e);
        }

        private void chkLock2_CheckStateChanged(object sender, EventArgs e)
        {
            chkLock2_CheckStateChanged2(sender, e);
        }

        #endregion

        #region Actions Control
        private void actionsControl_Cancel_OnClick(object sender, EventArgs e)
        {
            actionsControl_Cancel_OnClick2(sender, e);
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
        #endregion


        #region Index Control
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

        private void btnAutoFillGps_Click(object sender, EventArgs e)
        {
            btnAutoFillGps_Click2(sender, e);
        }

        private void btnLaserList_Click(object sender, EventArgs e)
        {
            btnLaserList_Click2(sender, e);
        }

        private void MetadataForm_Closing(object sender, CancelEventArgs e)
        {
            MetadataForm_Closing2(sender, e);
        }

        private void btnCompassList_Click(object sender, EventArgs e)
        {
            btnCompassList_Click2(sender, e);
        }

        private void txtMagDec_GotFocus(object sender, EventArgs e)
        {
            txtMagDec_GotFocus2(sender, e);
        }

        private void txtZone_GotFocus(object sender, EventArgs e)
        {
            txtZone_GotFocus2(sender, e);
        }

        private void txtName_GotFocus(object sender, EventArgs e)
        {
            txtName_GotFocus2(sender, e);
        }

        private void txtGPS_GotFocus(object sender, EventArgs e)
        {
            txtGPS_GotFocus2(sender, e);
        }

        private void txtLaser_GotFocus(object sender, EventArgs e)
        {
            txtLaser_GotFocus2(sender, e);
        }

        private void txtCompass_GotFocus(object sender, EventArgs e)
        {
            txtCompass_GotFocus2(sender, e);
        }

        private void txtCrew_GotFocus(object sender, EventArgs e)
        {
            txtCrew_GotFocus2(sender, e);
        }

        private void txtComment_GotFocus(object sender, EventArgs e)
        {
            txtComment_GotFocus2(sender, e);
        }

        private void tabDevProj_GotFocus(object sender, EventArgs e)
        {
            tabDevProj_GotFocus2(sender, e);
        }

        private void tabMeta_GotFocus(object sender, EventArgs e)
        {
            tabMeta_GotFocus2(sender, e);
        }

        private void btnSetAsDefault_Click(object sender, EventArgs e)
        {
            btnSetAsDefault_Click2(sender, e);
        }

        private void txtName_LostFocus(object sender, EventArgs e)
        {
            txtName_LostFocus2(sender, e);
        }

        private void txtZone_LostFocus(object sender, EventArgs e)
        {
            txtZone_LostFocus2(sender, e);
        }

        private void txtMagDec_LostFocus(object sender, EventArgs e)
        {
            txtMagDec_LostFocus2(sender, e);
        }

        private void txtGPS_LostFocus(object sender, EventArgs e)
        {
            txtGPS_LostFocus2(sender, e);
        }

        private void txtLaser_LostFocus(object sender, EventArgs e)
        {
            txtLaser_LostFocus2(sender, e);
        }

        private void txtCompass_LostFocus(object sender, EventArgs e)
        {
            txtCompass_LostFocus2(sender, e);
        }

        private void txtCrew_LostFocus(object sender, EventArgs e)
        {
            txtCrew_LostFocus2(sender, e);
        }

        private void txtComment_LostFocus(object sender, EventArgs e)
        {
            txtComment_LostFocus2(sender, e);
        }

        private void MetadataForm_GotFocus(object sender, EventArgs e)
        {
            MetadataForm_GotFocus2(sender, e);
        }

    }
}