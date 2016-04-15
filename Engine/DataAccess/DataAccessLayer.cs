using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using TwoTrails.BusinessObjects;
using TwoTrails.Engine;
using TwoTrails.GpsAccess;
using TwoTrails.Utilities;
using TwoTrails.BusinessLogic;

namespace TwoTrails.DataAccess
{
    public partial class DataAccessLayer
    {        
        private string _filePath;
        private SQLiteConnection _dbConnection = null;

        public TtDalVersion DalVersion { get; private set; }

        public DataAccessLayer() { }
        public DataAccessLayer(string path) 
        {
            try
            {
                _filePath = path;
                OpenDAL();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:Constructor");
            }
        }

        public DataAccessLayer(string path, bool newFile)
        {
            try
            {
                _filePath = path;

                if (!IsOpen)
                {
                    _dbConnection = OpenDB();
                    _dbConnection.Open();

                    if(!newFile)
                        TtUtils.WriteEvent(String.Format("File Opened: {0}", System.IO.Path.GetFileName(_filePath)));
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:Constructor");
            }
        }

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
            CreatePolygonTable();
            CreateMetaDataTable();
            CreatePointTable();
            CreateGpsPointDataTable();
            CreateTravPointDataTable();
            CreateQuondamPointDataTable();
            CreateProjectInfoDataTable();
            CreateTtnmeaTable();
            CreateGroupTable();

            TtMetaData md = CreateDefaultMetaData();

            SetupProjInfo();
            DalVersion = TwoTrailsSchema.SchemaVersion;

            if (md == null)
            {
                throw new Exception("Invalid metadata.");
            }
            else
            {
                InsertMetaData(md);
            }

            InsertGroup(Values.MainGroup);
            SetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.TtVersion, Values.TwoTrailsVersion);
        }

        private void CreatePointTable()
        {
            StringBuilder sqlCmd = new StringBuilder();
            sqlCmd.AppendFormat("CREATE TABLE {0}", TwoTrailsSchema.PointSchema.TableName);
            sqlCmd.AppendFormat("({0} TEXT, {1} INTEGER NOT NULL , {2} INTEGER NOT NULL , {3} TEXT REFERENCES {5}, {4} TEXT REFERENCES {5}, ",
                TwoTrailsSchema.SharedSchema.CN,
                TwoTrailsSchema.PointSchema.Order,
                TwoTrailsSchema.PointSchema.ID,
                TwoTrailsSchema.PointSchema.Polygon,
                TwoTrailsSchema.PointSchema.PolyCN,
                TwoTrailsSchema.PolygonSchema.TableName);
            sqlCmd.AppendFormat("{0} BOOLEAN NOT NULL , {1} TEXT, {2} TEXT NOT NULL , {3} TEXT REFERENCES {4}, ",                
                TwoTrailsSchema.PointSchema.OnBoundary,
                TwoTrailsSchema.PointSchema.Comment,
                TwoTrailsSchema.PointSchema.Operation,
                TwoTrailsSchema.PointSchema.MetaDataID,
                TwoTrailsSchema.MetaDataSchema.TableName);
            sqlCmd.AppendFormat("{0} TEXT, {1} REAL, {2} REAL, {3} REAL, {4} REAL, {5} REAL, {6} REAL, {7} TEXT, {8} TEXT, {9} TEXT, PRIMARY KEY ({10}))",
                TwoTrailsSchema.PointSchema.Time,
                TwoTrailsSchema.PointSchema.AdjX,
                TwoTrailsSchema.PointSchema.AdjY,
                TwoTrailsSchema.PointSchema.AdjZ,
                TwoTrailsSchema.PointSchema.UnAdjX,
                TwoTrailsSchema.PointSchema.UnAdjY,
                TwoTrailsSchema.PointSchema.UnAdjZ,
                TwoTrailsSchema.PointSchema.QuondamLinks,
                TwoTrailsSchema.PointSchema.GroupName,
                TwoTrailsSchema.PointSchema.GroupCN,
                TwoTrailsSchema.SharedSchema.CN);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = sqlCmd.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:CreatePointTable");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        private void CreatePolygonTable()
        {
            StringBuilder sqlCmd = new StringBuilder();
            sqlCmd.AppendFormat("CREATE TABLE {0}({1} TEXT, {2} TEXT, {3} REAL, {4} TEXT, ",
                TwoTrailsSchema.PolygonSchema.TableName,
                TwoTrailsSchema.SharedSchema.CN,
                TwoTrailsSchema.PolygonSchema.PolyID,
                TwoTrailsSchema.PolygonSchema.Accuracy,
                TwoTrailsSchema.PolygonSchema.Description);
            sqlCmd.AppendFormat("{0} REAL, {1} REAL, {2} INTEGER, {3} INTEGER, PRIMARY KEY ({4}))",
                TwoTrailsSchema.PolygonSchema.Area,
                TwoTrailsSchema.PolygonSchema.Perimeter,
                TwoTrailsSchema.PolygonSchema.IncrementBy,
                TwoTrailsSchema.PolygonSchema.PointStartIndex,
                TwoTrailsSchema.SharedSchema.CN);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = sqlCmd.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:CreatePolygonTable");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        private void CreateGroupTable()
        {
            StringBuilder sqlCmd = new StringBuilder();
            sqlCmd.AppendFormat("CREATE TABLE {0}({1} TEXT, {2} TEXT, {3} REAL, {4} TEXT, {5} TEXT, PRIMARY KEY ({6}))",
                TwoTrailsSchema.GroupSchema.TableName,
                TwoTrailsSchema.GroupSchema.CN,
                TwoTrailsSchema.GroupSchema.Name,
                TwoTrailsSchema.GroupSchema.Accuracy,
                TwoTrailsSchema.GroupSchema.Description,
                TwoTrailsSchema.GroupSchema.Type,
                TwoTrailsSchema.GroupSchema.CN);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = sqlCmd.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:CreatePolygonTable");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        private void CreateMetaDataTable()
        {
            StringBuilder sqlCmd = new StringBuilder();
            sqlCmd.AppendFormat("CREATE TABLE {0}({1} TEXT NOT NULL, {2} TEXT, {3} TEXT NOT NULL , {4} TEXT NOT NULL , {5} REAL,",                
                TwoTrailsSchema.MetaDataSchema.TableName,
                TwoTrailsSchema.MetaDataSchema.CN,
                TwoTrailsSchema.MetaDataSchema.ID,
                TwoTrailsSchema.MetaDataSchema.UomDistance,
                TwoTrailsSchema.MetaDataSchema.UomSlope,
                TwoTrailsSchema.MetaDataSchema.MagDec);
            sqlCmd.AppendFormat("{0} TEXT, {1} TEXT, {2} TEXT, {3} TEXT, {4} TEXT, {5} TEXT,",
                TwoTrailsSchema.MetaDataSchema.DeclinationType,
                TwoTrailsSchema.MetaDataSchema.UomElevation,
                TwoTrailsSchema.MetaDataSchema.Comment,
                TwoTrailsSchema.MetaDataSchema.Datum,
                TwoTrailsSchema.MetaDataSchema.Receiver,
                TwoTrailsSchema.MetaDataSchema.Laser);
            sqlCmd.AppendFormat("{0} TEXT, {1} TEXT, {2} INTEGER,",
                TwoTrailsSchema.MetaDataSchema.Compass,
                TwoTrailsSchema.MetaDataSchema.Crew,
                TwoTrailsSchema.MetaDataSchema.UtmZone);

            sqlCmd.AppendFormat("PRIMARY KEY ({0}))", 
                TwoTrailsSchema.MetaDataSchema.CN);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = sqlCmd.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:CreateMetaDataTable");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        private void CreateGpsPointDataTable()
        {
            StringBuilder sqlCmd = new StringBuilder();
            sqlCmd.AppendFormat("CREATE TABLE {0}({1} TEXT REFERENCES {2}, {3} REAL, {4} REAL, {5} REAL, ", 
                TwoTrailsSchema.GpsPointSchema.TableName,
                TwoTrailsSchema.SharedSchema.CN,
                TwoTrailsSchema.PointSchema.TableName,
                TwoTrailsSchema.GpsPointSchema.X,
                TwoTrailsSchema.GpsPointSchema.Y,
                TwoTrailsSchema.GpsPointSchema.Z);
            sqlCmd.AppendFormat("{0} REAL, {1} REAL, PRIMARY KEY ({2}))",
                TwoTrailsSchema.GpsPointSchema.UserAccuracy,
                TwoTrailsSchema.GpsPointSchema.RMSEr,
                TwoTrailsSchema.SharedSchema.CN);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = sqlCmd.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:CreateGpsPointDataTable");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        private void CreateTravPointDataTable()
        {
            StringBuilder sqlCmd = new StringBuilder();
            sqlCmd.AppendFormat("CREATE TABLE {0}({1} TEXT REFERENCES {2}, {3} REAL, ", 
                TwoTrailsSchema.TravPointSchema.TableName,
                TwoTrailsSchema.SharedSchema.CN,
                TwoTrailsSchema.PointSchema.TableName,
                TwoTrailsSchema.TravPointSchema.ForwardAz);
            sqlCmd.AppendFormat("{0} REAL, {1} REAL, {2} REAL, {3} REAL, {4} REAL, PRIMARY KEY ({5}))",
                TwoTrailsSchema.TravPointSchema.BackAz,
                TwoTrailsSchema.TravPointSchema.SlopeDistance,
                TwoTrailsSchema.TravPointSchema.VerticalAngle,
                TwoTrailsSchema.TravPointSchema.HorizDistance,
                TwoTrailsSchema.TravPointSchema.Accuracy,
                TwoTrailsSchema.SharedSchema.CN);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = sqlCmd.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:CreateTravPointDataTable");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        private void CreateQuondamPointDataTable()
        {
            StringBuilder sqlCmd = new StringBuilder();
            sqlCmd.AppendFormat("CREATE TABLE {0} ({1} TEXT REFERENCES {4}, {2} TEXT REFERENCES {4}, {3} REAL, PRIMARY KEY ({1}))",
                TwoTrailsSchema.QuondamPointSchema.TableName,
                TwoTrailsSchema.SharedSchema.CN,
                TwoTrailsSchema.QuondamPointSchema.ParentPointCN,
                TwoTrailsSchema.QuondamPointSchema.UserAccuracy,
                TwoTrailsSchema.PointSchema.TableName);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = sqlCmd.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:CreateQuondamPointDataTable");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        private void CreateProjectInfoDataTable()
        {
            StringBuilder sqlCmd = new StringBuilder();
            sqlCmd.AppendFormat("CREATE TABLE {0}({1} TEXT, {2} TEXT, {3} TEXT, {4} TEXT, {5} BOOLEAN, {6} BOOLEAN,",
                TwoTrailsSchema.ProjectInfoSchema.TableName,
                TwoTrailsSchema.ProjectInfoSchema.CN,
                TwoTrailsSchema.ProjectInfoSchema.ID,
                TwoTrailsSchema.ProjectInfoSchema.District,
                TwoTrailsSchema.ProjectInfoSchema.Forest,
                TwoTrailsSchema.ProjectInfoSchema.DropZeros,
                TwoTrailsSchema.ProjectInfoSchema.Round);
            sqlCmd.AppendFormat("{0} TEXT, {1} TEXT, {2} TEXT, {3} INTEGER, {5} TEXT, {6} TEXT, {7} TEXT, PRIMARY KEY ({4}))",
                TwoTrailsSchema.ProjectInfoSchema.Region,
                TwoTrailsSchema.ProjectInfoSchema.DeviceID,
                TwoTrailsSchema.ProjectInfoSchema.Year,
                TwoTrailsSchema.ProjectInfoSchema.UtmZone,
                TwoTrailsSchema.ProjectInfoSchema.CN,
                TwoTrailsSchema.ProjectInfoSchema.Description,
                TwoTrailsSchema.ProjectInfoSchema.TtDbSchemaVersion,
                TwoTrailsSchema.ProjectInfoSchema.TtVersion);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = sqlCmd.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:CreateProjectInfoDataTable");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        private void CreateTtnmeaTable()
        {
            StringBuilder sqlCmd = new StringBuilder();
            sqlCmd.AppendFormat("CREATE TABLE {0} ({1} TEXT, {2} TEXT REFERENCES {4}, {3} INTEGER, ",
                TwoTrailsSchema.TtnmeaSchema.TableName, //0
                TwoTrailsSchema.TtnmeaSchema.CN,        //1
                TwoTrailsSchema.TtnmeaSchema.PointCN,   //2
                TwoTrailsSchema.TtnmeaSchema.Used,      //3
                TwoTrailsSchema.TtnmeaSchema.TableName); //4
            sqlCmd.AppendFormat("{0} TEXT, {1} REAL, {2} REAL, {3} REAL, {4} REAL, ",
                TwoTrailsSchema.TtnmeaSchema.DateTimeZulu,
                TwoTrailsSchema.TtnmeaSchema.Longitude,
                TwoTrailsSchema.TtnmeaSchema.Latitude,
                TwoTrailsSchema.TtnmeaSchema.UtmX,
                TwoTrailsSchema.TtnmeaSchema.UtmY);
            sqlCmd.AppendFormat("{0} TEXT, {1} TEXT, {2} REAL, {3} TEXT, {4} INTEGER, ",
                TwoTrailsSchema.TtnmeaSchema.LatDir,
                TwoTrailsSchema.TtnmeaSchema.LonDir,
                TwoTrailsSchema.TtnmeaSchema.MagVar,
                TwoTrailsSchema.TtnmeaSchema.MagDir,
                TwoTrailsSchema.TtnmeaSchema.UtmZone);
            sqlCmd.AppendFormat("{0} DOUBLE, {1} TEXT, {2} INTEGER, {3} TEXT, ",
                TwoTrailsSchema.TtnmeaSchema.Altitude,
                TwoTrailsSchema.TtnmeaSchema.AltUnit,
                TwoTrailsSchema.TtnmeaSchema.FixQuality,
                TwoTrailsSchema.TtnmeaSchema.DiffType);
            sqlCmd.AppendFormat("{0} INTEGER, {1} REAL, {2} REAL, {3} REAL, {4} INTEGER, {5} INTEGER, ",
                TwoTrailsSchema.TtnmeaSchema.Mode,
                TwoTrailsSchema.TtnmeaSchema.PDOP,
                TwoTrailsSchema.TtnmeaSchema.HDOP,
                TwoTrailsSchema.TtnmeaSchema.VDOP,
                TwoTrailsSchema.TtnmeaSchema.SatelliteCount,
                TwoTrailsSchema.TtnmeaSchema.SatelliteUsed);
            sqlCmd.AppendFormat("{0} REAL, {1} REAL, {2} TEXT, {3} REAL, {4} REAL, ",
                TwoTrailsSchema.TtnmeaSchema.HDo_Position,
                TwoTrailsSchema.TtnmeaSchema.HAE,
                TwoTrailsSchema.TtnmeaSchema.HAE_Unit,
                TwoTrailsSchema.TtnmeaSchema.Speed,
                TwoTrailsSchema.TtnmeaSchema.Track_Angle);
            sqlCmd.AppendFormat("{0} TEXT, {1} TEXT, {2} REAL, {3} REAL, {4} REAL, ",
                TwoTrailsSchema.TtnmeaSchema.PRNS,
                TwoTrailsSchema.TtnmeaSchema.PRN1ID,
                TwoTrailsSchema.TtnmeaSchema.PRN1Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN1Az,
                TwoTrailsSchema.TtnmeaSchema.PRN1SRN);
            sqlCmd.AppendFormat("{0} TEXT, {1} REAL, {2} REAL, {3} REAL, {4} TEXT, {5} REAL, {6} REAL, {7} REAL, ",
                TwoTrailsSchema.TtnmeaSchema.PRN2ID,
                TwoTrailsSchema.TtnmeaSchema.PRN2Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN2Az,
                TwoTrailsSchema.TtnmeaSchema.PRN2SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN3ID,
                TwoTrailsSchema.TtnmeaSchema.PRN3Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN3Az,
                TwoTrailsSchema.TtnmeaSchema.PRN3SRN);
            sqlCmd.AppendFormat("{0} TEXT, {1} REAL, {2} REAL, {3} REAL, {4} TEXT, {5} REAL, {6} REAL, {7} REAL, ",
                TwoTrailsSchema.TtnmeaSchema.PRN4ID,
                TwoTrailsSchema.TtnmeaSchema.PRN4Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN4Az,
                TwoTrailsSchema.TtnmeaSchema.PRN4SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN5ID,
                TwoTrailsSchema.TtnmeaSchema.PRN5Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN5Az,
                TwoTrailsSchema.TtnmeaSchema.PRN5SRN);
            sqlCmd.AppendFormat("{0} TEXT, {1} REAL, {2} REAL, {3} REAL, {4} TEXT, {5} REAL, {6} REAL, {7} REAL, ",
                TwoTrailsSchema.TtnmeaSchema.PRN6ID,
                TwoTrailsSchema.TtnmeaSchema.PRN6Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN6Az,
                TwoTrailsSchema.TtnmeaSchema.PRN6SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN7ID,
                TwoTrailsSchema.TtnmeaSchema.PRN7Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN7Az,
                TwoTrailsSchema.TtnmeaSchema.PRN7SRN);
            sqlCmd.AppendFormat("{0} TEXT, {1} REAL, {2} REAL, {3} REAL, {4} TEXT, {5} REAL, {6} REAL, {7} REAL, ",
                TwoTrailsSchema.TtnmeaSchema.PRN8ID,
                TwoTrailsSchema.TtnmeaSchema.PRN8Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN8Az,
                TwoTrailsSchema.TtnmeaSchema.PRN8SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN9ID,
                TwoTrailsSchema.TtnmeaSchema.PRN9Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN9Az,
                TwoTrailsSchema.TtnmeaSchema.PRN9SRN);
            sqlCmd.AppendFormat("{0} TEXT, {1} REAL, {2} REAL, {3} REAL, {4} TEXT, {5} REAL, {6} REAL, {7} REAL, ",
                TwoTrailsSchema.TtnmeaSchema.PRN10ID,
                TwoTrailsSchema.TtnmeaSchema.PRN10Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN10Az,
                TwoTrailsSchema.TtnmeaSchema.PRN10SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN11ID,
                TwoTrailsSchema.TtnmeaSchema.PRN11Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN11Az,
                TwoTrailsSchema.TtnmeaSchema.PRN11SRN);
            sqlCmd.AppendFormat("{0} TEXT, {1} REAL, {2} REAL, {3} REAL, PRIMARY KEY ({4}))",
                TwoTrailsSchema.TtnmeaSchema.PRN12ID,
                TwoTrailsSchema.TtnmeaSchema.PRN12Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN12Az,
                TwoTrailsSchema.TtnmeaSchema.PRN12SRN,
                TwoTrailsSchema.TtnmeaSchema.CN);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = sqlCmd.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:CreateTtnmeaTable");
            }
            finally
            {
                cmd.Dispose();
            }
        }
        #endregion

        #region Connection/Connection String

        private string GetConnectionString(string path)
        {
            return String.Format("URI=file:{0}; New=False; foreign keys=false", path);
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

        public void OpenDAL()
        {
            if (!IsOpen)
            {
                _dbConnection = OpenDB();
                _dbConnection.Open();

                DalVersion = GetProjectTtDbVersion();

                TtUtils.WriteEvent(String.Format("File Opened: {0}", System.IO.Path.GetFileName(_filePath)));
            }
        }

        public void CloseDB()
        {
            if (IsOpen)
            {
                if (_dbConnection != null)
                {
                    _dbConnection.Dispose();
                    _dbConnection = null;
                }

                GC.Collect();
                TtUtils.WriteEvent(String.Format("File Closed: {0}", System.IO.Path.GetFileName(_filePath)));
            }
        }

        #endregion

        #region Points

        #region Get Points

        public TtPoint GetFirstPointInPolygon(string polyCn)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.PointSchema.PolyCN, polyCn);
            List<TtPoint> points = GetPoints(where.ToString(), 1);

            if (points.Count > 0)
                return points[0];
            else
                return null;
        }

        public List<TtPoint> GetPointsInPolygon(TtPolygon p)
        {
            return GetPointsInPolygon(p.CN);
        }
        
        public List<TtPoint> GetPointsInPolygon(string polyCn)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.PointSchema.PolyCN,
                polyCn);

            return GetPoints(where.ToString());
        }

        public int GetNumberOfPointsinPolygon(string polyCn)
        {
            int num = -1;

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = String.Format("SELECT count(*) FROM {0} where {1} = '{2}'",
                    TwoTrailsSchema.PointSchema.TableName, TwoTrailsSchema.PointSchema.PolyCN, polyCn);
                num = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetNumberOfPointsinPolygon");
            }
            finally
            {
                cmd.Dispose();
            }

            return num;
        }

        public List<TtPoint> GetBoundaryPoints(string polyCN)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = '{1}' and {2} = '{3}'",
                TwoTrailsSchema.PointSchema.OnBoundary,
                "True",
                TwoTrailsSchema.PointSchema.PolyCN,
                polyCN);
            return GetPoints(where.ToString());
        }

        public List<TtPoint> GetNavigationPoints(string polyCN)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("({0} = '{1}' or {0} = '{2}' or {0} = '{3}' or {0} = '{4}') and {5} = '{6}'",
                TwoTrailsSchema.PointSchema.Operation,
                OpType.GPS.ToString(),
                OpType.Traverse.ToString(),
                OpType.WayPoint.ToString(),
                OpType.Walk.ToString(),
                TwoTrailsSchema.PointSchema.PolyCN,
                polyCN);
            return GetPoints(where.ToString());
        }

        public List<TtPoint> GetPointsInGroup(string groupCN)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.PointSchema.GroupCN,
                groupCN);

            return GetPoints(where.ToString());
        }

        public List<TtPoint> GetPointsByMeta(string metaCN)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.PointSchema.MetaDataID,
                metaCN);

            return GetPoints(where.ToString());
        }

        public List<TtPoint> GetGpsPointsByMeta(string metaCN)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = '{1}' and ({2} = '{3}' or {2} = '{4}' or {2} = '{5}' or {2} = '{6}')",
                TwoTrailsSchema.PointSchema.MetaDataID,
                metaCN,
                TwoTrailsSchema.PointSchema.Operation,
                OpType.GPS.ToString(),
                OpType.Walk.ToString(),
                OpType.Take5.ToString(),
                OpType.WayPoint.ToString());

            return GetPoints(where.ToString());
        }

        public List<string> GetPointCNsInGroup(string groupCN)
        {
            string query = String.Format("select {0} from {1} where {2} = '{3}'",
                TwoTrailsSchema.SharedSchema.CN,
                TwoTrailsSchema.PointSchema.TableName,
                TwoTrailsSchema.PointSchema.GroupCN,
                groupCN);

            List<string> pointCNs = new List<string>();

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = query;

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        pointCNs.Add(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetPointCNsInGroup");
            }
            finally
            {
                cmd.Dispose();
            }

            return pointCNs;
        }

        private List<TtPoint> GetPoints(string where)
        {
            return GetPoints(where, 0);
        }

        private List<TtPoint> GetPoints(string where, int limit)
        {
            StringBuilder query = new StringBuilder();
            StringBuilder fields = new StringBuilder();
            fields.AppendFormat("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}",
                TwoTrailsSchema.PointSchema.Comment,
                TwoTrailsSchema.PointSchema.ID,
                TwoTrailsSchema.PointSchema.MetaDataID,
                TwoTrailsSchema.PointSchema.OnBoundary,
                TwoTrailsSchema.PointSchema.Operation,
                TwoTrailsSchema.PointSchema.Order,
                TwoTrailsSchema.PointSchema.Polygon,
                TwoTrailsSchema.PointSchema.PolyCN,
                TwoTrailsSchema.PointSchema.AdjX,
                TwoTrailsSchema.PointSchema.AdjY,
                TwoTrailsSchema.PointSchema.AdjZ,
                TwoTrailsSchema.SharedSchema.CN,
                TwoTrailsSchema.PointSchema.Time,
                TwoTrailsSchema.PointSchema.UnAdjX,
                TwoTrailsSchema.PointSchema.UnAdjY,
                TwoTrailsSchema.PointSchema.UnAdjZ,
                TwoTrailsSchema.PointSchema.QuondamLinks,
                TwoTrailsSchema.PointSchema.GroupName,
                TwoTrailsSchema.PointSchema.GroupCN);
            query.AppendFormat("SELECT {0} from {1} ",
                fields.ToString(),
                TwoTrailsSchema.PointSchema.TableName);
            if (where != null)
                query.AppendFormat("WHERE {0} ", where); 
            query.AppendFormat("ORDER BY {0}, {1}{2}",
                TwoTrailsSchema.PointSchema.PolyCN,
                TwoTrailsSchema.PointSchema.Order,
                (limit > 0) ? String.Format(" LIMIT {0}", limit) : String.Empty);

            List<TtPoint> points = new List<TtPoint>();

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = query.ToString();

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TtPoint pt;
                    try
                    {
                        OpType o = (OpType)Enum.Parse(typeof(OpType), reader.GetString(4), true);
                        pt = GetNewPointByOpType(o);
                        if (!reader.IsDBNull(5))
                        {
                            pt.Index = reader.GetInt64(5);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    if (!reader.IsDBNull(0))
                        pt.Comment = reader.GetString(0);
                    pt.PID = reader.GetInt32(1);
                    pt.MetaDefCN = reader.GetString(2);

                    pt.OnBnd = Boolean.Parse(reader.GetString(3));  // <= 1.1
                    //pt.OnBnd = reader.GetBoolean(3);  // >= 1.2.0

                    pt.PolyName = reader.GetString(6);
                    pt.PolyCN = reader.GetString(7);
                    pt.AdjX = reader.GetDouble(8);
                    pt.AdjY = reader.GetDouble(9);
                    pt.AdjZ = reader.GetDouble(10);

                    pt.CN = reader.GetString(11);
                    pt.Time = Convert.ToDateTime(reader.GetString(12));
                    pt.UnAdjX = reader.GetDouble(13);
                    pt.UnAdjY = reader.GetDouble(14);
                    pt.UnAdjZ = reader.GetDouble(15);

                    if (!reader.IsDBNull(16))
                    {
                        string[] links = reader.GetString(16).Split('_');
                        foreach (string link in links)
                        {
                            if (link.Length == 36)   //length of GUID
                                pt.AddQuondamLink(link);
                        }
                    }

                    pt.GroupName = reader.GetString(17);
                    pt.GroupCN = reader.GetString(18);

                    points.Add(pt);

                    switch (pt.op)
                    {
                        case OpType.GPS:
                        case OpType.WayPoint:
                        case OpType.Take5:
                        case OpType.Walk:
                            {
                                GetGpsPointData(pt);
                                break;
                            }
                        case OpType.Traverse:
                        case OpType.SideShot:
                            {
                                GetTravPointData(pt);
                                break;
                            }
                        case OpType.Quondam:
                            {
                                GetQuondamPointData(pt);
                                break;
                            }
                        default:
                            { throw new Exception("Optype not implemented for retreival"); }
                    }
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetPoints");
            }
            finally
            {
                cmd.Dispose();
            }

            return points;
        }

        public List<TtPoint> GetPoints(OpType op)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.PointSchema.Operation,
                op.ToString());
            return GetPoints(sb.ToString());
        }

        public List<TtPoint> getPointsByCNs(List<string> PolyCNs)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.PointSchema.PolyCN,
                PolyCNs[0]);

            for (int i = 1; i < PolyCNs.Count; i++)
            {
                sb.AppendFormat(" OR {0} = '{1}'",
                 TwoTrailsSchema.PointSchema.PolyCN,
                 PolyCNs[i]);
            }

            return GetPoints(sb.ToString());
        }

        public List<TtPoint> getPointsByPointCNs(List<string> PointCNs)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.SharedSchema.CN,
                PointCNs[0]);

            for (int i = 1; i < PointCNs.Count; i++)
            {
                sb.AppendFormat(" OR {0} = '{1}'",
                 TwoTrailsSchema.SharedSchema.CN,
                 PointCNs[i]);
            }

            return GetPoints(sb.ToString());
        }

        public List<TtPoint> GetPoints()
        {
            return GetPoints(null);
        }

        public TtPoint GetPointAtIndexPoly(int index, string polyCn)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = {1} and {2} = '{3}'",
                TwoTrailsSchema.PointSchema.Order, index,
                TwoTrailsSchema.PointSchema.PolyCN, polyCn);
            List<TtPoint> points = GetPoints(where.ToString());
            
            if(points.Count > 0)
                return points[0];
            else
                return null;
        }

        public TtPoint GetPoint(string CN)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = '{1}'", TwoTrailsSchema.SharedSchema.CN, CN);
            List<TtPoint> points = GetPoints(where.ToString());

            if (points.Count > 0)
                return points[0];
            else
                return null;
        }

        public int GetLastIndexOfPoly(string CN)
        {
            List<TtPoint> list = GetPointsInPolygon(CN);

            if (list.Count > 0)
                return (int)(list[list.Count - 1].Index);
            else
                return -1;
        }


        private void GetQuondamPointData(TtPoint pt)
        {
            QuondamPoint q = (QuondamPoint)pt;
            StringBuilder fields = new StringBuilder();
            fields.AppendFormat("{0}, {1}, {2}",
                TwoTrailsSchema.SharedSchema.CN,
                TwoTrailsSchema.QuondamPointSchema.ParentPointCN,
                TwoTrailsSchema.QuondamPointSchema.UserAccuracy);

            StringBuilder query = new StringBuilder();
            query.AppendFormat("select {0} from {1} where {2} = '{3}'",
                fields.ToString(),
                TwoTrailsSchema.QuondamPointSchema.TableName,
                TwoTrailsSchema.SharedSchema.CN,
                q.CN);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = query.ToString();

                SQLiteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    q.CN = reader.GetString(0);
                    if (!reader.IsDBNull(1))
                    {
                        try
                        {
                            q.ParentPoint = GetPoint(reader.GetString(1));
                        }
                        catch
                        {
                            TtUtils.WriteError("Qudondam Parent Doesnt exist", "DataAcessLayer:GetQuondamPointData");
                        }
                    }
                    q.ManualAccuracy = reader.GetDouble(2);
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetQuondamPointData");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        private void GetTravPointData(TtPoint pt)
        {
            SideShotPoint t = (SideShotPoint)pt;
            StringBuilder fields = new StringBuilder();
            fields.AppendFormat("{0}, {1}, {2}, {3}, {4}",
                TwoTrailsSchema.TravPointSchema.BackAz,
                TwoTrailsSchema.TravPointSchema.ForwardAz,
                TwoTrailsSchema.TravPointSchema.SlopeDistance,
                TwoTrailsSchema.TravPointSchema.VerticalAngle,
                TwoTrailsSchema.TravPointSchema.Accuracy);
            StringBuilder query = new StringBuilder();
            query.AppendFormat("select {0} from {1} where {2} = '{3}'",
                fields.ToString(),
                TwoTrailsSchema.TravPointSchema.TableName,
                TwoTrailsSchema.SharedSchema.CN,
                t.CN);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = query.ToString();

                SQLiteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        t.BackwardAz = reader.GetDouble(0);
                    if (!reader.IsDBNull(1))
                        t.ForwardAz = reader.GetDouble(1);
                    if (!reader.IsDBNull(2))
                        t.SlopeDistance = reader.GetDouble(2);
                    if (!reader.IsDBNull(3))
                        t.SlopeAngle = reader.GetDouble(3);
                    if (!reader.IsDBNull(4))
                        t.Accuracy = reader.ForceGetDouble(4);
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetTravPointData");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        private void GetGpsPointData(TtPoint pt)
        {
            GpsPoint gps = (GpsPoint)pt;
            StringBuilder fields = new StringBuilder();
            fields.AppendFormat("{0}, {1}, {2}, {3}, {4}",
                TwoTrailsSchema.GpsPointSchema.X,
                TwoTrailsSchema.GpsPointSchema.Y,
                TwoTrailsSchema.GpsPointSchema.Z,
                TwoTrailsSchema.GpsPointSchema.UserAccuracy,
                TwoTrailsSchema.GpsPointSchema.RMSEr);
            StringBuilder query = new StringBuilder();
            query.AppendFormat("select {0} from {1} where {2} = '{3}'",
                fields.ToString(),
                TwoTrailsSchema.GpsPointSchema.TableName,
                TwoTrailsSchema.SharedSchema.CN,
                gps.CN);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = query.ToString();

                SQLiteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //if (!reader.IsDBNull(0))
                    //    gps.X = reader.GetDouble(0);
                    //if (!reader.IsDBNull(1))
                    //    gps.Y = reader.GetDouble(1);
                    //if (!reader.IsDBNull(2))
                    //    gps.Z = reader.GetDouble(2);
                    if (!reader.IsDBNull(3))
                        gps.ManualAccuracy = reader.GetDouble(3);
                    if (!reader.IsDBNull(4))
                        gps.RMSEr = reader.GetDouble(4);
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetGpsPointData");
            }
            finally
            {
                cmd.Dispose();
            }
        }


        #endregion

        #region Save/Update Points

        public void SavePoint(TtPoint currentPoint, TtPoint updatedPoint)
        {
            if (updatedPoint == null)
                return;

            if (currentPoint == null)
            {
                InsertPoint(updatedPoint);
                return;
            }

            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                switch (updatedPoint.op)
                {
                    case OpType.GPS:
                    case OpType.Take5:
                    case OpType.Walk:
                    case OpType.WayPoint:
                        {
                            SavePoint(currentPoint, (GpsPoint)updatedPoint, trans);
                            break;
                        }
                    case OpType.SideShot:
                    case OpType.Traverse:
                        {
                            SavePoint(currentPoint, (SideShotPoint)updatedPoint, trans);
                            break;
                        }
                    case OpType.Quondam:
                        {
                            SavePoint(currentPoint, (QuondamPoint)updatedPoint, trans);
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:SavePoint");
            }
            finally
            {
                trans.Dispose();
            }
        }

        protected void SavePoint(TtPoint currentPoint, GpsPoint updatedPoint, SQLiteTransaction trans)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("Update {0} set ", TwoTrailsSchema.GpsPointSchema.TableName);

            UpdateBasePoint(currentPoint, updatedPoint, trans);

            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.GpsPointSchema.UserAccuracy, (updatedPoint.ManualAccuracy == null) ? ("null") :
                (String.Format("'{0}'", updatedPoint.ManualAccuracy.ToString())));
            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.GpsPointSchema.RMSEr, (updatedPoint.RMSEr == null) ? ("null") :
                (String.Format("'{0}'", ((updatedPoint.RMSEr).ToString()))));
            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.GpsPointSchema.X, updatedPoint.UnAdjX);
            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.GpsPointSchema.Y, updatedPoint.UnAdjY);
            query.AppendFormat("{0} = {1} ", TwoTrailsSchema.GpsPointSchema.Z, updatedPoint.UnAdjZ);

            query.AppendFormat("where {0} = '{1}'", TwoTrailsSchema.SharedSchema.CN, updatedPoint.CN);

            ExecuteUpdate(query.ToString(), trans);
        }

        protected void SavePoint(TtPoint currentPoint, SideShotPoint updatedPoint, SQLiteTransaction trans)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("Update {0} set ", TwoTrailsSchema.TravPointSchema.TableName);
            UpdateBasePoint(currentPoint, updatedPoint, trans);

            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.TravPointSchema.ForwardAz, (updatedPoint.ForwardAz == null) ? ("NULL") :
                (String.Format("'{0}'", updatedPoint.ForwardAz.ToString())));
            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.TravPointSchema.BackAz, (updatedPoint.BackwardAz == null) ? ("NULL") :
                (String.Format("'{0}'", updatedPoint.BackwardAz.ToString())));
            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.TravPointSchema.SlopeDistance, updatedPoint.SlopeDistance);
            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.TravPointSchema.VerticalAngle, updatedPoint.SlopeAngle);
            query.AppendFormat("{0} = {1} ", TwoTrailsSchema.TravPointSchema.Accuracy, (updatedPoint.Accuracy == null) ? ("NULL") :
                (String.Format("'{0}'", updatedPoint.Accuracy.ToString())));

            query.AppendFormat("where {0} = '{1}';", TwoTrailsSchema.SharedSchema.CN, updatedPoint.CN);


            ExecuteUpdate(query.ToString(), trans);
        }

        protected void SavePoint(TtPoint currentPoint, QuondamPoint updatedPoint, SQLiteTransaction trans)
        {
            StringBuilder query = new StringBuilder();
            UpdateBasePoint(currentPoint, updatedPoint, trans);
            query.AppendFormat("update {0} set ", TwoTrailsSchema.QuondamPointSchema.TableName);
            query.AppendFormat("{0} = {1},", TwoTrailsSchema.QuondamPointSchema.UserAccuracy, updatedPoint.ManualAccuracy);
            query.AppendFormat("{0} = '{1}'", TwoTrailsSchema.QuondamPointSchema.ParentPointCN, updatedPoint.ParentCN);
            query.AppendFormat("where {0} = '{1}';", TwoTrailsSchema.SharedSchema.CN, updatedPoint.CN);


            if (currentPoint == null || currentPoint.op != OpType.Quondam)
            {
                SaveLinkQuondam(updatedPoint, trans);
            }
            else
            {
                DeleteLinkQuondam(((QuondamPoint)currentPoint), trans);
                SaveLinkQuondam(updatedPoint, trans);
            }

            ExecuteUpdate(query.ToString(), trans);
        }

        public void SavePoints(List<TtPoint> points)
        {
            bool ct = false;
            SavePoints(points, points, ref ct);
        }

        public void SavePoints(List<GpsPoint> points)
        {
            bool ct = false;

            List<TtPoint> tpoints = new List<TtPoint>();

            foreach (TtPoint p in points)
                tpoints.Add(p);

            SavePoints(tpoints, tpoints, ref ct);
        }

        public void SavePoints(List<TtPoint> points, ref bool CancelToken)
        {
            SavePoints(points, points, ref CancelToken);
        }

        public void SavePoints(List<TtPoint> oldPoints, List<TtPoint> points)
        {
            bool ct = false;
            SavePoints(oldPoints, points, ref ct);
        }

        public void SavePoints(List<TtPoint> oldPoints, List<TtPoint> points, ref bool CancelToken)
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                if (oldPoints == null)
                {
                    for (int i = 0; i < points.Count; i++)
                    {
                        if (CancelToken)
                            return;

                        switch (points[i].op)
                        {
                            case OpType.GPS:
                            case OpType.Take5:
                            case OpType.Walk:
                            case OpType.WayPoint:
                                {
                                    SavePoint(null, (GpsPoint)points[i], trans);
                                    break;
                                }
                            case OpType.SideShot:
                            case OpType.Traverse:
                                {
                                    SavePoint(null, (SideShotPoint)points[i], trans);
                                    break;
                                }
                            case OpType.Quondam:
                                {
                                    SavePoint(null, (QuondamPoint)points[i], trans);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                }
                else if (points.Count == oldPoints.Count)
                {
                    for (int i = 0; i < points.Count; i++)
                    {
                        if (CancelToken)
                            return;

                        switch (points[i].op)
                        {
                            case OpType.GPS:
                            case OpType.Take5:
                            case OpType.Walk:
                            case OpType.WayPoint:
                                {
                                    SavePoint(oldPoints[i], (GpsPoint)points[i], trans);
                                    break;
                                }
                            case OpType.SideShot:
                            case OpType.Traverse:
                                {
                                    SavePoint(oldPoints[i], (SideShotPoint)points[i], trans);
                                    break;
                                }
                            case OpType.Quondam:
                                {
                                    SavePoint(oldPoints[i], (QuondamPoint)points[i], trans);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                }

                if (!CancelToken)
                {
                    trans.Commit();
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:SavePoints");
            }
            finally
            {
                trans.Dispose();
            }
        }

        protected void ExecuteUpdate(String sql, SQLiteTransaction trans)
        {
            if (!IsOpen)
                OpenDB();

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                update.Transaction = trans;
                update.CommandText = sql.ToString();
                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:ExecuteUpdate");
            }
            finally
            {
                update.Dispose();
            }
        }
        
        protected void UpdateBasePoint(TtPoint CurrentPoint, TtPoint UpdatedPoint, SQLiteTransaction trans)
        {

            StringBuilder query = new StringBuilder();

            if (CurrentPoint == null)
            {
                InsertPoint(UpdatedPoint, trans);
                return;
            }

            query.Append("Update ");

            query.AppendFormat("{0} set ", TwoTrailsSchema.PointSchema.TableName);
            //comment
            query.AppendFormat("{0} = '{1}',", TwoTrailsSchema.PointSchema.Comment, UpdatedPoint.Comment);
            //meta definition
            query.AppendFormat("{0} = '{1}',", TwoTrailsSchema.PointSchema.MetaDataID, UpdatedPoint.MetaDefCN);
            //On/off boundary
            query.AppendFormat("{0} = '{1}',", TwoTrailsSchema.PointSchema.OnBoundary, UpdatedPoint.OnBnd);
            
            
            if (CurrentPoint.op != UpdatedPoint.op)
            {
                ChangeOperation(CurrentPoint, UpdatedPoint, trans);
                query.AppendFormat("{0} = '{1}',", TwoTrailsSchema.PointSchema.Operation, UpdatedPoint.op);
            }
            
            query.AppendFormat("{0} = {1},", TwoTrailsSchema.PointSchema.AdjX, UpdatedPoint.AdjX);
            query.AppendFormat("{0} = {1},", TwoTrailsSchema.PointSchema.AdjY, UpdatedPoint.AdjY);
            query.AppendFormat("{0} = {1},", TwoTrailsSchema.PointSchema.Order, UpdatedPoint.Index);
            query.AppendFormat("{0} = '{1}',", TwoTrailsSchema.PointSchema.ID, UpdatedPoint.PID);
            query.AppendFormat("{0} = '{1}',", TwoTrailsSchema.PointSchema.Polygon, UpdatedPoint.PolyName);
            query.AppendFormat("{0} = '{1}',", TwoTrailsSchema.PointSchema.PolyCN, UpdatedPoint.PolyCN);
            query.AppendFormat("{0} = {1},", TwoTrailsSchema.PointSchema.AdjZ, UpdatedPoint.AdjZ);
            query.AppendFormat("{0} = {1},", TwoTrailsSchema.PointSchema.UnAdjX, UpdatedPoint.UnAdjX);
            query.AppendFormat("{0} = {1},", TwoTrailsSchema.PointSchema.UnAdjY, UpdatedPoint.UnAdjY);
            query.AppendFormat("{0} = {1},", TwoTrailsSchema.PointSchema.UnAdjZ, UpdatedPoint.UnAdjZ);
            query.AppendFormat("{0} = '{1}',", TwoTrailsSchema.PointSchema.GroupName, UpdatedPoint.GroupName);
            query.AppendFormat("{0} = '{1}',", TwoTrailsSchema.PointSchema.GroupCN, UpdatedPoint.GroupCN);

            StringBuilder QuondamLinks = new StringBuilder();
            if (UpdatedPoint.HasQuondamLinks)
            {
                foreach (string quondam in UpdatedPoint.LinkedPoints)
                {
                    QuondamLinks.AppendFormat("{0}_", quondam);
                }
            }
            query.AppendFormat("{0} = '{1}' ", TwoTrailsSchema.PointSchema.QuondamLinks, QuondamLinks.ToString());

            query.AppendFormat("where {0} = '{1}';", TwoTrailsSchema.SharedSchema.CN, CurrentPoint.CN);
            if (!IsOpen)
                OpenDB();

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                update = _dbConnection.CreateCommand();
                update.CommandText = query.ToString();
                update.Transaction = trans;
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:UpdateBasePoint");
            }
            finally
            {
                update.Dispose();
            }
        }

        #endregion

        #region Insert Points
        public void InsertPoints(List<TtPoint> newPoints)
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();
            try
            {
                foreach (TtPoint p in newPoints)
                    InsertPoint(p, trans);
                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:InsertPoints");
            }
            finally
            {
                trans.Dispose();
            }
        }

        public void InsertPoints(List<GpsPoint> newPoints)
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();
            try
            {
                foreach (TtPoint p in newPoints)
                    InsertPoint(p, trans);
                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:InsertPoints");
            }
            finally
            {
                trans.Dispose();
            }
        }
        
        public void InsertPoint(TtPoint newPoint)
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                InsertPoint(newPoint, trans);
                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:InsertPoint");
            }
            finally
            {
                trans.Dispose();
            }
        }
        
        private void InsertPoint(TtPoint newPoint, SQLiteTransaction trans)
        {
            StringBuilder queryBeginning = new StringBuilder();
            StringBuilder queryEnd = new StringBuilder();
            if (newPoint.CN == String.Empty)
                newPoint.CN = Guid.NewGuid().ToString();
            queryBeginning.AppendFormat("INSERT INTO {0} (", TwoTrailsSchema.PointSchema.TableName);
            queryEnd.Append("(");

            //CN
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.SharedSchema.CN);
            queryEnd.AppendFormat("'{0}',", newPoint.CN);

            //comment
            if (newPoint.Comment != "" && newPoint.Comment != null)
            {
                queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.Comment);
                queryEnd.AppendFormat("'{0}',", newPoint.Comment);
            }
            //meta definition
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.MetaDataID);
            queryEnd.AppendFormat("'{0}',", newPoint.MetaDefCN);

            //On/off boundary
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.OnBoundary);
            queryEnd.AppendFormat("'{0}',", newPoint.OnBnd);

            //Operation
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.Operation);
            queryEnd.AppendFormat("'{0}',", newPoint.op);

            //AdjX
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.AdjX);
            queryEnd.AppendFormat("'{0}',", newPoint.AdjX);

            //AdjY
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.AdjY);
            queryEnd.AppendFormat("'{0}',", newPoint.AdjY);

            //AdjZ
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.AdjZ);
            queryEnd.AppendFormat("'{0}',", newPoint.AdjZ);

            //UnadjX
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.UnAdjX);
            queryEnd.AppendFormat("'{0}',", newPoint.UnAdjX);

            //UnAdjY
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.UnAdjY);
            queryEnd.AppendFormat("'{0}',", newPoint.UnAdjY);

            //UnAdjZ
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.UnAdjZ);
            queryEnd.AppendFormat("'{0}',", newPoint.UnAdjZ);

            //Index
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.Order);
            queryEnd.AppendFormat("'{0}',", newPoint.Index);

            //PID
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.ID);
            queryEnd.AppendFormat("'{0}',", newPoint.PID);

            //PolyID
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.Polygon);
            queryEnd.AppendFormat("'{0}',", newPoint.PolyName);

            //PolyCN
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.PolyCN);
            queryEnd.AppendFormat("'{0}',", newPoint.PolyCN);

            //GruopName
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.GroupName);
            queryEnd.AppendFormat("'{0}',", newPoint.GroupName);

            //GroupCN
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.GroupCN);
            queryEnd.AppendFormat("'{0}',", newPoint.GroupCN);

            //Time
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PointSchema.Time);
            queryEnd.AppendFormat("'{0}',", System.DateTime.Now);

            StringBuilder QuondamLinks = new StringBuilder();
            if (newPoint.HasQuondamLinks)
            {
                foreach (string quondam in newPoint.LinkedPoints)
                {
                    QuondamLinks.AppendFormat("{0}_", quondam);
                }
            }
            queryBeginning.AppendFormat("{0}", TwoTrailsSchema.PointSchema.QuondamLinks);
            queryEnd.AppendFormat("'{0}'", QuondamLinks.ToString());

            queryBeginning.Append(") values ");
            queryEnd.Append(");");
            queryBeginning.AppendFormat(" {0}", queryEnd.ToString());

            if (!IsOpen)
                OpenDB();

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                update.Transaction = trans;
                update.CommandText = queryBeginning.ToString();
                update.ExecuteNonQuery();
                InsertNewOperation(newPoint, trans);
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:InsertPoint");
            }
            finally
            {
                update.Dispose();
            }
        }

        private void InsertGPS(GpsPoint gpsPoint, SQLiteTransaction trans)
        {
            StringBuilder queryBeginning = new StringBuilder();
            StringBuilder queryEnd = new StringBuilder();
            queryBeginning.AppendFormat("INSERT INTO {0} (", TwoTrailsSchema.GpsPointSchema.TableName);
            queryEnd.Append("(");

            //CN
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.SharedSchema.CN);
            queryEnd.AppendFormat("'{0}',", gpsPoint.CN);

            //User accuracy
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.GpsPointSchema.UserAccuracy);
            queryEnd.AppendFormat("{0},", (gpsPoint.ManualAccuracy == null) ? ("null") :
                (String.Format("'{0}'", gpsPoint.ManualAccuracy.ToString())));

            //RMSEr
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.GpsPointSchema.RMSEr);
            queryEnd.AppendFormat("{0},", (gpsPoint.RMSEr == null) ? ("null") :
                (String.Format("'{0}'", gpsPoint.RMSEr.ToString())));

            //X
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.GpsPointSchema.X);
            queryEnd.AppendFormat("'{0}',", gpsPoint.UnAdjX);

            //Y
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.GpsPointSchema.Y);
            queryEnd.AppendFormat("'{0}',", gpsPoint.UnAdjY);

            //Z
            queryBeginning.AppendFormat("{0}", TwoTrailsSchema.GpsPointSchema.Z);
            queryEnd.AppendFormat("'{0}'", gpsPoint.UnAdjZ);

            queryBeginning.Append(") values ");
            queryEnd.Append(");");
            queryBeginning.AppendFormat(" {0}", queryEnd.ToString());

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                if (trans != null)
                    update.Transaction = trans;
                update.CommandText = queryBeginning.ToString();
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:InsertGPS");
            }
            finally
            {
                update.Dispose();
            }
        }

        private void InsertTrav(SideShotPoint travPoint, SQLiteTransaction trans)
        {
            StringBuilder queryBeginning = new StringBuilder();
            StringBuilder queryEnd = new StringBuilder();
            queryBeginning.AppendFormat("INSERT INTO {0} (", TwoTrailsSchema.TravPointSchema.TableName);
            queryEnd.Append("(");


            //CN
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.SharedSchema.CN);
            queryEnd.AppendFormat("'{0}',", travPoint.CN);
            
            //Back AZ
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TravPointSchema.BackAz);
            queryEnd.AppendFormat("{0},", (travPoint.BackwardAz == null) ? ("null") :
                (String.Format("'{0}'", travPoint.BackwardAz.ToString())));

            //Forward Az
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TravPointSchema.ForwardAz);
            queryEnd.AppendFormat("{0},", (travPoint.ForwardAz == null) ? ("NULL") :
                (String.Format("'{0}'", travPoint.ForwardAz.ToString())));

            //Horiz dist
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TravPointSchema.HorizDistance);
            queryEnd.AppendFormat("'{0}',", travPoint.HorizontalDistance);
 
            //Slope Distance
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TravPointSchema.SlopeDistance);
            queryEnd.AppendFormat("'{0}',", travPoint.SlopeDistance);

            //Angle
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TravPointSchema.VerticalAngle);
            queryEnd.AppendFormat("'{0}',", travPoint.SlopeAngle);

            //Accuracy
            queryBeginning.AppendFormat("{0}", TwoTrailsSchema.TravPointSchema.Accuracy);
            queryEnd.AppendFormat("'{0}'", travPoint.Accuracy);

            queryBeginning.Append(") values ");
            queryEnd.Append(");");
            queryBeginning.AppendFormat(" {0}", queryEnd.ToString());

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                if (trans != null)
                    update.Transaction = trans;
                update.CommandText = queryBeginning.ToString();
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:InsertTrav");
            }
            finally
            {
                update.Dispose();
            }
        }

        private void InsertQuondam(QuondamPoint quondamPoint, SQLiteTransaction trans)
        {
            StringBuilder queryBeginning = new StringBuilder();
            StringBuilder queryEnd = new StringBuilder();
            queryBeginning.AppendFormat("INSERT INTO {0} (", TwoTrailsSchema.QuondamPointSchema.TableName);
            queryEnd.Append("(");


            //CN
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.SharedSchema.CN);
            queryEnd.AppendFormat("'{0}',", quondamPoint.CN);

            //Parent CN
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.QuondamPointSchema.ParentPointCN);
            queryEnd.AppendFormat("'{0}',", quondamPoint.ParentCN);

            //Manual Accuracy
            queryBeginning.AppendFormat("{0}", TwoTrailsSchema.QuondamPointSchema.UserAccuracy);
            queryEnd.AppendFormat("{0}", quondamPoint.ManualAccuracy);

            queryBeginning.Append(") values ");
            queryEnd.Append(");");
            queryBeginning.AppendFormat(" {0}", queryEnd.ToString());

            SaveLinkQuondam(quondamPoint, trans);

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                if (trans != null)
                    update.Transaction = trans;
                update.CommandText = queryBeginning.ToString();
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:InsertQuondam");
            }
            finally
            {
                update.Dispose();
            }
        }

        public void ChangeOperation(TtPoint currentPoint, TtPoint updatedPoint, SQLiteTransaction trans)
        {
            RemoveCurrentOperation(currentPoint, trans);
            InsertNewOperation(updatedPoint, trans);
        }

        /// <summary>
        /// Inserts the record in the GPS, TRAVERSE, or QUONDAM table for the point passed in.
        /// Does not insert the record in the base point table
        /// </summary>
        /// <param name="newPoint"></param>
        protected void InsertNewOperation(TtPoint newPoint, SQLiteTransaction trans)
        {
            switch (newPoint.op)
            {
                case OpType.GPS:
                case OpType.WayPoint:
                case OpType.Take5:
                case OpType.Walk:
                    {
                        InsertGPS((GpsPoint)newPoint, trans);
                        break;
                    }
                case OpType.Traverse:
                case OpType.SideShot:
                    {
                        InsertTrav((SideShotPoint)newPoint, trans);
                        break;
                    }
                case OpType.Quondam:
                    {
                        InsertQuondam((QuondamPoint)newPoint, trans);
                        break;
                    }
                default:
                    {
                        throw new ApplicationException("Unknown OpType");
                    }
            }
        }
            #endregion Insert Points

        #region Delete Points
        /// <summary>
        /// Deletes ONLY the GPS, TRAVERSE, QUONDAM record for the point passed in
        /// Does not effect the base point record
        /// </summary>
        /// <param name="currentPoint"></param>
        protected void RemoveCurrentOperation(TtPoint currentPoint, SQLiteTransaction trans)
        {
            StringBuilder sql = new StringBuilder();
            string tableName = PointTypeToTableName(currentPoint.op);

            sql.AppendFormat("DELETE FROM {0} WHERE {1} = '{2}'",
                tableName,
                TwoTrailsSchema.SharedSchema.CN,
                currentPoint.CN);

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                if (trans != null)
                    update.Transaction = trans;
                update.CommandText = sql.ToString();
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:RemoveCurrentOperation");
            }
            finally
            {
                update.Dispose();
            }
        }

        protected void RemoveCurrentOperation(string CN, SQLiteTransaction trans)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.SharedSchema.CN,
                CN);
            List<TtPoint> pts = GetPoints(where.ToString());
            RemoveCurrentOperation(pts[0], trans);
        }

        protected void RemoveCurrentOperation(SQLiteTransaction trans, string where)
        {
            StringBuilder sqlGps = new StringBuilder();
            StringBuilder sqlTrav = new StringBuilder();
            StringBuilder sqlQuon = new StringBuilder();

            sqlGps.AppendFormat("delete from {0} where {1}",
                TwoTrailsSchema.GpsPointSchema.TableName,
                where.ToString());
            sqlTrav.AppendFormat("delete from {0} where {1}",
                TwoTrailsSchema.TravPointSchema.TableName,
                where.ToString());
            sqlQuon.AppendFormat("delete from {0} where {1}",
                TwoTrailsSchema.QuondamPointSchema.TableName,
                where.ToString());

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                if (trans != null)
                    update.Transaction = trans;
                update.CommandText = sqlGps.ToString();
                update.ExecuteNonQuery();

                update = _dbConnection.CreateCommand();
                update.CommandText = sqlTrav.ToString();
                if (trans != null)
                    update.Transaction = trans;
                update.ExecuteNonQuery();

                update = _dbConnection.CreateCommand();
                update.CommandText = sqlQuon.ToString();
                if (trans != null)
                    update.Transaction = trans;
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:RemoveCurrentOperation");
            }
            finally
            {
                update.Dispose();
            }
        }

        public void DeletePoint(TtPoint p)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.SharedSchema.CN,
                p.CN);

            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                if (p.op == OpType.Quondam)
                {
                    DeleteLinkQuondam((QuondamPoint)p, trans);
                }

                DeletePoint(where.ToString(), trans);

                //delete nmea associated with the point
                if (p.IsGpsType())
                    DeleteNmeaBursts(p.CN, trans);

                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:DeletePoint");
            }
            finally
            {
                trans.Dispose();
            }
        }

        private void DeletePoint(string where, SQLiteTransaction trans)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("DELETE FROM {0} WHERE {1}",
                TwoTrailsSchema.PointSchema.TableName,
                where.ToString());

            List<string> pointCNs = GetCNs(TwoTrailsSchema.PointSchema.TableName, where.ToString());

            if (pointCNs.Count == 0)
                return;

            string inClause = StringListToInClause(TwoTrailsSchema.SharedSchema.CN, pointCNs);
            RemoveCurrentOperation(trans, inClause);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.Transaction = trans;
                cmd.CommandText = query.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:DeletePoint");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public void DeletePointsInGroup(string groupCN)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.PointSchema.GroupCN,
                groupCN);

            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {

                List<TtPoint> points = GetPointsInGroup(groupCN);
                foreach (TtPoint p in points)
                {
                    //delete nmea associated with the point
                    if (p.IsGpsType())
                        DeleteNmeaBursts(p.CN, trans);
                }

                DeletePoint(where.ToString(), trans);

                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:DeletePointsInGroup");
            }
            finally
            {
                trans.Dispose();
            }
        }

        public void DeletePointsInGroup(TtGroup group)
        {
            DeletePointsInGroup(group.CN);
        }

        public void DeletePointsInPolygon(string polyCN)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.PointSchema.PolyCN,
                polyCN);

            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                List<TtPoint> points = GetPointsInPolygon(polyCN);
                foreach (TtPoint p in points)
                {
                    //delete nmea associated with the point
                    if (p.IsGpsType())
                        DeleteNmeaBursts(p.CN, trans);
                }

                DeletePoint(where.ToString(), trans);

                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:DeletePointsInPolygon");
            }
            finally
            {
                trans.Dispose();
            }
        }
        #endregion

        #region Manage Quondams

        protected void SaveLinkQuondam(QuondamPoint qp, SQLiteTransaction trans)
        {
            TtPoint LinkedPoint;

            if (qp.ParentPoint != null)
            {
                LinkedPoint = GetPoint(qp.ParentCN);

                if (LinkedPoint != null)
                {
                    LinkedPoint.AddQuondamLink(qp.CN);

                    try
                    {
                        switch (LinkedPoint.op)
                        {
                            case OpType.GPS:
                            case OpType.Take5:
                            case OpType.Walk:
                            case OpType.WayPoint:
                                {
                                    SavePoint(LinkedPoint, (GpsPoint)LinkedPoint, trans);
                                    break;
                                }
                            case OpType.SideShot:
                            case OpType.Traverse:
                                {
                                    SavePoint(LinkedPoint, (SideShotPoint)LinkedPoint, trans);
                                    break;
                                }
                            case OpType.Quondam:
                                {
                                    SavePoint(LinkedPoint, (QuondamPoint)LinkedPoint, trans);
                                    break;
                                }
                            default:
                                {
                                    throw new Exception("Unkown Point Type");
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        TtUtils.WriteError(ex.Message, "DataAccessLayer:SaveLinkQuondam- update point");
                    }
                }
            }
            else
            {
                throw new Exception("Quondam has no parent to save.");
            }
            
        }

        protected void DeleteLinkQuondam(QuondamPoint qp, SQLiteTransaction trans)
        {
            TtPoint LinkedPoint;

            if (qp.ParentPoint != null)
            {
                LinkedPoint = GetPoint(qp.ParentCN);

                if (LinkedPoint != null)
                {
                    LinkedPoint.RemoveQuondamLink(qp.CN);

                    try
                    {
                        switch (LinkedPoint.op)
                        {
                            case OpType.GPS:
                            case OpType.Take5:
                            case OpType.Walk:
                            case OpType.WayPoint:
                                {
                                    SavePoint(LinkedPoint, (GpsPoint)LinkedPoint, trans);
                                    break;
                                }
                            case OpType.SideShot:
                            case OpType.Traverse:
                                {
                                    SavePoint(LinkedPoint, (SideShotPoint)LinkedPoint, trans);
                                    break;
                                }
                            case OpType.Quondam:
                                {
                                    SavePoint(LinkedPoint, (QuondamPoint)LinkedPoint, trans);
                                    break;
                                }
                            default:
                                {
                                    throw new Exception("Unkown Point Type");
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        TtUtils.WriteError(ex.Message, "DataAccessLayer:DeleteLinkQuondam- update point");
                    }
                }
            }
        }
        #endregion

        #endregion

        #region Polygons

        public List<string> GetPolygonNames()
        {
            StringBuilder sql = new StringBuilder();
            List<string> polyNames = new List<string>();
            sql.AppendFormat("select {0} from {1}", TwoTrailsSchema.PolygonSchema.PolyID,
                TwoTrailsSchema.PolygonSchema.TableName);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = sql.ToString();

                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name;
                    name = reader.GetString(0);
                    polyNames.Add(name);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetPolygonNames");
            }
            finally
            {
                cmd.Dispose();
            }

            return polyNames;
        }

        public bool PolyExists(string CN)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} = '{1}'", TwoTrailsSchema.SharedSchema.CN, CN);
            List<TtPolygon> polys = GetPolygons(sb.ToString());
            return polys.Count > 0;
        }

        #region Delete Polygon
        public int DeletePolygon(TtPolygon poly)
        {
            return DeletePolygon(poly.CN);
        }

        public int DeletePolygon(string CN)
        {
            StringBuilder polySql = new StringBuilder();
            polySql.AppendFormat("DELETE FROM {0} WHERE {1} = '{2}'",
                TwoTrailsSchema.PolygonSchema.TableName,
                TwoTrailsSchema.SharedSchema.CN,
                CN);

            StringBuilder where = new StringBuilder();
            where.AppendFormat("{0} = '{1}'", 
                TwoTrailsSchema.PointSchema.PolyCN, 
                CN);


            SQLiteTransaction trans = _dbConnection.BeginTransaction();
            SQLiteCommand cmd = _dbConnection.CreateCommand();
            int count = 0;

            try
            {
                List<TtPoint> points = GetPointsInPolygon(CN);
                foreach (TtPoint p in points)
                {
                    //delete nmea associated with the point
                    if (p.op == OpType.GPS || p.op == OpType.Take5 || p.op == OpType.Walk || p.op == OpType.WayPoint)
                        DeleteNmeaBursts(p.CN, trans);
                }

                DeletePoint(where.ToString(), trans);

                cmd.CommandText = polySql.ToString();
                cmd.Transaction = trans;
                count = cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:DeletePolygon");
            }
            finally
            {
                cmd.Dispose();
                trans.Dispose();
            }

            return count;
        }
        #endregion

        #region Get Polygons
        private List<TtPolygon> GetPolygons(string where)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7} from {8} ",
                TwoTrailsSchema.SharedSchema.CN,
                TwoTrailsSchema.PolygonSchema.PolyID,
                TwoTrailsSchema.PolygonSchema.Description,
                TwoTrailsSchema.PolygonSchema.Accuracy,
                TwoTrailsSchema.PolygonSchema.Area,
                TwoTrailsSchema.PolygonSchema.Perimeter,
                TwoTrailsSchema.PolygonSchema.IncrementBy,
                TwoTrailsSchema.PolygonSchema.PointStartIndex,
                TwoTrailsSchema.PolygonSchema.TableName);

            if (where != null)
                query.AppendFormat("WHERE {0}", where);

            SQLiteCommand cmd = _dbConnection.CreateCommand();
            List<TtPolygon> polys = new List<TtPolygon>();

            try
            {
                cmd.CommandText = query.ToString();
                TtPolygon poly = new TtPolygon();
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    poly.CN = reader.GetString(0);
                    poly.Name = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        poly.Description = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        poly.PolyAccu = reader.GetDouble(3);
                    if (!reader.IsDBNull(4))
                        poly.Area = reader.GetDouble(4);
                    if (!reader.IsDBNull(5))
                        poly.Perimeter = reader.GetDouble(5);
                    if (!reader.IsDBNull(6))
                        poly.IncrementBy = reader.GetInt32(6);
                    if (!reader.IsDBNull(7))
                        poly.PointStartIndex = reader.GetInt32(7);

                    polys.Add(poly);
                    poly = new TtPolygon();
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetQuondamPointData");
            }
            finally
            {
                cmd.Dispose();
            }

            return polys;
        }
        
        public TtPolygon GetPolygonByCn(string CN)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.SharedSchema.CN,
                CN);
            List<TtPolygon> polys = GetPolygons(sb.ToString());
            if (polys.Count > 0)
                return polys[0];
            else
                return null;
        }

        public TtPolygon GetPolygonByName(string CN)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.SharedSchema.CN,
                CN);
            List<TtPolygon> polys = GetPolygons(sb.ToString());
            if (polys.Count > 0)
                return polys[0];
            else
                return null;
        }

        public List<TtPolygon> GetPolygons()
        {
            return GetPolygons(null);
        }
        #endregion

        #region Insert / Update Polygons
        public void SavePolygon(TtPolygon currentPoly, TtPolygon updatedPoly)
        {
            if (currentPoly == null)
                InsertPolygon(updatedPoly);
            else
                UpdatePolygon(currentPoly, updatedPoly);

        }

        public void UpdatePolygon(TtPolygon currentPoly, TtPolygon updatePoly)
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                UpdatePolygon(currentPoly, updatePoly, trans);
                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:UpdatePolygon");
            }
            finally
            {
                trans.Dispose();
            }
        }

        private void UpdatePolygon(TtPolygon currentPoly, TtPolygon updatePoly, SQLiteTransaction trans)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("Update {0} set ", TwoTrailsSchema.PolygonSchema.TableName);

            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.SharedSchema.CN, updatePoly.CN);
            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.PolygonSchema.Accuracy, (updatePoly.PolyAccu == null) ? ("null") :
                (String.Format("'{0}'", updatePoly.PolyAccu.ToString())));
            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.PolygonSchema.Area, updatePoly.Area);
            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.PolygonSchema.Perimeter, updatePoly.Perimeter);
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.PolygonSchema.PolyID, updatePoly.Name);
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.PolygonSchema.Description, updatePoly.Description);
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.PolygonSchema.PointStartIndex, updatePoly.PointStartIndex);
            query.AppendFormat("{0} = '{1}' ", TwoTrailsSchema.PolygonSchema.IncrementBy, updatePoly.IncrementBy);

            query.AppendFormat("where {0} = '{1}'", TwoTrailsSchema.SharedSchema.CN, currentPoly.CN);
            if (!IsOpen)
                OpenDB();

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                if (trans != null)
                    update.Transaction = trans;
                update.CommandText = query.ToString();
                update.ExecuteNonQuery();

                //foreach point with that poly cn update point with new poly name
                query = new StringBuilder();
                query.AppendFormat("Update {0} set ", TwoTrailsSchema.PointSchema.TableName);
                query.AppendFormat("{0} = '{1}' ", TwoTrailsSchema.PointSchema.Polygon, updatePoly.Name);
                query.AppendFormat("where {0} = '{1}'", TwoTrailsSchema.PointSchema.PolyCN, currentPoly.CN);

                update = _dbConnection.CreateCommand();
                if (trans != null)
                    update.Transaction = trans;
                update.CommandText = query.ToString();
                update.ExecuteNonQuery();
                //--

                if (currentPoly.CN != updatePoly.CN)
                    UpdatePointsOnPolyCnChange(currentPoly.CN, updatePoly.CN, trans);
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:UpdatePolygon");
            }
            finally
            {
                update.Dispose();
            }
        }
        
        public void InsertPolygon(TtPolygon poly)
        {
            StringBuilder queryBeginning = new StringBuilder();
            StringBuilder queryEnd = new StringBuilder();

            if (poly.CN == "" || poly.CN == null)
                poly.CN = Guid.NewGuid().ToString();

            queryBeginning.AppendFormat("INSERT INTO {0} (", TwoTrailsSchema.PolygonSchema.TableName);
            queryEnd.Append("(");

            //CN
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.SharedSchema.CN);
            queryEnd.AppendFormat("'{0}',", poly.CN);

            //Name
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PolygonSchema.PolyID);
            queryEnd.AppendFormat("'{0}',", poly.Name);

            //Description
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PolygonSchema.Description);
            queryEnd.AppendFormat("'{0}',", poly.Description);

            //Poly Accuracy
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PolygonSchema.Accuracy);
            queryEnd.AppendFormat("{0},", (poly.PolyAccu == null) ? ("null") :
                (String.Format("'{0}'", poly.PolyAccu.ToString())));

            //Area
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PolygonSchema.Area);
            queryEnd.AppendFormat("'{0}',", poly.Area);

            //Perimeter
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PolygonSchema.Perimeter);
            queryEnd.AppendFormat("'{0}',", poly.Perimeter);

             //Point Start Index
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.PolygonSchema.PointStartIndex);
            queryEnd.AppendFormat("'{0}',", poly.PointStartIndex);

            //Increment value
            queryBeginning.AppendFormat("{0}", TwoTrailsSchema.PolygonSchema.IncrementBy);
            queryEnd.AppendFormat("'{0}'", poly.IncrementBy);

            queryBeginning.Append(") values ");
            queryEnd.Append(");");
            queryBeginning.AppendFormat(" {0}", queryEnd.ToString());

            if (!IsOpen)
                OpenDB();

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                update.CommandText = queryBeginning.ToString();
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:InsertPolygon");
            }
            finally
            {
                update.Dispose();
            }
        }

        #endregion
        #endregion

        #region Groups

        #region Get Groups
        public List<TtGroup> GetGroups()
        {
            return GetGroups(null);
        }

        public List<TtGroup> GetGroupsByType(GroupType type)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.GroupSchema.Type,
                type.ToString());
            List<TtGroup> groups = GetGroups(sb.ToString());
            return groups;
        }

        public TtGroup GetGroupByCN(string cn)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.GroupSchema.CN,
                cn);
            List<TtGroup> groups = GetGroups(sb.ToString());
            if (groups.Count > 0)
                return groups[0];
            else
                return null;
        }

        public TtGroup GetGroupByName(string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} = '{1}'",
                TwoTrailsSchema.GroupSchema.Name,
                name);
            List<TtGroup> groups = GetGroups(sb.ToString());
            if (groups.Count > 0)
                return groups[0];
            else
                return null;
        }

        private List<TtGroup> GetGroups(string where)
        {
            List<TtGroup> groups = new List<TtGroup>();

            StringBuilder query = new StringBuilder();
            query.AppendFormat("SELECT {0}, {1}, {2}, {3}, {4} from {5} ",
                TwoTrailsSchema.GroupSchema.CN,
                TwoTrailsSchema.GroupSchema.Name,
                TwoTrailsSchema.GroupSchema.Accuracy,
                TwoTrailsSchema.GroupSchema.Description,
                TwoTrailsSchema.GroupSchema.Type,
                TwoTrailsSchema.GroupSchema.TableName);

            if (where != null)
                query.AppendFormat("WHERE {0}", where);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = query.ToString();

                TtGroup group = new TtGroup();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    group.CN = reader.GetString(0);
                    group.SetGroupName(reader.GetString(1), null);
                    if (!reader.IsDBNull(2))
                        group.SetGroupManualAccuracy(reader.GetDouble(2), null);
                    if (!reader.IsDBNull(3))
                        group.Description = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        group.GroupType = (GroupType)Enum.Parse(typeof(GroupType), reader.GetString(4), true);
                    }

                    //group.Init(GetPointCNsInGroup(group.CN));

                    groups.Add(group);
                    group = new TtGroup();
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetGroups");
            }
            finally
            {
                cmd.Dispose();
            }

            return groups;
        }
        #endregion

        #region Insert / Save
        public void UpdateGroup(TtGroup currentGroup)
        {
            UpdateGroup(currentGroup, currentGroup);
        }

        public void UpdateGroup(TtGroup currentGroup, TtGroup updatedGroup)
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                UpdateGroup(currentGroup, updatedGroup, trans);
                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:UpdateGroup");
            }
            finally
            {
                trans.Dispose();
            }
        }

        public void UpdateGroups(List<TtGroup> groups)
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                foreach (TtGroup group in groups)
                {
                    UpdateGroup(group, group, trans);
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:UpdateGroups");
            }
            finally
            {
                trans.Dispose();
            }
        }

        private void UpdateGroup(TtGroup currentGroup, TtGroup updatedGroup, SQLiteTransaction trans)
        {
            if (currentGroup.CN != updatedGroup.CN)
                throw new Exception("Mismatch Group CN");

            StringBuilder query = new StringBuilder();
            query.AppendFormat("Update {0} set ", TwoTrailsSchema.GroupSchema.TableName);

            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.GroupSchema.CN, updatedGroup.CN);
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.GroupSchema.Name, updatedGroup.Name);
            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.GroupSchema.Accuracy, (updatedGroup.ManualAccuracy == null) ? ("NULL") : (updatedGroup.ManualAccuracy.ToString()));
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.GroupSchema.Description, updatedGroup.Description);
            query.AppendFormat("{0} = '{1}' ", TwoTrailsSchema.GroupSchema.Type, updatedGroup.GroupType.ToString());

            query.AppendFormat("where {0} = '{1}'", TwoTrailsSchema.GroupSchema.CN, updatedGroup.CN);
            if (!IsOpen)
                OpenDB();

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                if (trans != null)
                    update.Transaction = trans;
                update.CommandText = query.ToString();
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:UpdateGroup");
            }
            finally
            {
                update.Dispose();
            }
        }

        public int InsertGroup(TtGroup group)
        {
            StringBuilder queryBeginning = new StringBuilder();
            StringBuilder queryEnd = new StringBuilder();

            if (group.CN.IsEmpty())
                group.CN = Guid.NewGuid().ToString();

            queryBeginning.AppendFormat("INSERT INTO {0} (", TwoTrailsSchema.GroupSchema.TableName);
            queryEnd.Append("(");

            //CN
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.GroupSchema.CN);
            queryEnd.AppendFormat("'{0}',", group.CN);

            //Name
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.GroupSchema.Name);
            queryEnd.AppendFormat("'{0}',", group.Name);

            //Accuracy
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.GroupSchema.Accuracy);
            queryEnd.AppendFormat("{0},", (group.ManualAccuracy == null) ? ("NULL") : (group.ManualAccuracy.ToString()));

            //Description
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.GroupSchema.Description);
            queryEnd.AppendFormat("'{0}',", group.Description);

            //Type
            queryBeginning.AppendFormat("{0}", TwoTrailsSchema.GroupSchema.Type);
            queryEnd.AppendFormat("'{0}'", group.GroupType.ToString());

            queryBeginning.Append(") values ");
            queryEnd.Append(");");
            queryBeginning.AppendFormat(" {0}", queryEnd.ToString());

            if (!IsOpen)
                OpenDB();

            SQLiteCommand update = _dbConnection.CreateCommand();
            int num = 0;

            try
            {
                update.CommandText = queryBeginning.ToString();
                num = update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:InsertGroup");
            }
            finally
            {
                update.Dispose();
            }

            return num;
        }
        #endregion

        #region Delte Groups

        public bool DeleteGroup(TtGroup group)
        {
            return DeleteGroup(group.CN);
        }

        public bool DeleteGroup(string groupCN)
        {
            StringBuilder groupSql = new StringBuilder();
            groupSql.AppendFormat("DELETE FROM {0} WHERE {1} = '{2}'",
                TwoTrailsSchema.GroupSchema.TableName,
                TwoTrailsSchema.GroupSchema.CN,
                groupCN);

            SQLiteTransaction trans = _dbConnection.BeginTransaction();
            SQLiteCommand cmd = _dbConnection.CreateCommand();
            int count = 0;

            try
            {
                cmd.CommandText = groupSql.ToString();
                cmd.Transaction = trans;
                count = cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:DeleteGroup");
            }
            finally
            {
                cmd.Dispose();
                trans.Dispose();
            }

            if (count > 0)
            {
                List<TtPoint> points = GetPointsInGroup(groupCN);
                if (points.Count > 0)
                {
                    foreach (TtPoint p in points)
                    {
                        p.GroupName = Values.MainGroup.Name;
                        p.GroupCN = Values.MainGroup.CN;
                    }

                    SavePoints(points);
                }
            }

            return (count > 0);
        }

        #endregion

        #endregion

        #region TTNmea

        public void SaveNmeaBursts(List<NmeaBurst> Bursts, string pointCN)
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                foreach (NmeaBurst burst in Bursts)
                {
                    SaveNmeaBurst(burst, pointCN, trans);
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:SaveNmeaBursts");
            }
            finally
            {
                trans.Dispose();
            }
        }

        public void SaveNmeaBurst(NmeaBurst burst, string pointCN)
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                SaveNmeaBurst(burst, pointCN, trans);

                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:SaveNmeaBurst");
            }
            finally
            {
                trans.Dispose();
            }
        }

        protected void SaveNmeaBurst(NmeaBurst burst, string pointCN, SQLiteTransaction trans)
        {
            StringBuilder queryBeginning = new StringBuilder();
            StringBuilder queryEnd = new StringBuilder();
            queryBeginning.AppendFormat("INSERT INTO {0} (", TwoTrailsSchema.TtnmeaSchema.TableName);
            queryEnd.Append("(");

            //CN
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.CN);
            queryEnd.AppendFormat("'{0}',", Guid.NewGuid().ToString());

            //Point CN
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.PointCN);
            queryEnd.AppendFormat("'{0}',", pointCN);

            //Used in Point
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.Used);
            if(burst._Used)
                queryEnd.AppendFormat("'{0}',", 1);
            else
                queryEnd.AppendFormat("'{0}',", 0);

            //DateTime
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.DateTimeZulu);
            queryEnd.AppendFormat("'{0}',", burst._datetime.ToString());

            //Longitude
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.Longitude);
            queryEnd.AppendFormat("'{0}',", burst._longitude);

            //Latitude
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.Latitude);
            queryEnd.AppendFormat("'{0}',", burst._latitude);

            //Latitude Direction
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.LatDir);
            queryEnd.AppendFormat("'{0}',", burst._latDir.ToString());

            //Longitude Direction
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.LonDir);
            queryEnd.AppendFormat("'{0}',", burst._longDir.ToString());

            //Magnetitc Variation
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.MagVar);
            queryEnd.AppendFormat("'{0}',", burst._magVar);

            //Magnetitc Variation Direction
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.MagDir);
            queryEnd.AppendFormat("'{0}',", burst._magVarDir.ToString());

            //UTM Zone
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.UtmZone);
            queryEnd.AppendFormat("'{0}',", burst._utm_zone);

            //UTM X
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.UtmX);
            queryEnd.AppendFormat("'{0}',", burst._X);

            //UTM Y
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.UtmY);
            queryEnd.AppendFormat("'{0}',", burst._Y);

            //Altitude
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.Altitude);
            queryEnd.AppendFormat("'{0}',", burst._altitude);

            //Altitude Unit Type
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.AltUnit);
            queryEnd.AppendFormat("'{0}',", burst._alt_unit.ToString());

            //Fix Quality
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.FixQuality);
            queryEnd.AppendFormat("'{0}',", burst._fix_quality);

            //Altitude Fix Type
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.Mode);
            queryEnd.AppendFormat("'{0}',", burst._fix);

            //PDOP
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.PDOP);
            queryEnd.AppendFormat("'{0}',", burst._PDOP);

            //HDOP
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.HDOP);
            queryEnd.AppendFormat("'{0}',", burst._HDOP);

            //VDOP
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.VDOP);
            queryEnd.AppendFormat("'{0}',", burst._VDOP);

            //PRNs
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.PRNS);
            queryEnd.AppendFormat("'{0}',", burst._fixed_PRNs);

            //Horizontal Dilution of Position
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.HDo_Position);
            queryEnd.AppendFormat("'{0}',", burst._horiz_dilution_position);

            //HAE
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.HAE);
            queryEnd.AppendFormat("'{0}',", burst._geoid_height);

            //HAE Unit
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.HAE_Unit);
            queryEnd.AppendFormat("'{0}',", burst._geoid_unit);

            //Speed
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.Speed);
            queryEnd.AppendFormat("'{0}',", burst._speed);

            //HAE
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.Track_Angle);
            queryEnd.AppendFormat("'{0}',", burst._track_angle);

            //Satellite Count
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.SatelliteCount);
            queryEnd.AppendFormat("'{0}',", burst._num_of_sat);

            //Satellite Used
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.SatelliteUsed);
            queryEnd.AppendFormat("'{0}',", burst._num_of_used_sat);

            #region Satellites

            List<Satellite> sats = burst.GetSatellites();
            string satID = "", satElev = "", satAz = "", satSRN = "";

            for (int i = 0; i < sats.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN1ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN1Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN1Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN1SRN;
                            break;
                        }
                    case 1:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN2ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN2Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN2Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN2SRN;
                            break;
                        }
                    case 2:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN3ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN3Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN3Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN3SRN;
                            break;
                        }
                    case 3:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN4ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN4Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN4Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN4SRN;
                            break;
                        }
                    case 4:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN5ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN5Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN5Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN5SRN;
                            break;
                        }
                    case 5:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN6ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN6Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN6Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN6SRN;
                            break;
                        }
                    case 6:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN7ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN7Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN7Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN7SRN;
                            break;
                        }
                    case 7:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN8ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN8Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN8Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN8SRN;
                            break;
                        }
                    case 8:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN9ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN9Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN9Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN9SRN;
                            break;
                        }
                    case 9:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN10ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN10Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN10Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN10SRN;
                            break;
                        }
                    case 10:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN11ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN11Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN11Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN11SRN;
                            break;
                        }
                    case 11:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN12ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN12Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN12Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN12SRN;
                            break;
                        }
                }

                //Satellite Info
                queryBeginning.AppendFormat("{0},", satID);
                queryEnd.AppendFormat("'{0}',", sats[i].ID);

                queryBeginning.AppendFormat("{0},", satElev);
                queryEnd.AppendFormat("'{0}',", sats[i].Elevation);

                queryBeginning.AppendFormat("{0},", satAz);
                queryEnd.AppendFormat("'{0}',", sats[i].Azimuth);

                string end = i == sats.Count - 1 ? "" : ",";
                queryBeginning.AppendFormat("{0}{1}", satSRN, end);
                queryEnd.AppendFormat("'{0}'{1}", sats[i].SNR, end);
            }
            #endregion

            queryBeginning.Append(") values ");
            queryEnd.Append(");");
            queryBeginning.AppendFormat(" {0}", queryEnd.ToString());

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                if (trans != null)
                    update.Transaction = trans;

                update.CommandText = queryBeginning.ToString();
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:SaveNmeaBurst");
            }
            finally
            {
                update.Dispose();
            }
        }

        public void UpdateNmeaBursts(List<NmeaBurst> Bursts, string pointCN)
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                foreach (NmeaBurst burst in Bursts)
                {
                    UpdateNmeaBurst(burst, pointCN, trans);
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:UpdateNmeaBursts");
            }
            finally
            {
                trans.Dispose();
            }
        }

        protected void UpdateNmeaBurst(NmeaBurst burst, string pointCN, SQLiteTransaction trans)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("Update {0} set ", TwoTrailsSchema.TtnmeaSchema.TableName);

            //Point CN
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.PointCN, pointCN);

            //Used
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.Used, (burst._Used)?(1):(0));

            //DateTime
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.DateTimeZulu, burst._datetime.ToString());

            //Longitude
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.Longitude, burst._longitude);

            //Latitude
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.Latitude, burst._latitude);

            //Latitude Direction
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.LatDir, burst._latDir.ToString());

            //Longitude Direction
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.LonDir, burst._longDir.ToString());

            //Magnetitc Variation
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.MagVar, burst._magVar);

            //Magnetitc Variation Direction
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.MagDir, burst._magVarDir.ToString());

            //UTM Zone
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.UtmZone, burst._utm_zone);

            //UTM X
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.UtmX, burst._X);

            //UTM Y
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.UtmY, burst._Y);

            //Altitude
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.Altitude, burst._altitude);

            //Altitude Unit Type
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.AltUnit, burst._alt_unit.ToString());

            //Fix Quality
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.FixQuality, burst._fix_quality);

            //Altitude Fix Type
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.Mode, burst._fix);

            //PDOP
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.PDOP, burst._PDOP);

            //HDOP
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.HDOP, burst._HDOP);

            //VDOP
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.VDOP, burst._VDOP);

            //PRNs
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.PRNS, burst._fixed_PRNs);

            //Horizontal Dilution of Position
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.HDo_Position, burst._horiz_dilution_position);

            //HAE
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.HAE, burst._geoid_height);

            //HAE
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.HAE_Unit, burst._geoid_unit);

            //Speed
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.Speed, burst._speed);

            //Angle
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.Track_Angle, burst._track_angle);

            //Satellite Count
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.SatelliteCount, burst._num_of_sat);

            //Satellite Used
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.TtnmeaSchema.SatelliteUsed, burst._num_of_used_sat);

            #region Satellites

            List<Satellite> sats = burst.GetSatellites();
            string satID = "", satElev = "", satAz = "", satSRN = "";

            for (int i = 0; i < sats.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN1ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN1Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN1Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN1SRN;
                            break;
                        }
                    case 1:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN2ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN2Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN2Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN2SRN;
                            break;
                        }
                    case 2:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN3ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN3Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN3Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN3SRN;
                            break;
                        }
                    case 3:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN4ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN4Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN4Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN4SRN;
                            break;
                        }
                    case 4:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN5ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN5Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN5Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN5SRN;
                            break;
                        }
                    case 5:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN6ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN6Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN6Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN6SRN;
                            break;
                        }
                    case 6:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN7ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN7Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN7Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN7SRN;
                            break;
                        }
                    case 7:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN8ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN8Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN8Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN8SRN;
                            break;
                        }
                    case 8:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN9ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN9Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN9Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN9SRN;
                            break;
                        }
                    case 9:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN10ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN10Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN10Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN10SRN;
                            break;
                        }
                    case 10:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN11ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN11Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN11Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN11SRN;
                            break;
                        }
                    case 11:
                        {
                            satID = TwoTrailsSchema.TtnmeaSchema.PRN12ID;
                            satElev = TwoTrailsSchema.TtnmeaSchema.PRN12Elev;
                            satAz = TwoTrailsSchema.TtnmeaSchema.PRN12Az;
                            satSRN = TwoTrailsSchema.TtnmeaSchema.PRN12SRN;
                            break;
                        }
                }

                //Satellite Info
                query.AppendFormat("{0} = '{1}', ", satID, sats[i].ID);

                query.AppendFormat("{0} = '{1}', ", satElev, sats[i].Elevation);

                query.AppendFormat("{0} = '{1}', ", satAz, sats[i].Azimuth);

                query.AppendFormat("{0} = '{1}'{2} ", satSRN, sats[i].SNR, 
                    i == sats.Count - 1 ? "" : ",");
            }
            #endregion

            query.AppendFormat("where {0} = '{1}'", TwoTrailsSchema.SharedSchema.CN, burst._CN);

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                if (trans != null)
                    update.Transaction = trans;

                update.CommandText = query.ToString();
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:UpdateNmeaBurst");
            }
            finally
            {
                update.Dispose();
            }
        }

        public void DeleteNmeaBursts(string pointCN)
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                DeleteNmeaBursts(pointCN, trans);

                trans.Commit();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:DeleteNmeaBursts");
            }
            finally
            {
                trans.Dispose();
            }
        }

        protected void DeleteNmeaBursts(string pointCN, SQLiteTransaction trans)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("DELETE FROM {0} WHERE {1} = '{2}'",
                TwoTrailsSchema.TtnmeaSchema.TableName,
                TwoTrailsSchema.TtnmeaSchema.PointCN,
                pointCN);

            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.Transaction = trans;
                cmd.CommandText = query.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:DeleteNmeaBursts");
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public List<NmeaBurst> GetNmeaBursts()
        {
            return GetNmeaBursts(null);
        }

        public List<NmeaBurst> GetNmeaBurstsByPointCN(string cn)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} = '{1}'", TwoTrailsSchema.TtnmeaSchema.PointCN, cn);

            return GetNmeaBursts(sb.ToString());
        }

        private List<NmeaBurst> GetNmeaBursts(string where)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat(@"SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, 
{18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, 
{37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53}, {54}, {55}, 
{56}, {57}, {58}, {59}, {60}, {61}, {62}, {63}, {64}, {65}, {66}, {67}, {68}, {69}, {70}, {71}, {72}, {73}, {74}, 
{75} from {76}",

            #region Values
                TwoTrailsSchema.SharedSchema.CN,                //0
                TwoTrailsSchema.TtnmeaSchema.PointCN,
                TwoTrailsSchema.TtnmeaSchema.Used,
                TwoTrailsSchema.TtnmeaSchema.DateTimeZulu,
                TwoTrailsSchema.TtnmeaSchema.Longitude,
                TwoTrailsSchema.TtnmeaSchema.Latitude,          //5
                TwoTrailsSchema.TtnmeaSchema.LatDir,
                TwoTrailsSchema.TtnmeaSchema.LonDir,
                TwoTrailsSchema.TtnmeaSchema.MagVar,
                TwoTrailsSchema.TtnmeaSchema.MagDir,
                TwoTrailsSchema.TtnmeaSchema.UtmZone,           //10
                TwoTrailsSchema.TtnmeaSchema.UtmX,
                TwoTrailsSchema.TtnmeaSchema.UtmY,
                TwoTrailsSchema.TtnmeaSchema.Altitude,
                TwoTrailsSchema.TtnmeaSchema.AltUnit,
                TwoTrailsSchema.TtnmeaSchema.FixQuality,        //15
                TwoTrailsSchema.TtnmeaSchema.Mode,
                TwoTrailsSchema.TtnmeaSchema.PDOP,
                TwoTrailsSchema.TtnmeaSchema.HDOP,
                TwoTrailsSchema.TtnmeaSchema.VDOP,
                TwoTrailsSchema.TtnmeaSchema.PRNS,              //20
                TwoTrailsSchema.TtnmeaSchema.HDo_Position,
                TwoTrailsSchema.TtnmeaSchema.HAE,
                TwoTrailsSchema.TtnmeaSchema.HAE_Unit,
                TwoTrailsSchema.TtnmeaSchema.Speed,
                TwoTrailsSchema.TtnmeaSchema.Track_Angle,
                TwoTrailsSchema.TtnmeaSchema.SatelliteCount,
                TwoTrailsSchema.TtnmeaSchema.SatelliteUsed,     //27

                TwoTrailsSchema.TtnmeaSchema.PRN1ID,    //28
                TwoTrailsSchema.TtnmeaSchema.PRN1Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN1Az,
                TwoTrailsSchema.TtnmeaSchema.PRN1SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN2ID,    //32
                TwoTrailsSchema.TtnmeaSchema.PRN2Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN2Az,
                TwoTrailsSchema.TtnmeaSchema.PRN2SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN3ID,    //36
                TwoTrailsSchema.TtnmeaSchema.PRN3Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN3Az,
                TwoTrailsSchema.TtnmeaSchema.PRN3SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN4ID,    //40
                TwoTrailsSchema.TtnmeaSchema.PRN4Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN4Az,
                TwoTrailsSchema.TtnmeaSchema.PRN4SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN5ID,    //44
                TwoTrailsSchema.TtnmeaSchema.PRN5Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN5Az,
                TwoTrailsSchema.TtnmeaSchema.PRN5SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN6ID,    //48
                TwoTrailsSchema.TtnmeaSchema.PRN6Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN6Az,
                TwoTrailsSchema.TtnmeaSchema.PRN6SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN7ID,    //52
                TwoTrailsSchema.TtnmeaSchema.PRN7Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN7Az,
                TwoTrailsSchema.TtnmeaSchema.PRN7SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN8ID,    //56
                TwoTrailsSchema.TtnmeaSchema.PRN8Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN8Az,
                TwoTrailsSchema.TtnmeaSchema.PRN8SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN9ID,    //60
                TwoTrailsSchema.TtnmeaSchema.PRN9Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN9Az,
                TwoTrailsSchema.TtnmeaSchema.PRN9SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN10ID,   //64
                TwoTrailsSchema.TtnmeaSchema.PRN10Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN10Az,
                TwoTrailsSchema.TtnmeaSchema.PRN10SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN11ID,   //68
                TwoTrailsSchema.TtnmeaSchema.PRN11Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN11Az,
                TwoTrailsSchema.TtnmeaSchema.PRN11SRN,
                TwoTrailsSchema.TtnmeaSchema.PRN12ID,   //72
                TwoTrailsSchema.TtnmeaSchema.PRN12Elev,
                TwoTrailsSchema.TtnmeaSchema.PRN12Az,
                TwoTrailsSchema.TtnmeaSchema.PRN12SRN,  //75

                TwoTrailsSchema.TtnmeaSchema.TableName);   //76
            #endregion

            if (where != null)
                query.AppendFormat(" WHERE {0}", where);

            List<NmeaBurst> Bursts = new List<NmeaBurst>();
            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                cmd.CommandText = query.ToString();
                NmeaBurst burst = new NmeaBurst();
                SQLiteDataReader reader = cmd.ExecuteReader();

                #region Reader
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        burst._CN = reader.GetString(0);
                    if (!reader.IsDBNull(1))
                        burst._PointCN = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        burst._Used = reader.GetBoolean(2);
                    if (!reader.IsDBNull(3))
                        burst._datetime = DateTime.Parse(reader.GetString(3));
                    if (!reader.IsDBNull(4))
                        burst._longitude = reader.GetDouble(4);
                    if (!reader.IsDBNull(5))
                        burst._latitude = reader.GetDouble(5);
                    if (!reader.IsDBNull(6))
                        burst._latDir = (NorthSouth)Enum.Parse(typeof(NorthSouth), reader.GetString(6), true);
                    if (!reader.IsDBNull(7))
                        burst._longDir = (EastWest)Enum.Parse(typeof(EastWest), reader.GetString(7), true);
                    if (!reader.IsDBNull(8))
                        burst._magVar = reader.GetDouble(8);
                    if (!reader.IsDBNull(9))
                        burst._magVarDir = (EastWest)Enum.Parse(typeof(EastWest), reader.GetString(9), true);
                    if (!reader.IsDBNull(10))
                        burst._utm_zone = reader.GetInt32(10);
                    if (!reader.IsDBNull(11))
                        burst._X = reader.GetDouble(11);
                    if (!reader.IsDBNull(12))
                        burst._Y = reader.GetDouble(12);
                    if (!reader.IsDBNull(13))
                    {
                        burst._altitude = reader.GetDouble(13);
                        burst._Z = burst._altitude;
                    }
                    if (!reader.IsDBNull(14))
                        burst._alt_unit = (Unit)Enum.Parse(typeof(Unit), reader.GetString(14), true);
                    if (!reader.IsDBNull(15))
                        burst._fix_quality = reader.GetInt32(15);
                    if (!reader.IsDBNull(16))
                        burst._fix = reader.GetInt32(16);
                    if (!reader.IsDBNull(17))
                        burst._PDOP = reader.GetDouble(17);
                    if (!reader.IsDBNull(18))
                        burst._HDOP = reader.GetDouble(18);
                    if (!reader.IsDBNull(19))
                        burst._VDOP = reader.GetDouble(19);
                    if (!reader.IsDBNull(20))
                        burst._fixed_PRNs = reader.GetString(20);
                    if (!reader.IsDBNull(21))
                        burst._horiz_dilution_position = reader.GetDouble(21);
                    if (!reader.IsDBNull(22))
                        burst._geoid_height = reader.GetDouble(22);
                    if (!reader.IsDBNull(23))
                        burst._geoid_unit = (Unit)Enum.Parse(typeof(Unit), reader.GetString(23), true);
                    if (!reader.IsDBNull(24))
                        burst._speed = reader.GetDouble(24);
                    if (!reader.IsDBNull(25))
                        burst._track_angle = reader.GetDouble(25);
                    if (!reader.IsDBNull(26))
                        burst._num_of_sat = reader.GetInt32(26);
                    if (!reader.IsDBNull(27))
                        burst._num_of_used_sat = reader.GetInt32(27);

                    for (int i = 28; i < 76; i += 4)
                    {
                        Satellite sat = new Satellite();
                        if (!reader.IsDBNull(i))
                            sat.ID = reader.GetString(i);
                        if (!reader.IsDBNull(i + 1))
                            sat.Elevation = reader.GetDouble(i + 1);
                        if (!reader.IsDBNull(i + 2))
                            sat.Azimuth = reader.GetDouble(i + 2);
                        if (!reader.IsDBNull(i + 3))
                            sat.SNR = reader.GetDouble(i + 3);
                        burst.AddSatalite(sat);
                    }

                    Bursts.Add(burst);
                    burst = new NmeaBurst();
                }
                #endregion
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetNmeaBursts");
            }
            finally
            {
                cmd.Dispose();
            }

            return Bursts;
        }

        #endregion

        #region MetaData

        #region Insert/Update MetaData
        public void InsertMetaData(TtMetaData md)
        {
            StringBuilder queryBeginning = new StringBuilder();
            StringBuilder queryEnd = new StringBuilder();
            queryBeginning.AppendFormat("INSERT INTO {0} (", TwoTrailsSchema.MetaDataSchema.TableName);
            queryEnd.Append("(");

            //CN
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.CN);
            queryEnd.AppendFormat("'{0}',", md.CN);

            //Name
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.ID);
            queryEnd.AppendFormat("'{0}',", md.Name);

            //Zone
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.UtmZone);
            queryEnd.AppendFormat("'{0}',", md.Zone);

            //Datum
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.Datum);
            queryEnd.AppendFormat("'{0}',", md.datum.ToString());

            //Distance UoM
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.UomDistance);
            queryEnd.AppendFormat("'{0}',", md.uomDistance.ToString());

            //Elev UoM
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.UomElevation);
            queryEnd.AppendFormat("'{0}',", md.uomElevation);

            //Slope UoM
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.UomSlope);
            queryEnd.AppendFormat("'{0}',", md.uomSlope);

            //Comment
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.Comment);
            queryEnd.AppendFormat("'{0}',", md.Comment);

            //Compass
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.Compass);
            queryEnd.AppendFormat("'{0}',", md.Compass);

            //Crew
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.Crew);
            queryEnd.AppendFormat("'{0}',", md.Crew);

            //Declination Type
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.DeclinationType);
            queryEnd.AppendFormat("'{0}',", md.decType.ToString());

            //Declination  
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.MagDec);
            queryEnd.AppendFormat("{0},", md.magDec);

            //Laser
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.MetaDataSchema.Laser);
            queryEnd.AppendFormat("'{0}',", md.Laser);

            //Receiver
            queryBeginning.AppendFormat("{0}", TwoTrailsSchema.MetaDataSchema.Receiver);
            queryEnd.AppendFormat("'{0}'", md.Receiver);

            queryBeginning.Append(") values ");
            queryEnd.Append(");");
            queryBeginning.AppendFormat(" {0}", queryEnd.ToString());

            if (!IsOpen)
                OpenDB();

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                update.CommandText = queryBeginning.ToString();
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:InsertMetaData");
            }
            finally
            {
                update.Dispose();
            }
        }

        public void UpdateMetaData(TtMetaData md)
        {
            StringBuilder where = new StringBuilder();
            StringBuilder query = new StringBuilder();
            query.AppendFormat("Update {0} set ", TwoTrailsSchema.MetaDataSchema.TableName);
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.MetaDataSchema.Comment, md.Comment);
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.MetaDataSchema.Compass, md.Compass);
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.MetaDataSchema.Crew, md.Crew);
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.MetaDataSchema.Datum, md.datum.ToString());
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.MetaDataSchema.DeclinationType, md.decType.ToString());
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.MetaDataSchema.ID, md.Name);
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.MetaDataSchema.Laser, md.Laser);
            query.AppendFormat("{0} = {1}, ", TwoTrailsSchema.MetaDataSchema.MagDec, md.magDec);
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.MetaDataSchema.Receiver, md.Receiver); 
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.MetaDataSchema.UomDistance, md.uomDistance.ToString());
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.MetaDataSchema.UomElevation, md.uomElevation.ToString());
            query.AppendFormat("{0} = '{1}', ", TwoTrailsSchema.MetaDataSchema.UomSlope, md.uomSlope.ToString());          
            query.AppendFormat("{0} = {1} ", TwoTrailsSchema.MetaDataSchema.UtmZone, md.Zone);

            query.AppendFormat("where {0} = '{1}'", TwoTrailsSchema.MetaDataSchema.CN, md.CN);

            if (!IsOpen)
                OpenDB();

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                update.CommandText = query.ToString();
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:UpdateMetaData");
            }
            finally
            {
                update.Dispose();
            }
        }

        #endregion

        private int DeleteAllMeta()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM {0}",
                TwoTrailsSchema.MetaDataSchema.TableName);

            SQLiteCommand cmd = _dbConnection.CreateCommand();
            int count = 0;

            try
            {
                cmd.CommandText = sql.ToString();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:DeleteAllMeta");
            }
            finally
            {
                cmd.Dispose();
            }

            return count;
        }

        public int DeleteMetaData(string CN)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM {0} WHERE {1} = '{2}'",
                TwoTrailsSchema.MetaDataSchema.TableName,
                TwoTrailsSchema.MetaDataSchema.CN,
                CN);

            SQLiteCommand cmd = _dbConnection.CreateCommand();
            int count = 0;

            try
            {
                cmd.CommandText = sql.ToString();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:DeleteMetaData");
            }
            finally
            {
                cmd.Dispose();
            }

            return count;
        }

        public TtMetaData GetMetaDataByCN(string CN)
        {
            List<TtMetaData> data = GetMetaData(String.Format("where {0} = '{1}'", TwoTrailsSchema.MetaDataSchema.CN, CN));

            if (data.Count > 0)
                return data[0];

            return null;
        }

        public List<TtMetaData> GetMetaData()
        {
            return GetMetaData("");
        }

        private List<TtMetaData> GetMetaData(string where)
        {
            StringBuilder query = new StringBuilder();
            StringBuilder fields = new StringBuilder();
            fields.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
                TwoTrailsSchema.MetaDataSchema.CN, //0
                TwoTrailsSchema.MetaDataSchema.Comment,//1
                TwoTrailsSchema.MetaDataSchema.Compass, //2
                TwoTrailsSchema.MetaDataSchema.Crew,    //3
                TwoTrailsSchema.MetaDataSchema.Datum,   //4
                TwoTrailsSchema.MetaDataSchema.DeclinationType, //5
                TwoTrailsSchema.MetaDataSchema.ID,      //6
                TwoTrailsSchema.MetaDataSchema.Laser,   //7
                TwoTrailsSchema.MetaDataSchema.MagDec,  //8
                TwoTrailsSchema.MetaDataSchema.Receiver,    //9
                TwoTrailsSchema.MetaDataSchema.UomDistance,     //10
                TwoTrailsSchema.MetaDataSchema.UomElevation,    //11
                TwoTrailsSchema.MetaDataSchema.UomSlope,        //12
                TwoTrailsSchema.MetaDataSchema.UtmZone);         //13

            query.AppendFormat("select {0} from {1}",
                fields.ToString(),
                TwoTrailsSchema.MetaDataSchema.TableName);
            if (where != null)
                query.AppendFormat(" {0}", where);

            SQLiteCommand cmd = _dbConnection.CreateCommand();
            List<TtMetaData> metas = new List<TtMetaData>();

            try
            {
                cmd.CommandText = query.ToString();
                TtMetaData md = new TtMetaData();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    md.CN = reader.GetString(0);
                    if (!reader.IsDBNull(1))
                        md.Comment = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        md.Compass = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        md.Crew = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                        md.datum = (Datum)Enum.Parse(typeof(Datum), reader.GetString(4), true);
                    if (!reader.IsDBNull(5))
                        md.decType = (DeclinationType)Enum.Parse(typeof(DeclinationType), reader.GetString(5), true);
                    md.Name = reader.GetString(6);
                    if (!reader.IsDBNull(7))
                        md.Laser = reader.GetString(7);
                    if (!reader.IsDBNull(8))
                        md.magDec = reader.GetDouble(8);
                    if (!reader.IsDBNull(9))
                        md.Receiver = reader.GetString(9);
                    md.uomDistance = (UomDistance)Enum.Parse(typeof(UomDistance), reader.GetString(10), true);
                    md.uomElevation = (UomElevation)Enum.Parse(typeof(UomElevation), reader.GetString(11), true);
                    md.uomSlope = (UomSlope)Enum.Parse(typeof(UomSlope), reader.GetString(12), true);
                    md.Zone = reader.GetInt32(13);
                    metas.Add(md);
                    md = new TtMetaData();
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetMetaData");
            }
            finally
            {
                cmd.Dispose();
            }

            return metas;
        }

        #endregion

        #region Project Info

        #region Get Project Info values
        private String GetProjectInfoField(string columnName)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("select {0} from {1}", columnName,
                TwoTrailsSchema.ProjectInfoSchema.TableName);

            SQLiteCommand cmd = _dbConnection.CreateCommand();
            string value = null;

            try
            {
                cmd.CommandText = query.ToString();

                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        value = reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetProjectInfoField");
            }
            finally
            {
                cmd.Dispose();
            }

            return value;
        }
        
        public string GetProjectID()
        {
            return GetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.ID);
        }
        
        public string GetProjectDescription()
        {
            return GetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.Description);
        }

        public string GetProjectRegion()
        {
            return GetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.Region);
        }

        public string GetProjectForest()
        {
            return GetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.Forest);
        }

        public string GetProjectDistrict()
        {
            return GetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.District);
        }

        public String GetProjectYear()
        {
            return GetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.Year);
        }
       
        public bool GetProjectDropZeros()
        {
            string b = GetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.DropZeros);

            if (b.IsBool())
                return b.ToBool();
            return false;
        }

        public bool GetProjectRound()
        {
            string b = GetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.Round);

            if (b.IsBool())
                return b.ToBool();
            return false;
        }

        public string GetProjectDeviceID()
        {
            return GetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.DeviceID);
        }

        public string GetProjectTtStartVersion()
        {
            return GetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.TtVersion);
        }

        private TtDalVersion GetProjectTtDbVersion()
        {
            return new TtDalVersion(GetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.TtDbSchemaVersion));
        }

        /*
        public TtDalVersion GetProjectTtDbVersion2()
        {
            return new TtDalVersion(GetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.TtDbSchemaVersion));
        }
        */

        #endregion

        #region Set Project Info values
        private void SetupProjInfo()
        {
            StringBuilder queryBeginning = new StringBuilder();
            StringBuilder queryEnd = new StringBuilder();

            queryBeginning.AppendFormat("INSERT INTO {0} (", TwoTrailsSchema.ProjectInfoSchema.TableName);
            queryEnd.Append("(");

            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.ProjectInfoSchema.TtDbSchemaVersion);
            queryEnd.AppendFormat("'{0}',", TwoTrailsSchema.SchemaVersion);

            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.ProjectInfoSchema.TtVersion);
            queryEnd.AppendFormat("'{0}',", Values.TwoTrailsVersion);

            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.ProjectInfoSchema.DropZeros);
            queryEnd.AppendFormat("'{0}',", Values.Settings.ProjectOptions.DropZero);

            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.ProjectInfoSchema.Round);
            queryEnd.AppendFormat("'{0}',", Values.Settings.ProjectOptions.Round);

            //queryBeginning.AppendFormat("{0},", TwoTrailsSchema.ProjectInfoSchema.Region);
            //queryEnd.AppendFormat("'{0}',", Values.Settings.ProjectOptions.Region);

            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.ProjectInfoSchema.ID);
            queryEnd.AppendFormat("'{0}',", Values.Settings.ProjectOptions.ProjectName);

            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.ProjectInfoSchema.DeviceID);
            queryEnd.AppendFormat("'{0}',", TtUtils.GetDeviceName());

            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.ProjectInfoSchema.Forest);
            queryEnd.AppendFormat("'{0}',", Values.Settings.ProjectOptions.Forest);

            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.ProjectInfoSchema.District);
            queryEnd.AppendFormat("'{0}',", Values.Settings.ProjectOptions.District);

            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.ProjectInfoSchema.Description);
            queryEnd.AppendFormat("'{0}',", Values.Settings.ProjectOptions.Description);

            queryBeginning.AppendFormat("{0}", TwoTrailsSchema.ProjectInfoSchema.Year);
            queryEnd.AppendFormat("'{0}'", DateTime.Now.Year);

            queryBeginning.Append(") values ");
            queryEnd.Append(");");
            queryBeginning.AppendFormat(" {0}", queryEnd.ToString());

            if (!IsOpen)
                OpenDB();

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                update.CommandText = queryBeginning.ToString();
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:SetupProjInfo");
            }
            finally
            {
                update.Dispose();
            }
        }

        public void SetProjectID(string ID)
        {
            SetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.ID, ID);
        }

        public void SetProjectDescription(string description)
        {
            SetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.Description, description);
        }

        public void SetProjectRegion(string region)
        {
            if (region == null)
                region = String.Empty;
            SetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.Region, region);
        }

        public void SetProjectForest(string forest)
        {
            SetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.Forest, forest);
        }

        public void SetProjectDistrict(string district)
        {
            SetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.District, district);
        }

        public void SetProjectYear(string year)
        {
            SetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.Year, year);
        }

        public void SetProjectDropZeroSetting(bool dropZero)
        {
            SetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.DropZeros, dropZero.ToString());
        }

        public void SetProjectRoundSetting(bool round)
        {
            SetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.Round, round.ToString());
        }


        private void SetProjectDeviceID(string id)
        {
            SetProjectInfoField(TwoTrailsSchema.ProjectInfoSchema.DeviceID, id);
        }


        private void SetProjectInfoField(string columnName, string value)
        {
            StringBuilder updateQuery = new StringBuilder();
            updateQuery.AppendFormat("update {0} set {1} = '{2}'",
                TwoTrailsSchema.ProjectInfoSchema.TableName,
                columnName,
                value);

            if (!IsOpen)
                OpenDB();

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                update.CommandText = updateQuery.ToString();
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:SetProjectInfoField");
            }
            finally
            {
                update.Dispose();
            }
        }
        #endregion

        #endregion

        #region Counts / Info

        /// <summary>
        /// Get the total Polygon Count
        /// </summary>
        /// <returns>Total Polygon Count</returns>
        public long GetPolyCount()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select count(*) from {0};", TwoTrailsSchema.PolygonSchema.TableName);
            return GetCount(sql.ToString());
        }

        /// <summary>
        /// Get the total number of points
        /// </summary>
        /// <returns>Total Point Count</returns>
        public long GetPointCount()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select count(*) from {0};", TwoTrailsSchema.PointSchema.TableName);
            return GetCount(sql.ToString());
        }

        /// <summary>
        /// Get the number of points in a polygon
        /// </summary>
        /// <param name="polyName">Polygon Name</param>
        /// <returns>Point Count in the polygon</returns>
        public long GetPointCount(string polyCN)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select count(*) from {0} where {1} = '{2}'",
                TwoTrailsSchema.PointSchema.TableName,
                TwoTrailsSchema.PointSchema.PolyCN,
                polyCN);

            return GetCount(sql.ToString());
        }

        /// <summary>
        /// Get the number of points in a group
        /// </summary>
        /// <param name="gruopName">Group Name</param>
        /// <returns>Point Count in the polygon</returns>
        public long GetPointCountFromGroup(string groupCN)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select count(*) from {0} where {1} = '{2}'",
                TwoTrailsSchema.PointSchema.TableName,
                TwoTrailsSchema.PointSchema.GroupCN,
                groupCN);

            return GetCount(sql.ToString());
        }

        /// <summary>
        /// Return the # of points of an operation like the given one
        /// GPS and Waypoint
        /// Trav and SS
        /// Quondam
        /// 
        /// Probably mainly used for testing. Gives the # of rows in the given
        /// operation's table
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public long GetPointCountByOpGroup(OpType op)
        {
            StringBuilder sql = new StringBuilder();
            string tableName = PointTypeToTableName(op);

            sql.AppendFormat("select count(*) from {0}", tableName);

            return GetCount(sql.ToString());
        }

        /// <summary>
        /// Return the # of points of OpType op by looking in the points table.
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public long GetPointCount(OpType op)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select count(*) from {0} where {1} = {2}", TwoTrailsSchema.PointSchema.TableName,
                TwoTrailsSchema.PointSchema.Operation,
                op.ToString());

            return GetCount(sql.ToString());
        }

        /// <summary>
        /// Executes and returns the count from a select count(*) query
        /// </summary>
        /// <param name="countQuery">a query for only count(*)</param> 
        /// <returns>The count returned from the database</returns>
        private long GetCount(string countQuery)
        {
            SQLiteCommand cmd = _dbConnection.CreateCommand();
            long count = 0;

            try
            {
                cmd.CommandText = countQuery;

                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    count = reader.GetInt64(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetCount");
            }
            finally
            {
                cmd.Dispose();
            }

            return count;
        }
        
        /// <summary>
        /// Get the total number of groups
        /// </summary>
        /// <returns>Total Group Count</returns>
        public long GetGroupCount()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select count(*) from {0};", TwoTrailsSchema.GroupSchema.TableName);
            return GetCount(sql.ToString());
        }


        /// <summary>
        /// Get the total number of groups
        /// </summary>
        /// <returns>Total Group Count</returns>
        public long GetMetadataCount()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select count(*) from {0};", TwoTrailsSchema.MetaDataSchema.TableName);
            return GetCount(sql.ToString());
        }

        public bool HasChildQuondam(string pointCN)
        {
            StringBuilder query = new StringBuilder();
            query.AppendFormat("select count(*) from {0} where {1} = {2}",
                TwoTrailsSchema.QuondamPointSchema.TableName,
                TwoTrailsSchema.QuondamPointSchema.ParentPointCN,
                pointCN);
            return (GetCount(query.ToString()) > 0);
        }

        public bool HasChildQuondam(TtPoint p)
        {
            return HasChildQuondam(p.CN);
        }

        #endregion

        #region Defaults

        public TtMetaData CreateDefaultMetaData()
        {
            TtMetaData md = Engine.Values.Settings.ReadMetaSettings();

            if (md == null)
            {
                md = new TtMetaData();
                md.Name = "Meta1";
                md.magDec = 0;
                md.decType = DeclinationType.MagDec;
                md.Zone = 13;
                md.uomSlope = UomSlope.Percent;
                md.uomElevation = UomElevation.Feet;
                md.uomDistance = UomDistance.FeetTenths;
                md.datum = Datum.NAD83;
                InsertMetaData(md);
            }

            md.CN = Values.EmptyGuid;

            return md;
        }

        #endregion

        #region DB Utils

        public string PointTypeToTableName(OpType op)
        {
            switch(op)
            {
                case OpType.GPS:
                case OpType.WayPoint:
                case OpType.Take5:
                case OpType.Walk:
                    {
                        return TwoTrailsSchema.GpsPointSchema.TableName;
                    }
                case OpType.Traverse:
                case OpType.SideShot:
                    {
                        return TwoTrailsSchema.TravPointSchema.TableName;
                    }
                case OpType.Quondam:
                    {
                        return TwoTrailsSchema.QuondamPointSchema.TableName;
                    }
                default:
                    {
                        throw new NotImplementedException("Not implemented: PointTypeToTableName");
                    }
            }
        }

        public TtPoint GetNewPointByOpType(OpType o, TtPoint pointTocopy)
        {
            if (pointTocopy == null)
            {
                pointTocopy = new TtPoint();
            }

            if (pointTocopy.op == OpType.Quondam)
            {
                TtPoint ParentPoint = GetPoint(((QuondamPoint)pointTocopy).ParentCN);

                if (ParentPoint != null)
                {
                    TtPoint UpdatePoint = TtUtils.CopyPoint(ParentPoint);

                    UpdatePoint.RemoveQuondamLink(pointTocopy.CN);
                    SavePoint(ParentPoint, UpdatePoint);
                }
            }

            switch (o)
            {
                case OpType.GPS:
                    return new GpsPoint(pointTocopy);
                case OpType.Quondam:
                    return new QuondamPoint(pointTocopy);
                case OpType.SideShot:
                    return new SideShotPoint(pointTocopy);
                case OpType.Take5:
                    return new Take5Point(pointTocopy);
                case OpType.Traverse:
                    return new TravPoint(pointTocopy);
                case OpType.Walk:
                    return new WalkPoint(pointTocopy);
                case OpType.WayPoint:
                    return new WayPoint(pointTocopy);
                default:
                    throw new Exception("Invalid Optype");
            }
        }

        public TtPoint GetNewPointByOpType(OpType o)
        {
            switch (o)
            {
                case OpType.GPS:
                    return new GpsPoint();
                case OpType.Quondam:
                    return new QuondamPoint();
                case OpType.SideShot:
                    return new SideShotPoint();
                case OpType.Take5:
                    return new Take5Point();
                case OpType.Traverse:
                    return new TravPoint();
                case OpType.Walk:
                    return new WalkPoint();
                case OpType.WayPoint:
                    return new WayPoint();
                default:
                    throw new Exception("Invalid Optype");
            }
        }

        private List<string> GetCNs(string table, string where)
        {
            List<string> CNs = new List<string>();
            SQLiteCommand cmd = _dbConnection.CreateCommand();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("select {0} from {1} where {2}",
                    TwoTrailsSchema.SharedSchema.CN,
                    table,
                    where);
                cmd.CommandText = sb.ToString();

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CNs.Add(reader.GetString(0));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:GetCNs");
            }
            finally
            {
                cmd.Dispose();
            }

            return CNs;
        }

        private string StringListToInClause(string fieldName, List<string> values)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} in (",
                fieldName);
            if (values.Count == 0)
            {
                sb.Append(")");
                return sb.ToString();
            }
            for(int i = 0; i < values.Count-1; i++)
            {
                sb.AppendFormat("'{0}', ",
                    values[i]);
            }
            sb.AppendFormat("'{0}')", 
                values[values.Count - 1]);
            return sb.ToString();
        }

        #endregion

        #region move/renames
        private void UpdatePointsOnPolyCnChange(string currentPolyCN, string newPolyCN, SQLiteTransaction trans)
        {
            StringBuilder where = new StringBuilder();
            StringBuilder query = new StringBuilder();
            where.AppendFormat("{0} = '{1}'", 
                TwoTrailsSchema.PointSchema.PolyCN,
                currentPolyCN);

            query.AppendFormat("update {0} set {1} = '{2}' where {3}",
                TwoTrailsSchema.PointSchema.TableName,
                TwoTrailsSchema.PointSchema.PolyCN,
                newPolyCN,
                where.ToString());

            SQLiteCommand update = _dbConnection.CreateCommand();

            try
            {
                update.CommandText = query.ToString();
                update.Transaction = trans;
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessLayer:UpdatePointsOnPolyCnChange");
            }
            finally
            {
                update.Dispose();
            }
        }
        #endregion
    }

    public static class SqlDataExt
    {
        public static byte[] GetBytesEx(this SQLiteDataReader reader)
        {
            const int CHUNK_SIZE = 2 * 1024;
            byte[] buffer = new byte[CHUNK_SIZE];
            long bytesRead;
            long fieldOffset = 0;
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                while ((bytesRead = reader.GetBytes(0, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, (int)bytesRead);
                    fieldOffset += bytesRead;
                }
                return stream.ToArray();
            }
        }

        public static double? ForceGetDouble(this SQLiteDataReader reader, int i)
        {
            double? value = null;

            try
            {
                value = reader.GetDouble(i);
            }
            catch
            {
                object o = reader.GetValue(i);
                if (o is double)
                {
                    value = o as double?;
                }
            }

            return value;
        }
    }
}
