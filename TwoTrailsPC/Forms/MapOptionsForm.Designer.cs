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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDrawMap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radLatLon = new System.Windows.Forms.RadioButton();
            this.radUTM = new System.Windows.Forms.RadioButton();
            this.chkUnadjMisc = new System.Windows.Forms.CheckBox();
            this.chkUnadjNav = new System.Windows.Forms.CheckBox();
            this.chkDetails = new System.Windows.Forms.CheckBox();
            this.chkFollowPos = new System.Windows.Forms.CheckBox();
            this.chkAdjNav = new System.Windows.Forms.CheckBox();
            this.chkUnadjMyGPS = new System.Windows.Forms.CheckBox();
            this.chkUnadjWaypoints = new System.Windows.Forms.CheckBox();
            this.chkUnadjBound = new System.Windows.Forms.CheckBox();
            this.chkAdjMisc = new System.Windows.Forms.CheckBox();
            this.chkAdjBound = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSkip = new System.Windows.Forms.TextBox();
            this.txtBackground = new System.Windows.Forms.TextBox();
            this.btnBackground = new System.Windows.Forms.Button();
            this.chkLegend = new System.Windows.Forms.CheckBox();
            this.chkLines = new System.Windows.Forms.CheckBox();
            this.chkPoints = new System.Windows.Forms.CheckBox();
            this.lstPolygons = new System.Windows.Forms.ListView();
            this.chkUseMap = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCloseBnd = new System.Windows.Forms.CheckBox();
            this.cboLabels = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(4, 350);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDrawMap
            // 
            this.btnDrawMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawMap.Location = new System.Drawing.Point(603, 350);
            this.btnDrawMap.Margin = new System.Windows.Forms.Padding(4);
            this.btnDrawMap.Name = "btnDrawMap";
            this.btnDrawMap.Size = new System.Drawing.Size(100, 28);
            this.btnDrawMap.TabIndex = 2;
            this.btnDrawMap.Text = "Draw";
            this.btnDrawMap.UseVisualStyleBackColor = true;
            this.btnDrawMap.Click += new System.EventHandler(this.btnDrawMap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Unadjusted Elements";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 206);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Adjusted Elements";
            // 
            // radLatLon
            // 
            this.radLatLon.AutoSize = true;
            this.radLatLon.Enabled = false;
            this.radLatLon.Location = new System.Drawing.Point(555, 313);
            this.radLatLon.Margin = new System.Windows.Forms.Padding(4);
            this.radLatLon.Name = "radLatLon";
            this.radLatLon.Size = new System.Drawing.Size(85, 21);
            this.radLatLon.TabIndex = 38;
            this.radLatLon.Text = "Lat / Lon";
            this.radLatLon.UseVisualStyleBackColor = true;
            this.radLatLon.CheckedChanged += new System.EventHandler(this.radLatLon_CheckedChanged);
            // 
            // radUTM
            // 
            this.radUTM.AutoSize = true;
            this.radUTM.Enabled = false;
            this.radUTM.Location = new System.Drawing.Point(643, 313);
            this.radUTM.Margin = new System.Windows.Forms.Padding(4);
            this.radUTM.Name = "radUTM";
            this.radUTM.Size = new System.Drawing.Size(59, 21);
            this.radUTM.TabIndex = 39;
            this.radUTM.Text = "UTM";
            this.radUTM.UseVisualStyleBackColor = true;
            this.radUTM.CheckedChanged += new System.EventHandler(this.radUTM_CheckedChanged);
            // 
            // chkUnadjMisc
            // 
            this.chkUnadjMisc.AutoSize = true;
            this.chkUnadjMisc.Location = new System.Drawing.Point(339, 286);
            this.chkUnadjMisc.Margin = new System.Windows.Forms.Padding(4);
            this.chkUnadjMisc.Name = "chkUnadjMisc";
            this.chkUnadjMisc.Size = new System.Drawing.Size(101, 21);
            this.chkUnadjMisc.TabIndex = 36;
            this.chkUnadjMisc.TabStop = false;
            this.chkUnadjMisc.Text = "Misc Points";
            this.chkUnadjMisc.UseVisualStyleBackColor = true;
            this.chkUnadjMisc.CheckedChanged += new System.EventHandler(this.chkUnadjMisc_CheckedChanged);
            // 
            // chkUnadjNav
            // 
            this.chkUnadjNav.AutoSize = true;
            this.chkUnadjNav.Location = new System.Drawing.Point(339, 257);
            this.chkUnadjNav.Margin = new System.Windows.Forms.Padding(4);
            this.chkUnadjNav.Name = "chkUnadjNav";
            this.chkUnadjNav.Size = new System.Drawing.Size(129, 21);
            this.chkUnadjNav.TabIndex = 37;
            this.chkUnadjNav.TabStop = false;
            this.chkUnadjNav.Text = "Navigation Trail";
            this.chkUnadjNav.UseVisualStyleBackColor = true;
            this.chkUnadjNav.CheckedChanged += new System.EventHandler(this.chkUnadjNav_CheckedChanged);
            // 
            // chkDetails
            // 
            this.chkDetails.AutoSize = true;
            this.chkDetails.Enabled = false;
            this.chkDetails.Location = new System.Drawing.Point(459, 314);
            this.chkDetails.Margin = new System.Windows.Forms.Padding(4);
            this.chkDetails.Name = "chkDetails";
            this.chkDetails.Size = new System.Drawing.Size(83, 21);
            this.chkDetails.TabIndex = 35;
            this.chkDetails.TabStop = false;
            this.chkDetails.Text = "Gps Loc";
            this.chkDetails.UseVisualStyleBackColor = true;
            this.chkDetails.CheckedChanged += new System.EventHandler(this.chkDetails_CheckedChanged);
            // 
            // chkFollowPos
            // 
            this.chkFollowPos.AutoSize = true;
            this.chkFollowPos.Enabled = false;
            this.chkFollowPos.Location = new System.Drawing.Point(545, 286);
            this.chkFollowPos.Margin = new System.Windows.Forms.Padding(4);
            this.chkFollowPos.Name = "chkFollowPos";
            this.chkFollowPos.Size = new System.Drawing.Size(123, 21);
            this.chkFollowPos.TabIndex = 30;
            this.chkFollowPos.TabStop = false;
            this.chkFollowPos.Text = "Follow Position";
            this.chkFollowPos.UseVisualStyleBackColor = true;
            this.chkFollowPos.CheckedChanged += new System.EventHandler(this.chkFollowPos_CheckedChanged);
            // 
            // chkAdjNav
            // 
            this.chkAdjNav.AutoSize = true;
            this.chkAdjNav.Location = new System.Drawing.Point(132, 257);
            this.chkAdjNav.Margin = new System.Windows.Forms.Padding(4);
            this.chkAdjNav.Name = "chkAdjNav";
            this.chkAdjNav.Size = new System.Drawing.Size(129, 21);
            this.chkAdjNav.TabIndex = 29;
            this.chkAdjNav.TabStop = false;
            this.chkAdjNav.Text = "Navigation Trail";
            this.chkAdjNav.UseVisualStyleBackColor = true;
            this.chkAdjNav.CheckedChanged += new System.EventHandler(this.chkAdjNav_CheckedChanged);
            // 
            // chkUnadjMyGPS
            // 
            this.chkUnadjMyGPS.AutoSize = true;
            this.chkUnadjMyGPS.Location = new System.Drawing.Point(545, 257);
            this.chkUnadjMyGPS.Margin = new System.Windows.Forms.Padding(4);
            this.chkUnadjMyGPS.Name = "chkUnadjMyGPS";
            this.chkUnadjMyGPS.Size = new System.Drawing.Size(102, 21);
            this.chkUnadjMyGPS.TabIndex = 28;
            this.chkUnadjMyGPS.TabStop = false;
            this.chkUnadjMyGPS.Text = "My Position";
            this.chkUnadjMyGPS.UseVisualStyleBackColor = true;
            this.chkUnadjMyGPS.CheckedChanged += new System.EventHandler(this.chkUnadjMyGPS_CheckedChanged);
            // 
            // chkUnadjWaypoints
            // 
            this.chkUnadjWaypoints.AutoSize = true;
            this.chkUnadjWaypoints.Location = new System.Drawing.Point(545, 229);
            this.chkUnadjWaypoints.Margin = new System.Windows.Forms.Padding(4);
            this.chkUnadjWaypoints.Name = "chkUnadjWaypoints";
            this.chkUnadjWaypoints.Size = new System.Drawing.Size(96, 21);
            this.chkUnadjWaypoints.TabIndex = 33;
            this.chkUnadjWaypoints.TabStop = false;
            this.chkUnadjWaypoints.Text = "Waypoints";
            this.chkUnadjWaypoints.UseVisualStyleBackColor = true;
            this.chkUnadjWaypoints.CheckedChanged += new System.EventHandler(this.chkUnadjWaypoints_CheckedChanged);
            // 
            // chkUnadjBound
            // 
            this.chkUnadjBound.AutoSize = true;
            this.chkUnadjBound.Location = new System.Drawing.Point(339, 229);
            this.chkUnadjBound.Margin = new System.Windows.Forms.Padding(4);
            this.chkUnadjBound.Name = "chkUnadjBound";
            this.chkUnadjBound.Size = new System.Drawing.Size(123, 21);
            this.chkUnadjBound.TabIndex = 32;
            this.chkUnadjBound.TabStop = false;
            this.chkUnadjBound.Text = "Boundary Trail";
            this.chkUnadjBound.UseVisualStyleBackColor = true;
            this.chkUnadjBound.CheckedChanged += new System.EventHandler(this.chkUnadjBound_CheckedChanged);
            // 
            // chkAdjMisc
            // 
            this.chkAdjMisc.AutoSize = true;
            this.chkAdjMisc.Location = new System.Drawing.Point(132, 286);
            this.chkAdjMisc.Margin = new System.Windows.Forms.Padding(4);
            this.chkAdjMisc.Name = "chkAdjMisc";
            this.chkAdjMisc.Size = new System.Drawing.Size(101, 21);
            this.chkAdjMisc.TabIndex = 31;
            this.chkAdjMisc.TabStop = false;
            this.chkAdjMisc.Text = "Misc Points";
            this.chkAdjMisc.UseVisualStyleBackColor = true;
            this.chkAdjMisc.CheckedChanged += new System.EventHandler(this.chkAdjMisc_CheckedChanged);
            // 
            // chkAdjBound
            // 
            this.chkAdjBound.AutoSize = true;
            this.chkAdjBound.Location = new System.Drawing.Point(132, 229);
            this.chkAdjBound.Margin = new System.Windows.Forms.Padding(4);
            this.chkAdjBound.Name = "chkAdjBound";
            this.chkAdjBound.Size = new System.Drawing.Size(123, 21);
            this.chkAdjBound.TabIndex = 34;
            this.chkAdjBound.TabStop = false;
            this.chkAdjBound.Text = "Boundary Trail";
            this.chkAdjBound.UseVisualStyleBackColor = true;
            this.chkAdjBound.CheckedChanged += new System.EventHandler(this.chkAdjBound_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 324);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Skip Labels:";
            // 
            // txtSkip
            // 
            this.txtSkip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSkip.Enabled = false;
            this.txtSkip.Location = new System.Drawing.Point(112, 320);
            this.txtSkip.Margin = new System.Windows.Forms.Padding(4);
            this.txtSkip.Name = "txtSkip";
            this.txtSkip.Size = new System.Drawing.Size(132, 22);
            this.txtSkip.TabIndex = 25;
            this.txtSkip.TabStop = false;
            this.txtSkip.TextChanged += new System.EventHandler(this.txtSkip_TextChanged);
            // 
            // txtBackground
            // 
            this.txtBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackground.Location = new System.Drawing.Point(112, 352);
            this.txtBackground.Margin = new System.Windows.Forms.Padding(4);
            this.txtBackground.Name = "txtBackground";
            this.txtBackground.ReadOnly = true;
            this.txtBackground.Size = new System.Drawing.Size(277, 22);
            this.txtBackground.TabIndex = 26;
            this.txtBackground.TabStop = false;
            this.txtBackground.Visible = false;
            // 
            // btnBackground
            // 
            this.btnBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackground.Location = new System.Drawing.Point(399, 350);
            this.btnBackground.Margin = new System.Windows.Forms.Padding(4);
            this.btnBackground.Name = "btnBackground";
            this.btnBackground.Size = new System.Drawing.Size(100, 28);
            this.btnBackground.TabIndex = 24;
            this.btnBackground.TabStop = false;
            this.btnBackground.Text = "Background";
            this.btnBackground.UseVisualStyleBackColor = true;
            this.btnBackground.Visible = false;
            this.btnBackground.Click += new System.EventHandler(this.btnBackground_Click);
            // 
            // chkLegend
            // 
            this.chkLegend.AutoSize = true;
            this.chkLegend.Location = new System.Drawing.Point(4, 292);
            this.chkLegend.Margin = new System.Windows.Forms.Padding(4);
            this.chkLegend.Name = "chkLegend";
            this.chkLegend.Size = new System.Drawing.Size(78, 21);
            this.chkLegend.TabIndex = 21;
            this.chkLegend.TabStop = false;
            this.chkLegend.Text = "Legend";
            this.chkLegend.UseVisualStyleBackColor = true;
            // 
            // chkLines
            // 
            this.chkLines.AutoSize = true;
            this.chkLines.Checked = true;
            this.chkLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLines.Location = new System.Drawing.Point(4, 235);
            this.chkLines.Margin = new System.Windows.Forms.Padding(4);
            this.chkLines.Name = "chkLines";
            this.chkLines.Size = new System.Drawing.Size(64, 21);
            this.chkLines.TabIndex = 23;
            this.chkLines.TabStop = false;
            this.chkLines.Text = "Lines";
            this.chkLines.UseVisualStyleBackColor = true;
            this.chkLines.CheckedChanged += new System.EventHandler(this.chkLines_CheckedChanged);
            // 
            // chkPoints
            // 
            this.chkPoints.AutoSize = true;
            this.chkPoints.Checked = true;
            this.chkPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPoints.Location = new System.Drawing.Point(4, 207);
            this.chkPoints.Margin = new System.Windows.Forms.Padding(4);
            this.chkPoints.Name = "chkPoints";
            this.chkPoints.Size = new System.Drawing.Size(69, 21);
            this.chkPoints.TabIndex = 22;
            this.chkPoints.TabStop = false;
            this.chkPoints.Text = "Points";
            this.chkPoints.UseVisualStyleBackColor = true;
            this.chkPoints.CheckedChanged += new System.EventHandler(this.chkPoints_CheckedChanged);
            // 
            // lstPolygons
            // 
            this.lstPolygons.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstPolygons.FullRowSelect = true;
            this.lstPolygons.Location = new System.Drawing.Point(0, 0);
            this.lstPolygons.Margin = new System.Windows.Forms.Padding(4);
            this.lstPolygons.Name = "lstPolygons";
            this.lstPolygons.Size = new System.Drawing.Size(704, 198);
            this.lstPolygons.TabIndex = 19;
            this.lstPolygons.UseCompatibleStateImageBehavior = false;
            this.lstPolygons.View = System.Windows.Forms.View.Details;
            this.lstPolygons.SelectedIndexChanged += new System.EventHandler(this.lstPolygons_SelectedIndexChanged);
            // 
            // chkUseMap
            // 
            this.chkUseMap.AutoSize = true;
            this.chkUseMap.Enabled = false;
            this.chkUseMap.Location = new System.Drawing.Point(507, 354);
            this.chkUseMap.Margin = new System.Windows.Forms.Padding(4);
            this.chkUseMap.Name = "chkUseMap";
            this.chkUseMap.Size = new System.Drawing.Size(97, 21);
            this.chkUseMap.TabIndex = 42;
            this.chkUseMap.TabStop = false;
            this.chkUseMap.Text = "Use Image";
            this.chkUseMap.UseVisualStyleBackColor = true;
            this.chkUseMap.Visible = false;
            this.chkUseMap.CheckedChanged += new System.EventHandler(this.chkUseMap_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(529, 206);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "Misc Elements";
            // 
            // chkCloseBnd
            // 
            this.chkCloseBnd.AutoSize = true;
            this.chkCloseBnd.Location = new System.Drawing.Point(253, 322);
            this.chkCloseBnd.Margin = new System.Windows.Forms.Padding(4);
            this.chkCloseBnd.Name = "chkCloseBnd";
            this.chkCloseBnd.Size = new System.Drawing.Size(141, 21);
            this.chkCloseBnd.TabIndex = 43;
            this.chkCloseBnd.TabStop = false;
            this.chkCloseBnd.Text = "Close Boundaries";
            this.chkCloseBnd.UseVisualStyleBackColor = true;
            this.chkCloseBnd.CheckedChanged += new System.EventHandler(this.chkCloseBnd_CheckedChanged);
            // 
            // cboLabels
            // 
            this.cboLabels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLabels.FormattingEnabled = true;
            this.cboLabels.Location = new System.Drawing.Point(4, 264);
            this.cboLabels.Name = "cboLabels";
            this.cboLabels.Size = new System.Drawing.Size(121, 24);
            this.cboLabels.TabIndex = 44;
            this.cboLabels.SelectedIndexChanged += new System.EventHandler(this.cboLabels_SelectedIndexChanged);
            // 
            // MapOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 374);
            this.Controls.Add(this.cboLabels);
            this.Controls.Add(this.chkCloseBnd);
            this.Controls.Add(this.radUTM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radLatLon);
            this.Controls.Add(this.chkUnadjMisc);
            this.Controls.Add(this.chkUnadjNav);
            this.Controls.Add(this.chkDetails);
            this.Controls.Add(this.chkFollowPos);
            this.Controls.Add(this.chkAdjNav);
            this.Controls.Add(this.chkUnadjMyGPS);
            this.Controls.Add(this.chkUnadjWaypoints);
            this.Controls.Add(this.chkUnadjBound);
            this.Controls.Add(this.chkAdjMisc);
            this.Controls.Add(this.chkAdjBound);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSkip);
            this.Controls.Add(this.txtBackground);
            this.Controls.Add(this.btnBackground);
            this.Controls.Add(this.chkLegend);
            this.Controls.Add(this.chkLines);
            this.Controls.Add(this.chkPoints);
            this.Controls.Add(this.lstPolygons);
            this.Controls.Add(this.btnDrawMap);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.chkUseMap);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(722, 419);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(722, 419);
            this.Name = "MapOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Map Options";
            this.Load += new System.EventHandler(this.MapOptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDrawMap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radLatLon;
        private System.Windows.Forms.RadioButton radUTM;
        private System.Windows.Forms.CheckBox chkUnadjMisc;
        private System.Windows.Forms.CheckBox chkUnadjNav;
        private System.Windows.Forms.CheckBox chkDetails;
        private System.Windows.Forms.CheckBox chkFollowPos;
        private System.Windows.Forms.CheckBox chkAdjNav;
        private System.Windows.Forms.CheckBox chkUnadjMyGPS;
        private System.Windows.Forms.CheckBox chkUnadjWaypoints;
        private System.Windows.Forms.CheckBox chkUnadjBound;
        private System.Windows.Forms.CheckBox chkAdjMisc;
        private System.Windows.Forms.CheckBox chkAdjBound;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSkip;
        private System.Windows.Forms.TextBox txtBackground;
        private System.Windows.Forms.Button btnBackground;
        private System.Windows.Forms.CheckBox chkLegend;
        private System.Windows.Forms.CheckBox chkLines;
        private System.Windows.Forms.CheckBox chkPoints;
        private System.Windows.Forms.ListView lstPolygons;
        private System.Windows.Forms.CheckBox chkUseMap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkCloseBnd;
        private System.Windows.Forms.ComboBox cboLabels;
    }
}