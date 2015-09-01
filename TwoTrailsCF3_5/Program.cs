using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using TwoTrails.Forms;
using System.IO;

namespace TwoTrails
{
    public static class Program
    {
        public static bool Reload = false;
        public static String Filename = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            bool exit = false;

            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                if (args.Length > 0)
                {
                    if (arg[0] == '/')
                    {
                        switch (arg.Substring(1).ToLower())
                        {
                            case "clear":
                                {
                                    Directory.Delete("bin", true);
                                    exit = true;
                                }
                                break;
                        }
                    }
                    else
                    {
                        if (!File.Exists(arg))
                            Filename = arg;
                    }
                }
            }

            if (exit)
                return;

            do
            {
                Reload = false;
                Application.Run(new MainForm());
            } while (Reload);
        }
    }

}