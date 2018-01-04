namespace TwoTrails.Forms
{
    partial class MapForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.lblLoc = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.radUTM = new System.Windows.Forms.RadioButton();
            this.radLatLon = new System.Windows.Forms.RadioButton();
            this.chkDetails = new System.Windows.Forms.CheckBox();
            this.chkFollowPos = new System.Windows.Forms.CheckBox();
            this.chkMyPos = new System.Windows.Forms.CheckBox();
            this.chkInvert = new System.Windows.Forms.CheckBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.pnlMoveImage = new System.Windows.Forms.Panel();
            this.picCenter = new System.Windows.Forms.PictureBox();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.picDown = new System.Windows.Forms.PictureBox();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.picUp = new System.Windows.Forms.PictureBox();
            this.tmrMovePad = new System.Windows.Forms.Timer();
            this.constMove = new System.Windows.Forms.Timer();
            this.btnT5 = new System.Windows.Forms.Button();
            this.progT5 = new System.Windows.Forms.ProgressBar();
            this.drawPanel.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.pnlMoveImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // zoomBar
            // 
            this.zoomBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomBar.BackColor = System.Drawing.SystemColors.Control;
            this.zoomBar.Location = new System.Drawing.Point(0, 267);
            this.zoomBar.Maximum = 20;
            this.zoomBar.Minimum = 1;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(240, 27);
            this.zoomBar.TabIndex = 0;
            this.zoomBar.TabStop = false;
            this.zoomBar.Tag = "Zoom Map";
            this.zoomBar.Value = 1;
            this.zoomBar.Visible = false;
            this.zoomBar.ValueChanged += new System.EventHandler(this.zoomBar_ValueChanged);
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = System.Drawing.Color.Transparent;
            this.drawPanel.Controls.Add(this.pnlSettings);
            this.drawPanel.Controls.Add(this.pnlMoveImage);
            this.drawPanel.Controls.Add(this.picClose);
            this.drawPanel.Controls.Add(this.progT5);
            this.drawPanel.Controls.Add(this.lblLoc);
            this.drawPanel.Controls.Add(this.btnT5);
            this.drawPanel.Controls.Add(this.btnSettings);
            this.drawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawPanel.Location = new System.Drawing.Point(0, 0);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(240, 294);
            this.drawPanel.DoubleClick += new System.EventHandler(this.drawPanel_DoubleClick);
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel_Paint);
            this.drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseMove);
            this.drawPanel.Click += new System.EventHandler(this.drawPanel_Click);
            this.drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseDown);
            // 
            // lblLoc
            // 
            this.lblLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblLoc.Location = new System.Drawing.Point(0, 279);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(240, 15);
            this.lblLoc.Visible = false;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(168, 241);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(72, 20);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.TabStop = false;
            this.btnSettings.Text = "Settings";
            this.btnSettings.Visible = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSettings.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSettings.Controls.Add(this.radUTM);
            this.pnlSettings.Controls.Add(this.radLatLon);
            this.pnlSettings.Controls.Add(this.chkDetails);
            this.pnlSettings.Controls.Add(this.chkFollowPos);
            this.pnlSettings.Controls.Add(this.chkMyPos);
            this.pnlSettings.Controls.Add(this.chkInvert);
            this.pnlSettings.Location = new System.Drawing.Point(50, 43);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(140, 185);
            this.pnlSettings.Visible = false;
            // 
            // radUTM
            // 
            this.radUTM.Checked = true;
            this.radUTM.Enabled = false;
            this.radUTM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radUTM.Location = new System.Drawing.Point(37, 135);
            this.radUTM.Name = "radUTM";
            this.radUTM.Size = new System.Drawing.Size(100, 20);
            this.radUTM.TabIndex = 4;
            this.radUTM.Text = "UTM";
            this.radUTM.CheckedChanged += new System.EventHandler(this.radUTM_CheckedChanged);
            // 
            // radLatLon
            // 
            this.radLatLon.Enabled = false;
            this.radLatLon.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radLatLon.Location = new System.Drawing.Point(37, 158);
            this.radLatLon.Name = "radLatLon";
            this.radLatLon.Size = new System.Drawing.Size(100, 20);
            this.radLatLon.TabIndex = 4;
            this.radLatLon.TabStop = false;
            this.radLatLon.Text = "Lat / Long";
            this.radLatLon.CheckedChanged += new System.EventHandler(this.radLatLon_CheckedChanged);
            // 
            // chkDetails
            // 
            this.chkDetails.Enabled = false;
            this.chkDetails.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkDetails.Location = new System.Drawing.Point(14, 112);
            this.chkDetails.Name = "chkDetails";
            this.chkDetails.Size = new System.Drawing.Size(123, 20);
            this.chkDetails.TabIndex = 3;
            this.chkDetails.Text = "Show Details";
            this.chkDetails.CheckStateChanged += new System.EventHandler(this.chkDetails_CheckStateChanged);
            // 
            // chkFollowPos
            // 
            this.chkFollowPos.Enabled = false;
            this.chkFollowPos.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkFollowPos.Location = new System.Drawing.Point(14, 86);
            this.chkFollowPos.Name = "chkFollowPos";
            this.chkFollowPos.Size = new System.Drawing.Size(123, 20);
            this.chkFollowPos.TabIndex = 2;
            this.chkFollowPos.Text = "Follow Position";
            this.chkFollowPos.CheckStateChanged += new System.EventHandler(this.chkFollowPos_CheckStateChanged);
            // 
            // chkMyPos
            // 
            this.chkMyPos.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkMyPos.Location = new System.Drawing.Point(3, 60);
            this.chkMyPos.Name = "chkMyPos";
            this.chkMyPos.Size = new System.Drawing.Size(134, 20);
            this.chkMyPos.TabIndex = 1;
            this.chkMyPos.Text = "Show Position";
            this.chkMyPos.CheckStateChanged += new System.EventHandler(this.chkMyPos_CheckStateChanged);
            // 
            // chkInvert
            // 
            this.chkInvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInvert.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkInvert.Location = new System.Drawing.Point(3, 8);
            this.chkInvert.Name = "chkInvert";
            this.chkInvert.Size = new System.Drawing.Size(128, 20);
            this.chkInvert.TabIndex = 0;
            this.chkInvert.Text = "Invert Controls";
            this.chkInvert.CheckStateChanged += new System.EventHandler(this.chkInvert_CheckStateChanged);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
            this.picClose.Location = new System.Drawing.Point(4, 4);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(30, 30);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.Tag = "Close";
            this.picClose.Visible = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // pnlMoveImage
            // 
            this.pnlMoveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMoveImage.BackColor = System.Drawing.Color.Transparent;
            this.pnlMoveImage.Controls.Add(this.picCenter);
            this.pnlMoveImage.Controls.Add(this.picLeft);
            this.pnlMoveImage.Controls.Add(this.picDown);
            this.pnlMoveImage.Controls.Add(this.picRight);
            this.pnlMoveImage.Controls.Add(this.picUp);
            this.pnlMoveImage.Location = new System.Drawing.Point(162, 3);
            this.pnlMoveImage.Name = "pnlMoveImage";
            this.pnlMoveImage.Size = new System.Drawing.Size(75, 75);
            this.pnlMoveImage.Visible = false;
            this.pnlMoveImage.Click += new System.EventHandler(this.pnlMoveImage_Click);
            // 
            // picCenter
            // 
            this.picCenter.BackColor = System.Drawing.Color.Transparent;
            this.picCenter.Image = ((System.Drawing.Image)(resources.GetObject("picCenter.Image")));
            this.picCenter.Location = new System.Drawing.Point(25, 25);
            this.picCenter.Name = "picCenter";
            this.picCenter.Size = new System.Drawing.Size(25, 25);
            this.picCenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCenter.Tag = "Center";
            this.picCenter.Click += new System.EventHandler(this.picCenter_Click);
            // 
            // picLeft
            // 
            this.picLeft.BackColor = System.Drawing.Color.Transparent;
            this.picLeft.Image = ((System.Drawing.Image)(resources.GetObject("picLeft.Image")));
            this.picLeft.Location = new System.Drawing.Point(0, 25);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(25, 25);
            this.picLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLeft.Tag = "Move Left";
            this.picLeft.Click += new System.EventHandler(this.picLeft_Click);
            this.picLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLeft_MouseDown);
            this.picLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picLeft_MouseUp);
            // 
            // picDown
            // 
            this.picDown.BackColor = System.Drawing.Color.Transparent;
            this.picDown.Image = ((System.Drawing.Image)(resources.GetObject("picDown.Image")));
            this.picDown.Location = new System.Drawing.Point(25, 50);
            this.picDown.Name = "picDown";
            this.picDown.Size = new System.Drawing.Size(25, 25);
            this.picDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDown.Tag = "Move Down";
            this.picDown.Click += new System.EventHandler(this.picDown_Click);
            this.picDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDown_MouseDown);
            this.picDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picDown_MouseUp);
            // 
            // picRight
            // 
            this.picRight.BackColor = System.Drawing.Color.Transparent;
            this.picRight.Image = ((System.Drawing.Image)(resources.GetObject("picRight.Image")));
            this.picRight.Location = new System.Drawing.Point(50, 25);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(25, 25);
            this.picRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRight.Tag = "Move Right";
            this.picRight.Click += new System.EventHandler(this.picRight_Click);
            this.picRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picRight_MouseDown);
            this.picRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picRight_MouseUp);
            // 
            // picUp
            // 
            this.picUp.BackColor = System.Drawing.Color.Transparent;
            this.picUp.Image = ((System.Drawing.Image)(resources.GetObject("picUp.Image")));
            this.picUp.Location = new System.Drawing.Point(25, 0);
            this.picUp.Name = "picUp";
            this.picUp.Size = new System.Drawing.Size(25, 25);
            this.picUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUp.Tag = "Move Up";
            this.picUp.Click += new System.EventHandler(this.picUp_Click);
            this.picUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picUp_MouseDown);
            this.picUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picUp_MouseUp);
            // 
            // tmrMovePad
            // 
            this.tmrMovePad.Interval = 1000;
            this.tmrMovePad.Tick += new System.EventHandler(this.tmrMovePad_Tick);
            // 
            // constMove
            // 
            this.constMove.Interval = 250;
            this.constMove.Tick += new System.EventHandler(this.constMove_Tick);
            // 
            // btnT5
            // 
            this.btnT5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnT5.Location = new System.Drawing.Point(87, 241);
            this.btnT5.Name = "btnT5";
            this.btnT5.Size = new System.Drawing.Size(72, 20);
            this.btnT5.TabIndex = 3;
            this.btnT5.TabStop = false;
            this.btnT5.Text = "Take 5";
            this.btnT5.Visible = false;
            this.btnT5.Click += new System.EventHandler(this.btnT5_Click);
            // 
            // progT5
            // 
            this.progT5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progT5.Location = new System.Drawing.Point(3, 215);
            this.progT5.Name = "progT5";
            this.progT5.Size = new System.Drawing.Size(234, 20);
            this.progT5.Visible = false;
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.zoomBar);
            this.Controls.Add(this.drawPanel);
            this.KeyPreview = true;
            this.Name = "MapForm";
            this.Text = "MapForm";
            this.Load += new System.EventHandler(this.MapForm_Load);
            this.Closed += new System.EventHandler(this.MapForm_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapForm_KeyDown);
            this.drawPanel.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.pnlMoveImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar zoomBar;
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.Timer tmrMovePad;
        private System.Windows.Forms.Panel pnlMoveImage;
        private System.Windows.Forms.PictureBox picCenter;
        private System.Windows.Forms.PictureBox picLeft;
        private System.Windows.Forms.PictureBox picDown;
        private System.Windows.Forms.PictureBox picRight;
        private System.Windows.Forms.PictureBox picUp;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Timer constMove;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.CheckBox chkInvert;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.CheckBox chkFollowPos;
        private System.Windows.Forms.CheckBox chkMyPos;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.CheckBox chkDetails;
        private System.Windows.Forms.RadioButton radLatLon;
        private System.Windows.Forms.RadioButton radUTM;
        private System.Windows.Forms.ProgressBar progT5;
        private System.Windows.Forms.Button btnT5;
    }
}