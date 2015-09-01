namespace TwoTrails.Forms
{
    partial class MassEditPointLocManip
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
            this.radMove = new System.Windows.Forms.RadioButton();
            this.radQuondam = new System.Windows.Forms.RadioButton();
            this.cboTargetPoly = new System.Windows.Forms.ComboBox();
            this.cboInsertPoint = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radAfter = new System.Windows.Forms.RadioButton();
            this.radBegining = new System.Windows.Forms.RadioButton();
            this.radAtEnd = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radRevTrue = new System.Windows.Forms.RadioButton();
            this.radRevFalse = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // radMove
            // 
            this.radMove.AutoSize = true;
            this.radMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMove.Location = new System.Drawing.Point(6, 19);
            this.radMove.Name = "radMove";
            this.radMove.Size = new System.Drawing.Size(59, 19);
            this.radMove.TabIndex = 0;
            this.radMove.Text = "Move";
            this.radMove.UseVisualStyleBackColor = true;
            // 
            // radQuondam
            // 
            this.radQuondam.AutoSize = true;
            this.radQuondam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radQuondam.Location = new System.Drawing.Point(6, 44);
            this.radQuondam.Name = "radQuondam";
            this.radQuondam.Size = new System.Drawing.Size(87, 19);
            this.radQuondam.TabIndex = 0;
            this.radQuondam.Text = "Quondam";
            this.radQuondam.UseVisualStyleBackColor = true;
            // 
            // cboTargetPoly
            // 
            this.cboTargetPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTargetPoly.FormattingEnabled = true;
            this.cboTargetPoly.Location = new System.Drawing.Point(6, 19);
            this.cboTargetPoly.Name = "cboTargetPoly";
            this.cboTargetPoly.Size = new System.Drawing.Size(136, 21);
            this.cboTargetPoly.TabIndex = 1;
            this.cboTargetPoly.TabStop = false;
            this.cboTargetPoly.SelectedIndexChanged += new System.EventHandler(this.cboTargetPoly_SelectedIndexChanged);
            // 
            // cboInsertPoint
            // 
            this.cboInsertPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInsertPoint.Enabled = false;
            this.cboInsertPoint.FormattingEnabled = true;
            this.cboInsertPoint.Location = new System.Drawing.Point(6, 69);
            this.cboInsertPoint.Name = "cboInsertPoint";
            this.cboInsertPoint.Size = new System.Drawing.Size(136, 21);
            this.cboInsertPoint.TabIndex = 1;
            this.cboInsertPoint.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboInsertPoint);
            this.groupBox1.Controls.Add(this.radAfter);
            this.groupBox1.Controls.Add(this.radBegining);
            this.groupBox1.Controls.Add(this.radAtEnd);
            this.groupBox1.Location = new System.Drawing.Point(166, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Insert Location";
            // 
            // radAfter
            // 
            this.radAfter.AutoSize = true;
            this.radAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAfter.Location = new System.Drawing.Point(6, 44);
            this.radAfter.Name = "radAfter";
            this.radAfter.Size = new System.Drawing.Size(95, 19);
            this.radAfter.TabIndex = 0;
            this.radAfter.Text = "After Point:";
            this.radAfter.UseVisualStyleBackColor = true;
            this.radAfter.CheckedChanged += new System.EventHandler(this.radAfter_CheckedChanged);
            // 
            // radBegining
            // 
            this.radBegining.AutoSize = true;
            this.radBegining.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBegining.Location = new System.Drawing.Point(62, 19);
            this.radBegining.Name = "radBegining";
            this.radBegining.Size = new System.Drawing.Size(82, 19);
            this.radBegining.TabIndex = 0;
            this.radBegining.Text = "Begining";
            this.radBegining.UseVisualStyleBackColor = true;
            // 
            // radAtEnd
            // 
            this.radAtEnd.AutoSize = true;
            this.radAtEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAtEnd.Location = new System.Drawing.Point(6, 19);
            this.radAtEnd.Name = "radAtEnd";
            this.radAtEnd.Size = new System.Drawing.Size(50, 19);
            this.radAtEnd.TabIndex = 0;
            this.radAtEnd.Text = "End";
            this.radAtEnd.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radMove);
            this.groupBox2.Controls.Add(this.radQuondam);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 69);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Move Type";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboTargetPoly);
            this.groupBox3.Location = new System.Drawing.Point(166, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(148, 46);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Target Polygon";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radRevTrue);
            this.groupBox4.Controls.Add(this.radRevFalse);
            this.groupBox4.Location = new System.Drawing.Point(12, 87);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(148, 74);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Direction";
            // 
            // radRevTrue
            // 
            this.radRevTrue.AutoSize = true;
            this.radRevTrue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRevTrue.Location = new System.Drawing.Point(6, 46);
            this.radRevTrue.Name = "radRevTrue";
            this.radRevTrue.Size = new System.Drawing.Size(77, 19);
            this.radRevTrue.TabIndex = 0;
            this.radRevTrue.Text = "Reverse";
            this.radRevTrue.UseVisualStyleBackColor = true;
            // 
            // radRevFalse
            // 
            this.radRevFalse.AutoSize = true;
            this.radRevFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRevFalse.Location = new System.Drawing.Point(6, 19);
            this.radRevFalse.Name = "radRevFalse";
            this.radRevFalse.Size = new System.Drawing.Size(77, 19);
            this.radRevFalse.TabIndex = 0;
            this.radRevFalse.Text = "Forward";
            this.radRevFalse.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(239, 167);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 5;
            this.btnCommit.TabStop = false;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // MassEditPointLocManip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 196);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(341, 234);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(341, 234);
            this.Name = "MassEditPointLocManip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Point Location Manipulation";
            this.Load += new System.EventHandler(this.MassEditPointLocManip_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radMove;
        private System.Windows.Forms.RadioButton radQuondam;
        private System.Windows.Forms.ComboBox cboTargetPoly;
        private System.Windows.Forms.ComboBox cboInsertPoint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radAfter;
        private System.Windows.Forms.RadioButton radBegining;
        private System.Windows.Forms.RadioButton radAtEnd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radRevTrue;
        private System.Windows.Forms.RadioButton radRevFalse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCommit;
    }
}