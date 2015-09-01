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
    public partial class ExportForm : Form
    {
        public ExportForm(DataAccess.DataAccessLayer d)
        {
            InitializeComponent();
            DAL = d;
            Init();
        }

        private void chkOutAll_CheckedChanged(object sender, EventArgs e)
        {
            chkOutAll_CheckStateChanged2(sender, e);
        }

        private void chkOutPoints_CheckedChanged(object sender, EventArgs e)
        {
            chkOutPoints_CheckStateChanged2(sender, e);
        }

        private void chkOutProject_CheckedChanged(object sender, EventArgs e)
        {
            chkOutProject_CheckStateChanged2(sender, e);
        }

        private void chkOutNmea_CheckedChanged(object sender, EventArgs e)
        {
            chkOutNmea_CheckStateChanged2(sender, e);
        }

        private void chkOutKmz_CheckedChanged(object sender, EventArgs e)
        {
            chkOutKmz_CheckStateChanged2(sender, e);
        }

        private void chkOutMeta_CheckedChanged(object sender, EventArgs e)
        {
            chkOutMeta_CheckStateChanged2(sender, e);
        }

        private void chkOutPoly_CheckedChanged(object sender, EventArgs e)
        {
            chkOutPoly_CheckStateChanged2(sender, e);
        }

        private void chkOutGpx_CheckedChanged(object sender, EventArgs e)
        {
            chkOutGpx_CheckStateChanged2(sender, e);
        }

        private void chkOutSummary_CheckedChanged(object sender, EventArgs e)
        {
            chkOutSummary_CheckStateChanged2(sender, e);
        }

        private void chkOutShape_CheckedChanged(object sender, EventArgs e)
        {
            chkOutShape_CheckStateChanged2(sender, e);
        }

        private void chkOutHtml_CheckedChanged(object sender, EventArgs e)
        {
            chkOutHtml_CheckStateChanged2(sender, e);
        }

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
    }
}
