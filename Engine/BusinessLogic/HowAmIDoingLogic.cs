using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;
using TwoTrails.Engine;

namespace Engine.BusinessLogic
{
    class Leg
    {
        public double Point1Acc { get; private set; }
        public double Point2Acc { get; private set; }
        public double Distance { get; private set; }

        public Leg(TtPoint point1, TtPoint point2, Dictionary<string, TtPolygon> polys)
        {
            Point1Acc = TtUtils.GetPointAcc(point1, polys);
            Point2Acc = TtUtils.GetPointAcc(point2, polys);
            Distance = TtUtils.Distance(point1, point2);
        }

        public double GetAreaError()
        {
            return Distance * (Point1Acc + Point2Acc) / 2;
        }
    }

    public class HowAmIDoingLogic
    {
        HowAmIDoingOptions _options;
        TextWriter _writer;
        StringBuilder _PolyOutput, _PointOutput;

        Dictionary<string, TtPolygon> polys;
        DoublePoint _LastPoint;

        bool traversing;
        double travLength, _travGpsError;
        int travSegs, lastGpsPtName;

        TtPoint _LastTtPoint;
        List<Leg> _Legs, _TravLegs;

        double TotalTravError;
        double TotalGpsError;
        double TotalError;

        public HowAmIDoingLogic(HowAmIDoingOptions options)
        {
            _options = options;
        }

        public void Execute()
        {
            Execute(true);
        }

        public void Execute(bool showpoints)
        {
            if (_options.SaveReport)
                _writer = new StreamWriter(_options.ReportPath);
            else
            {
                _options.ReportText = new StringBuilder();
                _writer = new StringWriter(_options.ReportText);
            }

            _LastPoint = new DoublePoint();

            travLength = 0;
            travSegs = 0;

            TotalTravError = 0;
            TotalGpsError = 0;
            TotalError = 0;


            _writer.WriteLine("Project Summary");

            _writer.WriteLine();

            if(!_options.TtFilePath.IsEmpty())
                _writer.WriteLine("Project File: {0}", _options.TtFilePath);

            _writer.WriteLine("Project Name: {0}", _options.ProjectName);

            _writer.WriteLine("Region: {0}", _options.Region);

            _writer.WriteLine("Forest: {0}", _options.Forest);

            _writer.WriteLine("District: {0}", _options.District);

            _writer.WriteLine("Year: {0}", _options.Year);

            if(!_options.ProjectDescription.IsEmpty())
                _writer.WriteLine("Description: {0}", _options.ProjectDescription);

            _writer.WriteLine("Created on: TT {0}", _options.Data.GetProjectTtStartVersion());
            _writer.WriteLine("Running on: TT {0}", Values.TwoTrailsVersion);

            _writer.WriteLine();

            _writer.WriteLine("**** GPS Error can be divided by 2 if an appropriate ANGLE POINT METHOD is used instead of the WALK METHOD. ****");
            _writer.Write("**** Appropriate means that the boundary legs are reasonably ");
            _writer.Write("long between vertices where the boundary direction changes ");
            _writer.Write("by 90 degree angles where possible and changes at least ");
            _writer.WriteLine("more than 30 degrees most of the time. ****");
            _writer.WriteLine("**** If the unit is totally a direction distance-traverse. Use only the traverse contribution for area-error. ****");
            _writer.WriteLine("**** Points with asterisks are OFF boundary points. ****");

            polys = _options.Data.GetPolygons().ToDictionary(p => p.CN, p => p);

            foreach(TtPolygon poly in polys.Values)
            {
                _PointOutput = new StringBuilder();
                _PolyOutput = new StringBuilder();

                _writer.WriteLine();

                List<TtPoint> points = _options.Data.GetPointsInPolygon(poly.CN).FilterOut(OpType.WayPoint);

                TotalError = TotalTravError = TotalGpsError = _travGpsError = 0;
                traversing = false;
                _LastTtPoint = null;

                if (points.Count > 0)
                {
                    _LastTtPoint = null;
                    _Legs = new List<Leg>();

                    for (int j = 0; j < points.Count; j++)
                    {
                        OutputPointSummary(points[j], false, showpoints);
                    }

                    TtPoint pt = points[0];

                    for (int k = 0; k < points.Count; k++)
                    {
                        if (points[k].OnBnd)
                        {
                            pt = points[k];
                            break;
                        }
                    }

                    if (!pt.SameAdjLocation(_LastTtPoint))
                    {
                        //if (_LastTtPoint.op == OpType.SideShot || pt.op == OpType.SideShot)
                        //     _Legs.Add(new Leg(_LastTtPoint, pt, polys[_LastTtPoint.PolyCN].PolyAccu, polys[pt.PolyCN].PolyAccu));
                        //else
                            _Legs.Add(new Leg(_LastTtPoint, pt, polys));
                    }

                    foreach(Leg leg in _Legs)
                    {
                        TotalGpsError += leg.GetAreaError();
                    }

                    TotalError = TotalGpsError + TotalTravError;

                    OutputPolygonSummary(poly);
                    _PolyOutput.AppendLine();
                }
                else
                {
                    OutputPolygonSummary(poly);
                    _PolyOutput.AppendLine();

                    _PolyOutput.AppendLine("No Used Points in Polygon.");
                }

                _writer.Write(_PolyOutput);

                _writer.WriteLine(_PointOutput);
            }

            _writer.Close();
            _writer.Dispose();

            GC.Collect();
        }

        private void closeTraverse(TtPoint pt)
        {
            double closeError = TtUtils.Distance(_LastPoint.X, _LastPoint.Y,
                                    pt.UnAdjX, pt.UnAdjY);
            double travError = travLength / closeError;

            _PointOutput.AppendLine(String.Format("\tTraverse Total Segments: {0}", travSegs));
            _PointOutput.AppendLine(String.Format("\tTraverse Total Distance: {0:F4} feet.",
                TtUtils.ConvertToFeetTenths(travLength, Unit.METERS)));
            _PointOutput.AppendLine(String.Format("\tTraverse Closing Distance: {0:F4} feet.",
                TtUtils.ConvertToFeetTenths(closeError, Unit.METERS)));
            _PointOutput.AppendLine(String.Format("\tTraverse Close Error: 1 part in {0}.",
                Math.Round(travError)));

            TotalTravError += (travLength * closeError / 2);

            traversing = false;

            _TravLegs.Add(new Leg(_LastTtPoint, pt, polys));

            if (_TravLegs.Count > 0)
            {
                double travStartAcc = _TravLegs[0].Point1Acc;
                double travEndAcc = _TravLegs[_TravLegs.Count - 1].Point2Acc;
                double diff = travEndAcc - travStartAcc;
                double sumLegLen = 0;
                double legacc;

                foreach (Leg leg in _TravLegs)
                {
                    sumLegLen += leg.Distance;
                    legacc = (travStartAcc + Math.Abs((sumLegLen / travLength) * diff));
                    _travGpsError += leg.Distance * legacc;
                }

                TotalGpsError += _travGpsError;
            }
        }

        private void OutputPointSummary(TtPoint pt, bool fromQuondam, bool showpoints)
        {
            switch (pt.op)
            {
                case TwoTrails.Engine.OpType.GPS:
                case TwoTrails.Engine.OpType.Take5:
                case TwoTrails.Engine.OpType.Walk:
                case TwoTrails.Engine.OpType.WayPoint:
                    {
                        lastGpsPtName = pt.PID;

                        if (pt.OnBnd)
                        {
                            if (traversing)
                            {
                                closeTraverse(pt);
                                _LastTtPoint = pt;
                            }
                            else
                            {
                                if (_LastTtPoint == null)
                                {
                                    _LastTtPoint = pt;
                                }
                                else
                                {
                                    if (_LastTtPoint != null && _LastTtPoint.OnBnd)
                                    {
                                        _Legs.Add(new Leg(_LastTtPoint, pt, polys));
                                    }

                                    _LastTtPoint = pt;
                                }
                            }

                            _LastPoint = new DoublePoint(pt.UnAdjX, pt.UnAdjY);
                        }
                        else
                        {
                            _LastTtPoint = pt;
                        }

                        if (!fromQuondam && showpoints)
                        {
                            _PointOutput.AppendFormat("Point {0}: {2} {1}- ", pt.PID, pt.op.ToString(), pt.OnBnd ? " " : "*");

                            _PointOutput.AppendLine(String.Format("Accuracy is {0:F4} meters.", TtUtils.GetPointAcc(pt, polys)));
                        }
                        break;
                    }
                case TwoTrails.Engine.OpType.Traverse:
                    {
                        if (_LastTtPoint == null)
                        {
                            _LastTtPoint = pt;
                            break;
                        }

                        if (pt.OnBnd)
                        {
                            double? polyAcc = polys[pt.PolyCN].PolyAccu;

                            if (!traversing)
                            {
                                travSegs = 0;

                                travLength = TtUtils.Distance(_LastPoint.X, _LastPoint.Y, pt.UnAdjX, pt.UnAdjY);
                                _LastPoint = new DoublePoint(pt.UnAdjX, pt.UnAdjY);
                                traversing = true;

                                if (showpoints)
                                {
                                    _PointOutput.AppendLine("Traverse Start:");
                                }

                                _TravLegs = new List<Leg>();
                                if (_LastTtPoint != null && _LastTtPoint.OnBnd)
                                {
                                    _Legs.Add(new Leg(_LastTtPoint, pt, polys));
                                }
                            }
                            else
                            {
                                travLength += TtUtils.Distance(_LastPoint.X, _LastPoint.Y, pt.UnAdjX, pt.UnAdjY);
                                _LastPoint = new DoublePoint(pt.UnAdjX, pt.UnAdjY);

                                if (_LastTtPoint != null && _LastTtPoint.OnBnd)
                                {
                                    _Legs.Add(new Leg(_LastTtPoint, pt, polys));
                                }
                            }
                        }

                        _LastTtPoint = pt;

                        travSegs++;
                        break;
                    }
                case TwoTrails.Engine.OpType.SideShot:
                    {
                        if (showpoints)
                        {
                            _PointOutput.AppendLine(String.Format("Point {0}: {2} SideShot from Point {1}.", pt.PID, lastGpsPtName, pt.OnBnd ? " " : "*"));
                        }

                        if (_LastTtPoint != null && _LastTtPoint.OnBnd)
                        {
                            _Legs.Add(new Leg(_LastTtPoint, pt, polys));
                        }

                        _LastTtPoint = pt;

                        _LastPoint = new DoublePoint(pt.UnAdjX, pt.UnAdjY);

                        break;
                    }
                case TwoTrails.Engine.OpType.Quondam:
                    {
                        QuondamPoint qp = pt as QuondamPoint;

                        if (qp.ParentOp == OpType.Traverse && _LastTtPoint != null)
                        {
                            if (traversing)
                            {
                                closeTraverse(pt);
                            }
                            else
                            {
                                if (_LastTtPoint != null && _LastTtPoint.OnBnd)
                                {
                                    _Legs.Add(new Leg(_LastTtPoint, pt, polys));
                                }
                                _LastTtPoint = pt;
                            }
                        }
                        else
                        {
                            OutputPointSummary(qp.ParentPoint, true, showpoints);
                        }

                        if (showpoints)
                        {
                            _PointOutput.AppendLine(String.Format("Point {0}: {2} Quondam to Point {1} in {3}.", pt.PID,
                                qp.ParentPID, pt.OnBnd ? " " : "*", qp.ParentPoly));
                        }

                        _LastTtPoint = pt;
                        break;
                    }
            }
        }

        private void OutputPolygonSummary(TtPolygon p)
        {
            _PolyOutput.AppendLine(String.Format("----- Polygon ID: {0} -----", p.Name));

            if (!p.Description.IsEmpty())
                _PolyOutput.AppendLine(String.Format("Description: {0}", p.Description));

            if (p.Area > 0)
            {
                _PolyOutput.AppendLine();
                _PolyOutput.AppendLine(String.Format("The polygon area is: {2}{0:F4} Ha ({1:F4} ac).",
                    TtUtils.ConvertMeters2ToHa(p.Area), TtUtils.ConvertMeters2ToAcres(p.Area), _options.SaveReport ? "                " : ""));
                _PolyOutput.AppendLine(String.Format("The polygon perimeter is: {2}{0:F4} M ({1:F4} ft).", p.Perimeter,
                    TtUtils.ConvertToFeetTenths(p.Perimeter, Unit.METERS), _options.SaveReport ? "           " : ""));
            }

            if (TotalError > 0)
            {
                _PolyOutput.AppendLine(String.Format("The polygon area-error area is: {2}{0:F5} Ha ({1:F4} ac).",
                    TtUtils.ConvertMeters2ToHa(TotalError), TtUtils.ConvertMeters2ToAcres(TotalError),
                _options.SaveReport ? "     " : ""));

                _PolyOutput.AppendLine(String.Format("Ratio of area-error-area to area is: {0:F2}%.",
                    TotalError / p.Area * 100));
            }

            if (TotalGpsError > 0)
            {
                _PolyOutput.AppendLine();
                _PolyOutput.AppendLine(String.Format("GPS Contribution to area-error area: {2}{0:F5} Ha ({1:F4} ac).",
                    TtUtils.ConvertMeters2ToHa(TotalGpsError), TtUtils.ConvertMeters2ToAcres(TotalGpsError),
                    _options.SaveReport ? "                 " : ""));

                _PolyOutput.AppendLine(String.Format("GPS Contribution Ratio of area-error to area: {1}{0:F2}%.",
                    TotalGpsError / p.Area * 100, _options.SaveReport ? "        " : ""));
            }

            if (TotalTravError > 0)
            {
                _PolyOutput.AppendLine(" ");
                _PolyOutput.AppendLine(String.Format("Traverse Contribution to area-error area: {2}{0:F5} Ha ({1:F4} ac).",
                    TtUtils.ConvertMeters2ToHa(TotalTravError), TtUtils.ConvertMeters2ToAcres(TotalTravError),
                    _options.SaveReport ? "            " : ""));

                _PolyOutput.AppendLine(String.Format("Traverse Contribution Ratio of area-error to area: {1}{0:F2}%.",
                    TotalTravError / p.Area * 100, _options.SaveReport ? "   " : ""));
            }
        }
    }
}
