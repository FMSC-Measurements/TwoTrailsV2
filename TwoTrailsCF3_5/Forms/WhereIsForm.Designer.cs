namespace TwoTrails.Forms
{
    partial class WhereIsForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnNav = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radFromUTM = new System.Windows.Forms.RadioButton();
            this.radFromPoint = new System.Windows.Forms.RadioButton();
            this.btnFromPoint = new System.Windows.Forms.Button();
            this.btnFromPoly = new System.Windows.Forms.Button();
            this.cboFromPoint = new System.Windows.Forms.ComboBox();
            this.cboFromPoly = new System.Windows.Forms.ComboBox();
            this.txtFromY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFromX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radMyLoc = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.txtAzTrue = new System.Windows.Forms.TextBox();
            this.txtAzMag = new System.Windows.Forms.TextBox();
            this.btnMeta = new System.Windows.Forms.Button();
            this.cboMeta = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radToUTM = new System.Windows.Forms.RadioButton();
            this.btnToPoint = new System.Windows.Forms.Button();
            this.btnToPoly = new System.Windows.Forms.Button();
            this.cboToPoint = new System.Windows.Forms.ComboBox();
            this.cboToPoly = new System.Windows.Forms.ComboBox();
            this.txtToY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radToPoint = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(3, 266);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 25);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalc.Location = new System.Drawing.Point(167, 266);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(70, 25);
            this.btnCalc.TabIndex = 0;
            this.btnCalc.TabStop = false;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnNav
            // 
            this.btnNav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNav.Location = new System.Drawing.Point(79, 266);
            this.btnNav.Name = "btnNav";
            this.btnNav.Size = new System.Drawing.Size(82, 25);
            this.btnNav.TabIndex = 0;
            this.btnNav.TabStop = false;
            this.btnNav.Text = "Navigate";
            this.btnNav.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.Controls.Add(this.radFromUTM);
            this.panel1.Controls.Add(this.radFromPoint);
            this.panel1.Controls.Add(this.btnFromPoint);
            this.panel1.Controls.Add(this.btnFromPoly);
            this.panel1.Controls.Add(this.cboFromPoint);
            this.panel1.Controls.Add(this.cboFromPoly);
            this.panel1.Controls.Add(this.txtFromY);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtFromX);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.radMyLoc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 100);
            // 
            // radFromUTM
            // 
            this.radFromUTM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radFromUTM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radFromUTM.Location = new System.Drawing.Point(123, 23);
            this.radFromUTM.Name = "radFromUTM";
            this.radFromUTM.Size = new System.Drawing.Size(51, 20);
            this.radFromUTM.TabIndex = 14;
            this.radFromUTM.TabStop = false;
            this.radFromUTM.Text = "UTM";
            this.radFromUTM.CheckedChanged += new System.EventHandler(this.radFromUTM_CheckedChanged);
            // 
            // radFromPoint
            // 
            this.radFromPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radFromPoint.Checked = true;
            this.radFromPoint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radFromPoint.Location = new System.Drawing.Point(177, 23);
            this.radFromPoint.Name = "radFromPoint";
            this.radFromPoint.Size = new System.Drawing.Size(61, 20);
            this.radFromPoint.TabIndex = 1;
            this.radFromPoint.Text = "Point";
            this.radFromPoint.CheckedChanged += new System.EventHandler(this.radFromPoint_CheckedChanged);
            // 
            // btnFromPoint
            // 
            this.btnFromPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromPoint.Location = new System.Drawing.Point(134, 69);
            this.btnFromPoint.Name = "btnFromPoint";
            this.btnFromPoint.Size = new System.Drawing.Size(100, 22);
            this.btnFromPoint.TabIndex = 10;
            this.btnFromPoint.TabStop = false;
            this.btnFromPoint.Text = "Point";
            this.btnFromPoint.Click += new System.EventHandler(this.btnFromPoint_Click);
            // 
            // btnFromPoly
            // 
            this.btnFromPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromPoly.Location = new System.Drawing.Point(134, 45);
            this.btnFromPoly.Name = "btnFromPoly";
            this.btnFromPoly.Size = new System.Drawing.Size(100, 22);
            this.btnFromPoly.TabIndex = 10;
            this.btnFromPoly.TabStop = false;
            this.btnFromPoly.Text = "Poly";
            this.btnFromPoly.Click += new System.EventHandler(this.btnFromPoly_Click);
            // 
            // cboFromPoint
            // 
            this.cboFromPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFromPoint.Location = new System.Drawing.Point(134, 69);
            this.cboFromPoint.Name = "cboFromPoint";
            this.cboFromPoint.Size = new System.Drawing.Size(100, 22);
            this.cboFromPoint.TabIndex = 6;
            this.cboFromPoint.TabStop = false;
            this.cboFromPoint.SelectedIndexChanged += new System.EventHandler(this.cboFromPoint_SelectedIndexChanged);
            // 
            // cboFromPoly
            // 
            this.cboFromPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFromPoly.Location = new System.Drawing.Point(134, 45);
            this.cboFromPoly.Name = "cboFromPoly";
            this.cboFromPoly.Size = new System.Drawing.Size(100, 22);
            this.cboFromPoly.TabIndex = 6;
            this.cboFromPoly.TabStop = false;
            this.cboFromPoly.SelectedIndexChanged += new System.EventHandler(this.cboFromPoly_SelectedIndexChanged);
            // 
            // txtFromY
            // 
            this.txtFromY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromY.Location = new System.Drawing.Point(21, 70);
            this.txtFromY.Name = "txtFromY";
            this.txtFromY.Size = new System.Drawing.Size(107, 21);
            this.txtFromY.TabIndex = 4;
            this.txtFromY.TabStop = false;
            this.txtFromY.TextChanged += new System.EventHandler(this.txtFromY_TextChanged);
            this.txtFromY.GotFocus += new System.EventHandler(this.txtFromY_GotFocus);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(4, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.Text = "Y:";
            // 
            // txtFromX
            // 
            this.txtFromX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromX.Location = new System.Drawing.Point(21, 44);
            this.txtFromX.Name = "txtFromX";
            this.txtFromX.Size = new System.Drawing.Size(107, 21);
            this.txtFromX.TabIndex = 4;
            this.txtFromX.TabStop = false;
            this.txtFromX.TextChanged += new System.EventHandler(this.txtFromX_TextChanged);
            this.txtFromX.GotFocus += new System.EventHandler(this.txtFromX_GotFocus);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(4, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 20);
            this.label3.Text = "X:";
            // 
            // radMyLoc
            // 
            this.radMyLoc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radMyLoc.Location = new System.Drawing.Point(21, 24);
            this.radMyLoc.Name = "radMyLoc";
            this.radMyLoc.Size = new System.Drawing.Size(100, 20);
            this.radMyLoc.TabIndex = 1;
            this.radMyLoc.TabStop = false;
            this.radMyLoc.Text = "My Location";
            this.radMyLoc.CheckedChanged += new System.EventHandler(this.radMyLoc_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.Text = "From";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel3.Controls.Add(this.txtDistance);
            this.panel3.Controls.Add(this.txtAzTrue);
            this.panel3.Controls.Add(this.txtAzMag);
            this.panel3.Controls.Add(this.btnMeta);
            this.panel3.Controls.Add(this.cboMeta);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(0, 210);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 52);
            // 
            // txtDistance
            // 
            this.txtDistance.Enabled = false;
            this.txtDistance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtDistance.Location = new System.Drawing.Point(61, 29);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(70, 19);
            this.txtDistance.TabIndex = 4;
            this.txtDistance.TabStop = false;
            // 
            // txtAzTrue
            // 
            this.txtAzTrue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAzTrue.Enabled = false;
            this.txtAzTrue.Location = new System.Drawing.Point(137, 28);
            this.txtAzTrue.Name = "txtAzTrue";
            this.txtAzTrue.Size = new System.Drawing.Size(47, 21);
            this.txtAzTrue.TabIndex = 4;
            this.txtAzTrue.TabStop = false;
            // 
            // txtAzMag
            // 
            this.txtAzMag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAzMag.Enabled = false;
            this.txtAzMag.Location = new System.Drawing.Point(190, 28);
            this.txtAzMag.Name = "txtAzMag";
            this.txtAzMag.Size = new System.Drawing.Size(47, 21);
            this.txtAzMag.TabIndex = 4;
            this.txtAzMag.TabStop = false;
            // 
            // btnMeta
            // 
            this.btnMeta.Location = new System.Drawing.Point(4, 3);
            this.btnMeta.Name = "btnMeta";
            this.btnMeta.Size = new System.Drawing.Size(78, 22);
            this.btnMeta.TabIndex = 2;
            this.btnMeta.TabStop = false;
            this.btnMeta.Text = "MetaData";
            this.btnMeta.Click += new System.EventHandler(this.btnMeta_Click);
            // 
            // cboMeta
            // 
            this.cboMeta.Location = new System.Drawing.Point(4, 3);
            this.cboMeta.Name = "cboMeta";
            this.cboMeta.Size = new System.Drawing.Size(78, 22);
            this.cboMeta.TabIndex = 0;
            this.cboMeta.TabStop = false;
            this.cboMeta.SelectedIndexChanged += new System.EventHandler(this.cboMeta_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(79, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.Text = "Azimuth:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(-5, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 20);
            this.label10.Text = "Distance:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(134, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.Text = "True";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(187, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 20);
            this.label9.Text = "Mag";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.Controls.Add(this.radToUTM);
            this.panel2.Controls.Add(this.btnToPoint);
            this.panel2.Controls.Add(this.btnToPoly);
            this.panel2.Controls.Add(this.cboToPoint);
            this.panel2.Controls.Add(this.cboToPoly);
            this.panel2.Controls.Add(this.txtToY);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtToX);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.radToPoint);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 100);
            // 
            // radToUTM
            // 
            this.radToUTM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radToUTM.Location = new System.Drawing.Point(21, 23);
            this.radToUTM.Name = "radToUTM";
            this.radToUTM.Size = new System.Drawing.Size(100, 20);
            this.radToUTM.TabIndex = 14;
            this.radToUTM.TabStop = false;
            this.radToUTM.Text = "UTM";
            this.radToUTM.CheckedChanged += new System.EventHandler(this.radToUTM_CheckedChanged);
            // 
            // btnToPoint
            // 
            this.btnToPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToPoint.Location = new System.Drawing.Point(134, 70);
            this.btnToPoint.Name = "btnToPoint";
            this.btnToPoint.Size = new System.Drawing.Size(100, 22);
            this.btnToPoint.TabIndex = 10;
            this.btnToPoint.TabStop = false;
            this.btnToPoint.Text = "Point";
            this.btnToPoint.Click += new System.EventHandler(this.btnToPoint_Click);
            // 
            // btnToPoly
            // 
            this.btnToPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToPoly.Location = new System.Drawing.Point(134, 46);
            this.btnToPoly.Name = "btnToPoly";
            this.btnToPoly.Size = new System.Drawing.Size(100, 22);
            this.btnToPoly.TabIndex = 10;
            this.btnToPoly.TabStop = false;
            this.btnToPoly.Text = "Poly";
            this.btnToPoly.Click += new System.EventHandler(this.btnToPoly_Click);
            // 
            // cboToPoint
            // 
            this.cboToPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboToPoint.Location = new System.Drawing.Point(134, 70);
            this.cboToPoint.Name = "cboToPoint";
            this.cboToPoint.Size = new System.Drawing.Size(100, 22);
            this.cboToPoint.TabIndex = 6;
            this.cboToPoint.TabStop = false;
            this.cboToPoint.SelectedIndexChanged += new System.EventHandler(this.cboToPoint_SelectedIndexChanged);
            // 
            // cboToPoly
            // 
            this.cboToPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboToPoly.Location = new System.Drawing.Point(134, 46);
            this.cboToPoly.Name = "cboToPoly";
            this.cboToPoly.Size = new System.Drawing.Size(100, 22);
            this.cboToPoly.TabIndex = 6;
            this.cboToPoly.TabStop = false;
            this.cboToPoly.SelectedIndexChanged += new System.EventHandler(this.cboToPoly_SelectedIndexChanged);
            // 
            // txtToY
            // 
            this.txtToY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToY.Location = new System.Drawing.Point(21, 71);
            this.txtToY.Name = "txtToY";
            this.txtToY.Size = new System.Drawing.Size(107, 21);
            this.txtToY.TabIndex = 4;
            this.txtToY.TabStop = false;
            this.txtToY.TextChanged += new System.EventHandler(this.txtToY_TextChanged);
            this.txtToY.GotFocus += new System.EventHandler(this.txtToY_GotFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(4, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 20);
            this.label2.Text = "Y:";
            // 
            // txtToX
            // 
            this.txtToX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToX.Location = new System.Drawing.Point(21, 45);
            this.txtToX.Name = "txtToX";
            this.txtToX.Size = new System.Drawing.Size(107, 21);
            this.txtToX.TabIndex = 4;
            this.txtToX.TabStop = false;
            this.txtToX.TextChanged += new System.EventHandler(this.txtToX_TextChanged);
            this.txtToX.GotFocus += new System.EventHandler(this.txtToX_GotFocus);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(4, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 20);
            this.label5.Text = "X:";
            // 
            // radToPoint
            // 
            this.radToPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radToPoint.Checked = true;
            this.radToPoint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radToPoint.Location = new System.Drawing.Point(134, 23);
            this.radToPoint.Name = "radToPoint";
            this.radToPoint.Size = new System.Drawing.Size(67, 20);
            this.radToPoint.TabIndex = 15;
            this.radToPoint.Text = "Point";
            this.radToPoint.CheckedChanged += new System.EventHandler(this.radToPoint_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 20);
            this.label6.Text = "To";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WhereIsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnNav);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Name = "WhereIsForm";
            this.Text = "Where Is";
            this.Load += new System.EventHandler(this.WhereIsForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.WhereIsForm_Closing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        private void InitializeComponentWide()
        {
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnNav = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radFromUTM = new System.Windows.Forms.RadioButton();
            this.radFromPoint = new System.Windows.Forms.RadioButton();
            this.btnFromPoint = new System.Windows.Forms.Button();
            this.btnFromPoly = new System.Windows.Forms.Button();
            this.cboFromPoint = new System.Windows.Forms.ComboBox();
            this.cboFromPoly = new System.Windows.Forms.ComboBox();
            this.txtFromY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFromX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radMyLoc = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.txtAzTrue = new System.Windows.Forms.TextBox();
            this.txtAzMag = new System.Windows.Forms.TextBox();
            this.btnMeta = new System.Windows.Forms.Button();
            this.cboMeta = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radToUTM = new System.Windows.Forms.RadioButton();
            this.btnToPoint = new System.Windows.Forms.Button();
            this.btnToPoly = new System.Windows.Forms.Button();
            this.cboToPoint = new System.Windows.Forms.ComboBox();
            this.cboToPoly = new System.Windows.Forms.ComboBox();
            this.txtToY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radToPoint = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalc.Location = new System.Drawing.Point(247, 186);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(70, 25);
            this.btnCalc.TabIndex = 0;
            this.btnCalc.TabStop = false;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnNav
            // 
            this.btnNav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNav.Location = new System.Drawing.Point(79, 186);
            this.btnNav.Name = "btnNav";
            this.btnNav.Size = new System.Drawing.Size(162, 25);
            this.btnNav.TabIndex = 0;
            this.btnNav.TabStop = false;
            this.btnNav.Text = "Navigate";
            this.btnNav.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.Controls.Add(this.radFromPoint);
            this.panel1.Controls.Add(this.radFromUTM);
            this.panel1.Controls.Add(this.btnFromPoint);
            this.panel1.Controls.Add(this.btnFromPoly);
            this.panel1.Controls.Add(this.cboFromPoint);
            this.panel1.Controls.Add(this.cboFromPoly);
            this.panel1.Controls.Add(this.txtFromY);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtFromX);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.radMyLoc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 95);
            // 
            // radFromUTM
            // 
            this.radFromUTM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radFromUTM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radFromUTM.Location = new System.Drawing.Point(124, 24);
            this.radFromUTM.Name = "radFromUTM";
            this.radFromUTM.Size = new System.Drawing.Size(71, 20);
            this.radFromUTM.TabIndex = 14;
            this.radFromUTM.TabStop = false;
            this.radFromUTM.Text = "UTM";
            this.radFromUTM.CheckedChanged += new System.EventHandler(this.radFromUTM_CheckedChanged);
            // 
            // radFromPoint
            // 
            this.radFromPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radFromPoint.Checked = true;
            this.radFromPoint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radFromPoint.Location = new System.Drawing.Point(175, 24);
            this.radFromPoint.Name = "radFromPoint";
            this.radFromPoint.Size = new System.Drawing.Size(61, 20);
            this.radFromPoint.TabIndex = 1;
            this.radFromPoint.Text = "Point";
            this.radFromPoint.CheckedChanged += new System.EventHandler(this.radFromPoint_CheckedChanged);
            // 
            // btnFromPoint
            // 
            this.btnFromPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromPoint.Location = new System.Drawing.Point(136, 69);
            this.btnFromPoint.Name = "btnFromPoint";
            this.btnFromPoint.Size = new System.Drawing.Size(100, 22);
            this.btnFromPoint.TabIndex = 10;
            this.btnFromPoint.TabStop = false;
            this.btnFromPoint.Text = "Point";
            this.btnFromPoint.Click += new System.EventHandler(this.btnFromPoint_Click);
            // 
            // btnFromPoly
            // 
            this.btnFromPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromPoly.Location = new System.Drawing.Point(136, 45);
            this.btnFromPoly.Name = "btnFromPoly";
            this.btnFromPoly.Size = new System.Drawing.Size(100, 22);
            this.btnFromPoly.TabIndex = 10;
            this.btnFromPoly.TabStop = false;
            this.btnFromPoly.Text = "Poly";
            this.btnFromPoly.Click += new System.EventHandler(this.btnFromPoly_Click);
            // 
            // cboFromPoint
            // 
            this.cboFromPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFromPoint.Location = new System.Drawing.Point(136, 69);
            this.cboFromPoint.Name = "cboFromPoint";
            this.cboFromPoint.Size = new System.Drawing.Size(100, 22);
            this.cboFromPoint.TabIndex = 6;
            this.cboFromPoint.TabStop = false;
            this.cboFromPoint.SelectedIndexChanged += new System.EventHandler(this.cboFromPoint_SelectedIndexChanged);
            // 
            // cboFromPoly
            // 
            this.cboFromPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFromPoly.Location = new System.Drawing.Point(136, 45);
            this.cboFromPoly.Name = "cboFromPoly";
            this.cboFromPoly.Size = new System.Drawing.Size(100, 22);
            this.cboFromPoly.TabIndex = 6;
            this.cboFromPoly.TabStop = false;
            this.cboFromPoly.SelectedIndexChanged += new System.EventHandler(this.cboFromPoly_SelectedIndexChanged);
            // 
            // txtFromY
            // 
            this.txtFromY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromY.Location = new System.Drawing.Point(21, 70);
            this.txtFromY.Name = "txtFromY";
            this.txtFromY.Size = new System.Drawing.Size(110, 21);
            this.txtFromY.TabIndex = 4;
            this.txtFromY.TabStop = false;
            this.txtFromY.TextChanged += new System.EventHandler(this.txtFromY_TextChanged);
            this.txtFromY.GotFocus += new System.EventHandler(this.txtFromY_GotFocus);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(4, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.Text = "Y:";
            // 
            // txtFromX
            // 
            this.txtFromX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromX.Location = new System.Drawing.Point(21, 44);
            this.txtFromX.Name = "txtFromX";
            this.txtFromX.Size = new System.Drawing.Size(110, 21);
            this.txtFromX.TabIndex = 4;
            this.txtFromX.TabStop = false;
            this.txtFromX.TextChanged += new System.EventHandler(this.txtFromX_TextChanged);
            this.txtFromX.GotFocus += new System.EventHandler(this.txtFromX_GotFocus);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(4, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 20);
            this.label3.Text = "X:";
            // 
            // radMyLoc
            // 
            this.radMyLoc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radMyLoc.Location = new System.Drawing.Point(21, 24);
            this.radMyLoc.Name = "radMyLoc";
            this.radMyLoc.Size = new System.Drawing.Size(100, 20);
            this.radMyLoc.TabIndex = 1;
            this.radMyLoc.TabStop = false;
            this.radMyLoc.Text = "My Location";
            this.radMyLoc.CheckedChanged += new System.EventHandler(this.radMyLoc_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.Text = "From";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel3.Controls.Add(this.txtDistance);
            this.panel3.Controls.Add(this.txtAzTrue);
            this.panel3.Controls.Add(this.txtAzMag);
            this.panel3.Controls.Add(this.btnMeta);
            this.panel3.Controls.Add(this.cboMeta);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(243, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(77, 183);
            // 
            // txtDistance
            // 
            this.txtDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDistance.Enabled = false;
            this.txtDistance.Location = new System.Drawing.Point(4, 158);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(70, 21);
            this.txtDistance.TabIndex = 4;
            this.txtDistance.TabStop = false;
            // 
            // txtAzTrue
            // 
            this.txtAzTrue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAzTrue.Enabled = false;
            this.txtAzTrue.Location = new System.Drawing.Point(4, 110);
            this.txtAzTrue.Name = "txtAzTrue";
            this.txtAzTrue.Size = new System.Drawing.Size(70, 21);
            this.txtAzTrue.TabIndex = 4;
            this.txtAzTrue.TabStop = false;
            // 
            // txtAzMag
            // 
            this.txtAzMag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAzMag.Enabled = false;
            this.txtAzMag.Location = new System.Drawing.Point(4, 70);
            this.txtAzMag.Name = "txtAzMag";
            this.txtAzMag.Size = new System.Drawing.Size(70, 21);
            this.txtAzMag.TabIndex = 4;
            this.txtAzMag.TabStop = false;
            // 
            // btnMeta
            // 
            this.btnMeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMeta.Location = new System.Drawing.Point(4, 7);
            this.btnMeta.Name = "btnMeta";
            this.btnMeta.Size = new System.Drawing.Size(70, 22);
            this.btnMeta.TabIndex = 2;
            this.btnMeta.TabStop = false;
            this.btnMeta.Text = "Meta";
            this.btnMeta.Click += new System.EventHandler(this.btnMeta_Click);
            // 
            // cboMeta
            // 
            this.cboMeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMeta.Location = new System.Drawing.Point(4, 7);
            this.cboMeta.Name = "cboMeta";
            this.cboMeta.Size = new System.Drawing.Size(70, 22);
            this.cboMeta.TabIndex = 0;
            this.cboMeta.TabStop = false;
            this.cboMeta.SelectedIndexChanged += new System.EventHandler(this.cboMeta_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(3, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.Text = "Azimuth";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(0, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 20);
            this.label10.Text = "Distance";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(4, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.Text = "True";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(4, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.Text = "Mag";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.Controls.Add(this.radToUTM);
            this.panel2.Controls.Add(this.btnToPoint);
            this.panel2.Controls.Add(this.btnToPoly);
            this.panel2.Controls.Add(this.cboToPoint);
            this.panel2.Controls.Add(this.cboToPoly);
            this.panel2.Controls.Add(this.txtToY);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtToX);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.radToPoint);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 86);
            // 
            // radToUTM
            // 
            this.radToUTM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radToUTM.Location = new System.Drawing.Point(21, 15);
            this.radToUTM.Name = "radToUTM";
            this.radToUTM.Size = new System.Drawing.Size(100, 20);
            this.radToUTM.TabIndex = 14;
            this.radToUTM.TabStop = false;
            this.radToUTM.Text = "UTM";
            this.radToUTM.CheckedChanged += new System.EventHandler(this.radToUTM_CheckedChanged);
            // 
            // btnToPoint
            // 
            this.btnToPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToPoint.Location = new System.Drawing.Point(136, 60);
            this.btnToPoint.Name = "btnToPoint";
            this.btnToPoint.Size = new System.Drawing.Size(100, 22);
            this.btnToPoint.TabIndex = 10;
            this.btnToPoint.TabStop = false;
            this.btnToPoint.Text = "Point";
            this.btnToPoint.Click += new System.EventHandler(this.btnToPoint_Click);
            // 
            // btnToPoly
            // 
            this.btnToPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToPoly.Location = new System.Drawing.Point(136, 36);
            this.btnToPoly.Name = "btnToPoly";
            this.btnToPoly.Size = new System.Drawing.Size(100, 22);
            this.btnToPoly.TabIndex = 10;
            this.btnToPoly.TabStop = false;
            this.btnToPoly.Text = "Poly";
            this.btnToPoly.Click += new System.EventHandler(this.btnToPoly_Click);
            // 
            // cboToPoint
            // 
            this.cboToPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboToPoint.Location = new System.Drawing.Point(136, 60);
            this.cboToPoint.Name = "cboToPoint";
            this.cboToPoint.Size = new System.Drawing.Size(100, 22);
            this.cboToPoint.TabIndex = 6;
            this.cboToPoint.TabStop = false;
            this.cboToPoint.SelectedIndexChanged += new System.EventHandler(this.cboToPoint_SelectedIndexChanged);
            // 
            // cboToPoly
            // 
            this.cboToPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboToPoly.Location = new System.Drawing.Point(136, 36);
            this.cboToPoly.Name = "cboToPoly";
            this.cboToPoly.Size = new System.Drawing.Size(100, 22);
            this.cboToPoly.TabIndex = 6;
            this.cboToPoly.TabStop = false;
            this.cboToPoly.SelectedIndexChanged += new System.EventHandler(this.cboToPoly_SelectedIndexChanged);
            // 
            // txtToY
            // 
            this.txtToY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToY.Location = new System.Drawing.Point(21, 61);
            this.txtToY.Name = "txtToY";
            this.txtToY.Size = new System.Drawing.Size(110, 21);
            this.txtToY.TabIndex = 4;
            this.txtToY.TabStop = false;
            this.txtToY.TextChanged += new System.EventHandler(this.txtToY_TextChanged);
            this.txtToY.GotFocus += new System.EventHandler(this.txtToY_GotFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(4, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 20);
            this.label2.Text = "Y:";
            // 
            // txtToX
            // 
            this.txtToX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToX.Location = new System.Drawing.Point(21, 35);
            this.txtToX.Name = "txtToX";
            this.txtToX.Size = new System.Drawing.Size(110, 21);
            this.txtToX.TabIndex = 4;
            this.txtToX.TabStop = false;
            this.txtToX.TextChanged += new System.EventHandler(this.txtToX_TextChanged);
            this.txtToX.GotFocus += new System.EventHandler(this.txtToX_GotFocus);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(4, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 20);
            this.label5.Text = "X:";
            // 
            // radToPoint
            // 
            this.radToPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radToPoint.Checked = true;
            this.radToPoint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radToPoint.Location = new System.Drawing.Point(136, 15);
            this.radToPoint.Name = "radToPoint";
            this.radToPoint.Size = new System.Drawing.Size(67, 20);
            this.radToPoint.TabIndex = 15;
            this.radToPoint.Text = "Point";
            this.radToPoint.CheckedChanged += new System.EventHandler(this.radToPoint_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(3, -3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 20);
            this.label6.Text = "To";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(3, 186);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 25);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // WhereIsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnNav);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Name = "WhereIsForm";
            this.Text = "Where Is";
            this.Load += new System.EventHandler(this.WhereIsForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.WhereIsForm_Closing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnNav;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radFromPoint;
        private System.Windows.Forms.RadioButton radMyLoc;
        private System.Windows.Forms.TextBox txtFromY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFromX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFromPoint;
        private System.Windows.Forms.ComboBox cboFromPoly;
        private System.Windows.Forms.Button btnFromPoint;
        private System.Windows.Forms.Button btnFromPoly;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnToPoint;
        private System.Windows.Forms.Button btnToPoly;
        private System.Windows.Forms.ComboBox cboToPoint;
        private System.Windows.Forms.ComboBox cboToPoly;
        private System.Windows.Forms.TextBox txtToY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtToX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radFromUTM;
        private System.Windows.Forms.RadioButton radToPoint;
        private System.Windows.Forms.RadioButton radToUTM;
        private System.Windows.Forms.ComboBox cboMeta;
        private System.Windows.Forms.Button btnMeta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAzTrue;
        private System.Windows.Forms.TextBox txtAzMag;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnExit;
    }
}