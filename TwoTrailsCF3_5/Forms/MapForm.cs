using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class MapForm : Form
    {

        public MapForm()
        {
            InitializeComponent();
            setZoom(1);
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            MapForm_Load2(sender, e);
        }

        #region Controls

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            draw(sender, e);
        }

        private void zoomBar_ValueChanged(object sender, EventArgs e)
        {
            zoomBar_ValueChanged2(sender, e);
        }

        private void drawPanel_DoubleClick(object sender, EventArgs e)
        {
            drawPanel_DoubleClick2(sender, e);
        }

        private void drawPanel_Click(object sender, EventArgs e)
        {
            drawPanel_Click2(sender, e);
        }

        private void picUp_Click(object sender, EventArgs e)
        {
            picUp_Click2(sender, e);
        }

        private void picRight_Click(object sender, EventArgs e)
        {
            picRight_Click2(sender, e);
        }

        private void picDown_Click(object sender, EventArgs e)
        {
            picDown_Click2(sender, e);
        }

        private void picLeft_Click(object sender, EventArgs e)
        {
            picLeft_Click2(sender, e);
        }

        private void picCenter_Click(object sender, EventArgs e)
        {
            picCenter_Click2(sender, e);
        }

        private void pnlMoveImage_Click(object sender, EventArgs e)
        {
            pnlMoveImage_Click2(sender, e);
        }

        private void tmrMovePad_Tick(object sender, EventArgs e)
        {
            tmrMovePad_Tick2(sender, e);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            picClose_Click2(sender, e);
        }

        private void MapForm_Closed(object sender, EventArgs e)
        {
            MapForm_Closed2(sender, e);
        }

        #endregion

        #region ConstantMove

        private void picRight_MouseDown(object sender, MouseEventArgs e)
        {
            picRight_MouseDown2(sender, e);
        }

        private void picRight_MouseUp(object sender, MouseEventArgs e)
        {
            picRight_MouseUp2(sender, e);
        }

        private void picDown_MouseDown(object sender, MouseEventArgs e)
        {
            picDown_MouseDown2(sender, e);
        }

        private void picDown_MouseUp(object sender, MouseEventArgs e)
        {
            picDown_MouseUp2(sender, e);
        }

        private void picLeft_MouseDown(object sender, MouseEventArgs e)
        {
            picLeft_MouseDown2(sender, e);
        }

        private void picLeft_MouseUp(object sender, MouseEventArgs e)
        {
            picLeft_MouseUp2(sender, e);
        }

        private void picUp_MouseDown(object sender, MouseEventArgs e)
        {
            picUp_MouseDown2(sender, e);
        }

        private void picUp_MouseUp(object sender, MouseEventArgs e)
        {
            picUp_MouseUp2(sender, e);
        }
        #endregion

        #region Settings
        private void btnSettings_Click(object sender, EventArgs e)
        {
            btnSettings_Click2(sender, e);
        }

        private void chkInvert_CheckStateChanged(object sender, EventArgs e)
        {
            chkInvert_CheckStateChanged2(sender, e);
        }

        private void chkLabels_CheckStateChanged(object sender, EventArgs e)
        {
            chkLabels_CheckedChanged2(sender, e);
        }

        private void chkMyPos_CheckStateChanged(object sender, EventArgs e)
        {
            chkMyPos_CheckStateChanged2(sender, e);
        }

        private void chkFollowPos_CheckStateChanged(object sender, EventArgs e)
        {
            chkFollowPos_CheckStateChanged2(sender, e);
        }

        private void chkDetails_CheckStateChanged(object sender, EventArgs e)
        {
            chkDetails_CheckStateChanged2(sender, e);
        }

        private void radLatLon_CheckedChanged(object sender, EventArgs e)
        {
            radLatLon_CheckedChanged2(sender, e);
        }

        private void radUTM_CheckedChanged(object sender, EventArgs e)
        {
            radUTM_CheckedChanged2(sender, e);
        }
        #endregion

        private void drawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            drawPanel_MouseMove2(sender, e);
        }

        private void MapForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                picUp_Click2(sender, e);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                picDown_Click2(sender, e);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                picLeft_Click2(sender, e);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                picRight_Click2(sender, e);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                drawPanel_DoubleClick2(sender, e);
                //drawPanel_Click2(sender, e);
            }
        }

        private void drawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            drawPanel_MouseDown2(sender, e);
        }
    }
}