using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.IO.Ports;
using TwoTrails.LaserAccess;
using TwoTrails.Utilities;
using TwoTrails.Engine;
using System.Threading;
using TwoTrails.BusinessObjects;

namespace TwoTrails.LaserAccess
{
    public enum LaserErrorType
    {
        NoError,
        ComNotExist,
        UnknownError,
        LaserTimeout
    };

    public partial class LaserAccess : Component
    {

        #region Events

        public delegate void DelegateDeliverData(LaserData ld);
        public event DelegateDeliverData DataReceived;

        public delegate void DelegateLaserStarted();
        public event DelegateLaserStarted LaserStarted;

        public delegate void DelegateLaserEnded();
        public event DelegateLaserEnded LaserEnded;

        public delegate void DelegateInvalidStringFound();
        public event DelegateInvalidStringFound InvalidStringFound;

        public delegate void DelegateLaserError();
        public event DelegateLaserError LaserError;

        #endregion


        private SerialPort _port;
        public int Rate;
        public string Port;

        private bool _cancelled = false;
        private bool _busy = false;
        
        public LaserErrorType Error = LaserErrorType.NoError;

        public LaserAccess()
        {
            InitializeComponent();
        }

        public LaserAccess(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        private void InitializeLaserVariables()
        {

        }

        public void OpenLaser(string port, int rate)
        {
            if (_busy)
                return;
            _busy = true;
            _cancelled = false;
            Port = port;
            Rate = rate;
            ThreadPool.QueueUserWorkItem(new WaitCallback(LaserWorker), null);
        }

        public void OpenLaser()
        {
            if (_busy)
                return;
            _busy = true;
            _cancelled = false;
            ThreadPool.QueueUserWorkItem(new WaitCallback(LaserWorker));
        }

        public void CloseLaser()
        {
            _cancelled = true;
        }

        private void CloseLaserPort()
        {
            if (_port != null)
                _port.Close();
            _busy = false;
        }

        //Laser Connection and Read
        private void LaserWorker(object o)
        {
            try
            {
                _port = new SerialPort(Port, Rate);
                _port.Parity = Parity.None;
                _port.StopBits = StopBits.One;
                _port.DataBits = 8;
                _port.Handshake = Handshake.None;
                _port.ReadTimeout = Values.Settings.DeviceOptions.LaserTimeout;

                //if (!TtUtils.SerialPortTester.SerialPortTest(Port))
                //    throw new TimeoutException("SerialPortTest Failed");

                _port.Open();

                #region Trigger Event
                //Trigger Event
                if (LaserStarted != null)
                {
                    LaserStarted();
                }
                #endregion

                while (true)
                {
                    if (_cancelled)
                    {
                        CloseLaserPort();
                        #region Trigger Event
                        //Trigger Event
                        if (LaserEnded != null)
                        {
                            LaserEnded();
                        }
                        #endregion
                        return;
                    }

                    string sentence = _port.ReadLine();
                      
                    sentence = sentence.Trim();

                    LaserData ld = new LaserData();
                    if (ParseSentence(sentence, ref ld))
                    {
                        #region Trigger BurstReceived Event
                        if (DataReceived != null && ld != null && !_cancelled && ld.goodData)
                        {
                            DataReceived(ld);
                            //_cancelled = true;
                        }
                        #endregion
                    }
                }
            }
            #region Exceptions
            catch (TimeoutException toEx)
            {
                TtUtils.WriteError(toEx.Message, "LaserAccess:LaserWorker-toEx", toEx.StackTrace);

                #region trigger Error event
                Error = LaserErrorType.LaserTimeout;
                if (LaserError != null)
                    LaserError();
                #endregion
                CloseLaserPort();
            }
            catch (System.IO.IOException ioEx)
            {
                TtUtils.WriteError(ioEx.Message, "LaserAccess:LaserWorker-ioEx", ioEx.StackTrace);

                #region trigger Error event
                Error = LaserErrorType.ComNotExist;
                if (LaserError != null)
                    LaserError();
                #endregion
                CloseLaserPort();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "LaserAccess:LaserWorker-ex", ex.StackTrace);

                #region trigger Error event
                Error = LaserErrorType.UnknownError;
                if (LaserError != null)
                    LaserError();
                #endregion
                CloseLaserPort();
            }
            #endregion
        }

        private bool ParseSentence(string sentence, ref LaserData toFill)
        {
            if (!IsValidSentence(sentence))
            {
                if (InvalidStringFound != null && !_cancelled)
                {
                    InvalidStringFound();
                }
                return false;
            }

            return ParseLaserData(sentence, ref toFill);
        }

        private bool ParseLaserData(string sentence, ref LaserData toFill)
        {
            string[] tokens = sentence.Substring(0, sentence.Length - 3).Split(',');

            LaserData ld = new LaserData();

            try
            {
                if (tokens[1] != String.Empty)
                    ld._horizontal_vector_message = tokens[1];
                if (tokens[2] != String.Empty)
                    ld._horizontal_dist = Convert.ToDouble(tokens[2]);
                if (tokens[3] != String.Empty)
                    ld._horizontal_dist_unit = TtUtils.ConvertUnit(tokens[3]); //(Unit)Enum.Parse(typeof(Unit), tokens[3], true);
                if (tokens[4] != String.Empty)
                    ld._azimuth = Convert.ToDouble(tokens[4]);
                if (tokens[6] != String.Empty)
                    ld._inclination = Convert.ToDouble(tokens[6]);
                if (tokens[8] != String.Empty)
                    ld._slope = Convert.ToDouble(tokens[8]);
                if (tokens[9] != String.Empty)
                    ld._slope_unit = TtUtils.ConvertUnit(tokens[9]); //(Unit)Enum.Parse(typeof(Unit), tokens[9], true);

                ld.goodData = true;
                toFill = ld;
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool IsValidSentence(string sentence)
        {
            if (sentence.Length < 7)
                return false;
            string stringType = sentence.Substring(0, 6);
            if (stringType.IndexOf("$PL") != 0) //If its a partial string
                return false;
            stringType = stringType.Substring(3);
            int iChar, iLength;
            int uiChksum1, uiChksum2, CheckSum;

            iLength = sentence.Length;
            //Make sure there's a * for the CHKSUM value
            if (sentence[iLength - 3] != '*')
                return false;

            #region checksum
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
            #endregion

            return true;
        }

        public bool IsBusy
        {
            get
            {
                return _busy;
            }
        }



        #region Exceptions
        class LaserAccessException : Exception
        {
            public LaserAccessException(string message, Exception e)
                : base(message, e) { }
        }

        class LaserAccessTimeoutException : LaserAccessException
        {
            public LaserAccessTimeoutException(string message, Exception e)
                : base(message, e) { }

            public LaserAccessTimeoutException()
                : base("Laser port timed out.", new Exception()) { }
        }
        #endregion
    }
}
