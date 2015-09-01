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
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gpsSettingsCtrl = new TwoTrails.Controls.GpsSettingsCtrl();
            this.laserSettingsCtrl1 = new TwoTrails.Controls.LaserSettingsCtrl();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(188, 210);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "GPS";
            // 
            // gpsSettingsCtrl1
            // 
            this.gpsSettingsCtrl.Location = new System.Drawing.Point(0, 20);
            this.gpsSettingsCtrl.Name = "gpsSettingsCtrl1";
            this.gpsSettingsCtrl.Size = new System.Drawing.Size(267, 84);
            this.gpsSettingsCtrl.TabIndex = 1;
            this.gpsSettingsCtrl.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Laser";
            // 
            // laserSettingsCtrl1
            // 
            this.laserSettingsCtrl1.Location = new System.Drawing.Point(0, 123);
            this.laserSettingsCtrl1.Name = "laserSettingsCtrl1";
            this.laserSettingsCtrl1.Size = new System.Drawing.Size(267, 84);
            this.laserSettingsCtrl1.TabIndex = 2;
            this.laserSettingsCtrl1.TabStop = false;
            // 
            // DeviceSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.laserSettingsCtrl1);
            this.Controls.Add(this.gpsSettingsCtrl);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(274, 262);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(274, 262);
            this.Name = "DeviceSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Device Setup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(DeviceSetupForm_FormClosing);
            this.Icon = Properties.Resources.Map;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private TwoTrails.Controls.GpsSettingsCtrl gpsSettingsCtrl;
        private TwoTrails.Controls.LaserSettingsCtrl laserSettingsCtrl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}