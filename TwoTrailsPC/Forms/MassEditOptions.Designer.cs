namespace TwoTrails.Forms
{
    partial class MassEditOptions
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
            this.chkAltRows = new System.Windows.Forms.CheckBox();
            this.chkRowColors = new System.Windows.Forms.CheckBox();
            this.chkAutoClosePolys = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.radElevMeters = new System.Windows.Forms.RadioButton();
            this.radElevFeet = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(5, 139);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkAltRows
            // 
            this.chkAltRows.AutoSize = true;
            this.chkAltRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAltRows.Location = new System.Drawing.Point(12, 12);
            this.chkAltRows.Name = "chkAltRows";
            this.chkAltRows.Size = new System.Drawing.Size(122, 19);
            this.chkAltRows.TabIndex = 1;
            this.chkAltRows.TabStop = false;
            this.chkAltRows.Text = "Alternate Rows";
            this.chkAltRows.UseVisualStyleBackColor = true;
            this.chkAltRows.CheckedChanged += new System.EventHandler(this.chkAltRows_CheckedChanged);
            // 
            // chkRowColors
            // 
            this.chkRowColors.AutoSize = true;
            this.chkRowColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRowColors.Location = new System.Drawing.Point(12, 37);
            this.chkRowColors.Name = "chkRowColors";
            this.chkRowColors.Size = new System.Drawing.Size(99, 19);
            this.chkRowColors.TabIndex = 1;
            this.chkRowColors.TabStop = false;
            this.chkRowColors.Text = "Row Colors";
            this.chkRowColors.UseVisualStyleBackColor = true;
            this.chkRowColors.CheckedChanged += new System.EventHandler(this.chkRowColors_CheckedChanged);
            // 
            // chkAutoClosePolys
            // 
            this.chkAutoClosePolys.AutoSize = true;
            this.chkAutoClosePolys.Enabled = false;
            this.chkAutoClosePolys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoClosePolys.Location = new System.Drawing.Point(12, 62);
            this.chkAutoClosePolys.Name = "chkAutoClosePolys";
            this.chkAutoClosePolys.Size = new System.Drawing.Size(174, 19);
            this.chkAutoClosePolys.TabIndex = 1;
            this.chkAutoClosePolys.TabStop = false;
            this.chkAutoClosePolys.Text = "Auto Close Poly on Dist";
            this.chkAutoClosePolys.UseVisualStyleBackColor = true;
            this.chkAutoClosePolys.CheckedChanged += new System.EventHandler(this.chkAutoClosePolys_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.radElevMeters);
            this.panel2.Controls.Add(this.radElevFeet);
            this.panel2.Location = new System.Drawing.Point(5, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(151, 46);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Elevation:";
            // 
            // radElevMeters
            // 
            this.radElevMeters.AutoSize = true;
            this.radElevMeters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radElevMeters.Location = new System.Drawing.Point(71, 23);
            this.radElevMeters.Name = "radElevMeters";
            this.radElevMeters.Size = new System.Drawing.Size(69, 19);
            this.radElevMeters.TabIndex = 0;
            this.radElevMeters.Text = "Meters";
            this.radElevMeters.UseVisualStyleBackColor = true;
            // 
            // radElevFeet
            // 
            this.radElevFeet.AutoSize = true;
            this.radElevFeet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radElevFeet.Location = new System.Drawing.Point(12, 23);
            this.radElevFeet.Name = "radElevFeet";
            this.radElevFeet.Size = new System.Drawing.Size(53, 19);
            this.radElevFeet.TabIndex = 0;
            this.radElevFeet.Text = "Feet";
            this.radElevFeet.UseVisualStyleBackColor = true;
            this.radElevFeet.CheckedChanged += new System.EventHandler(this.radElevFeet_CheckedChanged);
            // 
            // MassEditOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 167);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chkAutoClosePolys);
            this.Controls.Add(this.chkRowColors);
            this.Controls.Add(this.chkAltRows);
            this.Controls.Add(this.btnClose);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(326, 205);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(326, 205);
            this.Name = "MassEditOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Multi Point Edit Options";
            this.Load += new System.EventHandler(this.MassEditOptions_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkAltRows;
        private System.Windows.Forms.CheckBox chkRowColors;
        private System.Windows.Forms.CheckBox chkAutoClosePolys;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radElevMeters;
        private System.Windows.Forms.RadioButton radElevFeet;
    }
}