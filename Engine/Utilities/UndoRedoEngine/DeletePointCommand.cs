using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Utilities
{
    class DeletePointCommand : TtPointCommand
    {
        TtPoint _OldPoint;

        public override TtPointCommandType CommandType
        {
            get;
            protected set;
        }

        public DeletePointCommand(TtPoint oldPoint)
        {
            CommandType = TtPointCommandType.Delete;
            _OldPoint = oldPoint;
        }

        public override void Execute(IDictionary<string, TtPoint> points)
        {
            if (_OldPoint.HasQuondamLinks)
            {
                foreach (string cn in _OldPoint.LinkedPoints)
                {
                    if (points.ContainsKey(cn))
                    {
                        points[cn].RemoveQuondamLink(_OldPoint.CN);
                    }
                }
            }

            points.Remove(_OldPoint.CN);
            Engine.Values.GroupManager.Groups[_OldPoint.GroupCN].RemovePointFromGroup(_OldPoint);
        }

        public override void UnExecute(IDictionary<string, TtPoint> points)
        {
            points.Add(_OldPoint.CN, _OldPoint);
            Engine.Values.GroupManager.Groups[_OldPoint.GroupCN].AddPointToGroup(_OldPoint);

            if (_OldPoint.HasQuondamLinks)
            {
                foreach (string cn in _OldPoint.LinkedPoints)
                {
                    if (points.ContainsKey(cn))
                    {
                        points[cn].AddQuondamLink(_OldPoint.CN);
                    }
                }
            }
        }
    }
}
