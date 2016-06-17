using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Ports;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TwoTrails.Forms;
using System.Runtime.InteropServices;
using TwoTrails.Engine;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;
using System.Threading;
using Ionic.Zip;
using TwoTrails.GpsAccess;

#if (PocketPC || WindowsCE || Mobile)
using Microsoft.WindowsCE.Forms;
#else
using Microsoft.Win32;
#endif

namespace TwoTrails.Utilities
{
    public static class TtUtils
    {
        public static bool AdvReport = true;

        static TtUtils()
        {
#if !(PocketPC || WindowsCE || Mobile)
            _writeLock = new ReaderWriterLockSlim();
#endif
        }

        #region Consts
        public const double MinPointAccuracy = 0.00001;
        #endregion


        #region Coeff
        public const double HA_Coeff = 2.471;

        public const double FeetToMeters_Coeff = 1200 / 3937d;
        public const double YardsToMeters_Coeff = FeetToMeters_Coeff * 3d;
        public const double ChainsToMeters_Coeff = FeetToMeters_Coeff * 66d;

        public const double MetersToFeet_Coeff = 3937 / 1200d; //3.28084;
        public const double YardsToFeet_Coeff = 3d;
        public const double ChainsToFeet_Coeff = 66d;

        public const double FeetToYards_Coeff = 1 / 3d;
        public const double MetersToYards_Coeff = 1 / YardsToMeters_Coeff;
        public const double ChainsToYards_Coeff = 22d;

        public const double FeetToChains_Coeff = 1/66d;
        public const double MetersToChains_Coeff = MetersToFeet_Coeff / 66d;
        public const double YardsToChains_Coeff = 3 / 66d;

        public const double Meters2ToAcres_Coeff = 0.000247105;
        public const double Meters2ToHectares_Coeff = 0.0001;

        public const double Degrees2Radians_Coeff = Math.PI / 180;
        public const double Radians2Degrees_Coeff = 180 / Math.PI;

        #endregion


        #region Azimuth
        public static double AzimuthModulo(double az)
        {
            double integerPart = Math.Floor(az);
            double fraction = az - integerPart;

            return (integerPart % 360) + fraction;
        }

        public static double AzimuthReverse(double az)
        {
            return AzimuthModulo(az + 180);
        }

        public static double AzimuthDiff(double fwd, double back)
        {
            double diff;

            if (back > fwd)
            {
                diff = back - 180;
            }
            else
            {
                diff = back + 180;
            }

            diff = Math.Abs(diff - fwd);

            return diff;
        }

        public static double AzimuthOfPoint(DoublePoint p1, DoublePoint p2)
        {
            double Xcord = p2.X - p1.X;
            double Ycord = p2.Y - p1.Y;

            double azimuth = Math.Atan2(Xcord, Ycord) * (180 / Math.PI);

            if (azimuth < 0)
                azimuth += 360;

            return azimuth;
        }

        public static double AzimuthOfPoint(double x1, double y1, double x2, double y2)
        {
            double Xcord = x2 - x1;
            double Ycord = y2 - y1;

            double azimuth = Math.Atan2(Xcord, Ycord) * (180 / Math.PI);

            if (azimuth < 0)
                azimuth += 360;

            return azimuth;
        }

        public static double AzimuthDiff(TtPoint l1p1, TtPoint l1p2, TtPoint l2p1, TtPoint l2p2)
        {
            double a1 = AzimuthOfPoint(l1p1.UnAdjX, l1p1.UnAdjY, l1p2.UnAdjX, l1p2.UnAdjY);
            double a2 = AzimuthOfPoint(l2p1.UnAdjX, l2p1.UnAdjY, l2p2.UnAdjX, l2p2.UnAdjY);

            return a1 - a2;
            //return (a1 - a2 + 360) % 360;
        }
        #endregion


        #region Conversions
        public static double ConvertToMeters(double value, Unit type)
        {
            switch (type)
            {
                case Unit.FEET_INCHES:
                    {
                        return ConvertFeetInchesToFeetTenths(value) * FeetToMeters_Coeff;
                    }
                case Unit.METERS:
                    {
                        return value;
                    }
                case Unit.YARDS:
                    {
                        return value * YardsToMeters_Coeff;
                    }
                case Unit.FEET_TENTH:
                    {
                        return value * FeetToMeters_Coeff;
                    }
                case Unit.CHAINS:
                    {
                        return value * ChainsToMeters_Coeff;
                    }
                case Unit.UNKNOWN:
                default:
                    {
                        throw new Exception("Unknown Unit Type");
                    }
            }
        }

        public static double ConvertToFeetInches(double value, Unit type)
        {
            switch (type)
            {
                case Unit.FEET_INCHES:
                    {
                        return value;
                    }
                case Unit.METERS:
                    {
                        return ConvertFeetTenthsToFeetInches(value * MetersToFeet_Coeff);
                    }
                case Unit.YARDS:
                    {
                        return ConvertFeetTenthsToFeetInches(value * YardsToFeet_Coeff);
                    }
                case Unit.FEET_TENTH:
                    {
                        return ConvertFeetTenthsToFeetInches(value);
                    }
                case Unit.CHAINS:
                    {
                        return ConvertFeetTenthsToFeetInches(value * ChainsToFeet_Coeff);
                    }
                case Unit.UNKNOWN:
                default:
                    {
                        throw new Exception("Unknown Unit Type");
                    }
            }
        }

        public static double ConvertToYards(double value, Unit type)
        {
            switch (type)
            {
                case Unit.FEET_INCHES:
                    {
                        return ConvertFeetInchesToFeetTenths(value) * FeetToYards_Coeff;
                    }
                case Unit.METERS:
                    {
                        return value * MetersToYards_Coeff;
                    }
                case Unit.YARDS:
                    {
                        return value;
                    }
                case Unit.FEET_TENTH:
                    {
                        return value * FeetToYards_Coeff;
                    }
                case Unit.CHAINS:
                    {
                        return value * ChainsToYards_Coeff;
                    }
                case Unit.UNKNOWN:
                default:
                    {
                        throw new Exception("Unknown Unit Type");
                    }
            }
        }

        public static double ConvertToChains(double value, Unit type)
        {
            switch (type)
            {
                case Unit.FEET_INCHES:
                    {
                        return ConvertFeetInchesToFeetTenths(value) * FeetToChains_Coeff;
                    }
                case Unit.METERS:
                    {
                        return value * MetersToChains_Coeff;
                    }
                case Unit.YARDS:
                    {
                        return value * YardsToChains_Coeff;
                    }
                case Unit.FEET_TENTH:
                    {
                        return value * FeetToChains_Coeff;
                    }
                case Unit.CHAINS:
                    {
                        return value;
                    }
                case Unit.UNKNOWN:
                default:
                    {
                        throw new Exception("Unknown Unit Type");
                    }
            }
        }

        public static double ConvertToFeetTenths(double value, Unit type)
        {
            switch (type)
            {
                case Unit.FEET_INCHES:
                    {
                        return ConvertFeetInchesToFeetTenths(value);
                    }
                case Unit.METERS:
                    {
                        return value * MetersToFeet_Coeff;
                    }
                case Unit.YARDS:
                    {
                        return value * YardsToFeet_Coeff;
                    }
                case Unit.FEET_TENTH:
                    {
                        return value;
                    }
                case Unit.CHAINS:
                    {
                        return value * ChainsToFeet_Coeff;
                    }
                case Unit.UNKNOWN:
                default:
                    {
                        throw new Exception("Unknown Unit Type");
                    }
            }
        }


        public static double DegreesToPercent(double d)
        {
            return Math.Tan(d * Math.PI / 180.0) * 100;
        }

        public static double PercentToDegrees(double d)
        {
            return Math.Atan(d / 100.0) * 180.0 / Math.PI;
        }

        public static double DegreesToRadian(double d)
        {
            return d * Degrees2Radians_Coeff;
        }

        public static double RadiansToDegrees(double d)
        {
            return d * Radians2Degrees_Coeff;
        }

        public static double HaToAcres(double ha)
        {
            return ha * HA_Coeff;
        }

        private static double GetInches(double dFtIn)
        {
            return (dFtIn - (int)dFtIn) * 12.0;
        }

        private static double ConvertFeetInchesToFeetTenths(double d)
        {
            return (int)d + GetInches(d) / 12.0;
        }

        private static double ConvertFeetTenthsToFeetInches(double d)
        {
            int feet = (int)d;

            return feet + ((d - feet) / 12.0);
        }


        public static double ConvertMeters2ToHa(double d)
        {
            return d * Meters2ToHectares_Coeff;
        }

        public static double ConvertMeters2ToAcres(double d)
        {
            return d * Meters2ToAcres_Coeff;
        }

        public static double ConvertDistance(double d, Unit to, Unit from)
        {
            if (to == from)
                return d;

            switch (to)
            {
                case Unit.CHAINS:
                    return ConvertToChains(d, from);
                case Unit.FEET_INCHES:
                    return ConvertToFeetInches(d, from);
                case Unit.FEET_TENTH:
                    return ConvertToFeetTenths(d, from);
                case Unit.METERS:
                    return ConvertToMeters(d, from);
                case Unit.YARDS:
                    return ConvertToYards(d, from);
                default:
                    break;
            }

            return -1;
        }


        public static double ConvertDistance(double d, UomDistance to, UomDistance from)
        {
            if (to == from)
                return d;

            switch (to)
            {
                case UomDistance.Chains:
                    return ConvertToChains(d, UomDistanceToUnit(from));
                case UomDistance.FeetInches:
                    return ConvertToFeetInches(d, UomDistanceToUnit(from));
                case UomDistance.FeetTenths:
                    return ConvertToFeetTenths(d, UomDistanceToUnit(from));
                case UomDistance.Meters:
                    return ConvertToMeters(d, UomDistanceToUnit(from));
                case UomDistance.Yards:
                    return ConvertToYards(d, UomDistanceToUnit(from));
                default:
                    break;
            }

            return -1;
        }

        public static double ConvertDistance(double d, UomElevation to, UomElevation from)
        {
            if (to == from)
                return d;

            switch (to)
            {

                case UomElevation.Feet:
                    return ConvertToFeetTenths(d, UomElevationToUnit(from));
                case UomElevation.Meters:
                    return ConvertToMeters(d, UomElevationToUnit(from));
                default:
                    break;
            }

            return -1;
        }

        public static double ConvertAngle(double d, UomSlope to, UomSlope from)
        {
            if (to == from)
                return d;

            if (to == UomSlope.Degrees)
            {
                return PercentToDegrees(d);
            }
            else
            {
                return DegreesToPercent(d);
            }
        }

        public static Unit UomDistanceToUnit(UomDistance uom)
        {
            Unit u;

            switch (uom)
            {
                case UomDistance.Chains:
                    u = Unit.CHAINS;
                    break;
                case UomDistance.FeetInches:
                    u = Unit.FEET_INCHES;
                    break;
                case UomDistance.FeetTenths:
                    u = Unit.FEET_TENTH;
                    break;
                case UomDistance.Meters:
                    u = Unit.METERS;
                    break;
                case UomDistance.Yards:
                    u = Unit.YARDS;
                    break;
                default:
                    u = Unit.UNKNOWN;
                    break;
            }

            return u;
        }

        public static UomDistance UnitToUomDistance(Unit u)
        {
            UomDistance uom;

            switch (u)
            {
                case Unit.CHAINS:
                    uom = UomDistance.Chains;
                    break;
                case Unit.FEET_INCHES:
                    uom = UomDistance.FeetInches;
                    break;
                case Unit.FEET_TENTH:
                    uom = UomDistance.FeetTenths;
                    break;
                case Unit.METERS:
                    uom = UomDistance.Meters;
                    break;
                case Unit.YARDS:
                    uom = UomDistance.Yards;
                    break;
                default:
                    uom = UomDistance.Meters;
                    break;
            }

            return uom;
        }

        public static Unit UomElevationToUnit(UomElevation uom)
        {
            Unit u;

            switch (uom)
            {
                case UomElevation.Feet:
                    u = Unit.FEET_TENTH;
                    break;
                case UomElevation.Meters:
                    u = Unit.METERS;
                    break;
                default:
                    u = Unit.UNKNOWN;
                    break;
            }

            return u;
        }

        public static UomDistance UnitToUomElevation(Unit u)
        {
            UomDistance uom;

            switch (u)
            {
                
                case Unit.FEET_TENTH:
                    uom = UomDistance.FeetTenths;
                    break;
                case Unit.METERS:
                    uom = UomDistance.Meters;
                    break;
                default:
                    uom = UomDistance.Meters;
                    break;
            }

            return uom;
        }

        public static double CovnertBytesToMegaBytes(ulong bytes)
        {
            return Convert.ToDouble(bytes) / 1048576.0;
        }

        public static double CovnertBytesToMegaBytes(uint bytes)
        {
            return Convert.ToDouble(bytes) / 1048576.0;
        }

        #endregion


        #region Convert Unit from string
        public static Unit ConvertUnit(string s)
        {
            if (s.Length > 0)
            {
                switch (s.ToLower()[0])
                {
                    case 'm':
                        return Unit.METERS;
                    case 'f':
                        return Unit.FEET_TENTH;
                    case 'y':
                        return Unit.YARDS;
                    case 'c':
                        return Unit.CHAINS;
                    default:
                        break;
                }
            }

            return Unit.UNKNOWN;
        }
        #endregion


        #region AlphaNumeric checking, Checksums, And Start/Ending Numbers, E^-# = 0
        public static string RemoveNonAlphaNumeric(string str)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            str = rgx.Replace(str, "");
            return str;
        }

        public static double? GetEndingNumber(string s)
        {
            Regex r = new Regex(@"\d+(\.\d+)?$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

            Match m = r.Match(s);

            try
            {
                if (m.Success)
                {
                    string ns = m.Groups[0].Value;
                    return Convert.ToDouble(ns);
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, "TtUtils:GetEndingNumber");
            }

            return null;
        }

        /*
        public static double? GetStartingNumber(string s)
        {
            Regex r = new Regex(@"$?\d+(\.\d+)", RegexOptions.Compiled | RegexOptions.CultureInvariant);

            Match m = r.Match(s);

            try
            {
                if (m.Success)
                {
                    string ns = m.Groups[0].Value;
                    return Convert.ToDouble(ns);
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, "TtUtils:GetEndingNumber");
            }

            return null;
        }

        public static int GenerateCheckSum(string str)
        {
            int checksum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                checksum ^= Convert.ToByte(str[i]);
            }

            return checksum;
        }
        */
        #endregion


        #region Rounding
        /// <summary>
        /// rounds to closest whole number if within MinPointAccuracy
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static double? RoundByAcc(double? num)
        {
            if (num == null)
                return num;

            double tmpNum = (double)num;

            if (tmpNum % 1 < MinPointAccuracy ||
                (1 - tmpNum % 1) < MinPointAccuracy)
                return Math.Round(tmpNum, 0);
            return num;
        }

        public static double RoundByAcc(double num)
        {
            if (num % 1 < MinPointAccuracy ||
                (1 - num % 1) < MinPointAccuracy)
                return Math.Round(num, 0);
            return num;
        }
        #endregion


        #region Copy Point/Meta
        public static TtPoint CopyPoint(TtPoint currentPoint)
        {
            if (currentPoint == null)
                return null;
            switch (currentPoint.op)
            {
                case OpType.GPS:
                    {
                        GpsPoint p = new GpsPoint(currentPoint);
                        return p;
                    }
                case OpType.Quondam:
                    {
                        QuondamPoint p = new QuondamPoint(currentPoint);
                        return p;
                    }
                case OpType.SideShot:
                    {
                        SideShotPoint p = new SideShotPoint(currentPoint);
                        return p;
                    }
                case OpType.Traverse:
                    {
                        TravPoint p = new TravPoint(currentPoint);
                        return p;
                    }
                case OpType.WayPoint:
                    {
                        WayPoint p = new WayPoint(currentPoint);
                        return p;
                    }
                case OpType.Take5:
                    {
                        Take5Point p = new Take5Point(currentPoint);
                        return p;
                    }
                case OpType.Walk:
                    {
                        WalkPoint p = new WalkPoint(currentPoint);
                        return p;
                    }
            }
            return new GpsPoint(currentPoint);
        }

        /// <summary>
        /// Creates an exact copy of a point except with a new guid
        /// </summary>
        /// <param name="currentPoint">point to clone</param>
        /// <returns>cloned point</returns>
        public static TtPoint ClonePoint<T>(T currentPoint) where T : TtPoint
        {
            TtPoint point = CopyPoint(currentPoint);
            point.CN = Guid.NewGuid().ToString();
            return point;
        }

        public static TtPoint GetNewPointByOpType(OpType o, TtPoint pointTocopy)
        {
            if (pointTocopy == null)
            {
                pointTocopy = new TtPoint();
            }

            if (pointTocopy.op == OpType.Quondam)
            {
                throw new Exception("Can't change from Quondam");
            }

            switch (o)
            {
                case OpType.GPS:
                    return new GpsPoint(pointTocopy);
                case OpType.Quondam:
                    return new QuondamPoint(pointTocopy);
                case OpType.SideShot:
                    return new SideShotPoint(pointTocopy);
                case OpType.Take5:
                    return new Take5Point(pointTocopy);
                case OpType.Traverse:
                    return new TravPoint(pointTocopy);
                case OpType.Walk:
                    return new WalkPoint(pointTocopy);
                case OpType.WayPoint:
                    return new WayPoint(pointTocopy);
                default:
                    throw new Exception("Invalid Optype");
            }
        }

        public static TtMetaData CopyMetadata(TtMetaData currMeta)
        {
            TtMetaData ttm = new TtMetaData();

            ttm.CN = currMeta.CN;
            ttm.Name = currMeta.Name;
            ttm.Zone = currMeta.Zone;
            ttm.datum = currMeta.datum;
            ttm.uomDistance = currMeta.uomDistance;
            ttm.uomElevation = currMeta.uomElevation;
            ttm.uomSlope = currMeta.uomSlope;
            ttm.decType = currMeta.decType;
            ttm.magDec = currMeta.magDec;

            ttm.Receiver = currMeta.Receiver;
            ttm.Laser = currMeta.Laser;
            ttm.Compass = currMeta.Compass;
            ttm.Crew = currMeta.Crew;
            ttm.Comment = currMeta.Comment;

            return ttm;
        }
        #endregion


        #region Distance / Rotation

        public static double Distance(Point p1, Point p2)
        {
            return Distance(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static double Distance(TtPoint p1, TtPoint p2)
        {
            return Distance(p1, p2, true);
        }

        public static double Distance(TtPoint p1, TtPoint p2, bool adjusted)
        {
            if (p1 == null || p2 == null)
                return -1;
            else
            {
                if(adjusted)
                    return Distance(p1.AdjX, p1.AdjY, p2.AdjX, p2.AdjY);
                else
                    return Distance(p1.UnAdjX, p1.UnAdjY, p2.UnAdjX, p2.UnAdjY);
            }
        }

        public static double Distance(DoublePoint p1, DoublePoint p2)
        {
            return Distance(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public static double DistanceLatLon(DoublePoint p1, DoublePoint p2)
        {
            return DistanceLatLon(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static double DistanceLatLon(double lon1, double lat1, double lon2, double lat2)
        {
            lat1 = DegreesToRadian(lat1);
            lat2 = DegreesToRadian(lat2);

            lon1 = DegreesToRadian(lon1);
            lon2 = DegreesToRadian(lon2);


            double R = 6371;
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2.0) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon / 2), 2.0);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c;

            return d * 1000;    //to meters
        }

        public static double DistanceFromLine(DoublePoint point, DoublePoint linePoint1, DoublePoint linePoint2)
        {
            return DistanceFromLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y, true);
        }

        public static double DistanceFromLine(DoublePoint point, DoublePoint linePoint1, DoublePoint linePoint2, bool isSegment)
        {
            return DistanceFromLine(point.X, point.Y, linePoint1.X, linePoint1.Y, linePoint2.X, linePoint2.Y);
        }

        public static double DistanceFromLine(double px, double py, double lx1, double ly1, double lx2, double ly2)
        {
            return DistanceFromLine(px, py, lx1, ly1, lx2, ly2, true);
        }

        public static double DistanceFromLine(double px, double py, double lx1, double ly1, double lx2, double ly2, bool isSegment)
        {
            double dist = CrossProduct(px, py, lx1, ly1, lx2, ly2) / Distance(lx1, ly1, lx2, ly2);

            if (isSegment)
            {
                double dot1 = DotProduct(px, py, lx1, ly1, lx2, ly2);
                if (dot1 > 0)
                    return Distance(lx2, ly2, px, py);
                double dot2 = DotProduct(px, py, lx2, ly2, lx1, ly1);
                if (dot2 > 0)
                    return Distance(lx1, ly1, px, py);
            }

            return dist;// Math.Abs(dist);
        }

        private static double CrossProduct(double px, double py, double lx1, double ly1, double lx2, double ly2)
        {
            double abx, aby, acx, acy;

            abx = lx2 - lx1;
            aby = ly2 - ly1;
            acx = px - lx1;
            acy = py - ly1;

            return abx * acy - aby * acx;
        }

        private static double DotProduct(double px, double py, double lx1, double ly1, double lx2, double ly2)
        {
            double abx, aby, bcx, bcy;

            abx = lx2 - lx1;
            aby = ly2 - ly1;
            bcx = px - lx2;
            bcy = py - ly2;

            return abx * bcx + aby * bcy;
        }

        private static double toRadian(double val)
        {
            return (Math.PI / 180) * val;
        }

        /// <summary>
        /// Rotates Point round another point
        /// </summary>
        /// <param name="point">point to rotate</param>
        /// <param name="angle">angle to rotate by in degrees</param>
        /// <param name="rPoint">point to rotate around</param>
        /// <returns>rotated point</returns>
        public static DoublePoint RotatePoint(DoublePoint point, double angle, DoublePoint rPoint)
        {
            return RotatePoint(point.X, point.Y, angle, rPoint.X, rPoint.Y);
        }

        /// <summary>
        /// Rotates coordinates around other coordinates
        /// </summary>
        /// <param name="x">rotating x</param>
        /// <param name="y">rotating y</param>
        /// <param name="angle">angle to rotate by in degrees</param>
        /// <param name="rX">x to rotate around</param>
        /// <param name="rY">y to rotate around</param>
        /// <returns>rotated point</returns>
        public static DoublePoint RotatePoint(double x, double y, double angle, double rX, double rY)
        {
            double ca = Math.Cos(angle * Degrees2Radians_Coeff);
            double sa = Math.Sin(angle * Degrees2Radians_Coeff);

            double dx = x - rX;
            double dy = y - rY;

            return new DoublePoint(
                (ca * dx - sa * dy + rX),
                (sa * dx + ca * dy + rY));
        }

        public static Point RotatePoint(int x, int y, double angle, int rX, int rY)
        {
            double ca = Math.Cos(angle * Degrees2Radians_Coeff);
            double sa = Math.Sin(angle * Degrees2Radians_Coeff);

            double dx = x - rX;
            double dy = y - rY;

            return new Point(
                (int)(ca * dx - sa * dy + rX),
                (int)(sa * dx + ca * dy + rY));
        }
        #endregion


        #region Check Point Value / Perim / Area / Enum / Bounds
   
        public static bool PointHasValue(TtPoint point)
        {
            bool hasvalue = false;

            if (point != null)
            {
                if (point.op == OpType.GPS || point.op == OpType.Take5 || point.op == OpType.Walk || point.op == OpType.WayPoint)
                {
                    GpsPoint gps = ((GpsPoint)point);

                    if (//gps.X != 0 || gps.Y != 0 || gps.Z != 0 ||
                       gps.UnAdjX != 0 || gps.UnAdjY != 0 || gps.UnAdjZ != 0)
                        hasvalue = true;
                }
                else if (point.op == OpType.SideShot || point.op == OpType.Traverse)
                {
                    SideShotPoint ssp = ((SideShotPoint)point);

                    if ((ssp.ForwardAz != null || ssp.BackwardAz != null) &&
                        (ssp.SlopeAngle != 0 || ssp.SlopeDistance > 0))
                        hasvalue = true;
                }
                else if (point.op == OpType.Quondam)
                {
                    QuondamPoint q = ((QuondamPoint)point);

                    if (q.ParentPoint != null)
                        hasvalue = true;
                }
            }

            return hasvalue;
        }

        public static double CalculatePerimeter(List<DoublePoint> points)
        {
            double perim = 0;

            if (points.Count > 1)
            {
                points.Add(points[0]);
                for (int i = 0; i < points.Count - 1; i++)
                {
                    perim += Distance(points[i], points[i + 1]);
                }
            }

            return perim;
        }

        public static double CalculateArea(List<DoublePoint> points)
        {
            double area = 0;

            if (points.Count > 2)
            {
                points.Add(points[0]);
                for (int i = 0; i < points.Count - 1; i++)
                {
                    area += ((points[i + 1].X - points[i].X) * (points[i + 1].Y + points[i].Y) / 2);
                }
            }

            return Math.Abs(area);
        }


        public static double GetPointAcc(TtPoint point, Dictionary<string, TtPolygon> polys)
        {
            if (point.op == OpType.Quondam)
            {
                QuondamPoint qp = ((QuondamPoint)point);
                if (PointHasValue(qp.ParentPoint))
                {
                    if (!polys.ContainsKey(qp.ParentPoint.PolyCN))
                    {
                        qp.ParentPoint.PolyCN = qp.PolyCN;
                    }

                    return GetPointAcc(qp.ParentPoint, polys);
                }
            }
            else if (polys.ContainsKey(point.PolyCN))
            {
                if (point.IsGpsType())
                    return GetGpsPointAcc((GpsPoint)point, polys[point.PolyCN].PolyAccu);
                else if (point.IsTravType())
                    return GetTravPointAcc((SideShotPoint)point, polys[point.PolyCN].PolyAccu);
            }

            return Values.Settings.DeviceOptions.DEFAULT_POINT_ACCURACY;
        }

        private static double GetTravPointAcc(SideShotPoint point, double? polyAcc)
        {
            if (point.Accuracy != null && point.Accuracy >= 0)
                return (double)point.Accuracy;
            else if (polyAcc != null && polyAcc >= 0)
                return (double)polyAcc;
            else
                return Values.Settings.DeviceOptions.DEFAULT_POINT_ACCURACY;
        }

        private static double GetGpsPointAcc(GpsPoint point, double? polyAcc)
        {
            if (point.ManualAccuracy != null && point.ManualAccuracy >= 0)
                return (double)point.ManualAccuracy;
            else if (polyAcc != null && polyAcc >= 0)
                return (double)polyAcc;
            else if (point.RMSEr != null && point.RMSEr > -1)
                return (double)point.RMSEr;
            else
                return Values.Settings.DeviceOptions.DEFAULT_POINT_ACCURACY;
        }


        public static bool AreAllGpsType(this List<TtPoint> points)
        {
            if (points.Count < 1)
                return false;

            for (int i = 0; i < points.Count; i++)
            {
                if (!points[i].IsGpsType())
                    return false;
            }

            return true;
        }

        public static bool AreAllTravType(this List<TtPoint> points)
        {
            if (points.Count < 1)
                return false;

            for (int i = 0; i < points.Count; i++)
            {
                if (!points[i].IsTravType())
                    return false;
            }

            return true;
        }

        public static bool AreAllQndmType(this List<TtPoint> points)
        {
            if (points.Count < 1)
                return false;

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].op != OpType.Quondam)
                    return false;
            }

            return true;
        }

        public static IEnumerable<Enum> EnumGetValues(Enum enumeration)
        {
            List<Enum> enumerations = new List<Enum>();
            foreach (System.Reflection.FieldInfo fieldInfo in enumeration.GetType().GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
            {
                enumerations.Add((Enum)fieldInfo.GetValue(enumeration));
            }
            return enumerations;
        }


        public static void Getbounds(List<TtPoint> points, bool adj, out DoublePoint TopLeft, out DoublePoint BottomRight)
        {
            TopLeft = new DoublePoint();
            BottomRight = new DoublePoint();

            if (points.Count < 1)
                return;

            if (adj)
            {
                TopLeft.X = points[0].AdjX;
                TopLeft.Y = points[0].AdjY;
            }
            else
            {
                TopLeft.X = points[0].UnAdjX;
                TopLeft.Y = points[0].UnAdjY;
            }

            BottomRight.X = TopLeft.X;
            BottomRight.Y = TopLeft.Y;

            double x, y;

            for (int i = 1; i < points.Count; i++)
            {
                if (adj)
                {
                    x = points[i].AdjX;
                    y = points[i].AdjY;
                }
                else
                {
                    x = points[i].UnAdjX;
                    y = points[i].UnAdjY;
                }

                if (TopLeft.X > x)
                    TopLeft.X = x;

                if (TopLeft.Y < y)
                    TopLeft.Y = y;

                if (BottomRight.X < x)
                    BottomRight.X = x;

                if (BottomRight.Y > y)
                    BottomRight.Y = y;
            }
        }

        public static void Getbounds(List<DoublePoint> points, out DoublePoint TopLeft, out DoublePoint BottomRight)
        {
            TopLeft = new DoublePoint();
            BottomRight = new DoublePoint();

            if (points.Count < 1)
                return;

            TopLeft.X = points[0].X;
            TopLeft.Y = points[0].Y;

            BottomRight.X = TopLeft.X;
            BottomRight.Y = TopLeft.Y;

            double x, y;

            for (int i = 1; i < points.Count; i++)
            {
                x = points[i].X;
                y = points[i].Y;

                if (TopLeft.X > x)
                    TopLeft.X = x;

                if (TopLeft.Y < y)
                    TopLeft.Y = y;

                if (BottomRight.X < x)
                    BottomRight.X = x;

                if (BottomRight.Y > y)
                    BottomRight.Y = y;
            }
        }
        #endregion


        #region Point Operations
        public static bool FilterBurst(GpsAccess.NmeaBurst b, int fixType, int dopType, double dopValue)
        {
            if (Values.Settings.ProjectOptions.DropZero && !b.IsValid || b.drop)
                return false;

            if ((fixType == 0) || (fixType == 1 && b._fix == 3) ||
                                (fixType == 2 && b._fix == 3 && b._fix_quality == 2))  //fix tpye
            {
                if (dopType == 0)    //is PDOP
                {
                    if (b._PDOP > dopValue)   //if burst.PDOP <=
                    {
                        return false;
                    }
                }
                else        //is HDOP
                {
                    if (b._HDOP > dopValue)   //if burst.HDOP is <=
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public static double BurstDistance(GpsAccess.NmeaBurst from, GpsAccess.NmeaBurst to)
        {
            return Math.Sqrt(Math.Pow((from._X - to._X), 2) + Math.Pow((from._Y - to._Y), 2));
        }


        public static TtPoint RecalcPoint(TtPoint point, int newZone, int oldZone, DataAccessLayer dal)
        {
            double RMSE95_COEF = 1.7308;

            if (point.IsGpsType())
            {
                List<NmeaBurst> bursts = dal.GetNmeaBurstsByPointCN(point.CN);
                List<NmeaBurst> ToUseBursts = new List<NmeaBurst>();

                NmeaBurst b;
                if (bursts.Count > 0)
                {
                    for (int i = 0; i < bursts.Count; i++)
                    {
                        b = bursts[i];

                        b.CalcZone(newZone);

                        if (b._Used)
                        {
                            ToUseBursts.Add(b);
                        }
                    }

                    double x = 0, y = 0;
                    double dRMSEx = 0, dRMSEy = 0, dRMSEr = 0;

                    if (ToUseBursts.Count > 0)
                    {
                        int i = 0, count = 0;

                        for (i = 0; i < ToUseBursts.Count; i++)
                        {
                            x += ToUseBursts[i]._X;
                            y += ToUseBursts[i]._Y;
                        }

                        x /= i;
                        y /= i;

                        for (i = 0; i < ToUseBursts.Count; i++)
                        {
                            dRMSEx += Math.Pow(ToUseBursts[i]._X - x, 2);
                            dRMSEy += Math.Pow(ToUseBursts[i]._Y - y, 2);
                            count++;
                        }

                        dRMSEx = Math.Sqrt(dRMSEx / count);
                        dRMSEy = Math.Sqrt(dRMSEy / count);
                        dRMSEr = Math.Sqrt(Math.Pow(dRMSEx, 2) + Math.Pow(dRMSEy, 2));
                        dRMSEr *= RMSE95_COEF;
                    }

                    GpsPoint gps = (GpsPoint)point;

                    gps.UnAdjX = x;
                    gps.UnAdjY = y;
                    //gps.X = gps.UnAdjX = x;
                    //gps.Y = gps.UnAdjY = y;
                    gps.AdjX = gps.AdjY = 0;
                    gps.RMSEr = (dRMSEr > Values.Settings.DeviceOptions.MIN_POINT_ACCURACY) ?
                    dRMSEr : Values.Settings.DeviceOptions.DEFAULT_POINT_ACCURACY;

                    dal.UpdateNmeaBursts(bursts, point.CN);
                    return gps;
                }
            }

            double lat, lon, utmX, utmY;

            UTMtoLatLon(point.UnAdjX, point.UnAdjY, oldZone, out lat, out lon);
            LatLontoUTM(lat, lon, newZone, out utmY, out utmX);

            point.UnAdjX = utmX; 
            point.UnAdjY = utmY;

            return point;
        }
        #endregion


        #region Device Info

        #region Device ID/Name
        private static Int32 METHOD_BUFFERED = 0;
        private static Int32 FILE_ANY_ACCESS = 0;
        private static Int32 FILE_DEVICE_HAL = 0x00000101;

        private const Int32 ERROR_NOT_SUPPORTED = 0x32;
        private const Int32 ERROR_INSUFFICIENT_BUFFER = 0x7A;

        private static Int32 IOCTL_HAL_GET_DEVICEID =
            ((FILE_DEVICE_HAL) << 16) | ((FILE_ANY_ACCESS) << 14)
            | ((21) << 2) | (METHOD_BUFFERED);

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern bool KernelIoControl(Int32 dwIoControlCode,
            IntPtr lpInBuf, Int32 nInBufSize, byte[] lpOutBuf,
            Int32 nOutBufSize, ref Int32 lpBytesReturned);

        public static string GetDeviceID()
        {
            // Initialize the output buffer to the size of a  
            // Win32 DEVICE_ID structure. 
            byte[] outbuff = new byte[20];
            Int32 dwOutBytes;
            bool done = false;

            Int32 nBuffSize = outbuff.Length;

            // Set DEVICEID.dwSize to size of buffer.  Some platforms look at 
            // this field rather than the nOutBufSize param of KernelIoControl 
            // when determining if the buffer is large enough.
            BitConverter.GetBytes(nBuffSize).CopyTo(outbuff, 0);
            dwOutBytes = 0;

            // Loop until the device ID is retrieved or an error occurs. 
            while (!done)
            {
                if (KernelIoControl(IOCTL_HAL_GET_DEVICEID, IntPtr.Zero,
                    0, outbuff, nBuffSize, ref dwOutBytes))
                {
                    done = true;
                }
                else
                {
                    int error = Marshal.GetLastWin32Error();
                    switch (error)
                    {
                        case ERROR_NOT_SUPPORTED:
                            throw new NotSupportedException(
                                "IOCTL_HAL_GET_DEVICEID is not supported on this device",
                                new Exception(error.ToString()));

                        case ERROR_INSUFFICIENT_BUFFER:

                            // The buffer is not big enough for the data.  The 
                            // required size is in the first 4 bytes of the output 
                            // buffer (DEVICE_ID.dwSize).
                            nBuffSize = BitConverter.ToInt32(outbuff, 0);
                            outbuff = new byte[nBuffSize];

                            // Set DEVICEID.dwSize to size of buffer.  Some 
                            // platforms look at this field rather than the 
                            // nOutBufSize param of KernelIoControl when 
                            // determining if the buffer is large enough.
                            BitConverter.GetBytes(nBuffSize).CopyTo(outbuff, 0);
                            break;

                        default:
                            throw new Exception(error.ToString() + "Unexpected error");
                    }
                }
            }

            // Copy the elements of the DEVICE_ID structure.
            Int32 dwPresetIDOffset = BitConverter.ToInt32(outbuff, 0x4);
            Int32 dwPresetIDSize = BitConverter.ToInt32(outbuff, 0x8);
            Int32 dwPlatformIDOffset = BitConverter.ToInt32(outbuff, 0xc);
            Int32 dwPlatformIDSize = BitConverter.ToInt32(outbuff, 0x10);
            StringBuilder sb = new StringBuilder();

            for (int i = dwPresetIDOffset;
                i < dwPresetIDOffset + dwPresetIDSize; i++)
            {
                sb.Append(String.Format("{0:X2}", outbuff[i]));
            }

            sb.Append("-");

            for (int i = dwPlatformIDOffset;
                i < dwPlatformIDOffset + dwPlatformIDSize; i++)
            {
                sb.Append(String.Format("{0:X2}", outbuff[i]));
            }
            return sb.ToString();
        }

        public static string GetDeviceName()
        {
#if (PocketPC || WindowsCE || Mobile)
            string did = GetDeviceID();
            if (did != string.Empty)
                return String.Format("{0} | {1}", did ,System.Net.Dns.GetHostName());
#endif
            return System.Net.Dns.GetHostName();
        }

        private const int SPI_GETPLATFORMTYPE = 257;
        [DllImport("coredll.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        private static extern int SystemParametersInfoString(int uiAction, int uiParam, StringBuilder pvParam, int fWinIni);

        public static string GetPlatformName()
        {
            try
            {
                StringBuilder sb = new StringBuilder(256);

                if (SystemParametersInfoString(SPI_GETPLATFORMTYPE, sb.Capacity, sb, 0) != 0)
                {
                    return sb.ToString();
                }
            }
            catch
            {
            }

            return "<Unknown platform>";
        }

        /*
        public static string GetOSName()
        {
#if (PocketPC || WindowsCE || Mobile)

#else
            var name = (from x in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().OfType<ManagementObject>()
                                  select x.GetPropertyValue("Caption")).FirstOrDefault();
            return name != null ? name.ToString() : "Unknown";
#endif
        }
        */

        public static bool IsPocketPC()
        {
            return (GetPlatformName().ToLower().IndexOf("pocketpc") >= 0);
        }
        #endregion

        #region Memory
        public struct MEMORYSTATUS
        {
            public UInt32 dwLength;
            public UInt32 dwMemoryLoad;
            public UInt32 dwTotalPhys;
            public UInt32 dwAvailPhys;
            public UInt32 dwTotalPageFile;
            public UInt32 dwAvailPageFile;
            public UInt32 dwTotalVirtual;
            public UInt32 dwAvailVirtual;
        }

        [DllImport("CoreDll.dll")]
        public static extern void GlobalMemoryStatus
        (
            ref MEMORYSTATUS lpBuffer
        );

        [DllImport("CoreDll.dll")]
        public static extern int GetSystemMemoryDivision
        (
            ref UInt32 lpdwStorePages,
            ref UInt32 lpdwRamPages,
            ref UInt32 lpdwPageSize
        );

        public static MEMORYSTATUS GetMemoryInfo()
        {
            MEMORYSTATUS memStatus = new MEMORYSTATUS();
            GlobalMemoryStatus(ref memStatus);
            return memStatus;
        }
        #endregion

        #region Battery
        [StructLayout(LayoutKind.Sequential)]
        public class SYSTEM_POWER_STATUS_EX
        {
            public byte ACLineStatus = 0;
            public byte BatteryFlag = 0;
            public byte BatteryLifePercent = 0;
            public byte Reserved1 = 0;
            public uint BatteryLifeTime = 0;
            public uint BatteryFullLifeTime = 0;
            public byte Reserved2 = 0;
            public byte BackupBatteryFlag = 0;
            public byte BackupBatteryLifePercent = 0;
            public byte Reserved3 = 0;
            public uint BackupBatteryLifeTime = 0;
            public uint BackupBatteryFullLifeTime = 0;
        }

        [DllImport("coredll.dll")]
        private static extern bool GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX pStatus, bool fUpdate);

        public static SYSTEM_POWER_STATUS_EX GetBatteryInfo()
        {
            SYSTEM_POWER_STATUS_EX binfo = new SYSTEM_POWER_STATUS_EX();

            GetSystemPowerStatusEx(binfo, true);

            return binfo;
        }

        #endregion

        #region Disk Space
        [DllImport("CoreDLL")]
        private static extern int GetDiskFreeSpaceEx(string DirectoryName, out ulong lpFreeBytesAvailableToCaller, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);

        public class FREE_SPACE
        {
            public string DirectoryName;
            public ulong FreeBytesAvailible;
            public ulong TotalCapacity;
            public ulong TotalFreeBytes;
        }

        public static FREE_SPACE GetFreeSpace(string dir)
        {
            FREE_SPACE fs = new FREE_SPACE();

            if (Directory.Exists(dir))
            {
                if (GetDiskFreeSpaceEx(dir, out fs.FreeBytesAvailible, out fs.TotalCapacity, out fs.TotalFreeBytes) > 0)
                {
                    fs.DirectoryName = dir;
                    return fs;
                }
            }

            return null;
        }

        #endregion

        #endregion


        #region Metadata Conversion

        public static TtPoint SaveConversion(TtPoint p, TtMetaData meta)
        {
            p = CopyPoint(p);

            p.AdjZ = ConvertDistance(p.AdjZ, UomElevation.Meters, meta.uomElevation);
            p.UnAdjZ = ConvertDistance(p.UnAdjZ, UomElevation.Meters, meta.uomElevation);

            switch (p.op)
            {
                case OpType.GPS:
                case OpType.Take5:
                case OpType.Walk:
                case OpType.WayPoint:
                    {
                        p.UnAdjZ = TtUtils.ConvertDistance(p.UnAdjZ, UomElevation.Meters, meta.uomElevation);
                        //((GpsPoint)p).Z = TtUtils.ConvertDistance(((GpsPoint)p).Z, UomElevation.Meters, meta.uomElevation);
                        break;
                    }
                case OpType.SideShot:
                    {
                        ((SideShotPoint)p).SlopeDistance = TtUtils.ConvertDistance(((SideShotPoint)p).SlopeDistance, UomDistance.Meters, meta.uomDistance);
                        ((SideShotPoint)p).SlopeAngle = TtUtils.ConvertAngle(((SideShotPoint)p).SlopeAngle, UomSlope.Degrees, meta.uomSlope);
                        break;
                    }
                case OpType.Traverse:
                    {
                        ((TravPoint)p).SlopeDistance = TtUtils.ConvertDistance(((TravPoint)p).SlopeDistance, UomDistance.Meters, meta.uomDistance);
                        ((TravPoint)p).SlopeAngle = TtUtils.ConvertAngle(((TravPoint)p).SlopeAngle, UomSlope.Degrees, meta.uomSlope);
                        break;
                    }
                case OpType.Quondam:
                default:
                    break;
            }

            return p;
        }

        public static TtPoint GetConversion(TtPoint p, TtMetaData meta)
        {
            p = CopyPoint(p);

            p.UnAdjZ = ConvertDistance(p.UnAdjZ, meta.uomElevation, UomElevation.Meters);
            p.AdjZ = ConvertDistance(p.AdjZ, meta.uomElevation, UomElevation.Meters);

            switch (p.op)
            {
                case OpType.GPS:
                case OpType.Take5:
                case OpType.Walk:
                case OpType.WayPoint:
                    {
                        p.UnAdjZ = TtUtils.ConvertDistance(p.UnAdjZ, meta.uomElevation, UomElevation.Meters);
                        break;
                    }
                case OpType.SideShot:
                    {
                        ((SideShotPoint)p).SlopeDistance = TtUtils.ConvertDistance(((SideShotPoint)p).SlopeDistance, meta.uomDistance, UomDistance.Meters);
                        ((SideShotPoint)p).SlopeAngle = TtUtils.ConvertAngle(((SideShotPoint)p).SlopeAngle, meta.uomSlope, UomSlope.Degrees);
                        break;
                    }
                case OpType.Traverse:
                    {
                        ((TravPoint)p).SlopeDistance = TtUtils.ConvertDistance(((TravPoint)p).SlopeDistance, meta.uomDistance, UomDistance.Meters);
                        ((TravPoint)p).SlopeAngle = TtUtils.ConvertAngle(((TravPoint)p).SlopeAngle, meta.uomSlope, UomSlope.Degrees);
                        break;
                    }
                case OpType.Quondam:
                default:
                    break;
            }

            return p;
        }
        #endregion


        #region Polygon Intersecting
        public static bool LineInOrIntersectRect(Point p1, Point p2, Rectangle r)
        {
            return (LineInRect(p1, p2, r) || LineIntersectsRect(p1, p2, r));
        }

        public static bool LineInRect(Point p1, Point p2, Rectangle r)
        {
            return (p1.X >= r.X && p1.Y >= r.Y && p1.X <= (r.X + r.Width) && p1.Y <= (r.Y + r.Height) ||
                p2.X >= r.X && p2.Y >= r.Y && p2.X <= (r.X + r.Width) && p2.Y <= (r.Y + r.Height));
        }

        public static bool LineIntersectsRect(Point p1, Point p2, Rectangle r)
        {
            return LineIntersectsLine(p1, p2, new Point(r.X, r.Y), new Point(r.X + r.Width, r.Y)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y), new Point(r.X + r.Width, r.Y + r.Height)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y + r.Height), new Point(r.X, r.Y + r.Height)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X, r.Y + r.Height), new Point(r.X, r.Y)) ||
                   (r.Contains(p1) && r.Contains(p2));
        }

        public static bool LineIntersectsLine(TtPoint l1p1, TtPoint l1p2, TtPoint l2p1, TtPoint l2p2)
        {
            double q = (l1p1.UnAdjY - l2p1.UnAdjY) * (l2p2.UnAdjX - l2p1.UnAdjX) - (l1p1.UnAdjX - l2p1.UnAdjX) * (l2p2.UnAdjY - l2p1.UnAdjY);
            double d = (l1p2.UnAdjX - l1p1.UnAdjX) * (l2p2.UnAdjY - l2p1.UnAdjY) - (l1p2.UnAdjY - l1p1.UnAdjY) * (l2p2.UnAdjX - l2p1.UnAdjX);

            if (d == 0)
                return false;

            double r = Math.Round(q / d, 4);

            q = (l1p1.UnAdjY - l2p1.UnAdjY) * (l1p2.UnAdjX - l1p1.UnAdjX) - (l1p1.UnAdjX - l2p1.UnAdjX) * (l1p2.UnAdjY - l1p1.UnAdjY);
            double s = q / d;

            if (r < 0 || r > 1 || s < 0 || s > 1)
                return false;

            return true;
        }

        public static bool LineIntersectsLine(Point l1p1, Point l1p2, Point l2p1, Point l2p2)
        {
            float q = (l1p1.Y - l2p1.Y) * (l2p2.X - l2p1.X) - (l1p1.X - l2p1.X) * (l2p2.Y - l2p1.Y);
            float d = (l1p2.X - l1p1.X) * (l2p2.Y - l2p1.Y) - (l1p2.Y - l1p1.Y) * (l2p2.X - l2p1.X);

            if (d == 0)
                return false;

            float r = q / d;

            q = (l1p1.Y - l2p1.Y) * (l1p2.X - l1p1.X) - (l1p1.X - l2p1.X) * (l1p2.Y - l1p1.Y);
            float s = q / d;

            if (r < 0 || r > 1 || s < 0 || s > 1)
                return false;

            return true;
        }

        public static bool LineIntersectsLineInfinite(TtPoint l1p1, TtPoint l1p2, TtPoint l2p1, TtPoint l2p2)
        {
            double a1 = AzimuthOfPoint(l1p1.UnAdjX, l1p1.UnAdjY, l1p2.UnAdjX, l1p2.UnAdjY);
            double a2 = AzimuthOfPoint(l2p1.UnAdjX, l2p1.UnAdjY, l2p2.UnAdjX, l2p2.UnAdjY);

            if (Math.Abs(a1 - a2) < 0.01)
                return false;

            return true;
        }

        public static DoublePoint LineIntersectionPoint(TtPoint p1, TtPoint p2, TtPoint p3, TtPoint p4)
        {
            double x = (((p1.UnAdjX * p2.UnAdjY) - (p1.UnAdjY * p2.UnAdjX)) * (p3.UnAdjX - p4.UnAdjX) -
                (p1.UnAdjX - p2.UnAdjX) * ((p3.UnAdjX * p4.UnAdjY) - (p3.UnAdjY * p4.UnAdjX))) /
                ((p1.UnAdjX - p2.UnAdjX) * (p3.UnAdjY - p4.UnAdjY) - (p1.UnAdjY - p2.UnAdjY) * (p3.UnAdjX - p4.UnAdjX));

            double y = (((p1.UnAdjX * p2.UnAdjY) - (p1.UnAdjY * p2.UnAdjX)) * (p3.UnAdjY - p4.UnAdjY) -
                (p1.UnAdjY - p2.UnAdjY) * ((p3.UnAdjX * p4.UnAdjY) - (p3.UnAdjY * p4.UnAdjX))) /
                ((p1.UnAdjX - p2.UnAdjX) * (p3.UnAdjY - p4.UnAdjY) - (p1.UnAdjY - p2.UnAdjY) * (p3.UnAdjX - p4.UnAdjX));

            return new DoublePoint(x, y);
        }


        private static DoublePoint LineIntersectionPoint(DoublePoint p1, DoublePoint p2, DoublePoint p3, DoublePoint p4)
        {
            double x = (((p1.X * p2.Y) - (p1.Y * p2.X)) * (p3.X - p4.X) -
                (p1.X - p2.X) * ((p3.X * p4.Y) - (p3.Y * p4.X))) /
                ((p1.X - p2.X) * (p3.Y - p4.Y) - (p1.Y - p2.Y) * (p3.X - p4.X));

            double y = (((p1.X * p2.Y) - (p1.Y * p2.X)) * (p3.Y - p4.Y) -
                (p1.Y - p2.Y) * ((p3.X * p4.Y) - (p3.Y * p4.X))) /
                ((p1.X - p2.X) * (p3.Y - p4.Y) - (p1.Y - p2.Y) * (p3.X - p4.X));

            return new DoublePoint(x, y);
        }
        #endregion


        #region Points and Polygon Calc

        public static bool PointInPoly(TtPoint point, ref List<DoublePoint> points)
        {
            return PointInPoly(point.AdjX, point.AdjY, ref points);
        }

        public static bool PointInPoly(DoublePoint point, ref List<DoublePoint> points)
        {
            return PointInPoly(point.X, point.Y, ref points);
        }

        public static bool PointInPoly(double pX, double pY, ref List<DoublePoint> points)
        {
            bool inPoly = false;

            int numOfSides = points.Count;

            try
            {
                if (numOfSides > 2)
                {
                    List<double> dXcoords = new List<double>();
                    List<double> dYcoords = new List<double>();

                    foreach (DoublePoint p in points)
                    {
                        dXcoords.Add(p.X);
                        dYcoords.Add(p.Y);
                    }

                    int j = 0;

                    for (int i = 0; i < points.Count; i++)
                    {
                        j++;
                        if (j == numOfSides)
                        {
                            j = 0;
                        }

                        if ((dYcoords[i] < pY && dYcoords[j] >= pY) || (dYcoords[j] < pY && dYcoords[i] >= pY))
                        {
                            if (dXcoords[i] + (pY - dYcoords[i]) / (dYcoords[j] - dYcoords[i])
                                * (dXcoords[j] - dXcoords[i]) < pX)
                            {
                                inPoly = !inPoly;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "TtUtils:PointInPoly");
            }

            return inPoly;
        }


        public static bool GetFarthestPoints(List<DoublePoint> points, out double top, out double bottom, out double left, out double right)
        {
            bool error = true;
            top = bottom = left = right = 0;

            try
            {
                if (points != null || points.Count > 0)
                {
                    top = bottom = points[0].Y;
                    left = right = points[0].X;

                    foreach (DoublePoint point in points)
                    {
                        if (point.Y > top)
                            top = point.Y;

                        if (point.Y < bottom)
                            bottom = point.Y;

                        if (point.X < left)
                            left = point.X;

                        if (point.X > right)
                            right = point.X;
                    }

                    error = false;
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "TtUtils:GetFarthestPoints");
            }

            return error;
        }

        public static void GetFarthestCorner(double pX, double pY, double top, double bottom, double left, double right, out double cX, out double cY)
        {
            cX = pX;
            cY = pY;

            double dist = 0, temp = 0;

            dist = Distance(pX, pY, left, top);
            cX = left;
            cY = top;

            temp = Distance(pX, pY, right, top);

            if (temp > dist)
            {
                dist = temp;
                cX = right;
                cY = top;
            }

            temp = Distance(pX, pY, left, bottom);

            if (temp > dist)
            {
                dist = temp;
                cX = left;
                cY = bottom;
            }

            temp = Distance(pX, pY, right, bottom);

            if (temp > dist)
            {
                dist = temp;
                cX = right;
                cY = bottom;
            }
        }

        #endregion


        #region SerialPortTester

        public static class SerialPortTester
        {
            private static bool isValid;
            private static string portname;

            private static void Tester()
            {

                SerialPort sp = new SerialPort(portname);

                try
                {
                    Application.DoEvents();
                    sp.Open();
                }
                catch
                {
                    return;
                }

                if (sp.IsOpen)
                {
                    isValid = true;
                }

                sp.Close();
            }

            public static bool SerialPortTest(string sp)
            {
                isValid = false;

                portname = sp;

                Thread t = new Thread(new ThreadStart(Tester));
                t.Start();
                Thread.Sleep(1000);
                t.Abort();

                return isValid;
            }
        }

        #endregion


        #region WaitCursor
        public static void ShowWaitCursor()
        {
            Cursor.Current = Cursors.WaitCursor;
#if (PocketPC || WindowsCE || Mobile)
            Cursor.Show();
#endif
        }

        public static void HideWaitCursor()
        {
#if (PocketPC || WindowsCE || Mobile)
            Cursor.Hide();
#endif
            Cursor.Current = Cursors.Default;
        }
        #endregion


        #region Logger

        //ToDo create one streamwriter and then implement lock()
        //finish converting String.Format

        private static string FILENAME = "TwoTrailsLog.txt";
        private static string ZIPNAME = "TwoTrailsExportLog";
        private static string DEVFILE = "DevInfoFile.txt";

#if !(PocketPC || WindowsCE || Mobile)
        private static ReaderWriterLockSlim _writeLock;
#endif

//        public static void WriteError(string error)
//        {
//            new Thread(() =>
//            {
//                Thread.CurrentThread.IsBackground = true;
//#if !(PocketPC || WindowsCE || Mobile)
//                _writeLock.EnterWriteLock();
//#endif
//                try
//                {
//                    using (StreamWriter sw = new StreamWriter(FILENAME, true))
//                    {
//                        sw.WriteLine(String.Format("ERR:[{0}]: {1}", DateTime.Now.ToString(), error));
//                    }
//                }
//                catch
//                {

//                }
//#if !(PocketPC || WindowsCE || Mobile)
//                finally
//                {
//                    _writeLock.ExitWriteLock();
//                }
//#endif
//            }).Start();
//        }

        public static void WriteError(string error, string codePage)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
#if !(PocketPC || WindowsCE || Mobile)
                _writeLock.EnterWriteLock();
#endif
                try
                {
                    using (StreamWriter sw = new StreamWriter(FILENAME, true))
                    {
                        sw.WriteLine(String.Format("ERR:[{0}][{1}]: {2}", DateTime.Now.ToString(), codePage, error));
                    }
                }
                catch
                {

                }
#if !(PocketPC || WindowsCE || Mobile)
                finally
                {
                    _writeLock.ExitWriteLock();
                }
#endif
            }).Start();
        }

        public static void WriteError(string error, string codePage, string stack)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
#if !(PocketPC || WindowsCE || Mobile)
                _writeLock.EnterWriteLock();
#endif
                try
                {
                    using (StreamWriter sw = new StreamWriter(FILENAME, true))
                    {
                        sw.WriteLine((String.Format("ERR:[{0}][{1}]: {2}", DateTime.Now.ToString(), codePage, error)));

                        int index = stack.OrdinalIndexOf('\n', 10);
                        if (index > 0)
                            stack = stack.Substring(index);
                        sw.WriteLine(String.Format("\tStack Trace: {0}", stack));
                    }
                }
                catch
                {

                }
#if !(PocketPC || WindowsCE || Mobile)
                finally
                {
                    _writeLock.ExitWriteLock();
                }
#endif
            }).Start();
        }

        public static void WriteMessage(string msg)
        {
#if !(PocketPC || WindowsCE || Mobile)
            _writeLock.EnterWriteLock();
#endif
            try
            {
                using (StreamWriter sw = new StreamWriter(FILENAME, true))
                {
                    sw.WriteLine(String.Format("MSG:[{0}]: {1}", DateTime.Now.ToString(), msg));
                }
            }
            catch
            {

            }
#if !(PocketPC || WindowsCE || Mobile)
            finally
            {
                _writeLock.ExitWriteLock();
            }
#endif
        }

        public static void WriteMessage(string msg, bool adv)
        {
            if (adv)
            {
                if (AdvReport)
                    WriteMessage(msg);
            }
            else
                WriteMessage(msg);
        }

        public static void WriteMessage(string msg, string codePage)
        {
#if !(PocketPC || WindowsCE || Mobile)
            _writeLock.EnterWriteLock();
#endif
            try
            {
                using (StreamWriter sw = new StreamWriter(FILENAME, true))
                {
                    sw.WriteLine(String.Format("MSG:[{0}][{1}]: {2}", DateTime.Now.ToString(), codePage, msg));
                }
            }
            catch
            {

            }
#if !(PocketPC || WindowsCE || Mobile)
            finally
            {
                _writeLock.ExitWriteLock();
            }
#endif
        }

        public static void WriteMessage(string msg, string codePage, bool adv)
        {
            if (adv)
            {
                if (AdvReport)
                    WriteMessage(msg, codePage);
            }
            else
                WriteMessage(msg, codePage);
        }

        public static void WriteEvent(string msg)
        {
#if !(PocketPC || WindowsCE || Mobile)
            _writeLock.EnterWriteLock();
#endif
            try
            {
                using (StreamWriter sw = new StreamWriter(FILENAME, true))
                {
                    sw.WriteLine(String.Format("EVENT:[{0}]: {1}", DateTime.Now.ToString(), msg));
                }
            }
            catch
            {

            }
#if !(PocketPC || WindowsCE || Mobile)
            finally
            {
                _writeLock.ExitWriteLock();
            }
#endif
        }

        public static void WriteEvent(string msg, bool adv)
        {
            if (adv)
            {
                if (AdvReport)
                    WriteEvent(msg);
            }
            else
                WriteEvent(msg);
        }

        public static void WriteEvent(string msg, string codePage)
        {
#if !(PocketPC || WindowsCE || Mobile)
            _writeLock.EnterWriteLock();
#endif
            try
            {
                using (StreamWriter sw = new StreamWriter(FILENAME, true))
                {
                    sw.WriteLine(String.Format("EVENT:[{0}][{1}]: {2}", DateTime.Now.ToString(), codePage, msg));
                }
            }
            catch
            {

            }
#if !(PocketPC || WindowsCE || Mobile)
            finally
            {
                _writeLock.ExitWriteLock();
            }
#endif
        }

        public static void WriteEvent(string msg, string codePage, bool adv)
        {
            if (adv)
            {
                if (AdvReport)
                    WriteEvent(msg, codePage);
            }
            else
                WriteEvent(msg, codePage);
        }

        public static void ClearErrorLog()
        {
#if !(PocketPC || WindowsCE || Mobile)
            _writeLock.EnterWriteLock();
#endif
            try
            {
                using (StreamWriter sw = new StreamWriter(FILENAME, false))
                {
                   //
                }
            }
            catch
            {

            }
#if !(PocketPC || WindowsCE || Mobile)
            finally
            {
                _writeLock.ExitWriteLock();
            }
#endif
        }


        public static void SetLogFileDestination(string dest)
        {
            FILENAME = dest;
        }

        public static bool ExportTtLog(string currFile, string expTo)
        {
            string _zipfile, _folder = String.Format("{0}_{1}", ZIPNAME, DateTime.Now.ToString().Replace('/', '-').Replace(':', '.'));
            bool success = false;

            try
            {
                if (expTo != null && expTo != "")
                    _zipfile = System.IO.Path.Combine(expTo, _folder + ".zip");
                else
                    _zipfile = System.IO.Path.Combine(Values.Settings.BinDirPath, _folder + ".zip");

                using (ZipFile zip = new ZipFile())
                {
                    if (File.Exists(Values.Settings.DeviceSettingsFilePath))
                        zip.AddFile(Values.Settings.DeviceSettingsFilePath, _folder);

                    if (File.Exists(Values.Settings.DefaultNamingFilePath))
                        zip.AddFile(Values.Settings.DefaultNamingFilePath, _folder);

                    if (File.Exists(Values.Settings.ProjectSettingsFilePath))
                        zip.AddFile(Values.Settings.ProjectSettingsFilePath, _folder);

                    if (File.Exists(FILENAME))
                        zip.AddFile(FILENAME, _folder);

                    if (currFile != null || currFile != "")
                    {
                        string[] files = currFile.Split('|');
                        foreach (string file in files)
                        {
                            if (File.Exists(file))
                                zip.AddFile(file, _folder);
                        }
                    }

                    //Create device info file and add
                    CreateDeviceInfoFile();

                    if (File.Exists(System.IO.Path.Combine(Values.Settings.BinDirPath, DEVFILE)))
                        zip.AddFile(System.IO.Path.Combine(Values.Settings.BinDirPath, DEVFILE), _folder);

                    //save zip
                    zip.Save(_zipfile);

                    //delete device info file
                    File.Delete(System.IO.Path.Combine(Values.Settings.BinDirPath, DEVFILE));

                    success = true;
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "TtUtils:ExportTtLog");
            }

            return success;
        }

        public static void CreateDeviceInfoFile()
        {
            StringBuilder sb = new StringBuilder();

#if (PocketPC || WindowsCE || Mobile)
            //get memory info
            MEMORYSTATUS memStatus = GetMemoryInfo();

            UInt32 memStorePages = 0;
            UInt32 memRamPages = 0;
            UInt32 memPageSize = 0;
            int res = GetSystemMemoryDivision(ref memStorePages, ref memRamPages, ref memPageSize);

            //get battery
            SYSTEM_POWER_STATUS_EX batStatus = GetBatteryInfo();
#endif

            sb.AppendLine("***** TwoTrails Information *****");
            sb.AppendFormat("Version: {1}{0}", Environment.NewLine, Values.TwoTrailsVersion);
            sb.AppendFormat("Build Date: {1}{0}", Environment.NewLine, Values.TwoTrailsBuildDate);
            sb.AppendFormat("DB Version: {1}{0}", Environment.NewLine, TwoTrails.DataAccess.TwoTrailsSchema.SchemaVersion);
            sb.AppendLine();

            sb.AppendLine("***** Device Information *****");
            sb.AppendFormat("Date: {1}{0}", Environment.NewLine, DateTime.Now.ToString());
            sb.AppendFormat("Device Name: {1}{0}", Environment.NewLine, GetDeviceName());
#if (PocketPC || WindowsCE || Mobile)
            sb.AppendFormat("Device ID: {1}{0}", Environment.NewLine, GetDeviceID());
#else
            sb.AppendFormat("Device ID: {1}{0}", Environment.NewLine, Environment.MachineName);
#endif
            sb.AppendFormat("OS Version: {1}{0}", Environment.NewLine, Environment.OSVersion);

#if (PocketPC || WindowsCE || Mobile)
            sb.AppendFormat("OEM Info: {1}{0}", Environment.NewLine, Platform.GetOEMInfo());
#endif
            sb.AppendFormat("Device Version: {1}{0}", Environment.NewLine, Environment.Version);
            sb.AppendLine();

#if (PocketPC || WindowsCE || Mobile)
            sb.AppendLine("--Memory Information--");
            sb.AppendFormat("Avail Phys: {1} ({2}:MB){0}", Environment.NewLine, memStatus.dwAvailPhys, CovnertBytesToMegaBytes(memStatus.dwAvailPhys).ToString().Truncate(7));
            sb.AppendFormat("Total Phys: {1} ({2}:MB){0}", Environment.NewLine, memStatus.dwTotalPhys, CovnertBytesToMegaBytes(memStatus.dwTotalPhys).ToString().Truncate(7));
            sb.AppendFormat("Avail Virtual: {1} ({2}:MB){0}", Environment.NewLine, memStatus.dwAvailVirtual, CovnertBytesToMegaBytes(memStatus.dwAvailVirtual).ToString().Truncate(7));
            sb.AppendFormat("Total Virtual: {1} ({2}:MB){0}", Environment.NewLine, memStatus.dwTotalVirtual, CovnertBytesToMegaBytes(memStatus.dwTotalVirtual).ToString().Truncate(7));
            sb.AppendFormat("Avail PageFile: {1} ({2}:MB){0}", Environment.NewLine, memStatus.dwAvailPageFile, CovnertBytesToMegaBytes(memStatus.dwAvailPageFile).ToString().Truncate(7));
            sb.AppendFormat("Total PageFile: {1} ({2}:MB){0}", Environment.NewLine, memStatus.dwTotalPageFile, CovnertBytesToMegaBytes(memStatus.dwTotalPageFile).ToString().Truncate(7));
            sb.AppendFormat("Length: {1}{0}", Environment.NewLine, memStatus.dwLength);
            sb.AppendFormat("Load: {1}{0}", Environment.NewLine, memStatus.dwMemoryLoad);
            sb.AppendFormat("Store Pages: {1}{0}", Environment.NewLine, memStorePages);
            sb.AppendFormat("Ram Pages: {1}{0}", Environment.NewLine, memRamPages);
            sb.AppendFormat("Page Size: {1}{0}", Environment.NewLine, memPageSize);
            sb.AppendLine();

            sb.AppendLine("--Battery Information--");
            sb.AppendFormat("LifePercent: {1}{0}", Environment.NewLine, batStatus.BatteryLifePercent);
            sb.AppendFormat("LifeTime: {1}{0}", Environment.NewLine, batStatus.BatteryLifeTime);
            sb.AppendFormat("FullLifeTime: {1}{0}", Environment.NewLine, batStatus.BatteryFullLifeTime);
            sb.AppendFormat("Flag: {1}{0}", Environment.NewLine, batStatus.BatteryFlag);
            sb.AppendLine();
            DirectoryInfo root = new DirectoryInfo(@"\");
            DirectoryInfo[] dirList = root.GetDirectories();
            FREE_SPACE fs;

            sb.AppendLine("--Free Space Information--");

            foreach (DirectoryInfo dir in dirList)
            {
                fs = GetFreeSpace(dir.FullName);

                if (fs != null && (fs.DirectoryName.ToLower().Contains("storage") || fs.DirectoryName.Contains("sd") || fs.DirectoryName.Contains("card")))
                {
                    sb.AppendFormat("Location: {1}{0}", Environment.NewLine, fs.DirectoryName);
                    sb.AppendFormat("Avail (MB): {1}{0}", Environment.NewLine, CovnertBytesToMegaBytes(fs.FreeBytesAvailible).ToString().Truncate(10));
                    sb.AppendFormat("Total Free (MB): {1}{0}", Environment.NewLine, CovnertBytesToMegaBytes(fs.TotalFreeBytes).ToString().Truncate(10));
                    sb.AppendFormat("Total (MB): {1}{0}", Environment.NewLine, CovnertBytesToMegaBytes(fs.TotalCapacity).ToString().Truncate(10));
                    sb.AppendLine();
                }
            }
            
#endif
            using (StreamWriter sw = new StreamWriter(System.IO.Path.Combine(Values.Settings.BinDirPath, DEVFILE), false))
            {
                sw.WriteLine(sb.ToString());
            }
        }

        #endregion


        #region Latitude Longitude Conversion

        public static void LatLonDegreeMinDecimalToDegreeDecimal(double latDegrees, double lonDegrees, out double latDecimal, out double lonDecimal)
        {
            double lat = 0, lon = 0;
            latDecimal = 0;
            lonDecimal = 0;

            latDecimal = Math.Floor(latDegrees / 100);
            lonDecimal = Math.Floor(lonDegrees / 100);

            lat = (latDegrees - (latDecimal * 100)) / 60;
            lon = (lonDegrees - (lonDecimal * 100)) / 60;

            latDecimal += lat;
            lonDecimal += lon;
        }

        public static void LatLonDegreeDecimalToDegreeMinDecimal(double latDegrees, double lonDegrees, out double latDecimal, out double lonDecimal)
        {
            double lat = 0, lon = 0;
            latDecimal = 0;
            lonDecimal = 0;

            latDecimal = Math.Floor(latDegrees);
            lonDecimal = Math.Floor(lonDegrees);

            lat = (latDegrees - latDecimal) * 60;
            lon = (lonDegrees - lonDecimal) * 60;

            latDecimal += lat;
            lonDecimal += lon;

            latDecimal *= 100;
            lonDecimal *= 100;
        }


        public static void LatLontoUTMwZone(double Lat, double Long, out double UTMNorthing, out double UTMEasting, out int Zone)
        {
            const double deg2rad = Math.PI / 180;

            double a = 6378137; //WGS84
            double eccSquared = 0.00669438; //WGS84
            double k0 = 0.9996;

            double LongOrigin;
            double eccPrimeSquared;
            double N, T, C, A, M;

            //Make sure the longitude is between -180.00 .. 179.9
            double LongTemp = (Long + 180) - ((int)((Long + 180) / 360)) * 360 - 180; // -180.00 .. 179.9;

            double LatRad = Lat * deg2rad;
            double LongRad = LongTemp * deg2rad;
            double LongOriginRad;
            int ZoneNumber = 13;

            ZoneNumber = ((int)((LongTemp + 180) / 6)) + 1;

            if (Lat >= 56.0 && Lat < 64.0 && LongTemp >= 3.0 && LongTemp < 12.0)
                ZoneNumber = 32;

            // Special zones for Svalbard
            if (Lat >= 72.0 && Lat < 84.0)
            {
                if (LongTemp >= 0.0 && LongTemp < 9.0) ZoneNumber = 31;
                else if (LongTemp >= 9.0 && LongTemp < 21.0) ZoneNumber = 33;
                else if (LongTemp >= 21.0 && LongTemp < 33.0) ZoneNumber = 35;
                else if (LongTemp >= 33.0 && LongTemp < 42.0) ZoneNumber = 37;
            }
            LongOrigin = (ZoneNumber - 1) * 6 - 180 + 3; //+3 puts origin in middle of zone
            LongOriginRad = LongOrigin * deg2rad;

            //compute the UTM Zone from the latitude and longitude
            Zone = ZoneNumber;

            eccPrimeSquared = (eccSquared) / (1 - eccSquared);

            N = a / Math.Sqrt(1 - eccSquared * Math.Sin(LatRad) * Math.Sin(LatRad));
            T = Math.Tan(LatRad) * Math.Tan(LatRad);
            C = eccPrimeSquared * Math.Cos(LatRad) * Math.Cos(LatRad);
            A = Math.Cos(LatRad) * (LongRad - LongOriginRad);

            M = a * ((1 - eccSquared / 4 - 3 * eccSquared * eccSquared / 64 - 5 * eccSquared * eccSquared * eccSquared / 256) * LatRad
            - (3 * eccSquared / 8 + 3 * eccSquared * eccSquared / 32 + 45 * eccSquared * eccSquared * eccSquared / 1024) * Math.Sin(2 * LatRad)
            + (15 * eccSquared * eccSquared / 256 + 45 * eccSquared * eccSquared * eccSquared / 1024) * Math.Sin(4 * LatRad)
            - (35 * eccSquared * eccSquared * eccSquared / 3072) * Math.Sin(6 * LatRad));

            UTMEasting = (double)(k0 * N * (A + (1 - T + C) * A * A * A / 6
            + (5 - 18 * T + T * T + 72 * C - 58 * eccPrimeSquared) * A * A * A * A * A / 120)
            + 500000.0);

            UTMNorthing = (double)(k0 * (M + N * Math.Tan(LatRad) * (A * A / 2 + (5 - T + 9 * C + 4 * C * C) * A * A * A * A / 24
            + (61 - 58 * T + T * T + 600 * C - 330 * eccPrimeSquared) * A * A * A * A * A * A / 720)));
            if (Lat < 0)
                UTMNorthing += 10000000.0; //10000000 meter offset for southern hemisphere
        }


        public static void LatLontoUTM(double Lat, double Long, int Zone, out double UTMNorthing, out double UTMEasting)
        {
            const double deg2rad = Math.PI / 180;

            double a = 6378137; //WGS84
            double eccSquared = 0.00669438; //WGS84
            double k0 = 0.9996;

            double LongOrigin;
            double eccPrimeSquared;
            double N, T, C, A, M;

            //Make sure the longitude is between -180.00 .. 179.9
            double LongTemp = (Long + 180) - ((int)((Long + 180) / 360)) * 360 - 180; // -180.00 .. 179.9;

            double LatRad = Lat * deg2rad;
            double LongRad = LongTemp * deg2rad;
            double LongOriginRad;

            // Special zones for Svalbard
            if (Lat >= 72.0 && Lat < 84.0)
            {
                if (LongTemp >= 0.0 && LongTemp < 9.0) Zone = 31;
                else if (LongTemp >= 9.0 && LongTemp < 21.0) Zone = 33;
                else if (LongTemp >= 21.0 && LongTemp < 33.0) Zone = 35;
                else if (LongTemp >= 33.0 && LongTemp < 42.0) Zone = 37;
            }
            LongOrigin = (Zone - 1) * 6 - 180 + 3; //+3 puts origin in middle of zone
            LongOriginRad = LongOrigin * deg2rad;

            eccPrimeSquared = (eccSquared) / (1 - eccSquared);

            N = a / Math.Sqrt(1 - eccSquared * Math.Sin(LatRad) * Math.Sin(LatRad));
            T = Math.Tan(LatRad) * Math.Tan(LatRad);
            C = eccPrimeSquared * Math.Cos(LatRad) * Math.Cos(LatRad);
            A = Math.Cos(LatRad) * (LongRad - LongOriginRad);

            M = a * ((1 - eccSquared / 4 - 3 * eccSquared * eccSquared / 64 - 5 * eccSquared * eccSquared * eccSquared / 256) * LatRad
            - (3 * eccSquared / 8 + 3 * eccSquared * eccSquared / 32 + 45 * eccSquared * eccSquared * eccSquared / 1024) * Math.Sin(2 * LatRad)
            + (15 * eccSquared * eccSquared / 256 + 45 * eccSquared * eccSquared * eccSquared / 1024) * Math.Sin(4 * LatRad)
            - (35 * eccSquared * eccSquared * eccSquared / 3072) * Math.Sin(6 * LatRad));

            UTMEasting = (double)(k0 * N * (A + (1 - T + C) * A * A * A / 6
            + (5 - 18 * T + T * T + 72 * C - 58 * eccPrimeSquared) * A * A * A * A * A / 120)
            + 500000.0);

            UTMNorthing = (double)(k0 * (M + N * Math.Tan(LatRad) * (A * A / 2 + (5 - T + 9 * C + 4 * C * C) * A * A * A * A / 24
            + (61 - 58 * T + T * T + 600 * C - 330 * eccPrimeSquared) * A * A * A * A * A * A / 720)));
            if (Lat < 0)
                UTMNorthing += 10000000.0; //10000000 meter offset for southern hemisphere
        }


        public static char UTMLetterDesignator(double Lat)
        {
            char LetterDesignator;

            if ((84 >= Lat) && (Lat >= 72)) LetterDesignator = 'X';
            else if ((72 > Lat) && (Lat >= 64)) LetterDesignator = 'W';
            else if ((64 > Lat) && (Lat >= 56)) LetterDesignator = 'V';
            else if ((56 > Lat) && (Lat >= 48)) LetterDesignator = 'U';
            else if ((48 > Lat) && (Lat >= 40)) LetterDesignator = 'T';
            else if ((40 > Lat) && (Lat >= 32)) LetterDesignator = 'S';
            else if ((32 > Lat) && (Lat >= 24)) LetterDesignator = 'R';
            else if ((24 > Lat) && (Lat >= 16)) LetterDesignator = 'Q';
            else if ((16 > Lat) && (Lat >= 8)) LetterDesignator = 'P';
            else if ((8 > Lat) && (Lat >= 0)) LetterDesignator = 'N';
            else if ((0 > Lat) && (Lat >= -8)) LetterDesignator = 'M';
            else if ((-8 > Lat) && (Lat >= -16)) LetterDesignator = 'L';
            else if ((-16 > Lat) && (Lat >= -24)) LetterDesignator = 'K';
            else if ((-24 > Lat) && (Lat >= -32)) LetterDesignator = 'J';
            else if ((-32 > Lat) && (Lat >= -40)) LetterDesignator = 'H';
            else if ((-40 > Lat) && (Lat >= -48)) LetterDesignator = 'G';
            else if ((-48 > Lat) && (Lat >= -56)) LetterDesignator = 'F';
            else if ((-56 > Lat) && (Lat >= -64)) LetterDesignator = 'E';
            else if ((-64 > Lat) && (Lat >= -72)) LetterDesignator = 'D';
            else if ((-72 > Lat) && (Lat >= -80)) LetterDesignator = 'C';
            else LetterDesignator = 'Z'; //Latitude is outside the UTM limits
            return LetterDesignator;
        }

        public class Ellipsoid
        {
            //Attributes
            public string ellipsoidName;
            public double EquatorialRadius;
            public double eccentricitySquared;

            public Ellipsoid(string name, double radius, double ecc)
            {
                ellipsoidName = name;
                EquatorialRadius = radius;
                eccentricitySquared = ecc;
            }
        };


        public static void UTMtoLatLon(double utmX, double utmY, int utmZone, out double latitude, out double longitude)
        {
            bool isNorthHemisphere = true; // utmZone[utmZone.Length - 1] >= 'N';

            double diflat = 0;// -0.00066286966871111111111111111111111111;
            double diflon = 0;// -0.0003868060578;

            int zone = utmZone; // int.Parse(utmZone.Substring(0, utmZone.Length - 1));
            double c_sa = 6378137.000000;
            double c_sb = 6356752.314245;
            double e2 = Math.Pow((Math.Pow(c_sa, 2) - Math.Pow(c_sb, 2)), 0.5) / c_sb;
            double e2cuadrada = Math.Pow(e2, 2);
            double c = Math.Pow(c_sa, 2) / c_sb;
            double x = utmX - 500000;
            double y = isNorthHemisphere ? utmY : utmY - 10000000;

            double s = ((zone * 6.0) - 183.0);
            double lat = y / (c_sa * 0.9996);
            double v = (c / Math.Pow(1 + (e2cuadrada * Math.Pow(Math.Cos(lat), 2)), 0.5)) * 0.9996;
            double a = x / v;
            double a1 = Math.Sin(2 * lat);
            double a2 = a1 * Math.Pow((Math.Cos(lat)), 2);
            double j2 = lat + (a1 / 2.0);
            double j4 = ((3 * j2) + a2) / 4.0;
            double j6 = ((5 * j4) + Math.Pow(a2 * (Math.Cos(lat)), 2)) / 3.0;
            double alfa = (3.0 / 4.0) * e2cuadrada;
            double beta = (5.0 / 3.0) * Math.Pow(alfa, 2);
            double gama = (35.0 / 27.0) * Math.Pow(alfa, 3);
            double bm = 0.9996 * c * (lat - alfa * j2 + beta * j4 - gama * j6);
            double b = (y - bm) / v;
            double epsi = ((e2cuadrada * Math.Pow(a, 2)) / 2.0) * Math.Pow((Math.Cos(lat)), 2);
            double eps = a * (1 - (epsi / 3.0));
            double nab = (b * (1 - epsi)) + lat;
            double senoheps = (Math.Exp(eps) - Math.Exp(-eps)) / 2.0;
            double delt = Math.Atan(senoheps / (Math.Cos(nab)));
            double tao = Math.Atan(Math.Cos(delt) * Math.Tan(nab));

            longitude = ((delt * (180.0 / Math.PI)) + s) + diflon;
            latitude = ((lat + (1 + e2cuadrada * Math.Pow(Math.Cos(lat), 2) - (3.0 / 2.0) * e2cuadrada * Math.Sin(lat) * Math.Cos(lat) * (tao - lat)) * (tao - lat)) * (180.0 / Math.PI)) + diflat;
        }
        #endregion


        #region Control Manipulation
        private const int BS_MULTILINE = 0x00002000;
        private const int GWL_STYLE = -16;

#if (PocketPC || WindowsCE || Mobile)
        [System.Runtime.InteropServices.DllImport("coredll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImport("coredll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        /*
        public static void MakeButtonMultiline(Button b)
        {
            IntPtr hwnd = b.Handle;
            int currentStyle = GetWindowLong(hwnd, GWL_STYLE);
            int newStyle = SetWindowLong(hwnd, GWL_STYLE, currentStyle | BS_MULTILINE);
        }
        */

        public static void MakeMultiline(this Button b)
        {
            IntPtr hwnd = b.Handle;
            int currentStyle = GetWindowLong(hwnd, GWL_STYLE);
            int newStyle = SetWindowLong(hwnd, GWL_STYLE, currentStyle | BS_MULTILINE);
        }
#endif
        #endregion


        #region Fix Points

        /*
        public static bool HasErrors(this TtPoint point)
        {
            if (point.GroupName.IsEmpty() || point.GroupCN.IsEmpty())
                return true;

            if (point.MetaDefCN.IsEmpty())
                return true;

            if (point.op == OpType.Quondam)
            {
                QuondamPoint p = (QuondamPoint)point;
                if(p.ParentPoint != null && p.ParentPoint.op == OpType.Quondam)
                    return true;
            }

            return false;
        }
        */

        public static bool HasErrors(this TtPoint point, Dictionary<string, TtMetaData> metadata, Dictionary<string, TtGroup> groups)
        {
            if (point.GroupName.IsEmpty() || point.GroupCN.IsEmpty() || !groups.ContainsKey(point.GroupCN))
                return true;

            if (point.MetaDefCN.IsEmpty() || !metadata.ContainsKey(point.MetaDefCN))
                return true;

            if (point.op == OpType.Quondam)
            {
                QuondamPoint p = (QuondamPoint)point;
                if (p.ParentPoint != null && p.ParentPoint.op == OpType.Quondam)
                    return true;
            }

            return false;
        }

        public static TtPoint Fix(this TtPoint point, DataAccess.DataAccessLayer dal, Dictionary<string, TtMetaData> metadata, Dictionary<string, TtGroup> groups)
        {
            if (dal.GetGroupByCN(Values.EmptyGuid) == null)
            {
                dal.InsertGroup(Values.MainGroup);
            }

            if (dal.GetMetaDataByCN(Values.EmptyGuid) == null)
            {
                dal.InsertMetaData(dal.CreateDefaultMetaData());
            }

            if (point.GroupName.IsEmpty() || point.GroupCN.IsEmpty() || !groups.ContainsKey(point.GroupCN))
            {
                point.GroupName = Values.MainGroup.Name;
                point.GroupCN = Values.MainGroup.CN;

                point.CN = Values.MainGroup.CN;
                point.GroupName = Values.MainGroup.Name;
            }

            if (point.MetaDefCN.IsEmpty() || !metadata.ContainsKey(point.MetaDefCN))
                point.MetaDefCN = Values.EmptyGuid;

            if (point.op == OpType.Quondam)
            {
                QuondamPoint p = (QuondamPoint)point;
                if (p.ParentPoint != null && p.ParentPoint.op == OpType.Quondam)
                {
                    TtPoint tmpPoint = p.ParentPoint;

                    while (tmpPoint.op == OpType.Quondam)
                    {
                        tmpPoint = ((QuondamPoint)tmpPoint).ParentPoint;
                        if (tmpPoint == null)
                            break;
                    }

                    p.ParentPoint = tmpPoint;
                    point = p;
                }
            }

            return point;
        }

        public static bool FixFile(string filename)
        {
            try
            {
                DataAccessLayer dal = new DataAccessLayer(filename);
                Dictionary<string, TtGroup> _Groups = dal.GetGroups().ToDictionary(g => g.CN, g => g);
                Dictionary<string, TtMetaData> _MetaData = dal.GetMetaData().ToDictionary(m => m.CN, m => m);


                if (dal.GetGroupCount() < 1)
                    dal.InsertGroup(Values.MainGroup);

                if (dal.GetMetadataCount() < 1)
                {
                    TtMetaData meta = Values.Settings.ReadMetaSettings();
                    if (meta != null)
                    {
                        dal.InsertMetaData(meta);
                    }
                    else
                    {
                        dal.CreateDefaultMetaData();
                    }
                }

                foreach (TtPoint point in dal.GetPoints())
                {
                    point.Fix(dal, _MetaData, _Groups);
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, "FixFile", ex.StackTrace);
            }

            return false;
        }

        #endregion


        #region Other
        public static void GuiInvoke(this Control control, Action action)
        {
            try
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(action);
                }
                else
                {
                    action();
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "GuiInvoke");
            }
        }

        public static void SelectAllViaInvoke(this TextBox textbox)
        {
            new Thread(() =>
            {
                Thread.Sleep(10);
                textbox.GuiInvoke(() =>
                {
                    textbox.SelectAll();
                });
            }).Start();
        }

#if !(PocketPC || WindowsCE || Mobile)
        public static string[] GetInstalledBrowsers()
        {
            RegistryKey browserKeys;
            //on 64bit the browsers are in a different location
            browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
            if (browserKeys == null)
                browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

            return browserKeys.GetSubKeyNames();
        }

        public static bool CheckBrowserInstalled(string installedBrowser)
        {
            foreach (string browser in GetInstalledBrowsers())
            {
                if (browser.ToLower().Contains(installedBrowser))
                    return true;
            }

            return false;
        }

        public static bool IsApplictionInstalled(string p_name)
        {
            string displayName;
            RegistryKey key;

            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            // NOT FOUND
            return false;
        }
#endif

        public static decimal FindDifference(decimal n1, decimal n2)
        {
            return Math.Abs(n1 - n2);
        }

        public static decimal FindDifference(double n1, double n2)
        {
            return Math.Abs(new decimal(n1) - new decimal(n2));
        }

        public static bool WithinDifferenceOf(double num1, double num2, double difference)
        {
            if (FindDifference(num1, num2) < new decimal(difference))
                return true;
            return false;
        }


        public static bool WriteCsvFile(string filename, List<string> Columns, List<List<string>> data)
        {
            if (data.Count > 0 && filename != null && filename != "" && Columns.Count > 0)
            {
                if (Columns.Count == data[0].Count)
                {
                    using (StreamWriter sw = new StreamWriter(filename, false))
                    {
                        StringBuilder sb = new StringBuilder();

                        foreach (string column in Columns)
                        {
                            sb.Append(column + ',');
                        }
                        sb.Remove(sb.Length - 1, 1);

                        sw.WriteLine(sb.ToString());

                        int columnSize = Columns.Count;

                        foreach (List<string> list in data)
                        {
                            if (list.Count < columnSize)
                                continue;

                            sb = new StringBuilder();

                            for (int i = 0; i < columnSize; i++)
                            {
                                sb.Append(list[i] + ',');
                            }

                            sb.Remove(sb.Length - 1, 1);
                            sw.WriteLine(sb);
                        }
                    }
                }
                else
                {
                    TtUtils.WriteError("Amount of Columns not equal to Amount of Data", "DataOutput:WriteCsv");
                    return false;
                }
            }
            else
            {
                TtUtils.WriteError("Columns or Data has not objects or filename not valid", "DataOutput:WriteCsv");
                return false;
            }

            return true;
        }


        public static Image ResizeImage(this Image image, Size size)
        {
            return ResizeImage(image, size.Width, size.Height);
        }

        public static Image ResizeImage(this Image image, int newWidth, int newHeight)
        {
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight, 
                          PixelFormat.Format24bppRgb);

#if !(PocketPC || WindowsCE || Mobile)
            bmPhoto.SetResolution(image.HorizontalResolution,
                         image.VerticalResolution);
#endif

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);

#if !(PocketPC || WindowsCE || Mobile)
            grPhoto.InterpolationMode =
                InterpolationMode.HighQualityBicubic;
#endif

            grPhoto.DrawImage(image,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        public static Image ResizeImage2(this Image image, Size size, bool preserveAspectRatio)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
#if (PocketPC || WindowsCE || Mobile)
                graphicsHandle.DrawImage(image, 0, 0, new Rectangle(0, 0, newWidth, newHeight), GraphicsUnit.Pixel);
#else
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
#endif
            }
            return newImage;
        }

        public static bool IntTryParse(string str, out int value)
        {
            try
            {
                value = Int32.Parse(str);
            }
            catch
            {
                value = Int32.MinValue;
                return false;
            }

            return true;
        }
        #endregion


        #region Optimization
        public class Parallel
        {
            public static void ForEach<T>(IEnumerable<T> items, Action<T> action)
            {
                if (items == null)
                    throw new ArgumentNullException("enumerable");
                if (action == null)
                    throw new ArgumentNullException("action");

                var resetEvents = new List<ManualResetEvent>();

                foreach (var item in items)
                {
                    var evt = new ManualResetEvent(false);
                    ThreadPool.QueueUserWorkItem((i) =>
                    {
                        action((T)i);
                        evt.Set();
                    }, item);
                    resetEvents.Add(evt);
                }

                foreach (var re in resetEvents)
                    re.WaitOne();
            }
        }
        #endregion
    }


    #region Extensions
    public static class StringExtended
    {
        public static string Truncate(this String str, int size)
        {
            if (str.Length > size)
                return str.Substring(0, size);

            return str;
        }

        public static int OrdinalIndexOf(this String str, char c, int n)
        {
            int pos = str.IndexOf(c, 0);
            while (n-- > 0 && pos != -1)
                pos = str.IndexOf(c, pos + 1);
            return pos;
        }

        public static int IndexOf(this String str, char c)
        {
            return IndexOf(str, c, 0);
        }

        public static int IndexOf(this String str, char c, int start)
        {
            for (int i = start; i < str.Length; i++)
            {
                if (str[i] == c)
                {
                    return i;
                }
            }

            return -1;
        }

        public static bool IsInteger(this String str)
        {
            str = str.Replace("-", "");

            if (str.IsEmpty())
                return false;

            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        public static bool IsDouble(this String str)
        {
            str = str.Replace("-", "").Replace(".", "");
            
            if (str.IsEmpty())
                return false;

            int dots = 0;

            foreach (char c in str)
            {
                if ((c < '0' || c > '9') && c != '.')
                    return false;

                if (c == '.')
                {
                    dots++;

                    if (dots > 1)
                        return false;
                }
            }

            return true;
        }

        public static int ToInteger(this String str)
        {
            return Int32.Parse(str);
        }

        public static double ToDouble(this String str)
        {
            if (str == null || str == String.Empty)
                return -1;

            return Double.Parse(str);
        }

        public static bool IsBool(this String str)
        {
            if (str.IsEmpty())
                return false;

            switch (str.ToLower())
            {
                case "true":
                case "t":
                case "1":
                case "false":
                case "f":
                case "0":
                case "on":
                case "off":
                    return true;
                default:
                    return false;
            }
        }

        public static bool ToBool(this String str)
        {
            switch (str.ToLower())
            {
                case "true":
                case "t":
                case "1":
                case "on":
                    return true;
                    /*
                case "false":
                case "f":
                case "0":
                case "off":
                    */
                default:
                    return false;
            }
        }

        public static string NotNull(this String str)
        {
            if (str == null)
                return String.Empty;
            return str;
        }

        public static bool IsEmpty(this String str)
        {
            return (str == null || str == String.Empty);
        }

        public static string Scrub(this String str)
        {
            if (str == null) return String.Empty;
            return str.Trim().Replace(",", ";");
        }

        public static string ScrubFileName(this String str)
        {
            StringBuilder sb = new StringBuilder(str);

            sb.Replace("/", "_");
            sb.Replace(",", "");
            sb.Replace("?", "");
            sb.Replace("@", "");
            sb.Replace("#", "");
            sb.Replace("$", "");
            sb.Replace("%", "");
            sb.Replace("^", "");
            sb.Replace("&", "");
            sb.Replace("*", "");
            sb.Replace(":", "");
            sb.Replace("\"", "");
            sb.Replace("\'", "");
            sb.Replace("<", "");
            sb.Replace(">", "");
            sb.Replace("|", "");

            return sb.ToString();
        }

        private static readonly char[] trimChars = new char[] { ' ', '\0', '\r', '\n' };

        public static string TrimEx(this String str)
        {
            return str.Trim(trimChars);
        }
    }

    public static class IntExtended
    {
        public static int Length(this int i)
        {
            return (i.ToString().Length);
        }
    }

    public static class ListExtended
    {
        public static List<TtPoint> CopyTtList(this IEnumerable<TtPoint> points)
        {
            List<TtPoint> newpoints = new List<TtPoint>();

            foreach(TtPoint p in points)
            {
                newpoints.Add(TtUtils.CopyPoint(p));
            }

            return newpoints;
        }

        public static List<TtPoint> FilterOut(this IEnumerable<TtPoint> points, OpType op)
        {
            return points.Where(p => p.op != op).ToList();
        }

        public static List<TtPoint> FilterOnly(this IEnumerable<TtPoint> points, OpType op)
        {
            return points.Where(p => p.op == op).ToList();
        }

        public static List<DoublePoint> ToDoublePoints<T>(this IEnumerable<T> points) where T : TtPoint
        {
            return points.ToDoublePoints(false);
        }

        public static List<DoublePoint> ToDoublePoints<T>(this IEnumerable<T> points, bool adjusted) where T : TtPoint
        {
            List<DoublePoint> dpoints = new List<DoublePoint>();

            if (adjusted)
            {
                foreach (TtPoint p in points)
                    dpoints.Add(new DoublePoint(p.AdjX, p.AdjY));
            }
            else
            {
                foreach (TtPoint p in points)
                    dpoints.Add(new DoublePoint(p.UnAdjX, p.UnAdjY));
            }

            return dpoints;
        }
    }
    #endregion


    public struct DataPair
    {
        public string Name;
        public string Path;

        public DataPair(string name, string path)
        {
            Name = name;
            Path = path;
        }
        public override string ToString()
        {
            return Name;
        }
    }


#if !(PocketPC || WindowsCE || Mobile)
    public static class FileAssociation
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        // Associate file extension with progID, description, icon and application
        public static void Associate(string extension,
               string progID, string description, string icon, string application)
        {
            try
            {
                Registry.ClassesRoot.CreateSubKey(extension).SetValue("", progID);
                if (progID != null && progID.Length > 0)
                {
                    using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(progID))
                    {
                        if (description != null)
                            key.SetValue("", description);
                        if (icon != null)
                            key.CreateSubKey("DefaultIcon").SetValue("", ToShortPathName(icon));
                        if (application != null)
                            key.CreateSubKey(@"Shell\Open\Command").SetValue("",
                                        ToShortPathName(application) + " \"%1\"");
                    }

                    // Tell explorer the file association has been changed
                    SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
                }
            }
            catch(Exception ex)
            {
                TtUtils.WriteError(ex.Message, "Program:AddExtension");
            }
        }

        public static void DeAssociate(string extension, string progID)
        {
            if (progID != null && progID.Length > 0)
            {
                if(Registry.ClassesRoot.GetValue(extension, null) != null)
                    Registry.ClassesRoot.DeleteSubKey(extension);
                if (Registry.ClassesRoot.GetValue(progID, null) != null)
                    Registry.ClassesRoot.DeleteSubKeyTree(progID);

                // Tell explorer the file association has been changed
                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            }
        }

        public static void NotifyIconChange()
        {
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        // Return true if extension already associated in registry
        public static bool IsAssociated(string extension)
        {
            return (Registry.ClassesRoot.OpenSubKey(extension, false) != null);
        }

        // Return short path format of a file name
        private static string ToShortPathName(string longName)
        {
            return System.IO.Path.Combine(Directory.GetCurrentDirectory(), longName);
        }
    }
#endif

}
