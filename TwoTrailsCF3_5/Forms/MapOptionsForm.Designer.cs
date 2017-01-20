namespace TwoTrails.Forms
{
    partial class MapOptionsForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDisplay = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.lstPolygons = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSkip = new System.Windows.Forms.TextBox();
            this.txtBackground = new System.Windows.Forms.TextBox();
            this.chkCloseBnd = new System.Windows.Forms.CheckBox();
            this.chkUseMap = new System.Windows.Forms.CheckBox();
            this.chkLegend = new System.Windows.Forms.CheckBox();
            this.cboLabels = new System.Windows.Forms.ComboBox();
            this.chkPoints = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBackground = new System.Windows.Forms.Button();
            this.btnDrawMap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabElements = new System.Windows.Forms.TabPage();
            this.btnDraw2 = new System.Windows.Forms.Button();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.radUTM = new System.Windows.Forms.RadioButton();
            this.radLatLon = new System.Windows.Forms.RadioButton();
            this.chkDetails = new System.Windows.Forms.CheckBox();
            this.chkFollowPos = new System.Windows.Forms.CheckBox();
            this.chkAdjMisc = new System.Windows.Forms.CheckBox();
            this.chkAdjBound = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAdjNav = new System.Windows.Forms.CheckBox();
            this.chkUnadjMyGPS = new System.Windows.Forms.CheckBox();
            this.chkUnadjWaypoints = new System.Windows.Forms.CheckBox();
            this.chkUnadjMisc = new System.Windows.Forms.CheckBox();
            this.chkUnadjBound = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkUnadjNav = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            this.tabElements.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabDisplay);
            this.tabControl.Controls.Add(this.tabElements);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 294);
            this.tabControl.TabIndex = 0;
            // 
            // tabDisplay
            // 
            this.tabDisplay.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabDisplay.Controls.Add(this.label6);
            this.tabDisplay.Controls.Add(this.lstPolygons);
            this.tabDisplay.Controls.Add(this.label2);
            this.tabDisplay.Controls.Add(this.txtSkip);
            this.tabDisplay.Controls.Add(this.txtBackground);
            this.tabDisplay.Controls.Add(this.chkCloseBnd);
            this.tabDisplay.Controls.Add(this.chkUseMap);
            this.tabDisplay.Controls.Add(this.chkLegend);
            this.tabDisplay.Controls.Add(this.cboLabels);
            this.tabDisplay.Controls.Add(this.chkPoints);
            this.tabDisplay.Controls.Add(this.btnExit);
            this.tabDisplay.Controls.Add(this.btnBackground);
            this.tabDisplay.Controls.Add(this.btnDrawMap);
            this.tabDisplay.Controls.Add(this.label1);
            this.tabDisplay.Location = new System.Drawing.Point(0, 0);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.Size = new System.Drawing.Size(240, 265);
            this.tabDisplay.Text = "Display Options";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.Text = "Labels:";
            // 
            // lstPolygons
            // 
            this.lstPolygons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPolygons.CheckBoxes = true;
            this.lstPolygons.FullRowSelect = true;
            this.lstPolygons.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstPolygons.Location = new System.Drawing.Point(7, 24);
            this.lstPolygons.Name = "lstPolygons";
            this.lstPolygons.Size = new System.Drawing.Size(225, 110);
            this.lstPolygons.TabIndex = 20;
            this.lstPolygons.View = System.Windows.Forms.View.Details;
            this.lstPolygons.SelectedIndexChanged += new System.EventHandler(this.lstPolygons_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(136, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.Text = "Skip Labels";
            // 
            // txtSkip
            // 
            this.txtSkip.Location = new System.Drawing.Point(95, 168);
            this.txtSkip.Name = "txtSkip";
            this.txtSkip.Size = new System.Drawing.Size(35, 25);
            this.txtSkip.TabIndex = 18;
            this.txtSkip.TabStop = false;
            this.txtSkip.TextChanged += new System.EventHandler(this.txtSkip_TextChanged);
            this.txtSkip.GotFocus += new System.EventHandler(this.txtSkip_GotFocus);
            this.txtSkip.LostFocus += new System.EventHandler(this.txtSkip_LostFocus);
            // 
            // txtBackground
            // 
            this.txtBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackground.Enabled = false;
            this.txtBackground.Location = new System.Drawing.Point(95, 217);
            this.txtBackground.Name = "txtBackground";
            this.txtBackground.ReadOnly = true;
            this.txtBackground.Size = new System.Drawing.Size(137, 25);
            this.txtBackground.TabIndex = 17;
            this.txtBackground.TabStop = false;
            this.txtBackground.Visible = false;
            // 
            // chkCloseBnd
            // 
            this.chkCloseBnd.Checked = true;
            this.chkCloseBnd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCloseBnd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkCloseBnd.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkCloseBnd.Location = new System.Drawing.Point(95, 198);
            this.chkCloseBnd.Name = "chkCloseBnd";
            this.chkCloseBnd.Size = new System.Drawing.Size(137, 20);
            this.chkCloseBnd.TabIndex = 16;
            this.chkCloseBnd.TabStop = false;
            this.chkCloseBnd.Text = "Close Boundaries";
            this.chkCloseBnd.CheckStateChanged += new System.EventHandler(this.chkCloseBnd_CheckStateChanged);
            // 
            // chkUseMap
            // 
            this.chkUseMap.Enabled = false;
            this.chkUseMap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkUseMap.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUseMap.Location = new System.Drawing.Point(169, 140);
            this.chkUseMap.Name = "chkUseMap";
            this.chkUseMap.Size = new System.Drawing.Size(110, 20);
            this.chkUseMap.TabIndex = 16;
            this.chkUseMap.TabStop = false;
            this.chkUseMap.Text = "Use Image";
            this.chkUseMap.Visible = false;
            this.chkUseMap.CheckStateChanged += new System.EventHandler(this.chkLegend_CheckStateChanged);
            // 
            // chkLegend
            // 
            this.chkLegend.Checked = true;
            this.chkLegend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLegend.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkLegend.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLegend.Location = new System.Drawing.Point(95, 140);
            this.chkLegend.Name = "chkLegend";
            this.chkLegend.Size = new System.Drawing.Size(74, 20);
            this.chkLegend.TabIndex = 16;
            this.chkLegend.TabStop = false;
            this.chkLegend.Text = "Legend";
            this.chkLegend.CheckStateChanged += new System.EventHandler(this.chkLegend_CheckStateChanged);
            // 
            // cboLabels
            // 
            this.cboLabels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLabels.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cboLabels.ForeColor = System.Drawing.Color.Black;
            this.cboLabels.Location = new System.Drawing.Point(7, 185);
            this.cboLabels.Name = "cboLabels";
            this.cboLabels.Size = new System.Drawing.Size(82, 26);
            this.cboLabels.TabIndex = 23;
            this.cboLabels.TabStop = false;
            this.cboLabels.SelectedIndexChanged += new System.EventHandler(this.cboLabels_SelectedIndexChanged);
            // 
            // chkPoints
            // 
            this.chkPoints.Checked = true;
            this.chkPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPoints.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkPoints.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkPoints.Location = new System.Drawing.Point(6, 140);
            this.chkPoints.Name = "chkPoints";
            this.chkPoints.Size = new System.Drawing.Size(100, 20);
            this.chkPoints.TabIndex = 12;
            this.chkPoints.TabStop = false;
            this.chkPoints.Text = "Points";
            this.chkPoints.CheckStateChanged += new System.EventHandler(this.chkPoints_CheckStateChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(7, 242);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 20);
            this.btnExit.TabIndex = 10;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBackground
            // 
            this.btnBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackground.Enabled = false;
            this.btnBackground.Location = new System.Drawing.Point(7, 217);
            this.btnBackground.Name = "btnBackground";
            this.btnBackground.Size = new System.Drawing.Size(83, 20);
            this.btnBackground.TabIndex = 9;
            this.btnBackground.TabStop = false;
            this.btnBackground.Text = "Background";
            this.btnBackground.Visible = false;
            this.btnBackground.Click += new System.EventHandler(this.btnBackground_Click);
            // 
            // btnDrawMap
            // 
            this.btnDrawMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawMap.Location = new System.Drawing.Point(150, 242);
            this.btnDrawMap.Name = "btnDrawMap";
            this.btnDrawMap.Size = new System.Drawing.Size(83, 20);
            this.btnDrawMap.TabIndex = 8;
            this.btnDrawMap.TabStop = false;
            this.btnDrawMap.Text = "Draw Map";
            this.btnDrawMap.Click += new System.EventHandler(this.btnDrawMap_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 17);
            this.label1.Text = "Select Polygons to Draw";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabElements
            // 
            this.tabElements.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabElements.Controls.Add(this.btnDraw2);
            this.tabElements.Controls.Add(this.btnExit2);
            this.tabElements.Controls.Add(this.radUTM);
            this.tabElements.Controls.Add(this.radLatLon);
            this.tabElements.Controls.Add(this.chkDetails);
            this.tabElements.Controls.Add(this.chkFollowPos);
            this.tabElements.Controls.Add(this.chkAdjMisc);
            this.tabElements.Controls.Add(this.chkAdjBound);
            this.tabElements.Controls.Add(this.label4);
            this.tabElements.Controls.Add(this.chkAdjNav);
            this.tabElements.Controls.Add(this.chkUnadjMyGPS);
            this.tabElements.Controls.Add(this.chkUnadjWaypoints);
            this.tabElements.Controls.Add(this.chkUnadjMisc);
            this.tabElements.Controls.Add(this.chkUnadjBound);
            this.tabElements.Controls.Add(this.label5);
            this.tabElements.Controls.Add(this.label3);
            this.tabElements.Controls.Add(this.chkUnadjNav);
            this.tabElements.Location = new System.Drawing.Point(0, 0);
            this.tabElements.Name = "tabElements";
            this.tabElements.Size = new System.Drawing.Size(232, 263);
            this.tabElements.Text = "Display Element Options";
            // 
            // btnDraw2
            // 
            this.btnDraw2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDraw2.Location = new System.Drawing.Point(142, 240);
            this.btnDraw2.Name = "btnDraw2";
            this.btnDraw2.Size = new System.Drawing.Size(83, 20);
            this.btnDraw2.TabIndex = 22;
            this.btnDraw2.TabStop = false;
            this.btnDraw2.Text = "Draw Map";
            this.btnDraw2.Click += new System.EventHandler(this.btnDrawMap_Click);
            // 
            // btnExit2
            // 
            this.btnExit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit2.Location = new System.Drawing.Point(7, 240);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(83, 20);
            this.btnExit2.TabIndex = 21;
            this.btnExit2.TabStop = false;
            this.btnExit2.Text = "Exit";
            this.btnExit2.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // radUTM
            // 
            this.radUTM.Enabled = false;
            this.radUTM.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radUTM.Location = new System.Drawing.Point(170, 220);
            this.radUTM.Name = "radUTM";
            this.radUTM.Size = new System.Drawing.Size(63, 20);
            this.radUTM.TabIndex = 17;
            this.radUTM.Text = "UTM";
            this.radUTM.CheckedChanged += new System.EventHandler(this.radUTM_CheckedChanged);
            // 
            // radLatLon
            // 
            this.radLatLon.Enabled = false;
            this.radLatLon.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radLatLon.Location = new System.Drawing.Point(84, 220);
            this.radLatLon.Name = "radLatLon";
            this.radLatLon.Size = new System.Drawing.Size(84, 20);
            this.radLatLon.TabIndex = 16;
            this.radLatLon.Text = "Lat / Lon";
            this.radLatLon.CheckedChanged += new System.EventHandler(this.radLatLon_CheckedChanged);
            // 
            // chkDetails
            // 
            this.chkDetails.Enabled = false;
            this.chkDetails.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkDetails.Location = new System.Drawing.Point(7, 220);
            this.chkDetails.Name = "chkDetails";
            this.chkDetails.Size = new System.Drawing.Size(76, 20);
            this.chkDetails.TabIndex = 15;
            this.chkDetails.Text = "Gps Loc";
            this.chkDetails.CheckStateChanged += new System.EventHandler(this.chkDetails_CheckStateChanged);
            // 
            // chkFollowPos
            // 
            this.chkFollowPos.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkFollowPos.Location = new System.Drawing.Point(122, 198);
            this.chkFollowPos.Name = "chkFollowPos";
            this.chkFollowPos.Size = new System.Drawing.Size(111, 20);
            this.chkFollowPos.TabIndex = 12;
            this.chkFollowPos.Text = "Follow Position";
            this.chkFollowPos.CheckStateChanged += new System.EventHandler(this.chkFollowPos_CheckStateChanged);
            // 
            // chkAdjMisc
            // 
            this.chkAdjMisc.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkAdjMisc.Location = new System.Drawing.Point(11, 69);
            this.chkAdjMisc.Name = "chkAdjMisc";
            this.chkAdjMisc.Size = new System.Drawing.Size(100, 20);
            this.chkAdjMisc.TabIndex = 9;
            this.chkAdjMisc.Text = "Misc Points";
            this.chkAdjMisc.CheckStateChanged += new System.EventHandler(this.chkAdjMisc_CheckStateChanged);
            // 
            // chkAdjBound
            // 
            this.chkAdjBound.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkAdjBound.Location = new System.Drawing.Point(11, 23);
            this.chkAdjBound.Name = "chkAdjBound";
            this.chkAdjBound.Size = new System.Drawing.Size(130, 20);
            this.chkAdjBound.TabIndex = 8;
            this.chkAdjBound.Text = "Boundary Trail";
            this.chkAdjBound.CheckStateChanged += new System.EventHandler(this.chkAdjBound_CheckStateChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(11, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 20);
            this.label4.Text = "Display Adjusted Elements";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkAdjNav
            // 
            this.chkAdjNav.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkAdjNav.Location = new System.Drawing.Point(11, 46);
            this.chkAdjNav.Name = "chkAdjNav";
            this.chkAdjNav.Size = new System.Drawing.Size(130, 20);
            this.chkAdjNav.TabIndex = 7;
            this.chkAdjNav.Text = "Navigation Trail";
            this.chkAdjNav.CheckStateChanged += new System.EventHandler(this.chkAdjNav_CheckStateChanged);
            // 
            // chkUnadjMyGPS
            // 
            this.chkUnadjMyGPS.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUnadjMyGPS.Location = new System.Drawing.Point(7, 198);
            this.chkUnadjMyGPS.Name = "chkUnadjMyGPS";
            this.chkUnadjMyGPS.Size = new System.Drawing.Size(120, 20);
            this.chkUnadjMyGPS.TabIndex = 5;
            this.chkUnadjMyGPS.Text = "My Position";
            this.chkUnadjMyGPS.CheckStateChanged += new System.EventHandler(this.chkUnadjMyGPS_CheckStateChanged);
            // 
            // chkUnadjWaypoints
            // 
            this.chkUnadjWaypoints.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUnadjWaypoints.Location = new System.Drawing.Point(7, 175);
            this.chkUnadjWaypoints.Name = "chkUnadjWaypoints";
            this.chkUnadjWaypoints.Size = new System.Drawing.Size(100, 20);
            this.chkUnadjWaypoints.TabIndex = 4;
            this.chkUnadjWaypoints.Text = "Waypoints";
            this.chkUnadjWaypoints.CheckStateChanged += new System.EventHandler(this.chkUnadjWaypoints_CheckStateChanged);
            // 
            // chkUnadjMisc
            // 
            this.chkUnadjMisc.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUnadjMisc.Location = new System.Drawing.Point(122, 112);
            this.chkUnadjMisc.Name = "chkUnadjMisc";
            this.chkUnadjMisc.Size = new System.Drawing.Size(100, 20);
            this.chkUnadjMisc.TabIndex = 3;
            this.chkUnadjMisc.Text = "Misc Points";
            this.chkUnadjMisc.CheckStateChanged += new System.EventHandler(this.chkUnadjMisc_CheckStateChanged);
            // 
            // chkUnadjBound
            // 
            this.chkUnadjBound.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUnadjBound.Location = new System.Drawing.Point(7, 112);
            this.chkUnadjBound.Name = "chkUnadjBound";
            this.chkUnadjBound.Size = new System.Drawing.Size(130, 20);
            this.chkUnadjBound.TabIndex = 2;
            this.chkUnadjBound.Text = "Boundary Trail";
            this.chkUnadjBound.CheckStateChanged += new System.EventHandler(this.chkUnadjBound_CheckStateChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(11, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 20);
            this.label5.Text = "Misc Elements";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(7, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 20);
            this.label3.Text = "Display Unadjusted Elements";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkUnadjNav
            // 
            this.chkUnadjNav.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUnadjNav.Location = new System.Drawing.Point(7, 135);
            this.chkUnadjNav.Name = "chkUnadjNav";
            this.chkUnadjNav.Size = new System.Drawing.Size(130, 20);
            this.chkUnadjNav.TabIndex = 0;
            this.chkUnadjNav.Text = "Navigation Trail";
            this.chkUnadjNav.CheckStateChanged += new System.EventHandler(this.chkUnadjNav_CheckStateChanged);
            // 
            // MapOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.tabControl);
            this.Name = "MapOptionsForm";
            this.Text = "Map Display Setup";
            this.tabControl.ResumeLayout(false);
            this.tabDisplay.ResumeLayout(false);
            this.tabElements.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDisplay = new System.Windows.Forms.TabPage();
            this.lstPolygons = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtBackground = new System.Windows.Forms.TextBox();
            this.btnBackground = new System.Windows.Forms.Button();
            this.txtSkip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPoints = new System.Windows.Forms.CheckBox();
            this.chkLines = new System.Windows.Forms.CheckBox();
            this.chkLegend = new System.Windows.Forms.CheckBox();
            this.btnDrawMap = new System.Windows.Forms.Button();
            this.cboLabels = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabElements = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.chkUnadjBound = new System.Windows.Forms.CheckBox();
            this.chkUnadjMisc = new System.Windows.Forms.CheckBox();
            this.chkUnadjWaypoints = new System.Windows.Forms.CheckBox();
            this.chkUnadjNav = new System.Windows.Forms.CheckBox();
            this.chkFollowPos = new System.Windows.Forms.CheckBox();
            this.radUTM = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.radLatLon = new System.Windows.Forms.RadioButton();
            this.chkAdjBound = new System.Windows.Forms.CheckBox();
            this.chkDetails = new System.Windows.Forms.CheckBox();
            this.chkAdjNav = new System.Windows.Forms.CheckBox();
            this.chkCloseBnd = new System.Windows.Forms.CheckBox();
            this.chkAdjMisc = new System.Windows.Forms.CheckBox();
            this.chkUnadjMyGPS = new System.Windows.Forms.CheckBox();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.btnDraw2 = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabElements.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDisplay);
            this.tabControl.Controls.Add(this.tabElements);
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(320, 214);
            this.tabControl.TabIndex = 0;
            // 
            // tabDisplay
            // 
            this.tabDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.tabDisplay.Controls.Add(this.lstPolygons);
            this.tabDisplay.Controls.Add(this.panel1);
            this.tabDisplay.Location = new System.Drawing.Point(0, 0);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.Size = new System.Drawing.Size(320, 185);
            this.tabDisplay.Text = "Display Options";
            // 
            // lstPolygons
            // 
            this.lstPolygons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPolygons.CheckBoxes = true;
            this.lstPolygons.FullRowSelect = true;
            this.lstPolygons.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstPolygons.Location = new System.Drawing.Point(7, 24);
            this.lstPolygons.Name = "lstPolygons";
            this.lstPolygons.Size = new System.Drawing.Size(227, 110);
            this.lstPolygons.TabIndex = 20;
            this.lstPolygons.View = System.Windows.Forms.View.Details;
            this.lstPolygons.SelectedIndexChanged += new System.EventHandler(this.lstPolygons_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.txtBackground);
            this.panel1.Controls.Add(this.btnBackground);
            this.panel1.Controls.Add(this.txtSkip);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkPoints);
            this.panel1.Controls.Add(this.chkLines);
            this.panel1.Controls.Add(this.chkLegend);
            this.panel1.Controls.Add(this.btnDrawMap);
            this.panel1.Controls.Add(this.cboLabels);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 185);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 17);
            this.label1.Text = "Select Polygons to Draw";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(7, 162);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 20);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtBackground
            // 
            this.txtBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackground.Enabled = false;
            this.txtBackground.Location = new System.Drawing.Point(110, 137);
            this.txtBackground.Name = "txtBackground";
            this.txtBackground.Size = new System.Drawing.Size(53, 25);
            this.txtBackground.TabIndex = 17;
            this.txtBackground.Visible = false;
            // 
            // btnBackground
            // 
            this.btnBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackground.Enabled = false;
            this.btnBackground.Location = new System.Drawing.Point(7, 137);
            this.btnBackground.Name = "btnBackground";
            this.btnBackground.Size = new System.Drawing.Size(97, 20);
            this.btnBackground.TabIndex = 9;
            this.btnBackground.Text = "Background";
            this.btnBackground.Visible = false;
            this.btnBackground.Click += new System.EventHandler(this.btnBackground_Click);
            // 
            // txtSkip
            // 
            this.txtSkip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSkip.Location = new System.Drawing.Point(175, 137);
            this.txtSkip.Name = "txtSkip";
            this.txtSkip.Size = new System.Drawing.Size(45, 25);
            this.txtSkip.TabIndex = 18;
            this.txtSkip.TextChanged += new System.EventHandler(this.txtSkip_TextChanged);
            this.txtSkip.GotFocus += new System.EventHandler(this.txtSkip_GotFocus);
            this.txtSkip.LostFocus += new System.EventHandler(this.txtSkip_LostFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(223, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.Text = "Skip Labels";
            // 
            // chkPoints
            // 
            this.chkPoints.Checked = true;
            this.chkPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPoints.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkPoints.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkPoints.Location = new System.Drawing.Point(237, 24);
            this.chkPoints.Name = "chkPoints";
            this.chkPoints.Size = new System.Drawing.Size(80, 20);
            this.chkPoints.TabIndex = 12;
            this.chkPoints.Text = "Points";
            this.chkPoints.CheckStateChanged += new System.EventHandler(this.chkPoints_CheckStateChanged);
            // 
            // chkLines
            // 
            this.chkLines.Checked = true;
            this.chkLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLines.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkLines.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLines.Location = new System.Drawing.Point(237, 50);
            this.chkLines.Name = "chkLines";
            this.chkLines.Size = new System.Drawing.Size(80, 20);
            this.chkLines.TabIndex = 13;
            this.chkLines.Text = "Lines";
            this.chkLines.CheckStateChanged += new System.EventHandler(this.chkLines_CheckStateChanged);
            // 
            // chkLegend
            // 
            this.chkLegend.Checked = true;
            this.chkLegend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLegend.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkLegend.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLegend.Location = new System.Drawing.Point(236, 76);
            this.chkLegend.Name = "chkLegend";
            this.chkLegend.Size = new System.Drawing.Size(97, 20);
            this.chkLegend.TabIndex = 16;
            this.chkLegend.Text = "Legend";
            this.chkLegend.CheckStateChanged += new System.EventHandler(this.chkLegend_CheckStateChanged);
            // 
            // btnDrawMap
            // 
            this.btnDrawMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawMap.Location = new System.Drawing.Point(230, 162);
            this.btnDrawMap.Name = "btnDrawMap";
            this.btnDrawMap.Size = new System.Drawing.Size(83, 20);
            this.btnDrawMap.TabIndex = 8;
            this.btnDrawMap.Text = "Draw Map";
            this.btnDrawMap.Click += new System.EventHandler(this.btnDrawMap_Click);
            // 
            // cboLabels
            // 
            this.cboLabels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLabels.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cboLabels.ForeColor = System.Drawing.Color.Black;
            this.cboLabels.Location = new System.Drawing.Point(236, 114);
            this.cboLabels.Name = "cboLabels";
            this.cboLabels.Size = new System.Drawing.Size(80, 26);
            this.cboLabels.TabIndex = 14;
            this.cboLabels.SelectedIndexChanged += new System.EventHandler(this.cboLabels_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(238, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.Text = "Labels:";
            // 
            // tabElements
            // 
            this.tabElements.BackColor = System.Drawing.SystemColors.Control;
            this.tabElements.Controls.Add(this.panel2);
            this.tabElements.Location = new System.Drawing.Point(0, 0);
            this.tabElements.Name = "tabElements";
            this.tabElements.Size = new System.Drawing.Size(312, 183);
            this.tabElements.Text = "Display Element Options";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.chkUnadjBound);
            this.panel2.Controls.Add(this.chkUnadjMisc);
            this.panel2.Controls.Add(this.chkUnadjWaypoints);
            this.panel2.Controls.Add(this.chkUnadjNav);
            this.panel2.Controls.Add(this.chkFollowPos);
            this.panel2.Controls.Add(this.radUTM);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.radLatLon);
            this.panel2.Controls.Add(this.chkAdjBound);
            this.panel2.Controls.Add(this.chkDetails);
            this.panel2.Controls.Add(this.chkAdjNav);
            this.panel2.Controls.Add(this.chkCloseBnd);
            this.panel2.Controls.Add(this.chkAdjMisc);
            this.panel2.Controls.Add(this.chkUnadjMyGPS);
            this.panel2.Controls.Add(this.btnExit2);
            this.panel2.Controls.Add(this.btnDraw2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 183);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(157, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 20);
            this.label3.Text = "Unadjusted Elements";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkUnadjBound
            // 
            this.chkUnadjBound.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUnadjBound.Location = new System.Drawing.Point(157, 27);
            this.chkUnadjBound.Name = "chkUnadjBound";
            this.chkUnadjBound.Size = new System.Drawing.Size(130, 20);
            this.chkUnadjBound.TabIndex = 2;
            this.chkUnadjBound.Text = "Boundary Trail";
            this.chkUnadjBound.CheckStateChanged += new System.EventHandler(this.chkUnadjBound_CheckStateChanged);
            // 
            // chkUnadjMisc
            // 
            this.chkUnadjMisc.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUnadjMisc.Location = new System.Drawing.Point(157, 73);
            this.chkUnadjMisc.Name = "chkUnadjMisc";
            this.chkUnadjMisc.Size = new System.Drawing.Size(100, 20);
            this.chkUnadjMisc.TabIndex = 3;
            this.chkUnadjMisc.Text = "Misc Points";
            this.chkUnadjMisc.CheckStateChanged += new System.EventHandler(this.chkUnadjMisc_CheckStateChanged);
            // 
            // chkUnadjWaypoints
            // 
            this.chkUnadjWaypoints.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUnadjWaypoints.Location = new System.Drawing.Point(157, 95);
            this.chkUnadjWaypoints.Name = "chkUnadjWaypoints";
            this.chkUnadjWaypoints.Size = new System.Drawing.Size(100, 20);
            this.chkUnadjWaypoints.TabIndex = 4;
            this.chkUnadjWaypoints.Text = "Waypoints";
            this.chkUnadjWaypoints.CheckStateChanged += new System.EventHandler(this.chkUnadjWaypoints_CheckStateChanged);
            // 
            // chkUnadjNav
            // 
            this.chkUnadjNav.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUnadjNav.Location = new System.Drawing.Point(157, 50);
            this.chkUnadjNav.Name = "chkUnadjNav";
            this.chkUnadjNav.Size = new System.Drawing.Size(130, 20);
            this.chkUnadjNav.TabIndex = 0;
            this.chkUnadjNav.Text = "Navigation Trail";
            this.chkUnadjNav.CheckStateChanged += new System.EventHandler(this.chkUnadjNav_CheckStateChanged);
            // 
            // chkFollowPos
            // 
            this.chkFollowPos.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkFollowPos.Location = new System.Drawing.Point(137, 121);
            this.chkFollowPos.Name = "chkFollowPos";
            this.chkFollowPos.Size = new System.Drawing.Size(111, 20);
            this.chkFollowPos.TabIndex = 12;
            this.chkFollowPos.Text = "Follow Position";
            this.chkFollowPos.CheckStateChanged += new System.EventHandler(this.chkFollowPos_CheckStateChanged);
            // 
            // radUTM
            // 
            this.radUTM.Enabled = false;
            this.radUTM.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radUTM.Location = new System.Drawing.Point(174, 143);
            this.radUTM.Name = "radUTM";
            this.radUTM.Size = new System.Drawing.Size(63, 20);
            this.radUTM.TabIndex = 17;
            this.radUTM.Text = "UTM";
            this.radUTM.CheckedChanged += new System.EventHandler(this.radUTM_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(11, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.Text = "Adjusted Elements";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // radLatLon
            // 
            this.radLatLon.Enabled = false;
            this.radLatLon.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radLatLon.Location = new System.Drawing.Point(84, 143);
            this.radLatLon.Name = "radLatLon";
            this.radLatLon.Size = new System.Drawing.Size(84, 20);
            this.radLatLon.TabIndex = 16;
            this.radLatLon.Text = "Lat / Lon";
            this.radLatLon.CheckedChanged += new System.EventHandler(this.radLatLon_CheckedChanged);
            // 
            // chkAdjBound
            // 
            this.chkAdjBound.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkAdjBound.Location = new System.Drawing.Point(11, 27);
            this.chkAdjBound.Name = "chkAdjBound";
            this.chkAdjBound.Size = new System.Drawing.Size(130, 20);
            this.chkAdjBound.TabIndex = 8;
            this.chkAdjBound.Text = "Boundary Trail";
            this.chkAdjBound.CheckStateChanged += new System.EventHandler(this.chkAdjBound_CheckStateChanged);
            // 
            // chkDetails
            // 
            this.chkDetails.Enabled = false;
            this.chkDetails.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkDetails.Location = new System.Drawing.Point(11, 143);
            this.chkDetails.Name = "chkDetails";
            this.chkDetails.Size = new System.Drawing.Size(76, 20);
            this.chkDetails.TabIndex = 15;
            this.chkDetails.Text = "Details";
            this.chkDetails.CheckStateChanged += new System.EventHandler(this.chkDetails_CheckStateChanged);
            // 
            // chkAdjNav
            // 
            this.chkAdjNav.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkAdjNav.Location = new System.Drawing.Point(11, 50);
            this.chkAdjNav.Name = "chkAdjNav";
            this.chkAdjNav.Size = new System.Drawing.Size(130, 20);
            this.chkAdjNav.TabIndex = 7;
            this.chkAdjNav.Text = "Navigation Trail";
            this.chkAdjNav.CheckStateChanged += new System.EventHandler(this.chkAdjNav_CheckStateChanged);
            // 
            // chkCloseBnd
            // 
            this.chkCloseBnd.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkCloseBnd.Location = new System.Drawing.Point(11, 99);
            this.chkCloseBnd.Name = "chkCloseBnd";
            this.chkCloseBnd.Size = new System.Drawing.Size(130, 20);
            this.chkCloseBnd.TabIndex = 9;
            this.chkCloseBnd.Text = "Close Boundaries";
            this.chkCloseBnd.CheckStateChanged += new System.EventHandler(this.chkCloseBnd_CheckStateChanged);
            // 
            // chkAdjMisc
            // 
            this.chkAdjMisc.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkAdjMisc.Location = new System.Drawing.Point(11, 76);
            this.chkAdjMisc.Name = "chkAdjMisc";
            this.chkAdjMisc.Size = new System.Drawing.Size(100, 20);
            this.chkAdjMisc.TabIndex = 9;
            this.chkAdjMisc.Text = "Misc Points";
            this.chkAdjMisc.CheckStateChanged += new System.EventHandler(this.chkAdjMisc_CheckStateChanged);
            // 
            // chkUnadjMyGPS
            // 
            this.chkUnadjMyGPS.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkUnadjMyGPS.Location = new System.Drawing.Point(11, 121);
            this.chkUnadjMyGPS.Name = "chkUnadjMyGPS";
            this.chkUnadjMyGPS.Size = new System.Drawing.Size(120, 20);
            this.chkUnadjMyGPS.TabIndex = 5;
            this.chkUnadjMyGPS.Text = "My Position";
            this.chkUnadjMyGPS.CheckStateChanged += new System.EventHandler(this.chkUnadjMyGPS_CheckStateChanged);
            // 
            // btnExit2
            // 
            this.btnExit2.Location = new System.Drawing.Point(7, 166);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(83, 20);
            this.btnExit2.TabIndex = 0;
            this.btnExit2.Text = "Exit";
            this.btnExit2.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDraw2
            // 
            this.btnDraw2.Location = new System.Drawing.Point(230, 166);
            this.btnDraw2.Name = "btnDraw2";
            this.btnDraw2.Size = new System.Drawing.Size(83, 20);
            this.btnDraw2.TabIndex = 0;
            this.btnDraw2.Text = "Draw Map";
            this.btnDraw2.Click += new System.EventHandler(this.btnDrawMap_Click);
            // 
            // MapOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.Controls.Add(this.tabControl);
            this.KeyPreview = true;
            this.Name = "MapOptionsForm";
            this.Text = "Map Display Setup";
            this.tabControl.ResumeLayout(false);
            this.tabDisplay.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabElements.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDisplay;
        private System.Windows.Forms.ComboBox cboLabels;
        private System.Windows.Forms.CheckBox chkPoints;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDrawMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSkip;
        private System.Windows.Forms.CheckBox chkLines;
        private System.Windows.Forms.CheckBox chkLegend;
        private System.Windows.Forms.TabPage tabElements;
        private System.Windows.Forms.CheckBox chkUnadjBound;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkUnadjNav;
        private System.Windows.Forms.CheckBox chkAdjMisc;
        private System.Windows.Forms.CheckBox chkAdjBound;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAdjNav;
        private System.Windows.Forms.CheckBox chkUnadjMyGPS;
        private System.Windows.Forms.CheckBox chkUnadjWaypoints;
        private System.Windows.Forms.CheckBox chkUnadjMisc;
        private System.Windows.Forms.ListView lstPolygons;
        private System.Windows.Forms.CheckBox chkFollowPos;
        private System.Windows.Forms.RadioButton radLatLon;
        private System.Windows.Forms.CheckBox chkDetails;
        private System.Windows.Forms.RadioButton radUTM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkUseMap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.Button btnDraw2;
        private System.Windows.Forms.CheckBox chkCloseBnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBackground;
        private System.Windows.Forms.Button btnBackground;
    }
}