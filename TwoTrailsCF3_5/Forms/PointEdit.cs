using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Forms
{
    public partial class PointEdit : Form
    {
        public PointEdit()
        {
            InitializeComponent();
        }

        private void PointEdit_Load(object sender, EventArgs e)
        {
            PointEdit_Load2();

        }
        #region Point Navigation
        private void indexNavControl1_AlreadyAtBeginning(object sender)
        {
            indexNavControl1_AlreadyAtBeginning2(sender);
        }

        private void indexNavControl1_AlreadyAtEnd(object sender)
        {
            indexNavControl1_AlreadyAtEnd2(sender);
        }

        private void indexNavControl1_IndexChanged(object sender, PointNavEventArgs e)
        {
            indexNavControl1_IndexChanged2(sender, e);
        }
        #endregion
        #region Point Actions
        private void actionsControl1_New_OnClick(object sender, EventArgs e)
        {
            actionsControl1_New_OnClick2(sender, e);
        }

        private void actionsControl1_Ok_OnClick(object sender, EventArgs e)
        {
            actionsControl1_Ok_OnClick2(sender, e);
        }

        private void actionsControl1_Misc_OnClick(object sender, EventArgs e)
        {
            actionsControl1_Misc_OnClick2(sender, e);
        }

        private void actionsControl1_Delete_OnClick(object sender, EventArgs e)
        {
            actionsControl1_Delete_OnClick2(sender, e);
        }

        private void actionsControl1_Cancel_OnClick(object sender, EventArgs e)
        {
            actionsControl1_Cancel_OnClick2(sender, e);
        }
        #endregion

        private void PointEdit_Closed(object sender, EventArgs e)
        {
            
        }

        private void PointEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        #region Point Info Changed events
        private void pointInfoCtrl1_Comment_OnTextChanged(object sender, EventArgs e)
        {
            pointInfoCtrl1_Comment_OnTextChanged2(sender, e);
        }

        private void pointInfoCtrl1_PID_OnTextChanged(object sender, EventArgs e)
        {
            pointInfoCtrl1_PID_OnTextChanged2(sender, e);
        }

        private void pointInfoCtrl1_OnBoundary_Click()
        {
            pointInfoCtrl1_OnBoundary_Click2();
        }

        private void pointInfoCtrl1_OnMetaDef_SelectedIndexChanged()
        {
            pointInfoCtrl1_OnMetaDef_SelectedIndexChanged2();
        }

        private void pointInfoCtrl1_OnOp_SelectedIndexChanged()
        {
            pointInfoCtrl1_OnOp_SelectedIndexChanged2();
        }

        private void pointInfoCtrl1_OnPoly_SelectedIndexChanged()
        {
            pointInfoCtrl1_OnPoly_SelectedIndexChanged2();
        }
        #endregion

        #region GPS Data Changed Events
        private void gpsInfoControl1_X_OnTextChanged(object sender, EventArgs e)
        {
            _dirty = true;
        }

        private void gpsInfoControl1_Y_OnTextChanged(object sender, EventArgs e)
        {
            _dirty = true;
        }

        private void gpsInfoControl1_Z_OnTextChanged(object sender, EventArgs e)
        {
            _dirty = true;
        }
        #endregion

        #region Quondom Info Changed
        private void quondamInfoControl1_Point_OnIndexChanged(object sender, EventArgs e)
        {
            _dirty = true;
        }

        private void quondamInfoControl1_Polygon_OnIndexChanged(object sender, EventArgs e)
        {
            _dirty = true;
        }
        #endregion

        private void PointEdit_Closing(object sender, CancelEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            PointEdit_Closing2(sender, e);
            Cursor.Hide();
            Cursor.Current = Cursors.Default;
        }

    }
}