// 401 CS SortedSet
// Tests with new generic structure SortedSet of .Net Framework 4
// 2010-02-24 FPVI

using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        // petit est présent deux fois
        SortedSet<string> myStringSet = new SortedSet<string>(new string[] { "Il", "était", "un", "petit", "petit", "navire" });

        foreach (string s in myStringSet)
        {
            Console.Write(s);
            Console.Write(" ");
        }
        Console.WriteLine();

        Console.WriteLine();
        Console.Write("(pause)");
        Console.ReadLine();
    }
}