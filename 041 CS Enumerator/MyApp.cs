// 041 CS Enumerator
// Construction de classes énumérables avec foreach en C#
// 2001-02-18   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010  Version 4 avec yield return

using System;
using System.Collections;

class MyApp
{
    public static void Main()
    {
        ThreeIntegers1 t1 = new ThreeIntegers1(11, 12, 13);

        // Accès simple via foreach
        foreach (int i in t1)
            Console.WriteLine(i);
        Console.WriteLine();

        IEnumerator e1 = t1.GetEnumerator();
        while (e1.MoveNext())
            Console.WriteLine(e1.Current.ToString());
        Console.WriteLine();



        ThreeIntegers2 t2 = new ThreeIntegers2(21, 22, 23);

        // Accès simple via foreach
        foreach (int i in t2)
            Console.WriteLine(i);
        Console.WriteLine();

        IDictionaryEnumerator e2 = t2.GetDictionaryEnumerator();
        while (e2.MoveNext())
            Console.WriteLine(e2.Key.ToString() + " -> " + e2.Value);
        Console.WriteLine();



        ThreeIntegers3 t3 = new ThreeIntegers3(31, 32, 33);

        // Accès simple via foreach
        foreach (int i in t3)
            Console.WriteLine(i);
        Console.WriteLine();



        ThreeIntegers4 t4 = new ThreeIntegers4(41, 42, 43);

        // Accès simple via foreach
        foreach (int i in t4)
            Console.WriteLine(i);
        Console.WriteLine();



        Console.ReadLine();
    }
}
