using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Utilities
{
    public class EditPointCommand : TtPointCommand
    {
        TtPoint _OldPoint, _NewPoint;

        public override TtPointCommandType CommandType
        {
            get; protected set;
        }

        public EditPointCommand(TtPoint newPoint)
        {
            CommandType = TtPointCommandType.SingleEdit;
            _NewPoint = TtUtils.CopyPoint(newPoint);
        }

        public override void Execute(IDictionary<string, TtPoint> points)
        {
            _OldPoint = TtUtils.CopyPoint(points[_NewPoint.CN]);

            points[_NewPoint.CN] = _NewPoint;
        }

        public override void UnExecute(IDictionary<string, TtPoint> points)
        {
            points[_NewPoint.CN] = _OldPoint;
        }
    }
}
