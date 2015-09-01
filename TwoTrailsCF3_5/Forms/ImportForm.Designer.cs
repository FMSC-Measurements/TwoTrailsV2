namespace TwoTrails.Forms
{
    partial class ImportForm
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
            this.ofD = new System.Windows.Forms.OpenFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabText = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkTxtElev = new System.Windows.Forms.CheckBox();
            this.radTxtElevMeters = new System.Windows.Forms.RadioButton();
            this.chkTxtIndex = new System.Windows.Forms.CheckBox();
            this.radTxtElevFeet = new System.Windows.Forms.RadioButton();
            this.chkTxtPID = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTxtMultiPoly = new System.Windows.Forms.CheckBox();
            this.radTxtUTM = new System.Windows.Forms.RadioButton();
            this.radTxtLatLng = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabTwoTrails2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.chkTt2Nmea = new System.Windows.Forms.CheckBox();
            this.chkTt2Groups = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabText.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabTwoTrails2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofD
            // 
            this.ofD.Filter = "Files|*.shp,*.txt,*.csv,*.tt,*.tt2,*kml|Shape File|*.shp|Text File|*.txt,*.csv|Tw" +
                "oTrails File|*.tt,*.tt2|Google Earth File|*.kml";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(165, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(72, 21);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.TabStop = false;
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(3, 3);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(234, 21);
            this.txtFile.TabIndex = 1;
            this.txtFile.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(167, 266);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(70, 25);
            this.btnImport.TabIndex = 4;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(79, 266);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(82, 25);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "Help";
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabText);
            this.tabControl.Controls.Add(this.tabTwoTrails2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl.Location = new System.Drawing.Point(0, 30);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 230);
            this.tabControl.TabIndex = 5;
            // 
            // tabText
            // 
            this.tabText.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabText.Controls.Add(this.panel1);
            this.tabText.Controls.Add(this.radTxtUTM);
            this.tabText.Controls.Add(this.radTxtLatLng);
            this.tabText.Controls.Add(this.label1);
            this.tabText.Location = new System.Drawing.Point(0, 0);
            this.tabText.Name = "tabText";
            this.tabText.Size = new System.Drawing.Size(240, 207);
            this.tabText.Text = "Text - CSV";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.chkTxtElev);
            this.panel1.Controls.Add(this.radTxtElevMeters);
            this.panel1.Controls.Add(this.chkTxtIndex);
            this.panel1.Controls.Add(this.radTxtElevFeet);
            this.panel1.Controls.Add(this.chkTxtPID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkTxtMultiPoly);
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 178);
            // 
            // chkTxtElev
            // 
            this.chkTxtElev.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkTxtElev.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTxtElev.Location = new System.Drawing.Point(8, 100);
            this.chkTxtElev.Name = "chkTxtElev";
            this.chkTxtElev.Size = new System.Drawing.Size(100, 20);
            this.chkTxtElev.TabIndex = 0;
            this.chkTxtElev.TabStop = false;
            this.chkTxtElev.Text = "Elevation";
            this.chkTxtElev.CheckStateChanged += new System.EventHandler(this.chkTxtElev_CheckStateChanged);
            // 
            // radTxtElevMeters
            // 
            this.radTxtElevMeters.Enabled = false;
            this.radTxtElevMeters.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radTxtElevMeters.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radTxtElevMeters.Location = new System.Drawing.Point(79, 126);
            this.radTxtElevMeters.Name = "radTxtElevMeters";
            this.radTxtElevMeters.Size = new System.Drawing.Size(66, 20);
            this.radTxtElevMeters.TabIndex = 0;
            this.radTxtElevMeters.TabStop = false;
            this.radTxtElevMeters.Text = "Meters";
            // 
            // chkTxtIndex
            // 
            this.chkTxtIndex.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkTxtIndex.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTxtIndex.Location = new System.Drawing.Point(8, 74);
            this.chkTxtIndex.Name = "chkTxtIndex";
            this.chkTxtIndex.Size = new System.Drawing.Size(100, 20);
            this.chkTxtIndex.TabIndex = 0;
            this.chkTxtIndex.TabStop = false;
            this.chkTxtIndex.Text = "Indexes";
            // 
            // radTxtElevFeet
            // 
            this.radTxtElevFeet.Checked = true;
            this.radTxtElevFeet.Enabled = false;
            this.radTxtElevFeet.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radTxtElevFeet.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radTxtElevFeet.Location = new System.Drawing.Point(20, 126);
            this.radTxtElevFeet.Name = "radTxtElevFeet";
            this.radTxtElevFeet.Size = new System.Drawing.Size(76, 20);
            this.radTxtElevFeet.TabIndex = 0;
            this.radTxtElevFeet.TabStop = false;
            this.radTxtElevFeet.Text = "Feet";
            // 
            // chkTxtPID
            // 
            this.chkTxtPID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkTxtPID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTxtPID.Location = new System.Drawing.Point(8, 48);
            this.chkTxtPID.Name = "chkTxtPID";
            this.chkTxtPID.Size = new System.Drawing.Size(100, 20);
            this.chkTxtPID.TabIndex = 0;
            this.chkTxtPID.TabStop = false;
            this.chkTxtPID.Text = "Point IDs";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "File Contains:";
            // 
            // chkTxtMultiPoly
            // 
            this.chkTxtMultiPoly.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkTxtMultiPoly.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTxtMultiPoly.Location = new System.Drawing.Point(8, 22);
            this.chkTxtMultiPoly.Name = "chkTxtMultiPoly";
            this.chkTxtMultiPoly.Size = new System.Drawing.Size(153, 20);
            this.chkTxtMultiPoly.TabIndex = 0;
            this.chkTxtMultiPoly.TabStop = false;
            this.chkTxtMultiPoly.Text = "Multiple Polygons";
            // 
            // radTxtUTM
            // 
            this.radTxtUTM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radTxtUTM.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radTxtUTM.Location = new System.Drawing.Point(167, 0);
            this.radTxtUTM.Name = "radTxtUTM";
            this.radTxtUTM.Size = new System.Drawing.Size(66, 20);
            this.radTxtUTM.TabIndex = 0;
            this.radTxtUTM.TabStop = false;
            this.radTxtUTM.Text = "UTM";
            // 
            // radTxtLatLng
            // 
            this.radTxtLatLng.Checked = true;
            this.radTxtLatLng.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radTxtLatLng.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radTxtLatLng.Location = new System.Drawing.Point(97, 0);
            this.radTxtLatLng.Name = "radTxtLatLng";
            this.radTxtLatLng.Size = new System.Drawing.Size(76, 20);
            this.radTxtLatLng.TabIndex = 0;
            this.radTxtLatLng.TabStop = false;
            this.radTxtLatLng.Text = "LatLng";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(7, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Point Format:";
            // 
            // tabTwoTrails2
            // 
            this.tabTwoTrails2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabTwoTrails2.Controls.Add(this.label3);
            this.tabTwoTrails2.Controls.Add(this.chkTt2Nmea);
            this.tabTwoTrails2.Controls.Add(this.chkTt2Groups);
            this.tabTwoTrails2.Location = new System.Drawing.Point(0, 0);
            this.tabTwoTrails2.Name = "tabTwoTrails2";
            this.tabTwoTrails2.Size = new System.Drawing.Size(232, 204);
            this.tabTwoTrails2.Text = "TwoTrails V2";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(7, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Include:";
            // 
            // chkTt2Nmea
            // 
            this.chkTt2Nmea.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkTt2Nmea.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTt2Nmea.Location = new System.Drawing.Point(7, 53);
            this.chkTt2Nmea.Name = "chkTt2Nmea";
            this.chkTt2Nmea.Size = new System.Drawing.Size(100, 20);
            this.chkTt2Nmea.TabIndex = 0;
            this.chkTt2Nmea.TabStop = false;
            this.chkTt2Nmea.Text = "NMEA";
            // 
            // chkTt2Groups
            // 
            this.chkTt2Groups.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkTt2Groups.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTt2Groups.Location = new System.Drawing.Point(7, 27);
            this.chkTt2Groups.Name = "chkTt2Groups";
            this.chkTt2Groups.Size = new System.Drawing.Size(100, 20);
            this.chkTt2Groups.TabIndex = 0;
            this.chkTt2Groups.TabStop = false;
            this.chkTt2Groups.Text = "Groups";
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtFile);
            this.Name = "ImportForm";
            this.Text = "Import";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ImportForm_Closing);
            this.tabControl.ResumeLayout(false);
            this.tabText.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabTwoTrails2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.ofD = new System.Windows.Forms.OpenFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabText = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkTxtElev = new System.Windows.Forms.CheckBox();
            this.radTxtElevMeters = new System.Windows.Forms.RadioButton();
            this.chkTxtIndex = new System.Windows.Forms.CheckBox();
            this.radTxtElevFeet = new System.Windows.Forms.RadioButton();
            this.chkTxtPID = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTxtMultiPoly = new System.Windows.Forms.CheckBox();
            this.radTxtUTM = new System.Windows.Forms.RadioButton();
            this.radTxtLatLng = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabTwoTrails2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.chkTt2Nmea = new System.Windows.Forms.CheckBox();
            this.chkTt2Groups = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabText.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabTwoTrails2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofD
            // 
            this.ofD.Filter = "Files|*.shp,*.txt,*.csv,*.tt,*.tt2,*kml|Shape File|*.shp|Text File|*.txt,*.csv|Tw" +
                "oTrails File|*.tt,*.tt2|Google Earth File|*.kml";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(165, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(72, 21);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.TabStop = false;
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(3, 3);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(234, 21);
            this.txtFile.TabIndex = 1;
            this.txtFile.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(167, 266);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(70, 25);
            this.btnImport.TabIndex = 4;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(79, 266);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(82, 25);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "Help";
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabText);
            this.tabControl.Controls.Add(this.tabTwoTrails2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl.Location = new System.Drawing.Point(0, 30);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 230);
            this.tabControl.TabIndex = 5;
            // 
            // tabText
            // 
            this.tabText.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabText.Controls.Add(this.panel1);
            this.tabText.Controls.Add(this.radTxtUTM);
            this.tabText.Controls.Add(this.radTxtLatLng);
            this.tabText.Controls.Add(this.label1);
            this.tabText.Location = new System.Drawing.Point(0, 0);
            this.tabText.Name = "tabText";
            this.tabText.Size = new System.Drawing.Size(240, 207);
            this.tabText.Text = "Text - CSV";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.chkTxtElev);
            this.panel1.Controls.Add(this.radTxtElevMeters);
            this.panel1.Controls.Add(this.chkTxtIndex);
            this.panel1.Controls.Add(this.radTxtElevFeet);
            this.panel1.Controls.Add(this.chkTxtPID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkTxtMultiPoly);
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 178);
            // 
            // chkTxtElev
            // 
            this.chkTxtElev.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkTxtElev.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTxtElev.Location = new System.Drawing.Point(8, 100);
            this.chkTxtElev.Name = "chkTxtElev";
            this.chkTxtElev.Size = new System.Drawing.Size(100, 20);
            this.chkTxtElev.TabIndex = 0;
            this.chkTxtElev.TabStop = false;
            this.chkTxtElev.Text = "Elevation";
            this.chkTxtElev.CheckStateChanged += new System.EventHandler(this.chkTxtElev_CheckStateChanged);
            // 
            // radTxtElevMeters
            // 
            this.radTxtElevMeters.Enabled = false;
            this.radTxtElevMeters.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radTxtElevMeters.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radTxtElevMeters.Location = new System.Drawing.Point(79, 126);
            this.radTxtElevMeters.Name = "radTxtElevMeters";
            this.radTxtElevMeters.Size = new System.Drawing.Size(66, 20);
            this.radTxtElevMeters.TabIndex = 0;
            this.radTxtElevMeters.TabStop = false;
            this.radTxtElevMeters.Text = "Meters";
            // 
            // chkTxtIndex
            // 
            this.chkTxtIndex.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkTxtIndex.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTxtIndex.Location = new System.Drawing.Point(8, 74);
            this.chkTxtIndex.Name = "chkTxtIndex";
            this.chkTxtIndex.Size = new System.Drawing.Size(100, 20);
            this.chkTxtIndex.TabIndex = 0;
            this.chkTxtIndex.TabStop = false;
            this.chkTxtIndex.Text = "Indexes";
            // 
            // radTxtElevFeet
            // 
            this.radTxtElevFeet.Checked = true;
            this.radTxtElevFeet.Enabled = false;
            this.radTxtElevFeet.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radTxtElevFeet.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radTxtElevFeet.Location = new System.Drawing.Point(20, 126);
            this.radTxtElevFeet.Name = "radTxtElevFeet";
            this.radTxtElevFeet.Size = new System.Drawing.Size(76, 20);
            this.radTxtElevFeet.TabIndex = 0;
            this.radTxtElevFeet.TabStop = false;
            this.radTxtElevFeet.Text = "Feet";
            // 
            // chkTxtPID
            // 
            this.chkTxtPID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkTxtPID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTxtPID.Location = new System.Drawing.Point(8, 48);
            this.chkTxtPID.Name = "chkTxtPID";
            this.chkTxtPID.Size = new System.Drawing.Size(100, 20);
            this.chkTxtPID.TabIndex = 0;
            this.chkTxtPID.TabStop = false;
            this.chkTxtPID.Text = "Point IDs";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "File Contains:";
            // 
            // chkTxtMultiPoly
            // 
            this.chkTxtMultiPoly.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkTxtMultiPoly.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTxtMultiPoly.Location = new System.Drawing.Point(8, 22);
            this.chkTxtMultiPoly.Name = "chkTxtMultiPoly";
            this.chkTxtMultiPoly.Size = new System.Drawing.Size(153, 20);
            this.chkTxtMultiPoly.TabIndex = 0;
            this.chkTxtMultiPoly.TabStop = false;
            this.chkTxtMultiPoly.Text = "Multiple Polygons";
            // 
            // radTxtUTM
            // 
            this.radTxtUTM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radTxtUTM.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radTxtUTM.Location = new System.Drawing.Point(167, 0);
            this.radTxtUTM.Name = "radTxtUTM";
            this.radTxtUTM.Size = new System.Drawing.Size(66, 20);
            this.radTxtUTM.TabIndex = 0;
            this.radTxtUTM.TabStop = false;
            this.radTxtUTM.Text = "UTM";
            // 
            // radTxtLatLng
            // 
            this.radTxtLatLng.Checked = true;
            this.radTxtLatLng.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radTxtLatLng.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radTxtLatLng.Location = new System.Drawing.Point(97, 0);
            this.radTxtLatLng.Name = "radTxtLatLng";
            this.radTxtLatLng.Size = new System.Drawing.Size(76, 20);
            this.radTxtLatLng.TabIndex = 0;
            this.radTxtLatLng.TabStop = false;
            this.radTxtLatLng.Text = "LatLng";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(7, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Point Format:";
            // 
            // tabTwoTrails2
            // 
            this.tabTwoTrails2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabTwoTrails2.Controls.Add(this.label3);
            this.tabTwoTrails2.Controls.Add(this.chkTt2Nmea);
            this.tabTwoTrails2.Controls.Add(this.chkTt2Groups);
            this.tabTwoTrails2.Location = new System.Drawing.Point(0, 0);
            this.tabTwoTrails2.Name = "tabTwoTrails2";
            this.tabTwoTrails2.Size = new System.Drawing.Size(232, 204);
            this.tabTwoTrails2.Text = "TwoTrails V2";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(7, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Include:";
            // 
            // chkTt2Nmea
            // 
            this.chkTt2Nmea.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkTt2Nmea.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTt2Nmea.Location = new System.Drawing.Point(7, 53);
            this.chkTt2Nmea.Name = "chkTt2Nmea";
            this.chkTt2Nmea.Size = new System.Drawing.Size(100, 20);
            this.chkTt2Nmea.TabIndex = 0;
            this.chkTt2Nmea.TabStop = false;
            this.chkTt2Nmea.Text = "NMEA";
            // 
            // chkTt2Groups
            // 
            this.chkTt2Groups.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkTt2Groups.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkTt2Groups.Location = new System.Drawing.Point(7, 27);
            this.chkTt2Groups.Name = "chkTt2Groups";
            this.chkTt2Groups.Size = new System.Drawing.Size(100, 20);
            this.chkTt2Groups.TabIndex = 0;
            this.chkTt2Groups.TabStop = false;
            this.chkTt2Groups.Text = "Groups";
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtFile);
            this.Name = "ImportForm";
            this.Text = "Import";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ImportForm_Closing);
            this.tabControl.ResumeLayout(false);
            this.tabText.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabTwoTrails2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.OpenFileDialog ofD;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabText;
        private System.Windows.Forms.TabPage tabTwoTrails2;
        private System.Windows.Forms.RadioButton radTxtLatLng;
        private System.Windows.Forms.RadioButton radTxtUTM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkTxtElev;
        private System.Windows.Forms.CheckBox chkTxtIndex;
        private System.Windows.Forms.CheckBox chkTxtPID;
        private System.Windows.Forms.CheckBox chkTxtMultiPoly;
        private System.Windows.Forms.RadioButton radTxtElevMeters;
        private System.Windows.Forms.RadioButton radTxtElevFeet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTt2Nmea;
        private System.Windows.Forms.CheckBox chkTt2Groups;
        private System.Windows.Forms.Label label3;
    }
}