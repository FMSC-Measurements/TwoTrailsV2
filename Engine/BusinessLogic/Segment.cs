using System;
using System.Collections.Generic;
using System.Text;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;
using System.Linq;
using TwoTrails.Utilities;

namespace TwoTrails.BusinessLogic
{
    public class Segment
    {
        private List<TtPoint> points;
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


        public Segment()
        {
            _calculated = true;
            points = new List<TtPoint>();
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
                TtPoint starting = points[0];

                if (len == 1)
                    return starting.AdjustPoint();

                if (!starting.Adjusted)
                    starting.AdjustPoint();

                TtPoint ending = points[len - 1];
                if (ending.op == TwoTrails.Engine.OpType.SideShot)
                {
                    if (!starting.Adjusted)
                    {
                        bool success = starting.AdjustPoint();
                        if (!success)
                        {
                            _adjusted = false;
                            return _adjusted;
                        }
                    }

                    _adjusted = AdjustSideShot();
                    return _adjusted;
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

        private bool AdjustTraverse()
        {
            double lastX, lastY, lastZ, currX, currY, currZ, deltaX, deltaY, deltaZ, deltaDistance, leg_length,
                adj_perimeter, deltaX_Correction, deltaY_Correction, deltaZ_Correction, adjX, adjY, adjZ;
            //X,Y of the final point of the travers, should be the closing point if it exists
            lastX = points[points.Count - 1].UnAdjX; //GPS Coords at the end of the traverse
            lastY = points[points.Count - 1].UnAdjY;
            lastZ = points[points.Count - 1].UnAdjZ;

            TtPoint currPoint, tempPoint;

            adj_perimeter = GetAdjustmentPerimeter();

            //No adjustment if there isn't a closing point
            if (points[points.Count - 1].op == TwoTrails.Engine.OpType.Traverse)
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

            //Loop through the points and apply the correction
            lastX = points[0].UnAdjX;
            lastY = points[0].UnAdjY;
            lastZ = points[0].UnAdjZ;
            leg_length = 0;

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

                currX = currPoint.UnAdjX;
                currY = currPoint.UnAdjY;
                currZ = currPoint.UnAdjZ;

                leg_length += Math.Sqrt(Math.Pow(currX - lastX, 2) + Math.Pow(currY - lastY, 2));
                adjX = leg_length * deltaX_Correction + currX;
                adjY = leg_length * deltaY_Correction + currY;
                adjZ = leg_length * deltaZ_Correction + currZ;

                points[i].AdjX = adjX;
                points[i].AdjY = adjY;
                points[i].AdjZ = adjZ;

                if (currPoint.IsTravType())
                {
                    ((SideShotPoint)points[i]).Accuracy = deltaDistance * leg_length / adj_perimeter;
                    ((SideShotPoint)points[i]).SetAdjusted();
                }

                lastX = currX;
                lastY = currY;
                lastZ = currZ;
            }

            return true;
        }

        private bool AdjustSideShot()
        {
            TtPoint p1 = points[0];
            SideShotPoint ss = (SideShotPoint)points[1];

            if (p1.UnAdjX == p1.AdjX &&
                p1.UnAdjY == p1.AdjY &&
                p1.UnAdjZ == p1.AdjZ)
            {
                return ss.AdjustPoint();
            }
            return ss.AdjustPoint(p1);
        }

        public bool Calculate()
        {
            if (points.Count == 0)
            {
                _calculated = true;
                return true;
            }
            bool success = true;
            TtPoint firstPoint = points[0];

            success = firstPoint.Calculated;
            switch (firstPoint.op)
            {
                case TwoTrails.Engine.OpType.GPS:
                case TwoTrails.Engine.OpType.WayPoint:
                case TwoTrails.Engine.OpType.Take5:
                case TwoTrails.Engine.OpType.Walk:
                    {
                        if (!success)
                            success = firstPoint.CalculatePoint();
                        break;
                    }
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
                default:
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
                        {
                            success = success && p.CalculatePoint();
                            break;
                        }
                    case TwoTrails.Engine.OpType.Traverse:
                    case TwoTrails.Engine.OpType.SideShot:
                        {
                            success = success && p.CalculatePoint(points[index - 1]);
                            break;
                        }
                    case TwoTrails.Engine.OpType.Quondam:
                        {
                            success = success && p.CalculatePoint();
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
            return success;
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
                if (_weight == -1)
                    _weight = CalculateWeight();
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        private int CalculateWeight()
        {
            if (points.Count == 0)
                return -1;
            TtPoint first = points[0];
            //Single GPS points are easy to calculate, high weight
            if (points.Count == 1 && (first.IsGpsType()))
                return 10;
            else if (points.Count == 1 && first.op == TwoTrails.Engine.OpType.Quondam)
            {
                //GPS should be calculated before Quondams that depend on them                
                if (((QuondamPoint)first).ParentPoint.IsGpsType())
                    return 7;   //8// gps must be calculated before the quondam
                else
                    return 3;

            }
            else if (points.Count == 1)
            {
                return 3;
            }
            else if (points.Count == 2)
            {
                //If it's a GPS with a trav or SS after, it can be calculated now.
                if (first.IsGpsType())
                    return 10;
                //Otherwise we need to calculate the quondam, and the quondam's parent point first
                else return 3;
            }
            else if (points.Count > 2)
            {
                TtPoint last = null;
                if (points.AreAllQndmType())
                {
                    first = ((QuondamPoint)points[0]).ParentPoint;
                    last = ((QuondamPoint)points[points.Count - 1]).ParentPoint;

                    return 3;
                }
                else
                {
                    last = points[points.Count - 1];
                    if (first.IsGpsType())
                    {
                        //If both the beginning and the end are GPS, then we can calculate the trav now
                        if (last.IsGpsType())
                        {
                            return 10;
                        }
                        //Otherwise there are other things that need to be calculated first
                        else
                        {
                            return 5;
                        }
                    }
                    else
                    {
                        if (last.IsGpsType())
                            return 5;
                        else
                        {
                            if (last.IsTravType())
                                return 3;
                            else
                                return 4;   //is quondam
                        }
                    }
                }
            }
            throw new Exception("???");
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