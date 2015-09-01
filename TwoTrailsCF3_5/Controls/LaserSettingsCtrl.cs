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
using TwoTrails.LaserAccess;

namespace TwoTrails.Controls
{
    public partial class LaserSettingsCtrl : UserControl
    {
        public LaserSettingsCtrl()
        {
            InitializeComponent();
            loadLaserSettingCtrl();
        }

        private void cboLaserPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLaserPort_SelectedIndexChanged2(sender, e);
        }

        private void btnLaserPort_Click(object sender, EventArgs e)
        {
            btnLaserPort_Click2(sender, e);
        }

        private void cboLaserBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLaserBaud_SelectedIndexChanged2(sender, e);
        }

        private void btnLaserBaud_Click(object sender, EventArgs e)
        {
            btnLaserBaud_Click2(sender, e);
        }

        private void btnCheckLaser_Click(object sender, EventArgs e)
        {
            btnCheckLaser_Click2(sender, e);
        }

        private void btnAutoLaser_Click(object sender, EventArgs e)
        {
            btnAutoLaser_Click2(sender, e);
        }

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
