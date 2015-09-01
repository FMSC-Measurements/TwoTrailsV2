using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;


namespace TwoTrails.Forms
{
    public partial class LinkedPointForm : Form
    {
        private TtPoint _SelectedPoint;
        private List<TtPoint> _Points;

        private void Init()
        {
            this.Icon = Properties.Resources.Map;

            _SelectedPoint = null;
            this.DialogResult = DialogResult.Cancel;

            lstPoints.Columns.Add("Point", -2, HorizontalAlignment.Left);
            lstPoints.Columns.Add("Operation", -2, HorizontalAlignment.Left);
            lstPoints.Columns.Add("Polygon", -2, HorizontalAlignment.Center);

            foreach (TtPoint point in _Points)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = point.PID.ToString();
                lvi.SubItems.Add(point.op.ToString());
                lvi.SubItems.Add(point.PolyName);
                lstPoints.Items.Add(lvi);
            }
        }


        #region Controls
        private void lstPoints_SelectedIndexChanged2(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = lstPoints.SelectedIndices;

            if (lstPoints.SelectedIndices.Count > 0)
            {
                _SelectedPoint = _Points[lstPoints.SelectedIndices[0]];
            }
            else
            {
                _SelectedPoint = null;
            }
        }

        private void btnCancel_Click2(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelect_Click2(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        public TtPoint SelectedPoint
        {
            get { return _SelectedPoint; }
        }
    }
}