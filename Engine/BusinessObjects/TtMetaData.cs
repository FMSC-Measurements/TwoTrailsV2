using System;
using System.Collections.Generic;
using System.Text;
using TwoTrails.Engine;

namespace TwoTrails.BusinessObjects
{
    
    public class TtMetaData
    {

        public TtMetaData()
        {
            CN = null;
            Name = "Metadata";
            Zone = 13;
            datum = Datum.NAD83;
            uomDistance = UomDistance.FeetTenths;
            uomElevation = UomElevation.Meters;
            uomSlope = UomSlope.Percent;
            decType = DeclinationType.MagDec;
            magDec = 0;

            Receiver = null;
            Laser = null;
            Compass = null;
            Crew = null;
            Comment = null;
        }

        public TtMetaData(TtMetaData ttm)
        {
            CN = null;
            Name = null;
            Zone = ttm.Zone;
            datum = ttm.datum;
            uomDistance = ttm.uomDistance;
            uomElevation = ttm.uomElevation;
            uomSlope = ttm.uomSlope;
            decType = ttm.decType;
            magDec = 0;

            Receiver = null;
            Laser = null;
            Compass = null;
            Crew = null;
            Comment = null;
        }

        #region Properties
        public string CN
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }

        public string Name { get; set; }
        public int Zone { get; set; }
        public Datum datum { get; set; }
        public UomDistance uomDistance { get; set; }
        public UomElevation uomElevation { get; set; }
        public UomSlope uomSlope { get; set; }
        public DeclinationType decType { get; set; }
        public double magDec { get; set; }

        //public string getMagDec { get { return magDec.ToString(); } }

        public string Receiver { get; set; }
        public string Laser { get; set; }
        public string Compass { get; set; }
        public string Crew { get; set; }
        public string Comment { get; set; }
        #endregion
    }
}