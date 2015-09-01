namespace TwoTrails.Forms
{
    partial class MergePolygonForm
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
            this.cboPoly1 = new System.Windows.Forms.ComboBox();
            this.cboPoly2 = new System.Windows.Forms.ComboBox();
            this.cboStartPointPoly1 = new System.Windows.Forms.ComboBox();
            this.cboStartPointPoly2 = new System.Windows.Forms.ComboBox();
            this.cboEndPointPoly1 = new System.Windows.Forms.ComboBox();
            this.cboEndPointPoly2 = new System.Windows.Forms.ComboBox();
            this.txtNewPolyName = new System.Windows.Forms.TextBox();
            this.radPointsQndm = new System.Windows.Forms.RadioButton();
            this.radPointsCopy = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radPoly1CCW = new System.Windows.Forms.RadioButton();
            this.radPoly1CW = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radPoly2CCW = new System.Windows.Forms.RadioButton();
            this.radPoly2CW = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPoly1
            // 
            this.cboPoly1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPoly1.FormattingEnabled = true;
            this.cboPoly1.Location = new System.Drawing.Point(6, 22);
            this.cboPoly1.Name = "cboPoly1";
            this.cboPoly1.Size = new System.Drawing.Size(121, 21);
            this.cboPoly1.TabIndex = 0;
            this.cboPoly1.TabStop = false;
            this.cboPoly1.SelectedIndexChanged += new System.EventHandler(this.cboPoly1_SelectedIndexChanged);
            // 
            // cboPoly2
            // 
            this.cboPoly2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPoly2.FormattingEnabled = true;
            this.cboPoly2.Location = new System.Drawing.Point(133, 22);
            this.cboPoly2.Name = "cboPoly2";
            this.cboPoly2.Size = new System.Drawing.Size(121, 21);
            this.cboPoly2.TabIndex = 0;
            this.cboPoly2.TabStop = false;
            this.cboPoly2.SelectedIndexChanged += new System.EventHandler(this.cboPoly2_SelectedIndexChanged);
            // 
            // cboStartPointPoly1
            // 
            this.cboStartPointPoly1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartPointPoly1.FormattingEnabled = true;
            this.cboStartPointPoly1.Location = new System.Drawing.Point(6, 65);
            this.cboStartPointPoly1.Name = "cboStartPointPoly1";
            this.cboStartPointPoly1.Size = new System.Drawing.Size(121, 21);
            this.cboStartPointPoly1.TabIndex = 0;
            this.cboStartPointPoly1.TabStop = false;
            this.cboStartPointPoly1.SelectedIndexChanged += new System.EventHandler(this.cboStartPointPoly1_SelectedIndexChanged);
            // 
            // cboStartPointPoly2
            // 
            this.cboStartPointPoly2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartPointPoly2.FormattingEnabled = true;
            this.cboStartPointPoly2.Location = new System.Drawing.Point(133, 65);
            this.cboStartPointPoly2.Name = "cboStartPointPoly2";
            this.cboStartPointPoly2.Size = new System.Drawing.Size(121, 21);
            this.cboStartPointPoly2.TabIndex = 0;
            this.cboStartPointPoly2.TabStop = false;
            this.cboStartPointPoly2.SelectedIndexChanged += new System.EventHandler(this.cboStartPointPoly2_SelectedIndexChanged);
            // 
            // cboEndPointPoly1
            // 
            this.cboEndPointPoly1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndPointPoly1.FormattingEnabled = true;
            this.cboEndPointPoly1.Location = new System.Drawing.Point(6, 108);
            this.cboEndPointPoly1.Name = "cboEndPointPoly1";
            this.cboEndPointPoly1.Size = new System.Drawing.Size(121, 21);
            this.cboEndPointPoly1.TabIndex = 0;
            this.cboEndPointPoly1.TabStop = false;
            this.cboEndPointPoly1.SelectedIndexChanged += new System.EventHandler(this.cboEndPointPoly1_SelectedIndexChanged);
            // 
            // cboEndPointPoly2
            // 
            this.cboEndPointPoly2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndPointPoly2.FormattingEnabled = true;
            this.cboEndPointPoly2.Location = new System.Drawing.Point(133, 108);
            this.cboEndPointPoly2.Name = "cboEndPointPoly2";
            this.cboEndPointPoly2.Size = new System.Drawing.Size(121, 21);
            this.cboEndPointPoly2.TabIndex = 0;
            this.cboEndPointPoly2.TabStop = false;
            this.cboEndPointPoly2.SelectedIndexChanged += new System.EventHandler(this.cboEndPointPoly2_SelectedIndexChanged);
            // 
            // txtNewPolyName
            // 
            this.txtNewPolyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNewPolyName.Location = new System.Drawing.Point(133, 181);
            this.txtNewPolyName.Name = "txtNewPolyName";
            this.txtNewPolyName.Size = new System.Drawing.Size(121, 20);
            this.txtNewPolyName.TabIndex = 1;
            this.txtNewPolyName.TabStop = false;
            // 
            // radPointsQndm
            // 
            this.radPointsQndm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radPointsQndm.AutoSize = true;
            this.radPointsQndm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPointsQndm.Location = new System.Drawing.Point(119, 159);
            this.radPointsQndm.Name = "radPointsQndm";
            this.radPointsQndm.Size = new System.Drawing.Size(139, 20);
            this.radPointsQndm.TabIndex = 2;
            this.radPointsQndm.Text = "Quondam Points";
            this.radPointsQndm.UseVisualStyleBackColor = true;
            // 
            // radPointsCopy
            // 
            this.radPointsCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radPointsCopy.AutoSize = true;
            this.radPointsCopy.Checked = true;
            this.radPointsCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPointsCopy.Location = new System.Drawing.Point(6, 159);
            this.radPointsCopy.Name = "radPointsCopy";
            this.radPointsCopy.Size = new System.Drawing.Size(109, 20);
            this.radPointsCopy.TabIndex = 2;
            this.radPointsCopy.TabStop = true;
            this.radPointsCopy.Text = "Copy Points";
            this.radPointsCopy.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(6, 207);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMerge.Location = new System.Drawing.Point(178, 207);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 3;
            this.btnMerge.TabStop = false;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Polygon 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(156, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Polygon 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Start Merge Point";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "End Merge Point";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "New Poly Name:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radPoly1CCW);
            this.panel1.Controls.Add(this.radPoly1CW);
            this.panel1.Location = new System.Drawing.Point(6, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(122, 22);
            this.panel1.TabIndex = 5;
            // 
            // radPoly1CCW
            // 
            this.radPoly1CCW.AutoSize = true;
            this.radPoly1CCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPoly1CCW.Location = new System.Drawing.Point(56, 0);
            this.radPoly1CCW.Name = "radPoly1CCW";
            this.radPoly1CCW.Size = new System.Drawing.Size(60, 20);
            this.radPoly1CCW.TabIndex = 0;
            this.radPoly1CCW.Text = "CCW";
            this.radPoly1CCW.UseVisualStyleBackColor = true;
            // 
            // radPoly1CW
            // 
            this.radPoly1CW.AutoSize = true;
            this.radPoly1CW.Checked = true;
            this.radPoly1CW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPoly1CW.Location = new System.Drawing.Point(0, 0);
            this.radPoly1CW.Name = "radPoly1CW";
            this.radPoly1CW.Size = new System.Drawing.Size(50, 20);
            this.radPoly1CW.TabIndex = 0;
            this.radPoly1CW.TabStop = true;
            this.radPoly1CW.Text = "CW";
            this.radPoly1CW.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radPoly2CCW);
            this.panel2.Controls.Add(this.radPoly2CW);
            this.panel2.Location = new System.Drawing.Point(133, 136);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(122, 22);
            this.panel2.TabIndex = 5;
            // 
            // radPoly2CCW
            // 
            this.radPoly2CCW.AutoSize = true;
            this.radPoly2CCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPoly2CCW.Location = new System.Drawing.Point(56, 0);
            this.radPoly2CCW.Name = "radPoly2CCW";
            this.radPoly2CCW.Size = new System.Drawing.Size(60, 20);
            this.radPoly2CCW.TabIndex = 0;
            this.radPoly2CCW.Text = "CCW";
            this.radPoly2CCW.UseVisualStyleBackColor = true;
            // 
            // radPoly2CW
            // 
            this.radPoly2CW.AutoSize = true;
            this.radPoly2CW.Checked = true;
            this.radPoly2CW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPoly2CW.Location = new System.Drawing.Point(0, 0);
            this.radPoly2CW.Name = "radPoly2CW";
            this.radPoly2CW.Size = new System.Drawing.Size(50, 20);
            this.radPoly2CW.TabIndex = 0;
            this.radPoly2CW.TabStop = true;
            this.radPoly2CW.Text = "CW";
            this.radPoly2CW.UseVisualStyleBackColor = true;
            // 
            // MergePolygonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 236);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.radPointsCopy);
            this.Controls.Add(this.radPointsQndm);
            this.Controls.Add(this.txtNewPolyName);
            this.Controls.Add(this.cboEndPointPoly2);
            this.Controls.Add(this.cboStartPointPoly2);
            this.Controls.Add(this.cboEndPointPoly1);
            this.Controls.Add(this.cboStartPointPoly1);
            this.Controls.Add(this.cboPoly2);
            this.Controls.Add(this.cboPoly1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(280, 274);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(280, 274);
            this.Name = "MergePolygonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Merge Polygons";
            this.Load += new System.EventHandler(this.MergePolygonForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MergePolygonForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPoly1;
        private System.Windows.Forms.ComboBox cboPoly2;
        private System.Windows.Forms.ComboBox cboStartPointPoly1;
        private System.Windows.Forms.ComboBox cboStartPointPoly2;
        private System.Windows.Forms.ComboBox cboEndPointPoly1;
        private System.Windows.Forms.ComboBox cboEndPointPoly2;
        private System.Windows.Forms.TextBox txtNewPolyName;
        private System.Windows.Forms.RadioButton radPointsQndm;
        private System.Windows.Forms.RadioButton radPointsCopy;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radPoly1CCW;
        private System.Windows.Forms.RadioButton radPoly1CW;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radPoly2CCW;
        private System.Windows.Forms.RadioButton radPoly2CW;
    }
}