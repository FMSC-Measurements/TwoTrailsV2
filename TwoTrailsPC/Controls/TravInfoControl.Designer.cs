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
            this.textBoxBAz = new System.Windows.Forms.TextBox();
            this.textBoxSlpAng = new System.Windows.Forms.TextBox();
            this.textBoxSlpDist = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDistUnit = new System.Windows.Forms.Label();
            this.lblSlopeUnit = new System.Windows.Forms.Label();
            this.txtMagDecl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLaser = new System.Windows.Forms.Label();
            this.radFA = new System.Windows.Forms.RadioButton();
            this.radBA = new System.Windows.Forms.RadioButton();
            this.lblDiff = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLaserActive = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFAz
            // 
            this.textBoxFAz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFAz.Location = new System.Drawing.Point(70, 3);
            this.textBoxFAz.Name = "textBoxFAz";
            this.textBoxFAz.Size = new System.Drawing.Size(60, 22);
            this.textBoxFAz.TabIndex = 0;
            this.textBoxFAz.TextChanged += new System.EventHandler(this.textBoxFAz_TextChanged);
            this.textBoxFAz.GotFocus += new System.EventHandler(this.textBoxFAz_GotFocus);
            // 
            // textBoxBAz
            // 
            this.textBoxBAz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBAz.Location = new System.Drawing.Point(211, 3);
            this.textBoxBAz.Name = "textBoxBAz";
            this.textBoxBAz.Size = new System.Drawing.Size(60, 22);
            this.textBoxBAz.TabIndex = 1;
            this.textBoxBAz.TextChanged += new System.EventHandler(this.textBoxBAz_TextChanged);
            this.textBoxBAz.GotFocus += new System.EventHandler(this.textBoxBAz_GotFocus);
            // 
            // textBoxSlpAng
            // 
            this.textBoxSlpAng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSlpAng.Location = new System.Drawing.Point(267, 31);
            this.textBoxSlpAng.Name = "textBoxSlpAng";
            this.textBoxSlpAng.Size = new System.Drawing.Size(60, 22);
            this.textBoxSlpAng.TabIndex = 3;
            this.textBoxSlpAng.TextChanged += new System.EventHandler(this.textBoxSlpAng_TextChanged);
            this.textBoxSlpAng.GotFocus += new System.EventHandler(this.textBoxSlpAng_GotFocus);
            // 
            // textBoxSlpDist
            // 
            this.textBoxSlpDist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSlpDist.Location = new System.Drawing.Point(93, 31);
            this.textBoxSlpDist.Name = "textBoxSlpDist";
            this.textBoxSlpDist.Size = new System.Drawing.Size(80, 22);
            this.textBoxSlpDist.TabIndex = 2;
            this.textBoxSlpDist.TextChanged += new System.EventHandler(this.textBoxSlpDist_TextChanged);
            this.textBoxSlpDist.GotFocus += new System.EventHandler(this.textBoxSlpDist_GotFocus);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fwd Az:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Back Az:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Slope Dist:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(179, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Slope Ang:";
            // 
            // lblDistUnit
            // 
            this.lblDistUnit.AutoSize = true;
            this.lblDistUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistUnit.Location = new System.Drawing.Point(53, 56);
            this.lblDistUnit.Name = "lblDistUnit";
            this.lblDistUnit.Size = new System.Drawing.Size(64, 13);
            this.lblDistUnit.TabIndex = 1;
            this.lblDistUnit.Text = "Feet Tenths";
            // 
            // lblSlopeUnit
            // 
            this.lblSlopeUnit.AutoSize = true;
            this.lblSlopeUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlopeUnit.Location = new System.Drawing.Point(227, 56);
            this.lblSlopeUnit.Name = "lblSlopeUnit";
            this.lblSlopeUnit.Size = new System.Drawing.Size(44, 13);
            this.lblSlopeUnit.TabIndex = 1;
            this.lblSlopeUnit.Text = "Percent";
            // 
            // txtMagDecl
            // 
            this.txtMagDecl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMagDecl.Location = new System.Drawing.Point(124, 76);
            this.txtMagDecl.Name = "txtMagDecl";
            this.txtMagDecl.ReadOnly = true;
            this.txtMagDecl.Size = new System.Drawing.Size(80, 22);
            this.txtMagDecl.TabIndex = 0;
            this.txtMagDecl.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mag Dec Used:";
            // 
            // lblLaser
            // 
            this.lblLaser.AutoSize = true;
            this.lblLaser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaser.Location = new System.Drawing.Point(10, 106);
            this.lblLaser.Name = "lblLaser";
            this.lblLaser.Size = new System.Drawing.Size(51, 16);
            this.lblLaser.TabIndex = 1;
            this.lblLaser.Text = "Laser:";
            // 
            // radFA
            // 
            this.radFA.AutoSize = true;
            this.radFA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFA.Location = new System.Drawing.Point(67, 104);
            this.radFA.Name = "radFA";
            this.radFA.Size = new System.Drawing.Size(54, 20);
            this.radFA.TabIndex = 2;
            this.radFA.Text = "Fwd";
            this.radFA.UseVisualStyleBackColor = true;
            // 
            // radBA
            // 
            this.radBA.AutoSize = true;
            this.radBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBA.Location = new System.Drawing.Point(124, 104);
            this.radBA.Name = "radBA";
            this.radBA.Size = new System.Drawing.Size(44, 20);
            this.radBA.TabIndex = 2;
            this.radBA.Text = "Bk";
            this.radBA.UseVisualStyleBackColor = true;
            // 
            // lblDiff
            // 
            this.lblDiff.AutoSize = true;
            this.lblDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiff.ForeColor = System.Drawing.Color.Red;
            this.lblDiff.Location = new System.Drawing.Point(277, 6);
            this.lblDiff.Name = "lblDiff";
            this.lblDiff.Size = new System.Drawing.Size(43, 16);
            this.lblDiff.TabIndex = 1;
            this.lblDiff.Text = "D: 00";
            this.lblDiff.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(264, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Laser";
            // 
            // lblLaserActive
            // 
            this.lblLaserActive.AutoSize = true;
            this.lblLaserActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaserActive.Location = new System.Drawing.Point(248, 100);
            this.lblLaserActive.Name = "lblLaserActive";
            this.lblLaserActive.Size = new System.Drawing.Size(79, 16);
            this.lblLaserActive.TabIndex = 1;
            this.lblLaserActive.Text = "Not Active";
            this.lblLaserActive.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TravInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radBA);
            this.Controls.Add(this.radFA);
            this.Controls.Add(this.lblDiff);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSlopeUnit);
            this.Controls.Add(this.lblDistUnit);
            this.Controls.Add(this.lblLaserActive);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLaser);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMagDecl);
            this.Controls.Add(this.textBoxSlpDist);
            this.Controls.Add(this.textBoxSlpAng);
            this.Controls.Add(this.textBoxBAz);
            this.Controls.Add(this.textBoxFAz);
            this.Name = "TravInfoControl";
            this.Size = new System.Drawing.Size(330, 130);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFAz;
        private System.Windows.Forms.TextBox textBoxBAz;
        private System.Windows.Forms.TextBox textBoxSlpAng;
        private System.Windows.Forms.TextBox textBoxSlpDist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDistUnit;
        private System.Windows.Forms.Label lblSlopeUnit;
        private System.Windows.Forms.TextBox txtMagDecl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLaser;
        private System.Windows.Forms.RadioButton radFA;
        private System.Windows.Forms.RadioButton radBA;
        private System.Windows.Forms.Label lblDiff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLaserActive;
    }
}
