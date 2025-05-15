// 041 CS Enumerator
// Construction de classes énumérables avec foreach en C#
// 2001-02-18   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010  Version 4 avec yield return

using System;
using System.Collections;
using System.Linq;

internal class MyApp
{
    public static void Main()
    {
        var t1 = new ThreeIntegers1(11, 12, 13);

        // Accès simple via foreach
        foreach (int i in t1)
            Console.WriteLine(i);
        Console.WriteLine();

        IEnumerator e1 = t1.GetEnumerator();
        while (e1.MoveNext())
            Console.WriteLine(e1.Current.ToString());
        Console.WriteLine();

        var t2 = new ThreeIntegers2(21, 22, 23);

        // Accès simple via foreach
        foreach (int i in t2)
            Console.WriteLine(i);
        Console.WriteLine();

        IDictionaryEnumerator e2 = t2.GetDictionaryEnumerator();
        while (e2.MoveNext())
            Console.WriteLine(e2.Key.ToString() + " -> " + e2.Value);
        Console.WriteLine();

        var t3 = new ThreeIntegers3(31, 32, 33);

        // Accès simple via foreach
        foreach (int i in t3)
            Console.WriteLine(i);
        Console.WriteLine();

        var t4 = new ThreeIntegers4(41, 42, 43);

        // Accès simple via foreach
        foreach (int i in t4.Cast<int>())
            Console.WriteLine(i);
        Console.WriteLine();

        Console.ReadLine();
    }
}