using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;
using TwoTrails.Engine;
using TwoTrails.Utilities;
using System.IO;

namespace TwoTrails.Forms
{
    public partial class ExportForm : Form
    {
        DataAccessLayer DAL;
        private bool _init;

        private void Init()
        {
            this.Icon = Properties.Resources.Map;
            _init = true;

            Values.DataExport.SelectedPath = System.IO.Path.GetDirectoryName(Values.CurrentTtFileName);

            if (Values.DataExport.SelectedPathDir == null)
                txtFolder.Text = "";
            else
            {
                txtFolder.Text = Values.DataExport.SelectedPath;
                txtFolder.SelectionStart = txtFolder.Text.Length;
            }

        #if (PocketPC || WindowsCE)
            chkOutShape.Enabled = false;
            chkOutShape.Checked = false;
        #endif
        }

        #region Controls
        private void btnFolder_Click2(object sender, EventArgs e)
        {
            if(Values.DataExport.SelectFolder())
                txtFolder.Text = Values.DataExport.SelectedPathDir;
        }

        private void btnClose_Click2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click2(object sender, EventArgs e)
        {
            TtUtils.ShowWaitCursor();

            while(!Directory.Exists(Values.DataExport.SelectedPathDir))
            {
                if (!Values.DataExport.SelectFolder())
                    return;
                txtFolder.Text = Values.DataExport.SelectedPath;
            }

            try
            {
                if (!Directory.Exists(Values.DataExport.SelectedPath))
                    Directory.CreateDirectory(Values.DataExport.SelectedPath);

                if (chkOutAll.Checked)
                {
                    Values.DataExport.DumpProject(DAL);
                }
                else
                {
                    if (chkOutNmea.Checked)
                        Values.DataExport.WriteTtNmea(DAL);
                    if (chkOutProject.Checked)
                        Values.DataExport.WriteProject(DAL);
                    if (chkOutMeta.Checked)
                        Values.DataExport.WriteMeta(DAL);
                    if (chkOutPoly.Checked)
                        Values.DataExport.WritePolygons(DAL);
                    if(chkOutPoints.Checked)
                        Values.DataExport.WritePoints(DAL);
                    if(chkOutKmz.Checked)
                        Values.DataExport.WriteKmz(DAL);
                    if(chkOutSummary.Checked)
                        Values.DataExport.WriteSummary(DAL);
                    if(chkOutGpx.Checked)
                        Values.DataExport.WriteGpx(DAL);
#if !(PocketPC || WindowsCE || Mobile)
                    if (chkOutShape.Checked)
                        Values.DataExport.WriteShapeFiles(DAL);
#endif
                    if (chkOutHtml.Checked)
                        Values.DataExport.WriteHtml(DAL);
                }
                TtUtils.HideWaitCursor();

#if !(PocketPC || WindowsCE || Mobile)

                Values.UpdateStatusText(String.Format("Files Exported to folder: {0}.", System.IO.Path.GetFileName(Values.DataExport.SelectedPath)));
#endif
                MessageBox.Show(String.Format("Files Exported to {0}.", Values.DataExport.SelectedPath));
            }
            catch(Exception ex)
            {
                TtUtils.HideWaitCursor();
                TtUtils.WriteError(ex.Message, "ExportFormLogic:Export", ex.StackTrace);
                MessageBox.Show("Data write error.");
            }
        }
        #endregion

        private bool CheckAll
        {
            set
            {
                if (!value)
                {
                    _init = false;
                    chkOutAll.Checked = false;
                }
            }
        }

        #region Options
        private void chkOutAll_CheckStateChanged2(object sender, EventArgs e)
        {
            if (_init)
            {
                bool chked = chkOutAll.Checked;

                chkOutPoints.Checked = chked;
                chkOutProject.Checked = chked;
                chkOutNmea.Checked = chked;
                chkOutKmz.Checked = chked;
                chkOutMeta.Checked = chked;
                chkOutPoly.Checked = chked;
                chkOutSummary.Checked = chked;
                chkOutGpx.Checked = chked;
                chkOutHtml.Checked = chked;

                #if !(PocketPC || WindowsCE)
                chkOutShape.Checked = chked;
                #endif
            }
            _init = true;
        }

        private void chkOutPoints_CheckStateChanged2(object sender, EventArgs e)
        {
            CheckAll = chkOutPoints.Checked;
        }

        private void chkOutProject_CheckStateChanged2(object sender, EventArgs e)
        {
            CheckAll = chkOutProject.Checked;
        }

        private void chkOutNmea_CheckStateChanged2(object sender, EventArgs e)
        {
            CheckAll = chkOutNmea.Checked;
        }

        private void chkOutKmz_CheckStateChanged2(object sender, EventArgs e)
        {
            CheckAll = chkOutKmz.Checked;
        }

        private void chkOutMeta_CheckStateChanged2(object sender, EventArgs e)
        {
            CheckAll = chkOutMeta.Checked;
        }

        private void chkOutPoly_CheckStateChanged2(object sender, EventArgs e)
        {
            CheckAll = chkOutPoly.Checked;
        }

        private void chkOutGpx_CheckStateChanged2(object sender, EventArgs e)
        {
            CheckAll = chkOutGpx.Checked;
        }

        private void chkOutSummary_CheckStateChanged2(object sender, EventArgs e)
        {
            CheckAll = chkOutSummary.Checked;
        }

        private void chkOutShape_CheckStateChanged2(object sender, EventArgs e)
        {
            CheckAll = chkOutShape.Checked;
        }

        private void chkOutHtml_CheckStateChanged2(object sender, EventArgs e)
        {
            CheckAll = chkOutAll.Checked;
        }
        #endregion
    }
}