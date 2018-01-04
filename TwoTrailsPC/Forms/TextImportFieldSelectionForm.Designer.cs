namespace TwoTrails.Forms
{
    partial class TextImportFieldSelectionForm
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
            this.cboPID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboX = new System.Windows.Forms.ComboBox();
            this.lblX = new System.Windows.Forms.Label();
            this.cboY = new System.Windows.Forms.ComboBox();
            this.cboZ = new System.Windows.Forms.ComboBox();
            this.lblY = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.cboCmt = new System.Windows.Forms.ComboBox();
            this.cboOnBnd = new System.Windows.Forms.ComboBox();
            this.cboPoly = new System.Windows.Forms.ComboBox();
            this.cboIndex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnParse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radUTM = new System.Windows.Forms.RadioButton();
            this.radLatLon = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radMeters = new System.Windows.Forms.RadioButton();
            this.radFeet = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPID
            // 
            this.cboPID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPID.FormattingEnabled = true;
            this.cboPID.Location = new System.Drawing.Point(16, 34);
            this.cboPID.Margin = new System.Windows.Forms.Padding(4);
            this.cboPID.Name = "cboPID";
            this.cboPID.Size = new System.Drawing.Size(160, 24);
            this.cboPID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "PID";
            // 
            // cboX
            // 
            this.cboX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboX.FormattingEnabled = true;
            this.cboX.Location = new System.Drawing.Point(185, 34);
            this.cboX.Margin = new System.Windows.Forms.Padding(4);
            this.cboX.Name = "cboX";
            this.cboX.Size = new System.Drawing.Size(160, 24);
            this.cboX.TabIndex = 0;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Location = new System.Drawing.Point(185, 11);
            this.lblX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(21, 20);
            this.lblX.TabIndex = 1;
            this.lblX.Text = "X";
            // 
            // cboY
            // 
            this.cboY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboY.FormattingEnabled = true;
            this.cboY.Location = new System.Drawing.Point(355, 34);
            this.cboY.Margin = new System.Windows.Forms.Padding(4);
            this.cboY.Name = "cboY";
            this.cboY.Size = new System.Drawing.Size(160, 24);
            this.cboY.TabIndex = 0;
            // 
            // cboZ
            // 
            this.cboZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZ.FormattingEnabled = true;
            this.cboZ.Location = new System.Drawing.Point(524, 34);
            this.cboZ.Margin = new System.Windows.Forms.Padding(4);
            this.cboZ.Name = "cboZ";
            this.cboZ.Size = new System.Drawing.Size(160, 24);
            this.cboZ.TabIndex = 0;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.Location = new System.Drawing.Point(355, 11);
            this.lblY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(20, 20);
            this.lblY.TabIndex = 1;
            this.lblY.Text = "Y";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZ.Location = new System.Drawing.Point(524, 11);
            this.lblZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(19, 20);
            this.lblZ.TabIndex = 1;
            this.lblZ.Text = "Z";
            // 
            // cboCmt
            // 
            this.cboCmt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCmt.FormattingEnabled = true;
            this.cboCmt.Location = new System.Drawing.Point(16, 87);
            this.cboCmt.Margin = new System.Windows.Forms.Padding(4);
            this.cboCmt.Name = "cboCmt";
            this.cboCmt.Size = new System.Drawing.Size(160, 24);
            this.cboCmt.TabIndex = 0;
            // 
            // cboOnBnd
            // 
            this.cboOnBnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOnBnd.FormattingEnabled = true;
            this.cboOnBnd.Location = new System.Drawing.Point(355, 87);
            this.cboOnBnd.Margin = new System.Windows.Forms.Padding(4);
            this.cboOnBnd.Name = "cboOnBnd";
            this.cboOnBnd.Size = new System.Drawing.Size(160, 24);
            this.cboOnBnd.TabIndex = 0;
            // 
            // cboPoly
            // 
            this.cboPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPoly.FormattingEnabled = true;
            this.cboPoly.Location = new System.Drawing.Point(185, 87);
            this.cboPoly.Margin = new System.Windows.Forms.Padding(4);
            this.cboPoly.Name = "cboPoly";
            this.cboPoly.Size = new System.Drawing.Size(160, 24);
            this.cboPoly.TabIndex = 0;
            // 
            // cboIndex
            // 
            this.cboIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndex.FormattingEnabled = true;
            this.cboIndex.Location = new System.Drawing.Point(524, 87);
            this.cboIndex.Margin = new System.Windows.Forms.Padding(4);
            this.cboIndex.Name = "cboIndex";
            this.cboIndex.Size = new System.Drawing.Size(160, 24);
            this.cboIndex.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Comment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(355, 64);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "OnBound";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(185, 64);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Poly";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(524, 64);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Index";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(585, 127);
            this.btnParse.Margin = new System.Windows.Forms.Padding(4);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(100, 28);
            this.btnParse.TabIndex = 2;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(16, 127);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radUTM);
            this.panel1.Controls.Add(this.radLatLon);
            this.panel1.Location = new System.Drawing.Point(125, 121);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 38);
            this.panel1.TabIndex = 3;
            // 
            // radUTM
            // 
            this.radUTM.AutoSize = true;
            this.radUTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radUTM.Location = new System.Drawing.Point(111, 9);
            this.radUTM.Margin = new System.Windows.Forms.Padding(4);
            this.radUTM.Name = "radUTM";
            this.radUTM.Size = new System.Drawing.Size(69, 24);
            this.radUTM.TabIndex = 0;
            this.radUTM.Text = "UTM";
            this.radUTM.UseVisualStyleBackColor = true;
            // 
            // radLatLon
            // 
            this.radLatLon.AutoSize = true;
            this.radLatLon.Checked = true;
            this.radLatLon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLatLon.Location = new System.Drawing.Point(0, 9);
            this.radLatLon.Margin = new System.Windows.Forms.Padding(4);
            this.radLatLon.Name = "radLatLon";
            this.radLatLon.Size = new System.Drawing.Size(94, 24);
            this.radLatLon.TabIndex = 0;
            this.radLatLon.TabStop = true;
            this.radLatLon.Text = "Lat/Lon";
            this.radLatLon.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radMeters);
            this.panel2.Controls.Add(this.radFeet);
            this.panel2.Location = new System.Drawing.Point(355, 121);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 38);
            this.panel2.TabIndex = 4;
            // 
            // radMeters
            // 
            this.radMeters.AutoSize = true;
            this.radMeters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMeters.Location = new System.Drawing.Point(129, 9);
            this.radMeters.Margin = new System.Windows.Forms.Padding(4);
            this.radMeters.Name = "radMeters";
            this.radMeters.Size = new System.Drawing.Size(88, 24);
            this.radMeters.TabIndex = 0;
            this.radMeters.Text = "Meters";
            this.radMeters.UseVisualStyleBackColor = true;
            // 
            // radFeet
            // 
            this.radFeet.AutoSize = true;
            this.radFeet.Checked = true;
            this.radFeet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFeet.Location = new System.Drawing.Point(0, 9);
            this.radFeet.Margin = new System.Windows.Forms.Padding(4);
            this.radFeet.Name = "radFeet";
            this.radFeet.Size = new System.Drawing.Size(111, 24);
            this.radFeet.TabIndex = 0;
            this.radFeet.TabStop = true;
            this.radFeet.Text = "Ft-Tenths";
            this.radFeet.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Elevation ( Z )";
            // 
            // TextImportFieldSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 210);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblZ);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboIndex);
            this.Controls.Add(this.cboZ);
            this.Controls.Add(this.cboPoly);
            this.Controls.Add(this.cboX);
            this.Controls.Add(this.cboOnBnd);
            this.Controls.Add(this.cboY);
            this.Controls.Add(this.cboCmt);
            this.Controls.Add(this.cboPID);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(717, 210);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(717, 210);
            this.Name = "TextImportFieldSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Parse Fields";
            this.Load += new System.EventHandler(this.TextImportFieldSelectionForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboX;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.ComboBox cboY;
        private System.Windows.Forms.ComboBox cboZ;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.ComboBox cboCmt;
        private System.Windows.Forms.ComboBox cboOnBnd;
        private System.Windows.Forms.ComboBox cboPoly;
        private System.Windows.Forms.ComboBox cboIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radUTM;
        private System.Windows.Forms.RadioButton radLatLon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radMeters;
        private System.Windows.Forms.RadioButton radFeet;
        private System.Windows.Forms.Label label2;
    }
}