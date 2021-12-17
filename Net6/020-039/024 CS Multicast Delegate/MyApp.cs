// 24 C# Multicast Delegate
// Essais de combinaison de delegates Multicast
//
// 2001-01-27   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;
using static System.Console;

internal delegate void MyDelegate(string sMsg);

internal class MyApp
{
    public static void Main()
    {
        MyDelegate d1, d2, d3;

        d1 = new MyDelegate(Sub1);
        d2 = new MyDelegate(Sub2);
        d3 = (MyDelegate)Delegate.Combine(d1, d2);

        d1("Hello 1");
        d2("Hello 2");
        d3("Hello 3");

        _ = Console.ReadLine();
    }

    private static void Sub1(string s) => WriteLine("Sub1: " + s);

    private static void Sub2(string s) => WriteLine("Sub2: " + s);
}