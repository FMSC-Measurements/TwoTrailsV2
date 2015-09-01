using System;
using System.Collections.Generic;
using System.Text;
using TwoTrails.Engine;

namespace TwoTrails.BusinessObjects
{
    public class TtPoint : IComparable<TtPoint>, IComparer<TtPoint>
    {
        protected string _CN;
        protected TwoTrails.Engine.OpType _op;
        //protected long _index;
        protected bool _calculated;
        protected bool _adjusted;

        public TtPoint()
        { 
            _CN = String.Empty;
            _LinkedPoints = new List<string>();
        }

        public TtPoint(TtPoint toCopy)
        {
            this._CN = toCopy.CN;
            this._op = toCopy.op;
            this.Comment = toCopy.Comment;
            this.Index = toCopy.Index;
            this.PolyCN = toCopy.PolyCN;
            this.PolyName = toCopy.PolyName;
            this.PID = toCopy.PID;
            this.Time = toCopy.Time;
            this.UnAdjX = toCopy.UnAdjX;
            this.UnAdjY = toCopy.UnAdjY;
            this.UnAdjZ = toCopy.UnAdjZ;
            this.AdjX = toCopy.AdjX;
            this.AdjY = toCopy.AdjY;
            this.AdjZ = toCopy.AdjZ;
            this._LinkedPoints = toCopy._LinkedPoints;
            this.MetaDefCN = toCopy.MetaDefCN;
            this.OnBnd = toCopy.OnBnd;
            this._GroupName = toCopy._GroupName;
            this._GroupCN = toCopy._GroupCN;
        }

        protected TtPoint(double x, double y, double z)
        {
            UnAdjX = x;
            UnAdjY = y;
            UnAdjZ = z;            
        }

        protected void Copy(TtPoint toCopy)
        {
            this._CN = toCopy.CN;
            this._op = toCopy.op;
            this.Comment = toCopy.Comment;
            this.Index = toCopy.Index;
            this.PolyCN = toCopy.PolyCN;
            this.PolyName = toCopy.PolyName;
            this.PID = toCopy.PID;
            this.Time = toCopy.Time;
            this.UnAdjX = toCopy.UnAdjX;
            this.UnAdjY = toCopy.UnAdjY;
            this.UnAdjZ = toCopy.UnAdjZ;
            this.AdjX = toCopy.AdjX;
            this.AdjY = toCopy.AdjY;
            this.AdjZ = toCopy.AdjZ;
            this._LinkedPoints = toCopy._LinkedPoints;
            this.MetaDefCN = toCopy.MetaDefCN;
            this.OnBnd = toCopy.OnBnd;
            this._GroupName = toCopy._GroupName;
            this._GroupCN = toCopy._GroupCN;
        }

        public void CopyInfo(TtPoint toCopy)
        {
            this._CN = toCopy._CN;
            if (this.Comment == null || this.Comment == String.Empty)
            {
                this.Comment = toCopy.Comment;
            }
            this.Index = toCopy.Index;
            this.PolyCN = toCopy.PolyCN;
            this.PolyName = toCopy.PolyName;
            this.PID = toCopy.PID;
            this._LinkedPoints = toCopy._LinkedPoints;
            this.MetaDefCN = toCopy.MetaDefCN;
            this._GroupName = toCopy._GroupName;
            this._GroupCN = toCopy._GroupCN;
        }

        private string _GroupCN;
        public string GroupCN
        {
            get { return _GroupCN; }
            set { _GroupCN = value; }
        }

        private string _GroupName;
        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }

        public string CN 
        {
            get
            {
                if (_CN == String.Empty)
                {
                    _CN = System.Guid.NewGuid().ToString();
                }
                return _CN;
            }
            set { _CN = value; }
        }

        public string PolyCN { get; set; }
        public string PolyName { get; set; }
        public int PID { get; set; }
        public string Comment { get; set; }
        /*
        private string _comment;
        public string Comment           
        {
            get { return _comment; }
            set { _comment = value; }
        }
        */

        public string MetaDefCN { get; set; }

        public bool OnBnd { get; set; }

        public double AdjX { get; set; }
        public double AdjY { get; set; }
        public double AdjZ { get; set; }

        public virtual double UnAdjX { get; set; }
        public virtual double UnAdjY { get; set; }
        public virtual double UnAdjZ { get; set; }

        public TwoTrails.Engine.OpType op { get { return _op; } }

        public long Index { get; set; }
        /*{
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }
        */

        public virtual bool Calculated { get { return _calculated; } }
        public virtual bool Adjusted { get { return _adjusted; } }

        public DateTime Time { get; set; }


        #region Quondam Links
        protected List<string> _LinkedPoints;

        public List<string> LinkedPoints
        {
            get { return _LinkedPoints; }
        }

        public bool HasQuondamLinks
        {
            get { return (_LinkedPoints.Count > 0); }
        }

        public void AddQuondamLink(TtPoint p)
        {
            AddQuondamLink(p.CN);
        }

        public void AddQuondamLink(string cn)
        {
            if(_LinkedPoints.IndexOf(cn) < 0)
                _LinkedPoints.Add(cn);
        }

        public void RemoveQuondamLink(TtPoint p)
        {
            RemoveQuondamLink(p.CN);
        }

        public void RemoveQuondamLink(string cn)
        {
            _LinkedPoints.Remove(cn);
        }

        #endregion


        public override string ToString()
        {
            return String.Format("{0}: {1}", PID, op);
        }


        public bool IsGpsType()
        {
            return (_op == OpType.GPS || _op == OpType.Take5 || _op == OpType.Walk || _op == OpType.WayPoint);
        }

        public bool IsTravType()
        {
            return (_op == OpType.SideShot || _op == OpType.Traverse);
        }

        public bool IsBndPoint()
        {
            return OnBnd && _op != OpType.WayPoint;
        }

        public bool IsNavPoint()
        {
            if(_op == OpType.GPS || _op == OpType.Take5 || _op == OpType.Walk || _op == OpType.Traverse)
                return true;
            else if (_op == OpType.Quondam)
            {
                QuondamPoint qp = (QuondamPoint)this;

                if (qp.ParentPoint != null && qp.ParentPoint.IsNavPoint())
                    return true;
            }

            return false;
        }


        public bool SameAdjLocation(TtPoint point)
        {
            if (this.AdjX == point.AdjX && this.AdjY == point.AdjY && this.AdjZ == point.AdjZ)
                return true;
            return false;
        }

        public bool SameUnAdjLocation(TtPoint point)
        {
            if (this.UnAdjX == point.UnAdjX && this.UnAdjY == point.UnAdjY && this.UnAdjZ == point.UnAdjZ)
                return true;
            return false;
        }


        public int Compare(TtPoint p1, TtPoint p2)
        {
            if (p1 == null && p2 == null)
                return 0;

            if (p1 == null && p2 != null)
                return -1;

            if (p1 != null && p2 == null)
                return 1;

            int val = p1.PolyName.CompareTo(p2.PolyName);

            if (val != 0)
                return val;
            else
            {
                val = p1.Index.CompareTo(p2.Index);

                if (val != 0)
                    return val;
                else
                {
                    val = p1.PID.CompareTo(p2.PID);

                    if (val != 0)
                        return val;
                    else
                        return p1.CN.CompareTo(p2.CN);
                        //return this.CN.CompareTo(p2.CN);
                }
            }
        }

        public int CompareTo(TtPoint p)
        {
            return Compare(this, p);
        }


        public virtual bool AdjustPoint()
        {
            return false;
        }

        public virtual bool AdjustPoint(TtPoint source)
        {
            return false;
        }

        /*
        public virtual bool ProcessPoint()
        {
            return true;
        }
        */

        public virtual bool CalculatePoint()
        {
            return true;
        }

        public virtual bool CalculatePoint(TtPoint previousPoint)
        {
            return true;
        }
    }
}