using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using TwoTrails.BusinessObjects;
using TwoTrails.Engine;
using TwoTrails.GpsAccess;
using TwoTrails.Utilities;
using System.Drawing;

namespace TwoTrails.DataAccess
{
    public class MediaAccessLayer
    {
        private string _filePath;
        private SQLiteConnection _dbConnection = null;
        
        public MediaAccessLayer(string path) 
        {
            try
            {
                _filePath = path;
                OpenMAL();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MediaAccessLayer:Constructor");
            }
        }

        private MediaAccessLayer _upgradeData;

        public bool IsOpen
        {
            get
            {
                if (_dbConnection == null) { return false; }
                return (_dbConnection.State == System.Data.ConnectionState.Open);
            }
        }

        #region Create Tables

        public void CreateTables()
        {
            CreatePicTable();
        }

        private void CreatePicTable()
        {
            StringBuilder sqlCmd = new StringBuilder();
            sqlCmd.AppendFormat(@"CREATE TABLE {0}({1} TEXT, {2} TEXT, {3} TEXT, {4} TEXT, 
                {5} TEXT, {6} REAL, {7} REAL, {8} REAL, {9} TEXT, 
                {10} REAL, {11} REAL, {12} BLOB, PRIMARY KEY ({1}))",
                TwoTrailsSchema.PictureSchema.TableName,    //0
                TwoTrailsSchema.PictureSchema.CN,
                TwoTrailsSchema.PictureSchema.FileName,
                TwoTrailsSchema.PictureSchema.Time,
                TwoTrailsSchema.PictureSchema.PicType,      
                TwoTrailsSchema.PictureSchema.FileType,     //5
                TwoTrailsSchema.PictureSchema.UtmX,
                TwoTrailsSchema.PictureSchema.UtmY,         
                TwoTrailsSchema.PictureSchema.Elev,         //8
                TwoTrailsSchema.PictureSchema.Comment,
                TwoTrailsSchema.PictureSchema.Az,           
                TwoTrailsSchema.PictureSchema.Acc,
                TwoTrailsSchema.PictureSchema.PicData);     //12

            try
            {
                SQLiteCommand cmd = _dbConnection.CreateCommand();
                cmd.CommandText = sqlCmd.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MediaAccessLayer:CreatePicTable");
            }
        }

        #endregion

        #region Connection/Connection String

        private string GetConnectionString(string path)
        {
            return String.Format("URI=file:{0}; New=False; foreign keys=false", path);   //Saves Data Correctly
            //return String.Format("Data Source={0};New=False;foreign keys=on", path);
        }

        public string GetConnectionString()
        {
            return GetConnectionString(_filePath);
        }

        //get the sqlite connection
        private SQLiteConnection OpenDB()
        {
            return new SQLiteConnection(GetConnectionString(_filePath));
        }

        #endregion

        #region Open/Close/Upgrade

        public void OpenMAL()
        {
            if (!IsOpen)
            {
                _dbConnection = OpenDB();
                _dbConnection.Open();

                TtUtils.WriteEvent(String.Format("File Opened: {0}", System.IO.Path.GetFileName(_filePath)));
            }
        }

        public void CloseDB()
        {
            if (IsOpen)
            {
                _dbConnection.Close();
                //_dbConnection.Dispose();
                TtUtils.WriteEvent(String.Format("File Closed: {0}", System.IO.Path.GetFileName(_filePath)));
            }
        }

        #region Upgrade
        public bool Upgrade(MediaAccessLayer oldData)
        {
            _upgradeData = oldData;

            if (_upgradeData != null)
            {
                
            }

            return false;
        }

        #endregion

        #endregion


        #region Pictures

        public void InsertPicture(TtPicture pic)
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();
            InsertPicture(pic, trans);
            trans.Commit();
        }

        private bool InsertPicture(TtPicture pic, SQLiteTransaction trans)
        {
            try
            {
                if (!pic.IsValid)
                    throw new Exception("Invalid TtPicture");

                using (SQLiteCommand cmd = _dbConnection.CreateCommand())
                {
                    StringBuilder queryBeginning = new StringBuilder();
                    StringBuilder queryEnd = new StringBuilder();

                    if (pic.CN == String.Empty)
                        pic.CN = Guid.NewGuid().ToString();

                    queryBeginning.AppendFormat("INSERT INTO {0} (", TwoTrailsSchema.PictureSchema.TableName);
                    queryEnd.Append("(");

                    //CN
                    queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.CN);
                    queryEnd.AppendFormat("'{0}',", pic.CN);


                    queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.PicData);
                    queryEnd.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.PicDataValue);
                    cmd.Parameters.Add(TwoTrailsSchema.PictureSchema.PicDataValue, System.Data.DbType.Binary).Value =
                        ((pic.HasData) ? pic.GetPictureBytes() : new byte[0]);

                    queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.Time);
                    queryEnd.AppendFormat("'{0}',", pic.Time.ToString());

                    queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.PicType);
                    queryEnd.AppendFormat("'{0}',", pic.Type);

                    queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.FileType);
                    queryEnd.AppendFormat("'{0}',", pic.FileType);

                    queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.FileName);
                    queryEnd.AppendFormat("'{0}',", pic.FileName);


                    queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.UtmX);
                    queryEnd.AppendFormat("{0},", pic.UtmX);

                    queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.UtmY);
                    queryEnd.AppendFormat("{0},", pic.UtmY);

                    queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.Elev);
                    queryEnd.AppendFormat("{0},", pic.Elevation);


                    queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.Comment);
                    queryEnd.AppendFormat("'{0}',", pic.Comment);


                    queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.Az);
                    queryEnd.AppendFormat("{0},", pic.Azimuth == null ? "null" : String.Format("'{0}'", pic.Azimuth.ToString()));

                    queryBeginning.AppendFormat("{0}", TwoTrailsSchema.PictureSchema.Acc);
                    queryEnd.AppendFormat("{0}", pic.Accuracy == null ? "null" : String.Format("'{0}'", pic.Accuracy.ToString()));

                    queryBeginning.Append(") values ");
                    queryEnd.Append(");");
                    queryBeginning.AppendFormat(" {0}", queryEnd.ToString());

                    cmd.Transaction = trans;
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                //
                return false;
            }

            return true;
        }

        public bool SavePicture(TtPicture pic)
        {
            bool saved = true;

            try
            {
                SQLiteTransaction trans = _dbConnection.BeginTransaction();
                saved = InsertPicture(pic, trans);
                trans.Commit();
            }
            catch
            {
                saved = false;
            }

            return saved;
        }

        private void SavePicture(TtPicture oldPic, TtPicture pic, SQLiteTransaction trans)
        {
            if (oldPic.CN != pic.CN)
                throw new Exception("Mismatch Picture CN");

            using (SQLiteCommand update = _dbConnection.CreateCommand())
            {
                StringBuilder queryBeginning = new StringBuilder();
                StringBuilder queryEnd = new StringBuilder();
                queryBeginning.AppendFormat("Update {0} set ", TwoTrailsSchema.PictureSchema.TableName);
                queryEnd.Append("(");

                queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.PicData);
                queryEnd.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.PicDataValue);
                update.Parameters.Add(TwoTrailsSchema.PictureSchema.PicDataValue, System.Data.DbType.Binary).Value =
                    ((pic.HasData) ? pic.GetPictureBytes() : new byte[0]);

                queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.Time);
                queryEnd.AppendFormat("'{0}',", pic.Time);

                queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.PicType);
                queryEnd.AppendFormat("'{0}',", pic.Type);

                queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.FileType);
                queryEnd.AppendFormat("'{0}',", pic.FileType);

                queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.FileName);
                queryEnd.AppendFormat("'{0}',", pic.FileName);


                queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.UtmX);
                queryEnd.AppendFormat("{0},", pic.UtmX);

                queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.UtmY);
                queryEnd.AppendFormat("{0},", pic.UtmY);

                queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.Elev);
                queryEnd.AppendFormat("{0},", pic.Elevation);


                queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.Comment);
                queryEnd.AppendFormat("'{0}',", pic.Comment);


                queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PictureSchema.Az);
                queryEnd.AppendFormat("{0},", pic.Azimuth == null ? "null" : String.Format("'{0}'", pic.Azimuth.ToString()));

                queryBeginning.AppendFormat("{0}", TwoTrailsSchema.PictureSchema.Acc);
                queryEnd.AppendFormat("{0}", pic.Accuracy == null ? "null" : String.Format("'{0}'", pic.Accuracy.ToString()));

                queryBeginning.Append(") values ");
                queryEnd.Append(");");

                queryBeginning.AppendFormat(" {0}", queryEnd.ToString());
                if (!IsOpen)
                    OpenDB();

                if (trans != null)
                    update.Transaction = trans;
                update.CommandText = queryBeginning.ToString();
                update.ExecuteNonQuery();
            }
        }



        public TtPicture GetPicture(string cn)
        {
            List<TtPicture> pics = GetPictures(String.Format("where {0} = '{1}'",
                TwoTrailsSchema.PictureSchema.CN, cn));
            if (pics.Count > 0)
                return pics[0];
            return null;
        }

        public List<TtPicture> GetPictures()
        {
            return GetPictures(String.Empty);
        }

        public List<TtPicture> GetPictures(List<string> picCNs)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.PictureSchema.CN,
                picCNs[0]);

            for (int i = 1; i < picCNs.Count; i++)
            {
                sb.AppendFormat(" OR {0} = '{1}'",
                 TwoTrailsSchema.PictureSchema.CN,
                 picCNs[i]);
            }

            return GetPictures(sb.ToString());
        }

        public List<TtPicture> GetPicturesWithin(double utmX, double utmY, double meters)
        {
            double ltX, gtX, ltY, gtY;

            ltX = utmX + meters;
            gtX = utmX - meters;

            ltY = utmY + meters;
            gtY = utmY - meters;

            return GetPictures(String.Format("{0} < {1} AND {0} > {2} AND {3} < {4} AND {3} > 5",
                TwoTrailsSchema.PictureSchema.UtmX, ltX, gtX, TwoTrailsSchema.PictureSchema.UtmY, ltY, gtY));
        }

        private List<TtPicture> GetPictures(string where)
        {
            List<TtPicture> pics = new List<TtPicture>();

            StringBuilder query = new StringBuilder();
            query.AppendFormat("SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11} from {12} ",
                TwoTrailsSchema.PictureSchema.CN,
                TwoTrailsSchema.PictureSchema.FileName,
                TwoTrailsSchema.PictureSchema.Time,
                TwoTrailsSchema.PictureSchema.PicType,
                TwoTrailsSchema.PictureSchema.FileType,
                TwoTrailsSchema.PictureSchema.PicData,
                TwoTrailsSchema.PictureSchema.UtmX,
                TwoTrailsSchema.PictureSchema.UtmY,
                TwoTrailsSchema.PictureSchema.Elev,
                TwoTrailsSchema.PictureSchema.Comment,
                TwoTrailsSchema.PictureSchema.Acc,
                TwoTrailsSchema.PictureSchema.Az,
                TwoTrailsSchema.PictureSchema.TableName);

            if (!where.IsEmpty())
                query.AppendFormat("WHERE {0}", where);

            SQLiteCommand cmd = _dbConnection.CreateCommand();
            cmd.CommandText = query.ToString();


            TtPicture pic = new TtPicture();
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                pic.CN = reader.GetString(0);

                if(!reader.IsDBNull(1))
                    pic.FileName = reader.GetString(1);
                if (!reader.IsDBNull(2))
                    pic.Time = DateTime.Parse(reader.GetString(2));
                if (!reader.IsDBNull(3))
                    pic.Type = (PictureType)Enum.Parse(typeof(PictureType), reader.GetString(4), true);
                if (!reader.IsDBNull(4))
                    pic.FileType = (PicFileType)Enum.Parse(typeof(PicFileType), reader.GetString(4), true);
                if (!reader.IsDBNull(5))
                {
                    pic.PictureData = reader.GetBytesEx();
                }
                if(!reader.IsDBNull(6))
                    pic.UtmX = reader.GetDouble(6);
                if (!reader.IsDBNull(7))
                    pic.UtmY = reader.GetDouble(7);
                if (!reader.IsDBNull(8))
                    pic.Elevation = reader.GetDouble(8);
                if (!reader.IsDBNull(9))
                    pic.Comment = reader.GetString(9);
                if (!reader.IsDBNull(10))
                    pic.Accuracy = reader.GetDouble(10);
                if (!reader.IsDBNull(11))
                    pic.Azimuth = reader.GetDouble(11);

                pics.Add(pic);
                pic = new TtPicture();
            }

            return pics;
        }
        #endregion
    }
}
