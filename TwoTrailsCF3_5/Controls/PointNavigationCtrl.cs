using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Controls
{
    public partial class PointNavigationCtrl : UserControl
    {
        public PointNavigationCtrl()
        {
            if(Engine.Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();

            Init();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            btnFirst_Click2(sender, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack_Click2(sender, e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext_Click2(sender, e);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            btnLast_Click2(sender, e);
        }

        private void btnLblPos_Click(object sender, EventArgs e)
        {
            btnLblPos_Click2(sender, e);
        }
    }
}
