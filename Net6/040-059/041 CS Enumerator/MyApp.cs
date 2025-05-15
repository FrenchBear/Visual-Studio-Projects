// 041 CS Enumerator
// Construction de classes énumérables avec foreach en C#
// 2001-02-18   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010  Version 4 avec yield return
// 2021-09-18   PV  VS2022, Net6

using System.Collections;
using static System.Console;

internal static class MyApp
{
    public static void Main()
    {
        ThreeIntegers1 t1 = new(11, 12, 13);

        // Accès simple via foreach
        foreach (int i in t1)
            WriteLine(i);
        WriteLine();

        var e1 = t1.GetEnumerator();
        while (e1.MoveNext())
            WriteLine(e1.Current.ToString());
        WriteLine();

        ThreeIntegers2 t2 = new(21, 22, 23);

        // Accès simple via foreach
        foreach (int i in t2)
            WriteLine(i);
        WriteLine();

        var e2 = t2.GetDictionaryEnumerator();
        while (e2.MoveNext())
            WriteLine(e2.Key + " -> " + e2.Value);
        WriteLine();

        ThreeIntegers3 t3 = new(31, 32, 33);

        // Accès simple via foreach
        foreach (int i in t3)
            WriteLine(i);
        WriteLine();

        ThreeIntegers4 t4 = new(41, 42, 43);

        // Accès simple via foreach
        foreach (int i in t4)
            WriteLine(i);
        WriteLine();

        //Console.ReadLine();
    }
}