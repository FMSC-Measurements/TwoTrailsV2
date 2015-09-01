namespace TwoTrails.Forms
{
    partial class QuondamRetraceForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRetrace = new System.Windows.Forms.Button();
            this.cboPoly = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstPoint1 = new System.Windows.Forms.ListBox();
            this.lstPoint2 = new System.Windows.Forms.ListBox();
            this.radUp = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.radDown = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPoly = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRetrace
            // 
            this.btnRetrace.Enabled = false;
            this.btnRetrace.Location = new System.Drawing.Point(155, 266);
            this.btnRetrace.Name = "btnRetrace";
            this.btnRetrace.Size = new System.Drawing.Size(82, 25);
            this.btnRetrace.TabIndex = 0;
            this.btnRetrace.TabStop = false;
            this.btnRetrace.Text = "Retrace";
            this.btnRetrace.Click += new System.EventHandler(this.btnRetrace_Click);
            // 
            // cboPoly
            // 
            this.cboPoly.Location = new System.Drawing.Point(131, 34);
            this.cboPoly.Name = "cboPoly";
            this.cboPoly.Size = new System.Drawing.Size(109, 22);
            this.cboPoly.TabIndex = 1;
            this.cboPoly.TabStop = false;
            this.cboPoly.SelectedIndexChanged += new System.EventHandler(this.cboPoly_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 20);
            this.label1.Text = "Retrace";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lstPoint1
            // 
            this.lstPoint1.Location = new System.Drawing.Point(0, 60);
            this.lstPoint1.Name = "lstPoint1";
            this.lstPoint1.Size = new System.Drawing.Size(240, 86);
            this.lstPoint1.TabIndex = 3;
            this.lstPoint1.TabStop = false;
            this.lstPoint1.SelectedIndexChanged += new System.EventHandler(this.lstPoint1_SelectedIndexChanged);
            // 
            // lstPoint2
            // 
            this.lstPoint2.Location = new System.Drawing.Point(0, 174);
            this.lstPoint2.Name = "lstPoint2";
            this.lstPoint2.Size = new System.Drawing.Size(240, 86);
            this.lstPoint2.TabIndex = 3;
            this.lstPoint2.TabStop = false;
            this.lstPoint2.SelectedIndexChanged += new System.EventHandler(this.lstPoint2_SelectedIndexChanged);
            // 
            // radUp
            // 
            this.radUp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.radUp.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radUp.Location = new System.Drawing.Point(28, 151);
            this.radUp.Name = "radUp";
            this.radUp.Size = new System.Drawing.Size(100, 20);
            this.radUp.TabIndex = 5;
            this.radUp.TabStop = false;
            this.radUp.Text = "Up";
            this.radUp.CheckedChanged += new System.EventHandler(this.radUp_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(3, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.Text = "Dir:";
            // 
            // radDown
            // 
            this.radDown.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.radDown.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radDown.Location = new System.Drawing.Point(131, 151);
            this.radDown.Name = "radDown";
            this.radDown.Size = new System.Drawing.Size(106, 20);
            this.radDown.TabIndex = 5;
            this.radDown.TabStop = false;
            this.radDown.Text = "Down";
            this.radDown.CheckedChanged += new System.EventHandler(this.radDown_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(70, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.Text = "Polygon:";
            // 
            // btnPoly
            // 
            this.btnPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPoly.Location = new System.Drawing.Point(131, 34);
            this.btnPoly.Name = "btnPoly";
            this.btnPoly.Size = new System.Drawing.Size(109, 22);
            this.btnPoly.TabIndex = 8;
            this.btnPoly.TabStop = false;
            this.btnPoly.Click += new System.EventHandler(this.btnPoly_Click);
            // 
            // QuondamRetraceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.radUp);
            this.Controls.Add(this.btnPoly);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radDown);
            this.Controls.Add(this.lstPoint2);
            this.Controls.Add(this.lstPoint1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPoly);
            this.Controls.Add(this.btnRetrace);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Name = "QuondamRetraceForm";
            this.Text = "Quondam Retrace";
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRetrace = new System.Windows.Forms.Button();
            this.cboPoly = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstPoint1 = new System.Windows.Forms.ListBox();
            this.lstPoint2 = new System.Windows.Forms.ListBox();
            this.radUp = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.radDown = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPoly = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRetrace
            // 
            this.btnRetrace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrace.Enabled = false;
            this.btnRetrace.Location = new System.Drawing.Point(235, 186);
            this.btnRetrace.Name = "btnRetrace";
            this.btnRetrace.Size = new System.Drawing.Size(82, 25);
            this.btnRetrace.TabIndex = 0;
            this.btnRetrace.TabStop = false;
            this.btnRetrace.Text = "Retrace";
            this.btnRetrace.Click += new System.EventHandler(this.btnRetrace_Click);
            // 
            // cboPoly
            // 
            this.cboPoly.Location = new System.Drawing.Point(211, 4);
            this.cboPoly.Name = "cboPoly";
            this.cboPoly.Size = new System.Drawing.Size(109, 22);
            this.cboPoly.TabIndex = 1;
            this.cboPoly.TabStop = false;
            this.cboPoly.SelectedIndexChanged += new System.EventHandler(this.cboPoly_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.Text = "Retrace";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lstPoint1
            // 
            this.lstPoint1.Location = new System.Drawing.Point(0, 29);
            this.lstPoint1.Name = "lstPoint1";
            this.lstPoint1.Size = new System.Drawing.Size(158, 128);
            this.lstPoint1.TabIndex = 3;
            this.lstPoint1.TabStop = false;
            this.lstPoint1.SelectedIndexChanged += new System.EventHandler(this.lstPoint1_SelectedIndexChanged);
            // 
            // lstPoint2
            // 
            this.lstPoint2.Location = new System.Drawing.Point(162, 29);
            this.lstPoint2.Name = "lstPoint2";
            this.lstPoint2.Size = new System.Drawing.Size(158, 128);
            this.lstPoint2.TabIndex = 3;
            this.lstPoint2.TabStop = false;
            this.lstPoint2.SelectedIndexChanged += new System.EventHandler(this.lstPoint2_SelectedIndexChanged);
            // 
            // radUp
            // 
            this.radUp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radUp.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radUp.Location = new System.Drawing.Point(79, 158);
            this.radUp.Name = "radUp";
            this.radUp.Size = new System.Drawing.Size(46, 20);
            this.radUp.TabIndex = 5;
            this.radUp.TabStop = false;
            this.radUp.Text = "Up";
            this.radUp.CheckedChanged += new System.EventHandler(this.radUp_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(3, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.Text = "Direction:";
            // 
            // radDown
            // 
            this.radDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radDown.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radDown.Location = new System.Drawing.Point(131, 158);
            this.radDown.Name = "radDown";
            this.radDown.Size = new System.Drawing.Size(77, 20);
            this.radDown.TabIndex = 5;
            this.radDown.TabStop = false;
            this.radDown.Text = "Down";
            this.radDown.CheckedChanged += new System.EventHandler(this.radDown_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(150, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.Text = "Polygon:";
            // 
            // btnPoly
            // 
            this.btnPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPoly.Location = new System.Drawing.Point(211, 4);
            this.btnPoly.Name = "btnPoly";
            this.btnPoly.Size = new System.Drawing.Size(109, 22);
            this.btnPoly.TabIndex = 8;
            this.btnPoly.TabStop = false;
            this.btnPoly.Click += new System.EventHandler(this.btnPoly_Click);
            // 
            // QuondamRetraceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.ControlBox = false;
            this.Controls.Add(this.btnPoly);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radDown);
            this.Controls.Add(this.radUp);
            this.Controls.Add(this.lstPoint2);
            this.Controls.Add(this.lstPoint1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPoly);
            this.Controls.Add(this.btnRetrace);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Name = "QuondamRetraceForm";
            this.Text = "Quondam Retrace";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRetrace;
        private System.Windows.Forms.ComboBox cboPoly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstPoint1;
        private System.Windows.Forms.ListBox lstPoint2;
        private System.Windows.Forms.RadioButton radUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPoly;
    }
}