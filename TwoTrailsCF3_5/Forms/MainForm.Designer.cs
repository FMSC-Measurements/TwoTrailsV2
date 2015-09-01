using System.Windows.Forms;
namespace TwoTrails.Forms
{
    partial class MainForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbTtFileName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDup = new System.Windows.Forms.Button();
            this.btnRecOpen = new System.Windows.Forms.Button();
            this.cboRecOpen = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnEditPointTable = new System.Windows.Forms.Button();
            this.btnMeta = new System.Windows.Forms.Button();
            this.buttonProjectInfo = new System.Windows.Forms.Button();
            this.btnPoly = new System.Windows.Forms.Button();
            this.btnPoint = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnWhere = new System.Windows.Forms.Button();
            this.btnHowAmIDoing = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnPlotGrid = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnGPSLogger = new System.Windows.Forms.Button();
            this.btnMassEdit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnEportLog = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.chkAutoUpdateIndex = new System.Windows.Forms.CheckBox();
            this.chkOnKeyboard = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkUseCombo = new System.Windows.Forms.CheckBox();
            this.btnDeviceSetup = new System.Windows.Forms.Button();
            this.radGpsAlwaysOnNo = new System.Windows.Forms.RadioButton();
            this.radGpsAlwaysOnYes = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbTtFileName
            // 
            this.tbTtFileName.Location = new System.Drawing.Point(4, 4);
            this.tbTtFileName.Name = "tbTtFileName";
            this.tbTtFileName.ReadOnly = true;
            this.tbTtFileName.Size = new System.Drawing.Size(233, 21);
            this.tbTtFileName.TabIndex = 4;
            this.tbTtFileName.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 262);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage2.Controls.Add(this.btnNew);
            this.tabPage2.Controls.Add(this.btnDup);
            this.tabPage2.Controls.Add(this.btnRecOpen);
            this.tabPage2.Controls.Add(this.cboRecOpen);
            this.tabPage2.Controls.Add(this.btnExit);
            this.tabPage2.Controls.Add(this.btnImport);
            this.tabPage2.Controls.Add(this.btnOpen);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 239);
            this.tabPage2.Text = "File";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnNew.Location = new System.Drawing.Point(7, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(226, 40);
            this.btnNew.TabIndex = 1;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDup
            // 
            this.btnDup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDup.Location = new System.Drawing.Point(123, 210);
            this.btnDup.Name = "btnDup";
            this.btnDup.Size = new System.Drawing.Size(110, 23);
            this.btnDup.TabIndex = 10;
            this.btnDup.TabStop = false;
            this.btnDup.Text = "Duplicate";
            this.btnDup.Click += new System.EventHandler(this.btnDup_Click);
            // 
            // btnRecOpen
            // 
            this.btnRecOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecOpen.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnRecOpen.Location = new System.Drawing.Point(7, 92);
            this.btnRecOpen.Name = "btnRecOpen";
            this.btnRecOpen.Size = new System.Drawing.Size(226, 40);
            this.btnRecOpen.TabIndex = 9;
            this.btnRecOpen.TabStop = false;
            this.btnRecOpen.Text = "Opened Recently";
            this.btnRecOpen.Click += new System.EventHandler(this.btnRecOpen_Click);
            // 
            // cboRecOpen
            // 
            this.cboRecOpen.Location = new System.Drawing.Point(7, 92);
            this.cboRecOpen.Name = "cboRecOpen";
            this.cboRecOpen.Size = new System.Drawing.Size(226, 22);
            this.cboRecOpen.TabIndex = 8;
            this.cboRecOpen.TabStop = false;
            this.cboRecOpen.SelectedIndexChanged += new System.EventHandler(this.cboRecOpen_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(7, 210);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnImport.Location = new System.Drawing.Point(7, 138);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(226, 40);
            this.btnImport.TabIndex = 2;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnOpen.Location = new System.Drawing.Point(7, 46);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(226, 40);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.TabStop = false;
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage1.Controls.Add(this.btnEditPointTable);
            this.tabPage1.Controls.Add(this.btnMeta);
            this.tabPage1.Controls.Add(this.buttonProjectInfo);
            this.tabPage1.Controls.Add(this.btnPoly);
            this.tabPage1.Controls.Add(this.btnPoint);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(232, 236);
            this.tabPage1.Text = "Data";
            // 
            // btnEditPointTable
            // 
            this.btnEditPointTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPointTable.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnEditPointTable.Location = new System.Drawing.Point(7, 184);
            this.btnEditPointTable.Name = "btnEditPointTable";
            this.btnEditPointTable.Size = new System.Drawing.Size(218, 40);
            this.btnEditPointTable.TabIndex = 3;
            this.btnEditPointTable.TabStop = false;
            this.btnEditPointTable.Text = "Table Edit";
            this.btnEditPointTable.Click += new System.EventHandler(this.btnEditPointTable_Click);
            // 
            // btnMeta
            // 
            this.btnMeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMeta.Enabled = false;
            this.btnMeta.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnMeta.Location = new System.Drawing.Point(7, 92);
            this.btnMeta.Name = "btnMeta";
            this.btnMeta.Size = new System.Drawing.Size(218, 40);
            this.btnMeta.TabIndex = 2;
            this.btnMeta.TabStop = false;
            this.btnMeta.Text = "Metadata Edit";
            this.btnMeta.Click += new System.EventHandler(this.btnMeta_Click);
            // 
            // buttonProjectInfo
            // 
            this.buttonProjectInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProjectInfo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.buttonProjectInfo.Location = new System.Drawing.Point(7, 138);
            this.buttonProjectInfo.Name = "buttonProjectInfo";
            this.buttonProjectInfo.Size = new System.Drawing.Size(218, 40);
            this.buttonProjectInfo.TabIndex = 2;
            this.buttonProjectInfo.TabStop = false;
            this.buttonProjectInfo.Text = "Project Info";
            this.buttonProjectInfo.Click += new System.EventHandler(this.buttonProjectInfo_Click);
            // 
            // btnPoly
            // 
            this.btnPoly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPoly.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnPoly.Location = new System.Drawing.Point(7, 46);
            this.btnPoly.Name = "btnPoly";
            this.btnPoly.Size = new System.Drawing.Size(218, 40);
            this.btnPoly.TabIndex = 1;
            this.btnPoly.TabStop = false;
            this.btnPoly.Text = "Polygon Edit";
            this.btnPoly.Click += new System.EventHandler(this.btnPoly_Click);
            // 
            // btnPoint
            // 
            this.btnPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPoint.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnPoint.Location = new System.Drawing.Point(7, 0);
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(218, 40);
            this.btnPoint.TabIndex = 0;
            this.btnPoint.TabStop = false;
            this.btnPoint.Text = "Point Edit";
            this.btnPoint.Click += new System.EventHandler(this.btnPoint_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage3.Controls.Add(this.btnWhere);
            this.tabPage3.Controls.Add(this.btnHowAmIDoing);
            this.tabPage3.Controls.Add(this.btnMap);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(232, 236);
            this.tabPage3.Text = "Tools";
            // 
            // btnWhere
            // 
            this.btnWhere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWhere.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnWhere.Location = new System.Drawing.Point(7, 92);
            this.btnWhere.Name = "btnWhere";
            this.btnWhere.Size = new System.Drawing.Size(218, 40);
            this.btnWhere.TabIndex = 6;
            this.btnWhere.TabStop = false;
            this.btnWhere.Text = "Where Is";
            this.btnWhere.Click += new System.EventHandler(this.btnWhere_Click);
            // 
            // btnHowAmIDoing
            // 
            this.btnHowAmIDoing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHowAmIDoing.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnHowAmIDoing.Location = new System.Drawing.Point(7, 46);
            this.btnHowAmIDoing.Name = "btnHowAmIDoing";
            this.btnHowAmIDoing.Size = new System.Drawing.Size(218, 40);
            this.btnHowAmIDoing.TabIndex = 2;
            this.btnHowAmIDoing.TabStop = false;
            this.btnHowAmIDoing.Text = "How am I doing?";
            this.btnHowAmIDoing.Click += new System.EventHandler(this.btnHowAmIDoing_Click);
            // 
            // btnMap
            // 
            this.btnMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMap.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnMap.Location = new System.Drawing.Point(7, 0);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(218, 40);
            this.btnMap.TabIndex = 1;
            this.btnMap.TabStop = false;
            this.btnMap.Text = "Draw Map";
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage4.Controls.Add(this.btnPlotGrid);
            this.tabPage4.Controls.Add(this.btnRename);
            this.tabPage4.Controls.Add(this.btnGPSLogger);
            this.tabPage4.Controls.Add(this.btnMassEdit);
            this.tabPage4.Controls.Add(this.btnExport);
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(232, 236);
            this.tabPage4.Text = "Tools 2";
            // 
            // btnPlotGrid
            // 
            this.btnPlotGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlotGrid.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnPlotGrid.Location = new System.Drawing.Point(7, 92);
            this.btnPlotGrid.Name = "btnPlotGrid";
            this.btnPlotGrid.Size = new System.Drawing.Size(218, 40);
            this.btnPlotGrid.TabIndex = 9;
            this.btnPlotGrid.TabStop = false;
            this.btnPlotGrid.Text = "Plot Grid";
            this.btnPlotGrid.Click += new System.EventHandler(this.btnPlotGrid_Click);
            // 
            // btnRename
            // 
            this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRename.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnRename.Location = new System.Drawing.Point(7, 46);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(218, 40);
            this.btnRename.TabIndex = 8;
            this.btnRename.TabStop = false;
            this.btnRename.Text = "Rename Points";
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnGPSLogger
            // 
            this.btnGPSLogger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGPSLogger.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnGPSLogger.Location = new System.Drawing.Point(7, 184);
            this.btnGPSLogger.Name = "btnGPSLogger";
            this.btnGPSLogger.Size = new System.Drawing.Size(218, 40);
            this.btnGPSLogger.TabIndex = 4;
            this.btnGPSLogger.TabStop = false;
            this.btnGPSLogger.Text = "GPS Logger";
            this.btnGPSLogger.Click += new System.EventHandler(this.btnGPSLogger_Click);
            // 
            // btnMassEdit
            // 
            this.btnMassEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMassEdit.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnMassEdit.Location = new System.Drawing.Point(7, 138);
            this.btnMassEdit.Name = "btnMassEdit";
            this.btnMassEdit.Size = new System.Drawing.Size(218, 40);
            this.btnMassEdit.TabIndex = 4;
            this.btnMassEdit.TabStop = false;
            this.btnMassEdit.Text = "Multi Point Edit";
            this.btnMassEdit.Click += new System.EventHandler(this.btnMassEdit_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnExport.Location = new System.Drawing.Point(7, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(218, 40);
            this.btnExport.TabIndex = 0;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage5.Controls.Add(this.btnReset);
            this.tabPage5.Controls.Add(this.btnEportLog);
            this.tabPage5.Controls.Add(this.btnInfo);
            this.tabPage5.Controls.Add(this.chkAutoUpdateIndex);
            this.tabPage5.Controls.Add(this.chkOnKeyboard);
            this.tabPage5.Controls.Add(this.btnClear);
            this.tabPage5.Controls.Add(this.chkUseCombo);
            this.tabPage5.Controls.Add(this.btnDeviceSetup);
            this.tabPage5.Controls.Add(this.radGpsAlwaysOnNo);
            this.tabPage5.Controls.Add(this.radGpsAlwaysOnYes);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Location = new System.Drawing.Point(0, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(240, 239);
            this.tabPage5.Text = "Settings";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.Location = new System.Drawing.Point(3, 167);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(70, 40);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Reset Defaults";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnEportLog
            // 
            this.btnEportLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEportLog.Location = new System.Drawing.Point(79, 213);
            this.btnEportLog.Name = "btnEportLog";
            this.btnEportLog.Size = new System.Drawing.Size(82, 20);
            this.btnEportLog.TabIndex = 15;
            this.btnEportLog.TabStop = false;
            this.btnEportLog.Text = "Export Log";
            this.btnEportLog.Click += new System.EventHandler(this.btnEportLog_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInfo.Location = new System.Drawing.Point(3, 213);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(70, 20);
            this.btnInfo.TabIndex = 15;
            this.btnInfo.TabStop = false;
            this.btnInfo.Text = "Info";
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // chkAutoUpdateIndex
            // 
            this.chkAutoUpdateIndex.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkAutoUpdateIndex.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkAutoUpdateIndex.Location = new System.Drawing.Point(3, 116);
            this.chkAutoUpdateIndex.Name = "chkAutoUpdateIndex";
            this.chkAutoUpdateIndex.Size = new System.Drawing.Size(173, 20);
            this.chkAutoUpdateIndex.TabIndex = 13;
            this.chkAutoUpdateIndex.TabStop = false;
            this.chkAutoUpdateIndex.Tag = "Updates the indexes of points in a polygon on save in Point Edit.";
            this.chkAutoUpdateIndex.Text = "Auto Index Update";
            this.chkAutoUpdateIndex.CheckStateChanged += new System.EventHandler(this.chkAutoUpdateIndex_CheckStateChanged);
            // 
            // chkOnKeyboard
            // 
            this.chkOnKeyboard.Checked = true;
            this.chkOnKeyboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnKeyboard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkOnKeyboard.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOnKeyboard.Location = new System.Drawing.Point(3, 64);
            this.chkOnKeyboard.Name = "chkOnKeyboard";
            this.chkOnKeyboard.Size = new System.Drawing.Size(189, 20);
            this.chkOnKeyboard.TabIndex = 11;
            this.chkOnKeyboard.TabStop = false;
            this.chkOnKeyboard.Text = "Use OnScreen Keyboard";
            this.chkOnKeyboard.CheckStateChanged += new System.EventHandler(this.chkOnKeyboard_CheckStateChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(167, 213);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 20);
            this.btnClear.TabIndex = 9;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear Logs";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkUseCombo
            // 
            this.chkUseCombo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkUseCombo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUseCombo.Location = new System.Drawing.Point(3, 90);
            this.chkUseCombo.Name = "chkUseCombo";
            this.chkUseCombo.Size = new System.Drawing.Size(159, 20);
            this.chkUseCombo.TabIndex = 7;
            this.chkUseCombo.TabStop = false;
            this.chkUseCombo.Text = "Use ComboBoxes";
            this.chkUseCombo.CheckStateChanged += new System.EventHandler(this.chkUseCombo_CheckStateChanged);
            // 
            // btnDeviceSetup
            // 
            this.btnDeviceSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeviceSetup.Location = new System.Drawing.Point(3, 23);
            this.btnDeviceSetup.Name = "btnDeviceSetup";
            this.btnDeviceSetup.Size = new System.Drawing.Size(234, 25);
            this.btnDeviceSetup.TabIndex = 5;
            this.btnDeviceSetup.TabStop = false;
            this.btnDeviceSetup.Tag = "Setup Page For GPS and Laser Settings";
            this.btnDeviceSetup.Text = "GPS and Laser Connections";
            this.btnDeviceSetup.Click += new System.EventHandler(this.btnDeviceSetup_Click);
            // 
            // radGpsAlwaysOnNo
            // 
            this.radGpsAlwaysOnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radGpsAlwaysOnNo.Checked = true;
            this.radGpsAlwaysOnNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radGpsAlwaysOnNo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radGpsAlwaysOnNo.Location = new System.Drawing.Point(187, 0);
            this.radGpsAlwaysOnNo.Name = "radGpsAlwaysOnNo";
            this.radGpsAlwaysOnNo.Size = new System.Drawing.Size(46, 20);
            this.radGpsAlwaysOnNo.TabIndex = 4;
            this.radGpsAlwaysOnNo.TabStop = false;
            this.radGpsAlwaysOnNo.Text = "No";
            this.radGpsAlwaysOnNo.CheckedChanged += new System.EventHandler(this.radGpsAlwaysOnNo_CheckedChanged);
            // 
            // radGpsAlwaysOnYes
            // 
            this.radGpsAlwaysOnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radGpsAlwaysOnYes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radGpsAlwaysOnYes.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radGpsAlwaysOnYes.Location = new System.Drawing.Point(137, 0);
            this.radGpsAlwaysOnYes.Name = "radGpsAlwaysOnYes";
            this.radGpsAlwaysOnYes.Size = new System.Drawing.Size(55, 20);
            this.radGpsAlwaysOnYes.TabIndex = 3;
            this.radGpsAlwaysOnYes.TabStop = false;
            this.radGpsAlwaysOnYes.Text = "Yes";
            this.radGpsAlwaysOnYes.CheckedChanged += new System.EventHandler(this.radGpsAlwaysOnYes_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(6, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.Text = "GPS Always On:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "TwoTrails File|*.tt2";
            this.openFileDialog1.FilterIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbTtFileName);
            this.Name = "MainForm";
            this.Text = "TwoTrails 2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.tbTtFileName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDup = new System.Windows.Forms.Button();
            this.btnRecOpen = new System.Windows.Forms.Button();
            this.cboRecOpen = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnEditPointTable = new System.Windows.Forms.Button();
            this.btnMeta = new System.Windows.Forms.Button();
            this.buttonProjectInfo = new System.Windows.Forms.Button();
            this.btnPoly = new System.Windows.Forms.Button();
            this.btnPoint = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnWhere = new System.Windows.Forms.Button();
            this.btnHowAmIDoing = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnPlotGrid = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnGPSLogger = new System.Windows.Forms.Button();
            this.btnMassEdit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnEportLog = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.chkAutoUpdateIndex = new System.Windows.Forms.CheckBox();
            this.chkOnKeyboard = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkUseCombo = new System.Windows.Forms.CheckBox();
            this.btnDeviceSetup = new System.Windows.Forms.Button();
            this.radGpsAlwaysOnNo = new System.Windows.Forms.RadioButton();
            this.radGpsAlwaysOnYes = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbTtFileName
            // 
            this.tbTtFileName.Location = new System.Drawing.Point(4, 4);
            this.tbTtFileName.Name = "tbTtFileName";
            this.tbTtFileName.ReadOnly = true;
            this.tbTtFileName.Size = new System.Drawing.Size(313, 21);
            this.tbTtFileName.TabIndex = 4;
            this.tbTtFileName.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(320, 182);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage2.Controls.Add(this.btnNew);
            this.tabPage2.Controls.Add(this.btnDup);
            this.tabPage2.Controls.Add(this.btnRecOpen);
            this.tabPage2.Controls.Add(this.cboRecOpen);
            this.tabPage2.Controls.Add(this.btnExit);
            this.tabPage2.Controls.Add(this.btnImport);
            this.tabPage2.Controls.Add(this.btnOpen);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(320, 159);
            this.tabPage2.Text = "File";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnNew.Location = new System.Drawing.Point(4, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(155, 40);
            this.btnNew.TabIndex = 1;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDup
            // 
            this.btnDup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDup.Location = new System.Drawing.Point(203, 130);
            this.btnDup.Name = "btnDup";
            this.btnDup.Size = new System.Drawing.Size(110, 23);
            this.btnDup.TabIndex = 10;
            this.btnDup.TabStop = false;
            this.btnDup.Text = "Duplicate";
            this.btnDup.Click += new System.EventHandler(this.btnDup_Click);
            // 
            // btnRecOpen
            // 
            this.btnRecOpen.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnRecOpen.Location = new System.Drawing.Point(4, 46);
            this.btnRecOpen.Name = "btnRecOpen";
            this.btnRecOpen.Size = new System.Drawing.Size(155, 40);
            this.btnRecOpen.TabIndex = 9;
            this.btnRecOpen.TabStop = false;
            this.btnRecOpen.Text = "Recent";
            this.btnRecOpen.Click += new System.EventHandler(this.btnRecOpen_Click);
            // 
            // cboRecOpen
            // 
            this.cboRecOpen.Location = new System.Drawing.Point(4, 64);
            this.cboRecOpen.Name = "cboRecOpen";
            this.cboRecOpen.Size = new System.Drawing.Size(155, 22);
            this.cboRecOpen.TabIndex = 8;
            this.cboRecOpen.TabStop = false;
            this.cboRecOpen.SelectedIndexChanged += new System.EventHandler(this.cboRecOpen_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(7, 130);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnImport.Location = new System.Drawing.Point(162, 46);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(155, 40);
            this.btnImport.TabIndex = 2;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnOpen.Location = new System.Drawing.Point(162, 0);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(155, 40);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.TabStop = false;
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage1.Controls.Add(this.btnEditPointTable);
            this.tabPage1.Controls.Add(this.btnMeta);
            this.tabPage1.Controls.Add(this.buttonProjectInfo);
            this.tabPage1.Controls.Add(this.btnPoly);
            this.tabPage1.Controls.Add(this.btnPoint);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(320, 159);
            this.tabPage1.Text = "Data";
            // 
            // btnEditPointTable
            // 
            this.btnEditPointTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPointTable.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnEditPointTable.Location = new System.Drawing.Point(162, 92);
            this.btnEditPointTable.Name = "btnEditPointTable";
            this.btnEditPointTable.Size = new System.Drawing.Size(155, 40);
            this.btnEditPointTable.TabIndex = 3;
            this.btnEditPointTable.TabStop = false;
            this.btnEditPointTable.Text = "Table Edit";
            this.btnEditPointTable.Click += new System.EventHandler(this.btnEditPointTable_Click);
            // 
            // btnMeta
            // 
            this.btnMeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMeta.Enabled = false;
            this.btnMeta.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnMeta.Location = new System.Drawing.Point(162, 46);
            this.btnMeta.Name = "btnMeta";
            this.btnMeta.Size = new System.Drawing.Size(155, 40);
            this.btnMeta.TabIndex = 2;
            this.btnMeta.TabStop = false;
            this.btnMeta.Text = "Metadata Edit";
            this.btnMeta.Click += new System.EventHandler(this.btnMeta_Click);
            // 
            // buttonProjectInfo
            // 
            this.buttonProjectInfo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.buttonProjectInfo.Location = new System.Drawing.Point(4, 92);
            this.buttonProjectInfo.Name = "buttonProjectInfo";
            this.buttonProjectInfo.Size = new System.Drawing.Size(155, 40);
            this.buttonProjectInfo.TabIndex = 2;
            this.buttonProjectInfo.TabStop = false;
            this.buttonProjectInfo.Text = "Project Info";
            this.buttonProjectInfo.Click += new System.EventHandler(this.buttonProjectInfo_Click);
            // 
            // btnPoly
            // 
            this.btnPoly.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnPoly.Location = new System.Drawing.Point(4, 46);
            this.btnPoly.Name = "btnPoly";
            this.btnPoly.Size = new System.Drawing.Size(155, 40);
            this.btnPoly.TabIndex = 1;
            this.btnPoly.TabStop = false;
            this.btnPoly.Text = "Polygon Edit";
            this.btnPoly.Click += new System.EventHandler(this.btnPoly_Click);
            // 
            // btnPoint
            // 
            this.btnPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPoint.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnPoint.Location = new System.Drawing.Point(4, 0);
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(313, 40);
            this.btnPoint.TabIndex = 0;
            this.btnPoint.TabStop = false;
            this.btnPoint.Text = "Point Edit";
            this.btnPoint.Click += new System.EventHandler(this.btnPoint_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage3.Controls.Add(this.btnWhere);
            this.tabPage3.Controls.Add(this.btnHowAmIDoing);
            this.tabPage3.Controls.Add(this.btnMap);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(320, 159);
            this.tabPage3.Text = "Tools";
            // 
            // btnWhere
            // 
            this.btnWhere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWhere.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnWhere.Location = new System.Drawing.Point(4, 92);
            this.btnWhere.Name = "btnWhere";
            this.btnWhere.Size = new System.Drawing.Size(313, 40);
            this.btnWhere.TabIndex = 6;
            this.btnWhere.TabStop = false;
            this.btnWhere.Text = "Where Is";
            this.btnWhere.Click += new System.EventHandler(this.btnWhere_Click);
            // 
            // btnHowAmIDoing
            // 
            this.btnHowAmIDoing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHowAmIDoing.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnHowAmIDoing.Location = new System.Drawing.Point(4, 46);
            this.btnHowAmIDoing.Name = "btnHowAmIDoing";
            this.btnHowAmIDoing.Size = new System.Drawing.Size(313, 40);
            this.btnHowAmIDoing.TabIndex = 2;
            this.btnHowAmIDoing.TabStop = false;
            this.btnHowAmIDoing.Text = "How am I doing?";
            this.btnHowAmIDoing.Click += new System.EventHandler(this.btnHowAmIDoing_Click);
            // 
            // btnMap
            // 
            this.btnMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMap.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnMap.Location = new System.Drawing.Point(4, 0);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(313, 40);
            this.btnMap.TabIndex = 1;
            this.btnMap.TabStop = false;
            this.btnMap.Text = "Draw Map";
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage4.Controls.Add(this.btnPlotGrid);
            this.tabPage4.Controls.Add(this.btnRename);
            this.tabPage4.Controls.Add(this.btnGPSLogger);
            this.tabPage4.Controls.Add(this.btnMassEdit);
            this.tabPage4.Controls.Add(this.btnExport);
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(320, 159);
            this.tabPage4.Text = "Tools 2";
            // 
            // btnPlotGrid
            // 
            this.btnPlotGrid.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnPlotGrid.Location = new System.Drawing.Point(4, 46);
            this.btnPlotGrid.Name = "btnPlotGrid";
            this.btnPlotGrid.Size = new System.Drawing.Size(155, 40);
            this.btnPlotGrid.TabIndex = 9;
            this.btnPlotGrid.TabStop = false;
            this.btnPlotGrid.Text = "Plot Grid";
            this.btnPlotGrid.Click += new System.EventHandler(this.btnPlotGrid_Click);
            // 
            // btnRename
            // 
            this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRename.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnRename.Location = new System.Drawing.Point(162, 0);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(155, 40);
            this.btnRename.TabIndex = 8;
            this.btnRename.TabStop = false;
            this.btnRename.Text = "Rename Points";
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnGPSLogger
            // 
            this.btnGPSLogger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGPSLogger.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnGPSLogger.Location = new System.Drawing.Point(4, 92);
            this.btnGPSLogger.Name = "btnGPSLogger";
            this.btnGPSLogger.Size = new System.Drawing.Size(313, 40);
            this.btnGPSLogger.TabIndex = 4;
            this.btnGPSLogger.TabStop = false;
            this.btnGPSLogger.Text = "GPS Logger";
            this.btnGPSLogger.Click += new System.EventHandler(this.btnGPSLogger_Click);
            // 
            // btnMassEdit
            // 
            this.btnMassEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMassEdit.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnMassEdit.Location = new System.Drawing.Point(162, 46);
            this.btnMassEdit.Name = "btnMassEdit";
            this.btnMassEdit.Size = new System.Drawing.Size(155, 40);
            this.btnMassEdit.TabIndex = 4;
            this.btnMassEdit.TabStop = false;
            this.btnMassEdit.Text = "Multi Point Edit";
            this.btnMassEdit.Click += new System.EventHandler(this.btnMassEdit_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnExport.Location = new System.Drawing.Point(4, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(155, 40);
            this.btnExport.TabIndex = 0;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage5.Controls.Add(this.btnReset);
            this.tabPage5.Controls.Add(this.btnEportLog);
            this.tabPage5.Controls.Add(this.btnInfo);
            this.tabPage5.Controls.Add(this.chkAutoUpdateIndex);
            this.tabPage5.Controls.Add(this.chkOnKeyboard);
            this.tabPage5.Controls.Add(this.btnClear);
            this.tabPage5.Controls.Add(this.chkUseCombo);
            this.tabPage5.Controls.Add(this.btnDeviceSetup);
            this.tabPage5.Controls.Add(this.radGpsAlwaysOnNo);
            this.tabPage5.Controls.Add(this.radGpsAlwaysOnYes);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Location = new System.Drawing.Point(0, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(320, 159);
            this.tabPage5.Text = "Settings";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(247, 87);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(70, 40);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Reset Defaults";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnEportLog
            // 
            this.btnEportLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEportLog.Location = new System.Drawing.Point(79, 133);
            this.btnEportLog.Name = "btnEportLog";
            this.btnEportLog.Size = new System.Drawing.Size(162, 20);
            this.btnEportLog.TabIndex = 15;
            this.btnEportLog.TabStop = false;
            this.btnEportLog.Text = "Export Log";
            this.btnEportLog.Click += new System.EventHandler(this.btnEportLog_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInfo.Location = new System.Drawing.Point(3, 133);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(70, 20);
            this.btnInfo.TabIndex = 15;
            this.btnInfo.TabStop = false;
            this.btnInfo.Text = "Info";
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // chkAutoUpdateIndex
            // 
            this.chkAutoUpdateIndex.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkAutoUpdateIndex.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkAutoUpdateIndex.Location = new System.Drawing.Point(3, 106);
            this.chkAutoUpdateIndex.Name = "chkAutoUpdateIndex";
            this.chkAutoUpdateIndex.Size = new System.Drawing.Size(173, 20);
            this.chkAutoUpdateIndex.TabIndex = 13;
            this.chkAutoUpdateIndex.TabStop = false;
            this.chkAutoUpdateIndex.Tag = "Updates the indexes of points in a polygon on save in Point Edit.";
            this.chkAutoUpdateIndex.Text = "Auto Index Update";
            this.chkAutoUpdateIndex.CheckStateChanged += new System.EventHandler(this.chkAutoUpdateIndex_CheckStateChanged);
            // 
            // chkOnKeyboard
            // 
            this.chkOnKeyboard.Checked = true;
            this.chkOnKeyboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnKeyboard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkOnKeyboard.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOnKeyboard.Location = new System.Drawing.Point(3, 54);
            this.chkOnKeyboard.Name = "chkOnKeyboard";
            this.chkOnKeyboard.Size = new System.Drawing.Size(189, 20);
            this.chkOnKeyboard.TabIndex = 11;
            this.chkOnKeyboard.TabStop = false;
            this.chkOnKeyboard.Text = "Use OnScreen Keyboard";
            this.chkOnKeyboard.CheckStateChanged += new System.EventHandler(this.chkOnKeyboard_CheckStateChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(247, 133);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 20);
            this.btnClear.TabIndex = 9;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear Logs";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkUseCombo
            // 
            this.chkUseCombo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkUseCombo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUseCombo.Location = new System.Drawing.Point(3, 80);
            this.chkUseCombo.Name = "chkUseCombo";
            this.chkUseCombo.Size = new System.Drawing.Size(159, 20);
            this.chkUseCombo.TabIndex = 7;
            this.chkUseCombo.TabStop = false;
            this.chkUseCombo.Text = "Use ComboBoxes";
            this.chkUseCombo.CheckStateChanged += new System.EventHandler(this.chkUseCombo_CheckStateChanged);
            // 
            // btnDeviceSetup
            // 
            this.btnDeviceSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeviceSetup.Location = new System.Drawing.Point(3, 23);
            this.btnDeviceSetup.Name = "btnDeviceSetup";
            this.btnDeviceSetup.Size = new System.Drawing.Size(314, 25);
            this.btnDeviceSetup.TabIndex = 5;
            this.btnDeviceSetup.TabStop = false;
            this.btnDeviceSetup.Tag = "Setup Page For Gps and Laser Settings";
            this.btnDeviceSetup.Text = "Gps and Laser Connections";
            this.btnDeviceSetup.Click += new System.EventHandler(this.btnDeviceSetup_Click);
            // 
            // radGpsAlwaysOnNo
            // 
            this.radGpsAlwaysOnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radGpsAlwaysOnNo.Checked = true;
            this.radGpsAlwaysOnNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radGpsAlwaysOnNo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radGpsAlwaysOnNo.Location = new System.Drawing.Point(267, 0);
            this.radGpsAlwaysOnNo.Name = "radGpsAlwaysOnNo";
            this.radGpsAlwaysOnNo.Size = new System.Drawing.Size(46, 20);
            this.radGpsAlwaysOnNo.TabIndex = 4;
            this.radGpsAlwaysOnNo.TabStop = false;
            this.radGpsAlwaysOnNo.Text = "No";
            this.radGpsAlwaysOnNo.CheckedChanged += new System.EventHandler(this.radGpsAlwaysOnNo_CheckedChanged);
            // 
            // radGpsAlwaysOnYes
            // 
            this.radGpsAlwaysOnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radGpsAlwaysOnYes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radGpsAlwaysOnYes.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radGpsAlwaysOnYes.Location = new System.Drawing.Point(217, 0);
            this.radGpsAlwaysOnYes.Name = "radGpsAlwaysOnYes";
            this.radGpsAlwaysOnYes.Size = new System.Drawing.Size(55, 20);
            this.radGpsAlwaysOnYes.TabIndex = 3;
            this.radGpsAlwaysOnYes.TabStop = false;
            this.radGpsAlwaysOnYes.Text = "Yes";
            this.radGpsAlwaysOnYes.CheckedChanged += new System.EventHandler(this.radGpsAlwaysOnYes_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(6, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.Text = "GPS Always On:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "TwoTrails File|*.tt2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbTtFileName);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "TwoTrails 2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion



        private System.Windows.Forms.TextBox tbTtFileName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ComboBox cboRecOpen;
        private TabPage tabPage5;
        private Label label1;
        private RadioButton radGpsAlwaysOnNo;
        private RadioButton radGpsAlwaysOnYes;
        private Button btnDeviceSetup;
        private CheckBox chkUseCombo;
        private Button btnRecOpen;
        private Button btnClear;
        private CheckBox chkOnKeyboard;
        private CheckBox chkAutoUpdateIndex;
        private Button btnInfo;
        private Button btnDup;
        private Button btnEportLog;
        private Button btnReset;
        private Button btnMassEdit;
        private Button btnHowAmIDoing;
        private Button btnWhere;
        private Button buttonProjectInfo;
        private Button btnMeta;
        private Button btnEditPointTable;
        private Button btnPoint;
        private Button btnPoly;
        private Button btnPlotGrid;
        private Button btnRename;
        private Button btnGPSLogger;




    }
}

