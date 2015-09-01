using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class MassEditNewGroup : Form
    {
        public TtGroup Group;

        public MassEditNewGroup()
        {
            InitializeComponent();
        }

        private void MassEditNewGroup_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;

            cboType.DataSource = new List<GroupType>((GroupType[])Enum.GetValues(typeof(GroupType)));
            cboType.SelectedItem = GroupType.General;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtName.Text.IsEmpty())
            {
                MessageBox.Show("The Group Must have a Name.");
                txtName.Focus();
            }
            else
            {
                if (cboType.SelectedItem != null && cboType.SelectedItem.GetType() == typeof(GroupType))
                {
                    Group = new TtGroup();
                    Group.Name = txtName.Text.Trim();
                    Group.Description = txtDesc.Text;
                    Group.GroupType = (GroupType)cboType.SelectedItem;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You Must Select a Group Type.");
                    cboType.Focus();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
