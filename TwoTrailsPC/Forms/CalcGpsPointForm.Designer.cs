namespace TwoTrails.Forms
{
    partial class CalcGpsPointForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboFixType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCustom = new System.Windows.Forms.CheckBox();
            this.txtRange = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtDOP = new System.Windows.Forms.TextBox();
            this.cboDOP = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblNssda3 = new System.Windows.Forms.Label();
            this.lblNssda2 = new System.Windows.Forms.Label();
            this.lblNssda1 = new System.Windows.Forms.Label();
            this.lblutmY3 = new System.Windows.Forms.Label();
            this.lblutmY2 = new System.Windows.Forms.Label();
            this.lblutmY1 = new System.Windows.Forms.Label();
            this.lblutmX3 = new System.Windows.Forms.Label();
            this.lblutmX2 = new System.Windows.Forms.Label();
            this.lblutmX1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.lblUtmX = new System.Windows.Forms.Label();
            this.lblUtmY = new System.Windows.Forms.Label();
            this.lblNssda = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblBurstInfo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.cboFixType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkCustom);
            this.panel1.Controls.Add(this.txtRange);
            this.panel1.Controls.Add(this.txtStart);
            this.panel1.Controls.Add(this.txtGroup);
            this.panel1.Controls.Add(this.txtDOP);
            this.panel1.Controls.Add(this.cboDOP);
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 118);
            this.panel1.TabIndex = 0;
            // 
            // cboFixType
            // 
            this.cboFixType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFixType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFixType.FormattingEnabled = true;
            this.cboFixType.Items.AddRange(new object[] {
            "Any",
            "3D",
            "3D+DIFF",
            "PPS",
            "Float RTK",
            "RTK"});
            this.cboFixType.Location = new System.Drawing.Point(218, 29);
            this.cboFixType.Name = "cboFixType";
            this.cboFixType.Size = new System.Drawing.Size(85, 24);
            this.cboFixType.TabIndex = 0;
            this.cboFixType.TabStop = false;
            this.cboFixType.SelectedIndexChanged += new System.EventHandler(this.cboFixType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(97, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "--- Filters ---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Group Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(157, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Start At:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(161, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Range:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fix Type:";
            // 
            // chkCustom
            // 
            this.chkCustom.AutoSize = true;
            this.chkCustom.Checked = true;
            this.chkCustom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustom.Location = new System.Drawing.Point(10, 64);
            this.chkCustom.Name = "chkCustom";
            this.chkCustom.Size = new System.Drawing.Size(98, 20);
            this.chkCustom.TabIndex = 2;
            this.chkCustom.TabStop = false;
            this.chkCustom.Text = "Customize";
            this.chkCustom.UseVisualStyleBackColor = true;
            this.chkCustom.Visible = false;
            this.chkCustom.CheckedChanged += new System.EventHandler(this.chkCustom_CheckedChanged);
            // 
            // txtRange
            // 
            this.txtRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRange.Location = new System.Drawing.Point(218, 59);
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(85, 22);
            this.txtRange.TabIndex = 1;
            this.txtRange.TabStop = false;
            this.txtRange.TextChanged += new System.EventHandler(this.txtRange_TextChanged);
            // 
            // txtStart
            // 
            this.txtStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStart.Location = new System.Drawing.Point(218, 87);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(85, 22);
            this.txtStart.TabIndex = 1;
            this.txtStart.TabStop = false;
            this.txtStart.TextChanged += new System.EventHandler(this.txtStart_TextChanged);
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroup.Location = new System.Drawing.Point(101, 87);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(40, 22);
            this.txtGroup.TabIndex = 1;
            this.txtGroup.TabStop = false;
            this.txtGroup.TextChanged += new System.EventHandler(this.txtGroup_TextChanged);
            // 
            // txtDOP
            // 
            this.txtDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOP.Location = new System.Drawing.Point(101, 29);
            this.txtDOP.Name = "txtDOP";
            this.txtDOP.Size = new System.Drawing.Size(40, 22);
            this.txtDOP.TabIndex = 1;
            this.txtDOP.TabStop = false;
            this.txtDOP.TextChanged += new System.EventHandler(this.txtDOP_TextChanged);
            // 
            // cboDOP
            // 
            this.cboDOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDOP.FormattingEnabled = true;
            this.cboDOP.Items.AddRange(new object[] {
            "PDOP",
            "HDOP"});
            this.cboDOP.Location = new System.Drawing.Point(10, 27);
            this.cboDOP.Name = "cboDOP";
            this.cboDOP.Size = new System.Drawing.Size(85, 24);
            this.cboDOP.TabIndex = 0;
            this.cboDOP.TabStop = false;
            this.cboDOP.SelectedIndexChanged += new System.EventHandler(this.cboDOP_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.chk3);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lblNssda3);
            this.panel2.Controls.Add(this.lblNssda2);
            this.panel2.Controls.Add(this.lblNssda1);
            this.panel2.Controls.Add(this.lblutmY3);
            this.panel2.Controls.Add(this.lblutmY2);
            this.panel2.Controls.Add(this.lblutmY1);
            this.panel2.Controls.Add(this.lblutmX3);
            this.panel2.Controls.Add(this.lblutmX2);
            this.panel2.Controls.Add(this.lblutmX1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.chk2);
            this.panel2.Controls.Add(this.chk1);
            this.panel2.Location = new System.Drawing.Point(7, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 99);
            this.panel2.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "3rd";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "2nd";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "1st";
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk3.Location = new System.Drawing.Point(10, 75);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(49, 20);
            this.chk3.TabIndex = 2;
            this.chk3.TabStop = false;
            this.chk3.Text = "3rd";
            this.chk3.UseVisualStyleBackColor = true;
            this.chk3.CheckedChanged += new System.EventHandler(this.chk3_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(233, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "NSSDA %";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(161, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "UTM Y";
            // 
            // lblNssda3
            // 
            this.lblNssda3.AutoSize = true;
            this.lblNssda3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNssda3.Location = new System.Drawing.Point(251, 76);
            this.lblNssda3.Name = "lblNssda3";
            this.lblNssda3.Size = new System.Drawing.Size(35, 15);
            this.lblNssda3.TabIndex = 3;
            this.lblNssda3.Text = "0.00";
            // 
            // lblNssda2
            // 
            this.lblNssda2.AutoSize = true;
            this.lblNssda2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNssda2.Location = new System.Drawing.Point(251, 50);
            this.lblNssda2.Name = "lblNssda2";
            this.lblNssda2.Size = new System.Drawing.Size(35, 15);
            this.lblNssda2.TabIndex = 3;
            this.lblNssda2.Text = "0.00";
            // 
            // lblNssda1
            // 
            this.lblNssda1.AutoSize = true;
            this.lblNssda1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNssda1.Location = new System.Drawing.Point(251, 24);
            this.lblNssda1.Name = "lblNssda1";
            this.lblNssda1.Size = new System.Drawing.Size(35, 15);
            this.lblNssda1.TabIndex = 3;
            this.lblNssda1.Text = "0.00";
            // 
            // lblutmY3
            // 
            this.lblutmY3.AutoSize = true;
            this.lblutmY3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblutmY3.Location = new System.Drawing.Point(147, 76);
            this.lblutmY3.Name = "lblutmY3";
            this.lblutmY3.Size = new System.Drawing.Size(83, 15);
            this.lblutmY3.TabIndex = 3;
            this.lblutmY3.Text = "0000000.00";
            // 
            // lblutmY2
            // 
            this.lblutmY2.AutoSize = true;
            this.lblutmY2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblutmY2.Location = new System.Drawing.Point(147, 50);
            this.lblutmY2.Name = "lblutmY2";
            this.lblutmY2.Size = new System.Drawing.Size(83, 15);
            this.lblutmY2.TabIndex = 3;
            this.lblutmY2.Text = "0000000.00";
            // 
            // lblutmY1
            // 
            this.lblutmY1.AutoSize = true;
            this.lblutmY1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblutmY1.Location = new System.Drawing.Point(147, 24);
            this.lblutmY1.Name = "lblutmY1";
            this.lblutmY1.Size = new System.Drawing.Size(83, 15);
            this.lblutmY1.TabIndex = 3;
            this.lblutmY1.Text = "0000000.00";
            // 
            // lblutmX3
            // 
            this.lblutmX3.AutoSize = true;
            this.lblutmX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblutmX3.Location = new System.Drawing.Point(63, 76);
            this.lblutmX3.Name = "lblutmX3";
            this.lblutmX3.Size = new System.Drawing.Size(75, 15);
            this.lblutmX3.TabIndex = 3;
            this.lblutmX3.Text = "000000.00";
            // 
            // lblutmX2
            // 
            this.lblutmX2.AutoSize = true;
            this.lblutmX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblutmX2.Location = new System.Drawing.Point(63, 50);
            this.lblutmX2.Name = "lblutmX2";
            this.lblutmX2.Size = new System.Drawing.Size(75, 15);
            this.lblutmX2.TabIndex = 3;
            this.lblutmX2.Text = "000000.00";
            // 
            // lblutmX1
            // 
            this.lblutmX1.AutoSize = true;
            this.lblutmX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblutmX1.Location = new System.Drawing.Point(63, 24);
            this.lblutmX1.Name = "lblutmX1";
            this.lblutmX1.Size = new System.Drawing.Size(75, 15);
            this.lblutmX1.TabIndex = 3;
            this.lblutmX1.Text = "000000.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(74, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "UTM X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Group";
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk2.Location = new System.Drawing.Point(10, 49);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(52, 20);
            this.chk2.TabIndex = 2;
            this.chk2.TabStop = false;
            this.chk2.Text = "2nd";
            this.chk2.UseVisualStyleBackColor = true;
            this.chk2.CheckedChanged += new System.EventHandler(this.chk2_CheckedChanged);
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk1.Location = new System.Drawing.Point(10, 23);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(47, 20);
            this.chk1.TabIndex = 2;
            this.chk1.TabStop = false;
            this.chk1.Text = "1st";
            this.chk1.UseVisualStyleBackColor = true;
            this.chk1.CheckedChanged += new System.EventHandler(this.chk1_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.lblUtmX);
            this.panel3.Controls.Add(this.lblUtmY);
            this.panel3.Controls.Add(this.lblNssda);
            this.panel3.Controls.Add(this.label27);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Location = new System.Drawing.Point(7, 236);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(313, 47);
            this.panel3.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(25, 4);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 20);
            this.label22.TabIndex = 3;
            this.label22.Text = "UTM X";
            // 
            // lblUtmX
            // 
            this.lblUtmX.AutoSize = true;
            this.lblUtmX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUtmX.Location = new System.Drawing.Point(18, 27);
            this.lblUtmX.Name = "lblUtmX";
            this.lblUtmX.Size = new System.Drawing.Size(76, 16);
            this.lblUtmX.TabIndex = 3;
            this.lblUtmX.Text = "000000.00";
            // 
            // lblUtmY
            // 
            this.lblUtmY.AutoSize = true;
            this.lblUtmY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUtmY.Location = new System.Drawing.Point(114, 27);
            this.lblUtmY.Name = "lblUtmY";
            this.lblUtmY.Size = new System.Drawing.Size(84, 16);
            this.lblUtmY.TabIndex = 3;
            this.lblUtmY.Text = "0000000.00";
            // 
            // lblNssda
            // 
            this.lblNssda.AutoSize = true;
            this.lblNssda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNssda.Location = new System.Drawing.Point(233, 27);
            this.lblNssda.Name = "lblNssda";
            this.lblNssda.Size = new System.Drawing.Size(36, 16);
            this.lblNssda.TabIndex = 3;
            this.lblNssda.Text = "0.00";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(211, 4);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(90, 20);
            this.label27.TabIndex = 3;
            this.label27.Text = "NSSDA %";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(125, 4);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 20);
            this.label26.TabIndex = 3;
            this.label26.Text = "UTM Y";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.lblBurstInfo);
            this.panel4.Location = new System.Drawing.Point(7, 289);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(313, 28);
            this.panel4.TabIndex = 1;
            // 
            // lblBurstInfo
            // 
            this.lblBurstInfo.AutoSize = true;
            this.lblBurstInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBurstInfo.Location = new System.Drawing.Point(77, 4);
            this.lblBurstInfo.Name = "lblBurstInfo";
            this.lblBurstInfo.Size = new System.Drawing.Size(149, 18);
            this.lblBurstInfo.TabIndex = 3;
            this.lblBurstInfo.Text = "0 of 0 Bursts Used";
            this.lblBurstInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(7, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalc.Location = new System.Drawing.Point(88, 324);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(141, 25);
            this.btnCalc.TabIndex = 2;
            this.btnCalc.TabStop = false;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(235, 324);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // CalcGpsPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 357);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(343, 395);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(343, 395);
            this.Name = "CalcGpsPointForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculate Gps Point";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboFixType;
        private System.Windows.Forms.ComboBox cboDOP;
        private System.Windows.Forms.TextBox txtRange;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.TextBox txtDOP;
        private System.Windows.Forms.CheckBox chkCustom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk1;
        private System.Windows.Forms.CheckBox chk3;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblutmX1;
        private System.Windows.Forms.Label lblutmY1;
        private System.Windows.Forms.Label lblNssda1;
        private System.Windows.Forms.Label lblNssda3;
        private System.Windows.Forms.Label lblNssda2;
        private System.Windows.Forms.Label lblutmY3;
        private System.Windows.Forms.Label lblutmY2;
        private System.Windows.Forms.Label lblutmX3;
        private System.Windows.Forms.Label lblutmX2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblUtmX;
        private System.Windows.Forms.Label lblUtmY;
        private System.Windows.Forms.Label lblNssda;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblBurstInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStart;
    }
}