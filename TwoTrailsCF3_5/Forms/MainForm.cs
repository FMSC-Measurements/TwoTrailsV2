using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Engine.BusinessLogic;
using System.IO;
using TwoTrails.Engine;
using TwoTrails.BusinessLogic;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class MainForm
    {

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainForm_Load2(sender, e);
        }

        #region Controls

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew_Click2(sender, e);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            btnInput_Click2(sender, e);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen_Click2(sender, e);
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            btnPoint_Click2(sender, e);
        }

        private void btnPoly_Click(object sender, EventArgs e)
        {
            btnPoly_Click2(sender, e);
        }

        private void btnHowAmIDoing_Click(object sender, EventArgs e)
        {
            btnHowAmIDoing_Click2(sender, e);                
        }

        private void buttonProjectInfo_Click(object sender, EventArgs e)
        {
            buttonProjectInfo_Click2(sender, e);
        }

        private void btnMeta_Click(object sender, EventArgs e)
        {
            btnMeta_Click2(sender, e);
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            btnMap_Click2(sender, e);
        }
        #endregion

        #region Setting and Controls

        private void radGpsAlwaysOnYes_CheckedChanged(object sender, EventArgs e)
        {
            radGpsAlwaysOnYes_CheckedChanged2(sender, e);
        }

        private void radGpsAlwaysOnNo_CheckedChanged(object sender, EventArgs e)
        {
            radGpsAlwaysOnNo_CheckedChanged2(sender, e);
        }

        private void btnDeviceSetup_Click(object sender, EventArgs e)
        {
            btnDeviceSetup_Click2(sender, e);
        }

        private void chkUseCombo_CheckStateChanged(object sender, EventArgs e)
        {
            chkUseCombo_CheckStateChanged2(sender, e);
        }


        private void chkOnKeyboard_CheckStateChanged(object sender, EventArgs e)
        {
            chkOnKeyboard_CheckStateChanged2(sender, e);
        }

        private void chkAutoUpdateIndex_CheckStateChanged(object sender, EventArgs e)
        {
            chkAutoUpdateIndex_CheckStateChanged2(sender, e);
        }
        #endregion

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            MainForm_Closing2(sender, e);
        }

        private void btnRecOpen_Click(object sender, EventArgs e)
        {
            btnRecOpen_Click2(sender, e);
        }

        private void cboRecOpen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboRecOpen_SelectedIndexChanged2(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnClear_Click2(sender, e);
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            btnRename_Click2(sender, e);
        }

        private void btnEditPointTable_Click(object sender, EventArgs e)
        {
            btnEditPointTable_Click2(sender, e);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport_Click2(sender, e);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            btnInfo_Click2(sender, e);
        }

        private void btnMassEdit_Click(object sender, EventArgs e)
        {
            btnMassEdit_Click2(sender, e);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            btnImport_Click2(sender, e);
        }

        private void btnDup_Click(object sender, EventArgs e)
        {
            btnDup_Click2(sender, e);
        }

        private void btnWhere_Click(object sender, EventArgs e)
        {
            btnWhere_Click2(sender, e);
        }

        private void btnPlotGrid_Click(object sender, EventArgs e)
        {
            btnPlotGrid_Click2(sender, e);
        }

        private void btnEportLog_Click(object sender, EventArgs e)
        {
            btnExportLog_Click2(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit_Click2(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset_Click2(sender, e);
        }

        private void btnGPSLogger_Click(object sender, EventArgs e)
        {
            btnGPSLogger_Click2(sender, e);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
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
    }
}