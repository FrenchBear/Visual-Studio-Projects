// 24 C# Multicast Delegate
// Essais de combinaison de delegates Multicast
// 2001-01-27   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;

internal delegate void MyDelegate(string sMsg);

internal class MyApp
{
    public static void Main()
    {
        MyDelegate d1, d2, d3;

        d1 = new MyDelegate(Sub1);
        d2 = new MyDelegate(Sub2);
        d3 = (MyDelegate)System.Delegate.Combine(d1, d2);

        d1("Hello 1");
        d2("Hello 2");
        d3("Hello 3");

        Console.ReadLine();
    }

    private static void Sub1(string s) => Console.WriteLine("Sub1: " + s);

    private static void Sub2(string s) => Console.WriteLine("Sub2: " + s);
}