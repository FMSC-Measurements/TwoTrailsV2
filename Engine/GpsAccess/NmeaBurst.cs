using System;
using System.Collections.Generic;
using System.Text;
using TwoTrails.Utilities;
using TwoTrails.BusinessObjects;

namespace TwoTrails.GpsAccess
{
    public enum NorthSouth
    {
        North,
        South
    }

    public enum EastWest
    {
        East,
        West
    }

    public static class CoordConvert
    {
        public static NorthSouth ConvertNorthSouth(string s)
        {
            if (s.Length > 0 && s.ToLower()[0] == 's')
                return NorthSouth.South;

            return NorthSouth.North;
        }

        public static EastWest ConvertEastWest(string s)
        {
            if (s.Length > 0 && s.ToLower()[0] == 'e')
                return EastWest.East;

            return EastWest.West;
        }
    }

    public class NmeaBurst
    {
        internal string _PointCN;
        internal string _CN;

        internal bool _Used;
        internal DateTime _time;
        internal DateTime _date;
        internal DateTime _datetime;

        internal double _latitude;
        internal double _longitude;
        internal NorthSouth _latDir;
        internal EastWest _longDir;
        internal double _magVar;
        internal EastWest _magVarDir;
        internal int _utm_zone;
        internal double _X; //in UTM
        internal double _Y;
        internal double _Z; //also altitude
        protected List<Satellite> SatellitesSeen;
        protected List<Satellite> SatellitesUsed;
        
        //GGA
        internal double _GGA_latitude;
        internal double _GGA_longitude;
        internal NorthSouth _GGA_latDir;
        internal EastWest _GGA_longDir;

        internal int _fix_quality;  //0 to 8  2 == has diff
        internal int _num_of_used_sat;
        internal double _horiz_dilution_position;
        internal double _altitude;      //MSL
        internal Unit _alt_unit;
        internal double _geoid_height;  //HAE
        internal Unit _geoid_unit;

        //GSA
        internal int _fix;          // 1 no fix, 2 2d, 3 3d
        internal string _fixed_PRNs;
        internal double _PDOP;
        internal double _HDOP;
        internal double _VDOP;

        //GSV
        internal int _num_of_sat;

        //GRMC
        internal double _RMC_latitude;
        internal double _RMC_longitude;
        internal NorthSouth _RMC_latDir;
        internal EastWest _RMC_longDir;

        internal double _speed;         //knots
        internal double _track_angle;   //degrees


        //burst GPS strings Added
        internal bool bRMC;
        internal bool bGGA;
        internal bool bGSA;
        internal bool bGSV;

        //how many GSV strings
        internal int countGSV;
        internal int totalGSV;

        //NMEA status
        internal bool complete;
        internal bool drop;
        protected int badData;


        internal protected NmeaBurst()
        {
            _Used = false;
            _PointCN = null;
            _CN = null;

            SatellitesSeen = new List<Satellite>();
            SatellitesUsed = new List<Satellite>();
            _time = DateTime.Now;
            _date = DateTime.Now;
            _datetime = DateTime.Now;

            _longitude = -1;
            _latitude = -1;

            _RMC_latitude = -1;
            _RMC_longitude = -1;
            _GGA_latitude = -1;
            _GGA_longitude = -1;

            _latDir = NorthSouth.North;
            _longDir = EastWest.West;

            countGSV = 0;
            totalGSV = 0;
            badData = 0;

            bRMC = false;
            bGGA = false;
            bGSA = false;
            bGSV = false;

            complete = false;
            drop = false;
        }

        public DateTime Timestamp
        {
            get { return _datetime; }
        }

        public void AddSatalite(Satellite s)
        {
            SatellitesSeen.Add(s);
        }

        public void Complete()
        {
            string[] fixedPRNs = _fixed_PRNs.Split('_');

            foreach (string prn in fixedPRNs)
            {
                foreach (Satellite sat in SatellitesUsed)
                {
                    if (sat.ID == prn)
                        SatellitesUsed.Add(sat);
                }
            }

            _Z = _altitude;

            if (_RMC_longitude > -1)
                _longitude = _RMC_longitude;
            else
                _longitude = _GGA_longitude;

            if (_RMC_latitude > -1)
                _latitude = _RMC_latitude;
            else
                _latitude = _GGA_latitude;

            _latDir = _RMC_latDir;
            _longDir = _RMC_longDir;

            if (_latitude > -1 && _longitude > -1)
            {
                double lat = -1, lon = -1;


                TtUtils.LatLonDegreeMinDecimalToDegreeDecimal(_latitude, _longitude, out lat, out lon);
                _latitude = lat;
                _longitude = lon;
                //TtUtils.LatLontoUTM(lat, (_longDir == EastWest.West) ? (lon * -1) : (lon), out _Y, out _X, out _utm_zone);
                //_X = (_longDir == EastWest.West) ? (_X * -1) : (_X);
                _Z = this._altitude;
            }
            else
            {
                drop = true;
            }

            _datetime = DateTime.Parse(string.Format("{0}/{1}/{2,4} {3}:{4}:{5}", _date.Month, _date.Day, _date.Year, _time.Hour, _time.Minute, _time.Second));

            complete = true;
        }

        public void BadData()
        {
            badData++;

            //if (badData > Engine.Values.BadDataLimit)
            //{
                drop = true;
            //}
        }

        public List<Satellite> GetSatellites() { return SatellitesSeen; }

        public bool IsValid
        {
            get
            {
                if (drop)
                    return false;
                return (_latitude > 0 && _longitude > 0);
            }
        }

        public bool IsValidNmea
        {
            get
            {
                if (drop)
                    return false;

                if (bRMC)
                    return (_RMC_latitude >= 0 && _RMC_longitude >= 0);

                if (bGGA)
                    return (_GGA_latitude >= 0 && _GGA_longitude >= 0);

                return true;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}- Drop:{1}, Lat:{2} Lon:{3}, Fix:{4}, SatSeen:{5}, SatUsed:{6}",
                _datetime.ToString(), drop.ToString(),
                _latitude, _longitude, _fix,
                SatellitesSeen.Count, SatellitesUsed.Count);
        }

        public BuisnessObjects.UTMCoord CalcZone(int utmZone)
        {
            TtUtils.LatLontoUTM(_latitude, (_longDir == EastWest.West) ? (_longitude * -1) : (_longitude), utmZone, out _Y, out _X);

            _utm_zone = utmZone;

            return new BuisnessObjects.UTMCoord(_X, _Y);
        }

        public void CalcRealZone()
        {
            TtUtils.LatLontoUTMwZone(_latitude, (_longDir == EastWest.West) ? (_longitude * -1) : (_longitude), out _Y, out _X, out _utm_zone);
        }
    }
}
