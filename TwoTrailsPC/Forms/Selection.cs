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
    public partial class Selection : Form
    {
        public int selection { get; internal set; }
        private bool closed = true;
        private int cSelect = -1;   //current selected index

        public Selection(string title, List<string> options, int currSelection)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Map;
            this.DialogResult = DialogResult.Cancel;
            selection = -1;

            if (currSelection < 0)
                cSelect = 0;
            else
                cSelect = currSelection;

            this.Text = title;
            lstSelection.Font = new Font(FontFamily.GenericSansSerif, 18, FontStyle.Regular);
            lstSelection.DataSource = options;
        }

        private void lstSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            selection = lstSelection.SelectedIndex;
            if (!closed)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else  //for first run
            {
                selection = cSelect;
                lstSelection.SelectedIndex = cSelect;
                closed = false;
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
