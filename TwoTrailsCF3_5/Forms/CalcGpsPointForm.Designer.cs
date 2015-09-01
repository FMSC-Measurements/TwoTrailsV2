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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRange = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkCustom = new System.Windows.Forms.CheckBox();
            this.btnFixType = new System.Windows.Forms.Button();
            this.btnDOP = new System.Windows.Forms.Button();
            this.txtDOP = new System.Windows.Forms.TextBox();
            this.cboDOP = new System.Windows.Forms.ComboBox();
            this.cboFixType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNssda3 = new System.Windows.Forms.Label();
            this.lblNssda2 = new System.Windows.Forms.Label();
            this.lblNssda1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblutmY3 = new System.Windows.Forms.Label();
            this.lblutmX3 = new System.Windows.Forms.Label();
            this.lblutmY1 = new System.Windows.Forms.Label();
            this.lblutmX1 = new System.Windows.Forms.Label();
            this.lblutmY2 = new System.Windows.Forms.Label();
            this.lblutmX2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNssda = new System.Windows.Forms.Label();
            this.lblUtmY = new System.Windows.Forms.Label();
            this.lblUtmX = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBurstInfo = new System.Windows.Forms.Label();
            this.pnlFilter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(167, 266);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 25);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(79, 266);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(82, 25);
            this.btnCalc.TabIndex = 0;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pnlFilter.Controls.Add(this.txtGroup);
            this.pnlFilter.Controls.Add(this.txtStart);
            this.pnlFilter.Controls.Add(this.label5);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.txtRange);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.chkCustom);
            this.pnlFilter.Controls.Add(this.btnFixType);
            this.pnlFilter.Controls.Add(this.btnDOP);
            this.pnlFilter.Controls.Add(this.txtDOP);
            this.pnlFilter.Controls.Add(this.cboDOP);
            this.pnlFilter.Controls.Add(this.cboFixType);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(240, 92);
            // 
            // txtGroup
            // 
            this.txtGroup.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtGroup.Location = new System.Drawing.Point(81, 66);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(35, 21);
            this.txtGroup.TabIndex = 13;
            this.txtGroup.TextChanged += new System.EventHandler(this.txtGroup_TextChanged);
            this.txtGroup.GotFocus += new System.EventHandler(this.txtGroup_GotFocus);
            this.txtGroup.LostFocus += new System.EventHandler(this.txtGroup_LostFocus);
            // 
            // txtStart
            // 
            this.txtStart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtStart.Location = new System.Drawing.Point(170, 66);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(67, 21);
            this.txtStart.TabIndex = 14;
            this.txtStart.Visible = false;
            this.txtStart.TextChanged += new System.EventHandler(this.txtStart_TextChanged);
            this.txtStart.GotFocus += new System.EventHandler(this.txtStart_GotFocus);
            this.txtStart.LostFocus += new System.EventHandler(this.txtStart_LostFocus);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(115, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.Text = "StartAt:";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(4, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Group Size:";
            // 
            // txtRange
            // 
            this.txtRange.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtRange.Location = new System.Drawing.Point(170, 44);
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(67, 21);
            this.txtRange.TabIndex = 12;
            this.txtRange.TextChanged += new System.EventHandler(this.txtRange_TextChanged);
            this.txtRange.GotFocus += new System.EventHandler(this.txtRange_GotFocus);
            this.txtRange.LostFocus += new System.EventHandler(this.txtRange_LostFocus);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(120, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.Text = "Range:";
            // 
            // chkCustom
            // 
            this.chkCustom.Checked = true;
            this.chkCustom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCustom.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkCustom.Location = new System.Drawing.Point(0, 44);
            this.chkCustom.Name = "chkCustom";
            this.chkCustom.Size = new System.Drawing.Size(104, 20);
            this.chkCustom.TabIndex = 11;
            this.chkCustom.Text = "Customize";
            this.chkCustom.Visible = false;
            this.chkCustom.CheckStateChanged += new System.EventHandler(this.chkCustom_CheckStateChanged);
            // 
            // btnFixType
            // 
            this.btnFixType.Location = new System.Drawing.Point(170, 20);
            this.btnFixType.Name = "btnFixType";
            this.btnFixType.Size = new System.Drawing.Size(67, 22);
            this.btnFixType.TabIndex = 5;
            this.btnFixType.Text = "3D+DIFF";
            this.btnFixType.Click += new System.EventHandler(this.btnFixType_Click);
            // 
            // btnDOP
            // 
            this.btnDOP.Location = new System.Drawing.Point(3, 20);
            this.btnDOP.Name = "btnDOP";
            this.btnDOP.Size = new System.Drawing.Size(67, 22);
            this.btnDOP.TabIndex = 4;
            this.btnDOP.Text = "PDOP";
            this.btnDOP.Click += new System.EventHandler(this.btnDOP_Click);
            // 
            // txtDOP
            // 
            this.txtDOP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDOP.Location = new System.Drawing.Point(74, 20);
            this.txtDOP.Name = "txtDOP";
            this.txtDOP.Size = new System.Drawing.Size(27, 21);
            this.txtDOP.TabIndex = 3;
            this.txtDOP.TextChanged += new System.EventHandler(this.txtDOP_TextChanged);
            this.txtDOP.GotFocus += new System.EventHandler(this.txtDOP_GotFocus);
            this.txtDOP.LostFocus += new System.EventHandler(this.txtDOP_LostFocus);
            // 
            // cboDOP
            // 
            this.cboDOP.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cboDOP.Items.Add("PDOP");
            this.cboDOP.Items.Add("HDOP");
            this.cboDOP.Location = new System.Drawing.Point(3, 20);
            this.cboDOP.Name = "cboDOP";
            this.cboDOP.Size = new System.Drawing.Size(67, 22);
            this.cboDOP.TabIndex = 2;
            this.cboDOP.SelectedIndexChanged += new System.EventHandler(this.cboDOP_SelectedIndexChanged);
            // 
            // cboFixType
            // 
            this.cboFixType.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cboFixType.Items.Add("Any");
            this.cboFixType.Items.Add("3D");
            this.cboFixType.Items.Add("3D+DIFF");
            this.cboFixType.Location = new System.Drawing.Point(170, 20);
            this.cboFixType.Name = "cboFixType";
            this.cboFixType.Size = new System.Drawing.Size(67, 22);
            this.cboFixType.TabIndex = 2;
            this.cboFixType.SelectedIndexChanged += new System.EventHandler(this.cboFixType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(107, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.Text = "Fix Type:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 20);
            this.label1.Text = "----- Filters -----";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.lblNssda3);
            this.panel2.Controls.Add(this.lblNssda2);
            this.panel2.Controls.Add(this.lblNssda1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblutmY3);
            this.panel2.Controls.Add(this.lblutmX3);
            this.panel2.Controls.Add(this.lblutmY1);
            this.panel2.Controls.Add(this.lblutmX1);
            this.panel2.Controls.Add(this.lblutmY2);
            this.panel2.Controls.Add(this.lblutmX2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.chk3);
            this.panel2.Controls.Add(this.chk2);
            this.panel2.Controls.Add(this.chk1);
            this.panel2.Location = new System.Drawing.Point(0, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 103);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(126, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.Text = "UTM Y";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(166, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.Text = "NSSDA %";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(24, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 20);
            this.label15.Text = "3rd";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(24, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 20);
            this.label14.Text = "2nd";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(24, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 20);
            this.label13.Text = "1st";
            // 
            // lblNssda3
            // 
            this.lblNssda3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblNssda3.Location = new System.Drawing.Point(204, 81);
            this.lblNssda3.Name = "lblNssda3";
            this.lblNssda3.Size = new System.Drawing.Size(36, 20);
            this.lblNssda3.Text = "0.00";
            // 
            // lblNssda2
            // 
            this.lblNssda2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblNssda2.Location = new System.Drawing.Point(204, 55);
            this.lblNssda2.Name = "lblNssda2";
            this.lblNssda2.Size = new System.Drawing.Size(36, 20);
            this.lblNssda2.Text = "0.00";
            // 
            // lblNssda1
            // 
            this.lblNssda1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblNssda1.Location = new System.Drawing.Point(204, 29);
            this.lblNssda1.Name = "lblNssda1";
            this.lblNssda1.Size = new System.Drawing.Size(36, 20);
            this.lblNssda1.Text = "0.00";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(62, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.Text = "UTM X";
            // 
            // lblutmY3
            // 
            this.lblutmY3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblutmY3.Location = new System.Drawing.Point(127, 81);
            this.lblutmY3.Name = "lblutmY3";
            this.lblutmY3.Size = new System.Drawing.Size(70, 20);
            this.lblutmY3.Text = "0000000.00";
            // 
            // lblutmX3
            // 
            this.lblutmX3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblutmX3.Location = new System.Drawing.Point(62, 81);
            this.lblutmX3.Name = "lblutmX3";
            this.lblutmX3.Size = new System.Drawing.Size(70, 20);
            this.lblutmX3.Text = "000000.00";
            // 
            // lblutmY1
            // 
            this.lblutmY1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblutmY1.Location = new System.Drawing.Point(127, 29);
            this.lblutmY1.Name = "lblutmY1";
            this.lblutmY1.Size = new System.Drawing.Size(70, 20);
            this.lblutmY1.Text = "0000000.00";
            // 
            // lblutmX1
            // 
            this.lblutmX1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblutmX1.Location = new System.Drawing.Point(62, 29);
            this.lblutmX1.Name = "lblutmX1";
            this.lblutmX1.Size = new System.Drawing.Size(70, 20);
            this.lblutmX1.Text = "000000.00";
            // 
            // lblutmY2
            // 
            this.lblutmY2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblutmY2.Location = new System.Drawing.Point(127, 55);
            this.lblutmY2.Name = "lblutmY2";
            this.lblutmY2.Size = new System.Drawing.Size(70, 20);
            this.lblutmY2.Text = "0000000.00";
            // 
            // lblutmX2
            // 
            this.lblutmX2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblutmX2.Location = new System.Drawing.Point(62, 55);
            this.lblutmX2.Name = "lblutmX2";
            this.lblutmX2.Size = new System.Drawing.Size(70, 20);
            this.lblutmX2.Text = "000000.00";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(4, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.Text = "Group";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chk3
            // 
            this.chk3.Enabled = false;
            this.chk3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chk3.Location = new System.Drawing.Point(3, 78);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(55, 20);
            this.chk3.TabIndex = 2;
            this.chk3.Text = "3rd";
            this.chk3.CheckStateChanged += new System.EventHandler(this.chk3_CheckStateChanged);
            // 
            // chk2
            // 
            this.chk2.Enabled = false;
            this.chk2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chk2.Location = new System.Drawing.Point(3, 52);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(55, 20);
            this.chk2.TabIndex = 1;
            this.chk2.Text = "2nd";
            this.chk2.CheckStateChanged += new System.EventHandler(this.chk2_CheckStateChanged);
            // 
            // chk1
            // 
            this.chk1.Enabled = false;
            this.chk1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chk1.Location = new System.Drawing.Point(3, 26);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(55, 20);
            this.chk1.TabIndex = 0;
            this.chk1.Text = "1st";
            this.chk1.CheckStateChanged += new System.EventHandler(this.chk1_CheckStateChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel3.Controls.Add(this.lblNssda);
            this.panel3.Controls.Add(this.lblUtmY);
            this.panel3.Controls.Add(this.lblUtmX);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(0, 199);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 40);
            // 
            // lblNssda
            // 
            this.lblNssda.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblNssda.Location = new System.Drawing.Point(160, 21);
            this.lblNssda.Name = "lblNssda";
            this.lblNssda.Size = new System.Drawing.Size(80, 20);
            this.lblNssda.Text = "0.00";
            this.lblNssda.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUtmY
            // 
            this.lblUtmY.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblUtmY.Location = new System.Drawing.Point(81, 23);
            this.lblUtmY.Name = "lblUtmY";
            this.lblUtmY.Size = new System.Drawing.Size(80, 20);
            this.lblUtmY.Text = "000000.00";
            this.lblUtmY.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUtmX
            // 
            this.lblUtmX.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblUtmX.Location = new System.Drawing.Point(4, 23);
            this.lblUtmX.Name = "lblUtmX";
            this.lblUtmX.Size = new System.Drawing.Size(80, 20);
            this.lblUtmX.Text = "000000.00";
            this.lblUtmX.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(157, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 20);
            this.label12.Text = "NSSDA %";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(81, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 20);
            this.label11.Text = "UTM Y";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(3, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.Text = "UTM X";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.Controls.Add(this.lblBurstInfo);
            this.panel1.Location = new System.Drawing.Point(0, 242);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 20);
            // 
            // lblBurstInfo
            // 
            this.lblBurstInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBurstInfo.Location = new System.Drawing.Point(4, 5);
            this.lblBurstInfo.Name = "lblBurstInfo";
            this.lblBurstInfo.Size = new System.Drawing.Size(233, 16);
            this.lblBurstInfo.Text = "0 of 0 Bursts used.";
            this.lblBurstInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CalcGpsPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.btnOk);
            this.Name = "CalcGpsPointForm";
            this.Text = "Calculate Gps Point";
            this.pnlFilter.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        private void InitializeComponentWide()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRange = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkCustom = new System.Windows.Forms.CheckBox();
            this.btnFixType = new System.Windows.Forms.Button();
            this.btnDOP = new System.Windows.Forms.Button();
            this.txtDOP = new System.Windows.Forms.TextBox();
            this.cboDOP = new System.Windows.Forms.ComboBox();
            this.cboFixType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblNssda3 = new System.Windows.Forms.Label();
            this.lblNssda2 = new System.Windows.Forms.Label();
            this.lblNssda1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblutmY3 = new System.Windows.Forms.Label();
            this.lblutmX3 = new System.Windows.Forms.Label();
            this.lblutmY1 = new System.Windows.Forms.Label();
            this.lblutmX1 = new System.Windows.Forms.Label();
            this.lblutmY2 = new System.Windows.Forms.Label();
            this.lblutmX2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblUtmX = new System.Windows.Forms.Label();
            this.lblNssda = new System.Windows.Forms.Label();
            this.lblUtmY = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBurstInfo = new System.Windows.Forms.Label();
            this.pnlFilter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(250, 117);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(67, 25);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(250, 148);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(67, 32);
            this.btnCalc.TabIndex = 0;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pnlFilter.Controls.Add(this.txtGroup);
            this.pnlFilter.Controls.Add(this.txtStart);
            this.pnlFilter.Controls.Add(this.label5);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.txtRange);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.chkCustom);
            this.pnlFilter.Controls.Add(this.btnFixType);
            this.pnlFilter.Controls.Add(this.btnDOP);
            this.pnlFilter.Controls.Add(this.txtDOP);
            this.pnlFilter.Controls.Add(this.cboDOP);
            this.pnlFilter.Controls.Add(this.cboFixType);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(244, 92);
            // 
            // txtGroup
            // 
            this.txtGroup.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtGroup.Enabled = false;
            this.txtGroup.Location = new System.Drawing.Point(82, 66);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(35, 21);
            this.txtGroup.TabIndex = 13;
            this.txtGroup.TextChanged += new System.EventHandler(this.txtGroup_TextChanged);
            this.txtGroup.GotFocus += new System.EventHandler(this.txtGroup_GotFocus);
            this.txtGroup.LostFocus += new System.EventHandler(this.txtGroup_LostFocus);
            // 
            // txtStart
            // 
            this.txtStart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtStart.Enabled = false;
            this.txtStart.Location = new System.Drawing.Point(173, 66);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(67, 21);
            this.txtStart.TabIndex = 14;
            this.txtStart.TextChanged += new System.EventHandler(this.txtStart_TextChanged);
            this.txtStart.GotFocus += new System.EventHandler(this.txtStart_GotFocus);
            this.txtStart.LostFocus += new System.EventHandler(this.txtStart_LostFocus);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(117, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.Text = "StartAt:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Group Size:";
            // 
            // txtRange
            // 
            this.txtRange.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtRange.Enabled = false;
            this.txtRange.Location = new System.Drawing.Point(173, 44);
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(67, 21);
            this.txtRange.TabIndex = 12;
            this.txtRange.TextChanged += new System.EventHandler(this.txtRange_TextChanged);
            this.txtRange.GotFocus += new System.EventHandler(this.txtRange_GotFocus);
            this.txtRange.LostFocus += new System.EventHandler(this.txtRange_LostFocus);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(122, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.Text = "Range:";
            // 
            // chkCustom
            // 
            this.chkCustom.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkCustom.Location = new System.Drawing.Point(0, 44);
            this.chkCustom.Name = "chkCustom";
            this.chkCustom.Size = new System.Drawing.Size(104, 20);
            this.chkCustom.TabIndex = 11;
            this.chkCustom.Text = "Customize";
            this.chkCustom.CheckStateChanged += new System.EventHandler(this.chkCustom_CheckStateChanged);
            // 
            // btnFixType
            // 
            this.btnFixType.Location = new System.Drawing.Point(173, 20);
            this.btnFixType.Name = "btnFixType";
            this.btnFixType.Size = new System.Drawing.Size(67, 22);
            this.btnFixType.TabIndex = 5;
            this.btnFixType.Text = "3D+DIFF";
            this.btnFixType.Click += new System.EventHandler(this.btnFixType_Click);
            // 
            // btnDOP
            // 
            this.btnDOP.Location = new System.Drawing.Point(3, 20);
            this.btnDOP.Name = "btnDOP";
            this.btnDOP.Size = new System.Drawing.Size(67, 22);
            this.btnDOP.TabIndex = 4;
            this.btnDOP.Text = "PDOP";
            this.btnDOP.Click += new System.EventHandler(this.btnDOP_Click);
            // 
            // txtDOP
            // 
            this.txtDOP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDOP.Location = new System.Drawing.Point(74, 20);
            this.txtDOP.Name = "txtDOP";
            this.txtDOP.Size = new System.Drawing.Size(27, 21);
            this.txtDOP.TabIndex = 3;
            this.txtDOP.TextChanged += new System.EventHandler(this.txtDOP_TextChanged);
            this.txtDOP.GotFocus += new System.EventHandler(this.txtDOP_GotFocus);
            this.txtDOP.LostFocus += new System.EventHandler(this.txtDOP_LostFocus);
            // 
            // cboDOP
            // 
            this.cboDOP.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cboDOP.Items.Add("PDOP");
            this.cboDOP.Items.Add("HDOP");
            this.cboDOP.Location = new System.Drawing.Point(3, 20);
            this.cboDOP.Name = "cboDOP";
            this.cboDOP.Size = new System.Drawing.Size(67, 22);
            this.cboDOP.TabIndex = 2;
            this.cboDOP.SelectedIndexChanged += new System.EventHandler(this.cboDOP_SelectedIndexChanged);
            // 
            // cboFixType
            // 
            this.cboFixType.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cboFixType.Items.Add("Any");
            this.cboFixType.Items.Add("3D");
            this.cboFixType.Items.Add("3D+DIFF");
            this.cboFixType.Location = new System.Drawing.Point(173, 20);
            this.cboFixType.Name = "cboFixType";
            this.cboFixType.Size = new System.Drawing.Size(67, 22);
            this.cboFixType.TabIndex = 2;
            this.cboFixType.SelectedIndexChanged += new System.EventHandler(this.cboFixType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(107, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.Text = "Fix Type:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 20);
            this.label1.Text = "----- Filters -----";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.lblNssda3);
            this.panel2.Controls.Add(this.lblNssda2);
            this.panel2.Controls.Add(this.lblNssda1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblutmY3);
            this.panel2.Controls.Add(this.lblutmX3);
            this.panel2.Controls.Add(this.lblutmY1);
            this.panel2.Controls.Add(this.lblutmX1);
            this.panel2.Controls.Add(this.lblutmY2);
            this.panel2.Controls.Add(this.lblutmX2);
            this.panel2.Controls.Add(this.chk3);
            this.panel2.Controls.Add(this.chk2);
            this.panel2.Controls.Add(this.chk1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 80);
            // 
            // chk1
            // 
            this.chk1.Enabled = false;
            this.chk1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chk1.Location = new System.Drawing.Point(3, 20);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(55, 20);
            this.chk1.TabIndex = 0;
            this.chk1.Text = "1st";
            this.chk1.CheckStateChanged += new System.EventHandler(this.chk1_CheckStateChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(24, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 20);
            this.label13.Text = "1st";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(126, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.Text = "UTM Y";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(166, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.Text = "NSSDA %";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(24, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 20);
            this.label15.Text = "3rd";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(24, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 20);
            this.label14.Text = "2nd";
            // 
            // lblNssda3
            // 
            this.lblNssda3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblNssda3.Location = new System.Drawing.Point(204, 61);
            this.lblNssda3.Name = "lblNssda3";
            this.lblNssda3.Size = new System.Drawing.Size(36, 20);
            this.lblNssda3.Text = "0.00";
            // 
            // lblNssda2
            // 
            this.lblNssda2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblNssda2.Location = new System.Drawing.Point(204, 42);
            this.lblNssda2.Name = "lblNssda2";
            this.lblNssda2.Size = new System.Drawing.Size(36, 20);
            this.lblNssda2.Text = "0.00";
            // 
            // lblNssda1
            // 
            this.lblNssda1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblNssda1.Location = new System.Drawing.Point(204, 23);
            this.lblNssda1.Name = "lblNssda1";
            this.lblNssda1.Size = new System.Drawing.Size(36, 20);
            this.lblNssda1.Text = "0.00";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(62, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.Text = "UTM X";
            // 
            // lblutmY3
            // 
            this.lblutmY3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblutmY3.Location = new System.Drawing.Point(127, 61);
            this.lblutmY3.Name = "lblutmY3";
            this.lblutmY3.Size = new System.Drawing.Size(70, 20);
            this.lblutmY3.Text = "0000000.00";
            // 
            // lblutmX3
            // 
            this.lblutmX3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblutmX3.Location = new System.Drawing.Point(62, 61);
            this.lblutmX3.Name = "lblutmX3";
            this.lblutmX3.Size = new System.Drawing.Size(70, 20);
            this.lblutmX3.Text = "000000.00";
            // 
            // lblutmY1
            // 
            this.lblutmY1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblutmY1.Location = new System.Drawing.Point(127, 23);
            this.lblutmY1.Name = "lblutmY1";
            this.lblutmY1.Size = new System.Drawing.Size(70, 20);
            this.lblutmY1.Text = "0000000.00";
            // 
            // lblutmX1
            // 
            this.lblutmX1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblutmX1.Location = new System.Drawing.Point(62, 23);
            this.lblutmX1.Name = "lblutmX1";
            this.lblutmX1.Size = new System.Drawing.Size(70, 20);
            this.lblutmX1.Text = "000000.00";
            // 
            // lblutmY2
            // 
            this.lblutmY2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblutmY2.Location = new System.Drawing.Point(127, 42);
            this.lblutmY2.Name = "lblutmY2";
            this.lblutmY2.Size = new System.Drawing.Size(70, 20);
            this.lblutmY2.Text = "0000000.00";
            // 
            // lblutmX2
            // 
            this.lblutmX2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblutmX2.Location = new System.Drawing.Point(62, 42);
            this.lblutmX2.Name = "lblutmX2";
            this.lblutmX2.Size = new System.Drawing.Size(70, 20);
            this.lblutmX2.Text = "000000.00";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(4, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.Text = "Group";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chk3
            // 
            this.chk3.Enabled = false;
            this.chk3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chk3.Location = new System.Drawing.Point(3, 58);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(55, 20);
            this.chk3.TabIndex = 2;
            this.chk3.Text = "3rd";
            this.chk3.CheckStateChanged += new System.EventHandler(this.chk3_CheckStateChanged);
            // 
            // chk2
            // 
            this.chk2.Enabled = false;
            this.chk2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chk2.Location = new System.Drawing.Point(3, 39);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(55, 20);
            this.chk2.TabIndex = 1;
            this.chk2.Text = "2nd";
            this.chk2.CheckStateChanged += new System.EventHandler(this.chk2_CheckStateChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.lblUtmX);
            this.panel3.Controls.Add(this.lblNssda);
            this.panel3.Controls.Add(this.lblUtmY);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(0, 177);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 37);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(164, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 20);
            this.label12.Text = "NSSDA %";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUtmX
            // 
            this.lblUtmX.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblUtmX.Location = new System.Drawing.Point(4, 21);
            this.lblUtmX.Name = "lblUtmX";
            this.lblUtmX.Size = new System.Drawing.Size(80, 20);
            this.lblUtmX.Text = "000000.00";
            this.lblUtmX.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNssda
            // 
            this.lblNssda.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblNssda.Location = new System.Drawing.Point(166, 19);
            this.lblNssda.Name = "lblNssda";
            this.lblNssda.Size = new System.Drawing.Size(75, 20);
            this.lblNssda.Text = "0.00";
            this.lblNssda.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUtmY
            // 
            this.lblUtmY.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblUtmY.Location = new System.Drawing.Point(90, 21);
            this.lblUtmY.Name = "lblUtmY";
            this.lblUtmY.Size = new System.Drawing.Size(80, 20);
            this.lblUtmY.Text = "000000.00";
            this.lblUtmY.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(90, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 20);
            this.label11.Text = "UTM Y";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(3, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.Text = "UTM X";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.Controls.Add(this.lblBurstInfo);
            this.panel1.Location = new System.Drawing.Point(247, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(71, 56);
            // 
            // lblBurstInfo
            // 
            this.lblBurstInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBurstInfo.Location = new System.Drawing.Point(-3, 0);
            this.lblBurstInfo.Name = "lblBurstInfo";
            this.lblBurstInfo.Size = new System.Drawing.Size(70, 48);
            this.lblBurstInfo.Text = "0 of 0\r\nBursts used.";
            this.lblBurstInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CalcGpsPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.btnOk);
            this.ControlBox = false;
            this.Name = "CalcGpsPointForm";
            this.Text = "Calculate Gps Point";
            this.pnlFilter.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFixType;
        private System.Windows.Forms.TextBox txtDOP;
        private System.Windows.Forms.ComboBox cboDOP;
        private System.Windows.Forms.Button btnFixType;
        private System.Windows.Forms.Button btnDOP;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chk3;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.CheckBox chk1;
        private System.Windows.Forms.Label lblutmY3;
        private System.Windows.Forms.Label lblutmX3;
        private System.Windows.Forms.Label lblutmY1;
        private System.Windows.Forms.Label lblutmX1;
        private System.Windows.Forms.Label lblutmY2;
        private System.Windows.Forms.Label lblutmX2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNssda3;
        private System.Windows.Forms.Label lblNssda2;
        private System.Windows.Forms.Label lblNssda1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblUtmY;
        private System.Windows.Forms.Label lblUtmX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblNssda;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkCustom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBurstInfo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}