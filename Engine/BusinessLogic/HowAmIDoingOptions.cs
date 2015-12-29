using System;
using System.Collections.Generic;
using System.Text;
using TwoTrails.DataAccess;

namespace Engine.BusinessLogic
{
    public class HowAmIDoingOptions
    {
        private DataAccessLayer _data;
        public DataAccessLayer Data { get { return _data; } }

        public bool SaveReport { get; set; }

        public string ReportPath { get; set; }

        public StringBuilder ReportText { get; set; }

        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string TtFilePath { get; set; }
        public string Region { get; set; }
        public string Forest { get; set; }
        public string District { get; set; }
        public string Year { get; set; }


        public HowAmIDoingOptions(DataAccessLayer dal)
        {
            _data = dal;
            SaveReport = false;
            ReportPath = String.Empty;
            ReportText = new StringBuilder();
        }

        public void PopulateFromDataLayer()
        {
            ProjectName = _data.GetProjectID();
            ProjectDescription = _data.GetProjectDescription();
            Region = _data.GetProjectRegion();
            Forest = _data.GetProjectForest();
            District = _data.GetProjectDistrict();
            Year = _data.GetProjectYear();
        }
    }
}