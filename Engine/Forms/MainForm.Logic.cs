using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.GpsAccess;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;
using TwoTrails.BusinessLogic;
using TwoTrails.Engine;
using Engine.BusinessLogic;
using System.Data.SQLite;
using System.IO;
using TwoTrails.Utilities;
using TwoTrails.Controls;

#if !(PocketPC || WindowsCE || Mobile)
using Microsoft.Win32;
#else
using FMSC.Controls;
#endif

namespace TwoTrails.Forms
{
    public delegate void UpdateToolStripDelegate(string status);
    public delegate void UpdateToolStripProgressDelegate();
    public delegate void UpdateInfoDelegate();

    public partial class MainForm
    {

        private DataAccessLayer data;
        string _FileName;
        private bool _fileloaded;
        private bool FileLoaded
        {
            get { return _fileloaded; }
            set
            {
                _fileloaded = value;

                btnPoint.Enabled = _fileloaded;
                btnPoly.Enabled = _fileloaded;
                buttonProjectInfo.Enabled = _fileloaded;
                btnExport.Enabled = _fileloaded;
                btnHowAmIDoing.Enabled = _fileloaded;
                btnMeta.Enabled = _fileloaded;
                btnDup.Enabled = _fileloaded;
                btnPlotGrid.Enabled = _fileloaded;
                btnMap.Enabled = _fileloaded;
#if !(PocketPC || WindowsCE || Mobile)
                btnGMap.Enabled = _fileloaded;
                btnGEarth.Enabled = _fileloaded;
                btnGroupEdit.Enabled = _fileloaded;
                btnMergePolys.Enabled = _fileloaded;
                btnPolyTransform.Enabled = _fileloaded;
#else
                btnRename.Enabled = _fileloaded;
#endif
                btnEditPointTable.Enabled = _fileloaded;
                btnMassEdit.Enabled = _fileloaded;
                btnImport.Enabled = _fileloaded;
            }
        }
        private bool _saveSettings = true;
#if !DEBUG
        private bool _closing = false, _loading = true;
#else
        private bool _loading;
#endif

        public MainForm()
        {
#if (PocketPC || WindowsCE || Mobile)
            if (Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();
            btnReset.MakeMultiline();

            chkUseCombo.Enabled = false;
            chkUseCombo.Visible = false;
#else
            InitializeComponent();
            chkOnKeyboard.Enabled = false;
            chkOnKeyboard.Visible = false;
#endif

#if !DEBUG
            chkAutoUpdateIndex.Visible = false;

    #if !(PocketPC || WindowsCE || Mobile)
            btnMergePolys.Visible = false;

            tsmiDoc.Enabled = false;
            tsmiTut.Enabled = false;
    #else
            //
    #endif
#else
    #if !(PocketPC || WindowsCE || Mobile)
            tsmiSettingsFolder.Visible = true;
    #else
            //
    #endif
#endif
        }

        private void MainForm_Load2(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;
            TtUtils.ShowWaitCursor();
            tabControl1.SelectedIndex = 0;
            FileLoaded = false;
            LoadSettings();
            _loading = false;

#if (PocketPC || WindowsCE || Mobile)
            TtUtils.WriteEvent("TwoTrails (Mobile): Loaded", true);

            if (!Directory.Exists(Values.DefaultSaveFolder))
            {
                Directory.CreateDirectory(Values.DefaultSaveFolder);
            }
#else
            TtUtils.WriteEvent(String.Format("TwoTrails (PC {0}): Loaded", Engine.Values.TwoTrailsVersion), true);
#endif

            TtUtils.HideWaitCursor();
        }

        private void MainForm_Closing2(object sender, CancelEventArgs e)
        {
#if !DEBUG
            if (!_closing)
            {
                if (MessageBox.Show("Are You sure you want to leave TwoTrails?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2)
                    == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
#endif
            if (data != null && data.IsOpen)
            {
                data.CloseDB();
            }

            if (_saveSettings)
                SaveSettings();

            if (TtUtils.AdvReport)
                TtUtils.WriteEvent("TwoTrails: Closed");
        }


        #region Controls

        private void btnNew_Click2(object sender, EventArgs e)
        {
            NewTtFile();
        }

        private void btnInput_Click2(object sender, EventArgs e)
        {
            data.OpenDAL();
            data.CloseDB();
        }

        private void btnOpen_Click2(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenTtFile(openFileDialog1.FileName);
            }
        }

        private void btnPoint_Click2(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (data != null)
                    {
                        using (PointEditForm form = new PointEditForm(data))
                        {
                            form.ShowDialog();

                        #if !(PocketPC || WindowsCE || Mobile)
                            UpdateInfo();
                        #endif
                        }
                    }

                    TtUtils.HideWaitCursor();
                }
                catch (Exception ex)
                {
                    TtUtils.HideWaitCursor();
                    TtUtils.WriteError(ex.Message, "MainFormLogic:btnPoint:PointFormInteralError", ex.StackTrace);
                    MessageBox.Show("Point Edit Failed to Load");
                }
            }
            catch (Exception ex)
            {
                TtUtils.HideWaitCursor();
                TtUtils.WriteError(ex.Message, "MainFormLogic:btnPoint");
                MessageBox.Show("Point Edit Failed to Load");
            }
        }

        private void btnPoly_Click2(object sender, EventArgs e)
        {
            using (PolyEditForm form = new PolyEditForm(data))
            {
                form.ShowDialog();

#if !(PocketPC || WindowsCE || Mobile)
                UpdateInfo();
#endif
            }
        }

        private void buttonProjectInfo_Click2(object sender, EventArgs e)
        {
            using (ProjectInfoForm form = new ProjectInfoForm(data))
            {
                form.ShowDialog();
#if!(PocketPC || WindowsCE || Mobile)
                UpdateInfo();
#endif
            }
        }

        private void btnHowAmIDoing_Click2(object sender, EventArgs e)
        {
            HowAmIDoingOptions options = new HowAmIDoingOptions(data);
            HowAmIDoingLogic logic = new HowAmIDoingLogic(options);

            options.PopulateFromDataLayer();
            options.TtFilePath = System.IO.Path.GetFileName(_FileName);
            options.SaveReport = false;

            using (HowAmIDoingForm form = new HowAmIDoingForm(logic, options))
            {
                DialogResult res = form.ShowDialog();
            }
        }

        #if (PocketPC || WindowsCE || Mobile)
        private void btnRecOpen_Click2(object sender, EventArgs e)
        {
            List<string> cboItems = new List<string>();

            foreach (RecentProject item in Values.Settings.ProjectOptions.RecOpen)
            {
                cboItems.Add(System.IO.Path.GetFileName(item.File));
            }

            using (Selection form = new Selection("Recent Files", cboItems, -1))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.selection > -1)
                    {
                        if (File.Exists(Values.Settings.ProjectOptions.RecOpen[form.selection].File))
                            OpenTtFile(Values.Settings.ProjectOptions.RecOpen[form.selection].File);
                        else
                            MessageBox.Show("Error, File does not Exist");
                    }
                }
            }
        }
        #endif

        private void cboRecOpen_SelectedIndexChanged2(object sender, EventArgs e)
        {
            if (cboRecOpen.SelectedIndex < 1)
                return;

            if (File.Exists(Values.Settings.ProjectOptions.RecOpen[cboRecOpen.SelectedIndex].File))
                OpenTtFile(Values.Settings.ProjectOptions.RecOpen[cboRecOpen.SelectedIndex].File);
            else
                MessageBox.Show("Error, File does not Exist");
        }

        private void btnRename_Click2(object sender, EventArgs e)
        {
            using(RenamePointForm form = new RenamePointForm(data))
            {
                if(form.DialogResult != DialogResult.Abort)
                    form.ShowDialog();
            }
        }

        private void btnMeta_Click2(object sender, EventArgs e)
        {
            using (MetadataForm form = new MetadataForm(data))
            {
                form.ShowDialog();
#if !(PocketPC || WindowsCE || Mobile)
                UpdateInfo();
#endif
            }
        }

        private void btnEditPointTable_Click2(object sender, EventArgs e)
        {
            try
            {
                using (EditPointTableForm form = new EditPointTableForm(data))
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                TtUtils.HideWaitCursor();
                AutoClosingMessageBox.Show("Open Point Table Error", "Table Error", 1);
                TtUtils.WriteError(ex.Message, "MainFormLogic:btnEditPointTable", ex.StackTrace);
            }
            
        }

        private void btnExport_Click2(object sender, EventArgs e)
        {
            using (ExportForm form = new ExportForm(data))
            {
                form.ShowDialog();
            }
        }

        private void btnInfo_Click2(object sender, EventArgs e)
        {
        #if DEBUG
            using (_TestForm1 form = new _TestForm1(data))
            {
                form.ShowDialog();
            }
        #else
            using (TwoTrailsInfoForm form = new TwoTrailsInfoForm())
            {
                form.ShowDialog();
            }
        #endif
        }

        private void btnImport_Click2(object sender, EventArgs e)
        {
            using (ImportForm form = new ImportForm(data, FileLoaded))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void btnDup_Click2(object sender, EventArgs e)
        {
            string newFile = System.IO.Path.GetDirectoryName(_FileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(_FileName) + "_bk" + System.IO.Path.GetExtension(_FileName);
            int count = 2;

            while (File.Exists(newFile))
            {
                newFile = String.Format("{0}\\{1}_bk({3}){2}", System.IO.Path.GetDirectoryName(_FileName), System.IO.Path.GetFileNameWithoutExtension(_FileName),
                    System.IO.Path.GetExtension(_FileName), count);
                count++;
            }

            if (File.Exists(_FileName))
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.FileName = newFile;
                    sfd.Filter = "TwoTrails File|*.tt2";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        data.CloseDB();

                        File.Copy(_FileName, sfd.FileName, true);

                        OpenTtFile(_FileName);

                        AutoClosingMessageBox.Show(String.Format("Project Copied as {0}.", sfd.FileName), "Project Duplicated", 1500);
                        Values.Settings.ProjectOptions.AddToRecent(sfd.FileName, data.GetProjectID());
                    }
                }
            }
            else
                MessageBox.Show("Project does not exist.");
        }

        private void btnWhere_Click2(object sender, EventArgs e)
        {
            try
            {
                using (WhereIsForm form = new WhereIsForm(data))
                {
                    form.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MainFormLogic:btnWhere");
            }
        }

        private void btnPlotGrid_Click2(object sender, EventArgs e)
        {
            using (PlotGridForm form = new PlotGridForm(data))
            {
                if (form.DialogResult != DialogResult.Abort && form.DialogResult != DialogResult.None)
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        //
                    }
                }
            }
        }

        private void btnMap_Click2(object sender, EventArgs e)
        {
            using (MapOptionsForm form = new MapOptionsForm(data))
            {
                form.ShowDialog();
            }
        }

        private void btnGPSLogger_Click2(object sender, EventArgs e)
        {
            using (GPSLoggerForm form = new GPSLoggerForm())
            {
                form.ShowDialog();
            }
        }

        #endregion


        #region Create / Open / Upgrade TTfile
        private void NewTtFile()
        {
            string fileName;

            if(data != null)
                data.CloseDB();
            FileLoaded = false;

#if (PocketPC || WindowsCE || Mobile)
            SelectFileDialogEx saveFileDialog1 = new SelectFileDialogEx(null, Values.DefaultSaveFolder);
            //Kb.SetKeyboardToRegularOverride();  //set regular keyboard
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
#else
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "TwoTrails 2 Files|*.tt2";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
#endif
            {
                TtUtils.ShowWaitCursor();
                fileName = saveFileDialog1.FileName;

                if (fileName.Length > 4)
                {
                    if (fileName.Substring(fileName.Length - 4, 4) != ".tt2")
                        fileName += ".tt2";
                }
                else
                {
                    fileName += ".tt2";
                }


                data = NewOpenLogic.NewTwoTrailsFile(fileName);
                if (data != null)
                {
                    _FileName = fileName;

#if (PocketPC || WindowsCE || Mobile)
                    tbTtFileName.Text = System.IO.Path.GetFileName(_FileName);
#else
                    ChangeTitle(_FileName);
#endif
                    data.OpenDAL();
                    tabControl1.SelectedIndex = 1;

                    Values.CurrentDbVersion = true;
                    FileLoaded = true;
                    Values.Settings.ProjectOptions.AddToRecent(_FileName, data.GetProjectID());
                    TtUtils.HideWaitCursor();

#if !(PocketPC || WindowsCE || Mobile)
                    Values.UpdateStatusText(String.Format("File {0} Loaded.", Path.GetFileName(_FileName)));
                    pnlInfo.Visible = true;
                    UpdateInfo(File.GetCreationTime(_FileName));
                    ChangeTitle(Path.GetFileName(_FileName));
#else
                        tbTtFileName.Text = System.IO.Path.GetFileName(fileName);
#endif

                    using (ProjectInfoForm form = new ProjectInfoForm(data))
                    {
                        form.ShowDialog();
#if!(PocketPC || WindowsCE || Mobile)
                        UpdateInfo();
#endif
                    }

                    Values.DataExport.FolderName = System.IO.Path.GetFileNameWithoutExtension(_FileName);
                }
                else
                {
#if!(PocketPC || WindowsCE || Mobile)
                    UpdateInfo();
#endif
                }
            }
        }

        private void OpenTtFile(string filename)
        {
            if (filename == "Recent Items")
                return;

            bool skip = false;
            try
            {
                TtUtils.ShowWaitCursor();
                _FileName = filename;
                Values.CurrentTtFileName = _FileName;

#if !(PocketPC || WindowsCE || Mobile)
                FileAttributes attributes = File.GetAttributes(_FileName);

                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    attributes = attributes & ~FileAttributes.ReadOnly;

                    File.SetAttributes(_FileName, attributes);
                }
#endif

                if (data != null && data.IsOpen)
                    data.CloseDB();
                data = new DataAccessLayer(_FileName);
                data.OpenDAL();
                Values.CurrentDbVersion = false;
                FileLoaded = true;

                Values.DataExport.FolderName = System.IO.Path.GetFileNameWithoutExtension(_FileName);

                TtUtils.HideWaitCursor();

                try
                {
                    if (data.DalVersion != TwoTrailsSchema.SchemaVersion)
                    {
                        bool closefile = false;

                        if (data.DalVersion < TwoTrailsSchema.SchemaVersion)
                        {
#if !(PocketPC || WindowsCE || Mobile)
                            pnlInfo.Visible = false;
#endif
                            if (MessageBox.Show(String.Format("Old Project Version ({1}). Would you like to upgrade to version {0}?", TwoTrailsSchema.SchemaVersion, data.DalVersion), "Old Project Version", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                UpgradeTtFile(_FileName);
                            }
                            else
                            {
                                closefile = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(
                                String.Format("This project file ({0}) requires a newer version of TwoTrails to open.", 
                                data.DalVersion), "incompatible file", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                            closefile = true;
                        }

                        if (closefile)
                        {
                            if (data != null && data.IsOpen)
                            {
                                data.CloseDB();
                            }

                            FileLoaded = false;
                        }

                        skip = true;
                    }
                    else
                    {
                        Values.CurrentDbVersion = true;

                    #if !(PocketPC || WindowsCE || Mobile)
                        Values.UpdateStatusText(String.Format("File {0} Loaded.", Path.GetFileName(_FileName)));
                        pnlInfo.Visible = true;
                        UpdateInfo(File.GetCreationTime(_FileName));
                        ChangeTitle(System.IO.Path.GetFileName(filename));
                    #else
                        tbTtFileName.Text = System.IO.Path.GetFileName(filename);
                    #endif
                    }
                }
                catch
                {
                    MessageBox.Show("Unable to get Project Version");
                    skip = true;
                }

                if(!skip)
                {
                    tabControl1.SelectedIndex = 1;

                    cboRecOpen.Items.Clear();
                    cboRecOpen.Items.Add(Values.Settings.ProjectOptions.RecOpen[0].File);
                    Values.Settings.ProjectOptions.AddToRecent(filename, data.GetProjectID());

                    foreach (RecentProject rec in Values.Settings.ProjectOptions.RecOpen)
                    {
                        if (rec.Name != "___")
                            cboRecOpen.Items.Add(System.IO.Path.GetFileName(rec.File));
                    }

                    cboRecOpen.SelectedIndex = 0;

                    #if (PocketPC || WindowsCE || Mobile)
                    btnRecOpen.Enabled = true;
                    #endif
                    cboRecOpen.Enabled = true;
                    Values.Settings.WriteProjectSettings();
                    Values.GPSA.LogFilename = Path.Combine(System.IO.Path.GetDirectoryName(filename), "GPS_Log.txt");
                }
            }
            catch (SQLiteException sqlEx)
            {
#if !(PocketPC || WindowsCE || Mobile)
                pnlInfo.Visible = false;
#endif
                switch (sqlEx.ResultCode)
                {
                    case SQLiteErrorCode.NotADb:
                        MessageBox.Show("Database error, not a TwoTrails File");
                        TtUtils.WriteError("SQLiteErrorCode.NotADatabase: Database error, not a TwoTrails File", "MainFormLogic");
                        break;
                    default:
                        MessageBox.Show(sqlEx.Message);
                        break;
                }

                #if (PocketPC || WindowsCE || Mobile)
                tbTtFileName.Text = "";
                #else
                ChangeTitle("");
                #endif
            }
            catch (Exception ex)
            {
#if !(PocketPC || WindowsCE || Mobile)
                pnlInfo.Visible = false;
#endif
                MessageBox.Show(ex.Message);
                #if (PocketPC || WindowsCE || Mobile)
                tbTtFileName.Text = "";
                #else
                ChangeTitle("");
                #endif
            }
            finally
            {
                TtUtils.HideWaitCursor();
            }
        }

        private void UpgradeTtFile(string filename)
        {
            DataAccessLayer oldData = null;

            string oldFile = System.IO.Path.GetDirectoryName(filename) + "\\" + System.IO.Path.GetFileNameWithoutExtension(filename) + ".old.tt2";

            try
            {
#if !(PocketPC || WindowsCE || Mobile)
            tsProg.Value = 0;
            tsProg.Visible = true;
#endif

                FileLoaded = false;

                TtUtils.WriteEvent("Database upgrade started.", true);

                if (data != null && data.IsOpen)
                    data.CloseDB();

                if (File.Exists(oldFile))
                {
                    if (MessageBox.Show(String.Format("File '{0}' already exists. Would you like to overwrite it?", System.IO.Path.GetFileNameWithoutExtension(oldFile)), "", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        File.Delete(oldFile);
                    }
                    else
                    {
                        int count = 2;
                        while (File.Exists(oldFile))
                        {
                            oldFile = System.IO.Path.GetDirectoryName(filename) + "\\" + System.IO.Path.GetFileNameWithoutExtension(filename) + String.Format(".old_{0}.tt2", count);
                            count++;
                        }
                    }
                }

                TtUtils.ShowWaitCursor();

#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusText(String.Format("Upgrading file {0}.", Path.GetFileName(_FileName)));
#endif
                TtUtils.ShowWaitCursor();
                string fileNoPath = System.IO.Path.GetFileName(filename);
                string oldFileNoPath = System.IO.Path.GetFileName(oldFile);

                Application.DoEvents();

#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusProgress();
#endif

                File.Move(filename, oldFile);
                TtUtils.WriteEvent(String.Format("File Renamed: {0} to {1}.", fileNoPath, oldFileNoPath), true);
                oldData = new DataAccessLayer(oldFile);
                oldData.OpenDAL();

#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusProgress();
#endif
                data = NewOpenLogic.NewTwoTrailsFile(filename);
                if (data == null)
                    throw new Exception(String.Format("Failed to create TtFile ", filename));
                data.OpenDAL();

                bool upgraded = data.Upgrade(oldData);
                TtUtils.WriteEvent("Upgrade proccess finished.", true);
                TtUtils.HideWaitCursor();

#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusProgress();
#endif

                if (upgraded)
                {
                    Values.CurrentDbVersion = true;
                    FileLoaded = true;

                    oldData.CloseDB();

                    TtUtils.WriteMessage(String.Format("{0} Upgraded to version {1}.", fileNoPath, TwoTrailsSchema.SchemaVersion));
                    MessageBox.Show("File upgraded successfully.");
                    tabControl1.SelectedIndex = 1;
                    Values.Settings.ProjectOptions.AddToRecent(filename, data.GetProjectID());

#if !(PocketPC || WindowsCE || Mobile)
                    UpdateInfo(File.GetCreationTime(_FileName));
                    Values.UpdateStatusText(String.Format("File {0} Upgraded.", Path.GetFileName(_FileName)));
                    tsProg.Visible = false;
                    ChangeTitle(Path.GetFileName(_FileName));
#else
                    tbTtFileName.Text = Path.GetFileName(_FileName);
#endif
                }
                else
                {
                    if (oldData != null && oldData.IsOpen)
                        oldData.CloseDB();
                    if (data != null && data.IsOpen)
                        data.CloseDB();

                    oldData = null;
                    data = null;

                    GC.Collect();

                    File.Delete(filename);
                    File.Move(oldFile, filename);
                    TtUtils.WriteMessage("File failed to upgrade.");

#if !(PocketPC || WindowsCE || Mobile)
                    tsProg.Value = 0;
#endif

                    MessageBox.Show("File failed to upgrade.");
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MainFormLogic:TtFileUpgrade");
                if (oldData != null && oldData.IsOpen)
                    oldData.CloseDB();
                if (data != null && data.IsOpen)
                    data.CloseDB();

                MessageBox.Show("An error has occured. Please see error log for details.");
#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusText("Upgrade Error.");
#endif
            }
            finally
            {
                TtUtils.HideWaitCursor();

#if !(PocketPC || WindowsCE || Mobile)
            tsProg.Visible = false;
#endif
            }

        }
        #endregion


        #region Settings and Controls

        public void LoadSettings()
        {
            Values.BadDataLimit = 5;
            Values.CurrentDbVersion = false;
            Values.Settings = new SettingsLogic();
            Values.DataExport = new DataOutput();
            //Values.GroupManager = new GroupManager();
            Values.GPSA = new TwoTrails.GpsAccess.GpsAccess();

            

#if !(PocketPC || WindowsCE || Mobile)

            Values.UpdateToolStripStatus = new UpdateToolStripDelegate(UpdateToolStringStatus);
            Values.UpdateToolStripProgress = new UpdateToolStripProgressDelegate(UpdateToolProgressBar);
            Values.UpdateInfo = new UpdateInfoDelegate(UpdateInfo);

            Values.UpdateStatusText("Settings Loaded");
            Values.GPSA.LogFilename = Path.Combine(Directory.GetCurrentDirectory(), "GPS_Log.txt");
#else
            Values.GPSA.LogFilename = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase),
                "GPS_Log.txt");
#endif

            TtUtils.SetLogFileDestination(Values.Settings.LogFilePath);

            if (!Values.Settings.ReadDeviceSettings())
            {
                Values.Settings.WriteDeviceSettings();
            }

            if (!Values.Settings.ReadProjectSettings())
            {
                Values.Settings.WriteProjectSettings();
            }

            #if DEBUG && (PocketPC || WindowsCE || Mobile)
            Values.Settings.DeviceOptions.UseSelection = true;
            #endif


            #region update program based on settings
            if (Values.Settings.DeviceOptions.KeepGpsOn)
            {
                radGpsAlwaysOnNo.Checked = false;
                radGpsAlwaysOnYes.Checked = true;
            }
            else
            {
                radGpsAlwaysOnNo.Checked = true;
                radGpsAlwaysOnYes.Checked = false;
            }

#if !(PocketPC || WindowsCE || Mobile)
            chkChangeGpsOnStart.Checked = Values.Settings.DeviceOptions.GetGpsOnStart;
#endif

            cboRecOpen.Items.Clear();

            cboRecOpen.Items.Add(Values.Settings.ProjectOptions.RecOpen[0].File);

            if (Values.Settings.ProjectOptions.RecOpen.Count > 0)
            {
                foreach (RecentProject rec in Values.Settings.ProjectOptions.RecOpen)
                {
                    if(rec.Name != "___")
                        cboRecOpen.Items.Add(System.IO.Path.GetFileName(rec.File));
                }

                for (int d = 0; d < cboRecOpen.Items.Count; d++)
                {
                    //cboRecOpen.Items[d].Attributes.Add("title", cboRecOpen.Items[d].Text);
                }
            }
            else
            {
                #if (PocketPC || WindowsCE || Mobile)
                btnRecOpen.Enabled = false;
                #endif
                cboRecOpen.Enabled = false;
            }

            #if (PocketPC || WindowsCE || Mobile)
            cboRecOpen.Visible = Values.Settings.DeviceOptions.UseSelection;
            btnRecOpen.Visible = Values.Settings.DeviceOptions.UseSelection;
            #endif


            chkOnKeyboard.Checked = Values.Settings.DeviceOptions.UseOnScreenKeyboard;
            chkUseCombo.Checked = !Values.Settings.DeviceOptions.UseSelection;
            #endregion


            Values.LaserA = new TwoTrails.LaserAccess.LaserAccess();

            #region Init GPS

            DialogResult r;

            if (Values.Settings.DeviceOptions.GpsComPort.ToLower() != "file"  && Values.Settings.DeviceOptions.GpsConfigured)
            {
                Values.GPSA.TestGps(Values.Settings.DeviceOptions.GpsComPort, Values.Settings.DeviceOptions.GpsBaud);

                //wait for gps to load
                System.Threading.Thread.Sleep(1000);

                //if error ask to configure
                if (Values.GPSA.Error != GpsErrorType.NoError)
                {
                    Values.Settings.DeviceOptions.KeepGpsOn = false;
                    radGpsAlwaysOnNo.Checked = true;
                    radGpsAlwaysOnYes.Checked = false;

                    switch (Values.GPSA.Error)
                    {
                        case GpsErrorType.ComNotExist:
                        case GpsErrorType.GpsTimeout:
                        case GpsErrorType.UnknownError:
                        default:
                            {
                                r = MessageBox.Show("An error occured trying to start GPS. Would you like to configure the GPS now?", "Keep GPS On Error", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                                if (r == DialogResult.Yes)
                                {
                                    using (DeviceSetupForm form = new DeviceSetupForm())
                                    {
                                        form.ShowDialog();
                                    }
                                }
                            }
                            break;
                    }
                }
                else
                {
                    //no error
                    Values.Settings.DeviceOptions.GpsConfigured = true;

                    if (!Values.Settings.DeviceOptions.KeepGpsOn)
                    {
                        Values.GPSA.CloseGps();
                    }
                }
            }
#if (PocketPC || WindowsCE || Mobile)
            else if (!Values.Settings.DeviceOptions.GpsConfigured)
            {
                r = MessageBox.Show("The GPS is not configured. Would you like to configure the GPS now?", "Gps not configured.", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    using (DeviceSetupForm form = new DeviceSetupForm())
                    {
                        form.ShowDialog();
                    }
                }
            }
            else   //gps is configured and is a file
            {
                Values.Settings.DeviceOptions.GpsConfigured = true;
            }
#endif
            #endregion

            if (!Program.Filename.IsEmpty())
            {
                OpenTtFile(Program.Filename);
            }
            else
            {
#if DEBUG
            if(Values.Settings.ProjectOptions.RecOpen.Count > 1)
                OpenTtFile(Values.Settings.ProjectOptions.RecOpen[1].File);
#endif
            }

            cboRecOpen.SelectedIndex = 0;
        }

        public void SaveSettings()
        {
            Values.Settings.WriteDeviceSettings();
            Values.Settings.WriteProjectSettings();

#if !(PocketPC || WindowsCE || Mobile)
            Values.UpdateStatusText("Settings Saved");
#endif
        }

        public void radGpsAlwaysOnYes_CheckedChanged2(object sender, EventArgs e)
        {
            if (radGpsAlwaysOnYes.Checked)
                Values.Settings.DeviceOptions.KeepGpsOn = true;
            else
                Values.Settings.DeviceOptions.KeepGpsOn = false;

            SaveSettings();
        }

        public void radGpsAlwaysOnNo_CheckedChanged2(object sender, EventArgs e)
        {
            //handled in radGpsAlwaysOnYes
        }

        public void btnDeviceSetup_Click2(object sender, EventArgs e)
        {
            using (DeviceSetupForm form = new DeviceSetupForm())
            {
                form.ShowDialog();
            }
        }

        public void chkUseCombo_CheckStateChanged2(object sender, EventArgs e)
        {
            if (!_loading)
            {
                Values.Settings.DeviceOptions.UseSelection = !chkUseCombo.Checked;
                Values.Settings.WriteDeviceSettings();
            }

#if (PocketPC || WindowsCE || Mobile)
            cboRecOpen.Visible = !Values.Settings.DeviceOptions.UseSelection;
            btnRecOpen.Visible = Values.Settings.DeviceOptions.UseSelection;
#else
            chkUseCombo.Visible = false;
#endif
        }

        private void btnClear_Click2(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the log files?", "Clear log Files",
                MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                TtUtils.ClearErrorLog();
                AutoClosingMessageBox.Show("Log file Cleared", "TwoTrailsLog", 750);
            }
        }

        private void chkOnKeyboard_CheckStateChanged2(object sender, EventArgs e)
        {
            if (!_loading)
            {
                Values.Settings.DeviceOptions.UseOnScreenKeyboard = chkOnKeyboard.Checked;
                Values.Settings.WriteDeviceSettings();
            }
        }

        private void chkAutoUpdateIndex_CheckStateChanged2(object sender, EventArgs e)
        {
            if (!_loading)
            {
                Values.Settings.DeviceOptions.AutoUpdateIndex = chkAutoUpdateIndex.Checked;
                Values.Settings.WriteDeviceSettings();
            }
        }

        private void btnMassEdit_Click2(object sender, EventArgs e)
        {
            using (MassEditForm form = new MassEditForm(data))
            {

                try
                {
                    if (form.DialogResult != DialogResult.Abort)
                        form.ShowDialog();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    MessageBox.Show(ex.Message);
                }

#if !(PocketPC || WindowsCE || Mobile)
                UpdateInfo();
#endif
            }
        }

        private void btnExportLog_Click2(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
    String.Format("If you are having trouble with your project file please add it to the export error log for debugging. (Would you like to add your project file {0}?)",
    System.IO.Path.GetFileName(_FileName)), "Export", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            
            StringBuilder sb = new StringBuilder();

            if (dr == DialogResult.No)
            {
                //
            }
            else if (dr == DialogResult.Yes)
            {
                sb.Append(_FileName);
            }
            else
                return;

            string _exportTo = Values.Settings.BinDirPath;

#if (PocketPC || WindowsCE || Mobile)
            using (FolderBrowserDialogCF fbd = new FolderBrowserDialogCF(null))
            {
                fbd.Title = "Select Output Location";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    if (fbd.Folder != null && fbd.Folder != "")
                        _exportTo = fbd.Folder;
                }
                else
                    return;
            }
#else
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select Output Location";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    _exportTo = fbd.SelectedPath;
                }
                else
                    return;
            }
            #endif

            TtUtils.ShowWaitCursor();
            if (TtUtils.ExportTtLog(sb.ToString(), _exportTo))
            {
                MessageBox.Show(String.Format("Log Exported to {0}", _exportTo));
            }
            else
                MessageBox.Show(String.Format("Export Log Generation Error. For manual export please go to \"{0}\" for log file.",
                    Values.Settings.LogFilePath));
            TtUtils.HideWaitCursor();
        }

        private void btnExit_Click2(object sender, EventArgs e)
        {
#if !DEBUG
            _closing = true;
#endif
            this.Close();
        }

        private void btnReset_Click2(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to reset all settings to their original defaults. Continue?",
                "Reset Settings", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                == DialogResult.OK)
            {
                try
                {
                    TtUtils.WriteEvent("Reseting Defaults");
                    if(File.Exists(Values.Settings.DeviceSettingsFilePath))
                        File.Delete(Values.Settings.DeviceSettingsFilePath);
                    if (File.Exists(Values.Settings.MetaSettingsFilePath))
                        File.Delete(Values.Settings.MetaSettingsFilePath);
                    if (File.Exists(Values.Settings.ProjectSettingsFilePath))
                        File.Delete(Values.Settings.ProjectSettingsFilePath);
                    if (File.Exists(Values.Settings.DefaultNamingFilePath))
                        File.Delete(Values.Settings.DefaultNamingFilePath);
                    TtUtils.WriteEvent("Defaults Reset");

                    MessageBox.Show("The Defaults have been reset. The program needs to restart in order for the changes to come into effect. Open projects will be saved.",
                        "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);

                    _saveSettings = false;

                    TwoTrails.Program.Reload = true;

                    this.Close();
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "MainForm:btn_Reset");
                }
            }
        }

        private void ChangeTitle(string filename)
        {
            if (filename.IsEmpty())
                this.Text = "TwoTrails V2";
            else
                this.Text = "TwoTrails V2 - " + System.IO.Path.GetFileName(filename);
        }
        #endregion


        #region PC Only
#if !(PocketPC || WindowsCE || Mobile)

        public void UpdateToolStringStatus(string status)
        {
            if (status.Length > 50)
                status = status.Substring(0, 50);

            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.GuiInvoke(() =>
                {
                    tsslStatus.Text = status;
                    statusStrip1.Refresh();
                });
            }
            else
            {
                tsslStatus.Text = status;
                statusStrip1.Refresh();
            }
        }

        public void UpdateToolProgressBar()
        {
            tsProg.Value += 10;
        }

        private void UpdateInfo(DateTime created)
        {
            lblDateCreated.Text = created.ToShortDateString();
            toolTip.SetToolTip(lblDateCreated, String.Format("{0}  {1}",
                created.ToLongDateString(), created.ToLongTimeString()));

            if (_fileloaded)
            {
                lblCreated.Text = data.GetProjectTtStartVersion();
            }

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            if (_fileloaded)
            {
                lblProject.Text = data.GetProjectID();
                lblFile.Text = System.IO.Path.GetFileName(_FileName);
                toolTip.SetToolTip(lblFile, _FileName);
                lblPolygons.Text = data.GetPolyCount().ToString();
                lblPoints.Text = data.GetPointCount().ToString();
                lblGroups.Text = data.GetGroupCount().ToString();
                lblMeta.Text = data.GetMetadataCount().ToString();
                pnlInfo.Visible = true;
            }
            else
            {
                lblProject.Text = String.Empty;
                lblFile.Text = String.Empty;
                toolTip.SetToolTip(lblFile, String.Empty);
                lblPolygons.Text = String.Empty;
                lblPoints.Text = String.Empty;
                lblGroups.Text = String.Empty;
                lblMeta.Text = String.Empty;
                pnlInfo.Visible = false;
            }
        }


        private void btnGroupEdit_Click2(object sender, EventArgs e)
        {
            using (GroupEditForm form = new GroupEditForm(data))
            {
                form.ShowDialog();
                UpdateInfo();
            }
        }

        private void btnGEarth_Click2(object sender, EventArgs e)
        {
            try
            {
                if (TtUtils.IsExtensionsOpenable("kml"))//TtUtils.IsApplictionInstalled("Google Earth") || TtUtils.IsApplictionInstalled("Google Earth Pro"))
                {
                    try
                    {
                        if (!System.IO.Directory.Exists(Values.DataExport.SelectedPath))
                            System.IO.Directory.CreateDirectory(Values.DataExport.SelectedPath);
                        KmlUtilities.KmlDocument doc = Values.DataExport.CreateKmlDoc(data);
                        string file = Values.DataExport.WriteKmzFile(doc);

                        if (System.IO.File.Exists(file))
                        {
                            System.Diagnostics.Process.Start(file);
                        }
                    }
                    catch (Exception ex)
                    {
                        TtUtils.WriteError(ex.Message, "MainFormLogic:GoogleEarth");
                        MessageBox.Show("An Error launching Google Earth has occured. Please see log file for details.");
                    }
                }
                else
                {
                    if (MessageBox.Show("Google Earth is not installed. Would you like to install it now?", "Google Earth Not Found", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start("www.google.com/earth/");
                    }
                }
            }
            catch
            {
                try
                {
                    if (!System.IO.Directory.Exists(Values.DataExport.SelectedPath))
                        System.IO.Directory.CreateDirectory(Values.DataExport.SelectedPath);
                    KmlUtilities.KmlDocument doc = Values.DataExport.CreateKmlDoc(data);
                    string file = Values.DataExport.WriteKmzFile(doc);

                    if (System.IO.File.Exists(file))
                    {
                        System.Diagnostics.Process.Start(file);
                    }
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "MainFormLogic:GoogleEarth");
                    MessageBox.Show("An error has occured. Please see Error log for details.");
                }
            }
        }

        private void btnGMap_Click2(object sender, EventArgs e)
        {
            if (data != null)
            {
                bool chrome = TtUtils.CheckBrowserInstalled("chrome");

                if (chrome || TtUtils.CheckBrowserInstalled("firefox"))
                {
                    string tempFile = System.IO.Path.GetTempPath() + "gmap.html";

                    try
                    {
                        using (TextWriter tw = new StreamWriter(tempFile, false))
                        {
                            tw.WriteLine(TtGMapGenerator.GenerateHtml(data));
                        }
                    }
                    catch (Exception ex)
                    {
                        TtUtils.WriteError(ex.Message, "MainFormLogic:GoogleMaps");
#if !(PocketPC || WindowsCE || Mobile)
                        Values.UpdateStatusText("Map Generation Error");
#endif
                        return;
                    }

                    if (chrome)
                        System.Diagnostics.Process.Start("chrome.exe", tempFile);
                    else
                        System.Diagnostics.Process.Start("firefox.exe", tempFile);


#if !(PocketPC || WindowsCE || Mobile)
                    Values.UpdateStatusText("Map Launched");
#endif
                }
                else
                {
                    if (MessageBox.Show("Google Chrome or Firefox must be installed to use this feature.\nClick Ok to install Google Chrome.", "Incompatible Browser",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start("www.google.com/chrome/browser/");

#if !(PocketPC || WindowsCE || Mobile)
                        Values.UpdateStatusText("Directed to Chrome Install Page");
#endif
                    }
                }
            }
        }

        private void btnMergePolys_Click2(object sender, EventArgs e)
        {
            using (MergePolygonForm form = new MergePolygonForm(data))
            {
                if (form.Setup())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        UpdateInfo();
                }
                else
                {
                    //message failed for some reason 
                }
            }
        }

        private void btnPolyTransform_Click2(object sender, EventArgs e)
        {
            using (PolygonTransformationForm form = new PolygonTransformationForm(data))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }


        private void tsmiDoc_Click2(object sender, EventArgs e)
        {

        }

        private void tsmiTut_Click2(object sender, EventArgs e)
        {

        }

        private void tsmiErrorLog_Click2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", Values.Settings.LogFilePath);
        }

        private void chkChangeGpsOnStart_CheckedChanged2(object sender, EventArgs e)
        {
            if (!_loading)
            {
                Values.Settings.DeviceOptions.GetGpsOnStart = chkChangeGpsOnStart.Checked;
                Values.Settings.WriteDeviceSettings();
            }
        }
#endif
        #endregion
    }

}
