namespace TwoTrails.Forms
{
    partial class WalkForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFreq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.btnFixType = new System.Windows.Forms.Button();
            this.btnDOP = new System.Windows.Forms.Button();
            this.txtDOP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.chkSound = new System.Windows.Forms.CheckBox();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPoly = new System.Windows.Forms.Label();
            this.cboDOP = new System.Windows.Forms.ComboBox();
            this.cboFixType = new System.Windows.Forms.ComboBox();
            this.txtIncrement = new System.Windows.Forms.TextBox();
            this.pnlSavePointIcon = new System.Windows.Forms.Panel();
            this.gpsInfoAdvCtrl = new TwoTrails.Controls.GpsInfoAdvCtrl();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(167, 266);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 25);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Stop";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapture.Location = new System.Drawing.Point(79, 266);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(82, 25);
            this.btnCapture.TabIndex = 9;
            this.btnCapture.Text = "Start";
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(3, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.Text = "Walk";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(4, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.Text = "Frequency:";
            // 
            // txtFreq
            // 
            this.txtFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFreq.Enabled = false;
            this.txtFreq.Location = new System.Drawing.Point(79, 178);
            this.txtFreq.Name = "txtFreq";
            this.txtFreq.Size = new System.Drawing.Size(40, 21);
            this.txtFreq.TabIndex = 13;
            this.txtFreq.TextChanged += new System.EventHandler(this.txtFreq_TextChanged);
            this.txtFreq.GotFocus += new System.EventHandler(this.txtFreq_GotFocus);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(10, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.Text = "Distance:";
            // 
            // txtAcc
            // 
            this.txtAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAcc.Enabled = false;
            this.txtAcc.Location = new System.Drawing.Point(79, 201);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(40, 21);
            this.txtAcc.TabIndex = 13;
            this.txtAcc.TextChanged += new System.EventHandler(this.txtAcc_TextChanged);
            this.txtAcc.GotFocus += new System.EventHandler(this.txtAcc_GotFocus);
            // 
            // btnFixType
            // 
            this.btnFixType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFixType.Enabled = false;
            this.btnFixType.Location = new System.Drawing.Point(167, 223);
            this.btnFixType.Name = "btnFixType";
            this.btnFixType.Size = new System.Drawing.Size(70, 22);
            this.btnFixType.TabIndex = 19;
            this.btnFixType.Text = "3D+DIFF";
            this.btnFixType.Click += new System.EventHandler(this.btnFixType_Click);
            // 
            // btnDOP
            // 
            this.btnDOP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDOP.Enabled = false;
            this.btnDOP.Location = new System.Drawing.Point(3, 223);
            this.btnDOP.Name = "btnDOP";
            this.btnDOP.Size = new System.Drawing.Size(70, 22);
            this.btnDOP.TabIndex = 18;
            this.btnDOP.Text = "PDOP";
            this.btnDOP.Click += new System.EventHandler(this.btnDOP_Click);
            // 
            // txtDOP
            // 
            this.txtDOP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDOP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDOP.Enabled = false;
            this.txtDOP.Location = new System.Drawing.Point(79, 224);
            this.txtDOP.Name = "txtDOP";
            this.txtDOP.Size = new System.Drawing.Size(40, 21);
            this.txtDOP.TabIndex = 17;
            this.txtDOP.GotFocus += new System.EventHandler(this.txtDOP_GotFocus);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(128, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 20);
            this.label4.Text = "Fix:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkLock
            // 
            this.chkLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLock.Checked = true;
            this.chkLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLock.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkLock.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLock.Location = new System.Drawing.Point(3, 245);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(70, 20);
            this.chkLock.TabIndex = 21;
            this.chkLock.Text = "Lock";
            this.chkLock.CheckStateChanged += new System.EventHandler(this.chkLock_CheckStateChanged);
            // 
            // chkSound
            // 
            this.chkSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSound.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkSound.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkSound.Location = new System.Drawing.Point(167, 245);
            this.chkSound.Name = "chkSound";
            this.chkSound.Size = new System.Drawing.Size(70, 20);
            this.chkSound.TabIndex = 22;
            this.chkSound.Text = "Sound";
            this.chkSound.CheckStateChanged += new System.EventHandler(this.chkSound_CheckStateChanged);
            // 
            // txtPID
            // 
            this.txtPID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPID.Enabled = false;
            this.txtPID.Location = new System.Drawing.Point(167, 178);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(70, 21);
            this.txtPID.TabIndex = 27;
            this.txtPID.TextChanged += new System.EventHandler(this.txtPID_TextChanged);
            this.txtPID.GotFocus += new System.EventHandler(this.txtPID_GotFocus);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(117, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.Text = "PID:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(117, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.Text = "Inc:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPoly
            // 
            this.lblPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPoly.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPoly.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPoly.Location = new System.Drawing.Point(62, 247);
            this.lblPoly.Name = "lblPoly";
            this.lblPoly.Size = new System.Drawing.Size(108, 20);
            this.lblPoly.Text = "Polygon";
            this.lblPoly.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboDOP
            // 
            this.cboDOP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboDOP.Enabled = false;
            this.cboDOP.Items.Add("PDOP");
            this.cboDOP.Items.Add("HDOP");
            this.cboDOP.Location = new System.Drawing.Point(3, 223);
            this.cboDOP.Name = "cboDOP";
            this.cboDOP.Size = new System.Drawing.Size(70, 22);
            this.cboDOP.TabIndex = 35;
            this.cboDOP.SelectedIndexChanged += new System.EventHandler(this.cboDOP_SelectedIndexChanged);
            // 
            // cboFixType
            // 
            this.cboFixType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFixType.Enabled = false;
            this.cboFixType.Items.Add("Any");
            this.cboFixType.Items.Add("3D");
            this.cboFixType.Items.Add("3D+DIFF");
            this.cboFixType.Location = new System.Drawing.Point(167, 223);
            this.cboFixType.Name = "cboFixType";
            this.cboFixType.Size = new System.Drawing.Size(70, 22);
            this.cboFixType.TabIndex = 36;
            this.cboFixType.SelectedIndexChanged += new System.EventHandler(this.cboFixType_SelectedIndexChanged);
            // 
            // txtIncrement
            // 
            this.txtIncrement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncrement.Enabled = false;
            this.txtIncrement.Location = new System.Drawing.Point(167, 201);
            this.txtIncrement.Name = "txtIncrement";
            this.txtIncrement.Size = new System.Drawing.Size(70, 21);
            this.txtIncrement.TabIndex = 27;
            this.txtIncrement.TextChanged += new System.EventHandler(this.txtIncrement_TextChanged);
            this.txtIncrement.GotFocus += new System.EventHandler(this.txtIncrement_GotFocus);
            // 
            // pnlSavePointIcon
            // 
            this.pnlSavePointIcon.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlSavePointIcon.Location = new System.Drawing.Point(0, 0);
            this.pnlSavePointIcon.Name = "pnlSavePointIcon";
            this.pnlSavePointIcon.Size = new System.Drawing.Size(23, 23);
            // 
            // gpsInfoAdvCtrl
            // 
            this.gpsInfoAdvCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpsInfoAdvCtrl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gpsInfoAdvCtrl.Location = new System.Drawing.Point(0, 23);
            this.gpsInfoAdvCtrl.Name = "gpsInfoAdvCtrl";
            this.gpsInfoAdvCtrl.Size = new System.Drawing.Size(240, 155);
            this.gpsInfoAdvCtrl.TabIndex = 7;
            this.gpsInfoAdvCtrl.Click += new System.EventHandler(this.gpsInfoAdvCtrl_Click);
            // 
            // WalkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSavePointIcon);
            this.Controls.Add(this.chkSound);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.txtFreq);
            this.Controls.Add(this.txtIncrement);
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.txtAcc);
            this.Controls.Add(this.btnDOP);
            this.Controls.Add(this.txtDOP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpsInfoAdvCtrl);
            this.Controls.Add(this.btnFixType);
            this.Controls.Add(this.cboFixType);
            this.Controls.Add(this.cboDOP);
            this.Controls.Add(this.lblPoly);
            this.Name = "WalkForm";
            this.Text = "Walk Point Capture";
            this.Load += new System.EventHandler(this.WalkForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.WalkForm_Closing);
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFreq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.btnFixType = new System.Windows.Forms.Button();
            this.btnDOP = new System.Windows.Forms.Button();
            this.txtDOP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.chkSound = new System.Windows.Forms.CheckBox();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPoly = new System.Windows.Forms.Label();
            this.cboDOP = new System.Windows.Forms.ComboBox();
            this.cboFixType = new System.Windows.Forms.ComboBox();
            this.txtIncrement = new System.Windows.Forms.TextBox();
            this.gpsInfoAdvCtrl = new TwoTrails.Controls.GpsInfoAdvCtrl();
            this.pnlSavePointIcon = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(246, 151);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(71, 25);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Stop";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapture.Location = new System.Drawing.Point(246, 121);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(71, 25);
            this.btnCapture.TabIndex = 9;
            this.btnCapture.Text = "Start";
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(246, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 25);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(0, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.Text = "Frequency:";
            // 
            // txtFreq
            // 
            this.txtFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFreq.Enabled = false;
            this.txtFreq.Location = new System.Drawing.Point(75, 146);
            this.txtFreq.Name = "txtFreq";
            this.txtFreq.Size = new System.Drawing.Size(40, 21);
            this.txtFreq.TabIndex = 13;
            this.txtFreq.TextChanged += new System.EventHandler(this.txtFreq_TextChanged);
            this.txtFreq.GotFocus += new System.EventHandler(this.txtFreq_GotFocus);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(10, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.Text = "Distance:";
            // 
            // txtAcc
            // 
            this.txtAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAcc.Enabled = false;
            this.txtAcc.Location = new System.Drawing.Point(75, 167);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(40, 21);
            this.txtAcc.TabIndex = 13;
            this.txtAcc.TextChanged += new System.EventHandler(this.txtAcc_TextChanged);
            this.txtAcc.GotFocus += new System.EventHandler(this.txtAcc_GotFocus);
            // 
            // btnFixType
            // 
            this.btnFixType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFixType.Enabled = false;
            this.btnFixType.Location = new System.Drawing.Point(45, 189);
            this.btnFixType.Name = "btnFixType";
            this.btnFixType.Size = new System.Drawing.Size(70, 22);
            this.btnFixType.TabIndex = 19;
            this.btnFixType.Text = "3D+DIFF";
            this.btnFixType.Click += new System.EventHandler(this.btnFixType_Click);
            // 
            // btnDOP
            // 
            this.btnDOP.Enabled = false;
            this.btnDOP.Location = new System.Drawing.Point(123, 189);
            this.btnDOP.Name = "btnDOP";
            this.btnDOP.Size = new System.Drawing.Size(70, 22);
            this.btnDOP.TabIndex = 18;
            this.btnDOP.Text = "PDOP";
            this.btnDOP.Click += new System.EventHandler(this.btnDOP_Click);
            // 
            // txtDOP
            // 
            this.txtDOP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDOP.Enabled = false;
            this.txtDOP.Location = new System.Drawing.Point(200, 190);
            this.txtDOP.Name = "txtDOP";
            this.txtDOP.Size = new System.Drawing.Size(40, 21);
            this.txtDOP.TabIndex = 17;
            this.txtDOP.GotFocus += new System.EventHandler(this.txtDOP_GotFocus);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(10, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 20);
            this.label4.Text = "Fix:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkLock
            // 
            this.chkLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLock.Checked = true;
            this.chkLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLock.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkLock.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLock.Location = new System.Drawing.Point(246, 49);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(71, 20);
            this.chkLock.TabIndex = 21;
            this.chkLock.Text = "Lock";
            this.chkLock.CheckStateChanged += new System.EventHandler(this.chkLock_CheckStateChanged);
            // 
            // chkSound
            // 
            this.chkSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSound.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkSound.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkSound.Location = new System.Drawing.Point(246, 75);
            this.chkSound.Name = "chkSound";
            this.chkSound.Size = new System.Drawing.Size(70, 20);
            this.chkSound.TabIndex = 22;
            this.chkSound.Text = "Sound";
            this.chkSound.CheckStateChanged += new System.EventHandler(this.chkSound_CheckStateChanged);
            // 
            // txtPID
            // 
            this.txtPID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPID.Enabled = false;
            this.txtPID.Location = new System.Drawing.Point(170, 146);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(70, 21);
            this.txtPID.TabIndex = 27;
            this.txtPID.TextChanged += new System.EventHandler(this.txtPID_TextChanged);
            this.txtPID.GotFocus += new System.EventHandler(this.txtPID_GotFocus);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(120, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.Text = "PID:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(120, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.Text = "Inc:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPoly
            // 
            this.lblPoly.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPoly.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPoly.Location = new System.Drawing.Point(246, 98);
            this.lblPoly.Name = "lblPoly";
            this.lblPoly.Size = new System.Drawing.Size(70, 20);
            this.lblPoly.Text = "Polygon";
            this.lblPoly.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboDOP
            // 
            this.cboDOP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboDOP.Enabled = false;
            this.cboDOP.Items.Add("PDOP");
            this.cboDOP.Items.Add("HDOP");
            this.cboDOP.Location = new System.Drawing.Point(123, 189);
            this.cboDOP.Name = "cboDOP";
            this.cboDOP.Size = new System.Drawing.Size(70, 22);
            this.cboDOP.TabIndex = 35;
            this.cboDOP.SelectedIndexChanged += new System.EventHandler(this.cboDOP_SelectedIndexChanged);
            // 
            // cboFixType
            // 
            this.cboFixType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFixType.Enabled = false;
            this.cboFixType.Items.Add("Any");
            this.cboFixType.Items.Add("3D");
            this.cboFixType.Items.Add("3D+DIFF");
            this.cboFixType.Location = new System.Drawing.Point(45, 189);
            this.cboFixType.Name = "cboFixType";
            this.cboFixType.Size = new System.Drawing.Size(70, 22);
            this.cboFixType.TabIndex = 36;
            this.cboFixType.SelectedIndexChanged += new System.EventHandler(this.cboFixType_SelectedIndexChanged);
            // 
            // txtIncrement
            // 
            this.txtIncrement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncrement.Enabled = false;
            this.txtIncrement.Location = new System.Drawing.Point(170, 167);
            this.txtIncrement.Name = "txtIncrement";
            this.txtIncrement.Size = new System.Drawing.Size(70, 21);
            this.txtIncrement.TabIndex = 27;
            this.txtIncrement.TextChanged += new System.EventHandler(this.txtIncrement_TextChanged);
            this.txtIncrement.GotFocus += new System.EventHandler(this.txtIncrement_GotFocus);
            // 
            // gpsInfoAdvCtrl
            // 
            this.gpsInfoAdvCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpsInfoAdvCtrl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gpsInfoAdvCtrl.Location = new System.Drawing.Point(0, 0);
            this.gpsInfoAdvCtrl.Name = "gpsInfoAdvCtrl";
            this.gpsInfoAdvCtrl.Size = new System.Drawing.Size(240, 145);
            this.gpsInfoAdvCtrl.TabIndex = 7;
            this.gpsInfoAdvCtrl.Click += new System.EventHandler(this.gpsInfoAdvCtrl_Click);
            // 
            // pnlSavePointIcon
            // 
            this.pnlSavePointIcon.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlSavePointIcon.Location = new System.Drawing.Point(241, 0);
            this.pnlSavePointIcon.Name = "pnlSavePointIcon";
            this.pnlSavePointIcon.Size = new System.Drawing.Size(23, 23);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.chkLock);
            this.panel1.Controls.Add(this.txtPID);
            this.panel1.Controls.Add(this.txtIncrement);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtDOP);
            this.panel1.Controls.Add(this.btnCapture);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkSound);
            this.panel1.Controls.Add(this.lblPoly);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 214);
            // 
            // WalkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSavePointIcon);
            this.Controls.Add(this.txtFreq);
            this.Controls.Add(this.txtAcc);
            this.Controls.Add(this.btnDOP);
            this.Controls.Add(this.gpsInfoAdvCtrl);
            this.Controls.Add(this.btnFixType);
            this.Controls.Add(this.cboFixType);
            this.Controls.Add(this.cboDOP);
            this.Controls.Add(this.panel1);
            this.Name = "WalkForm";
            this.Text = "Walk Point Capture";
            this.Load += new System.EventHandler(this.WalkForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.WalkForm_Closing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFreq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.Button btnFixType;
        private System.Windows.Forms.Button btnDOP;
        private System.Windows.Forms.TextBox txtDOP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.CheckBox chkSound;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPoly;
        private System.Windows.Forms.ComboBox cboDOP;
        private System.Windows.Forms.ComboBox cboFixType;
        private System.Windows.Forms.TextBox txtIncrement;
        private TwoTrails.Controls.GpsInfoAdvCtrl gpsInfoAdvCtrl;
        private System.Windows.Forms.Panel pnlSavePointIcon;
        private System.Windows.Forms.Panel panel1;
    }
}