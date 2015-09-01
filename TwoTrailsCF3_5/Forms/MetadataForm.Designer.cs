namespace TwoTrails.Forms
{
    partial class MetadataForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMeta = new System.Windows.Forms.TabPage();
            this.cboElev = new System.Windows.Forms.ComboBox();
            this.chkLock1 = new System.Windows.Forms.CheckBox();
            this.txtMagDec = new System.Windows.Forms.TextBox();
            this.cboMagDec = new System.Windows.Forms.ComboBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.cboDatum = new System.Windows.Forms.ComboBox();
            this.cboSlope = new System.Windows.Forms.ComboBox();
            this.cboDist = new System.Windows.Forms.ComboBox();
            this.cboMapProj = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtZone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tabDevProj = new System.Windows.Forms.TabPage();
            this.btnSetAsDefault = new System.Windows.Forms.Button();
            this.btnCompassList = new System.Windows.Forms.Button();
            this.btnLaserList = new System.Windows.Forms.Button();
            this.btnAutoFillGps = new System.Windows.Forms.Button();
            this.chkLock2 = new System.Windows.Forms.CheckBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtCrew = new System.Windows.Forms.TextBox();
            this.txtCompass = new System.Windows.Forms.TextBox();
            this.txtLaser = new System.Windows.Forms.TextBox();
            this.txtGPS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pointNavigationCtrl = new TwoTrails.Controls.PointNavigationCtrl();
            this.actionsControl = new TwoTrails.Controls.ActionsControl();
            this.bindingSourceMeta = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabMeta.SuspendLayout();
            this.tabDevProj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMeta)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMeta);
            this.tabControl1.Controls.Add(this.tabDevProj);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 250);
            this.tabControl1.TabIndex = 3;
            // 
            // tabMeta
            // 
            this.tabMeta.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabMeta.Controls.Add(this.cboElev);
            this.tabMeta.Controls.Add(this.chkLock1);
            this.tabMeta.Controls.Add(this.txtMagDec);
            this.tabMeta.Controls.Add(this.cboMagDec);
            this.tabMeta.Controls.Add(this.btnHelp);
            this.tabMeta.Controls.Add(this.cboDatum);
            this.tabMeta.Controls.Add(this.cboSlope);
            this.tabMeta.Controls.Add(this.cboDist);
            this.tabMeta.Controls.Add(this.cboMapProj);
            this.tabMeta.Controls.Add(this.label13);
            this.tabMeta.Controls.Add(this.label12);
            this.tabMeta.Controls.Add(this.label11);
            this.tabMeta.Controls.Add(this.label10);
            this.tabMeta.Controls.Add(this.label9);
            this.tabMeta.Controls.Add(this.label8);
            this.tabMeta.Controls.Add(this.label7);
            this.tabMeta.Controls.Add(this.txtZone);
            this.tabMeta.Controls.Add(this.txtName);
            this.tabMeta.Location = new System.Drawing.Point(0, 0);
            this.tabMeta.Name = "tabMeta";
            this.tabMeta.Size = new System.Drawing.Size(240, 227);
            this.tabMeta.Text = "Metadata";
            this.tabMeta.GotFocus += new System.EventHandler(this.tabMeta_GotFocus);
            // 
            // cboElev
            // 
            this.cboElev.Enabled = false;
            this.cboElev.Location = new System.Drawing.Point(51, 144);
            this.cboElev.Name = "cboElev";
            this.cboElev.Size = new System.Drawing.Size(64, 22);
            this.cboElev.TabIndex = 39;
            this.cboElev.TabStop = false;
            this.cboElev.SelectedIndexChanged += new System.EventHandler(this.cboElev_SelectedIndexChanged);
            // 
            // chkLock1
            // 
            this.chkLock1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLock1.Checked = true;
            this.chkLock1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLock1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkLock1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLock1.Location = new System.Drawing.Point(177, 174);
            this.chkLock1.Name = "chkLock1";
            this.chkLock1.Size = new System.Drawing.Size(64, 20);
            this.chkLock1.TabIndex = 50;
            this.chkLock1.TabStop = false;
            this.chkLock1.Text = "Lock";
            this.chkLock1.CheckStateChanged += new System.EventHandler(this.chkLock1_CheckStateChanged);
            // 
            // txtMagDec
            // 
            this.txtMagDec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMagDec.Location = new System.Drawing.Point(121, 172);
            this.txtMagDec.Name = "txtMagDec";
            this.txtMagDec.Size = new System.Drawing.Size(52, 21);
            this.txtMagDec.TabIndex = 49;
            this.txtMagDec.TabStop = false;
            this.txtMagDec.TextChanged += new System.EventHandler(this.txtMagDec_TextChanged);
            this.txtMagDec.GotFocus += new System.EventHandler(this.txtMagDec_GotFocus);
            this.txtMagDec.LostFocus += new System.EventHandler(this.txtMagDec_LostFocus);
            // 
            // cboMagDec
            // 
            this.cboMagDec.Enabled = false;
            this.cboMagDec.Location = new System.Drawing.Point(17, 172);
            this.cboMagDec.Name = "cboMagDec";
            this.cboMagDec.Size = new System.Drawing.Size(98, 22);
            this.cboMagDec.TabIndex = 48;
            this.cboMagDec.TabStop = false;
            this.cboMagDec.SelectedIndexChanged += new System.EventHandler(this.cboMagDec_SelectedIndexChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Enabled = false;
            this.btnHelp.Location = new System.Drawing.Point(129, 34);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(104, 21);
            this.btnHelp.TabIndex = 47;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "Get Zone";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // cboDatum
            // 
            this.cboDatum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDatum.Enabled = false;
            this.cboDatum.Location = new System.Drawing.Point(115, 60);
            this.cboDatum.Name = "cboDatum";
            this.cboDatum.Size = new System.Drawing.Size(118, 22);
            this.cboDatum.TabIndex = 39;
            this.cboDatum.TabStop = false;
            this.cboDatum.SelectedIndexChanged += new System.EventHandler(this.cboDatum_SelectedIndexChanged);
            // 
            // cboSlope
            // 
            this.cboSlope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSlope.Enabled = false;
            this.cboSlope.Location = new System.Drawing.Point(169, 144);
            this.cboSlope.Name = "cboSlope";
            this.cboSlope.Size = new System.Drawing.Size(64, 22);
            this.cboSlope.TabIndex = 39;
            this.cboSlope.TabStop = false;
            this.cboSlope.SelectedIndexChanged += new System.EventHandler(this.cboSlope_SelectedIndexChanged);
            // 
            // cboDist
            // 
            this.cboDist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDist.Enabled = false;
            this.cboDist.Location = new System.Drawing.Point(115, 116);
            this.cboDist.Name = "cboDist";
            this.cboDist.Size = new System.Drawing.Size(118, 22);
            this.cboDist.TabIndex = 39;
            this.cboDist.TabStop = false;
            this.cboDist.SelectedIndexChanged += new System.EventHandler(this.cboDist_SelectedIndexChanged);
            // 
            // cboMapProj
            // 
            this.cboMapProj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMapProj.Enabled = false;
            this.cboMapProj.Location = new System.Drawing.Point(115, 88);
            this.cboMapProj.Name = "cboMapProj";
            this.cboMapProj.Size = new System.Drawing.Size(118, 22);
            this.cboMapProj.TabIndex = 39;
            this.cboMapProj.TabStop = false;
            this.cboMapProj.SelectedIndexChanged += new System.EventHandler(this.cboMapProj_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label13.Location = new System.Drawing.Point(121, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 20);
            this.label13.Text = "Slope:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Location = new System.Drawing.Point(11, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 20);
            this.label12.Text = "Elev:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Location = new System.Drawing.Point(41, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 20);
            this.label11.Text = "Distance:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Location = new System.Drawing.Point(0, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 20);
            this.label10.Text = "Map Proj Units:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(0, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.Text = "Datum:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(3, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 20);
            this.label8.Text = "Zone:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(3, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.Text = "Name:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtZone
            // 
            this.txtZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZone.Location = new System.Drawing.Point(61, 34);
            this.txtZone.Name = "txtZone";
            this.txtZone.Size = new System.Drawing.Size(62, 21);
            this.txtZone.TabIndex = 37;
            this.txtZone.TabStop = false;
            this.txtZone.TextChanged += new System.EventHandler(this.txtZone_TextChanged);
            this.txtZone.GotFocus += new System.EventHandler(this.txtZone_GotFocus);
            this.txtZone.LostFocus += new System.EventHandler(this.txtZone_LostFocus);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(61, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(172, 21);
            this.txtName.TabIndex = 36;
            this.txtName.TabStop = false;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.GotFocus += new System.EventHandler(this.txtName_GotFocus);
            this.txtName.LostFocus += new System.EventHandler(this.txtName_LostFocus);
            // 
            // tabDevProj
            // 
            this.tabDevProj.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabDevProj.Controls.Add(this.btnSetAsDefault);
            this.tabDevProj.Controls.Add(this.btnCompassList);
            this.tabDevProj.Controls.Add(this.btnLaserList);
            this.tabDevProj.Controls.Add(this.btnAutoFillGps);
            this.tabDevProj.Controls.Add(this.chkLock2);
            this.tabDevProj.Controls.Add(this.txtComment);
            this.tabDevProj.Controls.Add(this.txtCrew);
            this.tabDevProj.Controls.Add(this.txtCompass);
            this.tabDevProj.Controls.Add(this.txtLaser);
            this.tabDevProj.Controls.Add(this.txtGPS);
            this.tabDevProj.Controls.Add(this.label3);
            this.tabDevProj.Controls.Add(this.label2);
            this.tabDevProj.Controls.Add(this.label6);
            this.tabDevProj.Controls.Add(this.label5);
            this.tabDevProj.Controls.Add(this.label1);
            this.tabDevProj.Location = new System.Drawing.Point(0, 0);
            this.tabDevProj.Name = "tabDevProj";
            this.tabDevProj.Size = new System.Drawing.Size(240, 227);
            this.tabDevProj.Text = "Device -  Project";
            this.tabDevProj.GotFocus += new System.EventHandler(this.tabDevProj_GotFocus);
            // 
            // btnSetAsDefault
            // 
            this.btnSetAsDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetAsDefault.Location = new System.Drawing.Point(3, 204);
            this.btnSetAsDefault.Name = "btnSetAsDefault";
            this.btnSetAsDefault.Size = new System.Drawing.Size(160, 20);
            this.btnSetAsDefault.TabIndex = 69;
            this.btnSetAsDefault.Text = "Set as Default Metadata";
            this.btnSetAsDefault.Click += new System.EventHandler(this.btnSetAsDefault_Click);
            // 
            // btnCompassList
            // 
            this.btnCompassList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompassList.Enabled = false;
            this.btnCompassList.Location = new System.Drawing.Point(186, 61);
            this.btnCompassList.Name = "btnCompassList";
            this.btnCompassList.Size = new System.Drawing.Size(39, 21);
            this.btnCompassList.TabIndex = 63;
            this.btnCompassList.TabStop = false;
            this.btnCompassList.Text = "List";
            this.btnCompassList.Click += new System.EventHandler(this.btnCompassList_Click);
            // 
            // btnLaserList
            // 
            this.btnLaserList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaserList.Enabled = false;
            this.btnLaserList.Location = new System.Drawing.Point(186, 34);
            this.btnLaserList.Name = "btnLaserList";
            this.btnLaserList.Size = new System.Drawing.Size(39, 21);
            this.btnLaserList.TabIndex = 63;
            this.btnLaserList.TabStop = false;
            this.btnLaserList.Text = "List";
            this.btnLaserList.Click += new System.EventHandler(this.btnLaserList_Click);
            // 
            // btnAutoFillGps
            // 
            this.btnAutoFillGps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoFillGps.Enabled = false;
            this.btnAutoFillGps.Location = new System.Drawing.Point(186, 7);
            this.btnAutoFillGps.Name = "btnAutoFillGps";
            this.btnAutoFillGps.Size = new System.Drawing.Size(39, 21);
            this.btnAutoFillGps.TabIndex = 63;
            this.btnAutoFillGps.TabStop = false;
            this.btnAutoFillGps.Text = "List";
            this.btnAutoFillGps.Click += new System.EventHandler(this.btnAutoFillGps_Click);
            // 
            // chkLock2
            // 
            this.chkLock2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLock2.Checked = true;
            this.chkLock2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLock2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkLock2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLock2.Location = new System.Drawing.Point(173, 204);
            this.chkLock2.Name = "chkLock2";
            this.chkLock2.Size = new System.Drawing.Size(64, 20);
            this.chkLock2.TabIndex = 57;
            this.chkLock2.Text = "Lock";
            this.chkLock2.CheckStateChanged += new System.EventHandler(this.chkLock2_CheckStateChanged);
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(83, 115);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(142, 21);
            this.txtComment.TabIndex = 47;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            this.txtComment.GotFocus += new System.EventHandler(this.txtComment_GotFocus);
            this.txtComment.LostFocus += new System.EventHandler(this.txtComment_LostFocus);
            // 
            // txtCrew
            // 
            this.txtCrew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCrew.Location = new System.Drawing.Point(83, 88);
            this.txtCrew.Name = "txtCrew";
            this.txtCrew.Size = new System.Drawing.Size(142, 21);
            this.txtCrew.TabIndex = 48;
            this.txtCrew.TextChanged += new System.EventHandler(this.txtCrew_TextChanged);
            this.txtCrew.GotFocus += new System.EventHandler(this.txtCrew_GotFocus);
            this.txtCrew.LostFocus += new System.EventHandler(this.txtCrew_LostFocus);
            // 
            // txtCompass
            // 
            this.txtCompass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompass.Location = new System.Drawing.Point(83, 61);
            this.txtCompass.Name = "txtCompass";
            this.txtCompass.Size = new System.Drawing.Size(142, 21);
            this.txtCompass.TabIndex = 45;
            this.txtCompass.TextChanged += new System.EventHandler(this.txtCompass_TextChanged);
            this.txtCompass.GotFocus += new System.EventHandler(this.txtCompass_GotFocus);
            this.txtCompass.LostFocus += new System.EventHandler(this.txtCompass_LostFocus);
            // 
            // txtLaser
            // 
            this.txtLaser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLaser.Location = new System.Drawing.Point(83, 34);
            this.txtLaser.Name = "txtLaser";
            this.txtLaser.Size = new System.Drawing.Size(142, 21);
            this.txtLaser.TabIndex = 46;
            this.txtLaser.TextChanged += new System.EventHandler(this.txtLaser_TextChanged);
            this.txtLaser.GotFocus += new System.EventHandler(this.txtLaser_GotFocus);
            this.txtLaser.LostFocus += new System.EventHandler(this.txtLaser_LostFocus);
            // 
            // txtGPS
            // 
            this.txtGPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGPS.Location = new System.Drawing.Point(83, 7);
            this.txtGPS.Name = "txtGPS";
            this.txtGPS.Size = new System.Drawing.Size(142, 21);
            this.txtGPS.TabIndex = 50;
            this.txtGPS.TextChanged += new System.EventHandler(this.txtGPS_TextChanged);
            this.txtGPS.GotFocus += new System.EventHandler(this.txtGPS_GotFocus);
            this.txtGPS.LostFocus += new System.EventHandler(this.txtGPS_LostFocus);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(7, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.Text = "Reciever:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.Text = "Laser:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(7, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.Text = "Comment:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(7, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.Text = "Crew:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(7, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.Text = "Compass:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pointNavigationCtrl
            // 
            this.pointNavigationCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pointNavigationCtrl.Location = new System.Drawing.Point(0, 248);
            this.pointNavigationCtrl.Name = "pointNavigationCtrl";
            this.pointNavigationCtrl.Size = new System.Drawing.Size(240, 33);
            this.pointNavigationCtrl.TabIndex = 4;
            this.pointNavigationCtrl.AlreadyAtEnd += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtEndEvent(this.pointNavigationCtrl_AlreadyAtEnd);
            this.pointNavigationCtrl.JumpPoint += new TwoTrails.Controls.PointNavigationCtrl.JumpPointEvent(this.pointNavigationCtrl_JumpPoint);
            this.pointNavigationCtrl.AlreadyAtBeginning += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtBeginningEvent(this.pointNavigationCtrl_AlreadyAtBeginning);
            this.pointNavigationCtrl.IndexChanged += new TwoTrails.Controls.PointNavigationCtrl.IndexChangedEvent(this.pointNavigationCtrl_IndexChanged);
            // 
            // actionsControl
            // 
            this.actionsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actionsControl.Location = new System.Drawing.Point(0, 280);
            this.actionsControl.Name = "actionsControl";
            this.actionsControl.Size = new System.Drawing.Size(240, 40);
            this.actionsControl.TabIndex = 2;
            this.actionsControl.Misc_OnClick += new TwoTrails.Controls.ActionsControl.MiscClicked(this.actionsControl_Misc_OnClick);
            this.actionsControl.Cancel_OnClick += new TwoTrails.Controls.ActionsControl.CancelClicked(this.actionsControl_Cancel_OnClick);
            this.actionsControl.New_OnClick += new TwoTrails.Controls.ActionsControl.NewClicked(this.actionsControl_New_OnClick);
            this.actionsControl.Ok_OnClick += new TwoTrails.Controls.ActionsControl.OkClicked(this.actionsControl_Ok_OnClick);
            this.actionsControl.Delete_OnClick += new TwoTrails.Controls.ActionsControl.DeleteClicked(this.actionsControl_Delete_OnClick);
            // 
            // bindingSourceMeta
            // 
            this.bindingSourceMeta.DataSource = typeof(TwoTrails.BusinessObjects.TtMetaData);
            // 
            // MetadataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.pointNavigationCtrl);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.actionsControl);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MetadataForm";
            this.Text = "Metadata";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.GotFocus += new System.EventHandler(this.MetadataForm_GotFocus);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MetadataForm_Closing);
            this.tabControl1.ResumeLayout(false);
            this.tabMeta.ResumeLayout(false);
            this.tabDevProj.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMeta)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMeta = new System.Windows.Forms.TabPage();
            this.cboElev = new System.Windows.Forms.ComboBox();
            this.chkLock1 = new System.Windows.Forms.CheckBox();
            this.txtMagDec = new System.Windows.Forms.TextBox();
            this.cboMagDec = new System.Windows.Forms.ComboBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.cboDatum = new System.Windows.Forms.ComboBox();
            this.cboSlope = new System.Windows.Forms.ComboBox();
            this.cboDist = new System.Windows.Forms.ComboBox();
            this.cboMapProj = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtZone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tabDevProj = new System.Windows.Forms.TabPage();
            this.btnSetAsDefault = new System.Windows.Forms.Button();
            this.btnCompassList = new System.Windows.Forms.Button();
            this.btnLaserList = new System.Windows.Forms.Button();
            this.btnAutoFillGps = new System.Windows.Forms.Button();
            this.chkLock2 = new System.Windows.Forms.CheckBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtCrew = new System.Windows.Forms.TextBox();
            this.txtCompass = new System.Windows.Forms.TextBox();
            this.txtLaser = new System.Windows.Forms.TextBox();
            this.txtGPS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pointNavigationCtrl = new TwoTrails.Controls.PointNavigationCtrl();
            this.actionsControl = new TwoTrails.Controls.ActionsControl();
            this.bindingSourceMeta = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabMeta.SuspendLayout();
            this.tabDevProj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMeta)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMeta);
            this.tabControl1.Controls.Add(this.tabDevProj);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 214);
            this.tabControl1.TabIndex = 3;
            // 
            // tabMeta
            // 
            this.tabMeta.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabMeta.Controls.Add(this.cboElev);
            this.tabMeta.Controls.Add(this.chkLock1);
            this.tabMeta.Controls.Add(this.txtMagDec);
            this.tabMeta.Controls.Add(this.cboMagDec);
            this.tabMeta.Controls.Add(this.btnHelp);
            this.tabMeta.Controls.Add(this.cboDatum);
            this.tabMeta.Controls.Add(this.cboSlope);
            this.tabMeta.Controls.Add(this.cboDist);
            this.tabMeta.Controls.Add(this.cboMapProj);
            this.tabMeta.Controls.Add(this.label13);
            this.tabMeta.Controls.Add(this.label12);
            this.tabMeta.Controls.Add(this.label11);
            this.tabMeta.Controls.Add(this.label10);
            this.tabMeta.Controls.Add(this.label9);
            this.tabMeta.Controls.Add(this.label8);
            this.tabMeta.Controls.Add(this.label7);
            this.tabMeta.Controls.Add(this.txtZone);
            this.tabMeta.Controls.Add(this.txtName);
            this.tabMeta.Location = new System.Drawing.Point(0, 0);
            this.tabMeta.Name = "tabMeta";
            this.tabMeta.Size = new System.Drawing.Size(240, 191);
            this.tabMeta.Text = "Metadata";
            this.tabMeta.GotFocus += new System.EventHandler(this.tabMeta_GotFocus);
            // 
            // cboElev
            // 
            this.cboElev.Enabled = false;
            this.cboElev.Location = new System.Drawing.Point(43, 134);
            this.cboElev.Name = "cboElev";
            this.cboElev.Size = new System.Drawing.Size(64, 22);
            this.cboElev.TabIndex = 39;
            this.cboElev.TabStop = false;
            this.cboElev.SelectedIndexChanged += new System.EventHandler(this.cboElev_SelectedIndexChanged);
            // 
            // chkLock1
            // 
            this.chkLock1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLock1.Checked = true;
            this.chkLock1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLock1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkLock1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLock1.Location = new System.Drawing.Point(165, 161);
            this.chkLock1.Name = "chkLock1";
            this.chkLock1.Size = new System.Drawing.Size(60, 20);
            this.chkLock1.TabIndex = 50;
            this.chkLock1.TabStop = false;
            this.chkLock1.Text = "Lock";
            this.chkLock1.CheckStateChanged += new System.EventHandler(this.chkLock1_CheckStateChanged);
            // 
            // txtMagDec
            // 
            this.txtMagDec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMagDec.Location = new System.Drawing.Point(113, 159);
            this.txtMagDec.Name = "txtMagDec";
            this.txtMagDec.Size = new System.Drawing.Size(52, 21);
            this.txtMagDec.TabIndex = 49;
            this.txtMagDec.TabStop = false;
            this.txtMagDec.TextChanged += new System.EventHandler(this.txtMagDec_TextChanged);
            this.txtMagDec.GotFocus += new System.EventHandler(this.txtMagDec_GotFocus);
            this.txtMagDec.LostFocus += new System.EventHandler(this.txtMagDec_LostFocus);
            // 
            // cboMagDec
            // 
            this.cboMagDec.Enabled = false;
            this.cboMagDec.Location = new System.Drawing.Point(9, 159);
            this.cboMagDec.Name = "cboMagDec";
            this.cboMagDec.Size = new System.Drawing.Size(98, 22);
            this.cboMagDec.TabIndex = 48;
            this.cboMagDec.TabStop = false;
            this.cboMagDec.SelectedIndexChanged += new System.EventHandler(this.cboMagDec_SelectedIndexChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Enabled = false;
            this.btnHelp.Location = new System.Drawing.Point(121, 32);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(104, 21);
            this.btnHelp.TabIndex = 47;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "Get Zone";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // cboDatum
            // 
            this.cboDatum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDatum.Enabled = false;
            this.cboDatum.Location = new System.Drawing.Point(107, 56);
            this.cboDatum.Name = "cboDatum";
            this.cboDatum.Size = new System.Drawing.Size(118, 22);
            this.cboDatum.TabIndex = 39;
            this.cboDatum.TabStop = false;
            this.cboDatum.SelectedIndexChanged += new System.EventHandler(this.cboDatum_SelectedIndexChanged);
            // 
            // cboSlope
            // 
            this.cboSlope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSlope.Enabled = false;
            this.cboSlope.Location = new System.Drawing.Point(161, 134);
            this.cboSlope.Name = "cboSlope";
            this.cboSlope.Size = new System.Drawing.Size(64, 22);
            this.cboSlope.TabIndex = 39;
            this.cboSlope.TabStop = false;
            this.cboSlope.SelectedIndexChanged += new System.EventHandler(this.cboSlope_SelectedIndexChanged);
            // 
            // cboDist
            // 
            this.cboDist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDist.Enabled = false;
            this.cboDist.Location = new System.Drawing.Point(107, 108);
            this.cboDist.Name = "cboDist";
            this.cboDist.Size = new System.Drawing.Size(118, 22);
            this.cboDist.TabIndex = 39;
            this.cboDist.TabStop = false;
            this.cboDist.SelectedIndexChanged += new System.EventHandler(this.cboDist_SelectedIndexChanged);
            // 
            // cboMapProj
            // 
            this.cboMapProj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMapProj.Enabled = false;
            this.cboMapProj.Location = new System.Drawing.Point(107, 82);
            this.cboMapProj.Name = "cboMapProj";
            this.cboMapProj.Size = new System.Drawing.Size(118, 22);
            this.cboMapProj.TabIndex = 39;
            this.cboMapProj.TabStop = false;
            this.cboMapProj.SelectedIndexChanged += new System.EventHandler(this.cboMapProj_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label13.Location = new System.Drawing.Point(113, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 20);
            this.label13.Text = "Slope:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Location = new System.Drawing.Point(3, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 20);
            this.label12.Text = "Elev:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Location = new System.Drawing.Point(33, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 20);
            this.label11.Text = "Disance:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Location = new System.Drawing.Point(-8, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 20);
            this.label10.Text = "Map Proj Units:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(-8, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.Text = "Datum:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(3, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.Text = "Zone:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(-5, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.Text = "Name:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtZone
            // 
            this.txtZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZone.Location = new System.Drawing.Point(53, 32);
            this.txtZone.Name = "txtZone";
            this.txtZone.Size = new System.Drawing.Size(62, 21);
            this.txtZone.TabIndex = 37;
            this.txtZone.TabStop = false;
            this.txtZone.TextChanged += new System.EventHandler(this.txtZone_TextChanged);
            this.txtZone.GotFocus += new System.EventHandler(this.txtZone_GotFocus);
            this.txtZone.LostFocus += new System.EventHandler(this.txtZone_LostFocus);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(53, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(172, 21);
            this.txtName.TabIndex = 36;
            this.txtName.TabStop = false;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.GotFocus += new System.EventHandler(this.txtName_GotFocus);
            this.txtName.LostFocus += new System.EventHandler(this.txtName_LostFocus);
            // 
            // tabDevProj
            // 
            this.tabDevProj.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabDevProj.Controls.Add(this.btnSetAsDefault);
            this.tabDevProj.Controls.Add(this.btnCompassList);
            this.tabDevProj.Controls.Add(this.btnLaserList);
            this.tabDevProj.Controls.Add(this.btnAutoFillGps);
            this.tabDevProj.Controls.Add(this.chkLock2);
            this.tabDevProj.Controls.Add(this.txtComment);
            this.tabDevProj.Controls.Add(this.txtCrew);
            this.tabDevProj.Controls.Add(this.txtCompass);
            this.tabDevProj.Controls.Add(this.txtLaser);
            this.tabDevProj.Controls.Add(this.txtGPS);
            this.tabDevProj.Controls.Add(this.label3);
            this.tabDevProj.Controls.Add(this.label2);
            this.tabDevProj.Controls.Add(this.label6);
            this.tabDevProj.Controls.Add(this.label5);
            this.tabDevProj.Controls.Add(this.label1);
            this.tabDevProj.Location = new System.Drawing.Point(0, 0);
            this.tabDevProj.Name = "tabDevProj";
            this.tabDevProj.Size = new System.Drawing.Size(240, 191);
            this.tabDevProj.Text = "Device -  Project";
            this.tabDevProj.GotFocus += new System.EventHandler(this.tabDevProj_GotFocus);
            // 
            // btnSetAsDefault
            // 
            this.btnSetAsDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetAsDefault.Location = new System.Drawing.Point(3, 161);
            this.btnSetAsDefault.Name = "btnSetAsDefault";
            this.btnSetAsDefault.Size = new System.Drawing.Size(160, 20);
            this.btnSetAsDefault.TabIndex = 69;
            this.btnSetAsDefault.Text = "Set as Default Metadata";
            this.btnSetAsDefault.Click += new System.EventHandler(this.btnSetAsDefault_Click);
            // 
            // btnCompassList
            // 
            this.btnCompassList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompassList.Enabled = false;
            this.btnCompassList.Location = new System.Drawing.Point(186, 61);
            this.btnCompassList.Name = "btnCompassList";
            this.btnCompassList.Size = new System.Drawing.Size(39, 21);
            this.btnCompassList.TabIndex = 63;
            this.btnCompassList.TabStop = false;
            this.btnCompassList.Text = "List";
            this.btnCompassList.Click += new System.EventHandler(this.btnCompassList_Click);
            // 
            // btnLaserList
            // 
            this.btnLaserList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaserList.Enabled = false;
            this.btnLaserList.Location = new System.Drawing.Point(186, 34);
            this.btnLaserList.Name = "btnLaserList";
            this.btnLaserList.Size = new System.Drawing.Size(39, 21);
            this.btnLaserList.TabIndex = 63;
            this.btnLaserList.TabStop = false;
            this.btnLaserList.Text = "List";
            this.btnLaserList.Click += new System.EventHandler(this.btnLaserList_Click);
            // 
            // btnAutoFillGps
            // 
            this.btnAutoFillGps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoFillGps.Enabled = false;
            this.btnAutoFillGps.Location = new System.Drawing.Point(186, 7);
            this.btnAutoFillGps.Name = "btnAutoFillGps";
            this.btnAutoFillGps.Size = new System.Drawing.Size(39, 21);
            this.btnAutoFillGps.TabIndex = 63;
            this.btnAutoFillGps.TabStop = false;
            this.btnAutoFillGps.Text = "List";
            this.btnAutoFillGps.Click += new System.EventHandler(this.btnAutoFillGps_Click);
            // 
            // chkLock2
            // 
            this.chkLock2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLock2.Checked = true;
            this.chkLock2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLock2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkLock2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLock2.Location = new System.Drawing.Point(165, 161);
            this.chkLock2.Name = "chkLock2";
            this.chkLock2.Size = new System.Drawing.Size(60, 20);
            this.chkLock2.TabIndex = 57;
            this.chkLock2.Text = "Lock";
            this.chkLock2.CheckStateChanged += new System.EventHandler(this.chkLock2_CheckStateChanged);
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(81, 115);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(144, 21);
            this.txtComment.TabIndex = 47;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            this.txtComment.GotFocus += new System.EventHandler(this.txtComment_GotFocus);
            this.txtComment.LostFocus += new System.EventHandler(this.txtComment_LostFocus);
            // 
            // txtCrew
            // 
            this.txtCrew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCrew.Location = new System.Drawing.Point(81, 88);
            this.txtCrew.Name = "txtCrew";
            this.txtCrew.Size = new System.Drawing.Size(144, 21);
            this.txtCrew.TabIndex = 48;
            this.txtCrew.TextChanged += new System.EventHandler(this.txtCrew_TextChanged);
            this.txtCrew.GotFocus += new System.EventHandler(this.txtCrew_GotFocus);
            this.txtCrew.LostFocus += new System.EventHandler(this.txtCrew_LostFocus);
            // 
            // txtCompass
            // 
            this.txtCompass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompass.Location = new System.Drawing.Point(81, 61);
            this.txtCompass.Name = "txtCompass";
            this.txtCompass.Size = new System.Drawing.Size(144, 21);
            this.txtCompass.TabIndex = 45;
            this.txtCompass.TextChanged += new System.EventHandler(this.txtCompass_TextChanged);
            this.txtCompass.GotFocus += new System.EventHandler(this.txtCompass_GotFocus);
            this.txtCompass.LostFocus += new System.EventHandler(this.txtCompass_LostFocus);
            // 
            // txtLaser
            // 
            this.txtLaser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLaser.Location = new System.Drawing.Point(81, 34);
            this.txtLaser.Name = "txtLaser";
            this.txtLaser.Size = new System.Drawing.Size(144, 21);
            this.txtLaser.TabIndex = 46;
            this.txtLaser.TextChanged += new System.EventHandler(this.txtLaser_TextChanged);
            this.txtLaser.GotFocus += new System.EventHandler(this.txtLaser_GotFocus);
            this.txtLaser.LostFocus += new System.EventHandler(this.txtLaser_LostFocus);
            // 
            // txtGPS
            // 
            this.txtGPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGPS.Location = new System.Drawing.Point(81, 7);
            this.txtGPS.Name = "txtGPS";
            this.txtGPS.Size = new System.Drawing.Size(144, 21);
            this.txtGPS.TabIndex = 50;
            this.txtGPS.TextChanged += new System.EventHandler(this.txtGPS_TextChanged);
            this.txtGPS.GotFocus += new System.EventHandler(this.txtGPS_GotFocus);
            this.txtGPS.LostFocus += new System.EventHandler(this.txtGPS_LostFocus);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(-1, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.Text = "Reciever:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(-1, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.Text = "Laser:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(-1, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.Text = "Comment:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(-1, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.Text = "Crew:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(-1, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.Text = "Compass:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pointNavigationCtrl
            // 
            this.pointNavigationCtrl.Location = new System.Drawing.Point(240, 0);
            this.pointNavigationCtrl.Name = "pointNavigationCtrl";
            this.pointNavigationCtrl.Size = new System.Drawing.Size(80, 99);
            this.pointNavigationCtrl.TabIndex = 4;
            this.pointNavigationCtrl.AlreadyAtEnd += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtEndEvent(this.pointNavigationCtrl_AlreadyAtEnd);
            this.pointNavigationCtrl.JumpPoint += new TwoTrails.Controls.PointNavigationCtrl.JumpPointEvent(this.pointNavigationCtrl_JumpPoint);
            this.pointNavigationCtrl.AlreadyAtBeginning += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtBeginningEvent(this.pointNavigationCtrl_AlreadyAtBeginning);
            this.pointNavigationCtrl.IndexChanged += new TwoTrails.Controls.PointNavigationCtrl.IndexChangedEvent(this.pointNavigationCtrl_IndexChanged);
            // 
            // actionsControl
            // 
            this.actionsControl.Location = new System.Drawing.Point(240, 99);
            this.actionsControl.Name = "actionsControl";
            this.actionsControl.Size = new System.Drawing.Size(80, 115);
            this.actionsControl.TabIndex = 2;
            this.actionsControl.Misc_OnClick += new TwoTrails.Controls.ActionsControl.MiscClicked(this.actionsControl_Misc_OnClick);
            this.actionsControl.Cancel_OnClick += new TwoTrails.Controls.ActionsControl.CancelClicked(this.actionsControl_Cancel_OnClick);
            this.actionsControl.New_OnClick += new TwoTrails.Controls.ActionsControl.NewClicked(this.actionsControl_New_OnClick);
            this.actionsControl.Ok_OnClick += new TwoTrails.Controls.ActionsControl.OkClicked(this.actionsControl_Ok_OnClick);
            this.actionsControl.Delete_OnClick += new TwoTrails.Controls.ActionsControl.DeleteClicked(this.actionsControl_Delete_OnClick);
            // 
            // bindingSourceMeta
            // 
            this.bindingSourceMeta.DataSource = typeof(TwoTrails.BusinessObjects.TtMetaData);
            // 
            // MetadataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.ControlBox = false;
            this.Controls.Add(this.pointNavigationCtrl);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.actionsControl);
            this.Name = "MetadataForm";
            this.Text = "Metadata";
            this.GotFocus += new System.EventHandler(this.MetadataForm_GotFocus);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MetadataForm_Closing);
            this.tabControl1.ResumeLayout(false);
            this.tabMeta.ResumeLayout(false);
            this.tabDevProj.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMeta)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private TwoTrails.Controls.ActionsControl actionsControl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMeta;
        private System.Windows.Forms.ComboBox cboMapProj;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtZone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TabPage tabDevProj;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtCrew;
        private System.Windows.Forms.TextBox txtCompass;
        private System.Windows.Forms.TextBox txtLaser;
        private System.Windows.Forms.TextBox txtGPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDatum;
        private System.Windows.Forms.ComboBox cboSlope;
        private System.Windows.Forms.ComboBox cboElev;
        private System.Windows.Forms.ComboBox cboDist;
        private System.Windows.Forms.CheckBox chkLock1;
        private System.Windows.Forms.TextBox txtMagDec;
        private System.Windows.Forms.ComboBox cboMagDec;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.CheckBox chkLock2;
        private System.Windows.Forms.BindingSource bindingSourceMeta;
        private TwoTrails.Controls.PointNavigationCtrl pointNavigationCtrl;
        private System.Windows.Forms.Button btnAutoFillGps;
        private System.Windows.Forms.Button btnLaserList;
        private System.Windows.Forms.Button btnCompassList;
        private System.Windows.Forms.Button btnSetAsDefault;
    }
}