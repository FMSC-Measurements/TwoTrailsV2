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
    public partial class QuondamInfoControl : UserControl
    {
        public QuondamInfoControl()
        {
            InitializeComponent();
            Init();
        }

        private void btnRetrace_Click(object sender, EventArgs e)
        {
            btnRetrace_Click2(sender, e);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            btnConvert_Click2(sender, e);
        }
    }
}
