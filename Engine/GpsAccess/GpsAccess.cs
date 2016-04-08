using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.IO.Ports;
using TwoTrails.GpsAccess;
using TwoTrails.Utilities;
using TwoTrails.Engine;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using TwoTrails.BusinessObjects;
using System.Runtime.InteropServices;

namespace TwoTrails.GpsAccess
{
    /// <summary>
    /// All valid NMEA non-proprietary strings
    /// </summary>
    public enum NmeaString
    {
        BOD,
        BWC,
        GGA,
        GLL,
        GSA,
        GSV,
        HDT,
        ROO,
        RMA,
        RMB,
        RMC,
        RTE,
        TRF,
        STN,
        VBW,
        VTG,
        WPL,
        XTE,
        ZDA
    };

    public enum GpsErrorType
    {
        NoError,
        ComNotExist,
        UnknownError,
        GpsTimeout,
        FileNull,
        FileOpenError,
        FileReadError,
        FileNotSelectedError,
        UnknownFileError,
        BurstDelegateError
    };


    /// <summary>
    /// An Error has occured
    /// </summary>
    public delegate void DelegateGpsError();

    /// <summary>
    /// Timeout when attempting to read from the com port
    /// </summary>
    public delegate void DelegateComTimeout();

    /// <summary>
    /// An invalid string is recieved
    /// </summary>
    public delegate void DelegateInvalidStringFound();

    /// <summary>
    /// The GPS thread has ended
    /// </summary>
    public delegate void DelegateGpsEnded();

    /// <summary>
    /// GPS thread has started
    /// </summary>
    public delegate void DelegateGpsStarted();

    /// <summary>
    /// A NMEA burst is recorded
    /// </summary>
    /// <param name="b">NmeaBurst object containing burst information</param>
    public delegate void DelegateDeliverBurst(NmeaBurst b);   

    public delegate void DelegateDeliverGpsString(String GpsString);

    #region Parsing Delegate Definitions
    /* Each of these hooks to a parsing function for each type of NMEA string being used.
     * To add additional NMEA strings they need to be added to the StringsToUse List as well
     * as a Delegate function added to the ParsingFunctions List
     */
    public delegate void DelegateParseGSV(String[] tokens, ref NmeaBurst b);
    public delegate void DelegateParseGGA(String[] tokens, ref NmeaBurst b);
    public delegate void DelegateParseRMC(String[] tokens, ref NmeaBurst b);
    public delegate void DelegateParseGSA(String[] tokens, ref NmeaBurst b);
    #endregion
    public partial class GpsAccess : Component
    {
        #region Events exposed
        public event DelegateDeliverBurst BurstReceived;

        public event DelegateGpsStarted GpsStarted;

        public event DelegateGpsEnded GpsEnded;

        public event DelegateInvalidStringFound InvalidStringFound;

        public event DelegateComTimeout ComTimeout;

        public event DelegateGpsError GpsError;

        public event DelegateDeliverGpsString StringReceived;
        public event DelegateDeliverGpsString ValidStringReceived;
        #endregion

        #region Parsing Delegates
        private DelegateParseGSV m_DelegateParseGSV;
        private DelegateParseGSA m_DelegateParseGSA;
        private DelegateParseGGA m_DelegateParseGGA;
        private DelegateParseRMC m_DelegateParseRMC;
        #endregion

        private SerialPort _port;
        public int Rate;
        public string Port;

        private bool _cancelled = false;
        private bool _busy = false;
        private bool ignoreFirst;   //ignore first string (bad data)
        private int _bursts;
        private bool _UseFile, FileOpen;
        private string GpsFile, sentence;
        StreamReader sr;
        StreamWriter sw;


        public GpsErrorType Error = GpsErrorType.NoError;
        
        /// <summary>
        /// The NMEA strings which will be parsed. Must have a corresponding entry in
        /// ParsingFunctions
        /// </summary>
        public static List<NmeaString> StringsToUse = new List<NmeaString>(
            new NmeaString[] {
            NmeaString.RMC,
            NmeaString.GSV,
            NmeaString.GGA,
            NmeaString.GSA
        });

        /// <summary>
        /// Holds the delegates used to call the parsing function appropriate for each NmeaString type
        /// that is to be parsed
        /// </summary>
        private Dictionary<NmeaString, Delegate > ParsingFunctions;
        
        /// <summary>
        /// The number of NMEA strings to read before giving up when trying to find a certain type of NMEA string
        /// </summary>
        public long FindTypeCount
        {
            get;
            set;
        }

        /// <summary>
        /// The number of lines to read before giving up when trying to find an NMEA formatted string
        /// </summary>
        public long IsNMEACount
        {
            get;
            set;
        }

        private bool _LogToFile = false, _test = false;
        public bool LogToFile
        {
            get { return _LogToFile; }
            set
            {
                if (_LogToFile != value)
                {
                    _LogToFile = value;

                    if (_LogToFile)
                    {
                        if (_LogFilename != _UsedFile)
                        {
                            try
                            {
                                if (sw != null)
                                {
                                    sw.Close();
                                    sw.Dispose();
                                    sw = null;
                                }

                                sw = new StreamWriter(LogFilename, true);
                                _UsedFile = _LogFilename;
                            }
                            catch (Exception ex)
                            {
                                TtUtils.WriteError(ex.Message, "GpsAccess:LogToFile", ex.StackTrace);
                            }
                        }
                    }
                }
            }
        }

        private string _LogFilename, _UsedFile = String.Empty;
        public string LogFilename
        {
            get { return _LogFilename; }
            set
            {
                if (LogToFile)
                {
                    LogToFile = false;
                    _LogFilename = value;
                    LogToFile = true;
                }
                else
                    _LogFilename = value;
            }
        }

        [DefaultValue(false)]
        public bool LogOnlyValid { get; set; }


        public bool IsBusy
        {
            get { return _busy; }
        }

        public int Bursts
        {
            get { return _bursts; }
        }

        public bool UsesFile { get { return _UseFile; } }

        public GpsAccess()
        {
            InitializeGpsVariables();
            InitializeComponent();
        }

        public GpsAccess(IContainer container)
        {
            container.Add(this);
            InitializeGpsVariables();
            InitializeComponent();
        }

        private void InitializeGpsVariables()
        {
                //Set up delegates for each string type to be used
            m_DelegateParseGSV = new DelegateParseGSV(ParseGSV);
            m_DelegateParseGGA = new DelegateParseGGA(ParseGGA);
            m_DelegateParseGSA = new DelegateParseGSA(ParseGSA);
            m_DelegateParseRMC = new DelegateParseRMC(ParseRMC);
                //Add the delegates to the dictionary to be called for each type
            ParsingFunctions = new Dictionary<NmeaString, Delegate>();
            ParsingFunctions.Add(NmeaString.GSV, m_DelegateParseGSV);
            ParsingFunctions.Add(NmeaString.GSA, m_DelegateParseGSA);
            ParsingFunctions.Add(NmeaString.GGA, m_DelegateParseGGA);
            ParsingFunctions.Add(NmeaString.RMC, m_DelegateParseRMC);

            Error = GpsErrorType.NoError;
            _bursts = 0;
            _UseFile = false;
            FileOpen = false;
            GpsFile = String.Empty;
        }

        #region Open / Close / Cancel
        public void OpenGps(string port, int rate)
        {
            if(_busy)
                return;
            _busy = true;
            _cancelled = false;
            Port = port;
            Rate = rate;
            ThreadPool.QueueUserWorkItem(new WaitCallback(GpsWorker), null);

#if (PocketPC || WindowsCE || Mobile)
            DisableDeviceSleep();
#endif
        }

        public void OpenGps()
        {
            OpenGps(Port, Rate);
        }

        public void TestGps(string port, int rate)
        {
            _test = true;
            OpenGps(port, rate);
        }

        public void TestGps()
        {
            _test = true;
            OpenGps();
        }

        public void CloseGps()
        {
            _cancelled = true;

            #if (PocketPC || WindowsCE || Mobile)
                EnableDeviceSleep();
            #endif
        }

        public void KillGps()
        {
            _cancelled = true;
            CloseGpsPort();

#if (PocketPC || WindowsCE || Mobile)
            EnableDeviceSleep();
#endif
        }

        private void CloseGpsPort()
        {
            if (!_UseFile)
            {
                if (_port != null)
                    _port.Close();
            }
            else if (FileOpen)
            {
                sr.Close();
                _UseFile = false;
            }
            _busy = false;
        }
        
        private void Cancel()
        {
            CloseGpsPort();
            //Trigger Event
            if (GpsEnded != null)
            {
                GpsEnded();
            }
        }
        #endregion
        

        //GPS Connection and Read
        private void GpsWorker(object o)
        {
            _UseFile = false;

            NmeaBurst burst = new NmeaBurst();
            _bursts = 0;

            try
            {
                #region File
                if (!Port.ToLower().Contains("com"))
                {
                    _UseFile = true;

                    GpsFile = Port;

                    try
                    {
                        try
                        {
                            sr = new StreamReader(GpsFile);
                            FileOpen = true;
                        }
                        catch(Exception ex)
                        {
                            TtUtils.WriteError(ex.Message, String.Format("GpsAccess:GpsWorker:OpenFile [{0}]", GpsFile), ex.StackTrace);
                            Error = GpsErrorType.FileOpenError;
                            if (GpsError != null)
                                GpsError();
                            Cancel();
                            return;
                        }

                        if (sr.Peek() < 1)
                        {
                            Error = GpsErrorType.FileNull;
                            if (GpsError != null)
                                GpsError();
                            Cancel();
                            return;
                        }

                        while (true)
                        {
                            if (_cancelled)
                            {
                                Cancel();
                                return;
                            }

                            try
                            {
                                sentence = sr.ReadLine();

                                if (sentence == null)
                                {
                                    sr.Close();
                                    FileOpen = false;
                                    sr = new StreamReader(GpsFile);
                                    FileOpen = true;
                                    sentence = sr.ReadLine();
                                }

                                sentence = sentence.Trim();
                            }
                            catch (Exception ex)
                            {
                                TtUtils.WriteError(ex.Message, "GpsAccess:GpsWorker:Readline", ex.StackTrace);
                                Error = GpsErrorType.FileReadError;
                                if (GpsError != null)
                                    GpsError();
                                Cancel();
                                return;
                            }

                            //create new burst if no burst or prev burst was completed
                            if (burst == null || burst.complete)
                            {
                                burst = new NmeaBurst();
                            }

                            ParseSentence(sentence, ref burst);

                            //if all lines are parsed mark as complete
                            if (burst != null)
                            {
                                if (burst.bGGA && burst.bGSA && burst.bGSV && burst.bRMC)
                                    burst.Complete();
                            }

                            //trigger complete burst completed
                            #region Trigger NmeaBurstReceived Event
                            if (burst != null && !_cancelled && burst.complete)
                            {
                                _bursts++;

                                try
                                {
                                    OnBurstReceived(burst);
                                }
                                catch (Exception ex)
                                {
                                    TtUtils.WriteError(ex.Message, "GpsAccess:GpsWorker:BurstReceived:Delegate", ex.StackTrace);
                                    Error = GpsErrorType.BurstDelegateError;
                                    if (GpsError != null)
                                        GpsError();
                                    Cancel();
                                    return;
                                }

                                Thread.Sleep(1000);
                            }
                            #endregion
                        }
                    }
                    catch (IOException ioEx)
                    {
                        TtUtils.WriteError(ioEx.Message, "GpsAccess:GpsWorker(IO)", ioEx.StackTrace);
                        Error = GpsErrorType.UnknownFileError;
                        if (GpsError != null)
                            GpsError();
                        Cancel();
                    }
                    catch (Exception ex)
                    {
                        TtUtils.WriteError(ex.Message, "GpsAccess:GpsWorker", ex.StackTrace);
                        Error = GpsErrorType.UnknownError;
                        if (GpsError != null)
                            GpsError();
                        Cancel();
                    }
                }
                        #endregion
                #region GpsDevice
                else
                {
                    _port = new SerialPort(Port, Rate);
                    _port.Parity = Parity.None;
                    _port.StopBits = StopBits.One;
                    _port.DataBits = 8;
                    _port.Handshake = Handshake.None;
                    _port.ReadTimeout = Values.Settings.DeviceOptions.GpsTimeout;
                    _port.Open();

                    ignoreFirst = true; //ignore first GPS string (bad data)

                    #region Trigger Event
                    //Trigger Event
                    if (GpsStarted != null)
                    {
                        GpsStarted();
                    }
                    #endregion

                    if (_test)
                    {
                        sentence = _port.ReadLine().TrimEx();
                        _test = false;
                    }
                    else
                    {
                        sentence = SyncGps().TrimEx();
                    }

                    while (true)
                    {
                        //create new burst if no burst or prev burst was completed
                        if (burst == null || burst.complete)
                        {
                            burst = new NmeaBurst();
                        }

                        ParseSentence(sentence, ref burst);

                        if(burst != null)
                        {

                            if (burst.bGGA && burst.bGSA && burst.bGSV && burst.bRMC)
                                burst.Complete();

                            #region Trigger NmeaBurstReceived Event
                            if (burst.complete && BurstReceived != null && !_cancelled)
                            {
                                _bursts++;

                                try
                                {
                                    if (burst.IsValidNmea)
                                    {
                                        OnBurstReceived(burst);
                                    }
                                    else
                                    {
                                        burst.drop = true;
                                        OnBurstReceived(burst);
                                        burst = null;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    TtUtils.WriteError(ex.Message, "GpsAccess:BurstReceived:Delegate", ex.StackTrace);
                                }
                            }
                            #endregion
                        }

                        if (_cancelled)
                        {
                            Cancel();
                            return;
                        }

                        sentence = _port.ReadLine().TrimEx();
                    }
                }
            }
                #endregion
            #region Catch Exceptions
            catch (TimeoutException toEx)
            {
                Error = GpsErrorType.GpsTimeout;
                TtUtils.WriteError(toEx.Message, "GpsAccess", toEx.StackTrace);

                #region trigger ComTimeout event
                if (ComTimeout != null)
                    ComTimeout();
                #endregion
                CloseGpsPort();
            }
            catch(System.IO.IOException ioEx)
            {
                Error = GpsErrorType.ComNotExist;
                TtUtils.WriteError(ioEx.Message, "GpsAccess", ioEx.StackTrace);

                #region trigger Error event
                if (GpsError != null)
                    GpsError();
                #endregion
                CloseGpsPort();
            }
            catch (Exception ex)
            {
                Error = GpsErrorType.UnknownError;
                TtUtils.WriteError(ex.Message, "GpsAccess", ex.StackTrace);

                #region trigger Error event
                if (GpsError != null)
                    GpsError();
                #endregion
                CloseGpsPort();
            }
            #endregion
        }


        private string SyncGps()
        {
            long longestInterval = 0;
            Stopwatch sw = new Stopwatch();

            string line, startString = String.Empty;

            line = _port.ReadLine();
            sw.Start();

            for(int i=0; i < 20; i++)
            {
                line = _port.ReadLine();
                sw.Stop();

                if (sw.ElapsedTicks > longestInterval)
                {
                    string[] tokens = line.Split(',');
                    if (tokens.Length > 0)
                    {
                        longestInterval = sw.ElapsedTicks;
                        startString = tokens[0];
                    }
                }

                sw.Reset();
                sw.Start();
            }
            
            sw.Stop();

            do
            {
                line = _port.ReadLine();
            }while(!line.StartsWith(startString));

            return line;
        }


        #region Parse GPS Strings
        /// <summary>
        /// Create a burst object out of the NMEA string
        /// </summary>
        /// <param name="sentence">the text string sentence</param>
        /// <returns>NmeaBurst containing the string information or null if invalid</returns>
        private bool ParseSentence(string sentence, ref NmeaBurst toFill)
        {
            OnStringReceived(sentence);

            bool? isValid = IsValidSentence(sentence);
            if (isValid != true)
            {
                if (InvalidStringFound != null && !_cancelled && !ignoreFirst)
                {
                    ignoreFirst = false;
                    InvalidStringFound();
                }
                return false;
            }

            OnValidStringReceived(sentence);

            string[] tokens = sentence.Split(',');
            string sType = tokens[0].Substring(3);

            tokens[tokens.Length - 1] = tokens[tokens.Length - 1].Substring(0, tokens[tokens.Length - 1].IndexOf('*'));

            NmeaString type = (NmeaString)Enum.Parse(typeof(NmeaString), sType, true);
            try
            {
                if (ParsingFunctions[type] != null)
                    ParsingFunctions[type].DynamicInvoke(tokens, toFill);
            }
            catch (KeyNotFoundException e)
            {
                throw new GpsAccessException("Function to handle burst type " + type.ToString() + " is missing.", e);
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "GpsAccess:ParseSentence", ex.StackTrace);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Parses a GSV sentence
        /// </summary>
        /// <param name="tokens">String tokens from the NMEA sentence</param>
        /// <param name="toFill">NmeaBurst to put the sentence data into</param>
        private void ParseGSV(String[] tokens, ref NmeaBurst toFill)
        {
            try
            {
                if (tokens[1] != String.Empty && toFill.totalGSV < 0)
                {
                    if (tokens[1].IsInteger())
                        toFill.totalGSV = Convert.ToInt32(tokens[1]);
                    if (tokens[3].IsInteger())
                        toFill._num_of_sat = Convert.ToInt32(tokens[3]);
                }

                for (int i = 4; i < tokens.Length - 4; i += 4)
                {
                    Satellite s = new Satellite();

                    if (tokens[i] != String.Empty)
                        s.ID = tokens[i];
                    if (tokens[i + 1].IsDouble())
                        s.Elevation = Convert.ToDouble(tokens[i + 1]);
                    if (tokens[i + 2].IsDouble())
                        s.Azimuth = Convert.ToDouble(tokens[i + 2]);
                    if (tokens[i + 3].IsDouble())
                        s.SNR = Convert.ToDouble(tokens[i + 3]);

                    toFill.AddSatalite(s);
                }

                toFill.countGSV++;

                //if all GSV sentences parsed mark as GSV completed
                if (toFill.countGSV >= toFill.totalGSV)
                    toFill.bGSV = true;
            }
            catch
            {
                toFill.BadData();
            }
        }

        private void ParseGSA(String[] tokens, ref NmeaBurst toFill)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                if (tokens[2].IsInteger())
                    toFill._fix = Convert.ToInt32(tokens[2]);

                for (int i = 3; i < 15; i++)
                {
                    if (tokens[i] != "")
                        sb.Append(tokens[i] + '_');
                }


                toFill._fixed_PRNs = sb.ToString();
                toFill._fixed_PRNs.TrimEnd('_');

                if (tokens[15].IsDouble())
                    toFill._PDOP = Convert.ToDouble(tokens[15]);
                if (tokens[16].IsDouble())
                    toFill._HDOP = Convert.ToDouble(tokens[16]);
                if (tokens[16].IsDouble())
                    toFill._VDOP = Convert.ToDouble(tokens[17]);

                toFill.bGSA = true;
            }
            catch
            {
                toFill.BadData();
            }
        }

        private void ParseGGA(String[] tokens, ref NmeaBurst toFill)
        {
            try
            {
                if (tokens[2].IsDouble())
                    toFill._GGA_latitude = Convert.ToDouble(tokens[2]);
                if (tokens[3] != String.Empty)
                    toFill._GGA_latDir = CoordConvert.ConvertNorthSouth(tokens[3]);// (NorthSouth)Enum.Parse(typeof(NorthSouth), tokens[3], true);
                if (tokens[4].IsDouble())
                    toFill._GGA_longitude = Convert.ToDouble(tokens[4]);
                if (tokens[5] != String.Empty)
                    toFill._GGA_longDir = CoordConvert.ConvertEastWest(tokens[5]);// (EastWest)Enum.Parse(typeof(EastWest), tokens[5], true);
                if (tokens[6].IsInteger())
                    toFill._fix_quality = Convert.ToInt32(tokens[6]);
                if (tokens[7].IsInteger())
                    toFill._num_of_used_sat = Convert.ToInt32(tokens[7]);
                if (tokens[8].IsDouble())
                    toFill._horiz_dilution_position = Convert.ToDouble(tokens[8]);
                if (tokens[9].IsDouble())
                    toFill._altitude = Convert.ToDouble(tokens[9]);
                if (tokens[10] != String.Empty)
                    toFill._alt_unit = TtUtils.ConvertUnit(tokens[10]);// (Unit)Enum.Parse(typeof(Unit), tokens[10], true);
                if (tokens[11].IsDouble())
                    toFill._geoid_height = Convert.ToDouble(tokens[11]);
                if (tokens[12] != String.Empty)
                    toFill._geoid_unit = TtUtils.ConvertUnit(tokens[12]);// (Unit)Enum.Parse(typeof(Unit), tokens[12], true);

                toFill.bGGA = true;
            }
            catch
            {
                toFill.BadData();
            }
        }

        /// <summary>
        /// Parses an RMC sentence which has the following format:
        /// RMC,225446,A,4916.45,N,12311.12,W,000.5,054.7,191194,020.3,E*68
        /// </summary>
        /// <param name="tokens">Tokens from the NMEA string in order </param>
        /// <param name="newNmeaBurst">NmeaBurst to add the data to </param>
        private void ParseRMC(String[] tokens, ref NmeaBurst toFill)
        {
            try
            {
                if (tokens[1] != string.Empty)
                {
                    if (tokens[1].Length > 6)
                        tokens[1] = tokens[1].Substring(0, 6);
                    toFill._time = DateTime.ParseExact(tokens[1], "HHmmss", System.Globalization.CultureInfo.CurrentCulture);
                }
                if (tokens[3].IsDouble())
                    toFill._RMC_latitude = Convert.ToDouble(tokens[3]);
                if (tokens[4] != String.Empty)
                    toFill._RMC_latDir = CoordConvert.ConvertNorthSouth(tokens[4]);// (NorthSouth)Enum.Parse(typeof(NorthSouth), tokens[4], true);
                if (tokens[5].IsDouble())
                    toFill._RMC_longitude = Convert.ToDouble(tokens[5]);
                if (tokens[6] != String.Empty)
                    toFill._RMC_longDir = CoordConvert.ConvertEastWest(tokens[6]);// (EastWest)Enum.Parse(typeof(EastWest), tokens[6], true);
                if (tokens[7].IsDouble())
                    toFill._track_angle = Convert.ToDouble(tokens[7]);
                if (tokens[8].IsDouble())
                    toFill._speed = Convert.ToDouble(tokens[8]);
                if (tokens[9] != String.Empty)
                {
                    if (tokens[9].Length > 6)
                        tokens[9] = tokens[9].Substring(0, 6);
                    toFill._date = DateTime.ParseExact(tokens[9], "ddMMyy", System.Globalization.CultureInfo.CurrentCulture);
                }
                if (tokens[10].IsDouble())
                    toFill._magVar = Convert.ToDouble(tokens[10]);
                if (tokens[11] != String.Empty)
                    toFill._magVarDir = CoordConvert.ConvertEastWest(tokens[11]);// (EastWest)Enum.Parse(typeof(EastWest), tokens[11], true);

                toFill.bRMC = true;
            }
            catch
            {
                toFill.BadData();
            }
        }

        #endregion

        /// <summary>
        /// Determines if a sentence is a valid NMEA string
        /// </summary>
        /// <param name="sentence">sentence to be validated</param>
        /// <returns>True if sentence is a valid NMEA string</returns>
        public static bool? IsValidSentence(string sentence)
        {
            //Make sure it starts w/ $GP
            if (sentence.Length < 7)
                return false;
            string stringType = sentence.Substring(0, 6);

            //Garmin proprietary strings, ignore data
            if (stringType.IndexOf("$PG") >= 0 || stringType.IndexOf("$PS") >= 0 || stringType.IndexOf("$HC") >= 0) 
                return null;
            if (!(stringType.IndexOf("$GP") == 0 || stringType.IndexOf("$GN") == 0)) //If its a partial string
                return false;

            stringType = stringType.Substring(3);
            int iChar, iLength;
            int uiChksum1, uiChksum2, CheckSum;

            iLength = sentence.Length;
            //Make sure there's a * for the CHKSUM value
            if (sentence[iLength - 3] != '*')
                return false;

            bool validStringType = false;
            
            //Compare to the string types that are wanted
            for (int i = 0; i < StringsToUse.Count; i++)
            {
                if (stringType == StringsToUse[i].ToString())
                {
                    validStringType = true;
                    break;
                }
            }
            if (!validStringType)
                return null;

            //ignore checksum
            //return true;

            uiChksum1 = sentence[iLength - 2] - 48;
            if (uiChksum1 > 9)
                uiChksum1 -= 7;

            uiChksum2 = sentence[iLength - 1] - 48;
            if (uiChksum2 > 9)
                uiChksum2 -= 7;

            uiChksum1 *= 16;

            uiChksum2 += uiChksum1;

            CheckSum = 0;
            iChar = 1;
            iLength -= 3;

            while (iChar < iLength)
            {
                CheckSum ^= sentence[iChar];
                iChar++;
            }

            if (uiChksum2 != CheckSum)
                return false;

            return true;
        }

        private void OnStringReceived(string sentence)
        {
            if (StringReceived != null)
                StringReceived(sentence);

            if (!LogOnlyValid && sw != null)
            {
                sw.WriteLine(sentence);
            }
        }

        private void OnValidStringReceived(string sentence)
        {
            if (ValidStringReceived != null)
                ValidStringReceived(sentence);

            if (LogOnlyValid && sw != null)
            {
                sw.WriteLine(sentence);
            }
        }

        private void OnBurstReceived(NmeaBurst burst)
        {
            if (LogToFile && sw != null)
            {
                sw.WriteLine(burst.ToString());
            }

            if (BurstReceived != null)
                BurstReceived(burst);
        }




#if (PocketPC || WindowsCE || Mobile)
        [DllImport("CoreDll.dll")]
        public static extern void SystemIdleTimerReset();

        private static int nDisableSleepCalls = 0;
        private static System.Threading.Timer preventSleepTimer = null;

        public static void DisableDeviceSleep()
        {
            nDisableSleepCalls++;
            if (nDisableSleepCalls == 1)
            {
                Debug.Assert(preventSleepTimer == null);
                // start a 30-second periodic timer
                preventSleepTimer = new System.Threading.Timer(new TimerCallback(PokeDeviceToKeepAwake),
                    null, 0, 30 * 1000);
            }
        }

        public static void EnableDeviceSleep()
        {
            nDisableSleepCalls--;
            if (nDisableSleepCalls == 0)
            {
                Debug.Assert(preventSleepTimer != null);
                if (preventSleepTimer != null)
                {
                    preventSleepTimer.Dispose();
                    preventSleepTimer = null;
                }
            }
        }

        private static void PokeDeviceToKeepAwake(object extra)
        {
            try
            {
                SystemIdleTimerReset();
            }
            catch (Exception e)
            {
                // TODO
            }
        }
#endif
    }

    class GpsAccessException : Exception
    {
        public GpsAccessException(string message, Exception e)
            : base(message, e)
        { }

    }


}