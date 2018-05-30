//#define OPZ

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;
using TwoTrails.GpsAccess;
using TwoTrails.Forms;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public delegate void DelegateGotBurst(TwoTrails.GpsAccess.NmeaBurst b);

    public partial class MapForm : Form
    {
        public class PolyWPoints
        {
            public TtPolygon polygon;
            public List<TtPoint> points;

            public PolyWPoints(TtPolygon poly, DataAccessLayer DAL)
            {
                this.polygon = poly;
                this.points = DAL.GetPointsInPolygon(poly.CN);

                foreach (TtPoint point in points)
                {
                    point.AdjY *= -1;
                    point.UnAdjY *= -1;
                }
            }
        }

        public struct PointName
        {
            public double X;
            public double Y;
            public String Name;

            public Point Point
            {
                get
                {
                    return new Point((int)X, (int)Y);
                }
            }

            public PointName(double x, double y, string name)
            {
                X = x;
                Y = y;
                Name = name;
            }
        }

        private List<string> polyCNs;
        private List<PolyWPoints> polys;
        private List<TtPoint> allPolyPoints;
        private DataAccessLayer DAL;
        private int pnlWidth, pnlHeight;
        private double zoomSize, offSetX, offSetY, moveOffsetX, moveOffsetY;
        private double myGpsPosX, myGpsPosY;
        private double dEast, dWest, dNorth, dSouth, latDiff, lonDiff;
        private Pen penPoints, penGrid, penAdjNav, penAdjBound, penUnAdjNav, penUnAdjBound, penMyPos;
        private Brush brushLabel, brushAdjPoint, brushUnAdjPoint, brushWayPoint;
        private Brush brushAdjMiscPoint, brushUnadjMiscPoint;
        private Font font;
        private double polysCenterX, polysCenterY, increaseSize;
        private double screenLatAdj = 1, screenLonAdj = 1, scrAdj = 1;
        private int timerTick;
        private double sideLength, sideDiff;
        private bool loaded = false;
        private bool tracking = false;
        private bool ignoreMyPos = false;
        private int direction, count;
        private long lastDraw = 0;
        private bool t5Enabled = false;
        private PolyWPoints t5PWP;


        private List<PointName> pns = new List<PointName>();
        bool drawPN = false, ignoreClick = false;
        PointName clickedPN;

        //private Image _MapBackgroud;


        public void loadMapData(List<string> p, DataAccessLayer d)
        {
            TtUtils.ShowWaitCursor();

            polyCNs = p;
            DAL = d;

            t5Enabled = !MapValues.mapPolyT5.IsEmpty() && MapValues.mapPolyT5 != Values.EmptyGuid;

            if (t5Enabled && !polyCNs.Contains(MapValues.mapPolyT5))
                polyCNs.Add(MapValues.mapPolyT5);

            font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            brushLabel = new SolidBrush(Color.Black);
            brushAdjPoint = new SolidBrush(Color.Black);
            brushUnAdjPoint = new SolidBrush(Color.Gray);
            brushWayPoint = new SolidBrush(Color.Blue);

            penPoints = new Pen(Color.Black, 3);

            penAdjNav = new Pen(Color.Teal, 4);
            penAdjBound = new Pen(Color.Red, 2);

            penUnAdjNav = new Pen(Color.Lime, 4);
            penUnAdjBound = new Pen(Color.DarkGreen, 2);

            penGrid = new Pen(Color.LightGray);
            penMyPos = new Pen(Color.Red, 5);

            brushAdjMiscPoint = new SolidBrush(Color.Green);
            brushUnadjMiscPoint = new SolidBrush(Color.LightGreen);

            polys = new List<PolyWPoints>();
            PolyWPoints pwp;
            foreach (string pCN in polyCNs)
            {
                pwp = new PolyWPoints(DAL.GetPolygonByCn(pCN), DAL);
                polys.Add(pwp);

                if (t5Enabled && pCN == MapValues.mapPolyT5)
                    t5PWP = pwp;
            }

            allPolyPoints = polys.SelectMany(poly => poly.points).ToList();
            

            //if (MapValues.mapHasBackground)
            //{
            //    if (System.IO.File.Exists(MapValues.mapBackgroundCoordsFile))
            //    {
            //        try
            //        {
            //            using (System.IO.StreamReader sr = new System.IO.StreamReader(MapValues.mapBackgroundCoordsFile))
            //            {
            //                string pos = string.Empty;
            //                for (int i = 0; i < 5; i++)
            //                {
            //                    pos = sr.ReadLine();
            //                }

            //                if (pos.IsDouble())
            //                {
            //                    double x = pos.ToDouble();
            //                    pos = sr.ReadLine();
            //                    double y = pos.ToDouble();

            //                    MapValues.mapBackgroundCoords = new Point((int)x, (int)y);

            //                #if (PocketPC || WindowsCE || Mobile)
            //                    Bitmap bmp = new Bitmap(MapValues.mapBackground);
            //                    _MapBackgroud = Image.FromHbitmap(bmp.GetHbitmap());
            //                #else
            //                    _MapBackgroud = Image.FromFile(MapValues.mapBackground);
            //                #endif
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MapValues.mapHasBackground = false;
            //            TtUtils.WriteError(ex.Message, "MapForm:InitValues:MapBackground", ex.StackTrace);
            //            MessageBox.Show("Map Background Error, see log for details.");
            //        }
            //    }
            //    else
            //        MapValues.mapHasBackground = false;
            //}


            btnT5.Visible = t5Enabled;
            progT5.Visible = t5Enabled;

            if (t5Enabled)
                initT5();

            loaded = true;

            TtUtils.HideWaitCursor();
        }

        private void MapForm_Load2(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;

            if (MapValues.mapMyPos)
            {
                startGPSTracking();

                if (MapValues.mapDetails)
                    lblLoc.Visible = true;
                else
                    lblLoc.Visible = false;
            }
            else
            {
                lblLoc.Visible = false;
            }
        }

        private void MapForm_Closed2(object sender, EventArgs e)
        {

            if (tracking)
                endGPSTracking();

            GC.Collect();
        }

        #region DrawMap

        public void draw(object sender, PaintEventArgs e)
        {
            pns.Clear();

            try
            {
                if (loaded && (polyCNs != null && polyCNs.Count > 0 || MapValues.mapMyPos))
                {
                    calcFarthestPolyPoints();

                    #region Screen Calculations
                    pnlWidth = e.ClipRectangle.Width;   //size of panel
                    pnlHeight = e.ClipRectangle.Height;

                    screenLonAdj = pnlWidth / lonDiff;  //adjust value of screen to polygons
                    screenLatAdj = pnlHeight / latDiff;

                    if (sideDiff < 10)
                        sideDiff = 10;

                    if (screenLonAdj < screenLatAdj)
                    {
                        scrAdj = screenLonAdj * .8;
                        sideLength = pnlWidth;
                        sideDiff = lonDiff;
                    }
                    else
                    {
                        scrAdj = screenLatAdj * .8;
                        sideLength = pnlHeight;
                        sideDiff = latDiff;
                    }

                    increaseSize = 1;
                    offSetX = 0;
                    offSetY = 0;

                    if (zoomSize > 1)
                    {
                        increaseSize = (zoomSize + 8) / 8;
                        offSetX = offSetY = (((sideDiff * scrAdj * increaseSize) - (sideDiff * scrAdj)) / 2);
                    }
                    #endregion

                    sharedDraw(e.Graphics);
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MapFormLogic:Draw", ex.StackTrace);
                MessageBox.Show("An Error has occured.");
                this.Close();
            }
        }

#if !(PocketPC || WindowsCE || Mobile)
        public void drawPrint(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                if (loaded && (polyCNs != null && polyCNs.Count > 0 || MapValues.mapMyPos))
                {
                    calcFarthestPolyPoints();

                    #region Screen Calculations
                    pnlWidth = e.PageBounds.Width;   //size of panel
                    pnlHeight = e.PageBounds.Height;

                    screenLonAdj = pnlWidth / lonDiff;  //adjust value of screen to polygons
                    screenLatAdj = pnlHeight / latDiff;

                    if (sideDiff < 10)
                        sideDiff = 10;

                    if (screenLonAdj < screenLatAdj)
                    {
                        scrAdj = screenLonAdj * .8;
                        sideLength = pnlWidth;
                        sideDiff = lonDiff;
                    }
                    else
                    {
                        scrAdj = screenLatAdj * .8;
                        sideLength = pnlHeight;
                        sideDiff = latDiff;
                    }

                    increaseSize = 1;
                    offSetX = 0;
                    offSetY = 0;

                    if (zoomSize > 1)
                    {
                        increaseSize = (zoomSize + 8) / 8;
                        offSetX = offSetY = (((sideDiff * scrAdj * increaseSize) - (sideDiff * scrAdj)) / 2);
                    }
                    #endregion

                    sharedDraw(e.Graphics);
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MapFormLogic:DrawPaint", ex.StackTrace);
                MessageBox.Show("An Error has occured.");
                this.Close();
            }
        }
#endif

        private void sharedDraw(Graphics g)
        {
            #region mappingLocation
            if (MapValues.mapMyPos && !ignoreMyPos)
            {
                //invert for draw
                myGpsPosY *= -1;

                //calc gps on screen
                myGpsPosX = ((((myGpsPosX - dWest) * scrAdj) * increaseSize) + sideLength * .1) - offSetX;
                myGpsPosY = ((((myGpsPosY - dSouth) * scrAdj) * increaseSize) + sideLength * .1) - offSetY;

                if (MapValues.mapFollowPos)
                {
                    //offset all polygons for gps tracking
                    offSetX += (myGpsPosX - pnlWidth / 2);
                    offSetY += (myGpsPosY - pnlHeight / 2);

                    //center gps
                    myGpsPosX = pnlWidth / 2;
                    myGpsPosY = pnlHeight / 2;
                }
                else
                {
                    //offset of gps location for movment controls
                    myGpsPosX += moveOffsetX;
                    myGpsPosY += moveOffsetY;

                    //offset for movement controls
                    offSetX -= moveOffsetX;
                    offSetY -= moveOffsetY;
                }
            }
            else
            {
                //offset for movement controls
                offSetX -= moveOffsetX;
                offSetY -= moveOffsetY;
            }
            #endregion

            #region MapSwitches

            //if (MapValues.mapHasBackground)
            //{
            //    try
            //    {
            //        Size size = new Size((int)(_MapBackgroud.Width * increaseSize),
            //            (int)(_MapBackgroud.Height * increaseSize));

            //        Point p = calcPointLocation(MapValues.mapBackgroundCoords.X,
            //                MapValues.mapBackgroundCoords.Y * -1);

            //        p.X -= (int)(sideLength * .2);
            //        p.Y -= (int)(sideLength * .2);

            //        g.DrawImage(_MapBackgroud.ResizeImage(size), p.X, p.Y);
            //    }
            //    catch (Exception ex)
            //    {
            //        TtUtils.WriteError(ex.Message, "MapForm:Draw:DrawBackgroud");
            //    }
            //}

            if (MapValues.mapGrid)
            {
                drawGrid(g);
            }

            #region MapLines
            if (MapValues.mapLines)
            {
                foreach (PolyWPoints poly in polys)
                {
                    if (MapValues.mapUnadjNav)
                    {
                        drawNavTrail(poly, false, g);
                    }

                    if (MapValues.mapUnadjBound)
                    {
                        drawBoundTrail(poly, false, g);
                    }

                    if (MapValues.mapAdjNav)
                    {
                        drawNavTrail(poly, true, g);
                    }

                    if (MapValues.mapAdjBound)
                    {
                        drawBoundTrail(poly, true, g);
                    }
                }
            }
            #endregion

            #region Points and Labels

            bool allLabels = MapValues.mapPolyLabels == Values.FullGuid;

            if (MapValues.mapPoints || MapValues.mapPolyLabels != Values.EmptyGuid)
            {
                int count = 0;
                bool writeLabel = false;

                foreach (TtPoint point in allPolyPoints)
                {
                    writeLabel = count == 0 && (allLabels || MapValues.mapPolyLabels == point.PolyCN);

                    if (point.op != OpType.WayPoint && !(!point.OnBnd && point.op == OpType.SideShot))
                    {
                        if (MapValues.mapUnadjNav || MapValues.mapUnadjBound)
                        {
                            drawPoint(point, false, g, writeLabel);
                        }

                        if (MapValues.mapAdjNav || MapValues.mapAdjBound)
                        {
                            drawPoint(point, true, g, writeLabel);
                        }
                    }

                    if (!point.OnBnd && point.op == OpType.SideShot)
                    {
                        if (MapValues.mapUnadjMisc)
                        {
                            drawMiscPoint(point, false, g, writeLabel);
                        }

                        if (MapValues.mapAdjMisc)
                        {
                            drawMiscPoint(point, true, g, writeLabel);
                        }
                    }

                    if (point.op == OpType.WayPoint)
                    {
                        if (MapValues.mapUnadjWaypoints)
                        {
                            drawWayPoint(point, g, writeLabel);
                        }
                    }

                    if (MapValues.mapSkip > 0)
                    {
                        if (MapValues.mapSkip > count + 1)
                            count++;
                        else
                            count = 0;
                    }
                }
            }
            #endregion

            if (MapValues.mapMyPos)
            {
                drawMyPos(g);
            }

            if (MapValues.mapLegend)
            {
                drawLegend(g);
            }

            if (drawPN)
            {
                Point newPoint = calcPointLocation(clickedPN.X, clickedPN.Y);

                drawPointLabel(g, clickedPN.Name, font, brushLabel, newPoint);


                Rectangle recPoint = new Rectangle();
                recPoint.X = newPoint.X - 5;
                recPoint.Y = newPoint.Y - 5;
                recPoint.Width = 10;
                recPoint.Height = 10;

                g.DrawEllipse(new Pen(Color.Red, 2), recPoint);
            }
            #endregion

            lastDraw = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }


        #region DrawObjects

        private void drawPoint(TtPoint point, bool adjusted, Graphics g, bool wLabel)
        {
            Point newPoint = new Point();
            Brush brush;
            Rectangle recPoint = new Rectangle();

            if (adjusted)
            {
                newPoint = calcPointLocation(point.AdjX, point.AdjY);
                brush = brushAdjPoint;
            }
            else
            {
                newPoint = calcPointLocation(point.UnAdjX, point.UnAdjY);
                brush = brushUnAdjPoint;
            }

            recPoint.X = newPoint.X - 2;
            recPoint.Y = newPoint.Y - 2;
            recPoint.Width = 4;
            recPoint.Height = 4;

            try
            {
                if (inScreen(newPoint))
                {
                    if (MapValues.mapPoints)
                    {
                        g.FillEllipse(brush, recPoint);

                        if (adjusted)
                            pns.Add(new PointName(point.AdjX, point.AdjY, point.PID.ToString()));
                        else
                            pns.Add(new PointName(point.UnAdjX, point.UnAdjY, point.PID.ToString()));
                    }

                    //??
                    if (wLabel)
                    {
                        drawPointLabel(g, point.PID.ToString(), font, brushLabel, newPoint);
                    }
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MapFormLogic- DrawPoint", ex.StackTrace);
            }

        }

        private void drawWayPoint(TtPoint point, Graphics g, bool wLabel)
        {
            Point newPoint = new Point();
            Rectangle recPoint = new Rectangle();

            newPoint = calcPointLocation(point.UnAdjX, point.UnAdjY);

            recPoint.X = newPoint.X - 2;
            recPoint.Y = newPoint.Y - 2;
            recPoint.Width = 4;
            recPoint.Height = 4;

            try
            {
                if (inScreen(newPoint))
                {
                    if (MapValues.mapPoints)
                    {
                        g.FillEllipse(brushWayPoint, recPoint);
                        pns.Add(new PointName(point.UnAdjX, point.UnAdjY, point.PID.ToString()));
                    }

                    //??
                    if (wLabel)
                    {
                        drawPointLabel(g, point.PID.ToString(), font, brushLabel, newPoint);
                    }
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MapFormLogic- WayPoint", ex.StackTrace);
            }
        }

        private void drawMiscPoint(TtPoint point, bool adjusted, Graphics g, bool wLabel)
        {
            Point newPoint = new Point();
            Brush brush;
            Rectangle recPoint = new Rectangle();

            if (adjusted)
            {
                newPoint = calcPointLocation(point.AdjX, point.AdjY);
                brush = brushAdjMiscPoint;
            }
            else
            {
                newPoint = calcPointLocation(point.UnAdjX, point.UnAdjY);
                brush = brushUnadjMiscPoint;
            }

            recPoint.X = newPoint.X - 2;
            recPoint.Y = newPoint.Y - 2;
            recPoint.Width = 4;
            recPoint.Height = 4;

            try
            {
                if (inScreen(newPoint))
                {
                    if (MapValues.mapPoints)
                    {
                        g.FillEllipse(brush, recPoint);

                        if (adjusted)
                            pns.Add(new PointName(point.AdjX, point.AdjY, point.PID.ToString()));
                        else
                            pns.Add(new PointName(point.UnAdjX, point.UnAdjY, point.PID.ToString()));
                    }
                    //??
                    if (wLabel)
                    {
                        drawPointLabel(g, point.PID.ToString(), font, brushLabel, newPoint);
                    }
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MapFormLogic- MiscPoint", ex.StackTrace);
            }
        }


        private void drawBoundTrail(PolyWPoints poly, bool adjusted, Graphics g)
        {
            List<TtPoint> polyPoints = poly.points.Where(p => p.IsBndPoint()).ToList();
            List<Point> adjForDrawPoints = new List<Point>();

            if (polyPoints.Count < 3)
                return;

            if (MapValues.closeBounds)
            {
                if ((polyPoints[0].AdjX != polyPoints[polyPoints.Count - 1].AdjX) ||
                    (polyPoints[0].AdjY != polyPoints[polyPoints.Count - 1].AdjY))
                {
                    polyPoints.Add(polyPoints[0]);
                }
            }

            double px = 0, py = 0;

            Point currPoint = new Point();

            foreach(TtPoint pt in polyPoints)
            {
                if (adjusted)
                {
                    px = pt.AdjX;
                    py = pt.AdjY;

                    currPoint = calcPointLocation(px, py);
                }
                else
                {
                    px = pt.UnAdjX;
                    py = pt.UnAdjY;

                    currPoint = calcPointLocation(px, py);
                }

                adjForDrawPoints.Add(currPoint);
            }

            try
            {
                if (adjusted)
                {
                    g.DrawLines(penAdjBound, adjForDrawPoints.ToArray());
                }
                else
                {
                    g.DrawLines(penUnAdjBound, adjForDrawPoints.ToArray());
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MapFormLogic- BoundTrail", ex.StackTrace);
            }
        }

        private void drawNavTrail(PolyWPoints poly, bool adjusted, Graphics g)
        {
            List<Point> adjForDrawPoints = new List<Point>();
            double px = 0, py = 0;

            Point currPoint = new Point();

            foreach(TtPoint pt in poly.points)
            {
                if (pt.IsNavPoint())
                { 
                    if (adjusted)
                    {
                        px = pt.AdjX;
                        py = pt.AdjY;

                        currPoint = calcPointLocation(px, py);
                    }
                    else
                    {
                        px = pt.UnAdjX;
                        py = pt.UnAdjY;

                        currPoint = calcPointLocation(px, py);
                    }

                    adjForDrawPoints.Add(currPoint);
                }
            }

            try
            {
                if (adjusted)
                {
                    g.DrawLines(penAdjNav, adjForDrawPoints.ToArray());
                }
                else
                {
                    g.DrawLines(penUnAdjNav, adjForDrawPoints.ToArray());
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MapFormLogic- NavTrail", ex.StackTrace);
            }
        }


        private void drawMyPos(Graphics g)
        {
            Rectangle recMyPos = new Rectangle();

            try
            {
                recMyPos.X = (int)(myGpsPosX - 2);
                recMyPos.Y = (int)(myGpsPosY - 2);

                recMyPos.Width = 4;
                recMyPos.Height = 4;


                if (MapValues.mapFollowPos || inScreen(recMyPos.X, recMyPos.Y))
                {
                    g.DrawEllipse(penMyPos, recMyPos);
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MapFormLogic- MyPos", ex.StackTrace);
            }
        }

        private void drawGrid(Graphics g)
        {
            double gridS = 0, off = 0;

            double[] gridV = new double[3];
            double[] gridH = new double[3];

            if (pnlWidth > pnlHeight)
            {
                gridS = pnlHeight / 4.0;
                off = (pnlWidth - pnlHeight) / 2.0;

                for (int i = 0; i < 3; i++)
                {
                    gridV[i] = gridS + gridS * i;
                    gridH[i] = gridS + off + gridS * i;
                }
            }
            else
            {
                gridS = pnlWidth / 4.0;
                off = (pnlHeight - pnlWidth) / 2.0;

                for (int i = 0; i < 3; i++)
                {
                    gridH[i] = gridS + off + gridS * i;
                    gridV[i] = gridS + gridS * i;
                }
            }

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    g.DrawLines(penGrid, new Point[] { new Point(0, (int)gridH[i]), new Point(pnlWidth, (int)gridH[i]) });
                    g.DrawLines(penGrid, new Point[] { new Point((int)gridV[i], 0), new Point((int)gridV[i], pnlHeight) });

                    if (MapValues.mapAxis)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MapFormLogic- Grid", ex.StackTrace);
            }
        }

        private void drawLegend(Graphics g)
        {
            int lblWidth = pnlWidth * 2 / 9;   //two nineth of the width of the screen
            int pX = pnlWidth - lblWidth;
            int pY = 20;    //start 20px from the top

            Rectangle recPoint = new Rectangle();
            RectangleF recLabel = new RectangleF();

            int lblHeight = pnlHeight / 15;
            int lineSpacing = lblHeight * 2 / 3;
            int itemSpacing = pnlHeight / 45;

            recLabel.Width = lblWidth;
            recLabel.Height = lblHeight;
            recLabel.X = pX;

            recPoint.Width = 4;
            recPoint.Height = 4;
            recPoint.X = pX + 15;


            if (MapValues.mapAdjBound)
            {
                recLabel.Y = pY;

                g.DrawString("AdjBound", font, new SolidBrush(Color.Red), recLabel);

                pY += lineSpacing;

                g.DrawLine(penAdjBound, pX, pY, pX + lblWidth, pY);

                pY += itemSpacing;
            }

            if (MapValues.mapUnadjBound)
            {
                recLabel.Y = pY;

                g.DrawString("UnAdjBound", font, new SolidBrush(Color.DarkGreen), recLabel);

                pY += lineSpacing;

                g.DrawLine(penUnAdjBound, pX, pY, pX + lblWidth, pY);

                pY += itemSpacing;
            }

            if (MapValues.mapAdjNav)
            {
                recLabel.Y = pY;

                g.DrawString("AdjNav", font, new SolidBrush(Color.Teal), recLabel);

                pY += lineSpacing;

                g.DrawLine(penAdjNav, pX, pY, pX + lblWidth, pY);

                pY += itemSpacing;
            }

            if (MapValues.mapUnadjNav)
            {
                recLabel.Y = pY;

                g.DrawString("UnAdjNav", font, new SolidBrush(Color.Lime), recLabel);

                pY += lineSpacing;

                g.DrawLine(penUnAdjNav, pX, pY, pX + lblWidth, pY);

                pY += itemSpacing;
            }

            if (MapValues.mapPoints)
            {
                if (MapValues.mapAdjBound || MapValues.mapAdjNav)
                {
                    recLabel.Y = pY;

                    g.DrawString("AdjPoint", font, brushAdjPoint, recLabel);

                    pY += lineSpacing;

                    recPoint.Y = pY - 2;

                    g.FillEllipse(brushAdjPoint, recPoint);

                    pY += itemSpacing;
                }

                if (MapValues.mapUnadjBound || MapValues.mapUnadjNav)
                {
                    recLabel.Y = pY;

                    g.DrawString("UnAdjPoint", font, brushUnAdjPoint, recLabel);

                    pY += lineSpacing;

                    recPoint.Y = pY - 2;

                    g.FillEllipse(brushUnAdjPoint, recPoint);

                    pY += itemSpacing;
                }
            }

            if (MapValues.mapAdjMisc)
            {
                recLabel.Y = pY;

                g.DrawString("AdjMisc", font, brushAdjMiscPoint, recLabel);

                pY += lineSpacing;

                recPoint.Y = pY - 2;

                g.FillEllipse(brushAdjMiscPoint, recPoint);

                pY += itemSpacing;
            }

            if(MapValues.mapUnadjMisc)
            {
                recLabel.Y = pY;

                g.DrawString("UnAdjMisc", font, brushUnadjMiscPoint, recLabel);

                pY += lineSpacing;

                recPoint.Y = pY - 2;

                g.FillEllipse(brushUnadjMiscPoint, recPoint);

                pY += itemSpacing;
            }

            if (MapValues.mapUnadjWaypoints)
            {
                recLabel.Y = pY;

                g.DrawString("WayPoint", font, brushWayPoint, recLabel);

                pY += lineSpacing;

                recPoint.Y = pY - 2;

                g.FillEllipse(brushWayPoint, recPoint);

                pY += itemSpacing;
            }

            if (MapValues.mapMyPos)
            {
                recLabel.Y = pY;

                g.DrawString("My Pos", font, new SolidBrush(Color.Red), recLabel);

                pY += lineSpacing;

                recPoint.Y = pY - 2;

                g.FillEllipse(new SolidBrush(Color.Red), recPoint);

                pY += itemSpacing;
            }
        }

        private void drawPointLabel(Graphics g, string pid, Font font, Brush brush, Point pointLoc)
        {
            RectangleF recLabel = new RectangleF();
            
#if !(PocketPC || WindowsCE || Mobile)
            int lblHeight = pnlHeight / 45;
#else
            int lblHeight = pnlHeight / 15;
#endif

            recLabel.X = pointLoc.X + 5;
            recLabel.Y = pointLoc.Y - lblHeight;
            recLabel.Width = pnlWidth / 6;
            recLabel.Height = lblHeight;

            g.DrawString(pid, font, brush, recLabel);
        }

        #endregion
        #endregion


        #region Calculations
        private Point calcPointLocation(double pX, double pY)
        {
            Point newPoint = new Point();

            if (pX > dWest)
            {
                newPoint.X = (int)(((((pX - dWest) * scrAdj) * increaseSize) + sideLength * .1) - offSetX);
            }
            else
            {
                newPoint.X = (int)((((pX - dWest) * increaseSize) + sideLength * .1) - offSetX);
            }

            if (pY > dSouth)
            {
                newPoint.Y = (int)(((((pY - dSouth) * scrAdj) * increaseSize) + sideLength * .1) - offSetY);
            }
            else
            {
                newPoint.Y = (int)((((pY - dSouth) * increaseSize) + sideLength * .1) - offSetY);
            }

            return newPoint;
        }
       
        private void calcFarthestPolyPoints()
        {
            bool firstPoint = true;

            dEast = dWest = dNorth = dSouth = 0;
            latDiff = lonDiff = 0;

            foreach (PolyWPoints poly in polys)
            {
                foreach (TtPoint point in poly.points)
                {
#if !DEBUG
                    if (point.Adjusted)
                    {
                        if (point.AdjX == 0 || point.AdjY == 0)
                            continue;
                    }
                    else
                    {
                        if (point.UnAdjX == 0 || point.UnAdjY == 0)
                            continue;
                    }
#endif

                    if (firstPoint)     //set all coordinates to the first point
                    {

                        if (point.Adjusted)
                        {
                            dEast = point.AdjX;
                            dWest = dEast;
                            dNorth = point.AdjY;
                            dSouth = dNorth;
                        }
                        else
                        {
                            dEast = point.UnAdjX;
                            dWest = dEast;
                            dNorth = point.UnAdjY;
                            dSouth = dNorth;
                        }

                        latDiff = 0;
                        lonDiff = 0;

                        firstPoint = false;
                    }
                    else
                    {
                        if (point.Adjusted)
                        {
                            if (dEast < point.AdjX)
                                dEast = point.AdjX;
                            else if (dWest > point.AdjX)
                                dWest = point.AdjX;

                            if (dNorth < point.AdjY)
                                dNorth = point.AdjY;
                            else if (dSouth > point.AdjY)
                                dSouth = point.AdjY;
                        }
                        else
                        {
                            if (dEast < point.UnAdjX)
                                dEast = point.UnAdjX;
                            else if (dWest > point.UnAdjX)
                                dWest = point.UnAdjX;

                            if (dNorth < point.UnAdjY)
                                dNorth = point.UnAdjY;
                            else if (dSouth > point.UnAdjY)
                                dSouth = point.UnAdjY;
                        }
                    }
                }
            }

            lonDiff = Math.Abs(dEast - dWest);
            latDiff = Math.Abs(dNorth - dSouth);

            polysCenterX = (dWest + (lonDiff / 2));
            polysCenterY = (dNorth - (latDiff / 2));
        }

        private bool inScreen(double pX, double pY)
        {
            return (pX > -1 && pY > -1 && pX <= pnlWidth && pY <= pnlHeight);
        }

        private bool inScreen(Point p)
        {
            return inScreen(p.X, p.Y);
        }
        #endregion


        #region Controls

        private void zoomBar_ValueChanged2(object sender, EventArgs e)
        {
            setZoom(zoomBar.Value);
            drawPanel.Refresh();
        }

        private void drawPanel_Click2(object sender, EventArgs e)
        {
            if (pnlSettings.Visible)
            {
                pnlSettings.Visible = false;
            }
            else
            {
                if (MapValues.mapPolyLabels == Values.EmptyGuid && !ignoreClick)
                {
#if (PocketPC || WindowsCE || Mobile)
                    int pointClickDist = pnlWidth / 20;
#else
                    int pointClickDist = pnlWidth / 60;
#endif


                    drawPN = false;
                    double dist, sDist = int.MaxValue;

                    Point p = drawPanel.PointToClient(MousePosition);
                    foreach (PointName pn in pns)
                    {
                        dist = TtUtils.Distance(calcPointLocation(pn.X, pn.Y), p);
                        if (dist < pointClickDist && dist < sDist)
                        {
                            sDist = dist;
                            drawPN = true;
                            clickedPN = pn;
                            //break;
                        }
                    }
                }
            }

            ignoreClick = false;
            drawPanel.Refresh();
        }

        public void drawPanel_DoubleClick2(object sender, EventArgs e)
        {
            if (!btnSettings.Visible)
                btnSettings.Visible = true;
            else
                btnSettings.Visible = false;

            if (!tmrMovePad.Enabled)
            {
                ShowControls();
            }
            else
            {
                HideControls();
            }
        }

        int oldX, oldY;

        private void drawPanel_MouseDown2(object sender, MouseEventArgs e)
        {
            oldX = e.X;
            oldY = e.Y;
        }

        public void drawPanel_MouseMove2(object sender, MouseEventArgs e)
        {
            if (!pnlSettings.Visible)
            {
                if (e.Button == MouseButtons.Left)
                {
                    moveOffsetX += (e.X - oldX);
                    moveOffsetY += (e.Y - oldY);
                    drawPanel.Refresh();
                }
            }

            if (e.Button != MouseButtons.None)
            {
                //ignoreClick = true;
            }

            oldX = e.X;
            oldY = e.Y;

        }

#if !(PocketPC || WindowsCE || Mobile)
        void MapForm_MouseWheel2(object sender, MouseEventArgs e)
        {
            if(!pnlSettings.Visible)
            {
                int oldVal = zoomBar.Value;

                if (e.Delta < 0)
                {
                    if(zoomBar.Value > zoomBar.Minimum)
                        zoomBar.Value--;
                }
                else
                {
                    if(zoomBar.Value < zoomBar.Maximum)
                        zoomBar.Value++;
                }

                if (zoomBar.Value != oldVal)
                {
                    setZoom(zoomBar.Value);
                    drawPanel.Refresh();
                }
            }
        }
#endif

        public void pnlMoveImage_Click2(object sender, EventArgs e)
        {
            pnlMoveImage.Visible = false;
#if (PocketPC || WindowsCE || Mobile)
            picClose.Visible = false;
#endif
            tmrMovePad.Enabled = false;
            btnSettings.Visible = false;
            timerTick = 0;
            drawPanel.Refresh();
        }

        public void picUp_Click2(object sender, EventArgs e)
        {
            timerTick = 0;

            if (!MapValues.mapMoveInvert)
                moveOffsetY -= 5;
            else
                moveOffsetY += 5;

            drawPanel.Refresh();
        }

        public void picRight_Click2(object sender, EventArgs e)
        {
            timerTick = 0;

            if (!MapValues.mapMoveInvert)
                moveOffsetX += 5;
            else
                moveOffsetX -= 5;

            drawPanel.Refresh();
        }

        public void picDown_Click2(object sender, EventArgs e)
        {
            timerTick = 0;

            if (!MapValues.mapMoveInvert)
                moveOffsetY += 5;
            else
                moveOffsetY -= 5;

            drawPanel.Refresh();
        }

        public void picLeft_Click2(object sender, EventArgs e)
        {
            timerTick = 0;

            if (!MapValues.mapMoveInvert)
                moveOffsetX -= 5;
            else
                moveOffsetX += 5;

            drawPanel.Refresh();
        }

        public void picCenter_Click2(object sender, EventArgs e)
        {
            timerTick = 0;
            moveOffsetX = 0;
            moveOffsetY = 0;
            drawPanel.Refresh();
        }

        public void picClose_Click2(object sender, EventArgs e)
        {
            pnlSettings.Visible = false;
            btnSettings.Visible = false;

            if (!Values.Settings.DeviceOptions.KeepGpsOn)
                endGPSTracking();

            pnlMoveImage.Visible = false;
#if (PocketPC || WindowsCE || Mobile)
            picClose.Visible = false;
#endif
            tmrMovePad.Enabled = false;
            btnSettings.Visible = false;
            timerTick = 0;

            this.Close();
        }

        public void setZoom(int size)
        {
            zoomSize = size;
        }


        private void ShowControls()
        {
            if (!MapValues.mapMyPos || !MapValues.mapFollowPos)
                pnlMoveImage.Visible = true;

#if (PocketPC || WindowsCE || Mobile)
            picClose.Visible = true;
#else
            btnClose.Visible = true;
#endif
            timerTick = 0;
            tmrMovePad.Enabled = true;
            btnSettings.Visible = true;
            zoomBar.Visible = true;

#if (PocketPC || WindowsCE || Mobile)
            lblLoc.Location = new Point(0, drawPanel.Height - 80);
            btnSettings.Location = new Point(
                btnSettings.Location.X,
                drawPanel.Height - 90
                - ((lblLoc.Visible) ? lblLoc.Height : 0));
#else
            lblLoc.Location = new Point(0, drawPanel.Height - 60);
#endif
            

            drawPanel.Refresh();
        }

        private void HideControls()
        {
            pnlMoveImage.Visible = false;

#if (PocketPC || WindowsCE || Mobile)
            picClose.Visible = false;
#else
            btnClose.Visible = false;
#endif

            tmrMovePad.Enabled = false;
            btnSettings.Visible = false;
            zoomBar.Visible = false;
            pnlSettings.Visible = false;

#if(PocketPC || WindowsCE || Mobile)

            lblLoc.Location = new Point(0, drawPanel.Height - 30);
            btnSettings.Location = new Point(
                btnSettings.Location.X,
                drawPanel.Height - 68);
#else
            lblLoc.Location = new Point(0, drawPanel.Height - 16);
#endif

            timerTick = 0;
            drawPanel.Refresh();
        }

        #endregion


        #region Timers
        public void tmrMovePad_Tick2(object sender, EventArgs e)
        {
            timerTick++;

            if (timerTick == 10)
            {
                HideControls();
                timerTick = 0;
            }
        }
        #endregion


        #region ConstantMove

        private void picRight_MouseDown2(object sender, MouseEventArgs e)
        {
            direction = 0;
            initConstMoveTimer();
        }

        private void picRight_MouseUp2(object sender, MouseEventArgs e)
        {
            constMove.Enabled = false;
        }

        private void picDown_MouseDown2(object sender, MouseEventArgs e)
        {
            direction = 1;
            initConstMoveTimer();
        }

        private void picDown_MouseUp2(object sender, MouseEventArgs e)
        {
            constMove.Enabled = false;
        }

        private void picLeft_MouseDown2(object sender, MouseEventArgs e)
        {
            direction = 2;
            initConstMoveTimer();
        }

        private void picLeft_MouseUp2(object sender, MouseEventArgs e)
        {
            constMove.Enabled = false;
        }

        private void picUp_MouseDown2(object sender, MouseEventArgs e)
        {
            direction = 3;
            initConstMoveTimer();
        }

        private void picUp_MouseUp2(object sender, MouseEventArgs e)
        {
            constMove.Enabled = false;
        }


        private void initConstMoveTimer()
        {
            count = 0;
            constMove.Interval = 250;
            constMove.Enabled = true;
        }

        private void constMove_Tick(object sender, EventArgs e)
        {
            if (count > 6 && count < 35 && count % 7 == 0)
            {
                constMove.Interval -= 50;
            }

            switch (direction)
            {
                case 0:
                    picRight_Click2(sender, e);
                    break;
                case 1:
                    picDown_Click2(sender, e);
                    break;
                case 2:
                    picLeft_Click2(sender, e);
                    break;
                case 3:
                    picUp_Click2(sender, e);
                    break;
                default:
                    break;
            }

            count++;
        }
        #endregion


        #region Settings
        private void btnSettings_Click2(object sender, EventArgs e)
        {
            if (!pnlSettings.Visible)
            {
                if (Values.WideScreen)
                    pnlSettings.Location = new Point(pnlSettings.Left, 10);

                chkInvert.Checked = MapValues.mapMoveInvert;
                chkMyPos.Checked = MapValues.mapMyPos;
                chkFollowPos.Checked = MapValues.mapFollowPos;
                chkDetails.Checked = MapValues.mapDetails;
                //chkLabels.Checked = MapValues.mapLabels;

                if (MapValues.mapDetailsUTM)
                {
                    radLatLon.Checked = false;
                    radUTM.Checked = true;
                }
                else
                {
                    radLatLon.Checked = true;
                    radUTM.Checked = false;
                }

                if (MapValues.mapMyPos && MapValues.mapDetails)
                {
                    radUTM.Enabled = true;
                    radLatLon.Enabled = true;
                }
                else
                {
                    radUTM.Enabled = false;
                    radLatLon.Enabled = false;
                }

                pnlSettings.Visible = true;
            }
            else
            {
                pnlSettings.Visible = false;
                drawPanel.Refresh();
            }
        }

        private void btnT5_Click2(object sender, EventArgs e)
        {
            if (!logging)
            {
                btnT5.Text = "Cancel";
                logged = 0;
                logging = true;
                progT5.Value = 0;
                t5Nmea = new List<NmeaBurst>();

            }
            else
            {
                logging = false;
                btnT5.Text = "Take 5";
            }
        }

        private void chkInvert_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapMoveInvert = chkInvert.Checked;
        }
        
        //private void chkLabels_CheckedChanged2(object sender, EventArgs e)
        //{
        //    MapValues.mapLabels = chkLabels.Checked;
        //}

        private void chkMyPos_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapMyPos = chkMyPos.Checked;

            if (MapValues.mapMyPos)
            {
                chkFollowPos.Enabled = true;
                chkDetails.Enabled = true;

                radLatLon.Checked = !MapValues.mapDetailsUTM;
                radUTM.Checked = MapValues.mapDetailsUTM;

                if (MapValues.mapDetails)
                {
                    lblLoc.Visible = true;
                    radLatLon.Enabled = true;
                    radUTM.Enabled = true;
                }
                else
                {
                    lblLoc.Visible = false;
                    radLatLon.Enabled = false;
                    radUTM.Enabled = false;
                }

                startGPSTracking();
            }
            else
            {
                chkFollowPos.Enabled = false;
                chkDetails.Enabled = false;
                radLatLon.Enabled = false;
                radUTM.Enabled = false;
                lblLoc.Visible = false;

                endGPSTracking();
            }
        }

        private void chkFollowPos_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapFollowPos = chkFollowPos.Checked;
        }

        private void chkDetails_CheckStateChanged2(object sender, EventArgs e)
        {
            MapValues.mapDetails = chkDetails.Checked;

            if (MapValues.mapDetails)
            {
                lblLoc.Visible = true;
                radLatLon.Enabled = true;
                radUTM.Enabled = true;
            }
            else
            {
                lblLoc.Visible = false;
                radLatLon.Enabled = false;
                radUTM.Enabled = false;
            }
        }

        private void radLatLon_CheckedChanged2(object sender, EventArgs e)
        {
            if (radLatLon.Checked)
                MapValues.mapDetailsUTM = false;
        }

        private void radUTM_CheckedChanged2(object sender, EventArgs e)
        {
            if (radUTM.Checked)
                MapValues.mapDetailsUTM = true;
        }
        #endregion


        #region GPSLocation

        public void getLoc(TwoTrails.GpsAccess.NmeaBurst b)
        {
            b.CalcRealZone();

            myGpsPosX = b._X;
            myGpsPosY = b._Y;

            if (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - lastDraw > 900)
            {
                if (b.IsValid)
                    ignoreMyPos = false;
                else
                    ignoreMyPos = true;

                try
                {
                    if (MapValues.mapDetails)
                    {
                        if (ignoreMyPos)
                            lblLoc.Text = "Bad GPS Position";

                        if (MapValues.mapDetailsUTM)
                        {
                            lblLoc.Text = String.Format("Zone:{0} {1:F}M {2}, {3:F}M {4}", b._utm_zone, b._X,
                                b._longDir.ToString(), b._Y, b._latDir.ToString());
                        }
                        else
                        {
                            lblLoc.Text = String.Format("Lat: {0}{1}  Lon: {2}{3}", b._latitude.ToString().Substring(0, 8),
                                (b._longDir == EastWest.West) ? ('W') : ('E'), b._longitude.ToString().Substring(0, 8), (b._latDir == NorthSouth.North) ? ('N') : ('S'));
                        }
                    }
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "MapFormLogic", ex.StackTrace);
                }

                drawPanel.Refresh(); 
            }

            if (t5Enabled)
                T5NmeaBurstRecieved(b);

        }

        private void GPSA_BurstReceived(TwoTrails.GpsAccess.NmeaBurst b)
        {
            this.Invoke(new DelegateGotBurst(getLoc), b);
        }

        public void startGPSTracking()
        {
            Values.GPSA.BurstReceived += new GpsAccess.DelegateDeliverBurst(GPSA_BurstReceived);
            tracking = true;

            Values.GPSA.OpenGps(Values.Settings.DeviceOptions.GpsComPort, Values.Settings.DeviceOptions.GpsBaud);
        }

        public void endGPSTracking()
        {
            Values.GPSA.BurstReceived -= new GpsAccess.DelegateDeliverBurst(GPSA_BurstReceived);
            tracking = false;

            if(!Values.Settings.DeviceOptions.KeepGpsOn)
                Values.GPSA.CloseGps();
        }
        #endregion


        #region Take5
        private bool logging;
        private int logged, ignore;
        private long _index;

        TtGroup T5Group;

        TtMetaData CurrMeta;
        Take5Point CurrentPoint;
        TtPoint LastPoint;

        List<NmeaBurst> t5Nmea;

        private void initT5()
        {
            logging = false;
            _index = 0;
            ignore = 0;

            progT5.Value = 0;
            progT5.Minimum = 0;
            progT5.Maximum = Values.Settings.DeviceOptions.Take5NmeaAmount;

            logged = 0;

            t5Nmea = new List<NmeaBurst>();
            CurrentPoint = null;
            CurrMeta = DAL.GetMetaDataByCN(Values.EmptyGuid);

            if (t5PWP.points.Count() > 0)
            {
                LastPoint = t5PWP.points.Last();
                _index = LastPoint.Index + 1;
            }
            else
            {
                LastPoint = null;
                _index = 0;
            }
        }

        private void SavePoint(TtPoint point)
        {
            if (point != null)
            {
                if (TtUtils.PointHasValue(point) || !Values.Settings.ProjectOptions.DropZero)
                {
                    TtUtils.ShowWaitCursor();

                    point = TtUtils.SaveConversion(point, CurrMeta);

                    point.CalculatePoint();
                    point.AdjustPoint();

                    DAL.InsertPoint(point);
                    DAL.SaveNmeaBursts(t5Nmea, point.CN);
                    TtUtils.HideWaitCursor();
                    LastPoint = point;

                    Take5Point invPoint = new Take5Point(point);
                    invPoint.AdjY *= -1;
                    invPoint.UnAdjY *= -1;
                    t5PWP.points.Add(invPoint);
                    allPolyPoints.Add(invPoint);

                    drawPanel.Refresh(); 
                }
            }
        }

        private void CreateNewTake5Point()
        {
            if (t5Nmea.Count >= Values.Settings.DeviceOptions.Take5NmeaAmount)
            {
                double x = 0, y = 0, z = 0;
                int count = 0;

                if (SetupPoint())
                {
                    NmeaBurst tmpBurst;

                    try
                    {
                        for (int i = 0; i < t5Nmea.Count; i++)
                        {
                            if (t5Nmea[i]._Used)
                            {
                                tmpBurst = t5Nmea[i];

                                x += tmpBurst._X;
                                y += tmpBurst._Y;
                                z += tmpBurst._Z;
                                count++;
                            }
                        }

                        x /= count;
                        y /= count;
                        z /= count;

                        double dRMSEx = 0, dRMSEy = 0, dRMSEr = 0;

                        for (int i = 0; i < t5Nmea.Count; i++)
                        {
                            tmpBurst = t5Nmea[i];

                            if (tmpBurst._Used)
                            {
                                dRMSEx += Math.Pow(tmpBurst._X - x, 2);
                                dRMSEy += Math.Pow(tmpBurst._Y - y, 2);
                            }
                        }

                        dRMSEx = Math.Sqrt(dRMSEx / count);
                        dRMSEy = Math.Sqrt(dRMSEy / count);
                        dRMSEr = Math.Sqrt(Math.Pow(dRMSEx, 2) + Math.Pow(dRMSEy, 2));
                        dRMSEr *= Values.RMSE95_COEF;

                        CurrentPoint.UnAdjX = x;
                        CurrentPoint.UnAdjY = y;
                        CurrentPoint.UnAdjZ = z;
                        CurrentPoint.RMSEr = (dRMSEr > Values.Settings.DeviceOptions.MIN_POINT_ACCURACY) ?
                            dRMSEr : Values.Settings.DeviceOptions.DEFAULT_POINT_ACCURACY;
                        CurrentPoint.Time = DateTime.Now;
                        CurrentPoint.MetaDefCN = CurrMeta.CN;

                        SavePoint(CurrentPoint);

                        this.GuiInvoke(() =>
                        {
                            btnT5.Text = "Take 5";
                            progT5.Value = 0;
                        });

                        t5Nmea = new List<NmeaBurst>();
                    }
                    catch (Exception ex)
                    {
                        TtUtils.WriteError(ex.Message, "MapForm:CreateNewTake5Point", ex.StackTrace);
                    }
                }
                else
                {
                    TtUtils.WriteError("SetupPoint Failed, the CurentPoint is NULL", "MapForm");
                }
            }
            else
            {
                TtUtils.WriteError("CreateNewTake5Point Called without enough Nmea Data", "MapForm");
            }
        }

        private bool SetupPoint()
        {
            CurrentPoint = new Take5Point();

            try
            {
                if (LastPoint != null)
                    CurrentPoint.PID = PointNaming.NamePoint(LastPoint, t5PWP.polygon);
                else
                    CurrentPoint.PID = PointNaming.NameFirstPoint(t5PWP.polygon);

                CurrentPoint.PolyCN = t5PWP.polygon.CN;
                CurrentPoint.PolyName = t5PWP.polygon.Name;
                CurrentPoint.OnBnd = true;
                CurrentPoint.Index = _index;

                if (T5Group == null)
                {
                    T5Group = new TtGroup();
                    T5Group.Name = String.Format("Take5_{0}", T5Group.CN.Truncate(8));
                    T5Group.GroupType = GroupType.Take5;

                    DAL.InsertGroup(T5Group);
                }

                CurrentPoint.GroupCN = T5Group.CN;
                CurrentPoint.GroupName = T5Group.Name;

                _index++;
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MapForm:SetupPoint", ex.StackTrace);
                return false;
            }

            return true;
        }


        private void T5NmeaBurstRecieved(GpsAccess.NmeaBurst b)
        {
            if (logging)
            {
                if (logged < Values.Settings.DeviceOptions.Take5NmeaAmount &&
                    (Values.Settings.DeviceOptions.IgnoreFirst ?
                        (Values.Settings.DeviceOptions.IgnoreFirstX - 1 < ignore) : true))
                {
                    b.CalcZone(CurrMeta.Zone);

                    if (TtUtils.FilterBurst(b, Values.Settings.DeviceOptions.Filter_T5_FixType,
                        Values.Settings.DeviceOptions.Filter_T5_DOP_TYPE,
                        Values.Settings.DeviceOptions.Filter_T5_DOP_VALUE))
                    {
                        b._Used = true;
                        logged++;
                    }
                    else
                    {
                        b._Used = false;
                    }

                    t5Nmea.Add(b);

                    this.GuiInvoke(() => { progT5.Value = logged; });

                    if (logged == Values.Settings.DeviceOptions.Take5NmeaAmount)
                    {
                        logging = false;
                        CreateNewTake5Point();
                    }

                    if (Values.Settings.DeviceOptions.Take5FailTrigger &&
                        t5Nmea.Count == Values.Settings.DeviceOptions.Take5NmeaAmount +
                            Values.Settings.DeviceOptions.Take5FailTriggerAmount)
                    {
                        logging = false;

                        foreach (NmeaBurst burst in t5Nmea)
                        {
                            burst._Used = true;
                        }

                        CreateNewTake5Point();
                    }
                }
                else
                    ignore++;
            }
        }

        #endregion
    }
}
