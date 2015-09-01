using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Forms
{
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();
            setZoom(1);


            this.MouseWheel += new MouseEventHandler(MapForm_MouseWheel);
        }

        ~MapForm()
        {
            this.MouseWheel -= new MouseEventHandler(MapForm_MouseWheel);
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            draw(sender, e);
        }

        private void drawPanel_Click(object sender, EventArgs e)
        {
            drawPanel_Click2(sender, e);
        }

        private void zoomBar_Scroll(object sender, EventArgs e)
        {
            zoomBar_ValueChanged2(sender, e);
        }

        private void drawPanel_DoubleClick(object sender, EventArgs e)
        {
            drawPanel_DoubleClick2(sender, e);
        }

        private void picUp_Click(object sender, EventArgs e)
        {
            picUp_Click2(sender, e);
        }

        private void picLeft_Click(object sender, EventArgs e)
        {
            picLeft_Click2(sender, e);
        }

        private void picCenter_Click(object sender, EventArgs e)
        {
            picCenter_Click2(sender, e);
        }

        private void picRight_Click(object sender, EventArgs e)
        {
            picRight_Click2(sender, e);
        }

        private void picDown_Click(object sender, EventArgs e)
        {
            picDown_Click2(sender, e);
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
                drawPanel_Click2(sender, e);
            }
        }

        private void chkInvert_CheckedChanged(object sender, EventArgs e)
        {
            chkInvert_CheckStateChanged2(sender, e);
        }

        private void chkLabels_CheckedChanged(object sender, EventArgs e)
        {
            chkLabels_CheckedChanged2(sender, e);
        }

        private void chkMyPos_CheckedChanged(object sender, EventArgs e)
        {
            chkMyPos_CheckStateChanged2(sender, e);
        }

        private void chkFollowPos_CheckedChanged(object sender, EventArgs e)
        {
            chkFollowPos_CheckStateChanged2(sender, e);
        }

        private void chkDetails_CheckedChanged(object sender, EventArgs e)
        {
            chkDetails_CheckStateChanged2(sender, e);
        }

        private void radUTM_CheckedChanged(object sender, EventArgs e)
        {
            radUTM_CheckedChanged2(sender, e);
        }

        private void radLatLon_CheckedChanged(object sender, EventArgs e)
        {
            radLatLon_CheckedChanged2(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            btnSettings_Click2(sender, e);
        }

        private void MapForm_Resize(object sender, EventArgs e)
        {
            drawPanel.Refresh();
        }

        private void picRight_MouseDown(object sender, MouseEventArgs e)
        {
            picRight_MouseDown2(sender, e);
        }

        private void picRight_MouseUp(object sender, MouseEventArgs e)
        {
            picRight_MouseUp2(sender, e);
        }

        private void picUp_MouseDown(object sender, MouseEventArgs e)
        {
            picUp_MouseDown2(sender, e);
        }

        private void picUp_MouseUp(object sender, MouseEventArgs e)
        {
            picUp_MouseUp2(sender, e);
        }

        private void picLeft_MouseDown(object sender, MouseEventArgs e)
        {
            picLeft_MouseDown2(sender, e);
        }

        private void picLeft_MouseUp(object sender, MouseEventArgs e)
        {
            picLeft_MouseUp2(sender, e);
        }

        private void picDown_MouseDown(object sender, MouseEventArgs e)
        {
            picDown_MouseDown2(sender, e);
        }

        private void picDown_MouseUp(object sender, MouseEventArgs e)
        {
            picDown_MouseUp2(sender, e);
        }

        private void tmrMovePad_Tick(object sender, EventArgs e)
        {
            tmrMovePad_Tick2(sender, e);
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            MapForm_Load2(sender, e);
        }

        private void drawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            drawPanel_MouseMove2(sender, e);
        }

        void MapForm_MouseWheel(object sender, MouseEventArgs e)
        {
            MapForm_MouseWheel2(sender, e);
        }

        private void drawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            drawPanel_MouseDown2(sender, e);
        }

        private void ctxmsPrint_Click(object sender, EventArgs e)
        {
            using (PrintDialog pd = new PrintDialog())
            {
                pd.Document = printDoc;
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }

        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            drawPrint(sender, e);
        }
    }
}
