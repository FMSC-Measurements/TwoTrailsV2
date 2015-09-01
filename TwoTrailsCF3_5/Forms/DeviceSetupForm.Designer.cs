namespace TwoTrails.Forms
{
    partial class DeviceSetupForm
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
            this.gpsSettingsCtrl = new TwoTrails.Controls.GpsSettingsCtrl();
            this.laserSettingsCtrl = new TwoTrails.Controls.LaserSettingsCtrl();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gpsSettingsCtrl
            // 
            this.gpsSettingsCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpsSettingsCtrl.Location = new System.Drawing.Point(0, 0);
            this.gpsSettingsCtrl.Name = "gpsSettingsCtrl";
            this.gpsSettingsCtrl.Size = new System.Drawing.Size(240, 113);
            this.gpsSettingsCtrl.TabIndex = 0;
            this.gpsSettingsCtrl.TabStop = false;
            // 
            // laserSettingsCtrl
            // 
            this.laserSettingsCtrl.Location = new System.Drawing.Point(0, 113);
            this.laserSettingsCtrl.Name = "laserSettingsCtrl";
            this.laserSettingsCtrl.Size = new System.Drawing.Size(240, 113);
            this.laserSettingsCtrl.TabIndex = 1;
            this.laserSettingsCtrl.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(165, 266);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Save";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DeviceSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.laserSettingsCtrl);
            this.Controls.Add(this.gpsSettingsCtrl);
            this.Name = "DeviceSetupForm";
            this.Text = "Device Setup";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DeviceSetupForm_Closing);
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.gpsSettingsCtrl = new TwoTrails.Controls.GpsSettingsCtrl();
            this.laserSettingsCtrl = new TwoTrails.Controls.LaserSettingsCtrl();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gpsSettingsCtrl
            // 
            this.gpsSettingsCtrl.Location = new System.Drawing.Point(0, 0);
            this.gpsSettingsCtrl.Name = "gpsSettingsCtrl";
            this.gpsSettingsCtrl.Size = new System.Drawing.Size(240, 107);
            this.gpsSettingsCtrl.TabIndex = 0;
            this.gpsSettingsCtrl.TabStop = false;
            // 
            // laserSettingsCtrl
            // 
            this.laserSettingsCtrl.Location = new System.Drawing.Point(0, 107);
            this.laserSettingsCtrl.Name = "laserSettingsCtrl";
            this.laserSettingsCtrl.Size = new System.Drawing.Size(240, 107);
            this.laserSettingsCtrl.TabIndex = 1;
            this.laserSettingsCtrl.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(245, 186);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Save";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DeviceSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.laserSettingsCtrl);
            this.Controls.Add(this.gpsSettingsCtrl);
            this.Name = "DeviceSetupForm";
            this.Text = "Device Setup";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DeviceSetupForm_Closing);
            this.ResumeLayout(false);

        }
        #endregion

        private TwoTrails.Controls.GpsSettingsCtrl gpsSettingsCtrl;
        private TwoTrails.Controls.LaserSettingsCtrl laserSettingsCtrl;
        private System.Windows.Forms.Button btnClose;

    }
}