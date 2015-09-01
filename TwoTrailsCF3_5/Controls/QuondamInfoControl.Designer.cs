namespace TwoTrails.Controls
{
    partial class QuondamInfoControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.TtPointBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxPID = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ttPolygonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxPolygon = new System.Windows.Forms.ListBox();
            this.btnRetrace = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnConvert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TtPointBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ttPolygonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.Text = "Polygons";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TtPointBindingSource
            // 
            this.TtPointBindingSource.DataSource = typeof(TwoTrails.BusinessObjects.TtPoint);
            // 
            // listBoxPID
            // 
            this.listBoxPID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPID.DataSource = this.TtPointBindingSource;
            this.listBoxPID.DisplayMember = "PID";
            this.listBoxPID.Location = new System.Drawing.Point(117, 16);
            this.listBoxPID.Name = "listBoxPID";
            this.listBoxPID.Size = new System.Drawing.Size(115, 86);
            this.listBoxPID.TabIndex = 2;
            this.listBoxPID.SelectedIndexChanged += new System.EventHandler(this.listBoxPID_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(121, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.Text = "Points";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ttPolygonBindingSource
            // 
            this.ttPolygonBindingSource.DataSource = typeof(TwoTrails.BusinessObjects.TtPolygon);
            // 
            // listBoxPolygon
            // 
            this.listBoxPolygon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxPolygon.DataSource = this.ttPolygonBindingSource;
            this.listBoxPolygon.DisplayMember = "Name";
            this.listBoxPolygon.Location = new System.Drawing.Point(3, 16);
            this.listBoxPolygon.Name = "listBoxPolygon";
            this.listBoxPolygon.Size = new System.Drawing.Size(108, 86);
            this.listBoxPolygon.TabIndex = 5;
            this.listBoxPolygon.SelectedIndexChanged += new System.EventHandler(this.listBoxPolygon_SelectedIndexChanged);
            // 
            // btnRetrace
            // 
            this.btnRetrace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRetrace.Location = new System.Drawing.Point(3, 105);
            this.btnRetrace.Name = "btnRetrace";
            this.btnRetrace.Size = new System.Drawing.Size(108, 20);
            this.btnRetrace.TabIndex = 6;
            this.btnRetrace.Text = "Retrace";
            this.btnRetrace.Click += new System.EventHandler(this.btnRetrace_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(TwoTrails.BusinessObjects.QuondamPoint);
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(117, 105);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(115, 20);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Tag = "Convert Quondam to its Linked Point";
            this.btnConvert.Text = "Convert";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // QuondamInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnRetrace);
            this.Controls.Add(this.listBoxPolygon);
            this.Controls.Add(this.listBoxPID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "QuondamInfoControl";
            this.Size = new System.Drawing.Size(235, 128);
            ((System.ComponentModel.ISupportInitialize)(this.TtPointBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ttPolygonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxPID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxPolygon;
        private System.Windows.Forms.Button btnRetrace;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource ttPolygonBindingSource;
        private System.Windows.Forms.BindingSource TtPointBindingSource;
        private System.Windows.Forms.Button btnConvert;
    }
}
