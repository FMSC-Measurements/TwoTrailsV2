using System;
using System.Collections.Generic;
using System.Text;

namespace TwoTrails.BusinessObjects
{
    #region WayPoint
    public class WayPoint : GpsPoint
    {
        public WayPoint()
            : base()
        {
            DefaultGpsValues();
            _op = TwoTrails.Engine.OpType.WayPoint;
        }

        public WayPoint(WayPoint p)
            : base(p)
        {
            _op = TwoTrails.Engine.OpType.WayPoint;
        }

        public WayPoint(TtPoint p)
            : base(p)
        {
            if (p.IsGpsType())
            {
                GpsCopy((GpsPoint)p);
                _op = TwoTrails.Engine.OpType.WayPoint;
            }
            else
            {
                DefaultGpsValues();
                _op = TwoTrails.Engine.OpType.WayPoint;
            }
        }

        public override bool AdjustPoint()
        {
            AdjX = UnAdjX;
            AdjY = UnAdjY;
            AdjZ = UnAdjZ;
            _calculated = true;
            _adjusted = true;
            return true;
        }
    }
    #endregion

    #region WalkPoint
    public class WalkPoint : GpsPoint
    {
        public WalkPoint()
            : base()
        {
            DefaultGpsValues();
            _op = TwoTrails.Engine.OpType.Walk;
        }

        public WalkPoint(WalkPoint p)
            :base(p)
        {
            _op = TwoTrails.Engine.OpType.Walk;
        }

        public WalkPoint(TtPoint p)
            :base(p)
        {
            if (p.IsGpsType())
            {
                GpsCopy((GpsPoint)p);
                _op = TwoTrails.Engine.OpType.Walk;
            }
            else
            {
                DefaultGpsValues();
                _op = TwoTrails.Engine.OpType.Walk;
            }
        }
    }
    #endregion

    #region Take5Point
    public class Take5Point : GpsPoint
    {
        public Take5Point()
            : base()
        {
            _op = TwoTrails.Engine.OpType.Take5;
        }

        public Take5Point(Take5Point p)
            : base(p)
        {
            _op = TwoTrails.Engine.OpType.Take5;
        }

        public Take5Point(GpsPoint p)
        {
            _op = TwoTrails.Engine.OpType.Take5;
        }

        public Take5Point(TtPoint p)
            : base (p)
        {
            if (p.op == TwoTrails.Engine.OpType.Take5 ||
                p.op == TwoTrails.Engine.OpType.GPS ||
                p.op == TwoTrails.Engine.OpType.WayPoint ||
                p.op == TwoTrails.Engine.OpType.Walk)
            {
                GpsCopy((GpsPoint)p);
                _op = TwoTrails.Engine.OpType.Take5;
            }
            else
            {
                DefaultGpsValues();
                _op = TwoTrails.Engine.OpType.Take5;
            }
        }

    }
    #endregion

    #region GpsPoint
    public class GpsPoint : TtPoint
    {
        public GpsPoint() : base()
        {
            DefaultGpsValues();
            _op = TwoTrails.Engine.OpType.GPS;
        }

        public GpsPoint(GpsPoint p) : base(p)
        {
            GpsCopy(p);
        }

        public GpsPoint(TtPoint p) : base(p)
        {
            /*
            if (p.op == TwoTrails.Engine.OpType.Take5 ||
                p.op == TwoTrails.Engine.OpType.GPS ||
                p.op == TwoTrails.Engine.OpType.WayPoint ||
                p.op == TwoTrails.Engine.OpType.Walk)
            */
            if(p.GetType() == typeof(GpsPoint))
            {
                GpsCopy((GpsPoint)p);
                _op = TwoTrails.Engine.OpType.GPS;
            }
            else
            {
                _op = TwoTrails.Engine.OpType.GPS;
                DefaultGpsValues();
            }               
        }

        protected void GpsCopy(GpsPoint p)
        {
            this.ManualAccuracy = p.ManualAccuracy;
            this.RMSEr = p.RMSEr;
            this.X = p.X;
            this.Y = p.Y;
            this.Z = p.Z;
        }

        public GpsPoint(double x, double y, double z) : base (x, y, z)
        {
            ManualAccuracy = null;
            _op = TwoTrails.Engine.OpType.GPS;
        }

        protected void DefaultGpsValues()
        {
            ManualAccuracy = null;
            RMSEr = null;
        }

        public double? ManualAccuracy { get; set; }        
        public double? RMSEr { get; set; }
        public double? NSSDA_RMSEr { get { return RMSEr * TwoTrails.Engine.Values.NSSDA_RMSEr95_Coeff; } }
        
        /*
        public override bool ProcessPoint()
        {
            //If we later want to rotate or some such, do it here or move the adjusted somewhere else...
            _calculated = true;
            UnAdjX = X;
            UnAdjY = Y;
            UnAdjZ = Z;
            return true;
        }
        */

        public override bool CalculatePoint()
        {
            //If we later want to rotate or some such, do it here or move the adjusted somewhere else...
            _calculated = true;
            //UnAdjX = X;
            //UnAdjY = Y;
            //UnAdjZ = Z;
            return true;

            //return ProcessPoint();
        }

        public override bool CalculatePoint(TtPoint t)
        {
            return CalculatePoint();
        }

        public override bool AdjustPoint()
        {
            if (!Calculated)
                return false;
            AdjX = UnAdjX;
            AdjY = UnAdjY;
            AdjZ = UnAdjZ;
            _adjusted = true;
            return true;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
    #endregion
}