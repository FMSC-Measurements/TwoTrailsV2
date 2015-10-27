using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using TwoTrails.BusinessObjects;
using TwoTrails.Engine;
using TwoTrails.GpsAccess;
using TwoTrails.Utilities;
using TwoTrails.BusinessLogic;


namespace TwoTrails.DataAccess
{
    public static class DbReleaseVersions
    {
        public static readonly TtDalVersion D0_9_2 = new TtDalVersion(0, 9, 2);
        public static readonly TtDalVersion D0_9_3 = new TtDalVersion(0, 9, 3);
        public static readonly TtDalVersion D0_9_4 = new TtDalVersion(0, 9, 4);
        public static readonly TtDalVersion D1_0_0 = new TtDalVersion(1, 0, 0);
        public static readonly TtDalVersion D1_1_0 = new TtDalVersion(1, 1, 0);
        public static readonly TtDalVersion D1_2_0 = new TtDalVersion(1, 2, 0);
    }

    public partial class DataAccessLayer
    {
        private DataAccessLayer _upgradeData;

        public bool Upgrade(DataAccessLayer oldData)
        {
            _upgradeData = oldData;
            bool success = false;

            try
            {
                if (_upgradeData != null)
                {
                    if (!_upgradeData.IsOpen)
                        _upgradeData.OpenDAL();

#if !(PocketPC || WindowsCE || Mobile)
                    Values.UpdateStatusProgress();
#endif

                    if (_upgradeData.IsOpen)
                    {
                        success = UpgradeProject() &&
                            UpgradeMeta() &&
                            UpgradePolys() &&
                            UpgradeGroups() &&
                            UpgradePoints() &&
                            UpgradeNmea();
                    }
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:Upgrade");
                return false;
            }
            finally
            {
                if (_upgradeData != null && _upgradeData.IsOpen)
                    _upgradeData.CloseDB();
                _upgradeData = null;
            }

            return success;
        }

        private bool UpgradeProject()
        {
            try
            {
                SetProjectID(_upgradeData.GetProjectID());
                SetProjectDescription(_upgradeData.GetProjectDescription());
                SetProjectRegion(_upgradeData.GetProjectRegion());
                SetProjectForest(_upgradeData.GetProjectForest());
                SetProjectDistrict(_upgradeData.GetProjectDistrict());
                SetProjectYear(_upgradeData.GetProjectYear());
                SetProjectDropZeroSetting(_upgradeData.GetProjectDropZeros());

                if (_upgradeData.DalVersion < DbReleaseVersions.D0_9_2)
                {
                    SetProjectRoundSetting(_upgradeData.GetProjectRound());
                }

                if (_upgradeData.DalVersion < DbReleaseVersions.D0_9_3)
                {
                    SetProjectDeviceID(_upgradeData.GetProjectDeviceID());
                }

#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusProgress();
#endif
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:UpgradeProject");
                return false;
            }

            return true;
        }


        #region Metadata
        private List<TtMetaData> GetUpgradeMetaData()
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
                (DalVersion < DbReleaseVersions.D1_1_0) ? "DistanceUOM" :
                TwoTrailsSchema.MetaDataSchema.UomDistance,     //10
                (DalVersion < DbReleaseVersions.D1_1_0) ? "ElevationUOM" :
                TwoTrailsSchema.MetaDataSchema.UomElevation,    //11
                (DalVersion < DbReleaseVersions.D1_1_0) ? "SlopeUOM" :
                TwoTrailsSchema.MetaDataSchema.UomSlope,        //12
                TwoTrailsSchema.MetaDataSchema.UtmZone);         //13

            query.AppendFormat("select {0} from {1}",
                fields.ToString(),
                TwoTrailsSchema.MetaDataSchema.TableName);

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
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:GetMetaData");
            }
            finally
            {
                cmd.Dispose();
            }

            return metas;
        }

        private bool UpgradeMeta()
        {
            try
            {
                DeleteAllMeta();

                foreach (TtMetaData meta in _upgradeData.GetUpgradeMetaData())
                {
                    InsertMetaData(meta);
                }

#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusProgress();
#endif
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:UpgradeMeta");
                return false;
            }

            return true;
        }
        #endregion


        #region Polygons
        private List<TtPolygon> GetUpgradePolygons()
        {
            //#query.AppendFormat("SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10} from {11} ",
            StringBuilder query = new StringBuilder();
            query.AppendFormat("SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7} from {8} ",
                TwoTrailsSchema.SharedSchema.CN,
                TwoTrailsSchema.PolygonSchema.PolyID,
                //#TwoTrailsSchema.PolygonSchema.Comment,
                TwoTrailsSchema.PolygonSchema.Description,
                //#TwoTrailsSchema.PolygonSchema.Locked,
                TwoTrailsSchema.PolygonSchema.Accuracy,
                TwoTrailsSchema.PolygonSchema.Area,
                TwoTrailsSchema.PolygonSchema.Perimeter,
                //#TwoTrailsSchema.PolygonSchema.NumOfLinks,
                TwoTrailsSchema.PolygonSchema.IncrementBy,
                TwoTrailsSchema.PolygonSchema.PointStartIndex,
                TwoTrailsSchema.PolygonSchema.TableName);

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
                    //#if (!reader.IsDBNull(2))
                    //#    poly.Comment = reader.GetString(2);
                    if (!reader.IsDBNull(2))
                        poly.Description = reader.GetString(2);
                    //#poly.IsLocked = Boolean.Parse(reader.GetString(4));
                    if (!reader.IsDBNull(3))
                        poly.PolyAccu = reader.GetDouble(3);
                    if (!reader.IsDBNull(4))
                        poly.Area = reader.GetDouble(4);
                    if (!reader.IsDBNull(5))
                        poly.Perimeter = reader.GetDouble(5);
                    //#if (!reader.IsDBNull(8))
                    //#    poly.LinkedQuondams = reader.GetInt32(8);
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
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:GetQuondamPointData");
            }
            finally
            {
                cmd.Dispose();
            }

            return polys;
        }

        private bool UpgradePolys()
        {
            try
            {
                foreach (TtPolygon poly in _upgradeData.GetUpgradePolygons())
                {
                    InsertPolygon(poly);
                }

#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusProgress();
#endif
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:UpgradePolys");
                return false;
            }

            return true;
        }
        #endregion


        #region Nmea
        private List<NmeaBurst> GetUpgradeNmeaBursts()
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
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:GetNmeaBursts");
            }
            finally
            {
                cmd.Dispose();
            }

            return Bursts;
        }

        private void InsertUpgradeNmeaBurst(NmeaBurst burst, SQLiteTransaction trans)
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
            queryEnd.AppendFormat("'{0}',", burst._PointCN);

            //Used in Point
            queryBeginning.AppendFormat("{0},", TwoTrailsSchema.TtnmeaSchema.Used);
            if (burst._Used)
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

            //HAE
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

                queryBeginning.AppendFormat("{0},", satSRN);
                queryEnd.AppendFormat("'{0}',", sats[i].SNR);
            }
            #endregion

            queryBeginning.Remove(queryBeginning.Length - 1, 1);
            queryEnd.Remove(queryEnd.Length - 1, 1);

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
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:SaveNmeaBurst");
            }
            finally
            {
                update.Dispose();
            }
        }

        private bool UpgradeNmea()
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                foreach (NmeaBurst burst in _upgradeData.GetUpgradeNmeaBursts())
                {
                    InsertUpgradeNmeaBurst(burst, trans);
                }

                trans.Commit();

#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusProgress();
#endif
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:UpgradeNmea");
                return false;
            }
            finally
            {
                trans.Dispose();
            }

            return true;
        }
        #endregion


        #region Points
        private List<TtPoint> GetUpgradePoints()
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
            query.AppendFormat("ORDER BY {0}, {1}", TwoTrailsSchema.PointSchema.PolyCN, TwoTrailsSchema.PointSchema.Order);

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

                    pt.OnBnd = Boolean.Parse(reader.GetString(3));


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

                    string[] links = reader.GetString(16).Split('_');
                    foreach (string link in links)
                    {
                        if (link.Length == 36)   //length of GUID
                            pt.AddQuondamLink(link);
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
                                GetOldTravPointData(pt);
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
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:GetPoints");
            }
            finally
            {
                cmd.Dispose();
            }

            return points;
        }


        #region GetOldPointData

        void GetOldTravPointData(TtPoint pt)
        {
            SideShotPoint t = (SideShotPoint)pt;
            StringBuilder fields = new StringBuilder();
            fields.AppendFormat("{0}, {1}, {2}, {3}",
                TwoTrailsSchema.TravPointSchema.BackAz,
                TwoTrailsSchema.TravPointSchema.ForwardAz,
                TwoTrailsSchema.TravPointSchema.SlopeDistance,
                TwoTrailsSchema.TravPointSchema.VerticalAngle);
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
        #endregion

        private void InsertUpgradePoint(TtPoint newPoint, SQLiteTransaction trans)
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
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:InsertPoint");
            }
            finally
            {
                update.Dispose();
            }
        }

        private bool UpgradePoints()
        {
            SQLiteTransaction trans = _dbConnection.BeginTransaction();

            try
            {
                foreach (TtPoint point in _upgradeData.GetUpgradePoints())
                {
                    InsertUpgradePoint(point, trans);
                }

                trans.Commit();

#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusProgress();
#endif
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:UpgradePoints");
                return false;
            }
            finally
            {
                trans.Dispose();
            }

            return true;
        }
        #endregion


        #region Groups
        private List<TtGroup> GetUpgradeGroups()
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
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:GetGroups");
            }
            finally
            {
                cmd.Dispose();
            }

            return groups;
        }

        private void InsertUpgradeGroup(TtGroup group)
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
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:InsertGroup");
            }
            finally
            {
                update.Dispose();
            }
        }

        private bool UpgradeGroups()
        {
            try
            {
                foreach (TtGroup group in _upgradeData.GetUpgradeGroups())
                {
                    if (group.CN == Values.MainGroup.CN && GetGroupByCN(Values.MainGroup.CN) != null)
                        continue;

                    InsertUpgradeGroup(group);
                }

#if !(PocketPC || WindowsCE || Mobile)
                Values.UpdateStatusProgress();
#endif
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataAccessUpgrader:UpgradeGroups");
                return false;
            }

            return true;
        }
        #endregion
    }



    public class TtDalVersion
    {
        public int Major;
        public int Minor;
        public int Update;

        public TtDalVersion(int maj, int min, int up)
        {
            Major = maj;
            Minor = min;
            Update = up;
        }

        public TtDalVersion(string versionString)
        {
            Major = Minor = Update = 0;

            if (versionString == null)
                return;

            string[] vals = versionString.Split('.');

            if (vals.Count() > 0)
            {
                if (vals[0].IsInteger())
                    Major = vals[0].ToInteger();
            }

            if (vals.Count() > 1)
            {
                if (vals[1].IsInteger())
                    Minor = vals[1].ToInteger();
            }

            if (vals.Count() > 2)
            {
                if (vals[2].IsInteger())
                    Update = vals[2].ToInteger();
            }
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}", Major, Minor, Update);
        }

        public static bool operator <(TtDalVersion version, TtDalVersion otherVersion)
        {
            if (version.Major < otherVersion.Major)
                return true;
            else if (version.Major == otherVersion.Major)
            {
                if (version.Minor < otherVersion.Minor)
                    return true;
                else if (version.Minor == otherVersion.Minor)
                {
                    if (version.Update < otherVersion.Update)
                        return true;
                }
            }

            return false;
        }

        public static bool operator >(TtDalVersion version, TtDalVersion otherVersion)
        {
            if (version.Major > otherVersion.Major)
                return true;
            else if (version.Major == otherVersion.Major)
            {
                if (version.Minor > otherVersion.Minor)
                    return true;
                else if (version.Minor == otherVersion.Minor)
                {
                    if (version.Update > otherVersion.Update)
                        return true;
                }
            }

            return false;
        }

        public static bool operator ==(TtDalVersion version, TtDalVersion otherVersion)
        {
            return (version.Major == otherVersion.Major &&
                version.Minor == otherVersion.Minor &&
                version.Update == otherVersion.Update);
        }

        public static bool operator !=(TtDalVersion version, TtDalVersion otherVersion)
        {
            return (version.Major != otherVersion.Major ||
                version.Minor != otherVersion.Minor ||
                version.Update != otherVersion.Update);
        }

        public override int GetHashCode()
        {
            return Major ^ Minor ^ Update;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(TtDalVersion))
                return false;

            TtDalVersion compVersion = (TtDalVersion)obj;

            if (Major == compVersion.Major && Minor == compVersion.Minor && Update == compVersion.Update)
                return true;

            return false;
        }
    }
}
