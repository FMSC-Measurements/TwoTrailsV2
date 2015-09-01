using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;

namespace TwoTrails.Forms
{
    public partial class AcquireGpsForm : Form
    {
        public AcquireGpsForm(TtPoint p, int currentZone, DataAccessLayer dal)
        {
            InitializeComponent();

            Init(p, currentZone, dal);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            btnLog_Click2(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk_Click2(sender, e);
        }

        private void AcquireGpsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm();
        }

        private void AcquireGpsForm_Load(object sender, EventArgs e)
        {
            AcquireGpsForm_Load2(sender, e);
        }
    }
}
