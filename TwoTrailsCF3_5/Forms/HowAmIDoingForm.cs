using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Engine.BusinessLogic;

namespace TwoTrails.Forms
{
    public partial class HowAmIDoingForm : Form
    {
        private HowAmIDoingLogic _logic;
        private HowAmIDoingOptions _options;

        public HowAmIDoingForm(HowAmIDoingLogic logic, HowAmIDoingOptions options)
        {
            InitializeComponent();
            _logic = logic;
            _options = options;
        }

        private void HowAmIDoingForm_Load(object sender, EventArgs e)
        {
            _logic.Execute(false);
            reportTextBox.Text = _options.ReportText.ToString();

            if (Environment.OSVersion.Version.Major < 5)
                this.WindowState = FormWindowState.Maximized;
        }

        private void reportTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}