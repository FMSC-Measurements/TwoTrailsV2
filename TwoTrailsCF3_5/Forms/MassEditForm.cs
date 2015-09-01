using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class MassEditForm : Form
    {
        public MassEditForm(DataAccessLayer dal)
        {
            if (Engine.Values.WideScreen)
            {
                InitializeComponentWide();
                btnConvert.MakeMultiline();
                btnSwitchPoly.MakeMultiline();
            }
            else
                InitializeComponent();

            Init(dal);

        }

        #region Controls
        private void cboPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPoly_SelectedIndexChanged2(sender, e);
        }

        private void btnPolygon_Click(object sender, EventArgs e)
        {
            btnPolygon_Click2(sender, e);
        }

        private void btnSwitchPoly_Click(object sender, EventArgs e)
        {
            btnSwitchPoly_Click2(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave_Click2(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit_Click2(sender, e);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            btnConvert_Click2(sender, e);
        }

        private void chkAll_CheckStateChanged(object sender, EventArgs e)
        {
            chkAll_CheckStateChanged2(sender, e);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            btnDel_Click2(sender, e);
        }

        private void btnBnd_Click(object sender, EventArgs e)
        {
            btnBnd_Click2(sender, e);
        }
        #endregion

    }
}