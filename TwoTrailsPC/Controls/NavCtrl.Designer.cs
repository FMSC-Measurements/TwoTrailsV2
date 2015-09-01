namespace TwoTrails.Controls
{
    partial class NavCtrl
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
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDistToGo = new System.Windows.Forms.Label();
            this.lblFpm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlDraw
            // 
            this.pnlDraw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDraw.Location = new System.Drawing.Point(0, 0);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(277, 278);
            this.pnlDraw.TabIndex = 0;
            this.pnlDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDraw_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dist To Go:";
            // 
            // lblDistToGo
            // 
            this.lblDistToGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDistToGo.AutoSize = true;
            this.lblDistToGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistToGo.Location = new System.Drawing.Point(95, 281);
            this.lblDistToGo.Name = "lblDistToGo";
            this.lblDistToGo.Size = new System.Drawing.Size(68, 16);
            this.lblDistToGo.TabIndex = 1;
            this.lblDistToGo.Text = "00000.00";
            // 
            // lblFpm
            // 
            this.lblFpm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFpm.AutoSize = true;
            this.lblFpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFpm.Location = new System.Drawing.Point(198, 281);
            this.lblFpm.Name = "lblFpm";
            this.lblFpm.Size = new System.Drawing.Size(40, 16);
            this.lblFpm.TabIndex = 1;
            this.lblFpm.Text = "        ";
            this.lblFpm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NavCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFpm);
            this.Controls.Add(this.lblDistToGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlDraw);
            this.Name = "NavCtrl";
            this.Size = new System.Drawing.Size(277, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDistToGo;
        private System.Windows.Forms.Label lblFpm;
    }
}
