// GetBuildVersion
// From https://www.codeproject.com/articles/73000/getting-operating-system-version-info-even-for-win
//
// 2017-01-05   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using Microsoft.Win32;
using System;
using static System.Console;

#pragma warning disable CA1416 // Validate platform compatibility

namespace CS605;

internal class Program
{
    private static void Main(string[] args)
    {
        var OSVer = Environment.OSVersion.Version;
        var BuildVersion = GetBuildVersion();

        WriteLine("OSVer: " + OSVer);
        WriteLine("Build Version: {0}", BuildVersion);
    }

    static public int GetBuildVersion() => int.Parse(RegistryRead(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuildNumber", "0"));

    private static string RegistryRead(string RegistryPath, string Field, string DefaultValue)
    {
        var rtn = "";
        var backSlash = "";
        var newRegistryPath = "";

        try
        {
            RegistryKey OurKey = null;
            var split_result = RegistryPath.Split('\\');

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
                    for (var i = 1; i < split_result.Length; i++)
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
