using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;
using TwoTrails.Engine;
using TwoTrails.GpsAccess;
using TwoTrails.BusinessLogic;
using TwoTrails.Controls;

namespace TwoTrails.Forms
{
    public partial class MetadataForm : Form
    {
        private DataAccessLayer DAL;

        private List<TtMetaData> MetaData;
        private List<string> _CNs;

        int CurrIndex, currZone = -1, oldZone = -1;
        TtMetaData _current;
        TtMetaData Current
        {
            get { return _current; }
            set
            {
                _current = value;

                if (_current != null)
                {
                    bindingSourceMeta.DataSource = _current;
                    LockLocks = false;
                    CurrIndex = _CNs.IndexOf(_current.CN);
                    currZone = _current.Zone;
                    oldZone = _current.Zone;
                }
                else
                {
                    LockLocks = true;
                    txtComment.Text = "";
                    txtCompass.Text = "";
                    txtCrew.Text = "";
                    txtGPS.Text = "";
                    txtLaser.Text = "";
                    txtMagDec.Text = "";
                    txtName.Text = "";
                    txtZone.Text = "";
                    CurrIndex = -1;
                    currZone = -1;
                    oldZone = -1;
                }

                zoneChanged = false;
            }
        }

        List<NmeaBurst> bursts;
        bool calcBursts, DelInit, zoneChanged;
        bool _recalc;

        private bool _dirty, _locked, _init;

        private void Init()
        {
            this.Icon = Properties.Resources.Map;

            bursts = new List<NmeaBurst>();
            calcBursts = false;
            DelInit = false;
            _recalc = false;

            try
            {
                MetaData = DAL.GetMetaData();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MetadataForm:Init-GetMetaData", ex.StackTrace);
            }

            _dirty = false;
            _CNs = new List<string>();

            Current = null;

            if (MetaData.Count > 0)
            {
                foreach (TtMetaData ttm in MetaData)
                {
                    _CNs.Add(ttm.CN);
                }

                Current = MetaData[0];
            }

            Bind();

            if(_CNs.Count > 0)
                pointNavigationCtrl.UpdatePointList(_CNs, 0);
            else
                pointNavigationCtrl.UpdatePointList(_CNs, -1);
            _init = true;

            actionsControl.MiscButtonText = "Copy Meta";

            AdjustNavControls();
        }

        private void MetadataForm_Closing2(object sender, CancelEventArgs e)
        {
            if (DelInit)
                Values.GPSA.BurstReceived -= GPSA_BurstReceived;

            if (Values.GPSA.IsBusy && !Values.Settings.DeviceOptions.KeepGpsOn)
            {
                Values.GPSA.CloseGps();
            }
        }

        public bool Locked
        {
            get { return _locked; }
            set
            {
                _locked = value;

                chkLock1.Checked = _locked;

#if (PocketPC || WindowsCE || Mobile)
                chkLock2.Checked = _locked;

                txtName.ReadOnly = _locked;
                txtZone.ReadOnly = _locked;
                txtMagDec.ReadOnly = _locked;

                txtGPS.ReadOnly = _locked;
                txtLaser.ReadOnly = _locked;
                txtCompass.ReadOnly = _locked;
                txtCrew.ReadOnly = _locked;
                txtComment.ReadOnly = _locked;
#else
                txtName.Enabled = !_locked;
                txtZone.Enabled = !_locked;
                txtMagDec.Enabled = !_locked;
                txtGPS.Enabled = !_locked;
                txtLaser.Enabled = !_locked;
                txtCompass.Enabled = !_locked;
                txtCrew.Enabled = !_locked;
                txtComment.Enabled = !_locked;

#endif

                btnHelp.Enabled = !_locked;
                //cboDatum.Enabled = !_locked;
                //cboMapProj.Enabled = !_locked;
                cboDist.Enabled = !_locked;
                cboElev.Enabled = !_locked;
                cboSlope.Enabled = !_locked;
                cboMagDec.Enabled = !_locked;

                btnAutoFillGps.Enabled = !_locked;
                btnLaserList.Enabled = !_locked;
                btnCompassList.Enabled = !_locked;

                actionsControl.DeleteEnabled = (MetaData.Count > 1 && CurrIndex != 0 && !_locked);
            }
        }

        private bool LockLocks
        {
            get { return chkLock1.Enabled; }
            set
            {
                if(value == true)
                    Locked = true;

                chkLock1.Enabled = !value;
#if (PocketPC || WindowsCE || Mobile)
                chkLock2.Enabled = !value;
#endif
            }
        }

        private void Bind()
        {
            try
            {
                cboDatum.DataSource = TtUtils.EnumGetValues(Datum.Local);
                cboDatum.DataBindings.Add("SelectedItem", bindingSourceMeta, "datum", true);

                cboDist.DataSource = TtUtils.EnumGetValues(UomDistance.Chains);
                cboDist.DataBindings.Add("SelectedItem", bindingSourceMeta, "uomDistance", true);

                cboElev.DataSource = TtUtils.EnumGetValues(UomElevation.Feet);
                cboElev.DataBindings.Add("SelectedItem", bindingSourceMeta, "uomElevation", true);

                cboSlope.DataSource = TtUtils.EnumGetValues(UomSlope.Degrees);
                cboSlope.DataBindings.Add("SelectedItem", bindingSourceMeta, "uomSlope", true);

                cboMagDec.DataSource = TtUtils.EnumGetValues(DeclinationType.DeedRot);
                cboMagDec.DataBindings.Add("SelectedItem", bindingSourceMeta, "decType", true);

                cboMapProj.Items.Add("Meters");
                cboMapProj.SelectedIndex = 0;

                txtName.DataBindings.Add("Text", bindingSourceMeta, "Name", true);
                txtZone.DataBindings.Add("Text", bindingSourceMeta, "Zone", true);
                txtMagDec.DataBindings.Add("Text", bindingSourceMeta, "magDec", true, DataSourceUpdateMode.OnValidation);

                txtGPS.DataBindings.Add("Text", bindingSourceMeta, "Receiver", true);
                txtLaser.DataBindings.Add("Text", bindingSourceMeta, "Laser", true);
                txtCompass.DataBindings.Add("Text", bindingSourceMeta, "Compass", true);
                txtCrew.DataBindings.Add("Text", bindingSourceMeta, "Crew", true);
                txtComment.DataBindings.Add("Text", bindingSourceMeta, "Comment", true);

                bindingSourceMeta.DataSource = MetaData;
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MetaDataFormLogic:Bind", ex.StackTrace);
            }
        }

        private void SaveMeta()
        {
            if (_dirty && Current != null)
            {
                try
                {
                    TtUtils.ShowWaitCursor();

                    if (zoneChanged && currZone != Current.Zone)
                    {

                        List<TtPoint> points = DAL.GetGpsPointsByMeta(Current.CN);
                        List<TtPoint> updatePoints = new List<TtPoint>();

                        TtPoint point;
                        for (int i = 0; i < points.Count; i++)
                        {
                            point = points[i];
                            updatePoints.Add(TtUtils.RecalcPoint(point, Current.Zone, oldZone, DAL));
                        }

                        if (updatePoints.Count > 0)
                        {
                            DAL.SavePoints(updatePoints);
                        }
                    }

                    DAL.UpdateMetaData(Current);

                    _dirty = false;
                }
                catch(Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "MetadataFormLogic:SaveMeta", ex.StackTrace);
                }

                TtUtils.HideWaitCursor();
            }
        }

        private void AdjustNavControls()
        {

            if (CurrIndex > 0 && _CNs.Count > 1)
            {
                pointNavigationCtrl.BackwardButtons = true;
            }
            else
            {
                pointNavigationCtrl.BackwardButtons = false;
            }

            if (CurrIndex < MetaData.Count - 1 && _CNs.Count > 1)
            {
                pointNavigationCtrl.ForwardButtons = true;
            }
            else
            {
                pointNavigationCtrl.ForwardButtons = false;
            }

            if (MetaData.Count > 1 && CurrIndex != 0 && !Locked)
            {
                actionsControl.DeleteEnabled = true;
            }
            else
            {
                actionsControl.DeleteEnabled = false;
            }
        }

        private void ChangeMeta(string cn)
        {
            if (MetaData.Count > 0)
            {
                int pos = -1;

                pos = _CNs.IndexOf(cn);

                if (pos > -1)
                {
                    SaveMeta();
                    _init = false;  //turn off _init so index changes dont set off _dirty
                    Current = TtUtils.CopyMetadata(MetaData[pos]);
                    _init = true;
                }

                Locked = true;
                AdjustNavControls();
            }
        }

        private void Changed()
        {
            if (_init)
            {
                _dirty = true;
                _recalc = true;
            }
        }

        #region Index Control
        private void pointNavigationCtrl_AlreadyAtBeginning2(object sender)
        {

        }

        private void pointNavigationCtrl_AlreadyAtEnd2(object sender)
        {

        }

        private void pointNavigationCtrl_IndexChanged2(object sender, TwoTrails.Controls.PointNavigationCtrl.PointNavEventArgs e)
        {
            ChangeMeta(e.NextPointCN);
        }

        private void pointNavigationCtrl_JumpPoint2(object sender)
        {
            List<string> opts = new List<string>();
            foreach (TtMetaData p in MetaData)
            {
                opts.Add(p.Name);
            }

            using (Selection form = new Selection("Points", opts, CurrIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ChangeMeta(MetaData[form.selection].CN);
                    pointNavigationCtrl.UpdateIndex(form.selection);
                }
            }
        }
        #endregion

        #region Actions Control
        private void actionsControl_Cancel_OnClick2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actionsControl_Delete_OnClick2(object sender, EventArgs e)
        {
            if (_current != null && CurrIndex != 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this Metadata? All points that use this Metadata will be switched to the default Metadata.", "Delete Metadata",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                    int pos = -1;
                    pos = _CNs.IndexOf(Current.CN);
                    if (pos > -1)
                    {
                        _CNs.RemoveAt(pos);
                        MetaData.RemoveAt(pos);

                        List<TtPoint> points = DAL.GetPointsByMeta(Current.CN);

                        if (points.Count > 0)
                        {
                            String dMetaCN = MetaData[0].CN;
                            foreach (TtPoint p in points)
                            {
                                p.MetaDefCN = dMetaCN;
                            }
                            DAL.SavePoints(points);
                        }

                        DAL.DeleteMetaData(Current.CN);

                        if (_CNs.Count > 0)
                            if (CurrIndex < _CNs.Count)
                                Current = MetaData[CurrIndex];
                            else
                                Current = MetaData[CurrIndex - 1];
                        else
                            Current = null;

                        pointNavigationCtrl.UpdatePointList(_CNs, CurrIndex);
                        AdjustNavControls();
                    }
                    else
                    {
                        MessageBox.Show("Delete Failed");
                    }
                }
            }
        }

        private void actionsControl_Misc_OnClick2(object sender, EventArgs e)
        {
            TtMetaData newmeta = new TtMetaData();

            newmeta.CN = Guid.NewGuid().ToString();
            newmeta.Comment = Current.Comment;
            newmeta.Compass = Current.Compass;
            newmeta.Crew = Current.Crew;
            newmeta.datum = Current.datum;
            newmeta.decType = Current.decType;
            newmeta.Laser = Current.Laser;
            newmeta.magDec = Current.magDec;
            newmeta.Receiver = Current.Receiver;
            newmeta.uomDistance = Current.uomDistance;
            newmeta.uomElevation = Current.uomElevation;
            newmeta.uomSlope = Current.uomSlope;
            newmeta.Zone = Current.Zone;

            int i = 1;
            string name = string.Empty;

            while (true)
            {
                name = String.Format("m_{0}", i);

                if (MetaData.Where(m => m.Name == name).Any())
                {
                    i++;
                }
                else
                {
                    newmeta.Name = name;
                    break;
                }
            }

            SaveMeta();

            _CNs.Add(newmeta.CN);
            MetaData.Add(newmeta);

            Current = newmeta;

            pointNavigationCtrl.UpdatePointList(_CNs, CurrIndex);

            AdjustNavControls();

            DAL.InsertMetaData(Current);
        }

        private void actionsControl_New_OnClick2(object sender, EventArgs e)
        {
            TtMetaData ttm = Values.Settings.ReadMetaSettings();
            ttm.CN = Guid.NewGuid().ToString();

            SaveMeta();

            if (_current != null)
            {
                double? d = TtUtils.GetEndingNumber(Current.Name);
                if (d != null)
                {
                    ttm.Name = "Metadata_" + (Convert.ToInt32(d) + 1);
                }
                else
                {
                    ttm.Name = "Metadata_" + (_CNs.Count);
                }
            }
            else
            {
                ttm.Name = "Metadata_1";
            }

            _CNs.Add(ttm.CN);
            MetaData.Add(ttm);

            Current = ttm;

            pointNavigationCtrl.UpdatePointList(_CNs, CurrIndex);

            AdjustNavControls();

            DAL.InsertMetaData(Current);
        }

        private void actionsControl_Ok_OnClick2(object sender, EventArgs e)
        {
            TtUtils.ShowWaitCursor();

            SaveMeta();

            if (_recalc)
            {
                if (PolygonAdjuster.CanAdjust(DAL))
                    PolygonAdjuster.Adjust(DAL, true, this);
            }
            else
            {
                TtUtils.HideWaitCursor();
                this.Close();
            }
        }
        #endregion

        #region Metadata

        private void txtName_TextChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void txtZone_TextChanged2(object sender, EventArgs e)
        {
            Changed();
            zoneChanged = true;
        }

        private void btnHelp_Click2(object sender, EventArgs e)
        {
            if (!Values.GPSA.IsBusy)
            {
                if (!Values.Settings.DeviceOptions.GpsConfigured)
                {
                    if (MessageBox.Show("Gps is not configured. Would you like to configure now?", "Configure Gps", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        using (DeviceSetupForm form = new DeviceSetupForm())
                        {
                            form.ShowDialog();

                            if (Values.Settings.DeviceOptions.GpsConfigured)
                            {
                                btnHelp_Click2(sender, e);
                            }
                        }
                    }
                }
                else
                {
                    Values.GPSA.BurstReceived += GPSA_BurstReceived;
                    DelInit = true;

                    TtUtils.ShowWaitCursor();
                    calcBursts = true;
                    bursts.Clear();
                    Values.GPSA.OpenGps(Values.Settings.DeviceOptions.GpsComPort, Values.Settings.DeviceOptions.GpsBaud);
                }
            }
            else
            {
                calcBursts = true;
                bursts.Clear();
            }
        }

        private void cboDatum_SelectedIndexChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void cboMapProj_SelectedIndexChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void cboDist_SelectedIndexChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void cboElev_SelectedIndexChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void cboSlope_SelectedIndexChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void cboMagDec_SelectedIndexChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void txtMagDec_TextChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void chkLock1_CheckStateChanged2(object sender, EventArgs e)
        {
            Locked = chkLock1.Checked;
        }

        #endregion

        #region Dev & Proj

        private void txtGPS_TextChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void txtLaser_TextChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void txtCompass_TextChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void txtCrew_TextChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void txtComment_TextChanged2(object sender, EventArgs e)
        {
            Changed();
        }

        private void chkLock2_CheckStateChanged2(object sender, EventArgs e)
        {
#if (PocketPC || WindowsCE || Mobile)
            Locked = chkLock2.Checked;
#endif
        }

        private void btnSetAsDefault_Click2(object sender, EventArgs e)
        {
            Engine.Values.Settings.WriteMetaSettings(Current);
            AutoClosingMessageBox.Show("Default Saved","Default MetaData", 1000);
        }

        #endregion

        #region GPS Functions
        private void GPSA_GpsError()
        {

        }

        private void GPSA_GpsEnded()
        {

        }

        private void GPSA_ComTimeout()
        {
            Values.GPSA.CloseGps();
            GPSA_GpsError();
        }

        private void GPSA_BurstReceived(NmeaBurst data)
        {
            if (calcBursts)
            {
                data.CalcRealZone();

                if(data.IsValid)
                    bursts.Add(data);

                if (bursts.Count > 4)
                {
                    double mag = 0;
                    int zone = 0;

                    foreach (NmeaBurst b in bursts)
                    {
                        mag += b._magVar;

                        zone = b._utm_zone;
                    }

                    mag /= bursts.Count;

                    this.GuiInvoke(() =>
                        {
                            Current.magDec = mag;
                            Current.Zone = zone;
                            txtZone.Text = zone.ToString();
                            txtMagDec.Text = mag.ToString();
                            TtUtils.HideWaitCursor();
                        });

                    Changed();

                    Values.GPSA.BurstReceived -= GPSA_BurstReceived;
                    DelInit = false;

                    TtUtils.HideWaitCursor();

                    if (!Values.Settings.DeviceOptions.KeepGpsOn)
                    {
                        Values.GPSA.CloseGps();
                    }

                    calcBursts = false;
                }
            }
        }

        private void GPSA_InvalidStringFound()
        {
            GPSA_GpsError();
        }
        #endregion

        private void btnAutoFillGps_Click2(object sender, EventArgs e)
        {
            List<string> items = new List<string>(new string[]{
               "Allegro MX",
               "Archer",
               "Archer 2",
               "Garmin 60",
               "Garmin 62",
               "Garmin 76",
               "Juno SB",
               "Juno 3B",
               "Juno 5B",
               "Mesa",
               "Trimble Geo7X",
               "Trimble Geo 6000",
               "Trimble Nomad G",
               "Trimble R1",
               "Trimble XT",
               "Trimble XM",
               "Trimble Yuma",
               "Trimble Yuma 2"
            });

            using (Selection form = new Selection("GPS Receiver", items, 0))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Current.Receiver = items[form.selection];
                    txtGPS.Text = Current.Receiver;
                    _dirty = true;
                }
            }

        }

        private void btnLaserList_Click2(object sender, EventArgs e)
        {
            List<string> items = new List<string>();

            items.Add("TruPulse 360");
            items.Add("TruPulse 200");
            items.Add("TruPulse Other");
            items.Add("Impulse 200");
            items.Add("Impulse 100");
            items.Add("Impulse Other");
            items.Add("Logger Tape");
            items.Add("Nylon Tape");
            items.Add("Chains");
            items.Add("Other");

            using(Selection form = new Selection("Laser / Rangefinder", items, 0))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Current.Laser = items[form.selection];
                    txtLaser.Text = Current.Laser;
                    _dirty = true;
                }
            }
        }

        private void btnCompassList_Click2(object sender, EventArgs e)
        {
            List<string> items = new List<string>();

            items.Add("Silva");
            items.Add("Suunto");
            items.Add("Other");

            using (Selection form = new Selection("Laser / Rangefinder", items, 0))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Current.Compass = items[form.selection];
                    txtCompass.Text = Current.Compass;
                    _dirty = true;
                }
            }
        }

        #region Focus
        private void txtMagDec_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtMagDec);
        }

        private void txtZone_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtZone);
        }

        private void txtName_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowRegular(this, txtName);
        }

        private void txtGPS_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowRegular(this, txtGPS);
        }

        private void txtLaser_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowRegular(this, txtLaser);
        }

        private void txtCompass_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowRegular(this, txtCompass);
        }

        private void txtCrew_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowRegular(this, txtCrew);
        }

        private void txtComment_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowRegular(this, txtComment);
        }

        private void tabDevProj_GotFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void tabMeta_GotFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void MetadataForm_GotFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }
        #endregion

        #region Lost Focus
        private void txtName_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtZone_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtMagDec_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtGPS_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtLaser_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtCompass_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtCrew_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtComment_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }
        #endregion
    }
}