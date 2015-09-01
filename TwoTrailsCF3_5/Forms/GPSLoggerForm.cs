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
    public partial class GPSLoggerForm : Form
    {
        public GPSLoggerForm()
        {
            if (TwoTrails.Engine.Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();
        }

        private void GPSLoggerForm_Load(object sender, EventArgs e)
        {
            GPSLoggerForm_Load2(sender, e);
        }

        private void GPSLoggerForm_Closing(object sender, CancelEventArgs e)
        {
            GPSLoggerForm_Closing2(sender, e);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            btnLog_Click2(sender, e);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            btnOptions_Click2(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnClose_Click2(sender, e);
        }

        private void chkLogToFile_CheckStateChanged(object sender, EventArgs e)
        {
            chkLogToFile_CheckStateChanged2(sender, e);
        }

        private void txtFile_GotFocus(object sender, EventArgs e)
        {
            SelectFile();
        }
    }
}