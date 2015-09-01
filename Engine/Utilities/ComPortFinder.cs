using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using TwoTrails.Engine;
using TwoTrails.GpsAccess;

namespace TwoTrails.Utilities
{
    public class ComPortFinder : IDisposable
    {
        public enum DeviceType
        {
            GPS,
            Laser,
            Both
        }

        public struct SerialDevice
        {
            public bool Exists;
            public string Port;
            public int Baud;
            public bool Valid;
        }

        public static readonly int ReadTimeout = 2000;

        private SerialDevice[] _Devices;
        private bool[] _Completed;
        private string[] _PortNames;

        private bool _DeviceFound = false, _Cancel = false;
        private DeviceType _DevType;

        int time = 0;


        public ComPortFinder()
        {
            _DevType = DeviceType.GPS;
        }

        public ComPortFinder(DeviceType type)
        {
            _DevType = type;
        }

        public void Find()
        {
            Find(false);
        }

        public void Find(bool retry)
        {
            time = 0;
            _Devices = new SerialDevice[10];
            _Completed = new bool[10];

            _DeviceFound = _Cancel = false;

            _PortNames = SerialPort.GetPortNames();

            if (_PortNames.Count() < 1)
            {
                Thread.Sleep(500);
                _PortNames = SerialPort.GetPortNames();
            }

            for (int i = 0; i < _PortNames.Length; i++)
            {
                //RunCheck(i);
                ThreadPool.QueueUserWorkItem(new WaitCallback(RunCheck), i);
            }
            
            while(true)
            {
                if (_Completed.Where(x => x == true).Count() == _PortNames.Length)
                    break;

                Thread.Sleep(1000);
                time++;
            }

            _Cancel = true;

            if (time < 1 && !retry)
                Find(true);
        }

        public void FindNoThread()
        {
            _Devices = new SerialDevice[10];
            _Completed = new bool[10];

            _DeviceFound = _Cancel = false;

            _PortNames = SerialPort.GetPortNames();

            if (_PortNames.Count() < 1)
            {
                Thread.Sleep(500);
                _PortNames = SerialPort.GetPortNames();
            }

            for (int i = 0; i < _PortNames.Length; i++)
            {
                RunCheck(i);
            }
        }

        public void RunCheck(object stateinfo)
        {
            int num = (int)stateinfo;

            SerialDevice device = new SerialDevice()
            {
                Exists = false,
                Port = _PortNames[num],
                Baud = 4800,
                Valid = false
            };

            try
            {
                lock (_Devices)
                {
                    _Devices[num] = device;
                }

                SerialPort _port = new SerialPort(device.Port, device.Baud);
                _port.Parity = Parity.None;
                _port.StopBits = StopBits.One;
                _port.DataBits = 8;
                //_port.Handshake = Handshake.None;
                _port.ReadTimeout = ReadTimeout;

                for (int i = 0; i < 8; i++)
                {
                    if (_DeviceFound || _Cancel)
                        break;

                    try
                    {
                        device.Baud = Values.DEFAULT_BAUD_VALUES_ORDERED[i];
                        _port.BaudRate = device.Baud;
                        System.Windows.Forms.Application.DoEvents();

                        if (!_port.IsOpen)
                        {
                            _port.Open();
                            Thread.Sleep(500);
                        }

                        string sentence = _port.ReadLine().Trim();
                        sentence = ReadPort(_port);    //ignore first sentence

                        device.Exists = true;

                        int validCount = 0;
                        for (int j = 0; j < 10; j++)
                        {
                            if (_Cancel)
                                break;

                            if (_DevType != DeviceType.Laser)
                            {
                                if (GpsAccess.GpsAccess.IsValidSentence(sentence) == true)
                                    validCount++;
                            }
                            
                            if(_DevType != DeviceType.GPS)
                            {
                                if (LaserAccess.LaserAccess.IsValidSentence(sentence) == true)
                                    validCount++;
                            }

                            sentence = ReadPort(_port);
                        }

                        if (validCount > 4)
                        {
                            device.Valid = true;
                            _DeviceFound = true;
                        }
                    }
                    catch (TimeoutException toEx)
                    {
                        TtUtils.WriteError(String.Format("{0}|{2}to:{1}", device.Port, toEx.Message, device.Baud), "autofind");
                    }
                    catch (System.IO.IOException ioEx)
                    {
                        TtUtils.WriteError(String.Format("{0}|{2}io:{1}", num, ioEx.Message, device.Baud), "autofind");
                        break;
                    }
                    catch (Exception ex)
                    {
                        TtUtils.WriteError(String.Format("{0}|{2}:{1}", num, ex.Message, device.Baud), "autofind");
                        break;
                    }
                    finally
                    {
                        _port.Close();
                    }

                    if (device.Valid)
                        break;
                }

            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "ComPortFinder:RunCheck");
            }

            lock (_Devices)
            {
                _Devices[num] = device;
            }

            lock (_Completed)
            {
                _Completed[num] = true;
            }
        }

        private string ReadPort(SerialPort port)
        {
            Thread.Sleep(250);
            return port.ReadLine().Trim();
        }

        public List<SerialDevice> GetValidDevices()
        {
            return _Devices.Where(d => d.Valid).ToList();
        }

        public void Dispose()
        {

        }
    }
}
