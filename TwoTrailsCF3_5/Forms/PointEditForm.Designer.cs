namespace TwoTrails.Forms
{
    partial class PointEditForm
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
            this.take5InfoCtrl1 = new TwoTrails.Controls.Take5InfoCtrl();
            this.pointInfoCtrl = new TwoTrails.Controls.PointInfoCtrl();
            this.pointNavigationCtrl = new TwoTrails.Controls.PointNavigationCtrl();
            this.actionsControl = new TwoTrails.Controls.ActionsControl();
            this.gpsInfoControl1 = new TwoTrails.Controls.GpsInfoControl();
            this.quondamInfoControl1 = new TwoTrails.Controls.QuondamInfoControl();
            this.travInfoControl1 = new TwoTrails.Controls.TravInfoControl();
            this.walkInfoCtrl1 = new TwoTrails.Controls.WalkInfoCtrl();
            this.SuspendLayout();
            // 
            // take5InfoCtrl1
            // 
            this.take5InfoCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.take5InfoCtrl1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.take5InfoCtrl1.Location = new System.Drawing.Point(0, 98);
            this.take5InfoCtrl1.Name = "take5InfoCtrl1";
            this.take5InfoCtrl1.Size = new System.Drawing.Size(240, 126);
            this.take5InfoCtrl1.TabIndex = 3;
            this.take5InfoCtrl1.ButtonHide += new TwoTrails.Controls.Take5InfoCtrl.ButtonHideEvent(this.take5InfoCtrl1_ButtonHide);
            this.take5InfoCtrl1.BurstAmountChanged += new TwoTrails.Controls.Take5InfoCtrl.BurstAmountChangedEvent(this.take5InfoCtrl1_BurstAmountChanged);
            // 
            // pointInfoCtrl
            // 
            this.pointInfoCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pointInfoCtrl.Location = new System.Drawing.Point(0, 0);
            this.pointInfoCtrl.Name = "pointInfoCtrl";
            this.pointInfoCtrl.Size = new System.Drawing.Size(240, 98);
            this.pointInfoCtrl.TabIndex = 2;
            this.pointInfoCtrl.OnPID_Enter += new TwoTrails.Controls.PointInfoCtrl.PID_Enter(this.pointInfoCtrl_OnPID_Enter);
            this.pointInfoCtrl.OnPoly_SelectedIndexChanged += new TwoTrails.Controls.PointInfoCtrl.Poly_SelectedIndexChanged(this.pointInfoCtrl_OnPoly_SelectedIndexChanged);
            this.pointInfoCtrl.OnComment_Enter += new TwoTrails.Controls.PointInfoCtrl.Comment_Enter(this.pointInfoCtrl_OnComment_Enter);
            this.pointInfoCtrl.OnLocked_CheckedChanged += new TwoTrails.Controls.PointInfoCtrl.Locked_CheckedChanged(this.pointInfoCtrl_OnLocked_CheckedChanged);
            this.pointInfoCtrl.PID_OnTextChanged += new TwoTrails.Controls.PointInfoCtrl.PID_TextChanged(this.pointInfoCtrl_PID_OnTextChanged);
            this.pointInfoCtrl.OnBoundary_Click += new TwoTrails.Controls.PointInfoCtrl.Boundary_Click(this.pointInfoCtrl_OnBoundary_Click);
            this.pointInfoCtrl.LinkedPointClicked += new TwoTrails.Controls.PointInfoCtrl.LinkedPointClickedEvent(this.pointInfoCtrl_LinkedPointClicked);
            this.pointInfoCtrl.OnMetaDef_SelectedIndexChanged += new TwoTrails.Controls.PointInfoCtrl.MetaDef_SelectedIndexChanged(this.pointInfoCtrl_OnMetaDef_SelectedIndexChanged);
            this.pointInfoCtrl.OnOp_SelectedIndexChanged += new TwoTrails.Controls.PointInfoCtrl.Op_SelectedIndexChanged(this.pointInfoCtrl_OnOp_SelectedIndexChanged);
            this.pointInfoCtrl.Comment_OnTextChanged += new TwoTrails.Controls.PointInfoCtrl.Comment_TextChanged(this.pointInfoCtrl_Comment_OnTextChanged);
            this.pointInfoCtrl.GotFocus += new System.EventHandler(this.pointInfoCtrl_GotFocus);
            // 
            // pointNavigationCtrl
            // 
            this.pointNavigationCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pointNavigationCtrl.Location = new System.Drawing.Point(0, 224);
            this.pointNavigationCtrl.Name = "pointNavigationCtrl";
            this.pointNavigationCtrl.Size = new System.Drawing.Size(240, 30);
            this.pointNavigationCtrl.TabIndex = 1;
            this.pointNavigationCtrl.GotFocus += new System.EventHandler(this.pointNavigationCtrl_GotFocus);
            this.pointNavigationCtrl.AlreadyAtEnd += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtEndEvent(this.pointNavigationCtrl_AlreadyAtEnd);
            this.pointNavigationCtrl.JumpPoint += new TwoTrails.Controls.PointNavigationCtrl.JumpPointEvent(this.pointNavigationCtrl_JumpPoint);
            this.pointNavigationCtrl.AlreadyAtBeginning += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtBeginningEvent(this.pointNavigationCtrl_AlreadyAtBeginning);
            this.pointNavigationCtrl.IndexChanged += new TwoTrails.Controls.PointNavigationCtrl.IndexChangedEvent(this.pointNavigationCtrl_IndexChanged);
            // 
            // actionsControl
            // 
            this.actionsControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsControl.Location = new System.Drawing.Point(0, 254);
            this.actionsControl.Name = "actionsControl";
            this.actionsControl.Size = new System.Drawing.Size(240, 40);
            this.actionsControl.TabIndex = 0;
            this.actionsControl.GotFocus += new System.EventHandler(this.actionsControl_GotFocus);
            this.actionsControl.Misc_OnClick += new TwoTrails.Controls.ActionsControl.MiscClicked(this.actionsControl_Misc_OnClick);
            this.actionsControl.Cancel_OnClick += new TwoTrails.Controls.ActionsControl.CancelClicked(this.actionsControl_Cancel_OnClick);
            this.actionsControl.New_OnClick += new TwoTrails.Controls.ActionsControl.NewClicked(this.actionsControl_New_OnClick);
            this.actionsControl.Ok_OnClick += new TwoTrails.Controls.ActionsControl.OkClicked(this.actionsControl_Ok_OnClick);
            this.actionsControl.Delete_OnClick += new TwoTrails.Controls.ActionsControl.DeleteClicked(this.actionsControl_Delete_OnClick);
            // 
            // gpsInfoControl1
            // 
            this.gpsInfoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpsInfoControl1.Location = new System.Drawing.Point(0, 98);
            this.gpsInfoControl1.Name = "gpsInfoControl1";
            this.gpsInfoControl1.Size = new System.Drawing.Size(240, 126);
            this.gpsInfoControl1.TabIndex = 7;
            this.gpsInfoControl1.MiscClick += new TwoTrails.Controls.MiscClickEvent(this.gpsInfoControl1_MiscClick);
            this.gpsInfoControl1.GotFocused += new TwoTrails.Controls.GpsInfoControl.GotFocusEvent(this.gpsInfoControl1_GotFocused);
            this.gpsInfoControl1.Y_OnTextChanged += new TwoTrails.Controls.GpsInfoControl.Y_TextChanged(this.gpsInfoControl1_Y_OnTextChanged);
            this.gpsInfoControl1.ManAcc_OnTextChanged += new TwoTrails.Controls.GpsInfoControl.ManAcc_TextChanged(this.gpsInfoControl1_ManAcc_OnTextChanged);
            this.gpsInfoControl1.Z_OnTextChanged += new TwoTrails.Controls.GpsInfoControl.Z_TextChanged(this.gpsInfoControl1_Z_OnTextChanged);
            this.gpsInfoControl1.DelNmea_OnClick += new TwoTrails.Controls.GpsInfoControl.DelNmea_Click(this.gpsInfoControl1_DelNmea_OnClick);
            this.gpsInfoControl1.X_OnTextChanged += new TwoTrails.Controls.GpsInfoControl.X_TextChanged(this.gpsInfoControl1_X_OnTextChanged);
            // 
            // quondamInfoControl1
            // 
            this.quondamInfoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quondamInfoControl1.AutoScroll = true;
            this.quondamInfoControl1.Location = new System.Drawing.Point(0, 98);
            this.quondamInfoControl1.Name = "quondamInfoControl1";
            this.quondamInfoControl1.Size = new System.Drawing.Size(240, 126);
            this.quondamInfoControl1.TabIndex = 6;
            this.quondamInfoControl1.PointsRetraced += new TwoTrails.Controls.QuondamInfoControl.PointsRetracedEvent(this.quondamInfoControl1_PointsRetraced);
            this.quondamInfoControl1.GotFocus += new System.EventHandler(this.quondamInfoControl1_GotFocused);
            this.quondamInfoControl1.PointConverted += new TwoTrails.Controls.QuondamInfoControl.PointConvertedEvent(this.quondamInfoControl1_PointConverted);
            this.quondamInfoControl1.Point_OnIndexChanged += new TwoTrails.Controls.QuondamInfoControl.SelectedPointChanged(this.quondamInfoControl1_Point_OnIndexChanged);
            this.quondamInfoControl1.Polygon_OnIndexChanged += new TwoTrails.Controls.QuondamInfoControl.SelectedPolygonChanged(this.quondamInfoControl1_Polygon_OnIndexChanged);
            // 
            // travInfoControl1
            // 
            this.travInfoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.travInfoControl1.Location = new System.Drawing.Point(0, 98);
            this.travInfoControl1.Name = "travInfoControl1";
            this.travInfoControl1.Size = new System.Drawing.Size(240, 126);
            this.travInfoControl1.TabIndex = 5;
            this.travInfoControl1.BAzTextChanged += new TwoTrails.Controls.TravInfoControl.BAzTextChangedEvent(this.travInfoControl1_BAzTextChanged);
            this.travInfoControl1.GotFocus += new System.EventHandler(this.travInfoControl1_GotFocused);
            this.travInfoControl1.SlopeAngleTextChanged += new TwoTrails.Controls.TravInfoControl.SlopeAngleTextChangedEvent(this.travInfoControl1_SlopeAngleTextChanged);
            this.travInfoControl1.SlopeDistTextChanged += new TwoTrails.Controls.TravInfoControl.SlopeDistTextChangedEvent(this.travInfoControl1_SlopeDistTextChanged);
            this.travInfoControl1.FAzTextChanged += new TwoTrails.Controls.TravInfoControl.FAzTextChangedEvent(this.travInfoControl1_FAzTextChanged);
            this.travInfoControl1.ValuesSet += new TwoTrails.Controls.TravInfoControl.ValuesSetEvent(travInfoControl1_ValuesSet);
            // 
            // walkInfoCtrl1
            // 
            this.walkInfoCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.walkInfoCtrl1.Location = new System.Drawing.Point(0, 98);
            this.walkInfoCtrl1.Name = "walkInfoCtrl1";
            this.walkInfoCtrl1.Size = new System.Drawing.Size(240, 126);
            this.walkInfoCtrl1.TabIndex = 4;
            this.walkInfoCtrl1.GotFocus += new System.EventHandler(this.walkInfoCtrl1_GotFocus);
            this.walkInfoCtrl1.DeleteWalk += new TwoTrails.Controls.WalkInfoCtrl.ButtonDeleteEvent(this.walkInfoCtrl1_DeleteWalk);
            this.walkInfoCtrl1.ButtonHide += new TwoTrails.Controls.WalkInfoCtrl.ButtonHideEvent(this.walkInfoCtrl1_ButtonHide);
            this.walkInfoCtrl1.EditAccuracy += new TwoTrails.Controls.WalkInfoCtrl.EditAccuracyEvent(this.walkInfoCtrl1_EditAccuracy);
            this.walkInfoCtrl1.AddToWalk += new TwoTrails.Controls.WalkInfoCtrl.ButtonAddEvent(this.walkInfoCtrl1_AddToWalk);
            // 
            // PointEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.take5InfoCtrl1);
            this.Controls.Add(this.pointInfoCtrl);
            this.Controls.Add(this.pointNavigationCtrl);
            this.Controls.Add(this.actionsControl);
            this.Controls.Add(this.gpsInfoControl1);
            this.Controls.Add(this.quondamInfoControl1);
            this.Controls.Add(this.travInfoControl1);
            this.Controls.Add(this.walkInfoCtrl1);
            this.KeyPreview = true;
            this.Name = "PointEditForm";
            this.Text = "PointEditForm";
            this.Load += new System.EventHandler(this.PointEditForm_Load);
            this.GotFocus += new System.EventHandler(this.PointEditForm_GotFocus);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PointEditForm_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PointEditForm_KeyDown);
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.take5InfoCtrl1 = new TwoTrails.Controls.Take5InfoCtrl();
            this.pointInfoCtrl = new TwoTrails.Controls.PointInfoCtrl();
            this.pointNavigationCtrl = new TwoTrails.Controls.PointNavigationCtrl();
            this.actionsControl = new TwoTrails.Controls.ActionsControl();
            this.gpsInfoControl1 = new TwoTrails.Controls.GpsInfoControl();
            this.quondamInfoControl1 = new TwoTrails.Controls.QuondamInfoControl();
            this.travInfoControl1 = new TwoTrails.Controls.TravInfoControl();
            this.walkInfoCtrl1 = new TwoTrails.Controls.WalkInfoCtrl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // take5InfoCtrl1
            // 
            this.take5InfoCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.take5InfoCtrl1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.take5InfoCtrl1.Location = new System.Drawing.Point(0, 98);
            this.take5InfoCtrl1.Name = "take5InfoCtrl1";
            this.take5InfoCtrl1.Size = new System.Drawing.Size(240, 116);
            this.take5InfoCtrl1.TabIndex = 3;
            this.take5InfoCtrl1.ButtonHide += new TwoTrails.Controls.Take5InfoCtrl.ButtonHideEvent(this.take5InfoCtrl1_ButtonHide);
            this.take5InfoCtrl1.BurstAmountChanged += new TwoTrails.Controls.Take5InfoCtrl.BurstAmountChangedEvent(this.take5InfoCtrl1_BurstAmountChanged);
            // 
            // pointInfoCtrl
            // 
            this.pointInfoCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pointInfoCtrl.Location = new System.Drawing.Point(0, 0);
            this.pointInfoCtrl.Name = "pointInfoCtrl";
            this.pointInfoCtrl.Size = new System.Drawing.Size(240, 98);
            this.pointInfoCtrl.TabIndex = 2;
            this.pointInfoCtrl.OnPID_Enter += new TwoTrails.Controls.PointInfoCtrl.PID_Enter(this.pointInfoCtrl_OnPID_Enter);
            this.pointInfoCtrl.OnPoly_SelectedIndexChanged += new TwoTrails.Controls.PointInfoCtrl.Poly_SelectedIndexChanged(this.pointInfoCtrl_OnPoly_SelectedIndexChanged);
            this.pointInfoCtrl.OnComment_Enter += new TwoTrails.Controls.PointInfoCtrl.Comment_Enter(this.pointInfoCtrl_OnComment_Enter);
            this.pointInfoCtrl.OnLocked_CheckedChanged += new TwoTrails.Controls.PointInfoCtrl.Locked_CheckedChanged(this.pointInfoCtrl_OnLocked_CheckedChanged);
            this.pointInfoCtrl.PID_OnTextChanged += new TwoTrails.Controls.PointInfoCtrl.PID_TextChanged(this.pointInfoCtrl_PID_OnTextChanged);
            this.pointInfoCtrl.OnBoundary_Click += new TwoTrails.Controls.PointInfoCtrl.Boundary_Click(this.pointInfoCtrl_OnBoundary_Click);
            this.pointInfoCtrl.LinkedPointClicked += new TwoTrails.Controls.PointInfoCtrl.LinkedPointClickedEvent(this.pointInfoCtrl_LinkedPointClicked);
            this.pointInfoCtrl.OnMetaDef_SelectedIndexChanged += new TwoTrails.Controls.PointInfoCtrl.MetaDef_SelectedIndexChanged(this.pointInfoCtrl_OnMetaDef_SelectedIndexChanged);
            this.pointInfoCtrl.OnOp_SelectedIndexChanged += new TwoTrails.Controls.PointInfoCtrl.Op_SelectedIndexChanged(this.pointInfoCtrl_OnOp_SelectedIndexChanged);
            this.pointInfoCtrl.Comment_OnTextChanged += new TwoTrails.Controls.PointInfoCtrl.Comment_TextChanged(this.pointInfoCtrl_Comment_OnTextChanged);
            this.pointInfoCtrl.GotFocus += new System.EventHandler(this.pointInfoCtrl_GotFocus);
            // 
            // pointNavigationCtrl
            // 
            this.pointNavigationCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pointNavigationCtrl.Location = new System.Drawing.Point(240, 0);
            this.pointNavigationCtrl.Name = "pointNavigationCtrl";
            this.pointNavigationCtrl.Size = new System.Drawing.Size(80, 93);
            this.pointNavigationCtrl.TabIndex = 1;
            this.pointNavigationCtrl.GotFocus += new System.EventHandler(this.pointNavigationCtrl_GotFocus);
            this.pointNavigationCtrl.AlreadyAtEnd += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtEndEvent(this.pointNavigationCtrl_AlreadyAtEnd);
            this.pointNavigationCtrl.JumpPoint += new TwoTrails.Controls.PointNavigationCtrl.JumpPointEvent(this.pointNavigationCtrl_JumpPoint);
            this.pointNavigationCtrl.AlreadyAtBeginning += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtBeginningEvent(this.pointNavigationCtrl_AlreadyAtBeginning);
            this.pointNavigationCtrl.IndexChanged += new TwoTrails.Controls.PointNavigationCtrl.IndexChangedEvent(this.pointNavigationCtrl_IndexChanged);
            // 
            // actionsControl
            // 
            this.actionsControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsControl.Location = new System.Drawing.Point(240, 93);
            this.actionsControl.Name = "actionsControl";
            this.actionsControl.Size = new System.Drawing.Size(80, 121);
            this.actionsControl.TabIndex = 0;
            this.actionsControl.GotFocus += new System.EventHandler(this.actionsControl_GotFocus);
            this.actionsControl.Misc_OnClick += new TwoTrails.Controls.ActionsControl.MiscClicked(this.actionsControl_Misc_OnClick);
            this.actionsControl.Cancel_OnClick += new TwoTrails.Controls.ActionsControl.CancelClicked(this.actionsControl_Cancel_OnClick);
            this.actionsControl.New_OnClick += new TwoTrails.Controls.ActionsControl.NewClicked(this.actionsControl_New_OnClick);
            this.actionsControl.Ok_OnClick += new TwoTrails.Controls.ActionsControl.OkClicked(this.actionsControl_Ok_OnClick);
            this.actionsControl.Delete_OnClick += new TwoTrails.Controls.ActionsControl.DeleteClicked(this.actionsControl_Delete_OnClick);
            // 
            // gpsInfoControl1
            // 
            this.gpsInfoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpsInfoControl1.Location = new System.Drawing.Point(0, 98);
            this.gpsInfoControl1.Name = "gpsInfoControl1";
            this.gpsInfoControl1.Size = new System.Drawing.Size(240, 116);
            this.gpsInfoControl1.TabIndex = 7;
            this.gpsInfoControl1.MiscClick += new TwoTrails.Controls.MiscClickEvent(this.gpsInfoControl1_MiscClick);
            this.gpsInfoControl1.GotFocused += new TwoTrails.Controls.GpsInfoControl.GotFocusEvent(this.gpsInfoControl1_GotFocused);
            this.gpsInfoControl1.Y_OnTextChanged += new TwoTrails.Controls.GpsInfoControl.Y_TextChanged(this.gpsInfoControl1_Y_OnTextChanged);
            this.gpsInfoControl1.ManAcc_OnTextChanged += new TwoTrails.Controls.GpsInfoControl.ManAcc_TextChanged(this.gpsInfoControl1_ManAcc_OnTextChanged);
            this.gpsInfoControl1.Z_OnTextChanged += new TwoTrails.Controls.GpsInfoControl.Z_TextChanged(this.gpsInfoControl1_Z_OnTextChanged);
            this.gpsInfoControl1.DelNmea_OnClick += new TwoTrails.Controls.GpsInfoControl.DelNmea_Click(this.gpsInfoControl1_DelNmea_OnClick);
            this.gpsInfoControl1.X_OnTextChanged += new TwoTrails.Controls.GpsInfoControl.X_TextChanged(this.gpsInfoControl1_X_OnTextChanged);
            // 
            // quondamInfoControl1
            // 
            this.quondamInfoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quondamInfoControl1.AutoScroll = true;
            this.quondamInfoControl1.Location = new System.Drawing.Point(0, 98);
            this.quondamInfoControl1.Name = "quondamInfoControl1";
            this.quondamInfoControl1.Size = new System.Drawing.Size(240, 116);
            this.quondamInfoControl1.TabIndex = 6;
            this.quondamInfoControl1.PointsRetraced += new TwoTrails.Controls.QuondamInfoControl.PointsRetracedEvent(this.quondamInfoControl1_PointsRetraced);
            this.quondamInfoControl1.GotFocus += new System.EventHandler(this.quondamInfoControl1_GotFocused);
            this.quondamInfoControl1.PointConverted += new TwoTrails.Controls.QuondamInfoControl.PointConvertedEvent(this.quondamInfoControl1_PointConverted);
            this.quondamInfoControl1.Point_OnIndexChanged += new TwoTrails.Controls.QuondamInfoControl.SelectedPointChanged(this.quondamInfoControl1_Point_OnIndexChanged);
            this.quondamInfoControl1.Polygon_OnIndexChanged += new TwoTrails.Controls.QuondamInfoControl.SelectedPolygonChanged(this.quondamInfoControl1_Polygon_OnIndexChanged);
            // 
            // travInfoControl1
            // 
            this.travInfoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.travInfoControl1.Location = new System.Drawing.Point(0, 98);
            this.travInfoControl1.Name = "travInfoControl1";
            this.travInfoControl1.Size = new System.Drawing.Size(240, 116);
            this.travInfoControl1.TabIndex = 5;
            this.travInfoControl1.BAzTextChanged += new TwoTrails.Controls.TravInfoControl.BAzTextChangedEvent(this.travInfoControl1_BAzTextChanged);
            this.travInfoControl1.GotFocus += new System.EventHandler(this.travInfoControl1_GotFocused);
            this.travInfoControl1.SlopeAngleTextChanged += new TwoTrails.Controls.TravInfoControl.SlopeAngleTextChangedEvent(this.travInfoControl1_SlopeAngleTextChanged);
            this.travInfoControl1.SlopeDistTextChanged += new TwoTrails.Controls.TravInfoControl.SlopeDistTextChangedEvent(this.travInfoControl1_SlopeDistTextChanged);
            this.travInfoControl1.FAzTextChanged += new TwoTrails.Controls.TravInfoControl.FAzTextChangedEvent(this.travInfoControl1_FAzTextChanged);
            this.travInfoControl1.ValuesSet += new TwoTrails.Controls.TravInfoControl.ValuesSetEvent(travInfoControl1_ValuesSet);
            // 
            // walkInfoCtrl1
            // 
            this.walkInfoCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.walkInfoCtrl1.Location = new System.Drawing.Point(0, 98);
            this.walkInfoCtrl1.Name = "walkInfoCtrl1";
            this.walkInfoCtrl1.Size = new System.Drawing.Size(240, 116);
            this.walkInfoCtrl1.TabIndex = 4;
            this.walkInfoCtrl1.GotFocus += new System.EventHandler(this.walkInfoCtrl1_GotFocus);
            this.walkInfoCtrl1.DeleteWalk += new TwoTrails.Controls.WalkInfoCtrl.ButtonDeleteEvent(this.walkInfoCtrl1_DeleteWalk);
            this.walkInfoCtrl1.ButtonHide += new TwoTrails.Controls.WalkInfoCtrl.ButtonHideEvent(this.walkInfoCtrl1_ButtonHide);
            this.walkInfoCtrl1.EditAccuracy += new TwoTrails.Controls.WalkInfoCtrl.EditAccuracyEvent(this.walkInfoCtrl1_EditAccuracy);
            this.walkInfoCtrl1.AddToWalk += new TwoTrails.Controls.WalkInfoCtrl.ButtonAddEvent(this.walkInfoCtrl1_AddToWalk);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.actionsControl);
            this.panel1.Controls.Add(this.pointNavigationCtrl);
            this.panel1.Controls.Add(this.pointInfoCtrl);
            this.panel1.Controls.Add(this.take5InfoCtrl1);
            this.panel1.Controls.Add(this.gpsInfoControl1);
            this.panel1.Controls.Add(this.quondamInfoControl1);
            this.panel1.Controls.Add(this.walkInfoCtrl1);
            this.panel1.Controls.Add(this.travInfoControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 214);
            // 
            // PointEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "PointEditForm";
            this.Text = "PointEditForm";
            this.Load += new System.EventHandler(this.PointEditForm_Load);
            this.GotFocus += new System.EventHandler(this.PointEditForm_GotFocus);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PointEditForm_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PointEditForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private TwoTrails.Controls.ActionsControl actionsControl;
        private TwoTrails.Controls.PointNavigationCtrl pointNavigationCtrl;
        private TwoTrails.Controls.PointInfoCtrl pointInfoCtrl;
        private TwoTrails.Controls.Take5InfoCtrl take5InfoCtrl1;
        private TwoTrails.Controls.WalkInfoCtrl walkInfoCtrl1;
        private TwoTrails.Controls.TravInfoControl travInfoControl1;
        private TwoTrails.Controls.QuondamInfoControl quondamInfoControl1;
        private TwoTrails.Controls.GpsInfoControl gpsInfoControl1;
        private System.Windows.Forms.Panel panel1;
    }
}