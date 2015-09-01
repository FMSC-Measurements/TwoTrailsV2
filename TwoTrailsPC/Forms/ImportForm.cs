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
    public partial class ImportForm : Form
    {
        public ImportForm(DataAccessLayer dal, bool isOpen)
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Abort;

            DAL = dal;
            Init();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen_Click2(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            btnHelp_Click2(sender, e);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            btnImport_Click2(sender, e);
        }

        private void chkTxtElev_CheckedChanged(object sender, EventArgs e)
        {
            chkTxtElev_CheckedChanged2(sender, e);
        }

        private void chkShpMulti_CheckedChanged(object sender, EventArgs e)
        {
            chkShpMulti_CheckedChanged2(sender, e);
        }

        private void btnShpClear_Click(object sender, EventArgs e)
        {
            btnShpClear_Click2(sender, e);
        }

        private void btnShpRemove_Click(object sender, EventArgs e)
        {
            btnShpRemove_Click2(sender, e);
        }

        private void btnShpAdd_Click(object sender, EventArgs e)
        {
            btnShpAdd_Click2(sender, e);
        }

        private void chkShpElev_CheckedChanged(object sender, EventArgs e)
        {
            chkShpElev_CheckedChanged2(sender, e);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl_SelectedIndexChanged2(sender, e);
        }

        private void ImportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ImportForm_FormClosing2(sender, e);
        }

        private void chkGpxElev_CheckedChanged(object sender, EventArgs e)
        {
            chkGpxElev_CheckedChanged2(sender, e);
        }
    }
}
