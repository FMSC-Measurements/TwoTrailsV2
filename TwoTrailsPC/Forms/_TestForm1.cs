using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.BusinessLogic;
using TwoTrails.DataAccess;
using TwoTrails.Engine;
using TwoTrails.Utilities;
using TwoTrails.Controls;

namespace TwoTrails.Forms
{
    public partial class _TestForm1 : Form
    {
        DataAccessLayer dal;

        public _TestForm1(DataAccessLayer d)
        {
            InitializeComponent();

            dal = d;
        }

        private void _TestForm_Load(object sender, EventArgs e)
        {
            
        
        }
    }
}
