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
    public partial class GPSLoggerForm : Form
    {
        public GPSLoggerForm()
        {
            InitializeComponent();
        }

        private void GPSLoggerForm_Load(object sender, EventArgs e)
        {
            GPSLoggerForm_Load2(sender, e);
        }

        private void txtFile_Click(object sender, EventArgs e)
        {
            SelectFile();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            btnLog_Click2(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnClose_Click2(sender, e);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            btnOptions_Click2(sender, e);
        }

        private void GPSLoggerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GPSLoggerForm_Closing2(sender, e);
        }

        private void chkLogToFile_CheckedChanged(object sender, EventArgs e)
        {
            chkLogToFile_CheckStateChanged2(sender, e);
        }
    }
}
