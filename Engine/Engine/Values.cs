using System;
using System.Collections.Generic;
using System.Text;
using TwoTrails.BusinessLogic;
using TwoTrails.Engine;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Engine
{
    public class Values
    {
        public static string TwoTrailsVersion
        {
            get
            {
                System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                
#if(PocketPC || WindowsCE || Mobile)
                string device = "CE";
#else
                string device = "PC";
#endif
                return String.Format("{0}: {1}.{2}.{3}-{4}", device, version.Major,
                    version.Minor, version.Build, version.Revision);


                //return (version.Major.ToString() + "." + version.Minor.ToString() +
                //    "." + version.Build.ToString() + "-" + version.Revision.ToString());
            }
        }

#if(!PocketPC || WindowsCE || Mobile)
        private static DateTime RetrieveLinkerTimestamp()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.ToLocalTime();
            return dt;
        }
#endif

        public static string TwoTrailsBuildDate
        {
           get
           {
#if(!PocketPC || WindowsCE || Mobile)
              return RetrieveLinkerTimestamp().ToShortDateString();
#else
              System.Version MyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
              //// MyVersion.Build = days after 2000-01-01
              //// MyVersion.Revision*2 = seconds after 0-hour  (NEVER daylight saving time)
              DateTime compileTime = new DateTime(2000, 1, 1).AddDays(MyVersion.Build).AddSeconds(MyVersion.Revision * 2);                
              return compileTime.ToShortDateString();
#endif
           }
        }

        public static double NSSDA_RMSEr95_Coeff
        {
            get { return 1.7308; }
        }

        public static double Default_GPS_Accuracy
        {
            get { return 6; }
        }

        public static string On
        {
            get { return "On"; }
        }

        public static string Off
        {
            get { return "Off"; }
        }

        public static int BadDataLimit{get; set;}

        public static readonly List<string> DEFAULT_PORT_NAMES = new List<string>(
            new string[] {
                "COM1",
                "COM2",
                "COM3",
                "COM4",
                "COM5",
                "COM6",
                "COM7",
                "COM8",
                "COM9",
                "Other",
                "File"
        });
        public static readonly List<int> DEFAULT_BAUD_VALUES = new List<int>(
            new int[]{
                4800,
                9600,
                14400,
                19200,
                38400,
                56000,
                57600,
                115200
        });
        public static readonly List<int> DEFAULT_BAUD_VALUES_ORDERED = new List<int>(
            new int[]{
                4800,
                9600,
                38400,
                19200,
                115200,
                14400,
                56000,
                57600
        });

        public static bool CurrentDbVersion { get; set; }

        public static SettingsLogic Settings;
        public static GpsAccess.GpsAccess GPSA;
        public static LaserAccess.LaserAccess LaserA;
        public static Utilities.DataOutput DataExport;
        //public static GroupManager GroupManager;

#if(PocketPC || WindowsCE || Mobile)
        public static readonly string DefaultSaveFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
#else
        public static readonly string DefaultSaveFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
#endif

        public static readonly string EmptyGuid = "00000000-0000-0000-0000-000000000000";
        public static readonly string FullGuid = "11111111-1111-1111-1111-111111111111";
        public static readonly TtGroup MainGroup = new TtGroup()
        { Name = "Main Group", CN = EmptyGuid, Description = String.Empty, GroupType = GroupType.General };

        public static bool GlobalCancelToken = false;
        public static bool AdjustingPolygons = false;

        public static string CurrentTtFileName { get; set; }

        public static string LastEditedPolygonCN { get; set; }

        public static bool WideScreen
        {
            get
            {
                return (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width >
                    System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height);
            }
        }

#if !(PocketPC || WindowsCE || Mobile)
        public static TwoTrails.Forms.UpdateToolStripDelegate UpdateToolStripStatus;
        public static void UpdateStatusText(string status)
        {
            UpdateToolStripStatus(status);
        }

        public static TwoTrails.Forms.UpdateToolStripProgressDelegate UpdateToolStripProgress;
        public static void UpdateStatusProgress()
        {
            UpdateToolStripProgress();
        }

        public static TwoTrails.Forms.UpdateInfoDelegate UpdateInfo;
#endif


        #region Remembered Form Values

        public static int FormPlotLastPolyIndex = -1;
        public static int FormPlotLastDistIndex = -1;
        public static int FormPlotLastLocIndex = -1;
        public static int FormPlotLastStartIndex = -1;
        public static int FormPlotLastGrid1Val = -1;
        public static int FormPlotLastGrid2Val = -1;
        public static int FormPlotLastTiltVal = 0;
        public static int FormPlotLastSampleIndex = -1;
        public static int FormPlotLastSampleVal = -1;
        #endregion
    }
}
