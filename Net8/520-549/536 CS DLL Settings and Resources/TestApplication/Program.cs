// 536 CS DLL Settings and Resources
// Demo app to retrieve appSettings and applicationSettings from config file of an application and a dll
//
// 2015-10-01   FPVI
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using ArithmeticNamespace;
using System.Configuration;
using static System.Console;

namespace CS536D;

internal class Program
{
    private static void Main(string[] args)
    {
        ArithmeticClass a = new();

        WriteLine("App appSetting:  " + GetAppSetting("MyAppSetting"));
        WriteLine("App Typed applicationSetting: " + Properties.Settings.Default.MyApplicationSetting);
        WriteLine("DLL applicationSetting:  " + a.GetApplicationSetting("MySettingString"));
        WriteLine("DLL Typed applicationSetting:  " + ArithmeticClass.GetTypedApplicationSetting("MySettingString"));
        WriteLine("DLL appSetting:  " + a.GetAppSetting("MyDLLAppSetting"));
        WriteLine("DLL Resource String: " + ArithmeticClass.GetStringResource("MyResourceString"));
    }

    // Add System.Configuration .dll reference and namespace
    // AppSettings only works for simple appSettings element in App.Config, that
    // is much simpler than applicationSettings section
    private static string GetAppSetting(string settingName) => ConfigurationManager.AppSettings[settingName];
}
