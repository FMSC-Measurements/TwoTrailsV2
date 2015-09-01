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
    public partial class ProjectInfoForm : Form
    {
        public ProjectInfoForm(DataAccess.DataAccessLayer d)
        {
            InitializeComponent();
            _data = d;
        }

        private void textBoxProjName_TextChanged(object sender, EventArgs e)
        {
            textBoxProjName_TextChanged2(sender, e);
        }

        private void textBoxProjDescription_TextChanged(object sender, EventArgs e)
        {
            textBoxProjDescription_TextChanged2(sender, e);
        }

        private void textBoxRegion_TextChanged(object sender, EventArgs e)
        {
            textBoxRegion_TextChanged2(sender, e);
        }

        private void textBoxForest_TextChanged(object sender, EventArgs e)
        {
            textBoxForest_TextChanged2(sender, e);
        }

        private void textBoxDistrict_TextChanged(object sender, EventArgs e)
        {
            textBoxDistrict_TextChanged2(sender, e);
        }

        private void textBoxYear_TextChanged(object sender, EventArgs e)
        {
            textBoxYear_TextChanged2(sender, e);
        }

        private void ProjectInfoForm_Load(object sender, EventArgs e)
        {
            ProjectInfoForm_Load2(sender, e);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonCancel_Click2(sender, e);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            buttonOK_Click2(sender, e);
        }

        private void chkDropZeros_CheckedChanged(object sender, EventArgs e)
        {
            chkDropZeros_CheckedChanged2(sender, e);
        }

        private void chkRound_CheckedChanged(object sender, EventArgs e)
        {
            chkRound_CheckedChanged2(sender, e);
        }
    }
}
