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
    public partial class ImportForm : Form
    {
        public ImportForm(DataAccessLayer dal, bool isOpen)
        {
            this.DialogResult = DialogResult.Abort;

            if(Engine.Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();

            DAL = dal;
            Init();
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            btnImport_Click2(sender, e);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            btnHelp_Click2(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen_Click2(sender, e);
        }

        private void chkTxtElev_CheckStateChanged(object sender, EventArgs e)
        {
            chkTxtElev_CheckedChanged2(sender, e);
        }

        private void ImportForm_Closing(object sender, CancelEventArgs e)
        {
            ImportForm_FormClosing2(sender, e);
        }


    }
}