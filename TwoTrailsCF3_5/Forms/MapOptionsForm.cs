using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.Engine;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class MapOptionsForm : Form
    {
        public MapOptionsForm(DataAccessLayer d)
        {
            if(Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();

            dal = d;

            MapOptionsForm_Load();

            if (MapValues.mapMyPos)
            {
                chkFollowPos.Enabled = true;
            }
            else
            {
                chkFollowPos.Enabled = false;
            }
        }

        #region DisplayOptions
        private void btnDrawMap_Click(object sender, EventArgs e)
        {
            btnDrawMap_Click2(sender, e);
        }

        private void btnBackground_Click(object sender, EventArgs e)
        {
            //btnBackground_Click2(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit_Click2(sender, e);
        }

        private void chkPoints_CheckStateChanged(object sender, EventArgs e)
        {
            chkPoints_CheckStateChanged2(sender, e);
        }

        private void chkLines_CheckStateChanged(object sender, EventArgs e)
        {
            chkLines_CheckStateChanged2(sender, e);
        }

        private void chkLegend_CheckStateChanged(object sender, EventArgs e)
        {
            chkLegend_CheckStateChanged2(sender, e);
        }

        private void txtSkip_TextChanged(object sender, EventArgs e)
        {
            txtSkip_TextChanged2(sender, e);
        }

        private void chkAxis_CheckStateChanged(object sender, EventArgs e)
        {
            chkAxis_CheckStateChanged2(sender, e);
        }

        private void txtSkip_LostFocus(object sender, EventArgs e)
        {
            txtSkip_TextChanged(sender, e);
            Kb.Hide(this);
        }

        private void txtSkip_GotFocus(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtSkip);
        }
        #endregion

        #region DisplayElements

        #region AdjustedElements

        private void chkAdjNav_CheckStateChanged(object sender, EventArgs e)
        {
            chkAdjNav_CheckStateChanged2(sender, e);
        }

        private void chkAdjBound_CheckStateChanged(object sender, EventArgs e)
        {
            chkAdjBound_CheckStateChanged2(sender, e);
        }

        private void chkAdjMisc_CheckStateChanged(object sender, EventArgs e)
        {
            chkAdjMisc_CheckStateChanged2(sender, e);
        }
        #endregion 

        #region UnadjustedElements
        private void chkUnadjNav_CheckStateChanged(object sender, EventArgs e)
        {
            chkUnadjNav_CheckStateChanged2(sender, e);
        }

        private void chkUnadjBound_CheckStateChanged(object sender, EventArgs e)
        {
            chkUnadjBound_CheckStateChanged2(sender, e);
        }

        private void chkUnadjMisc_CheckStateChanged(object sender, EventArgs e)
        {
            chkUnadjMisc_CheckStateChanged2(sender, e);
        }

        private void chkUnadjWaypoints_CheckStateChanged(object sender, EventArgs e)
        {
            chkUnadjWaypoints_CheckStateChanged2(sender, e);
        }

        private void chkUnadjMyGPS_CheckStateChanged(object sender, EventArgs e)
        {
            chkUnadjMyGPS_CheckStateChanged2(sender, e);
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

        private void lstPolygons_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPolygons_SelectedIndexChanged2(sender, e);
        }



        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void chkCloseBnd_CheckStateChanged(object sender, EventArgs e)
        {
            chkCloseBnd_CheckedChanged2(sender, e);
        }

        private void cboLabels_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLabels_SelectedIndexChanged2(sender, e);
        }

        private void cboT5_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboT5_SelectedIndexChanged2(sender, e);
        }
    }
}