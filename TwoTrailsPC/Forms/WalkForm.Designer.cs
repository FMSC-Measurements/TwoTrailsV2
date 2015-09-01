namespace TwoTrails.Forms
{
    partial class WalkForm
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
            this.pnlSavePointIcon = new System.Windows.Forms.Panel();
            this.txtFreq = new System.Windows.Forms.TextBox();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.txtDOP = new System.Windows.Forms.TextBox();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.txtIncrement = new System.Windows.Forms.TextBox();
            this.cboDOP = new System.Windows.Forms.ComboBox();
            this.cboFixType = new System.Windows.Forms.ComboBox();
            this.chkSound = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.lblPoly = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.gpsInfoAdvCtrl = new TwoTrails.Controls.GpsInfoAdvCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSavePointIcon
            // 
            this.pnlSavePointIcon.Location = new System.Drawing.Point(0, 0);
            this.pnlSavePointIcon.Name = "pnlSavePointIcon";
            this.pnlSavePointIcon.Size = new System.Drawing.Size(30, 30);
            this.pnlSavePointIcon.TabIndex = 1;
            // 
            // txtFreq
            // 
            this.txtFreq.Enabled = false;
            this.txtFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFreq.Location = new System.Drawing.Point(92, 232);
            this.txtFreq.Name = "txtFreq";
            this.txtFreq.Size = new System.Drawing.Size(70, 22);
            this.txtFreq.TabIndex = 2;
            this.txtFreq.TabStop = false;
            this.txtFreq.TextChanged += new System.EventHandler(this.txtFreq_TextChanged);
            // 
            // txtAcc
            // 
            this.txtAcc.Enabled = false;
            this.txtAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc.Location = new System.Drawing.Point(92, 260);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(70, 22);
            this.txtAcc.TabIndex = 2;
            this.txtAcc.TabStop = false;
            this.txtAcc.TextChanged += new System.EventHandler(this.txtAcc_TextChanged);
            // 
            // txtDOP
            // 
            this.txtDOP.Enabled = false;
            this.txtDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOP.Location = new System.Drawing.Point(92, 288);
            this.txtDOP.Name = "txtDOP";
            this.txtDOP.Size = new System.Drawing.Size(70, 22);
            this.txtDOP.TabIndex = 2;
            this.txtDOP.TabStop = false;
            this.txtDOP.TextChanged += new System.EventHandler(this.txtDOP_TextChanged);
            // 
            // txtPID
            // 
            this.txtPID.Enabled = false;
            this.txtPID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPID.Location = new System.Drawing.Point(256, 232);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(70, 22);
            this.txtPID.TabIndex = 2;
            this.txtPID.TabStop = false;
            this.txtPID.TextChanged += new System.EventHandler(this.txtPID_TextChanged);
            // 
            // txtIncrement
            // 
            this.txtIncrement.Enabled = false;
            this.txtIncrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncrement.Location = new System.Drawing.Point(256, 260);
            this.txtIncrement.Name = "txtIncrement";
            this.txtIncrement.Size = new System.Drawing.Size(70, 22);
            this.txtIncrement.TabIndex = 2;
            this.txtIncrement.TabStop = false;
            this.txtIncrement.TextChanged += new System.EventHandler(this.txtIncrement_TextChanged);
            // 
            // cboDOP
            // 
            this.cboDOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDOP.Enabled = false;
            this.cboDOP.FormattingEnabled = true;
            this.cboDOP.Items.AddRange(new object[] {
            "PDOP",
            "HDOP"});
            this.cboDOP.Location = new System.Drawing.Point(6, 288);
            this.cboDOP.Name = "cboDOP";
            this.cboDOP.Size = new System.Drawing.Size(80, 21);
            this.cboDOP.TabIndex = 3;
            this.cboDOP.TabStop = false;
            this.cboDOP.SelectedIndexChanged += new System.EventHandler(this.cboDOP_SelectedIndexChanged);
            // 
            // cboFixType
            // 
            this.cboFixType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFixType.Enabled = false;
            this.cboFixType.FormattingEnabled = true;
            this.cboFixType.Items.AddRange(new object[] {
            "Any",
            "3D",
            "3D+DIFF"});
            this.cboFixType.Location = new System.Drawing.Point(256, 288);
            this.cboFixType.Name = "cboFixType";
            this.cboFixType.Size = new System.Drawing.Size(70, 21);
            this.cboFixType.TabIndex = 3;
            this.cboFixType.TabStop = false;
            this.cboFixType.SelectedIndexChanged += new System.EventHandler(this.cboFixType_SelectedIndexChanged);
            // 
            // chkSound
            // 
            this.chkSound.AutoSize = true;
            this.chkSound.Checked = true;
            this.chkSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSound.Location = new System.Drawing.Point(255, 315);
            this.chkSound.Name = "chkSound";
            this.chkSound.Size = new System.Drawing.Size(71, 20);
            this.chkSound.TabIndex = 4;
            this.chkSound.TabStop = false;
            this.chkSound.Text = "Sound";
            this.chkSound.UseVisualStyleBackColor = true;
            this.chkSound.CheckedChanged += new System.EventHandler(this.chkSound_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(7, 341);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapture.Location = new System.Drawing.Point(98, 341);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(137, 25);
            this.btnCapture.TabIndex = 5;
            this.btnCapture.TabStop = false;
            this.btnCapture.Text = "Start";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(241, 341);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 25);
            this.btnOk.TabIndex = 5;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "Stop";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Frequency:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Distance:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(184, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Point ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(178, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Point Inc:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(176, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fix Type:";
            // 
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.Checked = true;
            this.chkLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLock.Location = new System.Drawing.Point(7, 315);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(60, 20);
            this.chkLock.TabIndex = 4;
            this.chkLock.TabStop = false;
            this.chkLock.Text = "Lock";
            this.chkLock.UseVisualStyleBackColor = true;
            this.chkLock.CheckedChanged += new System.EventHandler(this.chkLock_CheckedChanged);
            // 
            // lblPoly
            // 
            this.lblPoly.AutoSize = true;
            this.lblPoly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoly.Location = new System.Drawing.Point(125, 316);
            this.lblPoly.Name = "lblPoly";
            this.lblPoly.Size = new System.Drawing.Size(65, 16);
            this.lblPoly.TabIndex = 6;
            this.lblPoly.Text = "Polygon";
            this.lblPoly.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picBox
            // 
            this.picBox.Image = global::TwoTrails.Properties.Resources.Walking;
            this.picBox.Location = new System.Drawing.Point(298, -5);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(30, 40);
            this.picBox.TabIndex = 7;
            this.picBox.TabStop = false;
            this.picBox.Visible = false;
            // 
            // gpsInfoAdvCtrl
            // 
            this.gpsInfoAdvCtrl.Location = new System.Drawing.Point(0, 30);
            this.gpsInfoAdvCtrl.Name = "gpsInfoAdvCtrl";
            this.gpsInfoAdvCtrl.Size = new System.Drawing.Size(330, 200);
            this.gpsInfoAdvCtrl.TabIndex = 0;
            this.gpsInfoAdvCtrl.UtmRange = false;
            // 
            // WalkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 370);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPoly);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.chkSound);
            this.Controls.Add(this.cboFixType);
            this.Controls.Add(this.cboDOP);
            this.Controls.Add(this.txtDOP);
            this.Controls.Add(this.txtIncrement);
            this.Controls.Add(this.txtAcc);
            this.Controls.Add(this.txtFreq);
            this.Controls.Add(this.pnlSavePointIcon);
            this.Controls.Add(this.gpsInfoAdvCtrl);
            this.Controls.Add(this.picBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(346, 408);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(346, 408);
            this.Name = "WalkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Walk";
            this.Load += new System.EventHandler(this.WalkForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WalkForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TwoTrails.Controls.GpsInfoAdvCtrl gpsInfoAdvCtrl;
        private System.Windows.Forms.Panel pnlSavePointIcon;
        private System.Windows.Forms.TextBox txtFreq;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.TextBox txtDOP;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.TextBox txtIncrement;
        private System.Windows.Forms.ComboBox cboDOP;
        private System.Windows.Forms.ComboBox cboFixType;
        private System.Windows.Forms.CheckBox chkSound;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.Label lblPoly;
        private System.Windows.Forms.PictureBox picBox;
    }
}