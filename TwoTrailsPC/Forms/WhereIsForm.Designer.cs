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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboFromPoint = new System.Windows.Forms.ComboBox();
            this.cboFromPoly = new System.Windows.Forms.ComboBox();
            this.txtFromY = new System.Windows.Forms.TextBox();
            this.txtFromX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radMyLoc = new System.Windows.Forms.RadioButton();
            this.radFromUTM = new System.Windows.Forms.RadioButton();
            this.radFromPoint = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboToPoint = new System.Windows.Forms.ComboBox();
            this.cboToPoly = new System.Windows.Forms.ComboBox();
            this.txtToY = new System.Windows.Forms.TextBox();
            this.txtToX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radToUTM = new System.Windows.Forms.RadioButton();
            this.radToPoint = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboMeta = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAzTrue = new System.Windows.Forms.TextBox();
            this.txtAzMag = new System.Windows.Forms.TextBox();
            this.txtDistance2 = new System.Windows.Forms.TextBox();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNav = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.cboFromPoint);
            this.panel1.Controls.Add(this.cboFromPoly);
            this.panel1.Controls.Add(this.txtFromY);
            this.panel1.Controls.Add(this.txtFromX);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radMyLoc);
            this.panel1.Controls.Add(this.radFromUTM);
            this.panel1.Controls.Add(this.radFromPoint);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 120);
            this.panel1.TabIndex = 0;
            // 
            // cboFromPoint
            // 
            this.cboFromPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFromPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFromPoint.FormattingEnabled = true;
            this.cboFromPoint.Location = new System.Drawing.Point(145, 89);
            this.cboFromPoint.Name = "cboFromPoint";
            this.cboFromPoint.Size = new System.Drawing.Size(121, 24);
            this.cboFromPoint.TabIndex = 4;
            this.cboFromPoint.TabStop = false;
            this.cboFromPoint.SelectedIndexChanged += new System.EventHandler(this.cboFromPoint_SelectedIndexChanged);
            // 
            // cboFromPoly
            // 
            this.cboFromPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFromPoly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFromPoly.FormattingEnabled = true;
            this.cboFromPoly.Location = new System.Drawing.Point(145, 59);
            this.cboFromPoly.Name = "cboFromPoly";
            this.cboFromPoly.Size = new System.Drawing.Size(121, 24);
            this.cboFromPoly.TabIndex = 4;
            this.cboFromPoly.TabStop = false;
            this.cboFromPoly.SelectedIndexChanged += new System.EventHandler(this.cboFromPoly_SelectedIndexChanged);
            // 
            // txtFromY
            // 
            this.txtFromY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromY.Location = new System.Drawing.Point(38, 89);
            this.txtFromY.Name = "txtFromY";
            this.txtFromY.Size = new System.Drawing.Size(101, 22);
            this.txtFromY.TabIndex = 3;
            this.txtFromY.TabStop = false;
            this.txtFromY.TextChanged += new System.EventHandler(this.txtFromY_TextChanged);
            // 
            // txtFromX
            // 
            this.txtFromX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromX.Location = new System.Drawing.Point(38, 59);
            this.txtFromX.Name = "txtFromX";
            this.txtFromX.Size = new System.Drawing.Size(101, 22);
            this.txtFromX.TabIndex = 3;
            this.txtFromX.TabStop = false;
            this.txtFromX.TextChanged += new System.EventHandler(this.txtFromX_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "X:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // radMyLoc
            // 
            this.radMyLoc.AutoSize = true;
            this.radMyLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMyLoc.Location = new System.Drawing.Point(156, 33);
            this.radMyLoc.Name = "radMyLoc";
            this.radMyLoc.Size = new System.Drawing.Size(109, 20);
            this.radMyLoc.TabIndex = 0;
            this.radMyLoc.Text = "My Location";
            this.radMyLoc.UseVisualStyleBackColor = true;
            this.radMyLoc.CheckedChanged += new System.EventHandler(this.radMyLoc_CheckedChanged);
            // 
            // radFromUTM
            // 
            this.radFromUTM.AutoSize = true;
            this.radFromUTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFromUTM.Location = new System.Drawing.Point(85, 33);
            this.radFromUTM.Name = "radFromUTM";
            this.radFromUTM.Size = new System.Drawing.Size(59, 20);
            this.radFromUTM.TabIndex = 0;
            this.radFromUTM.Text = "UTM";
            this.radFromUTM.UseVisualStyleBackColor = true;
            this.radFromUTM.CheckedChanged += new System.EventHandler(this.radFromUTM_CheckedChanged);
            // 
            // radFromPoint
            // 
            this.radFromPoint.AutoSize = true;
            this.radFromPoint.Checked = true;
            this.radFromPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFromPoint.Location = new System.Drawing.Point(15, 33);
            this.radFromPoint.Name = "radFromPoint";
            this.radFromPoint.Size = new System.Drawing.Size(61, 20);
            this.radFromPoint.TabIndex = 0;
            this.radFromPoint.TabStop = true;
            this.radFromPoint.Text = "Point";
            this.radFromPoint.UseVisualStyleBackColor = true;
            this.radFromPoint.CheckedChanged += new System.EventHandler(this.radFromPoint_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.cboToPoint);
            this.panel2.Controls.Add(this.cboToPoly);
            this.panel2.Controls.Add(this.txtToY);
            this.panel2.Controls.Add(this.txtToX);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.radToUTM);
            this.panel2.Controls.Add(this.radToPoint);
            this.panel2.Location = new System.Drawing.Point(0, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 120);
            this.panel2.TabIndex = 1;
            // 
            // cboToPoint
            // 
            this.cboToPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToPoint.FormattingEnabled = true;
            this.cboToPoint.Location = new System.Drawing.Point(145, 89);
            this.cboToPoint.Name = "cboToPoint";
            this.cboToPoint.Size = new System.Drawing.Size(121, 24);
            this.cboToPoint.TabIndex = 4;
            this.cboToPoint.TabStop = false;
            this.cboToPoint.SelectedIndexChanged += new System.EventHandler(this.cboToPoint_SelectedIndexChanged);
            // 
            // cboToPoly
            // 
            this.cboToPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToPoly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToPoly.FormattingEnabled = true;
            this.cboToPoly.Location = new System.Drawing.Point(145, 59);
            this.cboToPoly.Name = "cboToPoly";
            this.cboToPoly.Size = new System.Drawing.Size(121, 24);
            this.cboToPoly.TabIndex = 4;
            this.cboToPoly.TabStop = false;
            this.cboToPoly.SelectedIndexChanged += new System.EventHandler(this.cboToPoly_SelectedIndexChanged);
            // 
            // txtToY
            // 
            this.txtToY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToY.Location = new System.Drawing.Point(38, 89);
            this.txtToY.Name = "txtToY";
            this.txtToY.Size = new System.Drawing.Size(101, 22);
            this.txtToY.TabIndex = 3;
            this.txtToY.TabStop = false;
            this.txtToY.TextChanged += new System.EventHandler(this.txtToY_TextChanged);
            // 
            // txtToX
            // 
            this.txtToX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToX.Location = new System.Drawing.Point(38, 59);
            this.txtToX.Name = "txtToX";
            this.txtToX.Size = new System.Drawing.Size(101, 22);
            this.txtToX.TabIndex = 3;
            this.txtToX.TabStop = false;
            this.txtToX.TextChanged += new System.EventHandler(this.txtToX_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(117, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "To";
            // 
            // radToUTM
            // 
            this.radToUTM.AutoSize = true;
            this.radToUTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radToUTM.Location = new System.Drawing.Point(145, 33);
            this.radToUTM.Name = "radToUTM";
            this.radToUTM.Size = new System.Drawing.Size(59, 20);
            this.radToUTM.TabIndex = 0;
            this.radToUTM.Text = "UTM";
            this.radToUTM.UseVisualStyleBackColor = true;
            this.radToUTM.CheckedChanged += new System.EventHandler(this.radToUTM_CheckedChanged);
            // 
            // radToPoint
            // 
            this.radToPoint.AutoSize = true;
            this.radToPoint.Checked = true;
            this.radToPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radToPoint.Location = new System.Drawing.Point(38, 33);
            this.radToPoint.Name = "radToPoint";
            this.radToPoint.Size = new System.Drawing.Size(61, 20);
            this.radToPoint.TabIndex = 0;
            this.radToPoint.TabStop = true;
            this.radToPoint.Text = "Point";
            this.radToPoint.UseVisualStyleBackColor = true;
            this.radToPoint.CheckedChanged += new System.EventHandler(this.radToPoint_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.cboMeta);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtAzTrue);
            this.panel3.Controls.Add(this.txtAzMag);
            this.panel3.Controls.Add(this.txtDistance2);
            this.panel3.Controls.Add(this.txtDistance);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(0, 252);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(277, 84);
            this.panel3.TabIndex = 2;
            // 
            // cboMeta
            // 
            this.cboMeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMeta.FormattingEnabled = true;
            this.cboMeta.Location = new System.Drawing.Point(51, 7);
            this.cboMeta.Name = "cboMeta";
            this.cboMeta.Size = new System.Drawing.Size(88, 24);
            this.cboMeta.TabIndex = 0;
            this.cboMeta.TabStop = false;
            this.cboMeta.SelectedIndexChanged += new System.EventHandler(this.cboMeta_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "( M )";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Dist:";
            // 
            // txtAzTrue
            // 
            this.txtAzTrue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAzTrue.Location = new System.Drawing.Point(190, 31);
            this.txtAzTrue.Name = "txtAzTrue";
            this.txtAzTrue.ReadOnly = true;
            this.txtAzTrue.Size = new System.Drawing.Size(75, 22);
            this.txtAzTrue.TabIndex = 3;
            this.txtAzTrue.TabStop = false;
            // 
            // txtAzMag
            // 
            this.txtAzMag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAzMag.Location = new System.Drawing.Point(190, 54);
            this.txtAzMag.Name = "txtAzMag";
            this.txtAzMag.ReadOnly = true;
            this.txtAzMag.Size = new System.Drawing.Size(75, 22);
            this.txtAzMag.TabIndex = 3;
            this.txtAzMag.TabStop = false;
            // 
            // txtDistance2
            // 
            this.txtDistance2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistance2.Location = new System.Drawing.Point(51, 57);
            this.txtDistance2.Name = "txtDistance2";
            this.txtDistance2.ReadOnly = true;
            this.txtDistance2.Size = new System.Drawing.Size(75, 22);
            this.txtDistance2.TabIndex = 3;
            this.txtDistance2.TabStop = false;
            // 
            // txtDistance
            // 
            this.txtDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistance.Location = new System.Drawing.Point(51, 34);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.ReadOnly = true;
            this.txtDistance.Size = new System.Drawing.Size(75, 22);
            this.txtDistance.TabIndex = 3;
            this.txtDistance.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(193, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Azimuth";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(142, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Mag:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(140, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "True:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Meta:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(6, 342);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNav
            // 
            this.btnNav.Location = new System.Drawing.Point(87, 342);
            this.btnNav.Name = "btnNav";
            this.btnNav.Size = new System.Drawing.Size(103, 23);
            this.btnNav.TabIndex = 3;
            this.btnNav.TabStop = false;
            this.btnNav.Text = "Navigate";
            this.btnNav.UseVisualStyleBackColor = true;
            this.btnNav.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(196, 342);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 3;
            this.btnCalc.TabStop = false;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // WhereIsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 371);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.btnNav);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(293, 409);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(293, 409);
            this.Name = "WhereIsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Where Is?";
            this.Load += new System.EventHandler(this.WhereIsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WhereIsForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radFromPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radMyLoc;
        private System.Windows.Forms.RadioButton radFromUTM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFromPoly;
        private System.Windows.Forms.TextBox txtFromY;
        private System.Windows.Forms.TextBox txtFromX;
        private System.Windows.Forms.ComboBox cboFromPoint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboToPoint;
        private System.Windows.Forms.ComboBox cboToPoly;
        private System.Windows.Forms.TextBox txtToY;
        private System.Windows.Forms.TextBox txtToX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radToUTM;
        private System.Windows.Forms.RadioButton radToPoint;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboMeta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAzTrue;
        private System.Windows.Forms.TextBox txtAzMag;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNav;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TextBox txtDistance2;
        private System.Windows.Forms.Label label12;
    }
}