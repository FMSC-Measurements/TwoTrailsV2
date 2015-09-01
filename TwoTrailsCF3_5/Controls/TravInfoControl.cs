using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Controls
{
    public partial class TravInfoControl : UserControl
    {
        
        public TravInfoControl()
        {
            if(Engine.Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();
            Init();
        }

        #region Controls
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

        #region Focus
        private void textBoxFAz_GotFocus(object sender, EventArgs e)
        {
            textBoxFAz_GotFocus2(sender, e);
        }

        private void textBoxBAz_GotFocus(object sender, EventArgs e)
        {
            textBoxBAz_GotFocus2(sender, e);
        }

        private void textBoxSlpDist_GotFocus(object sender, EventArgs e)
        {
            textBoxSlpDist_GotFocus2(sender, e);
        }

        private void textBoxSlpAng_GotFocus(object sender, EventArgs e)
        {
            textBoxSlpAng_GotFocus2(sender, e);
        }

        private void textBoxFAz_LostFocus(object sender, EventArgs e)
        {
            textBoxFAz_LostFocus2(sender, e);
        }

        private void textBoxBAz_LostFocus(object sender, EventArgs e)
        {
            textBoxBAz_LostFocus2(sender, e);
        }

        private void textBoxSlpDist_LostFocus(object sender, EventArgs e)
        {
            textBoxSlpDist_LostFocus2(sender, e);
        }

        private void textBoxSlpAng_LostFocus(object sender, EventArgs e)
        {
            textBoxSlpAng_LostFocus2(sender, e);
        }

        private void TravInfoControl_Click(object sender, EventArgs e)
        {
            TravInfoControl_Click2(sender, e);
        }
        #endregion


        #endregion
    }
}
