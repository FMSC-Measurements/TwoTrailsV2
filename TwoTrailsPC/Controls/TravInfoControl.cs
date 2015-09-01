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
    public partial class TravInfoControl : UserControl
    {
        public TravInfoControl()
        {
            InitializeComponent();
            Init();
        }

        private void textBoxFAz_TextChanged(object sender, EventArgs e)
        {
            textBoxFAz_TextChanged2(sender, e);
        }

        private void textBoxBAz_TextChanged(object sender, EventArgs e)
        {
            textBoxBAz_TextChanged2(sender, e);
        }

        private void textBoxSlpDist_TextChanged(object sender, EventArgs e)
        {
            textBoxSlpDist_TextChanged2(sender, e);
        }

        private void textBoxSlpAng_TextChanged(object sender, EventArgs e)
        {
            textBoxSlpAng_TextChanged2(sender, e);
        }

        void textBoxSlpDist_GotFocus(object sender, System.EventArgs e)
        {
            textBoxSlpDist_GotFocus2(sender, e);
        }

        void textBoxSlpAng_GotFocus(object sender, System.EventArgs e)
        {
            textBoxSlpAng_GotFocus2(sender, e);
        }

        void textBoxBAz_GotFocus(object sender, System.EventArgs e)
        {
            textBoxBAz_GotFocus2(sender, e);
        }

        void textBoxFAz_GotFocus(object sender, System.EventArgs e)
        {
            textBoxFAz_GotFocus2(sender, e);
        }
    }
}
