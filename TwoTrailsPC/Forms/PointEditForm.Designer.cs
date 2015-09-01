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
            this.pointNavigationCtrl = new TwoTrails.Controls.PointNavigationCtrl();
            this.actionsControl = new TwoTrails.Controls.ActionsControl();
            this.take5InfoCtrl1 = new TwoTrails.Controls.Take5InfoCtrl();
            this.travInfoControl1 = new TwoTrails.Controls.TravInfoControl();
            this.walkInfoCtrl1 = new TwoTrails.Controls.WalkInfoCtrl();
            this.gpsInfoControl1 = new TwoTrails.Controls.GpsInfoControl();
            this.pointInfoCtrl = new TwoTrails.Controls.PointInfoCtrl();
            this.quondamInfoControl1 = new TwoTrails.Controls.QuondamInfoControl();
            this.SuspendLayout();
            // 
            // pointNavigationCtrl
            // 
            this.pointNavigationCtrl.BackwardButtons = true;
            this.pointNavigationCtrl.ForwardButtons = true;
            this.pointNavigationCtrl.Location = new System.Drawing.Point(0, 296);
            this.pointNavigationCtrl.Name = "pointNavigationCtrl";
            this.pointNavigationCtrl.Size = new System.Drawing.Size(330, 40);
            this.pointNavigationCtrl.TabIndex = 7;
            this.pointNavigationCtrl.AlreadyAtEnd += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtEndEvent(this.pointNavigationCtrl_AlreadyAtEnd);
            this.pointNavigationCtrl.AlreadyAtBeginning += new TwoTrails.Controls.PointNavigationCtrl.AlreadyAtBeginningEvent(this.pointNavigationCtrl_AlreadyAtBeginning);
            this.pointNavigationCtrl.IndexChanged += new TwoTrails.Controls.PointNavigationCtrl.IndexChangedEvent(this.pointNavigationCtrl_IndexChanged);
            this.pointNavigationCtrl.JumpPoint += new TwoTrails.Controls.PointNavigationCtrl.JumpPointEvent(this.pointNavigationCtrl_JumpPoint);
            // 
            // actionsControl
            // 
            this.actionsControl.DeleteEnabled = true;
            this.actionsControl.Location = new System.Drawing.Point(0, 342);
            this.actionsControl.MiscButtonEnabled = true;
            this.actionsControl.MiscButtonText = "Misc";
            this.actionsControl.Name = "actionsControl";
            this.actionsControl.NewEnabled = true;
            this.actionsControl.Size = new System.Drawing.Size(330, 47);
            this.actionsControl.TabIndex = 6;
            this.actionsControl.New_OnClick += new TwoTrails.Controls.ActionsControl.NewClicked(this.actionsControl_New_OnClick);
            this.actionsControl.Cancel_OnClick += new TwoTrails.Controls.ActionsControl.CancelClicked(this.actionsControl_Cancel_OnClick);
            this.actionsControl.Delete_OnClick += new TwoTrails.Controls.ActionsControl.DeleteClicked(this.actionsControl_Delete_OnClick);
            this.actionsControl.Misc_OnClick += new TwoTrails.Controls.ActionsControl.MiscClicked(this.actionsControl_Misc_OnClick);
            this.actionsControl.Ok_OnClick += new TwoTrails.Controls.ActionsControl.OkClicked(this.actionsControl_Ok_OnClick);
            // 
            // take5InfoCtrl1
            // 
            this.take5InfoCtrl1.Location = new System.Drawing.Point(0, 120);
            this.take5InfoCtrl1.Name = "take5InfoCtrl1";
            this.take5InfoCtrl1.Size = new System.Drawing.Size(330, 170);
            this.take5InfoCtrl1.TabIndex = 5;
            this.take5InfoCtrl1.TabStop = false;
            this.take5InfoCtrl1.Visible = false;
            this.take5InfoCtrl1.BurstAmountChanged += new TwoTrails.Controls.Take5InfoCtrl.BurstAmountChangedEvent(this.take5InfoCtrl1_BurstAmountChanged);
            this.take5InfoCtrl1.ButtonHide += new TwoTrails.Controls.Take5InfoCtrl.ButtonHideEvent(this.take5InfoCtrl1_ButtonHide);
            this.take5InfoCtrl1.GotFocused += new TwoTrails.Controls.Take5InfoCtrl.GotFocusEvent(this.take5InfoCtrl1_GotFocused);
            // 
            // travInfoControl1
            // 
            this.travInfoControl1.FlashAz = false;
            this.travInfoControl1.Location = new System.Drawing.Point(0, 120);
            this.travInfoControl1.MetaData = null;
            this.travInfoControl1.Name = "travInfoControl1";
            this.travInfoControl1.Size = new System.Drawing.Size(330, 130);
            this.travInfoControl1.TabIndex = 4;
            this.travInfoControl1.TabStop = false;
            this.travInfoControl1.Visible = false;
            this.travInfoControl1.SlopeAngleTextChanged += new TwoTrails.Controls.TravInfoControl.SlopeAngleTextChangedEvent(this.travInfoControl_SlopeAngleTextChanged);
            this.travInfoControl1.FAzTextChanged += new TwoTrails.Controls.TravInfoControl.FAzTextChangedEvent(this.travInfoControl_FAzTextChanged);
            this.travInfoControl1.SlopeDistTextChanged += new TwoTrails.Controls.TravInfoControl.SlopeDistTextChangedEvent(this.travInfoControl_SlopeDistTextChanged);
            this.travInfoControl1.GotFocused += new TwoTrails.Controls.TravInfoControl.GotFocusEvent(this.travInfoControl1_GotFocused);
            this.travInfoControl1.BAzTextChanged += new TwoTrails.Controls.TravInfoControl.BAzTextChangedEvent(this.travInfoControl_BAzTextChanged);
            // 
            // walkInfoCtrl1
            // 
            this.walkInfoCtrl1.Location = new System.Drawing.Point(0, 122);
            this.walkInfoCtrl1.Name = "walkInfoCtrl1";
            this.walkInfoCtrl1.Size = new System.Drawing.Size(330, 128);
            this.walkInfoCtrl1.TabIndex = 3;
            this.walkInfoCtrl1.TabStop = false;
            this.walkInfoCtrl1.Visible = false;
            this.walkInfoCtrl1.DeleteWalk += new TwoTrails.Controls.WalkInfoCtrl.ButtonDeleteEvent(this.walkInfoCtrl_DeleteWalk);
            this.walkInfoCtrl1.EditAccuracy += new TwoTrails.Controls.WalkInfoCtrl.EditAccuracyEvent(this.walkInfoCtrl_EditAccuracy);
            this.walkInfoCtrl1.AddToWalk += new TwoTrails.Controls.WalkInfoCtrl.ButtonAddEvent(this.walkInfoCtrl_AddToWalk);
            this.walkInfoCtrl1.ButtonHide += new TwoTrails.Controls.WalkInfoCtrl.ButtonHideEvent(this.walkInfoCtrl_ButtonHide);
            // 
            // gpsInfoControl1
            // 
            this.gpsInfoControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.gpsInfoControl1.Location = new System.Drawing.Point(0, 122);
            this.gpsInfoControl1.MiscButtonText = "Misc";
            this.gpsInfoControl1.Name = "gpsInfoControl1";
            this.gpsInfoControl1.ShowMiscButton = true;
            this.gpsInfoControl1.Size = new System.Drawing.Size(330, 170);
            this.gpsInfoControl1.TabIndex = 1;
            this.gpsInfoControl1.TabStop = false;
            this.gpsInfoControl1.Visible = false;
            this.gpsInfoControl1.X_OnTextChanged += new TwoTrails.Controls.GpsInfoControl.X_TextChanged(this.gpsInfoControl_X_OnTextChanged);
            this.gpsInfoControl1.DelNmea_OnClick += new TwoTrails.Controls.GpsInfoControl.DelNmea_Click(this.gpsInfoControl_DelNmea_OnClick);
            this.gpsInfoControl1.Z_OnTextChanged += new TwoTrails.Controls.GpsInfoControl.Z_TextChanged(this.gpsInfoControl_Z_OnTextChanged);
            this.gpsInfoControl1.MiscClick += new TwoTrails.Controls.MiscClickEvent(this.gpsInfoControl_MiscClick);
            this.gpsInfoControl1.GotFocused += new TwoTrails.Controls.GpsInfoControl.GotFocusEvent(this.gpsInfoControl1_GotFocused);
            this.gpsInfoControl1.Y_OnTextChanged += new TwoTrails.Controls.GpsInfoControl.Y_TextChanged(this.gpsInfoControl_Y_OnTextChanged);
            this.gpsInfoControl1.ManAcc_OnTextChanged += new TwoTrails.Controls.GpsInfoControl.ManAcc_TextChanged(this.gpsInfoControl_ManAcc_OnTextChanged);
            // 
            // pointInfoCtrl
            // 
            this.pointInfoCtrl.CheckLockEnabled = false;
            this.pointInfoCtrl.FlashPoint = false;
            this.pointInfoCtrl.Location = new System.Drawing.Point(0, 0);
            this.pointInfoCtrl.Name = "pointInfoCtrl";
            this.pointInfoCtrl.ReadOnly = false;
            this.pointInfoCtrl.Size = new System.Drawing.Size(330, 115);
            this.pointInfoCtrl.TabIndex = 0;
            this.pointInfoCtrl.OnPoly_SelectedIndexChanged += new TwoTrails.Controls.PointInfoCtrl.Poly_SelectedIndexChanged(this.pointInfoCtrl1_OnPoly_SelectedIndexChanged);
            this.pointInfoCtrl.OnMetaDef_SelectedIndexChanged += new TwoTrails.Controls.PointInfoCtrl.MetaDef_SelectedIndexChanged(this.pointInfoCtrl1_OnMetaDef_SelectedIndexChanged);
            this.pointInfoCtrl.OnPID_Enter += new TwoTrails.Controls.PointInfoCtrl.PID_Enter(this.pointInfoCtrl1_OnPID_Enter);
            this.pointInfoCtrl.PID_OnTextChanged += new TwoTrails.Controls.PointInfoCtrl.PID_TextChanged(pointInfoCtrl_PID_OnTextChanged2);
            this.pointInfoCtrl.OnBoundary_Click += new TwoTrails.Controls.PointInfoCtrl.Boundary_Click(this.pointInfoCtrl1_OnBoundary_Click);
            this.pointInfoCtrl.Comment_OnTextChanged += new TwoTrails.Controls.PointInfoCtrl.Comment_TextChanged(this.pointInfoCtrl_Comment_OnTextChanged);
            this.pointInfoCtrl.OnLocked_CheckedChanged += new TwoTrails.Controls.PointInfoCtrl.Locked_CheckedChanged(this.pointInfoCtrl1_OnLocked_CheckedChanged);
            this.pointInfoCtrl.OnOp_SelectedIndexChanged += new TwoTrails.Controls.PointInfoCtrl.Op_SelectedIndexChanged(this.pointInfoCtrl1_OnOp_SelectedIndexChanged);
            // 
            // quondamInfoControl1
            // 
            this.quondamInfoControl1.Location = new System.Drawing.Point(0, 122);
            this.quondamInfoControl1.Name = "quondamInfoControl1";
            this.quondamInfoControl1.Size = new System.Drawing.Size(330, 170);
            this.quondamInfoControl1.TabIndex = 2;
            this.quondamInfoControl1.TabStop = false;
            this.quondamInfoControl1.Visible = false;
            this.quondamInfoControl1.Polygon_OnIndexChanged += new TwoTrails.Controls.QuondamInfoControl.SelectedPolygonChanged(this.quondamInfoControl_Polygon_OnIndexChanged);
            this.quondamInfoControl1.PointsRetraced += new TwoTrails.Controls.QuondamInfoControl.PointsRetracedEvent(this.quondamInfoControl_PointsRetraced);
            this.quondamInfoControl1.PointConverted += new TwoTrails.Controls.QuondamInfoControl.PointConvertedEvent(this.quondamInfoControl_PointConverted);
            this.quondamInfoControl1.GotFocused += new TwoTrails.Controls.QuondamInfoControl.GotFocusEvent(this.quondamInfoControl1_GotFocused);
            this.quondamInfoControl1.Point_OnIndexChanged += new TwoTrails.Controls.QuondamInfoControl.SelectedPointChanged(this.quondamInfoControl_Point_OnIndexChanged);
            // 
            // PointEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 390);
            this.Controls.Add(this.pointNavigationCtrl);
            this.Controls.Add(this.actionsControl);
            this.Controls.Add(this.take5InfoCtrl1);
            this.Controls.Add(this.travInfoControl1);
            this.Controls.Add(this.walkInfoCtrl1);
            this.Controls.Add(this.gpsInfoControl1);
            this.Controls.Add(this.pointInfoCtrl);
            this.Controls.Add(this.quondamInfoControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(348, 428);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(348, 428);
            this.Name = "PointEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Point Edit";
            this.Load += new System.EventHandler(this.PointEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PointEditForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private TwoTrails.Controls.PointInfoCtrl pointInfoCtrl;
        private TwoTrails.Controls.GpsInfoControl gpsInfoControl1;
        private TwoTrails.Controls.QuondamInfoControl quondamInfoControl1;
        private TwoTrails.Controls.WalkInfoCtrl walkInfoCtrl1;
        private TwoTrails.Controls.TravInfoControl travInfoControl1;
        private TwoTrails.Controls.Take5InfoCtrl take5InfoCtrl1;
        private TwoTrails.Controls.ActionsControl actionsControl;
        private TwoTrails.Controls.PointNavigationCtrl pointNavigationCtrl;

    }
}