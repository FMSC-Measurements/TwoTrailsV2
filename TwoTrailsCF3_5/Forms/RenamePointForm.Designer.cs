namespace TwoTrails.Forms
{
    partial class RenamePointForm
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
            this.lstPoints = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.cboPoly = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPoly = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPoints
            // 
            this.lstPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPoints.BackColor = System.Drawing.SystemColors.GrayText;
            this.lstPoints.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lstPoints.Location = new System.Drawing.Point(0, 31);
            this.lstPoints.Name = "lstPoints";
            this.lstPoints.Size = new System.Drawing.Size(240, 170);
            this.lstPoints.TabIndex = 0;
            this.lstPoints.SelectedIndexChanged += new System.EventHandler(this.lstPoints_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(3, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Tag = "Cancel Renaming";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuto.Location = new System.Drawing.Point(79, 266);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(82, 25);
            this.btnAuto.TabIndex = 2;
            this.btnAuto.Tag = "Auto Rename Points and order index based on Naming Settings.";
            this.btnAuto.Text = "Auto";
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(167, 266);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Tag = "Finish and Save";
            this.btnOk.Text = "Save";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFirst.Location = new System.Drawing.Point(3, 207);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(54, 25);
            this.btnFirst.TabIndex = 3;
            this.btnFirst.Tag = "Move Point to Top";
            this.btnFirst.Text = "First";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Location = new System.Drawing.Point(63, 207);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(54, 25);
            this.btnUp.TabIndex = 3;
            this.btnUp.Tag = "Move Point Up";
            this.btnUp.Text = "Up";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Location = new System.Drawing.Point(123, 207);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(54, 25);
            this.btnDown.TabIndex = 3;
            this.btnDown.Tag = "Move Point Down";
            this.btnDown.Text = "Down";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLast.Location = new System.Drawing.Point(183, 207);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(54, 25);
            this.btnLast.TabIndex = 3;
            this.btnLast.Tag = "Move Point To End";
            this.btnLast.Text = "Last";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // txtPID
            // 
            this.txtPID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPID.Location = new System.Drawing.Point(3, 239);
            this.txtPID.MaxLength = 30;
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(234, 21);
            this.txtPID.TabIndex = 4;
            this.txtPID.Tag = "Point ID";
            this.txtPID.TextChanged += new System.EventHandler(this.txtPID_TextChanged);
            this.txtPID.GotFocus += new System.EventHandler(this.txtPID_GotFocus);
            this.txtPID.LostFocus += new System.EventHandler(this.txtPID_LostFocus);
            // 
            // cboPoly
            // 
            this.cboPoly.Location = new System.Drawing.Point(109, 3);
            this.cboPoly.Name = "cboPoly";
            this.cboPoly.Size = new System.Drawing.Size(128, 22);
            this.cboPoly.TabIndex = 6;
            this.cboPoly.SelectedIndexChanged += new System.EventHandler(this.cboPoly_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Polygon:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnPoly
            // 
            this.btnPoly.Location = new System.Drawing.Point(105, 3);
            this.btnPoly.Name = "btnPoly";
            this.btnPoly.Size = new System.Drawing.Size(132, 22);
            this.btnPoly.TabIndex = 8;
            this.btnPoly.Tag = "Polygon";
            this.btnPoly.Click += new System.EventHandler(this.btnPoly_Click);
            // 
            // RenamePointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.btnPoly);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPoly);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstPoints);
            this.KeyPreview = true;
            this.Name = "RenamePointForm";
            this.Text = "Rename / Move Points";
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.lstPoints = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.cboPoly = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPoly = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPoints
            // 
            this.lstPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPoints.BackColor = System.Drawing.SystemColors.GrayText;
            this.lstPoints.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lstPoints.Location = new System.Drawing.Point(3, 31);
            this.lstPoints.Name = "lstPoints";
            this.lstPoints.Size = new System.Drawing.Size(248, 142);
            this.lstPoints.TabIndex = 0;
            this.lstPoints.SelectedIndexChanged += new System.EventHandler(this.lstPoints_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(257, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Tag = "Cancel Renaming";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuto.Location = new System.Drawing.Point(257, 120);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(60, 25);
            this.btnAuto.TabIndex = 2;
            this.btnAuto.Tag = "Auto Rename Points and order index based on Naming Settings.";
            this.btnAuto.Text = "Auto";
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(257, 150);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(60, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Tag = "Finish and Save";
            this.btnOk.Text = "Save";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirst.Location = new System.Drawing.Point(257, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(60, 25);
            this.btnFirst.TabIndex = 3;
            this.btnFirst.Tag = "Move Point to Top";
            this.btnFirst.Text = "First";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(257, 32);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(60, 25);
            this.btnUp.TabIndex = 3;
            this.btnUp.Tag = "Move Point Up";
            this.btnUp.Text = "Up";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Location = new System.Drawing.Point(257, 62);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(60, 25);
            this.btnDown.TabIndex = 3;
            this.btnDown.Tag = "Move Point Down";
            this.btnDown.Text = "Down";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.Location = new System.Drawing.Point(257, 91);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(60, 25);
            this.btnLast.TabIndex = 3;
            this.btnLast.Tag = "Move Point To End";
            this.btnLast.Text = "Last";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // txtPID
            // 
            this.txtPID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPID.Location = new System.Drawing.Point(3, 184);
            this.txtPID.MaxLength = 30;
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(248, 21);
            this.txtPID.TabIndex = 4;
            this.txtPID.Tag = "Point ID";
            this.txtPID.TextChanged += new System.EventHandler(this.txtPID_TextChanged);
            // 
            // cboPoly
            // 
            this.cboPoly.Location = new System.Drawing.Point(76, 3);
            this.cboPoly.Name = "cboPoly";
            this.cboPoly.Size = new System.Drawing.Size(175, 22);
            this.cboPoly.TabIndex = 6;
            this.cboPoly.SelectedIndexChanged += new System.EventHandler(this.cboPoly_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.Text = "Polygon:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnPoly
            // 
            this.btnPoly.Location = new System.Drawing.Point(72, 3);
            this.btnPoly.Name = "btnPoly";
            this.btnPoly.Size = new System.Drawing.Size(179, 22);
            this.btnPoly.TabIndex = 8;
            this.btnPoly.Tag = "Polygon";
            this.btnPoly.Click += new System.EventHandler(this.btnPoly_Click);
            // 
            // RenamePointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.ControlBox = false;
            this.Controls.Add(this.btnPoly);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPoly);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstPoints);
            this.KeyPreview = true;
            this.Name = "RenamePointForm";
            this.Text = "Rename / Move Points";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ListBox lstPoints;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.ComboBox cboPoly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPoly;
    }
}