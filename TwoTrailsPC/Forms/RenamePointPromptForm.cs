using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class RenamePointPromptForm : Form
    {
        public int StartIndex;
        public int Increment;

        public RenamePointPromptForm(int start, int inc)
        {
            InitializeComponent();
            StartIndex = start;
            Increment = inc;

            txtStartIndex.Text = start.ToString();
            txtIncrement.Text = inc.ToString();

            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtStartIndex.Text.IsInteger())
            {
                if (txtIncrement.Text.IsInteger())
                {
                    StartIndex = txtStartIndex.Text.ToInteger();
                    Increment = txtIncrement.Text.ToInteger();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    txtIncrement.Focus();
            }
            else
                txtStartIndex.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
