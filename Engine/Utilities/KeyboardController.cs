using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using TwoTrails.Engine;

#if (PocketPC || WindowsCE || Mobile)
using Microsoft.WindowsCE.Forms;
#endif

namespace TwoTrails.Utilities
{
    public static class Kb
    {
        [DllImport("coredll.dll")]
        private static extern bool SipGetInfo(ref SIPINFO pSipInfo);

        [DllImport("coredll.dll")]
        private static extern bool SipSetInfo(ref SIPINFO pSipInfo);

        private static void SetSipLocation(int x, int y)
        {
            Size size = GetSipSize();
            RECT bounds = new RECT();
            bounds.Left = x;
            bounds.Top = y;
            bounds.Right = bounds.Left + size.Width;
            bounds.Bottom = bounds.Top + size.Height;

            SIPINFO info = new SIPINFO();
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            SipGetInfo(ref info);
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            info.Rect = bounds;

            SipSetInfo(ref info);
        }

        private static Size GetSipSize()
        {
            Size size = new Size();
            SIPINFO info = new SIPINFO();
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            SipGetInfo(ref info);
            size = new Size(info.Rect.Right - info.Rect.Left, info.Rect.Bottom - info.Rect.Top);
            return size;
        }

        private static void ShowSIP()
        {
            SIPINFO info = new SIPINFO();
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            SipGetInfo(ref info);
            info.Flags |= SIPFlags.SIPF_ON;
            SipSetInfo(ref info);
        }

        private static void HideSIP()
        {
            SIPINFO info = new SIPINFO();
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            SipGetInfo(ref info);
            info.Flags &= ~SIPFlags.SIPF_ON;
            SipSetInfo(ref info);
        }

        private static void LockSIP()
        {
            SIPINFO info = new SIPINFO();
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            SipGetInfo(ref info);
            info.Flags |= SIPFlags.SIPF_LOCKED | SIPFlags.SIPF_DOCKED;
            SipSetInfo(ref info);
        }

        private static void UnlockSIP()
        {
            SIPINFO info = new SIPINFO();
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            SipGetInfo(ref info);
            info.Flags &= ~(SIPFlags.SIPF_LOCKED | SIPFlags.SIPF_DOCKED);
            SipSetInfo(ref info);
        }

        private static void SetSipLocation(Point pt)
        {
            SetSipLocation(pt.X, pt.Y);
        }



        public static void Show(UserControl parentControl, Control control)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                return;

            if (parentControl.TopLevelControl != null)
            {
                Type t = parentControl.TopLevelControl.GetType();

                if (t.BaseType == typeof(Form) || t == typeof(Form))
                    Show(parentControl.TopLevelControl as Form,
                        parentControl.Top + control.Top,
                        parentControl.Top + control.Bottom);
                else
                    Show(parentControl.TopLevelControl, parentControl.Top + control.Top,
                        parentControl.Top + control.Bottom);
            }
            else if (parentControl.Parent != null)
            {
                //Type t = parentControl.Parent.GetType();

                if (parentControl.Parent.GetType() == typeof(Form))
                    Show(parentControl.Parent as Form,
                        parentControl.Top + control.Top,
                        parentControl.Top + control.Bottom);
                else
                    Show(parentControl.Parent, parentControl.Top + control.Top,
                        parentControl.Top + control.Bottom);
            }
#endif
        }

        private static void Show(Control parentControl, int controlTop, int controlBottom)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (parentControl.TopLevelControl != null)
            {
                Type t = parentControl.TopLevelControl.GetType();

                if (t.BaseType == typeof(Form) || t == typeof(Form))
                    Show(parentControl.TopLevelControl as Form,
                        parentControl.Top + controlTop,
                        parentControl.Top + controlBottom);
                else
                    Show(parentControl.TopLevelControl, parentControl.Top + controlTop,
                        parentControl.Top + controlBottom);
            }
            else if (parentControl.Parent != null)
            {
                if (parentControl.Parent.GetType() == typeof(Form))
                    Show(parentControl.Parent as Form,
                        parentControl.Top + controlTop,
                        parentControl.Top + controlBottom);
                else
                    Show(parentControl.Parent, parentControl.Top + controlTop,
                        parentControl.Top + controlBottom);
            }
#endif
        }

        private static void Show(Form form, int controlTop, int controlBottom)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                return;

            SIPINFO info = new SIPINFO();
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            SipGetInfo(ref info);

            Size rSize = new Size(info.Rect.Right - info.Rect.Left, info.Rect.Bottom - info.Rect.Top);

            if ((form.Top + controlBottom + 20) >
                (form.Bottom - rSize.Height))
            {
                SetSipLocation(0, form.Top + controlTop - rSize.Height);
            }
            else
            {
                SetSipLocation(0, form.Bottom - rSize.Height);
            }

            ShowSIP();
#endif
        }

        public static void Show(Form form, Control control)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                return;

            SIPINFO info = new SIPINFO();
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            SipGetInfo(ref info);

            Size rSize = new Size(info.Rect.Right - info.Rect.Left, info.Rect.Bottom - info.Rect.Top);

            if ((form.Top + control.Bottom + 20) >
                (form.Bottom - rSize.Height))
            {
                SetSipLocation(0, form.Top + control.Top - rSize.Height);
            }
            else
            {
                SetSipLocation(0, form.Bottom - rSize.Height);
            }

            ShowSIP();
#endif
        }


        public static void Show(Form form)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                return;

            SIPINFO info = new SIPINFO();
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            SipGetInfo(ref info);

            Size rSize = new Size(info.Rect.Right - info.Rect.Left, info.Rect.Bottom - info.Rect.Top);

            
            SetSipLocation(0, form.Bottom - rSize.Height);

            ShowSIP();
#endif
        }

        public static void ShowOnTop(Form form)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                return;

            SIPINFO info = new SIPINFO();
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            SipGetInfo(ref info);

            Size rSize = new Size(info.Rect.Right - info.Rect.Left, info.Rect.Bottom - info.Rect.Top);

            SetSipLocation(0, form.Top);

            ShowSIP();
#endif
        }


        public static void Hide(Form form)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                return;

            Size size = GetSipSize();
            RECT bounds = new RECT();
            bounds.Left = 0;
            bounds.Top = form.Bottom - size.Height;
            bounds.Right = bounds.Left + size.Width;
            bounds.Bottom = bounds.Top + size.Height;

            SIPINFO info = new SIPINFO();
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            SipGetInfo(ref info);
            info.Size = (uint)Marshal.SizeOf(typeof(SIPINFO));
            info.Rect = bounds;
            info.Flags &= ~SIPFlags.SIPF_ON;

            SipSetInfo(ref info);
#endif
        }

        public static void Hide(UserControl control)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (control.TopLevelControl != null)
            {
                Type t = control.TopLevelControl.GetType();

                if (t.BaseType == typeof(Form) || t == typeof(Form))
                    Hide(control.TopLevelControl as Form);
                else
                    Hide(control.TopLevelControl);
            }
            else if (control.Parent != null)
            {
                if (control.Parent.GetType() == typeof(Form))
                    Hide(control.Parent as Form);
                else
                    Hide(control.Parent);
            }
#endif
        }

        private static void Hide(Control control)
        {
            #if (PocketPC || WindowsCE || Mobile)
            if (control.Parent.GetType() == typeof(Form))
                Hide(control.Parent as Form);
            else
                Hide(control.Parent);
            #endif
        }


        public static void ShowRegular(Form form)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                return;

            Show(form);
            if (_IsKeyNumeric)
                SetKeyboardToRegular();
#endif
        }

        public static void ShowRegular(UserControl parentControl, Control control)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                return;

            Show(parentControl, control);
            if (_IsKeyNumeric)
                SetKeyboardToRegular();
#endif
        }

        public static void ShowRegular(Form form, Control control)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                return;

            Show(form, control);
            if (_IsKeyNumeric)
                SetKeyboardToRegular();
#endif
        }


        public static void ShowNumeric(Form form)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                return;

            Show(form);
            if (!_IsKeyNumeric)
                SetKeyboardToNumeric();
#endif
        }

        public static void ShowNumeric(UserControl parentControl, Control control)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                return;

            Show(parentControl, control);
            if (!_IsKeyNumeric)
                SetKeyboardToNumeric();
#endif
        }

        public static void ShowNumeric(Form form, Control control)
        {
#if (PocketPC || WindowsCE || Mobile)
            if (!Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                return;

            Show(form, control);
            if (!_IsKeyNumeric)
                SetKeyboardToNumeric();
#endif
        }


        #region Old Keyboard Functions

        /// <summary>
        /// Function to show the windows mobile keyboard
        /// </summary>
        /// <param name="dwFlag">TRUE for up, FALSE for down</param>
        /// <returns></returns>
        [DllImport("coredll.dll")]
        private static extern bool SipShowIM(int dwFlag);

        [DllImport("coredll.dll")]
        private extern static IntPtr FindWindow(string wndClass, string caption);

        [DllImport("coredll.dll")]
        private extern static IntPtr GetWindow(IntPtr hWnd, int nType);

        [DllImport("coredll.dll")]
        private extern static int GetPixel(IntPtr hdc, int nXPos, int nYPos);

        [DllImport("coredll.dll")]
        private extern static void SetPixel(IntPtr hdc, int nXPos, int nYPos, int clr);

        [DllImport("coredll.dll")]
        private extern static IntPtr GetDC(IntPtr hWnd);

        [DllImport("coredll.dll")]
        private extern static void ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("coredll.dll")]
        private static extern bool SipSetCurrentIM(byte[] clsid);

        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int GW_CHILD = 5;
#if (PocketPC || WindowsCE || Mobile)
        private static bool _IsKeyNumeric;
#endif
        private static void ShowKeyboard()
        {
            if (Values.Settings.DeviceOptions.UseOnScreenKeyboard)
            {
                SipShowIM(1);
            }
        }

        private static void ShowKeyboardRegular()
        {
            if (Values.Settings.DeviceOptions.UseOnScreenKeyboard)
            {
                SipShowIM(1);
#if (PocketPC || WindowsCE || Mobile)
                if (_IsKeyNumeric)
                    SetKeyboardToRegular();
#endif
            }
        }

        private static void ShowKeyboardNumeric()
        {
            if (Values.Settings.DeviceOptions.UseOnScreenKeyboard)
            {
                SipShowIM(1);
#if (PocketPC || WindowsCE || Mobile)
                if (!_IsKeyNumeric)
                    SetKeyboardToNumeric();
#endif
            }
        }

        private static void HideKeyboard()
        {
            if (Values.Settings.DeviceOptions.UseOnScreenKeyboard)
                SipShowIM(0);
        }

        public static void SetKeyboardToRegularOverride()
        {
#if (PocketPC || WindowsCE || Mobile)
            SetKeyboardToRegular();
#endif
        }


#if (PocketPC || WindowsCE || Mobile)
        private static void SetKeyboardToRegular()
        {
            // Find the SIP window
            IntPtr hWnd = FindWindow("SipWndClass", null);
            // Go one level below as the actual SIP window is a child
            hWnd = GetWindow(hWnd, GW_CHILD);
            // Obtain its context and get a color sample
            // The premise here is that the numeric mode is controlled by a virtual button in the top left corner
            // Whenever the numeric mode is active, the button background will be of COLOR_WINDOW_TEXT
            IntPtr hDC = GetDC(hWnd);
            int pixel = GetPixel(hDC, 2, 2);
            // Notice that we cannot simply compare the color to the system color as the system color is 24 bit (or palette)
            // and the real color is dithered to 15-16 bits for most devices, so white (0xff, 0xff, 0xff) becomes
            // almost white (oxf8, 0xfc, 0xf8)

            // here we only want to simulate the click if the keyboard is in numeric mode, in 
            // which case the back color will be WindowText
            //int clrText = (SystemColors.Window.R) | (SystemColors.Window.G << 8) | (SystemColors.Window.B << 16);
            int clrText = (SystemColors.WindowText.R) | (SystemColors.WindowText.G << 8) | (SystemColors.WindowText.B << 16);

            SetPixel(hDC, 2, 2, clrText);
            int pixelNew = GetPixel(hDC, 2, 2);
            // Restore the original pixel
            SetPixel(hDC, 2, 2, pixel);

            if (pixel == pixelNew)
            {
                // Simulate stylus click
                Message msg = Message.Create(hWnd, WM_LBUTTONDOWN, new IntPtr(1), new IntPtr(0x00090009));
                MessageWindow.SendMessage(ref msg);
                msg = Message.Create(hWnd, WM_LBUTTONUP, new IntPtr(0), new IntPtr(0x00090009));
                MessageWindow.SendMessage(ref msg);
            }
            // Free resources
            ReleaseDC(hWnd, hDC);

            _IsKeyNumeric = false;
        }

        private static void SetKeyboardToNumeric()
        {
            // Find the SIP window
            IntPtr hWnd = FindWindow("SipWndClass", null);
            // Go one level below as the actual SIP window is a child
            hWnd = GetWindow(hWnd, GW_CHILD);
            // Obtain its context and get a color sample
            // The premise here is that the numeric mode is controlled by a virtual button in the top left corner
            // Whenever the numeric mode is active, the button background will be of COLOR_WINDOW_TEXT
            IntPtr hDC = GetDC(hWnd);
            int pixel = GetPixel(hDC, 2, 2);
            // Notice that we cannot simply compare the color to the system color as the system color is 24 bit (or palette)
            // and the real color is dithered to 15-16 bits for most devices, so white (0xff, 0xff, 0xff) becomes
            // almost white (oxf8, 0xfc, 0xf8)
            int clrText = (SystemColors.Window.R) | (SystemColors.Window.G << 8) | (SystemColors.Window.B << 16);
            SetPixel(hDC, 2, 2, clrText);
            int pixelNew = GetPixel(hDC, 2, 2);
            // Restore the original pixel
            SetPixel(hDC, 2, 2, pixel);

            if (pixel == pixelNew)
            {
                // Simulate stylus click
                Message msg = Message.Create(hWnd, WM_LBUTTONDOWN, new IntPtr(1), new IntPtr(0x00090009));
                MessageWindow.SendMessage(ref msg);
                msg = Message.Create(hWnd, WM_LBUTTONUP, new IntPtr(0), new IntPtr(0x00090009));
                MessageWindow.SendMessage(ref msg);
            }
            // Free resources
            ReleaseDC(hWnd, hDC);

            _IsKeyNumeric = true;
        }

        //http://stackoverflow.com/questions/1324559/
#endif

        #endregion
    }

    [Flags]
    public enum SIPFlags : uint
    {
        SIPF_OFF = 0x00000000,
        SIPF_ON = 0x00000001,
        SIPF_DOCKED = 0x00000002,
        SIPF_LOCKED = 0x00000004
    }

    public struct SIPINFO
    {
        /// <summary>
        /// Size, in bytes, of the SIPINFO structure. This member must be filled in by the application with the size of operator. Because the system can check the size of the structure to determine the operating system version number, this member allows for future enhancements to the SIPINFO structure while maintaining backward compatibility.
        /// </summary>
        public uint Size;
        /// <summary>
        /// Specifies flags representing state information of the software-based input panel. 
        /// </summary>
        public SIPFlags Flags;
        /// <summary>
        /// Rectangle, in screen coordinates, that represents the area of the desktop not obscured by the software-based input panel. If the software-based input panel is floating, this rectangle is equivalent to the working area. Full-screen applications that respond to software-based input panel size changes can set their window rectangle to this rectangle. If the software-based input panel is docked but does not occupy an entire edge, then this rectangle represents the largest rectangle not obscured by the software-based input panel. If an application wants to use the screen space around the software-based input panel, it needs to reference rcSipRect.
        /// </summary>
        public RECT RectVisibleDesktop;
        /// <summary>
        /// Rectangle, in screen coordinates of the window rectangle and not the client area, the represents the size and location of the software-based input panel. An application does not generally use this information unless it needs to wrap around a floating or a docked software-based input panel that does not occupy an entire edge.
        /// </summary>
        public RECT Rect;
        /// <summary>
        /// Specifies the size of the data pointed to by the pvImData member.
        /// </summary>
        public uint ImDataSize;
        /// <summary>
        /// Void pointer to IM-defined data. The IM calls the IInputMethod::GetImData and IInputMethod::SetImData methods to send and receive information from this structure. 
        /// </summary>
        public IntPtr ImData;
    }

    /*
    /// <summary>
    /// This structure contains information about the current state of the input panel, such as the input panel size, screen location, docked status, and visibility status.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct SIPINFO
    {
        /// <summary>
        /// Size, in bytes, of the SIPINFO structure. This member must be filled in by the application with the size of operator. Because the system can check the size of the structure to determine the operating system version number, this member allows for future enhancements to the SIPINFO structure while maintaining backward compatibility.
        /// </summary>
        public int cbSize;

        /// <summary>
        /// Specifies flags representing state information of the input panel. It is any combination of the following bit flags:
        /// Value               Description
        /// SIPF_DOCKED         The input panel is docked, or not floating.
        /// SIPF_LOCKED         The input panel is locked, meaning that the user cannot change its visible status.
        /// SIPF_OFF            The input panel is off, or not visible.
        /// SIPF_ON             The input panel is on, or visible.
        /// </summary>
        public uint fdwFlags;

        /// <summary>
        /// Rectangle, in screen coordinates, that represents the area of the desktop not obscured by the input panel. If the input panel is floating, this rectangle is equivalent to the working area. Full-screen applications that respond to input panel size changes can set their window rectangle to this rectangle. If the input panel is docked but does not occupy an entire edge, then this rectangle represents the largest rectangle not obscured by the input panel. If an application wants to use the screen space around the input panel, it needs to reference rcSipRect.
        /// </summary>
        public RECT rcVisibleDesktop;

        /// <summary>
        /// Rectangle, in screen coordinates of the window rectangle and not the client area, the represents the size and location of the input panel. An application does not generally use this information unless it needs to wrap around a floating or a docked input panel that does not occupy an entire edge.
        /// </summary>
        public RECT rcSipRect;

        /// <summary>
        /// Specifies the size of the data pointed to by the pvImData member.
        /// </summary>
        public uint dwImDataSize;

        /// <summary>
        /// Void pointer to input method (IM)-defined data. The IM calls the IInputMethod::GetImData and IInputMethod::SetImData methods to send and receive information from this structure. 
        /// </summary>
        public IntPtr pvImData;
    }
    */

    
    /// <summary>
    /// This structure defines the coordinates of the upper-left and lower-right corners of a rectangle. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        /// <summary>
        /// Specifies the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int Left;

        /// <summary>
        /// Specifies the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int Top;

        /// <summary>
        /// Specifies the x-coordinate of the lower-right corner of the rectangle. 
        /// </summary>
        public int Right;

        /// <summary>
        /// Specifies the y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public int Bottom;
    }
    
}

