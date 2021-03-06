﻿using System;
using System.Collections.Generic;
using System.Text;
using TwoTrails.Utilities;
//using TwoTrails.Utilities;

namespace TwoTrails.BusinessObjects
{

    public class TravPoint : SideShotPoint 
    {
        public TravPoint() : base() 
        {
            _op = TwoTrails.Engine.OpType.Traverse;
        }

        public TravPoint(TravPoint p)
            : base(p)
        {
            _op = TwoTrails.Engine.OpType.Traverse;
        }

        public TravPoint(QuondamPoint p)
            : base(p)
        {
            _op = TwoTrails.Engine.OpType.Traverse;
        }

        public TravPoint(TtPoint p) : base(p)
        {
            if (p.op == TwoTrails.Engine.OpType.Traverse)
            {          
                CopySideShot((TravPoint)p);
                _op = TwoTrails.Engine.OpType.Traverse;
            }
            else if (p.op == TwoTrails.Engine.OpType.SideShot)
            {
                CopySideShot((SideShotPoint)p);
                _op = TwoTrails.Engine.OpType.Traverse;
            }
            else
            {
                DefaultSideShotValues();
                _op = TwoTrails.Engine.OpType.Traverse;
            }
                
        }

    }

    public class SideShotPoint : TtPoint
    {
        public SideShotPoint()
        {
            DefaultSideShotValues();
            _op = TwoTrails.Engine.OpType.SideShot;
        }

        protected void DefaultSideShotValues()
        {
            ForwardAz = null;
            BackwardAz = null;
            SlopeDistance = 0;
            SlopeAngle = 0;
            Accuracy = null;
        }

        public SideShotPoint(SideShotPoint p)
            : base(p)
        {
            CopySideShot(p);
        }

        public SideShotPoint(TtPoint p) : base(p)
        {
            if (p.op == TwoTrails.Engine.OpType.SideShot)
            {
                CopySideShot((SideShotPoint)p);
                _op = TwoTrails.Engine.OpType.SideShot;
            }
            else if (p.op == TwoTrails.Engine.OpType.Traverse)
            {
                CopySideShot((TravPoint)p);
                _op = TwoTrails.Engine.OpType.SideShot;
            }
            else
            {
                DefaultSideShotValues();
                _op = TwoTrails.Engine.OpType.SideShot;
            }
        }
        
        protected void CopySideShot(SideShotPoint p)
        {
            this._op = TwoTrails.Engine.OpType.SideShot;
            this.BackwardAz = p.BackwardAz;
            this.ForwardAz = p.ForwardAz;
            this.SlopeDistance = p.SlopeDistance;
            this.SlopeAngle = p.SlopeAngle;
            this.Accuracy = p.Accuracy;
        }
        
        private double? _forwardAz;
        private double? _backwardAz;
        private double? _accuracy;

        public double? Accuracy
        {
            get { return _accuracy; }
            set { _accuracy = value; }
        }

        public double? ForwardAz
        {
            get
            {
                return _forwardAz;
            }
            set
            {
                if (value == null)
                    _forwardAz = null;
                else
                    _forwardAz = TtUtils.AzimuthModulo((double)value);
            }
        }
        public double? BackwardAz
        {
            get
            {
                return _backwardAz;
            }
            set
            {
                if (value == null)
                    _backwardAz = null;
                else
                    _backwardAz = TtUtils.AzimuthModulo((double)value);
            }
        }

        /// <summary>
        /// Returns the average of the two Azimuths as a forward Azimuths assuming both values exist
        /// If only one exists returns it as a forward Azimuth
        /// </summary>     
        public double? Azimuth
        {
            get
            {
                double adjustedBackAz = 0;
                if (ForwardAz != null && ForwardAz >= 0 && BackwardAz != null && BackwardAz >= 0)
                {
                    if (BackwardAz > ForwardAz && BackwardAz >= 180)
                        adjustedBackAz = (double)BackwardAz - 180;
                    else
                        adjustedBackAz = (double)BackwardAz + 180.0;
                }
                else
                {
                    if (ForwardAz != null && ForwardAz >= 0)
                        return (double)ForwardAz;
                    else if (BackwardAz != null && BackwardAz >= 0)
                    {
                        return TtUtils.AzimuthModulo((double)BackwardAz + 180);
                    }
                    return null;
                }

                double taz = ((double)ForwardAz + adjustedBackAz) / 2;

                if (Math.Abs(taz - adjustedBackAz) > 100)
                {
                    return TtUtils.AzimuthModulo(taz + 180);
                }
                else
                {
                    return TtUtils.AzimuthModulo(taz);
                }
            }
        }


        public double SlopeDistance { get; set; }
        public double SlopeAngle { get; set; }
        public double HorizontalDistance
        {
            get
            {
                return SlopeDistance * Math.Cos(SlopeAngle * (Math.PI / 180.0));
            }
        }
        public double Declination { get; set; }

        public override bool CalculatePoint(TtPoint pt)
        {
            return CalcTravLocation(pt.UnAdjX, pt.UnAdjY, pt.UnAdjZ, true);
        }

        protected bool CalcTravLocation(double startingX, double startingY, double startingZ, bool isUnadjusted)
        {
            //Must have a valid azimuth to proceed
            if (Azimuth == null || Azimuth < 0)
            {
                _calculated = false;
                throw new Exception("Invalid Azimuth");
            }

            //Try the average azimuth first
            double azToUse = (double)Azimuth;

                //Adjust by the declination
            /* Apply the magnetic declination */
            /* East declination is positve, west is negative */
            azToUse += Declination;

            /* azimuth conversion from north to mathematic postive X-axis */
            azToUse = 90 - azToUse;
            double x, y, z;

            x = startingX + (HorizontalDistance * Math.Cos(azToUse * TtUtils.Degrees2Radians_Coeff));
            y = startingY + (HorizontalDistance * Math.Sin(azToUse * TtUtils.Degrees2Radians_Coeff));
            z = startingZ + (SlopeDistance * Math.Sin(SlopeAngle * TtUtils.Degrees2Radians_Coeff));

            if(isUnadjusted)
            {
                UnAdjX = x;
                UnAdjY = y;
                UnAdjZ = z;
                _calculated = true;
                _adjusted = false;
            }
            else
            {
                AdjX = x;
                AdjY = y;
                AdjZ = z;
                _adjusted = true;
            }
            
            return true;
        }

        /// <summary>
        /// Adjust based on a GPS/Waypoint start. The source point didn't adjust so our ss doesn't 
        /// need to change.
        /// </summary>
        /// <returns></returns>
        public override bool AdjustPoint()
        {
            if (!Calculated)
                return false;
            AdjX = UnAdjX;
            AdjY = UnAdjY;
            AdjZ = UnAdjZ;
            _adjusted = true;   //show that point is adjusted
            return true;
        }

        public override bool AdjustPoint(TtPoint source)
        {
            return CalcTravLocation(source.UnAdjX, source.UnAdjY, source.UnAdjZ, false);
        }

        public void SetAdjusted()
        {
            _adjusted = true;
        }
    }

}