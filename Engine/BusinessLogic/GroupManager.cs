using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;

namespace TwoTrails.BusinessLogic
{
    public class GroupManager
    {
        public static readonly string GCN = "00000000-0000-0000-0000-000000000000";
        public static readonly TtGroup MainGroup = new TtGroup() { Name = "No Group",
            CN = GCN, Description = String.Empty, GroupType = GroupType.General };

        private Dictionary<string, TtGroup> _Groups;
        public Dictionary<string, TtGroup> Groups
        {
            get { return _Groups; }
            set { _Groups = value; }
        }

        public GroupManager()
        {
            _Groups = new Dictionary<string, TtGroup>();
            _Groups.Add(MainGroup.CN, MainGroup);
        }

        public void InitGroups(DataAccessLayer dal)
        {
            Groups = dal.GetGroups().ToDictionary(k => k.CN, g => g);
        }

        public bool AddGroup(TtGroup group, DataAccessLayer dal)
        {
            if (!Groups.ContainsKey(group.CN))
            {
                Groups.Add(group.CN, group);
                if (dal.InsertGroup(group) > 0)
                    return true;

                Groups.Remove(group.CN);
            }

            return false;
        }

        public bool DeleteGroup(string cn, DataAccessLayer dal)
        {
            return DeleteGroup(cn, dal, false);
        }

        public bool DeleteGroup(string cn, DataAccessLayer dal, bool deletePoints)
        {
            if (Groups.ContainsKey(cn))
            {
                List<TtPoint> points = dal.GetPointsInGroup(cn);

                if (deletePoints)
                {
                    dal.DeletePointsInGroup(cn);
                }
                else
                {
                    for (int i = 0; i < points.Count; i++)
                    {
                        points[i].GroupCN = MainGroup.CN;
                        points[i].GroupName = MainGroup.Name;
                    }

                    dal.SavePoints(points, points);
                }

                _Groups.Remove(cn);

                return dal.DeleteGroup(cn);
            }

            return false;
        }

        public void SaveGroup(string cn, DataAccessLayer dal)
        {
            dal.UpdateGroup(Groups[cn], Groups[cn]);
        }

        public void SaveGroups(DataAccessLayer dal)
        {
            dal.UpdateGroups(Groups.Values.ToList());
        }

        public bool MergeGroups(string cn1, string cn2, DataAccessLayer dal)
        {
            if (Groups.ContainsKey(cn1) && Groups.ContainsKey(cn2))
                return MergeGroups(Groups[cn1], Groups[cn2], dal);
            return false;
        }

        public bool MergeGroups(TtGroup group1, TtGroup group2, DataAccessLayer dal)
        {
            List<TtPoint> points = dal.GetPointsInGroup(group2.CN);  //group2.Points.Values.ToList();

            for (int i = 0; i < points.Count; i++)
            {
                points[i].GroupCN = group1.CN;
                points[i].GroupName = group1.Name;
            }

            //group1.AddPointsToGroup(points);

            dal.SavePoints(points, points);
            return dal.DeleteGroup(group2.CN);
        }
    }
}
