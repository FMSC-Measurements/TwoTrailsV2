using System;
using System.Collections.Generic;
using System.Text;

namespace TwoTrails.GpsAccess
{
    public class Satellite
    {
        public string ID { get; set; }
        public double Elevation { get; set; }
        public double Azimuth { get; set; }
        public double SNR { get; set; }
    }
}
