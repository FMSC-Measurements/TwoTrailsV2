using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;
using TwoTrails.BusinessLogic;


namespace TwoTrails.Forms
{
    public partial class PolygonTransformationForm : Form
    {
        DataAccessLayer dal;
        BindingList<TtPolygon> AdjPolys, RefPolys;
        List<TtPolygon> _Polys;
        List<TtPoint> _AdjPoints, _RefPoints;
        List<GpsPoint> _TransformedPoints;
        BindingList<TtPoint> AdjPoints1, AdjPoints2, RefPoints1, RefPoints2;
        private delegate void TransformDelegate();

        bool _transforming = false;
        bool MultiPolys = false;

        public PolygonTransformationForm(DataAccessLayer d)
        {
            InitializeComponent();
            dal = d;
        }

        private void PolygonTransformationForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;
            
            _Polys = dal.GetPolygons();

            if (_Polys.Count < 1)
            {
                MessageBox.Show("Polygon Transformation requires at least 1 Polygon.");
                this.Close();
                return;
            }

            AdjPolys = new BindingList<TtPolygon>(_Polys);

            cboTransAdjPoly.DataSource = AdjPolys;
            cboRotAdjPoly.DataSource = AdjPolys;
            cboSclAdjPoly.DataSource = AdjPolys;

            if (_Polys.Count > 1)
            {
                MultiPolys = true;
                RefPolys = new BindingList<TtPolygon>(_Polys);

                cboTransRefPoly.DataSource = RefPolys;
                cboRotRefPoly.DataSource = RefPolys;
                cboSclRefPoly.DataSource = RefPolys;

                cboTransAdjPoly.SelectedIndex = 1;

                _RefPoints = dal.GetPointsInPolygon(_Polys[0].CN);
                _AdjPoints = dal.GetPointsInPolygon(_Polys[1].CN);

                RefPoints1 = new BindingList<TtPoint>(_RefPoints);
                RefPoints2 = new BindingList<TtPoint>(_RefPoints);

                cboTransRefPoint.DataSource = RefPoints1;

                cboRotRefPoint1.DataSource = RefPoints1;
                cboRotRefPoint2.DataSource = RefPoints2;

                cboSclRefPoint1.DataSource = RefPoints1;
                cboSclRefPoint2.DataSource = RefPoints2;

                if(_RefPoints.Count > 0)
                    cboRotRefPoint2.SelectedIndex = _RefPoints.Count - 1;
            }
            else
            {
                cboTransAdjPoly.SelectedIndex = 0;

                _AdjPoints = dal.GetPointsInPolygon(_Polys[0].CN);

                chkRotate.Checked = true;
                chkTranslate.Checked = true;
                chkScale.Checked = true;

                radTransManual.Checked = true;
                radRotAngle.Checked = true;
                radRotAdj.Checked = true;
                radSclManual.Checked = true;

                chkRotate.Checked = false;
                chkTranslate.Checked = false;
                chkScale.Checked = false;
            }

            AdjPoints1 = new BindingList<TtPoint>(_AdjPoints);
            AdjPoints2 = new BindingList<TtPoint>(_AdjPoints);
                
            cboTransAdjPoint.DataSource = AdjPoints1;

            cboRotAdjPoint1.DataSource = AdjPoints1;
            cboRotAdjPoint2.DataSource = AdjPoints2;

            cboSclAdjPoint1.DataSource = AdjPoints1;
            cboSclAdjPoint2.DataSource = AdjPoints2;

            if(AdjPoints2.Count > 0)
                cboRotAdjPoint2.SelectedIndex = AdjPoints2.Count - 1;

            cboSclType.SelectedIndex = 0;

            radsRowToOpt = new Dictionary<int, Dictionary<TransOpt, RadioButton>>();
            radsRowToOpt.Add(0, new Dictionary<TransOpt, RadioButton>());
            radsRowToOpt.Add(1, new Dictionary<TransOpt, RadioButton>());
            radsRowToOpt.Add(2, new Dictionary<TransOpt, RadioButton>());

            radsRowToOpt[0].Add(TransOpt.Rotate, radOptRot1);
            radsRowToOpt[1].Add(TransOpt.Rotate, radOptRot2);
            radsRowToOpt[2].Add(TransOpt.Rotate, radOptRot3);

            radsRowToOpt[0].Add(TransOpt.Scale, radOptScale1);
            radsRowToOpt[1].Add(TransOpt.Scale, radOptScale2);
            radsRowToOpt[2].Add(TransOpt.Scale, radOptScale3);

            radsRowToOpt[0].Add(TransOpt.Translate, radOptTrans1);
            radsRowToOpt[1].Add(TransOpt.Translate, radOptTrans2);
            radsRowToOpt[2].Add(TransOpt.Translate, radOptTrans3);


            rowToOpts = new TransOpt[] { to1, to2, to3 };
            optsToRow = new Dictionary<TransOpt, int>();
            optsToRow.Add(to1, 0);
            optsToRow.Add(to2, 1);
            optsToRow.Add(to3, 2);
        }


        private void btnTransform_Click(object sender, EventArgs e)
        {
            if (_transforming)
            {
                MessageBox.Show("Polygons are currently being transformed. Try again in a moment.");
                return;
            }

            if (TwoTrails.Engine.Values.AdjustingPolygons)
            {
                MessageBox.Show("Polygons are currently being saved. Try again in a moment.");
                return;
            }

            if (!CheckControls())
                return;

            /*
            foreach (TtPoint p in _AdjPoints)
            {
                if (!p.IsGpsType())
                {
                    if (MessageBox.Show("The Adjusting Polygon has non GPS type points in it. You will need to make a copy of the polygon in order to transform it. Do you want to Copy and Transform now?",
                        "", MessageBoxButtons.UnAdjYesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        makeCopy = true;
                    }
                    else 
                        return;
                    break;
                }
            }
            */

            TtPolygon newPoly = new TtPolygon();
            TtPolygon transPoly = cboTransAdjPoly.SelectedItem as TtPolygon;

            string polyName = String.Format("{0} (Transformed)", transPoly.Name);

            bool renaming = true;
            int inc = 2;
            while (renaming)
            {
                renaming = false;
                foreach (TtPolygon poly in dal.GetPolygons())
                {
                    if (poly.Name.Equals(polyName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        polyName = String.Format("{0} (Transformed {1})", transPoly.Name, inc);
                        inc++;
                        renaming = true;
                        break;
                    }
                }
            }

            newPoly.Name = polyName;
            newPoly.PointStartIndex = (int)(dal.GetPolyCount() + 1010);

            _TransformedPoints = new List<GpsPoint>();
            int index = 0;
            GpsPoint tmpPoint;

            foreach (GpsPoint p in _AdjPoints)
            {
                if (p.IsGpsType())
                {
                    tmpPoint = TtUtils.ClonePoint(p) as GpsPoint;
                    tmpPoint.Index = index;
                    tmpPoint.PolyCN = newPoly.CN;
                    tmpPoint.PolyName = newPoly.Name;
                    index++;
                    _TransformedPoints.Add(tmpPoint);
                }
            }
            

            TransformDelegate del = new TransformDelegate(DoTransform);
            del.BeginInvoke(null, null);

            dal.InsertPolygon(newPoly);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            PolygonAdjuster.Adjust(dal, true, this);

            this.Close();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            using (MapOptionsForm mapopts = new MapOptionsForm(dal))
            {
                mapopts.ShowDialog();
            }
        }


        private bool CheckControls()
        {
            if (cboRotAdjPoly.SelectedIndex == cboRotRefPoly.SelectedIndex)
            {
                MessageBox.Show("The Reference Polygon must be different than the adjusted polygon.");
                return false;
            }

            if (MultiPolys && cboRotRefPoint1.SelectedIndex == cboRotRefPoint2.SelectedIndex)
            {
                MessageBox.Show("Reference Point 1 must be different than Reference Point 2.");
                return false;
            }

            if (cboRotAdjPoint1.SelectedIndex == cboRotAdjPoint2.SelectedIndex)
            {
                MessageBox.Show("Adjusted Point 1 must be different than Adjusted Point 2.");
                return false;
            }

            if (chkTranslate.Checked)
            {
                if (!radTransPoints.Checked)
                {
                    if (!txtTransX.Text.IsEmpty() && !txtTransX.Text.IsDouble())
                    {
                        MessageBox.Show("Translate X must be numeric.");
                        txtTransX.Focus();
                        return false;
                    }

                    if (!txtTransY.Text.IsEmpty() && !txtTransY.Text.IsDouble())
                    {
                        MessageBox.Show("Translate Y must be numeric.");
                        txtTransY.Focus();
                        return false;
                    }
                }
            }

            if (chkRotate.Checked)
            {
                if (radRotAngle.Checked && !txtRotAngle.Text.IsEmpty() && !txtRotAngle.Text.IsDouble())
                {
                    MessageBox.Show("Rotation angle be numeric.");
                    txtSclWidth.Focus();
                    return false;
                }
            }

            if (chkScale.Checked)
            {
                if (!radSclPoints.Checked)
                {
                    if (!txtSclWidth.Text.IsEmpty() && !txtSclWidth.Text.IsDouble())
                    {
                        MessageBox.Show("Scale width must be numeric.");
                        txtSclWidth.Focus();
                        return false;
                    }

                    if (!txtSclHeight.Text.IsEmpty() && !txtSclHeight.Text.IsDouble())
                    {
                        MessageBox.Show("Scale height must be numeric.");
                        txtSclHeight.Focus();
                        return false;
                    }
                }
            }

            return true;
        }


        private void DoTransform()
        {
            this.GuiInvoke(() =>
                {

                    if (Transform())
                    {
                        dal.InsertPoints(_TransformedPoints);
                        PolygonAdjuster.Adjust(dal, null);
                        MessageBox.Show("Polygon Transformed.");
                    }
                });
        }

        private bool Transform()
        {
            bool save = true;
            _transforming = true;

            try
            {
                switch (to1)
                {
                    case TransOpt.Scale:
                        if (chkScale.Checked)
                            Scale();
                        break;
                    case TransOpt.Rotate:
                        if (chkRotate.Checked)
                            save &= Rotate();
                        break;
                    case TransOpt.Translate:
                        if (chkTranslate.Checked)
                            Translate();
                        break;
                }

                switch (to2)
                {
                    case TransOpt.Scale:
                        if (chkScale.Checked)
                            Scale();
                        break;
                    case TransOpt.Rotate:
                        if (chkRotate.Checked)
                            save &= Rotate();
                        break;
                    case TransOpt.Translate:
                        if (chkTranslate.Checked)
                            Translate();
                        break;
                }

                switch (to3)
                {
                    case TransOpt.Scale:
                        if (chkScale.Checked)
                            Scale();
                        break;
                    case TransOpt.Rotate:
                        if (chkRotate.Checked)
                            save &= Rotate();
                        break;
                    case TransOpt.Translate:
                        if (chkTranslate.Checked)
                            Translate();
                        break;
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "PolygonTransformationForm:Transform");
                _transforming = false;
                return false;
            }

            _transforming = false;
            return save;
        }

        private void Translate()
        {
            if (cboTransAdjPoint.SelectedIndex > -1 && (cboTransRefPoint.SelectedIndex > -1 || MultiPolys))
            {
                double adjX = 0, adjY = 0;

                if (radTransPoints.Checked)
                {
                    GpsPoint refp = cboTransRefPoint.SelectedItem as GpsPoint;
                    GpsPoint transp = _TransformedPoints[cboSclAdjPoint1.SelectedIndex] as GpsPoint;

                    adjX = refp.UnAdjX - transp.UnAdjX;
                    adjY = refp.UnAdjY - transp.UnAdjY;
                }
                else
                {
                    if (!txtTransX.Text.IsEmpty())
                        adjX = txtTransX.Text.ToDouble();

                    if(!txtTransY.Text.IsEmpty())
                        adjY = txtTransY.Text.ToDouble();

                    if (radTransFeet.Checked)
                    {
                        adjX = TtUtils.ConvertToMeters(adjX, Unit.FEET_TENTH);
                        adjY = TtUtils.ConvertToMeters(adjY, Unit.FEET_TENTH);
                    }
                }

                for (int i = 0; i < _TransformedPoints.Count; i++)
                {
                    _TransformedPoints[i].UnAdjX += adjX;
                    _TransformedPoints[i].UnAdjY += adjY;
                }
            }
            else
                throw new Exception("Invalid Translate Point Selection");
        }

        private bool Rotate()
        {
            GpsPoint centerPoint, tempPoint;
            DoublePoint dpCenter = new DoublePoint(), tempDP;
            bool doRotate = true;
            double angle = 0;

            TtPoint ref1 = new TtPoint();
            TtPoint ref2 = new TtPoint();
            TtPoint adj1 = new TtPoint();
            TtPoint adj2 = new TtPoint();

            if (MultiPolys)
            {
                ref1 = cboRotRefPoint1.SelectedItem as TtPoint;
                ref2 = cboRotRefPoint2.SelectedItem as TtPoint;
            }

            adj1 = cboRotAdjPoint1.SelectedItem as TtPoint;
            adj2 = cboRotAdjPoint2.SelectedItem as TtPoint;

            if (radRotPoint.Checked)
            {
                if (TtUtils.LineIntersectsLineInfinite(ref1, ref2, adj1, adj2) || TtUtils.LineIntersectsLineInfinite(adj1, adj2, ref1, ref2))
                {
                    dpCenter = new DoublePoint(adj1.UnAdjX, adj1.UnAdjY);
                }
                else
                {
                    MessageBox.Show("Polygon can not rotate on vertex. The lines are parallel.");
                    return false;
                }
            }
            else
            {
                if (radRotRef.Checked)
                {
                    centerPoint = cboRotRefPoint1.SelectedItem as GpsPoint;
                    dpCenter = new DoublePoint(centerPoint.UnAdjX, centerPoint.UnAdjY);
                }
                else
                {
                    centerPoint = cboRotAdjPoint1.SelectedItem as GpsPoint;
                    dpCenter = new DoublePoint(centerPoint.UnAdjX, centerPoint.UnAdjY);
                }
            }

            if (doRotate)
            {
                if (radRotPoint.Checked)
                {
                    //get clockwire rotation angle
                    angle = -TtUtils.AzimuthDiff(ref1, ref2, adj1, adj2);

                    if (double.IsNaN(angle) || double.IsInfinity(angle))
                        doRotate = false;
                }
                else
                {
                    angle = TtUtils.DegreesToRadian((txtRotAngle.Text.ToDouble() * -1) - 360);
                }

                if (doRotate)
                {
                    for (int i = 0; i < _TransformedPoints.Count; i++)
                    {
                        tempPoint = _TransformedPoints[i];
                        tempDP = TtUtils.RotatePoint(tempPoint.UnAdjX, tempPoint.UnAdjY, angle, dpCenter.X, dpCenter.Y);
                        tempPoint.UnAdjX = tempDP.X;
                        tempPoint.UnAdjY = tempDP.Y;
                        _TransformedPoints[i] = tempPoint;
                    }
                }
            }

            return true;
        }

        private void Scale()
        {
            double top, bottom, left, right;

            TtUtils.GetFarthestPoints(_TransformedPoints.ToDoublePoints(), out top, out bottom, out left, out right);

            DoublePoint adjCenter = new DoublePoint((left + right) / 2, (top + bottom) / 2);

            double scaleDist, scaleDistX = 1, scaleDistY = 1;

            if (radSclPoints.Checked)
            {
                GpsPoint refp1 = cboSclRefPoint1.SelectedItem as GpsPoint;
                GpsPoint refp2 = cboSclRefPoint2.SelectedItem as GpsPoint;

                GpsPoint adjp1 = _TransformedPoints[cboSclAdjPoint1.SelectedIndex] as GpsPoint;
                GpsPoint adjp2 = _TransformedPoints[cboSclAdjPoint2.SelectedIndex] as GpsPoint;

                double refdist = TtUtils.Distance(refp1, refp2, false);
                double adjdist = TtUtils.Distance(adjp1, adjp2, false);

                scaleDist = refdist / adjdist;
                
                if (double.IsInfinity(scaleDist))
                    throw new Exception("Infinity scale error");

                adjCenter = new DoublePoint(adjp1.UnAdjX, adjp1.UnAdjY);

                scaleDistX = scaleDistY = scaleDist;
            }
            else
            {
                if (cboSclType.SelectedIndex == 0)      //%
                {
                    scaleDistX = txtSclWidth.Text.ToDouble() / 100;
                    scaleDistY = txtSclHeight.Text.ToDouble() / 100;
                }
                else if (cboSclType.SelectedIndex == 1) //Ft
                {
                    if(!txtSclWidth.Text.IsEmpty())
                        scaleDistX = (right - left) / TtUtils.ConvertToMeters(txtSclWidth.Text.ToDouble(), Unit.FEET_TENTH);
                    
                    if(!txtSclHeight.Text.IsEmpty())
                        scaleDistY = (top - bottom) / TtUtils.ConvertToMeters(txtSclHeight.Text.ToDouble(), Unit.FEET_TENTH);
                }
                else if (cboSclType.SelectedIndex == 2) //M
                {
                    if (!txtSclWidth.Text.IsEmpty())
                        scaleDistX = (right - left) / txtSclWidth.Text.ToDouble();

                    if (!txtSclHeight.Text.IsEmpty())
                        scaleDistY = (top - bottom) / txtSclHeight.Text.ToDouble();
                }
            }

            for (int i = 0; i < _TransformedPoints.Count; i++)
            {
                GpsPoint p = _TransformedPoints[i];

                DoublePoint dp = new DoublePoint(p.UnAdjX, p.UnAdjY);

                double dist = TtUtils.Distance(dp, adjCenter);

                if (dist <= 0)
                    continue;

                double theta = Math.Asin((dp.Y - adjCenter.Y) / dist);

                p.UnAdjX = adjCenter.X + ((dist * scaleDistX) * Math.Cos(theta));
                p.UnAdjY = adjCenter.Y + ((dist * scaleDistY) * Math.Sin(theta));
            }
        }


        void updateLists()
        {
            if (_AdjPoints != null)
            {
                TtPolygon adjPoly = cboTransAdjPoly.SelectedItem as TtPolygon;

                if (adjPoly.CN != _AdjPoints[0].PolyCN)
                {
                    _AdjPoints = dal.GetPointsInPolygon(adjPoly.CN);

                    AdjPoints1 = new BindingList<TtPoint>(_AdjPoints);
                    AdjPoints2 = new BindingList<TtPoint>(_AdjPoints);

                    cboTransAdjPoint.DataSource = AdjPoints1;

                    cboRotAdjPoint1.DataSource = AdjPoints1;
                    cboRotAdjPoint2.DataSource = AdjPoints2;

                    cboSclAdjPoint1.DataSource = AdjPoints1;
                    cboSclAdjPoint2.DataSource = AdjPoints2;

                }

                TtPolygon refPoly = cboTransRefPoly.SelectedItem as TtPolygon;

                if (refPoly.CN != _RefPoints[0].PolyCN)
                {
                    _RefPoints = dal.GetPointsInPolygon(refPoly.CN);

                    RefPoints1 = new BindingList<TtPoint>(_RefPoints);
                    RefPoints2 = new BindingList<TtPoint>(_RefPoints);

                    cboTransRefPoint.DataSource = RefPoints1;

                    cboRotRefPoint1.DataSource = RefPoints1;
                    cboRotRefPoint2.DataSource = RefPoints2;

                    cboSclRefPoint1.DataSource = RefPoints1;
                    cboSclRefPoint2.DataSource = RefPoints2;
                } 
            }
        }




        #region Controls

        private void EnableTransform()
        {
            if (chkRotate.Checked || chkTranslate.Checked || chkScale.Checked)
                btnTransform.Enabled = true;
            else
                btnTransform.Enabled = false;
        }

        private void chkTranslate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTranslate.Checked)
            {
                if (!MultiPolys)
                {
                    radTransManual.Enabled = true;

                    cboTransAdjPoint.Enabled = true;
                    cboTransAdjPoly.Enabled = true;
                    cboTransRefPoint.Enabled = false;
                    cboTransRefPoly.Enabled = false;
                    txtTransX.Enabled = true;
                    txtTransY.Enabled = true;
                    pnlTransUnit.Enabled = true;
                }
                else
                {
                    radTransPoints.Enabled = true;
                    radTransManual.Enabled = true;

                    if (radTransPoints.Checked)
                    {
                        cboTransAdjPoint.Enabled = true;
                        cboTransAdjPoly.Enabled = true;
                        cboTransRefPoint.Enabled = true;
                        cboTransRefPoly.Enabled = true;
                        txtTransX.Enabled = false;
                        txtTransY.Enabled = false;
                        pnlTransUnit.Enabled = false;
                    }
                    else
                    {
                        cboTransAdjPoint.Enabled = true;
                        cboTransAdjPoly.Enabled = true;
                        cboTransRefPoint.Enabled = false;
                        cboTransRefPoly.Enabled = false;
                        txtTransX.Enabled = true;
                        txtTransY.Enabled = true;
                        pnlTransUnit.Enabled = true;
                    }
                }
            }
            else
            {
                radTransPoints.Enabled = false;
                radTransManual.Enabled = false;
                cboTransAdjPoint.Enabled = false;
                cboTransAdjPoly.Enabled = false;
                cboTransRefPoint.Enabled = false;
                cboTransRefPoly.Enabled = false;
                txtTransX.Enabled = false;
                txtTransY.Enabled = false;
                pnlTransUnit.Enabled = false;
            }

            EnableTransform();
        }

        private void chkRotate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRotate.Checked)
            {
                if (!MultiPolys)
                {
                    radRotAngle.Enabled = true;
                    radRotAdj.Enabled = true;
                    cboRotAdjPoint1.Enabled = true;
                    cboRotAdjPoly.Enabled = true;
                    txtRotAngle.Enabled = true;
                }
                else
                {
                    radRotPoint.Enabled = true;
                    radRotAngle.Enabled = true;

                    if (radRotPoint.Checked)
                    {
                        cboRotAdjPoint1.Enabled = true;
                        cboRotAdjPoint2.Enabled = true;
                        cboRotAdjPoly.Enabled = true;

                        cboRotRefPoint1.Enabled = true;
                        cboRotRefPoint2.Enabled = true;
                        cboRotRefPoly.Enabled = true;

                        txtRotAngle.Enabled = false;
                        radRotAdj.Enabled = false;
                        radRotRef.Enabled = false;
                    }
                    else
                    {
                        /*
                        radRotAdj.Enabled = true;
                        radRotRef.Enabled = true;

                        cboRotRefPoly.Enabled = true;
                        cboRotRefPoint1.Enabled = true;
                        cboRotAdjPoly.Enabled = true;
                        txtRotAngle.Enabled = true;
                        */

                        txtRotAngle.Enabled = true;
                        radRotAdj.Enabled = true;
                        radRotRef.Enabled = true;

                        if (radRotAdj.Checked)
                        {
                            cboRotAdjPoint1.Enabled = true;
                            cboRotAdjPoint2.Enabled = false;
                            cboRotAdjPoly.Enabled = true;

                            cboRotRefPoint1.Enabled = false;
                            cboRotRefPoint2.Enabled = false;
                            cboRotRefPoly.Enabled = true;
                        }
                        else
                        {
                            cboRotAdjPoint1.Enabled = false;
                            cboRotAdjPoint2.Enabled = false;
                            cboRotAdjPoly.Enabled = false;

                            cboRotRefPoint1.Enabled = true;
                            cboRotRefPoint2.Enabled = false;
                            cboRotRefPoly.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                radRotPoint.Enabled = false;
                radRotAngle.Enabled = false;

                cboRotAdjPoint1.Enabled = false;
                cboRotAdjPoint2.Enabled = false;
                cboRotAdjPoly.Enabled = false;
                cboRotRefPoint1.Enabled = false;
                cboRotRefPoint2.Enabled = false;
                cboRotRefPoly.Enabled = false;
                txtRotAngle.Enabled = false;

                radRotAdj.Enabled = false;
                radRotRef.Enabled = false;
            }

            EnableTransform();
        }

        private void chkScale_CheckedChanged(object sender, EventArgs e)
        {
            if (chkScale.Checked)
            {
                if (!MultiPolys)
                {
                    radSclManual.Enabled = true;
                    cboSclAdjPoly.Enabled = true;
                    txtSclHeight.Enabled = true;
                    txtSclWidth.Enabled = true;
                    cboSclType.Enabled = true;
                }
                else
                {
                    radSclPoints.Enabled = true;
                    radSclManual.Enabled = true;

                    if (radSclPoints.Checked)
                    {
                        cboSclAdjPoint1.Enabled = true;
                        cboSclAdjPoint2.Enabled = true;
                        cboSclAdjPoly.Enabled = true;
                        cboSclRefPoint1.Enabled = true;
                        cboSclRefPoint2.Enabled = true;
                        cboSclRefPoly.Enabled = true;
                    }
                    else
                    {
                        cboSclAdjPoly.Enabled = true;
                        txtSclHeight.Enabled = true;
                        txtSclWidth.Enabled = true;
                        cboSclType.Enabled = true;
                    }
                }
            }
            else
            {
                radSclPoints.Enabled = false;
                radSclManual.Enabled = false;

                cboSclAdjPoint1.Enabled = false;
                cboSclAdjPoint2.Enabled = false;
                cboSclAdjPoly.Enabled = false;
                cboSclRefPoint1.Enabled = false;
                cboSclRefPoint2.Enabled = false;
                cboSclRefPoly.Enabled = false;

                txtSclHeight.Enabled = false;
                txtSclWidth.Enabled = false;
                cboSclType.Enabled = false;
            }

            EnableTransform();
        }


        private void radRotPoint_CheckedChanged(object sender, EventArgs e)
        {
            if (radRotPoint.Checked)
            {
                txtRotAngle.Enabled = false;

                radRotAdj.Enabled = false;
                radRotRef.Enabled = false;

                cboRotAdjPoint1.Enabled = true;
                cboRotAdjPoint2.Enabled = true;
                cboRotAdjPoly.Enabled = true;
                cboRotRefPoint1.Enabled = true;
                cboRotRefPoint2.Enabled = true;
                cboRotRefPoly.Enabled = true;
            }
            else
            {
                txtRotAngle.Enabled = true;
                radRotAdj.Enabled = true;
                radRotRef.Enabled = true;

                /*
                if (radRotVertex.Checked)
                {
                    cboRotAdjPoint1.Enabled = true;
                    cboRotAdjPoint2.Enabled = true;
                    cboRotAdjPoly.Enabled = true;
                    cboRotRefPoint1.Enabled = true;
                    cboRotRefPoint2.Enabled = true;
                    cboRotRefPoly.Enabled = true;
                }
                else 
                    */
                if (radRotAdj.Checked)
                {
                    cboRotAdjPoint1.Enabled = true;
                    cboRotAdjPoint2.Enabled = false;
                    cboRotAdjPoly.Enabled = true;

                    cboRotRefPoint1.Enabled = false;
                    cboRotRefPoint2.Enabled = false;
                    cboRotRefPoly.Enabled = true;
                }
                else
                {
                    cboRotAdjPoint1.Enabled = false;
                    cboRotAdjPoint2.Enabled = false;
                    cboRotAdjPoly.Enabled = false;

                    cboRotRefPoint1.Enabled = true;
                    cboRotRefPoint2.Enabled = false;
                    cboRotRefPoly.Enabled = true;
                }
            }
        }

        /*
        private void radRotVertex_CheckedChanged(object sender, EventArgs e)
        {
            cboRotAdjPoint1.Enabled = true;
            cboRotAdjPoint2.Enabled = true;
            cboRotAdjPoly.Enabled = true;
            cboRotRefPoint1.Enabled = true;
            cboRotRefPoint2.Enabled = true;
            cboRotRefPoly.Enabled = true;
        }
        */

        private void radRotRef_CheckedChanged(object sender, EventArgs e)
        {
            cboRotAdjPoint1.Enabled = false;
            cboRotAdjPoint2.Enabled = false;
            cboRotAdjPoly.Enabled = false;
            cboRotRefPoint1.Enabled = true;
            cboRotRefPoint2.Enabled = false;
            cboRotRefPoly.Enabled = true;
        }

        private void radRotAdj_CheckedChanged(object sender, EventArgs e)
        {
            cboRotAdjPoint1.Enabled = true;
            cboRotAdjPoint2.Enabled = false;
            cboRotAdjPoly.Enabled = true;
            cboRotRefPoint1.Enabled = false;
            cboRotRefPoint2.Enabled = false;
            cboRotRefPoly.Enabled = false;
        }

        private void radSclPoints_CheckedChanged(object sender, EventArgs e)
        {
            if (radSclPoints.Checked)
            {
                cboSclAdjPoint1.Enabled = true;
                cboSclAdjPoint2.Enabled = true;
                cboSclAdjPoly.Enabled = true;
                cboSclRefPoint1.Enabled = true;
                cboSclRefPoint2.Enabled = true;
                cboSclRefPoly.Enabled = true;

                txtSclHeight.Enabled = false;
                txtSclWidth.Enabled = false;
                cboSclType.Enabled = false;
            }
            else
            {
                cboSclAdjPoint1.Enabled = false;
                cboSclAdjPoint2.Enabled = false;
                cboSclAdjPoly.Enabled = true;
                cboSclRefPoint1.Enabled = false;
                cboSclRefPoint2.Enabled = false;
                cboSclRefPoly.Enabled = false;

                txtSclHeight.Enabled = true;
                txtSclWidth.Enabled = true;
                cboSclType.Enabled = true;
            }
        }

        private void radTransPoints_CheckedChanged(object sender, EventArgs e)
        {
            if (radTransPoints.Checked)
            {
                cboTransAdjPoint.Enabled = true;
                cboTransAdjPoly.Enabled = true;
                cboTransRefPoint.Enabled = true;
                cboTransRefPoly.Enabled = true;
                txtTransX.Enabled = false;
                txtTransY.Enabled = false;
                pnlTransUnit.Enabled = false;
            }
            else
            {
                cboTransAdjPoint.Enabled = true;
                cboTransAdjPoly.Enabled = true;
                cboTransRefPoint.Enabled = false;
                cboTransRefPoly.Enabled = false;
                txtTransX.Enabled = true;
                txtTransY.Enabled = true;
                pnlTransUnit.Enabled = true;
            }
        }
        #endregion


        #region Options

        enum TransOpt { Scale, Rotate, Translate }

        private TransOpt to1 = TransOpt.Scale, to2 = TransOpt.Rotate, to3 = TransOpt.Translate;
        Dictionary<int, Dictionary<TransOpt, RadioButton>> radsRowToOpt;

        Dictionary<TransOpt, int> optsToRow;
        TransOpt[] rowToOpts;

        private void changeOpt(int currRow, TransOpt changeTo)
        {
            if (currRow < 0 || currRow > 2)
                return;

            int oldRow;
            TransOpt oldOpt;

            if (changeTo != rowToOpts[currRow])
            {
                oldRow = optsToRow[changeTo];
                oldOpt = rowToOpts[currRow];

                rowToOpts[currRow] = changeTo;
                rowToOpts[oldRow] = oldOpt;

                optsToRow[oldOpt] = oldRow;
                optsToRow[changeTo] = currRow;

                radsRowToOpt[currRow][changeTo].Checked = true;
                radsRowToOpt[oldRow][oldOpt].Checked = true;
            }
        }


        private void radOptScale1_CheckedChanged(object sender, EventArgs e)
        {
            if(radOptScale1.Checked)
                changeOpt(0, TransOpt.Scale);
        }

        private void radOptScale2_CheckedChanged(object sender, EventArgs e)
        {
            if (radOptScale2.Checked)
                changeOpt(1, TransOpt.Scale);
        }

        private void radOptScale3_CheckedChanged(object sender, EventArgs e)
        {
            if (radOptScale3.Checked)
                changeOpt(2, TransOpt.Scale);
        }

        private void radOptRot1_CheckedChanged(object sender, EventArgs e)
        {
            if (radOptRot1.Checked)
                changeOpt(0, TransOpt.Rotate);
        }

        private void radOptRot2_CheckedChanged(object sender, EventArgs e)
        {
            if(radOptRot2.Checked)
                changeOpt(1, TransOpt.Rotate);
        }

        private void radOptRot3_CheckedChanged(object sender, EventArgs e)
        {
            if (radOptRot3.Checked)
                changeOpt(2, TransOpt.Rotate);
        }

        private void radOptTrans1_CheckedChanged(object sender, EventArgs e)
        {
            if(radOptTrans1.Checked)
                changeOpt(0, TransOpt.Translate);
        }

        private void radOptTrans2_CheckedChanged(object sender, EventArgs e)
        {
            if (radOptTrans2.Checked)
                changeOpt(1, TransOpt.Translate);
        }

        private void radOptTrans3_CheckedChanged(object sender, EventArgs e)
        {
            if (radOptTrans3.Checked)
                changeOpt(2, TransOpt.Translate);
        }
        #endregion

        private void cboTransRefPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateLists();
        }

        private void cboTransAdjPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateLists();
        }

        private void cboRotRefPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateLists();
        }

        private void cboRotAdjPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateLists();
        }

        private void cboSclRefPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateLists();
        }

        private void cboSclAdjPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateLists();
        }


    }
}
