using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Utilities;
using TwoTrails.Engine;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;
using TwoTrails.BusinessLogic;
using TwoTrails.Controls;
using System.Threading;

namespace TwoTrails.Forms
{
    public partial class PlotGridForm : Form
    {
        public enum PointLocation
        {
            Inside,
            Extents
        }

        public enum SampleType
        {
            Points,
            Percent
        }

        private DataAccessLayer DAL;

        private double ix, iy;
        private bool delOld;
        private double? tilt;

        //private TtPolygon CurrPoly;
        private TtPoint CurrPoint;
        private Dictionary<string, TtPoint> Points;
        private Dictionary<string, int> dicPointNames;

        private List<TtPolygon> _Polys;
        private List<string> lstPoly, lstLoc, lstDist;

        private string polyName;
        private Unit dist;
        private string PolyCN;
        private PointLocation loc;
        private SampleType sType;
        private bool DoSample;
        int SampleAmt;
        bool _generated;

        Thread genThread;
        bool _killThread;
        bool ThreadRunning { get; set; }

        public void Init()
        {
            this.Icon = Properties.Resources.Map;
            this.DialogResult = DialogResult.Cancel;

            _killThread = false;

#if (PocketPC || WindowsCE || Mobile)
            if (Values.Settings.DeviceOptions.UseSelection)
            {
                btnDist.Visible = true;
                btnLoc.Visible = true;
                btnPoly.Visible = true;
                btnStart.Visible = true;
                btnSample.Visible = true;

                cboDist.Visible = false;
                cboLoc.Visible = false;
                cboPoly.Visible = false;
                cboSample.Visible = false;
                cboStart.Visible = false;
            }
            else
            {
                btnDist.Visible = false;
                btnLoc.Visible = false;
                btnPoly.Visible = false;
                btnStart.Visible = false;
                btnSample.Visible = false;

                cboDist.Visible = true;
                cboLoc.Visible = true;
                cboPoly.Visible = true;
                cboSample.Visible = true;
                cboStart.Visible = true;
            }
#endif

            ix = 100;
            iy = 100;
            delOld = true;
            tilt = null;

            lstPoly = new List<string>();
            lstDist = new List<string>();
            lstLoc = new List<string>();

            _Polys = DAL.GetPolygons();

            if (_Polys.Count < 1)
            {
                MessageBox.Show("");
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                foreach (TtPolygon poly in _Polys)
                {
                    cboPoly.Items.Add(poly.Name);
                    lstPoly.Add(poly.Name);
                }

                ChangePoly(_Polys[0].CN);

                lstLoc.Add(PointLocation.Inside.ToString());
                lstLoc.Add(PointLocation.Extents.ToString());

                cboLoc.Items.Add(PointLocation.Inside);
                cboLoc.Items.Add(PointLocation.Extents);

                lstDist.Add(Unit.FEET_TENTH.ToString());
                lstDist.Add(Unit.METERS.ToString());
                lstDist.Add(Unit.FEET_INCHES.ToString());
                lstDist.Add(Unit.YARDS.ToString());
                lstDist.Add(Unit.CHAINS.ToString());

                cboDist.Items.Add(Unit.FEET_TENTH);
                cboDist.Items.Add(Unit.METERS);
                cboDist.Items.Add(Unit.FEET_INCHES);
                cboDist.Items.Add(Unit.YARDS);
                cboDist.Items.Add(Unit.CHAINS);

                cboLoc.SelectedIndex = 0;
                cboDist.SelectedIndex = 0;
                cboPoly.SelectedIndex = 0;

                dist = Unit.FEET_TENTH;
                PolyCN = _Polys[0].CN;
                loc = PointLocation.Inside;

#if (PocketPC || WindowsCE || Mobile)
                btnPoly.Text = lstPoly[0];
                btnLoc.Text = loc.ToString();
                btnDist.Text = dist.ToString();
#endif
                sType = SampleType.Percent;

                cboSample.Items.Add(SampleType.Percent.ToString());
                cboSample.Items.Add(SampleType.Points.ToString());

#if (PocketPC || WindowsCE || Mobile)
                cboSample.SelectedIndex = 0;
                btnSample.Text = sType.ToString();
#endif

                DoSample = false;
                chkSample.Checked = DoSample;

                SampleAmt = 100;
                txtSample.Text = SampleAmt.ToString();
                _generated = false;

                if (Values.FormPlotLastPolyIndex > -1)
                    cboPoly.SelectedIndex = Values.FormPlotLastPolyIndex;
                if (Values.FormPlotLastStartIndex > -1)
                    cboStart.SelectedIndex = Values.FormPlotLastStartIndex;
                if (Values.FormPlotLastDistIndex > -1)
                    cboDist.SelectedIndex = Values.FormPlotLastDistIndex;
                if (Values.FormPlotLastLocIndex > -1)
                    cboLoc.SelectedIndex = Values.FormPlotLastLocIndex;
                if (Values.FormPlotLastGrid1Val > 0)
                    txti1.Text = Values.FormPlotLastGrid1Val.ToString();
                if (Values.FormPlotLastGrid2Val > 0)
                    txti2.Text = Values.FormPlotLastGrid2Val.ToString();
                if (Values.FormPlotLastTiltVal > 0)
                    txtTilt.Text = Values.FormPlotLastTiltVal.ToString();

                if (Values.FormPlotLastSampleIndex > -1)
                    cboSample.SelectedIndex = Values.FormPlotLastSampleIndex;
                if (Values.FormPlotLastSampleVal > 0)
                    txtSample.Text = Values.FormPlotLastSampleVal.ToString();
            }

        }

        private void Generate()
        {
            ThreadRunning = true;

            if (Points.Count > 2)
            {
                TtMetaData meta = DAL.GetMetaDataByCN(Points.First().Value.MetaDefCN);
                if (meta == null)
                {
                    throw new Exception("No Meta Data");
                }

                TtPolygon newPoly = new TtPolygon();
                newPoly.Name = polyName;
                newPoly.Description = "Plot Grid";
                newPoly.PointStartIndex = ((int)DAL.GetPolyCount() + 1) * 1000 + 10;
                newPoly.IncrementBy = 1;

                DAL.InsertPolygon(newPoly);

                Random rand = new Random();

                double gridX = ix, gridY = iy, angle;

                TtUtils.ShowWaitCursor();

                try
                {
                    //convert to meters if not meters
                    if (dist != Unit.METERS)
                    {
                        gridX = TtUtils.ConvertToMeters(gridX, dist);
                        gridY = TtUtils.ConvertToMeters(gridY, dist);
                    }

                    //get rotation
                    if (tilt == null)
                        angle = rand.Next(-45, 45);
                    else
                        angle = (double)tilt * -1;

                    newPoly.Description = String.Format("Angle: {0}, GridX(Mt): {1}, GridY(Mt): {2}",
                        angle, gridX, gridY);

                    angle = TtUtils.DegreesToRadian(angle);

                    //add list of DoublePoints from TtPoints (using DoublePoints is Faster in the calculations)
                    List<DoublePoint> _Points = new List<DoublePoint>();

                    //return if canceled
                    if (_killThread)
                    {
                        ThreadRunning = false;
                        return;
                    }

                    foreach (TtPoint p in Points.Values.Where( pt => pt.OnBnd))
                    {
                        _Points.Add(new DoublePoint(p.AdjX, p.AdjY));
                    }

                    double startX, startY;
                    double top, bottom, left, right;
                    top = bottom = left = right = 0;

                    if (!TtUtils.GetFarthestPoints(_Points, out top, out bottom, out left, out right))
                    {
                        //if CurrPoint is null get random start point, else use selected StartPoint
                        if (CurrPoint == null)
                        {
                            startY = rand.NextDouble() * (top - bottom) + bottom;
                            startX = rand.NextDouble() * (right - left) + left;
                        }
                        else
                        {
                            startX = CurrPoint.AdjX;
                            startY = CurrPoint.AdjY;
                        }

                        //push boundaries of the polygon box by 10 meters (for Extents)
                        top += 10;
                        bottom -= 10;
                        left -= 10;
                        right += 10;

                        double farX = startX, farY = startY;
                        TtUtils.GetFarthestCorner(startX, startY, top, bottom, left, right, out farX, out farY);

                        double dist2 = TtUtils.Distance(startX, startY, farX, farY);

                        int ptAmtY = (int)(Math.Floor(dist2 / gridY) + 1);
                        int ptAmtX = (int)(Math.Floor(dist2 / gridX) + 1);

                        double farLeft, farRight, farTop, farBottom;

                        farLeft = startX - (ptAmtX * gridX);
                        farRight = startX + (ptAmtX * gridX);
                        farTop = startY + (ptAmtY * gridY);
                        farBottom = startY - (ptAmtY * gridY);

                        double i = farLeft;
                        double j = farTop;

                        List<DoublePoint> dblPts = new List<DoublePoint>();

                        DoublePoint _point;

                        List<DoublePoint> rec = new List<DoublePoint>();
                        rec.Add(new DoublePoint(left, top));
                        rec.Add(new DoublePoint(right, top));
                        rec.Add(new DoublePoint(right, bottom));
                        rec.Add(new DoublePoint(left, bottom));

                        while (i <= farRight)
                        {
                            while (j >= farBottom)
                            {
                                //return if canceled
                                if (_killThread)
                                {
                                    ThreadRunning = false;
                                    return;
                                }
                                
                                //add the rotated point

                                _point = TtUtils.RotatePoint(i, j, angle, startX, startY);

                                if (loc == PointLocation.Inside)
                                {
                                    //add if point inside the polygon

                                    if (TtUtils.PointInPoly(_point, ref _Points))
                                        dblPts.Add(_point);
                                }
                                else
                                {
                                    //add if point inside the polygon box

                                    if (TtUtils.PointInPoly(_point, ref rec))
                                        dblPts.Add(_point);
                                }

                                j -= gridY;

                            }
                            i += gridX;
                            j = farTop;
                        }

                        List<TtPoint> _NewPoints = new List<TtPoint>();
                        WayPoint way;
                        WayPoint lastWay = null;

                        //add points to polygon
                        for (int a = 0; a < dblPts.Count; a++)
                        {
                            //return if canceled
                            if (_killThread)
                            {
                                ThreadRunning = false;
                                return;
                            }

                            way = new WayPoint();

                            DoublePoint dp = dblPts[a];
                            //way.X = dp.X;
                            way.UnAdjX = dp.X;
                            //way.Y = dp.Y;
                            way.UnAdjY = dp.Y;
                            way.UnAdjZ = 0;
                            way.PolyCN = newPoly.CN;
                            way.PolyName = newPoly.Name;
                            way.OnBnd = false;
                            way.ManualAccuracy = null;
                            way.Index = a;
                            way.Comment = "Generated Point";
                            way.GroupCN = Values.MainGroup.CN;
                            way.GroupName = Values.MainGroup.Name;

                            if (lastWay == null)
                                way.PID = PointNaming.NameFirstPoint(newPoly);
                            else
                                way.PID = PointNaming.NamePoint(lastWay, newPoly);

                            way.Time = DateTime.Now;
                            way.MetaDefCN = meta.CN;

                            _NewPoints.Add(way);

                            lastWay = way;
                        }

                        DAL.SavePoints(null, _NewPoints, ref _killThread);

                        //return if canceled
                        if (_killThread)
                        {
                            ThreadRunning = false;
                            return;
                        }

                        DAL.SavePolygon(newPoly, newPoly);
                        TtUtils.HideWaitCursor();

                        lstPoly.Add(polyName);
                        _Polys.Add(newPoly);

                        AutoClosingMessageBox.Show(String.Format("{0} Points Generated.", dblPts.Count),
                            "Points Generated", 1000);
                        _generated = true;
                    }
                    else
                    {
                        //polygon has less than 3 sides
                        MessageBox.Show("No Points Generated.");

                        DAL.DeletePolygon(newPoly.CN);
                    }

                }
                catch (Exception ex)
                {
                    if (!_killThread)
                    {
                        TtUtils.WriteError(ex.Message, "PlotGirdFormLogic:Generate");
                        MessageBox.Show("Plot Generate Error.");
                    }
                }

                TtUtils.HideWaitCursor();
            }
            else
            {
                MessageBox.Show("Polygon must have minimum of 3 points.");
            }

            ThreadRunning = false;
            btnPlot.GuiInvoke(() =>
                {
                    btnPlot.Enabled = true;
                });
        }

        private void ChangePoly(string cn)
        {
            Points = new Dictionary<string, TtPoint>();
            dicPointNames = new Dictionary<string, int>();
            cboStart.Items.Clear();
            cboStart.Items.Add("<Random>");

            foreach (TtPoint point in DAL.GetPointsInPolygon(cn))
            {
                Points.Add(point.CN, point);
                dicPointNames.Add(point.CN, point.PID);
                cboStart.Items.Add(point.PID);
            }

            cboStart.SelectedIndex = 0;
        }

        #region Controls
        private void btnPlot_Click2(object sender, EventArgs e)
        {
            if (DoSample)
            {
                List<TtPoint> points = DAL.GetPointsInPolygon(_Polys[cboPoly.SelectedIndex].CN);
                List<TtPoint> nPoints = new List<TtPoint>();

                TtPolygon npoly = new TtPolygon((int)(DAL.GetPolyCount() + 1) * 1000 + 10);

                string polyName = lstPoly[cboPoly.SelectedIndex];

                IEnumerable<TtPolygon> polys = _Polys.Where(p => p.Name.EndsWith(polyName + "_PltSample"));

                if (polys.Count() > 0)
                {
                    npoly = polys.First();

                    try
                    {
                        DAL.DeletePointsInPolygon(npoly.CN);
                    }
                    catch (Exception ex)
                    {
                        TtUtils.WriteError(ex.Message, "PlotGridFormLogic::btnPlot(Sample)");
                    }
                }
                else
                {
                    npoly.Name = lstPoly[cboPoly.SelectedIndex] + "_PltSample";
                    DAL.InsertPolygon(npoly);
                }

                int amt;
                if (sType == SampleType.Percent)
                    amt = (int)((SampleAmt / 100.0) * points.Count);
                else
                    amt = SampleAmt;

                Random rand = new Random();

                while (amt < points.Count)
                {
                    points.RemoveAt(rand.Next(0, points.Count - 1));
                }

                TtPoint tmpPoint;

                for (int i = 0; i < points.Count; i++)
                {
                    tmpPoint = TtUtils.ClonePoint(points[i]);

                    if (i == 0)
                        tmpPoint.PID = PointNaming.NameFirstPoint(npoly);
                    else
                        tmpPoint.PID = PointNaming.NamePoint(nPoints[i - 1], npoly);

                    tmpPoint.Index = i;
                    tmpPoint.PolyName = npoly.Name;
                    tmpPoint.PolyCN = npoly.CN;
                    tmpPoint.GroupCN = Values.MainGroup.CN;
                    tmpPoint.GroupName = Values.MainGroup.Name;

                    nPoints.Add(tmpPoint);
                }

                DAL.InsertPoints(nPoints);

                MessageBox.Show(String.Format("{0} Plots Created.", nPoints.Count));
            }
            else
            {
                if (delOld)
                {
                    for (int i = 0; i < lstPoly.Count; i++)
                    {
                        if (i != cboPoly.SelectedIndex &&
                            lstPoly[i] == lstPoly[cboPoly.SelectedIndex] + "_PltCntr")
                        {
                            try
                            {
                                DAL.DeletePolygon(_Polys[i].CN);
                                lstPoly.RemoveAt(i);
                                _Polys.RemoveAt(i);
                                i--;
                            }
                            catch (Exception ex)
                            {
                                TtUtils.WriteError(ex.Message, "PlotGridFormLogic::btnPlot");
                            }
                        }
                    }
                }

                polyName = lstPoly[cboPoly.SelectedIndex] + "_PltCntr";

                if (!ThreadRunning)
                {
                    genThread = new Thread(new ThreadStart(Generate));
                    genThread.IsBackground = true;

                    btnPlot.Enabled = false;

                    genThread.Start();
                }
                else
                {
                    AutoClosingMessageBox.Show("Already Running Plot Generation.", "Thread Currently Running", 500);
                }
            }
        }

        private void btnClose_Click2(object sender, EventArgs e)
        {
            if (cboPoly.SelectedIndex > -1)
                Values.FormPlotLastPolyIndex = cboPoly.SelectedIndex;
            if (cboStart.SelectedIndex > -1)
                Values.FormPlotLastStartIndex = cboStart.SelectedIndex;
            if (cboDist.SelectedIndex > -1)
                Values.FormPlotLastDistIndex = cboDist.SelectedIndex;
            if (cboLoc.SelectedIndex > -1)
                Values.FormPlotLastLocIndex = cboLoc.SelectedIndex;
            if (txti1.Text.IsInteger())
                Values.FormPlotLastGrid1Val = txti1.Text.ToInteger();
            if (txti2.Text.IsInteger())
                Values.FormPlotLastGrid2Val = txti2.Text.ToInteger();
            if (txtTilt.Text.IsInteger())
                Values.FormPlotLastTiltVal = txtTilt.Text.ToInteger();

            if (cboSample.SelectedIndex > -1)
                Values.FormPlotLastSampleIndex = cboSample.SelectedIndex;
            if (txtSample.Text.IsInteger())
                Values.FormPlotLastSampleVal = txtSample.Text.ToInteger();


            if (ThreadRunning)
            {
                if (MessageBox.Show("Plots are being generated, do you want to cancel and close?", "Close",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    if (ThreadRunning)
                        TtUtils.ShowWaitCursor();
                    return;
                }
                else
                {
                    if (ThreadRunning)
                    {
                        genThread.Abort();
                        _killThread = true;
                        TtUtils.HideWaitCursor();
                    }
                }
            }

            //adjust for XYZ to become UnAdjXYZ
            if (_generated)
            {
                TtUtils.ShowWaitCursor();
                PolygonAdjuster.Adjust(DAL, true, this);
            }
            else
                this.Close();
        }

        private void txti1_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                if (txti1.Text.Length > 0)
                {
                    ix = Convert.ToDouble(txti1.Text);

                    if (ix < 1)
                    {
                        MessageBox.Show("Grid interval must be greater than 0.");
                    }
                }
            }
            catch
            {
                //
            }
        }

        private void txti2_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                if (txti2.Text.Length > 0)
                {
                    iy = Convert.ToDouble(txti2.Text);

                    if (iy < 1)
                    {
                        MessageBox.Show("Grid interval must be greater than 0.");
                    }
                }
            }
            catch
            {
                //
            }
        }

        private void txti1_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txti1);
            txti1.SelectAllViaInvoke();
        }

        private void txti2_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txti2);
            txti2.SelectAllViaInvoke();
        }

        private void txti1_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
            if (txti1.Text.Length < 1)
                txti1.Text = ix.ToString();
        }

        private void txti2_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
            if (txti2.Text.Length < 1)
                txti2.Text = iy.ToString();
        }

        private void txtTilt_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                if (txtTilt.Text.Length > 0)
                {
                    if (txtTilt.Text == "<rand>" || txtTilt.Text == "rand")
                    {
                        tilt = null;
                    }
                    else
                    {
                        tilt = Convert.ToDouble(txtTilt.Text);
                    }

                    if (tilt != null)
                    {
                        if (tilt < -45)
                        {
                            tilt = -45;
                            txtTilt.Text = tilt.ToString();
                        }
                        else if (tilt > 45)
                        {
                            tilt = 45;
                            txtTilt.Text = tilt.ToString();
                        }
                    }
                }
            }
            catch
            {
                tilt = null;
            }
        }

        private void txtTilt_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtTilt);
            txtTilt.SelectAllViaInvoke();
        }

        private void txtTilt_LostFocus2(object sender, EventArgs e)
        {
            if (txtTilt.Text.Length < 1 || tilt == null)
            {
                txtTilt.Text = "<rand>";
            }

            Kb.Hide(this);
        }

        private void cboLoc_SelectedIndexChanged2(object sender, EventArgs e)
        {
            loc = (PointLocation)Enum.Parse(typeof(PointLocation), lstLoc[cboLoc.SelectedIndex], true);
#if (PocketPC || WindowsCE || Mobile)
            btnLoc.Text = loc.ToString();
#endif
        }

        private void cboPoly_SelectedIndexChanged2(object sender, EventArgs e)
        {
            PolyCN = _Polys[cboPoly.SelectedIndex].CN;
#if (PocketPC || WindowsCE || Mobile)
            btnPoly.Text = _Polys[cboPoly.SelectedIndex].Name;
#endif
            ChangePoly(PolyCN);
        }

        private void cboDist_SelectedIndexChanged2(object sender, EventArgs e)
        {
            if (cboDist.SelectedItem != null)
            {
                dist = (Unit)cboDist.SelectedItem;
                //dist = (Unit)Enum.Parse(typeof(Unit), (string)cboDist.SelectedItem, true);
#if (PocketPC || WindowsCE || Mobile)
                btnDist.Text = dist.ToString();
#endif
            }
        }

        private void chkDelOld_CheckStateChanged2(object sender, EventArgs e)
        {
            delOld = chkDelOld.Checked;
        }

        private void cboStart_SelectedIndexChanged2(object sender, EventArgs e)
        {
            if (cboStart.SelectedIndex == 0)
            {
                CurrPoint = null;
            }
            else
            {
                CurrPoint = Points[dicPointNames.Keys.ToList()[cboStart.SelectedIndex - 1]];
            }

#if (PocketPC || WindowsCE || Mobile)
            if (CurrPoint == null)
                btnStart.Text = "<Random>";
            else
                btnStart.Text = CurrPoint.PID.ToString();
#endif
        }
        
#if (PocketPC || WindowsCE || Mobile)
        private void btnDist_Click2(object sender, EventArgs e)
        {
            using (Selection form = new Selection("Measurement Type", lstDist, lstDist.IndexOf(dist.ToString())))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    dist = (Unit)Enum.Parse(typeof(Unit), lstDist[form.selection], true);
                    btnDist.Text = dist.ToString();
                    cboDist.SelectedIndex = form.selection;
                }
            }
        }

        private void btnLoc_Click2(object sender, EventArgs e)
        {
            using (Selection form = new Selection("Point Location", lstLoc, lstLoc.IndexOf(loc.ToString())))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    loc = (PointLocation)Enum.Parse(typeof(PointLocation), lstLoc[form.selection], true);
                    btnLoc.Text = loc.ToString();
                    cboLoc.SelectedIndex = form.selection;
                }
            }
        }

        private void btnPoly_Click2(object sender, EventArgs e)
        {
            using (Selection form = new Selection("Polygon Selection", lstPoly, cboPoly.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    PolyCN = _Polys[form.selection].CN;
                    btnPoly.Text = _Polys[form.selection].Name;
                    cboPoly.SelectedIndex = form.selection;

                    ChangePoly(PolyCN);
                }
            }
        }

        private void btnStart_Click2(object sender, EventArgs e)
        {
            List<string> lstPoints = dicPointNames.Values.ToList().ConvertAll(p => p.ToString());
            lstPoints.Insert(0,"Random");

            using (Selection form = new Selection("Start Point Selection", lstPoints, cboStart.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.selection == 0)
                    {
                        CurrPoint = null;
                    }
                    else
                    {
                        CurrPoint = Points[dicPointNames.Keys.ToList()[form.selection -1]];
                    }

                    cboStart.SelectedIndex = form.selection;

                    if (CurrPoint == null)
                        btnStart.Text = "<Random>";
                    else
                        btnStart.Text = CurrPoint.PID.ToString();
                }
            }
        }

        private void btnSample_Click2(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            items.Add(SampleType.Percent.ToString());
            items.Add(SampleType.Points.ToString());

            using (Selection form = new Selection("Sample Selection", items, cboSample.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.selection == 0)
                    {
                        sType = SampleType.Percent;
                    }
                    else
                    {
                        sType = SampleType.Points;
                    }

                    cboSample.SelectedIndex = form.selection;
                    btnSample.Text = sType.ToString();
                }
            }
        }
#endif
        private void cboSample_SelectedIndexChanged2(object sender, EventArgs e)
        {
            if (cboSample.SelectedIndex == 0)
                sType = SampleType.Percent;
            else
                sType = SampleType.Points;

#if (PocketPC || WindowsCE || Mobile)
            btnSample.Text = sType.ToString();
#endif
        }

        private void txtSample_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtSample);
            txtSample.SelectAllViaInvoke();
        }

        private void txtSample_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                if (txtSample.Text.Length > 0)
                {
                    SampleAmt = Convert.ToInt32(txtSample.Text);

                    if (SampleAmt < 1)
                    {
                        MessageBox.Show("Sample Amount must be greater than 0.");
                        SampleAmt = 1;
                    }

                    if (sType == SampleType.Percent && SampleAmt > 100)
                    {
                        MessageBox.Show("Sample Amount cannot be greater than 100%.");
                        SampleAmt = 100;
                    }
                }
            }
            catch
            {
                //
            }
        }

        private void txtSample_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void chkSample_Click2(object sender, EventArgs e)
        {
            DoSample = chkSample.Checked;

            txtSample.Enabled = DoSample;
            cboSample.Enabled = DoSample;


            cboSample.Enabled = DoSample;
            txtSample.Enabled = DoSample;

            cboLoc.Enabled = !DoSample;
            cboDist.Enabled = !DoSample;
            cboStart.Enabled = !DoSample;
            txti1.Enabled = !DoSample;
            txti2.Enabled = !DoSample;
            txtTilt.Enabled = !DoSample;
            chkDelOld.Enabled = !DoSample;

#if (PocketPC || WindowsCE || Mobile)
            btnDist.Enabled = !DoSample;
            btnLoc.Enabled = !DoSample;
            btnStart.Enabled = !DoSample;
#endif
        }

        #endregion
    }
}