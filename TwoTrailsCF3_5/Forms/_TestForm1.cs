using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Utilities;
using TwoTrails.BusinessObjects;
using TwoTrails.Controls;
using TwoTrails.DataAccess;
using System.Media;
using TwoTrails.Engine;
using TwoTrails.LaserAccess;

namespace TwoTrails.Forms
{
    public partial class _TestForm1 : Form
    {
        public _TestForm1(DataAccessLayer d)
        {
            InitializeComponent();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void _TestForm1_Load(object sender, EventArgs e)
        {
            if (!Values.LaserA.IsBusy)
            {
                Values.LaserA.OpenLaser("COM3", 4800);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



    }
}