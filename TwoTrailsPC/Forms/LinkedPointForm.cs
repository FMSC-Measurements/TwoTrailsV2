using System;
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
    public partial class LinkedPointForm : Form
    {
        public LinkedPointForm(List<TtPoint> points)
        {
            InitializeComponent();
            _Points = points;
            Init();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            btnSelect_Click2(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void lstPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPoints_SelectedIndexChanged2(sender, e);
        }
    }
}
