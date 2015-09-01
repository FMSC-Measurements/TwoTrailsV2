using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;
using TwoTrails.Utilities;
using TwoTrails.Forms;
using TwoTrails.GpsAccess;

namespace TwoTrails.Controls
{
    public partial class GpsSettingsCtrl : UserControl
    {
        private bool getPort, getBaud, gpsRecvData, startCheck = false;
        private string errMsg;
        bool _init = false; 

        public GpsSettingsCtrl()
        {
            InitializeComponent();
            loadGpsSettingCtrl();
            _init = true;
        }

        public void loadGpsSettingCtrl()
        {
            //GPS Delegates to interact with the form
            Values.GPSA.BurstReceived += GPSA_BurstReceived;
            Values.GPSA.BurstReceived += GPSA_BurstReceived;
            Values.GPSA.InvalidStringFound += GPSA_InvalidStringFound;
            Values.GPSA.ComTimeout += GPSA_ComTimeout;
            Values.GPSA.GpsEnded += GPSA_GpsEnded;
            Values.GPSA.GpsError += GPSA_GpsError;
            Values.GPSA.ValidStringReceived += GPSA_ValidStringReceived;

#if (PocketPC || WindowsCE || Mobile)
            if (Values.Settings.DeviceOptions.UseSelection)
            {
                cboGpsPort.Visible = false;
                btnGpsPort.Visible = true;
                cboGpsBaud.Visible = false;
                btnGpsBaud.Visible = true;
            }
            else
            {
                cboGpsPort.Visible = true;
                btnGpsPort.Visible = false;
                cboGpsBaud.Visible = true;
                btnGpsBaud.Visible = false;
            }
#endif

            foreach (string port in Values.DEFAULT_PORT_NAMES)
            {
                cboGpsPort.Items.Add(port);
            }

            foreach (int baud in Values.DEFAULT_BAUD_VALUES)
            {
                cboGpsBaud.Items.Add(baud.ToString());
            }

            string gpsPort = Values.Settings.DeviceOptions.GpsComPort;
            //string gpsPort = TtUtils.RemoveNonAlphaNumeric(Values.Settings.DeviceOptions.GpsComPort);
            
            int gpsBaud = Values.Settings.DeviceOptions.GpsBaud;

            if (Values.DEFAULT_PORT_NAMES.IndexOf(gpsPort) < 0)
            {
                cboGpsPort.Items.Add(gpsPort);
            }

            if (Values.DEFAULT_BAUD_VALUES.IndexOf(gpsBaud) < 0)
            {
                cboGpsPort.Items.Add(gpsBaud);
            }

            cboGpsPort.Text = gpsPort;
            cboGpsBaud.Text = gpsBaud.ToString();

#if (PocketPC || WindowsCE || Mobile)
            btnGpsPort.Text = gpsPort;
            btnGpsBaud.Text = gpsBaud.ToString();
#endif


            getBaud = false;
            getPort = false;

            gpsRecvData = false;

            errMsg = "";
        }
        
        public void CloseGps()
        {
            if (!Values.Settings.DeviceOptions.KeepGpsOn)
            {
                if (Values.GPSA.IsBusy)
                {
                    Values.GPSA.CloseGps();
                }
            }
            btnHelp.Visible = false;

            Values.GPSA.BurstReceived -= GPSA_BurstReceived;
            Values.GPSA.InvalidStringFound -= GPSA_InvalidStringFound;
            Values.GPSA.ComTimeout -= GPSA_ComTimeout;
            Values.GPSA.GpsEnded -= GPSA_GpsEnded;
            Values.GPSA.GpsError -= GPSA_GpsError;
        }
        
        #region Controls
        private void cboGpsPort_SelectedIndexChanged2(object sender, EventArgs e)
        {
            getPortSelection(cboGpsPort.Text.ToString());
        }

        private void cboGpsBaud_SelectedIndexChanged2(object sender, EventArgs e)
        {
            getBaudSelection(cboGpsBaud.Text.ToString());
        }
#if (PocketPC || WindowsCE || Mobile)
        private void btnGpsPort_Click2(object sender, EventArgs e)
        {
            List<string> cboItems = new List<string>();
            string selection = null;

            foreach (string item in cboGpsPort.Items)
            {
                cboItems.Add(item);
            }

            using (Selection form = new Selection("GPS Port", cboItems, cboGpsPort.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    selection = cboItems[form.selection].ToString();
                    getPortSelection(selection);
                }
            }
        }

        private void btnGpsBaud_Click2(object sender, EventArgs e)
        {
            List<string> cboItems = new List<string>();
            string selection = null;

            foreach (string item in cboGpsBaud.Items)
            {
                cboItems.Add(item);
            }

            using (Selection form = new Selection("GPS Port", cboItems, cboGpsBaud.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    selection = cboItems[form.selection].ToString();
                    getBaudSelection(selection);
                }
            }
        }
#endif
        private void btnCheckGps_Click2(object sender, EventArgs e)
        {
            btnHelp.Visible = false;
            gpsRecvData = false;
            startCheck = true;

            if (Values.GPSA.IsBusy)
            {
                txtGpsOutput.Text = "Closing GPS connection..";
                Values.GPSA.CloseGps();
                txtGpsOutput.Text = "GPS connection closed.";
                System.Threading.Thread.Sleep(500);
            }

            txtGpsOutput.Text = "Accessing GPS..";
            Values.GPSA.TestGps(Values.Settings.DeviceOptions.GpsComPort, Values.Settings.DeviceOptions.GpsBaud);
        }

        private void btnAutoGps_Click2(object sender, EventArgs e)
        {
            using (ComPortFinder cpf = new ComPortFinder())
            {
                TtUtils.ShowWaitCursor();
                Values.GPSA.CloseGps();
                System.Threading.Thread.Sleep(150);
                cpf.Find();
                TtUtils.HideWaitCursor();

                List<ComPortFinder.SerialDevice> devs = cpf.GetValidDevices();

                if (devs.Count > 0)
                {
                    DisplayDevices(devs, cpf);
                }
                else
                {
                    if(MessageBox.Show("Could not locate GPS Reciever. Would you like to try finding the port using a different method? (will be slow)",
                        "GPS Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        TtUtils.ShowWaitCursor();
                        Values.GPSA.CloseGps();
                        System.Threading.Thread.Sleep(150);
                        cpf.FindNoThread();
                        TtUtils.HideWaitCursor();

                        if (devs.Count > 0)
                        {
                            DisplayDevices(devs, cpf);
                        }
                        else
                        {
                            AutoClosingMessageBox.Show("Could not locatate GPS Reciever", "GPS Not Found", 2000);
                        }
                    }           
                }
                //AutoClosingMessageBox.Show("Could not locatate GPS Reciever", "GPS Not Found", 2000);
            }
        }

        private void DisplayDevices(List<ComPortFinder.SerialDevice> devs, ComPortFinder cpf)
        {
            if (devs.Count == 1)
            {
                ComPortFinder.SerialDevice dev = devs[0];
                getPortSelection(dev.Port);
                getBaudSelection(dev.Baud.ToString());
                Values.GPSA.TestGps(Values.Settings.DeviceOptions.GpsComPort, Values.Settings.DeviceOptions.GpsBaud);
                Values.Settings.DeviceOptions.GpsConfigured = true;
                AutoClosingMessageBox.Show(String.Format("GPS set to Port: {0} with a Baud of {1}", dev.Port, dev.Baud), "GPS Found", 3000);
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Several Devices Found:\n");

                foreach (ComPortFinder.SerialDevice dev in cpf.GetValidDevices())
                {
                    sb.AppendFormat("(P:{0} - B:{1}){2}\n", dev.Port, dev.Baud, Environment.NewLine);
                }

                MessageBox.Show(sb.ToString());
            }
        }

        private void btnHelp_Click2(object sender, EventArgs e)
        {
            MessageBox.Show(errMsg);
        }

        #endregion


        #region Port and Baud selection
        private void getPortSelection(string portChoice)
        {
            if (!_init) return;

            if (portChoice != "Other")
            {
                Values.Settings.DeviceOptions.GpsComPort = portChoice;
#if (PocketPC || WindowsCE || Mobile)
                btnGpsPort.Text = portChoice;
#endif
                cboGpsPort.Text = portChoice;

                if (Values.Settings.DeviceOptions.GpsComPort.ToLower() != "file")
                {
                    if(!System.IO.File.Exists(Values.Settings.DeviceOptions.GpsComPort))
                        Values.Settings.DeviceOptions.GpsConfigured = false;
                }
                else
                {
                    using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
                    {
                        ofd.Filter = "Text Files|*.txt|All Files|*.*";

                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            Values.Settings.DeviceOptions.GpsComPort = ofd.FileName;
                            Values.Settings.DeviceOptions.GpsConfigured = true;
                            Values.Settings.DeviceOptions.KeepGpsOn = false;
                        }
                    }
                }
            }
            else
            {
                lblValue.Text = "COM:";
                getPort = true;
                txtPortValue.Text = String.Empty;
                txtPortValue.Visible = true;
                txtBaudValue.Visible = false;
                pnlOtherChoice.Visible = true;
            }
#if !(PocketPC || WindowsCE || Mobile)
            toolTip1.SetToolTip(cboGpsPort, Values.Settings.DeviceOptions.GpsComPort);
#endif
        }

        private void getBaudSelection(string baudChoice)
        {
            if (!_init) return;

            if (baudChoice != "Other")
            {
                Values.Settings.DeviceOptions.GpsBaud = Convert.ToInt32(baudChoice);
#if (PocketPC || WindowsCE || Mobile)
                btnGpsBaud.Text = baudChoice;
#endif
                cboGpsBaud.Text = baudChoice;
            }
            else
            {
                lblValue.Text = "Baud: ";
                getBaud = true;
                txtBaudValue.Text = "";
                txtBaudValue.Visible = true;
                txtPortValue.Visible = false;
                pnlOtherChoice.Visible = true;
            }
#if !(PocketPC || WindowsCE || Mobile)
            toolTip1.SetToolTip(cboGpsBaud, Values.Settings.DeviceOptions.GpsBaud.ToString());
#endif
        }

        private void btnOkChoice_Click2(object sender, EventArgs e)
        {
            string baudText, portText;
            int tmp = -1, atPos = -1;

            if (getPort)
            {
                portText = TtUtils.RemoveNonAlphaNumeric(txtPortValue.Text);

                try
                {
                    tmp = Int32.Parse(portText);

                    if (tmp < 0)
                    {
                        throw new Exception("isNegative");
                    }

                    portText = ("COM" + tmp);

                    atPos = cboGpsPort.Items.IndexOf(portText);

                    if (atPos < 0)
                    {
                        cboGpsPort.Items.Add(portText);
                    }

                    cboGpsPort.Text = portText;
#if (PocketPC || WindowsCE || Mobile)
                    btnGpsPort.Text = portText;
#endif
                    Values.Settings.DeviceOptions.GpsComPort = portText;


                    getPort = false;
                    pnlOtherChoice.Visible = false;
                }
                catch (Exception ex)
                {
                    if (ex.Message == "isNegative")
                    {
                        MessageBox.Show("The number must be Positive.");
                    }
                    else
                    {
                        MessageBox.Show("Text must be Numeric.");
                    }
                }

            }
            else if (getBaud)
            {
                baudText = TtUtils.RemoveNonAlphaNumeric(txtBaudValue.Text);

                try
                {
                    tmp = Int32.Parse(baudText);

                    if (tmp < 0)
                    {
                        throw new Exception("isNegative");
                    }

                    atPos = cboGpsPort.Items.IndexOf(tmp);

                    if (atPos < 0)
                    {
                        cboGpsPort.Items.Add(tmp);
                    }

                    cboGpsBaud.Text = tmp.ToString();
#if (PocketPC || WindowsCE || Mobile)
                    btnGpsBaud.Text = tmp.ToString();
#endif
                    Values.Settings.DeviceOptions.GpsBaud = tmp;


                    getBaud = false;
                    pnlOtherChoice.Visible = false;
                }
                catch (Exception ex)
                {
                    if (ex.Message == "isNegative")
                    {
                        MessageBox.Show("The number must be Positive.");
                    }
                    else
                    {
                        MessageBox.Show("Text must be Numeric.");
                    }
                }
            }
        }
        #endregion


        #region GPS Functions
        private void GPSA_GpsError()
        {
            string error = null;

            switch (Values.GPSA.Error)
            {
                case GpsAccess.GpsErrorType.ComNotExist:
                    error = Values.Settings.DeviceOptions.GpsComPort + " does not exist.";
                    errMsg = Values.Settings.DeviceOptions.GpsComPort + " does not exist. Try using a different COM port.";
                    break;
                case GpsAccess.GpsErrorType.GpsTimeout:
                    error = "GPS connection timed out.";
                    errMsg = "The GPS timed out. Try using a different Baud.";
                    break;
                case GpsAccess.GpsErrorType.NoError:
                    errMsg = "No Error occured.";
                    break;
                case TwoTrails.GpsAccess.GpsErrorType.FileNotSelectedError:
                    error = "No file sellected.";
                    txtGpsOutput.Text = "";
                    break;
                case GpsAccess.GpsErrorType.UnknownError:
                default:
                    error = "Unknown Error.";
                    errMsg = "An unknown error occured. View ErrorLog.txt for details.";
                    break;
            }

            if (error != null)
            {
                Values.Settings.DeviceOptions.GpsConfigured = false;

                this.GuiInvoke(() =>
                    {
                        txtGpsOutput.Text = error;
                        btnHelp.Visible = true;

                        MessageBox.Show(errMsg);
                    });
            }
        }

        private void GPSA_GpsEnded()
        {
        }

        private void GPSA_ComTimeout()
        {
            this.GuiInvoke(() =>
            {
                txtGpsOutput.Text = "GPS connection timed out.";
                Values.GPSA.CloseGps();
                GPSA_GpsError();
            });
        }

        private void GPSA_BurstReceived(TwoTrails.GpsAccess.NmeaBurst b)
        {
            //string data = "Lat: " + b._latitude.ToString() + ", Lon: " + b._longitude.ToString();

            /*

            if (startCheck)
            {
                if (!gpsRecvData)
                {
                    Values.Settings.DeviceOptions.GpsConfigured = true;
                    startCheck = false;

                    this.GuiInvoke(() =>
                        {
                            gpsRecvData = true;
                            txtGpsOutput.Text = "GPS Successful";
                            Values.GPSA.CloseGps(); ;

                            AutoClosingMessageBox.Show("GPS Configured", "Gps Configuration", 1000);
                        });
                }
            }
            */
        }

        private void GPSA_ValidStringReceived(string validString)
        {
            if (startCheck)
            {
                if (!gpsRecvData)
                {
                    Values.Settings.DeviceOptions.GpsConfigured = true;
                    startCheck = false;

                    this.GuiInvoke(() =>
                    {
                        gpsRecvData = true;
                        txtGpsOutput.Text = "GPS Successful";
                        Values.GPSA.CloseGps(); ;

                        AutoClosingMessageBox.Show("GPS Configured", "Gps Configuration", 1000);
                    });
                }
            }
        }

        private void GPSA_InvalidStringFound()
        {
            this.GuiInvoke(() =>
            {
                txtGpsOutput.Text = "GPS receiving invalid data.";
                //GPSA_GpsError();
            });
        }
        
        #endregion
    }
}
