using System;
using System.Collections.Generic;
using System.Text;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;
using System.Linq;
using TwoTrails.Utilities;
using TwoTrails.Engine;

namespace TwoTrails.BusinessLogic
{
    public class Segment
    {
        private List<TtPoint> points;
        private Dictionary<string, TtPolygon> polys;
        private int _weight = -1;

        private bool _calculated;
        public bool IsCalculated
        {
            get { return _calculated; }
        }

        private bool _adjusted;
        public bool IsAdjusted
        {
            get { return _adjusted; }
        }


        public int Count
        {
            get { return points.Count; }
        }


        public Segment(Dictionary<string, TtPolygon> polys)
        {
            points = new List<TtPoint>();
            this.polys = polys;
        }


        public void Add(TtPoint pt)
        {
            points.Add(pt);
            _calculated = false;
            _weight = -1;
        }

        public TtPoint this[int index]
        {
            get { return points[index]; }
        }



        public bool Adjust()
        {
            if (points.Count == 0)
            {
                _adjusted = true;
            }
            else if (!_calculated)
            {
                _adjusted = false;
            }
            else
            {
                int len = points.Count;
                TtPoint startPoint = points[0];

                if (len == 1)
                    return startPoint.AdjustPoint();

                if (!startPoint.Adjusted)
                    startPoint.AdjustPoint();

                TtPoint endPoint = points[len - 1];
                if (endPoint.op == TwoTrails.Engine.OpType.SideShot)
                {
                    if (!endPoint.Adjusted)
                    {
                        _adjusted = AdjustSideShot(startPoint, (SideShotPoint)endPoint);
                    }
                }
                else if (points.Count > 2 && points[1].op == TwoTrails.Engine.OpType.Traverse)
                {
                    _adjusted = AdjustTraverse();
                }
                else //is quondam or random points
                {
                    for (int i = 1; i < len; i++)
                    {
                        points[i].AdjustPoint();
                    }
                }
            }

            return _adjusted;
        }

        private bool AdjustTraverse()
        {
            double lastX, lastY, lastZ, currX, currY, currZ, deltaX, deltaY, deltaZ, deltaDistance, leg_length,
                adj_perimeter, deltaX_Correction, deltaY_Correction, deltaZ_Correction, adjX, adjY, adjZ;
            

            TtPoint currPoint, tempPoint;

            tempPoint = points[points.Count - 1];

            //X,Y of the final point of the travers, should be the closing point if it exists
            lastX = tempPoint.UnAdjX; //GPS Coords at the end of the traverse
            lastY = tempPoint.UnAdjY;
            lastZ = tempPoint.UnAdjZ;

            adj_perimeter = GetAdjustmentPerimeter();

            //No adjustment if there isn't a closing point
            if (tempPoint.op == TwoTrails.Engine.OpType.Traverse)
            {
                deltaX = 0;
                deltaY = 0;
                deltaZ = 0;
            }
            else
            {
                tempPoint = points[points.Count - 2];

                deltaX = lastX - tempPoint.UnAdjX;
                deltaY = lastY - tempPoint.UnAdjY;
                deltaZ = lastZ - tempPoint.UnAdjZ;
            }

            //deltaDistance = trav closure error
            deltaDistance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            deltaX_Correction = deltaX / adj_perimeter;
            deltaY_Correction = deltaY / adj_perimeter;
            deltaZ_Correction = deltaZ / adj_perimeter;

            tempPoint = points[0];

            //Loop through the points and apply the correction
            lastX = tempPoint.UnAdjX;
            lastY = tempPoint.UnAdjY;
            lastZ = tempPoint.UnAdjZ;
            leg_length = 0;

            double acc = TtUtils.GetPointAcc(tempPoint, polys);
            double accEnd = TtUtils.GetPointAcc(points[points.Count - 1], polys);
            double accDiff = (accEnd - acc) / (points.Count - 1);

            for (int i = 0; i < points.Count; i++)
            {
                currPoint = points[i];

                if (i == points.Count - 1 && currPoint.op == TwoTrails.Engine.OpType.Quondam)
                {
                    break;
                }

                if (currPoint.IsGpsType())
                {
                    if (!currPoint.Adjusted)
                        points[i].AdjustPoint();
                    continue;
                }

                acc += accDiff;

                currX = currPoint.UnAdjX;
                currY = currPoint.UnAdjY;
                currZ = currPoint.UnAdjZ;

                leg_length += Math.Sqrt(Math.Pow(currX - lastX, 2) + Math.Pow(currY - lastY, 2));
                adjX = leg_length * deltaX_Correction + currX;
                adjY = leg_length * deltaY_Correction + currY;
                adjZ = leg_length * deltaZ_Correction + currZ;

                currPoint.AdjX = adjX;
                currPoint.AdjY = adjY;
                currPoint.AdjZ = adjZ;

                if (currPoint.IsTravType())
                {
                    //((SideShotPoint)currPoint).Accuracy = deltaDistance * leg_length / adj_perimeter;
                    
                    //or distribute between first and last gps value
                    //startPoint + (diff(start, end) / pointCount - 2)
                    ((SideShotPoint)currPoint).Accuracy = acc;

                    ((SideShotPoint)currPoint).SetAdjusted();
                }

                lastX = currX;
                lastY = currY;
                lastZ = currZ;
            }

            return true;
        }

        private bool AdjustSideShot(TtPoint prevPoint, SideShotPoint ss)
        {
            ss.Accuracy = TtUtils.GetPointAcc(prevPoint, polys);

            return ss.AdjustPoint(prevPoint);
        }

        public double GetAdjustmentPerimeter()
        {
            if (points.Count < 1)
                return 0;
            double adjustment_perim = 0;

            double currX, currY, lastX, lastY;
            lastX = points[0].UnAdjX;
            lastY = points[0].UnAdjY;
            //loop through all the points, stop if we get to the closing gps
            for (int i = 1; i < points.Count && points[i].op == TwoTrails.Engine.OpType.Traverse; i++)
            {
                currX = points[i].UnAdjX;
                currY = points[i].UnAdjY;

                adjustment_perim += Math.Sqrt(Math.Pow(currX - lastX, 2) + Math.Pow(currY - lastY, 2));

                lastX = currX;
                lastY = currY;
            }

            return adjustment_perim;
        }

        public bool Calculate()
        {
            if (points.Count == 0)
            {
                _calculated = true;
                return true;
            }

            TtPoint firstPoint = points[0];

            bool success = firstPoint.Calculated;
            switch (firstPoint.op)
            {
                case TwoTrails.Engine.OpType.GPS:
                case TwoTrails.Engine.OpType.WayPoint:
                case TwoTrails.Engine.OpType.Take5:
                case TwoTrails.Engine.OpType.Walk:
                case TwoTrails.Engine.OpType.Quondam:
                    {
                        if (!success)
                            success = firstPoint.CalculatePoint();
                        break;
                    }
                case TwoTrails.Engine.OpType.Traverse:
                    {
                        //Must be a trav with a SideShot off of it. Must already be calculated.
                        if (!success)
                            return false;
                        break;
                    }
                default: // no sideshots
                    {
                        throw new Exception("Different optype " + firstPoint.op.ToString());
                    }
            }

            int index = 1;
            while (index < points.Count)
            {
                TtPoint p = points[index];
                switch (p.op)
                {
                    case TwoTrails.Engine.OpType.GPS:
                    case TwoTrails.Engine.OpType.WayPoint:
                    case TwoTrails.Engine.OpType.Walk:
                    case TwoTrails.Engine.OpType.Take5:
                    case TwoTrails.Engine.OpType.Quondam:
                        {
                            success &= p.CalculatePoint();
                            break;
                        }
                    case TwoTrails.Engine.OpType.Traverse:
                    case TwoTrails.Engine.OpType.SideShot:
                        {
                            success &= p.CalculatePoint(points[index - 1]);
                            break;
                        }
                    default:
                        {
                            throw new NotImplementedException("Unknown optype in the Segment, can't calculate");
                        }
                }

                index++;
            }

            _calculated = success;

            return _calculated;
        }


        /// <summary>
        /// High weight indicates that this segment is likely to be calculated/adjusted easily. 
        /// Lower weight indicates that the segment has dependencies in other segments and may
        /// not be able to be calculated on the first run through. High weight segments should be
        /// calculated and adjusted first.
        /// </summary>
        public int Weight
        {
            get
            {
                if (_weight < 0)
                    _weight = CalculateWeight();
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }


        //optimized
        private int CalculateWeight()
        {
            int count = points.Count;
            TtPoint fPoint = points[0];

            
            if (count < 3)
            {
                if (fPoint.IsGpsType())
                {
                    return 10;
                }
                else if (fPoint.op == OpType.Quondam)
                {
                    if (((QuondamPoint)fPoint).ParentPoint.IsGpsType())
                    {
                        return 8;
                    }

                    return 4;
                }

                return 3;
            }
            else
            {
                if (points.AreAllQndmType())
                {
                    return 2;
                }
                else
                {
                    TtPoint lPoint = points[points.Count - 1];

                    bool fGPS = fPoint.IsGpsType(), lGPS = lPoint.IsGpsType();

                    if (fGPS && lGPS || fGPS && (lPoint.op == OpType.Quondam && ((QuondamPoint)lPoint).ParentCN == fPoint.CN))
                    {
                        return 9;
                    }
                    else if ((fGPS || (fPoint.op == TwoTrails.Engine.OpType.Quondam &&
                        ((QuondamPoint)fPoint).ParentPoint.IsGpsType())) &&

                        (lGPS || (lPoint.op == TwoTrails.Engine.OpType.Quondam &&
                        ((QuondamPoint)lPoint).ParentPoint.IsGpsType())))
                    {
                        return 7;
                    }
                    else
                    {
                        if (lPoint.IsTravType())
                            return 3;
                        else
                            return 4;   //is quondam
                    }
                }
            }
        }

        public override string ToString()
        {
            if (points != null || points.Count == 0)
            {
                if (points.Count == 1)
                    return String.Format("{0}:{1}", points[0].op, points[0].PID);
                else
                    return String.Format("{0} to {1}", points[0].PID, points[points.Count - 1].PID);
            }
            else
                return "No Points";
        }
    }
}