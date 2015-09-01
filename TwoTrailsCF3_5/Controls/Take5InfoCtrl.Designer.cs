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
            this.btnFixType = new System.Windows.Forms.Button();
            this.btnDOP = new System.Windows.Forms.Button();
            this.txtDOP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDOP = new System.Windows.Forms.ComboBox();
            this.cboFixType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBursts = new System.Windows.Forms.TextBox();
            this.chkIgnoreNmea = new System.Windows.Forms.CheckBox();
            this.txtIgnore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFixType
            // 
            this.btnFixType.Location = new System.Drawing.Point(165, 28);
            this.btnFixType.Name = "btnFixType";
            this.btnFixType.Size = new System.Drawing.Size(67, 22);
            this.btnFixType.TabIndex = 9;
            this.btnFixType.TabStop = false;
            this.btnFixType.Text = "3D+DIFF";
            this.btnFixType.Click += new System.EventHandler(this.btnFixType_Click);
            // 
            // btnDOP
            // 
            this.btnDOP.Location = new System.Drawing.Point(3, 27);
            this.btnDOP.Name = "btnDOP";
            this.btnDOP.Size = new System.Drawing.Size(67, 22);
            this.btnDOP.TabIndex = 8;
            this.btnDOP.TabStop = false;
            this.btnDOP.Text = "PDOP";
            this.btnDOP.Click += new System.EventHandler(this.btnDOP_Click);
            // 
            // txtDOP
            // 
            this.txtDOP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDOP.Location = new System.Drawing.Point(74, 27);
            this.txtDOP.Name = "txtDOP";
            this.txtDOP.Size = new System.Drawing.Size(27, 21);
            this.txtDOP.TabIndex = 7;
            this.txtDOP.TabStop = false;
            this.txtDOP.TextChanged += new System.EventHandler(this.txtDOP_TextChanged);
            this.txtDOP.GotFocus += new System.EventHandler(this.txtDOP_GotFocus);
            this.txtDOP.LostFocus += new System.EventHandler(this.txtDOP_LostFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(102, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.Text = "Fix Type:";
            // 
            // cboDOP
            // 
            this.cboDOP.Items.Add("PDOP");
            this.cboDOP.Items.Add("HDOP");
            this.cboDOP.Location = new System.Drawing.Point(3, 27);
            this.cboDOP.Name = "cboDOP";
            this.cboDOP.Size = new System.Drawing.Size(67, 22);
            this.cboDOP.TabIndex = 11;
            this.cboDOP.TabStop = false;
            this.cboDOP.SelectedIndexChanged += new System.EventHandler(this.cboDOP_SelectedIndexChanged);
            // 
            // cboFixType
            // 
            this.cboFixType.Items.Add("ANY");
            this.cboFixType.Items.Add("3D");
            this.cboFixType.Items.Add("3D+DIFF");
            this.cboFixType.Location = new System.Drawing.Point(165, 28);
            this.cboFixType.Name = "cboFixType";
            this.cboFixType.Size = new System.Drawing.Size(67, 22);
            this.cboFixType.TabIndex = 12;
            this.cboFixType.TabStop = false;
            this.cboFixType.SelectedIndexChanged += new System.EventHandler(this.cboFixType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 20);
            this.label1.Text = "----Filter----";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(76, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.Text = "Nmea Bursts:";
            // 
            // txtBursts
            // 
            this.txtBursts.Location = new System.Drawing.Point(164, 53);
            this.txtBursts.Name = "txtBursts";
            this.txtBursts.Size = new System.Drawing.Size(68, 21);
            this.txtBursts.TabIndex = 15;
            this.txtBursts.TabStop = false;
            this.txtBursts.TextChanged += new System.EventHandler(this.txtBursts_TextChanged);
            this.txtBursts.GotFocus += new System.EventHandler(this.txtBursts_GotFocus);
            this.txtBursts.LostFocus += new System.EventHandler(this.txtBursts_LostFocus);
            // 
            // chkIgnoreNmea
            // 
            this.chkIgnoreNmea.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkIgnoreNmea.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkIgnoreNmea.Location = new System.Drawing.Point(74, 76);
            this.chkIgnoreNmea.Name = "chkIgnoreNmea";
            this.chkIgnoreNmea.Size = new System.Drawing.Size(163, 20);
            this.chkIgnoreNmea.TabIndex = 19;
            this.chkIgnoreNmea.TabStop = false;
            this.chkIgnoreNmea.Tag = "Ignore the first amount of Nmea Data";
            this.chkIgnoreNmea.Text = "Ignore First Nmea";
            this.chkIgnoreNmea.CheckStateChanged += new System.EventHandler(this.chkIgnoreNmea_CheckStateChanged);
            // 
            // txtIgnore
            // 
            this.txtIgnore.Enabled = false;
            this.txtIgnore.Location = new System.Drawing.Point(3, 75);
            this.txtIgnore.Name = "txtIgnore";
            this.txtIgnore.Size = new System.Drawing.Size(67, 21);
            this.txtIgnore.TabIndex = 20;
            this.txtIgnore.TabStop = false;
            this.txtIgnore.TextChanged += new System.EventHandler(this.txtIgnore_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(47, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.Text = "Number of Nmea:";
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(165, 4);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(65, 20);
            this.btnHide.TabIndex = 25;
            this.btnHide.Text = "Hide";
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // Take5InfoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.txtIgnore);
            this.Controls.Add(this.chkIgnoreNmea);
            this.Controls.Add(this.txtBursts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFixType);
            this.Controls.Add(this.btnDOP);
            this.Controls.Add(this.txtDOP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboDOP);
            this.Controls.Add(this.cboFixType);
            this.Controls.Add(this.label3);
            this.Name = "Take5InfoCtrl";
            this.Size = new System.Drawing.Size(235, 140);
            this.Click += new System.EventHandler(this.Take5InfoCtrl_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFixType;
        private System.Windows.Forms.Button btnDOP;
        private System.Windows.Forms.TextBox txtDOP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDOP;
        private System.Windows.Forms.ComboBox cboFixType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBursts;
        private System.Windows.Forms.CheckBox chkIgnoreNmea;
        private System.Windows.Forms.TextBox txtIgnore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHide;
    }
}
