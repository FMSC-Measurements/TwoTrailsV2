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
            this.label1 = new System.Windows.Forms.Label();
            this.chkDelOld = new System.Windows.Forms.CheckBox();
            this.txti1 = new System.Windows.Forms.TextBox();
            this.txtSample = new System.Windows.Forms.TextBox();
            this.cboLoc = new System.Windows.Forms.ComboBox();
            this.cboPoly = new System.Windows.Forms.ComboBox();
            this.cboDist = new System.Windows.Forms.ComboBox();
            this.cboStart = new System.Windows.Forms.ComboBox();
            this.cboSample = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txti2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTilt = new System.Windows.Forms.TextBox();
            this.chkSample = new System.Windows.Forms.CheckBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location";
            // 
            // chkDelOld
            // 
            this.chkDelOld.AutoSize = true;
            this.chkDelOld.Checked = true;
            this.chkDelOld.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDelOld.Location = new System.Drawing.Point(22, 173);
            this.chkDelOld.Name = "chkDelOld";
            this.chkDelOld.Size = new System.Drawing.Size(154, 19);
            this.chkDelOld.TabIndex = 7;
            this.chkDelOld.Text = "Delete Old Plot Grid";
            this.chkDelOld.UseVisualStyleBackColor = true;
            this.chkDelOld.CheckedChanged += new System.EventHandler(this.chkDelOld_CheckedChanged);
            // 
            // txti1
            // 
            this.txti1.Location = new System.Drawing.Point(103, 121);
            this.txti1.Name = "txti1";
            this.txti1.Size = new System.Drawing.Size(50, 20);
            this.txti1.TabIndex = 4;
            this.txti1.TextChanged += new System.EventHandler(this.txti1_TextChanged);
            // 
            // txtSample
            // 
            this.txtSample.Enabled = false;
            this.txtSample.Location = new System.Drawing.Point(194, 197);
            this.txtSample.Name = "txtSample";
            this.txtSample.Size = new System.Drawing.Size(30, 20);
            this.txtSample.TabIndex = 10;
            this.txtSample.TextChanged += new System.EventHandler(this.txtSample_TextChanged);
            // 
            // cboLoc
            // 
            this.cboLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoc.FormattingEnabled = true;
            this.cboLoc.Location = new System.Drawing.Point(103, 40);
            this.cboLoc.Name = "cboLoc";
            this.cboLoc.Size = new System.Drawing.Size(121, 21);
            this.cboLoc.TabIndex = 0;
            this.cboLoc.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);
            // 
            // cboPoly
            // 
            this.cboPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPoly.FormattingEnabled = true;
            this.cboPoly.Location = new System.Drawing.Point(103, 12);
            this.cboPoly.Name = "cboPoly";
            this.cboPoly.Size = new System.Drawing.Size(121, 21);
            this.cboPoly.TabIndex = 1;
            this.cboPoly.SelectedIndexChanged += new System.EventHandler(this.cboPoly_SelectedIndexChanged);
            // 
            // cboDist
            // 
            this.cboDist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDist.FormattingEnabled = true;
            this.cboDist.Location = new System.Drawing.Point(103, 67);
            this.cboDist.Name = "cboDist";
            this.cboDist.Size = new System.Drawing.Size(121, 21);
            this.cboDist.TabIndex = 2;
            this.cboDist.SelectedIndexChanged += new System.EventHandler(this.cboDist_SelectedIndexChanged);
            // 
            // cboStart
            // 
            this.cboStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStart.FormattingEnabled = true;
            this.cboStart.Location = new System.Drawing.Point(103, 94);
            this.cboStart.Name = "cboStart";
            this.cboStart.Size = new System.Drawing.Size(121, 21);
            this.cboStart.TabIndex = 3;
            this.cboStart.SelectedIndexChanged += new System.EventHandler(this.cboStart_SelectedIndexChanged);
            // 
            // cboSample
            // 
            this.cboSample.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSample.Enabled = false;
            this.cboSample.FormattingEnabled = true;
            this.cboSample.Location = new System.Drawing.Point(126, 197);
            this.cboSample.Name = "cboSample";
            this.cboSample.Size = new System.Drawing.Size(62, 21);
            this.cboSample.TabIndex = 9;
            this.cboSample.SelectedIndexChanged += new System.EventHandler(this.cboSample_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Polygon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Distance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Start Point";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Grid Interval";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(158, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "x";
            // 
            // txti2
            // 
            this.txti2.Location = new System.Drawing.Point(174, 122);
            this.txti2.Name = "txti2";
            this.txti2.Size = new System.Drawing.Size(50, 20);
            this.txti2.TabIndex = 5;
            this.txti2.TextChanged += new System.EventHandler(this.txti2_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tilt Grid Axis (-45 to +45)";
            // 
            // txtTilt
            // 
            this.txtTilt.Location = new System.Drawing.Point(174, 147);
            this.txtTilt.Name = "txtTilt";
            this.txtTilt.Size = new System.Drawing.Size(50, 20);
            this.txtTilt.TabIndex = 6;
            this.txtTilt.TextChanged += new System.EventHandler(this.txtTilt_TextChanged);
            // 
            // chkSample
            // 
            this.chkSample.AutoSize = true;
            this.chkSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSample.Location = new System.Drawing.Point(22, 198);
            this.chkSample.Name = "chkSample";
            this.chkSample.Size = new System.Drawing.Size(98, 19);
            this.chkSample.TabIndex = 8;
            this.chkSample.Text = "Subsample";
            this.chkSample.UseVisualStyleBackColor = true;
            this.chkSample.CheckedChanged += new System.EventHandler(this.chkSample_CheckedChanged);
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(149, 225);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(75, 23);
            this.btnPlot.TabIndex = 11;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 225);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PlotGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 257);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.cboSample);
            this.Controls.Add(this.cboStart);
            this.Controls.Add(this.cboDist);
            this.Controls.Add(this.cboPoly);
            this.Controls.Add(this.cboLoc);
            this.Controls.Add(this.txtSample);
            this.Controls.Add(this.txti2);
            this.Controls.Add(this.txtTilt);
            this.Controls.Add(this.txti1);
            this.Controls.Add(this.chkSample);
            this.Controls.Add(this.chkDelOld);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 295);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 295);
            this.Name = "PlotGridForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Plot Grid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDelOld;
        private System.Windows.Forms.TextBox txti1;
        private System.Windows.Forms.TextBox txtSample;
        private System.Windows.Forms.ComboBox cboLoc;
        private System.Windows.Forms.ComboBox cboPoly;
        private System.Windows.Forms.ComboBox cboDist;
        private System.Windows.Forms.ComboBox cboStart;
        private System.Windows.Forms.ComboBox cboSample;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txti2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTilt;
        private System.Windows.Forms.CheckBox chkSample;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnClose;
    }
}