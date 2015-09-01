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
            this.btnMisc = new System.Windows.Forms.Button();
            this.btnDelNmea = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtElevation = new System.Windows.Forms.Label();
            this.txtRMSE = new System.Windows.Forms.TextBox();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.txtManAcc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePoint)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxX
            // 
            this.textBoxX.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "X", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "#.#####"));
            this.textBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX.Location = new System.Drawing.Point(30, 3);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(205, 21);
            this.textBoxX.TabIndex = 0;
            this.textBoxX.TextChanged += new System.EventHandler(this.textBoxX_TextChanged);
            // 
            // bindingSourcePoint
            // 
            this.bindingSourcePoint.DataSource = typeof(TwoTrails.BusinessObjects.GpsPoint);
            this.bindingSourcePoint.DataError += new System.Windows.Forms.BindingManagerDataErrorEventHandler(this.bindingSourcePoint_DataError);
            // 
            // textBoxY
            // 
            this.textBoxY.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "Y", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "#.#####"));
            this.textBoxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxY.Location = new System.Drawing.Point(30, 30);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(205, 21);
            this.textBoxY.TabIndex = 1;
            this.textBoxY.TextChanged += new System.EventHandler(this.textBoxY_TextChanged);
            // 
            // textBoxZ
            // 
            this.textBoxZ.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "Z", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "#.#####"));
            this.textBoxZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZ.Location = new System.Drawing.Point(30, 57);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(205, 21);
            this.textBoxZ.TabIndex = 2;
            this.textBoxZ.TextChanged += new System.EventHandler(this.textBoxZ_TextChanged);
            // 
            // btnMisc
            // 
            this.btnMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMisc.Location = new System.Drawing.Point(240, 84);
            this.btnMisc.Name = "btnMisc";
            this.btnMisc.Size = new System.Drawing.Size(75, 46);
            this.btnMisc.TabIndex = 1;
            this.btnMisc.TabStop = false;
            this.btnMisc.Text = "Misc";
            this.btnMisc.UseVisualStyleBackColor = true;
            this.btnMisc.Click += new System.EventHandler(this.btnMisc_Click);
            // 
            // btnDelNmea
            // 
            this.btnDelNmea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelNmea.Location = new System.Drawing.Point(160, 84);
            this.btnDelNmea.Name = "btnDelNmea";
            this.btnDelNmea.Size = new System.Drawing.Size(75, 46);
            this.btnDelNmea.TabIndex = 2;
            this.btnDelNmea.TabStop = false;
            this.btnDelNmea.Text = "Delete NMEA";
            this.btnDelNmea.UseVisualStyleBackColor = true;
            this.btnDelNmea.Visible = false;
            this.btnDelNmea.Click += new System.EventHandler(this.btnDelNmea_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Z:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "RMSE (M):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Manual Acc:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "NSSDA Acc:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(241, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 30);
            this.label7.TabIndex = 4;
            this.label7.Text = "UTM\r\n(METERS)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtElevation
            // 
            this.txtElevation.AutoSize = true;
            this.txtElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtElevation.Location = new System.Drawing.Point(241, 60);
            this.txtElevation.Name = "txtElevation";
            this.txtElevation.Size = new System.Drawing.Size(47, 15);
            this.txtElevation.TabIndex = 5;
            this.txtElevation.Text = "          ";
            this.txtElevation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRMSE
            // 
            this.txtRMSE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "RMSEr", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "#.##"));
            this.txtRMSE.Enabled = false;
            this.txtRMSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMSE.Location = new System.Drawing.Point(104, 84);
            this.txtRMSE.Name = "txtRMSE";
            this.txtRMSE.Size = new System.Drawing.Size(50, 21);
            this.txtRMSE.TabIndex = 0;
            this.txtRMSE.TabStop = false;
            // 
            // txtAcc
            // 
            this.txtAcc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "NSSDA_RMSEr", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "#.##"));
            this.txtAcc.Enabled = false;
            this.txtAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc.Location = new System.Drawing.Point(104, 111);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(50, 21);
            this.txtAcc.TabIndex = 0;
            this.txtAcc.TabStop = false;
            // 
            // txtManAcc
            // 
            this.txtManAcc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "ManualAccuracy", true));
            this.txtManAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManAcc.Location = new System.Drawing.Point(104, 138);
            this.txtManAcc.Name = "txtManAcc";
            this.txtManAcc.Size = new System.Drawing.Size(50, 21);
            this.txtManAcc.TabIndex = 0;
            this.txtManAcc.TabStop = false;
            this.txtManAcc.TextChanged += new System.EventHandler(this.txtManAcc_TextChanged);
            // 
            // GpsInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtElevation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelNmea);
            this.Controls.Add(this.btnMisc);
            this.Controls.Add(this.txtManAcc);
            this.Controls.Add(this.txtAcc);
            this.Controls.Add(this.txtRMSE);
            this.Controls.Add(this.textBoxZ);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Name = "GpsInfoControl";
            this.Size = new System.Drawing.Size(330, 170);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.Button btnMisc;
        private System.Windows.Forms.Button btnDelNmea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtElevation;
        private System.Windows.Forms.TextBox txtRMSE;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.TextBox txtManAcc;
        private System.Windows.Forms.BindingSource bindingSourcePoint;
    }
}
