namespace TwoTrails.Forms
{
    partial class EditPointTableForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridPoints = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cstsmiResetRow = new System.Windows.Forms.ToolStripMenuItem();
            this.cstsmiResetTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResetRow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResetTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIDs = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPoints)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridPoints
            // 
            this.dataGridPoints.AllowUserToAddRows = false;
            this.dataGridPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPoints.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPoints.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridPoints.Location = new System.Drawing.Point(0, 24);
            this.dataGridPoints.Name = "dataGridPoints";
            this.dataGridPoints.Size = new System.Drawing.Size(740, 413);
            this.dataGridPoints.TabIndex = 0;
            this.dataGridPoints.TabStop = false;
            this.dataGridPoints.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPoints_CellValueChanged);
            this.dataGridPoints.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridPoints_CellMouseDown);
            this.dataGridPoints.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridPoints_CellValidating);
            this.dataGridPoints.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPoints_CellEndEdit);
            this.dataGridPoints.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridPoints_DataError);
            this.dataGridPoints.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPoints_CellContentClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cstsmiResetRow,
            this.cstsmiResetTable});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(135, 48);
            // 
            // cstsmiResetRow
            // 
            this.cstsmiResetRow.Name = "cstsmiResetRow";
            this.cstsmiResetRow.Size = new System.Drawing.Size(134, 22);
            this.cstsmiResetRow.Text = "Reset Row";
            this.cstsmiResetRow.Click += new System.EventHandler(this.cstsmiResetRow_Click);
            // 
            // cstsmiResetTable
            // 
            this.cstsmiResetTable.Name = "cstsmiResetTable";
            this.cstsmiResetTable.Size = new System.Drawing.Size(134, 22);
            this.cstsmiResetTable.Text = "Reset Table";
            this.cstsmiResetTable.Visible = false;
            this.cstsmiResetTable.Click += new System.EventHandler(this.cstsmiResetTable_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.tsmiClose});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(740, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.tsmiSaveClose,
            this.tsmiExport,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "File";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSave.Size = new System.Drawing.Size(179, 22);
            this.tsmiSave.Text = "Save";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiSaveClose
            // 
            this.tsmiSaveClose.Name = "tsmiSaveClose";
            this.tsmiSaveClose.Size = new System.Drawing.Size(179, 22);
            this.tsmiSaveClose.Text = "Save and Close";
            this.tsmiSaveClose.Click += new System.EventHandler(this.tsmiSaveClose_Click);
            // 
            // tsmiExport
            // 
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmiExport.Size = new System.Drawing.Size(179, 22);
            this.tsmiExport.Text = "Export Table";
            this.tsmiExport.Visible = false;
            this.tsmiExport.Click += new System.EventHandler(this.tsmiExport_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tsmiExit.Size = new System.Drawing.Size(179, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiResetRow,
            this.tsmiResetTable,
            this.tsmiIDs});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // tsmiResetRow
            // 
            this.tsmiResetRow.Name = "tsmiResetRow";
            this.tsmiResetRow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiResetRow.Size = new System.Drawing.Size(176, 22);
            this.tsmiResetRow.Text = "Reset Row";
            this.tsmiResetRow.Click += new System.EventHandler(this.tsmiResetRow_Click);
            // 
            // tsmiResetTable
            // 
            this.tsmiResetTable.Name = "tsmiResetTable";
            this.tsmiResetTable.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.tsmiResetTable.Size = new System.Drawing.Size(176, 22);
            this.tsmiResetTable.Text = "Reset Table";
            this.tsmiResetTable.Click += new System.EventHandler(this.tsmiResetTable_Click);
            // 
            // tsmiIDs
            // 
            this.tsmiIDs.CheckOnClick = true;
            this.tsmiIDs.Name = "tsmiIDs";
            this.tsmiIDs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsmiIDs.Size = new System.Drawing.Size(176, 22);
            this.tsmiIDs.Text = "Show IDs";
            this.tsmiIDs.Click += new System.EventHandler(this.tsmiIDs_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 440);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(740, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(37, 17);
            this.tsslStatus.Text = "          ";
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(48, 20);
            this.tsmiClose.Text = "Close";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // EditPointTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 462);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.dataGridPoints);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "EditPointTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Point Table";
            this.Load += new System.EventHandler(this.EditPointTableForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditPointTableForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPoints)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPoints;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiResetRow;
        private System.Windows.Forms.ToolStripMenuItem tsmiResetTable;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveClose;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cstsmiResetRow;
        private System.Windows.Forms.ToolStripMenuItem cstsmiResetTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiIDs;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
    }
}