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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAreaHA = new System.Windows.Forms.TextBox();
            this.txtAreaAC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPerimMet = new System.Windows.Forms.TextBox();
            this.txtPerimFt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPolyAcc = new System.Windows.Forms.TextBox();
            this.txtStartIndex = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInc = new System.Windows.Forms.TextBox();
            this.pointNavigationCtrl1 = new TwoTrails.Controls.PointNavigationCtrl();
            this.actionsControlPolygons = new TwoTrails.Controls.ActionsControl();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxID.Location = new System.Drawing.Point(46, 3);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(191, 21);
            this.textBoxID.TabIndex = 0;
            this.textBoxID.TabStop = false;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxID.GotFocus += new System.EventHandler(this.textBoxID_GotFocus);
            this.textBoxID.LostFocus += new System.EventHandler(this.textBoxID_LostFocus);
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDesc.Location = new System.Drawing.Point(46, 30);
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.Size = new System.Drawing.Size(191, 21);
            this.textBoxDesc.TabIndex = 1;
            this.textBoxDesc.TabStop = false;
            this.textBoxDesc.TextChanged += new System.EventHandler(this.textBoxDesc_TextChanged);
            this.textBoxDesc.GotFocus += new System.EventHandler(this.textBoxDesc_GotFocus);
            this.textBoxDesc.LostFocus += new System.EventHandler(this.textBoxDesc_LostFocus);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(4, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.Text = "Desc";
            // 
            // txtAreaHA
            // 
            this.txtAreaHA.Location = new System.Drawing.Point(67, 77);
            this.txtAreaHA.Name = "txtAreaHA";
            this.txtAreaHA.ReadOnly = true;
            this.txtAreaHA.Size = new System.Drawing.Size(50, 21);
            this.txtAreaHA.TabIndex = 11;
            this.txtAreaHA.TabStop = false;
            // 
            // txtAreaAC
            // 
            this.txtAreaAC.Location = new System.Drawing.Point(67, 104);
            this.txtAreaAC.Name = "txtAreaAC";
            this.txtAreaAC.ReadOnly = true;
            this.txtAreaAC.Size = new System.Drawing.Size(50, 21);
            this.txtAreaAC.TabIndex = 11;
            this.txtAreaAC.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(4, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.Text = "Area(ha):";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(4, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.Text = "Area(ac):";
            // 
            // txtPerimMet
            // 
            this.txtPerimMet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerimMet.Location = new System.Drawing.Point(187, 77);
            this.txtPerimMet.Name = "txtPerimMet";
            this.txtPerimMet.ReadOnly = true;
            this.txtPerimMet.Size = new System.Drawing.Size(50, 21);
            this.txtPerimMet.TabIndex = 11;
            this.txtPerimMet.TabStop = false;
            // 
            // txtPerimFt
            // 
            this.txtPerimFt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerimFt.Location = new System.Drawing.Point(187, 104);
            this.txtPerimFt.Name = "txtPerimFt";
            this.txtPerimFt.ReadOnly = true;
            this.txtPerimFt.Size = new System.Drawing.Size(50, 21);
            this.txtPerimFt.TabIndex = 11;
            this.txtPerimFt.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(121, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.Text = "Perim(m):";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(121, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.Text = "Perim(ft):";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(4, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(233, 20);
            this.label7.Text = "______   Poly Info   ______";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(3, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 20);
            this.label8.Text = "Poly Pt Acc:";
            // 
            // txtPolyAcc
            // 
            this.txtPolyAcc.Location = new System.Drawing.Point(79, 131);
            this.txtPolyAcc.Name = "txtPolyAcc";
            this.txtPolyAcc.Size = new System.Drawing.Size(38, 21);
            this.txtPolyAcc.TabIndex = 35;
            this.txtPolyAcc.TabStop = false;
            this.txtPolyAcc.TextChanged += new System.EventHandler(this.txtPolyAcc_TextChanged);
            this.txtPolyAcc.GotFocus += new System.EventHandler(this.txtPolyAcc_GotFocus);
            this.txtPolyAcc.LostFocus += new System.EventHandler(this.txtPolyAcc_LostFocus);
            // 
            // txtStartIndex
            // 
            this.txtStartIndex.Location = new System.Drawing.Point(187, 156);
            this.txtStartIndex.Name = "txtStartIndex";
            this.txtStartIndex.Size = new System.Drawing.Size(50, 21);
            this.txtStartIndex.TabIndex = 44;
            this.txtStartIndex.TabStop = false;
            this.txtStartIndex.TextChanged += new System.EventHandler(this.txtStartIndex_TextChanged);
            this.txtStartIndex.GotFocus += new System.EventHandler(this.txtStartIndex_GotFocus);
            this.txtStartIndex.LostFocus += new System.EventHandler(this.txtStartIndex_LostFocus);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(95, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.Text = "Start Point:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Location = new System.Drawing.Point(113, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.Text = "Point Inc:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtInc
            // 
            this.txtInc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInc.Location = new System.Drawing.Point(187, 129);
            this.txtInc.Name = "txtInc";
            this.txtInc.Size = new System.Drawing.Size(50, 21);
            this.txtInc.TabIndex = 11;
            this.txtInc.TabStop = false;
            this.txtInc.TextChanged += new System.EventHandler(this.txtInc_TextChanged);
            this.txtInc.GotFocus += new System.EventHandler(this.txtInc_GotFocus);
            this.txtInc.LostFocus += new System.EventHandler(this.txtInc_LostFocus);
            // 
            // pointNavigationCtrl1
            // 
            this.pointNavigationCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pointNavigationCtrl1.Location = new System.Drawing.Point(0, 219);
            this.pointNavigationCtrl1.Name = "pointNavigationCtrl1";
            this.pointNavigationCtrl1.Size = new System.Drawing.Size(240, 35);
            this.pointNavigationCtrl1.TabIndex = 18;
            this.pointNavigationCtrl1.JumpPoint += new TwoTrails.Controls.PointNavigationCtrl.JumpPointEvent(this.pointNavigationCtrl1_JumpPoint);
            this.pointNavigationCtrl1.IndexChanged += new TwoTrails.Controls.PointNavigationCtrl.IndexChangedEvent(this.pointNavigationCtrl1_IndexChanged);
            // 
            // actionsControlPolygons
            // 
            this.actionsControlPolygons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actionsControlPolygons.DeleteEnabled = true;
            this.actionsControlPolygons.Location = new System.Drawing.Point(0, 254);
            this.actionsControlPolygons.MiscButtonEnabled = false;
            this.actionsControlPolygons.MiscButtonText = "Rotate";
            this.actionsControlPolygons.Name = "actionsControlPolygons";
            this.actionsControlPolygons.Size = new System.Drawing.Size(240, 40);
            this.actionsControlPolygons.TabIndex = 5;
            this.actionsControlPolygons.Misc_OnClick += new TwoTrails.Controls.ActionsControl.MiscClicked(this.actionsControlPolygons_MiscClicked_OnClick);
            this.actionsControlPolygons.Cancel_OnClick += new TwoTrails.Controls.ActionsControl.CancelClicked(this.actionsControlPolygons_Cancel_OnClick);
            this.actionsControlPolygons.New_OnClick += new TwoTrails.Controls.ActionsControl.NewClicked(this.actionsControlPolygons_NewClicked_OnClick);
            this.actionsControlPolygons.Ok_OnClick += new TwoTrails.Controls.ActionsControl.OkClicked(this.actionsControlPolygons_OkClicked_OnClick);
            this.actionsControlPolygons.Delete_OnClick += new TwoTrails.Controls.ActionsControl.DeleteClicked(this.actionsControlPolygons_DeleteClicked_OnClick);
            // 
            // chkLock
            // 
            this.chkLock.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkLock.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLock.Location = new System.Drawing.Point(4, 160);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(100, 20);
            this.chkLock.TabIndex = 55;
            this.chkLock.TabStop = false;
            this.chkLock.Text = "Locked";
            this.chkLock.CheckStateChanged += new System.EventHandler(this.chkLock_CheckStateChanged);
            // 
            // PolyEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.txtPolyAcc);
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.txtStartIndex);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pointNavigationCtrl1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInc);
            this.Controls.Add(this.txtPerimFt);
            this.Controls.Add(this.txtPerimMet);
            this.Controls.Add(this.txtAreaAC);
            this.Controls.Add(this.txtAreaHA);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.actionsControlPolygons);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.textBoxID);
            this.Name = "PolyEditForm";
            this.Text = "Polygon Edit";
            this.Load += new System.EventHandler(this.PolyEditForm_Load);
            this.GotFocus += new System.EventHandler(this.PolyEditForm_GotFocus);
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAreaHA = new System.Windows.Forms.TextBox();
            this.txtAreaAC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPerimMet = new System.Windows.Forms.TextBox();
            this.txtPerimFt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPolyAcc = new System.Windows.Forms.TextBox();
            this.txtStartIndex = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInc = new System.Windows.Forms.TextBox();
            this.pointNavigationCtrl1 = new TwoTrails.Controls.PointNavigationCtrl();
            this.actionsControlPolygons = new TwoTrails.Controls.ActionsControl();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxID.Location = new System.Drawing.Point(46, 3);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(188, 21);
            this.textBoxID.TabIndex = 0;
            this.textBoxID.TabStop = false;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxID.GotFocus += new System.EventHandler(this.textBoxID_GotFocus);
            this.textBoxID.LostFocus += new System.EventHandler(this.textBoxID_LostFocus);
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDesc.Location = new System.Drawing.Point(46, 30);
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.Size = new System.Drawing.Size(188, 21);
            this.textBoxDesc.TabIndex = 1;
            this.textBoxDesc.TabStop = false;
            this.textBoxDesc.TextChanged += new System.EventHandler(this.textBoxDesc_TextChanged);
            this.textBoxDesc.GotFocus += new System.EventHandler(this.textBoxDesc_GotFocus);
            this.textBoxDesc.LostFocus += new System.EventHandler(this.textBoxDesc_LostFocus);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(4, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.Text = "Desc";
            // 
            // txtAreaHA
            // 
            this.txtAreaHA.Location = new System.Drawing.Point(67, 77);
            this.txtAreaHA.Name = "txtAreaHA";
            this.txtAreaHA.ReadOnly = true;
            this.txtAreaHA.Size = new System.Drawing.Size(50, 21);
            this.txtAreaHA.TabIndex = 11;
            this.txtAreaHA.TabStop = false;
            // 
            // txtAreaAC
            // 
            this.txtAreaAC.Location = new System.Drawing.Point(67, 104);
            this.txtAreaAC.Name = "txtAreaAC";
            this.txtAreaAC.ReadOnly = true;
            this.txtAreaAC.Size = new System.Drawing.Size(50, 21);
            this.txtAreaAC.TabIndex = 11;
            this.txtAreaAC.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(4, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.Text = "Area(ha):";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(4, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.Text = "Area(ac):";
            // 
            // txtPerimMet
            // 
            this.txtPerimMet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerimMet.Location = new System.Drawing.Point(184, 79);
            this.txtPerimMet.Name = "txtPerimMet";
            this.txtPerimMet.ReadOnly = true;
            this.txtPerimMet.Size = new System.Drawing.Size(50, 21);
            this.txtPerimMet.TabIndex = 11;
            this.txtPerimMet.TabStop = false;
            // 
            // txtPerimFt
            // 
            this.txtPerimFt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerimFt.Location = new System.Drawing.Point(184, 106);
            this.txtPerimFt.Name = "txtPerimFt";
            this.txtPerimFt.ReadOnly = true;
            this.txtPerimFt.Size = new System.Drawing.Size(50, 21);
            this.txtPerimFt.TabIndex = 11;
            this.txtPerimFt.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(118, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.Text = "Perim(m):";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(118, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.Text = "Perim(ft):";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(4, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(230, 20);
            this.label7.Text = "______   Poly Info   ______";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(3, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.Text = "Poly Pt Acc:";
            // 
            // txtPolyAcc
            // 
            this.txtPolyAcc.Location = new System.Drawing.Point(79, 131);
            this.txtPolyAcc.Name = "txtPolyAcc";
            this.txtPolyAcc.Size = new System.Drawing.Size(38, 21);
            this.txtPolyAcc.TabIndex = 35;
            this.txtPolyAcc.TabStop = false;
            this.txtPolyAcc.TextChanged += new System.EventHandler(this.txtPolyAcc_TextChanged);
            this.txtPolyAcc.GotFocus += new System.EventHandler(this.txtPolyAcc_GotFocus);
            this.txtPolyAcc.LostFocus += new System.EventHandler(this.txtPolyAcc_LostFocus);
            // 
            // txtStartIndex
            // 
            this.txtStartIndex.Location = new System.Drawing.Point(184, 158);
            this.txtStartIndex.Name = "txtStartIndex";
            this.txtStartIndex.Size = new System.Drawing.Size(50, 21);
            this.txtStartIndex.TabIndex = 44;
            this.txtStartIndex.TabStop = false;
            this.txtStartIndex.TextChanged += new System.EventHandler(this.txtStartIndex_TextChanged);
            this.txtStartIndex.GotFocus += new System.EventHandler(this.txtStartIndex_GotFocus);
            this.txtStartIndex.LostFocus += new System.EventHandler(this.txtStartIndex_LostFocus);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(92, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.Text = "Start Index:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Location = new System.Drawing.Point(119, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.Text = "Inc:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtInc
            // 
            this.txtInc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInc.Location = new System.Drawing.Point(184, 131);
            this.txtInc.Name = "txtInc";
            this.txtInc.Size = new System.Drawing.Size(50, 21);
            this.txtInc.TabIndex = 11;
            this.txtInc.TabStop = false;
            this.txtInc.TextChanged += new System.EventHandler(this.txtInc_TextChanged);
            this.txtInc.GotFocus += new System.EventHandler(this.txtInc_GotFocus);
            this.txtInc.LostFocus += new System.EventHandler(this.txtInc_LostFocus);
            // 
            // pointNavigationCtrl1
            // 
            this.pointNavigationCtrl1.Location = new System.Drawing.Point(240, 0);
            this.pointNavigationCtrl1.Name = "pointNavigationCtrl1";
            this.pointNavigationCtrl1.Size = new System.Drawing.Size(80, 93);
            this.pointNavigationCtrl1.TabIndex = 18;
            this.pointNavigationCtrl1.JumpPoint += new TwoTrails.Controls.PointNavigationCtrl.JumpPointEvent(this.pointNavigationCtrl1_JumpPoint);
            this.pointNavigationCtrl1.IndexChanged += new TwoTrails.Controls.PointNavigationCtrl.IndexChangedEvent(this.pointNavigationCtrl1_IndexChanged);
            // 
            // actionsControlPolygons
            // 
            this.actionsControlPolygons.DeleteEnabled = true;
            this.actionsControlPolygons.Location = new System.Drawing.Point(240, 99);
            this.actionsControlPolygons.MiscButtonEnabled = false;
            this.actionsControlPolygons.MiscButtonText = "Rotate";
            this.actionsControlPolygons.Name = "actionsControlPolygons";
            this.actionsControlPolygons.Size = new System.Drawing.Size(80, 115);
            this.actionsControlPolygons.TabIndex = 5;
            this.actionsControlPolygons.Misc_OnClick += new TwoTrails.Controls.ActionsControl.MiscClicked(this.actionsControlPolygons_MiscClicked_OnClick);
            this.actionsControlPolygons.Cancel_OnClick += new TwoTrails.Controls.ActionsControl.CancelClicked(this.actionsControlPolygons_Cancel_OnClick);
            this.actionsControlPolygons.New_OnClick += new TwoTrails.Controls.ActionsControl.NewClicked(this.actionsControlPolygons_NewClicked_OnClick);
            this.actionsControlPolygons.Ok_OnClick += new TwoTrails.Controls.ActionsControl.OkClicked(this.actionsControlPolygons_OkClicked_OnClick);
            this.actionsControlPolygons.Delete_OnClick += new TwoTrails.Controls.ActionsControl.DeleteClicked(this.actionsControlPolygons_DeleteClicked_OnClick);
            // 
            // chkLock
            // 
            this.chkLock.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkLock.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkLock.Location = new System.Drawing.Point(4, 160);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(100, 20);
            this.chkLock.TabIndex = 55;
            this.chkLock.TabStop = false;
            this.chkLock.Text = "Locked";
            this.chkLock.CheckStateChanged += new System.EventHandler(this.chkLock_CheckStateChanged);
            // 
            // PolyEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.ControlBox = false;
            this.Controls.Add(this.txtPolyAcc);
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.txtStartIndex);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pointNavigationCtrl1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInc);
            this.Controls.Add(this.txtPerimFt);
            this.Controls.Add(this.txtPerimMet);
            this.Controls.Add(this.txtAreaAC);
            this.Controls.Add(this.txtAreaHA);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.actionsControlPolygons);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.textBoxID);
            this.Name = "PolyEditForm";
            this.Text = "Polygon Edit";
            this.Load += new System.EventHandler(this.PolyEditForm_Load);
            this.GotFocus += new System.EventHandler(this.PolyEditForm_GotFocus);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private TwoTrails.Controls.ActionsControl actionsControlPolygons;
        private System.Windows.Forms.TextBox txtAreaHA;
        private System.Windows.Forms.TextBox txtAreaAC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPerimMet;
        private System.Windows.Forms.TextBox txtPerimFt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private TwoTrails.Controls.PointNavigationCtrl pointNavigationCtrl1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPolyAcc;
        private System.Windows.Forms.TextBox txtStartIndex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtInc;
        private System.Windows.Forms.CheckBox chkLock;
    }
}