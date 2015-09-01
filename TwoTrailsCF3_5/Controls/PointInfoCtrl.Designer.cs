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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointInfoCtrl));
            this.label5 = new System.Windows.Forms.Label();
            this.bindingSourcePoint = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceMetaDefs = new System.Windows.Forms.BindingSource(this.components);
            this.cbMetaDef = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.labelComment = new System.Windows.Forms.LinkLabel();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.btnBoundary = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSourcePolys = new System.Windows.Forms.BindingSource(this.components);
            this.cbPoly = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPID = new System.Windows.Forms.TextBox();
            this.bindingSourceOps = new System.Windows.Forms.BindingSource(this.components);
            this.btnOp = new System.Windows.Forms.Button();
            this.picLinked = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMetaDefs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePolys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOps)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(2, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.Text = "MetaDef";
            // 
            // bindingSourcePoint
            // 
            this.bindingSourcePoint.DataSource = typeof(TwoTrails.BusinessObjects.TtPoint);
            // 
            // bindingSourceMetaDefs
            // 
            this.bindingSourceMetaDefs.DataSource = typeof(TwoTrails.BusinessObjects.TtMetaData);
            // 
            // cbMetaDef
            // 
            this.cbMetaDef.Location = new System.Drawing.Point(59, 74);
            this.cbMetaDef.Name = "cbMetaDef";
            this.cbMetaDef.Size = new System.Drawing.Size(77, 22);
            this.cbMetaDef.TabIndex = 25;
            this.cbMetaDef.TabStop = false;
            this.cbMetaDef.Tag = "Meta Data";
            this.cbMetaDef.SelectedIndexChanged += new System.EventHandler(this.cbMetaDef_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(137, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.Text = "Boundary";
            // 
            // chkLocked
            // 
            this.chkLocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLocked.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLocked.Location = new System.Drawing.Point(142, 77);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(67, 17);
            this.chkLocked.TabIndex = 24;
            this.chkLocked.TabStop = false;
            this.chkLocked.Tag = "Lock Entering Data";
            this.chkLocked.Text = "Locked";
            this.chkLocked.CheckStateChanged += new System.EventHandler(this.chkLocked_CheckStateChanged);
            // 
            // labelComment
            // 
            this.labelComment.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelComment.Location = new System.Drawing.Point(0, 53);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(30, 13);
            this.labelComment.TabIndex = 23;
            this.labelComment.Text = "Cmt";
            // 
            // tbComment
            // 
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "Comment", true));
            this.tbComment.Location = new System.Drawing.Point(33, 50);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(204, 21);
            this.tbComment.TabIndex = 22;
            this.tbComment.TabStop = false;
            this.tbComment.Tag = "Comment";
            this.tbComment.TextChanged += new System.EventHandler(this.tbComment_TextChanged);
            this.tbComment.GotFocus += new System.EventHandler(this.tbComment_GotFocus);
            this.tbComment.LostFocus += new System.EventHandler(this.tbComment_LostFocus);
            // 
            // btnBoundary
            // 
            this.btnBoundary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBoundary.Location = new System.Drawing.Point(199, 25);
            this.btnBoundary.Name = "btnBoundary";
            this.btnBoundary.Size = new System.Drawing.Size(38, 22);
            this.btnBoundary.TabIndex = 21;
            this.btnBoundary.TabStop = false;
            this.btnBoundary.Tag = "Boundary";
            this.btnBoundary.Text = "ON";
            this.btnBoundary.Click += new System.EventHandler(this.btnBoundary_Click);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 22);
            this.label3.Text = "Op";
            // 
            // cbOp
            // 
            this.cbOp.Location = new System.Drawing.Point(33, 25);
            this.cbOp.Name = "cbOp";
            this.cbOp.Size = new System.Drawing.Size(85, 22);
            this.cbOp.TabIndex = 20;
            this.cbOp.TabStop = false;
            this.cbOp.SelectedIndexChanged += new System.EventHandler(this.cbOp_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(137, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.Text = "Poly";
            // 
            // bindingSourcePolys
            // 
            this.bindingSourcePolys.DataSource = typeof(TwoTrails.BusinessObjects.TtPolygon);
            // 
            // cbPoly
            // 
            this.cbPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPoly.DataSource = this.bindingSourcePolys;
            this.cbPoly.DisplayMember = "Name";
            this.cbPoly.Location = new System.Drawing.Point(170, 1);
            this.cbPoly.Name = "cbPoly";
            this.cbPoly.Size = new System.Drawing.Size(67, 22);
            this.cbPoly.TabIndex = 19;
            this.cbPoly.TabStop = false;
            this.cbPoly.Tag = "Current Polygon";
            this.cbPoly.SelectedIndexChanged += new System.EventHandler(this.cbPoly_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.Text = "PID";
            // 
            // tbPID
            // 
            this.tbPID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePoint, "PID", true));
            this.tbPID.Location = new System.Drawing.Point(33, 1);
            this.tbPID.Name = "tbPID";
            this.tbPID.Size = new System.Drawing.Size(85, 21);
            this.tbPID.TabIndex = 17;
            this.tbPID.TabStop = false;
            this.tbPID.Tag = "Point ID";
            this.tbPID.TextChanged += new System.EventHandler(this.tbPID_TextChanged);
            this.tbPID.GotFocus += new System.EventHandler(this.tbPID_GotFocus);
            this.tbPID.LostFocus += new System.EventHandler(this.tbPID_LostFocus);
            // 
            // btnOp
            // 
            this.btnOp.Location = new System.Drawing.Point(33, 25);
            this.btnOp.Name = "btnOp";
            this.btnOp.Size = new System.Drawing.Size(85, 22);
            this.btnOp.TabIndex = 30;
            this.btnOp.TabStop = false;
            this.btnOp.Tag = "Operation Type";
            this.btnOp.Text = "GPS";
            this.btnOp.Click += new System.EventHandler(this.btnOp_Click);
            // 
            // picLinked
            // 
            this.picLinked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLinked.BackColor = System.Drawing.SystemColors.ControlDark;

            //relocated to constructor
            //this.picLinked.Image = ((System.Drawing.Image)(resources.GetObject("picLinked.Image")));
        
            this.picLinked.Location = new System.Drawing.Point(215, 74);
            this.picLinked.Name = "picLinked";
            this.picLinked.Size = new System.Drawing.Size(20, 20);
            this.picLinked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLinked.Visible = false;
            this.picLinked.Click += new System.EventHandler(this.picLinked_Click);
            // 
            // PointInfoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.picLinked);
            this.Controls.Add(this.btnOp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbMetaDef);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkLocked);
            this.Controls.Add(this.labelComment);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.btnBoundary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbOp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPoly);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPID);
            this.Name = "PointInfoCtrl";
            this.Size = new System.Drawing.Size(240, 98);
            this.Click += new System.EventHandler(this.PointInfoCtrl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMetaDefs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePolys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMetaDef;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkLocked;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Button btnBoundary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPoly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPID;
        private System.Windows.Forms.BindingSource bindingSourcePoint;
        private System.Windows.Forms.BindingSource bindingSourcePolys;
        private System.Windows.Forms.BindingSource bindingSourceMetaDefs;
        private System.Windows.Forms.BindingSource bindingSourceOps;
        private System.Windows.Forms.LinkLabel labelComment;
        private System.Windows.Forms.Button btnOp;
        private System.Windows.Forms.PictureBox picLinked;
    }
}
