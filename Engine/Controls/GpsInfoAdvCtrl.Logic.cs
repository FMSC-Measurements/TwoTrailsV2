using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;
using TwoTrails.GpsAccess;
using TwoTrails.Utilities;

namespace TwoTrails.Controls
{
    public partial class GpsInfoAdvCtrl : UserControl
    {
        public delegate void DelegateGotBurstB(NmeaBurst b);
        public DelegateGotBurstB m_DelegateGotBurst;

        private double UTMX, UTMY;
        private List<double> UtmRangeX;
        private List<double> UtmRangeY;
        bool RangeOn;
        int currZone;

        public void Init()
        {
            m_DelegateGotBurst = new DelegateGotBurstB(gpsReceivingData);

            UtmRangeX = new List<double>();
            UtmRangeY = new List<double>();

            UTMX = 0;
            UTMY = 0;

            RangeOn = false;
        }

        private void Display(NmeaBurst b)
        {
            if (RangeOn)
            {
                UtmRangeX.Add(b._X);
                UtmRangeY.Add(b._Y);
                CalculateUtmRange();
            }

            lblAlt.Text = b._altitude.ToString();

            if (b._magVar >= 0)
                lblDec.Text = "+" + b._magVar.ToString();
            else
                lblDec.Text = b._magVar.ToString();

            lblPdop.Text = b._PDOP.ToString();
            lblHdop.Text = b._HDOP.ToString();
            lblSat.Text = b._num_of_used_sat.ToString();

            if (b._fix_quality == 2)
                lblDiff.Text = "Yes";
            else
                lblDiff.Text = "No";

            lblUtmRangeX.Text = UTMX.ToString("F2").Truncate(6);
            lblUtmRangeY.Text = UTMY.ToString("F2").Truncate(6);

            lblLat.Text = b._latitude.ToString().Truncate(7);
            lblLon.Text = b._longitude.ToString().Truncate(7);

            lblUTMX.Text = b._X.ToString().Truncate(11);
            lblUTMY.Text = b._Y.ToString().Truncate(11);

            if (b._fix_quality > 0 && b._fix_quality < 4)
                lblGpsStatus.Text = "OK";
            else if (b._fix_quality == 8)
            {
                lblGpsStatus.Text = "Simulation";
            }
            else
                lblGpsStatus.Text = "No Fix";

            string gpsString = "";

            if (b._fix_quality != 3)
            {
                switch (b._fix)
                {
                    case 2:
                        gpsString = "GPS-2D";
                        break;
                    case 3:
                        gpsString = "GPS-3D";
                        break;
                    default:
                        gpsString = "GPS-UNKOWN";
                        break;
                }

                if (b._fix_quality == 2)
                    gpsString = gpsString + "-DIFF";

                lblGpsFix.Text = gpsString;
            }
            else
            {
                lblGpsFix.Text = "GPS-PPS";
            }
        }

        public void AddToRange(List<NmeaBurst> bursts)
        {
            foreach (NmeaBurst b in bursts)
            {
                UtmRangeX.Add(b._X);
                UtmRangeY.Add(b._Y);
            }

            CalculateUtmRange();
        }

        private void CalculateUtmRange()
        {
            UTMX = 0;
            UTMY = 0;

            double min, max;

            if (UtmRangeX.Count > 0)
            {
                min = UtmRangeX[0];
                max = UtmRangeX[0];

                foreach (double d in UtmRangeX)
                {
                    if (min > d)
                        min = d;
                    if (max < d)
                        max = d;
                }

                UTMX = max - min;
            }

            if (UtmRangeY.Count > 0)
            {
                min = UtmRangeY[0];
                max = UtmRangeY[0];

                foreach (double d in UtmRangeY)
                {
                    if (min > d)
                        min = d;
                    if (max < d)
                        max = d;
                }

                UTMY = max - min;
            }
        }

        public void ClearUtmRange()
        {
            UtmRangeX.Clear();
            UtmRangeY.Clear();

            UTMX = 0;
            UTMY = 0;
        }

        public void Reset()
        {
            ClearUtmRange();

            lblAlt.Text = "0000.00";
            lblDec.Text = "+00.0";

            lblPdop.Text = "0.0";
            lblHdop.Text = "0.0";
            lblSat.Text = "00";
            lblDiff.Text = "0000";

            lblUtmRangeX.Text = "0.0";
            lblUtmRangeY.Text = "0.0";

            lblLat.Text = "000.000";
            lblLon.Text = "000.000";
            lblUTMX.Text = "0000000.00";
            lblUTMY.Text = "0000000.00";

            lblGpsStatus.Text = "XX";
            lblGpsFix.Text = "XXX-XX-XXXX";
        }

        private void gpsReceivingData(NmeaBurst b)
        {
            Display(b);
        }

        private void GPSA_BurstReceived(TwoTrails.GpsAccess.NmeaBurst b)
        {
            b.CalcZone(currZone);

            this.GuiInvoke(() =>
            {
                if (this.Parent.Visible)
                    this.Invoke(m_DelegateGotBurst, b);
            });
        }

        public void StartControl()
        {
            Values.GPSA.BurstReceived += new GpsAccess.DelegateDeliverBurst(GPSA_BurstReceived);
        }

        void GPSA_ValidStringReceived(string GpsString)
        {
            TtUtils.WriteEvent(GpsString, "GIAC:ValidString");
        }

        public void StopControl()
        {
            Values.GPSA.BurstReceived -= new GpsAccess.DelegateDeliverBurst(GPSA_BurstReceived);
        }

        public bool UtmRange
        {
            set { RangeOn = value; }
            get { return RangeOn; }
        }

        public void SetZone(int zone)
        {
            currZone = zone;
        }
    }
}
