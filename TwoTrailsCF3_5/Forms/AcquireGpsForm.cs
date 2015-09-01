using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Forms
{
    public partial class AcquireGpsForm : Form
    {
        public AcquireGpsForm(TtPoint p, int currentZone, DataAccessLayer dal)
        {
            if(Engine.Values.WideScreen)
                InitializeComponentWide();
            else
                InitializeComponent();

            Init(p, currentZone, dal);
        }

        private void AcquireGpsForm_Closing(object sender, CancelEventArgs e)
        {
            CloseForm();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk_Click2(sender, e);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            btnLog_Click2(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void AcquireGpsForm_Load(object sender, EventArgs e)
        {
            AcquireGpsForm_Load2(sender, e);
        }

    }
}