using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;

namespace TwoTrails.Forms
{
    public partial class Take5Form : Form
    {
        public Take5Form(TtPolygon poly, DataAccessLayer dal, TtMetaData meta, TtPoint lastPoint, int cIndex)
        {
            InitializeComponent();

            Init(poly, dal, meta, lastPoint, cIndex);
        }

        private void txtPID_TextChanged(object sender, EventArgs e)
        {
            txtPID_TextChanged2(sender, e);
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            txtComment_TextChanged2(sender, e);
        }

        private void btnBound_Click(object sender, EventArgs e)
        {
            btnBound_Click2(sender, e);
        }

        private void chkLocked_CheckedChanged(object sender, EventArgs e)
        {
            chkLocked_CheckStateChanged2(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            btnCapture_Click2(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk_Click2(sender, e);
        }

        private void Take5Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm();
        }

        private void btnSideshot_Click(object sender, EventArgs e)
        {
            btnSideshot_Click2(sender, e);
        }
    }
}
