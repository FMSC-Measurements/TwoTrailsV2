using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Controls
{
    public partial class GpsSettingsCtrl : UserControl
    {
        private void cboGpsPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboGpsPort_SelectedIndexChanged2(sender, e);
        }

        private void cboGpsBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboGpsBaud_SelectedIndexChanged2(sender, e);
        }

        private void btnAutoGps_Click(object sender, EventArgs e)
        {
            btnAutoGps_Click2(sender, e);
        }

        private void btnCheckGps_Click(object sender, EventArgs e)
        {
            btnCheckGps_Click2(sender, e);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            btnHelp_Click2(sender, e);
        }

        private void btnOkChoice_Click(object sender, EventArgs e)
        {
            btnOkChoice_Click2(sender, e);
        }
    }
}
