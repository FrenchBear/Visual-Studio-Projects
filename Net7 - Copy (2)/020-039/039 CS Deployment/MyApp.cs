﻿// 2001 PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6
// 2023-01-10	PV		Net7

using System;

internal static class MyApp
{
    static public void Main()
    {
        CS039Lib.MyLib m = new();
        m.Test();
        _ = Console.ReadLine();
    }
}
