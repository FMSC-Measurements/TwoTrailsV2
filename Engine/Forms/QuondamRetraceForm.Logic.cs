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
using TwoTrails.Utilities;
using TwoTrails.Engine;

namespace TwoTrails.Forms
{
    public partial class QuondamRetraceForm : Form
    {
        DataAccessLayer DAL;

        private List<TtPolygon> _Polygons;
        private List<List<TtPoint>> _Points;

        private List<TtPoint> _NewPoints, _FinalPoints;

        public List<TtPoint> FinalPoints { get { return _FinalPoints; } }

        private int _CurrPointToIndex, _CurrPointFromIndex, _CurrPolyIndex;

        public void Init(int pointIndex, int polyIndex)
        {
            this.Icon = Properties.Resources.Map;
            this.DialogResult = DialogResult.Cancel;

            _Polygons = DAL.GetPolygons();
            _Points = new List<List<TtPoint>>();

            try
            {
                foreach (TtPolygon poly in _Polygons)
                {
                    cboPoly.Items.Add(poly.Name);

                    _Points.Add(DAL.GetPointsInPolygon(poly));
                }
                LoadListboxes();

                _CurrPolyIndex = polyIndex;
                _CurrPointFromIndex = pointIndex;


                cboPoly.SelectedIndex = _CurrPolyIndex;
                lstPoint1.SelectedIndex = _CurrPointFromIndex;
                _NewPoints = new List<TtPoint>();
                _FinalPoints = new List<TtPoint>();
#if (PocketPC || WindowsCE || Mobile)
                btnPoly.Text = _Polygons[_CurrPolyIndex].Name;


                if (Values.Settings.DeviceOptions.UseSelection)
                {
                    cboPoly.Visible = false;
                    btnPoly.Visible = true;
                }
                else
                {
                    cboPoly.Visible = true;
                    btnPoly.Visible = false;
                }
#endif

            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "QuondamRetraceForm:Init", ex.StackTrace);
            }

        }

        private void LoadListboxes()
        {
            lstPoint1.Items.Clear();
            lstPoint2.Items.Clear();

            for (int i = 0; i < _Points[_CurrPolyIndex].Count; i++)
            {
                lstPoint1.Items.Add(_Points[_CurrPolyIndex][i].PID);
                lstPoint2.Items.Add(_Points[_CurrPolyIndex][i].PID);
            }
        }


        private void ReTrace()
        {
            TtPolygon _Poly = _Polygons[_CurrPolyIndex];
            bool dirUp = radUp.Checked;
            int index = _CurrPointFromIndex;

            if (_CurrPointToIndex < 0)
                return;

            _NewPoints.Clear();

            while (index != _CurrPointToIndex)
            {
                AddPoint(index);

                if (dirUp)
                {
                    index--;

                    if (index < 0)
                        index = _Points[_CurrPolyIndex].Count - 1;
                }
                else
                {
                    index++;

                    if (index == _Points[_CurrPolyIndex].Count)
                        index = 0;
                }
            }

            if (_CurrPointFromIndex != index)
            {
                AddPoint(index);
            }

            _FinalPoints.AddRange(_NewPoints);
        }

        private void AddPoint(int index)
        {
            _NewPoints.Add(_Points[_CurrPolyIndex][index]);
        }


        #region Controls
        private void lstPoint1_SelectedIndexChanged2(object sender, EventArgs e)
        {
            _CurrPointFromIndex = lstPoint1.SelectedIndex;


            if (lstPoint1.SelectedIndex > 0)
            {
                radUp.Text = String.Format("{0} to {1}",
                    _Points[_CurrPolyIndex][_CurrPointFromIndex].PID,
                    _Points[_CurrPolyIndex][_CurrPointFromIndex - 1].PID);
            }
            else
            {
                radUp.Text = String.Format("{0} to {1}",
                    _Points[_CurrPolyIndex][_CurrPointFromIndex].PID,
                    _Points[_CurrPolyIndex][_Points[_CurrPolyIndex].Count - 1].PID);
            }

            if (lstPoint1.SelectedIndex < _Points[_CurrPolyIndex].Count - 2)
            {
                radDown.Text = String.Format("{0} to {1}",
                    _Points[_CurrPolyIndex][_CurrPointFromIndex].PID,
                    _Points[_CurrPolyIndex][_CurrPointFromIndex + 1].PID);
            }
            else
            {
                radDown.Text = String.Format("{0} to {1}",
                    _Points[_CurrPolyIndex][_CurrPointFromIndex].PID,
                    _Points[_CurrPolyIndex][0].PID);
            }
        }

        private void lstPoint2_SelectedIndexChanged2(object sender, EventArgs e)
        {
            _CurrPointToIndex = lstPoint2.SelectedIndex;
        }

        private void cboPoly_SelectedIndexChanged2(object sender, EventArgs e)
        {
            _CurrPolyIndex = cboPoly.SelectedIndex;
#if (PocketPC || WindowsCE || Mobile)
            btnPoly.Text = _Polygons[_CurrPolyIndex].Name;
#endif

            LoadListboxes();
        }
#if (PocketPC || WindowsCE || Mobile)
        private void btnPoly_Click2(object sender, EventArgs e)
        {
            List<string> items = new List<string>();

            foreach (TtPolygon poly in _Polygons)
            {
                items.Add(poly.Name);
            }

            using (Selection form = new Selection("Polygons", items, cboPoly.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cboPoly.SelectedIndex = form.selection;
                    btnPoly.Text = _Polygons[form.selection].Name;
                }
            }
        }
#endif
        private void btnCancel_Click2(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnRetrace_Click2(object sender, EventArgs e)
        {
            ReTrace();

            DialogResult dr = MessageBox.Show("Commit " + _FinalPoints.Count + " Quondams to Polygon?", "Commit Quondams", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (dr == DialogResult.No)
            {
                if (MessageBox.Show("Are you sure you want to exit without commiting the points?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    this.Close();
            }
            else if (dr == DialogResult.Cancel)
            {
                _FinalPoints.Clear();
            }
        }

        private void radUp_CheckedChanged2(object sender, EventArgs e)
        {
            btnRetrace.Enabled = true;
        }

        private void radDown_CheckedChanged2(object sender, EventArgs e)
        {
            btnRetrace.Enabled = true;
        }
        #endregion
    }
}