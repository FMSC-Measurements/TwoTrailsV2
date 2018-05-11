using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using System.IO;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;
using TwoTrails.Engine;

namespace TwoTrails.Forms
{
    public partial class ImportForm : Form
    {
        DataAccessLayer DAL;
        DataImport DI;
        bool _adjust = false;


        DataImport.FileType _FileType = DataImport.FileType.Text;
        
#if (PocketPC || WindowsCE || Mobile)
        List<DataPair> _Tt2PolyList;
#else
        BindingList<DataPair> _ShapeFileList;
#endif

        private void Init()
        {
            this.Icon = Properties.Resources.Map;

            if (DAL != null && DAL.IsOpen)
            {
                //create new dataaccess layer
            }
            
            DI = new DataImport(DAL);

#if !(PocketPC || WindowsCE || Mobile)
            lblShpZone.Text = DI.ProjectZone.ToString();

            _ShapeFileList = new BindingList<DataPair>();
            lstShpFiles.DisplayMember = "Name";
            lstShpFiles.DataSource = _ShapeFileList;
#endif
        }

#if (PocketPC || WindowsCE || Mobile)
        private void ImportForm_FormClosing2(object sender, CancelEventArgs e)
#else
        private void ImportForm_FormClosing2(object sender, FormClosingEventArgs e)
#endif
        {
            if (_adjust)
            {
                TwoTrails.BusinessLogic.PolygonAdjuster.Adjust(DAL, this);
                _adjust = false;
                e.Cancel = true;
            }

            if (DI != null)
            {
                DI.Dispose();
            }
        }

        private void GoToFileTypePage()
        {
            switch (_FileType)
            {
                case DataImport.FileType.Text:
                    tabControl.SelectedIndex = 1;
                    break;
                case DataImport.FileType.Shape:
                    tabControl.SelectedIndex = 0;
                    break;
                case DataImport.FileType.GoogleEarth:
                    MessageBox.Show("Not Yet Implemented.");
                    break;
                case DataImport.FileType.GPX:
                    tabControl.SelectedIndex = 2;
                    break;
                case DataImport.FileType.TwoTrails:
                    tabControl.SelectedIndex = 3;
                    break;
                case DataImport.FileType.TwoTrails2:
                    tabControl.SelectedIndex = 4;
                    break;
                case DataImport.FileType.NotImplementedType:
                    MessageBox.Show("File Type not Implemented.");
                    break;
            }

            if (_FileType != DataImport.FileType.NotImplementedType)
                btnImport.Enabled = true;
        }


        private bool Import()
        {
            bool result = false;
            switch (_FileType)
            {
                case DataImport.FileType.Text:
#if (PocketPC || WindowsCE || Mobile)
                    result = DI.ImportText(radTxtLatLng.Checked, chkTxtMultiPoly.Checked,
                        chkTxtPID.Checked, chkTxtIndex.Checked, chkTxtElev.Checked, radTxtElevFeet.Checked, true, true);
#else
                    result = DI.ImportText(radTxtLatLng.Checked, chkTxtMultiPoly.Checked,
                        chkTxtPID.Checked, chkTxtIndex.Checked, chkTxtElev.Checked, radTxtElevFeet.Checked,
                        chkUseCmt.Checked, chkUseOnBound.Checked);
#endif
                    break;
                case DataImport.FileType.GoogleEarth:
                    break;
#if !(PocketPC || WindowsCE || Mobile)
                case DataImport.FileType.GPX:
                    result = DI.ImportGpx(chkGpxElev.Checked, radGpxElevFeet.Checked);
                    break;
                case DataImport.FileType.Shape:
                    if (chkShpMulti.Checked)
                        result = DI.ImportShapes(_ShapeFileList.Select(fp => fp.Path).ToList(),
                            false, true, chkShpElev.Checked, radShpElevFeet.Checked);
                    else
                        result = DI.ImportShape(false, true, chkShpElev.Checked, radShpElevFeet.Checked);
                    break;
                case DataImport.FileType.TwoTrails:
                    result = DI.ImportTt(chkLstTtPolys.CheckedItems.Cast<string>().ToList(), chkTtNmea.Checked);
                    break;
#endif
                case DataImport.FileType.TwoTrails2:
                #if (PocketPC || WindowsCE || Mobile)
                    result = DI.ImportTt2(_Tt2PolyList.Select(d => d.Path).ToList(), chkTt2Groups.Checked, chkTt2Nmea.Checked);
                #else
                    result = DI.ImportTt2(chkLstTt2Polys.CheckedItems.Cast<DataPair>().Select(d => d.Path).ToList(),
                        chkTt2Groups.Checked, chkTt2Nmea.Checked);
                #endif
                    break;
                case DataImport.FileType.NotImplementedType:
                    break;
            }

            if (result)
                _adjust = true;

            return result;
        }


        private void btnOpen_Click2(object sender, EventArgs e)
        {
            if (ofD.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofD.FileName;
                txtFile.SelectionStart = txtFile.Text.Length;
                txtFile.ScrollToCaret();

                _FileType = DI.SetFileType(ofD.FileName);
                GoToFileTypePage();
                btnImport.Enabled = true;

                switch(_FileType)
                {
                    case DataImport.FileType.TwoTrails2:
                        {
                            if (DI.SetupTt2Import())
                            {
                            #if (PocketPC || WindowsCE || Mobile)
                                _Tt2PolyList = DI.GetTt2Polygons();
                            #else
                                chkLstTt2Polys.Items.Clear();
                                foreach (DataPair p in DI.GetTt2Polygons())
                                    chkLstTt2Polys.Items.Add(p);
                            #endif
                            }
                            else
                                btnImport.Enabled = false;
                        }
                        break;
                    #if !(PocketPC || WindowsCE || Mobile)
                    case DataImport.FileType.Shape:
                        {
                            if (!DI.CheckShapeUsability(ofD.FileName))
                            {
                                txtFile.Text = String.Empty;
                                _FileType = DataImport.FileType.NotImplementedType;
                                btnImport.Enabled = false;
                            }
                        }
                        break;
                    case DataImport.FileType.TwoTrails:
                        {
                            if (DI.SetupTtImport())
                            {
                                chkLstTtPolys.Items.Clear();
                                foreach (string p in DI.GetTtPolygons())
                                    chkLstTtPolys.Items.Add(p);
                            }
                            else
                                btnImport.Enabled = false;
                        }
                        break;
#endif
                }
            }
        }

        private void btnCancel_Click2(object sender, EventArgs e)
        {
            if (Values.AdjustingPolygons)
            {
                Values.GlobalCancelToken = true;
            }
            else
                this.Close();
        }

        private void btnHelp_Click2(object sender, EventArgs e)
        {

        }

        private void btnImport_Click2(object sender, EventArgs e)
        {
            if (_FileType != DataImport.FileType.NotImplementedType)
            {
                MessageBox.Show(Import() ? "Data Imported." : "Data Failed to Import. Check log file for details.");
            }
        }

        private void tabControl_SelectedIndexChanged2(object sender, EventArgs e)
        {
#if (PocketPC || WindowsCE || Mobile)

#else
            if (tabControl.SelectedIndex != 1)
            {
                btnOpen.Enabled = true;
            }
            else
            {
                if (chkShpMulti.Checked)
                    btnOpen.Enabled = false;
                else
                    btnOpen.Enabled = true;
            }
#endif
        }


        #region SubControls
        private void chkTxtElev_CheckedChanged2(object sender, EventArgs e)
        {
            radTxtElevFeet.Enabled = chkTxtElev.Checked;
            radTxtElevMeters.Enabled = chkTxtElev.Checked;
        }

#if !(PocketPC || WindowsCE || Mobile)
        private void chkShpMulti_CheckedChanged2(object sender, EventArgs e)
        {
            btnShpAdd.Enabled = chkShpMulti.Checked;
            btnShpRemove.Enabled = chkShpMulti.Checked;
            btnShpClear.Enabled = chkShpMulti.Checked;
            lstShpFiles.Enabled = chkShpMulti.Checked;
            btnOpen.Enabled = !chkShpMulti.Checked;
        }

        private void btnShpClear_Click2(object sender, EventArgs e)
        {
            _ShapeFileList.Clear();
            btnImport.Enabled = false;
        }

        private void btnShpRemove_Click2(object sender, EventArgs e)
        {
            if (_ShapeFileList.Count > 0)
            {
                _ShapeFileList.RemoveAt(lstShpFiles.SelectedIndex);
            }

            if (lstShpFiles.Items.Count < 1)
                btnImport.Enabled = false;
        }

        private void btnShpAdd_Click2(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Shape Files|*.shp";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fn in ofd.FileNames)
                    {
                        if (DI.CheckShapeUsability(fn))
                        {
                            _ShapeFileList.Add(new DataPair(System.IO.Path.GetFileName(fn), fn));
                            btnImport.Enabled = true;
                            _FileType = DataImport.FileType.Shape;
                        }
                    }
                }
            }
        }

        private void chkShpElev_CheckedChanged2(object sender, EventArgs e)
        {
            radShpElevFeet.Enabled = chkShpElev.Checked;
            radShpElevMeters.Enabled = chkShpElev.Checked;
        }

        private void chkGpxElev_CheckedChanged2(object sender, EventArgs e)
        {
            radGpxElevFeet.Enabled = chkGpxElev.Checked;
            radGpxElevMeters.Enabled = chkGpxElev.Checked;
        }
#endif

        #endregion
    }
}