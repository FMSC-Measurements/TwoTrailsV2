namespace TwoTrails.Controls
{
    partial class PointInfoCtrl
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
            this.tbPID = new System.Windows.Forms.TextBox();
            this.bindingSourcePoint = new System.Windows.Forms.BindingSource(this.components);
            this.tbComment = new System.Windows.Forms.TextBox();
            this.cbPoly = new System.Windows.Forms.ComboBox();
            this.bindingSourcePolys = new System.Windows.Forms.BindingSource(this.components);
            this.cbMetaDef = new System.Windows.Forms.ComboBox();
            this.btnBoundary = new System.Windows.Forms.Button();
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.picLinked = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bindingSourceMetaDefs = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceOps = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePolys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLinked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMetaDefs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOps)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPID
            // 
            this.tbPID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "PID", true));
            this.tbPID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPID.Location = new System.Drawing.Point(46, 3);
            this.tbPID.Name = "tbPID";
            this.tbPID.Size = new System.Drawing.Size(100, 22);
            this.tbPID.TabIndex = 0;
            this.tbPID.TabStop = false;
            this.tbPID.TextChanged += new System.EventHandler(this.tbPID_TextChanged);
            // 
            // bindingSourcePoint
            // 
            this.bindingSourcePoint.DataSource = typeof(TwoTrails.BusinessObjects.TtPoint);
            // 
            // tbComment
            // 
            this.tbComment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "Comment", true));
            this.tbComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbComment.Location = new System.Drawing.Point(46, 60);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(281, 22);
            this.tbComment.TabIndex = 3;
            this.tbComment.TabStop = false;
            this.tbComment.TextChanged += new System.EventHandler(this.tbComment_TextChanged);
            // 
            // cbPoly
            // 
            this.cbPoly.DataSource = this.bindingSourcePolys;
            this.cbPoly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPoly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoly.FormattingEnabled = true;
            this.cbPoly.Location = new System.Drawing.Point(227, 3);
            this.cbPoly.Name = "cbPoly";
            this.cbPoly.Size = new System.Drawing.Size(100, 24);
            this.cbPoly.TabIndex = 2;
            this.cbPoly.TabStop = false;
            this.cbPoly.SelectedIndexChanged += new System.EventHandler(this.cbPoly_SelectedIndexChanged);
            // 
            // bindingSourcePolys
            // 
            this.bindingSourcePolys.DataSource = typeof(TwoTrails.BusinessObjects.TtPolygon);
            // 
            // cbMetaDef
            // 
            this.cbMetaDef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetaDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMetaDef.FormattingEnabled = true;
            this.cbMetaDef.Location = new System.Drawing.Point(78, 88);
            this.cbMetaDef.Name = "cbMetaDef";
            this.cbMetaDef.Size = new System.Drawing.Size(134, 24);
            this.cbMetaDef.TabIndex = 2;
            this.cbMetaDef.TabStop = false;
            this.cbMetaDef.SelectedIndexChanged += new System.EventHandler(this.cbMetaDef_SelectedIndexChanged);
            // 
            // btnBoundary
            // 
            this.btnBoundary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoundary.Location = new System.Drawing.Point(236, 31);
            this.btnBoundary.Name = "btnBoundary";
            this.btnBoundary.Size = new System.Drawing.Size(91, 23);
            this.btnBoundary.TabIndex = 2;
            this.btnBoundary.TabStop = false;
            this.btnBoundary.Text = "On";
            this.btnBoundary.UseVisualStyleBackColor = true;
            this.btnBoundary.Click += new System.EventHandler(this.btnBoundary_Click);
            // 
            // chkLocked
            // 
            this.chkLocked.AutoSize = true;
            this.chkLocked.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLocked.Location = new System.Drawing.Point(218, 90);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(78, 20);
            this.chkLocked.TabIndex = 4;
            this.chkLocked.TabStop = false;
            this.chkLocked.Text = "Locked";
            this.chkLocked.UseVisualStyleBackColor = true;
            this.chkLocked.CheckedChanged += new System.EventHandler(this.chkLocked_CheckedChanged);
            // 
            // picLinked
            // 
            this.picLinked.InitialImage = global::TwoTrails.Properties.Resources.ChainLink_512;
            this.picLinked.Location = new System.Drawing.Point(302, 88);
            this.picLinked.Name = "picLinked";
            this.picLinked.Size = new System.Drawing.Size(25, 25);
            this.picLinked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLinked.TabIndex = 5;
            this.picLinked.TabStop = false;
            this.picLinked.Visible = false;
            this.picLinked.Click += new System.EventHandler(this.picLinked_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "PID:";
            // 
            // cbOp
            // 
            this.cbOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOp.FormattingEnabled = true;
            this.cbOp.Location = new System.Drawing.Point(46, 31);
            this.cbOp.Name = "cbOp";
            this.cbOp.Size = new System.Drawing.Size(100, 24);
            this.cbOp.TabIndex = 1;
            this.cbOp.TabStop = false;
            this.cbOp.SelectedIndexChanged += new System.EventHandler(this.cbOp_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(152, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Polygon:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Op:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(152, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Boundary:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Cmt:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "MetaDef:";
            // 
            // bindingSourceMetaDefs
            // 
            this.bindingSourceMetaDefs.DataSource = typeof(TwoTrails.BusinessObjects.TtMetaData);
            // 
            // PointInfoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picLinked);
            this.Controls.Add(this.chkLocked);
            this.Controls.Add(this.btnBoundary);
            this.Controls.Add(this.cbOp);
            this.Controls.Add(this.cbMetaDef);
            this.Controls.Add(this.cbPoly);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.tbPID);
            this.Name = "PointInfoCtrl";
            this.Size = new System.Drawing.Size(330, 115);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePolys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLinked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMetaDefs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPID;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.ComboBox cbPoly;
        private System.Windows.Forms.ComboBox cbMetaDef;
        private System.Windows.Forms.Button btnBoundary;
        private System.Windows.Forms.CheckBox chkLocked;
        private System.Windows.Forms.PictureBox picLinked;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbOp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bindingSourcePoint;
        private System.Windows.Forms.BindingSource bindingSourcePolys;
        private System.Windows.Forms.BindingSource bindingSourceMetaDefs;
        private System.Windows.Forms.BindingSource bindingSourceOps;
    }
}
