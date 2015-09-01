namespace TwoTrails.Forms
{
    partial class ProjectInfoForm
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
            this.textBoxProjName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProjDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRegion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxForest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDistrict = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.chkDropZeros = new System.Windows.Forms.CheckBox();
            this.chkRound = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxProjName
            // 
            this.textBoxProjName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProjName.Location = new System.Drawing.Point(81, 10);
            this.textBoxProjName.Name = "textBoxProjName";
            this.textBoxProjName.Size = new System.Drawing.Size(149, 21);
            this.textBoxProjName.TabIndex = 0;
            this.textBoxProjName.TabStop = false;
            this.textBoxProjName.TextChanged += new System.EventHandler(this.textBoxProjName_TextChanged);
            this.textBoxProjName.GotFocus += new System.EventHandler(this.textBoxProjName_GotFocus);
            this.textBoxProjName.LostFocus += new System.EventHandler(this.textBoxProjName_LostFocus);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 21);
            this.label1.Text = "Project ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(0, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.Text = "Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxProjDescription
            // 
            this.textBoxProjDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProjDescription.Location = new System.Drawing.Point(81, 37);
            this.textBoxProjDescription.Multiline = true;
            this.textBoxProjDescription.Name = "textBoxProjDescription";
            this.textBoxProjDescription.Size = new System.Drawing.Size(149, 20);
            this.textBoxProjDescription.TabIndex = 3;
            this.textBoxProjDescription.TabStop = false;
            this.textBoxProjDescription.TextChanged += new System.EventHandler(this.textBoxProjDescription_TextChanged);
            this.textBoxProjDescription.GotFocus += new System.EventHandler(this.textBoxProjDescription_GotFocus);
            this.textBoxProjDescription.LostFocus += new System.EventHandler(this.textBoxProjDescription_LostFocus);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.Text = "Region";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxRegion
            // 
            this.textBoxRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRegion.Location = new System.Drawing.Point(81, 63);
            this.textBoxRegion.Name = "textBoxRegion";
            this.textBoxRegion.Size = new System.Drawing.Size(149, 21);
            this.textBoxRegion.TabIndex = 6;
            this.textBoxRegion.TabStop = false;
            this.textBoxRegion.TextChanged += new System.EventHandler(this.textBoxRegion_TextChanged);
            this.textBoxRegion.GotFocus += new System.EventHandler(this.textBoxRegion_GotFocus);
            this.textBoxRegion.LostFocus += new System.EventHandler(this.textBoxRegion_LostFocus);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.Text = "Forest";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxForest
            // 
            this.textBoxForest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxForest.Location = new System.Drawing.Point(81, 92);
            this.textBoxForest.Name = "textBoxForest";
            this.textBoxForest.Size = new System.Drawing.Size(149, 21);
            this.textBoxForest.TabIndex = 9;
            this.textBoxForest.TabStop = false;
            this.textBoxForest.TextChanged += new System.EventHandler(this.textBoxForest_TextChanged);
            this.textBoxForest.GotFocus += new System.EventHandler(this.textBoxForest_GotFocus);
            this.textBoxForest.LostFocus += new System.EventHandler(this.textBoxForest_LostFocus);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(6, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.Text = "District";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxDistrict
            // 
            this.textBoxDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDistrict.Location = new System.Drawing.Point(81, 123);
            this.textBoxDistrict.Name = "textBoxDistrict";
            this.textBoxDistrict.Size = new System.Drawing.Size(149, 21);
            this.textBoxDistrict.TabIndex = 12;
            this.textBoxDistrict.TabStop = false;
            this.textBoxDistrict.TextChanged += new System.EventHandler(this.textBoxDistrict_TextChanged);
            this.textBoxDistrict.GotFocus += new System.EventHandler(this.textBoxDistrict_GotFocus);
            this.textBoxDistrict.LostFocus += new System.EventHandler(this.textBoxDistrict_LostFocus);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(6, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.Text = "Year";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxYear.Location = new System.Drawing.Point(81, 153);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(149, 21);
            this.textBoxYear.TabIndex = 15;
            this.textBoxYear.TabStop = false;
            this.textBoxYear.TextChanged += new System.EventHandler(this.textBoxYear_TextChanged);
            this.textBoxYear.GotFocus += new System.EventHandler(this.textBoxYear_GotFocus);
            this.textBoxYear.LostFocus += new System.EventHandler(this.textBoxYear_LostFocus);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(165, 292);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(72, 25);
            this.buttonOK.TabIndex = 17;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(3, 292);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(72, 25);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // chkDropZeros
            // 
            this.chkDropZeros.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkDropZeros.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkDropZeros.Location = new System.Drawing.Point(81, 180);
            this.chkDropZeros.Name = "chkDropZeros";
            this.chkDropZeros.Size = new System.Drawing.Size(156, 20);
            this.chkDropZeros.TabIndex = 25;
            this.chkDropZeros.Text = "Drop Empty Points";
            this.chkDropZeros.CheckStateChanged += new System.EventHandler(this.chkDropZero_CheckStateChanged);
            // 
            // chkRound
            // 
            this.chkRound.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkRound.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkRound.Location = new System.Drawing.Point(81, 206);
            this.chkRound.Name = "chkRound";
            this.chkRound.Size = new System.Drawing.Size(114, 20);
            this.chkRound.TabIndex = 25;
            this.chkRound.TabStop = false;
            this.chkRound.Text = "Round Points";
            this.chkRound.Visible = false;
            this.chkRound.CheckStateChanged += new System.EventHandler(this.chkRound_CheckStateChanged);
            // 
            // ProjectInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.chkRound);
            this.Controls.Add(this.chkDropZeros);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxDistrict);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxForest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxRegion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxProjDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxProjName);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ProjectInfoForm";
            this.Text = "Project Information";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProjectInfoForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ProjectInfoForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProjName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxProjDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRegion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxForest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDistrict;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox chkDropZeros;
        private System.Windows.Forms.CheckBox chkRound;

    }
}