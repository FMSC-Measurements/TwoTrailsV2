using System;
using System.Collections.Generic;
using System.Text;

namespace TwoTrails.BusinessObjects
{
    public class QuondamPoint : TtPoint//, ITtPoint
    {
        public QuondamPoint()
        {
            ParentPoint = null;
            _op = TwoTrails.Engine.OpType.Quondam;
        }

        public QuondamPoint(QuondamPoint p) : base(p)
        {
            this.ParentPoint = p.ParentPoint;
            _op = TwoTrails.Engine.OpType.Quondam;
        }

        public QuondamPoint(TtPoint p) : base(p)
        {
            if (p.op == TwoTrails.Engine.OpType.Quondam)
            {
                QuondamPoint q = (QuondamPoint)p;
                _op = TwoTrails.Engine.OpType.Quondam;
                this.ParentPoint = q.ParentPoint;
            }
            else
            {
                _op = TwoTrails.Engine.OpType.Quondam;
                this.ParentPoint = null;
            }
        }

        public int ParentPID 
        {
            get { return ParentPoint.PID; }          
        }
        public string ParentPoly 
        {
            get { return ParentPoint.PolyName; }
        }
        public string ParentCN
        {
            get 
            {
                if (ParentPoint == null || ParentPoint.CN == null)
                    return String.Empty;
                return ParentPoint.CN; 
            }
        }

        public TwoTrails.Engine.OpType ParentOp 
        { 
            get { return ParentPoint.op; } 
        }
        
        /*
        public override bool Adjusted
        {
            get
            {
                return ParentPoint.Adjusted;
            }
        }
        */
        public override bool Calculated
        {
            get
            {
                return ParentPoint.Calculated && _calculated;
            }
        }
        public double ManualAccuracy { get; set; }
        public TtPoint ParentPoint { get; set; }

        public override bool CalculatePoint(TtPoint parent)
        {
            return CalculatePoint();
        }

        public override bool CalculatePoint()
        {
            if (ParentPoint == null || ParentPoint.Calculated == false)                           
                return false;
            base.UnAdjX = ParentPoint.UnAdjX;
            base.UnAdjY = ParentPoint.UnAdjY;
            base.UnAdjZ = ParentPoint.UnAdjZ;

            base.MetaDefCN = ParentPoint.MetaDefCN;
            //base._op = ParentPoint.op; //Base op will be quondam, not the parent op
            base._calculated = true;

            return true;
        }

        public override bool AdjustPoint()
        {
            if (ParentPoint.Adjusted)
            {
                base.AdjX = ParentPoint.AdjX;
                base.AdjY = ParentPoint.AdjY;
                base.AdjZ = ParentPoint.AdjZ;
                _adjusted = true;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}- {2}", PID, op,
                (ParentPoint != null) ? (ParentPoint.PID.ToString()) : (String.Empty));
        }
    }
}