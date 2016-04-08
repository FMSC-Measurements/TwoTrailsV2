using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;
using TwoTrails.Engine;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class GroupEditForm : Form
    {
        public class GroupEdit
        {  
            public TtGroup Group;
            public bool Edited;

            public string GroupName
            {
                get { return Group.Name; }
            }

            /*
            public int PointCount
            {
                get { return Group.NumberOfPoints; }
            }
            */

            public string Description
            {
                get { return Group.Description; }
            }

            public string GroupType
            {
                get { return Group.GroupType.ToString(); }
            }

            public GroupEdit(TtGroup g)
            {
                Group = g;
                Edited = false;
            }
        }

        private bool _locked = false;
        public bool Locked
        {
            get { return _locked; }
            set
            {
                _locked = value;
                txtGroupName.Enabled = !_locked;
                btnDelete.Enabled = !_locked;
                txtDesc.Enabled = !_locked;
                cboType.Enabled = !_locked;
            }
        }

        BindingList<GroupEdit> _DisplayGroups;
        DataAccessLayer dal;
        BindingSource bs;

        public GroupEditForm(DataAccessLayer d)
        {
            InitializeComponent();
            dal = d;
        }

        private void GroupEditForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;
            Locked = true;

            _DisplayGroups = new BindingList<GroupEdit>(dal.GetGroups()
                .Where(g => g.CN != Values.MainGroup.CN)
                .Select(g => new GroupEdit(g)).ToList());

            bs = new BindingSource();
            bs.DataSource = _DisplayGroups;

            dgvGroups.RowHeadersVisible = false;
            dgvGroups.AutoGenerateColumns = true;
            dgvGroups.DataSource = bs;

            dgvGroups.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            cboType.DataSource = new List<GroupType>((GroupType[])Enum.GetValues(typeof(GroupType)));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GroupEdit group in _DisplayGroups)
                {
                    if (group.Edited)
                    {
                        List<TtPoint> points = new List<TtPoint>();

                        foreach (TtPoint point in dal.GetPointsInGroup(group.Group.CN))
                        {
                            point.GroupCN = group.Group.CN;
                            point.GroupName = group.Group.Name;

                            points.Add(point);
                        }

                        dal.SavePoints(points);
                        dal.UpdateGroup(group.Group);
                    }
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "GroudEditForm:Save", ex.StackTrace);
            }

            this.Close();
        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            int index = dgvGroups.SelectedRows[0].Index;

            if (!txtGroupName.Text.Equals(_DisplayGroups[index].Group.Name))
            {
                _DisplayGroups[index].Group.Name = txtGroupName.Text;
                _DisplayGroups[index].Edited = true;
                dgvGroups.Refresh();
            }
        }
        
        private void dgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count > 0)
            {
                int index = dgvGroups.SelectedRows[0].Index;
                GroupEdit Current = _DisplayGroups[index];
                txtGroupName.Text = Current.Group.Name;
                txtDesc.Text = Current.Group.Description;
                cboType.SelectedItem = Current.Group.GroupType;
                _DisplayGroups[index] = Current;
                Locked = false;
            }
            else
                Locked = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dgvGroups.SelectedRows[0].Index;
            GroupEdit Current = _DisplayGroups[index];

            if (Current.Group.CN == Values.MainGroup.CN)
            {
                MessageBox.Show("You can not delete the main group");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this group?",
                    "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Hand,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (dal.GetPointCountFromGroup(Current.Group.CN) > 0 && MessageBox.Show("Would you like to delete all the points in this group?",
                        "", MessageBoxButtons.YesNo, MessageBoxIcon.Hand,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        dal.DeletePointsInGroup(Current.Group.CN);
                        dal.DeleteGroup(Current.Group.CN);
                    }
                    else
                    {
                        dal.DeleteGroup(Current.Group.CN);
                    }
                    _DisplayGroups.RemoveAt(index);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TtGroup g = new TtGroup("group");
            dal.InsertGroup(g);
            _DisplayGroups.Insert(0, new GroupEdit(g));
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count > 0)
            {
                int index = dgvGroups.SelectedRows[0].Index;
                GroupEdit Current = _DisplayGroups[index];

                if (Current.Group != null && cboType.SelectedItem != null)
                {
                    GroupType t = (GroupType)cboType.SelectedItem;

                    if (t != Current.Group.GroupType)
                    {
                        _DisplayGroups[index].Group.GroupType = t;
                        _DisplayGroups[index].Edited = true;
                        dgvGroups.Refresh();
                    }
                }
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            int index = dgvGroups.SelectedRows[0].Index;

            if (!txtDesc.Text.Equals(_DisplayGroups[index].Group.Description))
            {
                _DisplayGroups[index].Group.Description = txtDesc.Text;
                _DisplayGroups[index].Edited = true;
                dgvGroups.Refresh();
            }
        }
    }
}
