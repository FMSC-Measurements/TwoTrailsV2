using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Controls
{
    public partial class WalkInfoCtrl : UserControl
    {
        public WalkInfoCtrl()
        {
            InitializeComponent();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            btnHide_Click2(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd_Click2(sender, e);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            btnDel_Click2(sender, e);
        }

        private void btnSetManAcc_Click(object sender, EventArgs e)
        {
            btnSetManAcc_Click2(sender, e);
        }
    }
}
