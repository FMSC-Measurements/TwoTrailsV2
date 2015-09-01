namespace TwoTrails.Forms
{
    partial class SelectFileDialogEx
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstBrowse = new System.Windows.Forms.ListBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnNewFolder = new System.Windows.Forms.Button();
            this.pnlFolder = new System.Windows.Forms.Panel();
            this.btnFolderCreate = new System.Windows.Forms.Button();
            this.btnFolderCancel = new System.Windows.Forms.Button();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblDir = new System.Windows.Forms.Label();
            this.pnlFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(165, 271);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 20);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(3, 271);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 20);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstBrowse
            // 
            this.lstBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBrowse.BackColor = System.Drawing.SystemColors.GrayText;
            this.lstBrowse.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lstBrowse.Location = new System.Drawing.Point(0, 75);
            this.lstBrowse.Name = "lstBrowse";
            this.lstBrowse.Size = new System.Drawing.Size(240, 194);
            this.lstBrowse.TabIndex = 1;
            this.lstBrowse.TabStop = false;
            this.lstBrowse.SelectedIndexChanged += new System.EventHandler(this.lstBrowse_SelectedIndexChanged);
            this.lstBrowse.GotFocus += new System.EventHandler(this.lstBrowse_GotFocus);
            // 
            // cboType
            // 
            this.cboType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboType.Location = new System.Drawing.Point(0, 0);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(240, 22);
            this.cboType.TabIndex = 2;
            this.cboType.TabStop = false;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            this.cboType.GotFocus += new System.EventHandler(this.cboType_GotFocus);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtFileName.Location = new System.Drawing.Point(77, 22);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(163, 23);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.TabStop = false;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            this.txtFileName.GotFocus += new System.EventHandler(this.txtFileName_GotFocus);
            this.txtFileName.LostFocus += new System.EventHandler(this.txtFileName_LostFocus);
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewFolder.Location = new System.Drawing.Point(81, 271);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(78, 20);
            this.btnNewFolder.TabIndex = 0;
            this.btnNewFolder.TabStop = false;
            this.btnNewFolder.Text = "New Folder";
            this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
            // 
            // pnlFolder
            // 
            this.pnlFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFolder.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlFolder.Controls.Add(this.btnFolderCreate);
            this.pnlFolder.Controls.Add(this.btnFolderCancel);
            this.pnlFolder.Controls.Add(this.txtFolderName);
            this.pnlFolder.Location = new System.Drawing.Point(0, 105);
            this.pnlFolder.Name = "pnlFolder";
            this.pnlFolder.Size = new System.Drawing.Size(240, 62);
            this.pnlFolder.Visible = false;
            // 
            // btnFolderCreate
            // 
            this.btnFolderCreate.Location = new System.Drawing.Point(118, 36);
            this.btnFolderCreate.Name = "btnFolderCreate";
            this.btnFolderCreate.Size = new System.Drawing.Size(72, 20);
            this.btnFolderCreate.TabIndex = 1;
            this.btnFolderCreate.TabStop = false;
            this.btnFolderCreate.Text = "Create";
            this.btnFolderCreate.Click += new System.EventHandler(this.btnFolderCreate_Click);
            // 
            // btnFolderCancel
            // 
            this.btnFolderCancel.Location = new System.Drawing.Point(40, 36);
            this.btnFolderCancel.Name = "btnFolderCancel";
            this.btnFolderCancel.Size = new System.Drawing.Size(72, 20);
            this.btnFolderCancel.TabIndex = 1;
            this.btnFolderCancel.TabStop = false;
            this.btnFolderCancel.Text = "Cancel";
            this.btnFolderCancel.Click += new System.EventHandler(this.btnFolderCancel_Click);
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point(3, 9);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(234, 21);
            this.txtFolderName.TabIndex = 0;
            this.txtFolderName.TabStop = false;
            this.txtFolderName.GotFocus += new System.EventHandler(this.txtFolderName_GotFocus);
            // 
            // lblDesc
            // 
            this.lblDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblDesc.ForeColor = System.Drawing.Color.Black;
            this.lblDesc.Location = new System.Drawing.Point(0, 25);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(78, 20);
            this.lblDesc.Text = "File Name:";
            // 
            // lblDir
            // 
            this.lblDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDir.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblDir.Location = new System.Drawing.Point(0, 45);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(240, 20);
            this.lblDir.Text = "Directory";
            this.lblDir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SelectFileDialogEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblDir);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.pnlFolder);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNewFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstBrowse);
            this.Controls.Add(this.cboType);
            this.Name = "SelectFileDialogEx";
            this.Text = "Select File";
            this.Load += new System.EventHandler(this.SelectFileDialogEx_Load);
            this.pnlFolder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstBrowse;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnNewFolder;
        private System.Windows.Forms.Panel pnlFolder;
        private System.Windows.Forms.Button btnFolderCreate;
        private System.Windows.Forms.Button btnFolderCancel;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblDir;
    }
}