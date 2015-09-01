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
            this.components = new System.ComponentModel.Container();
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.lblLoc = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.radLatLon = new System.Windows.Forms.RadioButton();
            this.radUTM = new System.Windows.Forms.RadioButton();
            this.chkDetails = new System.Windows.Forms.CheckBox();
            this.chkFollowPos = new System.Windows.Forms.CheckBox();
            this.chkMyPos = new System.Windows.Forms.CheckBox();
            this.chkInvert = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlMoveImage = new System.Windows.Forms.Panel();
            this.picCenter = new System.Windows.Forms.PictureBox();
            this.picDown = new System.Windows.Forms.PictureBox();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.picUp = new System.Windows.Forms.PictureBox();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.tmrMovePad = new System.Windows.Forms.Timer(this.components);
            this.constMove = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxmsPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.chkLabels = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            this.drawPanel.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.pnlMoveImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // zoomBar
            // 
            this.zoomBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomBar.Location = new System.Drawing.Point(0, 533);
            this.zoomBar.Maximum = 20;
            this.zoomBar.Minimum = 1;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(684, 45);
            this.zoomBar.TabIndex = 0;
            this.zoomBar.TabStop = false;
            this.zoomBar.Tag = "Zoom Map";
            this.zoomBar.Value = 1;
            this.zoomBar.Visible = false;
            this.zoomBar.Scroll += new System.EventHandler(this.zoomBar_Scroll);
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = System.Drawing.Color.White;
            this.drawPanel.Controls.Add(this.lblLoc);
            this.drawPanel.Controls.Add(this.pnlSettings);
            this.drawPanel.Controls.Add(this.btnClose);
            this.drawPanel.Controls.Add(this.btnSettings);
            this.drawPanel.Controls.Add(this.pnlMoveImage);
            this.drawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawPanel.Location = new System.Drawing.Point(0, 0);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(684, 562);
            this.drawPanel.TabIndex = 1;
            this.drawPanel.DoubleClick += new System.EventHandler(this.drawPanel_DoubleClick);
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel_Paint);
            this.drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseMove);
            this.drawPanel.Click += new System.EventHandler(this.drawPanel_Click);
            this.drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseDown);
            // 
            // lblLoc
            // 
            this.lblLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoc.AutoSize = true;
            this.lblLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoc.Location = new System.Drawing.Point(5, 546);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(51, 16);
            this.lblLoc.TabIndex = 4;
            this.lblLoc.Text = "label1";
            this.lblLoc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblLoc.Visible = false;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSettings.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlSettings.Controls.Add(this.radLatLon);
            this.pnlSettings.Controls.Add(this.radUTM);
            this.pnlSettings.Controls.Add(this.chkDetails);
            this.pnlSettings.Controls.Add(this.chkFollowPos);
            this.pnlSettings.Controls.Add(this.chkMyPos);
            this.pnlSettings.Controls.Add(this.chkLabels);
            this.pnlSettings.Controls.Add(this.chkInvert);
            this.pnlSettings.Location = new System.Drawing.Point(275, 150);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(150, 200);
            this.pnlSettings.TabIndex = 3;
            this.pnlSettings.Visible = false;
            // 
            // radLatLon
            // 
            this.radLatLon.AutoSize = true;
            this.radLatLon.Enabled = false;
            this.radLatLon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLatLon.Location = new System.Drawing.Point(32, 171);
            this.radLatLon.Name = "radLatLon";
            this.radLatLon.Size = new System.Drawing.Size(85, 20);
            this.radLatLon.TabIndex = 1;
            this.radLatLon.Text = "Lat / Lon";
            this.radLatLon.UseVisualStyleBackColor = true;
            this.radLatLon.CheckedChanged += new System.EventHandler(this.radLatLon_CheckedChanged);
            // 
            // radUTM
            // 
            this.radUTM.AutoSize = true;
            this.radUTM.Checked = true;
            this.radUTM.Enabled = false;
            this.radUTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radUTM.Location = new System.Drawing.Point(32, 145);
            this.radUTM.Name = "radUTM";
            this.radUTM.Size = new System.Drawing.Size(59, 20);
            this.radUTM.TabIndex = 1;
            this.radUTM.TabStop = true;
            this.radUTM.Text = "UTM";
            this.radUTM.UseVisualStyleBackColor = true;
            this.radUTM.CheckedChanged += new System.EventHandler(this.radUTM_CheckedChanged);
            // 
            // chkDetails
            // 
            this.chkDetails.AutoSize = true;
            this.chkDetails.Enabled = false;
            this.chkDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDetails.Location = new System.Drawing.Point(20, 119);
            this.chkDetails.Name = "chkDetails";
            this.chkDetails.Size = new System.Drawing.Size(117, 20);
            this.chkDetails.TabIndex = 0;
            this.chkDetails.TabStop = false;
            this.chkDetails.Text = "Show Details";
            this.chkDetails.UseVisualStyleBackColor = true;
            this.chkDetails.CheckedChanged += new System.EventHandler(this.chkDetails_CheckedChanged);
            // 
            // chkFollowPos
            // 
            this.chkFollowPos.AutoSize = true;
            this.chkFollowPos.Enabled = false;
            this.chkFollowPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFollowPos.Location = new System.Drawing.Point(20, 93);
            this.chkFollowPos.Name = "chkFollowPos";
            this.chkFollowPos.Size = new System.Drawing.Size(132, 20);
            this.chkFollowPos.TabIndex = 0;
            this.chkFollowPos.TabStop = false;
            this.chkFollowPos.Text = "Follow Position";
            this.chkFollowPos.UseVisualStyleBackColor = true;
            this.chkFollowPos.CheckedChanged += new System.EventHandler(this.chkFollowPos_CheckedChanged);
            // 
            // chkMyPos
            // 
            this.chkMyPos.AutoSize = true;
            this.chkMyPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMyPos.Location = new System.Drawing.Point(10, 67);
            this.chkMyPos.Name = "chkMyPos";
            this.chkMyPos.Size = new System.Drawing.Size(107, 20);
            this.chkMyPos.TabIndex = 0;
            this.chkMyPos.TabStop = false;
            this.chkMyPos.Text = "My Position";
            this.chkMyPos.UseVisualStyleBackColor = true;
            this.chkMyPos.CheckedChanged += new System.EventHandler(this.chkMyPos_CheckedChanged);
            // 
            // chkInvert
            // 
            this.chkInvert.AutoSize = true;
            this.chkInvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInvert.Location = new System.Drawing.Point(10, 15);
            this.chkInvert.Name = "chkInvert";
            this.chkInvert.Size = new System.Drawing.Size(126, 20);
            this.chkInvert.TabIndex = 0;
            this.chkInvert.TabStop = false;
            this.chkInvert.Text = "Invert Controls";
            this.chkInvert.UseVisualStyleBackColor = true;
            this.chkInvert.CheckedChanged += new System.EventHandler(this.chkInvert_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(12, 504);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(597, 504);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.TabStop = false;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Visible = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlMoveImage
            // 
            this.pnlMoveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMoveImage.Controls.Add(this.picCenter);
            this.pnlMoveImage.Controls.Add(this.picDown);
            this.pnlMoveImage.Controls.Add(this.picRight);
            this.pnlMoveImage.Controls.Add(this.picUp);
            this.pnlMoveImage.Controls.Add(this.picLeft);
            this.pnlMoveImage.Location = new System.Drawing.Point(597, 12);
            this.pnlMoveImage.Name = "pnlMoveImage";
            this.pnlMoveImage.Size = new System.Drawing.Size(75, 75);
            this.pnlMoveImage.TabIndex = 0;
            this.pnlMoveImage.Visible = false;
            // 
            // picCenter
            // 
            this.picCenter.Image = global::TwoTrails.Properties.Resources._8_direction;
            this.picCenter.InitialImage = global::TwoTrails.Properties.Resources._8_direction;
            this.picCenter.Location = new System.Drawing.Point(25, 25);
            this.picCenter.Name = "picCenter";
            this.picCenter.Size = new System.Drawing.Size(25, 25);
            this.picCenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCenter.TabIndex = 0;
            this.picCenter.TabStop = false;
            this.picCenter.Tag = "Center Map";
            this.picCenter.Click += new System.EventHandler(this.picCenter_Click);
            // 
            // picDown
            // 
            this.picDown.Image = global::TwoTrails.Properties.Resources.arrow_down;
            this.picDown.InitialImage = global::TwoTrails.Properties.Resources.arrow_down;
            this.picDown.Location = new System.Drawing.Point(25, 50);
            this.picDown.Name = "picDown";
            this.picDown.Size = new System.Drawing.Size(25, 25);
            this.picDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDown.TabIndex = 0;
            this.picDown.TabStop = false;
            this.picDown.Tag = "Move Down";
            this.picDown.Click += new System.EventHandler(this.picDown_Click);
            this.picDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDown_MouseDown);
            this.picDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picDown_MouseUp);
            // 
            // picRight
            // 
            this.picRight.Image = global::TwoTrails.Properties.Resources.arrow_right;
            this.picRight.InitialImage = global::TwoTrails.Properties.Resources.arrow_right;
            this.picRight.Location = new System.Drawing.Point(50, 25);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(25, 25);
            this.picRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRight.TabIndex = 0;
            this.picRight.TabStop = false;
            this.picRight.Tag = "Move Right";
            this.picRight.Click += new System.EventHandler(this.picRight_Click);
            this.picRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picRight_MouseDown);
            this.picRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picRight_MouseUp);
            // 
            // picUp
            // 
            this.picUp.Image = global::TwoTrails.Properties.Resources.arrow_up;
            this.picUp.InitialImage = global::TwoTrails.Properties.Resources.arrow_up;
            this.picUp.Location = new System.Drawing.Point(25, 0);
            this.picUp.Name = "picUp";
            this.picUp.Size = new System.Drawing.Size(25, 25);
            this.picUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUp.TabIndex = 0;
            this.picUp.TabStop = false;
            this.picUp.Tag = "Move Up";
            this.picUp.Click += new System.EventHandler(this.picUp_Click);
            this.picUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picUp_MouseDown);
            this.picUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picUp_MouseUp);
            // 
            // picLeft
            // 
            this.picLeft.Image = global::TwoTrails.Properties.Resources.arrow_left;
            this.picLeft.InitialImage = global::TwoTrails.Properties.Resources.arrow_left;
            this.picLeft.Location = new System.Drawing.Point(0, 25);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(25, 25);
            this.picLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLeft.TabIndex = 0;
            this.picLeft.TabStop = false;
            this.picLeft.Tag = "Move Left";
            this.picLeft.Click += new System.EventHandler(this.picLeft_Click);
            this.picLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLeft_MouseDown);
            this.picLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picLeft_MouseUp);
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
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxmsPrint});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(141, 26);
            // 
            // ctxmsPrint
            // 
            this.ctxmsPrint.Name = "ctxmsPrint";
            this.ctxmsPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.ctxmsPrint.Size = new System.Drawing.Size(140, 22);
            this.ctxmsPrint.Text = "Print";
            this.ctxmsPrint.Click += new System.EventHandler(this.ctxmsPrint_Click);
            // 
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // chkLabels
            // 
            this.chkLabels.AutoSize = true;
            this.chkLabels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLabels.Location = new System.Drawing.Point(10, 41);
            this.chkLabels.Name = "chkLabels";
            this.chkLabels.Size = new System.Drawing.Size(115, 20);
            this.chkLabels.TabIndex = 0;
            this.chkLabels.TabStop = false;
            this.chkLabels.Text = "Show Labels";
            this.chkLabels.UseVisualStyleBackColor = true;
            this.chkLabels.CheckedChanged += new System.EventHandler(this.chkLabels_CheckedChanged);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 562);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.zoomBar);
            this.Controls.Add(this.drawPanel);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "MapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TwoTrails - Map";
            this.Load += new System.EventHandler(this.MapForm_Load);
            this.Resize += new System.EventHandler(this.MapForm_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            this.drawPanel.ResumeLayout(false);
            this.drawPanel.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.pnlMoveImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar zoomBar;
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.Panel pnlMoveImage;
        private System.Windows.Forms.PictureBox picCenter;
        private System.Windows.Forms.PictureBox picDown;
        private System.Windows.Forms.PictureBox picRight;
        private System.Windows.Forms.PictureBox picUp;
        private System.Windows.Forms.PictureBox picLeft;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.CheckBox chkDetails;
        private System.Windows.Forms.CheckBox chkFollowPos;
        private System.Windows.Forms.CheckBox chkMyPos;
        private System.Windows.Forms.CheckBox chkInvert;
        private System.Windows.Forms.RadioButton radLatLon;
        private System.Windows.Forms.RadioButton radUTM;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.Timer tmrMovePad;
        private System.Windows.Forms.Timer constMove;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ctxmsPrint;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.CheckBox chkLabels;
    }
}