using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Forms
{
    public partial class Take5Form : Form
    {
        public Take5Form(TtPolygon poly, DataAccessLayer dal, TtMetaData meta, TtPoint currentPoint, int currIndex, bool isInsert)
        {
            if (Engine.Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();

            Init(poly, dal, meta, currentPoint, currIndex, isInsert);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk_Click2(sender, e);
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            btnCapture_Click2(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void Take5Form_Closing(object sender, CancelEventArgs e)
        {
            CloseForm();

        }

        private void btnBound_Click(object sender, EventArgs e)
        {
            btnBound_Click2(sender, e);
        }

        private void chkLocked_CheckStateChanged(object sender, EventArgs e)
        {
            chkLocked_CheckStateChanged2(sender, e);
        }

        private void txtPID_TextChanged(object sender, EventArgs e)
        {
            txtPID_TextChanged2(sender,e);
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            txtComment_TextChanged2(sender, e);
        }

        private void btnSideshot_Click(object sender, EventArgs e)
        {
            btnSideshot_Click2(sender, e);
        }

        private void travInfoControl1_BAzTextChanged()
        {
            travInfoControl1_BAzTextChanged2();
        }

        private void travInfoControl1_FAzTextChanged()
        {
            travInfoControl1_FAzTextChanged2();
        }

        private void travInfoControl1_SlopeAngleTextChanged()
        {
            travInfoControl1_SlopeAngleTextChanged2();
        }

        private void travInfoControl1_SlopeDistTextChanged()
        {
            travInfoControl1_SlopeDistTextChanged2();
        }

        private void travInfoControl1_GotFocused()
        {
            travInfoControl1_GotFocused2();
        }

        private void txtPID_GotFocus(object sender, EventArgs e)
        {
            txtPID_GotFocus2(sender, e);
        }

        private void txtComment_GotFocus(object sender, EventArgs e)
        {
            txtComment_GotFocus2(sender, e);
        }

        private void txtPID_LostFocus(object sender, EventArgs e)
        {
            txtPID_LostFocus2(sender, e);
        }

        private void txtComment_LostFocus(object sender, EventArgs e)
        {
            txtComment_LostFocus2(sender, e);
        }
    }
}