// 38 C# tableaux
// Essais sur la création dynamique de tableaux
//
// 2001-02-08   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;
using static System.Console;

internal static class MyApp
{
    public static void Main()
    {
        var t1 = new int[10];

        int[] t2 =
        {
            1,2,3,4,5
        };

        var t3 = new int[]
        {
          1,2,3,4,5
        };

        unchecked
        {
            var a = 500000;
            var b = 400000;
            t1[0] = a * b;
        }
        WriteLine("t1[0]: {0}", t1[0]);

        object[] u1;
        u1 = null;
        WriteLine("u1==null: {0}", u1 == null);

        u1 = new object[10];
        WriteLine("u1[0]==null: {0}", u1[0] == null);

        u1[0] = new object();
        WriteLine("u1[0]==null: {0}", u1[0] == null);

        _ = Console.ReadLine();
    }
}