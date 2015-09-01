using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace TwoTrails.Utilities
{
    public static class Platform
    {
        [DllImport("coredll.dll")]
        private static extern int SystemParametersInfo(uint uiAction, uint uiParam, StringBuilder pvParam, uint fWiniIni);

        private const uint SPI_GETPLATFORMTYPE = 257;
        private const uint SPI_GETOEMINFO = 258;

        private static string GetSystemParameter(uint uiParam)
        {
            StringBuilder sb = new StringBuilder(128);
            if (SystemParametersInfo(uiParam, (uint)sb.Capacity, sb, 0) == 0)
                throw new ApplicationException("Failed to get system parameter");
            return sb.ToString();
        }

        public static string GetPlatformType()
        {
            return GetSystemParameter(SPI_GETPLATFORMTYPE);
        }

        public static string GetOEMInfo()
        {
            return GetSystemParameter(SPI_GETOEMINFO);
        }

        // Returns true if the device has a cellular radio
        public static bool GetHasRadio()
        {
            return File.Exists(@"\Windows\Phone.dll");
        }


        // Returns true if the application is running on a
        // desktop version of the Windows operating system
        public static bool IsDesktopWindows
        {
            get { return Environment.OSVersion.Platform != PlatformID.WinCE; }
        }

        // Returns true if the application is running on a
        // device powered by some form of WIndows CE based
        // operating system
        public static bool IsWindowsCE
        {
            get { return Environment.OSVersion.Platform == PlatformID.WinCE; }
        }

        // Returns true if the application is running on a
        // windows mobile device
        public static bool IsWindowsMobile
        {
            get { return (IsWindowsMobileStandard || IsWindowsMobileClassic || IsWindowsMobileProfessional); }
        }

        // Returns true if the application is running on a
        // Windows Mobile Standard (i.e. Smartphone) device
        public static bool IsWindowsMobileStandard
        {
            get { return IsWindowsCE && (GetPlatformType() == "SmartPhone"); }
        }

        // Returns true if the application is running on a
        // Windows Mobile Classic (i.e. Pocket PC without
        // cellphone) device.
        public static bool IsWindowsMobileClassic
        {
            get { return IsWindowsCE && !GetHasRadio() && (GetPlatformType() == "PocketPC"); }
        }

        // Returns true if the application is running on a
        // Windows Mobile Professional (i.e. Pocket PC with
        // cellphone) device.
        public static bool IsWindowsMobileProfessional
        {
            get { return IsWindowsCE && GetHasRadio() && (GetPlatformType() == "PocketPC"); }
        }

        // Returns true if the application is running
        // within the Device Emulator on a desktop machine
        public static bool IsEmulator
        {
            get { return IsWindowsCE && (GetOEMInfo() == "Microsoft DeviceEmulator"); }
        }
    }
}

/***
http://social.msdn.microsoft.com/Forums/en-US/a2bb8b9d-3b33-4f43-81cd-49e685d20f11/how-to-get-device-information
***/