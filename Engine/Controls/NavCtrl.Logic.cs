using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Utilities;
using TwoTrails.BusinessObjects;


namespace TwoTrails.Controls
{
    public partial class NavCtrl : UserControl
    {
        //Consts
        const int SafeDistFromPath = 1;
        const int FarDistFromPathLvl1 = 2;
        const int FarDistFromPathLvl2 = 5;
        const int FarDistFromPathLvl3 = 7;
        const int FarDistFromPathLvl4 = 10;

        const int ProximityDist = 3;    //3 meters


        private DoublePoint _TargetPoint, _LastPoint, _OrigPoint;

        private DoublePoint TargetPoint
        {
            get { return _TargetPoint; }
            set { _TargetPoint = value; }
        }

        private DoublePoint LastPoint
        {
            get { return _LastPoint; }
            set { _LastPoint = value; }
        }

        private DoublePoint OrigPoint
        {
            get { return _OrigPoint; }
            set { _OrigPoint = value; }
        }

        private double _FeetPerMin;
        public double FeetPerMin
        {
            get { return _FeetPerMin; }
            set
            {
                _FeetPerMin = value;
                lblFpm.Text = String.Format("{0:F1}FtpM", _FeetPerMin);
            }
        }

        public double TotalDistance { get; private set; }
        public double DistanceToGo { get; private set; }
        public double LastDistanceToGo { get; private set; }
        public double DistanceFromPath { get; private set; }
        public double LastDistanceFromPath { get; private set; }
        public double DegreesDirectionOff { get; private set; }
        public int DirectionFromPath { get; private set; }

        public bool WrongDirection { get; private set; }
        private int WrongDirectionCounter { get; set; }

        private double _angle;
        private int _position;

        public NavCtrl()
        {
            InitializeComponent();
        }

        public void Init(DoublePoint startPoint, DoublePoint endPoint)
        {
            OrigPoint = startPoint;
            TargetPoint = endPoint;
            TotalDistance = TtUtils.Distance(OrigPoint, TargetPoint);
        }

        public void UpdateLocation(DoublePoint newLoc)
        {
            double lastDistToGo = DistanceToGo;

            DistanceToGo = TtUtils.Distance(newLoc, _TargetPoint);
            lblDistToGo.Text = String.Format("{0:F1}Ft", TtUtils.ConvertToFeetTenths(DistanceToGo, Unit.METERS));

            DistanceFromPath = TtUtils.DistanceFromLine(newLoc, OrigPoint, TargetPoint);

            double distanceFromLastLoc = TtUtils.Distance(newLoc, _LastPoint);

            //angle
            _angle = Math.Atan2(_TargetPoint.X - _LastPoint.X, _TargetPoint.Y - _LastPoint.Y)
                - Math.Atan2(newLoc.X - _LastPoint.X, newLoc.Y - _LastPoint.Y);

            _position = Math.Sign((_LastPoint.X - _TargetPoint.X) * (newLoc.Y - _TargetPoint.Y) -
                (_LastPoint.Y - _TargetPoint.Y) * (newLoc.X - _TargetPoint.X));

            pnlDraw.Refresh();

            LastDistanceToGo = DistanceToGo;
            LastDistanceFromPath = DistanceFromPath;

            _LastPoint = newLoc;
        }

        private void pnlDraw_Paint(object sender, PaintEventArgs e)
        {
            if (Math.Abs(DistanceFromPath) < SafeDistFromPath &&
                Math.Abs(LastDistanceFromPath - DistanceFromPath) < SafeDistFromPath)
            {
                DirectionFromPath = 0;
            }
            else if (DistanceFromPath < SafeDistFromPath)
            {
                DirectionFromPath--;
            }
            else
            {
                DirectionFromPath++;
            }

            if (DistanceToGo > LastDistanceToGo)
            {
                WrongDirectionCounter++;

                if (WrongDirectionCounter > 2)
                    WrongDirection = true;
            }
            else
            {
                WrongDirectionCounter = 0;
                WrongDirection = false;
            }

            DrawAtAngle(_angle, _position, DistanceToGo / TotalDistance * 100.0, e);

            //if within 3 meters, show within 5 meters circle
            if (DistanceToGo < ProximityDist)
            {
                DrawWithinXDist(e);
            }

            /*
            if (WrongDirection)
            {
                DrawWrongDirection(e);
            }
            else if (DirectionFromPath > 0)
            {
                DrawLeft(Math.Abs(DistanceFromPath), e);
            }
            else if (DirectionFromPath < 0)
            {
                DrawRight(Math.Abs(DistanceFromPath), e);
            }
            else
            {
                if(DistanceToGo > 0)
                    DrawForward(Math.Abs(DistanceToGo / TotalDistance * 100.0), e);
            }
            */
        }

        private void DrawAtAngle(double angle, int position, double percentToTarget, PaintEventArgs e)
        {
            Point[] points = new Point[7];

            int extraLength = (percentToTarget > 100) ? (100) : (int)(percentToTarget);

            int height = (60 + extraLength);
            int halfHeight = height / 2;
            int pnlHalfWidth = pnlDraw.Width / 2;
            int pnlHalfHeight = pnlDraw.Height / 2;

            points[0] = new Point(pnlHalfWidth, pnlHalfHeight - halfHeight);
            points[1] = new Point(pnlHalfWidth + 30, pnlHalfHeight - halfHeight + 30);
            points[2] = new Point(pnlHalfWidth + 15, pnlHalfHeight - halfHeight + 30);
            points[3] = new Point(pnlHalfWidth + 15, pnlHalfHeight + halfHeight);
            points[4] = new Point(pnlHalfWidth - 15, pnlHalfHeight + halfHeight);
            points[5] = new Point(pnlHalfWidth - 15, pnlHalfHeight - halfHeight + 30);
            points[6] = new Point(pnlHalfWidth - 30, pnlHalfHeight - halfHeight + 30);

            if (position > 0)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i] = TtUtils.RotatePoint(points[i].X, points[i].Y, -angle, pnlHalfWidth, pnlHalfHeight);
                }
            }
            else
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i] = TtUtils.RotatePoint(points[i].X, points[i].Y, angle, pnlHalfWidth, pnlHalfHeight);
                }
            }

            if(angle < 1 && angle > -1)
                e.Graphics.FillPolygon(new SolidBrush(Color.Black), points);
            else
                e.Graphics.FillPolygon(new SolidBrush(Color.Red), points);
        }

        private void DrawWithinXDist(PaintEventArgs e)
        {
            int pnlHalfWidth = pnlDraw.Width / 2;
            int pnlHalfHeight = pnlDraw.Height / 2;

#if !(PocketPC || WindowsCE || Mobile)
            e.Graphics.DrawEllipse(new Pen(Color.Black, 5),
                new Rectangle(new Point(pnlHalfWidth - 60, pnlHalfHeight - 60),
                    new Size(120, 120)));
            
            e.Graphics.DrawEllipse(new Pen(Color.Black, 5),
                new Rectangle(new Point(pnlHalfWidth - 45, pnlHalfHeight - 45),
                    new Size(90, 90)));
            
            e.Graphics.DrawString("Within 5 Meters", new Font("", 15, FontStyle.Bold), new SolidBrush(Color.Red), new PointF(5, 5));
#else
            e.Graphics.DrawEllipse(new Pen(Color.Black, 5),
                new Rectangle(pnlHalfWidth - 60, pnlHalfHeight - 60, 20, 120));
            
            e.Graphics.DrawEllipse(new Pen(Color.Black, 5),
                new Rectangle(pnlHalfWidth - 45, pnlHalfHeight - 45, 90, 90));

            e.Graphics.DrawString("Within 5 Meters", new Font("", 15, FontStyle.Bold), new SolidBrush(Color.Red), new RectangleF(5, 5, 100, 40));
#endif

        }


        /*
        private void DrawLeft(double distFromPath, PaintEventArgs e)
        {
            Point[] points = new Point[7];

            int extraLength = 0;

            if (distFromPath >= FarDistFromPathLvl1 && distFromPath < FarDistFromPathLvl2)
                extraLength = 25;
            else if (distFromPath >= FarDistFromPathLvl2 && distFromPath < FarDistFromPathLvl3)
                extraLength = 50;
            else if (distFromPath >= FarDistFromPathLvl3 && distFromPath < FarDistFromPathLvl4)
                extraLength = 75;
            else if (distFromPath >= FarDistFromPathLvl4)
                extraLength = 100;

            int width = (100 + extraLength);
            int halfWidth = width / 2;
            int pnlHalfWidth = pnlDraw.Width / 2;


            points[0] = new Point(pnlHalfWidth - halfWidth, 105);
            points[1] = new Point(pnlHalfWidth - halfWidth + 50, 50);
            points[2] = new Point(pnlHalfWidth - halfWidth + 50, 80);
            points[3] = new Point(pnlHalfWidth + halfWidth, 80);
            points[4] = new Point(pnlHalfWidth + halfWidth, 130);
            points[5] = new Point(pnlHalfWidth - halfWidth + 50, 130);
            points[6] = new Point(pnlHalfWidth - halfWidth + 50, 160);

            e.Graphics.FillPolygon(new SolidBrush(Color.Black), points);
        }

        private void DrawRight(double distFromPath, PaintEventArgs e)
        {
            Point[] points = new Point[7];

            int extraLength = 0;

            if (distFromPath >= FarDistFromPathLvl1 && distFromPath < FarDistFromPathLvl2)
                extraLength = 25;
            else if (distFromPath >= FarDistFromPathLvl2 && distFromPath < FarDistFromPathLvl3)
                extraLength = 50;
            else if (distFromPath >= FarDistFromPathLvl3 && distFromPath < FarDistFromPathLvl4)
                extraLength = 75;
            else if (distFromPath >= FarDistFromPathLvl4)
                extraLength = 100;

            int width = (100 + extraLength);
            int halfWidth = width / 2;
            int pnlHalfWidth = pnlDraw.Width / 2;


            points[0] = new Point(pnlHalfWidth + halfWidth, 105);
            points[1] = new Point(pnlHalfWidth + halfWidth - 50, 50);
            points[2] = new Point(pnlHalfWidth + halfWidth - 50, 80);
            points[3] = new Point(pnlHalfWidth - halfWidth, 80);
            points[4] = new Point(pnlHalfWidth - halfWidth, 130);
            points[5] = new Point(pnlHalfWidth + halfWidth - 50, 130);
            points[6] = new Point(pnlHalfWidth + halfWidth - 50, 160);

            e.Graphics.FillPolygon(new SolidBrush(Color.Black), points);
        }

        private void DrawForward(double percentToTarget, PaintEventArgs e)
        {
            Point[] points = new Point[7];

            int extraLength = (percentToTarget > 100)?(100):(int)(percentToTarget);

            int height = (60 + extraLength);
            int halfHeight = height / 2;
            int pnlHalfWidth = pnlDraw.Width / 2;
            int pnlHalfHeight = pnlDraw.Height / 2;


            points[0] = new Point(pnlHalfWidth, pnlHalfHeight - halfHeight);
            points[1] = new Point(pnlHalfWidth + 30, pnlHalfHeight - halfHeight + 30);
            points[2] = new Point(pnlHalfWidth + 15, pnlHalfHeight - halfHeight + 30);
            points[3] = new Point(pnlHalfWidth + 15, pnlHalfHeight + halfHeight);
            points[4] = new Point(pnlHalfWidth - 15, pnlHalfHeight + halfHeight);
            points[5] = new Point(pnlHalfWidth - 15, pnlHalfHeight - halfHeight + 30);
            points[6] = new Point(pnlHalfWidth - 30, pnlHalfHeight - halfHeight + 30);

            e.Graphics.FillPolygon(new SolidBrush(Color.Black), points);
        }

        private void DrawWrongDirection(PaintEventArgs e)
        {
            Point[] points = new Point[12];

            int pnlHalfWidth = pnlDraw.Width / 2;
            int pnlHalfHeight = pnlDraw.Height / 2;
            int halfSize = (pnlDraw.Width <= pnlDraw.Height) ? ((pnlDraw.Width - 40) / 2) : ((pnlDraw.Height - 40) / 2);
            int thickness = 20;
            int halfThick = thickness / 2;

            points[0] = new Point(pnlHalfWidth - halfSize, pnlHalfHeight - halfSize);
            points[1] = new Point(pnlHalfWidth - halfSize + thickness, pnlHalfHeight - halfSize);
            points[2] = new Point(pnlHalfWidth, pnlHalfHeight - halfThick);
            points[3] = new Point(pnlHalfWidth + halfSize - thickness, pnlHalfHeight - halfSize);
            points[4] = new Point(pnlHalfWidth + halfSize, pnlHalfHeight - halfSize);
            points[5] = new Point(pnlHalfWidth + halfThick, pnlHalfHeight);
            points[6] = new Point(pnlHalfWidth + halfSize, pnlHalfHeight + halfSize);
            points[7] = new Point(pnlHalfWidth + halfSize - thickness, pnlHalfHeight + halfSize);
            points[8] = new Point(pnlHalfWidth, pnlHalfHeight + halfThick);
            points[9] = new Point(pnlHalfWidth - halfSize + thickness, pnlHalfHeight + halfSize);
            points[10] = new Point(pnlHalfWidth - halfSize, pnlHalfHeight + halfSize);
            points[11] = new Point(pnlHalfWidth - halfThick, pnlHalfHeight);

            e.Graphics.FillPolygon(new SolidBrush(Color.Red), points);
        }
        */
    }
}
