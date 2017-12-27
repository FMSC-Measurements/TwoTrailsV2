using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class MapOptionsForm : Form
    {
        private MapForm mForm;
        private DataAccessLayer dal;
        private List<string> allPolyCNs;

        public void MapOptionsForm_Load()
        {
            this.Icon = Properties.Resources.Map;

            TtUtils.ShowWaitCursor();

            mForm = new MapForm();

            MapValues.setup();
            initValues();

            loadListbox(dal);

            TtUtils.HideWaitCursor();
        }

        private void initValues()
        {
            chkAdjBound.Checked = MapValues.mapAdjBound;
            chkAdjMisc.Checked = MapValues.mapAdjMisc;
            chkAdjNav.Checked = MapValues.mapAdjNav;
            //chkGrid.Checked = MapValues.mapGrid;
            //chkLabels.Checked = MapValues.mapLabels;
            txtSkip.Enabled = MapValues.mapPolyLabels != Values.EmptyGuid;

#if DEBUG
            chkLegend.Checked = false;
            MapValues.mapLegend = false;
#else
            chkLegend.Checked = MapValues.mapLegend;
#endif
            chkPoints.Checked = MapValues.mapPoints;
            chkUnadjBound.Checked = MapValues.mapUnadjBound;
            chkUnadjMisc.Checked = MapValues.mapUnadjMisc;
            chkUnadjMyGPS.Checked = MapValues.mapMyPos;
            chkUnadjNav.Checked = MapValues.mapUnadjNav;
            chkUnadjWaypoints.Checked = MapValues.mapUnadjWaypoints;
            chkFollowPos.Checked = MapValues.mapFollowPos;
            chkDetails.Checked = MapValues.mapDetails;

            //txtBackground.Text = MapValues.mapBackground;
            //if (!MapValues.mapBackground.IsEmpty())
            //{
            //    chkUseMap.Enabled = true;
            //    chkUseMap.Checked = MapValues.mapHasBackground;
            //}

            if (MapValues.mapDetailsUTM)
            {
                radLatLon.Checked = false;
                radUTM.Checked = true;
            }
            else
            {
                radLatLon.Checked = true;
                radUTM.Checked = false;
            }

            chkCloseBnd.Checked = MapValues.closeBounds;
        }


        private void loadListbox(DataAccessLayer d)
        {
            dal = d;

            int w = lstPolygons.Width;

            lstPolygons.Columns.Add("Polygons", w / 4, HorizontalAlignment.Left);
            lstPolygons.Columns.Add("Points", w / 5,HorizontalAlignment.Left);
            lstPolygons.Columns.Add("Area (Ac)", -1, HorizontalAlignment.Left);

            /*
            lstPolygons.Columns.Add("Polygons", 100, HorizontalAlignment.Left);
            lstPolygons.Columns.Add("Points",50,HorizontalAlignment.Left);
            lstPolygons.Columns.Add("Area (Ac)", 70, HorizontalAlignment.Left);
            */

            cboLabels.Items.Add("None");
            cboLabels.Items.Add("All");

            cboT5.Items.Add("No Poly");

            if(dal != null)
            {
                List<TtPolygon> polys = dal.GetPolygons();
                allPolyCNs = new List<string>();

                TtPolygon poly;

                for (int i = 0; i < polys.Count; i++)
                {
                    poly = polys[i];

                    ListViewItem l = new ListViewItem(poly.Name);
                    l.SubItems.Add(dal.GetPointCount(poly.CN).ToString());
                    //l.SubItems.Add((polys[i].Area / 1000).ToString());
                    l.SubItems.Add(TtUtils.ConvertMeters2ToAcres(poly.Area).ToString());
                    allPolyCNs.Add(poly.CN);

                    if (i % 2 == 1)
                        l.BackColor = Color.LightGray;

                    lstPolygons.Items.Add(l);
                    cboLabels.Items.Add(poly.Name);
                    cboT5.Items.Add(poly.Name);

                    if (MapValues.mapPolyLabels == poly.CN)
                        cboLabels.SelectedIndex = i + 2;
                }

                if (MapValues.mapPolyLabels == Values.EmptyGuid)
                    cboLabels.SelectedIndex = 0;

                if (MapValues.mapPolyT5 == Values.EmptyGuid)
                    cboT5.SelectedIndex = 0;

                if (MapValues.mapPolyLabels == Values.FullGuid)
                    cboLabels.SelectedIndex = 1;

                lstPolygons.CheckBoxes = true;
            }

#if !(PocketPC || WindowsCE || Mobile)
            lstPolygons.Columns[0].Width = -2;
            lstPolygons.Columns[1].Width = -2;
            lstPolygons.Columns[2].Width = -2;
#endif

        }

        private void btnDrawMap_Click2(object sender, EventArgs e)
        {
            List<string> polys = new List<string>();

            for (int i = 0; i < lstPolygons.Items.Count; i++)
            {
                if (lstPolygons.Items[i].Checked)
                {
                    polys.Add(allPolyCNs[i]);
                }
            }

            if (polys.Count > 0)
            {
                mForm.loadMapData(polys, dal);
                mForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Polygons Selected.");
            }

            initValues();
        }

        private void btnExit_Click2(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }

        #region DisplayOptions

        bool _ignoreChange = false;
        public void lstPolygons_SelectedIndexChanged2(object sender, EventArgs e)
        {
            if (!_ignoreChange && lstPolygons.SelectedIndices.Count > 0)
            {
                int index = lstPolygons.SelectedIndices[0];

                _ignoreChange = true;
                lstPolygons.Items[index].Checked = !lstPolygons.Items[index].Checked;
                _ignoreChange = false;
            }
        }

        //public void btnBackground_Click2(object sender, EventArgs e)
        //{
        //    using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
        //    {
        //        ofd.Filter = "Image Files|*.jpg;*.bmp;*.png";

        //        if (ofd.ShowDialog() == DialogResult.OK)
        //        {
        //            string file = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
        //            string worldFile = String.Format("{0}{1}", file, ".jgw");

        //            worldFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(ofd.FileName), worldFile);

        //            if (System.IO.File.Exists(worldFile))
        //            {
        //                txtBackground.Text = ofd.FileName;
        //                txtBackground.SelectionStart = ofd.FileName.Length;
        //                chkUseMap.Checked = true;
        //                chkUseMap.Enabled = true;

        //                MapValues.mapHasBackground = true;
        //                MapValues.mapBackground = ofd.FileName;
        //                MapValues.mapBackgroundCoordsFile = worldFile;
        //            }
        //            else
        //            {
        //                MessageBox.Show("World Projection File (.jgw) must be in same folder as the image file.");

        //                MapValues.mapHasBackground = false;
        //                MapValues.mapBackground = String.Empty;
        //                MapValues.mapBackgroundCoordsFile = String.Empty;
        //            }
        //        }
        //    }
        //}

        //private void chkUseMap_CheckedChanged2(object sender, EventArgs e)
        //{
        //    MapValues.mapHasBackground = chkUseMap.Checked;
        //}

        public void chkPoints_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapPoints = chkPoints.Checked;
        }

        public void chkLines_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapLines = chkLines.Checked;
        }

        //public void chkLabels_CheckStateChanged2(object sender, EventArgs e)
        //{
        //    MapValues.mapLabels = chkLabels.Checked;
        //    txtSkip.Enabled = MapValues.mapLabels;
        //}

        private void cboLabels_SelectedIndexChanged2(object sender, EventArgs e)
        {
            txtSkip.Enabled = cboLabels.SelectedIndex == 0;

            if (cboLabels.SelectedIndex == 0)
                MapValues.mapPolyLabels = Values.EmptyGuid;
            else if (cboLabels.SelectedIndex == 1)
                MapValues.mapPolyLabels = Values.FullGuid;
            else if (cboLabels.SelectedIndex > 1)
                MapValues.mapPolyLabels = allPolyCNs[cboLabels.SelectedIndex - 2];
        }

        private void cboT5_SelectedIndexChanged2(object sender, EventArgs e)
        {
            if (cboT5.SelectedIndex == 0)
                MapValues.mapPolyT5 = Values.EmptyGuid;
            else if (cboLabels.SelectedIndex > 0)
                MapValues.mapPolyT5 = allPolyCNs[cboT5.SelectedIndex - 1];
        }

        public void chkGrid_CheckStateChanged2(object sender, EventArgs e)
        {
            //MapValues.mapGrid = chkGrid.Checked;
        }

        public void chkLegend_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapLegend = chkLegend.Checked;
        }

        public void txtSkip_TextChanged2(object sender, EventArgs e)
        {
            int skip = 0;

            try
            {
                if (txtSkip.Text.Length > 0)
                {
                    skip = Convert.ToInt32(txtSkip.Text);

                    MapValues.mapSkip = skip;
                }
                else
                {
                    skip = 0;
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MapOptionsFormLogic:txtSkip");
            }
        }

        public void chkAxis_CheckStateChanged2(object sender, EventArgs e)
        {
            //MapValues.mapAxis = chkAxis.Checked;
        }

        private void chkCloseBnd_CheckedChanged2(object sender, EventArgs e)
        {
            MapValues.closeBounds = chkCloseBnd.Checked;
        }
        #endregion

        #region DisplayElements

        #region AdjustedElements

        public void chkAdjNav_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapAdjNav = chkAdjNav.Checked;
        }

        public void chkAdjBound_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapAdjBound = chkAdjBound.Checked;
        }

        public void chkAdjMisc_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapAdjMisc = chkAdjMisc.Checked;
        }
        #endregion

        #region UnadjustedElements
        public void chkUnadjNav_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapUnadjNav = chkUnadjNav.Checked;
        }

        public void chkUnadjBound_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapUnadjBound = chkUnadjBound.Checked;
        }

        public void chkUnadjMisc_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapUnadjMisc = chkUnadjMisc.Checked;
        }

        public void chkUnadjWaypoints_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapUnadjWaypoints = chkUnadjWaypoints.Checked;
        }

        public void chkUnadjMyGPS_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapMyPos = chkUnadjMyGPS.Checked;

            if (MapValues.mapMyPos)
            {
                chkFollowPos.Enabled = true;
                chkDetails.Enabled = true;
                //radLatLon.Enabled = true;
                //radUTM.Enabled = true;
            }
            else
            {
                chkFollowPos.Enabled = false;
                chkDetails.Enabled = false;
                radLatLon.Enabled = false;
                radUTM.Enabled = false;
            }
        }

        public void chkFollowPos_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapFollowPos = chkFollowPos.Checked;
        }

        public void chkDetails_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapDetails = chkDetails.Checked;

            if (MapValues.mapDetails)
            {
                radLatLon.Enabled = true;
                radUTM.Enabled = true;
            }
            else
            {
                radLatLon.Enabled = false;
                radUTM.Enabled = false;
            }
        }

        public void radLatLon_CheckedChanged2(object sender, EventArgs e)
        {
            if (radLatLon.Checked)
                MapValues.mapDetailsUTM = false;
        }

        public void radUTM_CheckedChanged2(object sender, EventArgs e)
        {
            if (radUTM.Checked)
                MapValues.mapDetailsUTM = true;
        }

        #endregion
        #endregion
    }
}
