// Essai de DllImport
//
// 2001-02-18   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;
using System.Runtime.InteropServices;

internal class MyApp
{
    [DllImport("Kernel32", EntryPoint = "GetSystemDirectory")]
    public static extern uint GSD(System.Text.StringBuilder str, int len);

    public static void Main()
    {
        System.Text.StringBuilder strb = new(500);
        GSD(strb, strb.Capacity);

        Console.WriteLine("SystemDirectory: <{0}>", strb);
        Console.WriteLine("SystemDirectory: <{0}>", System.Environment.SystemDirectory);

        //Console.ReadLine();
    }
}