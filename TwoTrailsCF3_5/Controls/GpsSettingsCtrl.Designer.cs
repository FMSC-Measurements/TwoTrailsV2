namespace TwoTrails.Controls
{
    partial class GpsSettingsCtrl
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
            this.cboGpsPort = new System.Windows.Forms.ComboBox();
            this.btnCheckGps = new System.Windows.Forms.Button();
            this.cboGpsBaud = new System.Windows.Forms.ComboBox();
            this.btnAutoGps = new System.Windows.Forms.Button();
            this.txtGpsOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGpsPort = new System.Windows.Forms.Button();
            this.btnGpsBaud = new System.Windows.Forms.Button();
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
            this.label1.Text = "GPS";
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
            // cboGpsPort
            // 
            this.cboGpsPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGpsPort.Location = new System.Drawing.Point(66, 27);
            this.cboGpsPort.Name = "cboGpsPort";
            this.cboGpsPort.Size = new System.Drawing.Size(80, 22);
            this.cboGpsPort.TabIndex = 3;
            this.cboGpsPort.TabStop = false;
            this.cboGpsPort.SelectedIndexChanged += new System.EventHandler(this.cboGpsPort_SelectedIndexChanged);
            // 
            // btnCheckGps
            // 
            this.btnCheckGps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckGps.Location = new System.Drawing.Point(151, 54);
            this.btnCheckGps.Name = "btnCheckGps";
            this.btnCheckGps.Size = new System.Drawing.Size(86, 20);
            this.btnCheckGps.TabIndex = 2;
            this.btnCheckGps.TabStop = false;
            this.btnCheckGps.Tag = "Checks GPS Settings";
            this.btnCheckGps.Text = "Check";
            this.btnCheckGps.Click += new System.EventHandler(this.btnCheckGps_Click);
            // 
            // cboGpsBaud
            // 
            this.cboGpsBaud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGpsBaud.Location = new System.Drawing.Point(65, 52);
            this.cboGpsBaud.Name = "cboGpsBaud";
            this.cboGpsBaud.Size = new System.Drawing.Size(80, 22);
            this.cboGpsBaud.TabIndex = 1;
            this.cboGpsBaud.TabStop = false;
            this.cboGpsBaud.SelectedIndexChanged += new System.EventHandler(this.cboGpsBaud_SelectedIndexChanged);
            // 
            // btnAutoGps
            // 
            this.btnAutoGps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoGps.Location = new System.Drawing.Point(152, 27);
            this.btnAutoGps.Name = "btnAutoGps";
            this.btnAutoGps.Size = new System.Drawing.Size(85, 20);
            this.btnAutoGps.TabIndex = 6;
            this.btnAutoGps.TabStop = false;
            this.btnAutoGps.Tag = "Finds Port and Baud";
            this.btnAutoGps.Text = "Auto GPS";
            this.btnAutoGps.Click += new System.EventHandler(this.btnAutoGps_Click);
            // 
            // txtGpsOutput
            // 
            this.txtGpsOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGpsOutput.BackColor = System.Drawing.SystemColors.Control;
            this.txtGpsOutput.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtGpsOutput.Location = new System.Drawing.Point(3, 80);
            this.txtGpsOutput.Name = "txtGpsOutput";
            this.txtGpsOutput.ReadOnly = true;
            this.txtGpsOutput.Size = new System.Drawing.Size(233, 23);
            this.txtGpsOutput.TabIndex = 7;
            this.txtGpsOutput.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.Text = "Baud:";
            // 
            // btnGpsPort
            // 
            this.btnGpsPort.Location = new System.Drawing.Point(66, 27);
            this.btnGpsPort.Name = "btnGpsPort";
            this.btnGpsPort.Size = new System.Drawing.Size(80, 22);
            this.btnGpsPort.TabIndex = 10;
            this.btnGpsPort.TabStop = false;
            this.btnGpsPort.Text = "Port";
            this.btnGpsPort.Click += new System.EventHandler(this.btnGpsPort_Click);
            // 
            // btnGpsBaud
            // 
            this.btnGpsBaud.Location = new System.Drawing.Point(65, 52);
            this.btnGpsBaud.Name = "btnGpsBaud";
            this.btnGpsBaud.Size = new System.Drawing.Size(80, 22);
            this.btnGpsBaud.TabIndex = 11;
            this.btnGpsBaud.TabStop = false;
            this.btnGpsBaud.Text = "Baud";
            this.btnGpsBaud.Click += new System.EventHandler(this.btnGpsBaud_Click);
            // 
            // pnlOtherChoice
            // 
            this.pnlOtherChoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnHelp.Location = new System.Drawing.Point(184, 80);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(52, 23);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.Text = "Help";
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // GpsSettingsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pnlOtherChoice);
            this.Controls.Add(this.btnGpsBaud);
            this.Controls.Add(this.btnGpsPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGpsOutput);
            this.Controls.Add(this.btnAutoGps);
            this.Controls.Add(this.cboGpsBaud);
            this.Controls.Add(this.btnCheckGps);
            this.Controls.Add(this.cboGpsPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GpsSettingsCtrl";
            this.Size = new System.Drawing.Size(240, 110);
            this.pnlOtherChoice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGpsPort;
        private System.Windows.Forms.Button btnCheckGps;
        private System.Windows.Forms.ComboBox cboGpsBaud;
        private System.Windows.Forms.Button btnAutoGps;
        private System.Windows.Forms.TextBox txtGpsOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGpsPort;
        private System.Windows.Forms.Button btnGpsBaud;
        private System.Windows.Forms.Panel pnlOtherChoice;
        private System.Windows.Forms.Button btnOkChoice;
        private System.Windows.Forms.TextBox txtPortValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtBaudValue;
        private System.Windows.Forms.Button btnHelp;
    }
}
