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
using TwoTrails.LaserAccess;

namespace TwoTrails.Controls
{

    public partial class LaserSettingsCtrl : UserControl
    {
        private bool getPort, getBaud;
        private int invalidDataCount;
        private string errMsg;
        private bool _laserDelegatesOpen;

        public void loadLaserSettingCtrl()
        {
            btnAutoLaser.Enabled = false;

#if (PocketPC || WindowsCE || Mobile)
            if (Values.Settings.DeviceOptions.UseSelection)
            {
                cboLaserPort.Visible = false;
                btnLaserPort.Visible = true;
                cboLaserBaud.Visible = false;
                btnLaserBaud.Visible = true;
            }
            else
            {
                cboLaserPort.Visible = true;
                btnLaserPort.Visible = false;
                cboLaserBaud.Visible = true;
                btnLaserBaud.Visible = false;
            }
#endif

            foreach (string port in Values.DEFAULT_PORT_NAMES)
            {
                cboLaserPort.Items.Add(port);
            }

            foreach (int baud in Values.DEFAULT_BAUD_VALUES)
            {
                cboLaserBaud.Items.Add(baud.ToString());
            }

            //string LaserPort = TtUtils.RemoveNonAlphaNumeric(Values.Settings.DeviceOptions.LaserComPort);
            string LaserPort = Values.Settings.DeviceOptions.LaserComPort;
            
            int LaserBaud = Values.Settings.DeviceOptions.LaserBaud;

            if (Values.DEFAULT_PORT_NAMES.IndexOf(LaserPort) < 0)
            {
                cboLaserPort.Items.Add(LaserPort);
            }

            if (Values.DEFAULT_BAUD_VALUES.IndexOf(LaserBaud) < 0)
            {
                cboLaserPort.Items.Add(LaserBaud);
            }

            cboLaserPort.Text = LaserPort;
            cboLaserBaud.Text = LaserBaud.ToString();
#if (PocketPC || WindowsCE || Mobile)
            btnLaserPort.Text = LaserPort;
            btnLaserBaud.Text = LaserBaud.ToString();
#endif

            getBaud = false;
            getPort = false;

            errMsg = "";

            _laserDelegatesOpen = false;
        }

        private void cboLaserPort_SelectedIndexChanged2(object sender, EventArgs e)
        {
            getPortSelection(cboLaserPort.Text.ToString());
        }

        private void cboLaserBaud_SelectedIndexChanged2(object sender, EventArgs e)
        {
            getBaudSelection(cboLaserBaud.Text.ToString());
        }
#if (PocketPC || WindowsCE || Mobile)
        private void btnLaserPort_Click2(object sender, EventArgs e)
        {
            List<string> cboItems = new List<string>();
            string selection = null;

            foreach (string item in cboLaserPort.Items)
            {
                cboItems.Add(item);
            }

            using (Selection form = new Selection("Laser Port", cboItems, cboLaserPort.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    selection = cboItems[form.selection].ToString();
                    getPortSelection(selection);
                }
            }
        }

        private void btnLaserBaud_Click2(object sender, EventArgs e)
        {
            List<string> cboItems = new List<string>();
            string selection = null;

            foreach (string item in cboLaserBaud.Items)
            {
                cboItems.Add(item);
            }

            using (Selection form = new Selection("Laser Port", cboItems, cboLaserBaud.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    selection = cboItems[form.selection].ToString();
                    getBaudSelection(selection);
                }
            }
        }
#endif
        private void btnCheckLaser_Click2(object sender, EventArgs e)
        {
            invalidDataCount = 0;
            btnHelp.Visible = false;

            if (Values.LaserA.IsBusy)
            {
                txtLaserOutput.Text = "Closing Laser connection..";
                CloseLaser();
                txtLaserOutput.Text = "Laser connection closed.";
                while (Values.LaserA.IsBusy)
                {
                    System.Threading.Thread.Sleep(10);
                }
            }

            Values.LaserA.LaserEnded += new LaserAccess.LaserAccess.DelegateLaserEnded(LaserA_LaserEnded);
            Values.LaserA.LaserStarted += new LaserAccess.LaserAccess.DelegateLaserStarted(LaserA_LaserStarted);
            Values.LaserA.LaserError += new LaserAccess.LaserAccess.DelegateLaserError(LaserA_LaserError);
            Values.LaserA.InvalidStringFound += new LaserAccess.LaserAccess.DelegateInvalidStringFound(LaserA_InvalidStringFound);
            Values.LaserA.DataReceived += new LaserAccess.LaserAccess.DelegateDeliverData(LaserA_DataReceived);
            _laserDelegatesOpen = true;

            txtLaserOutput.Text = "Accessing Laser..";
            Values.LaserA.OpenLaser(Values.Settings.DeviceOptions.LaserComPort, Values.Settings.DeviceOptions.LaserBaud);
        }

        private void btnAutoLaser_Click2(object sender, EventArgs e)
        {
            using (ComPortFinder cpf = new ComPortFinder(ComPortFinder.DeviceType.Laser))
            {
                TtUtils.ShowWaitCursor();
                cpf.Find();
                TtUtils.HideWaitCursor();

                List<ComPortFinder.SerialDevice> devs = cpf.GetValidDevices();

                if (devs.Count > 0)
                {
                    if (devs.Count == 1)
                    {
                        ComPortFinder.SerialDevice dev = devs[0];
                        getPortSelection(dev.Port);
                        getBaudSelection(dev.Baud.ToString());
                        Values.LaserA.OpenLaser(Values.Settings.DeviceOptions.LaserComPort, Values.Settings.DeviceOptions.LaserBaud);
                        AutoClosingMessageBox.Show(String.Format("Laser set to Port: {0} with a Baud of {1}", dev.Port, dev.Baud), "Laser Found", 3000);
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
                else
                {
                    AutoClosingMessageBox.Show("Could not locatate Laser", "Laser Not Found", 2000);
                }
            }
        }


        public void CloseLaser()
        {
            btnHelp.Visible = false;
            Values.LaserA.CloseLaser();

            if (_laserDelegatesOpen)
            {
                Values.LaserA.LaserEnded -= LaserA_LaserEnded;
                Values.LaserA.LaserStarted -= LaserA_LaserStarted;
                Values.LaserA.LaserError -= LaserA_LaserError;
                Values.LaserA.InvalidStringFound -= LaserA_InvalidStringFound;
                Values.LaserA.DataReceived -= LaserA_DataReceived;
                _laserDelegatesOpen = false;
            }
        }

        private void getPortSelection(string portChoice)
        {
            if (portChoice != "Other")
            {
                Values.Settings.DeviceOptions.LaserComPort = portChoice;
#if (PocketPC || WindowsCE || Mobile)
                btnLaserPort.Text = portChoice;
#endif
                cboLaserPort.Text = portChoice;

                if (Values.Settings.DeviceOptions.LaserComPort.ToLower() == "file")
                {
                    MessageBox.Show("Laser data must come from COM Port.");
                    Values.Settings.DeviceOptions.LaserComPort = (string)cboLaserPort.Items[1];

                    /*
                    using (OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
                    {
                        ofd.Filter = "Text Files|*.txt|All Files|*.*";

                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            Values.Settings.DeviceOptions.LaserComPort = ofd.FileName;
                        }
                    }
                    */
                }
            }
            else
            {
                lblValue.Text = "Port: COM";
                getPort = true;
                txtPortValue.Text = "";
                txtPortValue.Visible = true;
                txtBaudValue.Visible = false;
                pnlOtherChoice.Visible = true;
            }
#if !(PocketPC || WindowsCE || Mobile)
            toolTip1.SetToolTip(cboLaserPort, Values.Settings.DeviceOptions.LaserComPort);
#endif
        }

        private void getBaudSelection(string baudChoice)
        {
            if (baudChoice != "Other")
            {
                Values.Settings.DeviceOptions.LaserBaud = Convert.ToInt32(baudChoice);
#if (PocketPC || WindowsCE || Mobile)
                btnLaserBaud.Text = baudChoice;
#endif
                cboLaserBaud.Text = baudChoice;
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
            toolTip1.SetToolTip(cboLaserBaud, Values.Settings.DeviceOptions.LaserBaud.ToString());
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

                    atPos = cboLaserPort.Items.IndexOf(portText);

                    if (atPos < 0)
                    {
                        cboLaserPort.Items.Add(portText);
                    }

                    cboLaserPort.Text = portText;
#if (PocketPC || WindowsCE || Mobile)
                    btnLaserPort.Text = portText;
#endif
                    Values.Settings.DeviceOptions.LaserComPort = portText;


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

                    atPos = cboLaserPort.Items.IndexOf(tmp);

                    if (atPos < 0)
                    {
                        cboLaserPort.Items.Add(tmp);
                    }

                    cboLaserBaud.Text = tmp.ToString();
#if (PocketPC || WindowsCE || Mobile)
                    btnLaserBaud.Text = tmp.ToString();
#endif
                    Values.Settings.DeviceOptions.LaserBaud = tmp;


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

        private void btnHelp_Click2(object sender, EventArgs e)
        {
            MessageBox.Show(errMsg);
        }


        #region Laser


        private void LaserA_DataReceived(LaserData data)
        {
            this.GuiInvoke(() =>
                {
                    txtLaserOutput.Text = "Laser received- " + data.ToString();
                    System.Threading.Thread.Sleep(1000);
                    txtLaserOutput.Text = "Laser Successful";
                    CloseLaser();
                });

            AutoClosingMessageBox.Show("Laser Configured", "Laser Configuration", 1000);
        }

        private void LaserA_InvalidStringFound()
        {
            this.GuiInvoke(() =>
                {
                    if (invalidDataCount < 5)
                    {
                        txtLaserOutput.Text = "Laser receiving invalid data.";
                    }
                    else
                    {
                        txtLaserOutput.Text = "Laser invalid data timeout.";
                        CloseLaser();

                        btnHelp.Visible = true;
                    }

                    invalidDataCount++;
                    errMsg = "Laser invalid data timeout. The Laser recieved only invalid data for too long. Check if the Laser is using the right COM port and see if the device is working properly.";
                });
        }

        private void LaserA_LaserStarted()
        {

        }

        private void LaserA_LaserEnded()
        {

        }

        private void LaserA_LaserError()
        {
            this.GuiInvoke(() =>
                {
                    string error = null;

                    switch (Values.LaserA.Error)
                    {
                        case LaserAccess.LaserErrorType.ComNotExist:
                            error = Values.Settings.DeviceOptions.LaserComPort + " does not exist.";
                            errMsg = Values.Settings.DeviceOptions.LaserComPort + " does not exist. Try using a different COM port.";
                            break;
                        case LaserAccess.LaserErrorType.LaserTimeout:
                            error = "The Laser timed out.";
                            errMsg = "The Laser timed out. Try using a different Baud.";
                            break;
                        case LaserAccess.LaserErrorType.NoError:
                            errMsg = "No Error occured.";
                            break;
                        case LaserAccess.LaserErrorType.UnknownError:
                        default:
                            error = "Unknown Error.";
                            errMsg = "An unknown error occured. View ErrorLog.txt for details.";
                            break;
                    }

                    if (error != null)
                    {
                        txtLaserOutput.Text = error;
                        btnHelp.Visible = true;

                        MessageBox.Show(errMsg);
                    }
                });
        }

        #endregion
    }
}
