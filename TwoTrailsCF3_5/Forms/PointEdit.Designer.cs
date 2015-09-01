using TwoTrails.BusinessObjects;
namespace TwoTrails.Forms
{
    partial class PointEdit
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
            this.quondamInfoControl1 = new TwoTrails.Controls.QuondamInfoControl();
            this.travInfoControl1 = new TwoTrails.Controls.TravInfoControl();
            this.gpsInfoControl1 = new TwoTrails.Forms.GpsInfoControl();
            this.actionsControl1 = new TwoTrails.Forms.ActionsControl();
            this.indexNavControl1 = new TwoTrails.Forms.IndexNavControl();
            this.pointInfoCtrl1 = new TwoTrails.Forms.PointInfoCtrl();
            this.walkInfoCtrl1 = new TwoTrails.Controls.WalkInfoCtrl();
            this.SuspendLayout();
            // 
            // take5InfoCtrl1
            // 
            this.take5InfoCtrl1.Location = new System.Drawing.Point(0, 98);
            this.take5InfoCtrl1.Name = "take5InfoCtrl1";
            this.take5InfoCtrl1.Size = new System.Drawing.Size(240, 120);
            this.take5InfoCtrl1.TabIndex = 6;
            // 
            // quondamInfoControl1
            // 
            this.quondamInfoControl1.Location = new System.Drawing.Point(0, 98);
            this.quondamInfoControl1.Name = "quondamInfoControl1";
            this.quondamInfoControl1.Size = new System.Drawing.Size(240, 120);
            this.quondamInfoControl1.TabIndex = 5;
            this.quondamInfoControl1.Point_OnIndexChanged += new TwoTrails.Controls.QuondamInfoControl.SelectedPointChanged(this.quondamInfoControl1_Point_OnIndexChanged);
            this.quondamInfoControl1.Polygon_OnIndexChanged += new TwoTrails.Controls.QuondamInfoControl.SelectedPolygonChanged(this.quondamInfoControl1_Polygon_OnIndexChanged);
            // 
            // travInfoControl1
            // 
            this.travInfoControl1.Location = new System.Drawing.Point(0, 98);
            this.travInfoControl1.Name = "travInfoControl1";
            this.travInfoControl1.Size = new System.Drawing.Size(240, 120);
            this.travInfoControl1.TabIndex = 4;
            // 
            // gpsInfoControl1
            // 
            this.gpsInfoControl1.Location = new System.Drawing.Point(0, 98);
            this.gpsInfoControl1.Name = "gpsInfoControl1";
            this.gpsInfoControl1.Size = new System.Drawing.Size(240, 120);
            this.gpsInfoControl1.TabIndex = 3;
            this.gpsInfoControl1.Y_OnTextChanged += new TwoTrails.Forms.GpsInfoControl.Y_TextChanged(this.gpsInfoControl1_Y_OnTextChanged);
            this.gpsInfoControl1.Z_OnTextChanged += new TwoTrails.Forms.GpsInfoControl.Z_TextChanged(this.gpsInfoControl1_Z_OnTextChanged);
            this.gpsInfoControl1.X_OnTextChanged += new TwoTrails.Forms.GpsInfoControl.X_TextChanged(this.gpsInfoControl1_X_OnTextChanged);
            // 
            // actionsControl1
            // 
            this.actionsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsControl1.DeleteEnabled = true;
            this.actionsControl1.Location = new System.Drawing.Point(0, 254);
            this.actionsControl1.MiscButtonEnabled = true;
            this.actionsControl1.MiscButtonText = "Misc";
            this.actionsControl1.Name = "actionsControl1";
            this.actionsControl1.Size = new System.Drawing.Size(240, 40);
            this.actionsControl1.TabIndex = 2;
            this.actionsControl1.Misc_OnClick += new TwoTrails.Forms.ActionsControl.MiscClicked(this.actionsControl1_Misc_OnClick);
            this.actionsControl1.Cancel_OnClick += new TwoTrails.Forms.ActionsControl.CancelClicked(this.actionsControl1_Cancel_OnClick);
            this.actionsControl1.New_OnClick += new TwoTrails.Forms.ActionsControl.NewClicked(this.actionsControl1_New_OnClick);
            this.actionsControl1.Ok_OnClick += new TwoTrails.Forms.ActionsControl.OkClicked(this.actionsControl1_Ok_OnClick);
            this.actionsControl1.Delete_OnClick += new TwoTrails.Forms.ActionsControl.DeleteClicked(this.actionsControl1_Delete_OnClick);
            // 
            // indexNavControl1
            // 
            this.indexNavControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.indexNavControl1.Location = new System.Drawing.Point(0, 218);
            this.indexNavControl1.Name = "indexNavControl1";
            this.indexNavControl1.NavigationEnabled = true;
            this.indexNavControl1.SelectedIndex = -1;
            this.indexNavControl1.Size = new System.Drawing.Size(240, 36);
            this.indexNavControl1.TabIndex = 1;
            this.indexNavControl1.AlreadyAtEnd += new TwoTrails.Forms.IndexNavControl.AlreadyAtEndEvent(this.indexNavControl1_AlreadyAtEnd);
            this.indexNavControl1.AlreadyAtBeginning += new TwoTrails.Forms.IndexNavControl.AlreadyAtBeginningEvent(this.indexNavControl1_AlreadyAtBeginning);
            this.indexNavControl1.IndexChanged += new TwoTrails.Forms.IndexNavControl.IndexChangedEvent(this.indexNavControl1_IndexChanged);
            // 
            // pointInfoCtrl1
            // 
            this.pointInfoCtrl1.Comment = "";
            this.pointInfoCtrl1.Location = new System.Drawing.Point(0, 0);
            this.pointInfoCtrl1.MetaDefID = "";
            this.pointInfoCtrl1.Name = "pointInfoCtrl1";
            this.pointInfoCtrl1.OnBoundary = false;
            this.pointInfoCtrl1.PID = "";
            this.pointInfoCtrl1.PolyID = "";
            this.pointInfoCtrl1.ReadOnly = false;
            this.pointInfoCtrl1.Size = new System.Drawing.Size(240, 98);
            this.pointInfoCtrl1.TabIndex = 0;
            this.pointInfoCtrl1.OnPoly_SelectedIndexChanged += new TwoTrails.Forms.PointInfoCtrl.Poly_SelectedIndexChanged(this.pointInfoCtrl1_OnPoly_SelectedIndexChanged);
            this.pointInfoCtrl1.PID_OnTextChanged += new TwoTrails.Forms.PointInfoCtrl.PID_TextChanged(this.pointInfoCtrl1_PID_OnTextChanged);
            this.pointInfoCtrl1.OnBoundary_Click += new TwoTrails.Forms.PointInfoCtrl.Boundary_Click(this.pointInfoCtrl1_OnBoundary_Click);
            this.pointInfoCtrl1.OnMetaDef_SelectedIndexChanged += new TwoTrails.Forms.PointInfoCtrl.MetaDef_SelectedIndexChanged(this.pointInfoCtrl1_OnMetaDef_SelectedIndexChanged);
            this.pointInfoCtrl1.OnOp_SelectedIndexChanged += new TwoTrails.Forms.PointInfoCtrl.Op_SelectedIndexChanged(this.pointInfoCtrl1_OnOp_SelectedIndexChanged);
            this.pointInfoCtrl1.Comment_OnTextChanged += new TwoTrails.Forms.PointInfoCtrl.Comment_TextChanged(this.pointInfoCtrl1_Comment_OnTextChanged);
            // 
            // walkInfoCtrl1
            // 
            this.walkInfoCtrl1.Location = new System.Drawing.Point(0, 98);
            this.walkInfoCtrl1.Name = "walkInfoCtrl1";
            this.walkInfoCtrl1.Size = new System.Drawing.Size(240, 120);
            this.walkInfoCtrl1.TabIndex = 7;
            // 
            // PointEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.walkInfoCtrl1);
            this.Controls.Add(this.take5InfoCtrl1);
            this.Controls.Add(this.quondamInfoControl1);
            this.Controls.Add(this.travInfoControl1);
            this.Controls.Add(this.gpsInfoControl1);
            this.Controls.Add(this.actionsControl1);
            this.Controls.Add(this.indexNavControl1);
            this.Controls.Add(this.pointInfoCtrl1);
            this.KeyPreview = true;
            this.Name = "PointEdit";
            this.Text = "PointEdit";
            this.Load += new System.EventHandler(this.PointEdit_Load);
            this.Closed += new System.EventHandler(this.PointEdit_Closed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PointEdit_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PointEdit_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private PointInfoCtrl pointInfoCtrl1;
        private IndexNavControl indexNavControl1;
        private ActionsControl actionsControl1;
        private GpsInfoControl gpsInfoControl1;
        private TwoTrails.Controls.TravInfoControl travInfoControl1;
        private TwoTrails.Controls.QuondamInfoControl quondamInfoControl1;
        private TwoTrails.Controls.Take5InfoCtrl take5InfoCtrl1;
        private TwoTrails.Controls.WalkInfoCtrl walkInfoCtrl1;
    }
}