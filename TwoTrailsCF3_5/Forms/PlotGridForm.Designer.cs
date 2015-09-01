namespace TwoTrails.Forms
{
    partial class PlotGridForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPlot = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDist = new System.Windows.Forms.Button();
            this.btnPoly = new System.Windows.Forms.Button();
            this.cboStart = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.cboDist = new System.Windows.Forms.ComboBox();
            this.cboLoc = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPoly = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSample = new System.Windows.Forms.Button();
            this.cboSample = new System.Windows.Forms.ComboBox();
            this.chkSample = new System.Windows.Forms.CheckBox();
            this.chkDelOld = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txti2 = new System.Windows.Forms.TextBox();
            this.txtTilt = new System.Windows.Forms.TextBox();
            this.txtSample = new System.Windows.Forms.TextBox();
            this.txti1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(3, 266);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPlot
            // 
            this.btnPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlot.Location = new System.Drawing.Point(167, 266);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(70, 25);
            this.btnPlot.TabIndex = 0;
            this.btnPlot.TabStop = false;
            this.btnPlot.Text = "Plot";
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(0, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 29);
            this.label4.Text = "Make Plot Grid";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnDist);
            this.panel1.Controls.Add(this.btnPoly);
            this.panel1.Controls.Add(this.cboStart);
            this.panel1.Controls.Add(this.btnLoc);
            this.panel1.Controls.Add(this.cboDist);
            this.panel1.Controls.Add(this.cboLoc);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboPoly);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 127);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(91, 98);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(135, 22);
            this.btnStart.TabIndex = 6;
            this.btnStart.TabStop = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDist
            // 
            this.btnDist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDist.Location = new System.Drawing.Point(76, 70);
            this.btnDist.Name = "btnDist";
            this.btnDist.Size = new System.Drawing.Size(150, 22);
            this.btnDist.TabIndex = 6;
            this.btnDist.TabStop = false;
            this.btnDist.Click += new System.EventHandler(this.btnDist_Click);
            // 
            // btnPoly
            // 
            this.btnPoly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPoly.Location = new System.Drawing.Point(76, 42);
            this.btnPoly.Name = "btnPoly";
            this.btnPoly.Size = new System.Drawing.Size(150, 22);
            this.btnPoly.TabIndex = 6;
            this.btnPoly.TabStop = false;
            this.btnPoly.Click += new System.EventHandler(this.btnPoly_Click);
            // 
            // cboStart
            // 
            this.cboStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStart.Location = new System.Drawing.Point(91, 98);
            this.cboStart.Name = "cboStart";
            this.cboStart.Size = new System.Drawing.Size(135, 22);
            this.cboStart.TabIndex = 2;
            this.cboStart.TabStop = false;
            this.cboStart.SelectedIndexChanged += new System.EventHandler(this.cboStart_SelectedIndexChanged);
            // 
            // btnLoc
            // 
            this.btnLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoc.Location = new System.Drawing.Point(76, 11);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(150, 22);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.TabStop = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cboDist
            // 
            this.cboDist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDist.Location = new System.Drawing.Point(76, 70);
            this.cboDist.Name = "cboDist";
            this.cboDist.Size = new System.Drawing.Size(150, 22);
            this.cboDist.TabIndex = 2;
            this.cboDist.TabStop = false;
            this.cboDist.SelectedIndexChanged += new System.EventHandler(this.cboDist_SelectedIndexChanged);
            // 
            // cboLoc
            // 
            this.cboLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLoc.Location = new System.Drawing.Point(76, 11);
            this.cboLoc.Name = "cboLoc";
            this.cboLoc.Size = new System.Drawing.Size(150, 22);
            this.cboLoc.TabIndex = 2;
            this.cboLoc.TabStop = false;
            this.cboLoc.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(3, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.Text = "Start Point:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboPoly
            // 
            this.cboPoly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPoly.Location = new System.Drawing.Point(76, 42);
            this.cboPoly.Name = "cboPoly";
            this.cboPoly.Size = new System.Drawing.Size(150, 22);
            this.cboPoly.TabIndex = 2;
            this.cboPoly.TabStop = false;
            this.cboPoly.SelectedIndexChanged += new System.EventHandler(this.cboPoly_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.Text = "Distance:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.Text = "Polygon:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 33);
            this.label1.Text = "Generate Location:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.Controls.Add(this.btnSample);
            this.panel2.Controls.Add(this.cboSample);
            this.panel2.Controls.Add(this.chkSample);
            this.panel2.Controls.Add(this.chkDelOld);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txti2);
            this.panel2.Controls.Add(this.txtTilt);
            this.panel2.Controls.Add(this.txtSample);
            this.panel2.Controls.Add(this.txti1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(3, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 103);
            // 
            // btnSample
            // 
            this.btnSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSample.Enabled = false;
            this.btnSample.Location = new System.Drawing.Point(98, 78);
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(74, 22);
            this.btnSample.TabIndex = 3;
            this.btnSample.TabStop = false;
            this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
            // 
            // cboSample
            // 
            this.cboSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSample.Enabled = false;
            this.cboSample.Location = new System.Drawing.Point(98, 78);
            this.cboSample.Name = "cboSample";
            this.cboSample.Size = new System.Drawing.Size(72, 22);
            this.cboSample.TabIndex = 8;
            this.cboSample.TabStop = false;
            this.cboSample.SelectedIndexChanged += new System.EventHandler(this.cboSample_SelectedIndexChanged);
            // 
            // chkSample
            // 
            this.chkSample.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkSample.Location = new System.Drawing.Point(5, 80);
            this.chkSample.Name = "chkSample";
            this.chkSample.Size = new System.Drawing.Size(98, 20);
            this.chkSample.TabIndex = 4;
            this.chkSample.TabStop = false;
            this.chkSample.Text = "Subsample";
            this.chkSample.Click += new System.EventHandler(this.chkSample_Click);
            // 
            // chkDelOld
            // 
            this.chkDelOld.Checked = true;
            this.chkDelOld.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelOld.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkDelOld.Location = new System.Drawing.Point(5, 59);
            this.chkDelOld.Name = "chkDelOld";
            this.chkDelOld.Size = new System.Drawing.Size(167, 20);
            this.chkDelOld.TabIndex = 4;
            this.chkDelOld.TabStop = false;
            this.chkDelOld.Text = "Delete Old Plot Grid";
            this.chkDelOld.CheckStateChanged += new System.EventHandler(this.chkDelOld_CheckStateChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(155, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.Text = "x";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txti2
            // 
            this.txti2.Location = new System.Drawing.Point(176, 7);
            this.txti2.Name = "txti2";
            this.txti2.Size = new System.Drawing.Size(50, 21);
            this.txti2.TabIndex = 1;
            this.txti2.TabStop = false;
            this.txti2.Text = "100";
            this.txti2.TextChanged += new System.EventHandler(this.txti2_TextChanged);
            this.txti2.GotFocus += new System.EventHandler(this.txti2_GotFocus);
            this.txti2.LostFocus += new System.EventHandler(this.txti2_LostFocus);
            // 
            // txtTilt
            // 
            this.txtTilt.Location = new System.Drawing.Point(176, 34);
            this.txtTilt.Name = "txtTilt";
            this.txtTilt.Size = new System.Drawing.Size(50, 21);
            this.txtTilt.TabIndex = 1;
            this.txtTilt.TabStop = false;
            this.txtTilt.Text = "<rand>";
            this.txtTilt.TextChanged += new System.EventHandler(this.txtTilt_TextChanged);
            this.txtTilt.GotFocus += new System.EventHandler(this.txtTilt_GotFocus);
            this.txtTilt.LostFocus += new System.EventHandler(this.txtTilt_LostFocus);
            // 
            // txtSample
            // 
            this.txtSample.Enabled = false;
            this.txtSample.Location = new System.Drawing.Point(176, 78);
            this.txtSample.Name = "txtSample";
            this.txtSample.Size = new System.Drawing.Size(50, 21);
            this.txtSample.TabIndex = 1;
            this.txtSample.TabStop = false;
            this.txtSample.TextChanged += new System.EventHandler(this.txtSample_TextChanged);
            this.txtSample.GotFocus += new System.EventHandler(this.txtSample_GotFocus);
            this.txtSample.LostFocus += new System.EventHandler(this.txtSample_LostFocus);
            // 
            // txti1
            // 
            this.txti1.Location = new System.Drawing.Point(98, 7);
            this.txti1.Name = "txti1";
            this.txti1.Size = new System.Drawing.Size(50, 21);
            this.txti1.TabIndex = 1;
            this.txti1.TabStop = false;
            this.txti1.Text = "100";
            this.txti1.TextChanged += new System.EventHandler(this.txti1_TextChanged);
            this.txti1.GotFocus += new System.EventHandler(this.txti1_GotFocus);
            this.txti1.LostFocus += new System.EventHandler(this.txti1_LostFocus);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(5, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 20);
            this.label7.Text = "Tilt Grid axis (-45 to +45):";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(5, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.Text = "Grid Interval:";
            // 
            // PlotGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Name = "PlotGridForm";
            this.Text = "Plot Grid";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPlot = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDist = new System.Windows.Forms.Button();
            this.btnPoly = new System.Windows.Forms.Button();
            this.cboStart = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.cboDist = new System.Windows.Forms.ComboBox();
            this.cboLoc = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPoly = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSample = new System.Windows.Forms.Button();
            this.cboSample = new System.Windows.Forms.ComboBox();
            this.chkSample = new System.Windows.Forms.CheckBox();
            this.chkDelOld = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txti2 = new System.Windows.Forms.TextBox();
            this.txtTilt = new System.Windows.Forms.TextBox();
            this.txtSample = new System.Windows.Forms.TextBox();
            this.txti1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(3, 186);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPlot
            // 
            this.btnPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlot.Location = new System.Drawing.Point(247, 186);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(70, 25);
            this.btnPlot.TabIndex = 0;
            this.btnPlot.TabStop = false;
            this.btnPlot.Text = "Plot";
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(0, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(320, 29);
            this.label4.Text = "Make Plot Grid";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnDist);
            this.panel1.Controls.Add(this.btnPoly);
            this.panel1.Controls.Add(this.cboStart);
            this.panel1.Controls.Add(this.btnLoc);
            this.panel1.Controls.Add(this.cboDist);
            this.panel1.Controls.Add(this.cboLoc);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboPoly);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 70);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(240, 42);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(74, 22);
            this.btnStart.TabIndex = 6;
            this.btnStart.TabStop = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDist
            // 
            this.btnDist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDist.Location = new System.Drawing.Point(240, 11);
            this.btnDist.Name = "btnDist";
            this.btnDist.Size = new System.Drawing.Size(74, 22);
            this.btnDist.TabIndex = 6;
            this.btnDist.TabStop = false;
            this.btnDist.Click += new System.EventHandler(this.btnDist_Click);
            // 
            // btnPoly
            // 
            this.btnPoly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPoly.Location = new System.Drawing.Point(76, 42);
            this.btnPoly.Name = "btnPoly";
            this.btnPoly.Size = new System.Drawing.Size(74, 22);
            this.btnPoly.TabIndex = 6;
            this.btnPoly.TabStop = false;
            this.btnPoly.Click += new System.EventHandler(this.btnPoly_Click);
            // 
            // cboStart
            // 
            this.cboStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStart.Location = new System.Drawing.Point(240, 42);
            this.cboStart.Name = "cboStart";
            this.cboStart.Size = new System.Drawing.Size(74, 22);
            this.cboStart.TabIndex = 2;
            this.cboStart.TabStop = false;
            this.cboStart.SelectedIndexChanged += new System.EventHandler(this.cboStart_SelectedIndexChanged);
            // 
            // btnLoc
            // 
            this.btnLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoc.Location = new System.Drawing.Point(76, 11);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(74, 22);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.TabStop = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cboDist
            // 
            this.cboDist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDist.Location = new System.Drawing.Point(240, 11);
            this.cboDist.Name = "cboDist";
            this.cboDist.Size = new System.Drawing.Size(74, 22);
            this.cboDist.TabIndex = 2;
            this.cboDist.TabStop = false;
            this.cboDist.SelectedIndexChanged += new System.EventHandler(this.cboDist_SelectedIndexChanged);
            // 
            // cboLoc
            // 
            this.cboLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLoc.Location = new System.Drawing.Point(76, 11);
            this.cboLoc.Name = "cboLoc";
            this.cboLoc.Size = new System.Drawing.Size(74, 22);
            this.cboLoc.TabIndex = 2;
            this.cboLoc.TabStop = false;
            this.cboLoc.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(152, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.Text = "Start Point:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboPoly
            // 
            this.cboPoly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPoly.Location = new System.Drawing.Point(76, 42);
            this.cboPoly.Name = "cboPoly";
            this.cboPoly.Size = new System.Drawing.Size(74, 22);
            this.cboPoly.TabIndex = 2;
            this.cboPoly.TabStop = false;
            this.cboPoly.SelectedIndexChanged += new System.EventHandler(this.cboPoly_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(167, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.Text = "Distance:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.Text = "Polygon:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 33);
            this.label1.Text = "Generate Location:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.Controls.Add(this.btnSample);
            this.panel2.Controls.Add(this.cboSample);
            this.panel2.Controls.Add(this.chkSample);
            this.panel2.Controls.Add(this.chkDelOld);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txti2);
            this.panel2.Controls.Add(this.txtTilt);
            this.panel2.Controls.Add(this.txtSample);
            this.panel2.Controls.Add(this.txti1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 83);
            // 
            // btnSample
            // 
            this.btnSample.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSample.Enabled = false;
            this.btnSample.Location = new System.Drawing.Point(242, 55);
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(70, 22);
            this.btnSample.TabIndex = 3;
            this.btnSample.TabStop = false;
            this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
            // 
            // cboSample
            // 
            this.cboSample.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboSample.Enabled = false;
            this.cboSample.Location = new System.Drawing.Point(242, 55);
            this.cboSample.Name = "cboSample";
            this.cboSample.Size = new System.Drawing.Size(70, 22);
            this.cboSample.TabIndex = 8;
            this.cboSample.TabStop = false;
            this.cboSample.SelectedIndexChanged += new System.EventHandler(this.cboSample_SelectedIndexChanged);
            // 
            // chkSample
            // 
            this.chkSample.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkSample.Location = new System.Drawing.Point(149, 57);
            this.chkSample.Name = "chkSample";
            this.chkSample.Size = new System.Drawing.Size(101, 20);
            this.chkSample.TabIndex = 4;
            this.chkSample.TabStop = false;
            this.chkSample.Text = "Subsample";
            this.chkSample.Click += new System.EventHandler(this.chkSample_Click);
            // 
            // chkDelOld
            // 
            this.chkDelOld.Checked = true;
            this.chkDelOld.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelOld.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkDelOld.Location = new System.Drawing.Point(3, 57);
            this.chkDelOld.Name = "chkDelOld";
            this.chkDelOld.Size = new System.Drawing.Size(167, 20);
            this.chkDelOld.TabIndex = 4;
            this.chkDelOld.TabStop = false;
            this.chkDelOld.Text = "Delete Old Plot Grid";
            this.chkDelOld.CheckStateChanged += new System.EventHandler(this.chkDelOld_CheckStateChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(155, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.Text = "x";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txti2
            // 
            this.txti2.Location = new System.Drawing.Point(176, 7);
            this.txti2.Name = "txti2";
            this.txti2.Size = new System.Drawing.Size(50, 21);
            this.txti2.TabIndex = 1;
            this.txti2.TabStop = false;
            this.txti2.Text = "100";
            this.txti2.TextChanged += new System.EventHandler(this.txti2_TextChanged);
            this.txti2.GotFocus += new System.EventHandler(this.txti2_GotFocus);
            this.txti2.LostFocus += new System.EventHandler(this.txti2_LostFocus);
            // 
            // txtTilt
            // 
            this.txtTilt.Location = new System.Drawing.Point(176, 32);
            this.txtTilt.Name = "txtTilt";
            this.txtTilt.Size = new System.Drawing.Size(50, 21);
            this.txtTilt.TabIndex = 1;
            this.txtTilt.TabStop = false;
            this.txtTilt.Text = "<rand>";
            this.txtTilt.TextChanged += new System.EventHandler(this.txtTilt_TextChanged);
            this.txtTilt.GotFocus += new System.EventHandler(this.txtTilt_GotFocus);
            this.txtTilt.LostFocus += new System.EventHandler(this.txtTilt_LostFocus);
            // 
            // txtSample
            // 
            this.txtSample.Enabled = false;
            this.txtSample.Location = new System.Drawing.Point(333, 59);
            this.txtSample.Name = "txtSample";
            this.txtSample.Size = new System.Drawing.Size(50, 21);
            this.txtSample.TabIndex = 1;
            this.txtSample.TabStop = false;
            this.txtSample.TextChanged += new System.EventHandler(this.txtSample_TextChanged);
            this.txtSample.GotFocus += new System.EventHandler(this.txtSample_GotFocus);
            this.txtSample.LostFocus += new System.EventHandler(this.txtSample_LostFocus);
            // 
            // txti1
            // 
            this.txti1.Location = new System.Drawing.Point(98, 7);
            this.txti1.Name = "txti1";
            this.txti1.Size = new System.Drawing.Size(50, 21);
            this.txti1.TabIndex = 1;
            this.txti1.TabStop = false;
            this.txti1.Text = "100";
            this.txti1.TextChanged += new System.EventHandler(this.txti1_TextChanged);
            this.txti1.GotFocus += new System.EventHandler(this.txti1_GotFocus);
            this.txti1.LostFocus += new System.EventHandler(this.txti1_LostFocus);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(5, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 20);
            this.label7.Text = "Tilt Grid axis (-45 to +45):";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(5, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.Text = "Grid Interval:";
            // 
            // PlotGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Name = "PlotGridForm";
            this.Text = "Plot Grid";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboDist;
        private System.Windows.Forms.ComboBox cboLoc;
        private System.Windows.Forms.ComboBox cboPoly;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txti2;
        private System.Windows.Forms.TextBox txti1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTilt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkDelOld;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnDist;
        private System.Windows.Forms.Button btnPoly;
        private System.Windows.Forms.Button btnSample;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cboStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkSample;
        private System.Windows.Forms.TextBox txtSample;
        private System.Windows.Forms.ComboBox cboSample;
    }
}