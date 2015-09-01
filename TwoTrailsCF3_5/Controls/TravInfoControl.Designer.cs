namespace TwoTrails.Controls
{
    partial class TravInfoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxFAz = new System.Windows.Forms.TextBox();
            this.textBoxSlpDist = new System.Windows.Forms.TextBox();
            this.textBoxBAz = new System.Windows.Forms.TextBox();
            this.textBoxSlpAng = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMagDecl = new System.Windows.Forms.TextBox();
            this.radFA = new System.Windows.Forms.RadioButton();
            this.radBA = new System.Windows.Forms.RadioButton();
            this.lblDiff = new System.Windows.Forms.Label();
            this.lblDistUnit = new System.Windows.Forms.Label();
            this.lblSlopeUnit = new System.Windows.Forms.Label();
            this.lblLaser = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLaserActive = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFAz
            // 
            this.textBoxFAz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxFAz.Location = new System.Drawing.Point(37, 8);
            this.textBoxFAz.Name = "textBoxFAz";
            this.textBoxFAz.Size = new System.Drawing.Size(55, 21);
            this.textBoxFAz.TabIndex = 0;
            this.textBoxFAz.TextChanged += new System.EventHandler(this.textBoxFAz_TextChanged);
            this.textBoxFAz.GotFocus += new System.EventHandler(this.textBoxFAz_GotFocus);
            this.textBoxFAz.LostFocus += new System.EventHandler(this.textBoxFAz_LostFocus);
            // 
            // textBoxSlpDist
            // 
            this.textBoxSlpDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxSlpDist.Location = new System.Drawing.Point(58, 34);
            this.textBoxSlpDist.Name = "textBoxSlpDist";
            this.textBoxSlpDist.Size = new System.Drawing.Size(67, 21);
            this.textBoxSlpDist.TabIndex = 1;
            this.textBoxSlpDist.TextChanged += new System.EventHandler(this.textBoxSlpDist_TextChanged);
            this.textBoxSlpDist.GotFocus += new System.EventHandler(this.textBoxSlpDist_GotFocus);
            this.textBoxSlpDist.LostFocus += new System.EventHandler(this.textBoxSlpDist_LostFocus);
            // 
            // textBoxBAz
            // 
            this.textBoxBAz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxBAz.Location = new System.Drawing.Point(131, 8);
            this.textBoxBAz.Name = "textBoxBAz";
            this.textBoxBAz.Size = new System.Drawing.Size(55, 21);
            this.textBoxBAz.TabIndex = 2;
            this.textBoxBAz.TextChanged += new System.EventHandler(this.textBoxBAz_TextChanged);
            this.textBoxBAz.GotFocus += new System.EventHandler(this.textBoxBAz_GotFocus);
            this.textBoxBAz.LostFocus += new System.EventHandler(this.textBoxBAz_LostFocus);
            // 
            // textBoxSlpAng
            // 
            this.textBoxSlpAng.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSlpAng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxSlpAng.Location = new System.Drawing.Point(186, 35);
            this.textBoxSlpAng.Name = "textBoxSlpAng";
            this.textBoxSlpAng.Size = new System.Drawing.Size(46, 21);
            this.textBoxSlpAng.TabIndex = 3;
            this.textBoxSlpAng.TextChanged += new System.EventHandler(this.textBoxSlpAng_TextChanged);
            this.textBoxSlpAng.GotFocus += new System.EventHandler(this.textBoxSlpAng_GotFocus);
            this.textBoxSlpAng.LostFocus += new System.EventHandler(this.textBoxSlpAng_LostFocus);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.Text = "FAz:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(98, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.Text = "BAz:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.Text = "SlpDist:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(131, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.Text = "SlpAng:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(3, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 18);
            this.label5.Text = "Mag Decl Used:";
            // 
            // txtMagDecl
            // 
            this.txtMagDecl.BackColor = System.Drawing.Color.LightGray;
            this.txtMagDecl.Location = new System.Drawing.Point(110, 78);
            this.txtMagDecl.Name = "txtMagDecl";
            this.txtMagDecl.ReadOnly = true;
            this.txtMagDecl.Size = new System.Drawing.Size(52, 21);
            this.txtMagDecl.TabIndex = 5;
            // 
            // radFA
            // 
            this.radFA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radFA.Checked = true;
            this.radFA.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radFA.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radFA.Location = new System.Drawing.Point(54, 105);
            this.radFA.Name = "radFA";
            this.radFA.Size = new System.Drawing.Size(50, 20);
            this.radFA.TabIndex = 6;
            this.radFA.Text = "FA";
            // 
            // radBA
            // 
            this.radBA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radBA.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radBA.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radBA.Location = new System.Drawing.Point(110, 105);
            this.radBA.Name = "radBA";
            this.radBA.Size = new System.Drawing.Size(50, 20);
            this.radBA.TabIndex = 6;
            this.radBA.TabStop = false;
            this.radBA.Text = "BA";
            // 
            // lblDiff
            // 
            this.lblDiff.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiff.ForeColor = System.Drawing.Color.Red;
            this.lblDiff.Location = new System.Drawing.Point(192, 12);
            this.lblDiff.Name = "lblDiff";
            this.lblDiff.Size = new System.Drawing.Size(46, 21);
            this.lblDiff.Text = "D: 00";
            this.lblDiff.Visible = false;
            // 
            // lblDistUnit
            // 
            this.lblDistUnit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblDistUnit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblDistUnit.Location = new System.Drawing.Point(3, 56);
            this.lblDistUnit.Name = "lblDistUnit";
            this.lblDistUnit.Size = new System.Drawing.Size(108, 20);
            this.lblDistUnit.Text = "Feet Tenths";
            this.lblDistUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSlopeUnit
            // 
            this.lblSlopeUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSlopeUnit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblSlopeUnit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSlopeUnit.Location = new System.Drawing.Point(136, 58);
            this.lblSlopeUnit.Name = "lblSlopeUnit";
            this.lblSlopeUnit.Size = new System.Drawing.Size(96, 20);
            this.lblSlopeUnit.Text = "Percent";
            this.lblSlopeUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLaser
            // 
            this.lblLaser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblLaser.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLaser.Location = new System.Drawing.Point(3, 107);
            this.lblLaser.Name = "lblLaser";
            this.lblLaser.Size = new System.Drawing.Size(45, 18);
            this.lblLaser.Text = "Laser:";
            this.lblLaser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(181, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.Text = "Laser";
            // 
            // lblLaserActive
            // 
            this.lblLaserActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLaserActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblLaserActive.Location = new System.Drawing.Point(162, 105);
            this.lblLaserActive.Name = "lblLaserActive";
            this.lblLaserActive.Size = new System.Drawing.Size(71, 20);
            this.lblLaserActive.Text = "Not Active";
            this.lblLaserActive.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TravInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.lblLaserActive);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxSlpAng);
            this.Controls.Add(this.lblSlopeUnit);
            this.Controls.Add(this.lblDistUnit);
            this.Controls.Add(this.lblDiff);
            this.Controls.Add(this.radBA);
            this.Controls.Add(this.radFA);
            this.Controls.Add(this.txtMagDecl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBAz);
            this.Controls.Add(this.textBoxSlpDist);
            this.Controls.Add(this.textBoxFAz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLaser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Name = "TravInfoControl";
            this.Size = new System.Drawing.Size(240, 128);
            this.Click += new System.EventHandler(this.TravInfoControl_Click);
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.textBoxFAz = new System.Windows.Forms.TextBox();
            this.textBoxSlpDist = new System.Windows.Forms.TextBox();
            this.textBoxBAz = new System.Windows.Forms.TextBox();
            this.textBoxSlpAng = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMagDecl = new System.Windows.Forms.TextBox();
            this.radFA = new System.Windows.Forms.RadioButton();
            this.radBA = new System.Windows.Forms.RadioButton();
            this.lblDiff = new System.Windows.Forms.Label();
            this.lblDistUnit = new System.Windows.Forms.Label();
            this.lblSlopeUnit = new System.Windows.Forms.Label();
            this.lblLaser = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLaserActive = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFAz
            // 
            this.textBoxFAz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxFAz.Location = new System.Drawing.Point(37, 8);
            this.textBoxFAz.Name = "textBoxFAz";
            this.textBoxFAz.Size = new System.Drawing.Size(55, 21);
            this.textBoxFAz.TabIndex = 0;
            this.textBoxFAz.TextChanged += new System.EventHandler(this.textBoxFAz_TextChanged);
            this.textBoxFAz.GotFocus += new System.EventHandler(this.textBoxFAz_GotFocus);
            this.textBoxFAz.LostFocus += new System.EventHandler(this.textBoxFAz_LostFocus);
            // 
            // textBoxSlpDist
            // 
            this.textBoxSlpDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxSlpDist.Location = new System.Drawing.Point(58, 34);
            this.textBoxSlpDist.Name = "textBoxSlpDist";
            this.textBoxSlpDist.Size = new System.Drawing.Size(67, 21);
            this.textBoxSlpDist.TabIndex = 1;
            this.textBoxSlpDist.TextChanged += new System.EventHandler(this.textBoxSlpDist_TextChanged);
            this.textBoxSlpDist.GotFocus += new System.EventHandler(this.textBoxSlpDist_GotFocus);
            this.textBoxSlpDist.LostFocus += new System.EventHandler(this.textBoxSlpDist_LostFocus);
            // 
            // textBoxBAz
            // 
            this.textBoxBAz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxBAz.Location = new System.Drawing.Point(131, 8);
            this.textBoxBAz.Name = "textBoxBAz";
            this.textBoxBAz.Size = new System.Drawing.Size(55, 21);
            this.textBoxBAz.TabIndex = 2;
            this.textBoxBAz.TextChanged += new System.EventHandler(this.textBoxBAz_TextChanged);
            this.textBoxBAz.GotFocus += new System.EventHandler(this.textBoxBAz_GotFocus);
            this.textBoxBAz.LostFocus += new System.EventHandler(this.textBoxBAz_LostFocus);
            // 
            // textBoxSlpAng
            // 
            this.textBoxSlpAng.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSlpAng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxSlpAng.Location = new System.Drawing.Point(186, 35);
            this.textBoxSlpAng.Name = "textBoxSlpAng";
            this.textBoxSlpAng.Size = new System.Drawing.Size(46, 21);
            this.textBoxSlpAng.TabIndex = 3;
            this.textBoxSlpAng.TextChanged += new System.EventHandler(this.textBoxSlpAng_TextChanged);
            this.textBoxSlpAng.GotFocus += new System.EventHandler(this.textBoxSlpAng_GotFocus);
            this.textBoxSlpAng.LostFocus += new System.EventHandler(this.textBoxSlpAng_LostFocus);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.Text = "FAz:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(98, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.Text = "BAz:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.Text = "SlpDist:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(131, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.Text = "SlpAng:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(3, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 18);
            this.label5.Text = "Mag Decl Used:";
            // 
            // txtMagDecl
            // 
            this.txtMagDecl.BackColor = System.Drawing.Color.LightGray;
            this.txtMagDecl.Location = new System.Drawing.Point(110, 69);
            this.txtMagDecl.Name = "txtMagDecl";
            this.txtMagDecl.ReadOnly = true;
            this.txtMagDecl.Size = new System.Drawing.Size(52, 21);
            this.txtMagDecl.TabIndex = 5;
            // 
            // radFA
            // 
            this.radFA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radFA.Checked = true;
            this.radFA.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radFA.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radFA.Location = new System.Drawing.Point(54, 92);
            this.radFA.Name = "radFA";
            this.radFA.Size = new System.Drawing.Size(50, 20);
            this.radFA.TabIndex = 6;
            this.radFA.Text = "FA";
            // 
            // radBA
            // 
            this.radBA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radBA.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radBA.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radBA.Location = new System.Drawing.Point(110, 92);
            this.radBA.Name = "radBA";
            this.radBA.Size = new System.Drawing.Size(50, 20);
            this.radBA.TabIndex = 6;
            this.radBA.TabStop = false;
            this.radBA.Text = "BA";
            // 
            // lblDiff
            // 
            this.lblDiff.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiff.ForeColor = System.Drawing.Color.Red;
            this.lblDiff.Location = new System.Drawing.Point(192, 12);
            this.lblDiff.Name = "lblDiff";
            this.lblDiff.Size = new System.Drawing.Size(46, 21);
            this.lblDiff.Text = "D: 00";
            this.lblDiff.Visible = false;
            // 
            // lblDistUnit
            // 
            this.lblDistUnit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblDistUnit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblDistUnit.Location = new System.Drawing.Point(17, 56);
            this.lblDistUnit.Name = "lblDistUnit";
            this.lblDistUnit.Size = new System.Drawing.Size(108, 20);
            this.lblDistUnit.Text = "Feet Tenths";
            this.lblDistUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSlopeUnit
            // 
            this.lblSlopeUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSlopeUnit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblSlopeUnit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSlopeUnit.Location = new System.Drawing.Point(131, 58);
            this.lblSlopeUnit.Name = "lblSlopeUnit";
            this.lblSlopeUnit.Size = new System.Drawing.Size(101, 20);
            this.lblSlopeUnit.Text = "Percent";
            this.lblSlopeUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLaser
            // 
            this.lblLaser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblLaser.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLaser.Location = new System.Drawing.Point(3, 94);
            this.lblLaser.Name = "lblLaser";
            this.lblLaser.Size = new System.Drawing.Size(45, 18);
            this.lblLaser.Text = "Laser:";
            this.lblLaser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(179, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.Text = "Laser";
            // 
            // lblLaserActive
            // 
            this.lblLaserActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLaserActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblLaserActive.Location = new System.Drawing.Point(166, 94);
            this.lblLaserActive.Name = "lblLaserActive";
            this.lblLaserActive.Size = new System.Drawing.Size(71, 20);
            this.lblLaserActive.Text = "Not Active";
            this.lblLaserActive.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TravInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.lblLaserActive);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMagDecl);
            this.Controls.Add(this.textBoxSlpAng);
            this.Controls.Add(this.lblSlopeUnit);
            this.Controls.Add(this.lblDistUnit);
            this.Controls.Add(this.lblDiff);
            this.Controls.Add(this.radBA);
            this.Controls.Add(this.radFA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBAz);
            this.Controls.Add(this.textBoxSlpDist);
            this.Controls.Add(this.textBoxFAz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLaser);
            this.Controls.Add(this.label3);
            this.Name = "TravInfoControl";
            this.Size = new System.Drawing.Size(240, 116);
            this.Click += new System.EventHandler(this.TravInfoControl_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFAz;
        private System.Windows.Forms.TextBox textBoxSlpDist;
        private System.Windows.Forms.TextBox textBoxBAz;
        private System.Windows.Forms.TextBox textBoxSlpAng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMagDecl;
        private System.Windows.Forms.RadioButton radFA;
        private System.Windows.Forms.RadioButton radBA;
        private System.Windows.Forms.Label lblDiff;
        private System.Windows.Forms.Label lblDistUnit;
        private System.Windows.Forms.Label lblSlopeUnit;
        private System.Windows.Forms.Label lblLaser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLaserActive;
    }
}
