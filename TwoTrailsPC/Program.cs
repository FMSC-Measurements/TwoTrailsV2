using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TwoTrails.Forms;
using System.IO;
using TwoTrails.Utilities;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;

namespace TwoTrails
{
    public static class Program
    {
        //Program Assembly GUID
        static String AppID = Assembly.GetExecutingAssembly().GetType().GUID.ToString();
        static Mutex mutex = new Mutex(true, AppID);

        public static bool Reload = false;
        public static String Filename = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool exit = false, fix = false, upgrade = false;

            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string arg = args[i];

                    if (arg[0] == '/' || arg[0] == '-')
                    {
                        switch (arg.Substring(1).ToLower())
                        {
                            case "install":
                                {
                                    if (!FileAssociation.IsAssociated(".tt2"))
                                    {
                                        string currExe = Path.Combine(Directory.GetCurrentDirectory(), "TwoTrails.exe");
                                        FileAssociation.Associate(".tt2", "TwoTrails V2",
                                            "TwoTrails V2 File", currExe + ",1", currExe);
                                    }
                                    
                                    FileAssociation.NotifyIconChange();
                                    exit = true;
                                }
                                break;
                            case "clear":
                            case "uninstall":
                                {
                                    Directory.Delete("bin", true);
                                    exit = true;
                                }
                                break;
                            case "fix":
                                {
                                    fix = true;
                                    exit = true;
                                }
                                break;
                            case "upgrade":
                                {
                                    upgrade = true;
                                    exit = true;
                                }
                                break;
                        }
                    }
                    else
                    {
                        if (File.Exists(arg))
                        {
                            Filename = arg;
                        }
                    }
                }

                if (!Filename.IsEmpty())
                {
                    if (fix)
                    {
                        if (TtUtils.FixFile(Filename))
                        {
                            Console.WriteLine("File fixed.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to fix file.");
                        }
                    }
                    else if (upgrade)
                    {
                        try
                        {
                            DataAccess.DataAccessLayer dal = new DataAccess.DataAccessLayer(Filename);

                            if (dal.DalVersion < DataAccess.TwoTrailsSchema.SchemaVersion)
                            {
                                string nFileName = String.Format("{0}_upgrade.tt2",
                                    Path.GetFileNameWithoutExtension(Filename));

                                DataAccess.DataAccessLayer dalUpgrade = BusinessLogic.NewOpenLogic.NewTwoTrailsFile(nFileName);
                                if(dalUpgrade != null)
                                {
                                    dalUpgrade.OpenDAL();
                                    if (dalUpgrade.IsOpen)
                                    {
                                        if (dalUpgrade.Upgrade(dal))
                                            Console.WriteLine("File Upgraded");
                                        else
                                            throw new Exception("Upgrade task failed.");
                                    }
                                }
                                else
                                    throw new Exception("upgrade file did not open");
                            }
                            else if (dal.DalVersion > DataAccess.TwoTrailsSchema.SchemaVersion)
                            {
                                Console.WriteLine(String.Format("This project file ({0}) is newer than this version of TwoTrails. Please Update TwoTrails to the newest version.", dal.DalVersion));
                            }
                            else
                                Console.WriteLine(String.Format("TwoTrails file is already up to date. ({0})", DataAccess.TwoTrailsSchema.SchemaVersion));
                        }
                        catch (Exception ex)
                        {
                            TtUtils.WriteError(ex.Message, "Program:Upgrade", ex.StackTrace);
                            Console.WriteLine("Failed to upgrade.");
                        }
                    }
                }
            }



            if (exit)
            {
                return;
            }

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

#if !DEBUG
                using (SplashScreen s = new SplashScreen())
                {
                    s.ShowDialog();
                }
#endif

                do
                {
                    Reload = false;
                    Application.Run(new MainForm());
                } while (Reload);
            }
            else
            {
                // send our Win32 message to make the currently running instance
                // jump on top of all the other windows
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }

        }
    }

    // this class just wraps some Win32 stuff that we're going to use
    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}
