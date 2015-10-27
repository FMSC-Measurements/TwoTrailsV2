using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTrails.Engine;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;

namespace TwoTrails.Utilities
{
    public class MultiAddPointCommand : TtPointCommand
    {
        List<TtPoint> _NewPoints;
        List<string> _OldCNs;

        public override TtPointCommandType CommandType
        {
            get;
            protected set;
        }

        public MultiAddPointCommand(List<TtPoint> newPoints)
        {
            CommandType = TtPointCommandType.Add;
            _NewPoints = new List<TtPoint>();
            _OldCNs = new List<string>();

            foreach (TtPoint p in newPoints)
            {
                _NewPoints.Add(TtUtils.CopyPoint(p));
                _OldCNs.Add(p.CN);
            }

        }

        public override void Execute(IDictionary<string, TtPoint> points)
        {
            foreach (TtPoint p in _NewPoints)
            {
                if (points.ContainsKey(p.CN))
                    points[p.CN] = p;
                else
                    points.Add(p.CN, p);

                //Values.GroupManager.Groups[p.GroupCN].AddPointToGroup(p);
            }
        }

        public override void UnExecute(IDictionary<string, TtPoint> points)
        {
            TtPoint tmpPoint;

            foreach (string cn in _OldCNs)
            {
                tmpPoint = points[cn];
                points[cn] = null;
                //Values.GroupManager.Groups[tmpPoint.GroupCN].RemovePointFromGroup(tmpPoint);
            }
        }
    }
}
