using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;

namespace TwoTrails.Forms
{
    public partial class DeviceSetupForm : Form
    {
        private void DeviceSetupForm_Closing2(object sender, CancelEventArgs e)
        {
            //gpsSettingsCtrl.close();
            Values.Settings.WriteDeviceSettings();
        }

        private void btnClose_Click2(object sender, EventArgs e)
        {
            if (!Values.Settings.DeviceOptions.GpsConfigured)
            {
                //if not configed, finish configuring?
                if (MessageBox.Show("The GPS is not configured. Would you like to exit the GPS setup anyway?",
                    "GPS not configured", MessageBoxButtons.YesNo, MessageBoxIcon.Hand,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gpsSettingsCtrl.CloseGps();
                    this.Close();
                }

            }
            else
            {
                gpsSettingsCtrl.CloseGps();
                this.Close();
            }
        }
    }
}
