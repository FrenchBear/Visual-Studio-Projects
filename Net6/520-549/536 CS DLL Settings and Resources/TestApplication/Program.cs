﻿// 536 CS DLL Settings and Resources
// Demo app to retrieve appSettings and applicationSettings from config file of an application and a dll
//
// 2015-10-01   FPVI
// 2021-09-26   PV      VS2022; Net6

using ArithmeticNamespace;
using System;
using System.Configuration;
using static System.Console;

namespace TestApplication;

internal class Program
{
    private static void Main(string[] args)
    {
        ArithmeticClass a = new();

        WriteLine("App appSetting:  " + GetAppSetting("MyAppSetting"));
        WriteLine("App Typed applicationSetting: " + Properties.Settings.Default.MyApplicationSetting);
        WriteLine("DLL applicationSetting:  " + a.GetApplicationSetting("MySettingString"));
        WriteLine("DLL Typed applicationSetting:  " + a.GetTypedApplicationSetting("MySettingString"));
        WriteLine("DLL appSetting:  " + a.GetAppSetting("MyDLLAppSetting"));
        WriteLine("DLL Resource String: " + a.GetStringResource("MyResourceString"));
    }

    // Add System.Configuration .dll reference and namespace
    // AppSettings only works for simple appSettings element in App.Config, that
    // is much simpler than applicationSettings section
    private static string GetAppSetting(string settingName) => ConfigurationManager.AppSettings[settingName];
}