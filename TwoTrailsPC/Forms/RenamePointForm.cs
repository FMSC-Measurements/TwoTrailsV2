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
    public partial class RenamePointForm : Form
    {
        public RenamePointForm(DataAccessLayer d)
        {
            DAL = d;
            InitializeComponent();
            Init();
        }

        private void cboPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPoly_SelectedIndexChanged2(sender, e);
        }

        private void lstPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPoints_SelectedIndexChanged2(sender, e);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            btnFirst_Click2(sender, e);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            btnUp_Click2(sender, e);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            btnDown_Click2(sender, e);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            btnLast_Click2(sender, e);
        }

        private void txtPID_TextChanged(object sender, EventArgs e)
        {
            txtPID_TextChanged2(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            btnAuto_Click2(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk_Click2(sender, e);
        }

        private void RenamePointForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
