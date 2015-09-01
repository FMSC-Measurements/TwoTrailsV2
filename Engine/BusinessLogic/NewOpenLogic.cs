using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;
using TwoTrails.Engine;

namespace TwoTrails.BusinessLogic
{
    public class NewOpenLogic
    {
        //private static string _connectionString;

        public static DataAccess.DataAccessLayer NewTwoTrailsFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            /*
            StringBuilder sbConnStr = new StringBuilder();
            sbConnStr.AppendFormat("URI=file:{0};Version=3;", path);  
            _connectionString = sbConnStr.ToString();
            */

            //_connectionString = String.Format("URI=file:{0};Version=3;", path);
        
            DataAccess.DataAccessLayer db = new DataAccess.DataAccessLayer(path, true);

            if (db.IsOpen)
            {
                db.CreateTables();

                TtUtils.WriteEvent(String.Format("File Created: {0}", System.IO.Path.GetFileName(path)));
                return db;
            }
            else
                TtUtils.WriteEvent(String.Format("Failed to Create: {0}", System.IO.Path.GetFileName(path)));

            return null;
        }
    }
}