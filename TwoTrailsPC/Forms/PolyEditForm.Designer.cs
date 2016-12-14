namespace TwoTrails.Forms
{
    partial class PolyEditForm
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
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.txtAreaHA = new System.Windows.Forms.TextBox();
            this.txtAreaAC = new System.Windows.Forms.TextBox();
            this.txtPolyAcc = new System.Windows.Forms.TextBox();
            this.txtPerimMet = new System.Windows.Forms.TextBox();
            this.txtPerimFt = new System.Windows.Forms.TextBox();
            this.txtInc = new System.Windows.Forms.TextBox();
            this.txtStartIndex = new System.Windows.Forms.TextBox();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.actionsControlPolygons = new TwoTrails.Controls.ActionsControl();
            this.pointNavigationCtrl1 = new TwoTrails.Controls.PointNavigationCtrl();
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.Location = new System.Drawing.Point(63, 12);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(259, 22);
            this.textBoxID.TabIndex = 0;
            this.textBoxID.TabStop = false;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Enabled = false;
            this.textBoxDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDesc.Location = new System.Drawing.Point(63, 40);
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.Size = new System.Drawing.Size(259, 22);
            this.textBoxDesc.TabIndex = 0;
            this.textBoxDesc.TabStop = false;
            this.textBoxDesc.TextChanged += new System.EventHandler(this.textBoxDesc_TextChanged);
            // 
            // txtAreaHA
            // 
            this.txtAreaHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaHA.Location = new System.Drawing.Point(90, 100);
            this.txtAreaHA.Name = "txtAreaHA";
            this.txtAreaHA.ReadOnly = true;
            this.txtAreaHA.Size = new System.Drawing.Size(72, 22);
            this.txtAreaHA.TabIndex = 0;
            this.txtAreaHA.TabStop = false;
            // 
            // txtAreaAC
            // 
            this.txtAreaAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaAC.Location = new System.Drawing.Point(90, 128);
            this.txtAreaAC.Name = "txtAreaAC";
            this.txtAreaAC.ReadOnly = true;
            this.txtAreaAC.Size = new System.Drawing.Size(72, 22);
            this.txtAreaAC.TabIndex = 0;
            this.txtAreaAC.TabStop = false;
            // 
            // txtPolyAcc
            // 
            this.txtPolyAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPolyAcc.Location = new System.Drawing.Point(123, 156);
            this.txtPolyAcc.Name = "txtPolyAcc";
            this.txtPolyAcc.Size = new System.Drawing.Size(39, 22);
            this.txtPolyAcc.TabIndex = 0;
            this.txtPolyAcc.TabStop = false;
            this.txtPolyAcc.TextChanged += new System.EventHandler(this.txtPolyAcc_TextChanged);
            // 
            // txtPerimMet
            // 
            this.txtPerimMet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPerimMet.Location = new System.Drawing.Point(248, 100);
            this.txtPerimMet.Name = "txtPerimMet";
            this.txtPerimMet.ReadOnly = true;
            this.txtPerimMet.Size = new System.Drawing.Size(72, 22);
            this.txtPerimMet.TabIndex = 0;
            this.txtPerimMet.TabStop = false;
            // 
            // txtPerimFt
            // 
            this.txtPerimFt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPerimFt.Location = new System.Drawing.Point(248, 128);
            this.txtPerimFt.Name = "txtPerimFt";
            this.txtPerimFt.ReadOnly = true;
            this.txtPerimFt.Size = new System.Drawing.Size(72, 22);
            this.txtPerimFt.TabIndex = 0;
            this.txtPerimFt.TabStop = false;
            // 
            // txtInc
            // 
            this.txtInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInc.Location = new System.Drawing.Point(248, 156);
            this.txtInc.Name = "txtInc";
            this.txtInc.Size = new System.Drawing.Size(72, 22);
            this.txtInc.TabIndex = 0;
            this.txtInc.TabStop = false;
            this.txtInc.TextChanged += new System.EventHandler(this.txtInc_TextChanged);
            // 
            // txtStartIndex
            // 
            this.txtStartIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartIndex.Location = new System.Drawing.Point(248, 184);
            this.txtStartIndex.Name = "txtStartIndex";
            this.txtStartIndex.Size = new System.Drawing.Size(72, 22);
            this.txtStartIndex.TabIndex = 0;
            this.txtStartIndex.TabStop = false;
            this.txtStartIndex.TextChanged += new System.EventHandler(this.txtStartIndex_TextChanged);
            // 
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.Checked = true;
            this.chkLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLock.Location = new System.Drawing.Point(15, 184);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(78, 20);
            this.chkLock.TabIndex = 1;
            this.chkLock.TabStop = false;
            this.chkLock.Text = "Locked";
            this.chkLock.UseVisualStyleBackColor = true;
            this.chkLock.CheckedChanged += new System.EventHandler(this.chkLock_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Desc:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Area(ha):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(61, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(219, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "_____ Polygon Info _____";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Area(ac):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Poly Pt Acc (M):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(168, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Perim(m):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(172, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Perim(ft):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(172, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Point Inc:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(159, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Start Point:";
            // 
            // actionsControlPolygons
            // 
            this.actionsControlPolygons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsControlPolygons.DeleteEnabled = true;
            this.actionsControlPolygons.Location = new System.Drawing.Point(0, 246);
            this.actionsControlPolygons.MiscButtonEnabled = true;
            this.actionsControlPolygons.MiscButtonText = "Misc";
            this.actionsControlPolygons.Name = "actionsControlPolygons";
            this.actionsControlPolygons.NewEnabled = true;
            this.actionsControlPolygons.OkEnabled = true;
            this.actionsControlPolygons.Size = new System.Drawing.Size(330, 47);
            this.actionsControlPolygons.TabIndex = 4;
            this.actionsControlPolygons.TabStop = false;
            this.actionsControlPolygons.New_OnClick += new TwoTrails.Controls.ActionsControl.NewClicked(this.actionsControlPolygons_New_OnClick);
            this.actionsControlPolygons.Cancel_OnClick += new TwoTrails.Controls.ActionsControl.CancelClicked(this.actionsControlPolygons_Cancel_OnClick);
            this.actionsControlPolygons.Delete_OnClick += new TwoTrails.Controls.ActionsControl.DeleteClicked(this.actionsControlPolygons_Delete_OnClick);
            this.actionsControlPolygons.Misc_OnClick += new TwoTrails.Controls.ActionsControl.MiscClicked(this.actionsControlPolygons_Misc_OnClick);
            this.actionsControlPolygons.Ok_OnClick += new TwoTrails.Controls.ActionsControl.OkClicked(this.actionsControlPolygons_Ok_OnClick);
            // 
            // pointNavigationCtrl1
            // 
            this.pointNavigationCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pointNavigationCtrl1.BackwardButtons = true;
            this.pointNavigationCtrl1.ForwardButtons = true;
            this.pointNavigationCtrl1.Location = new System.Drawing.Point(0, 206);
            this.pointNavigationCtrl1.Name = "pointNavigationCtrl1";
            this.pointNavigationCtrl1.Size = new System.Drawing.Size(330, 40);
            this.pointNavigationCtrl1.TabIndex = 3;
            this.pointNavigationCtrl1.TabStop = false;
            this.pointNavigationCtrl1.AlreadyAtEnd += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtEndEvent(this.pointNavigationCtrl1_AlreadyAtEnd);
            this.pointNavigationCtrl1.AlreadyAtBeginning += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtBeginningEvent(this.pointNavigationCtrl1_AlreadyAtBeginning);
            this.pointNavigationCtrl1.IndexChanged += new TwoTrails.Controls.PointNavigationCtrl.IndexChangedEvent(this.pointNavigationCtrl1_IndexChanged);
            this.pointNavigationCtrl1.JumpPoint += new TwoTrails.Controls.PointNavigationCtrl.JumpPointEvent(this.pointNavigationCtrl1_JumpPoint);
            // 
            // PolyEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 295);
            this.Controls.Add(this.txtPolyAcc);
            this.Controls.Add(this.actionsControlPolygons);
            this.Controls.Add(this.pointNavigationCtrl1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.txtStartIndex);
            this.Controls.Add(this.txtInc);
            this.Controls.Add(this.txtPerimFt);
            this.Controls.Add(this.txtAreaAC);
            this.Controls.Add(this.txtPerimMet);
            this.Controls.Add(this.txtAreaHA);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.textBoxID);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(348, 333);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(348, 333);
            this.Name = "PolyEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Polygon Edit";
            this.Load += new System.EventHandler(this.PolyEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.TextBox txtAreaHA;
        private System.Windows.Forms.TextBox txtAreaAC;
        private System.Windows.Forms.TextBox txtPolyAcc;
        private System.Windows.Forms.TextBox txtPerimMet;
        private System.Windows.Forms.TextBox txtPerimFt;
        private System.Windows.Forms.TextBox txtInc;
        private System.Windows.Forms.TextBox txtStartIndex;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private TwoTrails.Controls.PointNavigationCtrl pointNavigationCtrl1;
        private TwoTrails.Controls.ActionsControl actionsControlPolygons;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}