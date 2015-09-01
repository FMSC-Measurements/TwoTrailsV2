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
    public partial class MassEditNewPoly : Form
    {
        public TtPolygon Poly;

        public MassEditNewPoly(string name, int startIndex)
        {
            InitializeComponent();

            Poly = new TtPolygon();
            Poly.Name = name;
            Poly.PointStartIndex = startIndex;
        }

        private void MassEditNewPoly_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;

            txtName.Text = Poly.Name;
            txtStartIndex.Text = Poly.PointStartIndex.ToString();
            txtPointInc.Text = "10";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtStartIndex.Text.IsInteger() && txtStartIndex.Text.ToInteger() > 0)
            {
                Poly.PointStartIndex = txtStartIndex.Text.ToInteger();

                if (txtPointInc.Text.IsInteger() && txtPointInc.Text.ToInteger() > 0)
                {
                    Poly.IncrementBy = txtPointInc.Text.ToInteger();

                    if (!txtName.Text.IsEmpty())
                    {
                        Poly.Name = txtName.Text.Trim();
                        Poly.Description = txtDesc.Text.Trim();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The Polygon must have a name.");
                        txtPointInc.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Point Increment must be numeric and greater than 0.");
                    txtPointInc.Focus();
                }
            }
            else
            {
                MessageBox.Show("Start Index must be numeric and greater than 0.");
                txtStartIndex.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}
