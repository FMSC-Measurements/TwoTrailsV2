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
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.ofD = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabShape = new System.Windows.Forms.TabPage();
            this.lblShpZone = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radShpElevMeters = new System.Windows.Forms.RadioButton();
            this.radShpElevFeet = new System.Windows.Forms.RadioButton();
            this.lstShpFiles = new System.Windows.Forms.ListBox();
            this.chkShpMulti = new System.Windows.Forms.CheckBox();
            this.btnShpClear = new System.Windows.Forms.Button();
            this.btnShpAdd = new System.Windows.Forms.Button();
            this.btnShpRemove = new System.Windows.Forms.Button();
            this.chkShpElev = new System.Windows.Forms.CheckBox();
            this.tabText = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radTxtElevMeters = new System.Windows.Forms.RadioButton();
            this.radTxtElevFeet = new System.Windows.Forms.RadioButton();
            this.chkTxtElev = new System.Windows.Forms.CheckBox();
            this.chkTxtIndex = new System.Windows.Forms.CheckBox();
            this.chkUseCmt = new System.Windows.Forms.CheckBox();
            this.chkUseOnBound = new System.Windows.Forms.CheckBox();
            this.chkTxtPID = new System.Windows.Forms.CheckBox();
            this.chkTxtMultiPoly = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radTxtUTM = new System.Windows.Forms.RadioButton();
            this.radTxtLatLng = new System.Windows.Forms.RadioButton();
            this.tabGPX = new System.Windows.Forms.TabPage();
            this.radGpxElevMeters = new System.Windows.Forms.RadioButton();
            this.radGpxElevFeet = new System.Windows.Forms.RadioButton();
            this.chkGpxElev = new System.Windows.Forms.CheckBox();
            this.tabTwoTrails1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkTtNmea = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkLstTtPolys = new System.Windows.Forms.CheckedListBox();
            this.tabTwoTrails2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkTt2Nmea = new System.Windows.Forms.CheckBox();
            this.chkTt2Groups = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkLstTt2Polys = new System.Windows.Forms.CheckedListBox();
            this.tabControl.SuspendLayout();
            this.tabShape.SuspendLayout();
            this.tabText.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabGPX.SuspendLayout();
            this.tabTwoTrails1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabTwoTrails2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(256, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(36, 14);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(214, 20);
            this.txtFile.TabIndex = 1;
            this.txtFile.TabStop = false;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(256, 232);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(7, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Location = new System.Drawing.Point(88, 232);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // ofD
            // 
            this.ofD.Filter = "Files|*.shp;*.txt;*.csv;*.tt;*.tt2;*.gpx|Shape File|*.shp|Text File|*.txt,*.csv|T" +
                "woTrails File|*.tt,*.tt2|GPS Exchange File|*.gpx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "File";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabShape);
            this.tabControl.Controls.Add(this.tabText);
            this.tabControl.Controls.Add(this.tabGPX);
            this.tabControl.Controls.Add(this.tabTwoTrails1);
            this.tabControl.Controls.Add(this.tabTwoTrails2);
            this.tabControl.Location = new System.Drawing.Point(0, 40);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(338, 186);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabShape
            // 
            this.tabShape.Controls.Add(this.lblShpZone);
            this.tabShape.Controls.Add(this.label4);
            this.tabShape.Controls.Add(this.label3);
            this.tabShape.Controls.Add(this.radShpElevMeters);
            this.tabShape.Controls.Add(this.radShpElevFeet);
            this.tabShape.Controls.Add(this.lstShpFiles);
            this.tabShape.Controls.Add(this.chkShpMulti);
            this.tabShape.Controls.Add(this.btnShpClear);
            this.tabShape.Controls.Add(this.btnShpAdd);
            this.tabShape.Controls.Add(this.btnShpRemove);
            this.tabShape.Controls.Add(this.chkShpElev);
            this.tabShape.Location = new System.Drawing.Point(4, 22);
            this.tabShape.Name = "tabShape";
            this.tabShape.Padding = new System.Windows.Forms.Padding(3);
            this.tabShape.Size = new System.Drawing.Size(330, 160);
            this.tabShape.TabIndex = 1;
            this.tabShape.Text = "Shape";
            this.tabShape.UseVisualStyleBackColor = true;
            // 
            // lblShpZone
            // 
            this.lblShpZone.AutoSize = true;
            this.lblShpZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShpZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblShpZone.Location = new System.Drawing.Point(265, 22);
            this.lblShpZone.Name = "lblShpZone";
            this.lblShpZone.Size = new System.Drawing.Size(16, 16);
            this.lblShpZone.TabIndex = 7;
            this.lblShpZone.Text = "0";
            this.lblShpZone.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(221, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Zone:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(197, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "UTM Format Only";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // radShpElevMeters
            // 
            this.radShpElevMeters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radShpElevMeters.AutoSize = true;
            this.radShpElevMeters.Enabled = false;
            this.radShpElevMeters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radShpElevMeters.Location = new System.Drawing.Point(258, 138);
            this.radShpElevMeters.Name = "radShpElevMeters";
            this.radShpElevMeters.Size = new System.Drawing.Size(69, 19);
            this.radShpElevMeters.TabIndex = 5;
            this.radShpElevMeters.Text = "Meters";
            this.radShpElevMeters.UseVisualStyleBackColor = true;
            // 
            // radShpElevFeet
            // 
            this.radShpElevFeet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radShpElevFeet.AutoSize = true;
            this.radShpElevFeet.Checked = true;
            this.radShpElevFeet.Enabled = false;
            this.radShpElevFeet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radShpElevFeet.Location = new System.Drawing.Point(199, 138);
            this.radShpElevFeet.Name = "radShpElevFeet";
            this.radShpElevFeet.Size = new System.Drawing.Size(53, 19);
            this.radShpElevFeet.TabIndex = 6;
            this.radShpElevFeet.TabStop = true;
            this.radShpElevFeet.Text = "Feet";
            this.radShpElevFeet.UseVisualStyleBackColor = true;
            // 
            // lstShpFiles
            // 
            this.lstShpFiles.Enabled = false;
            this.lstShpFiles.FormattingEnabled = true;
            this.lstShpFiles.Location = new System.Drawing.Point(3, 22);
            this.lstShpFiles.Name = "lstShpFiles";
            this.lstShpFiles.Size = new System.Drawing.Size(189, 108);
            this.lstShpFiles.TabIndex = 0;
            this.lstShpFiles.TabStop = false;
            // 
            // chkShpMulti
            // 
            this.chkShpMulti.AutoSize = true;
            this.chkShpMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShpMulti.Location = new System.Drawing.Point(6, 2);
            this.chkShpMulti.Name = "chkShpMulti";
            this.chkShpMulti.Size = new System.Drawing.Size(185, 20);
            this.chkShpMulti.TabIndex = 3;
            this.chkShpMulti.TabStop = false;
            this.chkShpMulti.Text = "Import Multiple Shapes";
            this.chkShpMulti.UseVisualStyleBackColor = true;
            this.chkShpMulti.CheckedChanged += new System.EventHandler(this.chkShpMulti_CheckedChanged);
            // 
            // btnShpClear
            // 
            this.btnShpClear.Enabled = false;
            this.btnShpClear.Location = new System.Drawing.Point(3, 134);
            this.btnShpClear.Name = "btnShpClear";
            this.btnShpClear.Size = new System.Drawing.Size(59, 23);
            this.btnShpClear.TabIndex = 1;
            this.btnShpClear.TabStop = false;
            this.btnShpClear.Text = "Clear";
            this.btnShpClear.UseVisualStyleBackColor = true;
            this.btnShpClear.Click += new System.EventHandler(this.btnShpClear_Click);
            // 
            // btnShpAdd
            // 
            this.btnShpAdd.Enabled = false;
            this.btnShpAdd.Location = new System.Drawing.Point(133, 134);
            this.btnShpAdd.Name = "btnShpAdd";
            this.btnShpAdd.Size = new System.Drawing.Size(59, 23);
            this.btnShpAdd.TabIndex = 1;
            this.btnShpAdd.TabStop = false;
            this.btnShpAdd.Text = "Add";
            this.btnShpAdd.UseVisualStyleBackColor = true;
            this.btnShpAdd.Click += new System.EventHandler(this.btnShpAdd_Click);
            // 
            // btnShpRemove
            // 
            this.btnShpRemove.Enabled = false;
            this.btnShpRemove.Location = new System.Drawing.Point(68, 134);
            this.btnShpRemove.Name = "btnShpRemove";
            this.btnShpRemove.Size = new System.Drawing.Size(59, 23);
            this.btnShpRemove.TabIndex = 1;
            this.btnShpRemove.TabStop = false;
            this.btnShpRemove.Text = "Remove";
            this.btnShpRemove.UseVisualStyleBackColor = true;
            this.btnShpRemove.Click += new System.EventHandler(this.btnShpRemove_Click);
            // 
            // chkShpElev
            // 
            this.chkShpElev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShpElev.AutoSize = true;
            this.chkShpElev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShpElev.Location = new System.Drawing.Point(199, 121);
            this.chkShpElev.Name = "chkShpElev";
            this.chkShpElev.Size = new System.Drawing.Size(92, 20);
            this.chkShpElev.TabIndex = 4;
            this.chkShpElev.TabStop = false;
            this.chkShpElev.Text = "Elevation";
            this.chkShpElev.UseVisualStyleBackColor = true;
            this.chkShpElev.CheckedChanged += new System.EventHandler(this.chkShpElev_CheckedChanged);
            // 
            // tabText
            // 
            this.tabText.Controls.Add(this.groupBox1);
            this.tabText.Controls.Add(this.label2);
            this.tabText.Controls.Add(this.radTxtUTM);
            this.tabText.Controls.Add(this.radTxtLatLng);
            this.tabText.Location = new System.Drawing.Point(4, 22);
            this.tabText.Name = "tabText";
            this.tabText.Padding = new System.Windows.Forms.Padding(3);
            this.tabText.Size = new System.Drawing.Size(330, 160);
            this.tabText.TabIndex = 0;
            this.tabText.Text = "Text - CSV";
            this.tabText.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.radTxtElevMeters);
            this.groupBox1.Controls.Add(this.radTxtElevFeet);
            this.groupBox1.Controls.Add(this.chkTxtElev);
            this.groupBox1.Controls.Add(this.chkTxtIndex);
            this.groupBox1.Controls.Add(this.chkUseCmt);
            this.groupBox1.Controls.Add(this.chkUseOnBound);
            this.groupBox1.Controls.Add(this.chkTxtPID);
            this.groupBox1.Controls.Add(this.chkTxtMultiPoly);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 127);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Contains";
            this.groupBox1.Visible = false;
            // 
            // radTxtElevMeters
            // 
            this.radTxtElevMeters.AutoSize = true;
            this.radTxtElevMeters.Enabled = false;
            this.radTxtElevMeters.Location = new System.Drawing.Point(168, 97);
            this.radTxtElevMeters.Name = "radTxtElevMeters";
            this.radTxtElevMeters.Size = new System.Drawing.Size(69, 19);
            this.radTxtElevMeters.TabIndex = 1;
            this.radTxtElevMeters.Text = "Meters";
            this.radTxtElevMeters.UseVisualStyleBackColor = true;
            // 
            // radTxtElevFeet
            // 
            this.radTxtElevFeet.AutoSize = true;
            this.radTxtElevFeet.Checked = true;
            this.radTxtElevFeet.Enabled = false;
            this.radTxtElevFeet.Location = new System.Drawing.Point(109, 97);
            this.radTxtElevFeet.Name = "radTxtElevFeet";
            this.radTxtElevFeet.Size = new System.Drawing.Size(53, 19);
            this.radTxtElevFeet.TabIndex = 1;
            this.radTxtElevFeet.TabStop = true;
            this.radTxtElevFeet.Text = "Feet";
            this.radTxtElevFeet.UseVisualStyleBackColor = true;
            // 
            // chkTxtElev
            // 
            this.chkTxtElev.AutoSize = true;
            this.chkTxtElev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTxtElev.Location = new System.Drawing.Point(11, 98);
            this.chkTxtElev.Name = "chkTxtElev";
            this.chkTxtElev.Size = new System.Drawing.Size(92, 20);
            this.chkTxtElev.TabIndex = 0;
            this.chkTxtElev.TabStop = false;
            this.chkTxtElev.Text = "Elevation";
            this.chkTxtElev.UseVisualStyleBackColor = true;
            this.chkTxtElev.CheckedChanged += new System.EventHandler(this.chkTxtElev_CheckedChanged);
            // 
            // chkTxtIndex
            // 
            this.chkTxtIndex.AutoSize = true;
            this.chkTxtIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTxtIndex.Location = new System.Drawing.Point(11, 72);
            this.chkTxtIndex.Name = "chkTxtIndex";
            this.chkTxtIndex.Size = new System.Drawing.Size(81, 20);
            this.chkTxtIndex.TabIndex = 0;
            this.chkTxtIndex.TabStop = false;
            this.chkTxtIndex.Text = "Indexes";
            this.chkTxtIndex.UseVisualStyleBackColor = true;
            // 
            // chkUseCmt
            // 
            this.chkUseCmt.AutoSize = true;
            this.chkUseCmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseCmt.Location = new System.Drawing.Point(168, 72);
            this.chkUseCmt.Name = "chkUseCmt";
            this.chkUseCmt.Size = new System.Drawing.Size(99, 20);
            this.chkUseCmt.TabIndex = 0;
            this.chkUseCmt.TabStop = false;
            this.chkUseCmt.Text = "Comments";
            this.chkUseCmt.UseVisualStyleBackColor = true;
            // 
            // chkUseOnBound
            // 
            this.chkUseOnBound.AutoSize = true;
            this.chkUseOnBound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseOnBound.Location = new System.Drawing.Point(168, 46);
            this.chkUseOnBound.Name = "chkUseOnBound";
            this.chkUseOnBound.Size = new System.Drawing.Size(105, 20);
            this.chkUseOnBound.TabIndex = 0;
            this.chkUseOnBound.TabStop = false;
            this.chkUseOnBound.Text = "Has OnBnd";
            this.chkUseOnBound.UseVisualStyleBackColor = true;
            // 
            // chkTxtPID
            // 
            this.chkTxtPID.AutoSize = true;
            this.chkTxtPID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTxtPID.Location = new System.Drawing.Point(11, 46);
            this.chkTxtPID.Name = "chkTxtPID";
            this.chkTxtPID.Size = new System.Drawing.Size(89, 20);
            this.chkTxtPID.TabIndex = 0;
            this.chkTxtPID.TabStop = false;
            this.chkTxtPID.Text = "Point IDs";
            this.chkTxtPID.UseVisualStyleBackColor = true;
            // 
            // chkTxtMultiPoly
            // 
            this.chkTxtMultiPoly.AutoSize = true;
            this.chkTxtMultiPoly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTxtMultiPoly.Location = new System.Drawing.Point(11, 20);
            this.chkTxtMultiPoly.Name = "chkTxtMultiPoly";
            this.chkTxtMultiPoly.Size = new System.Drawing.Size(150, 20);
            this.chkTxtMultiPoly.TabIndex = 0;
            this.chkTxtMultiPoly.TabStop = false;
            this.chkTxtMultiPoly.Text = "Multiple Polygons";
            this.chkTxtMultiPoly.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Point Format:";
            this.label2.Visible = false;
            // 
            // radTxtUTM
            // 
            this.radTxtUTM.AutoSize = true;
            this.radTxtUTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTxtUTM.Location = new System.Drawing.Point(191, 7);
            this.radTxtUTM.Name = "radTxtUTM";
            this.radTxtUTM.Size = new System.Drawing.Size(59, 20);
            this.radTxtUTM.TabIndex = 0;
            this.radTxtUTM.Text = "UTM";
            this.radTxtUTM.UseVisualStyleBackColor = true;
            this.radTxtUTM.Visible = false;
            // 
            // radTxtLatLng
            // 
            this.radTxtLatLng.AutoSize = true;
            this.radTxtLatLng.Checked = true;
            this.radTxtLatLng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTxtLatLng.Location = new System.Drawing.Point(113, 7);
            this.radTxtLatLng.Name = "radTxtLatLng";
            this.radTxtLatLng.Size = new System.Drawing.Size(72, 20);
            this.radTxtLatLng.TabIndex = 0;
            this.radTxtLatLng.TabStop = true;
            this.radTxtLatLng.Text = "LatLng";
            this.radTxtLatLng.UseVisualStyleBackColor = true;
            this.radTxtLatLng.Visible = false;
            // 
            // tabGPX
            // 
            this.tabGPX.Controls.Add(this.radGpxElevMeters);
            this.tabGPX.Controls.Add(this.radGpxElevFeet);
            this.tabGPX.Controls.Add(this.chkGpxElev);
            this.tabGPX.Location = new System.Drawing.Point(4, 22);
            this.tabGPX.Name = "tabGPX";
            this.tabGPX.Padding = new System.Windows.Forms.Padding(3);
            this.tabGPX.Size = new System.Drawing.Size(330, 160);
            this.tabGPX.TabIndex = 2;
            this.tabGPX.Text = "GPX";
            this.tabGPX.UseVisualStyleBackColor = true;
            // 
            // radGpxElevMeters
            // 
            this.radGpxElevMeters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radGpxElevMeters.AutoSize = true;
            this.radGpxElevMeters.Enabled = false;
            this.radGpxElevMeters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGpxElevMeters.Location = new System.Drawing.Point(258, 138);
            this.radGpxElevMeters.Name = "radGpxElevMeters";
            this.radGpxElevMeters.Size = new System.Drawing.Size(69, 19);
            this.radGpxElevMeters.TabIndex = 8;
            this.radGpxElevMeters.Text = "Meters";
            this.radGpxElevMeters.UseVisualStyleBackColor = true;
            // 
            // radGpxElevFeet
            // 
            this.radGpxElevFeet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radGpxElevFeet.AutoSize = true;
            this.radGpxElevFeet.Checked = true;
            this.radGpxElevFeet.Enabled = false;
            this.radGpxElevFeet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGpxElevFeet.Location = new System.Drawing.Point(199, 138);
            this.radGpxElevFeet.Name = "radGpxElevFeet";
            this.radGpxElevFeet.Size = new System.Drawing.Size(53, 19);
            this.radGpxElevFeet.TabIndex = 9;
            this.radGpxElevFeet.TabStop = true;
            this.radGpxElevFeet.Text = "Feet";
            this.radGpxElevFeet.UseVisualStyleBackColor = true;
            // 
            // chkGpxElev
            // 
            this.chkGpxElev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGpxElev.AutoSize = true;
            this.chkGpxElev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGpxElev.Location = new System.Drawing.Point(199, 121);
            this.chkGpxElev.Name = "chkGpxElev";
            this.chkGpxElev.Size = new System.Drawing.Size(92, 20);
            this.chkGpxElev.TabIndex = 7;
            this.chkGpxElev.TabStop = false;
            this.chkGpxElev.Text = "Elevation";
            this.chkGpxElev.UseVisualStyleBackColor = true;
            this.chkGpxElev.CheckedChanged += new System.EventHandler(this.chkGpxElev_CheckedChanged);
            // 
            // tabTwoTrails1
            // 
            this.tabTwoTrails1.Controls.Add(this.groupBox3);
            this.tabTwoTrails1.Controls.Add(this.label6);
            this.tabTwoTrails1.Controls.Add(this.chkLstTtPolys);
            this.tabTwoTrails1.Location = new System.Drawing.Point(4, 22);
            this.tabTwoTrails1.Name = "tabTwoTrails1";
            this.tabTwoTrails1.Padding = new System.Windows.Forms.Padding(3);
            this.tabTwoTrails1.Size = new System.Drawing.Size(330, 160);
            this.tabTwoTrails1.TabIndex = 3;
            this.tabTwoTrails1.Text = "TwoTrails 1.0";
            this.tabTwoTrails1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkTtNmea);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(167, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 139);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Include";
            // 
            // chkTtNmea
            // 
            this.chkTtNmea.AutoSize = true;
            this.chkTtNmea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTtNmea.Location = new System.Drawing.Point(6, 20);
            this.chkTtNmea.Name = "chkTtNmea";
            this.chkTtNmea.Size = new System.Drawing.Size(70, 20);
            this.chkTtNmea.TabIndex = 0;
            this.chkTtNmea.TabStop = false;
            this.chkTtNmea.Text = "NMEA";
            this.chkTtNmea.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Select Polygons";
            // 
            // chkLstTtPolys
            // 
            this.chkLstTtPolys.CheckOnClick = true;
            this.chkLstTtPolys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLstTtPolys.FormattingEnabled = true;
            this.chkLstTtPolys.Location = new System.Drawing.Point(4, 23);
            this.chkLstTtPolys.Name = "chkLstTtPolys";
            this.chkLstTtPolys.Size = new System.Drawing.Size(156, 132);
            this.chkLstTtPolys.TabIndex = 3;
            this.chkLstTtPolys.TabStop = false;
            // 
            // tabTwoTrails2
            // 
            this.tabTwoTrails2.Controls.Add(this.groupBox2);
            this.tabTwoTrails2.Controls.Add(this.label5);
            this.tabTwoTrails2.Controls.Add(this.chkLstTt2Polys);
            this.tabTwoTrails2.Location = new System.Drawing.Point(4, 22);
            this.tabTwoTrails2.Name = "tabTwoTrails2";
            this.tabTwoTrails2.Padding = new System.Windows.Forms.Padding(3);
            this.tabTwoTrails2.Size = new System.Drawing.Size(330, 160);
            this.tabTwoTrails2.TabIndex = 4;
            this.tabTwoTrails2.Text = "TwoTrails V2";
            this.tabTwoTrails2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkTt2Nmea);
            this.groupBox2.Controls.Add(this.chkTt2Groups);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(167, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 139);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Include";
            // 
            // chkTt2Nmea
            // 
            this.chkTt2Nmea.AutoSize = true;
            this.chkTt2Nmea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTt2Nmea.Location = new System.Drawing.Point(6, 46);
            this.chkTt2Nmea.Name = "chkTt2Nmea";
            this.chkTt2Nmea.Size = new System.Drawing.Size(70, 20);
            this.chkTt2Nmea.TabIndex = 0;
            this.chkTt2Nmea.TabStop = false;
            this.chkTt2Nmea.Text = "NMEA";
            this.chkTt2Nmea.UseVisualStyleBackColor = true;
            // 
            // chkTt2Groups
            // 
            this.chkTt2Groups.AutoSize = true;
            this.chkTt2Groups.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTt2Groups.Location = new System.Drawing.Point(6, 20);
            this.chkTt2Groups.Name = "chkTt2Groups";
            this.chkTt2Groups.Size = new System.Drawing.Size(77, 20);
            this.chkTt2Groups.TabIndex = 0;
            this.chkTt2Groups.TabStop = false;
            this.chkTt2Groups.Text = "Groups";
            this.chkTt2Groups.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Select Polygons";
            // 
            // chkLstTt2Polys
            // 
            this.chkLstTt2Polys.CheckOnClick = true;
            this.chkLstTt2Polys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLstTt2Polys.FormattingEnabled = true;
            this.chkLstTt2Polys.Location = new System.Drawing.Point(4, 23);
            this.chkLstTt2Polys.Name = "chkLstTt2Polys";
            this.chkLstTt2Polys.Size = new System.Drawing.Size(156, 132);
            this.chkLstTt2Polys.TabIndex = 0;
            this.chkLstTt2Polys.TabStop = false;
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 261);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnOpen);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(354, 299);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(354, 299);
            this.Name = "ImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabShape.ResumeLayout(false);
            this.tabShape.PerformLayout();
            this.tabText.ResumeLayout(false);
            this.tabText.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabGPX.ResumeLayout(false);
            this.tabGPX.PerformLayout();
            this.tabTwoTrails1.ResumeLayout(false);
            this.tabTwoTrails1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabTwoTrails2.ResumeLayout(false);
            this.tabTwoTrails2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.OpenFileDialog ofD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabText;
        private System.Windows.Forms.TabPage tabShape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radTxtUTM;
        private System.Windows.Forms.RadioButton radTxtLatLng;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkTxtElev;
        private System.Windows.Forms.CheckBox chkTxtIndex;
        private System.Windows.Forms.CheckBox chkTxtPID;
        private System.Windows.Forms.CheckBox chkTxtMultiPoly;
        private System.Windows.Forms.RadioButton radTxtElevMeters;
        private System.Windows.Forms.RadioButton radTxtElevFeet;
        private System.Windows.Forms.TabPage tabGPX;
        private System.Windows.Forms.TabPage tabTwoTrails1;
        private System.Windows.Forms.TabPage tabTwoTrails2;
        private System.Windows.Forms.ListBox lstShpFiles;
        private System.Windows.Forms.CheckBox chkShpMulti;
        private System.Windows.Forms.Button btnShpClear;
        private System.Windows.Forms.Button btnShpAdd;
        private System.Windows.Forms.Button btnShpRemove;
        private System.Windows.Forms.RadioButton radShpElevMeters;
        private System.Windows.Forms.RadioButton radShpElevFeet;
        private System.Windows.Forms.CheckBox chkShpElev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblShpZone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox chkLstTt2Polys;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkTt2Nmea;
        private System.Windows.Forms.CheckBox chkTt2Groups;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkTtNmea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox chkLstTtPolys;
        private System.Windows.Forms.RadioButton radGpxElevMeters;
        private System.Windows.Forms.RadioButton radGpxElevFeet;
        private System.Windows.Forms.CheckBox chkGpxElev;
        private System.Windows.Forms.CheckBox chkUseOnBound;
        private System.Windows.Forms.CheckBox chkUseCmt;
    }
}