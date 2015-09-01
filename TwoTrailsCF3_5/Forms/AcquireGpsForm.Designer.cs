namespace TwoTrails.Forms
{
    partial class AcquireGpsForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRecieved = new System.Windows.Forms.Label();
            this.lblLogged = new System.Windows.Forms.Label();
            this.gpsInfoAdvCtrl = new TwoTrails.Controls.GpsInfoAdvCtrl();
            this.pnlLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(3, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLog
            // 
            this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLog.Location = new System.Drawing.Point(79, 266);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(82, 25);
            this.btnLog.TabIndex = 1;
            this.btnLog.Text = "Log GPS";
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(167, 266);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Calculate";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlLog
            // 
            this.pnlLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLog.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlLog.Controls.Add(this.label9);
            this.pnlLog.Controls.Add(this.label7);
            this.pnlLog.Controls.Add(this.label8);
            this.pnlLog.Controls.Add(this.lblRecieved);
            this.pnlLog.Controls.Add(this.lblLogged);
            this.pnlLog.Location = new System.Drawing.Point(0, 0);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(240, 29);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(153, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.Text = ":Received";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(-5, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.Text = " Logged:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(108, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 20);
            this.label8.Text = "-";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRecieved
            // 
            this.lblRecieved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecieved.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblRecieved.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecieved.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblRecieved.Location = new System.Drawing.Point(120, 6);
            this.lblRecieved.Name = "lblRecieved";
            this.lblRecieved.Size = new System.Drawing.Size(40, 20);
            this.lblRecieved.Text = "00";
            // 
            // lblLogged
            // 
            this.lblLogged.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogged.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLogged.Location = new System.Drawing.Point(66, 6);
            this.lblLogged.Name = "lblLogged";
            this.lblLogged.Size = new System.Drawing.Size(40, 20);
            this.lblLogged.Text = "00";
            this.lblLogged.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gpsInfoAdvCtrl
            // 
            this.gpsInfoAdvCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpsInfoAdvCtrl.Location = new System.Drawing.Point(0, 29);
            this.gpsInfoAdvCtrl.Name = "gpsInfoAdvCtrl";
            this.gpsInfoAdvCtrl.Size = new System.Drawing.Size(240, 150);
            this.gpsInfoAdvCtrl.TabIndex = 3;
            // 
            // AcquireGpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.gpsInfoAdvCtrl);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnCancel);
            this.Name = "AcquireGpsForm";
            this.Text = "Acquire Gps";
            this.Load += new System.EventHandler(this.AcquireGpsForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AcquireGpsForm_Closing);
            this.pnlLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRecieved = new System.Windows.Forms.Label();
            this.lblLogged = new System.Windows.Forms.Label();
            this.gpsInfoAdvCtrl = new TwoTrails.Controls.GpsInfoAdvCtrl();
            this.pnlLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(3, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLog
            // 
            this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLog.Location = new System.Drawing.Point(79, 186);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(162, 25);
            this.btnLog.TabIndex = 1;
            this.btnLog.Text = "Log Gps";
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(247, 186);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Calculate";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlLog
            // 
            this.pnlLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLog.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlLog.Controls.Add(this.label9);
            this.pnlLog.Controls.Add(this.label7);
            this.pnlLog.Controls.Add(this.label8);
            this.pnlLog.Controls.Add(this.lblRecieved);
            this.pnlLog.Controls.Add(this.lblLogged);
            this.pnlLog.Location = new System.Drawing.Point(0, 0);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(320, 29);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(233, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.Text = ":Received";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(-5, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.Text = " Logged:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(108, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.Text = "-";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRecieved
            // 
            this.lblRecieved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecieved.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblRecieved.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecieved.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblRecieved.Location = new System.Drawing.Point(199, 6);
            this.lblRecieved.Name = "lblRecieved";
            this.lblRecieved.Size = new System.Drawing.Size(40, 20);
            this.lblRecieved.Text = "00";
            // 
            // lblLogged
            // 
            this.lblLogged.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogged.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLogged.Location = new System.Drawing.Point(66, 6);
            this.lblLogged.Name = "lblLogged";
            this.lblLogged.Size = new System.Drawing.Size(40, 20);
            this.lblLogged.Text = "00";
            this.lblLogged.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gpsInfoAdvCtrl
            // 
            this.gpsInfoAdvCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpsInfoAdvCtrl.Location = new System.Drawing.Point(0, 29);
            this.gpsInfoAdvCtrl.Name = "gpsInfoAdvCtrl";
            this.gpsInfoAdvCtrl.Size = new System.Drawing.Size(320, 150);
            this.gpsInfoAdvCtrl.TabIndex = 3;
            // 
            // AcquireGpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.Controls.Add(this.gpsInfoAdvCtrl);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnCancel);
            this.ControlBox = false;
            this.Name = "AcquireGpsForm";
            this.Text = "Acquire Gps";
            this.Load += new System.EventHandler(this.AcquireGpsForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AcquireGpsForm_Closing);
            this.pnlLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Label lblLogged;
        private System.Windows.Forms.Label lblRecieved;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private TwoTrails.Controls.GpsInfoAdvCtrl gpsInfoAdvCtrl;
    }
}