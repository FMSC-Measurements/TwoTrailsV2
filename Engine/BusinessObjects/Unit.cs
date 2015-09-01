using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwoTrails.BusinessObjects
{
    public enum Unit
    {
        FEET_INCHES,
        METERS,
        YARDS,
        FEET_TENTH,
        CHAINS,
        UNKNOWN
    }

    public struct DoublePoint
    {
        public double X;
        public double Y;

        public DoublePoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}