using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.GpsAccess;
using TwoTrails.Engine;
using TwoTrails.Utilities;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;
namespace TwoTrails.Forms
{
    public partial class AcquireGpsForm : Form
    {
        private int logged, recieved, currentZone;
        private bool bLogBtn;
        private bool logging;
        private bool _data, calculated, _init;
        private int pointName;
        private string pointCN;
        private GpsPoint _Point;
        List<NmeaBurst> NmeaData;
        private DataAccessLayer DAL;

        public void Init(TtPoint p, int currentZone, DataAccessLayer dal)
        {
            Values.GPSA.BurstReceived += GPSA_BurstReceived;
            Values.GPSA.InvalidStringFound += GPSA_InvalidStringFound;
            Values.GPSA.ComTimeout += GPSA_ComTimeout;
            Values.GPSA.GpsStarted += GPSA_GpsStarted;
            Values.GPSA.GpsEnded += GPSA_GpsEnded;
            Values.GPSA.GpsError += GPSA_GpsError;
            _init = true;

            this.currentZone = currentZone;

            pointName = p.PID;
            this.Text = "Point: " + pointName;
            pointCN = p.CN;

            DAL = dal;

            logged = 0;
            recieved = 0;
            logging = bLogBtn = _data = calculated = false;

            NmeaData = new List<NmeaBurst>();
        }

        private void AcquireGpsForm_Load2(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;

#if !(PocketPC || WindowsCE || Mobile)
            using (DeviceSetupForm dsf = new DeviceSetupForm())
            {
                dsf.ShowDialog();
            }
#endif

            if (!Values.GPSA.IsBusy)
            {
                Values.GPSA.OpenGps(Values.Settings.DeviceOptions.GpsComPort, Values.Settings.DeviceOptions.GpsBaud);
            }

            gpsInfoAdvCtrl.SetZone(currentZone);
            gpsInfoAdvCtrl.StartControl();
        }

        public void CloseForm()
        {
            Dispose();
        }

        public new void Dispose()
        {
            if (_init)
            {
                try
                {
                    gpsInfoAdvCtrl.StopControl();

                    Values.GPSA.BurstReceived -= GPSA_BurstReceived;
                    Values.GPSA.InvalidStringFound -= GPSA_InvalidStringFound;
                    Values.GPSA.ComTimeout -= GPSA_ComTimeout;
                    Values.GPSA.GpsStarted -= GPSA_GpsStarted;
                    Values.GPSA.GpsEnded -= GPSA_GpsEnded;
                    Values.GPSA.GpsError -= GPSA_GpsError;
                    _init = false;

                    if (!Values.Settings.DeviceOptions.KeepGpsOn)
                    {
                        if (Values.GPSA.IsBusy)
                        {
                            Values.GPSA.CloseGps();
                        }
                    }

                    //base.Dispose();
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "AcquireGpsFormLogic:CloseForm");
                }
            }
        }

        #region GPS Functions

        private void GPSA_BurstReceived(NmeaBurst b)
        {
            if (logging)
            {
                logged++;
                NmeaData.Add(b);
            }
            recieved++;

            this.GuiInvoke(() =>
                {
                    lblRecieved.Text = recieved.ToString();
                    lblLogged.Text = logged.ToString();
                });
        }

        private void GPSA_InvalidStringFound()
        {
            GPSA_GpsError();
        }

        private void GPSA_ComTimeout()
        {
            Values.GPSA.CloseGps();
            GPSA_GpsError();
        }

        private void GPSA_GpsStarted()
        {

        }

        private void GPSA_GpsEnded()
        {

        }

        private void GPSA_GpsError()
        {

            switch (Values.GPSA.Error)
            {
                case GpsAccess.GpsErrorType.ComNotExist:
                    break;
                case GpsAccess.GpsErrorType.GpsTimeout:
                    break;
                case GpsAccess.GpsErrorType.NoError:
                    break;
                case GpsAccess.GpsErrorType.UnknownError:
                default:
                    break;
            }

        }

        #endregion

        public void AddToNmea(List<NmeaBurst> moreBursts)
        {
            NmeaData.AddRange(moreBursts);
            gpsInfoAdvCtrl.AddToRange(moreBursts);
        }

        #region Controls

        private void btnLog_Click2(object sender, EventArgs e)
        {
            if (!bLogBtn)
            {
                logging = bLogBtn = true;
                gpsInfoAdvCtrl.UtmRange = true;
                btnLog.Text = "Stop";
                btnOk.Enabled = calculated = _data = false;
            }
            else
            {
                logging = bLogBtn = false;
                gpsInfoAdvCtrl.UtmRange = false;
                btnLog.Text = "Log GPS";
                btnOk.Enabled = _data = true;
            }
        }

        private void btnOk_Click2(object sender, EventArgs e)
        {
            if (_data)
            {
                try
                {
                    using (CalcGpsPointForm form = new CalcGpsPointForm(NmeaData, pointName, pointCN, DAL, currentZone, false))
                    {
                        form.ShowDialog();

                        if (form.IsCalaculated && !form.Canceled)
                        {
                            calculated = true;
                            _Point = (GpsPoint)TtUtils.CopyPoint(form._GpsPoint);

                            this.Close();
                        }
                        else
                        {
                            calculated = false;
                            //do nothing
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Calculate Point Form Error.");
                }
            }
            else
            {
                MessageBox.Show("No Gps points logged.");
            }
        }

        private void btnCancel_Click2(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel without calculating?", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #endregion

        public bool IsCalc
        {
            get { return calculated; }
        }

        public GpsPoint _GpsPoint
        {
            get
            {
                return _Point;
            }
        }
    }
}