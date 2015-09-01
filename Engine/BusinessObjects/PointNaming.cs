using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwoTrails.BusinessObjects
{
    public static class PointNaming
    {
        public static int NameFirstPoint(TtPolygon parentPolygon)
        {
            return parentPolygon.PointStartIndex;
        }

        public static int NamePoint(TtPoint previousPoint, TtPolygon parentPolygon)
        {
            if (previousPoint == null)
                return NameFirstPoint(parentPolygon);

            return NamePoint(previousPoint, parentPolygon.IncrementBy);
        }

        public static int NamePoint(TtPoint previousPoint, int incrementBy)
        {
            if (incrementBy < 1)
                throw new Exception("Invalid Increment Value");

            int rem = incrementBy - (previousPoint.PID % incrementBy);

            if (rem > 0)
                return (previousPoint.PID + rem);

            return (previousPoint.PID + incrementBy);
        }

        public static int NameInsertPoint(TtPoint previousPoint)
        {
            return (previousPoint.PID + 1);
        }

        public static void RenamePoints(ref List<TtPoint> points, TtPolygon parentPoly)
        {
            RenamePoints(ref points, parentPoly.PointStartIndex, parentPoly.IncrementBy);

            /*
            if (points != null && points.Count > 0)
            {
                int pid = parentPoly.PointStartIndex;

                for (int i = 0; i < points.Count; i++)
                {
                    points[i].PID = pid;
                    pid += parentPoly.IncrementBy;
                }
            }
            */
        }

        public static void RenamePoints(ref List<TtPoint> points, int pointStartIndex, int incrementBy)
        {
            if (incrementBy < 1)
                throw new Exception("Invalid Increment Value");

            if (pointStartIndex < 0)
                throw new Exception("Invalid Point Start Index Value");

            if (points != null && points.Count > 0)
            {
                int pid = pointStartIndex;

                for (int i = 0; i < points.Count; i++)
                {
                    points[i].PID = pid;
                    pid += incrementBy;
                }
            }
        }
    }
}
