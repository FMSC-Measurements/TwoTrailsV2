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
            this.btnClose = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnFolder = new System.Windows.Forms.Button();
            this.chkOutAll = new System.Windows.Forms.CheckBox();
            this.chkOutPoints = new System.Windows.Forms.CheckBox();
            this.chkOutProject = new System.Windows.Forms.CheckBox();
            this.chkOutNmea = new System.Windows.Forms.CheckBox();
            this.chkOutMeta = new System.Windows.Forms.CheckBox();
            this.chkOutSummary = new System.Windows.Forms.CheckBox();
            this.chkOutPoly = new System.Windows.Forms.CheckBox();
            this.chkOutGpx = new System.Windows.Forms.CheckBox();
            this.chkOutKmz = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkOutHtml = new System.Windows.Forms.CheckBox();
            this.chkOutShape = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(4, 292);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(4, 4);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(233, 21);
            this.txtFolder.TabIndex = 1;
            this.txtFolder.GotFocus += new System.EventHandler(this.txtFolder_GotFocus);
            this.txtFolder.LostFocus += new System.EventHandler(this.txtFolder_LostFocus);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(167, 292);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(70, 25);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnFolder
            // 
            this.btnFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolder.Location = new System.Drawing.Point(110, 31);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(127, 25);
            this.btnFolder.TabIndex = 3;
            this.btnFolder.Text = "Output Location";
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // chkOutAll
            // 
            this.chkOutAll.Checked = true;
            this.chkOutAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutAll.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkOutAll.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOutAll.Location = new System.Drawing.Point(4, 36);
            this.chkOutAll.Name = "chkOutAll";
            this.chkOutAll.Size = new System.Drawing.Size(100, 20);
            this.chkOutAll.TabIndex = 4;
            this.chkOutAll.Text = "All";
            this.chkOutAll.CheckStateChanged += new System.EventHandler(this.chkOutAll_CheckStateChanged);
            // 
            // chkOutPoints
            // 
            this.chkOutPoints.Checked = true;
            this.chkOutPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutPoints.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkOutPoints.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOutPoints.Location = new System.Drawing.Point(4, 61);
            this.chkOutPoints.Name = "chkOutPoints";
            this.chkOutPoints.Size = new System.Drawing.Size(100, 20);
            this.chkOutPoints.TabIndex = 4;
            this.chkOutPoints.Text = "Points";
            this.chkOutPoints.CheckStateChanged += new System.EventHandler(this.chkOutPoints_CheckStateChanged);
            // 
            // chkOutProject
            // 
            this.chkOutProject.Checked = true;
            this.chkOutProject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutProject.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkOutProject.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOutProject.Location = new System.Drawing.Point(3, 86);
            this.chkOutProject.Name = "chkOutProject";
            this.chkOutProject.Size = new System.Drawing.Size(100, 20);
            this.chkOutProject.TabIndex = 4;
            this.chkOutProject.Text = "Project";
            this.chkOutProject.CheckStateChanged += new System.EventHandler(this.chkOutProject_CheckStateChanged);
            // 
            // chkOutNmea
            // 
            this.chkOutNmea.Checked = true;
            this.chkOutNmea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutNmea.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkOutNmea.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOutNmea.Location = new System.Drawing.Point(3, 111);
            this.chkOutNmea.Name = "chkOutNmea";
            this.chkOutNmea.Size = new System.Drawing.Size(100, 20);
            this.chkOutNmea.TabIndex = 4;
            this.chkOutNmea.Text = "NMEA";
            this.chkOutNmea.CheckStateChanged += new System.EventHandler(this.chkOutNmea_CheckStateChanged);
            // 
            // chkOutMeta
            // 
            this.chkOutMeta.Checked = true;
            this.chkOutMeta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutMeta.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkOutMeta.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOutMeta.Location = new System.Drawing.Point(4, 161);
            this.chkOutMeta.Name = "chkOutMeta";
            this.chkOutMeta.Size = new System.Drawing.Size(100, 20);
            this.chkOutMeta.TabIndex = 4;
            this.chkOutMeta.Text = "MetaData";
            this.chkOutMeta.CheckStateChanged += new System.EventHandler(this.chkOutMeta_CheckStateChanged);
            // 
            // chkOutSummary
            // 
            this.chkOutSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOutSummary.Checked = true;
            this.chkOutSummary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutSummary.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkOutSummary.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOutSummary.Location = new System.Drawing.Point(110, 111);
            this.chkOutSummary.Name = "chkOutSummary";
            this.chkOutSummary.Size = new System.Drawing.Size(100, 20);
            this.chkOutSummary.TabIndex = 4;
            this.chkOutSummary.Text = "Summary";
            this.chkOutSummary.CheckStateChanged += new System.EventHandler(this.chkOutSummary_CheckStateChanged);
            // 
            // chkOutPoly
            // 
            this.chkOutPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOutPoly.Checked = true;
            this.chkOutPoly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutPoly.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkOutPoly.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOutPoly.Location = new System.Drawing.Point(110, 61);
            this.chkOutPoly.Name = "chkOutPoly";
            this.chkOutPoly.Size = new System.Drawing.Size(100, 20);
            this.chkOutPoly.TabIndex = 4;
            this.chkOutPoly.Text = "Polygons";
            this.chkOutPoly.CheckStateChanged += new System.EventHandler(this.chkOutPoly_CheckStateChanged);
            // 
            // chkOutGpx
            // 
            this.chkOutGpx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOutGpx.Checked = true;
            this.chkOutGpx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutGpx.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkOutGpx.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOutGpx.Location = new System.Drawing.Point(110, 86);
            this.chkOutGpx.Name = "chkOutGpx";
            this.chkOutGpx.Size = new System.Drawing.Size(100, 20);
            this.chkOutGpx.TabIndex = 4;
            this.chkOutGpx.Text = "GPX";
            this.chkOutGpx.CheckStateChanged += new System.EventHandler(this.chkOutGpx_CheckStateChanged);
            // 
            // chkOutKmz
            // 
            this.chkOutKmz.Checked = true;
            this.chkOutKmz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutKmz.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkOutKmz.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOutKmz.Location = new System.Drawing.Point(4, 136);
            this.chkOutKmz.Name = "chkOutKmz";
            this.chkOutKmz.Size = new System.Drawing.Size(100, 20);
            this.chkOutKmz.TabIndex = 4;
            this.chkOutKmz.Text = "KMZ";
            this.chkOutKmz.CheckStateChanged += new System.EventHandler(this.chkOutKmz_CheckStateChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.chkOutHtml);
            this.panel1.Controls.Add(this.chkOutShape);
            this.panel1.Controls.Add(this.chkOutSummary);
            this.panel1.Controls.Add(this.chkOutAll);
            this.panel1.Controls.Add(this.chkOutMeta);
            this.panel1.Controls.Add(this.chkOutGpx);
            this.panel1.Controls.Add(this.txtFolder);
            this.panel1.Controls.Add(this.chkOutPoly);
            this.panel1.Controls.Add(this.chkOutKmz);
            this.panel1.Controls.Add(this.btnFolder);
            this.panel1.Controls.Add(this.chkOutNmea);
            this.panel1.Controls.Add(this.chkOutProject);
            this.panel1.Controls.Add(this.chkOutPoints);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 320);
            // 
            // chkOutHtml
            // 
            this.chkOutHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOutHtml.Checked = true;
            this.chkOutHtml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutHtml.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkOutHtml.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOutHtml.Location = new System.Drawing.Point(110, 161);
            this.chkOutHtml.Name = "chkOutHtml";
            this.chkOutHtml.Size = new System.Drawing.Size(100, 20);
            this.chkOutHtml.TabIndex = 4;
            this.chkOutHtml.Text = "HTML";
            this.chkOutHtml.Visible = false;
            this.chkOutHtml.CheckStateChanged += new System.EventHandler(this.chkOutHtml_CheckStateChanged);
            // 
            // chkOutShape
            // 
            this.chkOutShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOutShape.Checked = true;
            this.chkOutShape.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutShape.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkOutShape.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkOutShape.Location = new System.Drawing.Point(110, 136);
            this.chkOutShape.Name = "chkOutShape";
            this.chkOutShape.Size = new System.Drawing.Size(100, 20);
            this.chkOutShape.TabIndex = 4;
            this.chkOutShape.Text = "Shape";
            this.chkOutShape.Visible = false;
            this.chkOutShape.CheckStateChanged += new System.EventHandler(this.chkOutShape_CheckStateChanged);
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ExportForm";
            this.Text = "Export";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.CheckBox chkOutAll;
        private System.Windows.Forms.CheckBox chkOutPoints;
        private System.Windows.Forms.CheckBox chkOutProject;
        private System.Windows.Forms.CheckBox chkOutNmea;
        private System.Windows.Forms.CheckBox chkOutMeta;
        private System.Windows.Forms.CheckBox chkOutSummary;
        private System.Windows.Forms.CheckBox chkOutPoly;
        private System.Windows.Forms.CheckBox chkOutGpx;
        private System.Windows.Forms.CheckBox chkOutKmz;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkOutHtml;
        private System.Windows.Forms.CheckBox chkOutShape;
    }
}