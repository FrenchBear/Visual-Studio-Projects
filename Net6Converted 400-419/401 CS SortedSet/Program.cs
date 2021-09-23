// 401 CS SortedSet
// Tests with new generic structure SortedSet of .Net Framework 4
//
// 2010-02-24   PV
// 2021-09-23   PV  VS2022; Net6

using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        // petit est présent deux fois
        SortedSet<string> myStringSet = new(new string[] { "Il", "était", "un", "petit", "petit", "navire" });

        foreach (string s in myStringSet)
        {
            Console.Write(s);
            Console.Write(" ");
        }
        Console.WriteLine();

        //Console.WriteLine();
        //Console.Write("(pause)");
        //Console.ReadLine();
    }
}