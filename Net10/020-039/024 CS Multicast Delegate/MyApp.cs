// 24 C# Multicast Delegate
// Essais de combinaison de delegates Multicast
//
// 2001-01-27   PV
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System;
using static System.Console;

internal delegate void MyDelegate(string sMsg);

internal static class MyApp
{
    public static void Main()
    {
        //MyDelegate d1, d2, d3;

        var d1 = new MyDelegate(Sub1);
        var d2 = new MyDelegate(Sub2);
        var d3 = (MyDelegate)Delegate.Combine(d1, d2);

        d1("Hello 1");
        d2("Hello 2");
        d3("Hello 3");

        _ = ReadLine();
    }

    private static void Sub1(string s) => WriteLine("Sub1: " + s);

    private static void Sub2(string s) => WriteLine("Sub2: " + s);
}
