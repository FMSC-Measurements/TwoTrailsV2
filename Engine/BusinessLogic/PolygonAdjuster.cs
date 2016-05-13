using System;
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
    public static class PolygonAdjuster
    {
        public static bool CanAdjust(DataAccessLayer dal)
        {
            foreach (TtPolygon poly in dal.GetPolygons())
            {
                if (dal.GetPointCount(poly.CN) > 0)
                {
                    TtPoint p = dal.GetFirstPointInPolygon(poly.CN);
                    if (p != null)
                    {
                        if (p.IsTravType())
                        {
                            System.Windows.Forms.MessageBox.Show(String.Format("Polygon {0} can not start with a {1}. Point {2} must derive from a GPS type or Quondam.",
                                poly.Name, p.op.ToString(), p.PID), "Bad Polygon Start");
                            return false;
                        }
                        /*
                        else if (p.op == OpType.Quondam)
                        {
                            if (((QuondamPoint)p).ParentOp == OpType.Traverse)
                            {
                                System.Windows.Forms.MessageBox.Show(String.Format("Polygon {0} can not start with a Quondam to a Traverse. Point {2} must derive from a GPS type.",
                                    poly.Name, p.op.ToString(), p.PID), "Bad Polygon Start");
                                return false;
                            }
                        }
                        */
                    }
                    else
                    {
                        //no point
                        return false;
                    }
                }
            }

            return true;
        }


        public static void Adjust(DataAccessLayer dal)
        {
            Adjust(dal, false, null);
        }

        public static void Adjust(DataAccessLayer dal, bool updateIndexes)
        {
            Adjust(dal, updateIndexes, null);
        }

        public static void Adjust(DataAccessLayer dal, System.Windows.Forms.Form form)
        {
            Adjust(dal, false, form);
        }

        public static void Adjust(DataAccessLayer dal, bool updateIndexes, System.Windows.Forms.Form form)
        {
            if (form != null && !Values.AdjustingPolygons)
            {
                new Thread(() =>
                {
                    Values.GlobalCancelToken = false;
                    Values.AdjustingPolygons = true;

#if !(PocketPC || WindowsCE || Mobile)
                    Values.UpdateStatusText("Adjusting Polygons (Do NOT close Program)");
#endif
                    if (updateIndexes && Values.Settings.DeviceOptions.AutoUpdateIndex)
                    {
                        List<TtPoint> iPoints = new List<TtPoint>();

                        foreach (TtPolygon poly in dal.GetPolygons())
                        {
                            int index = 0;
                            foreach (TtPoint p in dal.GetPointsInPolygon(poly.CN))
                            {
                                if (p.Index != index)
                                {
                                    p.Index = index;
                                    iPoints.Add(p);
                                }

                                index++;
                            }
                        }

                        dal.SavePoints(iPoints, ref Values.GlobalCancelToken);
                    }

                    bool result = CalculateSegmentsInOrderByWeight(dal);

                    if (Values.GlobalCancelToken)
                    {
#if !(PocketPC || WindowsCE || Mobile)
                        Values.UpdateStatusText("Polygons Adjustment Canceled");
                    }
                    else
                    {
                        if (result)
                            Values.UpdateStatusText("Polygons Adjusted");
#endif
                    }

                    Values.AdjustingPolygons = false;
                    Values.GlobalCancelToken = false;

                    form.GuiInvoke(() =>
                    {
                        TtUtils.HideWaitCursor();
                        form.Close();
                    });

                    GC.Collect();

                }).Start();
            }
            else
            {
                Values.AdjustingPolygons = true;

#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusText("Adjusting Polygons (Do NOT close Program)");
#endif
                bool result = CalculateSegmentsInOrderByWeight(dal);

#if !(PocketPC || WindowsCE || Mobile)
                if (Values.GlobalCancelToken)
                {
                    Values.UpdateStatusText("Polygons Adjustment Canceled");
                }
                else
                {
                    if (result)
                        Values.UpdateStatusText("Polygons Adjusted");
                }
#endif

                Values.AdjustingPolygons = false;
                GC.Collect();
            }
        }


        private static bool CalculateSegmentsInOrderByWeight(DataAccessLayer dal)
        {
            try
            {
                SegmentFactory sf = new SegmentFactory(dal);

                if (!sf.HasNext())
                    return true;

                SegmentList sl = new SegmentList();
                List<Segment> adjusted = new List<Segment>();

                while (sf.HasNext())
                {
                    sl.Add(sf.Next());
                }

                while (sl.HasNext())
                {
                    if (Values.GlobalCancelToken)
                        return false;

                    Segment seg = sl.Next();
                    if (seg.Calculate())
                    {
                        seg.Adjust();
                        adjusted.Add(seg);
                    }
                    else
                    {
                        seg.Weight--;
                        sl.Add(seg);
                    }
                }

                if (Values.GlobalCancelToken)
                    return false;

                SaveAllSegments(dal, adjusted);

                if (Values.GlobalCancelToken)
                    return false;

                CalculateAreaAndPerimeter(dal);
            }
            catch (Exception ex)
            {
#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusText("Polygon Adjustment Failed. See Error Log for details.");
#endif
                TtUtils.WriteError(ex.Message, "SegmentFactory:PolygonAdjuster", ex.StackTrace);

                return false;
            }

            return true;
        }

        private static void SaveAllSegments(DataAccessLayer dal, List<Segment> adjusted)
        {
            TtPoint point;
            Dictionary<string, TtPoint> points = new Dictionary<string, TtPoint>();

            for (int s = 0; s < adjusted.Count; s++)
            {
                for (int i = 0; i < adjusted[s].Count; i++)
                {
                    point = adjusted[s][i];

                    if (!points.ContainsKey(point.CN))
                        points.Add(point.CN, point);
                }
            }

            dal.SavePoints(points.Values.ToList(), ref Values.GlobalCancelToken);
        }

        private static void CalculateAreaAndPerimeter(DataAccessLayer DAL)
        {
            List<TtPolygon> polys = DAL.GetPolygons();

            if (polys != null && polys.Count > 0)
            {
                foreach (TtPolygon poly in polys)
                {
                    try
                    {
                        TtPolygon newPoly = new TtPolygon(poly);
                        List<TtPoint> points = DAL.GetBoundaryPoints(poly.CN).FilterOut(OpType.WayPoint).ToList();

                        if (points.Count > 2)
                        {
                            double perim = 0, area = 0;

                            points.Add(points[0]);
                            TtPoint p1, p2;
                            for (int i = 0; i < points.Count - 1; i++)
                            {
                                p1 = points[i];
                                p2 = points[i + 1];

                                perim += TtUtils.Distance(p1, p2);
                                area += ((p2.AdjX - p1.AdjX) * (p2.AdjY + p1.AdjY) / 2);
                            }

                            newPoly.Perimeter = perim;
                            newPoly.Area = Math.Abs(area);
                        }
                        else
                        {
                            newPoly.Perimeter = 0;
                            newPoly.Area = 0;
                        }

                        DAL.SavePolygon(poly, newPoly);
                    }
                    catch (Exception ex)
                    {
                        TtUtils.WriteError(ex.Message, "SegmentFactory:CalculateAreaAndPerimeter", ex.StackTrace);
                    }
                }
            }
        }
    }
}
