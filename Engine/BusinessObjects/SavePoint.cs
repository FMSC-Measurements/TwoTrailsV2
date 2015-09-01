using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwoTrails.BusinessObjects
{
    public class SavePoint
    {
        public DateTime Time { get; set; }
        public string CN { get; set; }
        public string Comment { get; set; }

        public SavePoint()
        {
            Time = DateTime.Now;
            CN = "SP" + Guid.NewGuid().ToString("N");
            Comment = String.Empty;
        }

        public SavePoint(string comment)
        {
            Time = DateTime.Now;
            CN = "SP" + Guid.NewGuid().ToString("N");
            Comment = comment;
        }

        public SavePoint(DateTime time, string cn, string comment)
        {
            Time = time;
            CN = cn;
            Comment = comment;
        }
    }
}
