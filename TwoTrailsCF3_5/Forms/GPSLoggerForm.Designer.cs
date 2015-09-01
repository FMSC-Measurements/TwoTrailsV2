namespace TwoTrails.Forms
{
    partial class GPSLoggerForm
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
            this.lstStrings = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.chkLogToFile = new System.Windows.Forms.CheckBox();
            this.btnOptions = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // lstStrings
            // 
            this.lstStrings.BackColor = System.Drawing.SystemColors.GrayText;
            this.lstStrings.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstStrings.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lstStrings.Location = new System.Drawing.Point(0, 0);
            this.lstStrings.Name = "lstStrings";
            this.lstStrings.Size = new System.Drawing.Size(240, 242);
            this.lstStrings.TabIndex = 0;
            this.lstStrings.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(3, 271);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLog
            // 
            this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLog.Location = new System.Drawing.Point(165, 271);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(72, 20);
            this.btnLog.TabIndex = 1;
            this.btnLog.TabStop = false;
            this.btnLog.Text = "Log";
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // chkLogToFile
            // 
            this.chkLogToFile.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkLogToFile.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLogToFile.Location = new System.Drawing.Point(3, 247);
            this.chkLogToFile.Name = "chkLogToFile";
            this.chkLogToFile.Size = new System.Drawing.Size(109, 20);
            this.chkLogToFile.TabIndex = 2;
            this.chkLogToFile.TabStop = false;
            this.chkLogToFile.Text = "Log To File";
            this.chkLogToFile.CheckStateChanged += new System.EventHandler(this.chkLogToFile_CheckStateChanged);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Enabled = false;
            this.btnOptions.Location = new System.Drawing.Point(81, 271);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(78, 20);
            this.btnOptions.TabIndex = 1;
            this.btnOptions.TabStop = false;
            this.btnOptions.Text = "Options";
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(101, 246);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(136, 21);
            this.txtFile.TabIndex = 3;
            this.txtFile.TabStop = false;
            this.txtFile.GotFocus += new System.EventHandler(this.txtFile_GotFocus);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            // 
            // GPSLoggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.chkLogToFile);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstStrings);
            this.Name = "GPSLoggerForm";
            this.Text = "GPS Logger";
            this.Load += new System.EventHandler(this.GPSLoggerForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.GPSLoggerForm_Closing);
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.lstStrings = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.chkLogToFile = new System.Windows.Forms.CheckBox();
            this.btnOptions = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // lstStrings
            // 
            this.lstStrings.BackColor = System.Drawing.SystemColors.GrayText;
            this.lstStrings.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstStrings.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lstStrings.Location = new System.Drawing.Point(0, 0);
            this.lstStrings.Name = "lstStrings";
            this.lstStrings.Size = new System.Drawing.Size(337, 162);
            this.lstStrings.TabIndex = 0;
            this.lstStrings.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(3, 191);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLog
            // 
            this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLog.Location = new System.Drawing.Point(262, 191);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(72, 20);
            this.btnLog.TabIndex = 1;
            this.btnLog.TabStop = false;
            this.btnLog.Text = "Log";
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // chkLogToFile
            // 
            this.chkLogToFile.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkLogToFile.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLogToFile.Location = new System.Drawing.Point(3, 168);
            this.chkLogToFile.Name = "chkLogToFile";
            this.chkLogToFile.Size = new System.Drawing.Size(109, 20);
            this.chkLogToFile.TabIndex = 2;
            this.chkLogToFile.TabStop = false;
            this.chkLogToFile.Text = "Log To File";
            this.chkLogToFile.CheckStateChanged += new System.EventHandler(this.chkLogToFile_CheckStateChanged);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Enabled = false;
            this.btnOptions.Location = new System.Drawing.Point(81, 191);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(175, 20);
            this.btnOptions.TabIndex = 1;
            this.btnOptions.TabStop = false;
            this.btnOptions.Text = "Options";
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(101, 167);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(136, 21);
            this.txtFile.TabIndex = 3;
            this.txtFile.TabStop = false;
            this.txtFile.GotFocus += new System.EventHandler(this.txtFile_GotFocus);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            // 
            // GPSLoggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(337, 214);
            this.ControlBox = false;
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.chkLogToFile);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstStrings);
            this.Name = "GPSLoggerForm";
            this.Text = "GPSLoggerForm";
            this.Load += new System.EventHandler(this.GPSLoggerForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.GPSLoggerForm_Closing);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ListBox lstStrings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.CheckBox chkLogToFile;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}