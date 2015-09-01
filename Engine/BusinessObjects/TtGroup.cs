using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTrails.DataAccess;
using TwoTrails.Engine;
using TwoTrails.Utilities;

namespace TwoTrails.BusinessObjects
{
    public enum GroupType
    {
        General,
        Walk,
        Take5
    }

    public class TtGroup
    {
        protected string _CN;
        public string CN { get { return _CN; } set { _CN = value; } }

        protected string _Name;
        public string Name { get { return _Name; } internal set { _Name = value; } }

        protected string _Desc;
        public string Description { get { return _Desc; } set { _Desc = value; } }

        public double? ManualAccuracy { get; private set; }
        public GroupType GroupType { get; set; }
        
        private List<string> _PointCNs;
        public List<string> PointCNs { get { return _PointCNs; } }
        public int NumberOfPoints { get { return _PointCNs.Count; } }

        /*
        protected Dictionary<string, TtPoint> _Points;
        public Dictionary<string, TtPoint> Points { get { return _Points; } }

        public int NumberOfPoints { get; set; }
        public int NumOfTraversePoints { get; set; }
        public int NumOfSideShotPoints { get; set; }
        public int NumOfQndPoints { get; set; }
        public int NumOfGpsPoints { get; set; }
        public int NumOfGpsTypePoints { get; set; }
        public int NumOfWayPoints { get; set; }
        public int NumOfWalkPoints { get; set; }
        public int NumOfTake5Points { get; set; }
        public int NumOfPointsOnBnd { get; set; }
        public int NumOfPointsOffBnd { get; set; }
        */

        public TtGroup()
        {
            _CN = Guid.NewGuid().ToString();
            _Name = String.Empty;
            GroupType = GroupType.Walk;
            ManualAccuracy = null;
            _Desc = String.Empty;

            _PointCNs = new List<string>();

            /*
            _Points = new Dictionary<string, TtPoint>();

            NumberOfPoints = 0;
            NumOfTraversePoints = 0;
            NumOfSideShotPoints = 0;
            NumOfQndPoints = 0;
            NumOfGpsPoints = 0;
            NumOfGpsTypePoints = 0;
            NumOfWayPoints = 0;
            NumOfWalkPoints = 0;
            NumOfTake5Points = 0;
            NumOfPointsOnBnd = 0;
            NumOfPointsOffBnd = 0;
            */
        }

        public TtGroup(string name)
        {
            _CN = Guid.NewGuid().ToString();
            _Name = name;
            GroupType = GroupType.Walk;
            ManualAccuracy = null;
            _Desc = String.Empty;

            _PointCNs = new List<string>();

            /*
            _Points = new Dictionary<string, TtPoint>();

            NumberOfPoints = 0;
            NumOfTraversePoints = 0;
            NumOfSideShotPoints = 0;
            NumOfQndPoints = 0;
            NumOfGpsPoints = 0;
            NumOfGpsTypePoints = 0;
            NumOfWayPoints = 0;
            NumOfWalkPoints = 0;
            NumOfTake5Points = 0;
            NumOfPointsOnBnd = 0;
            NumOfPointsOffBnd = 0;
            */
        }

        public TtGroup(string cn, string name, double manAcc, string desc, GroupType gt)
        {
            _CN = cn;
            _Name = name;
            ManualAccuracy = manAcc;
            GroupType = gt;
            _Desc = desc;

            _PointCNs = new List<string>();
            
            /*
            _Points = new Dictionary<string, TtPoint>();

            NumberOfPoints = 0;
            NumOfTraversePoints = 0;
            NumOfSideShotPoints = 0;
            NumOfQndPoints = 0;
            NumOfGpsPoints = 0;
            NumOfGpsTypePoints = 0;
            NumOfWayPoints = 0;
            NumOfWalkPoints = 0;
            NumOfTake5Points = 0;
            NumOfPointsOnBnd = 0;
            NumOfPointsOffBnd = 0;
            */
        }

        public TtGroup(TtGroup ttgroup)
        {
            _CN = ttgroup._CN;
            _Name = ttgroup._Name;
            //NumberOfPoints = ttgroup.NumberOfPoints;
            ManualAccuracy = ttgroup.ManualAccuracy;
            GroupType = ttgroup.GroupType;
            _Desc = ttgroup._Desc;

            _PointCNs = ttgroup.PointCNs;

            /*
            _Points = ttgroup._Points;

            NumOfTraversePoints = ttgroup.NumOfTraversePoints;
            NumOfSideShotPoints = ttgroup.NumOfSideShotPoints;
            NumOfQndPoints = ttgroup.NumOfQndPoints;
            NumOfGpsPoints = ttgroup.NumOfGpsPoints;
            NumOfGpsTypePoints = ttgroup.NumOfGpsTypePoints;
            NumOfWayPoints = ttgroup.NumOfWayPoints;
            NumOfWalkPoints = ttgroup.NumOfWalkPoints;
            NumOfTake5Points = ttgroup.NumOfTake5Points;
            NumOfPointsOnBnd = ttgroup.NumOfPointsOnBnd;
            NumOfPointsOffBnd = ttgroup.NumOfPointsOffBnd;
            */
        }

        public void Init(List<string> cns)
        {
            _PointCNs = cns;
        }

        /// <summary>
        /// Sets Manual Accuracy to all Gps Type Points.
        /// </summary>
        /// <param name="acc">Accuracy</param>
        /// <param name="dal">DataAccessLayer</param>
        public void SetGroupManualAccuracy(double acc, DataAccessLayer dal)
        {
            if (acc < 0)
                return;

            ManualAccuracy = acc;

            if (dal == null)
                return;

            List<GpsPoint> gpsPoints = dal.GetPointsInGroup(this.CN)
                .Where(p => p.IsGpsType())
                .Cast<GpsPoint>()
                .ToList();

            for (int i = 0; i < gpsPoints.Count; i++)
                gpsPoints[i].ManualAccuracy = ManualAccuracy;

            dal.SavePoints(gpsPoints);
        }

        public void SetGroupName(string name, DataAccessLayer dal)
        {
            if (name.IsEmpty())
                return;

            Name = name;

            if (dal == null)
                return;

            List<TtPoint> points = dal.GetPointsInGroup(this.CN)
                .Where(p => p.IsGpsType())
                .ToList();

            for (int i = 0; i < points.Count; i++)
                points[i].GroupName = Name;

            dal.SavePoints(points, points);
        }

        public void AddPointsToGroup(List<TtPoint> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                AddPointToGroup(points[i]);
            }
        }

        public void AddPointToGroup(TtPoint point)
        {
            if (!PointCNs.Contains(point.CN))
            {
                point.GroupCN = CN;
                point.GroupName = Name;
                _PointCNs.Add(point.CN);
            }

            /*
            if (!_Points.ContainsKey(point.CN))
            {
                point.GroupCN = CN;
                point.GroupName = Name;

                _Points.Add(point.CN, point);

                NumberOfPoints++;

                switch (point.op)
                {
                    case OpType.GPS:
                        {
                            NumOfGpsPoints++;
                            NumOfGpsTypePoints++;
                            break;
                        }
                    case OpType.WayPoint:
                        {
                            NumOfWayPoints++;
                            NumOfGpsTypePoints++;
                            break;
                        }
                    case OpType.Traverse:
                        {
                            NumOfTraversePoints++;
                            break;
                        }
                    case OpType.SideShot:
                        {
                            NumOfSideShotPoints++;
                            break;
                        }
                    case OpType.Quondam:
                        {
                            NumOfQndPoints++;
                            break;
                        }
                    case OpType.Walk:
                        {
                            NumOfWalkPoints++;
                            NumOfGpsTypePoints++;
                            break;
                        }
                    case OpType.Take5:
                        {
                            NumOfTake5Points++;
                            NumOfGpsTypePoints++;
                            break;
                        }
                }

                if (point.OnBnd)
                    NumOfPointsOnBnd++;
                else
                    NumOfPointsOffBnd++;
            }
            */
        }

        public void RemovePointFromGroup(TtPoint point)
        {
            if (PointCNs.Contains(point.CN))
            {
                point.GroupName = Values.MainGroup.Name;
                point.GroupCN = Values.MainGroup.CN;
                _PointCNs.Remove(point.CN);
            }

            /*
            if (_Points.ContainsKey(point.CN))
            {
                _Points.Remove(point.CN);

                NumberOfPoints--;

                switch (point.op)
                {
                    case OpType.GPS:
                        {
                            NumOfGpsPoints--;
                            NumOfGpsTypePoints--;
                            break;
                        }
                    case OpType.WayPoint:
                        {
                            NumOfWayPoints--;
                            NumOfGpsTypePoints--;
                            break;
                        }
                    case OpType.Traverse:
                        {
                            NumOfTraversePoints--;
                            break;
                        }
                    case OpType.SideShot:
                        {
                            NumOfSideShotPoints--;
                            break;
                        }
                    case OpType.Quondam:
                        {
                            NumOfQndPoints--;
                            break;
                        }
                    case OpType.Walk:
                        {
                            NumOfWalkPoints--;
                            NumOfGpsTypePoints--;
                            break;
                        }
                    case OpType.Take5:
                        {
                            NumOfTake5Points--;
                            NumOfGpsTypePoints--;
                            break;
                        }
                }

                if (point.OnBnd)
                    NumOfPointsOnBnd--;
                else
                    NumOfPointsOffBnd--;
            }
            */
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
