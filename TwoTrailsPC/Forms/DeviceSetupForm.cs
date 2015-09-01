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
    public partial class DeviceSetupForm : Form
    {
        public DeviceSetupForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnClose_Click2(sender, e);
        }


        void DeviceSetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeviceSetupForm_Closing2(sender, e);
        }
    }
}
