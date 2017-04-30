// GetBuildVersion
// From https://www.codeproject.com/articles/73000/getting-operating-system-version-info-even-for-win
// 2017-01-05   PV

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Version OSVer = Environment.OSVersion.Version;
            int BuildVersion = GetBuildVersion();

            WriteLine("OSVer: " + OSVer.ToString());
            WriteLine("Build Version: {0}", BuildVersion);


            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        static public int GetBuildVersion()
        {
            return int.Parse(RegistryRead(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuildNumber", "0"));
        }

        private static string RegistryRead(string RegistryPath, string Field, string DefaultValue)
        {
            string rtn = "";
            string backSlash = "";
            string newRegistryPath = "";

            try
            {
                RegistryKey OurKey = null;
                string[] split_result = RegistryPath.Split('\\');

                if (split_result.Length > 0)
                {
                    split_result[0] = split_result[0].ToUpper();        // Make the first entry uppercase...

                    if (split_result[0] == "HKEY_CLASSES_ROOT") OurKey = Registry.ClassesRoot;
                    else if (split_result[0] == "HKEY_CURRENT_USER") OurKey = Registry.CurrentUser;
                    else if (split_result[0] == "HKEY_LOCAL_MACHINE") OurKey = Registry.LocalMachine;
                    else if (split_result[0] == "HKEY_USERS") OurKey = Registry.Users;
                    else if (split_result[0] == "HKEY_CURRENT_CONFIG") OurKey = Registry.CurrentConfig;

                    if (OurKey != null)
                    {
                        for (int i = 1; i < split_result.Length; i++)
                        {
                            newRegistryPath += backSlash + split_result[i];
                            backSlash = "\\";
                        }

                        if (newRegistryPath != "")
                        {
                            //rtn = (string)Registry.GetValue(RegistryPath, "CurrentVersion", DefaultValue);

                            OurKey = OurKey.OpenSubKey(newRegistryPath);
                            rtn = (string)OurKey.GetValue(Field, DefaultValue);
                            OurKey.Close();
                        }
                    }
                }
            }
            catch { }

            return rtn;
        }
    }
}
