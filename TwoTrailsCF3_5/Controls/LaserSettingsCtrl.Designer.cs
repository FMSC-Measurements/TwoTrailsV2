namespace TwoTrails.Controls
{
    partial class LaserSettingsCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLaserPort = new System.Windows.Forms.ComboBox();
            this.btnCheckLaser = new System.Windows.Forms.Button();
            this.cboLaserBaud = new System.Windows.Forms.ComboBox();
            this.btnAutoLaser = new System.Windows.Forms.Button();
            this.txtLaserOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLaserPort = new System.Windows.Forms.Button();
            this.btnLaserBaud = new System.Windows.Forms.Button();
            this.pnlOtherChoice = new System.Windows.Forms.Panel();
            this.txtBaudValue = new System.Windows.Forms.TextBox();
            this.btnOkChoice = new System.Windows.Forms.Button();
            this.txtPortValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pnlOtherChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 24);
            this.label1.Text = "Laser";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.Text = "Port:";
            // 
            // cboLaserPort
            // 
            this.cboLaserPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLaserPort.Location = new System.Drawing.Point(66, 27);
            this.cboLaserPort.Name = "cboLaserPort";
            this.cboLaserPort.Size = new System.Drawing.Size(80, 22);
            this.cboLaserPort.TabIndex = 3;
            this.cboLaserPort.TabStop = false;
            this.cboLaserPort.SelectedIndexChanged += new System.EventHandler(this.cboLaserPort_SelectedIndexChanged);
            // 
            // btnCheckLaser
            // 
            this.btnCheckLaser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckLaser.Location = new System.Drawing.Point(151, 54);
            this.btnCheckLaser.Name = "btnCheckLaser";
            this.btnCheckLaser.Size = new System.Drawing.Size(86, 20);
            this.btnCheckLaser.TabIndex = 2;
            this.btnCheckLaser.TabStop = false;
            this.btnCheckLaser.Tag = "Checks Laser Settings";
            this.btnCheckLaser.Text = "Check";
            this.btnCheckLaser.Click += new System.EventHandler(this.btnCheckLaser_Click);
            // 
            // cboLaserBaud
            // 
            this.cboLaserBaud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLaserBaud.Location = new System.Drawing.Point(65, 52);
            this.cboLaserBaud.Name = "cboLaserBaud";
            this.cboLaserBaud.Size = new System.Drawing.Size(80, 22);
            this.cboLaserBaud.TabIndex = 1;
            this.cboLaserBaud.TabStop = false;
            this.cboLaserBaud.SelectedIndexChanged += new System.EventHandler(this.cboLaserBaud_SelectedIndexChanged);
            // 
            // btnAutoLaser
            // 
            this.btnAutoLaser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoLaser.Location = new System.Drawing.Point(152, 27);
            this.btnAutoLaser.Name = "btnAutoLaser";
            this.btnAutoLaser.Size = new System.Drawing.Size(85, 20);
            this.btnAutoLaser.TabIndex = 6;
            this.btnAutoLaser.TabStop = false;
            this.btnAutoLaser.Tag = "Finds Port and Baud";
            this.btnAutoLaser.Text = "Auto Laser";
            this.btnAutoLaser.Click += new System.EventHandler(this.btnAutoLaser_Click);
            // 
            // txtLaserOutput
            // 
            this.txtLaserOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLaserOutput.BackColor = System.Drawing.SystemColors.Control;
            this.txtLaserOutput.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtLaserOutput.Location = new System.Drawing.Point(3, 80);
            this.txtLaserOutput.Name = "txtLaserOutput";
            this.txtLaserOutput.ReadOnly = true;
            this.txtLaserOutput.Size = new System.Drawing.Size(233, 23);
            this.txtLaserOutput.TabIndex = 7;
            this.txtLaserOutput.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.Text = "Baud:";
            // 
            // btnLaserPort
            // 
            this.btnLaserPort.Location = new System.Drawing.Point(66, 27);
            this.btnLaserPort.Name = "btnLaserPort";
            this.btnLaserPort.Size = new System.Drawing.Size(80, 22);
            this.btnLaserPort.TabIndex = 10;
            this.btnLaserPort.TabStop = false;
            this.btnLaserPort.Text = "Port";
            this.btnLaserPort.Click += new System.EventHandler(this.btnLaserPort_Click);
            // 
            // btnLaserBaud
            // 
            this.btnLaserBaud.Location = new System.Drawing.Point(65, 52);
            this.btnLaserBaud.Name = "btnLaserBaud";
            this.btnLaserBaud.Size = new System.Drawing.Size(80, 22);
            this.btnLaserBaud.TabIndex = 11;
            this.btnLaserBaud.TabStop = false;
            this.btnLaserBaud.Text = "Baud";
            this.btnLaserBaud.Click += new System.EventHandler(this.btnLaserBaud_Click);
            // 
            // pnlOtherChoice
            // 
            this.pnlOtherChoice.BackColor = System.Drawing.SystemColors.GrayText;
            this.pnlOtherChoice.Controls.Add(this.txtBaudValue);
            this.pnlOtherChoice.Controls.Add(this.btnOkChoice);
            this.pnlOtherChoice.Controls.Add(this.txtPortValue);
            this.pnlOtherChoice.Controls.Add(this.lblValue);
            this.pnlOtherChoice.Location = new System.Drawing.Point(0, 25);
            this.pnlOtherChoice.Name = "pnlOtherChoice";
            this.pnlOtherChoice.Size = new System.Drawing.Size(240, 50);
            this.pnlOtherChoice.Visible = false;
            // 
            // txtBaudValue
            // 
            this.txtBaudValue.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtBaudValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtBaudValue.Location = new System.Drawing.Point(94, 12);
            this.txtBaudValue.MaxLength = 6;
            this.txtBaudValue.Name = "txtBaudValue";
            this.txtBaudValue.Size = new System.Drawing.Size(62, 26);
            this.txtBaudValue.TabIndex = 3;
            this.txtBaudValue.TabStop = false;
            this.txtBaudValue.GotFocus += new System.EventHandler(this.txtBaudValue_GotFocus);
            this.txtBaudValue.LostFocus += new System.EventHandler(this.txtBaudValue_LostFocus);
            // 
            // btnOkChoice
            // 
            this.btnOkChoice.Location = new System.Drawing.Point(162, 15);
            this.btnOkChoice.Name = "btnOkChoice";
            this.btnOkChoice.Size = new System.Drawing.Size(58, 20);
            this.btnOkChoice.TabIndex = 2;
            this.btnOkChoice.Text = "OK";
            this.btnOkChoice.Click += new System.EventHandler(this.btnOkChoice_Click);
            // 
            // txtPortValue
            // 
            this.txtPortValue.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtPortValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtPortValue.Location = new System.Drawing.Point(94, 12);
            this.txtPortValue.MaxLength = 2;
            this.txtPortValue.Name = "txtPortValue";
            this.txtPortValue.Size = new System.Drawing.Size(62, 26);
            this.txtPortValue.TabIndex = 1;
            // 
            // lblValue
            // 
            this.lblValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblValue.Location = new System.Drawing.Point(3, 15);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(85, 20);
            this.lblValue.Text = "Value";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnHelp.Location = new System.Drawing.Point(184, 80);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(52, 23);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.Text = "Help";
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // LaserSettingsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pnlOtherChoice);
            this.Controls.Add(this.btnLaserBaud);
            this.Controls.Add(this.btnLaserPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLaserOutput);
            this.Controls.Add(this.btnAutoLaser);
            this.Controls.Add(this.cboLaserBaud);
            this.Controls.Add(this.btnCheckLaser);
            this.Controls.Add(this.cboLaserPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LaserSettingsCtrl";
            this.Size = new System.Drawing.Size(240, 110);
            this.pnlOtherChoice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLaserPort;
        private System.Windows.Forms.Button btnCheckLaser;
        private System.Windows.Forms.ComboBox cboLaserBaud;
        private System.Windows.Forms.Button btnAutoLaser;
        private System.Windows.Forms.TextBox txtLaserOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLaserPort;
        private System.Windows.Forms.Button btnLaserBaud;
        private System.Windows.Forms.Panel pnlOtherChoice;
        private System.Windows.Forms.Button btnOkChoice;
        private System.Windows.Forms.TextBox txtPortValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtBaudValue;
        private System.Windows.Forms.Button btnHelp;
    }
}
