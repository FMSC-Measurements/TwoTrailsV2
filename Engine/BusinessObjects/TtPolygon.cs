using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using TwoTrails.Utilities;

namespace TwoTrails.BusinessObjects
{
    //[Serializable]
    public class TtPolygon
    {
        #region members
        private string _CN;
        #endregion

        public TtPolygon(TtPolygon p)
        {
            _CN = p.CN;
            Name = p.Name;
            Description = p.Description;
            //#Comment = p.Comment;
            IsLocked = p.IsLocked;
            PolyAccu = p.PolyAccu;
            Area = p.Area;
            Perimeter = p.Perimeter;
            _incrementBy = p.IncrementBy;
            _PointStartIndex = p._PointStartIndex;
        }

        public TtPolygon()
        {
            CN = Guid.NewGuid().ToString();
            IncrementBy = 10;
            PointStartIndex = 1010;
            PolyAccu = null;
        }

        public TtPolygon(int pointStartIndex)
        {
            CN = Guid.NewGuid().ToString();
            IncrementBy = 10;
            PointStartIndex = pointStartIndex;
            PolyAccu = null;
        }

        public string CN
        {
            get
            {
                if(_CN.IsEmpty())
                {
                    _CN = System.Guid.NewGuid().ToString();
                    return _CN;
                }
                else
                    return _CN;
            }
            set
            {
                _CN = value;
            }
        }
        public string Name { get; set; }
        public string Description { get; set; }
        //#public string Comment { get; set; }

        private int _incrementBy;
        public int IncrementBy
        {
            get { return _incrementBy; }
            set
            {
                if (value > 0)
                {
                    _incrementBy = value;
                }
                else
                    throw new Exception("Invalid Increment Value");
            }
        }

        private int _PointStartIndex;
        public int PointStartIndex
        {
            get { return _PointStartIndex; }
            set
            {
                if (value > 0)
                {
                    _PointStartIndex = value;
                }
                else
                    throw new Exception("Invalid Start Index Value");
            }
        }

        public bool IsLocked { get; set; }
        public double? PolyAccu { get; set; }

        public double Area { get; set; }
        public double Perimeter { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}