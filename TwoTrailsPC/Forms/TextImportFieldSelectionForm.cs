using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Forms
{
    public partial class TextImportFieldSelectionForm : Form
    {
        public int iPID = -1, iX = -1, iY = -1, iZ = -1,
            iComment = -1, iPoly = -1, iBound = -1, iIndex = -1;
        public bool bFeet, bLatLon;


        public TextImportFieldSelectionForm(
            int gPID, int gX, int gY, int gZ,
            int gComment, int gPoly, int gBound, int gIndex, string[] origColumns)
        {
            InitializeComponent();

            string[] columns = new string[origColumns.Length + 1];
            columns[0] = "No Identifier";
            origColumns.CopyTo(columns, 1);

            cboPID.Items.AddRange(columns);
            if (gPID > -1)
                cboPID.SelectedIndex = gPID;
            else
                cboPID.SelectedIndex = 0;
                

            cboX.Items.AddRange(columns);
            if (gX > -1)
                cboX.SelectedIndex = gX;
            else
                cboX.SelectedIndex = 0;


            cboY.Items.AddRange(columns);
            if (gY > -1)
                cboY.SelectedIndex = gY;
            else
                cboY.SelectedIndex = 0;


            cboZ.Items.AddRange(columns);

            if (gZ > -1)
                cboZ.SelectedIndex = gZ;
            else
                cboZ.SelectedIndex = 0;


            cboCmt.Items.AddRange(columns);

            if (gComment > -1)
                cboCmt.SelectedIndex = gComment;
            else
                cboCmt.Enabled = false;


            cboPoly.Items.AddRange(columns);

            if (gPoly > -1)
                cboPoly.SelectedIndex = gPoly;
            else
                cboPoly.SelectedIndex = 0;


            cboOnBnd.Items.AddRange(columns);

            if (gBound > -1)
                cboOnBnd.SelectedIndex = gBound;
            else
                cboOnBnd.SelectedIndex = 0;


            cboIndex.Items.AddRange(columns);

            if (gIndex > -1)
                cboIndex.SelectedIndex = gIndex;
            else
                cboIndex.SelectedIndex = 0;
        }

        private void TextImportFieldSelectionForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (!CheckDupFields())
            {
                iPID = cboPID.SelectedIndex - 1;
                iX = cboX.SelectedIndex - 1;
                iY = cboY.SelectedIndex - 1;
                iZ = cboZ.SelectedIndex - 1;
                iComment = cboCmt.SelectedIndex - 1;
                iPoly = cboPoly.SelectedIndex - 1;
                iBound = cboOnBnd.SelectedIndex - 1;
                iIndex = cboIndex.SelectedIndex - 1;
                bFeet = radFeet.Checked;
                bLatLon = radLatLon.Checked;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Some fields have the same collumn selected. There can not be any duplicate fields.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public bool CheckDupFields()
        {
            return false;
        }
    }
}
