using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Utilities
{
    public class MultiEditPointCommand : TtPointCommand
    {
        List<TtPoint> _OldPoints, _NewPoints;

        public override TtPointCommandType CommandType
        {
            get;
            protected set;
        }

        public MultiEditPointCommand(List<TtPoint> newPoints)
        {
            CommandType = TtPointCommandType.MultiEdit;
            _NewPoints = new List<TtPoint>();

            foreach (TtPoint p in newPoints)
            {
                _NewPoints.Add(TtUtils.CopyPoint(p));
            }

        }

        public override void Execute(IDictionary<string, TtPoint> points)
        {
            _OldPoints = new List<TtPoint>();

            foreach (TtPoint p in _NewPoints)
            {
                _OldPoints.Add(TtUtils.CopyPoint(points[p.CN]));
                points[p.CN] = p;
            }
        }

        public override void UnExecute(IDictionary<string, TtPoint> points)
        {
            foreach (TtPoint p in _OldPoints)
            {
                points[p.CN] = p;
            }
        }
    }
}
