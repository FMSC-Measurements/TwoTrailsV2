using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using TwoTrails.Utilities;
using TwoTrails.BusinessObjects;
using TwoTrails.Engine;

namespace TwoTrails.BusinessLogic
{
    public class SettingsLogic
    {
        public DeviceSettingsOptions DeviceOptions { get; set; }
        public ProjectSettingsOptions ProjectOptions { get; set; }


        #region Constructors / Intialization
        public SettingsLogic(DeviceSettingsOptions options)
        {
            SetUp();
            DeviceOptions = options;
        }

        public SettingsLogic(ProjectSettingsOptions options)
        {
            SetUp();
            ProjectOptions = options;
        }

        public SettingsLogic()
        {
            SetUp();
        }

        private void SetUp()
        {
            DeviceOptions = new DeviceSettingsOptions();
            ProjectOptions = new ProjectSettingsOptions();
#if (PocketPC || WindowsCE || Mobile)
            _ExePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);         
#else
            _ExePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
#endif
            if (!Directory.Exists(BinDirPath))
                Directory.CreateDirectory(BinDirPath);
        }
        #endregion

        #region Paths / Filenames
        private string _ExePath;
        private const string GPS_SETTINGS_FILENAME = "device_settings.txt";
        private const string PROJECT_SETTINGS_FILENAME = "project_setting.txt";
        private const string ERROR_LOG_FILENAME = "TwoTrailsLog.txt";
        private const string DEFAULT_NAMING_FILENAME = "default_naming_setting.txt";
        private const string DEFAULT_META_FILENAME = "default_meta_setting.txt";
        private const string BIN_DIR_NAME = "bin";
        private const string COMMON_APPLICATION_DATA = "TwoTrails";
        
        public string BinDirPath
        {
#if (PocketPC || WindowsCE || Mobile)
            get { return System.IO.Path.Combine(_ExePath, BIN_DIR_NAME); }
#else
            get
            {
                return System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                    COMMON_APPLICATION_DATA);
            }
#endif

            //get { return System.IO.Path.Combine(_ExePath, BIN_DIR_NAME); }
        }

        public string DeviceSettingsFilePath
        {
            get { return System.IO.Path.Combine(BinDirPath, GPS_SETTINGS_FILENAME); }
        }

        public string ProjectSettingsFilePath
        {
            get { return System.IO.Path.Combine(BinDirPath, PROJECT_SETTINGS_FILENAME); }
        }

        public string MetaSettingsFilePath
        {
            get { return System.IO.Path.Combine(BinDirPath, DEFAULT_META_FILENAME); }
        }

        public string LogFilePath
        {
            get { return System.IO.Path.Combine(BinDirPath, ERROR_LOG_FILENAME); }
        }

        public string DefaultNamingFilePath
        {
            get { return System.IO.Path.Combine(BinDirPath, DEFAULT_NAMING_FILENAME); }
        }
        #endregion

        #region Settings Keywords
        #region Device
        private const string LASER_BAUD = "LaserBaud";
        private const string GPS_BAUD = "GpsBaud";
        private const string LASER_PORT = "LaserPort";
        private const string GPS_PORT = "GpsPort";
        private const string USE_SELECTION = "Selection";
        private const string KEEP_GPS_ON = "GpsAlwaysOn";
        private const string LOG_ALL_GPS = "LogAllGps";

        private const string FILTER_GPS_DOP_TYPE = "FilterGpsDopType";
        private const string FILTER_GPS_DOP_VALUE = "FilterGpsDopValue";
        private const string FILTER_GPS_FIX_TYPE = "FilterGpsFixType";

        private const string FILTER_T5_DOP_TYPE = "FilterT5DopType";
        private const string FILTER_T5_DOP_VALUE = "FilterT5DopValue";
        private const string FILTER_T5_FIX_TYPE = "FilterT5FixType";

        private const string FILTER_WALK_DOP_TYPE = "FilterWalkDopType";
        private const string FILTER_WALK_DOP_VALUE = "FilterWalkDopValue";
        private const string FILTER_WALK_FIX_TYPE = "FilterWalkFixType";

        private const string GPS_CONFIGURED = "GpsConfigured";
        private const string USE_ONSCREEN_KEYBOARD = "OnScreenKeyboard";
        private const string UPDATE_INDEX_ON_SAVE = "AutoUpdateIndex";
        private const string IGNORE_FIRST_NMEA = "IgnoreNmea";
        private const string IGNORE_FIRST_NMEA_AMOUNT = "IgnoreNmeaAmount";
        private const string FILTER_ACCURACY = "FilterAccuracy";
        private const string FILTER_FREQUENCY = "FilterFrequency";
        private const string TAKE_5_FAIL = "Take5Fail";
        private const string TAKE_5_FAIL_AMOUNT = "take5FailAmount";
        private const string WALK_INCREMENT = "WalkIncrement";


        private const string MASS_EDIT_ELEV_FEET = "MEPElevFeet";
        private const string MASS_EDIT_AUTO_POLY_CLOSE = "MEPAutoPolyClose";
        private const string MASS_EDIT_ALT_ROWS = "MEPAltRows";
        private const string MASS_EDIT_COLOR_ROWS = "MEPColorRows";
        #endregion

        #region Project
        private const string REGION = "Region";
        private const string FOREST = "Forest";
        private const string DISTRICT = "District";
        private const string YEAR = "Year";
        private const string RECENT = "Recent";
        private const string DROP_ZERO = "DropZero";
        private const string ROUND = "RoundPoint";
        #endregion

        #region Meta Settings
        private const string META_CN = "CN";
        private const string META_NAME = "Name";
        private const string META_ZONE = "Zone";
        private const string META_DATUM = "Datum";
        private const string META_DISTANCE = "Distance";
        private const string META_ELEVATION = "Elevation";
        private const string META_SLOPE = "Slope";
        private const string META_DECTYPE = "Declination";
        private const string META_MAGDEC = "MagneticDeclination";
        private const string META_RECEIVER = "Receiver";
        private const string META_LASER = "Laser";
        private const string META_COMPASS = "Compass";
        private const string META_CREW = "Crew";
        #endregion
        #endregion

        #region Device Settings
        public void WriteDeviceSettings()
        {
            using (XmlTextWriter textWriter = new XmlTextWriter(DeviceSettingsFilePath, null))
            {
                textWriter.Formatting = Formatting.Indented;

                textWriter.WriteStartDocument();

                textWriter.WriteStartElement("DeviceSettings");
                
                textWriter.WriteStartElement(GPS_PORT);

                if (File.Exists(DeviceOptions.GpsComPort))
                    textWriter.WriteValue(DeviceOptions.GpsComPort);
                else if (!DeviceOptions.GpsComPort.IsEmpty())
                {
                    string tmp = DeviceOptions.GpsComPort.Replace("\\", "\\\\");
                    if (tmp[tmp.Length - 1] == ':')
                        textWriter.WriteValue(tmp.Substring(0, tmp.Length - 1));
                    else
                        textWriter.WriteValue(tmp);
                }

                textWriter.WriteEndElement(); //GpsPort
                


                textWriter.WriteStartElement(LASER_PORT);

                if (File.Exists(DeviceOptions.LaserComPort))
                    textWriter.WriteValue(DeviceOptions.LaserComPort);
                else if (!DeviceOptions.LaserComPort.IsEmpty())
                {
                    string tmp = DeviceOptions.LaserComPort.Replace("\\", "\\\\");
                    if (tmp[tmp.Length - 1] == ':')
                        textWriter.WriteValue(tmp.Substring(0, tmp.Length - 1));
                    else
                        textWriter.WriteValue(tmp);
                }

                textWriter.WriteEndElement(); //LaserPort



                textWriter.WriteStartElement(GPS_BAUD);
                textWriter.WriteValue(DeviceOptions.GpsBaud);
                textWriter.WriteEndElement(); //GpsBaud

                textWriter.WriteStartElement(LASER_BAUD);
                textWriter.WriteValue(DeviceOptions.LaserBaud);
                textWriter.WriteEndElement(); //LaserBaud

                textWriter.WriteStartElement(KEEP_GPS_ON);
                textWriter.WriteValue(DeviceOptions.KeepGpsOn);
                textWriter.WriteEndElement(); //Gps Always on

                textWriter.WriteStartElement(LOG_ALL_GPS);
                textWriter.WriteValue(DeviceOptions.LogAllGps);
                textWriter.WriteEndElement();//Log all Gps Data

                textWriter.WriteStartElement(USE_SELECTION);
                textWriter.WriteValue(DeviceOptions.UseSelection);
                textWriter.WriteEndElement(); //Selection Button

                textWriter.WriteStartElement(FILTER_GPS_DOP_TYPE);
                if(DeviceOptions.Filter_GPS_DOP_TYPE == 0)
                    textWriter.WriteValue("PDOP");
                else
                    textWriter.WriteValue("HDOP");
                textWriter.WriteEndElement(); //Filter DOP Type

                textWriter.WriteStartElement(FILTER_GPS_DOP_VALUE);
                textWriter.WriteValue(DeviceOptions.Filter_GPS_DOP_VALUE);
                textWriter.WriteEndElement(); //Filter Dop Value

                textWriter.WriteStartElement(FILTER_GPS_FIX_TYPE);
                textWriter.WriteValue(DeviceOptions.Filter_GPS_FixType);
                textWriter.WriteEndElement(); //Filter Fix Type

                textWriter.WriteStartElement(FILTER_T5_DOP_TYPE);
                if (DeviceOptions.Filter_T5_DOP_TYPE == 0)
                    textWriter.WriteValue("PDOP");
                else
                    textWriter.WriteValue("HDOP");
                textWriter.WriteEndElement(); //Filter DOP Type

                textWriter.WriteStartElement(FILTER_T5_DOP_VALUE);
                textWriter.WriteValue(DeviceOptions.Filter_T5_DOP_VALUE);
                textWriter.WriteEndElement(); //Filter Dop Value

                textWriter.WriteStartElement(FILTER_T5_FIX_TYPE);
                textWriter.WriteValue(DeviceOptions.Filter_T5_FixType);
                textWriter.WriteEndElement(); //Filter Fix Type

                textWriter.WriteStartElement(FILTER_WALK_DOP_TYPE);
                if (DeviceOptions.Filter_WALK_DOP_TYPE == 0)
                    textWriter.WriteValue("PDOP");
                else
                    textWriter.WriteValue("HDOP");
                textWriter.WriteEndElement(); //Filter DOP Type

                textWriter.WriteStartElement(FILTER_WALK_DOP_VALUE);
                textWriter.WriteValue(DeviceOptions.Filter_WALK_DOP_VALUE);
                textWriter.WriteEndElement(); //Filter Dop Value

                textWriter.WriteStartElement(FILTER_WALK_FIX_TYPE);
                textWriter.WriteValue(DeviceOptions.Filter_WALK_FixType);
                textWriter.WriteEndElement(); //Filter Fix Type

                textWriter.WriteStartElement(GPS_CONFIGURED);
                textWriter.WriteValue(DeviceOptions.GpsConfigured);
                textWriter.WriteEndElement(); //If Gps is configured

                textWriter.WriteStartElement(USE_ONSCREEN_KEYBOARD);
                textWriter.WriteValue(DeviceOptions.UseOnScreenKeyboard);
                textWriter.WriteEndElement(); //If to use the onscreen keyboard

                textWriter.WriteStartElement(UPDATE_INDEX_ON_SAVE);
                textWriter.WriteValue(DeviceOptions.AutoUpdateIndex);
                textWriter.WriteEndElement(); //Update the index of the points on save in pointeditform

                textWriter.WriteStartElement(IGNORE_FIRST_NMEA);
                textWriter.WriteValue(DeviceOptions.IgnoreFirst);
                textWriter.WriteEndElement();   //If ignore first nmea

                textWriter.WriteStartElement(IGNORE_FIRST_NMEA_AMOUNT);
                textWriter.WriteValue(DeviceOptions.IgnoreFirstX);
                textWriter.WriteEndElement();   //amount of nmea to ignore

                textWriter.WriteStartElement(FILTER_ACCURACY);
                textWriter.WriteValue(DeviceOptions.Filter_Accuracy);
                textWriter.WriteEndElement();   //accuracy for walk

                textWriter.WriteStartElement(FILTER_FREQUENCY);
                textWriter.WriteValue(DeviceOptions.Filter_Frequency);
                textWriter.WriteEndElement();   //frequency for walk

                textWriter.WriteStartElement(TAKE_5_FAIL);
                textWriter.WriteValue(DeviceOptions.Take5FailTrigger);
                textWriter.WriteEndElement();   //if to calc bad nmea in take 5 if no good data comes in

                textWriter.WriteStartElement(TAKE_5_FAIL_AMOUNT);
                textWriter.WriteValue(DeviceOptions.Take5FailTriggerAmount);
                textWriter.WriteEndElement();   //after this many packets + the required amount to start the take5 point calculation

                textWriter.WriteStartElement(WALK_INCREMENT);
                textWriter.WriteValue(DeviceOptions.WalkIncrement);
                textWriter.WriteEndElement();   //increment when walking

                textWriter.WriteStartElement(MASS_EDIT_ALT_ROWS);
                textWriter.WriteValue(DeviceOptions.FormMassEditUseAlternatingRows);
                textWriter.WriteEndElement();   //Mass Edit alternationg rows

                textWriter.WriteStartElement(MASS_EDIT_AUTO_POLY_CLOSE);
                textWriter.WriteValue(DeviceOptions.FormMassEditAutoClosePoly);
                textWriter.WriteEndElement();   //Mass Edit auto close poly

                textWriter.WriteStartElement(MASS_EDIT_COLOR_ROWS);
                textWriter.WriteValue(DeviceOptions.FormMassEditUseColoredRows);
                textWriter.WriteEndElement();   //Mass Edit alternationg rows

                textWriter.WriteStartElement(MASS_EDIT_ELEV_FEET);
                textWriter.WriteValue(DeviceOptions.FormMassEditElevationFeet);
                textWriter.WriteEndElement();   //Mass Edit elev is feet

                textWriter.WriteEndElement(); //DeviceSettings
                textWriter.WriteEndDocument();

                textWriter.Close();
            }

#if !(PocketPC || WindowsCE || Mobile)
            Values.UpdateStatusText("Settings Saved.");
#endif
        }

        public bool ReadDeviceSettings()
        {
            if (!File.Exists(DeviceSettingsFilePath))
                return false;
            using (XmlTextReader textReader = new XmlTextReader(DeviceSettingsFilePath))
            {
                
                string lastElement = String.Empty;
                while (textReader.Read())
                {
                    XmlNodeType nType = textReader.NodeType;
                    switch (nType)
                    {
                        case XmlNodeType.Element:
                            {
                                lastElement = textReader.Name;
                                break;
                            }
                        case XmlNodeType.Text:
                            {
                                switch (lastElement)
                                {
                                    case GPS_BAUD:
                                        {
                                            DeviceOptions.GpsBaud = textReader.ReadContentAsInt();
                                            break;
                                        }
                                    case GPS_PORT:
                                        {
                                            DeviceOptions.GpsComPort = textReader.ReadString();
                                            break;
                                        }
                                    case LASER_BAUD:
                                        {
                                            DeviceOptions.LaserBaud = textReader.ReadContentAsInt();
                                            break;
                                        }
                                    case LASER_PORT:
                                        {
                                            DeviceOptions.LaserComPort = textReader.ReadString();
                                            break;
                                        }
                                    case USE_SELECTION:
                                        {
                                            DeviceOptions.UseSelection = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    case KEEP_GPS_ON:
                                        {
                                            DeviceOptions.KeepGpsOn = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    case LOG_ALL_GPS:
                                        {
                                            DeviceOptions.LogAllGps = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    case FILTER_GPS_DOP_TYPE:
                                        {
                                            if (textReader.ReadString().Trim().ToLower() == "pdop")
                                                DeviceOptions.Filter_GPS_DOP_TYPE = 0;
                                            else
                                                DeviceOptions.Filter_GPS_DOP_TYPE = 1;
                                            break;
                                        }
                                    case FILTER_GPS_DOP_VALUE:
                                        {
                                            DeviceOptions.Filter_GPS_DOP_VALUE = textReader.ReadContentAsDouble();
                                            break;
                                        }
                                    case FILTER_GPS_FIX_TYPE:
                                        {
                                            DeviceOptions.Filter_GPS_FixType = textReader.ReadContentAsInt();
                                            break;
                                        }
                                    case FILTER_T5_DOP_TYPE:
                                        {
                                            if (textReader.ReadString().Trim().ToLower() == "pdop")
                                                DeviceOptions.Filter_T5_DOP_TYPE = 0;
                                            else
                                                DeviceOptions.Filter_T5_DOP_TYPE = 1;
                                            break;
                                        }
                                    case FILTER_T5_DOP_VALUE:
                                        {
                                            DeviceOptions.Filter_T5_DOP_VALUE = textReader.ReadContentAsDouble();
                                            break;
                                        }
                                    case FILTER_T5_FIX_TYPE:
                                        {
                                            DeviceOptions.Filter_T5_FixType = textReader.ReadContentAsInt();
                                            break;
                                        }
                                    case FILTER_WALK_DOP_TYPE:
                                        {
                                            if (textReader.ReadString().Trim().ToLower() == "pdop")
                                                DeviceOptions.Filter_WALK_DOP_TYPE = 0;
                                            else
                                                DeviceOptions.Filter_WALK_DOP_TYPE = 1;
                                            break;
                                        }
                                    case FILTER_WALK_DOP_VALUE:
                                        {
                                            DeviceOptions.Filter_WALK_DOP_VALUE = textReader.ReadContentAsDouble();
                                            break;
                                        }
                                    case FILTER_WALK_FIX_TYPE:
                                        {
                                            DeviceOptions.Filter_WALK_FixType = textReader.ReadContentAsInt();
                                            break;
                                        }
                                    case GPS_CONFIGURED:
                                        {
                                            DeviceOptions.GpsConfigured = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    case USE_ONSCREEN_KEYBOARD:
                                        {
                                            DeviceOptions.UseOnScreenKeyboard = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    case UPDATE_INDEX_ON_SAVE:
                                        {
                                            DeviceOptions.AutoUpdateIndex = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    case IGNORE_FIRST_NMEA:
                                        {
                                            DeviceOptions.IgnoreFirst = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    case IGNORE_FIRST_NMEA_AMOUNT:
                                        {
                                            DeviceOptions.IgnoreFirstX = textReader.ReadContentAsInt();
                                            break;
                                        }
                                    case FILTER_ACCURACY:
                                        {
                                            DeviceOptions.Filter_Accuracy = textReader.ReadContentAsDouble();
                                            break;
                                        }
                                    case FILTER_FREQUENCY:
                                        {
                                            DeviceOptions.Filter_Frequency = textReader.ReadContentAsInt();
                                            break;
                                        }
                                    case TAKE_5_FAIL:
                                        {
                                            DeviceOptions.Take5FailTrigger = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    case TAKE_5_FAIL_AMOUNT:
                                        {
                                            DeviceOptions.Take5FailTriggerAmount = textReader.ReadContentAsInt();
                                            break;
                                        }
                                    case WALK_INCREMENT:
                                        {
                                            DeviceOptions.WalkIncrement = textReader.ReadContentAsInt();
                                            break;
                                        }
                                    case MASS_EDIT_ALT_ROWS:
                                        {
                                            DeviceOptions.FormMassEditUseAlternatingRows = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    case MASS_EDIT_AUTO_POLY_CLOSE:
                                        {
                                            DeviceOptions.FormMassEditAutoClosePoly = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    case MASS_EDIT_COLOR_ROWS:
                                        {
                                            DeviceOptions.FormMassEditUseColoredRows = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    case MASS_EDIT_ELEV_FEET:
                                        {
                                            DeviceOptions.FormMassEditElevationFeet = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                                break;
                            }
                    }

                }
            }

            return true;
        }
        #endregion

        #region Project Settings
        public void WriteProjectSettings()
        {
            using (XmlTextWriter textWriter = new XmlTextWriter(ProjectSettingsFilePath, null))
            {
                textWriter.Formatting = Formatting.Indented;

                textWriter.WriteStartDocument();

                textWriter.WriteStartElement("ProjectSettings");

                textWriter.WriteStartElement(REGION); //Region
                textWriter.WriteValue(ProjectOptions.Region);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement(FOREST); //Forest
                textWriter.WriteValue(ProjectOptions.Forest);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement(DISTRICT); //District
                textWriter.WriteValue(ProjectOptions.District);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement(YEAR); //Year
                textWriter.WriteValue(ProjectOptions.Year);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement(DROP_ZERO); //Drop Zero
                textWriter.WriteValue(ProjectOptions.DropZero);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement(ROUND); //Round
                textWriter.WriteValue(ProjectOptions.Round);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement(RECENT); //Recent List
                textWriter.WriteValue(ProjectOptions.WriteRecent());
                textWriter.WriteEndElement();

                textWriter.WriteEndElement();//ProjectSettings
                textWriter.Close();
            }
        }

        public bool ReadProjectSettings()
        {
            if (!File.Exists(ProjectSettingsFilePath))
                return false;
            using (XmlTextReader textReader = new XmlTextReader(ProjectSettingsFilePath))
            {

                string lastElement = "";
                while (textReader.Read())
                {
                    XmlNodeType nType = textReader.NodeType;
                    switch (nType)
                    {
                        case XmlNodeType.Element:
                            {
                                lastElement = textReader.Name;
                                break;
                            }
                        case XmlNodeType.Text:
                            {
                                switch (lastElement)
                                {
                                    case REGION:
                                        {
                                            ProjectOptions.Region = textReader.ReadContentAsInt();
                                            break;
                                        }
                                    case FOREST:
                                        {
                                            ProjectOptions.Forest = textReader.ReadString();
                                            break;
                                        }
                                    case DISTRICT:
                                        {
                                            ProjectOptions.District = textReader.ReadString();
                                            break;
                                        }
                                    case YEAR:
                                        {
                                            //ProjectOptions.Year = textReader.ReadString();
                                            ProjectOptions.Year = DateTime.Now.Year.ToString();
                                            break;
                                        }
                                    case RECENT:
                                        {
                                            ProjectOptions.ParseRecent(textReader.ReadString());
                                            break;
                                        }
                                    case DROP_ZERO:
                                        {
                                            ProjectOptions.DropZero = textReader.ReadContentAsBoolean();
                                            break;
                                        }
                                    case ROUND:
                                        {
                                            ProjectOptions.Round = textReader.ReadContentAsBoolean();
                                            break;
                                        }

                                }
                                break;
                            }
                    }
                }
            }

            return true;
        }
        #endregion

        #region Meta Default Settings
        public void WriteMetaSettings(TtMetaData md)
        {
            using (XmlTextWriter textWriter = new XmlTextWriter(MetaSettingsFilePath, null))
            {
                textWriter.Formatting = Formatting.Indented;

                textWriter.WriteStartDocument();

                textWriter.WriteStartElement("MetaSettings");

                textWriter.WriteStartElement(META_CN);
                textWriter.WriteValue(md.CN.NotNull());
                textWriter.WriteEndElement(); //CN

                textWriter.WriteStartElement(META_COMPASS);
                textWriter.WriteValue(md.Compass.NotNull());
                textWriter.WriteEndElement(); //compass

                textWriter.WriteStartElement(META_CREW);
                textWriter.WriteValue(md.Crew.NotNull());
                textWriter.WriteEndElement(); //crew

                textWriter.WriteStartElement(META_DATUM);
                textWriter.WriteValue(md.datum.ToString());
                textWriter.WriteEndElement(); //datum

                textWriter.WriteStartElement(META_DECTYPE);
                textWriter.WriteValue(md.decType.ToString());
                textWriter.WriteEndElement(); //declination type

                textWriter.WriteStartElement(META_DISTANCE);
                textWriter.WriteValue(md.uomDistance.ToString());
                textWriter.WriteEndElement();//distance

                textWriter.WriteStartElement(META_ELEVATION);
                textWriter.WriteValue(md.uomElevation.ToString());
                textWriter.WriteEndElement(); //elevation

                textWriter.WriteStartElement(META_LASER);
                textWriter.WriteValue(md.Laser.NotNull());
                textWriter.WriteEndElement(); //laser

                textWriter.WriteStartElement(META_MAGDEC);
                textWriter.WriteValue(md.magDec);
                textWriter.WriteEndElement(); //magnetic declination

                textWriter.WriteStartElement(META_NAME);
                textWriter.WriteValue(md.Name.NotNull());
                textWriter.WriteEndElement(); //name

                textWriter.WriteStartElement(META_RECEIVER);
                textWriter.WriteValue(md.Receiver.NotNull());
                textWriter.WriteEndElement(); //receiver

                textWriter.WriteStartElement(META_SLOPE);
                textWriter.WriteValue(md.uomSlope.ToString());
                textWriter.WriteEndElement(); //slope

                textWriter.WriteStartElement(META_ZONE);
                textWriter.WriteValue(md.Zone);
                textWriter.WriteEndElement();   //zone

                textWriter.WriteEndElement(); //DeviceSettings
                textWriter.WriteEndDocument();

                textWriter.Close();
            }
        }

        public TtMetaData ReadMetaSettings()
        {
            TtMetaData md = new TtMetaData();

            if (!File.Exists(MetaSettingsFilePath))
                return null;
            using (XmlTextReader textReader = new XmlTextReader(MetaSettingsFilePath))
            {

                string lastElement = "";
                while (textReader.Read())
                {
                    XmlNodeType nType = textReader.NodeType;
                    switch (nType)
                    {
                        case XmlNodeType.Element:
                            {
                                lastElement = textReader.Name;
                                break;
                            }
                        case XmlNodeType.Text:
                            {
                                switch (lastElement)
                                {
                                    case META_CN:
                                        {
                                            md.CN = textReader.ReadString();
                                            break;
                                        }
                                    case META_COMPASS:
                                        {
                                            md.Compass = textReader.ReadString();
                                            break;
                                        }
                                    case META_CREW:
                                        {
                                            md.Crew = textReader.ReadString();
                                            break;
                                        }
                                    case META_DATUM:
                                        {
                                            try
                                            {
                                                md.datum = (Datum)Enum.Parse(typeof(Datum), textReader.ReadString(), true);
                                            }
                                            catch
                                            {
                                                //
                                            }
                                            break;
                                        }
                                    case META_DECTYPE:
                                        {
                                            try
                                            {
                                                md.decType = (DeclinationType)Enum.Parse(typeof(DeclinationType), textReader.ReadString(), true);
                                            }
                                            catch
                                            {
                                                //
                                            }
                                            break;
                                        }
                                    case META_DISTANCE:
                                        {
                                            try
                                            {
                                                md.uomDistance = (UomDistance)Enum.Parse(typeof(UomDistance), textReader.ReadString(), true);
                                            }
                                            catch
                                            {
                                                //
                                            }
                                            break;
                                        }
                                    case META_ELEVATION:
                                        {
                                            try
                                            {
                                                md.uomElevation = (UomElevation)Enum.Parse(typeof(UomElevation), textReader.ReadString(), true);
                                            }
                                            catch
                                            {
                                                //
                                            }
                                            break;
                                        }
                                    case META_LASER:
                                        {
                                            md.Laser = textReader.ReadString();
                                            break;
                                        }
                                    case META_MAGDEC:
                                        {
                                            md.magDec = textReader.ReadContentAsDouble();
                                            break;
                                        }
                                    case META_NAME:
                                        {
                                            md.Name = textReader.ReadString();
                                            break;
                                        }
                                    case META_RECEIVER:
                                        {
                                            md.Receiver = textReader.ReadString();
                                            break;
                                        }
                                    case META_SLOPE:
                                        {
                                            try
                                            {
                                                md.uomSlope = (UomSlope)Enum.Parse(typeof(UomSlope), textReader.ReadString(), true);
                                            }
                                            catch
                                            {
                                                //
                                            }
                                            break;
                                        }
                                    case META_ZONE:
                                        {
                                            md.Zone = textReader.ReadContentAsInt();
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                                break;
                            }
                    }

                }
            }

            return md;
        }
        #endregion
    }
}