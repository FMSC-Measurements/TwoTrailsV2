using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace GpxUtilities
{
    public class GpxDocument
    {
        private List<GpxPoint> _Waypoints;
        private List<GpxRoute> _Routes;
        private List<GpxTrack> _Tracks;

        public string Creator { get; set; }     //Required Field
        public GpxMetadata MetaData { get; set; }
        public string Extensions { get; set; }

        public List<GpxPoint> Waypoints { get { return _Waypoints; } }
        public List<GpxRoute> Routes { get { return _Routes; } }
        public List<GpxTrack> Tracks { get { return _Tracks; } }

        public GpxDocument()
        {
            init(null);
        }

        public GpxDocument(string creator)
        {
            init(creator);
        }

        private void init(string creator)
        {
            _Waypoints = new List<GpxPoint>();
            _Routes = new List<GpxRoute>();
            _Tracks = new List<GpxTrack>();

            if (creator != null)
                Creator = creator;
            else
                Creator = "Auto Generated";
            MetaData = null;
            Extensions = null;
        }

        public void AddPoint(GpxPoint point)
        {
            if(point != null)
                _Waypoints.Add(point);
        }

        public GpxPoint GetPointById(string id)
        {
            foreach (GpxPoint point in _Waypoints)
            {
                if (point.ID == id)
                {
                    return point;
                }
            }

            return null;
        }

        public void DeletePointById(string id)
        {
            for (int i = 0; i < _Waypoints.Count; i++)
            {
                if (_Waypoints[i].ID == id)
                {
                    _Waypoints.RemoveAt(i);
                }
            }
        }

        public void DeletePointAtPos(int pos)
        {
            if (pos < _Waypoints.Count && pos > -1)
            {
                _Waypoints.RemoveAt(pos);
            }
        }

        public void AddRoute(GpxRoute route)
        {
            if (route != null)
                _Routes.Add(route);
        }

        public GpxRoute GetRouteByName(string name)
        {
            foreach (GpxRoute route in _Routes)
            {
                if (route.Name == name)
                {
                    return route;
                }
            }

            return null;
        }

        public void DeletePointByName(string name)
        {
            for (int i = 0; i < _Routes.Count; i++)
            {
                if (_Routes[i].Name == name)
                {
                    _Routes.RemoveAt(i);
                }
            }
        }

        public void DeleteRouteAtPos(int pos)
        {
            if (pos < _Routes.Count && pos > -1)
            {
                _Routes.RemoveAt(pos);
            }
        }

        public void AddTrack(GpxTrack Track)
        {
            if (Track != null)
                _Tracks.Add(Track);
        }

        public GpxTrack GetTrackByName(string name)
        {
            foreach (GpxTrack Track in _Tracks)
            {
                if (Track.Name == name)
                {
                    return Track;
                }
            }

            return null;
        }

        public void DeleteTrackByName(string name)
        {
            for (int i = 0; i < _Tracks.Count; i++)
            {
                if (_Tracks[i].Name == name)
                {
                    _Tracks.RemoveAt(i);
                }
            }
        }

        public void DeleteTrackAtPos(int pos)
        {
            if (pos < _Tracks.Count && pos > -1)
            {
                _Tracks.RemoveAt(pos);
            }
        }
    }

    public class GpxMetadata
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Copyright { get; set; }
        public string Link { get; set; }
        public DateTime? Time { get; set; }
        public List<string> Keywords { get; set; }
        public string Extensions { get; set; }

        public GpxMetadata()
        {
            init(null, null);
        }

        public GpxMetadata(string name)
        {
            init(name, null);
        }

        public GpxMetadata(string name, string desc)
        {
            init(name, desc);
        }

        private void init(string name, string desc)
        {
            Name = name;
            Description = desc;
            Author = null;
            Copyright = null;
            Link = null;
            Time = null;
            Keywords = null;
            Extensions = null;
        }
    }

    public class GpxBaseTrack
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Link { get; set; }
        public int? Number { get; set; }
        public string Type { get; set; }
        public string Extensions { get; set; }

        public GpxBaseTrack()
        {
            init(null, null);
        }

        public GpxBaseTrack(string name)
        {
            init(name, null);
        }

        public GpxBaseTrack(string name, string desc)
        {
            init(name, desc);
        }

        private void init(string name, string desc)
        {
            Name = name;
            Description = desc;
            Comment = null;
            Source = null;
            Link = null;
            Number = null;
            Type = null;
            Extensions = null;
        }
    }

    public class GpxRoute : GpxBaseTrack
    {
        public List<GpxPoint> Points { get; set; }

        public GpxRoute() : base ()
        {
            Points = new List<GpxPoint>();
        }

        public GpxRoute(string name) : base (name)
        {
            Points = new List<GpxPoint>();
        }

        public GpxRoute(string name, string desc) : base (name, desc)
        {
            Points = new List<GpxPoint>();
        }
    }

    public class GpxTrack : GpxBaseTrack
    {
        public List<GpxTrackSeg> Segments;

        public GpxTrack() : base()
        {
            Segments = new List<GpxTrackSeg>();
        }

        public GpxTrack(string name) : base(name)
        {
            Segments = new List<GpxTrackSeg>();
        }

        public GpxTrack(string name, string desc) : base(name, desc)
        {
            Segments = new List<GpxTrackSeg>();
        }
    }

    public class GpxTrackSeg
    {
        public List<GpxPoint> Points { get; set; }
        public string Extensions { get; set; }

        public GpxTrackSeg()
        {
            Points = new List<GpxPoint>();
            Extensions = null;
        }
    }


    public class GpxPoint
    {
        public string ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Altitude { get; set; }
        public DateTime? Time { get; set; }
        public double? MagVar { get; set; }
        public double? GeoidHeight { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string Source { get; set; }
        public string Link { get; set; }
        public string Symmetry { get; set; }
        public int? Fix { get; set; }
        public int? SatteliteNum { get; set; }
        public double? HDOP { get; set; }
        public double? PDOP { get; set; }
        public double? VDOP { get; set; }
        public double? AgeOfData { get; set; }
        public string DGpsId { get; set; }
        public string Extensions { get; set; }

        public GpxPoint(double lat, double lon)
        {
            init(lat, lon, null);
        }

        public GpxPoint(double lat, double lon, double? alt)
        {
            init(lat, lon, alt);
        }

        private void init(double lat, double lon, double? alt)
        {
            ID = Guid.NewGuid().ToString();
            Latitude = lat;
            Longitude = lon;
            Altitude = alt;
            Time = null;
            MagVar = null;
            GeoidHeight = null;
            Name = null;
            Description = null;
            Comment = null;
            Source = null;
            Link = null;
            Symmetry = null;
            Fix = null;
            SatteliteNum = null;
            HDOP = null;
            PDOP = null;
            VDOP = null;
            AgeOfData = null;
            DGpsId = null;
            Extensions = null;
        }
    }

    public enum PointType
    {
        WayPoint,
        RoutePoint,
        TrackPoint
    }



    public class GpxWriter : XmlTextWriter
    {
        #region Members

        private string _file;
        private GpxDocument _doc;
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
        public GpxDocument Document
        {
            get { return _doc; }
            set
            {
                _doc = value;
            }
        }
        #endregion

        public GpxWriter(string filename)
            : base(filename, null)
        {
            init(filename, null);
        }

        public GpxWriter(string filename, GpxDocument doc)
            : base(filename, null)
        {
            init(filename, doc);
        }

        private void init(string filename, GpxDocument doc)
        {
            Document = doc;
            _FileName = filename;
            Formatting = Formatting.Indented;
            Indentation = 4;
        }

        public void WriteStartGpx()
        {
            WriteStartElement("gpx");
            WriteAttributeString("version", "1.1");
            WriteAttributeString("creator", Document.Creator);

            _open = true;
        }

        public void WriteEndGpx()
        {
            WriteEndElement();
            _open = false;
        }

        public void WriteGpxDocument()
        {
            WriteGpxDocument(Document);
        }

        public void WriteGpxDocument(GpxDocument doc)
        {
            if (_open && doc != null)
            {
                if(doc.MetaData != null)
                    WriteGpxMetadata(doc.MetaData);

                if (doc.Waypoints != null && doc.Waypoints.Count > 0)
                {
                    foreach (GpxPoint point in doc.Waypoints)
                    {
                        WriteGpxPoint(point, PointType.WayPoint);
                    }
                }

                if (doc.Routes != null && doc.Routes.Count > 0)
                {
                    foreach (GpxRoute route in doc.Routes)
                    {
                        WriteGpxRoute(route);
                    }
                }

                if (doc.Tracks != null && doc.Tracks.Count > 0)
                {
                    foreach (GpxTrack track in doc.Tracks)
                    {
                        WriteGpxTrack(track);
                    }
                }

                if (doc.Extensions != null)
                    WriteGpxExtensions(doc.Extensions);
            }
        }

        public void WriteGpxRoute(GpxRoute route)
        {
            if (route != null)
            {
                WriteStartElement("rte");

                if (route.Name != null && route.Name != "")
                    WriteElementString("name", route.Name);

                if (route.Comment != null && route.Comment != "")
                    WriteElementString("cmt", route.Comment);

                if (route.Description != null && route.Description != "")
                    WriteElementString("desc", route.Description);

                if (route.Source != null && route.Source != "")
                    WriteElementString("src", route.Source);

                if (route.Link != null && route.Link != "")
                    WriteElementString("link", route.Link);

                if (route.Number != null)
                    WriteElementString("number", route.Number.ToString());

                if (route.Type != null && route.Type != "")
                    WriteElementString("type", route.Type);

                if (route.Extensions != null)
                    WriteGpxExtensions(route.Extensions);

                WriteStartElement("rtept");

                foreach (GpxPoint point in route.Points)
                {
                    WriteGpxPoint(point, PointType.RoutePoint);
                }

                //end of points
                WriteEndElement();
                //end of route
                WriteEndElement();
            }
        }

        public void WriteGpxTrack(GpxTrack track)
        {
            if (track != null)
            {
                WriteStartElement("trk");

                if (track.Name != null && track.Name != "")
                    WriteElementString("name", track.Name);

                if (track.Comment != null && track.Comment != "")
                    WriteElementString("cmt", track.Comment);

                if (track.Description != null && track.Description != "")
                    WriteElementString("desc", track.Description);

                if (track.Source != null && track.Source != "")
                    WriteElementString("src", track.Source);

                if (track.Link != null && track.Link != "")
                    WriteElementString("link", track.Link);

                if (track.Number != null)
                    WriteElementString("number", track.Number.ToString());

                if (track.Type != null && track.Type != "")
                    WriteElementString("type", track.Type);

                if (track.Extensions != null)
                    WriteGpxExtensions(track.Extensions);

                if (track.Segments != null)
                {
                    foreach (GpxTrackSeg seg in track.Segments)
                    {
                        WriteGpxTrackSegment(seg);
                    }
                }

                //end of route
                WriteEndElement();
            }
        }

        public void WriteGpxTrackSegment(GpxTrackSeg trackseg)
        {
            if (trackseg != null)
            {
                WriteStartElement("trkseg");

                if (trackseg.Points != null)
                {
                    foreach (GpxPoint point in trackseg.Points)
                    {
                        WriteGpxPoint(point, PointType.TrackPoint);
                    }
                }

                WriteGpxExtensions(trackseg.Extensions);

                WriteEndElement();
            }
        }

        public void WriteGpxPoint(GpxPoint point)
        {
            WriteGpxPoint(point, PointType.WayPoint);
        }

        public void WriteGpxPoint(GpxPoint point, PointType type)
        {
            if (point != null)
            {
                switch (type)
                {
                    case PointType.RoutePoint:
                        WriteStartElement("rtept");
                        break;
                    case PointType.TrackPoint:
                        WriteStartElement("trkpt");
                        break;
                    case PointType.WayPoint:
                    default:
                        WriteStartElement("wpt");
                        break;
                }

                WriteAttributeString("lat", point.Latitude.ToString());
                WriteAttributeString("lon", point.Longitude.ToString());

                if (point.Altitude != null)
                    WriteElementString("ele", point.Altitude.ToString());
                if (point.Time != null)
                    WriteElementString("time", point.Time.ToString());
                if (point.MagVar != null)
                    WriteElementString("magvar", point.MagVar.ToString());
                if (point.GeoidHeight != null)
                    WriteElementString("geoidheight", point.GeoidHeight.ToString());
                if (point.Name != null && point.Name != "")
                    WriteElementString("name", point.Name);
                if (point.Comment != null && point.Comment != "")
                    WriteElementString("cmt", point.Comment);
                if (point.Description != null && point.Description != "")
                    WriteElementString("desc", point.Description);
                if (point.Source != null && point.Source != "")
                    WriteElementString("src", point.Source);
                if (point.Link != null && point.Link != "")
                    WriteElementString("link", point.Link);
                if (point.Symmetry != null && point.Symmetry != "")
                    WriteElementString("sym", point.Symmetry);
                if (point.Fix != null)
                    WriteElementString("fix", point.Fix.ToString());
                if (point.SatteliteNum != null)
                    WriteElementString("sat", point.SatteliteNum.ToString());
                if (point.HDOP != null)
                    WriteElementString("hdop", point.HDOP.ToString());
                if (point.VDOP != null)
                    WriteElementString("vdop", point.VDOP.ToString());
                if (point.PDOP != null)
                    WriteElementString("pdop", point.PDOP.ToString());
                if (point.AgeOfData != null)
                    WriteElementString("ageofdata", point.AgeOfData.ToString());
                if (point.DGpsId != null && point.DGpsId != "")
                    WriteElementString("dgpsid", point.DGpsId);

                WriteGpxExtensions(point.Extensions);

                WriteEndElement();
            }
        }

        public void WriteGpxMetadata(GpxMetadata meta)
        {
            if (meta != null)
            {
                WriteStartElement("metadata");

                if (meta.Name != null && meta.Name != "")
                    WriteElementString("name", meta.Name);
                if (meta.Description != null && meta.Description != "")
                    WriteElementString("desc", meta.Description);
                if (meta.Author != null && meta.Author != "")
                    WriteElementString("author", meta.Author);
                if (meta.Copyright != null && meta.Copyright != "")
                    WriteElementString("copyright", meta.Copyright);
                if (meta.Link != null && meta.Link != "")
                    WriteElementString("link", meta.Link);
                if (meta.Time != null)
                    WriteElementString("time", meta.Time.ToString());

                if (meta.Keywords != null && meta.Keywords.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (string keyword in meta.Keywords)
                    {
                        sb.Append(keyword + ", ");
                    }

                    sb.Remove(sb.Length - 1, 1);

                    WriteElementString("keywords", sb.ToString());
                }

                if (meta.Extensions != null)
                    WriteGpxExtensions(meta.Extensions);

                WriteEndElement();
            }
        }

        public void WriteGpxExtensions(string extenstions)
        {
            if (extenstions != null && extenstions != "")
                WriteElementString("extensions", extenstions);
        }
    }
}
