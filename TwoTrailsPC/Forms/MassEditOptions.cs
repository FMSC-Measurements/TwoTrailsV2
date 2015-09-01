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
    public partial class MassEditOptions : Form
    {
        public MassEditOptions()
        {
            InitializeComponent();
        }

        private void MassEditOptions_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;

            chkAutoClosePolys.Checked = Values.Settings.DeviceOptions.FormMassEditAutoClosePoly;
            chkAltRows.Checked = Values.Settings.DeviceOptions.FormMassEditUseAlternatingRows;
            chkRowColors.Checked = Values.Settings.DeviceOptions.FormMassEditUseColoredRows;
            
            radElevFeet.Checked = Values.Settings.DeviceOptions.FormMassEditElevationFeet;
            radElevMeters.Checked = !Values.Settings.DeviceOptions.FormMassEditElevationFeet;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Values.Settings.WriteDeviceSettings();
            this.Close();
        }

        private void radElevFeet_CheckedChanged(object sender, EventArgs e)
        {
            Values.Settings.DeviceOptions.FormMassEditElevationFeet = radElevFeet.Checked;
        }

        private void chkAltRows_CheckedChanged(object sender, EventArgs e)
        {
            Values.Settings.DeviceOptions.FormMassEditUseAlternatingRows = chkAltRows.Checked;
        }

        private void chkRowColors_CheckedChanged(object sender, EventArgs e)
        {
            Values.Settings.DeviceOptions.FormMassEditUseColoredRows = chkRowColors.Checked;
        }

        private void chkAutoClosePolys_CheckedChanged(object sender, EventArgs e)
        {
            Values.Settings.DeviceOptions.FormMassEditAutoClosePoly = chkAutoClosePolys.Checked;
        }

    }
}
