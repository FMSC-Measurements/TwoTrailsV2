namespace TwoTrails.Forms
{
    partial class Take5Form
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
            this.gpsInfoAdvCtrl = new TwoTrails.Controls.GpsInfoAdvCtrl();
            this.progCapture = new System.Windows.Forms.ProgressBar();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnBound = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSideshot = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.travInfoControl1 = new TwoTrails.Controls.TravInfoControl();
            this.btnSideshot = new System.Windows.Forms.Button();
            this.pnlSideshot.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpsInfoAdvCtrl
            // 
            this.gpsInfoAdvCtrl.Location = new System.Drawing.Point(0, 27);
            this.gpsInfoAdvCtrl.Name = "gpsInfoAdvCtrl";
            this.gpsInfoAdvCtrl.Size = new System.Drawing.Size(330, 200);
            this.gpsInfoAdvCtrl.TabIndex = 0;
            this.gpsInfoAdvCtrl.UtmRange = false;
            // 
            // progCapture
            // 
            this.progCapture.Location = new System.Drawing.Point(2, 3);
            this.progCapture.Maximum = 5;
            this.progCapture.Name = "progCapture";
            this.progCapture.Size = new System.Drawing.Size(326, 23);
            this.progCapture.Step = 1;
            this.progCapture.TabIndex = 1;
            // 
            // txtPID
            // 
            this.txtPID.Enabled = false;
            this.txtPID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPID.Location = new System.Drawing.Point(83, 233);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(100, 22);
            this.txtPID.TabIndex = 2;
            this.txtPID.TabStop = false;
            this.txtPID.TextChanged += new System.EventHandler(this.txtPID_TextChanged);
            // 
            // txtComment
            // 
            this.txtComment.Enabled = false;
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(83, 261);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(244, 22);
            this.txtComment.TabIndex = 2;
            this.txtComment.TabStop = false;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            // 
            // btnBound
            // 
            this.btnBound.Enabled = false;
            this.btnBound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBound.Location = new System.Drawing.Point(267, 231);
            this.btnBound.Name = "btnBound";
            this.btnBound.Size = new System.Drawing.Size(60, 25);
            this.btnBound.TabIndex = 3;
            this.btnBound.TabStop = false;
            this.btnBound.Text = "ON";
            this.btnBound.UseVisualStyleBackColor = true;
            this.btnBound.Click += new System.EventHandler(this.btnBound_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapture.Location = new System.Drawing.Point(93, 315);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(144, 25);
            this.btnCapture.TabIndex = 3;
            this.btnCapture.TabStop = false;
            this.btnCapture.Text = "Take 5";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(2, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(243, 315);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 25);
            this.btnOk.TabIndex = 3;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "Finish";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkLocked
            // 
            this.chkLocked.AutoSize = true;
            this.chkLocked.Checked = true;
            this.chkLocked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLocked.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLocked.Location = new System.Drawing.Point(7, 289);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(60, 20);
            this.chkLocked.TabIndex = 4;
            this.chkLocked.TabStop = false;
            this.chkLocked.Text = "Lock";
            this.chkLocked.UseVisualStyleBackColor = true;
            this.chkLocked.CheckedChanged += new System.EventHandler(this.chkLocked_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Point ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Comment:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(189, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Boundary:";
            // 
            // pnlSideshot
            // 
            this.pnlSideshot.Controls.Add(this.label4);
            this.pnlSideshot.Controls.Add(this.travInfoControl1);
            this.pnlSideshot.Location = new System.Drawing.Point(0, 0);
            this.pnlSideshot.Name = "pnlSideshot";
            this.pnlSideshot.Size = new System.Drawing.Size(330, 225);
            this.pnlSideshot.TabIndex = 6;
            this.pnlSideshot.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(128, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "SideShot";
            // 
            // travInfoControl1
            // 
            this.travInfoControl1.FlashAz = false;
            this.travInfoControl1.Location = new System.Drawing.Point(0, 50);
            this.travInfoControl1.MetaData = null;
            this.travInfoControl1.Name = "travInfoControl1";
            this.travInfoControl1.Size = new System.Drawing.Size(330, 130);
            this.travInfoControl1.TabIndex = 0;
            this.travInfoControl1.UseLaser = true;
            // 
            // btnSideshot
            // 
            this.btnSideshot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSideshot.Location = new System.Drawing.Point(122, 287);
            this.btnSideshot.Name = "btnSideshot";
            this.btnSideshot.Size = new System.Drawing.Size(92, 25);
            this.btnSideshot.TabIndex = 3;
            this.btnSideshot.TabStop = false;
            this.btnSideshot.Text = "SideShot";
            this.btnSideshot.UseVisualStyleBackColor = true;
            this.btnSideshot.Click += new System.EventHandler(this.btnSideshot_Click);
            // 
            // Take5Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 344);
            this.Controls.Add(this.pnlSideshot);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkLocked);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnSideshot);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnBound);
            this.Controls.Add(this.progCapture);
            this.Controls.Add(this.gpsInfoAdvCtrl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(346, 382);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(346, 382);
            this.Name = "Take5Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Take 5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Take5Form_FormClosing);
            this.pnlSideshot.ResumeLayout(false);
            this.pnlSideshot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TwoTrails.Controls.GpsInfoAdvCtrl gpsInfoAdvCtrl;
        private System.Windows.Forms.ProgressBar progCapture;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnBound;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkLocked;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlSideshot;
        private System.Windows.Forms.Label label4;
        private TwoTrails.Controls.TravInfoControl travInfoControl1;
        private System.Windows.Forms.Button btnSideshot;
    }
}