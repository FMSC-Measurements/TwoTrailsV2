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
            this.listBoxPolygon = new System.Windows.Forms.ListBox();
            this.listBoxPID = new System.Windows.Forms.ListBox();
            this.btnRetrace = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ttPolygonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TtPointBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ttPolygonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtPointBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxPolygon
            // 
            this.listBoxPolygon.DataSource = this.ttPolygonBindingSource;
            this.listBoxPolygon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPolygon.FormattingEnabled = true;
            this.listBoxPolygon.Location = new System.Drawing.Point(3, 16);
            this.listBoxPolygon.Name = "listBoxPolygon";
            this.listBoxPolygon.Size = new System.Drawing.Size(160, 121);
            this.listBoxPolygon.TabIndex = 0;
            this.listBoxPolygon.TabStop = false;
            this.listBoxPolygon.SelectedIndexChanged += new System.EventHandler(this.listBoxPolygon_SelectedIndexChanged);
            // 
            // listBoxPID
            // 
            this.listBoxPID.DataSource = this.TtPointBindingSource;
            this.listBoxPID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPID.FormattingEnabled = true;
            this.listBoxPID.Location = new System.Drawing.Point(167, 16);
            this.listBoxPID.Name = "listBoxPID";
            this.listBoxPID.Size = new System.Drawing.Size(160, 121);
            this.listBoxPID.TabIndex = 0;
            this.listBoxPID.TabStop = false;
            this.listBoxPID.SelectedIndexChanged += new System.EventHandler(this.listBoxPID_SelectedIndexChanged);
            // 
            // btnRetrace
            // 
            this.btnRetrace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetrace.Location = new System.Drawing.Point(3, 143);
            this.btnRetrace.Name = "btnRetrace";
            this.btnRetrace.Size = new System.Drawing.Size(160, 24);
            this.btnRetrace.TabIndex = 1;
            this.btnRetrace.Text = "Retrace";
            this.btnRetrace.UseVisualStyleBackColor = true;
            this.btnRetrace.Click += new System.EventHandler(this.btnRetrace_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Location = new System.Drawing.Point(167, 143);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(160, 24);
            this.btnConvert.TabIndex = 1;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Polygons";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Points";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(TwoTrails.BusinessObjects.QuondamPoint);
            // 
            // ttPolygonBindingSource
            // 
            this.ttPolygonBindingSource.DataSource = typeof(TwoTrails.BusinessObjects.TtPolygon);
            // 
            // TtPointBindingSource
            // 
            this.TtPointBindingSource.DataSource = typeof(TwoTrails.BusinessObjects.TtPoint);
            // 
            // QuondamInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnRetrace);
            this.Controls.Add(this.listBoxPID);
            this.Controls.Add(this.listBoxPolygon);
            this.Name = "QuondamInfoControl";
            this.Size = new System.Drawing.Size(330, 170);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ttPolygonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtPointBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPolygon;
        private System.Windows.Forms.ListBox listBoxPID;
        private System.Windows.Forms.Button btnRetrace;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource ttPolygonBindingSource;
        private System.Windows.Forms.BindingSource TtPointBindingSource;
    }
}
