using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;

namespace TwoTrails.Forms
{
    public partial class TwoTrailsInfoForm : Form
    {
        public TwoTrailsInfoForm()
        {
            InitializeComponent();

            lblTtVersion.Text = Values.TwoTrailsVersion;
            lblBuildDate.Text = Values.TwoTrailsBuildDate;
            lblDbVersion.Text = DataAccess.TwoTrailsSchema.SchemaVersion.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}