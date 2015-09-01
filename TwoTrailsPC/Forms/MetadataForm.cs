using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;

namespace TwoTrails.Forms
{
    public partial class MetadataForm : Form
    {
        public MetadataForm(DataAccessLayer d)
        {
            InitializeComponent();
            DAL = d;
            Init();
        }

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

        private void chkLock1_CheckedChanged(object sender, EventArgs e)
        {
            chkLock1_CheckStateChanged2(sender, e);
        }

        private void txtGps_TextChanged(object sender, EventArgs e)
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

        private void btnAutoFillGps_Click(object sender, EventArgs e)
        {
            btnAutoFillGps_Click2(sender, e);
        }

        private void btnLaserList_Click(object sender, EventArgs e)
        {
            btnLaserList_Click2(sender, e);
        }

        private void btnCompassList_Click(object sender, EventArgs e)
        {
            btnCompassList_Click2(sender, e);
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            txtComment_TextChanged2(sender, e);
        }

        private void pointNavigationCtrl1_AlreadyAtBeginning(object sender)
        {
            pointNavigationCtrl_AlreadyAtBeginning2(sender);
        }

        private void pointNavigationCtrl1_AlreadyAtEnd(object sender)
        {
            pointNavigationCtrl_AlreadyAtEnd2(sender);
        }

        private void pointNavigationCtrl1_JumpPoint(object sender)
        {
            pointNavigationCtrl_JumpPoint2(sender);
        }

        private void pointNavigationCtrl1_IndexChanged(object sender, TwoTrails.Controls.PointNavigationCtrl.PointNavEventArgs e)
        {
            pointNavigationCtrl_IndexChanged2(sender, e);
        }

        private void actionsControl1_Cancel_OnClick(object sender, EventArgs e)
        {
            actionsControl_Cancel_OnClick2(sender, e);
        }

        private void actionsControl1_Delete_OnClick(object sender, EventArgs e)
        {
            actionsControl_Delete_OnClick2(sender, e);
        }

        private void actionsControl1_Misc_OnClick(object sender, EventArgs e)
        {
            actionsControl_Misc_OnClick2(sender, e);
        }

        private void actionsControl1_New_OnClick(object sender, EventArgs e)
        {
            actionsControl_New_OnClick2(sender, e);
        }

        private void actionsControl1_Ok_OnClick(object sender, EventArgs e)
        {
            actionsControl_Ok_OnClick2(sender, e);
        }

        private void btnSetAsDefault_Click(object sender, EventArgs e)
        {
            btnSetAsDefault_Click2(sender, e);
        }
    }
}
