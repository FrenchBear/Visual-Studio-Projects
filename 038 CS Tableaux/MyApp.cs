// 38 C# tableaux
// Essais sur la cr�ation dynamique de tableaux
// 2001-02-08   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

internal class MyApp
{
    public static void Main()
    {
        int[] t1;
        t1 = new int[10];

        int[] t2 =
        {
            1,2,3,4,5
        };

        int[] t3 = new int[]
        {
          1,2,3,4,5
        };

        unchecked
        {
            int a = 500000;
            int b = 400000;
            t1[0] = a * b;
        }
        Console.WriteLine("t1[0]: {0}", t1[0]);

        object[] u1;
        u1 = null;
        Console.WriteLine("u1==null: {0}", u1 == null);

        u1 = new Object[10];
        Console.WriteLine("u1[0]==null: {0}", u1[0] == null);

        u1[0] = new Object();
        Console.WriteLine("u1[0]==null: {0}", u1[0] == null);

        Console.ReadLine();
    }
}