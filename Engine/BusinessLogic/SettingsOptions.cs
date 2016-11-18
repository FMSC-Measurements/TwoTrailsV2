using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.IO;
using TwoTrails.Utilities;

namespace TwoTrails.BusinessLogic
{
    public struct RecentProject
    {
        public readonly string Name;
        public readonly string File;

        public RecentProject(string nf)
        {
            Name = "";
            File = "";

            try
            {
                string[] s = nf.Split(',');

                if (s.Length > 1)
                {
                    Name = s[0];
                    File = s[1];
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "SettingsOpetions- RecentProject", ex.StackTrace);
            }
        }

        public RecentProject(string n, string f)
        {
            Name = n;
            File = f;
        }
    };

    public class DeviceSettingsOptions
    {
        public DeviceSettingsOptions()
        {
            GpsComPort = "COM1";
            LaserComPort = "";
            GpsBaud = 4800;
            LaserBaud = 0;

        #if (Mobile || PocketPC)
            KeepGpsOn = true;
            UseSelection = true;
            UseOnScreenKeyboard = true;
        #else
            KeepGpsOn = false;
            UseSelection = false;
            UseOnScreenKeyboard = false;
        #endif

            AutoUpdateIndex = true;

            GpsTimeout = 3000;
            LaserTimeout = 10000;

            LogAllGps = false;

            Filter_GPS_DOP_TYPE = DEFAULT_GPS_DOP_TYPE;
            Filter_GPS_FixType = DEFAULT_GPS_FIX_TYPE;
            Filter_GPS_DOP_VALUE = DEFAULT_GPS_DOP_VALUE;

            Filter_T5_DOP_TYPE = DEFAULT_T5_DOP_TYPE;
            Filter_T5_FixType = DEFAULT_T5_FIX_TYPE;
            Filter_T5_DOP_VALUE = DEFAULT_T5_DOP_VALUE;

            Filter_WALK_DOP_TYPE = DEFAULT_WALK_DOP_TYPE;
            Filter_WALK_FixType = DEFAULT_WALK_FIX_TYPE;
            Filter_WALK_DOP_VALUE = DEFAULT_WALK_DOP_VALUE;

            WalkIncrement = DEFAULT_WALK_INCREMENT;

            GpsConfigured = false;

            Take5NmeaAmount = DEFAULT_NMEA_AMOUNT;
            Take5FailTrigger = false;
            Take5FailTriggerAmount = DEFAULT_TAKE5_TRIGGER_AMOUNT;

            Filter_Accuracy = 0;
            Filter_Frequency = 10;

            IgnoreFirstX = DEFAULT_IGNORE_AMOUNT;
            IgnoreFirst = false;

            DropZero = DEFAULT_DROP_ZERO;
            Round = DEFAULT_ROUND;
            GetGpsOnStart = DEFAULT_GET_GPS_ON_START;

            FormMassEditElevationFeet = true;
            FormMassEditAutoClosePoly = false;
            FormMassEditUseAlternatingRows = true;
            FormMassEditUseColoredRows = false;
            FormMassEditAdvEdit = false;
            FormMassEditPointLocManip = -1;
        }
        
        //Defualts
        public int DEFAULT_GPS_DOP_TYPE { get { return 1; } }
        public int DEFAULT_GPS_FIX_TYPE { get { return 1; } }
        public double DEFAULT_GPS_DOP_VALUE { get { return 20; } }
        public int DEFAULT_T5_DOP_TYPE { get { return 1; } }
        public int DEFAULT_T5_FIX_TYPE { get { return 1; } }
        public double DEFAULT_T5_DOP_VALUE { get { return 20; } }
        public int DEFAULT_WALK_DOP_TYPE { get { return 1; } }
        public int DEFAULT_WALK_FIX_TYPE { get { return 1; } }
        public double DEFAULT_WALK_DOP_VALUE { get { return 20; } }
        public int DEFAULT_NMEA_AMOUNT { get { return 5; } }
        public int DEFAULT_TAKE5_TRIGGER_AMOUNT { get { return 5; } }
        public int DEFAULT_IGNORE_AMOUNT { get { return 2; } }
        public bool DEFAULT_DROP_ZERO { get { return false; } }
        public bool DEFAULT_ROUND { get { return false; } }
        public int DEFAULT_WALK_INCREMENT { get { return 2; } }
        public double DEFAULT_POINT_ACCURACY { get { return 6.01d; } }
        public double MIN_POINT_ACCURACY { get { return 0.0001; } }
        public bool DEFAULT_GET_GPS_ON_START { get { return false; } }



        //Gps & Laser
        public string GpsComPort { get; set; }
        public string LaserComPort { get; set; }

        public int GpsBaud { get; set; }
        public int LaserBaud { get; set; }

        public bool KeepGpsOn { get; set; }

        public int GpsTimeout { get; set; }  //how long the device will try to read data
        public int LaserTimeout { get; set; }  //how long the device will try to read data

        public bool LogAllGps { get; set; }

        /*
        public bool _GpsConfigured;
        public bool GpsConfigured
        {
            get { return _GpsConfigured; }
            set { _GpsConfigured = value; }
        }
        */
        public bool GpsConfigured { get; set; }


        //Other
        public bool UseSelection { get; set; }  //Selecction button (instead of combobox)
        public int Take5NmeaAmount { get; set; }
        public bool Take5FailTrigger { get; set; }
        public int Take5FailTriggerAmount { get; set; }
        public bool UseOnScreenKeyboard { get; set; }
        public bool AutoUpdateIndex { get; set; }
        public int IgnoreFirstX { get; set; }
        public bool IgnoreFirst { get; set; }
        public bool DropZero { get; set; }
        public bool Round { get; set; }
        public int WalkIncrement { get; set; }
        public bool GetGpsOnStart { get; set; }

        //filters
        public int Filter_GPS_DOP_TYPE { get; set; }
        public double Filter_GPS_DOP_VALUE { get; set; }
        public int Filter_GPS_FixType { get; set; }

        public int Filter_T5_DOP_TYPE { get; set; }
        public double Filter_T5_DOP_VALUE { get; set; }
        public int Filter_T5_FixType { get; set; }


        public int Filter_WALK_DOP_TYPE { get; set; }
        public double Filter_WALK_DOP_VALUE { get; set; }
        public int Filter_WALK_FixType { get; set; }


        public int Filter_Frequency { get; set; }
        public double Filter_Accuracy { get; set; }

        //forms
        public bool FormMassEditElevationFeet { get; set; }
        public bool FormMassEditAutoClosePoly { get; set; }
        public bool FormMassEditUseAlternatingRows { get; set; }
        public bool FormMassEditUseColoredRows { get; set; }
        public bool FormMassEditAdvEdit { get; set; }
        public int FormMassEditPointLocManip { get; set; }
    }

    public class ProjectSettingsOptions
    {
        public ProjectSettingsOptions()
        {
            ProjectName = "1";
            Description = "My Project";
            //Region = 13;
            Forest = "WOD";
            District = "FMSC";
            Year = DateTime.Now.Year.ToString();
            DropZero = false;
            Round = false;

            IsRec = false;
            RecOpen = new List<RecentProject>();
            RecOpen.Add(new RecentProject("___", "Recently Opened Files"));
        }

        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }
        public string Forest { get; set; }
        public string District { get; set; }
        public string Year { get; set; }
        public bool DropZero { get; set; }
        public bool Round { get; set; }

        public List<RecentProject> RecOpen;
        public bool IsRec { get; set; }

        public bool AddToRecent(string filename, string name)
        {
            bool added = false;

            for(int i=0; i < RecOpen.Count; i++)
            {
                if (RecOpen[i].File == filename)
                {
                    RecOpen.RemoveAt(i);
                    RecOpen.Insert(1, new RecentProject(name, filename));
                    added = true;
                    break;
                }
            }

            if(!added)
                RecOpen.Insert(1, new RecentProject(name, filename));

            if (RecOpen.Count > 11)
            {
                RecOpen.RemoveRange(11, RecOpen.Count - 11);
            }

            return true;
        }

        public void ParseRecent(string recString)
        {
            foreach (string rec in recString.Split(';'))
            {
                RecentProject recProj = new RecentProject(rec);

                if (File.Exists(recProj.File))
                {
                    RecOpen.Add(recProj);
                }
            }

            if (RecOpen.Count > 0)
            {
                IsRec = true;
            }
        }

        public string WriteRecent()
        {
            StringBuilder recOut = new StringBuilder();

            List<string> added = new List<string>();

            foreach (RecentProject rec in RecOpen)
            {
                if (rec.Name != "___" &&  File.Exists(rec.File)
                    && !added.Contains(rec.File))
                {
                    recOut.AppendFormat("{0},{1};",rec.Name, rec.File);
                }
            }

            return recOut.ToString();
        }
    }           

}