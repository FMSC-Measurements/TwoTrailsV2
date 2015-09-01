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
            this.components = new System.ComponentModel.Container();
            this.cboGpsBaud = new System.Windows.Forms.ComboBox();
            this.cboGpsPort = new System.Windows.Forms.ComboBox();
            this.btnAutoGps = new System.Windows.Forms.Button();
            this.btnCheckGps = new System.Windows.Forms.Button();
            this.txtGpsOutput = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlOtherChoice = new System.Windows.Forms.Panel();
            this.btnOkChoice = new System.Windows.Forms.Button();
            this.txtPortValue = new System.Windows.Forms.TextBox();
            this.txtBaudValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlOtherChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboGpsBaud
            // 
            this.cboGpsBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGpsBaud.FormattingEnabled = true;
            this.cboGpsBaud.Location = new System.Drawing.Point(50, 32);
            this.cboGpsBaud.Name = "cboGpsBaud";
            this.cboGpsBaud.Size = new System.Drawing.Size(133, 21);
            this.cboGpsBaud.TabIndex = 0;
            this.cboGpsBaud.TabStop = false;
            this.cboGpsBaud.SelectedIndexChanged += new System.EventHandler(this.cboGpsBaud_SelectedIndexChanged);
            // 
            // cboGpsPort
            // 
            this.cboGpsPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGpsPort.FormattingEnabled = true;
            this.cboGpsPort.Location = new System.Drawing.Point(50, 5);
            this.cboGpsPort.Name = "cboGpsPort";
            this.cboGpsPort.Size = new System.Drawing.Size(133, 21);
            this.cboGpsPort.TabIndex = 0;
            this.cboGpsPort.TabStop = false;
            this.cboGpsPort.SelectedIndexChanged += new System.EventHandler(this.cboGpsPort_SelectedIndexChanged);
            // 
            // btnAutoGps
            // 
            this.btnAutoGps.Location = new System.Drawing.Point(189, 3);
            this.btnAutoGps.Name = "btnAutoGps";
            this.btnAutoGps.Size = new System.Drawing.Size(75, 23);
            this.btnAutoGps.TabIndex = 1;
            this.btnAutoGps.Text = "Auto";
            this.btnAutoGps.UseVisualStyleBackColor = true;
            this.btnAutoGps.Click += new System.EventHandler(this.btnAutoGps_Click);
            // 
            // btnCheckGps
            // 
            this.btnCheckGps.Location = new System.Drawing.Point(189, 32);
            this.btnCheckGps.Name = "btnCheckGps";
            this.btnCheckGps.Size = new System.Drawing.Size(75, 23);
            this.btnCheckGps.TabIndex = 1;
            this.btnCheckGps.Text = "Check";
            this.btnCheckGps.UseVisualStyleBackColor = true;
            this.btnCheckGps.Click += new System.EventHandler(this.btnCheckGps_Click);
            // 
            // txtGpsOutput
            // 
            this.txtGpsOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGpsOutput.Location = new System.Drawing.Point(6, 59);
            this.txtGpsOutput.Name = "txtGpsOutput";
            this.txtGpsOutput.Size = new System.Drawing.Size(258, 22);
            this.txtGpsOutput.TabIndex = 2;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(214, 59);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(50, 22);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baud:";
            // 
            // pnlOtherChoice
            // 
            this.pnlOtherChoice.Controls.Add(this.btnOkChoice);
            this.pnlOtherChoice.Controls.Add(this.txtPortValue);
            this.pnlOtherChoice.Controls.Add(this.txtBaudValue);
            this.pnlOtherChoice.Controls.Add(this.lblValue);
            this.pnlOtherChoice.Location = new System.Drawing.Point(0, 16);
            this.pnlOtherChoice.Name = "pnlOtherChoice";
            this.pnlOtherChoice.Size = new System.Drawing.Size(267, 50);
            this.pnlOtherChoice.TabIndex = 4;
            this.pnlOtherChoice.Visible = false;
            // 
            // btnOkChoice
            // 
            this.btnOkChoice.Location = new System.Drawing.Point(178, 14);
            this.btnOkChoice.Name = "btnOkChoice";
            this.btnOkChoice.Size = new System.Drawing.Size(75, 23);
            this.btnOkChoice.TabIndex = 2;
            this.btnOkChoice.TabStop = false;
            this.btnOkChoice.Text = "OK";
            this.btnOkChoice.UseVisualStyleBackColor = true;
            this.btnOkChoice.Click += new System.EventHandler(this.btnOkChoice_Click);
            // 
            // txtPortValue
            // 
            this.txtPortValue.Location = new System.Drawing.Point(72, 16);
            this.txtPortValue.Name = "txtPortValue";
            this.txtPortValue.Size = new System.Drawing.Size(100, 20);
            this.txtPortValue.TabIndex = 1;
            this.txtPortValue.TabStop = false;
            // 
            // txtBaudValue
            // 
            this.txtBaudValue.Location = new System.Drawing.Point(72, 16);
            this.txtBaudValue.Name = "txtBaudValue";
            this.txtBaudValue.Size = new System.Drawing.Size(100, 20);
            this.txtBaudValue.TabIndex = 1;
            this.txtBaudValue.TabStop = false;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(14, 16);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(52, 16);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "Value:";
            // 
            // GpsSettingsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlOtherChoice);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCheckGps);
            this.Controls.Add(this.btnAutoGps);
            this.Controls.Add(this.cboGpsPort);
            this.Controls.Add(this.cboGpsBaud);
            this.Controls.Add(this.txtGpsOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "GpsSettingsCtrl";
            this.Size = new System.Drawing.Size(267, 84);
            this.pnlOtherChoice.ResumeLayout(false);
            this.pnlOtherChoice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboGpsBaud;
        private System.Windows.Forms.ComboBox cboGpsPort;
        private System.Windows.Forms.Button btnAutoGps;
        private System.Windows.Forms.Button btnCheckGps;
        private System.Windows.Forms.TextBox txtGpsOutput;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlOtherChoice;
        private System.Windows.Forms.Button btnOkChoice;
        private System.Windows.Forms.TextBox txtBaudValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtPortValue;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
