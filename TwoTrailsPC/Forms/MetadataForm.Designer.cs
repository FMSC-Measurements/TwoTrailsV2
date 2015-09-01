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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.txtMagDec = new System.Windows.Forms.TextBox();
            this.txtZone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboSlope = new System.Windows.Forms.ComboBox();
            this.cboDist = new System.Windows.Forms.ComboBox();
            this.cboElev = new System.Windows.Forms.ComboBox();
            this.cboMagDec = new System.Windows.Forms.ComboBox();
            this.cboMapProj = new System.Windows.Forms.ComboBox();
            this.cboDatum = new System.Windows.Forms.ComboBox();
            this.tabDevProj = new System.Windows.Forms.TabPage();
            this.btnCompassList = new System.Windows.Forms.Button();
            this.btnLaserList = new System.Windows.Forms.Button();
            this.btnAutoFillGps = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtCrew = new System.Windows.Forms.TextBox();
            this.txtCompass = new System.Windows.Forms.TextBox();
            this.txtLaser = new System.Windows.Forms.TextBox();
            this.txtGPS = new System.Windows.Forms.TextBox();
            this.chkLock1 = new System.Windows.Forms.CheckBox();
            this.actionsControl = new TwoTrails.Controls.ActionsControl();
            this.pointNavigationCtrl = new TwoTrails.Controls.PointNavigationCtrl();
            this.bindingSourceMeta = new System.Windows.Forms.BindingSource(this.components);
            this.btnSetAsDefault = new System.Windows.Forms.Button();
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
            this.tabControl1.Location = new System.Drawing.Point(5, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(392, 151);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMeta
            // 
            this.tabMeta.Controls.Add(this.label7);
            this.tabMeta.Controls.Add(this.label6);
            this.tabMeta.Controls.Add(this.label4);
            this.tabMeta.Controls.Add(this.label5);
            this.tabMeta.Controls.Add(this.label3);
            this.tabMeta.Controls.Add(this.label2);
            this.tabMeta.Controls.Add(this.label1);
            this.tabMeta.Controls.Add(this.btnHelp);
            this.tabMeta.Controls.Add(this.txtMagDec);
            this.tabMeta.Controls.Add(this.txtZone);
            this.tabMeta.Controls.Add(this.txtName);
            this.tabMeta.Controls.Add(this.cboSlope);
            this.tabMeta.Controls.Add(this.cboDist);
            this.tabMeta.Controls.Add(this.cboElev);
            this.tabMeta.Controls.Add(this.cboMagDec);
            this.tabMeta.Controls.Add(this.cboMapProj);
            this.tabMeta.Controls.Add(this.cboDatum);
            this.tabMeta.Location = new System.Drawing.Point(4, 22);
            this.tabMeta.Name = "tabMeta";
            this.tabMeta.Padding = new System.Windows.Forms.Padding(3);
            this.tabMeta.Size = new System.Drawing.Size(384, 125);
            this.tabMeta.TabIndex = 0;
            this.tabMeta.Text = "Metadata";
            this.tabMeta.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(194, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Distance:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(194, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Slope:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Map Proj Units:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(190, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Elevation:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Datum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Zone:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(110, 35);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.TabStop = false;
            this.btnHelp.Text = "Get Zone";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // txtMagDec
            // 
            this.txtMagDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMagDec.Location = new System.Drawing.Point(298, 96);
            this.txtMagDec.Name = "txtMagDec";
            this.txtMagDec.Size = new System.Drawing.Size(76, 22);
            this.txtMagDec.TabIndex = 1;
            this.txtMagDec.TabStop = false;
            this.txtMagDec.TextChanged += new System.EventHandler(this.txtMagDec_TextChanged);
            // 
            // txtZone
            // 
            this.txtZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZone.Location = new System.Drawing.Point(65, 35);
            this.txtZone.Name = "txtZone";
            this.txtZone.Size = new System.Drawing.Size(39, 22);
            this.txtZone.TabIndex = 1;
            this.txtZone.TabStop = false;
            this.txtZone.TextChanged += new System.EventHandler(this.txtZone_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(65, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 22);
            this.txtName.TabIndex = 1;
            this.txtName.TabStop = false;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // cboSlope
            // 
            this.cboSlope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSlope.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSlope.FormattingEnabled = true;
            this.cboSlope.Location = new System.Drawing.Point(252, 64);
            this.cboSlope.Name = "cboSlope";
            this.cboSlope.Size = new System.Drawing.Size(122, 24);
            this.cboSlope.TabIndex = 0;
            this.cboSlope.TabStop = false;
            this.cboSlope.SelectedIndexChanged += new System.EventHandler(this.cboSlope_SelectedIndexChanged);
            // 
            // cboDist
            // 
            this.cboDist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDist.FormattingEnabled = true;
            this.cboDist.Location = new System.Drawing.Point(273, 4);
            this.cboDist.Name = "cboDist";
            this.cboDist.Size = new System.Drawing.Size(101, 24);
            this.cboDist.TabIndex = 0;
            this.cboDist.TabStop = false;
            this.cboDist.SelectedIndexChanged += new System.EventHandler(this.cboDist_SelectedIndexChanged);
            // 
            // cboElev
            // 
            this.cboElev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboElev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboElev.FormattingEnabled = true;
            this.cboElev.Location = new System.Drawing.Point(273, 34);
            this.cboElev.Name = "cboElev";
            this.cboElev.Size = new System.Drawing.Size(101, 24);
            this.cboElev.TabIndex = 0;
            this.cboElev.TabStop = false;
            this.cboElev.SelectedIndexChanged += new System.EventHandler(this.cboElev_SelectedIndexChanged);
            // 
            // cboMagDec
            // 
            this.cboMagDec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMagDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMagDec.FormattingEnabled = true;
            this.cboMagDec.Location = new System.Drawing.Point(191, 94);
            this.cboMagDec.Name = "cboMagDec";
            this.cboMagDec.Size = new System.Drawing.Size(101, 24);
            this.cboMagDec.TabIndex = 0;
            this.cboMagDec.TabStop = false;
            this.cboMagDec.SelectedIndexChanged += new System.EventHandler(this.cboMagDec_SelectedIndexChanged);
            // 
            // cboMapProj
            // 
            this.cboMapProj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMapProj.Enabled = false;
            this.cboMapProj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMapProj.FormattingEnabled = true;
            this.cboMapProj.Location = new System.Drawing.Point(122, 94);
            this.cboMapProj.Name = "cboMapProj";
            this.cboMapProj.Size = new System.Drawing.Size(63, 24);
            this.cboMapProj.TabIndex = 0;
            this.cboMapProj.TabStop = false;
            this.cboMapProj.SelectedIndexChanged += new System.EventHandler(this.cboMapProj_SelectedIndexChanged);
            // 
            // cboDatum
            // 
            this.cboDatum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatum.Enabled = false;
            this.cboDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDatum.FormattingEnabled = true;
            this.cboDatum.Location = new System.Drawing.Point(64, 64);
            this.cboDatum.Name = "cboDatum";
            this.cboDatum.Size = new System.Drawing.Size(121, 24);
            this.cboDatum.TabIndex = 0;
            this.cboDatum.TabStop = false;
            this.cboDatum.SelectedIndexChanged += new System.EventHandler(this.cboDatum_SelectedIndexChanged);
            // 
            // tabDevProj
            // 
            this.tabDevProj.Controls.Add(this.btnCompassList);
            this.tabDevProj.Controls.Add(this.btnLaserList);
            this.tabDevProj.Controls.Add(this.btnAutoFillGps);
            this.tabDevProj.Controls.Add(this.label12);
            this.tabDevProj.Controls.Add(this.label11);
            this.tabDevProj.Controls.Add(this.label9);
            this.tabDevProj.Controls.Add(this.label10);
            this.tabDevProj.Controls.Add(this.label8);
            this.tabDevProj.Controls.Add(this.txtComment);
            this.tabDevProj.Controls.Add(this.txtCrew);
            this.tabDevProj.Controls.Add(this.txtCompass);
            this.tabDevProj.Controls.Add(this.txtLaser);
            this.tabDevProj.Controls.Add(this.txtGPS);
            this.tabDevProj.Location = new System.Drawing.Point(4, 22);
            this.tabDevProj.Name = "tabDevProj";
            this.tabDevProj.Padding = new System.Windows.Forms.Padding(3);
            this.tabDevProj.Size = new System.Drawing.Size(384, 125);
            this.tabDevProj.TabIndex = 1;
            this.tabDevProj.Text = "Device - Project";
            this.tabDevProj.UseVisualStyleBackColor = true;
            // 
            // btnCompassList
            // 
            this.btnCompassList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompassList.Location = new System.Drawing.Point(213, 61);
            this.btnCompassList.Name = "btnCompassList";
            this.btnCompassList.Size = new System.Drawing.Size(43, 23);
            this.btnCompassList.TabIndex = 3;
            this.btnCompassList.TabStop = false;
            this.btnCompassList.Text = "List";
            this.btnCompassList.UseVisualStyleBackColor = true;
            this.btnCompassList.Click += new System.EventHandler(this.btnCompassList_Click);
            // 
            // btnLaserList
            // 
            this.btnLaserList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaserList.Location = new System.Drawing.Point(213, 33);
            this.btnLaserList.Name = "btnLaserList";
            this.btnLaserList.Size = new System.Drawing.Size(43, 23);
            this.btnLaserList.TabIndex = 3;
            this.btnLaserList.TabStop = false;
            this.btnLaserList.Text = "List";
            this.btnLaserList.UseVisualStyleBackColor = true;
            this.btnLaserList.Click += new System.EventHandler(this.btnLaserList_Click);
            // 
            // btnAutoFillGps
            // 
            this.btnAutoFillGps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoFillGps.Location = new System.Drawing.Point(213, 5);
            this.btnAutoFillGps.Name = "btnAutoFillGps";
            this.btnAutoFillGps.Size = new System.Drawing.Size(43, 23);
            this.btnAutoFillGps.TabIndex = 3;
            this.btnAutoFillGps.TabStop = false;
            this.btnAutoFillGps.Text = "List";
            this.btnAutoFillGps.UseVisualStyleBackColor = true;
            this.btnAutoFillGps.Click += new System.EventHandler(this.btnAutoFillGps_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(262, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Comment:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(35, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Crew:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(30, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Laser:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Compass:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Receiver:";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(262, 33);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(116, 78);
            this.txtComment.TabIndex = 0;
            this.txtComment.TabStop = false;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            // 
            // txtCrew
            // 
            this.txtCrew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrew.Location = new System.Drawing.Point(87, 90);
            this.txtCrew.Name = "txtCrew";
            this.txtCrew.Size = new System.Drawing.Size(120, 22);
            this.txtCrew.TabIndex = 0;
            this.txtCrew.TabStop = false;
            this.txtCrew.TextChanged += new System.EventHandler(this.txtCrew_TextChanged);
            // 
            // txtCompass
            // 
            this.txtCompass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompass.Location = new System.Drawing.Point(87, 62);
            this.txtCompass.Name = "txtCompass";
            this.txtCompass.Size = new System.Drawing.Size(120, 22);
            this.txtCompass.TabIndex = 0;
            this.txtCompass.TabStop = false;
            this.txtCompass.TextChanged += new System.EventHandler(this.txtCompass_TextChanged);
            // 
            // txtLaser
            // 
            this.txtLaser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLaser.Location = new System.Drawing.Point(87, 34);
            this.txtLaser.Name = "txtLaser";
            this.txtLaser.Size = new System.Drawing.Size(120, 22);
            this.txtLaser.TabIndex = 0;
            this.txtLaser.TabStop = false;
            this.txtLaser.TextChanged += new System.EventHandler(this.txtLaser_TextChanged);
            // 
            // txtGPS
            // 
            this.txtGPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPS.Location = new System.Drawing.Point(87, 6);
            this.txtGPS.Name = "txtGPS";
            this.txtGPS.Size = new System.Drawing.Size(120, 22);
            this.txtGPS.TabIndex = 0;
            this.txtGPS.TabStop = false;
            this.txtGPS.TextChanged += new System.EventHandler(this.txtGps_TextChanged);
            // 
            // chkLock1
            // 
            this.chkLock1.AutoSize = true;
            this.chkLock1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLock1.Location = new System.Drawing.Point(338, 7);
            this.chkLock1.Name = "chkLock1";
            this.chkLock1.Size = new System.Drawing.Size(56, 19);
            this.chkLock1.TabIndex = 4;
            this.chkLock1.TabStop = false;
            this.chkLock1.Text = "Lock";
            this.chkLock1.UseVisualStyleBackColor = true;
            this.chkLock1.CheckedChanged += new System.EventHandler(this.chkLock1_CheckedChanged);
            // 
            // actionsControl
            // 
            this.actionsControl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.actionsControl.DeleteEnabled = true;
            this.actionsControl.Location = new System.Drawing.Point(5, 200);
            this.actionsControl.MiscButtonEnabled = true;
            this.actionsControl.MiscButtonText = "Misc";
            this.actionsControl.Name = "actionsControl";
            this.actionsControl.NewEnabled = true;
            this.actionsControl.OkEnabled = true;
            this.actionsControl.Size = new System.Drawing.Size(332, 47);
            this.actionsControl.TabIndex = 6;
            this.actionsControl.New_OnClick += new TwoTrails.Controls.ActionsControl.NewClicked(this.actionsControl1_New_OnClick);
            this.actionsControl.Cancel_OnClick += new TwoTrails.Controls.ActionsControl.CancelClicked(this.actionsControl1_Cancel_OnClick);
            this.actionsControl.Delete_OnClick += new TwoTrails.Controls.ActionsControl.DeleteClicked(this.actionsControl1_Delete_OnClick);
            this.actionsControl.Misc_OnClick += new TwoTrails.Controls.ActionsControl.MiscClicked(this.actionsControl1_Misc_OnClick);
            this.actionsControl.Ok_OnClick += new TwoTrails.Controls.ActionsControl.OkClicked(this.actionsControl1_Ok_OnClick);
            // 
            // pointNavigationCtrl
            // 
            this.pointNavigationCtrl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pointNavigationCtrl.BackwardButtons = true;
            this.pointNavigationCtrl.ForwardButtons = true;
            this.pointNavigationCtrl.Location = new System.Drawing.Point(5, 160);
            this.pointNavigationCtrl.Name = "pointNavigationCtrl";
            this.pointNavigationCtrl.Size = new System.Drawing.Size(332, 40);
            this.pointNavigationCtrl.TabIndex = 5;
            this.pointNavigationCtrl.AlreadyAtEnd += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtEndEvent(this.pointNavigationCtrl1_AlreadyAtEnd);
            this.pointNavigationCtrl.AlreadyAtBeginning += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtBeginningEvent(this.pointNavigationCtrl1_AlreadyAtBeginning);
            this.pointNavigationCtrl.IndexChanged += new TwoTrails.Controls.PointNavigationCtrl.IndexChangedEvent(this.pointNavigationCtrl1_IndexChanged);
            this.pointNavigationCtrl.JumpPoint += new TwoTrails.Controls.PointNavigationCtrl.JumpPointEvent(this.pointNavigationCtrl1_JumpPoint);
            // 
            // bindingSourceMeta
            // 
            this.bindingSourceMeta.DataSource = typeof(TwoTrails.BusinessObjects.TtMetaData);
            // 
            // btnSetAsDefault
            // 
            this.btnSetAsDefault.Location = new System.Drawing.Point(338, 204);
            this.btnSetAsDefault.Name = "btnSetAsDefault";
            this.btnSetAsDefault.Size = new System.Drawing.Size(59, 40);
            this.btnSetAsDefault.TabIndex = 7;
            this.btnSetAsDefault.TabStop = false;
            this.btnSetAsDefault.Text = "Set As Default";
            this.btnSetAsDefault.UseVisualStyleBackColor = true;
            this.btnSetAsDefault.Click += new System.EventHandler(this.btnSetAsDefault_Click);
            // 
            // MetadataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 249);
            this.Controls.Add(this.btnSetAsDefault);
            this.Controls.Add(this.actionsControl);
            this.Controls.Add(this.pointNavigationCtrl);
            this.Controls.Add(this.chkLock1);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(418, 287);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(418, 287);
            this.Name = "MetadataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Metadata";
            this.tabControl1.ResumeLayout(false);
            this.tabMeta.ResumeLayout(false);
            this.tabMeta.PerformLayout();
            this.tabDevProj.ResumeLayout(false);
            this.tabDevProj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMeta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMeta;
        private System.Windows.Forms.TabPage tabDevProj;
        private System.Windows.Forms.ComboBox cboDatum;
        private System.Windows.Forms.TextBox txtZone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboSlope;
        private System.Windows.Forms.ComboBox cboElev;
        private System.Windows.Forms.ComboBox cboMagDec;
        private System.Windows.Forms.ComboBox cboMapProj;
        private System.Windows.Forms.TextBox txtMagDec;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkLock1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGPS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtCrew;
        private System.Windows.Forms.TextBox txtCompass;
        private System.Windows.Forms.TextBox txtLaser;
        private System.Windows.Forms.Button btnCompassList;
        private System.Windows.Forms.Button btnLaserList;
        private System.Windows.Forms.Button btnAutoFillGps;
        private System.Windows.Forms.ComboBox cboDist;
        private TwoTrails.Controls.PointNavigationCtrl pointNavigationCtrl;
        private TwoTrails.Controls.ActionsControl actionsControl;
        private System.Windows.Forms.BindingSource bindingSourceMeta;
        private System.Windows.Forms.Button btnSetAsDefault;
    }
}