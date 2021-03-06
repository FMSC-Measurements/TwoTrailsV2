﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TwoTrails.BusinessLogic;
using TwoTrails.BusinessObjects;
using TwoTrails.Engine;
using TwoTrails.DataAccess;
using TwoTrails.Utilities;
using System.Threading;

namespace TwoTrails.BusinessLogic
{
    public class SegmentFactory
    {
        private List<TtPoint> points;
        private Dictionary<string, TtPolygon> polys;
        //private List<TtPoint> origPoints;
        //private DataAccessLayer _db;
        //Dictionary<string, TtMetaData> metas;

        public SegmentFactory(DataAccessLayer dal)
        {
            Dictionary<string, TtMetaData> meta = dal.GetMetaData().ToDictionary(m => m.CN, m => m);
            polys = dal.GetPolygons().ToDictionary(p => p.CN, p => p);

            List<TtPoint> tmpWayPoints = new List<TtPoint>();
            Dictionary<string, TtPoint> tmpPoints = new Dictionary<string, TtPoint>();

            foreach (TtPoint p in dal.GetPoints())
            {
                if (p.op == OpType.WayPoint)
                {
                    p.CalculatePoint();
                    p.AdjustPoint();
                    tmpWayPoints.Add(p);
                }
                else
                {
                    tmpPoints.Add(p.CN, p);

                    if (p.IsTravType())
                    {
                        ((SideShotPoint)p).Declination = meta[p.MetaDefCN].magDec;
                    }
                }
            }

            if (tmpWayPoints.Count > 0)
            {
                dal.SavePoints(tmpWayPoints, tmpWayPoints);
            }

            QuondamPoint qp;
            foreach (TtPoint p in tmpPoints.Values)
            {
                if (p.op == OpType.Quondam)
                {
                    qp = p as QuondamPoint;
                    qp.ParentPoint = tmpPoints[qp.ParentCN];
                }
            }

            points = tmpPoints.Values.ToList();
        }

        /*
        private void LoadPointsFromDb()
        {
            List<TtPoint> tmpWayPoints = new List<TtPoint>();
            points = new List<TtPoint>();
            foreach (TtPoint p in _db.GetPoints())
            {
                if (p.op == OpType.WayPoint)
                {
                    p.AdjustPoint();
                    tmpWayPoints.Add(p);
                }
                else
                {
                    points.Add(p);
                }
            }

            _db.SavePoints(tmpWayPoints);


            //points = points.FilterOut(OpType.WayPoint);

            metas = _db.GetMetaData().ToDictionary(m => m.CN, m => m);
            foreach (SideShotPoint point in points.Where(p => p.IsTravType()).Cast<SideShotPoint>())
            {
                point.Declination = metas[point.MetaDefCN].magDec;
            }

            Dictionary<string, TtPoint> tmpPoints = points.ToDictionary(p => p.CN, p => p);

            foreach (QuondamPoint p in points.FilterOnly(OpType.Quondam).Cast<QuondamPoint>())
            {
                p.ParentPoint = tmpPoints[p.ParentCN];
            }

            origPoints = new List<TtPoint>(points);
        }
        */

        public bool HasNext()
        {
            return points.Count > 0;
        }

        public Segment Next()
        {
            if (!HasNext())
                return null;

            int index = 0;
            Segment seg = new Segment(polys);
            TtPoint prev = points[index];
            index++;

            seg.Add(prev);
            bool finished = false;
            bool travStarted = false;
            bool startTypeFound = (prev.IsGpsType() || (prev.op == OpType.Quondam &&
                ((QuondamPoint)prev).ParentPoint.IsGpsType()));
            bool SavePrev = false;

            TtPoint current;
            string currentPolygon = prev.PolyCN;
            if (index == points.Count)
                points.Remove(prev);

            while (index < points.Count && !finished)
            {
                current = points[index];
                if (currentPolygon != current.PolyCN)
                {
                    finished = true;
                    points.Remove(prev);
                    continue;
                }

                OpType tmpOp = current.op;
                TtPoint tmpQp = null;

                while (tmpOp == OpType.Quondam)
                {
                    if (tmpQp == null)
                        tmpQp = ((QuondamPoint)current).ParentPoint;
                    else
                        tmpQp = ((QuondamPoint)tmpQp).ParentPoint;

                    tmpOp = tmpQp.op;
                }

                switch (tmpOp)
                {
                    case OpType.GPS:
                    case OpType.WayPoint:
                    case OpType.Walk:
                    case OpType.Take5:
                        {
                            if (seg.Count == 1)                         
                            {
                                if (startTypeFound) //Already have a point (and only 1), Segment is finished   
                                {
	                                finished = true; 
                                }
                                else //left over trav point from a sideshot
                                {
                                    seg = new Segment(polys);
                                    seg.Add(current);
                                    startTypeFound = true;
                                }
                            }
                            else if (travStarted) //Or we are at the closing end of a traverse
                            {
                                finished = true;
                                seg.Add(current);
                            }
                            else
                            {
                                throw new Exception("2nd GPS type without trav start");
                            }

                            points.Remove(prev);
                            index--;
                            prev = current;
                            break;
                        }
                    case OpType.Traverse:
                        {
                            if ( prev.op == OpType.Traverse ||
                                
                                prev.op == OpType.Quondam && ((QuondamPoint)prev).ParentOp == OpType.Traverse)
                            {
                                //finished = true;
                                seg.Add(current);

                                points.Remove(prev);
                            }
                            else
                            {
                                seg.Add(current);

                                if (startTypeFound)
                                    travStarted = true;

                                if (!SavePrev)
                                {
                                    if (points.Count == 1)
                                        points.Remove(current);
                                    points.Remove(prev);
                                }
                                else
                                {
                                    SavePrev = false;
                                    index++;
                                }
                            }

                            prev = current;
                            break;
                        }
                    case OpType.SideShot:
                        {
                            if (seg.Count == 1) //Only the parent point for this sideshot so far
                            {
                                seg.Add(current);
                                points.Remove(current); // don't remove the parent point, may be needed again
                                finished = true;
                            }
                            else // skip this point
                            {
                                SavePrev = true;
                                index++;
                            }
                            break;
                        }
                }

            }

            return seg;
        }
            
    }
}