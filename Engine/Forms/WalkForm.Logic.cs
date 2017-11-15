using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;
using TwoTrails.GpsAccess;
using TwoTrails.Utilities;
using TwoTrails.Engine;
using TwoTrails.BusinessLogic;
using TwoTrails.Controls;
using System.Media;
using System.Threading;

namespace TwoTrails.Forms
{
    public partial class WalkForm : Form
    {
        TtPolygon Polygon;
        DataAccessLayer DAL;

        TtGroup WalkGroup;
        WalkPoint CurrentPoint;
        WalkPoint LastPoint;
        NmeaBurst CurrentNmea;
        NmeaBurst LastNmea;

        private bool logging, _locked, _isInsert;
        private int logged, _index;

        private bool _sound;
        private bool OnBound;

        TtMetaData _currmeta;

        private int _increment;

        List<TtPoint> _AdjustInsertPoints;

        private SoundPlayer player;

#if (PocketPC || WindowsCE || Mobile)
        private AnimationCtrl animation;
#endif

        public void Init(TtPolygon poly, DataAccessLayer dal, TtMetaData meta, int currIndex, bool isInsert)
        {
            this.Icon = Properties.Resources.Map;
            TtUtils.ShowWaitCursor();
            Values.GPSA.BurstReceived += GPSA_BurstReceived;
            Values.GPSA.InvalidStringFound += GPSA_InvalidStringFound;
            Values.GPSA.ComTimeout += GPSA_ComTimeout;
            Values.GPSA.GpsStarted += GPSA_GpsStarted;
            Values.GPSA.GpsEnded += GPSA_GpsEnded;
            Values.GPSA.GpsError += GPSA_GpsError;

            Polygon = poly;
            DAL = dal;
            _currmeta = meta;

            logging = false;
            this.DialogResult = DialogResult.Cancel;
            OnBound = true;

            lblPoly.Text = "Poly: " + Polygon.Name;

            logged = 0;
            _locked = true;
            _isInsert = isInsert;

            _sound = true;
#if (PocketPC || WindowsCE || Mobile)
            player = new SoundPlayer(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ring.wav"));
#else
            player = new SoundPlayer(Properties.Resources.Ring);
#endif


#if !(PocketPC || WindowsCE || Mobile)
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.Image = Properties.Resources.Walking_Transparent;
#else
            animation = new AnimationCtrl();
            animation.Location = new Point((this.Width - Properties.Resources.walking1.Width / 5) - 10, 0);
            this.Controls.Add(animation);
            animation.BringToFront();
            animation.LoadImage(new List<Bitmap>() { Properties.Resources.walking1, Properties.Resources.walking2, 
            Properties.Resources.walking3 ,Properties.Resources.walking4, Properties.Resources.walking5,
            Properties.Resources.walking6, Properties.Resources.walking7,},
            Properties.Resources.walking1.Width / 5, Properties.Resources.walking1.Height / 5, 75, -1);      
#endif
            CurrentPoint = null;


            List<TtPoint> points = DAL.GetPointsInPolygon(Polygon);

            if (isInsert)
            {
                _AdjustInsertPoints = points.Where(p => p.Index >= currIndex).ToList();
            }

            _index = currIndex;

            if (_index > 0)
            {
                TtPoint lPoint = (points[_index - 1]);
                LastPoint = new WalkPoint();
                LastPoint.PID = lPoint.PID;
                LastPoint.Index = lPoint.Index;
            }

            cboDOP.SelectedIndex = Values.Settings.DeviceOptions.Filter_WALK_DOP_TYPE;
            cboFixType.SelectedIndex = Values.Settings.DeviceOptions.Filter_WALK_FixType;

#if (PocketPC || WindowsCE || Mobile)
            btnDOP.Text = cboDOP.Text;
            btnFixType.Text = cboFixType.Text;
#endif

            txtDOP.Text = Values.Settings.DeviceOptions.Filter_WALK_DOP_VALUE.ToString();

            txtAcc.Text = Values.Settings.DeviceOptions.Filter_Accuracy.ToString();

            txtFreq.Text = Values.Settings.DeviceOptions.Filter_Frequency.ToString();

            txtIncrement.Text = Values.Settings.DeviceOptions.WalkIncrement.ToString();
            _increment = Values.Settings.DeviceOptions.WalkIncrement;

            gpsInfoAdvCtrl.SetZone(_currmeta.Zone);
            gpsInfoAdvCtrl.StartControl();

            TtUtils.HideWaitCursor();
        }

        public void Load2()
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.GpsConfigured)
            {
                DialogResult dr = MessageBox.Show("GPS is not currently configured. Would you like to configure now?", "Configure GPS", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    using (DeviceSetupForm form = new DeviceSetupForm())
                    {
                        form.ShowDialog();
                    }
                }
                else
                    CloseForm();
            }
#else
            if (Values.Settings.DeviceOptions.GetGpsOnStart)
            {
                using (DeviceSetupForm form = new DeviceSetupForm())
                {
                    form.ShowDialog();
                }
            }
#endif

            if (!Values.GPSA.IsBusy)
                Values.GPSA.OpenGps(Values.Settings.DeviceOptions.GpsComPort, Values.Settings.DeviceOptions.GpsBaud);
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


        private void CreateWalkPoint(NmeaBurst b)
        {
            try
            {
                if (WalkGroup == null)
                {
                    WalkGroup = new TtGroup();
                    WalkGroup.SetGroupName(String.Format("Walk_{0}", WalkGroup.CN.Truncate(8)), null);

                    DAL.InsertGroup(WalkGroup);
                }

                if (CurrentPoint != null)
                {
                    if (_isInsert)
                    {
                        long index = CurrentPoint.Index;
                        foreach (TtPoint p in _AdjustInsertPoints)
                            p.Index = ++index;

                        DAL.SavePoints(_AdjustInsertPoints);
                    }

                    DAL.InsertPoint(CurrentPoint);
                    DAL.SaveNmeaBurst(CurrentNmea, CurrentPoint.CN);

                    LastPoint = CurrentPoint;

                    btnOk.GuiInvoke(() => { btnOk.Enabled = true; });
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "WalkFormLogic:CreateWalkPoint-Save Current Point", ex.StackTrace);
            }

            LastNmea = CurrentNmea;
            CurrentNmea = b;

            if (SetupPoint())
            {
                try
                {
                    CurrentPoint.UnAdjX = b._X;
                    CurrentPoint.UnAdjY = b._Y;
                    CurrentPoint.UnAdjZ = b._Z;
                    //CurrentPoint.X = b._X;
                    //CurrentPoint.Y = b._Y;
                    //CurrentPoint.Z = b._Z;
                    CurrentPoint.Time = DateTime.Now;
                    CurrentPoint.MetaDefCN = _currmeta.CN;
                    CurrentPoint.RMSEr = Values.Settings.DeviceOptions.MIN_POINT_ACCURACY;

                    b._Used = true;

                    if (_sound)
                    {
                        try
                        {
                            player.Play();
                        }
                        catch
                        {

                        }
                    }

                    new Thread(()=>
                        {
                            if(TtUtils.PointHasValue(CurrentPoint) || !Values.Settings.ProjectOptions.DropZero)
                                DrawSavePointIcon();
                            else
                                CurrentPoint = LastPoint;
                        }).Start();
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "WalkFormLogic:CreateWalkPoint", ex.StackTrace);
                }
            }
        }

        private bool SetupPoint()
        {
            CurrentPoint = new WalkPoint();

            try
            {
                if (LastPoint == null)
                    CurrentPoint.PID = PointNaming.NameFirstPoint(Polygon);
                else
                    CurrentPoint.PID = PointNaming.NamePoint(LastPoint, Values.Settings.DeviceOptions.WalkIncrement);

                _index++;
                CurrentPoint.PolyCN = Polygon.CN;
                CurrentPoint.PolyName = Polygon.Name;
                CurrentPoint.OnBnd = OnBound;
                CurrentPoint.Index = _index;
                CurrentPoint.GroupCN = WalkGroup.CN;
                CurrentPoint.GroupName = WalkGroup.Name;
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "WalkFormLogic:SetupPoint", ex.StackTrace);
                return false;
            }

            this.GuiInvoke(() =>
                {
                    txtPID.Text = CurrentPoint.PID.ToString();
                });

            return true;
        }

        private void DrawSavePointIcon()
        {
            Graphics g = pnlSavePointIcon.CreateGraphics();
            Brush b;
#if (PocketPC || WindowsCE || Mobile)
            b = new SolidBrush(Color.White);
            g.FillEllipse(b, 1, 1, 20, 20);
#else
            b = new SolidBrush(Color.Black);
            g.FillEllipse(b, 1, 1, 27, 27);
#endif

            Thread.Sleep(500);

#if (PocketPC || WindowsCE || Mobile)
            g.Clear(Color.Gray);
#else
            g.Clear(SystemColors.Control);
#endif
        }


        #region GPS Functions

        private void GPSA_BurstReceived(GpsAccess.NmeaBurst b)
        {
            if (logging)
            {
                if (logged == 0)
                {
                    b.CalcZone(_currmeta.Zone);

                    if (TtUtils.FilterBurst(b, Values.Settings.DeviceOptions.Filter_WALK_FixType,
                        Values.Settings.DeviceOptions.Filter_WALK_DOP_TYPE,
                        Values.Settings.DeviceOptions.Filter_WALK_DOP_VALUE))
                    {
                        if (Values.Settings.DeviceOptions.Filter_Accuracy > 0)
                        {
                            if (CurrentNmea == null || TtUtils.BurstDistance(CurrentNmea, b) > Values.Settings.DeviceOptions.Filter_Accuracy)
                            {
                                CreateWalkPoint(b);
                            }
                            else
                            {
                                logged--;   //try again next point
                            }
                        }
                        else
                        {
                            CreateWalkPoint(b);
                        }
                    }
                    else
                    {
                        logged--;   //try again next point
                    }
                }

                if (logged >= Values.Settings.DeviceOptions.Filter_Frequency)
                    logged = 0;
                else
                    logged++;
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
            logging = false;
#if (PocketPC || WindowsCE || Mobile)
            animation.StopAnimation();
#else
            picBox.Visible = false;
#endif
            gpsInfoAdvCtrl.UtmRange = false;

            TtUtils.ShowWaitCursor();
            try
            {
                if (CurrentPoint != null)
                {
                    DAL.InsertPoint(CurrentPoint);
                    DAL.SaveNmeaBurst(CurrentNmea, CurrentPoint.CN);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "WalkFormLogic:Ok:SavePoints", ex.StackTrace);
            }
            Kb.Hide(this);
            TtUtils.HideWaitCursor();
        }

        private void btnCapture_Click2(object sender, EventArgs e)
        {
            try
            {
                if (!logging)
                {
                    chkLock.Checked = true;
                    logged = 0;

                    logging = true;
                    btnCapture.Text = "Pause";
                    gpsInfoAdvCtrl.UtmRange = true;
                    logging = true;

#if (PocketPC || WindowsCE || Mobile)
                    animation.StartAnimation();
#else
                    picBox.Visible = true;
#endif
                }
                else
                {
                    logging = false;
                    btnCapture.Text = "Resume";
                    gpsInfoAdvCtrl.UtmRange = false;

#if (PocketPC || WindowsCE || Mobile)
                    animation.StopAnimation();
#else
                    picBox.Visible = false;
#endif
                }
            }
            catch(Exception ex)
            {
                TtUtils.WriteError(ex.Message, "WalkFormLogic:btnCapture", ex.StackTrace);
            }
        }

        private void btnCancel_Click2(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtFreq_TextChanged2(object sender, EventArgs e)
        {
            if (!_locked)
            {
                try
                {
                    Values.Settings.DeviceOptions.Filter_Frequency = Convert.ToInt32(txtFreq.Text);
                }
                catch
                {
                    txtFreq.Text = Values.Settings.DeviceOptions.Filter_Frequency.ToString();
                }
            }
        }

        private void txtAcc_TextChanged2(object sender, EventArgs e)
        {
            if (!_locked)
            {
                try
                {
                    Values.Settings.DeviceOptions.Filter_Accuracy = Convert.ToInt32(txtAcc.Text);
                }
                catch
                {
                    txtAcc.Text = Values.Settings.DeviceOptions.Filter_Accuracy.ToString();
                }
            }
        }

#if (PocketPC || WindowsCE || Mobile)
        private void btnDOP_Click2(object sender, EventArgs e)
        {
            List<string> cboItems = new List<string>();

            foreach (object item in cboDOP.Items)
            {
                cboItems.Add(item.ToString());
            }

            using (Selection form = new Selection("Dilution of Precision", cboItems, cboDOP.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    btnDOP.Text = cboItems[form.selection].ToString();
                    cboDOP.SelectedIndex = form.selection;
                }
            }
        }

        private void btnFixType_Click2(object sender, EventArgs e)
        {
            List<string> cboItems = new List<string>();

            foreach (object item in cboFixType.Items)
            {
                cboItems.Add(item.ToString());
            }

            using (Selection form = new Selection("Fix Type", cboItems, cboFixType.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    btnFixType.Text = cboItems[form.selection].ToString();
                    cboFixType.SelectedIndex = form.selection;
                }
            }
        }
#endif
        private void cboDOP_SelectedIndexChanged2(object sender, EventArgs e)
        {
#if (PocketPC || WindowsCE || Mobile)
            btnDOP.Text = cboDOP.Text;
#endif
        }

        private void cboFixType_SelectedIndexChanged2(object sender, EventArgs e)
        {
#if (PocketPC || WindowsCE || Mobile)
            btnFixType.Text = cboFixType.Text;
#endif
        }

        private void txtDOP_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                double val = 0;
                val = Convert.ToDouble(txtDOP.Text);

                if (val > 0)
                {
                    Values.Settings.DeviceOptions.Filter_WALK_DOP_VALUE = val;
                }
            }
            catch
            {

            }
        }

        private void txtIncrement_TextChanged2(object sender, EventArgs e)
        {
            if (!_locked)
            {
                try
                {
                    Values.Settings.DeviceOptions.WalkIncrement = Convert.ToInt32(txtIncrement.Text);
                    _increment = Values.Settings.DeviceOptions.WalkIncrement;
                }
                catch
                {
                    txtIncrement.Text = Values.Settings.DeviceOptions.WalkIncrement.ToString();
                }
            }
        }

        private void txtPID_TextChanged2(object sender, EventArgs e)
        {
            if (!_locked)
            {
                if (CurrentPoint != null && txtPID.Text != "" && txtPID.Text.IsInteger())
                {
                    CurrentPoint.PID = txtPID.Text.ToInteger();
                }
                else
                    txtPID.Text = CurrentPoint.PID.ToString();
            }
        }

        private void chkSound_CheckStateChanged2(object sender, EventArgs e)
        {
            _sound = chkSound.Checked;
        }

        private void chkLock_CheckStateChanged2(object sender, EventArgs e)
        {
            _locked = chkLock.Checked;

            txtFreq.Enabled = !_locked;
            txtAcc.Enabled = !_locked;
            txtDOP.Enabled = !_locked;
            txtPID.Enabled = !_locked;
            txtIncrement.Enabled = !_locked;
            cboDOP.Enabled = !_locked;
            cboFixType.Enabled = !_locked;
#if (PocketPC || WindowsCE || Mobile)
            btnDOP.Enabled = !_locked;
            btnFixType.Enabled = !_locked;
#endif
        }

        private void gpsInfoAdvCtrl_Click2(object sender, EventArgs e)
        {

        }

        private void txtFreq_GotFocus2(object sender, EventArgs e)
        {
            txtFreq.SelectAllViaInvoke();
            Kb.ShowNumeric(this, txtFreq);
        }

        private void txtAcc_GotFocus2(object sender, EventArgs e)
        {
            txtAcc.SelectAllViaInvoke();
            Kb.ShowNumeric(this, txtAcc);
        }

        private void txtDOP_GotFocus2(object sender, EventArgs e)
        {
            txtDOP.SelectAllViaInvoke();
            Kb.ShowNumeric(this, txtDOP);
        }

        private void txtPID_GotFocus2(object sender, EventArgs e)
        {
            txtPID.SelectAllViaInvoke();
            Kb.ShowRegular(this, txtPID);
        }

        private void txtIncrement_GotFocus2(object sender, EventArgs e)
        {
            txtIncrement.SelectAllViaInvoke();
            Kb.ShowNumeric(this, txtIncrement);
        }
        #endregion
    }
}