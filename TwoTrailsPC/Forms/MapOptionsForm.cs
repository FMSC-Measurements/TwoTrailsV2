using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.Engine;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class MapOptionsForm : Form
    {
        public MapOptionsForm(DataAccess.DataAccessLayer d)
        {
            InitializeComponent();

            dal = d;

            if (MapValues.mapMyPos)
            {
                chkFollowPos.Enabled = true;
            }
            else
            {
                chkFollowPos.Enabled = false;
            }
        }

        private void MapOptionsForm_Load(object sender, EventArgs e)
        {
            MapOptionsForm_Load();
        }

        private void chkPoints_CheckedChanged(object sender, EventArgs e)
        {
            chkPoints_CheckStateChanged2(sender, e);
        }

        private void chkLines_CheckedChanged(object sender, EventArgs e)
        {
            chkLines_CheckStateChanged2(sender, e);
        }

        //private void chkLabels_CheckedChanged(object sender, EventArgs e)
        //{
        //    chkLabels_CheckStateChanged2(sender, e);
        //}

        private void chkLegend_CheckedChanged(object sender, EventArgs e)
        {
            chkLegend_CheckStateChanged2(sender, e);
        }

        private void btnBackground_Click(object sender, EventArgs e)
        {
            btnBackground_Click2(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDrawMap_Click(object sender, EventArgs e)
        {
            btnDrawMap_Click2(sender, e);
        }

        private void chkAdjBound_CheckedChanged(object sender, EventArgs e)
        {
            chkAdjBound_CheckStateChanged2(sender, e);
        }

        private void chkAdjNav_CheckedChanged(object sender, EventArgs e)
        {
            chkAdjNav_CheckStateChanged2(sender, e);
        }

        private void chkAdjMisc_CheckedChanged(object sender, EventArgs e)
        {
            chkAdjMisc_CheckStateChanged2(sender, e);
        }

        private void chkUnadjBound_CheckedChanged(object sender, EventArgs e)
        {
            chkUnadjBound_CheckStateChanged2(sender, e);
        }

        private void chkUnadjNav_CheckedChanged(object sender, EventArgs e)
        {
            chkUnadjNav_CheckStateChanged2(sender, e);
        }

        private void chkUnadjMisc_CheckedChanged(object sender, EventArgs e)
        {
            chkUnadjMisc_CheckStateChanged2(sender, e);
        }

        private void chkUnadjWaypoints_CheckedChanged(object sender, EventArgs e)
        {
            chkUnadjWaypoints_CheckStateChanged2(sender, e);
        }

        private void chkUnadjMyGPS_CheckedChanged(object sender, EventArgs e)
        {
            chkUnadjMyGPS_CheckStateChanged2(sender, e);
        }

        private void chkFollowPos_CheckedChanged(object sender, EventArgs e)
        {
            chkFollowPos_CheckStateChanged2(sender, e);
        }

        private void chkDetails_CheckedChanged(object sender, EventArgs e)
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

        private void chkUseMap_CheckedChanged(object sender, EventArgs e)
        {
            chkUseMap_CheckedChanged2(sender, e);
        }

        private void txtSkip_TextChanged(object sender, EventArgs e)
        {
            txtSkip_TextChanged2(sender, e);
        }

        private void lstPolygons_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPolygons_SelectedIndexChanged2(sender, e);
        }

        private void chkCloseBnd_CheckedChanged(object sender, EventArgs e)
        {
            chkCloseBnd_CheckedChanged2(sender, e);
        }

        private void cboLabels_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLabels_SelectedIndexChanged2(sender, e);
        }
    }
}
