﻿// Try DllImport
//
// 2001-02-18   PV
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Runtime.InteropServices;
using static System.Console;

internal static class MyApp
{
    [DllImport("Kernel32", EntryPoint = "GetSystemDirectory", CharSet = CharSet.Unicode)]
    public static extern uint GSD(System.Text.StringBuilder str, int len);

    public static void Main()
    {
        System.Text.StringBuilder strb = new(500);
        _ = GSD(strb, strb.Capacity);

        WriteLine("SystemDirectory: <{0}>", strb);
        WriteLine("SystemDirectory: <{0}>", Environment.SystemDirectory);
    }
}

