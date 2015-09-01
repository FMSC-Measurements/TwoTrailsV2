using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;

namespace TwoTrails.Forms
{
    public partial class DeviceSetupForm : Form
    {
        public DeviceSetupForm()
        {
            if (Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();
        }

        private void DeviceSetupForm_Closing(object sender, CancelEventArgs e)
        {
            DeviceSetupForm_Closing2(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnClose_Click2(sender, e);
        }
    }
}