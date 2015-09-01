using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TwoTrails.Engine;
using TwoTrails.Utilities;
using TwoTrails.GpsAccess;

namespace TwoTrails.Forms
{
    public partial class GPSLoggerForm : Form
    {
        bool _Logging = false, loading = false;

        void GPSA_ValidStringReceived(string GpsString)
        {
            if (_Logging && Values.GPSA.LogOnlyValid)
            {
                lstStrings.GuiInvoke(() =>
                    {
                        lstStrings.Items.Insert(0, GpsString);

                        //lstStrings.Items.Add(GpsString);
                        //lstStrings.TopIndex = lstStrings.Items.Count - 1;
                    });
            }
        }

        void GPSA_StringReceived(string GpsString)
        {
            if (_Logging && !Values.GPSA.LogOnlyValid)
            {
                lstStrings.GuiInvoke(() =>
                    {
                        lstStrings.Items.Insert(0, GpsString);

                        //lstStrings.Items.Add(GpsString);
                        //lstStrings.TopIndex = lstStrings.Items.Count - 1;
                    });
            }
        }

        private void GPSLoggerForm_Load2(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;
            loading = true;

            Values.GPSA.StringReceived += GPSA_StringReceived;
            Values.GPSA.ValidStringReceived += GPSA_ValidStringReceived;

            if (!Values.GPSA.IsBusy)
            {
                Values.GPSA.OpenGps();
            }

            txtFile.Text = Values.GPSA.LogFilename;
            txtFile.SelectionStart = txtFile.Text.Length;

            loading = false;
        }

        private void GPSLoggerForm_Closing2(object sender, CancelEventArgs e)
        {
            Values.GPSA.StringReceived -= new DelegateDeliverGpsString(GPSA_StringReceived);
            Values.GPSA.ValidStringReceived -= new DelegateDeliverGpsString(GPSA_ValidStringReceived);

            if (!Values.Settings.DeviceOptions.KeepGpsOn)
            {
                if (Values.GPSA.IsBusy)
                {
                    Values.GPSA.CloseGps();
                }
            }
        }

        private void btnLog_Click2(object sender, EventArgs e)
        {
            _Logging = !_Logging;



            if (_Logging)
                btnLog.Text = "Stop";
            else
                btnLog.Text = "Log";
        }

        private void btnOptions_Click2(object sender, EventArgs e)
        {

        }

        private void btnClose_Click2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkLogToFile_CheckStateChanged2(object sender, EventArgs e)
        {
            Values.GPSA.LogToFile = chkLogToFile.Checked;
        }

        private void SelectFile()
        {
            lstStrings.Focus();
            if (!loading)
            {
//#if (PocketPC || WindowsCE || Mobile)
                /*
                using (SelectFileDialogEx sfd =
                    new SelectFileDialogEx(Values.GPSA.LogFilename, Values.Settings.ProjectSettingsFilePath))
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        txtFile.Text = sfd.FileName;
                        txtFile.SelectionStart = txtFile.Text.Length;
                        Values.GPSA.LogFilename = sfd.FileName;
                    }
                }
                */
//#else

                if (saveFileDialog1.FileName.IsEmpty())
                    saveFileDialog1.FileName = Values.GPSA.LogFilename;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtFile.Text = saveFileDialog1.FileName;
                    txtFile.SelectionStart = txtFile.Text.Length;
                    Values.GPSA.LogFilename = saveFileDialog1.FileName;
                }
//#endif
            }

            chkLogToFile.Focus();
        }
    }
}
