using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.Engine;
using TwoTrails.GpsAccess;
using TwoTrails.Utilities;
using TwoTrails.BusinessObjects;
using TwoTrails.Controls;

namespace TwoTrails.Forms
{
    public partial class WhereIsForm : Form
    {
        private const int TIMER_INTERVAL = 1;    //seconds; how often bursts come from gps 

        //Nav
        TwoTrails.Controls.NavCtrl navCtrl;

        DataAccessLayer DAL;
        bool pointsAvail;

        List<TtPolygon> _Polygons;
        List<string> _PolyNames;
        List<TtPoint> _FromPoints, _ToPoints;
        List<string> _FromPointNames, _ToPointNames;
        List<TtMetaData> _Meta;

        TtPolygon _FromPolygon, _ToPolygon;
        TtPoint _FromPoint, _ToPoint;
        TtMetaData _CurrMeta;
        bool UseMyPos, _init, _navigating;

        double _UtmYFrom, _UtmXFrom, _UtmYTo, _UtmXTo,_Alt, _MagDec;

        DoublePoint _LastPos;
        double fpm;

        public double MagDec
        {
            get { return _MagDec; }
            set
            {
                _MagDec = value;
            }
        }

        public double UtmYFrom
        {
            get { return _UtmYFrom; }
            set
            {
                _UtmYFrom = value;
            }
        }

        public double UtmXFrom
        {
            get { return _UtmXFrom; }
            set
            {
                _UtmXFrom = value;
            }
        }

        public double UtmYTo
        {
            get { return _UtmYTo; }
            set
            {
                _UtmYTo = value;
            }
        }

        public double UtmXTo
        {
            get { return _UtmXTo; }
            set
            {
                _UtmXTo = value;
            }
        }

        public double Altitude
        {
            get { return _Alt; }
            set
            {
                _Alt = value;
            }
        }


        public WhereIsForm(DataAccessLayer dal)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();
#else
            InitializeComponent();
#endif

            navCtrl = new NavCtrl();
            navCtrl.Location = new Point(0, 0);

#if (PocketPC || WindowsCE || Mobile)
            if (Values.WideScreen)
                navCtrl.Size = new Size(240, 183);
            else
                navCtrl.Size = new Size(240, 205);
#else
            navCtrl.Size = new Size(277, 252);
#endif

            navCtrl.BringToFront();
            navCtrl.Visible = false;
            navCtrl.TabStop = false;

            Controls.Add(navCtrl);

            DAL = dal;
            Init();
        }

        public void Init()
        {
            this.Icon = Properties.Resources.Map;
            _init = false;

            _Polygons = new List<TtPolygon>();
            _FromPoints = new List<TtPoint>();
            _ToPoints = new List<TtPoint>();
            _PolyNames = new List<string>();
            _FromPointNames = new List<string>();
            _ToPointNames = new List<string>();
            _Meta = new List<TtMetaData>();

            pointsAvail = false;

            _FromPoint = null;
            _ToPoint = null;
            _FromPolygon = null;
            _ToPolygon = null;
            _CurrMeta = null;

            _navigating = false;

            if (DAL != null)
            {
                _Polygons = DAL.GetPolygons();

                _Meta = DAL.GetMetaData();

                if (_Meta.Count > 0)
                {
                    foreach (TtMetaData m in _Meta)
                    {
                        cboMeta.Items.Add(m.Name);
                    }

                    _CurrMeta = _Meta[0];
#if (PocketPC || WindowsCE || Mobile)
                    btnMeta.Text = _CurrMeta.Name;
#endif
                    cboMeta.SelectedIndex = 0;
                }

                if (_Polygons.Count > 0)
                {
                    foreach (TtPolygon poly in _Polygons)
                    {
                        if (DAL.GetPointCount(poly.CN) > 0)
                            pointsAvail = true;
                    }
                }
            }
            else
            {
#if (PocketPC || WindowsCE || Mobile)
                btnMeta.Enabled = false;
#endif
                cboMeta.Enabled = false;
                _CurrMeta = Values.Settings.ReadMetaSettings();

                if (_CurrMeta == null)
                {
                    _CurrMeta = new TtMetaData()
                    {
                        CN = Guid.Empty.ToString(),
                        Name = "DefaultMeta",
                        magDec = 0,
                        decType = DeclinationType.MagDec,
                        Zone = 13,
                        uomSlope = UomSlope.Percent,
                        uomElevation = UomElevation.Feet,
                        uomDistance = UomDistance.FeetTenths,
                        datum = Datum.NAD83
                    };
                }
            }

            UseMyPos = false;

            #region Setup Controls
            if (Values.Settings.DeviceOptions.UseSelection)
            {
                cboFromPoint.Visible = false;
                cboFromPoly.Visible = false;
                cboToPoint.Visible = false;
                cboToPoly.Visible = false;
                cboMeta.Visible = false;

#if (PocketPC || WindowsCE || Mobile)
                btnToPoint.Visible = true;
                btnToPoly.Visible = true;
                btnFromPoint.Visible = true;
                btnFromPoly.Visible = true;
                btnMeta.Visible = true;

                btnToPoint.Enabled = true;
                btnToPoly.Enabled = true;
                btnFromPoint.Enabled = true;
                btnFromPoly.Enabled = true;
#endif
                cboFromPoint.Enabled = false;
                cboFromPoly.Enabled = false;
                cboToPoint.Enabled = false;
                cboToPoly.Enabled = false;
            }
            else
            {
                cboFromPoint.Visible = true;
                cboFromPoly.Visible = true;
                cboToPoint.Visible = true;
                cboToPoly.Visible = true;
                cboMeta.Visible = true;

#if (PocketPC || WindowsCE || Mobile)
                btnToPoint.Visible = false;
                btnToPoly.Visible = false;
                btnFromPoint.Visible = false;
                btnFromPoly.Visible = false;
                btnMeta.Visible = false;

                btnToPoint.Enabled = false;
                btnToPoly.Enabled = false;
                btnFromPoint.Enabled = false;
                btnFromPoly.Enabled = false;
#endif
                cboFromPoint.Enabled = true;
                cboFromPoly.Enabled = true;
                cboToPoint.Enabled = true;
                cboToPoly.Enabled = true;
            }

            txtFromX.Enabled = false;
            txtFromY.Enabled = false;
            txtToX.Enabled = false;
            txtToY.Enabled = false;

            if (pointsAvail == true)
            {
                foreach (TtPolygon poly in _Polygons)
                {
                    cboFromPoly.Items.Add(poly.Name);
                    cboToPoly.Items.Add(poly.Name);
                    _PolyNames.Add(poly.Name);
                }

                cboFromPoly.SelectedIndex = 0;
                cboToPoly.SelectedIndex = 0;
                //ChangeFromPoly(0);
                //ChangeToPoly(0);
            }
            else
            {
                radToPoint.Enabled = false;
                radFromPoint.Enabled = false;

                txtFromX.Enabled = true;
                txtFromY.Enabled = true;
                txtToX.Enabled = true;
                txtToY.Enabled = true;

                radFromUTM.Checked = true;
                radToUTM.Checked = true;
            }
            #endregion
        }


        private void ChangeFromPoly(int index)
        {
            if(index < 0 || index > _Polygons.Count -1)
                return;

            if (_FromPolygon != _Polygons[index])
            {
                _FromPolygon = _Polygons[index];
#if (PocketPC || WindowsCE || Mobile)
                btnFromPoly.Text = _FromPolygon.Name;
#endif

                cboFromPoint.Items.Clear();
                _FromPointNames.Clear();

                _FromPoints = DAL.GetPointsInPolygon(_FromPolygon.CN);

                if (_FromPoints.Count == 0)
                {
                    _FromPoint = new GpsPoint(0, 0, 0);
                    txtFromX.Text = String.Empty;
                    txtFromY.Text = String.Empty;
                    cboFromPoint.Text = String.Empty;
                }
                else
                {
                    foreach (TtPoint p in _FromPoints)
                    {
                        cboFromPoint.Items.Add(p.PID);
                        _FromPointNames.Add(p.PID.ToString());
                    }

                    cboFromPoint.SelectedIndex = 0;
                }
            }
        }

        private void ChangeToPoly(int index)
        {
            if (index < 0 || index > _Polygons.Count - 1)
                return;

            if (_ToPolygon != _Polygons[index])
            {
                _ToPolygon = _Polygons[index];
#if (PocketPC || WindowsCE || Mobile)
                btnToPoly.Text = _ToPolygon.Name;
#endif

                cboToPoint.Items.Clear();
                _ToPointNames.Clear();

                _ToPoints = DAL.GetPointsInPolygon(_ToPolygon.CN);

                if (_ToPoints.Count == 0)
                {
                    _ToPoint = new GpsPoint(0, 0, 0);
                    txtToX.Text = String.Empty;
                    txtToY.Text = String.Empty;
                    cboToPoint.Text = String.Empty;
                }
                else
                {
                    foreach (TtPoint p in _ToPoints)
                    {
                        cboToPoint.Items.Add(p.PID);
                        _ToPointNames.Add(p.PID.ToString());
                    }

                    cboToPoint.SelectedIndex = 0;
                }
            }
        }


        private void ChangeToPoint(int index)
        {
            if (index < 0 || index > _ToPoints.Count - 1)
            {
                _ToPoint = null;
#if (PocketPC || WindowsCE || Mobile)
                btnToPoint.Text = "";
#endif
                txtToX.Text = "";
                txtToY.Text = "";
            }
            else
            {
                _ToPoint = _ToPoints[index];
#if (PocketPC || WindowsCE || Mobile)
                btnToPoint.Text = _ToPoint.PID.ToString();
#endif

                UtmYTo = _ToPoint.UnAdjY;
                UtmXTo = _ToPoint.UnAdjX;

                txtToX.Text = UtmXTo.ToString("F5").Truncate(12);
                txtToY.Text = UtmYTo.ToString("F5").Truncate(12);
            }
        }

        private void ChangeFromPoint(int index)
        {
            if (index < 0 || index > _FromPoints.Count - 1)
            {
                _FromPoint = null;
#if (PocketPC || WindowsCE || Mobile)
                btnFromPoint.Text = "";
#endif
            }
            else
            {
                _FromPoint = _FromPoints[index];
#if (PocketPC || WindowsCE || Mobile)
                btnFromPoint.Text = _FromPoint.PID.ToString();
#endif
            }

            UtmYFrom = _FromPoint.UnAdjY;
            UtmXFrom = _FromPoint.UnAdjX;

            txtFromX.Text = UtmXFrom.ToString("F5").Truncate(12);
            txtFromY.Text = UtmYFrom.ToString("F5").Truncate(12);
        }


        private void ChangeMeta(int index)
        {
            if (_Meta.Count > 0 && index > -1 && index < _Meta.Count)
            {
                _CurrMeta = _Meta[index];
#if (PocketPC || WindowsCE || Mobile)
                btnMeta.Text = _CurrMeta.Name;
#endif
            }
        }



        private void Calculate()
        {
            DoublePoint from, to;
            double az = 0, azMag = 0, dist;

            if (_FromPoint != null && !_navigating)
            {
                _UtmYFrom = _FromPoint.UnAdjY;
                _UtmXFrom = _FromPoint.UnAdjX;

                from = new DoublePoint(_UtmXFrom, _UtmYFrom);
            }
            else
            {
                from = new DoublePoint(_UtmXFrom, _UtmYFrom);
            }

            if (_ToPoint != null)
            {
                _UtmYTo = _ToPoint.UnAdjY;
                _UtmXTo = _ToPoint.UnAdjX;

                to = new DoublePoint(_UtmXTo, _UtmYTo);
            }
            else
            {
                to = new DoublePoint(_UtmXTo, _UtmYTo);
            }

            az = TtUtils.AzimuthOfPoint(from, to);

            azMag = az - ((_CurrMeta != null)?(_CurrMeta.magDec):(0));

            dist = (_CurrMeta == null) ? (TtUtils.Distance(from, to)) : (TtUtils.ConvertDistance(TtUtils.Distance(from, to), _CurrMeta.uomDistance, UomDistance.Meters));

            txtAzMag.Text = azMag.ToString("F2").Truncate(6);
            txtAzTrue.Text = az.ToString("F2").Truncate(6);

            string abv = String.Empty;
            switch (_CurrMeta.uomDistance)
            {
                case UomDistance.Chains:
                    abv = "C";
                    break;
                case UomDistance.FeetInches:
                    abv = "Ft";
                    break;
                case UomDistance.FeetTenths:
                    abv = "FtT";
                    break;
                case UomDistance.Meters:
                    abv = "M";
                    break;
                case UomDistance.Yards:
                    abv = "Y";
                    break;
            }

            txtDistance.Text = String.Format("{0} ({1})", dist.ToString("F2").Truncate(8), abv);

#if !(PocketPC || WindowsCE || Mobile)
            txtDistance2.Text = TtUtils.Distance(from, to).ToString("F2").Truncate(8);
#endif
            //WiNCtrl.Azimuth = az;
        }

        private void WhereIsForm_Load2(object sender, EventArgs e)
        {
            //StartGps();
        }

        private void WhereIsForm_Closing2(object sender, CancelEventArgs e)
        {
            StopGps();
            GC.Collect();
        }

        private double calculateFeetPerMin()
        {
            if (_LastPos.X == 0 && _LastPos.Y == 0)
                return 0;

            double dist = TtUtils.Distance(_LastPos.X, _LastPos.Y, _UtmXFrom, _UtmYFrom);

            dist = TtUtils.ConvertToFeetTenths(dist, Unit.METERS);

            double distPerMin = dist * (60 / TIMER_INTERVAL);

            return distPerMin;
        }


        #region Controls
        private void btnExit_Click2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNav_Click2(object sender, EventArgs e)
        {
            if (!_navigating)
            {
                if (!Values.Settings.DeviceOptions.GpsConfigured)
                {
                    using (DeviceSetupForm dsf = new DeviceSetupForm())
                    {
                        dsf.ShowDialog();

                        if (!Values.Settings.DeviceOptions.GpsConfigured)
                            return;
                    }
                }

                if (radFromPoint.Checked)
                {
                    if (_FromPoint == null)
                    {
                        AutoClosingMessageBox.Show("No From Point", "From Point Missing", 1000);
                        return;
                    }
                    else
                    {
                        if (radToPoint.Checked)
                        {
                            if (_ToPoint == null)
                            {
                                AutoClosingMessageBox.Show("No To Point", "To Point Missing", 1000);
                                return;
                            }
                            else
                            {
                                if (_ToPoint.CN == _FromPoint.CN)
                                {
                                    AutoClosingMessageBox.Show("You can not travel to the same point you come from.", "", 1000);
                                    return;
                                }
                                else
                                {
                                    navCtrl.Init(new DoublePoint(_FromPoint.AdjX, _FromPoint.AdjY),
                                        new DoublePoint(_ToPoint.AdjX, _ToPoint.AdjY));
                                }
                            
                            }
                        }
                        else
                        {
                            navCtrl.Init(new DoublePoint(_FromPoint.AdjX, _FromPoint.AdjY),
                                    new DoublePoint(_UtmXTo, _UtmYTo));
                        }
                    }
                }
                else
                {
                    if (radToPoint.Checked)
                    {
                        if (_ToPoint == null)
                        {
                            AutoClosingMessageBox.Show("No To Point", "To Point Missing", 1000);
                            return;
                        }
                        else
                        {
                            navCtrl.Init(new DoublePoint(_UtmXFrom, _UtmYFrom),
                                new DoublePoint(_ToPoint.AdjX, _ToPoint.AdjY));
                        }
                    }
                    else
                    {
                        navCtrl.Init(new DoublePoint(_UtmXFrom, _UtmYFrom),
                                new DoublePoint(_UtmXTo, _UtmYTo));
                    }
                }

                navCtrl.BringToFront();

                StartGps();

                btnNav.Text = "Stop";
                panel1.Visible = false;
                panel2.Visible = false;
                navCtrl.Visible = true;

                _navigating = true;
                _LastPos = new DoublePoint(0,0);
            }
            else
            {
                btnNav.Text = "Navigate";
                navCtrl.Visible = false;
                panel1.Visible = true;
                panel2.Visible = true;
                _navigating = false;

                if (!UseMyPos)
                {
                    StopGps();
                    if (radFromPoint.Checked)
                        ChangeFromPoint(cboFromPoint.SelectedIndex);
                }
            }
        }

        private void btnCalc_Click2(object sender, EventArgs e)
        {
            Calculate();
        }

        #region Point / Poly Controls
        private void radMyLoc_CheckedChanged2(object sender, EventArgs e)
        {
            if (radMyLoc.Checked)
            {
                UseMyPos = true;
                StartGps();
            }
            else
            {
                UseMyPos = false;
                StopGps();
            }
        }

        private void radFromUTM_CheckedChanged2(object sender, EventArgs e)
        {
            //
        }

        private void radFromPoint_CheckedChanged2(object sender, EventArgs e)
        {
            if (radFromPoint.Checked)
            {
                cboFromPoint.Enabled = true;
                cboFromPoly.Enabled = true;
#if (PocketPC || WindowsCE || Mobile)
                btnFromPoint.Enabled = true;
                btnFromPoly.Enabled = true;
#endif
                txtFromX.Enabled = false;
                txtFromY.Enabled = false;
                ChangeFromPoly(0);
            }
            else
            {
                cboFromPoint.Enabled = false;
                cboFromPoly.Enabled = false;
#if (PocketPC || WindowsCE || Mobile)
                btnFromPoint.Enabled = false;
                btnFromPoly.Enabled = false;
#endif
                txtFromX.Enabled = true;
                txtFromY.Enabled = true;
                _FromPoint = null;
            }
        }

        private void txtFromX_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                UtmXFrom = Convert.ToDouble(txtFromX.Text);
            }
            catch
            {

            }
        }

        private void txtFromY_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                UtmYFrom = Convert.ToDouble(txtFromY.Text);
            }
            catch
            {

            }
        }
#if (PocketPC || WindowsCE || Mobile)
        private void btnFromPoly_Click2(object sender, EventArgs e)
        {
            using (Selection form = new Selection("Choose Polygon", _PolyNames, cboFromPoly.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cboFromPoly.SelectedIndex = form.selection;
                }
            }
        }

        private void btnFromPoint_Click2(object sender, EventArgs e)
        {
            using (Selection form = new Selection("Choose Point", _ToPointNames, cboFromPoint.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                     cboFromPoint.SelectedIndex = form.selection;
                }
            }
        }
#endif
        private void cboFromPoly_SelectedIndexChanged2(object sender, EventArgs e)
        {
            ChangeFromPoly(cboFromPoly.SelectedIndex);
        }

        private void cboFromPoint_SelectedIndexChanged2(object sender, EventArgs e)
        {
            ChangeFromPoint(cboFromPoint.SelectedIndex);
        }

        private void radToUTM_CheckedChanged2(object sender, EventArgs e)
        {
            //
        }

        private void radToPoint_CheckedChanged2(object sender, EventArgs e)
        {
            if (radToPoint.Checked)
            {
                cboToPoint.Enabled = true;
                cboToPoly.Enabled = true;
#if (PocketPC || WindowsCE || Mobile)
                btnToPoint.Enabled = true;
                btnToPoly.Enabled = true;
#endif
                txtToY.Enabled = false;
                txtToX.Enabled = false;
                ChangeToPoly(0);
            }
            else
            {
                cboToPoint.Enabled = false;
                cboToPoly.Enabled = false;
#if (PocketPC || WindowsCE || Mobile)
                btnToPoint.Enabled = false;
                btnToPoly.Enabled = false;
#endif
                txtToY.Enabled = true;
                txtToX.Enabled = true;
                _ToPoint = null;
            }
        }

        private void txtToX_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                UtmXTo = Convert.ToDouble(txtToX.Text);
            }
            catch
            {

            }
        }

        private void txtToY_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                UtmYTo = Convert.ToDouble(txtToY.Text);
            }
            catch
            {

            }
        }
#if (PocketPC || WindowsCE || Mobile)
        private void btnToPoly_Click2(object sender, EventArgs e)
        {
            using (Selection form = new Selection("Choose Polygon", _PolyNames, cboToPoly.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cboToPoly.SelectedIndex = form.selection;
                }
            }
        }

        private void btnToPoint_Click2(object sender, EventArgs e)
        {
            using (Selection form = new Selection("Choose Point", _ToPointNames, cboToPoint.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cboToPoint.SelectedIndex = form.selection;
                }
            }
        }
#endif
        private void cboToPoly_SelectedIndexChanged2(object sender, EventArgs e)
        {
            ChangeToPoly(cboToPoly.SelectedIndex);
        }

        private void cboToPoint_SelectedIndexChanged2(object sender, EventArgs e)
        {
            ChangeToPoint(cboToPoint.SelectedIndex);
        }

        private void cboMeta_SelectedIndexChanged2(object sender, EventArgs e)
        {
            ChangeMeta(cboMeta.SelectedIndex);
        }
    #if (PocketPC || WindowsCE || Mobile)
        private void btnMeta_Click2(object sender, EventArgs e)
        {
            List<string> items = new List<string>();

            foreach (TtMetaData m in _Meta)
            {
                items.Add(m.Name);
            }

            using (Selection form = new Selection("Choose MetaData", items, cboMeta.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cboMeta.SelectedIndex = form.selection;
                }
            }
        }
#endif
        private void txtFromX_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtFromX);
        }

        private void txtFromY_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtFromY);
        }

        private void txtToX_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtToX);
        }

        private void txtToY_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtToY);
        }
        #endregion
        #endregion


        #region GPS Functions

        private void StartGps()
        {
            if (!_init)
            {
                if (!Values.Settings.DeviceOptions.GpsConfigured)
                {
                    DialogResult dr = MessageBox.Show("GPS is not currently configured. Would you like to configure now?", "Configure GPS", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                    {
                        using (DeviceSetupForm form = new DeviceSetupForm())
                        {
                            form.ShowDialog();
                            if (!Values.Settings.DeviceOptions.GpsConfigured)
                                return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                try
                {
                    Values.GPSA.BurstReceived += GPSA_BurstReceived;
                    /*
                    Values.GPSA.InvalidStringFound += GPSA_InvalidStringFound;
                    Values.GPSA.ComTimeout += GPSA_ComTimeout;
                    Values.GPSA.GpsStarted += GPSA_GpsStarted;
                    Values.GPSA.GpsEnded += GPSA_GpsEnded;
                    Values.GPSA.GpsError += GPSA_GpsError;
                    */
                    _init = true;

                    if (!Values.GPSA.IsBusy)
                    {
                        Values.GPSA.OpenGps(Values.Settings.DeviceOptions.GpsComPort, Values.Settings.DeviceOptions.GpsBaud);
                    }
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "WhereIsForm:StartGps", ex.StackTrace);
                }
            }
        }

        private void StopGps()
        {
            if (_init)
            {
                try
                {
                    Values.GPSA.BurstReceived -= GPSA_BurstReceived;
                    /*
                    Values.GPSA.InvalidStringFound -= GPSA_InvalidStringFound;
                    Values.GPSA.ComTimeout -= GPSA_ComTimeout;
                    Values.GPSA.GpsStarted -= GPSA_GpsStarted;
                    Values.GPSA.GpsEnded -= GPSA_GpsEnded;
                    Values.GPSA.GpsError -= GPSA_GpsError;
                    */
                    _init = false;

                    if (!Values.Settings.DeviceOptions.KeepGpsOn)
                    {
                        if (Values.GPSA.IsBusy)
                        {
                            Values.GPSA.CloseGps();
                        }
                    }
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "WhereIsForm:StopGps", ex.StackTrace);
                }
            }
        }


        private void GPSA_BurstReceived(NmeaBurst b)
        {
            if (UseMyPos || _init)
            {
                double x = 0, y = 0;

                if (b._longDir == EastWest.West)
                    x = b._longitude * -1;
                else
                    x = b._longitude;

                if (b._latDir == NorthSouth.South)
                    y = b._latitude * -1;
                else
                    y = b._latitude;

                TtUtils.LatLontoUTM(y, x, _CurrMeta.Zone, out _UtmYFrom, out _UtmXFrom);

                this.GuiInvoke(() =>
                    {
                        txtFromX.Text = UtmXFrom.ToString("F5").Truncate(12);
                        txtFromY.Text = UtmYFrom.ToString("F5").Truncate(12);
                    });

                Altitude = TtUtils.ConvertDistance(b._altitude, UomDistance.FeetTenths, TtUtils.UnitToUomDistance(b._alt_unit));
                MagDec = b._magVar;

                this.GuiInvoke(() =>
                    {
                        Calculate();
                    });

                if (_navigating)
                {
                    fpm = calculateFeetPerMin();

                    this.GuiInvoke(() =>
                        {
                            navCtrl.UpdateLocation(new DoublePoint(_UtmXFrom, _UtmYFrom));
                            navCtrl.FeetPerMin = fpm;
                        });
                }

                _LastPos = new DoublePoint(UtmXFrom, UtmYFrom);
            }
        }

        /*
        private void GPSA_InvalidStringFound()
        {
            GPSA_GpsError();
        }

        private void GPSA_ComTimeout()
        {
            Values.GPSA.CloseGps();
            GPSA_GpsError();
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

        private void GPSA_GpsStarted()
        {

        }

        private void GPSA_GpsEnded()
        {

        }
        */
        #endregion
    }
}