namespace TwoTrails.Forms
{
    partial class Take5Form
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
            this.progCapture = new System.Windows.Forms.ProgressBar();
            this.lblLabel = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBound = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.gpsInfoAdvCtrl = new TwoTrails.Controls.GpsInfoAdvCtrl();
            this.pnlSideshot = new System.Windows.Forms.Panel();
            this.travInfoControl1 = new TwoTrails.Controls.TravInfoControl();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSideshot = new System.Windows.Forms.Button();
            this.pnlSideshot.SuspendLayout();
            this.SuspendLayout();
            // 
            // progCapture
            // 
            this.progCapture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progCapture.Location = new System.Drawing.Point(0, 23);
            this.progCapture.Maximum = 5;
            this.progCapture.Name = "progCapture";
            this.progCapture.Size = new System.Drawing.Size(240, 20);
            // 
            // lblLabel
            // 
            this.lblLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLabel.Location = new System.Drawing.Point(0, 0);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(240, 20);
            this.lblLabel.Text = "Take 5";
            this.lblLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(3, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapture.Location = new System.Drawing.Point(79, 266);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(82, 25);
            this.btnCapture.TabIndex = 4;
            this.btnCapture.Text = "Take 5";
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(167, 266);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 25);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Finish";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(3, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.Text = "PID:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(3, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.Text = "Cmt:";
            // 
            // txtPID
            // 
            this.txtPID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtPID.Enabled = false;
            this.txtPID.Location = new System.Drawing.Point(35, 197);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(88, 21);
            this.txtPID.TabIndex = 8;
            this.txtPID.TextChanged += new System.EventHandler(this.txtPID_TextChanged);
            this.txtPID.GotFocus += new System.EventHandler(this.txtPID_GotFocus);
            this.txtPID.LostFocus += new System.EventHandler(this.txtPID_LostFocus);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(129, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.Text = "Boundary:";
            // 
            // btnBound
            // 
            this.btnBound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBound.Enabled = false;
            this.btnBound.Location = new System.Drawing.Point(202, 198);
            this.btnBound.Name = "btnBound";
            this.btnBound.Size = new System.Drawing.Size(35, 22);
            this.btnBound.TabIndex = 10;
            this.btnBound.Text = "ON";
            this.btnBound.Click += new System.EventHandler(this.btnBound_Click);
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtComment.Enabled = false;
            this.txtComment.Location = new System.Drawing.Point(35, 221);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(202, 21);
            this.txtComment.TabIndex = 8;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            this.txtComment.GotFocus += new System.EventHandler(this.txtComment_GotFocus);
            this.txtComment.LostFocus += new System.EventHandler(this.txtComment_LostFocus);
            // 
            // chkLocked
            // 
            this.chkLocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLocked.Checked = true;
            this.chkLocked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLocked.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLocked.Location = new System.Drawing.Point(3, 245);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(70, 20);
            this.chkLocked.TabIndex = 14;
            this.chkLocked.Text = "Locked";
            this.chkLocked.CheckStateChanged += new System.EventHandler(this.chkLocked_CheckStateChanged);
            // 
            // gpsInfoAdvCtrl
            // 
            this.gpsInfoAdvCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpsInfoAdvCtrl.Location = new System.Drawing.Point(0, 45);
            this.gpsInfoAdvCtrl.Name = "gpsInfoAdvCtrl";
            this.gpsInfoAdvCtrl.Size = new System.Drawing.Size(240, 150);
            this.gpsInfoAdvCtrl.TabIndex = 0;
            // 
            // pnlSideshot
            // 
            this.pnlSideshot.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlSideshot.Controls.Add(this.travInfoControl1);
            this.pnlSideshot.Controls.Add(this.label9);
            this.pnlSideshot.Location = new System.Drawing.Point(0, 0);
            this.pnlSideshot.Name = "pnlSideshot";
            this.pnlSideshot.Size = new System.Drawing.Size(240, 195);
            this.pnlSideshot.Visible = false;
            // 
            // travInfoControl1
            // 
            this.travInfoControl1.Location = new System.Drawing.Point(0, 25);
            this.travInfoControl1.Name = "travInfoControl1";
            this.travInfoControl1.Size = new System.Drawing.Size(240, 128);
            this.travInfoControl1.TabIndex = 26;
            this.travInfoControl1.BAzTextChanged += new TwoTrails.Controls.TravInfoControl.BAzTextChangedEvent(this.travInfoControl1_BAzTextChanged);
            this.travInfoControl1.SlopeAngleTextChanged += new TwoTrails.Controls.TravInfoControl.SlopeAngleTextChangedEvent(this.travInfoControl1_SlopeAngleTextChanged);
            this.travInfoControl1.SlopeDistTextChanged += new TwoTrails.Controls.TravInfoControl.SlopeDistTextChangedEvent(this.travInfoControl1_SlopeDistTextChanged);
            this.travInfoControl1.GotFocused += new TwoTrails.Controls.TravInfoControl.GotFocusEvent(this.travInfoControl1_GotFocused);
            this.travInfoControl1.FAzTextChanged += new TwoTrails.Controls.TravInfoControl.FAzTextChangedEvent(this.travInfoControl1_FAzTextChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(0, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(240, 20);
            this.label9.Text = "Take SideShot";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSideshot
            // 
            this.btnSideshot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSideshot.Location = new System.Drawing.Point(79, 243);
            this.btnSideshot.Name = "btnSideshot";
            this.btnSideshot.Size = new System.Drawing.Size(82, 22);
            this.btnSideshot.TabIndex = 4;
            this.btnSideshot.Text = "SideShot";
            this.btnSideshot.Click += new System.EventHandler(this.btnSideshot_Click);
            // 
            // Take5Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSideshot);
            this.Controls.Add(this.chkLocked);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.btnBound);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnSideshot);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.progCapture);
            this.Controls.Add(this.gpsInfoAdvCtrl);
            this.Name = "Take5Form";
            this.Text = "Take 5 Point Capture";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Take5Form_Closing);
            this.pnlSideshot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.progCapture = new System.Windows.Forms.ProgressBar();
            this.lblLabel = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBound = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.gpsInfoAdvCtrl = new TwoTrails.Controls.GpsInfoAdvCtrl();
            this.travInfoControl1 = new TwoTrails.Controls.TravInfoControl();
            this.btnSideshot = new System.Windows.Forms.Button();
            this.pnlSideshot = new System.Windows.Forms.Panel();
            this.pnlSideshot.SuspendLayout();
            this.SuspendLayout();
            // 
            // progCapture
            // 
            this.progCapture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progCapture.Location = new System.Drawing.Point(0, 3);
            this.progCapture.Maximum = 5;
            this.progCapture.Name = "progCapture";
            this.progCapture.Size = new System.Drawing.Size(240, 20);
            // 
            // lblLabel
            // 
            this.lblLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLabel.Location = new System.Drawing.Point(239, 0);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(81, 20);
            this.lblLabel.Text = "Take 5";
            this.lblLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(3, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapture.Location = new System.Drawing.Point(246, 140);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(70, 40);
            this.btnCapture.TabIndex = 4;
            this.btnCapture.Text = "Take 5";
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(246, 186);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 25);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Finish";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(241, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.Text = "PID:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(79, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.Text = "Cmt:";
            // 
            // txtPID
            // 
            this.txtPID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtPID.Enabled = false;
            this.txtPID.Location = new System.Drawing.Point(273, 71);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(46, 21);
            this.txtPID.TabIndex = 8;
            this.txtPID.TextChanged += new System.EventHandler(this.txtPID_TextChanged);
            this.txtPID.GotFocus += new System.EventHandler(this.txtPID_GotFocus);
            this.txtPID.LostFocus += new System.EventHandler(this.txtPID_LostFocus);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(241, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.Text = "Bnd:";
            // 
            // btnBound
            // 
            this.btnBound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBound.Enabled = false;
            this.btnBound.Location = new System.Drawing.Point(273, 95);
            this.btnBound.Name = "btnBound";
            this.btnBound.Size = new System.Drawing.Size(46, 22);
            this.btnBound.TabIndex = 10;
            this.btnBound.Text = "ON";
            this.btnBound.Click += new System.EventHandler(this.btnBound_Click);
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtComment.Enabled = false;
            this.txtComment.Location = new System.Drawing.Point(124, 186);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(116, 21);
            this.txtComment.TabIndex = 8;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            this.txtComment.GotFocus += new System.EventHandler(this.txtComment_GotFocus);
            this.txtComment.LostFocus += new System.EventHandler(this.txtComment_LostFocus);
            // 
            // chkLocked
            // 
            this.chkLocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLocked.Checked = true;
            this.chkLocked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLocked.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLocked.Location = new System.Drawing.Point(241, 48);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(66, 20);
            this.chkLocked.TabIndex = 14;
            this.chkLocked.Text = "Locked";
            this.chkLocked.CheckStateChanged += new System.EventHandler(this.chkLocked_CheckStateChanged);
            // 
            // gpsInfoAdvCtrl
            // 
            this.gpsInfoAdvCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpsInfoAdvCtrl.Location = new System.Drawing.Point(0, 29);
            this.gpsInfoAdvCtrl.Name = "gpsInfoAdvCtrl";
            this.gpsInfoAdvCtrl.Size = new System.Drawing.Size(240, 154);
            this.gpsInfoAdvCtrl.TabIndex = 0;
            // 
            // travInfoControl1
            // 
            this.travInfoControl1.Location = new System.Drawing.Point(0, 0);
            this.travInfoControl1.Name = "travInfoControl1";
            this.travInfoControl1.Size = new System.Drawing.Size(240, 155);
            this.travInfoControl1.TabIndex = 20;
            this.travInfoControl1.BAzTextChanged += new TwoTrails.Controls.TravInfoControl.BAzTextChangedEvent(this.travInfoControl1_BAzTextChanged);
            this.travInfoControl1.SlopeAngleTextChanged += new TwoTrails.Controls.TravInfoControl.SlopeAngleTextChangedEvent(this.travInfoControl1_SlopeAngleTextChanged);
            this.travInfoControl1.SlopeDistTextChanged += new TwoTrails.Controls.TravInfoControl.SlopeDistTextChangedEvent(this.travInfoControl1_SlopeDistTextChanged);
            this.travInfoControl1.GotFocused += new TwoTrails.Controls.TravInfoControl.GotFocusEvent(this.travInfoControl1_GotFocused);
            this.travInfoControl1.FAzTextChanged += new TwoTrails.Controls.TravInfoControl.FAzTextChangedEvent(this.travInfoControl1_FAzTextChanged);
            // 
            // btnSideshot
            // 
            this.btnSideshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSideshot.Location = new System.Drawing.Point(244, 25);
            this.btnSideshot.Name = "btnSideshot";
            this.btnSideshot.Size = new System.Drawing.Size(72, 20);
            this.btnSideshot.TabIndex = 26;
            this.btnSideshot.TabStop = false;
            this.btnSideshot.Text = "SideShot";
            this.btnSideshot.Click += new System.EventHandler(this.btnSideshot_Click);
            // 
            // pnlSideshot
            // 
            this.pnlSideshot.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlSideshot.Controls.Add(this.travInfoControl1);
            this.pnlSideshot.Location = new System.Drawing.Point(0, 29);
            this.pnlSideshot.Name = "pnlSideshot";
            this.pnlSideshot.Size = new System.Drawing.Size(240, 154);
            this.pnlSideshot.Visible = false;
            // 
            // Take5Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSideshot);
            this.Controls.Add(this.btnSideshot);
            this.Controls.Add(this.chkLocked);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.btnBound);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.progCapture);
            this.Controls.Add(this.gpsInfoAdvCtrl);
            this.Name = "Take5Form";
            this.Text = "Take 5 Point Capture";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Take5Form_Closing);
            this.pnlSideshot.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private TwoTrails.Controls.GpsInfoAdvCtrl gpsInfoAdvCtrl;
        private System.Windows.Forms.ProgressBar progCapture;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBound;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.CheckBox chkLocked;
        private System.Windows.Forms.Panel pnlSideshot;
        private System.Windows.Forms.Label label9;
        private TwoTrails.Controls.TravInfoControl travInfoControl1;
        private System.Windows.Forms.Button btnSideshot;
    }
}