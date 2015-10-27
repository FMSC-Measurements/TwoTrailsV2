using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Utilities
{
    public class MultiDeletePointCommand : TtPointCommand
    {
        List<TtPoint> _OldPoints;

        public override TtPointCommandType CommandType
        {
            get;
            protected set;
        }

        public MultiDeletePointCommand(List<TtPoint> oldPoints)
        {
            CommandType = TtPointCommandType.Delete;
            _OldPoints = new List<TtPoint>();

            foreach (TtPoint p in oldPoints)
            {
                _OldPoints.Add(TtUtils.CopyPoint(p));
            }
        }

        public override void Execute(IDictionary<string, TtPoint> points)
        {
            foreach (TtPoint p in _OldPoints)
            {
                if (p.HasQuondamLinks)
                {
                    foreach (string cn in p.LinkedPoints)
                    {
                        if (points.ContainsKey(cn))
                        {
                            points[cn].RemoveQuondamLink(p.CN);
                        }
                    }
                }

                points.Remove(p.CN);
                //Engine.Values.GroupManager.Groups[p.GroupCN].RemovePointFromGroup(p);
            }
        }

        public override void UnExecute(IDictionary<string, TtPoint> points)
        {
            foreach (TtPoint p in _OldPoints)
            {
                points.Add(p.CN, p);
                //Engine.Values.GroupManager.Groups[p.GroupCN].AddPointToGroup(p);

                if (p.HasQuondamLinks)
                {
                    foreach (string cn in p.LinkedPoints)
                    {
                        if (points.ContainsKey(cn))
                        {
                            points[cn].AddQuondamLink(p.CN);
                        }
                    }
                }
            }
        }
    }
}
