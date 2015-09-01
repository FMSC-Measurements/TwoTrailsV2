namespace TwoTrails.Controls
{
    partial class Take5InfoCtrl
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
            this.btnHide = new System.Windows.Forms.Button();
            this.cboDOP = new System.Windows.Forms.ComboBox();
            this.cboFixType = new System.Windows.Forms.ComboBox();
            this.txtDOP = new System.Windows.Forms.TextBox();
            this.txtBursts = new System.Windows.Forms.TextBox();
            this.txtIgnore = new System.Windows.Forms.TextBox();
            this.chkIgnoreNmea = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHide
            // 
            this.btnHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.Location = new System.Drawing.Point(252, 5);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(75, 23);
            this.btnHide.TabIndex = 0;
            this.btnHide.TabStop = false;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // cboDOP
            // 
            this.cboDOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDOP.FormattingEnabled = true;
            this.cboDOP.Items.AddRange(new object[] {
            "PDOP",
            "HDOP"});
            this.cboDOP.Location = new System.Drawing.Point(3, 37);
            this.cboDOP.Name = "cboDOP";
            this.cboDOP.Size = new System.Drawing.Size(90, 21);
            this.cboDOP.TabIndex = 1;
            this.cboDOP.TabStop = false;
            this.cboDOP.SelectedIndexChanged += new System.EventHandler(this.cboDOP_SelectedIndexChanged);
            // 
            // cboFixType
            // 
            this.cboFixType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFixType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFixType.FormattingEnabled = true;
            this.cboFixType.Items.AddRange(new object[] {
            "ANY",
            "3D",
            "3D+DIFF"});
            this.cboFixType.Location = new System.Drawing.Point(252, 37);
            this.cboFixType.Name = "cboFixType";
            this.cboFixType.Size = new System.Drawing.Size(75, 21);
            this.cboFixType.TabIndex = 1;
            this.cboFixType.TabStop = false;
            this.cboFixType.SelectedIndexChanged += new System.EventHandler(this.cboFixType_SelectedIndexChanged);
            // 
            // txtDOP
            // 
            this.txtDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOP.Location = new System.Drawing.Point(99, 37);
            this.txtDOP.Name = "txtDOP";
            this.txtDOP.Size = new System.Drawing.Size(40, 20);
            this.txtDOP.TabIndex = 2;
            this.txtDOP.TabStop = false;
            this.txtDOP.TextChanged += new System.EventHandler(this.txtDOP_TextChanged);
            // 
            // txtBursts
            // 
            this.txtBursts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBursts.Location = new System.Drawing.Point(114, 63);
            this.txtBursts.Name = "txtBursts";
            this.txtBursts.Size = new System.Drawing.Size(75, 20);
            this.txtBursts.TabIndex = 2;
            this.txtBursts.TabStop = false;
            this.txtBursts.TextChanged += new System.EventHandler(this.txtBursts_TextChanged);
            // 
            // txtIgnore
            // 
            this.txtIgnore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIgnore.Location = new System.Drawing.Point(3, 92);
            this.txtIgnore.Name = "txtIgnore";
            this.txtIgnore.Size = new System.Drawing.Size(57, 20);
            this.txtIgnore.TabIndex = 2;
            this.txtIgnore.TabStop = false;
            this.txtIgnore.TextChanged += new System.EventHandler(this.txtIgnore_TextChanged);
            // 
            // chkIgnoreNmea
            // 
            this.chkIgnoreNmea.AutoSize = true;
            this.chkIgnoreNmea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreNmea.Location = new System.Drawing.Point(66, 92);
            this.chkIgnoreNmea.Name = "chkIgnoreNmea";
            this.chkIgnoreNmea.Size = new System.Drawing.Size(150, 20);
            this.chkIgnoreNmea.TabIndex = 3;
            this.chkIgnoreNmea.TabStop = false;
            this.chkIgnoreNmea.Text = "Ignore First Nmea";
            this.chkIgnoreNmea.UseVisualStyleBackColor = true;
            this.chkIgnoreNmea.CheckedChanged += new System.EventHandler(this.chkIgnoreNmea_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "-- Filter --";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fix Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Num of Nmea:";
            // 
            // Take5InfoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkIgnoreNmea);
            this.Controls.Add(this.txtBursts);
            this.Controls.Add(this.txtIgnore);
            this.Controls.Add(this.txtDOP);
            this.Controls.Add(this.cboFixType);
            this.Controls.Add(this.cboDOP);
            this.Controls.Add(this.btnHide);
            this.Name = "Take5InfoCtrl";
            this.Size = new System.Drawing.Size(330, 170);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.ComboBox cboDOP;
        private System.Windows.Forms.ComboBox cboFixType;
        private System.Windows.Forms.TextBox txtDOP;
        private System.Windows.Forms.TextBox txtBursts;
        private System.Windows.Forms.TextBox txtIgnore;
        private System.Windows.Forms.CheckBox chkIgnoreNmea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
