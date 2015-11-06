using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.DataAccess;
using TwoTrails.Engine;
using TwoTrails.Utilities;
using TwoTrails.Forms;
using TwoTrails.BusinessLogic;
using System.Xml;

#if !(PocketPC || WindowsCE || Mobile)
using GeoAPI;
using GeoAPI.Geometries;
using NetTopologySuite.Utilities;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.Features;
using NetTopologySuite.Operation.Polygonize;
using MetaKitWrapper;
#endif

namespace TwoTrails.Utilities
{
    public class DataImport
    {
        public enum FileType
        {
            GoogleEarth,
            GPX,
            Shape,
            Text,
            TwoTrails,
            TwoTrails2,
            NotImplementedType
        }

        DataAccessLayer dal, importDal;

        string _FileName;
        FileType _FileType;

        Dictionary<string, TtPolygon> _Polygons;
        Dictionary<string, string> _IdToCN;
        Dictionary<string, int> _PolyIndexes;
        TtPolygon _Poly;
        List<TtPoint> _Points;
        TtMetaData _Meta;

        public int ProjectZone { get { return _Meta.Zone; } }

        public DataImport(DataAccessLayer d)
        {
            dal = d;

            //get default meta
            if(dal != null)
                _Meta = dal.GetMetaData()[0];
        }

        public FileType SetFileType(string filename)
        {
            _FileName = filename;

            if (File.Exists(_FileName))
            {
                switch(System.IO.Path.GetExtension(_FileName).Trim('.'))
                {
                    case "kml":
                        _FileType = FileType.GoogleEarth;
                        break;
                    case "gpx":
                        _FileType = FileType.GPX;
                        break;
                    case "shp":
                        _FileType = FileType.Shape;
                        break;
                    case "txt":
                    case "csv":
                        _FileType = FileType.Text;
                        break;
                    case "tt":
                        _FileType = FileType.TwoTrails;
                        break;
                    case "tt2":
                        _FileType = FileType.TwoTrails2;
                        break;
                    default:
                        _FileType = FileType.NotImplementedType;
                        break;
                }
            }
            else
                throw new FileNotFoundException();

            return _FileType;
        }

        public void Dispose()
        {
#if !(PocketPC || WindowsCE || Mobile)
            if (metaKit != null)
                metaKit.CloseDB();
#endif
        }




        public bool ImportText(bool latLng, bool multiPoly, bool usePID,
            bool useIndex, bool useElev, bool elevFeet, bool useComment, bool useBound)
        {
            try
            {
                string line, tmp;

                int pidIndex = -1, xIndex = -1, yIndex = -1, zIndex = -1,
                    cmtIndex = -1, polyIndex = -1, bndIndex = -1, iIndex = -1;

                int mX = 0, mY = 0, mZ = 0; 

                _Polygons = new Dictionary<string, TtPolygon>();
                _PolyIndexes = new Dictionary<string, int>();
                _IdToCN = new Dictionary<string, string>();
                _Points = new List<TtPoint>();

                int requiredFields = 2 + (multiPoly ? 1 : 0) + (usePID ? 1 : 0) + 
                    (useIndex ? 1 : 0) + (useElev ? 1 : 0);

                if (!multiPoly)
                {
                    int polyCount = (int)dal.GetPolyCount();
                    polyCount++;
                    _Poly = new TtPolygon(1000 * polyCount + 10);
                    _Poly.Name = String.Format("Poly {0}", polyCount);
                    _Polygons.Add(_Poly.CN, _Poly);
                }

                using (StreamReader sr = new StreamReader(_FileName))
                {
                    if (sr.EndOfStream)
                    {
                        MessageBox.Show("Empty File");
                        return false;
                    }

                    line = sr.ReadLine();

                    #region Get Fields

                    List<string> strOrder = line.Split(',').ToList();

                    if (strOrder.Count < 2)
                    {
                        MessageBox.Show("Invalid File Info");
                        return false;
                    }
                    else
                    {


                        for (int i = 0; i < strOrder.Count; i++)
                        {
                            #region Parse Fields
                            switch (strOrder[i].ToLower())
                            {
#if !(PocketPC || WindowsCE || Mobile)
                                    //pc only
                                case "x":
                                case "adjx":
                                case "xadj":
                                    if (!latLng)
                                    {
                                        xIndex = i;
                                        mX++;
                                    }
                                    break;
                                case "lon":
                                case "lng":
                                case "long":
                                case "longitude":
                                    if (latLng)
                                    {
                                        xIndex = i;
                                        mX++;
                                    }
                                    break;
                                case "y":
                                case "adjy":
                                case "yadj":
                                    if (!latLng)
                                    {
                                        yIndex = i;
                                        mY++;
                                    }
                                    break;
                                case "lat":
                                case "latitude":
                                    if (latLng)
                                    {
                                        yIndex = i;
                                        mY++;
                                    }
                                    break;
                                case "z":
                                case "adjz":
                                case "zadj":
                                case "elev":
                                case "elevation":
                                case "altitide":
                                    zIndex = i;
                                    mZ++;
                                    break;
                                    //pc only
#endif
                                case "pid":
                                case "id":
                                case "point id":
                                    pidIndex = i;
                                    break;
                                case "cmt":
                                case "comment":
                                case "note":
                                case "notes":
                                    cmtIndex = i;
                                    break;
                                case "poly":
                                case "polygon":
                                case "poly name":
                                case "polygon name":
                                case "poly index":
                                case "polygon index":
                                    polyIndex = i;
                                    break;
                                case "bnd":
                                case "bound":
                                case "onbnd":
                                case "onbound":
                                case "boundary":
                                case "onboundary":
                                    bndIndex = i;
                                    break;
                                case "idx":
                                case "indx":
                                case "index":
                                    iIndex = i;
                                    break;
                                default:
                                    //unknown field
                                    break;
                            }
                            #endregion
                        }
#if !(PocketPC || WindowsCE || Mobile)

                        using (TextImportFieldSelectionForm form =
                            new TextImportFieldSelectionForm(
                        pidIndex, xIndex, yIndex, zIndex, cmtIndex, polyIndex,
                        bndIndex, iIndex, strOrder.ToArray()))
                        {
                            if (form.ShowDialog() == DialogResult.OK)
                            {

                                pidIndex = form.iPID;
                                xIndex = form.iX;
                                yIndex = form.iY;
                                zIndex = form.iZ;
                                cmtIndex = form.iComment;
                                polyIndex = form.iPoly;
                                bndIndex = form.iBound;
                                iIndex = form.iIndex;
                                elevFeet = form.bFeet;
                                latLng = form.bLatLon;
                            }
                            else
                            {
                                return false;
                            }
                        }

#else
                        #region Unknown / Dup Fields
                        if (xIndex < 0 || mX > 1)
                        {
                            using (Selection form = new Selection("Select X value field", strOrder, 0))
                            {
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    form.Width = form.Width + 100;
                                    if (form.selection > -1)
                                        xIndex = form.selection;
                                }
                                else
                                    return false;
                            }
                        }

                        if (yIndex < 0 || mY > 1)
                        {
                            using (Selection form = new Selection("Select Y value field", strOrder, 0))
                            {
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    if (form.selection > -1)
                                        yIndex = form.selection;
                                }
                                else
                                    return false;
                            }
                        }

                        if (useElev && (zIndex < 0 || mZ > 1))
                        {
                            using (Selection form = new Selection("Select Elevation field", strOrder, 0))
                            {
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    if (form.selection > -1)
                                        zIndex = form.selection;
                                }
                                else
                                    return false;
                            }
                        }

                        if (usePID && pidIndex < 0)
                        {
                            using (Selection form = new Selection("Select Point ID field", strOrder, 0))
                            {
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    if (form.selection > -1)
                                        pidIndex = form.selection;
                                }
                                else
                                    return false;
                            }
                        }

                        if (multiPoly && polyIndex < 0)
                        {
                            using (Selection form = new Selection("Select Poly ID field", strOrder, 0))
                            {
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    if (form.selection > -1)
                                        polyIndex = form.selection;
                                }
                                else
                                    return false;
                            }
                        }

                        if (useIndex && iIndex < 0)
                        {
                            using (Selection form = new Selection("Select Point Index field", strOrder, 0))
                            {
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    if (form.selection > -1)
                                        iIndex = form.selection;
                                }
                                else
                                    return false;
                            }
                        }
                        #endregion
#endif
                    }

                    #endregion

                    int index = 0;

                    #region Parse Data
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        List<string> details = line.Split(',').ToList();

                        if (details.Count < requiredFields)
                            continue;

                        GpsPoint p = new GpsPoint();

                        if (multiPoly || polyIndex > -1)
                        {
                            tmp = details[polyIndex];

                            if (tmp.Length > 0)
                            {
                                if(_IdToCN.ContainsKey(tmp))
                                {
                                    _Poly = _Polygons[_IdToCN[tmp]];
                                }
                                else
                                {
                                    _Poly = new TtPolygon(1000 * (_Polygons.Count + 1) + 10);
                                    _Poly.Name = details[polyIndex];

                                    _Polygons.Add(_Poly.CN, _Poly);
                                    _IdToCN.Add(_Poly.Name, _Poly.CN);
                                    _PolyIndexes.Add(_Poly.CN, 0);
                                }
                            }
                            else
                                continue;
                        }

                        p.PolyCN = _Poly.CN;
                        p.PolyName = _Poly.Name;
                        p.MetaDefCN = _Meta.CN;

                        if (!usePID || polyIndex < 0)
                        {
                            if (_Points.Count > 0)
                            {
                                p.PID = PointNaming.NamePoint(_Points.Last(), _Poly);
                            }
                            else
                            {
                                p.PID = PointNaming.NameFirstPoint(_Poly);
                            }
                        }
                        else
                        {
                            tmp = details[pidIndex];
                            if (tmp.Length > 0 && tmp.IsInteger())
                            {
                                p.PID = Convert.ToInt32(tmp);
                            }
                            else
                            {
                                PointNaming.NamePoint(_Points.Last(), _Poly);
                            }
                        }

                        try
                        {
                            tmp = details[xIndex];
                            if (tmp.Length > 0 && tmp.IsDouble())
                            {
                                p.X = Convert.ToDouble(tmp);
                            }
                            else
                                p.X = 0;

                            p.UnAdjX = p.X;

                            tmp = details[yIndex];
                            if (tmp.Length > 0)
                                p.Y = Convert.ToDouble(tmp);
                            else
                                p.Y = 0;

                            p.UnAdjY = p.Y;

                            if (useElev)
                            {
                                tmp = details[zIndex];
                                if (tmp.Length > 0 && tmp.IsDouble())
                                {
                                    if (elevFeet)
                                        p.Z = TtUtils.ConvertToMeters(tmp.ToDouble(), Unit.FEET_TENTH);
                                    else
                                        p.Z = tmp.ToDouble();
                                }
                                else
                                {
                                    p.Z = 0;
                                }

                                p.UnAdjZ = p.Z;
                            }

                            if (latLng)
                            {
                                double x, y;

                                TtUtils.LatLontoUTM(p.Y, p.X, _Meta.Zone, out y, out x);

                                p.X = x;
                                p.Y = y;

                                p.UnAdjX = p.X;
                                p.UnAdjY = p.Y;
                            }

                        }
                        catch
                        {
                            continue;
                        }

                        if (cmtIndex > -1)
                        {
                            p.Comment = details[cmtIndex];
                        }

                        if (useIndex && iIndex > -1)
                        {
                            tmp = details[iIndex];
                            if (tmp.IsInteger())
                            {
                                p.Index = tmp.ToInteger();
                                index = (int)(p.Index + 1);
                            }
                            else continue;
                        }
                        else
                        {
                            if (multiPoly || polyIndex > -1)
                            {
                                p.Index = _PolyIndexes[p.PolyCN];
                                _PolyIndexes[p.PolyCN]++;
                            }
                            else
                            {
                                p.Index = index;
                                index++;
                            }
                        }

                        if (bndIndex > -1)
                        {
                            tmp = details[bndIndex];
                            if (tmp.IsBool())
                            {
                                p.OnBnd = tmp.ToBool();
                            }
                        }
                        else
                        {
                            p.OnBnd = true;
                        }

                        p.GroupCN = Values.MainGroup.CN;
                        p.GroupName = Values.MainGroup.Name;

                        _Points.Add(p);
                    }
                    #endregion

                    foreach (TtPolygon p in _Polygons.Values)
                    {
                        dal.InsertPolygon(p);
                    }

                    dal.InsertPoints(_Points);

                    PolygonAdjuster.Adjust(dal);

                    return true;
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "ImportFormnLogic:ParseTxt");
                MessageBox.Show(@"An Error has occured while importing data. 
Make sure other applications are not using the file which is being imported.
Check the error log for complete details.", "Import Error");
            }

            return false;
        }


        public bool ImportGpx(bool useElev, bool elevFeet)
        {
            _Points = new List<TtPoint>();
            List<TtPolygon> polys = new List<TtPolygon>();

            using(XmlTextReader r = new XmlTextReader(new StreamReader(_FileName)))
            {
                bool inObject, inPoly, inPoint, inElev, fpoint;
                inObject = inPoly = inPoint = inElev = fpoint = false;

                double lat, lon, elev, utmX, utmY;
                lat = lon = elev = utmX = utmY = 0;

                GpsPoint point = new GpsPoint();
                TtPolygon poly = new TtPolygon();

                int polyCount = (int)dal.GetPolyCount() + 1, index = 0;

                string tmp;

                try
                {
                    try
                    {
                        r.Namespaces = false;

                        while (r.Read())
                        {
                            switch (r.NodeType)
                            {
                                case XmlNodeType.Element:
                                    {
                                        if (r.Name == "rte" || r.Name == "trk")
                                            inObject = true;
                                        else if (!inPoly && (r.Name == "rtept" || r.Name == "trkseg"))
                                        {
                                            inPoly = true;
                                            poly = new TtPolygon();
                                            poly.Name = String.Format("Poly {0}", polyCount);
                                            poly.PointStartIndex = polyCount * 1000 + 10;
                                            polyCount++;
                                            poly.IncrementBy = 10;
                                            fpoint = true;
                                            index = 0;
                                        }
                                        else if (inPoly && (r.Name == "rtept" || r.Name == "trkpt"))
                                        {
                                            inPoint = true;
                                            point = new GpsPoint();

                                            tmp = r.GetAttribute("lat");
                                            if (tmp.IsDouble())
                                                lat = tmp.ToDouble();

                                            tmp = r.GetAttribute("lon");
                                            if (tmp.IsDouble())
                                                lon = tmp.ToDouble();
                                        }
                                        else if (r.Name == "ele")
                                            inElev = true;
                                    }
                                    break;
                                case XmlNodeType.EndElement:
                                    {
                                        if (r.Name == "rte" || r.Name == "trk")
                                            inObject = false;
                                        else if (!inPoint && (r.Name == "rtept" || r.Name == "trkseg"))
                                        {
                                            inPoly = false;
                                            polys.Add(poly);
                                        }
                                        else if (inPoint && (r.Name == "rtept" && inPoint || r.Name == "trkpt"))
                                        {
                                            inPoint = false;

                                            if (lat != 0 && lon != 0)
                                            {
                                                if (fpoint)
                                                    point.PID = PointNaming.NameFirstPoint(poly);
                                                else
                                                    point.PID = PointNaming.NamePoint(_Points[_Points.Count - 1], poly);

                                                point.PolyCN = poly.CN;
                                                point.PolyName = poly.Name;

                                                point.MetaDefCN = _Meta.CN;

                                                point.Index = index;
                                                index++;

                                                point.OnBnd = true;

                                                point.GroupCN = Values.MainGroup.CN;
                                                point.GroupName = Values.MainGroup.Name;

                                                TtUtils.LatLontoUTM(lat, lon, _Meta.Zone, out utmY, out utmX);

                                                point.X = utmX;
                                                point.Y = utmY;

                                                if (useElev)
                                                {
                                                    if (elevFeet)
                                                        point.Z = TtUtils.ConvertToMeters(elev, Unit.FEET_TENTH);
                                                    else
                                                        point.Z = elev;
                                                }

                                                _Points.Add(point);

                                                fpoint = false;
                                            }
                                        }
                                        else if (r.Name == "ele")
                                            inElev = false;
                                    }
                                    break;
                                case XmlNodeType.Text:
                                    {
                                        if (inElev)
                                        {
                                            if (r.Value.IsDouble())
                                                elev = r.Value.ToDouble();
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch (XmlException ex)
                    {
                        if (!ex.Message.ToLower().Contains("undeclared"))
                        {
                            return false;
                        }
                    }

                    foreach (TtPolygon p in polys)
                        dal.InsertPolygon(p);
                    dal.InsertPoints(_Points);
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "DataImport:ImportGpx");
                    return false;
                }
            }

            return true;
        }



        #region TwoTrails1 Files
#if !(PocketPC || WindowsCE || Mobile)

        MetaKit metaKit = null;
        bool _MetaOpen = false;
        Dictionary<string, int> metaKitViews;
        Dictionary<int, string> pidToCN;

        public readonly static string projdata = "ProjectData";
        public readonly static string metadata = "MetaData";
        public readonly static string polydata = "PolyAttr";
        public readonly static string ptdata = "OpPt";
        public readonly static string nmeadata = "TTNMEA";

        public bool SetupTtImport()
        {
            if (System.IO.Path.GetExtension(_FileName).ToLower() != ".tt")
                return false;

            try
            {
                if (metaKit != null)
                    metaKit.CloseDB();

                metaKit = new MetaKit();

                if (metaKit.OpenDB(_FileName))
                {
                    return SetupMetaKitViews();
                }
            }
            catch(Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataImpot", ex.StackTrace);
                MessageBox.Show("Failed to Load TwoTrails 1.0 File. Check Log for details.");
            }

            _MetaOpen = false;

            return false;
        }

        private bool SetupMetaKitViews()
        {
            if (metaKit == null)
                return false;

            metaKitViews = new Dictionary<string, int>();

            try
            {
                metaKitViews.Add(projdata, metaKit.OpenView(projdata));
                metaKitViews.Add(metadata, metaKit.OpenView(metadata));
                metaKitViews.Add(polydata, metaKit.OpenView(polydata));
                metaKitViews.Add(ptdata, metaKit.OpenView(ptdata));
                metaKitViews.Add(nmeadata, metaKit.OpenView(nmeadata));
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataImport", ex.StackTrace);
                MessageBox.Show("Failed to Load TwoTrails 1.0 Data. Check Log for details.");
                return false;
            }

            _MetaOpen = true;
            return true;
        }

        public List<string> GetTtPolygons()
        {
            List<string> polys = new List<string>();

            if (metaKitViews[polydata] > -1)
            {
                int id = metaKitViews[polydata];
                int rc = metaKit.GetRowCount(id);
                for (int i = 0; i < rc; i++)
                {
                    polys.Add(metaKit.GetString(id, i, 0));
                }
            }

            return polys;
        }

        public bool ImportTt(List<string> polys, bool useNmea)
        {
            if (!_MetaOpen)
                return false;

            _Points = new List<TtPoint>();
            _Polygons = new Dictionary<string, TtPolygon>();
            _IdToCN = new Dictionary<string, string>();
            pidToCN = new Dictionary<int, string>();
            _PolyIndexes = new Dictionary<string, int>();

            Dictionary<string, TtMetaData> metaData = new Dictionary<string, TtMetaData>();
            Dictionary<string, string> metaLinkToId = new Dictionary<string, string>();
            Dictionary<string, int> qndLinks = new Dictionary<string, int>();
            List<int> pointWNMEA = new List<int>();

            Dictionary<int, List<TwoTrails.GpsAccess.NmeaBurst>> nmeas = new Dictionary<int, List<TwoTrails.GpsAccess.NmeaBurst>>();

            int viewId = metaKitViews[polydata];
            int rowCount;
            int polyCount = (int)dal.GetPolyCount();
            polyCount++;

            string tmpStr, tmpStr2;
            int tmpInt;
            double tmpDouble;

            try
            {
                #region Polygons
                rowCount = metaKit.GetRowCount(viewId);
                for (int i = 0; i < rowCount; i++)
                {
                    _Poly = new TtPolygon();

                    tmpStr = metaKit.GetString(viewId, i, 0);

                    if (!tmpStr.IsEmpty())
                    {
                        tmpStr2 = null;
                        _Poly.Name = tmpStr;
                    }
                    else
                    {
                        tmpStr2 = tmpStr;
                        _Poly.Name = String.Format("Poly {0}", polyCount);
                    }

                    _Poly.PointStartIndex = 1000 * polyCount + 10;

                    if (!polys.Contains(tmpStr))
                        continue;
                    polyCount++;

                    tmpStr = metaKit.GetString(viewId, i, 1);
                    if (!tmpStr.IsEmpty())
                        _Poly.Description = tmpStr;

                    tmpStr = metaKit.GetString(viewId, i, 10);
                    if (!tmpStr.IsEmpty())
                    {
                        if(_Poly.Description.IsEmpty())
                            _Poly.Description = tmpStr;
                        else
                            String.Format("{0}, Comment: {1}", _Poly.Description, tmpStr);
                    }

                    tmpDouble = metaKit.GetDouble(viewId, i, 11);
                    if(tmpDouble > 0)
                        _Poly.PolyAccu = tmpDouble;

                    _Polygons.Add(_Poly.CN, _Poly);
                    _IdToCN.Add(_Poly.Name, _Poly.CN);
                    _PolyIndexes.Add(_Poly.CN, 0);

                    if (tmpStr2 != null)
                    {
                        _IdToCN.Add(tmpStr2, _Poly.CN);
                    }
                }
                #endregion

                #region Metadata
                viewId = metaKitViews[metadata];

                TtMetaData newMeta;

                for (int i = 0; i < metaKit.GetRowCount(viewId); i++)
                {
                    newMeta = new TtMetaData();
                    newMeta.CN = Guid.NewGuid().ToString();

                    tmpInt = metaKit.GetInt(viewId, i, 2);
                    if (tmpInt > -1)
                        newMeta.Zone = tmpInt;

                    newMeta.Receiver = metaKit.GetString(viewId, i, 3);
                    newMeta.Laser = metaKit.GetString(viewId, i, 4);
                    newMeta.Compass = metaKit.GetString(viewId, i, 5);
                    newMeta.Crew = metaKit.GetString(viewId, i, 9);
                    newMeta.Comment = metaKit.GetString(viewId, i, 17);

                    tmpStr = metaKit.GetString(viewId, i, 10);
                    if(tmpStr.IsEmpty())
                    {
                        newMeta.Name = String.Format("Metadata {0}", metaData.Count + 1);
                        metaLinkToId.Add(newMeta.Name, newMeta.CN);
                        if (!metaLinkToId.ContainsKey(tmpStr))
                            metaLinkToId.Add(tmpStr, newMeta.CN);
                    }
                    else
                    {
                        newMeta.Name = tmpStr;
                        metaLinkToId.Add(tmpStr, newMeta.CN);
                    }

                    tmpStr = metaKit.GetString(viewId, i, 11);
                    tmpStr = tmpStr.ToLower();
                    if (tmpStr.Contains("meter"))
                        newMeta.uomDistance = UomDistance.Meters;
                    else if (tmpStr.Contains("chain"))
                        newMeta.uomDistance = UomDistance.Chains;
                    else if (tmpStr.Contains("tenth"))
                        newMeta.uomDistance = UomDistance.FeetTenths;
                    else if (tmpStr.Contains("inch"))
                        newMeta.uomDistance = UomDistance.FeetInches;
                    else if (tmpStr.Contains("yard"))
                        newMeta.uomDistance = UomDistance.Yards;

                    tmpStr = metaKit.GetString(viewId, i, 15);
                    tmpStr = tmpStr.ToLower();
                    if (tmpStr.Contains("feet"))
                        newMeta.uomElevation = UomElevation.Feet;
                    else if (tmpStr.Contains("meter"))
                        newMeta.uomElevation = UomElevation.Meters;

                    tmpStr = metaKit.GetString(viewId, i, 16);
                    tmpStr = tmpStr.ToLower();
                    if (tmpStr.Contains("deg"))
                        newMeta.uomSlope = UomSlope.Degrees;
                    else if (tmpStr.Contains("per"))
                        newMeta.uomSlope = UomSlope.Percent;

                    metaData.Add(newMeta.CN, newMeta);
                }
                #endregion
                
                #region Points
                TtPoint point;

                GpsPoint gps;
                SideShotPoint ssp;

                viewId = metaKitViews[ptdata];
                rowCount = metaKit.GetRowCount(viewId);
                for (int i = 0; i < rowCount; i++)
                {
                    tmpStr = metaKit.GetString(viewId, i, 0);

                    if (tmpStr.IsEmpty() || !polys.Contains(tmpStr))
                        continue;

                    point = new TtPoint();

                    _Poly = _Polygons[_IdToCN[tmpStr]];
                    point.PolyCN = _Poly.CN;
                    point.PolyName = _Poly.Name;

                    point.GroupCN = Values.MainGroup.CN;
                    point.GroupName = Values.MainGroup.Name;

                    tmpInt = metaKit.GetInt(viewId, i, 1);
                    if (tmpInt > 0)
                        point.PID = tmpInt;
                    else
                    {
                        if (_Points.Count > 1)
                            PointNaming.NamePoint(_Points[_Points.Count - 1], _Poly);
                        else
                            PointNaming.NameFirstPoint(_Poly);
                    }

                    pidToCN.Add(point.PID, point.CN);

                    tmpStr = metaKit.GetString(viewId, i, 2);
                    if (tmpStr.IsEmpty() || !tmpStr.IsBool())
                        point.OnBnd = false;
                    else
                        point.OnBnd = tmpStr.ToBool();

                    OpType op;

                    tmpStr = metaKit.GetString(viewId, i, 3);
                    if (tmpStr.IsEmpty())
                        continue;
                    else
                    {
                        try
                        {
                            op = (OpType)Enum.Parse(typeof(OpType), tmpStr, true);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    switch (op)
                    {
                        case OpType.GPS:
                        case OpType.Walk:
                        case OpType.WayPoint:
                            {
                                gps = new GpsPoint(point);

                                gps.X = metaKit.GetDouble(viewId, i, 4);
                                gps.Y = metaKit.GetDouble(viewId, i, 5);
                                gps.Z = metaKit.GetDouble(viewId, i, 6);
                                gps.UnAdjX = gps.X;
                                gps.UnAdjY = gps.Y;
                                gps.UnAdjZ = gps.Z;

                                tmpDouble = metaKit.GetDouble(viewId, i, 32);
                                if (tmpDouble != 0)
                                    gps.ManualAccuracy = tmpDouble;

                                tmpDouble = metaKit.GetDouble(viewId, i, 33);
                                if (tmpDouble != 0)
                                    gps.RMSEr = tmpDouble;


                                if(metaKit.GetInt(viewId, i, 55) > 0)
                                    pointWNMEA.Add(point.PID);

                                if (op == OpType.Walk)
                                    point = new WalkPoint(gps);
                                else if (op == OpType.WayPoint)
                                    point = new WayPoint(gps);
                                else
                                    point = gps;
                            }
                            break;
                        case OpType.SideShot:
                        case OpType.Traverse:
                            {
                                ssp = new SideShotPoint(point);

                                tmpDouble = metaKit.GetDouble(viewId, i, 22);
                                if (tmpDouble != -1)
                                    ssp.ForwardAz = tmpDouble;

                                tmpDouble = metaKit.GetDouble(viewId, i, 23);
                                if (tmpDouble != -1)
                                    ssp.BackwardAz = tmpDouble;

                                ssp.SlopeDistance = metaKit.GetDouble(viewId, i, 24);
                                ssp.SlopeAngle = metaKit.GetDouble(viewId, i, 25);

                                if (op == OpType.Traverse)
                                    point = new TravPoint(ssp);
                                else
                                    point = ssp;
                            }
                            break;
                        case OpType.Quondam:
                            {
                                point = new QuondamPoint(point);
                                    
                                tmpStr = metaKit.GetString(viewId, i, 29);
                                try
                                {
                                    if (!tmpStr.IsEmpty())
                                    {
                                        tmpStr2 = tmpStr.Split(',')[1].Trim();
                                        qndLinks.Add(point.CN, tmpStr2.ToInteger());
                                    }
                                }
                                catch
                                {
                                    //bad quondam
                                }
                            }
                            break;
                        default:
                            continue;
                    }

                    tmpStr = metaKit.GetString(viewId, i, 56);
                    if (tmpStr.IsEmpty() || !metadata.Contains(tmpStr))
                        point.MetaDefCN = _Meta.CN;
                    else
                    {
                        point.MetaDefCN = metaData[tmpStr].CN;
                    }

                    tmpStr = metaKit.GetString(viewId, i, 38);
                    if (!tmpStr.IsEmpty())
                        point.Comment = tmpStr;

                    point.Index = _PolyIndexes[point.PolyCN];
                    _PolyIndexes[point.PolyCN]++;

                    point.Time = DateTime.Now;

                    _Points.Add(point);
                }

                for (int i = 0; i < _Points.Count; i++)
                {
                    if (_Points[i].op == OpType.Quondam)
                    {
                        if(qndLinks.ContainsKey(_Points[i].CN))
                        {
                            QuondamPoint qp = ((QuondamPoint)_Points[i]);
                            qp.ParentPoint = _Points.Where(p => p.PID == qndLinks[qp.CN]).First();
                            _Points[i] = qp;
                        }
                    }
                }

                #endregion

                #region NMEA
                if (useNmea)
                {
                    TwoTrails.GpsAccess.NmeaBurst burst;

                    viewId = metaKitViews[nmeadata];
                    tmpInt = metaKit.GetRowCount(viewId);
                    for (int i = 0; i < tmpInt; i++)
                    {
                        tmpStr = metaKit.GetString(viewId, i, 1);
                        if (tmpStr.IsInteger())
                        {
                            int pid = tmpStr.ToInteger();
                            if (pointWNMEA.Contains(pid))
                            {
                                if (!nmeas.ContainsKey(pid))
                                    nmeas.Add(pid, new List<TwoTrails.GpsAccess.NmeaBurst>());

                                burst = new TwoTrails.GpsAccess.NmeaBurst();
                                burst._CN = Guid.NewGuid().ToString();

                                burst._Used = metaKit.GetInt(viewId, i, 2) > 0;

                                tmpStr = metaKit.GetString(viewId, i, 3);
                                if (!tmpStr.IsEmpty())
                                    burst._date = DateTime.ParseExact(tmpStr, "MMddyy", null);

                                tmpStr2 = metaKit.GetString(viewId, i, 4);
                                if (!tmpStr2.IsEmpty())
                                    burst._date = DateTime.ParseExact(tmpStr + tmpStr2, "MMddyyHHmmss", null);

                                burst._GGA_longitude = metaKit.GetDouble(viewId, i, 5);
                                burst._RMC_longitude = burst._GGA_longitude;

                                burst._GGA_latitude = metaKit.GetDouble(viewId, i, 6);
                                burst._RMC_latitude = burst._GGA_latitude;

                                burst._alt_unit = Unit.METERS;
                                burst._altitude = metaKit.GetFloat(viewId, i, 11);

                                burst._horiz_dilution_position = metaKit.GetDouble(viewId, i, 12);
                                burst._fix_quality = metaKit.GetInt(viewId, i, 13);

                                burst._fix = metaKit.GetInt(viewId, i, 15);

                                burst._PDOP = metaKit.GetFloat(viewId, i, 16);
                                burst._HDOP = metaKit.GetFloat(viewId, i, 17);
                                burst._VDOP = metaKit.GetFloat(viewId, i, 18);

                                burst._magVar = metaKit.GetFloat(viewId, i, 19);
                                burst._num_of_sat = metaKit.GetInt(viewId, i, 20);
                                burst._fixed_PRNs = metaKit.GetString(viewId, i, 21);

                                burst._GGA_latDir = TwoTrails.GpsAccess.NorthSouth.North;
                                burst._GGA_longDir = TwoTrails.GpsAccess.EastWest.West;
                                burst._magVarDir = TwoTrails.GpsAccess.EastWest.East;
                                burst._RMC_latDir = TwoTrails.GpsAccess.NorthSouth.North;
                                burst._RMC_longDir = TwoTrails.GpsAccess.EastWest.West;

                                for (int j = 22; j < 70; j += 4)
                                {
                                    GpsAccess.Satellite s = new TwoTrails.GpsAccess.Satellite();

                                    s.ID = metaKit.GetString(viewId, i, j);
                                    s.Elevation = metaKit.GetInt(viewId, i, j + 1);
                                    s.Azimuth = metaKit.GetInt(viewId, i, j + 2);
                                    s.SNR = metaKit.GetInt(viewId, i, j + 3);

                                    burst.AddSatalite(s);
                                }

                                burst.Complete();

                                nmeas[pid].Add(burst);
                            }
                        }
                    }
                }

                #endregion

                dal.InsertPoints(_Points);

                foreach (TtMetaData m in metaData.Values)
                    dal.InsertMetaData(m);
                foreach (TtPolygon poly in _Polygons.Values)
                    dal.InsertPolygon(poly);

                foreach (KeyValuePair<int, List<GpsAccess.NmeaBurst>> bl in nmeas)
                    dal.SaveNmeaBursts(bl.Value, pidToCN[bl.Key]);
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataImport:ImportTt");
                return false;
            }

            return true;
        }


#endif
        #endregion


        #region TwoTrails2 Files

        public bool SetupTt2Import()
        {
            if (System.IO.Path.GetExtension(_FileName).ToLower() != ".tt2")
                return false;

            importDal = new DataAccessLayer(_FileName);

            return true;
        }

        public List<DataPair> GetTt2Polygons()
        {
            if (importDal == null)
                throw new NullReferenceException();

            List<DataPair> polys = new List<DataPair>();

            foreach (TtPolygon p in importDal.GetPolygons())
                polys.Add(new DataPair(p.Name, p.CN));

            return polys;
        }

        public bool ImportTt2(List<string> cns, bool useGroups, bool useNmea)
        {
            try
            {
                Dictionary<string, TtMetaData> metas = new Dictionary<string, TtMetaData>();
                List<TtMetaData> tmpMeta = importDal.GetMetaData();

                foreach (TtMetaData meta in tmpMeta)
                {
                    meta.Name = String.Format("{0} {1}", meta.Name, "(Imported)");
                }

                Dictionary<string, TtMetaData> importedMetas = tmpMeta.ToDictionary(m => m.CN, m => m);
                tmpMeta.Clear();

                /*
                 * Compare default meta from imported with default from current
                 * if they are the same set the current meta to the value of the imported meta
                 * 
                 * importedMetas[EmptyGuid] = currentmeta
                 * 
                 * set all imported points with importedmeta to current meta
                */

                List<string> currPolyCNs = dal.GetPolygons().Select(p => p.CN).ToList();
                _Polygons = new Dictionary<string, TtPolygon>();
                _Points = new List<TtPoint>();
                Dictionary<string, TtPoint> tmpPoints = new Dictionary<string, TtPoint>();
                Dictionary<string, TtGroup> groups = dal.GetGroups().ToDictionary(g => g.CN, g => g);

                List<TwoTrails.GpsAccess.NmeaBurst> nmea = new List<TwoTrails.GpsAccess.NmeaBurst>();

                Action<TtPoint> parsePoint = null;
                parsePoint = (TtPoint ip) =>
                {
                    if(tmpPoints.ContainsKey(ip.CN))
                        return;

                    if (useGroups)
                    {
                        try
                        {
                            if (groups.ContainsKey(ip.GroupCN))
                            {
                                ip.GroupCN = ip.GroupCN;
                                ip.GroupName = groups[ip.GroupCN].Name;
                            }
                            else
                            {
                                dal.InsertGroup(importDal.GetGroupByCN(ip.GroupCN));
                                ip.GroupCN = ip.GroupCN;
                                ip.GroupName = groups[ip.GroupCN].Name;
                            }
                        }
                        catch
                        {
                            ip.GroupCN = Values.MainGroup.CN;
                            ip.GroupName = Values.MainGroup.Name;
                        }
                    }
                    else
                    {
                        ip.GroupCN = Values.MainGroup.CN;
                        ip.GroupName = Values.MainGroup.Name;
                    }

                    if (!metas.ContainsKey(ip.MetaDefCN))
                    {
                        metas.Add(ip.MetaDefCN, importedMetas[ip.MetaDefCN]);
                        dal.InsertMetaData(importedMetas[ip.MetaDefCN]);
                    }

                    if (useNmea && ip.IsGpsType())
                    {
                        nmea.AddRange(importDal.GetNmeaBurstsByPointCN(ip.CN));
                    }
                    else if (ip.op == OpType.Quondam)
                    {
                        parsePoint(importDal.GetPoint(((QuondamPoint)ip).ParentCN));
                    }

                    tmpPoints.Add(ip.CN, ip);
                };

                foreach (string icn in cns)
                {
                    if (currPolyCNs.Contains(icn))
                        continue;

                    _Poly = importDal.GetPolygonByCn(icn);

                    foreach (TtPoint ip in importDal.GetPointsInPolygon(_Poly.CN))
                    {
                        parsePoint(ip);
                    }

                    _Polygons.Add(_Poly.CN, _Poly);
                }

                foreach (TtPolygon poly in _Polygons.Values)
                    dal.InsertPolygon(poly);

                dal.InsertPoints(tmpPoints.Values.ToList());
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataImport:ImportTt2", ex.StackTrace);
                return false;
            }

            return true;
        }

        #endregion


        #region Shape Files
#if !(PocketPC || WindowsCE || Mobile)

        public bool CheckShapeUsability(string filename)
        {
            if (filename == String.Empty) return false;

            string basename = System.IO.Path.GetFileNameWithoutExtension(filename);
            string path = System.IO.Path.GetDirectoryName(filename);

            if (File.Exists(System.IO.Path.Combine(path, String.Format("{0}.shx", basename))) &&
                File.Exists(System.IO.Path.Combine(path, String.Format("{0}.prj", basename))) &&
                File.Exists(System.IO.Path.Combine(path, String.Format("{0}.dbf", basename))))
            {
                int zone = ParseProjectFile(System.IO.Path.Combine(path, String.Format("{0}.prj", basename)));

                if (zone < 0)
                {
                    MessageBox.Show(String.Format("File: {0} is not formated in NAD83.", basename), "Incorrect file formatting.");
                    return false;
                }
                else if (zone != _Meta.Zone)
                {
                    MessageBox.Show(String.Format("Zone ({1}) from file {0} does not match Zone ({2}) in the project.",
                        basename, zone, _Meta.Zone), "Mismatching UTM Zones");
                    return false;
                }

                _FileType = FileType.Shape;
                return true;
            }
            else
            {
                MessageBox.Show(String.Format("File: {0}, does not contain all 4 files (shp, shx, prj, dbf)", basename),
                    "Missing paired files");
            }

            return false;
        }

        private int ParseProjectFile(string filename)
        {
            //DETECT LAT-LON


            string tmp = File.ReadAllText(filename).ToLower();

            if (tmp.Contains("nad"))
            {
                tmp = tmp.Substring(tmp.IndexOf("nad"), 21);
                if (tmp.Contains("zone"))
                {
                    tmp = tmp.Substring(tmp.IndexOf("zone") + 5, 2);

                    if(tmp.IsInteger())
                        return tmp.ToInteger();
                }
            }

            return -1;
        }

        public bool ImportShape(bool latlon, bool useShapeProps, bool useElev, bool elevFeet)
        {
            return ImportShapes(new List<string>() { _FileName }, latlon, useShapeProps, useElev, elevFeet);
        }

        public bool ImportShapes(List<string> files, bool latlon, bool useShapeProps, bool useElev, bool elevFeet)
        {
            GeometryFactory factory;
            ShapefileDataReader shapeFileDataReader;
            ArrayList features;
            Feature feature;
            AttributesTable attributesTable;
            string[] keys;
            Geometry geometry;
            DbaseFieldDescriptor fldDescriptor;
            int polyCount = (int)dal.GetPolyCount();

            GpsPoint gps;
            int index = 0;

            _Polygons = new Dictionary<string, TtPolygon>();
            _Points = new List<TtPoint>();

            List<TtPoint> tmpPoints = new List<TtPoint>();


            try
            {
                foreach (string file in files)
                {
                    //polyCount = 1;

                    factory = new GeometryFactory();
                    shapeFileDataReader = new ShapefileDataReader(file, factory);
                    DbaseFileHeader header = shapeFileDataReader.DbaseHeader;

                    features = new ArrayList();
                    while (shapeFileDataReader.Read())
                    {
                        feature = new Feature();
                        attributesTable = new AttributesTable();
                        keys = new string[header.NumFields];
                        geometry = (Geometry)shapeFileDataReader.Geometry;

                        for (int i = 0; i < header.NumFields; i++)
                        {
                            fldDescriptor = header.Fields[i];
                            keys[i] = fldDescriptor.Name;
                            attributesTable.AddAttribute(fldDescriptor.Name, shapeFileDataReader.GetValue(i));
                        }

                        feature.Geometry = geometry;
                        feature.Attributes = attributesTable;
                        features.Add(feature);
                    }

                    bool areAllPoints = true;
                    foreach (Feature feat in features)
                    {
                        if (feat.Geometry.GeometryType.ToLower() != "point")
                        {
                            areAllPoints = false;
                            break;
                        }
                    }

                    //if all features are points
                    if (areAllPoints)
                    {
                        tmpPoints.Clear();

                        _Poly = new TtPolygon(1000 * polyCount + 10);

                        if (files.Count < 2)
                            _Poly.Name = Path.GetFileNameWithoutExtension(file);
                        else
                            _Poly.Name = String.Format("{0} {1}", Path.GetFileNameWithoutExtension(file), polyCount);

                        index = 0;

                        foreach (Feature feat in features)
                        {
                            //if features is only a point there should only be 1 coord
                            foreach (Coordinate coord in feat.Geometry.Coordinates)
                            {
                                gps = new GpsPoint();
                                gps.OnBnd = true;

                                gps.Index = index;
                                index++;

                                gps.MetaDefCN = _Meta.CN;

                                if (tmpPoints.Count > 0)
                                    gps.PID = PointNaming.NamePoint(tmpPoints.Last(), _Poly);
                                else
                                    gps.PID = PointNaming.NameFirstPoint(_Poly);

                                if (latlon)
                                {
                                    double x,y;

                                    TtUtils.LatLontoUTM(coord.Y, coord.X, _Meta.Zone, out y, out x);

                                    gps.X = x;
                                    gps.Y = y;
                                }
                                else
                                {
                                    gps.X = coord.X;
                                    gps.Y = coord.Y;
                                }

                                if (useElev)
                                {
                                    if (coord.Z != double.NaN)
                                    {
                                        if (elevFeet)
                                            gps.Z = TtUtils.ConvertToMeters(coord.Z, Unit.FEET_TENTH);
                                        else
                                            gps.Z = coord.Z;
                                    }
                                    else
                                        gps.Z = 0;
                                }
                                else
                                    gps.Z = 0;

                                gps.PolyCN = _Poly.CN;
                                gps.PolyName = _Poly.Name;

                                gps.GroupCN = Values.MainGroup.CN;
                                gps.GroupName = Values.MainGroup.Name;
                                
                                tmpPoints.Add(gps);
                            }

                            _Points.AddRange(tmpPoints);
                        }
                            
                        _Polygons.Add(_Poly.CN, _Poly);
                        polyCount++;
                    }
                    else //else get points out of each features
                    {
                        foreach (Feature feat in features)
                        {
                            tmpPoints.Clear();

                            _Poly = new TtPolygon(1000 * polyCount + 10);


                            if (files.Count < 2)
                                _Poly.Name = Path.GetFileNameWithoutExtension(file);
                            else
                                _Poly.Name = String.Format("{0} {1}", Path.GetFileNameWithoutExtension(file), polyCount);

                            #region Shape Desc Properties
                            if (useShapeProps)
                            {
                                object[] objs = feat.Attributes.GetValues();
                                string[] names = feat.Attributes.GetNames();
                                string objv;

                                for (int i = 0; i < feat.Attributes.Count; i++)
                                {
                                    objv = (string)objs[i];

                                    if (objv.IsEmpty())
                                        continue;

                                    switch (names[i])
                                    {
                                        case "Description":
                                            if (_Poly.Description.IsEmpty())
                                                _Poly.Description = objv;
                                            else
                                                _Poly.Description = String.Format("{0} | {1}", _Poly.Description, objv);
                                            break;
                                        case "Name":
                                            _Poly.Name = objv;
                                            break;
                                        case "Poly":
                                            if (_Poly.Description.IsEmpty())
                                                _Poly.Description = objv;
                                            else
                                                _Poly.Description = String.Format("{0} | {1}", _Poly.Description, objv);
                                            break;
                                        case "Comment":
                                            if (_Poly.Description.IsEmpty())
                                                _Poly.Description = objv;
                                            else
                                                _Poly.Description = String.Format("{0} | {1}", _Poly.Description, objv);
                                            break;
                                    }
                                }
                            }
                            #endregion


                            index = 0;

                            foreach (Coordinate coord in feat.Geometry.Coordinates)
                            {
                                gps = new GpsPoint();
                                gps.OnBnd = true;

                                gps.Index = index;
                                index++;

                                gps.MetaDefCN = _Meta.CN;

                                if (tmpPoints.Count > 0)
                                    gps.PID = PointNaming.NamePoint(tmpPoints.Last(), _Poly);
                                else
                                    gps.PID = PointNaming.NameFirstPoint(_Poly);

                                if (latlon)
                                {
                                    double x, y;

                                    TtUtils.LatLontoUTM(coord.Y, coord.X, _Meta.Zone, out y, out x);

                                    gps.UnAdjX = x;
                                    gps.UnAdjY = y;
                                }
                                else
                                {
                                    gps.UnAdjX = coord.X;
                                    gps.UnAdjY = coord.Y;
                                }

                                if (useElev)
                                {
                                    if (coord.Z == double.NaN)
                                    {
                                        if (elevFeet)
                                            gps.UnAdjZ = TtUtils.ConvertToMeters(coord.Z, Unit.FEET_TENTH);
                                        else
                                            gps.Z = coord.Z;
                                    }
                                    else
                                        gps.UnAdjZ = 0;
                                }
                                else
                                    gps.UnAdjZ = 0;

                                gps.PolyCN = _Poly.CN;
                                gps.PolyName = _Poly.Name;

                                gps.GroupCN = Values.MainGroup.CN;
                                gps.GroupName = Values.MainGroup.Name;
                                
                                tmpPoints.Add(gps);
                            }

                            _Points.AddRange(tmpPoints);
                            _Polygons.Add(_Poly.CN, _Poly);
                            polyCount++;
                        }
                    }

                    //Close and free up any resources
                    shapeFileDataReader.Close();
                    shapeFileDataReader.Dispose();
                }

                foreach (TtPolygon poly in _Polygons.Values)
                    dal.InsertPolygon(poly);

                dal.InsertPoints(_Points);

                PolygonAdjuster.Adjust(dal);
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DataImport:ImportShapes", ex.StackTrace);

                return false;
            }

            return true;
        }

#endif
        #endregion
    }
}
