namespace TwoTrails.Forms
{
    partial class PolygonTransformationForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTransform = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cboSclType = new System.Windows.Forms.ComboBox();
            this.chkScale = new System.Windows.Forms.CheckBox();
            this.txtSclWidth = new System.Windows.Forms.TextBox();
            this.txtSclHeight = new System.Windows.Forms.TextBox();
            this.cboSclRefPoly = new System.Windows.Forms.ComboBox();
            this.cboSclRefPoint1 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboSclAdjPoly = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboSclRefPoint2 = new System.Windows.Forms.ComboBox();
            this.radSclManual = new System.Windows.Forms.RadioButton();
            this.cboSclAdjPoint1 = new System.Windows.Forms.ComboBox();
            this.radSclPoints = new System.Windows.Forms.RadioButton();
            this.cboSclAdjPoint2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboRotAdjPoint2 = new System.Windows.Forms.ComboBox();
            this.cboRotRefPoint2 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radRotAdj = new System.Windows.Forms.RadioButton();
            this.radRotRef = new System.Windows.Forms.RadioButton();
            this.txtRotAngle = new System.Windows.Forms.TextBox();
            this.chkRotate = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboRotRefPoly = new System.Windows.Forms.ComboBox();
            this.cboRotAdjPoint1 = new System.Windows.Forms.ComboBox();
            this.radRotAngle = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cboRotRefPoint1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radRotPoint = new System.Windows.Forms.RadioButton();
            this.cboRotAdjPoly = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlTransUnit = new System.Windows.Forms.Panel();
            this.radTransMeters = new System.Windows.Forms.RadioButton();
            this.radTransFeet = new System.Windows.Forms.RadioButton();
            this.txtTransY = new System.Windows.Forms.TextBox();
            this.txtTransX = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.radTransManual = new System.Windows.Forms.RadioButton();
            this.radTransPoints = new System.Windows.Forms.RadioButton();
            this.chkTranslate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTransAdjPoly = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTransAdjPoint = new System.Windows.Forms.ComboBox();
            this.cboTransRefPoint = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTransRefPoly = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radOptScale3 = new System.Windows.Forms.RadioButton();
            this.radOptRot3 = new System.Windows.Forms.RadioButton();
            this.radOptTrans3 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radOptScale2 = new System.Windows.Forms.RadioButton();
            this.radOptRot2 = new System.Windows.Forms.RadioButton();
            this.radOptTrans2 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radOptScale1 = new System.Windows.Forms.RadioButton();
            this.radOptRot1 = new System.Windows.Forms.RadioButton();
            this.radOptTrans1 = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlTransUnit.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(4, 235);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTransform
            // 
            this.btnTransform.Enabled = false;
            this.btnTransform.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransform.Location = new System.Drawing.Point(193, 235);
            this.btnTransform.Name = "btnTransform";
            this.btnTransform.Size = new System.Drawing.Size(75, 23);
            this.btnTransform.TabIndex = 2;
            this.btnTransform.TabStop = false;
            this.btnTransform.Text = "Transform";
            this.btnTransform.UseVisualStyleBackColor = true;
            this.btnTransform.Click += new System.EventHandler(this.btnTransform_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDraw.Location = new System.Drawing.Point(85, 235);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(102, 23);
            this.btnDraw.TabIndex = 2;
            this.btnDraw.TabStop = false;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cboSclType);
            this.tabPage3.Controls.Add(this.chkScale);
            this.tabPage3.Controls.Add(this.txtSclWidth);
            this.tabPage3.Controls.Add(this.txtSclHeight);
            this.tabPage3.Controls.Add(this.cboSclRefPoly);
            this.tabPage3.Controls.Add(this.cboSclRefPoint1);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.cboSclAdjPoly);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.cboSclRefPoint2);
            this.tabPage3.Controls.Add(this.radSclManual);
            this.tabPage3.Controls.Add(this.cboSclAdjPoint1);
            this.tabPage3.Controls.Add(this.radSclPoints);
            this.tabPage3.Controls.Add(this.cboSclAdjPoint2);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(269, 203);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Scale";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cboSclType
            // 
            this.cboSclType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSclType.Enabled = false;
            this.cboSclType.FormattingEnabled = true;
            this.cboSclType.Items.AddRange(new object[] {
            "( % )",
            "( Ft )",
            "( M )"});
            this.cboSclType.Location = new System.Drawing.Point(206, 136);
            this.cboSclType.Name = "cboSclType";
            this.cboSclType.Size = new System.Drawing.Size(50, 21);
            this.cboSclType.TabIndex = 7;
            this.cboSclType.TabStop = false;
            // 
            // chkScale
            // 
            this.chkScale.AutoSize = true;
            this.chkScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkScale.Location = new System.Drawing.Point(8, 6);
            this.chkScale.Name = "chkScale";
            this.chkScale.Size = new System.Drawing.Size(67, 20);
            this.chkScale.TabIndex = 2;
            this.chkScale.Text = "Scale";
            this.chkScale.UseVisualStyleBackColor = true;
            this.chkScale.CheckedChanged += new System.EventHandler(this.chkScale_CheckedChanged);
            // 
            // txtSclWidth
            // 
            this.txtSclWidth.Enabled = false;
            this.txtSclWidth.Location = new System.Drawing.Point(160, 136);
            this.txtSclWidth.Name = "txtSclWidth";
            this.txtSclWidth.Size = new System.Drawing.Size(40, 20);
            this.txtSclWidth.TabIndex = 5;
            this.txtSclWidth.TabStop = false;
            // 
            // txtSclHeight
            // 
            this.txtSclHeight.Enabled = false;
            this.txtSclHeight.Location = new System.Drawing.Point(61, 136);
            this.txtSclHeight.Name = "txtSclHeight";
            this.txtSclHeight.Size = new System.Drawing.Size(40, 20);
            this.txtSclHeight.TabIndex = 5;
            this.txtSclHeight.TabStop = false;
            // 
            // cboSclRefPoly
            // 
            this.cboSclRefPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSclRefPoly.Enabled = false;
            this.cboSclRefPoly.FormattingEnabled = true;
            this.cboSclRefPoly.Location = new System.Drawing.Point(8, 45);
            this.cboSclRefPoly.Name = "cboSclRefPoly";
            this.cboSclRefPoly.Size = new System.Drawing.Size(121, 21);
            this.cboSclRefPoly.TabIndex = 0;
            this.cboSclRefPoly.TabStop = false;
            this.cboSclRefPoly.SelectedIndexChanged += new System.EventHandler(this.cboSclRefPoly_SelectedIndexChanged);
            // 
            // cboSclRefPoint1
            // 
            this.cboSclRefPoint1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSclRefPoint1.Enabled = false;
            this.cboSclRefPoint1.FormattingEnabled = true;
            this.cboSclRefPoint1.Location = new System.Drawing.Point(8, 85);
            this.cboSclRefPoint1.Name = "cboSclRefPoint1";
            this.cboSclRefPoint1.Size = new System.Drawing.Size(121, 21);
            this.cboSclRefPoint1.TabIndex = 0;
            this.cboSclRefPoint1.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(107, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 15);
            this.label15.TabIndex = 4;
            this.label15.Text = "Width:";
            // 
            // cboSclAdjPoly
            // 
            this.cboSclAdjPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSclAdjPoly.Enabled = false;
            this.cboSclAdjPoly.FormattingEnabled = true;
            this.cboSclAdjPoly.Location = new System.Drawing.Point(135, 45);
            this.cboSclAdjPoly.Name = "cboSclAdjPoly";
            this.cboSclAdjPoly.Size = new System.Drawing.Size(121, 21);
            this.cboSclAdjPoly.TabIndex = 0;
            this.cboSclAdjPoly.TabStop = false;
            this.cboSclAdjPoly.SelectedIndexChanged += new System.EventHandler(this.cboSclAdjPoly_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Height:";
            // 
            // cboSclRefPoint2
            // 
            this.cboSclRefPoint2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSclRefPoint2.Enabled = false;
            this.cboSclRefPoint2.FormattingEnabled = true;
            this.cboSclRefPoint2.Location = new System.Drawing.Point(8, 112);
            this.cboSclRefPoint2.Name = "cboSclRefPoint2";
            this.cboSclRefPoint2.Size = new System.Drawing.Size(121, 21);
            this.cboSclRefPoint2.TabIndex = 0;
            this.cboSclRefPoint2.TabStop = false;
            // 
            // radSclManual
            // 
            this.radSclManual.AutoSize = true;
            this.radSclManual.Enabled = false;
            this.radSclManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSclManual.Location = new System.Drawing.Point(190, 7);
            this.radSclManual.Name = "radSclManual";
            this.radSclManual.Size = new System.Drawing.Size(66, 17);
            this.radSclManual.TabIndex = 3;
            this.radSclManual.Text = "Manual";
            this.radSclManual.UseVisualStyleBackColor = true;
            // 
            // cboSclAdjPoint1
            // 
            this.cboSclAdjPoint1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSclAdjPoint1.Enabled = false;
            this.cboSclAdjPoint1.FormattingEnabled = true;
            this.cboSclAdjPoint1.Location = new System.Drawing.Point(135, 85);
            this.cboSclAdjPoint1.Name = "cboSclAdjPoint1";
            this.cboSclAdjPoint1.Size = new System.Drawing.Size(121, 21);
            this.cboSclAdjPoint1.TabIndex = 0;
            this.cboSclAdjPoint1.TabStop = false;
            // 
            // radSclPoints
            // 
            this.radSclPoints.AutoSize = true;
            this.radSclPoints.Checked = true;
            this.radSclPoints.Enabled = false;
            this.radSclPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSclPoints.Location = new System.Drawing.Point(124, 7);
            this.radSclPoints.Name = "radSclPoints";
            this.radSclPoints.Size = new System.Drawing.Size(60, 17);
            this.radSclPoints.TabIndex = 3;
            this.radSclPoints.TabStop = true;
            this.radSclPoints.Text = "Points";
            this.radSclPoints.UseVisualStyleBackColor = true;
            this.radSclPoints.CheckedChanged += new System.EventHandler(this.radSclPoints_CheckedChanged);
            // 
            // cboSclAdjPoint2
            // 
            this.cboSclAdjPoint2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSclAdjPoint2.Enabled = false;
            this.cboSclAdjPoint2.FormattingEnabled = true;
            this.cboSclAdjPoint2.Location = new System.Drawing.Point(135, 112);
            this.cboSclAdjPoint2.Name = "cboSclAdjPoint2";
            this.cboSclAdjPoint2.Size = new System.Drawing.Size(121, 21);
            this.cboSclAdjPoint2.TabIndex = 0;
            this.cboSclAdjPoint2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(178, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Point";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(38, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Ref Polygon";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(164, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Adj Polygon";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(50, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Point";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cboRotAdjPoint2);
            this.tabPage2.Controls.Add(this.cboRotRefPoint2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.txtRotAngle);
            this.tabPage2.Controls.Add(this.chkRotate);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cboRotRefPoly);
            this.tabPage2.Controls.Add(this.cboRotAdjPoint1);
            this.tabPage2.Controls.Add(this.radRotAngle);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cboRotRefPoint1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.radRotPoint);
            this.tabPage2.Controls.Add(this.cboRotAdjPoly);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(269, 203);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rotate";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cboRotAdjPoint2
            // 
            this.cboRotAdjPoint2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRotAdjPoint2.Enabled = false;
            this.cboRotAdjPoint2.FormattingEnabled = true;
            this.cboRotAdjPoint2.Location = new System.Drawing.Point(135, 112);
            this.cboRotAdjPoint2.Name = "cboRotAdjPoint2";
            this.cboRotAdjPoint2.Size = new System.Drawing.Size(121, 21);
            this.cboRotAdjPoint2.TabIndex = 0;
            this.cboRotAdjPoint2.TabStop = false;
            // 
            // cboRotRefPoint2
            // 
            this.cboRotRefPoint2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRotRefPoint2.Enabled = false;
            this.cboRotRefPoint2.FormattingEnabled = true;
            this.cboRotRefPoint2.Location = new System.Drawing.Point(8, 112);
            this.cboRotRefPoint2.Name = "cboRotRefPoint2";
            this.cboRotRefPoint2.Size = new System.Drawing.Size(121, 21);
            this.cboRotRefPoint2.TabIndex = 0;
            this.cboRotRefPoint2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radRotAdj);
            this.panel1.Controls.Add(this.radRotRef);
            this.panel1.Location = new System.Drawing.Point(3, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 23);
            this.panel1.TabIndex = 6;
            // 
            // radRotAdj
            // 
            this.radRotAdj.AutoSize = true;
            this.radRotAdj.Enabled = false;
            this.radRotAdj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRotAdj.Location = new System.Drawing.Point(89, 2);
            this.radRotAdj.Name = "radRotAdj";
            this.radRotAdj.Size = new System.Drawing.Size(76, 17);
            this.radRotAdj.TabIndex = 3;
            this.radRotAdj.Text = "Adj Point";
            this.toolTip1.SetToolTip(this.radRotAdj, "Adj Polygon rotates around the Adj Point.");
            this.radRotAdj.UseVisualStyleBackColor = true;
            this.radRotAdj.CheckedChanged += new System.EventHandler(this.radRotAdj_CheckedChanged);
            // 
            // radRotRef
            // 
            this.radRotRef.AutoSize = true;
            this.radRotRef.Enabled = false;
            this.radRotRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRotRef.Location = new System.Drawing.Point(5, 2);
            this.radRotRef.Name = "radRotRef";
            this.radRotRef.Size = new System.Drawing.Size(78, 17);
            this.radRotRef.TabIndex = 3;
            this.radRotRef.Text = "Ref Point";
            this.toolTip1.SetToolTip(this.radRotRef, "Adj Polygon rotates around the Ref Point.");
            this.radRotRef.UseVisualStyleBackColor = true;
            this.radRotRef.CheckedChanged += new System.EventHandler(this.radRotRef_CheckedChanged);
            // 
            // txtRotAngle
            // 
            this.txtRotAngle.Enabled = false;
            this.txtRotAngle.Location = new System.Drawing.Point(62, 158);
            this.txtRotAngle.Name = "txtRotAngle";
            this.txtRotAngle.Size = new System.Drawing.Size(68, 20);
            this.txtRotAngle.TabIndex = 5;
            this.txtRotAngle.TabStop = false;
            // 
            // chkRotate
            // 
            this.chkRotate.AutoSize = true;
            this.chkRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRotate.Location = new System.Drawing.Point(8, 6);
            this.chkRotate.Name = "chkRotate";
            this.chkRotate.Size = new System.Drawing.Size(73, 20);
            this.chkRotate.TabIndex = 2;
            this.chkRotate.Text = "Rotate";
            this.chkRotate.UseVisualStyleBackColor = true;
            this.chkRotate.CheckedChanged += new System.EventHandler(this.chkRotate_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(38, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ref Polygon";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(133, 159);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 15);
            this.label21.TabIndex = 4;
            this.label21.Text = "(Degrees)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Angle:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(50, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Point";
            // 
            // cboRotRefPoly
            // 
            this.cboRotRefPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRotRefPoly.Enabled = false;
            this.cboRotRefPoly.FormattingEnabled = true;
            this.cboRotRefPoly.Location = new System.Drawing.Point(8, 45);
            this.cboRotRefPoly.Name = "cboRotRefPoly";
            this.cboRotRefPoly.Size = new System.Drawing.Size(121, 21);
            this.cboRotRefPoly.TabIndex = 0;
            this.cboRotRefPoly.TabStop = false;
            this.cboRotRefPoly.SelectedIndexChanged += new System.EventHandler(this.cboRotRefPoly_SelectedIndexChanged);
            // 
            // cboRotAdjPoint1
            // 
            this.cboRotAdjPoint1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRotAdjPoint1.Enabled = false;
            this.cboRotAdjPoint1.FormattingEnabled = true;
            this.cboRotAdjPoint1.Location = new System.Drawing.Point(135, 85);
            this.cboRotAdjPoint1.Name = "cboRotAdjPoint1";
            this.cboRotAdjPoint1.Size = new System.Drawing.Size(121, 21);
            this.cboRotAdjPoint1.TabIndex = 0;
            this.cboRotAdjPoint1.TabStop = false;
            // 
            // radRotAngle
            // 
            this.radRotAngle.AutoSize = true;
            this.radRotAngle.Enabled = false;
            this.radRotAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRotAngle.Location = new System.Drawing.Point(199, 7);
            this.radRotAngle.Name = "radRotAngle";
            this.radRotAngle.Size = new System.Drawing.Size(57, 17);
            this.radRotAngle.TabIndex = 3;
            this.radRotAngle.Text = "Angle";
            this.radRotAngle.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(164, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Adj Polygon";
            // 
            // cboRotRefPoint1
            // 
            this.cboRotRefPoint1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRotRefPoint1.Enabled = false;
            this.cboRotRefPoint1.FormattingEnabled = true;
            this.cboRotRefPoint1.Location = new System.Drawing.Point(8, 85);
            this.cboRotRefPoint1.Name = "cboRotRefPoint1";
            this.cboRotRefPoint1.Size = new System.Drawing.Size(121, 21);
            this.cboRotRefPoint1.TabIndex = 0;
            this.cboRotRefPoint1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(178, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Point";
            // 
            // radRotPoint
            // 
            this.radRotPoint.AutoSize = true;
            this.radRotPoint.Checked = true;
            this.radRotPoint.Enabled = false;
            this.radRotPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRotPoint.Location = new System.Drawing.Point(133, 7);
            this.radRotPoint.Name = "radRotPoint";
            this.radRotPoint.Size = new System.Drawing.Size(60, 17);
            this.radRotPoint.TabIndex = 3;
            this.radRotPoint.TabStop = true;
            this.radRotPoint.Text = "Points";
            this.radRotPoint.UseVisualStyleBackColor = true;
            this.radRotPoint.CheckedChanged += new System.EventHandler(this.radRotPoint_CheckedChanged);
            // 
            // cboRotAdjPoly
            // 
            this.cboRotAdjPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRotAdjPoly.Enabled = false;
            this.cboRotAdjPoly.FormattingEnabled = true;
            this.cboRotAdjPoly.Location = new System.Drawing.Point(135, 45);
            this.cboRotAdjPoly.Name = "cboRotAdjPoly";
            this.cboRotAdjPoly.Size = new System.Drawing.Size(121, 21);
            this.cboRotAdjPoly.TabIndex = 0;
            this.cboRotAdjPoly.TabStop = false;
            this.cboRotAdjPoly.SelectedIndexChanged += new System.EventHandler(this.cboRotAdjPoly_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlTransUnit);
            this.tabPage1.Controls.Add(this.txtTransY);
            this.tabPage1.Controls.Add(this.txtTransX);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.radTransManual);
            this.tabPage1.Controls.Add(this.radTransPoints);
            this.tabPage1.Controls.Add(this.chkTranslate);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cboTransAdjPoly);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cboTransAdjPoint);
            this.tabPage1.Controls.Add(this.cboTransRefPoint);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cboTransRefPoly);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(269, 203);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Translate";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlTransUnit
            // 
            this.pnlTransUnit.Controls.Add(this.radTransMeters);
            this.pnlTransUnit.Controls.Add(this.radTransFeet);
            this.pnlTransUnit.Enabled = false;
            this.pnlTransUnit.Location = new System.Drawing.Point(135, 165);
            this.pnlTransUnit.Name = "pnlTransUnit";
            this.pnlTransUnit.Size = new System.Drawing.Size(121, 32);
            this.pnlTransUnit.TabIndex = 8;
            // 
            // radTransMeters
            // 
            this.radTransMeters.AutoSize = true;
            this.radTransMeters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTransMeters.Location = new System.Drawing.Point(53, -1);
            this.radTransMeters.Name = "radTransMeters";
            this.radTransMeters.Size = new System.Drawing.Size(63, 17);
            this.radTransMeters.TabIndex = 0;
            this.radTransMeters.Text = "Meters";
            this.radTransMeters.UseVisualStyleBackColor = true;
            // 
            // radTransFeet
            // 
            this.radTransFeet.AutoSize = true;
            this.radTransFeet.Checked = true;
            this.radTransFeet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTransFeet.Location = new System.Drawing.Point(0, 0);
            this.radTransFeet.Name = "radTransFeet";
            this.radTransFeet.Size = new System.Drawing.Size(50, 17);
            this.radTransFeet.TabIndex = 0;
            this.radTransFeet.TabStop = true;
            this.radTransFeet.Text = "Feet";
            this.radTransFeet.UseVisualStyleBackColor = true;
            // 
            // txtTransY
            // 
            this.txtTransY.Enabled = false;
            this.txtTransY.Location = new System.Drawing.Point(135, 138);
            this.txtTransY.Name = "txtTransY";
            this.txtTransY.Size = new System.Drawing.Size(121, 20);
            this.txtTransY.TabIndex = 7;
            this.txtTransY.TabStop = false;
            // 
            // txtTransX
            // 
            this.txtTransX.Enabled = false;
            this.txtTransX.Location = new System.Drawing.Point(135, 112);
            this.txtTransX.Name = "txtTransX";
            this.txtTransX.Size = new System.Drawing.Size(121, 20);
            this.txtTransX.TabIndex = 7;
            this.txtTransX.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(57, 141);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Translate Y";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(57, 115);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Translate X";
            // 
            // radTransManual
            // 
            this.radTransManual.AutoSize = true;
            this.radTransManual.Enabled = false;
            this.radTransManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTransManual.Location = new System.Drawing.Point(190, 7);
            this.radTransManual.Name = "radTransManual";
            this.radTransManual.Size = new System.Drawing.Size(66, 17);
            this.radTransManual.TabIndex = 5;
            this.radTransManual.Text = "Manual";
            this.radTransManual.UseVisualStyleBackColor = true;
            // 
            // radTransPoints
            // 
            this.radTransPoints.AutoSize = true;
            this.radTransPoints.Checked = true;
            this.radTransPoints.Enabled = false;
            this.radTransPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTransPoints.Location = new System.Drawing.Point(124, 7);
            this.radTransPoints.Name = "radTransPoints";
            this.radTransPoints.Size = new System.Drawing.Size(60, 17);
            this.radTransPoints.TabIndex = 4;
            this.radTransPoints.TabStop = true;
            this.radTransPoints.Text = "Points";
            this.radTransPoints.UseVisualStyleBackColor = true;
            this.radTransPoints.CheckedChanged += new System.EventHandler(this.radTransPoints_CheckedChanged);
            // 
            // chkTranslate
            // 
            this.chkTranslate.AutoSize = true;
            this.chkTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTranslate.Location = new System.Drawing.Point(8, 6);
            this.chkTranslate.Name = "chkTranslate";
            this.chkTranslate.Size = new System.Drawing.Size(93, 20);
            this.chkTranslate.TabIndex = 1;
            this.chkTranslate.Text = "Translate";
            this.chkTranslate.UseVisualStyleBackColor = true;
            this.chkTranslate.CheckedChanged += new System.EventHandler(this.chkTranslate_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(178, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Point";
            // 
            // cboTransAdjPoly
            // 
            this.cboTransAdjPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransAdjPoly.Enabled = false;
            this.cboTransAdjPoly.FormattingEnabled = true;
            this.cboTransAdjPoly.Location = new System.Drawing.Point(135, 45);
            this.cboTransAdjPoly.Name = "cboTransAdjPoly";
            this.cboTransAdjPoly.Size = new System.Drawing.Size(121, 21);
            this.cboTransAdjPoly.TabIndex = 0;
            this.cboTransAdjPoly.TabStop = false;
            this.cboTransAdjPoly.SelectedIndexChanged += new System.EventHandler(this.cboTransAdjPoly_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ref Polygon";
            // 
            // cboTransAdjPoint
            // 
            this.cboTransAdjPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransAdjPoint.Enabled = false;
            this.cboTransAdjPoint.FormattingEnabled = true;
            this.cboTransAdjPoint.Location = new System.Drawing.Point(135, 85);
            this.cboTransAdjPoint.Name = "cboTransAdjPoint";
            this.cboTransAdjPoint.Size = new System.Drawing.Size(121, 21);
            this.cboTransAdjPoint.TabIndex = 0;
            this.cboTransAdjPoint.TabStop = false;
            // 
            // cboTransRefPoint
            // 
            this.cboTransRefPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransRefPoint.Enabled = false;
            this.cboTransRefPoint.FormattingEnabled = true;
            this.cboTransRefPoint.Location = new System.Drawing.Point(8, 85);
            this.cboTransRefPoint.Name = "cboTransRefPoint";
            this.cboTransRefPoint.Size = new System.Drawing.Size(121, 21);
            this.cboTransRefPoint.TabIndex = 0;
            this.cboTransRefPoint.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Point";
            // 
            // cboTransRefPoly
            // 
            this.cboTransRefPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransRefPoly.Enabled = false;
            this.cboTransRefPoly.FormattingEnabled = true;
            this.cboTransRefPoly.Location = new System.Drawing.Point(8, 45);
            this.cboTransRefPoly.Name = "cboTransRefPoly";
            this.cboTransRefPoly.Size = new System.Drawing.Size(121, 21);
            this.cboTransRefPoly.TabIndex = 0;
            this.cboTransRefPoly.TabStop = false;
            this.cboTransRefPoly.SelectedIndexChanged += new System.EventHandler(this.cboTransRefPoly_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(164, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Adj Polygon";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabOptions);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(277, 229);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabStop = false;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.label20);
            this.tabOptions.Controls.Add(this.label19);
            this.tabOptions.Controls.Add(this.label18);
            this.tabOptions.Controls.Add(this.panel5);
            this.tabOptions.Controls.Add(this.panel3);
            this.tabOptions.Controls.Add(this.panel2);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(269, 203);
            this.tabOptions.TabIndex = 3;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(189, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 16);
            this.label20.TabIndex = 1;
            this.label20.Text = "Third";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(100, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 16);
            this.label19.TabIndex = 1;
            this.label19.Text = "Second";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(36, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 16);
            this.label18.TabIndex = 1;
            this.label18.Text = "First";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.radOptScale3);
            this.panel5.Controls.Add(this.radOptRot3);
            this.panel5.Controls.Add(this.radOptTrans3);
            this.panel5.Location = new System.Drawing.Point(170, 25);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(82, 70);
            this.panel5.TabIndex = 0;
            // 
            // radOptScale3
            // 
            this.radOptScale3.AutoSize = true;
            this.radOptScale3.Checked = true;
            this.radOptScale3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOptScale3.Location = new System.Drawing.Point(3, 49);
            this.radOptScale3.Name = "radOptScale3";
            this.radOptScale3.Size = new System.Drawing.Size(57, 17);
            this.radOptScale3.TabIndex = 0;
            this.radOptScale3.TabStop = true;
            this.radOptScale3.Text = "Scale";
            this.radOptScale3.UseVisualStyleBackColor = true;
            this.radOptScale3.CheckedChanged += new System.EventHandler(this.radOptScale3_CheckedChanged);
            // 
            // radOptRot3
            // 
            this.radOptRot3.AutoSize = true;
            this.radOptRot3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOptRot3.Location = new System.Drawing.Point(3, 26);
            this.radOptRot3.Name = "radOptRot3";
            this.radOptRot3.Size = new System.Drawing.Size(63, 17);
            this.radOptRot3.TabIndex = 0;
            this.radOptRot3.Text = "Rotate";
            this.radOptRot3.UseVisualStyleBackColor = true;
            this.radOptRot3.CheckedChanged += new System.EventHandler(this.radOptRot3_CheckedChanged);
            // 
            // radOptTrans3
            // 
            this.radOptTrans3.AutoSize = true;
            this.radOptTrans3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOptTrans3.Location = new System.Drawing.Point(3, 3);
            this.radOptTrans3.Name = "radOptTrans3";
            this.radOptTrans3.Size = new System.Drawing.Size(78, 17);
            this.radOptTrans3.TabIndex = 0;
            this.radOptTrans3.Text = "Translate";
            this.radOptTrans3.UseVisualStyleBackColor = true;
            this.radOptTrans3.CheckedChanged += new System.EventHandler(this.radOptTrans3_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radOptScale2);
            this.panel3.Controls.Add(this.radOptRot2);
            this.panel3.Controls.Add(this.radOptTrans2);
            this.panel3.Location = new System.Drawing.Point(89, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(82, 70);
            this.panel3.TabIndex = 0;
            // 
            // radOptScale2
            // 
            this.radOptScale2.AutoSize = true;
            this.radOptScale2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOptScale2.Location = new System.Drawing.Point(3, 49);
            this.radOptScale2.Name = "radOptScale2";
            this.radOptScale2.Size = new System.Drawing.Size(57, 17);
            this.radOptScale2.TabIndex = 0;
            this.radOptScale2.Text = "Scale";
            this.radOptScale2.UseVisualStyleBackColor = true;
            this.radOptScale2.CheckedChanged += new System.EventHandler(this.radOptScale2_CheckedChanged);
            // 
            // radOptRot2
            // 
            this.radOptRot2.AutoSize = true;
            this.radOptRot2.Checked = true;
            this.radOptRot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOptRot2.Location = new System.Drawing.Point(3, 26);
            this.radOptRot2.Name = "radOptRot2";
            this.radOptRot2.Size = new System.Drawing.Size(63, 17);
            this.radOptRot2.TabIndex = 0;
            this.radOptRot2.TabStop = true;
            this.radOptRot2.Text = "Rotate";
            this.radOptRot2.UseVisualStyleBackColor = true;
            this.radOptRot2.CheckedChanged += new System.EventHandler(this.radOptRot2_CheckedChanged);
            // 
            // radOptTrans2
            // 
            this.radOptTrans2.AutoSize = true;
            this.radOptTrans2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOptTrans2.Location = new System.Drawing.Point(3, 3);
            this.radOptTrans2.Name = "radOptTrans2";
            this.radOptTrans2.Size = new System.Drawing.Size(78, 17);
            this.radOptTrans2.TabIndex = 0;
            this.radOptTrans2.Text = "Translate";
            this.radOptTrans2.UseVisualStyleBackColor = true;
            this.radOptTrans2.CheckedChanged += new System.EventHandler(this.radOptTrans2_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radOptScale1);
            this.panel2.Controls.Add(this.radOptRot1);
            this.panel2.Controls.Add(this.radOptTrans1);
            this.panel2.Location = new System.Drawing.Point(8, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(82, 70);
            this.panel2.TabIndex = 0;
            // 
            // radOptScale1
            // 
            this.radOptScale1.AutoSize = true;
            this.radOptScale1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOptScale1.Location = new System.Drawing.Point(3, 49);
            this.radOptScale1.Name = "radOptScale1";
            this.radOptScale1.Size = new System.Drawing.Size(57, 17);
            this.radOptScale1.TabIndex = 0;
            this.radOptScale1.Text = "Scale";
            this.radOptScale1.UseVisualStyleBackColor = true;
            this.radOptScale1.CheckedChanged += new System.EventHandler(this.radOptScale1_CheckedChanged);
            // 
            // radOptRot1
            // 
            this.radOptRot1.AutoSize = true;
            this.radOptRot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOptRot1.Location = new System.Drawing.Point(3, 26);
            this.radOptRot1.Name = "radOptRot1";
            this.radOptRot1.Size = new System.Drawing.Size(63, 17);
            this.radOptRot1.TabIndex = 0;
            this.radOptRot1.Text = "Rotate";
            this.radOptRot1.UseVisualStyleBackColor = true;
            this.radOptRot1.CheckedChanged += new System.EventHandler(this.radOptRot1_CheckedChanged);
            // 
            // radOptTrans1
            // 
            this.radOptTrans1.AutoSize = true;
            this.radOptTrans1.Checked = true;
            this.radOptTrans1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOptTrans1.Location = new System.Drawing.Point(3, 3);
            this.radOptTrans1.Name = "radOptTrans1";
            this.radOptTrans1.Size = new System.Drawing.Size(78, 17);
            this.radOptTrans1.TabIndex = 0;
            this.radOptTrans1.TabStop = true;
            this.radOptTrans1.Text = "Translate";
            this.radOptTrans1.UseVisualStyleBackColor = true;
            this.radOptTrans1.CheckedChanged += new System.EventHandler(this.radOptTrans1_CheckedChanged);
            // 
            // PolygonTransformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(274, 263);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnTransform);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PolygonTransformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Polygon Transformation";
            this.Load += new System.EventHandler(this.PolygonTransformationForm_Load);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnlTransUnit.ResumeLayout(false);
            this.pnlTransUnit.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTransform;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkScale;
        private System.Windows.Forms.TextBox txtSclWidth;
        private System.Windows.Forms.TextBox txtSclHeight;
        private System.Windows.Forms.ComboBox cboSclRefPoly;
        private System.Windows.Forms.ComboBox cboSclRefPoint1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboSclAdjPoly;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboSclRefPoint2;
        private System.Windows.Forms.RadioButton radSclManual;
        private System.Windows.Forms.ComboBox cboSclAdjPoint1;
        private System.Windows.Forms.RadioButton radSclPoints;
        private System.Windows.Forms.ComboBox cboSclAdjPoint2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtRotAngle;
        private System.Windows.Forms.CheckBox chkRotate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboRotAdjPoint2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboRotRefPoly;
        private System.Windows.Forms.ComboBox cboRotAdjPoint1;
        private System.Windows.Forms.RadioButton radRotAngle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboRotRefPoint1;
        private System.Windows.Forms.ComboBox cboRotRefPoint2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radRotPoint;
        private System.Windows.Forms.ComboBox cboRotAdjPoly;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlTransUnit;
        private System.Windows.Forms.RadioButton radTransMeters;
        private System.Windows.Forms.RadioButton radTransFeet;
        private System.Windows.Forms.TextBox txtTransY;
        private System.Windows.Forms.TextBox txtTransX;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton radTransManual;
        private System.Windows.Forms.RadioButton radTransPoints;
        private System.Windows.Forms.CheckBox chkTranslate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTransAdjPoly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTransAdjPoint;
        private System.Windows.Forms.ComboBox cboTransRefPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTransRefPoly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ComboBox cboSclType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radRotAdj;
        private System.Windows.Forms.RadioButton radRotRef;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radOptScale3;
        private System.Windows.Forms.RadioButton radOptRot3;
        private System.Windows.Forms.RadioButton radOptTrans3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radOptScale2;
        private System.Windows.Forms.RadioButton radOptRot2;
        private System.Windows.Forms.RadioButton radOptTrans2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radOptScale1;
        private System.Windows.Forms.RadioButton radOptRot1;
        private System.Windows.Forms.RadioButton radOptTrans1;
        private System.Windows.Forms.Label label21;
    }
}