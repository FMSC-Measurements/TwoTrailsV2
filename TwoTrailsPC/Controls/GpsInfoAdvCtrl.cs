using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;
using TwoTrails.GpsAccess;

namespace TwoTrails.Controls
{
    public partial class GpsInfoAdvCtrl : UserControl
    {
        public GpsInfoAdvCtrl()
        {
            InitializeComponent();
            Init();
        }
    }
}
