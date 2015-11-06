using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTrails.Engine;
using TwoTrails.BusinessObjects;
using System.Windows.Forms;
using System.IO;
using TwoTrails.DataAccess;
using KmlUtilities;
using GpxUtilities;
using Engine.BusinessLogic;
using System.Collections;
using Ionic.Zip;

#if !(PocketPC || WindowsCE || Mobile)
using GeoAPI;
using GeoAPI.Geometries;
using NetTopologySuite.Utilities;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.Features;
using NetTopologySuite.Operation.Polygonize;
#else
using FMSC.Controls;
#endif

namespace TwoTrails.Utilities
{
    public class DataOutput
    {
        private string _SelectedPath;
        public string SelectedPathDir { get { return _SelectedPath; } }
        public string SelectedPath
        {
            get { return System.IO.Path.Combine(_SelectedPath, FolderName); }
            set
            {
                _SelectedPath = value;
            }
        }

        public string FolderName { get; set; }

        public DataOutput()
        {
            try
            {
#if(PocketPC || WindowsCE || Mobile)
                SelectedPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
#else
                SelectedPath = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
#endif
            }
            catch
            {
                SelectedPath = null;
            }
        }

        public bool SelectFolder(string path)
        {
            SelectedPath = path;
            return true;
        }

        public bool SelectFolder()
        {
            try
            {
#if (PocketPC || WindowsCE || Mobile)
                
                using (FolderBrowserDialogCF fbd = new FolderBrowserDialogCF(null))
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        SelectedPath = fbd.Folder;
                        return true;
                    }
                }
#else
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Select Output Location";
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        SelectedPath = fbd.SelectedPath;
                        return true;
                    }
                }
#endif
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataOutput:SelectFolder");
            }

            return false;
        }

        public bool CreateDirectory()
        {
            try
            {
                if(!Directory.Exists(SelectedPath))
                    Directory.CreateDirectory(SelectedPath);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void DumpProject(DataAccessLayer DAL)
        {
            while (!Directory.Exists(_SelectedPath))
            {
                if (!SelectFolder())
                    return;
            }

            try
            {
                WriteTtNmea(DAL);
                WriteProject(DAL);
                WriteMeta(DAL);
                WritePolygons(DAL);
                WritePoints(DAL);
                WriteKmz(DAL);
                WriteSummary(DAL);
                WriteGpx(DAL);
                WriteShapes(DAL);
                WriteHtml(DAL);
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataOuput:DumpProject", ex.StackTrace);
                throw new Exception("DumpAll Error");
            }
        }


        public void WriteTtNmea(DataAccessLayer DAL)
        {
            List<GpsAccess.NmeaBurst> bursts = DAL.GetNmeaBursts();

            if (bursts != null && bursts.Count > 0)
            {
                List<string> Columns = new List<string>();
                List<List<string>> data = new List<List<string>>();

                #region Columns
                Columns.Add("Point ID");
                Columns.Add("Point CN");
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.Used);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.DateTimeZulu);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.Longitude);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.Latitude);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.LatDir);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.LonDir);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.MagVar);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.MagDir);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.UtmZone);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.UtmX);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.UtmY);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.Altitude);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.AltUnit);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.FixQuality);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.Mode);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PDOP);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.HDOP);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.VDOP);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRNS);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.HDo_Position);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.HAE);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.HAE_Unit);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.Speed);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.Track_Angle);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.SatelliteCount);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.SatelliteUsed);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN1ID);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN1Elev);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN1Az);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN1SRN);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN2ID);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN2Elev);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN2Az);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN2SRN);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN3ID);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN3Elev);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN3Az);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN3SRN);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN4ID);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN4Elev);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN4Az);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN4SRN);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN5ID);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN5Elev);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN5Az);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN5SRN);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN6ID);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN6Elev);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN6Az);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN6SRN);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN7ID);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN7Elev);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN7Az);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN7SRN);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN8ID);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN8Elev);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN8Az);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN8SRN);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN9ID);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN9Elev);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN9Az);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN9SRN);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN10ID);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN10Elev);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN10Az);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN10SRN);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN11ID);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN11Elev);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN11Az);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN11SRN);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN12ID);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN12Elev);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN12Az);
                Columns.Add(TwoTrailsSchema.TtnmeaSchema.PRN12SRN);
                #endregion

                #region Add Data
                foreach (GpsAccess.NmeaBurst burst in bursts)
                {
                    List<string> burstData = new List<string>();

                    string pointID = "", pointCN = "";
                    TtPoint p = DAL.GetPoint(burst._PointCN);
                    if (p != null)
                    {
                        pointID = p.PID.ToString();
                        pointCN = p.CN;
                    }

                    burstData.Add(pointID);                     //0
                    burstData.Add(pointCN);
                    burstData.Add(burst._Used.ToString());
                    burstData.Add(burst._datetime.ToString("MM/dd/yyyy hh:mm:ss tt"));
                    burstData.Add(burst._longitude.ToString());
                    burstData.Add(burst._latitude.ToString());  //5
                    burstData.Add(burst._latDir.ToString());    
                    burstData.Add(burst._longDir.ToString());
                    burstData.Add(burst._magVar.ToString());
                    burstData.Add(burst._magVarDir.ToString());
                    burstData.Add(burst._utm_zone.ToString());  //10
                    burstData.Add(burst._X.ToString());         
                    burstData.Add(burst._Y.ToString());
                    burstData.Add(burst._altitude.ToString());
                    burstData.Add(burst._alt_unit.ToString());
                    burstData.Add(burst._fix_quality.ToString());//15
                    burstData.Add(burst._fix.ToString());       
                    burstData.Add(burst._PDOP.ToString());
                    burstData.Add(burst._HDOP.ToString());
                    burstData.Add(burst._VDOP.ToString());
                    burstData.Add(burst._fixed_PRNs);           //20
                    burstData.Add(burst._horiz_dilution_position.ToString());
                    burstData.Add(burst._geoid_height.ToString());
                    burstData.Add(burst._geoid_unit.ToString());
                    burstData.Add(burst._speed.ToString());
                    burstData.Add(burst._track_angle.ToString());   //25
                    burstData.Add(burst._num_of_sat.ToString());    
                    burstData.Add(burst._num_of_used_sat.ToString());   

                    foreach (GpsAccess.Satellite sat in burst.GetSatellites())
                    {
                        burstData.Add(sat.ID);
                        burstData.Add(sat.Elevation.ToString());
                        burstData.Add(sat.Azimuth.ToString());
                        burstData.Add(sat.SNR.ToString());
                    }

                    data.Add(burstData);
                }
                #endregion

                WriteCsvFile("TtNmeaData", Columns, data);
            }
        }

        public void WriteProject(DataAccessLayer DAL)
        {
            if (Values.Settings.ProjectOptions != null && Values.Settings.DeviceOptions != null)
            {
                List<string> Columns = new List<string>();
                List<List<string>> data = new List<List<string>>();

                #region Columns
                Columns.Add("Project ID");
                Columns.Add("Description");
                Columns.Add("Region");
                Columns.Add("Forest");
                Columns.Add("District");
                Columns.Add("Year");
                Columns.Add("DropZero");
                Columns.Add("GPS COM");
                Columns.Add("GPS Baud");
                Columns.Add("Laser COM");
                Columns.Add("Laser Baud");
                Columns.Add("TtVersion");
                //Columns.Add("Build Date");
                Columns.Add("TtDbVersion");
                #endregion

                #region Add Data
                List<string> info = new List<string>();
                info.Add(Values.Settings.ProjectOptions.ProjectName.Scrub());
                info.Add(Values.Settings.ProjectOptions.Description.Scrub());
                info.Add(Values.Settings.ProjectOptions.Region.ToString());
                info.Add(Values.Settings.ProjectOptions.Forest.Scrub());
                info.Add(Values.Settings.ProjectOptions.District.Scrub());
                info.Add(Values.Settings.ProjectOptions.Year);
                info.Add(Values.Settings.ProjectOptions.DropZero.ToString());
                info.Add(Values.Settings.DeviceOptions.GpsComPort.Scrub());
                info.Add(Values.Settings.DeviceOptions.GpsBaud.ToString());
                info.Add(Values.Settings.DeviceOptions.LaserComPort.Scrub());
                info.Add(Values.Settings.DeviceOptions.LaserBaud.ToString());
                info.Add(DAL.GetProjectTtStartVersion());
                //info.Add(Values.TwoTrailsBuildDate);
                info.Add(DAL.DalVersion.ToString());
                data.Add(info);
                #endregion

                WriteCsvFile("ProjectInfo", Columns, data);
            }
        }

        public void WriteMeta(DataAccessLayer DAL)
        {
            List<TtMetaData> meta = DAL.GetMetaData();

            if (meta != null && meta.Count > 0)
            {
                List<string> Columns = new List<string>();
                List<List<string>> data = new List<List<string>>();

                #region Columns
                Columns.Add("Name");
                Columns.Add("UTM Zone");
                Columns.Add("Datum");
                Columns.Add("Distance");
                Columns.Add("Elevation");
                Columns.Add("Slope");
                Columns.Add("Declination Type");
                Columns.Add("Declination");
                Columns.Add("Gps");
                Columns.Add("Laser");
                Columns.Add("Compass");
                Columns.Add("Crew");
                Columns.Add("Comment");
                Columns.Add("CN");
                #endregion

                #region Add Data
                foreach (TtMetaData md in meta)
                {
                    List<string> metaData = new List<string>();

                    metaData.Add(md.Name.Scrub());
                    metaData.Add(md.Zone.ToString());
                    metaData.Add(md.datum.ToString());
                    metaData.Add(md.uomDistance.ToString());
                    metaData.Add(md.uomElevation.ToString());
                    metaData.Add(md.uomSlope.ToString());
                    metaData.Add(md.decType.ToString());
                    metaData.Add(md.magDec.ToString());
                    metaData.Add(md.Receiver.Scrub());
                    metaData.Add(md.Laser.Scrub());
                    metaData.Add(md.Compass.Scrub());
                    metaData.Add(md.Crew.Scrub());
                    metaData.Add(md.Comment.Scrub());
                    metaData.Add(md.CN);

                    data.Add(metaData);
                }
                #endregion

                WriteCsvFile("Metadata", Columns, data);
            }
        }

        public void WritePolygons(DataAccessLayer DAL)
        {
            List<TtPolygon> polys = DAL.GetPolygons();

            if (polys != null && polys.Count > 0)
            {
                List<string> Columns = new List<string>();
                List<List<string>> data = new List<List<string>>();

                #region Columns
                Columns.Add("Name");
                Columns.Add("Accuracy");
                Columns.Add("Area_MtSq");
                Columns.Add("Perimeter_M");
                Columns.Add("Description");
                Columns.Add("CN");
                #endregion

                #region Add Data
                foreach (TtPolygon poly in polys)
                {
                    List<string> polyData = new List<string>();

                    polyData.Add(poly.Name.Scrub());
                    polyData.Add(poly.PolyAccu.ToString());
                    polyData.Add(poly.Area.ToString());
                    polyData.Add(poly.Perimeter.ToString());
                    polyData.Add(poly.Description.Scrub());
                    polyData.Add(poly.CN);

                    data.Add(polyData);
                }
                #endregion

                WriteCsvFile("Polygons", Columns, data);
            }
        }

        public bool WritePoints(DataAccessLayer DAL)
        {
            List<TtPoint> points = DAL.GetPoints();

            if (points != null && points.Count > 0)
            {
                List<string> Columns = new List<string>();
                List<List<string>> data = new List<List<string>>();
                Dictionary<string, TtMetaData> meta = DAL.GetMetaData().ToDictionary(m => m.CN, m => m);
         
                #region Columns
                Columns.Add("Point ID");    //0
                Columns.Add("CN");
                Columns.Add("Operation");
                Columns.Add("Index");
                Columns.Add("Poly Name"); 
                Columns.Add("DateTime");
                Columns.Add("Metadata");
                Columns.Add("OnBnd");  
                Columns.Add("AdjX");
                Columns.Add("AdjY");        
                Columns.Add("AdjZ");
                Columns.Add("UnAdjX");
                Columns.Add("UnAdjY");  
                Columns.Add("UnAdjZ");
                Columns.Add("X");           
                Columns.Add("Y");
                Columns.Add("Z");
                Columns.Add("RMSEr");
                Columns.Add("Man Acc");
                Columns.Add("Fwd Az");
                Columns.Add("Back Az");
                Columns.Add("Slope Dist");
                Columns.Add("Horiz Dist");
                Columns.Add("Slope Dist Type");
                Columns.Add("Slope Angle");
                Columns.Add("Slope Angle Type");
                Columns.Add("Parent Name");
                Columns.Add("Parent CN");
                Columns.Add("Comment");
                Columns.Add("Poly CN");
                Columns.Add("Group Name");
                Columns.Add("Group CN");    
                Columns.Add("Linked CNs");
                #endregion

                TtMetaData tmpMeta;

                #region Add Data
                try
                {
                    foreach (TtPoint p in points)
                    {
                        List<string> pl = new List<string>();

                        tmpMeta = meta[p.MetaDefCN];

                        pl.Add(p.PID.ToString());   //0
                        pl.Add(p.CN);
                        pl.Add(p.op.ToString());
                        pl.Add(p.Index.ToString());
                        pl.Add(p.PolyName.Scrub());
                        pl.Add(p.Time.ToString("MM/dd/yyyy hh:mm:ss tt"));

                        
                        try
                        {
                            pl.Add(tmpMeta.Name);
                        }
                        catch
                        {
                            pl.Add(p.MetaDefCN);
                        }

                        pl.Add(p.OnBnd.ToString());
                        pl.Add(p.AdjX.ToString());
                        pl.Add(p.AdjY.ToString());
                        pl.Add(p.AdjZ.ToString());
                        pl.Add(p.UnAdjX.ToString());
                        pl.Add(p.UnAdjY.ToString());
                        pl.Add(p.UnAdjZ.ToString());

                        if (p.IsGpsType())
                        {
                            pl.Add(((GpsPoint)p).X.ToString());
                            pl.Add(((GpsPoint)p).Y.ToString());
                            pl.Add(((GpsPoint)p).Z.ToString());
                            pl.Add(((GpsPoint)p).RMSEr.ToString());
                            pl.Add(((GpsPoint)p).ManualAccuracy.ToString());
                        }
                        else
                        {
                            for (int i = 0; i < 5; i++) { pl.Add(""); }
                        }

                        if (p.IsTravType())
                        {
                            SideShotPoint sp = (SideShotPoint)p;

                            pl.Add(sp.ForwardAz.ToString());
                            pl.Add(sp.BackwardAz.ToString());

                            pl.Add(TtUtils.ConvertDistance(sp.SlopeDistance, tmpMeta.uomDistance, UomDistance.Meters).ToString());
                            pl.Add(TtUtils.ConvertDistance(sp.HorizontalDistance, tmpMeta.uomDistance, UomDistance.Meters).ToString());
                            pl.Add(tmpMeta.uomDistance.ToString());

                            pl.Add(TtUtils.ConvertAngle(sp.SlopeAngle, tmpMeta.uomSlope, UomSlope.Degrees).ToString());
                            pl.Add(tmpMeta.uomSlope.ToString());
                        }
                        else
                        {
                            for (int i = 0; i < 7; i++) { pl.Add(""); }
                        }

                        if (p.op == OpType.Quondam)
                        {
                            pl.Add(((QuondamPoint)p).ParentPID.ToString());
                            pl.Add(((QuondamPoint)p).ParentCN);
                        }
                        else
                        {
                            pl.Add(""); pl.Add("");
                        }

                        pl.Add(p.Comment.Scrub());
                        pl.Add(p.PolyCN);
                        pl.Add(p.GroupName.Scrub());
                        pl.Add(p.GroupCN);

                        StringBuilder sb = new StringBuilder();
                        foreach (string link in p.LinkedPoints)
                        {
                            sb.Append(link + "_");
                        }

                        pl.Add(sb.ToString());

                        data.Add(pl);
                    }
                #endregion

                    if (!WriteCsvFile("Points", Columns, data))
                        return false;

                    data.Clear();
                    Columns.Clear();

                    #region Columns
                    Columns.Add("Group Name");  //0
                    Columns.Add("CN");
                    Columns.Add("Description");
                    Columns.Add("Manual Accuracy");
                    Columns.Add("Group Type");
                    //Columns.Add("Number Of Points");    //5
                    /*
                    Columns.Add("Num Of GpsType Points");
                    Columns.Add("Num Of Gps Points");
                    Columns.Add("Num Of Traverse Points");
                    Columns.Add("Num Of Take5 Points");
                    Columns.Add("Num Of Walk Points");      //10
                    Columns.Add("Num Of SideShot Points"); 
                    Columns.Add("Num Of Qnd Points");
                    Columns.Add("Num Of Way Points");
                    Columns.Add("Num Of Points OnBnd");
                    Columns.Add("Num Of Points OffBnd");//15
                    */
                    #endregion

                    foreach (TtGroup g in DAL.GetGroups())
                    {
                        List<string> gl = new List<string>();

                        gl.Add(g.Name.Scrub());         //0
                        gl.Add(g.CN);
                        gl.Add(g.Description.Scrub());
                        gl.Add(g.ManualAccuracy.ToString());
                        gl.Add(g.GroupType.ToString());
                        //gl.Add(g.NumberOfPoints.ToString());   //5
                        /*
                        gl.Add(g.NumOfGpsTypePoints.ToString());
                        gl.Add(g.NumOfGpsPoints.ToString());
                        gl.Add(g.NumOfTraversePoints.ToString());
                        gl.Add(g.NumOfTake5Points.ToString());
                        gl.Add(g.NumOfWalkPoints.ToString());  //10
                        gl.Add(g.NumOfSideShotPoints.ToString());
                        gl.Add(g.NumOfQndPoints.ToString());
                        gl.Add(g.NumOfWayPoints.ToString());
                        gl.Add(g.NumOfPointsOnBnd.ToString());
                        gl.Add(g.NumOfPointsOffBnd.ToString());//15
                        */

                        data.Add(gl);
                    }

                    return WriteCsvFile("Groups", Columns, data);

                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "DataOutput:WritePoints");
                    throw ex;
                }
            }

            return false;
        }

        public void WriteKmz(DataAccessLayer DAL)
        {
            KmlDocument doc = CreateKmlDoc(DAL);

            if(doc != null)
                WriteKmzFile(doc);
        }

        public void WriteSummary(DataAccessLayer DAL)
        {
            HowAmIDoingOptions options = new HowAmIDoingOptions(DAL);
            HowAmIDoingLogic logic = new HowAmIDoingLogic(options);

            options.TtFilePath = System.IO.Path.GetFileName(Values.CurrentTtFileName);
            options.ReportPath = String.Format("{0}\\{1}_Sumary.txt", SelectedPath,
                Values.Settings.ProjectOptions.ProjectName);
            options.SaveReport = true;
            options.PopulateFromDataLayer();

            logic.Execute();

            //using (StreamWriter sw = new StreamWriter(SelectedPath + "\\" +
            //    Values.Settings.ProjectOptions.ProjectName + "_Summary.txt"))
            //{
            //    sw.WriteLine(options.ReportText.ToString());
            //}
        }

        public void WriteGpx(DataAccessLayer DAL)
        {
            GpxDocument doc = CreateGpxDoc(DAL);

            if (doc != null)
                WriteGpxFile(doc);
        }

        public void WriteShapes(DataAccessLayer DAL)
        {
            WriteShapeFiles(DAL);
        }

        public void WriteHtml(DataAccessLayer DAL)
        {
            WriteTextFile(TtGMapGenerator.GenerateHtml(DAL), "html");
        }


        public KmlDocument CreateKmlDoc(DataAccessLayer DAL)
        {
            #region Create Document

            KmlDocument doc = new KmlDocument(Values.Settings.ProjectOptions.ProjectName, Values.Settings.ProjectOptions.Description);

            doc.Open = true;
            doc.Properties = new KmlProperties();
            doc.Properties.Snippit = "Generated in TwoTrails";
            doc.Visibility = true;

            #endregion


            #region Create Styles / StyleMaps

            const int AdjLineSize = 5;
            const int UnAdjLineSize = 7;

            KmlStyle sAdjBound = new KmlStyle("AdjBound");
            KmlStyle sUnAdjBound = new KmlStyle("UnAdjBound");
            KmlStyle sAdjNav = new KmlStyle("AdjNav");
            KmlStyle sUnAdjNav = new KmlStyle("UnAdjNav");
            KmlStyle sAdjMisc = new KmlStyle("AdjMisc");
            KmlStyle sUnAdjMisc = new KmlStyle("UnAdjMisc");
            KmlStyle sWay = new KmlStyle("Way");
            
            KmlColor AdjBoundColor = new KmlColor(27, 211, 224, 255);   //1BD3E0
            KmlColor UnAdjBoundColor = new KmlColor(27, 112, 224, 255); //1B70E0
            KmlColor AdjNavColor = new KmlColor(27, 224, 142, 255);     //1BE08E
            KmlColor UnAdjNavColor = new KmlColor(14, 168, 86, 255);    //0E8A56
            KmlColor AdjMiscColor = new KmlColor(234, 90, 250, 255);    //EA5AFA
            KmlColor UnAdjMiscColor = new KmlColor(164, 29, 179, 255);  //A41DB3
            KmlColor WayColor = new KmlColor(255, 0, 0, 255);           //FF0000
            KmlColor KmlWhite = new KmlColor(255, 255, 255, 255);       //FFFFFF

            sAdjBound.SetColorsILP(AdjBoundColor);
            sAdjBound.IconScale = 1;
            sAdjBound.LineWidth = AdjLineSize;
            sAdjBound.LineLabelVisibility = true;
            sAdjBound.PolygonFill = false;
            sAdjBound.PolygonOutline = true;
            sAdjBound.BalloonDisplayMode = DisplayMode.Default;

            sUnAdjBound.SetColorsILP(UnAdjBoundColor);
            sUnAdjBound.IconScale = 1;
            sUnAdjBound.LineWidth = UnAdjLineSize;
            sUnAdjBound.LineLabelVisibility = false;
            sUnAdjBound.PolygonFill = false;
            sUnAdjBound.PolygonOutline = true;
            sUnAdjBound.BalloonDisplayMode = DisplayMode.Default;

            sAdjNav.SetColorsILP(AdjNavColor);
            sAdjNav.IconScale = 1;
            sAdjNav.LineWidth = AdjLineSize;
            sAdjNav.LineLabelVisibility = false;
            sAdjNav.PolygonFill = false;
            sAdjNav.PolygonOutline = true;
            sAdjNav.BalloonDisplayMode = DisplayMode.Default;

            sUnAdjNav.SetColorsILP(UnAdjNavColor);
            sUnAdjNav.IconScale = 1;
            sUnAdjNav.LineWidth = UnAdjLineSize;
            sUnAdjNav.LineLabelVisibility = false;
            sUnAdjNav.PolygonFill = false;
            sUnAdjNav.PolygonOutline = true;
            sUnAdjNav.BalloonDisplayMode = DisplayMode.Default;

            sUnAdjMisc.IconColorMode = ColorMode.Normal;
            sUnAdjMisc.IconColor = UnAdjMiscColor;
            sUnAdjMisc.IconScale = 1;
            sUnAdjMisc.BalloonDisplayMode = DisplayMode.Default;

            sWay.IconColorMode = ColorMode.Normal;
            sWay.IconColor = WayColor;
            sWay.IconScale = 1;
            sWay.BalloonDisplayMode = DisplayMode.Default;

            KmlStyle sAdjBoundH = new KmlStyle(sAdjBound, "AdjBoundH");
            KmlStyle sUnAdjBoundH = new KmlStyle(sUnAdjBound, "UnAdjBoundH");
            KmlStyle sAdjNavH = new KmlStyle(sAdjNav, "AdjNavH");
            KmlStyle sUnAdjNavH = new KmlStyle(sUnAdjNav, "UnAdjNavH");
            KmlStyle sAdjMiscH = new KmlStyle(sAdjMisc, "AdjMiscH");
            KmlStyle sUnAdjMiscH = new KmlStyle(sUnAdjMisc, "UnAdjMiscH");
            KmlStyle sWayH = new KmlStyle(sWay, "WayH");

            sAdjBoundH.IconScale = 1.1;
            sAdjBoundH.IconColor = KmlWhite;
            sUnAdjBoundH.IconScale = 1.1;
            sUnAdjBoundH.IconColor = KmlWhite;
            sAdjNavH.IconScale = 1.1;
            sAdjNavH.IconColor = KmlWhite;
            sUnAdjNavH.IconScale = 1.1;
            sUnAdjNavH.IconColor = KmlWhite;
            sAdjMiscH.IconScale = 1.1;
            sAdjMiscH.IconColor = KmlWhite;
            sUnAdjMiscH.IconScale = 1.1;
            sUnAdjMiscH.IconColor = KmlWhite;
            sWayH.IconScale = 1.1;
            sWayH.IconColor = KmlWhite;

            doc.AddStyle(sAdjBound);
            doc.AddStyle(sAdjBoundH);
            doc.AddStyle(sUnAdjBound);
            doc.AddStyle(sUnAdjBoundH);
            doc.AddStyle(sAdjNav);
            doc.AddStyle(sAdjNavH);
            doc.AddStyle(sUnAdjNav);
            doc.AddStyle(sUnAdjNavH);
            doc.AddStyle(sAdjMisc);
            doc.AddStyle(sAdjMiscH);
            doc.AddStyle(sUnAdjMisc);
            doc.AddStyle(sUnAdjMiscH);
            doc.AddStyle(sWay);
            doc.AddStyle(sWayH);


            KmlStyleMap sAdjBoundMap = new KmlStyleMap("AdjBoundMap", sAdjBound.StyleUrl, sAdjBoundH.StyleUrl);
            KmlStyleMap sUnAdjBoundMap = new KmlStyleMap("UnAdjBoundMap", sUnAdjBound.StyleUrl, sUnAdjBoundH.StyleUrl);
            KmlStyleMap sAdjNavMap = new KmlStyleMap("AdjNavMap", sAdjNav.StyleUrl, sAdjNavH.StyleUrl);
            KmlStyleMap sUnAdjNavMap = new KmlStyleMap("UnAdjNavMap", sUnAdjNav.StyleUrl, sUnAdjNavH.StyleUrl);
            KmlStyleMap sAdjMiscMap = new KmlStyleMap("AdjMiscMap", sAdjMisc.StyleUrl, sAdjMiscH.StyleUrl);
            KmlStyleMap sUnAdjMiscMap = new KmlStyleMap("UnAdjMiscMap", sUnAdjMisc.StyleUrl, sUnAdjMiscH.StyleUrl);
            KmlStyleMap sWayMap = new KmlStyleMap("WayMap", sWay.StyleUrl, sWayH.StyleUrl);

            doc.AddStyleMap(sAdjBoundMap);
            doc.AddStyleMap(sUnAdjBoundMap);
            doc.AddStyleMap(sAdjNavMap);
            doc.AddStyleMap(sUnAdjNavMap);
            doc.AddStyleMap(sAdjMiscMap);
            doc.AddStyleMap(sUnAdjMiscMap);
            doc.AddStyleMap(sWayMap);

            #endregion

            #region Create Polygons

            List<TtPolygon> polys = DAL.GetPolygons();

            foreach (TtPolygon poly in polys)
            {
                List<TtPoint> points = DAL.GetPointsInPolygon(poly.CN);

                #region Create root Polygon Folder
                KmlFolder folder = new KmlFolder(poly.Name, poly.Description);

                folder.Open = false;
                folder.Visibility = true;

                folder.Properties = new KmlProperties();
                folder.Properties.Snippit = poly.Description;
                folder.Properties.ExtendedData = new KmlExtendedData();
                folder.Properties.ExtendedData.AddData(new KmlExtendedData.Data(" ", "In Meters"));
                folder.Properties.ExtendedData.AddData(new KmlExtendedData.Data("Accuracy", poly.PolyAccu.ToString()));
                folder.Properties.ExtendedData.AddData(new KmlExtendedData.Data("Perimeter", poly.Perimeter.ToString()));
                folder.Properties.ExtendedData.AddData(new KmlExtendedData.Data("Area", poly.Area.ToString()));
                #endregion

                #region Create SubFolders under Polygon root
                KmlFolder fAdjBound = new KmlFolder("AdjBound", "Adjusted Boundary Polygon");
                KmlFolder fUnAdjBound = new KmlFolder("UnAdjBound", "UnAdjusted Boundary Polygon");
                KmlFolder fAdjNav = new KmlFolder("AdjNav", "Adjusted Navigation Polygon");
                KmlFolder fUnAdjNav = new KmlFolder("UnAdjNav", "UnAdjusted Navigation Polygon");
                KmlFolder fMiscPoints = new KmlFolder("Misc", "Misc Points");
                KmlFolder fWayPoints = new KmlFolder("Waypoints", "Waypoints");

                fAdjBound.StyleUrl = sAdjBoundMap.StyleUrl;
                fUnAdjBound.StyleUrl = sUnAdjBoundMap.StyleUrl;
                fAdjNav.StyleUrl = sAdjNavMap.StyleUrl;
                fUnAdjNav.StyleUrl = sUnAdjNavMap.StyleUrl;
                fMiscPoints.StyleUrl = sAdjMiscMap.StyleUrl;
                fWayPoints.StyleUrl = sWayMap.StyleUrl;

                fAdjBound.Visibility = true;
                fUnAdjBound.Visibility = false;
                fAdjNav.Visibility = false;
                fUnAdjNav.Visibility = false;
                fMiscPoints.Visibility = false;
                fWayPoints.Visibility = false;

                fAdjBound.Open = false;
                fUnAdjBound.Open = false;
                fAdjNav.Open = false;
                fUnAdjNav.Open = false;
                fMiscPoints.Open = false;
                fWayPoints.Open = false;

                #endregion

                #region Create SubFolders for Bound, Nav and Misc

                KmlFolder fAdjBoundPoints = new KmlFolder("Points", "Adjusted Boundary Points");
                KmlFolder fUnAdjBoundPoints = new KmlFolder("Points", "UnAdjusted Boundary Points");
                KmlFolder fAdjNavPoints = new KmlFolder("Points", "Adjusted Navigation Points");
                KmlFolder fUnAdjNavPoints = new KmlFolder("Points", "UnAdjusted Navigation Points");
                KmlFolder fAdjMiscPoints = new KmlFolder("Adj Points", "Adjusted Misc Points");
                KmlFolder fUnAdjMiscPoints = new KmlFolder("UnAdj Points", "UnAdjusted Misc Points");

                fAdjBoundPoints.Visibility = true;
                fUnAdjBoundPoints.Visibility = false;
                fAdjNavPoints.Visibility = false;
                fUnAdjNavPoints.Visibility = false;
                fAdjMiscPoints.Visibility = false;
                fUnAdjMiscPoints.Visibility = false;

                fAdjBoundPoints.Open = false;
                fUnAdjBoundPoints.Open = false;
                fAdjNavPoints.Open = false;
                fUnAdjNavPoints.Open = false;
                fAdjMiscPoints.Open = false;
                fUnAdjMiscPoints.Open = false;
                #endregion

                #region Create Geometry

                KmlPolygon AdjBoundPoly = new KmlPolygon("AdjBoundPoly");
                KmlPolygon UnAdjBoundPoly = new KmlPolygon("UnAdjBoundPoly");
                List<Coordinates> AdjBoundPointList = new List<Coordinates>();
                List<Coordinates> UnAdjBoundPointList = new List<Coordinates>();

                KmlPolygon AdjNavPoly = new KmlPolygon("AdjNavPoly");
                KmlPolygon UnAdjNavPoly = new KmlPolygon("UnAdjNavPoly");
                List<Coordinates> AdjNavPointList = new List<Coordinates>();
                List<Coordinates> UnAdjNavPointList = new List<Coordinates>();

                AdjBoundPoly.AltMode = AltitudeMode.clampToGround;
                UnAdjBoundPoly.AltMode = AltitudeMode.clampToGround;
                AdjNavPoly.AltMode = AltitudeMode.clampToGround;
                UnAdjNavPoly.AltMode = AltitudeMode.clampToGround;

                AdjBoundPoly.IsPath = false;
                UnAdjBoundPoly.IsPath = false;
                AdjNavPoly.IsPath = true;
                UnAdjNavPoly.IsPath = true;

                #endregion

                #region Add Placemarks

                TtMetaData md = null;

                if (points.Count > 0)
                {
                    md = DAL.GetMetaDataByCN(points[0].MetaDefCN);

                    if (md == null)
                        throw new Exception("Meta Data is null. Cant obtain UTM Zone");
                }

                foreach (TtPoint point in points)
                {
                    double lat, lon;
                    TtUtils.UTMtoLatLon(point.AdjX, point.AdjY, md.Zone, out lat, out lon);
                    Coordinates adjCoord = new Coordinates(lat, lon, point.AdjZ);

                    TtUtils.UTMtoLatLon(point.UnAdjX, point.UnAdjY, md.Zone, out lat, out lon);
                    Coordinates unAdjCoord = new Coordinates(lat, lon, point.UnAdjZ);

                    string snippit = "Point Operation: " + point.op.ToString();

                    #region Create Placemarks for Bound/Nav

                    KmlPlacemark adjPm = new KmlPlacemark(point.PID.ToString(),
                        String.Format("Point Operation: {0}<br><div>\t     Adjusted<br>UtmX: {1}<br>UtmY: {2}</div><br>{3}",
                            point.op.ToString(), point.AdjX, point.AdjY, point.Comment));
                    adjPm.View = new KmlView();
                    adjPm.View.TimeStamp = point.Time;
                    adjPm.View.Coordinates = adjCoord;
                    adjPm.View.Tilt = 15;
                    adjPm.View.AltMode = AltitudeMode.clampToGround;
                    adjPm.View.Range = 150;

                    adjPm.Properties = new KmlProperties();
                    adjPm.Properties.Snippit = snippit;

                    adjPm.StyleUrl = sAdjBoundMap.StyleUrl;
                    adjPm.Open = false;
                    adjPm.Visibility = true;
                    adjPm.AddPoint(new KmlPoint(adjCoord, AltitudeMode.clampToGround));


                    KmlPlacemark unAdjPm = new KmlPlacemark(point.PID.ToString(),
                        String.Format("Point Operation: {0}<br><div>     Unadjusted<br>UtmX: {1}<br>UtmY: {2}</div><br>{3}",
                            point.op.ToString(), point.UnAdjX, point.UnAdjY, point.Comment));
                    unAdjPm.View = new KmlView();
                    unAdjPm.View.TimeStamp = point.Time;
                    unAdjPm.View.Coordinates = adjCoord;
                    unAdjPm.View.Tilt = 15;
                    unAdjPm.View.AltMode = AltitudeMode.clampToGround;
                    unAdjPm.View.Range = 150;

                    unAdjPm.Properties = new KmlProperties();
                    unAdjPm.Properties.Snippit = snippit;

                    unAdjPm.StyleUrl = sUnAdjBoundMap.StyleUrl;
                    unAdjPm.Open = false;
                    unAdjPm.Visibility = false;
                    unAdjPm.AddPoint(new KmlPoint(adjCoord, AltitudeMode.clampToGround));

                    #endregion

                    #region Add points and placemarks to lists
                    if (point.IsBndPoint())
                    {
                        AdjBoundPointList.Add(adjCoord);
                        UnAdjBoundPointList.Add(unAdjCoord);
                        fAdjBoundPoints.AddPlacemark(new KmlPlacemark(adjPm));
                        fUnAdjBoundPoints.AddPlacemark(new KmlPlacemark(unAdjPm));
                    }

                    unAdjPm.StyleUrl = String.Copy(sUnAdjNavMap.StyleUrl);
                    adjPm.StyleUrl = String.Copy(sAdjNavMap.StyleUrl);
                    adjPm.Visibility = false;

                    if (point.IsNavPoint())
                    {
                        AdjNavPointList.Add(adjCoord);
                        UnAdjNavPointList.Add(unAdjCoord);
                        fAdjNavPoints.AddPlacemark(new KmlPlacemark(adjPm));
                        fUnAdjNavPoints.AddPlacemark(new KmlPlacemark(unAdjPm));
                    }
                    else if (point.op == OpType.Quondam)
                    {
                        QuondamPoint p = point as QuondamPoint;

                        if (p.IsNavPoint())
                        {
                            AdjNavPointList.Add(adjCoord);
                            UnAdjNavPointList.Add(unAdjCoord);
                            fAdjNavPoints.AddPlacemark(new KmlPlacemark(adjPm));
                            fUnAdjNavPoints.AddPlacemark(new KmlPlacemark(unAdjPm));
                        }
                    }

                    #region Create Way / Misc point placemarks

                    unAdjPm.StyleUrl = String.Copy(sWayMap.StyleUrl);

                    if (point.op == OpType.WayPoint)
                    {
                        fWayPoints.AddPlacemark(new KmlPlacemark(unAdjPm));
                    }

                    #endregion
                    #endregion
                }

                #region Create Poly Placemarks

                //assign points to polys

                if(AdjBoundPointList.Count > 0)
                    AdjBoundPointList.Add(AdjBoundPointList[0]);
                if(UnAdjBoundPointList.Count > 0)
                    UnAdjBoundPointList.Add(UnAdjBoundPointList[0]);
                
                AdjBoundPoly.OuterBoundary = AdjBoundPointList;
                UnAdjBoundPoly.OuterBoundary = UnAdjBoundPointList;
                AdjNavPoly.OuterBoundary = AdjNavPointList;
                UnAdjNavPoly.OuterBoundary = UnAdjNavPointList;

                //get default data for the placemarks
                KmlView.KmlTimeSpan ts = null;
                if(points.Count > 0 )    
                    new KmlView.KmlTimeSpan(points[0].Time, points[points.Count - 1].Time);
                KmlPolygon.Dimensions adjDim = AdjBoundPoly.GetOuterDimensions();
                KmlPolygon.Dimensions unAdjDim = UnAdjBoundPoly.GetOuterDimensions();

                double? adjRange = null;
                double? unAdjRange = null;
                double? width;

                if (adjDim != null)
                {
                    adjRange = TtUtils.DistanceLatLon(0, adjDim.North, 0, adjDim.South);
                    width = TtUtils.DistanceLatLon(adjDim.East, 0, adjDim.West, 0);

                    if (width != null && width > adjRange)
                        adjRange = width;
                }

                if (unAdjDim != null)
                {
                    unAdjRange = TtUtils.DistanceLatLon(0, unAdjDim.North, 0, unAdjDim.South);
                    width = TtUtils.DistanceLatLon(unAdjDim.East, 0, unAdjDim.West, 0);

                    if (width != null && width > unAdjRange)
                        unAdjRange = width;
                }

                if (adjRange == null)
                    adjRange = 1000;
                else
                    adjRange *= 1.1;
                if (unAdjRange == null)
                    unAdjRange = 1000;
                else
                    unAdjRange *= 1.1;

                //AdjBoundPlacemark
                KmlPlacemark AdjBoundPlacemark = new KmlPlacemark("AdjBoundPoly", "Adjusted Boundary Polygon", new KmlView());
                AdjBoundPlacemark.View.AltMode = AltitudeMode.clampToGround;
                AdjBoundPlacemark.View.Coordinates = AdjBoundPoly.AveragedCoords;
                if (points.Count > 1)
                    AdjBoundPlacemark.View.TimeSpan = ts;
                AdjBoundPlacemark.View.Range = (double)adjRange;
                AdjBoundPlacemark.View.Tilt = 5;

                AdjBoundPlacemark.Properties = new KmlProperties();
                AdjBoundPlacemark.Properties.Snippit = poly.Description;

                AdjBoundPlacemark.Open = false;
                AdjBoundPlacemark.Visibility = true;
                AdjBoundPlacemark.AddPolygon(AdjBoundPoly);
                AdjBoundPlacemark.StyleUrl = sAdjBoundMap.StyleUrl;

                //UnAdjBoundPlacemark
                KmlPlacemark UnAdjBoundPlacemark = new KmlPlacemark("UnAdjBoundPoly", "UnAdjusted Boundary Polygon", new KmlView());
                UnAdjBoundPlacemark.View.AltMode = AltitudeMode.clampToGround;
                UnAdjBoundPlacemark.View.Coordinates = UnAdjBoundPoly.AveragedCoords;
                if (points.Count > 1)
                    UnAdjBoundPlacemark.View.TimeSpan = ts;
                UnAdjBoundPlacemark.View.Range = (double)unAdjRange;
                UnAdjBoundPlacemark.View.Tilt = 5;

                UnAdjBoundPlacemark.Properties = new KmlProperties();
                UnAdjBoundPlacemark.Properties.Snippit = poly.Description;

                UnAdjBoundPlacemark.Open = false;
                UnAdjBoundPlacemark.Visibility = false;
                UnAdjBoundPlacemark.AddPolygon(UnAdjBoundPoly);
                UnAdjBoundPlacemark.StyleUrl = sUnAdjBoundMap.StyleUrl;

                //AdjNavPlacemark
                KmlPlacemark AdjNavPlacemark = new KmlPlacemark("AdjNavPoly", "Adjusted Navigation Path", new KmlView());
                AdjNavPlacemark.View.AltMode = AltitudeMode.clampToGround;
                AdjNavPlacemark.View.Coordinates = AdjNavPoly.AveragedCoords;
                if (points.Count > 1)
                    AdjNavPlacemark.View.TimeSpan = ts;
                AdjNavPlacemark.View.Range = (double)adjRange;
                AdjNavPlacemark.View.Tilt = 5;

                AdjNavPlacemark.Properties = new KmlProperties();
                AdjNavPlacemark.Properties.Snippit = poly.Description;

                AdjNavPlacemark.Open = false;
                AdjNavPlacemark.Visibility = false;
                AdjNavPlacemark.AddPolygon(AdjNavPoly);
                AdjNavPlacemark.StyleUrl = sAdjNavMap.StyleUrl;

                //UnAdjNavPlacemark
                KmlPlacemark UnAdjNavPlacemark = new KmlPlacemark("UnAdjNavPoly", "UnAdjusted Navigation Path", new KmlView());
                UnAdjNavPlacemark.View.AltMode = AltitudeMode.clampToGround;
                UnAdjNavPlacemark.View.Coordinates = UnAdjNavPoly.AveragedCoords;
                if (points.Count > 1)
                    UnAdjNavPlacemark.View.TimeSpan = ts;
                UnAdjNavPlacemark.View.Range = (double)unAdjRange;
                UnAdjNavPlacemark.View.Tilt = 5;

                UnAdjNavPlacemark.Properties = new KmlProperties();
                UnAdjNavPlacemark.Properties.Snippit = poly.Description;

                UnAdjNavPlacemark.Open = false;
                UnAdjNavPlacemark.Visibility = false;
                UnAdjNavPlacemark.AddPolygon(UnAdjNavPoly);
                UnAdjNavPlacemark.StyleUrl = sUnAdjNavMap.StyleUrl;

                //add placemarks
                fAdjBound.AddPlacemark(AdjBoundPlacemark);
                fUnAdjBound.AddPlacemark(UnAdjBoundPlacemark);
                fAdjNav.AddPlacemark(AdjNavPlacemark);
                fUnAdjNav.AddPlacemark(UnAdjNavPlacemark);

                #endregion

                #endregion

                #region Add Folders To eachother
                //added point folders to bound/nav/misc folders
                fAdjBound.AddFolder(fAdjBoundPoints);
                fUnAdjBound.AddFolder(fUnAdjBoundPoints);
                fAdjNav.AddFolder(fAdjNavPoints);
                fUnAdjNav.AddFolder(fUnAdjNavPoints);
                fMiscPoints.AddFolder(fAdjMiscPoints);
                fMiscPoints.AddFolder(fUnAdjMiscPoints);

                //add bound/nav/misc/way folders to root polygon folder
                folder.AddFolder(fAdjBound);
                folder.AddFolder(fUnAdjBound);
                folder.AddFolder(fAdjNav);
                folder.AddFolder(fUnAdjNav);
                folder.AddFolder(fMiscPoints);
                folder.AddFolder(fWayPoints);

                //add polygon root to KmlDoc
                doc.AddFolder(folder);
                #endregion
            }

            #endregion

            return doc;
        }

        public GpxDocument CreateGpxDoc(DataAccessLayer DAL)
        {
            GpxDocument doc = new GpxDocument("USFS TwoTrails - http://www.fs.fed.us/fmsc/measure/geospatial/twotrails/");

            doc.MetaData = new GpxMetadata();
            doc.MetaData.Time = DateTime.Now;
            doc.MetaData.Name = Values.Settings.ProjectOptions.ProjectName;
            doc.MetaData.Link = "http://www.fs.fed.us/fmsc/measure/geospatial/twotrails/";

            #region Create Polygons

            List<TtPolygon> polys = DAL.GetPolygons();

            foreach (TtPolygon poly in polys)
            {
                GpxRoute AdjRoute = new GpxRoute(poly.Name + " - Adj Boundary", poly.Description);
                GpxTrack AdjTrack = new GpxTrack(poly.Name + " - Adj Navigation", poly.Description);

                GpxRoute UnAdjRoute = new GpxRoute(poly.Name + " - UnAdj Boundary", poly.Description);
                GpxTrack UnAdjTrack = new GpxTrack(poly.Name + " - UnAdj Navigation", poly.Description);

                AdjTrack.Segments.Add(new GpxTrackSeg());
                UnAdjTrack.Segments.Add(new GpxTrackSeg());

                List<TtPoint> points = DAL.GetPointsInPolygon(poly.CN);
                TtMetaData md = null;

                if (points.Count > 0)
                {
                    md = DAL.GetMetaDataByCN(points[0].MetaDefCN);

                    if (md == null)
                        throw new Exception("Meta Data is null.  Cant obtain UTM Zone");
                }

                if (points != null && points.Count > 0)
                {
                    foreach (TtPoint point in points)
                    {
                        double lat, lon;
                        TtUtils.UTMtoLatLon(point.AdjX, point.AdjY, md.Zone, out lat, out lon);
                        GpxPoint adjpoint = new GpxPoint(lat, lon, point.AdjZ);

                        TtUtils.UTMtoLatLon(point.UnAdjX, point.UnAdjY, md.Zone, out lat, out lon);
                        GpxPoint unAdjpoint = new GpxPoint(lat, lon, point.UnAdjZ);

                        adjpoint.Name = point.PID.ToString();
                        adjpoint.Time = point.Time;
                        adjpoint.Comment = point.Comment;
                        adjpoint.Description = "Point Operation: " + point.op.ToString() + "<br>UtmX:" + point.AdjX +
                            "<br>UtmY: " + point.AdjY;

                        unAdjpoint.Name = point.PID.ToString();
                        unAdjpoint.Time = point.Time;
                        unAdjpoint.Comment = point.Comment;
                        unAdjpoint.Description = "Point Operation: " + point.op.ToString() + "<br>UtmX:" + point.UnAdjX +
                            "<br>UtmY: " + point.UnAdjY;

                        #region Add points to lists
                        if (point.IsBndPoint())
                        {
                            AdjRoute.Points.Add(adjpoint);
                            UnAdjRoute.Points.Add(unAdjpoint);
                        }

                        if (point.IsNavPoint())
                        {
                            AdjTrack.Segments[0].Points.Add(adjpoint);
                            UnAdjTrack.Segments[0].Points.Add(unAdjpoint);
                        }
                        else if (point.op == OpType.Quondam)
                        {
                            QuondamPoint p = (QuondamPoint)point;

                            if (p.IsNavPoint())
                            {
                                AdjTrack.Segments[0].Points.Add(adjpoint);
                                UnAdjTrack.Segments[0].Points.Add(unAdjpoint);
                            }
                        }

                        if (point.op == OpType.WayPoint)
                        {
                            doc.AddPoint(unAdjpoint);
                        }
                        #endregion
                    }
                }


                doc.AddRoute(AdjRoute);
                doc.AddRoute(UnAdjRoute);
                doc.AddTrack(AdjTrack);
                doc.AddTrack(UnAdjTrack);
            }

            #endregion

            return doc;
        }
        

        #region Writers
        public bool WriteCsvFile(string filename, List<string> Columns, List<List<string>> data)
        {
            filename = filename.ScrubFileName();

            if (data.Count > 0 && filename != null && filename != "" && Columns.Count > 0)
            {
                if (Columns.Count == data[0].Count)
                {
                    using (StreamWriter sw = new StreamWriter(SelectedPath + "\\" +
                        Values.Settings.ProjectOptions.ProjectName + "_" + filename +
                        ".csv", false))
                    {
                        StringBuilder sb = new StringBuilder();

                        foreach (string column in Columns)
                        {
                            sb.Append(column + ',');
                        }
                        sb.Remove(sb.Length - 1, 1);

                        sw.WriteLine(sb.ToString());

                        int columnSize = Columns.Count;

                        foreach (List<string> list in data)
                        {
                            if (list.Count < columnSize)
                                continue;

                            sb = new StringBuilder();

                            for (int i = 0; i < columnSize; i++)
                            {
                                sb.Append(list[i] + ',');
                            }

                            sb.Remove(sb.Length - 1, 1);
                            sw.WriteLine(sb);
                        }
                    }
                }
                else
                {
                    TtUtils.WriteError("Amount of Columns not equal to Amount of Data", "DataOutput:WriteCsv");
                    return false;
                }
            }
            else
            {
                TtUtils.WriteError("Columns or Data has not objects or filename not valid", "DataOutput:WriteCsv");
                return false;
            }

            return true;
        }

        public void WriteGpxFile(GpxDocument doc)
        {
            if (doc != null)
            {
                string file = String.Format("{0}\\{1}.gpx", SelectedPath, Values.Settings.ProjectOptions.ProjectName);
                if (File.Exists(file))
                    File.Delete(file);

                using (GpxWriter gw = new GpxWriter(file, doc))
                {
                    gw.WriteStartDocument();
                    gw.WriteStartGpx();
                    gw.WriteGpxDocument();
                    gw.WriteEndGpx();
                    gw.WriteEndDocument();
                }
            }
        }

        public string WriteKmzFile(KmlDocument doc)
        {
            if (doc != null)
            {
                string file = String.Format("{0}\\{1}.kml", SelectedPath, Values.Settings.ProjectOptions.ProjectName);

                if (File.Exists(file))
                    File.Delete(file);

                try
                {
                    using (KmlWriter kw = new KmlWriter(file, doc))
                    {
                        kw.WriteStartDocument();
                        kw.WriteStartKml();
                        kw.WriteKmlDocument();
                        kw.WriteEndKml();
                        kw.WriteEndDocument();
                    }

                    string zfile = file.Remove(file.Length - 3, 3) + "kmz";

                    using (ZipFile zip = new ZipFile())
                    {
                        if (File.Exists(file))
                            zip.AddFile(file);

                        //save zip
                        zip.Save(zfile);

                        File.Delete(file);
                    }

                    return zfile;
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "DataOutput:WriteKmzFile");
                }
            }

            return null;
        }
        
        public void WriteShapeFiles(DataAccessLayer DAL)
        {
        #if !(PocketPC || WindowsCE || Mobile)
            List<TtPolygon> polys = DAL.GetPolygons();
            Dictionary<string, TtMetaData> metas = DAL.GetMetaData().ToDictionary(m => m.CN, m => m);

            string folder = SelectedPath + "\\GIS";
            Directory.CreateDirectory(folder);

            foreach (TtPolygon poly in polys)
            {
                string _CurrDir = String.Format("{0}\\{1}\\", folder, poly.Name.ScrubFileName());
                string _File = String.Format("{0}\\{1}\\{1}", folder, poly.Name.ScrubFileName());
                Directory.CreateDirectory(_CurrDir);

                string CurrFileName = System.IO.Path.Combine(folder, poly.Name);

                List<TtPoint> points = DAL.GetPointsInPolygon(poly.CN).ToList();

                List<WayPoint> wayPoints = points.FilterOnly(OpType.WayPoint).Cast<WayPoint>().ToList();
                points = points.FilterOut(OpType.WayPoint).ToList();

                TtMetaData md;

                if (points.Count > 0 || wayPoints.Count > 0)
                {
                    if (points.Count > 0)
                        md = DAL.GetMetaDataByCN(points[0].MetaDefCN);
                    else
                        md = DAL.GetMetaDataByCN(wayPoints[0].MetaDefCN);
                    if (md == null)
                        continue;
                }
                else
                    continue;

                if (wayPoints.Count > 0)
                    WriteWayPoints(_File, wayPoints, md);

                if (points.Count < 1)
                    continue;

                CoordinateList BAdjCoords = new CoordinateList();
                CoordinateList BUnAdjCoords = new CoordinateList();

                CoordinateList NavAdjCoords = new CoordinateList();
                CoordinateList NavUnAdjCoords = new CoordinateList();

                bool hasWayPoints = false;

                foreach (TtPoint point in points)
                {
                    if (point.IsNavPoint())
                    {
                        NavAdjCoords.Add(new Coordinate(point.AdjX, point.AdjY, point.AdjZ));
                        NavUnAdjCoords.Add(new Coordinate(point.UnAdjX, point.UnAdjY, point.UnAdjZ));
                    }

                    if (point.IsBndPoint())
                    {
                        BAdjCoords.Add(new Coordinate(point.AdjX, point.AdjY, point.AdjZ));
                        BUnAdjCoords.Add(new Coordinate(point.UnAdjX, point.UnAdjY, point.UnAdjZ));
                    }

                    if (point.op == OpType.WayPoint)
                    {
                        hasWayPoints = true;
                    }
                }

                #region Navigation

                #region Adj
                string FileName = _File + "_NavAdj";
                GeometryFactory geoFac = new GeometryFactory();
                ShapefileDataWriter sdw;
                Polygonizer polyizer = new Polygonizer();

                ArrayList features = new ArrayList();
                AttributesTable attTable = new AttributesTable();
                
                attTable.AddAttribute("Poly_Name", poly.Name);
                attTable.AddAttribute("Desc", poly.Description);
                attTable.AddAttribute("Poly", "Navigation Adjusted"); 
                attTable.AddAttribute("CN", poly.CN);
                attTable.AddAttribute("Perim_M", poly.Perimeter);

                Feature feat = new Feature();
                DbaseFileHeader dbh;

                if (NavAdjCoords.Count > 1)
                {
                    sdw = new ShapefileDataWriter(FileName, geoFac);

                    feat.Geometry = new NetTopologySuite.Geometries.LineString(NavAdjCoords.ToArray());
                    
                    feat.Attributes = attTable;

                    features.Add(feat);

                    dbh = ShapefileDataWriter.GetHeader((Feature)features[0], features.Count);

                    sdw.Header = dbh;
                    sdw.Write(features);
                    WriteProjection(FileName, md.Zone);

                    //points
                    FileName = _File + "_NavAdj_Points";
                    geoFac = new GeometryFactory();
                    sdw = new ShapefileDataWriter(FileName, geoFac);
                    features = new ArrayList();
                    attTable["Poly"] = "Navigation Adjusted Points";

                    features = GetPointFeatures(points.Where(p => p.IsNavPoint()), true, DAL, metas);

                    if (features.Count > 0)
                    {
                        dbh = ShapefileDataWriter.GetHeader((Feature)features[0], features.Count);
                        sdw.Header = dbh;
                        sdw.Write(features);
                        WriteProjection(FileName, md.Zone);
                    }
                }
                #endregion

                #region UnAdj
                if (NavUnAdjCoords.Count > 1)
                {
                    FileName = _File + "_NavUnAdj";
                    geoFac = new GeometryFactory();
                    sdw = new ShapefileDataWriter(FileName, geoFac);
                    features = new ArrayList();
                    attTable["Poly"] = "Navigation UnAdjusted";
                    feat = new Feature();
                    feat.Geometry = new NetTopologySuite.Geometries.LineString(NavUnAdjCoords.ToArray());
                    //feat.Geometry = new NetTopologySuite.Geometries.LinearRing(NavUnAdjCoords.ToArray());
                    feat.Attributes = attTable;

                    features.Add(feat);

                    dbh = ShapefileDataWriter.GetHeader((Feature)features[0], features.Count);
                    sdw.Header = dbh;
                    sdw.Write(features);
                    WriteProjection(FileName, md.Zone);

                    //points
                    FileName = _File + "_NavUnAdj_Points";
                    geoFac = new GeometryFactory();
                    sdw = new ShapefileDataWriter(FileName, geoFac);
                    features = new ArrayList();
                    attTable["Poly"] = "Navigation UnAdjusted Points";

                    features = GetPointFeatures(points.Where(p => p.IsNavPoint()), false, DAL, metas);

                    if (features.Count > 0)
                    {
                        dbh = ShapefileDataWriter.GetHeader((Feature)features[0], features.Count);
                        sdw.Header = dbh;
                        sdw.Write(features);
                        WriteProjection(FileName, md.Zone);
                    }
                }
                #endregion

                #endregion

                #region Boundary

                #region Adj Line
                if (BAdjCoords.Count > 1)
                {
                    FileName = _File + "_BndAdjLine";
                    geoFac = new GeometryFactory();
                    sdw = new ShapefileDataWriter(FileName, geoFac);
                    features = new ArrayList();
                    attTable["Poly"] = "Boundary Adjusted Line";
                    feat = new Feature();
                    feat.Geometry = new NetTopologySuite.Geometries.LineString(BAdjCoords.ToArray());
                    feat.Attributes = attTable;

                    features.Add(feat);

                    dbh = ShapefileDataWriter.GetHeader((Feature)features[0], features.Count);
                    sdw.Header = dbh;
                    sdw.Write(features);
                    WriteProjection(FileName, md.Zone);
                }
                #endregion

                #region UnAdj Line
                if (BUnAdjCoords.Count > 1)
                {
                    FileName = _File + "_BndUnAdjLine";
                    geoFac = new GeometryFactory();
                    sdw = new ShapefileDataWriter(FileName, geoFac);
                    features = new ArrayList();
                    attTable["Poly"] = "Boundary UnAdjusted Line";
                    feat = new Feature();
                    feat.Geometry = new NetTopologySuite.Geometries.LineString(BUnAdjCoords.ToArray());
                    feat.Attributes = attTable;

                    features.Add(feat);

                    dbh = ShapefileDataWriter.GetHeader((Feature)features[0], features.Count);
                    sdw.Header = dbh;
                    sdw.Write(features);
                    WriteProjection(FileName, md.Zone);
                }
                #endregion

                #region Adj
                if (BAdjCoords.Count > 3)
                {
                    FileName = _File + "_BndAdj";
                    geoFac = new GeometryFactory();
                    sdw = new ShapefileDataWriter(FileName, geoFac);
                    features = new ArrayList();
                    attTable.AddAttribute("Area_MtSq", poly.Area);
                    attTable["Poly"] = "Boundary Adjusted";
                    feat = new Feature();

                    if (BAdjCoords[0] != BAdjCoords[BAdjCoords.Count - 1])
                        BAdjCoords.Add(BAdjCoords[0]);

                    feat.Geometry = new NetTopologySuite.Geometries.Polygon(new NetTopologySuite.Geometries.LinearRing(BAdjCoords.ToArray()));
                    feat.Attributes = attTable;

                    features.Add(feat);

                    dbh = ShapefileDataWriter.GetHeader((Feature)features[0], features.Count);
                    sdw.Header = dbh;
                    sdw.Write(features);
                    WriteProjection(FileName, md.Zone);

                    //points
                    FileName = _File + "_BndAdj_Points";
                    geoFac = new GeometryFactory();
                    sdw = new ShapefileDataWriter(FileName, geoFac);
                    features = new ArrayList();
                    attTable["Poly"] = "Boundary Adjusted Points";

                    features = GetPointFeatures(points.Where(p => p.IsBndPoint()), true, DAL, metas);

                    if (features.Count > 0)
                    {
                        dbh = ShapefileDataWriter.GetHeader((Feature)features[0], features.Count);
                        sdw.Header = dbh;
                        sdw.Write(features);
                        WriteProjection(FileName, md.Zone);
                    }
                }
                #endregion

                #region UnAdj
                if (BUnAdjCoords.Count > 3)
                {
                    FileName = _File + "_BndUnAdj";
                    geoFac = new GeometryFactory();
                    sdw = new ShapefileDataWriter(FileName, geoFac);
                    features = new ArrayList();
                    attTable["Poly"] = "Boundary UnAdjusted";
                    feat = new Feature();

                    if (BUnAdjCoords[0] != BUnAdjCoords[BUnAdjCoords.Count - 1])
                        BUnAdjCoords.Add(BUnAdjCoords[0]);

                    feat.Geometry = new NetTopologySuite.Geometries.Polygon(new LinearRing(BUnAdjCoords.ToArray()));
                    feat.Attributes = attTable;

                    features.Add(feat);

                    dbh = ShapefileDataWriter.GetHeader((Feature)features[0], features.Count);
                    sdw.Header = dbh;
                    sdw.Write(features);
                    WriteProjection(FileName, md.Zone);

                    //points
                    FileName = _File + "_BndUnAdj_Points";
                    geoFac = new GeometryFactory();
                    sdw = new ShapefileDataWriter(FileName, geoFac);
                    features = new ArrayList();
                    attTable["Poly"] = "Boundary UnAdjusted Points";

                    features = GetPointFeatures(points.Where(p => p.IsBndPoint()), false, DAL, metas);

                    if (features.Count > 0)
                    {
                        dbh = ShapefileDataWriter.GetHeader((Feature)features[0], features.Count);
                        sdw.Header = dbh;
                        sdw.Write(features);
                        WriteProjection(FileName, md.Zone);
                    }
                }
                #endregion

                #region WayPoints
                if (hasWayPoints)
                {
                    //points
                    FileName = _File + "_WayPoints";
                    geoFac = new GeometryFactory();
                    sdw = new ShapefileDataWriter(FileName, geoFac);
                    features = new ArrayList();
                    attTable["Poly"] = "WayPoints";

                    features = GetPointFeatures(points.Where(p => p.op == OpType.WayPoint), false, DAL, metas);

                    if (features.Count > 0)
                    {
                        dbh = ShapefileDataWriter.GetHeader((Feature)features[0], features.Count);
                        sdw.Header = dbh;
                        sdw.Write(features);
                        WriteProjection(FileName, md.Zone);
                    }
                }
                #endregion
                #endregion
            }
        #endif
        }

#if !(PocketPC || WindowsCE || Mobile)
        private ArrayList GetPointFeatures(IEnumerable<TtPoint> points, bool adjusted, DataAccessLayer DAL, Dictionary<string, TtMetaData> metas)
        {
            ArrayList features = new ArrayList();
            Feature feat;

            
            AttributesTable attPointTable = new AttributesTable();

            foreach (TtPoint p in points)
            {
                TtMetaData tmpMeta = metas[p.MetaDefCN];

                attPointTable = new AttributesTable();
                attPointTable.AddAttribute("PID", p.PID);
                attPointTable.AddAttribute("Op", p.op.ToString());
                attPointTable.AddAttribute("Index", p.Index);
                attPointTable.AddAttribute("PolyName", p.PolyName);
                attPointTable.AddAttribute("DateTime", p.Time.ToString("MM/dd/yyyy hh:mm:ss tt"));

                /*
                if (metas.ContainsKey(p.MetaDefCN))
                    attPointTable.AddAttribute("MetaData", tmpMeta.Name);
                else
                    attPointTable.AddAttribute("MetaData", String.Empty);
                */

                attPointTable.AddAttribute("OnBnd", p.OnBnd);
                //attPointTable.AddAttribute("GroupName", p.GroupName);
                attPointTable.AddAttribute("AdjX", p.AdjX);
                attPointTable.AddAttribute("AdjY", p.AdjY);
                attPointTable.AddAttribute("AdjZ", p.AdjZ);
                attPointTable.AddAttribute("UnAdjX", p.UnAdjX);
                attPointTable.AddAttribute("UnAdjY", p.UnAdjY);
                attPointTable.AddAttribute("UnAdjZ", p.UnAdjZ);


                if (p.IsGpsType())
                {
                    GpsPoint gps = (GpsPoint)p;
                    //attPointTable.AddAttribute("X", gps.X);
                    //attPointTable.AddAttribute("Y", gps.X);
                    //attPointTable.AddAttribute("Z", gps.Z);
                    attPointTable.AddAttribute("RMSEr", gps.RMSEr.dNoNull());
                    attPointTable.AddAttribute("ManAcc", gps.ManualAccuracy.dNoNull());
                }
                else
                {
                    //attPointTable.AddAttribute("X", String.Empty);
                    //attPointTable.AddAttribute("Y", String.Empty);
                    //attPointTable.AddAttribute("Z", String.Empty);
                    attPointTable.AddAttribute("RMSEr", String.Empty);
                    attPointTable.AddAttribute("ManAcc", String.Empty);
                }

                /*
                if (p.IsTravType())
                {
                    SideShotPoint ssp = (SideShotPoint)p;
                    attPointTable.AddAttribute("FwdAz", ssp.ForwardAz.dNoNull());
                    attPointTable.AddAttribute("BkAz", ssp.BackwardAz.dNoNull());
                    attPointTable.AddAttribute("SlopeDist", TtUtils.ConvertDistance(ssp.SlopeDistance, tmpMeta.uomDistance, UomDistance.Meters).ToString());
                    attPointTable.AddAttribute("HorzDist", TtUtils.ConvertDistance(ssp.HorizontalDistance, tmpMeta.uomDistance, UomDistance.Meters).ToString());
                    attPointTable.AddAttribute("DistType", tmpMeta.uomDistance.ToString());
                    attPointTable.AddAttribute("SlopeAngle", ssp.SlopeAngle);
                    attPointTable.AddAttribute("AngleType", tmpMeta.uomSlope.ToString());
                }
                else
                {
                    attPointTable.AddAttribute("FwdAz", String.Empty);
                    attPointTable.AddAttribute("BkAz", String.Empty);
                    attPointTable.AddAttribute("SlopeDist", String.Empty);
                    attPointTable.AddAttribute("HorzDist", String.Empty);
                    attPointTable.AddAttribute("DistType", String.Empty);
                    attPointTable.AddAttribute("SlopeAngle", String.Empty);
                    attPointTable.AddAttribute("AngleType", String.Empty);
                }
                */

                if (p.op == OpType.Quondam)
                {
                    QuondamPoint q = (QuondamPoint)p;
                    attPointTable.AddAttribute("ParentName", q.ParentPID);
                }
                else
                {
                    attPointTable.AddAttribute("ParentName", String.Empty);
                }


                attPointTable.AddAttribute("Comment", p.Comment == null ? String.Empty : p.Comment);

                feat = new Feature();
                feat.Geometry = (adjusted) ?
                    new NetTopologySuite.Geometries.Point(p.AdjX, p.AdjY, p.AdjZ) :
                    new NetTopologySuite.Geometries.Point(p.UnAdjX, p.UnAdjY, p.UnAdjZ);

                feat.Attributes = attPointTable;

                features.Add(feat);
            }

            return features;
        }
#endif


        private void WriteWayPoints(string file, List<WayPoint> points, TtMetaData md)
        {
        #if !(PocketPC || WindowsCE || Mobile)
            string FileName = file + "_WayPoints";
            GeometryFactory geoFac = new GeometryFactory();
            ShapefileDataWriter sdw = new ShapefileDataWriter(FileName, geoFac);

            ArrayList features = new ArrayList();
            AttributesTable attTable;


            Feature feat = new Feature();
            DbaseFileHeader dbh;


            foreach (WayPoint point in points)
            {
                feat = new Feature();
                attTable = new AttributesTable();

                attTable.AddAttribute("PID", point.PID);
                attTable.AddAttribute("Comment", point.Comment ?? String.Empty);
                attTable.AddAttribute("CN", point.CN);
                attTable.AddAttribute("Group", point.GroupName ?? String.Empty);
                attTable.AddAttribute("RMSEr", point.RMSEr ?? -1);
                attTable.AddAttribute("UnAdjX", point.UnAdjX);
                attTable.AddAttribute("UnAdjY", point.UnAdjY);
                attTable.AddAttribute("UnAdjZ", point.UnAdjZ);

                feat.Geometry = new NetTopologySuite.Geometries.Point(point.UnAdjX, point.UnAdjY, point.UnAdjZ);
                feat.Attributes = attTable;

                features.Add(feat);
            }

            dbh = ShapefileDataWriter.GetHeader((Feature)features[0], features.Count);

            sdw.Header = dbh;
            sdw.Write(features);
            WriteProjection(FileName, md.Zone);
        #endif
        }

        private void WriteProjection(string FileName, int Zone)
        {
            //create data for projection file
            string _Projection = String.Format("PROJCS[\"NAD_1983_UTM_Zone_{0}N\",GEOGCS[\"GCS_North_American_1983\",DATUM[\"D_North_American_1983\",SPHEROID[\"GRS_1980\",6378137.0,298.257222101]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]],PROJECTION[\"Transverse_Mercator\"],PARAMETER[\"False_Easting\",500000.0],PARAMETER[\"False_Northing\",0.0],PARAMETER[\"Central_Meridian\",{1}],PARAMETER[\"Scale_Factor\",0.9996],PARAMETER[\"Latitude_Of_Origin\",0.0],UNIT[\"Meter\",1.0],AUTHORITY[\"EPSG\",269{0}]]", Zone.ToString(), (-183 + Zone * 6).ToString());
            string _file = "";

            if (FileName != null && FileName.Length > 0)
            {
                if (FileName.Length > 4 && FileName.Substring(FileName.Length - 4, 3) == "prj")
                    _file = FileName;
                else
                    _file = FileName + ".prj";

                using (TextWriter tw = new StreamWriter(_file, false))
                {
                    tw.WriteLine(_Projection);
                }
            }
            else
                TtUtils.WriteError("Filename Invalid", "DataOutput:WriteProjection");
        }

        private void WriteTextFile(string text, string ext)
        {
            if (!text.IsEmpty())
            {
                string file = String.Format("{0}\\{1}_Map.{2}", SelectedPath,
                    Values.Settings.ProjectOptions.ProjectName, ext);

                if (File.Exists(file))
                    File.Delete(file);

                using (StreamWriter sw = new StreamWriter(file, false))
                {
                    sw.WriteLine(text);
                }
            }
        }
        
        #endregion

    }

    public static class doubleex
    {
        public static string dNoNull(this double? d)
        {
            return d == null ? String.Empty : d.ToString();
        }
    }
}
