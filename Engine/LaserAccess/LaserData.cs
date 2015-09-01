using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTrails.BusinessObjects;

namespace TwoTrails.LaserAccess
{
    public class LaserData
    {
        internal DateTime _time;

        internal string _horizontal_vector_message;
        internal double _horizontal_dist;
        internal Unit _horizontal_dist_unit;
        internal double _azimuth;
        internal double _inclination;
        internal double _slope;
        internal Unit _slope_unit;

        internal bool goodData;

        internal protected LaserData()
        {
            _time = DateTime.Now;
            goodData = false;
        }

        public DateTime Timestamp
        {
            get { return _time; }
        }

        public override string ToString()
        {
            return "Dist: " + _horizontal_dist;
        }
    }
}
