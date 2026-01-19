// 2001 PV
//
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System;

internal static class MyApp
{
    public static void Main()
    {
        CS039Lib.MyLib m = new();
        m.Test();
        _ = Console.ReadLine();
    }
}
