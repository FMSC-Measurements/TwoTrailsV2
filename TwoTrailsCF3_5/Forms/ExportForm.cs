using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Forms
{
    public partial class ExportForm : Form
    {
        public ExportForm(DataAccess.DataAccessLayer d)
        {
            InitializeComponent();
            DAL = d;
            Init();
        }


        #region Controls
        private void btnFolder_Click(object sender, EventArgs e)
        {
            btnFolder_Click2(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnClose_Click2(sender, e);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport_Click2(sender, e);
        }
        #endregion

        #region Options
        private void chkOutAll_CheckStateChanged(object sender, EventArgs e)
        {
            chkOutAll_CheckStateChanged2(sender, e);
        }

        private void chkOutPoints_CheckStateChanged(object sender, EventArgs e)
        {
            chkOutPoints_CheckStateChanged2(sender, e);
        }

        private void chkOutProject_CheckStateChanged(object sender, EventArgs e)
        {
            chkOutProject_CheckStateChanged2(sender, e);
        }

        private void chkOutNmea_CheckStateChanged(object sender, EventArgs e)
        {
            chkOutNmea_CheckStateChanged2(sender, e);
        }

        private void chkOutKmz_CheckStateChanged(object sender, EventArgs e)
        {
            chkOutKmz_CheckStateChanged2(sender, e);
        }

        private void chkOutMeta_CheckStateChanged(object sender, EventArgs e)
        {
            chkOutMeta_CheckStateChanged2(sender, e);
        }

        private void chkOutPoly_CheckStateChanged(object sender, EventArgs e)
        {
            chkOutPoly_CheckStateChanged2(sender, e);
        }

        private void chkOutGpx_CheckStateChanged(object sender, EventArgs e)
        {
            chkOutGpx_CheckStateChanged2(sender, e);
        }

        private void chkOutSummary_CheckStateChanged(object sender, EventArgs e)
        {
            chkOutSummary_CheckStateChanged2(sender, e);
        }

        private void chkOutShape_CheckStateChanged(object sender, EventArgs e)
        {
            chkOutShape_CheckStateChanged2(sender, e);
        }

        private void chkOutHtml_CheckStateChanged(object sender, EventArgs e)
        {
            chkOutHtml_CheckStateChanged2(sender, e);
        }
        #endregion

        private void txtFolder_GotFocus(object sender, EventArgs e)
        {
            Utilities.Kb.ShowRegular(this);
        }

        private void txtFolder_LostFocus(object sender, EventArgs e)
        {
            Utilities.Kb.Hide(this);
        }

    }
}