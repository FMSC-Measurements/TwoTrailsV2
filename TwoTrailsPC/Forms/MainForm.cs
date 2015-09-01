using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Utilities;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace TwoTrails.Forms
{
    public partial class MainForm : Form
    {
        private void MainForm_Load(object sender, EventArgs e)
        {
            MainForm_Load2(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew_Click2(sender, e);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen_Click2(sender, e);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            btnImport_Click2(sender, e);
        }

        private void btnDup_Click(object sender, EventArgs e)
        {
            btnDup_Click2(sender, e);
        }

        private void cboRecOpen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboRecOpen_SelectedIndexChanged2(sender, e);
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            btnPoint_Click2(sender, e);
        }

        private void btnPoly_Click(object sender, EventArgs e)
        {
            btnPoly_Click2(sender, e);
        }

        private void btnMeta_Click(object sender, EventArgs e)
        {
            btnMeta_Click2(sender, e);
        }

        private void buttonProjectInfo_Click(object sender, EventArgs e)
        {
            buttonProjectInfo_Click2(sender, e);
        }

        private void btnEditPointTable_Click(object sender, EventArgs e)
        {
            btnEditPointTable_Click2(sender, e);
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            btnMap_Click2(sender, e);
        }

        private void btnGMap_Click(object sender, EventArgs e)
        {
            btnGMap_Click2(sender, e);
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            btnRename_Click2(sender, e);
        }

        private void btnHowAmIDoing_Click(object sender, EventArgs e)
        {
            btnHowAmIDoing_Click2(sender, e);
        }

        private void btnWhere_Click(object sender, EventArgs e)
        {
            btnWhere_Click2(sender, e);
        }

        private void btnPlotGrid_Click(object sender, EventArgs e)
        {
            btnPlotGrid_Click2(sender, e);
        }

        private void btnMassEdit_Click(object sender, EventArgs e)
        {
            btnMassEdit_Click2(sender, e);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport_Click2(sender, e);
        }

        private void btnDeviceSetup_Click(object sender, EventArgs e)
        {
            btnDeviceSetup_Click2(sender, e);
        }

        private void btnExportLog_Click(object sender, EventArgs e)
        {
            btnExportLog_Click2(sender, e);
        }

        private void radGpsAlwaysOnYes_CheckedChanged(object sender, EventArgs e)
        {
            radGpsAlwaysOnYes_CheckedChanged2(sender, e);
        }

        private void radGpsAlwaysOnNo_CheckedChanged(object sender, EventArgs e)
        {
            radGpsAlwaysOnNo_CheckedChanged2(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset_Click2(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnClear_Click2(sender, e);
        }

        private void chkAutoUpdateIndex_CheckedChanged(object sender, EventArgs e)
        {
            chkAutoUpdateIndex_CheckStateChanged2(sender, e);
        }

        private void chkOnKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            chkOnKeyboard_CheckStateChanged2(sender, e);
        }

        private void chkUseCombo_CheckedChanged(object sender, EventArgs e)
        {
            chkUseCombo_CheckStateChanged2(sender, e);
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            btnNew_Click2(sender, e);
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            btnOpen_Click2(sender, e);
        }

        private void tsmiDup_Click(object sender, EventArgs e)
        {
            btnDup_Click2(sender, e);
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            btnExit_Click2(sender, e);
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            btnInfo_Click2(sender, e);
        }

        private void tsmiDoc_Click(object sender, EventArgs e)
        {
            tsmiDoc_Click2(sender, e);
        }

        private void tsmiTut_Click(object sender, EventArgs e)
        {
            tsmiTut_Click2(sender, e);
        }

        private void tsmiErrorLog_Click(object sender, EventArgs e)
        {
            tsmiErrorLog_Click2(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm_Closing2(sender, e);
        }

        private void btnGroupEdit_Click(object sender, EventArgs e)
        {
            btnGroupEdit_Click2(sender, e);
        }

        private void cboRecOpen_MouseLeave(object sender, EventArgs e)
        {
            cboRecOpen.Refresh();
        }

        private void btnGEarth_Click(object sender, EventArgs e)
        {
            btnGEarth_Click2(sender, e);
        }

        private void tsmiSettingsFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Engine.Values.Settings.BinDirPath);
        }

        private void btnMergePolys_Click(object sender, EventArgs e)
        {
            btnMergePolys_Click2(sender, e);
        }

        private void btnPolyTransform_Click(object sender, EventArgs e)
        {
            btnPolyTransform_Click2(sender, e);
        }

        private void btnGPSLogger_Click(object sender, EventArgs e)
        {
            btnGPSLogger_Click2(sender, e);
        }





        [DebuggerStepThrough]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }

        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;

            MessageBox.Show("TwoTrails is already open.", "Two Trails", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    // this class just wraps some Win32 stuff that we're going to use
    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}
