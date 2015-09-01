﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Forms
{
    public partial class QuondamRetraceForm : Form
    {
        public QuondamRetraceForm(TwoTrails.DataAccess.DataAccessLayer dal, int pointIndex, int polyIndex)
        {
            InitializeComponent();

            DAL = dal;

            Init(pointIndex, polyIndex);
        }

        private void lstPoint1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPoint1_SelectedIndexChanged2(sender, e);
        }

        private void lstPoint2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPoint2_SelectedIndexChanged2(sender, e);
        }

        private void cboPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPoly_SelectedIndexChanged2(sender, e);
        }

        private void radUp_CheckedChanged(object sender, EventArgs e)
        {
            radUp_CheckedChanged2(sender, e);
        }

        private void radDown_CheckedChanged(object sender, EventArgs e)
        {
            radDown_CheckedChanged2(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void btnRetrace_Click(object sender, EventArgs e)
        {
            btnRetrace_Click2(sender, e);
        }
    }
}
