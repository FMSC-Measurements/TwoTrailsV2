namespace TwoTrails.Forms
{
    partial class ExportForm
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
            this.chkOutAll = new System.Windows.Forms.CheckBox();
            this.chkOutPoints = new System.Windows.Forms.CheckBox();
            this.chkOutProject = new System.Windows.Forms.CheckBox();
            this.chkOutNmea = new System.Windows.Forms.CheckBox();
            this.chkOutKmz = new System.Windows.Forms.CheckBox();
            this.chkOutMeta = new System.Windows.Forms.CheckBox();
            this.chkOutPoly = new System.Windows.Forms.CheckBox();
            this.chkOutGpx = new System.Windows.Forms.CheckBox();
            this.chkOutSummary = new System.Windows.Forms.CheckBox();
            this.chkOutShape = new System.Windows.Forms.CheckBox();
            this.chkOutHtml = new System.Windows.Forms.CheckBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkOutAll
            // 
            this.chkOutAll.AutoSize = true;
            this.chkOutAll.Checked = true;
            this.chkOutAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutAll.Location = new System.Drawing.Point(12, 38);
            this.chkOutAll.Name = "chkOutAll";
            this.chkOutAll.Size = new System.Drawing.Size(37, 17);
            this.chkOutAll.TabIndex = 0;
            this.chkOutAll.Text = "All";
            this.chkOutAll.UseVisualStyleBackColor = true;
            this.chkOutAll.CheckedChanged += new System.EventHandler(this.chkOutAll_CheckedChanged);
            // 
            // chkOutPoints
            // 
            this.chkOutPoints.AutoSize = true;
            this.chkOutPoints.Checked = true;
            this.chkOutPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutPoints.Location = new System.Drawing.Point(12, 63);
            this.chkOutPoints.Name = "chkOutPoints";
            this.chkOutPoints.Size = new System.Drawing.Size(55, 17);
            this.chkOutPoints.TabIndex = 0;
            this.chkOutPoints.Text = "Points";
            this.chkOutPoints.UseVisualStyleBackColor = true;
            this.chkOutPoints.CheckedChanged += new System.EventHandler(this.chkOutPoints_CheckedChanged);
            // 
            // chkOutProject
            // 
            this.chkOutProject.AutoSize = true;
            this.chkOutProject.Checked = true;
            this.chkOutProject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutProject.Location = new System.Drawing.Point(12, 86);
            this.chkOutProject.Name = "chkOutProject";
            this.chkOutProject.Size = new System.Drawing.Size(59, 17);
            this.chkOutProject.TabIndex = 0;
            this.chkOutProject.Text = "Project";
            this.chkOutProject.UseVisualStyleBackColor = true;
            this.chkOutProject.CheckedChanged += new System.EventHandler(this.chkOutProject_CheckedChanged);
            // 
            // chkOutNmea
            // 
            this.chkOutNmea.AutoSize = true;
            this.chkOutNmea.Checked = true;
            this.chkOutNmea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutNmea.Location = new System.Drawing.Point(12, 109);
            this.chkOutNmea.Name = "chkOutNmea";
            this.chkOutNmea.Size = new System.Drawing.Size(57, 17);
            this.chkOutNmea.TabIndex = 0;
            this.chkOutNmea.Text = "NMEA";
            this.chkOutNmea.UseVisualStyleBackColor = true;
            this.chkOutNmea.CheckedChanged += new System.EventHandler(this.chkOutNmea_CheckedChanged);
            // 
            // chkOutKmz
            // 
            this.chkOutKmz.AutoSize = true;
            this.chkOutKmz.Checked = true;
            this.chkOutKmz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutKmz.Location = new System.Drawing.Point(12, 132);
            this.chkOutKmz.Name = "chkOutKmz";
            this.chkOutKmz.Size = new System.Drawing.Size(49, 17);
            this.chkOutKmz.TabIndex = 0;
            this.chkOutKmz.Text = "KMZ";
            this.chkOutKmz.UseVisualStyleBackColor = true;
            this.chkOutKmz.CheckedChanged += new System.EventHandler(this.chkOutKmz_CheckedChanged);
            // 
            // chkOutMeta
            // 
            this.chkOutMeta.AutoSize = true;
            this.chkOutMeta.Checked = true;
            this.chkOutMeta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutMeta.Location = new System.Drawing.Point(12, 155);
            this.chkOutMeta.Name = "chkOutMeta";
            this.chkOutMeta.Size = new System.Drawing.Size(73, 17);
            this.chkOutMeta.TabIndex = 0;
            this.chkOutMeta.Text = "MetaData";
            this.chkOutMeta.UseVisualStyleBackColor = true;
            this.chkOutMeta.CheckedChanged += new System.EventHandler(this.chkOutMeta_CheckedChanged);
            // 
            // chkOutPoly
            // 
            this.chkOutPoly.AutoSize = true;
            this.chkOutPoly.Checked = true;
            this.chkOutPoly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutPoly.Location = new System.Drawing.Point(117, 67);
            this.chkOutPoly.Name = "chkOutPoly";
            this.chkOutPoly.Size = new System.Drawing.Size(69, 17);
            this.chkOutPoly.TabIndex = 0;
            this.chkOutPoly.Text = "Polygons";
            this.chkOutPoly.UseVisualStyleBackColor = true;
            this.chkOutPoly.CheckedChanged += new System.EventHandler(this.chkOutPoly_CheckedChanged);
            // 
            // chkOutGpx
            // 
            this.chkOutGpx.AutoSize = true;
            this.chkOutGpx.Checked = true;
            this.chkOutGpx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutGpx.Location = new System.Drawing.Point(117, 90);
            this.chkOutGpx.Name = "chkOutGpx";
            this.chkOutGpx.Size = new System.Drawing.Size(48, 17);
            this.chkOutGpx.TabIndex = 0;
            this.chkOutGpx.Text = "GPX";
            this.chkOutGpx.UseVisualStyleBackColor = true;
            this.chkOutGpx.CheckedChanged += new System.EventHandler(this.chkOutGpx_CheckedChanged);
            // 
            // chkOutSummary
            // 
            this.chkOutSummary.AutoSize = true;
            this.chkOutSummary.Checked = true;
            this.chkOutSummary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutSummary.Location = new System.Drawing.Point(117, 113);
            this.chkOutSummary.Name = "chkOutSummary";
            this.chkOutSummary.Size = new System.Drawing.Size(69, 17);
            this.chkOutSummary.TabIndex = 0;
            this.chkOutSummary.Text = "Summary";
            this.chkOutSummary.UseVisualStyleBackColor = true;
            this.chkOutSummary.CheckedChanged += new System.EventHandler(this.chkOutSummary_CheckedChanged);
            // 
            // chkOutShape
            // 
            this.chkOutShape.AutoSize = true;
            this.chkOutShape.Checked = true;
            this.chkOutShape.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutShape.Location = new System.Drawing.Point(117, 136);
            this.chkOutShape.Name = "chkOutShape";
            this.chkOutShape.Size = new System.Drawing.Size(57, 17);
            this.chkOutShape.TabIndex = 0;
            this.chkOutShape.Text = "Shape";
            this.chkOutShape.UseVisualStyleBackColor = true;
            this.chkOutShape.CheckedChanged += new System.EventHandler(this.chkOutShape_CheckedChanged);
            // 
            // chkOutHtml
            // 
            this.chkOutHtml.AutoSize = true;
            this.chkOutHtml.Checked = true;
            this.chkOutHtml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutHtml.Location = new System.Drawing.Point(117, 159);
            this.chkOutHtml.Name = "chkOutHtml";
            this.chkOutHtml.Size = new System.Drawing.Size(56, 17);
            this.chkOutHtml.TabIndex = 0;
            this.chkOutHtml.Text = "HTML";
            this.chkOutHtml.UseVisualStyleBackColor = true;
            this.chkOutHtml.CheckedChanged += new System.EventHandler(this.chkOutHtml_CheckedChanged);
            // 
            // btnFolder
            // 
            this.btnFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolder.Location = new System.Drawing.Point(117, 38);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(92, 23);
            this.btnFolder.TabIndex = 1;
            this.btnFolder.Text = "Output Location";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(141, 183);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(5, 183);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(12, 12);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(197, 20);
            this.txtFolder.TabIndex = 2;
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 210);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.chkOutHtml);
            this.Controls.Add(this.chkOutMeta);
            this.Controls.Add(this.chkOutShape);
            this.Controls.Add(this.chkOutKmz);
            this.Controls.Add(this.chkOutSummary);
            this.Controls.Add(this.chkOutNmea);
            this.Controls.Add(this.chkOutGpx);
            this.Controls.Add(this.chkOutProject);
            this.Controls.Add(this.chkOutPoly);
            this.Controls.Add(this.chkOutPoints);
            this.Controls.Add(this.chkOutAll);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(237, 248);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(237, 248);
            this.Name = "ExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkOutAll;
        private System.Windows.Forms.CheckBox chkOutPoints;
        private System.Windows.Forms.CheckBox chkOutProject;
        private System.Windows.Forms.CheckBox chkOutNmea;
        private System.Windows.Forms.CheckBox chkOutKmz;
        private System.Windows.Forms.CheckBox chkOutMeta;
        private System.Windows.Forms.CheckBox chkOutPoly;
        private System.Windows.Forms.CheckBox chkOutGpx;
        private System.Windows.Forms.CheckBox chkOutSummary;
        private System.Windows.Forms.CheckBox chkOutShape;
        private System.Windows.Forms.CheckBox chkOutHtml;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFolder;
    }
}