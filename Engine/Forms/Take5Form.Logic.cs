using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;
using TwoTrails.GpsAccess;
using TwoTrails.DataAccess;
using TwoTrails.Utilities;
using TwoTrails.BusinessObjects;
using TwoTrails.BusinessLogic;

namespace TwoTrails.Forms
{
    public partial class Take5Form : Form
    {
        #region Variables

        private const double RMSE95_COEF = 1.7308;
        private bool logging, _locked, checkMeta, _isInsert;
        private int logged, _index, currentZone;

        private DataAccessLayer DAL;

        TtGroup T5Group;

        TtMetaData CurrMeta;
        Take5Point CurrentPoint;
        TtPoint LastPoint;
        List<NmeaBurst> CurrentNmea;
        List<NmeaBurst> LastNmea;
        List<TtPoint> _AdjustInsertPoints;
        TtPolygon Polygon;
        private bool OnBound, takingSideshot = false, lastPointSaved = false;
        private int ignore;

        #endregion

        public void Init(TtPolygon poly, DataAccessLayer dal, TtMetaData meta, TtPoint currentPoint, int currIndex, bool isInsert)
        {
            this.Icon = Properties.Resources.Map;
            TtUtils.ShowWaitCursor();
#if (PocketPC || WindowsCE || Mobile)
            lblLabel.Text = "Take " + Values.Settings.DeviceOptions.Take5NmeaAmount.ToString();
#endif
            btnCapture.Text = "Take " + Values.Settings.DeviceOptions.Take5NmeaAmount.ToString();
            this.Text = "Take " + Values.Settings.DeviceOptions.Take5NmeaAmount.ToString() + " Point Capture";

            Values.GPSA.BurstReceived += GPSA_BurstReceived;
            Values.GPSA.InvalidStringFound += GPSA_InvalidStringFound;
            Values.GPSA.ComTimeout += GPSA_ComTimeout;
            Values.GPSA.GpsStarted += GPSA_GpsStarted;
            Values.GPSA.GpsEnded += GPSA_GpsEnded;
            Values.GPSA.GpsError += GPSA_GpsError;

            travInfoControl1.UseLaser = false;

            Polygon = poly;
            DAL = dal;
            CurrMeta = meta;

            logging = false;
            this.DialogResult = DialogResult.Cancel;
            OnBound = true;
            _index = 0;
            ignore = 0;

            progCapture.Value = 0;
            progCapture.Minimum = 0;
            progCapture.Maximum = Values.Settings.DeviceOptions.Take5NmeaAmount;

            logged = 0;
            _locked = true;

            CurrentNmea = new List<NmeaBurst>();
            LastNmea = new List<NmeaBurst>();
            CurrentPoint = null;

            _index = currIndex;
            LastPoint = currentPoint;

            _isInsert = isInsert;

            gpsInfoAdvCtrl.SetZone(CurrMeta.Zone);
            gpsInfoAdvCtrl.StartControl();

            if (Values.GPSA.UsesFile && Values.Settings.DeviceOptions.GetGpsOnStart)
            {
                using (DeviceSetupForm dsf = new DeviceSetupForm())
                {
                    dsf.ShowDialog();
                }
            }

            if(!Values.GPSA.IsBusy)
                Values.GPSA.OpenGps(Values.Settings.DeviceOptions.GpsComPort, Values.Settings.DeviceOptions.GpsBaud);
            TtUtils.HideWaitCursor();

            if (dal.GetPointCount(poly.CN) < 1)
            {
                checkMeta = true;
            }

            if (isInsert)
            {
                _AdjustInsertPoints = dal.GetPointsInPolygon(poly.CN).Where(p => p.Index >= currIndex).ToList();
            }
        }

        public void CloseForm()
        {
            gpsInfoAdvCtrl.StopControl();

            Values.GPSA.BurstReceived -= GPSA_BurstReceived;
            Values.GPSA.InvalidStringFound -= GPSA_InvalidStringFound;
            Values.GPSA.ComTimeout -= GPSA_ComTimeout;
            Values.GPSA.GpsStarted -= GPSA_GpsStarted;
            Values.GPSA.GpsEnded -= GPSA_GpsEnded;
            Values.GPSA.GpsError -= GPSA_GpsError;

            if (!Values.Settings.DeviceOptions.KeepGpsOn)
            {
                if (Values.GPSA.IsBusy)
                {
                    Values.GPSA.CloseGps();
                }
            }
        }

        private void SaveLastPoint(TtPoint point)
        {
            if (point != null)
            {
                if (TtUtils.PointHasValue(point) || !Values.Settings.ProjectOptions.DropZero)
                {
                    TtUtils.ShowWaitCursor();

                    if (T5Group == null)
                    {
                        T5Group = new TtGroup();
                        T5Group.Name = String.Format("Take5_{0}", T5Group.CN.Truncate(8));
                        T5Group.GroupType = GroupType.Take5;

                        DAL.InsertGroup(T5Group);
                    }

                    point.GroupCN = T5Group.CN;
                    point.GroupName = T5Group.Name;

                    point = TtUtils.SaveConversion(point, CurrMeta);

                    if (_isInsert)
                    {
                        long index = point.Index;
                        foreach (TtPoint p in _AdjustInsertPoints)
                            p.Index = ++index;

                        DAL.SavePoints(_AdjustInsertPoints);
                    }

                    DAL.InsertPoint(point);
                    DAL.SaveNmeaBursts(LastNmea, point.CN);
                    TtUtils.HideWaitCursor();
                    LastPoint = point;
                }
            }
        }

        private void CreateNewTake5Point()
        {
            if (CurrentNmea.Count >= Values.Settings.DeviceOptions.Take5NmeaAmount)
            {
                double x = 0, y = 0, z = 0;
                int count = 0;

                //moved to capture
                /*
                if (!lastPointSaved)
                {
                    SaveLastPoint(CurrentPoint);
                    lastPointSaved = true;
                }
                */

                if (SetupPoint())
                {
                    NmeaBurst tmpBurst;

                    try
                    {
                        for (int i = 0; i < CurrentNmea.Count; i++)
                        {
                            if (CurrentNmea[i]._Used)
                            {
                                tmpBurst = CurrentNmea[i];

                                x += tmpBurst._X;
                                y += tmpBurst._Y;
                                z += tmpBurst._Z;
                                count++;
                            }
                        }

                        x /= count;
                        y /= count;
                        z /= count;

                        double dRMSEx = 0, dRMSEy = 0, dRMSEr = 0;

                        for (int i = 0; i < CurrentNmea.Count; i++)
                        {
                            tmpBurst = CurrentNmea[i];

                            if (tmpBurst._Used)
                            {
                                dRMSEx += Math.Pow(tmpBurst._X - x, 2);
                                dRMSEy += Math.Pow(tmpBurst._Y - y, 2);
                            }
                        }

                        dRMSEx = Math.Sqrt(dRMSEx / count);
                        dRMSEy = Math.Sqrt(dRMSEy / count);
                        dRMSEr = Math.Sqrt(Math.Pow(dRMSEx, 2) + Math.Pow(dRMSEy, 2));
                        dRMSEr *= RMSE95_COEF;

                        CurrentPoint.UnAdjX = x;
                        CurrentPoint.UnAdjY = y;
                        CurrentPoint.UnAdjZ = z;
                        //CurrentPoint.X = x;
                        //CurrentPoint.Y = y;
                        //CurrentPoint.Z = z;
                        CurrentPoint.RMSEr = (dRMSEr > Values.Settings.DeviceOptions.MIN_POINT_ACCURACY) ?
                            dRMSEr : Values.Settings.DeviceOptions.DEFAULT_POINT_ACCURACY;
                        CurrentPoint.Time = DateTime.Now;
                        CurrentPoint.MetaDefCN = CurrMeta.CN;

                        this.GuiInvoke(() =>
                            {
                                btnCapture.Enabled = true;
                                btnOk.Enabled = true;
                            });


                        LastNmea = CurrentNmea;
                        CurrentNmea = new List<NmeaBurst>();
                    }
                    catch (Exception ex)
                    {
                        TtUtils.WriteError(ex.Message, "Take5Form:CreateNewTake5Point", ex.StackTrace);
                    }
                }
                else
                {
                    //the currentpoint is null
                    //cancel create new point
                    btnCapture.Enabled = true;
                    TtUtils.WriteError("SetupPoint Failed, the CurentPoint is NULL", "Take5Form"); 
                }
            }
            else
            {
                //not right amount of nmea data
                btnCapture.Enabled = true;
                TtUtils.WriteError("CreateNewTake5Point Called without enough Nmea Data", "Take5Form"); 
            }
        }

        private bool SetupPoint()
        {
            CurrentPoint = new Take5Point();
            lastPointSaved = false;

            try
            {
                if(LastPoint != null)
                    CurrentPoint.PID = PointNaming.NamePoint(LastPoint, Polygon);
                else
                    CurrentPoint.PID = PointNaming.NameFirstPoint(Polygon);

                CurrentPoint.PolyCN = Polygon.CN;
                CurrentPoint.PolyName = Polygon.Name;
                CurrentPoint.OnBnd = OnBound;
                CurrentPoint.Index = _index;
                CurrentPoint.GroupCN = Values.MainGroup.CN;
                CurrentPoint.GroupName = Values.MainGroup.Name;
                _index++;
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "Take5Form:SetupPoint", ex.StackTrace);
                return false;
            }

            this.GuiInvoke(() => {
                txtPID.Text = CurrentPoint.PID.ToString();
                txtComment.Text = CurrentPoint.Comment;
            });

            return true;
        }


        #region Sideshot
        private bool SetupSideshot()
        {
            takingSideshot = true;

            if (!lastPointSaved)
            {
                SaveLastPoint(CurrentPoint);
                lastPointSaved = true;
            }

            btnCapture.Text = "Commit SS";

            SideShotPoint ss = new SideShotPoint();

            try
            {
                if (LastPoint != null)
                    ss.PID = PointNaming.NamePoint(LastPoint, Polygon);
                else
                    ss.PID = PointNaming.NameFirstPoint(Polygon);

                _index++;
                ss.PolyCN = Polygon.CN;
                ss.PolyName = Polygon.Name;
                ss.OnBnd = OnBound;
                ss.Index = _index;
                ss.GroupCN = Values.MainGroup.CN;
                ss.GroupName = Values.MainGroup.Name;
                ss.MetaDefCN = CurrMeta.CN;

                this.GuiInvoke(() =>
                {
                    txtPID.Text = ss.PID.ToString();
                    txtComment.Text = ss.Comment;
                });

                travInfoControl1.CurrentPoint = ss;
                pnlSideshot.Visible = true;

                return true;
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "Take5Form:SetupSideshot", ex.StackTrace);
            }

            return false;
        }

        private bool CancelSideshot()
        {
            CloseSideshot();
            return false;
        }

        private bool AddSideshot()
        {
            if (TtUtils.PointHasValue(travInfoControl1.CurrentPoint))
            {
                SaveLastPoint(travInfoControl1.CurrentPoint);
                lastPointSaved = true;
                CloseSideshot();
                return true;
            }
            else
            {
                if (travInfoControl1.CurrentPoint.ForwardAz == null &&
                    travInfoControl1.CurrentPoint.BackwardAz == null)
                {
                    MessageBox.Show("Point must have a Forward or Backward Azimuth.", "Sideshot Error");
                }
                else if (travInfoControl1.CurrentPoint.SlopeDistance <= 0)
                {
                    MessageBox.Show("Point's Distance must be greater than 0.", "Sideshot Error");
                }
                else
                {
                    MessageBox.Show("Sideshot Error", "Sideshot Error");
                }
            }

            return false;
        }

        private void CloseSideshot()
        {
            btnCapture.Text = "Take " + Values.Settings.DeviceOptions.Take5NmeaAmount.ToString();
            pnlSideshot.Visible = false;
            takingSideshot = false;
        }
        #endregion

        #region GPS Functions
        private void GPSA_BurstReceived(GpsAccess.NmeaBurst b)
        {
            if (checkMeta && b.IsValid)
            {
                if (b.CalcRealZone() != CurrMeta.Zone)
                {
                    MessageBox.Show("The current UTM zone does not match the set metadata zone.",
                        "Zone mismatch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

                checkMeta = false;
            }

            if (logging)
            {
                if (logged < Values.Settings.DeviceOptions.Take5NmeaAmount &&
                    (Values.Settings.DeviceOptions.IgnoreFirst ?
                        (Values.Settings.DeviceOptions.IgnoreFirstX - 1 < ignore) : true))
                {
                    b.CalcZone(CurrMeta.Zone);

                    if (TtUtils.FilterBurst(b, Values.Settings.DeviceOptions.Filter_T5_FixType,
                        Values.Settings.DeviceOptions.Filter_T5_DOP_TYPE,
                        Values.Settings.DeviceOptions.Filter_T5_DOP_VALUE))
                    {
                        b._Used = true;
                        logged++;
                    }
                    else
                    {
                        b._Used = false;
                    }

                    CurrentNmea.Add(b);

                    this.GuiInvoke(()=> { progCapture.Value = logged; });

                    if (logged == Values.Settings.DeviceOptions.Take5NmeaAmount)
                    {
                        logging = false;
                        gpsInfoAdvCtrl.UtmRange = false;
                        CreateNewTake5Point();
                    }

                    if (Values.Settings.DeviceOptions.Take5FailTrigger &&
                        CurrentNmea.Count == Values.Settings.DeviceOptions.Take5NmeaAmount +
                            Values.Settings.DeviceOptions.Take5FailTriggerAmount)
                    {
                        logging = false;
                        gpsInfoAdvCtrl.UtmRange = false;

                        foreach (NmeaBurst burst in CurrentNmea)
                        {
                            burst._Used = true;
                        }

                        CreateNewTake5Point();
                    }
                }
                else
                    ignore++;
            }
        }

        private void GPSA_InvalidStringFound()
        {

        }

        private void GPSA_ComTimeout()
        {

        }

        private void GPSA_GpsStarted()
        {

        }

        private void GPSA_GpsEnded()
        {

        }

        private void GPSA_GpsError()
        {

        }
        #endregion

        #region Controls

        private void btnOk_Click2(object sender, EventArgs e)
        {
            bool close = false;
            TtUtils.ShowWaitCursor();
            try
            {
                if (takingSideshot)
                {
                    if (TtUtils.PointHasValue(travInfoControl1.CurrentPoint))
                    {
                        SaveLastPoint(travInfoControl1.CurrentPoint);
                        lastPointSaved = true;
                        CloseSideshot();
                    }
                    else
                    {
                        if (travInfoControl1.CurrentPoint.ForwardAz == null &&
                            travInfoControl1.CurrentPoint.BackwardAz == null)
                        {
                            MessageBox.Show("Point must have a Forward or Backward Azimuth.", "Sideshot Error");
                        }
                        else if (travInfoControl1.CurrentPoint.SlopeDistance <= 0)
                        {
                            MessageBox.Show("Point's Distance must be greater than 0.", "Sideshot Error");
                        }
                        else
                        {
                            MessageBox.Show("Sideshot Error", "Sideshot Error");
                        }

                        return;
                    }
                }
                else
                {
                    if (CurrentPoint != null)
                    {
                        SaveLastPoint(CurrentPoint);
                    }
                }
                close = true;
            }
            catch (DataException daEx)
            {
                TtUtils.WriteError(daEx.Message, "Take5Form:btnOk(DataException)", daEx.StackTrace);
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "Take5Form:btnOk", ex.StackTrace);
            }

            if (close)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCapture_Click2(object sender, EventArgs e)
        {
            if (takingSideshot)
            {
                AddSideshot();
            }
            else
            {
                if (!logging)
                {
#if !(PocketPC || WindowsCE || Mobile)
                    if (Values.Settings.DeviceOptions.GetGpsOnStart)
                    {
                        using (DeviceSetupForm dsf = new DeviceSetupForm())
                        {
                            dsf.ShowDialog();
                        }
                    }

                    System.Threading.Thread.Sleep(1000);
                    if (!Values.GPSA.IsBusy)
                    {
                        Values.GPSA.OpenGps(Values.Settings.DeviceOptions.GpsComPort, Values.Settings.DeviceOptions.GpsBaud);
                    }
#endif
                    //moved from create new
                    if (!lastPointSaved)
                    {
                        SaveLastPoint(CurrentPoint);
                        lastPointSaved = true;
                    }

                    logging = true;
                    logged = 0;
                    ignore = 0;
                    txtPID.Text = "";
                    txtComment.Text = "";
                    btnCapture.Enabled = false;
                    progCapture.Value = logged;

                    gpsInfoAdvCtrl.ClearUtmRange();
                    gpsInfoAdvCtrl.UtmRange = true;
                }
            }
        }

        private void btnCancel_Click2(object sender, EventArgs e)
        {
            if (takingSideshot)
            {
                CancelSideshot();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnBound_Click2(object sender, EventArgs e)
        {
            if (OnBound)
            {
                OnBound = false;
                btnBound.Text = Values.Off;
            }
            else
            {
                OnBound = true;
                btnBound.Text = Values.On;
            }

            if (!_locked && CurrentPoint != null)
            {
                CurrentPoint.OnBnd = OnBound;
            }
        }

        private void chkLocked_CheckStateChanged2(object sender, EventArgs e)
        {
            if (_locked)
            {
                _locked = false;
                txtPID.Enabled = true;
                txtComment.Enabled = true;
                btnBound.Enabled = true;
            }
            else
            {
                _locked = true;
                txtPID.Enabled = false;
                txtComment.Enabled = false;
                btnBound.Enabled = false;
            }
        }

        private void txtPID_TextChanged2(object sender, EventArgs e)
        {
            if (!_locked)
            {
                if (takingSideshot)
                {
                    if (travInfoControl1.CurrentPoint != null && !txtPID.Text.IsEmpty() && txtPID.Text.IsInteger())
                    {
                        travInfoControl1.CurrentPoint.PID = txtPID.Text.ToInteger();
                    }
                    else
                    {
                        txtPID.Text = travInfoControl1.CurrentPoint.PID.ToString();
                    }
                }
                else
                {
                    if (CurrentPoint != null && !txtPID.Text.IsEmpty() && txtComment.Text.IsInteger())
                    {
                        CurrentPoint.PID = txtPID.Text.ToInteger();
                    }
                    else
                    {
                        txtPID.Text = CurrentPoint.PID.ToString();
                    }
                }
            }
        }

        private void txtComment_TextChanged2(object sender, EventArgs e)
        {
            if (!_locked)
            {
                if (takingSideshot)
                {
                    if (travInfoControl1.CurrentPoint != null && txtComment.Text != String.Empty)
                    {
                        travInfoControl1.CurrentPoint.Comment = txtComment.Text;
                    }
                }
                else
                {
                    if (CurrentPoint != null && txtComment.Text != "")
                    {
                        CurrentPoint.Comment = txtComment.Text;
                    }
                }
            }
        }


        private void txtPID_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtPID);
        }

        private void txtComment_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowRegular(this, txtComment);
        }

        private void txtPID_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtComment_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }


        private void btnSideshot_Click2(object sender, EventArgs e)
        {
            if (!logging)
            {
                if (takingSideshot)
                {
                    CancelSideshot();
                }
                else
                {
                    SetupSideshot();
                }
            }
        }

        private void travInfoControl1_BAzTextChanged2()
        {

        }

        private void travInfoControl1_FAzTextChanged2()
        {

        }

        private void travInfoControl1_SlopeAngleTextChanged2()
        {

        }

        private void travInfoControl1_SlopeDistTextChanged2()
        {

        }

        private void travInfoControl1_GotFocused2()
        {

        }
        #endregion


    }
}