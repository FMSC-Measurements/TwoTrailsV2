using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

//Version 1.2

namespace KmlUtilities
{
    /*** https://developers.google.com/kml/documentation/kmlreference ***/

    public class KmlDocument
    {
        #region Members
        
        private List<KmlStyle> _Styles;
        private List<KmlStyleMap> _StyleMaps;
        private List<KmlFolder> _SubFolders;
        private List<KmlPlacemark> _Placemarks;
        private string _CN;
        #endregion

        #region Properties

        public string Name { get; set; }
        public string Desctription { get; set; }
        public string StyleUrl { get; set; }
        public KmlProperties Properties { get; set; }
        public bool? Open { get; set; }
        public bool? Visibility { get; set; }

        public string CN
        {
            get { return _CN; }
        }
        public List<KmlStyle> Styles
        {
            get { return _Styles; }
        }
        public List<KmlStyleMap> StyleMaps
        {
            get { return _StyleMaps; }
        }
        public List<KmlFolder> SubFolders
        {
            get { return _SubFolders; }
        }
        public List<KmlPlacemark> PlaceMarks
        {
            get { return _Placemarks; }
        }
        #endregion


        public KmlDocument()
        {
            Init(null, null);
        }

        public KmlDocument(string name)
        {
            Init(name, null);
        }

        public KmlDocument(string name, string desc)
        {
            Init(name, desc);
        }

        private void Init(string name, string desc)
        {
            Name = name;
            Desctription = desc;
            _CN = Guid.NewGuid().ToString();

            _Styles = new List<KmlStyle>();
            _StyleMaps = new List<KmlStyleMap>();
            _SubFolders = new List<KmlFolder>();
            _Placemarks = new List<KmlPlacemark>();

            Properties = null;
            StyleUrl = null;
            Properties = null;
            Open = null;
            Visibility = null;
        }

        
        #region Methods

        public void AddFolder(KmlFolder f)
        {
            if(f != null && f.CN != "")
                _SubFolders.Add(f);
        }

        public void RemoveFolder(string cn)
        {
            for (int i = 0; i < _SubFolders.Count; i++)
            {
                if (_SubFolders[i].CN == cn)
                {
                    _SubFolders.RemoveAt(i);
                    return;
                }
            }
        }

        public KmlFolder GetFolder(string cn)
        {
            foreach(KmlFolder folder in _SubFolders)
            {
                if (folder.CN == cn)
                    return folder;
            }

            return null;
        }

        public KmlFolder GetFolderByName(string name)
        {
            foreach (KmlFolder folder in _SubFolders)
            {
                if (folder.Name == name)
                    return folder;
            }

            return null;
        }


        public void AddPlacemark(KmlPlacemark p)
        {
            if (p != null && p.CN != "")
                _Placemarks.Add(p);
        }

        public void RemovePlacemark(string cn)
        {
            for (int i = 0; i < _Placemarks.Count; i++)
            {
                if (_Placemarks[i].CN == cn)
                {
                    _Placemarks.RemoveAt(i);
                    return;
                }
            }
        }

        public KmlPlacemark GetPlacemark(string cn)
        {
            foreach (KmlPlacemark pm in _Placemarks)
            {
                if (pm.CN == cn)
                    return pm;
            }

            return null;
        }

        public KmlPlacemark GetPlacemarkByName(string name)
        {
            foreach (KmlPlacemark pm in _Placemarks)
            {
                if (pm.Name == name)
                    return pm;
            }

            return null;
        }


        public void AddStyle(KmlStyle s)
        {
            if (s != null)
                _Styles.Add(s);
        }

        public void RemoveStyleById(string id)
        {
            for (int i = 0; i < _Styles.Count; i++)
            {
                if (_Styles[i].ID == id)
                {
                    _Styles.RemoveAt(i);
                    return;
                }
            }
        }

        public KmlStyle GetStyleById(string id)
        {
            foreach (KmlStyle s in _Styles)
            {
                if (s.ID == id)
                    return s;
            }

            return null;
        }


        public void AddStyleMap(KmlStyleMap s)
        {
            if (s != null)
                _StyleMaps.Add(s);
        }

        public void RemoveStyleMapById(string id)
        {
            for (int i = 0; i < _StyleMaps.Count; i++)
            {
                if (_StyleMaps[i].ID == id)
                {
                    _StyleMaps.RemoveAt(i);
                    return;
                }
            }
        }

        public KmlStyleMap GetStyleMapById(string id)
        {
            foreach (KmlStyleMap s in _StyleMaps)
            {
                if (s.ID == id)
                    return s;
            }

            return null;
        }
        #endregion

    }

    public class KmlFolder
    {
        #region Members

        private List<KmlFolder> _SubFolders;
        private List<KmlPlacemark> _Placemarks;
        private string _CN;
        #endregion

        #region Properties

        public string Name { get; set; }
        public string Desctription { get; set; }
        public string StyleUrl { get; set; }
        public KmlProperties Properties { get; set; }
        public bool? Open { get; set; }
        public bool? Visibility { get; set; }

        public string CN
        {
            get { return _CN; }
        }
        public List<KmlFolder> SubFolders
        {
            get { return _SubFolders; }
        }
        public List<KmlPlacemark> PlaceMarks
        {
            get { return _Placemarks; }
        }
        #endregion


        public KmlFolder(string name)
        {
            init(name, null);
        }

        public KmlFolder(string name, string desc)
        {
            init(name, desc);
        }

        private void init(string name, string desc)
        {
            Name = name;
            _CN = Guid.NewGuid().ToString();

            _SubFolders = new List<KmlFolder>();
            _Placemarks = new List<KmlPlacemark>();

            Desctription = desc;
            Properties = null;
            StyleUrl = null;
            Properties = null;
            Open = null;
            Visibility = null;
        }
        
        
        #region Methods

        public void AddFolder(KmlFolder f)
        {
            if(f != null && f.CN != "")
                _SubFolders.Add(f);
        }

        public void RemoveFolder(string cn)
        {
            for (int i = 0; i < _SubFolders.Count; i++)
            {
                if (_SubFolders[i].CN == cn)
                {
                    _SubFolders.RemoveAt(i);
                    return;
                }
            }
        }

        public KmlFolder GetFolder(string cn)
        {
            foreach(KmlFolder folder in _SubFolders)
            {
                if (folder.CN == cn)
                    return folder;
            }

            return null;
        }

        public KmlFolder GetFolderByName(string name)
        {
            foreach (KmlFolder folder in _SubFolders)
            {
                if (folder.Name == name)
                    return folder;
            }

            return null;
        }


        public void AddPlacemark(KmlPlacemark p)
        {
            if (p != null && p.CN != "")
                _Placemarks.Add(p);
        }

        public void RemovePlacemark(string cn)
        {
            for (int i = 0; i < _Placemarks.Count; i++)
            {
                if (_Placemarks[i].CN == cn)
                {
                    _Placemarks.RemoveAt(i);
                    return;
                }
            }
        }

        public KmlPlacemark GetPlacemark(string cn)
        {
            foreach (KmlPlacemark pm in _Placemarks)
            {
                if (pm.CN == cn)
                    return pm;
            }

            return null;
        }

        public KmlPlacemark GetPlacemarkByName(string name)
        {
            foreach (KmlPlacemark pm in _Placemarks)
            {
                if (pm.Name == name)
                    return pm;
            }

            return null;
        }
        #endregion
    }

    public class KmlPlacemark
    {
        #region Members

        private List<KmlPolygon> _Polygons;
        private List<KmlPoint> _Points;
        private string _CN;
        #endregion

        #region Properties

        public string Name { get; set; }
        public string Desctription { get; set; }
        public string StyleUrl { get; set; }
        public KmlView View { get; set; }
        public KmlProperties Properties { get; set; }
        public bool? Visibility { get; set; }
        public bool? Open { get; set; }


        public string CN
        {
            get { return _CN; }
        }
        public List<KmlPolygon> Polygons
        {
            get { return _Polygons; }
        }
        public List<KmlPoint> Points
        {
            get { return _Points; }
        }
        #endregion

        public KmlPlacemark(string name)
        {
            Init(name, null, null);
        }

        public KmlPlacemark(string name, string desc)
        {
            Init(name, desc, null);
        }

        public KmlPlacemark(string name, string desc, KmlView v)
        {
            Init(name, desc, v);
        }

        private void Init(string name, string desc, KmlView v)
        {
            Name = name;
            View = v;

            if (desc != null)
                Desctription = desc;
            else
                Desctription = "";

            _CN = Guid.NewGuid().ToString();

            StyleUrl = null;
            Properties = null;
            Visibility = null;
            Open = null;

            _Polygons = new List<KmlPolygon>();
            _Points = new List<KmlPoint>();
        }

        public KmlPlacemark(KmlPlacemark pm)
        {
            Init(pm.Name, pm.Desctription, new KmlView(pm.View));

            _CN = pm._CN;
            StyleUrl = pm.StyleUrl; ;
            Properties = new KmlProperties(pm.Properties);
            Visibility = pm.Visibility;
            Open = pm.Open;

            _Polygons = pm.Polygons.ToList();
            _Points = pm.Points.ToList();
        }


        #region Methods

        public void AddPoint(KmlPoint p)
        {
            if (p != null && p.CN != "")
                _Points.Add(p);
        }

        public void AddPolygon(KmlPolygon p)
        {
            if (p != null && p.CN != "")
                _Polygons.Add(p);
        }

        public void RemovePoint(string cn)
        {
            for (int i = 0; i < _Points.Count; i++)
            {
                if (_Points[i].CN == cn)
                {
                    _Points.RemoveAt(i);
                    return;
                }
            }
        }

        public void RemovePolygon(string cn)
        {
            for (int i = 0; i < _Polygons.Count; i++)
            {
                if (_Polygons[i].CN == cn)
                {
                    _Polygons.RemoveAt(i);
                    return;
                }
            }
        }

        public KmlPoint GetPoint(string cn)
        {
            foreach (KmlPoint point in _Points)
            {
                if (point.CN == cn)
                    return point;
            }

            return null;
        }

        public KmlPoint GetPointByName(string name)
        {
            foreach (KmlPoint point in _Points)
            {
                if (point.Name == name)
                    return point;
            }

            return null;
        }

        public KmlPolygon GetPolygon(string cn)
        {
            foreach (KmlPolygon poly in _Polygons)
            {
                if (poly.CN == cn)
                    return poly;
            }

            return null;
        }

        public KmlPolygon GetPolygonByName(string name)
        {
            foreach (KmlPolygon poly in _Polygons)
            {
                if (poly.Name == name)
                    return poly;
            }

            return null;
        }

        #endregion
    }

    public class KmlPolygon
    {
        public class Dimensions
        {
            public double East;
            public double West;
            public double North;
            public double South;

            public Dimensions(double e, double w, double n, double s)
            {
                East = e;
                West = w;
                North = n;
                South = s;
            }
        }

        private int _tessellate, _extrude;
        private AltitudeMode? _AltMode;
        private string _CN;

        public string Name { get; set; }
        public List<Coordinates> OuterBoundary { get; set; }
        public List<Coordinates> InnerBoundary { get; set; }
        public bool IsPath { get; set; }

        public AltitudeMode? AltMode {
            get { return _AltMode; }
            set 
            {
                _AltMode = value;

                if (_AltMode != null && (_AltMode == AltitudeMode.clampToSeaFloor || _AltMode == AltitudeMode.clampToGround))
                {
                    _tessellate = 1;
                    _extrude = 0;
                }
                else
                {
                    _tessellate = 0;
                    _extrude = 1;
                    
                }
            }
        }

        public int Tessellate { get { return _tessellate; } set { _tessellate = value; } }
        public int Extrude { get { return _extrude; } set { _extrude = value; } }
        public Coordinates AveragedCoords
        {
            get
            {
                Coordinates c = new Coordinates();
                double lat = 0, lon = 0;
                int count = 0;

                foreach (Coordinates coord in OuterBoundary)
                {
                    lat += (double)coord.Lat;
                    lon += (double)coord.Lon;
                    count++;
                }

                if (count > 0)
                {
                    lat /= count;
                    lon /= count;
                }

                c.Lon = lon;
                c.Lat = lat;
                c.Alt = 1000;

                return c;
            }
        }

        public KmlPolygon(string name)
        {
            init(name, null);
        }
        
        public KmlPolygon(string name, List<Coordinates> ob)
        {
            init(name, ob);
        }

        private void init(string name, List<Coordinates> ob)
        {
            Name = name;
            OuterBoundary = ob;
            _CN = Guid.NewGuid().ToString();
            IsPath = false;
            _extrude = 0;
            _tessellate = 0;
        }

        public string CN
        {
            get { return _CN; }
        }

        public Dimensions GetOuterDimensions()
        {
            if (OuterBoundary.Count < 1)
                return null;

            Dimensions d = new Dimensions((double)OuterBoundary[0].Lon, (double)OuterBoundary[0].Lon, (double)OuterBoundary[0].Lat, (double)OuterBoundary[0].Lat);

            foreach (Coordinates c in OuterBoundary)
            {
                if (c.Lat < d.South)
                    d.South = (double)c.Lat;

                if (c.Lat > d.North)
                    d.North = (double)c.Lat;

                if (c.Lon < d.West)
                    d.West = (double)c.Lon;

                if (c.Lon > d.East)
                    d.East = (double)c.Lon;
            }

            return d;
        }

        public Dimensions GetInnerDimensions()
        {
            if (InnerBoundary.Count < 1)
                return null;

            Dimensions d = new Dimensions((double)InnerBoundary[0].Lon, (double)InnerBoundary[0].Lon, (double)InnerBoundary[0].Lat, (double)InnerBoundary[0].Lat);

            foreach (Coordinates c in InnerBoundary)
            {
                if (c.Lat < d.South)
                    d.South = (double)c.Lat;

                if (c.Lat > d.North)
                    d.North = (double)c.Lat;

                if (c.Lon < d.West)
                    d.West = (double)c.Lon;

                if (c.Lon > d.East)
                    d.East = (double)c.Lon;
            }

            return d;
        }
    }

    public class KmlPoint
    {
        private string _CN;
        public AltitudeMode? _AltMode;
        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }
        public int? Extrude { get; set; }

        public AltitudeMode? AltMode
        {
            get { return _AltMode; }
            set
            {
                _AltMode = value;

                if (_AltMode != null && (_AltMode == AltitudeMode.clampToSeaFloor || _AltMode == AltitudeMode.clampToGround))
                {
                    Extrude = 0;
                }
                else
                {
                    Extrude = 1;

                }
            }
        }

        public KmlPoint()
        {
            init(new Coordinates(), AltitudeMode.clampToGround);
        }

        public KmlPoint(Coordinates c)
        {
            init(c, AltitudeMode.clampToGround);
        }

        public KmlPoint(Coordinates c, AltitudeMode altMode)
        {
            init(c, altMode);
        }
        
        private void init(Coordinates c, AltitudeMode altMode)
        {
            Coordinates = c;
            AltMode = altMode;
            _CN = Guid.NewGuid().ToString();
        }

        public string CN
        {
            get { return _CN; }
        }
    }

    public class KmlStyle
    {
        private string _id;

        public KmlStyle()
        {
            Init(null);
        }

        public KmlStyle(string id)
        {
            Init(id);
        }

        public KmlStyle(KmlStyle s, string id)
        {
            initK(s, id);
        }

        public KmlStyle(KmlStyle s)
        {
            initK(s, null);
        }

        private void initK(KmlStyle s, string id)
        {
            if (id != null)
                _id = id;
            else
                _id = Guid.NewGuid().ToString();

            PolygonID = s.PolygonID;
            PolygonColorMode = s.PolygonColorMode;
            PolygonColor = s.PolygonColor;
            PolygonFill = s.PolygonFill;
            PolygonOutline = s.PolygonOutline;

            IconID = s.IconID;
            IconUrl = s.IconUrl;
            IconColor = s.IconColor;
            IconScale = s.IconScale;
            IconHeading = s.IconHeading;
            IconHotSpot = s.IconHotSpot;

            LabelID = s.LabelID;
            LabelColor = s.LabelColor;
            LabelScale = s.LabelScale;
            LabelColorMode = s.LabelColorMode;

            LineID = s.LineID;
            LineColor = s.LineColor;
            LineWidth = s.LineWidth;
            LineColorMode = s.LineColorMode;
            LineOuterColor = s.LineOuterColor;
            LineOuterWidth = s.LineOuterWidth;
            LinePhysicalWidth = s.LinePhysicalWidth;
            LineLabelVisibility = s.LineLabelVisibility;

            BalloonID = s.BalloonID;
            BalloonBgColor = s.BalloonBgColor;
            BalloonTextColor = s.BalloonTextColor;
            BalloonText = s.BalloonText;
            BalloonDisplayMode = s.BalloonDisplayMode;

            ListID = s.ListID;
            ListListItemType = s.ListListItemType;
            ListBgColor = s.ListBgColor;
            ListItemState = s.ListItemState;
            ListItemIconUrl = s.ListItemIconUrl;
        }

        private void Init(string id)
        {
            if (id != null)
                _id = id;
            else
                _id = Guid.NewGuid().ToString();

            PolygonID = null;
            PolygonColorMode = null;
            PolygonColor = null;
            PolygonFill = null;
            PolygonOutline = null;

            IconID = null;
            IconUrl = null;
            IconColor = null;
            IconScale = null;
            IconHeading = null;
            IconHotSpot = null;

            LabelID = null;
            LabelColor = null;
            LabelScale = null;
            LabelColorMode = null;

            LineID = null;
            LineColor = null;
            LineWidth = null;
            LineColorMode = null;
            LineOuterColor = null;
            LineOuterWidth = null;
            LinePhysicalWidth = null;
            LineLabelVisibility = null;

            BalloonID = null;
            BalloonBgColor = null;
            BalloonTextColor = null;
            BalloonText = null;
            BalloonDisplayMode = null;

            ListID = null;
            ListListItemType = null;
            ListBgColor = null;
            ListItemState = null;
            ListItemIconUrl = null;
        }

        public void SetColorsILP(KmlColor c)
        {
            IconColor = c;
            LineColor = c;
            PolygonColor = new KmlColor(c);
            PolygonColor.A = 50;

            IconColorMode = ColorMode.Normal;
            LineColorMode = ColorMode.Normal;
            PolygonColorMode = ColorMode.Normal;
        }

        #region Properties
        public string ID { get { return _id; } set { _id = value; } }
        public string  StyleUrl { get { return '#' + _id; } }

        public string   IconID { get; set; }
        public string   IconUrl { get; set; }
        public KmlColor  IconColor { get; set; }
        public double?  IconScale { get; set; }
        public ColorMode? IconColorMode { get; set; }
        public double?  IconHeading { get; set; }
        public HotSpot? IconHotSpot { get; set; }

        public string   LabelID { get; set; }
        public KmlColor LabelColor { get; set; }
        public double?   LabelScale { get; set; }
        public ColorMode? LabelColorMode { get; set; }

        public string   LineID { get; set; }
        public KmlColor LineColor { get; set; }
        public double?  LineWidth { get; set; }
        public ColorMode? LineColorMode { get; set; }
        public KmlColor LineOuterColor { get; set; }
        public double?  LineOuterWidth { get; set; }
        public double?  LinePhysicalWidth { get; set; }
        public bool?    LineLabelVisibility { get; set; }

        public string PolygonID { get; set; }
        public KmlColor PolygonColor { get; set; }
        public ColorMode? PolygonColorMode { get; set; }
        public bool?  PolygonFill { get; set; }
        public bool?  PolygonOutline { get; set; }

        public string BalloonID { get; set; }
        public KmlColor BalloonBgColor { get; set; }
        public KmlColor BalloonTextColor { get; set; }
        public string BalloonText { get; set; }
        public DisplayMode? BalloonDisplayMode { get; set; }

        public string ListID { get; set; }
        public ListItemType? ListListItemType { get; set; }
        public KmlColor ListBgColor { get; set; }
        public State? ListItemState { get; set; }
        public string ListItemIconUrl { get; set; }
        #endregion
    }

    public class KmlStyleMap
    {
        private string _id;

        public KmlStyleMap()
        {
            init(null, null, null);
        }

        public KmlStyleMap(string id)
        {
            init(id, null, null);
        }

        public KmlStyleMap(string id, string norm, string high)
        {
            init(id, norm, high);
        }

        private void init(string id, string norm, string high)
        {
            if (id != null)
                _id = id;
            else
                _id = Guid.NewGuid().ToString();

            NormalStyleUrl = norm;
            HightLightedStyleUrl = high;
        }

        public string ID { get { return _id; } }
        public string StyleUrl { get { return '#' + _id; } }

        public string NormalStyleUrl { get; set; }
        public string HightLightedStyleUrl { get; set; }
    }

    public class KmlView
    {
        public class KmlTimeSpan
        {
            public DateTime StartTime;
            public DateTime EndTime;

            public KmlTimeSpan(DateTime s, DateTime e)
            {
                StartTime = s;
                EndTime = e;
            }
        }

        public KmlView()
        {
            TimeSpan = null;
            TimeStamp = null;
            Coordinates = null;
            Heading = null;
            Tilt = null;
            Range = 1000;
        }

        public KmlView(Coordinates c, double h, double t, double r)
        {
            TimeSpan = null;
            TimeStamp = null;
            Coordinates = c;
            Heading = h;
            Tilt = t;
            Range = r;
        }

        public KmlView(KmlView v)
        {
            TimeSpan = v.TimeSpan;
            TimeStamp = v.TimeStamp;
            Coordinates = v.Coordinates;
            Heading = v.Heading;
            Tilt = v.Tilt;
            Range = v.Range;
        }

        public KmlTimeSpan TimeSpan { get; set; }
        public DateTime? TimeStamp { get; set; }
        public Coordinates? Coordinates { get; set; }
        public double? Heading { get; set; }
        public double? Tilt { get; set; }
        public double Range { get; set; }
        public AltitudeMode? AltMode { get; set; }
    }

    public class KmlProperties
    {
        public string Author { get; set; }
        public string Link { get; set; }
        public string Address { get; set; }
        public string Snippit { get; set; }
        public int? SnippitMaxLines { get; set; }
        public string Region { get; set; }
        public KmlExtendedData ExtendedData { get; set; }

        public KmlProperties()
        {
            Author = null;
            Link = null;
            Address = null;
            Snippit = null;
            SnippitMaxLines = null;
            Region = null;
            ExtendedData = null;
        }

        public KmlProperties(KmlProperties p)
        {
            Author = p.Author;
            Link = p.Link;
            Address = p.Address;
            Snippit = p.Snippit;
            SnippitMaxLines = p.SnippitMaxLines;
            Region = p.Region;
            ExtendedData = p.ExtendedData;
        }
    }

    public class KmlExtendedData
    {
        public class Data
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }

            public Data()
            {
                init(null, null, null);
            }

            public Data(string name, string value)
            {
                init(name, value, null);
            }

            public Data(string name, string value, string id)
            {
                init(name, value, id);
            }

            private void init(string name, string value, string id)
            {
                Name = name;
                Value = value;
                ID = id;
            }
        }

        private List<Data> _DataItems;
        public List<Data> DataItems { get { return _DataItems; } }

        public KmlExtendedData()
        {
            _DataItems = new List<Data>();
        }

        public void AddData(Data data)
        {
            if (data != null && data.Name != null && data.Value != null)
                _DataItems.Add(data);
        }

        public void RemoveDataById(string id)
        {
            for (int i = 0; i < _DataItems.Count; i++)
            {
                if (_DataItems[i].ID == id)
                {
                    _DataItems.RemoveAt(i);
                    return;
                }
            }
        }

        public Data GetDataById(string id)
        {
            foreach (Data d in _DataItems)
            {
                if (d.ID == id)
                    return d;
            }

            return null;
        }
    }

    public class KmlColor
    {
        private int _r;
        private int _g;
        private int _b;
        private int _a;

        public int R
        {
            get { return _r; }
            set
            {
                if (value > 255)
                    _r = 255;
                else if (value < 0)
                    _r = 0;
                else
                    _r = value;
            }
        }

        public int G
        {
            get { return _g; }
            set
            {
                if (value > 255)
                    _g = 255;
                else if (value < 0)
                    _g = 0;
                else
                    _g = value;
            }
        }

        public int B
        {
            get { return _b; }
            set
            {
                if (value > 255)
                    _b = 255;
                else if (value < 0)
                    _b = 0;
                else
                    _b = value;
            }
        }

        public int A
        {
            get { return _a; }
            set
            {
                if (value > 255)
                    _a = 255;
                else if (value < 0)
                    _a = 0;
                else
                    _a = value;
            }
        }

        public KmlColor()
        {
            //black
            R = 0;
            G = 0;
            B = 0;
            A = 255;
        }

        public KmlColor(string color)
        {
            //black
            R = 0;
            G = 0;
            B = 0;
            A = 255;

            SetColorFromStringRGBA(color);
        }

        public KmlColor(KmlColor color)
        {
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public KmlColor(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public void SetColorFromStringRGBA(string color)
        {
            if (color == null || color.Length < 2)
                throw new Exception("String must be greater than 2 and even");

            if (color.Length % 2 != 0)
                throw new Exception("String must be even");

            int i=0;
            List<string> colors = new List<string>();


            for(;i < color.Length; i+=2)
            {
                colors.Add(color.Substring(i, 2)); 
            }

            int len = colors.Count;

            if (len > 0)
                R = Convert.ToInt32(colors[0], 16);
            if (len > 1)
                G = Convert.ToInt32(colors[1], 16);
            if (len > 2)
                B = Convert.ToInt32(colors[2], 16);
            if (len > 3)
                A = Convert.ToInt32(colors[3], 16);
        }

        public string ToStringRGBA()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(R.ToString("X2"));
            sb.Append(G.ToString("X2"));
            sb.Append(B.ToString("X2"));
            sb.Append(A.ToString("X2"));

            return sb.ToString();
        }

        //ABGR klm color is reversed
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(A.ToString("X2"));
            sb.Append(B.ToString("X2"));
            sb.Append(G.ToString("X2"));
            sb.Append(R.ToString("X2"));

            return sb.ToString();
        }
    }

    
    #region Types

    public struct Coordinates
    {
        public Coordinates(double? y, double? x)
        {
            Lat = y;
            Lon = x;
            Alt = null;
        }

        public Coordinates(double? y, double? x, double? z)
        {
            Lat = y;
            Lon = x;
            Alt = z;
        }

        public double? Lat;
        public double? Lon;
        public double? Alt;
    }

    public enum ColorMode
    {
        Normal,
        Random
    }

    public enum DisplayMode
    {
        Default,
        Hide
    }

    public enum ListItemType
    {
        Check,
        CheckOffOnly,
        CheckHideChildern,
        RadioFolder
    }

    public enum State
    {
        Open,
        closed,
        Error,
        Fetching0,
        Fetching1,
        Fetching2
    }

    public enum XYUnitType
    {
        Fraction,
        Pixels,
        InsetPixels
    }

    public struct HotSpot
    {
        public double X;
        public double Y;
        public XYUnitType xUnits;
        public XYUnitType yUnits;

        public HotSpot(double x, double y, XYUnitType xu, XYUnitType yu)
        {
            X = x;
            Y = y;
            xUnits = xu;
            yUnits = yu;
        }
    }

    public enum AltitudeMode
    {
        clampToGround,
        clampToSeaFloor,
        relativeToGround,
        realitiveToSeaFloor,
        absolute
    }
    #endregion


    public class KmlWriter : XmlTextWriter
    {
        #region Members

        private string _file;
        private KmlDocument _doc;
        #endregion

        #region Properties

        private bool _open;
        private string _FileName
        {
            get { return _file; }
            set
            {
                _file = value;
                if (_file != null && _file != "")
                    _open = true;
                else
                    _open = false;
            }
        }
        public KmlDocument Document
        {
            get { return _doc; }
            set
            {
                _doc = value;
            }
        }
        #endregion


        public KmlWriter(string filename, KmlDocument doc) : base(filename, null)
        {
            Init(filename, doc);
        }

        public KmlWriter(string filename) : base(filename, null)
        {
            Init(filename, null);
        }

        private void Init(string filename, KmlDocument doc)
        {
            Document = doc;
            _FileName = filename;
            Formatting = Formatting.Indented;
            Indentation = 4;
        }

        public void WriteStartKml()
        {
            WriteStartElement("kml");
            WriteAttributeString("xlmns", "http://www.opengis.net/kml/2.2");
            WriteAttributeString("xlmns:gx", "http://www.google.com/kml/ext/2.2");
            _open = true;
        }

        public void WriteEndKml()
        {
            WriteEndElement();
            _open = false;
        }

        public void WriteKmlDocument()
        {
            WriteKmlDocument(Document);
        }

        public void WriteKmlDocument(KmlDocument doc)
        {
            if (_open && doc != null)
            {
                //start document
                WriteStartElement("Document");

                //kml name
                WriteStartElement("name");
                if (doc.Name != null)
                    WriteValue(doc.Name);
                else
                    WriteValue("TwoTrails");
                WriteEndElement();

                //description
                WriteKmlDescription(doc.Desctription);

                if (doc.Visibility != null)
                    WriteElementString("visibility", ConvertBool((bool)doc.Visibility).ToString());
                if (doc.Open != null)
                    WriteElementString("open", ConvertBool((bool)doc.Open).ToString());


                if (doc.Properties != null)
                    WriteKmlProperties(doc.Properties);

                foreach (KmlStyle style in doc.Styles)
                {
                    WriteKmlStyle(style);
                }
                foreach (KmlStyleMap map in doc.StyleMaps)
                {
                    WriteKmlStyleMap(map);
                }
                foreach (KmlFolder subFolder in doc.SubFolders)
                {
                    WriteKmlFolder(subFolder);
                }
                foreach (KmlPlacemark pm in doc.PlaceMarks)
                {
                    WriteKmlPlacemark(pm);
                }

                //end document
                WriteEndElement();
            }
            else if (!_open)
            {
                throw new Exception("KmlStart not written.");
            }
            else
            {
                throw new Exception("Document is null.");
            }
        }

        public void WriteKmlFolder(KmlFolder folder)
        {
            if (folder != null)
            {
                WriteStartElement("Folder");
                WriteComment("Folder Guid: " + folder.CN);

                WriteElementString("name", folder.Name);
                WriteKmlDescription(folder.Desctription);

                if(folder.StyleUrl != null && folder.StyleUrl != "")
                    WriteElementString("styleUrl", folder.StyleUrl);

                if (folder.Visibility != null)
                    WriteElementString("visibility", ConvertBool((bool)folder.Visibility).ToString());
                if (folder.Open != null)
                    WriteElementString("open", ConvertBool((bool)folder.Open).ToString());

                if (folder.Properties != null)
                    WriteKmlProperties(folder.Properties);

                foreach (KmlFolder subFolder in folder.SubFolders)
                {
                    WriteKmlFolder(subFolder);
                }
                foreach (KmlPlacemark pm in folder.PlaceMarks)
                {
                    WriteKmlPlacemark(pm);
                }

                //end folder
                WriteEndElement();
            }
        }
        
        public void WriteKmlPlacemark(KmlPlacemark pm)
        {
            if (pm != null)
            {
                WriteStartElement("Placemark");
                WriteComment("Placemark Guid: " + pm.CN);

                WriteElementString("name", pm.Name);

                WriteKmlDescription(pm.Desctription);
                
                if (pm.View != null && pm.View.Coordinates != null)
                    WriteKmlView(pm.View);
                else
                {
                    KmlView v = new KmlView();

                    if (pm.Polygons != null && pm.Polygons.Count > 0)
                    {
                        v.Coordinates = pm.Polygons[0].AveragedCoords;
                        v.AltMode = pm.Polygons[0].AltMode;
                    }
                    else if (pm.Points != null && pm.Points.Count > 0)
                    {
                        v.Coordinates = pm.Points[0].Coordinates;
                        v.AltMode = pm.Points[0]._AltMode;
                    }

                    WriteKmlView(v);
                }

                if(pm.StyleUrl != null && pm.StyleUrl != "")
                    WriteElementString("styleUrl", pm.StyleUrl);

                if (pm.Visibility != null)
                    WriteElementString("visibility", ConvertBool((bool)pm.Visibility).ToString());
                if (pm.Open != null)
                    WriteElementString("open", ConvertBool((bool)pm.Open).ToString());

                if (pm.Properties != null)
                    WriteKmlProperties(pm.Properties);


                if ((pm.Points.Count + pm.Polygons.Count) > 1)
                {
                    WriteStartElement("MultiGeometry");

                    foreach (KmlPolygon poly in pm.Polygons)
                    {
                        WriteKmlPolygon(poly);
                    }
                    foreach (KmlPoint point in pm.Points)
                    {
                        WriteKmlPoint(point);
                    }

                    //end MultiGeo
                    WriteEndElement();
                }
                else
                {
                    if (pm.Polygons.Count > 0)
                    {
                        WriteKmlPolygon(pm.Polygons[0]);
                    }
                    else if (pm.Points.Count > 0)
                    {
                        WriteKmlPoint(pm.Points[0]);
                    }
                    else
                    {
                        //just point and polys for now
                    }
                }

                //end placemark
                WriteEndElement();
            }
        }

        public void WriteKmlPolygon(KmlPolygon poly)
        {
            try
            {
                if (poly != null)
                {
                    if (!poly.IsPath)
                        WriteStartElement("Polygon");
                    else
                        WriteStartElement("LineString");

                    if (poly.Name != null)
                        WriteAttributeString("id", poly.Name);
                    WriteComment("Poly Guid: " + poly.CN);

                    if (poly.Extrude == 1)
                        WriteElementString("extrude", poly.Extrude.ToString());
                    if (poly.Tessellate == 1)
                        WriteElementString("tessellate", poly.Tessellate.ToString());

                    if (poly.AltMode != null)
                    {
                        if (poly.AltMode == AltitudeMode.clampToGround || poly.AltMode == AltitudeMode.relativeToGround || poly.AltMode == AltitudeMode.absolute)
                            WriteElementString("altitudeMode", poly.AltMode.ToString());
                        else
                            WriteElementString("gx:altitudeMode", poly.AltMode.ToString());
                    }

                    if (!poly.IsPath)
                    {
                        WriteStartElement("outerBoundaryIs");
                        WriteStartElement("LinearRing");
                        WriteStartElement("coordinates");

                        foreach (Coordinates c in poly.OuterBoundary)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(c.Lon + "," + c.Lat);

                            if (c.Alt != null)
                                sb.Append("," + c.Alt + " ");
                            else
                                sb.Append(" ");
                            WriteValue(sb.ToString());
                        }

                        WriteEndElement();
                        WriteEndElement();
                        WriteEndElement();

                        if (poly.InnerBoundary != null && poly.InnerBoundary.Count > 0)
                        {
                            WriteStartElement("innerBoundaryIs");
                            WriteStartElement("LinearRing");
                            WriteStartElement("coordinates");

                            foreach (Coordinates c in poly.InnerBoundary)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append(c.Lon + "," + c.Lat);

                                if (c.Alt != null)
                                    sb.Append("," + c.Alt + " ");
                                else
                                    sb.Append(" ");
                                WriteValue(sb.ToString());
                            }

                            WriteEndElement();
                            WriteEndElement();
                            WriteEndElement();
                        }
                    }
                    else
                    {
                        WriteStartElement("coordinates");

                        foreach (Coordinates c in poly.OuterBoundary)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(c.Lon + "," + c.Lat);

                            if (c.Alt != null)
                                sb.Append("," + c.Alt + " ");
                            else
                                sb.Append(" ");
                            WriteValue(sb.ToString());
                        }

                        WriteEndElement();
                    }

                    //end poly
                    WriteEndElement();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("WriteKmlPoly Error: " + ex.Message);
            }
        }

        public void WriteKmlPoint(KmlPoint point)
        {
            try
            {
                if (point != null)
                {
                    WriteStartElement("Point");

                    if (point.Name != null)
                        WriteAttributeString("id", point.Name);
                    WriteComment("Point Guid: " + point.CN);

                    if (point.Extrude != null)
                        WriteElementString("extrude", point.Extrude.ToString());

                    if (point.AltMode != null)
                    {
                        if (point.AltMode == AltitudeMode.clampToGround || point.AltMode == AltitudeMode.relativeToGround || point.AltMode == AltitudeMode.absolute)
                            WriteElementString("altitudeMode", point.AltMode.ToString());
                        else
                            WriteElementString("gx:altitudeMode", point.AltMode.ToString());
                    }

                    WriteStartElement("coordinates");
                    StringBuilder sb = new StringBuilder();
                    sb.Append(point.Coordinates.Lon + "," + point.Coordinates.Lat);

                    if (point.Coordinates.Alt != null)
                        sb.Append("," + point.Coordinates.Alt + " ");
                    else
                        sb.Append(" ");
                    WriteValue(sb.ToString());
                    WriteEndElement();

                    //end poly
                    WriteEndElement();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("WriteKmlPoint Error: " + ex.Message);
            }
        }

        public void WriteKmlStyle(KmlStyle style)
        {
            try
            {
                //start style
                WriteStartElement("Style");
                WriteAttributeString("id", style.ID);

                #region Icon Style
                if (style.IconUrl != null || style.IconColor != null || style.IconColorMode != null || style.IconScale != null ||
                    style.IconHeading != null || style.IconHotSpot != null)
                {
                    WriteStartElement("IconStyle");
                    if (style.IconID != null)
                        WriteAttributeString("id", style.IconID);

                    if (style.IconColor != null)
                        WriteElementString("color", style.IconColor.ToString());
                    if (style.IconUrl != null && style.IconUrl != "")
                    {
                        WriteStartElement("Icon");
                        WriteElementString("href", style.IconUrl);
                        WriteEndElement();
                    }
                    if (style.IconScale != null)
                        WriteElementString("scale", style.IconScale.ToString());
                    if (style.IconColorMode != null)
                        WriteElementString("colorMode", ConvertColorMode(style.IconColorMode));
                    if (style.IconHeading != null)
                        WriteElementString("heading", style.IconHeading.ToString());
                    if (style.IconHotSpot != null)
                    {
                        WriteStartElement("hotSpot");
                        WriteAttributeString("x", style.IconHotSpot.Value.X.ToString());
                        WriteAttributeString("y", style.IconHotSpot.Value.Y.ToString());
                        WriteAttributeString("xunits", ConvertXYUnits(style.IconHotSpot.Value.xUnits));
                        WriteAttributeString("yunits", ConvertXYUnits(style.IconHotSpot.Value.yUnits));
                        WriteEndElement();
                    }

                    WriteEndElement();
                }
                #endregion

                #region Label Style

                if (style.LabelColor != null || style.LabelColorMode != null || style.LabelScale != null)
                {
                    WriteStartElement("LabelStyle");
                    if (style.LabelID != null)
                        WriteAttributeString("id", style.LabelID);

                    if (style.LabelColor != null)
                        WriteElementString("color", style.LabelColor.ToString());
                    if (style.LabelColorMode != null)
                        WriteElementString("colorMode", ConvertColorMode(style.LabelColorMode));
                    if (style.LabelScale != null)
                        WriteElementString("scale", style.LabelScale.ToString());

                    WriteEndElement();
                }
                #endregion

                #region Line Style

                if (style.LineColor != null || style.LineColorMode != null || style.LineLabelVisibility != null || style.LineOuterColor != null ||
                    style.LineOuterWidth != null || style.LinePhysicalWidth != null || style.LineWidth != null)
                {
                    WriteStartElement("LineStyle");
                    if (style.LineID != null)
                        WriteAttributeString("id", style.LineID);

                    if (style.LineColor != null)
                        WriteElementString("color", style.LineColor.ToString());
                    if (style.LineColorMode != null)
                        WriteElementString("colorMode", ConvertColorMode(style.LineColorMode));
                    if (style.LineWidth != null)
                        WriteElementString("width", style.LineWidth.ToString());

                    if (style.LineOuterColor != null)
                        WriteElementString("gx:outerColor", style.LineOuterColor.ToString());
                    if (style.LineOuterWidth != null)
                        WriteElementString("gx:outerWidth", style.LineOuterWidth.ToString());
                    if (style.LinePhysicalWidth != null)
                        WriteElementString("gx:physicalWidth", style.LinePhysicalWidth.ToString());
                    if (style.LineLabelVisibility != null)
                        WriteElementString("gx:labelVisibility", ConvertBool((bool)style.LineLabelVisibility).ToString());

                    WriteEndElement();
                }

                #endregion

                #region Poly Style

                if (style.PolygonColor != null || style.PolygonColorMode != null || style.PolygonFill != null || style.PolygonOutline != null)
                {
                    WriteStartElement("PolyStyle");
                    if (style.PolygonID != null)
                        WriteAttributeString("id", style.PolygonID);

                    if (style.PolygonColor != null)
                        WriteElementString("color", style.PolygonColor.ToString());
                    if (style.PolygonColorMode != null)
                        WriteElementString("colorMode", ConvertColorMode(style.PolygonColorMode));
                    if (style.PolygonFill != null)
                        WriteElementString("fill", ConvertBool((bool)style.PolygonFill).ToString());
                    if (style.PolygonOutline != null)
                        WriteElementString("outline", ConvertBool((bool)style.PolygonOutline).ToString());

                    WriteEndElement();
                }
                #endregion

                #region Balloon Style

                if (style.BalloonBgColor != null || style.BalloonTextColor != null || style.BalloonText != null || style.BalloonDisplayMode != null)
                {
                    WriteStartElement("BalloonStyle");
                    if (style.BalloonID != null)
                        WriteAttributeString("id", style.BalloonID);

                    if (style.BalloonBgColor != null)
                        WriteElementString("bgColor", style.BalloonBgColor.ToString());
                    if (style.BalloonTextColor != null)
                        WriteElementString("textColor", style.BalloonTextColor.ToString());
                    if (style.BalloonText != null && style.BalloonText != "")
                        WriteElementString("text", style.BalloonText);
                    if (style.BalloonDisplayMode != null)
                        WriteElementString("displayMode", ConvertDisplayMode(style.BalloonDisplayMode));

                    WriteEndElement();
                }
                #endregion

                #region List Style

                if (style.ListBgColor != null || style.ListItemIconUrl != null || style.ListItemState != null || style.ListListItemType != null)
                {
                    WriteStartElement("listItemType");
                    if (style.ListID != null)
                        WriteAttributeString("id", style.ListID);

                    if (style.ListListItemType != null)
                        WriteElementString("listItemType", ConvertListItemType(style.ListListItemType));
                    if (style.ListBgColor != null)
                        WriteElementString("bgColor", style.ListBgColor.ToString());

                    if (style.ListItemState != null || style.ListItemIconUrl != null)
                    {
                        WriteStartElement("ItemIcon");

                        if (style.ListItemState != null)
                            WriteElementString("state", ConvertState(style.ListItemState));
                        if (style.ListItemIconUrl != null && style.ListItemIconUrl != "")
                            WriteElementString("href", style.ListItemIconUrl);

                        WriteEndElement();
                    }
                    WriteEndElement();
                }
                #endregion

                //end style
                WriteEndElement();
            }
            catch (Exception ex)
            {
                throw new Exception("WriteKmlStyle Error: " + ex.Message);
            }
        }

        public void WriteKmlStyleMap(KmlStyleMap map)
        {
            try
            {
                if (map != null && map.HightLightedStyleUrl != null && map.NormalStyleUrl != null)
                {
                    WriteStartElement("StyleMap");
                    WriteAttributeString("id", map.ID);

                    WriteStartElement("Pair");
                    WriteElementString("key", "normal");
                    WriteElementString("styleUrl", map.NormalStyleUrl);
                    WriteEndElement();

                    WriteStartElement("Pair");
                    WriteElementString("key", "highlight");
                    WriteElementString("styleUrl", map.HightLightedStyleUrl);
                    WriteEndElement();

                    WriteEndElement();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("WriteKmlStyleMap Error: " + ex.Message);
            }
        }

        public void WriteKmlProperties(KmlProperties prop)
        {
            try
            {
                if (prop.Author != null && prop.Author != "")
                    WriteElementString("atom:author", prop.Author);
                if (prop.Link != null && prop.Link != "")
                    WriteElementString("atom:link", prop.Link);
                if (prop.Address != null && prop.Address != "")
                    WriteElementString("address", prop.Address);
                if (prop.Snippit != null && prop.Snippit != "")
                {
                    WriteStartElement("Snippit");

                    if (prop.SnippitMaxLines != null)
                        WriteAttributeString("maxLines", prop.SnippitMaxLines.ToString());
                    else
                        WriteAttributeString("maxLines", "2");

                    WriteValue(prop.Snippit);
                    WriteEndElement();
                }

                if (prop.Region != null && prop.Region != "")
                    WriteElementString("region", prop.Region);

                //write extended data
                if (prop.ExtendedData != null)
                {
                    if (prop.ExtendedData.DataItems.Count > 0)
                    {
                        WriteStartElement("ExtendedData");

                        foreach (KmlExtendedData.Data data in prop.ExtendedData.DataItems)
                        {
                            if (data.Name != null && data.Value != null)
                            {
                                WriteStartElement("Data");
                                WriteAttributeString("name", data.Name);
                                WriteElementString("value", data.Value);
                                WriteEndElement();
                            }
                        }

                        WriteEndElement();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("WriteKmlProperties Error: " + ex.Message);
            }
        }

        private void WriteKmlView(KmlView v)
        {
            WriteStartElement("LookAt");

            if (v.TimeSpan != null && v.TimeSpan.StartTime != null && v.TimeSpan.EndTime != null)
            {
                WriteStartElement("gx:TimeSpan");
                WriteElementString("begin", ConvertToKmlDateTime(v.TimeSpan.StartTime));
                WriteElementString("end", ConvertToKmlDateTime(v.TimeSpan.EndTime));
                WriteEndElement();
            }
            else if (v.TimeStamp != null)
            {
                WriteStartElement("gx:TimeStamp");
                WriteElementString("when", ConvertToKmlDateTime((DateTime)v.TimeStamp));
                WriteEndElement();
            }

            if (v.Coordinates != null)
            {
                if (v.Coordinates.Value.Lon != null)
                    WriteElementString("longitude", v.Coordinates.Value.Lon.ToString());
                if (v.Coordinates.Value.Lat != null)
                    WriteElementString("latitude", v.Coordinates.Value.Lat.ToString());
                if (v.Coordinates.Value.Alt != null)
                    WriteElementString("altitude", v.Coordinates.Value.Alt.ToString());
            }

            WriteElementString("range", v.Range.ToString());

            if (v.Tilt != null)
                WriteElementString("tilt", v.Tilt.ToString());
            if (v.Heading != null)
                WriteElementString("heading", v.Heading.ToString());
            if (v.AltMode != null)
            {
                if (v.AltMode == AltitudeMode.absolute || v.AltMode == AltitudeMode.clampToGround || v.AltMode == AltitudeMode.relativeToGround)
                    WriteElementString("altitudeMode", v.AltMode.ToString());
                else
                    WriteElementString("gx:altitudeMode", v.AltMode.ToString());
            }

            WriteEndElement();
        }

        private void WriteKmlDescription(string desc)
        {
            if (desc != null && desc != "")
            {
                WriteStartElement("description");
                WriteCData(desc);
                WriteEndElement();
            }
        }


        #region Conversions
        private int ConvertBool(bool b)
        {
            return (b ? 1 : 0);
        }

        private string ConvertColorMode(ColorMode? c)
        {
            switch(c)
            {
                case ColorMode.Random:
                    return "random";
                case ColorMode.Normal:
                default:
                    return "normal";
            }
        }

        private string ConvertXYUnits(XYUnitType? xyu)
        {
            switch (xyu)
            {
                case XYUnitType.InsetPixels:
                    return "insetPixels";
                case XYUnitType.Pixels:
                    return "pixels";
                case XYUnitType.Fraction:
                default:
                    return "fraction";
            }
        }

        private string ConvertDisplayMode(DisplayMode? dm)
        {
            switch (dm)
            {
                case DisplayMode.Hide:
                    return "hide";
                case DisplayMode.Default:
                default:
                    return "default";
            }
        }

        private string ConvertListItemType(ListItemType? lit)
        {
            switch (lit)
            {
                case ListItemType.CheckHideChildern:
                    return "checkHideChildern";
                case ListItemType.CheckOffOnly:
                    return "checkOffOnly";
                case ListItemType.RadioFolder:
                    return "radioFolder";
                case ListItemType.Check:
                default:
                    return "check";
            }
        }

        private string ConvertState(State? s)
        {
            switch (s)
            {
                case State.closed:
                    return "closed";
                case State.Error:
                    return "error";
                case State.Fetching0:
                    return "fetching0";
                case State.Fetching1:
                    return "fetching1";
                case State.Fetching2:
                    return "fetching2";
                case State.Open:
                default:
                    return "open";
            }
        }

        private string ConvertToKmlDateTime(DateTime dt)
        {
            return String.Format("{0}-{1}-{2}T{3}:{4}:{5}Z", dt.Year.ToString("D4"), dt.Month.ToString("D2"), dt.Day.ToString("D2"), dt.Hour.ToString("D2"), dt.Minute.ToString("D2"), dt.Second.ToString("D2"));
        }
        #endregion
    }
}
