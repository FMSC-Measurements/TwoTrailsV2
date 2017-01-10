namespace TwoTrails.Controls
{
    partial class GpsInfoControl
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
            this.components = new System.ComponentModel.Container();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.bindingSourcePoint = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelNmea = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRMSE = new System.Windows.Forms.TextBox();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtManAcc = new System.Windows.Forms.TextBox();
            this.btnMisc = new System.Windows.Forms.Button();
            this.txtElevation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePoint)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxX
            // 
            this.textBoxX.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "UnAdjX", true));
            this.textBoxX.Location = new System.Drawing.Point(28, 3);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(139, 21);
            this.textBoxX.TabIndex = 0;
            this.textBoxX.TabStop = false;
            this.textBoxX.TextChanged += new System.EventHandler(this.textBoxX_TextChanged);
            this.textBoxX.GotFocus += new System.EventHandler(this.textBoxX_GotFocus);
            this.textBoxX.LostFocus += new System.EventHandler(this.textBoxX_LostFocus);
            // 
            // bindingSourcePoint
            // 
            this.bindingSourcePoint.DataSource = typeof(TwoTrails.BusinessObjects.GpsPoint);
            this.bindingSourcePoint.DataError += new System.Windows.Forms.BindingManagerDataErrorEventHandler(this.bindingSourcePoint_DataError);
            // 
            // textBoxY
            // 
            this.textBoxY.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "UnAdjY", true));
            this.textBoxY.Location = new System.Drawing.Point(28, 30);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(139, 21);
            this.textBoxY.TabIndex = 1;
            this.textBoxY.TabStop = false;
            this.textBoxY.TextChanged += new System.EventHandler(this.textBoxY_TextChanged);
            this.textBoxY.GotFocus += new System.EventHandler(this.textBoxY_GotFocus);
            this.textBoxY.LostFocus += new System.EventHandler(this.textBoxY_LostFocus);
            // 
            // textBoxZ
            // 
            this.textBoxZ.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "UnAdjZ", true));
            this.textBoxZ.Location = new System.Drawing.Point(28, 58);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(99, 21);
            this.textBoxZ.TabIndex = 2;
            this.textBoxZ.TabStop = false;
            this.textBoxZ.TextChanged += new System.EventHandler(this.textBoxZ_TextChanged);
            this.textBoxZ.GotFocus += new System.EventHandler(this.textBoxZ_GotFocus);
            this.textBoxZ.LostFocus += new System.EventHandler(this.textBoxZ_LostFocus);
            // 
            // labelX
            // 
            this.labelX.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelX.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelX.Location = new System.Drawing.Point(4, 5);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(18, 20);
            this.labelX.Text = "X:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(4, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.Text = "Y:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(4, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.Text = "Z:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(173, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 47);
            this.label3.Text = "UTM (Meters)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnDelNmea
            // 
            this.btnDelNmea.Location = new System.Drawing.Point(133, 106);
            this.btnDelNmea.Name = "btnDelNmea";
            this.btnDelNmea.Size = new System.Drawing.Size(99, 17);
            this.btnDelNmea.TabIndex = 4;
            this.btnDelNmea.TabStop = false;
            this.btnDelNmea.Text = "Del Nmea";
            this.btnDelNmea.Visible = false;
            this.btnDelNmea.Click += new System.EventHandler(this.btnDelNmea_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(4, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.Text = "RMSE:";
            // 
            // txtRMSE
            // 
            this.txtRMSE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "RMSEr", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#.##"));
            this.txtRMSE.Enabled = false;
            this.txtRMSE.Location = new System.Drawing.Point(47, 82);
            this.txtRMSE.Name = "txtRMSE";
            this.txtRMSE.Size = new System.Drawing.Size(40, 21);
            this.txtRMSE.TabIndex = 6;
            this.txtRMSE.TabStop = false;
            // 
            // txtAcc
            // 
            this.txtAcc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "NSSDA_RMSEr", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#.##"));
            this.txtAcc.Enabled = false;
            this.txtAcc.Location = new System.Drawing.Point(173, 82);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(40, 21);
            this.txtAcc.TabIndex = 8;
            this.txtAcc.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(95, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.Text = "NSSDA Acc:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(4, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.Text = "Man Acc (M):";
            // 
            // txtManAcc
            // 
            this.txtManAcc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "ManualAccuracy", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#.##"));
            this.txtManAcc.Location = new System.Drawing.Point(87, 104);
            this.txtManAcc.Name = "txtManAcc";
            this.txtManAcc.Size = new System.Drawing.Size(40, 21);
            this.txtManAcc.TabIndex = 16;
            this.txtManAcc.TabStop = false;
            this.txtManAcc.TextChanged += new System.EventHandler(this.txtManAcc_TextChanged);
            this.txtManAcc.GotFocus += new System.EventHandler(this.txtManAcc_GotFocus);
            this.txtManAcc.LostFocus += new System.EventHandler(this.txtManAcc_LostFocus);
            // 
            // btnMisc
            // 
            this.btnMisc.Location = new System.Drawing.Point(173, 43);
            this.btnMisc.Name = "btnMisc";
            this.btnMisc.Size = new System.Drawing.Size(59, 37);
            this.btnMisc.TabIndex = 24;
            this.btnMisc.TabStop = false;
            this.btnMisc.Text = "Take 5 Setup";
            this.btnMisc.Visible = false;
            this.btnMisc.Click += new System.EventHandler(this.btnMisc_Click);
            // 
            // txtElevation
            // 
            this.txtElevation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtElevation.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txtElevation.Location = new System.Drawing.Point(129, 60);
            this.txtElevation.Name = "txtElevation";
            this.txtElevation.Size = new System.Drawing.Size(41, 20);
            this.txtElevation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GpsInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.txtElevation);
            this.Controls.Add(this.btnMisc);
            this.Controls.Add(this.txtManAcc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAcc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRMSE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelNmea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.textBoxZ);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Name = "GpsInfoControl";
            this.Size = new System.Drawing.Size(235, 128);
            this.Click += new System.EventHandler(this.GpsInfoControl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePoint)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.bindingSourcePoint = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelNmea = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRMSE = new System.Windows.Forms.TextBox();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtManAcc = new System.Windows.Forms.TextBox();
            this.btnMisc = new System.Windows.Forms.Button();
            this.txtElevation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePoint)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxX
            // 
            this.textBoxX.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "UnAdjX", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "#.#####"));
            this.textBoxX.Location = new System.Drawing.Point(28, 3);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(139, 21);
            this.textBoxX.TabIndex = 0;
            this.textBoxX.TabStop = false;
            this.textBoxX.TextChanged += new System.EventHandler(this.textBoxX_TextChanged);
            this.textBoxX.GotFocus += new System.EventHandler(this.textBoxX_GotFocus);
            this.textBoxX.LostFocus += new System.EventHandler(this.textBoxX_LostFocus);
            // 
            // bindingSourcePoint
            // 
            this.bindingSourcePoint.DataSource = typeof(TwoTrails.BusinessObjects.GpsPoint);
            this.bindingSourcePoint.DataError += new System.Windows.Forms.BindingManagerDataErrorEventHandler(this.bindingSourcePoint_DataError);
            // 
            // textBoxY
            // 
            this.textBoxY.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "UnAdjY", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "#.#####"));
            this.textBoxY.Location = new System.Drawing.Point(28, 26);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(139, 21);
            this.textBoxY.TabIndex = 1;
            this.textBoxY.TabStop = false;
            this.textBoxY.TextChanged += new System.EventHandler(this.textBoxY_TextChanged);
            this.textBoxY.GotFocus += new System.EventHandler(this.textBoxY_GotFocus);
            this.textBoxY.LostFocus += new System.EventHandler(this.textBoxY_LostFocus);
            // 
            // textBoxZ
            // 
            this.textBoxZ.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "UnAdjZ", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "#.#####"));
            this.textBoxZ.Location = new System.Drawing.Point(28, 49);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(99, 21);
            this.textBoxZ.TabIndex = 2;
            this.textBoxZ.TabStop = false;
            this.textBoxZ.TextChanged += new System.EventHandler(this.textBoxZ_TextChanged);
            this.textBoxZ.GotFocus += new System.EventHandler(this.textBoxZ_GotFocus);
            this.textBoxZ.LostFocus += new System.EventHandler(this.textBoxZ_LostFocus);
            // 
            // labelX
            // 
            this.labelX.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelX.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelX.Location = new System.Drawing.Point(4, 5);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(18, 20);
            this.labelX.Text = "X:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(4, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.Text = "Y:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(4, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.Text = "Z:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(173, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 47);
            this.label3.Text = "UTM (Meters)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnDelNmea
            // 
            this.btnDelNmea.Location = new System.Drawing.Point(133, 96);
            this.btnDelNmea.Name = "btnDelNmea";
            this.btnDelNmea.Size = new System.Drawing.Size(99, 17);
            this.btnDelNmea.TabIndex = 4;
            this.btnDelNmea.TabStop = false;
            this.btnDelNmea.Text = "Del Nmea";
            this.btnDelNmea.Click += new System.EventHandler(this.btnDelNmea_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(4, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.Text = "RMSE:";
            // 
            // txtRMSE
            // 
            this.txtRMSE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "RMSEr", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#.##"));
            this.txtRMSE.Enabled = false;
            this.txtRMSE.Location = new System.Drawing.Point(47, 72);
            this.txtRMSE.Name = "txtRMSE";
            this.txtRMSE.Size = new System.Drawing.Size(40, 21);
            this.txtRMSE.TabIndex = 6;
            this.txtRMSE.TabStop = false;
            // 
            // txtAcc
            // 
            this.txtAcc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "NSSDA_RMSEr", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#.##"));
            this.txtAcc.Enabled = false;
            this.txtAcc.Location = new System.Drawing.Point(173, 72);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(40, 21);
            this.txtAcc.TabIndex = 8;
            this.txtAcc.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(95, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.Text = "NSSDA Acc:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(4, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.Text = "Man Acc (M):";
            // 
            // txtManAcc
            // 
            this.txtManAcc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "ManualAccuracy", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#.##"));
            this.txtManAcc.Location = new System.Drawing.Point(87, 92);
            this.txtManAcc.Name = "txtManAcc";
            this.txtManAcc.Size = new System.Drawing.Size(40, 21);
            this.txtManAcc.TabIndex = 16;
            this.txtManAcc.TabStop = false;
            this.txtManAcc.TextChanged += new System.EventHandler(this.txtManAcc_TextChanged);
            this.txtManAcc.GotFocus += new System.EventHandler(this.txtManAcc_GotFocus);
            this.txtManAcc.LostFocus += new System.EventHandler(this.txtManAcc_LostFocus);
            // 
            // btnMisc
            // 
            this.btnMisc.Location = new System.Drawing.Point(173, 35);
            this.btnMisc.Name = "btnMisc";
            this.btnMisc.Size = new System.Drawing.Size(59, 37);
            this.btnMisc.TabIndex = 24;
            this.btnMisc.TabStop = false;
            this.btnMisc.Text = "Take 5 Setup";
            this.btnMisc.Visible = false;
            this.btnMisc.Click += new System.EventHandler(this.btnMisc_Click);
            // 
            // txtElevation
            // 
            this.txtElevation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtElevation.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txtElevation.Location = new System.Drawing.Point(129, 52);
            this.txtElevation.Name = "txtElevation";
            this.txtElevation.Size = new System.Drawing.Size(41, 20);
            this.txtElevation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GpsInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.txtElevation);
            this.Controls.Add(this.btnMisc);
            this.Controls.Add(this.txtManAcc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAcc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRMSE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelNmea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.textBoxZ);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Name = "GpsInfoControl";
            this.Size = new System.Drawing.Size(235, 116);
            this.Click += new System.EventHandler(this.GpsInfoControl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePoint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSourcePoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelNmea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRMSE;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtManAcc;
        private System.Windows.Forms.Button btnMisc;
        private System.Windows.Forms.Label txtElevation;
    }
}
