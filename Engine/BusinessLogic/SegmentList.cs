using System;
using System.Collections.Generic;
using System.Text;

namespace TwoTrails.BusinessLogic
{
    //Sort segments by both weight then FIFO
    public class SegmentList
    {
        private List<Segment> _list = new List<Segment>();
        private bool _sorted = false;

        public void Add(Segment s)
        {
            _list.Add(s);
            _sorted = false;
        }

        public void AddRange(List<Segment> s)
        {
            _list.AddRange(s);
            _sorted = false;
        }

        public Segment Next()
        {
            if (_list.Count == 0)
                return null;

            if (!_sorted)
            {
                _list.Sort(SortByWeight);
                _sorted = true;
            }

            Segment current = _list[0];
            _list.Remove(current);

            return current;
        }

        private static int SortByWeight(Segment a, Segment b)
        {
            if (a == null)
            {
                if (b == null)
                    return 0;
                return 1;
            }

            if (b == null)
            {
                if (a == null)
                    return 0;
                return -1;
            }

            if (a.Weight == b.Weight)
                return 0;

            if (a.Weight > b.Weight)
                return -1;
            else
                return 1;
        }

        public bool HasNext()
        {
            return _list.Count > 0;
        }
    }
}