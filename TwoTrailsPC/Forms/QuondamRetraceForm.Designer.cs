namespace TwoTrails.Forms
{
    partial class QuondamRetraceForm
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
            this.lstPoint1 = new System.Windows.Forms.ListBox();
            this.lstPoint2 = new System.Windows.Forms.ListBox();
            this.cboPoly = new System.Windows.Forms.ComboBox();
            this.radUp = new System.Windows.Forms.RadioButton();
            this.radDown = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRetrace = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstPoint1
            // 
            this.lstPoint1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPoint1.FormattingEnabled = true;
            this.lstPoint1.ItemHeight = 15;
            this.lstPoint1.Location = new System.Drawing.Point(12, 33);
            this.lstPoint1.Name = "lstPoint1";
            this.lstPoint1.Size = new System.Drawing.Size(237, 199);
            this.lstPoint1.TabIndex = 0;
            this.lstPoint1.TabStop = false;
            this.lstPoint1.SelectedIndexChanged += new System.EventHandler(this.lstPoint1_SelectedIndexChanged);
            // 
            // lstPoint2
            // 
            this.lstPoint2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPoint2.FormattingEnabled = true;
            this.lstPoint2.ItemHeight = 15;
            this.lstPoint2.Location = new System.Drawing.Point(12, 261);
            this.lstPoint2.Name = "lstPoint2";
            this.lstPoint2.Size = new System.Drawing.Size(237, 199);
            this.lstPoint2.TabIndex = 0;
            this.lstPoint2.TabStop = false;
            this.lstPoint2.SelectedIndexChanged += new System.EventHandler(this.lstPoint2_SelectedIndexChanged);
            // 
            // cboPoly
            // 
            this.cboPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPoly.FormattingEnabled = true;
            this.cboPoly.Location = new System.Drawing.Point(103, 6);
            this.cboPoly.Name = "cboPoly";
            this.cboPoly.Size = new System.Drawing.Size(146, 21);
            this.cboPoly.TabIndex = 1;
            this.cboPoly.TabStop = false;
            this.cboPoly.SelectedIndexChanged += new System.EventHandler(this.cboPoly_SelectedIndexChanged);
            // 
            // radUp
            // 
            this.radUp.AutoSize = true;
            this.radUp.Location = new System.Drawing.Point(61, 238);
            this.radUp.Name = "radUp";
            this.radUp.Size = new System.Drawing.Size(39, 17);
            this.radUp.TabIndex = 2;
            this.radUp.Text = "Up";
            this.radUp.UseVisualStyleBackColor = true;
            this.radUp.CheckedChanged += new System.EventHandler(this.radUp_CheckedChanged);
            // 
            // radDown
            // 
            this.radDown.AutoSize = true;
            this.radDown.Location = new System.Drawing.Point(155, 238);
            this.radDown.Name = "radDown";
            this.radDown.Size = new System.Drawing.Size(53, 17);
            this.radDown.TabIndex = 2;
            this.radDown.Text = "Down";
            this.radDown.UseVisualStyleBackColor = true;
            this.radDown.CheckedChanged += new System.EventHandler(this.radDown_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 466);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRetrace
            // 
            this.btnRetrace.Location = new System.Drawing.Point(174, 466);
            this.btnRetrace.Name = "btnRetrace";
            this.btnRetrace.Size = new System.Drawing.Size(75, 23);
            this.btnRetrace.TabIndex = 3;
            this.btnRetrace.TabStop = false;
            this.btnRetrace.Text = "Retrace";
            this.btnRetrace.UseVisualStyleBackColor = true;
            this.btnRetrace.Click += new System.EventHandler(this.btnRetrace_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Direction:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Polygon:";
            // 
            // QuondamRetraceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 498);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRetrace);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radDown);
            this.Controls.Add(this.radUp);
            this.Controls.Add(this.cboPoly);
            this.Controls.Add(this.lstPoint2);
            this.Controls.Add(this.lstPoint1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(279, 536);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(279, 535);
            this.Name = "QuondamRetraceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quondam Retrace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPoint1;
        private System.Windows.Forms.ListBox lstPoint2;
        private System.Windows.Forms.ComboBox cboPoly;
        private System.Windows.Forms.RadioButton radUp;
        private System.Windows.Forms.RadioButton radDown;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRetrace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}