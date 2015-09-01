using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class EditPointTableForm : Form
    {
        public EditPointTableForm(DataAccessLayer d)
        {
            DAL = d;
            InitializeComponent();
            Init();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click2(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave_Click2(sender, e);
        }

        private void EditPointTableForm_Closing(object sender, CancelEventArgs e)
        {
            if(this.DialogResult == DialogResult.OK)
                Save();
        }

        private void EditPointTableForm_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void EditPointTableForm_Click(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }
    }
}