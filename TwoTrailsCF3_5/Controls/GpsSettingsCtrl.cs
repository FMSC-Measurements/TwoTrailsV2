using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessLogic;
using TwoTrails.Engine;
using TwoTrails.Utilities;
using TwoTrails.Forms;

namespace TwoTrails.Controls
{
    public partial class GpsSettingsCtrl : UserControl
    {
        #region Controls
        private void cboGpsPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboGpsPort_SelectedIndexChanged2(sender, e);
        }

        private void btnGpsPort_Click(object sender, EventArgs e)
        {
            btnGpsPort_Click2(sender, e);
        }

        private void cboGpsBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboGpsBaud_SelectedIndexChanged2(sender, e);
        }

        private void btnGpsBaud_Click(object sender, EventArgs e)
        {
            btnGpsBaud_Click2(sender, e);
        }

        private void btnCheckGps_Click(object sender, EventArgs e)
        {
            btnCheckGps_Click2(sender, e);
        }

        private void btnAutoGps_Click(object sender, EventArgs e)
        {
            btnAutoGps_Click2(sender, e);
        }
        #endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            btnHelp_Click2(sender, e);
        }

        private void btnOkChoice_Click(object sender, EventArgs e)
        {
            btnOkChoice_Click2(sender, e);
        }

        private void txtBaudValue_GotFocus(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtBaudValue);
        }

        private void txtBaudValue_LostFocus(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }
    }
}
