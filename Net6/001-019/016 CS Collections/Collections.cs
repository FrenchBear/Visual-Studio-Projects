// Essais des collections de System.Collections
// Je fais pas encore bien la difference entre HashTable et Dictionary...
// 2001-02-21   PV  (ajout de SortedList)
// 2001-08-15   PV  Beta2; fin de Dictionnary: r�gle le probl�me !!!!!!!
// 2006-10-01   PV  VS2005: Found a substitute for Hashtable(hcp, comparer) which is now obsolete...
// 2012-02-25   PV  VS2010
// 2021-09-17   PV  VS2022/Net6

using System;
using System.Collections;
using static System.Console;

internal class TestCollections
{
    public static void PrintKeysAndValues(IDictionary myCollection)
    {
        IDictionaryEnumerator myEnumerator = myCollection.GetEnumerator();
        WriteLine("-KEY-\t-VALUE-");
        while (myEnumerator.MoveNext())
        {
            WriteLine("{0}\t{1}", myEnumerator.Key, myEnumerator.Value);
        }
        WriteLine();
    }

    public static void TestHashtable()
    {
        Hashtable h = new()
        {
            { "G", "Grenoble" },
            { "R", "Fontaine" },
            { "S", "Spip" },
            { "H", "Roanne" }
        };
        try
        { h.Add("G", "Grenoble"); }
        catch
        { WriteLine("�chec � l'ajout d'une cl� en double dans une Hashtable"); }
        try
        { h.Add("g", "grenoble"); }
        catch
        { WriteLine("�chec � l'ajout d'une m�me cl� MAJ/min dans une Hashtable"); }

        WriteLine("HashTable: {0} �l�ment(s)", h.Count);
        PrintKeysAndValues(h);
    }

    private class MyComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y) => x.Equals(y);

        public int GetHashCode(object obj) => obj.ToString().ToLower().GetHashCode();
    }

    public static void TestCaseInsensitiveHashtable()
    {
        Hashtable h = new(new MyComparer());

        // With IEqualityComparer:
        Hashtable h2 = new(StringComparer.OrdinalIgnoreCase);
        // Seee http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dndotnet/html/StringsinNET20.asp

        //IEqualityComparer comparer = new CaseInsensitiveComparer.Default();
        //Hashtable h = new Hashtable(comparer);

        h.Add("G", "Grenoble");
        h.Add("R", "Fontaine");
        h.Add("S", "Spip");
        h.Add("H", "Roanne");
        try
        { h.Add("G", "Grenoble"); }
        catch
        { WriteLine("�chec � l'ajout d'une cl� en double dans une CaseInsensitiveHashtable"); }
        try
        { h.Add("g", "grenoble"); }
        catch
        { WriteLine("�chec � l'ajout d'une m�me cl� MAJ/min dans une CaseInsensitiveHashtable"); }

        WriteLine("CaseInsensitiveHashtable: {0} �l�ment(s)", h.Count);
        PrintKeysAndValues(h);
    }

    // Une SortedList est tri�e en permanence
    public static void TestSortedList()
    {
        SortedList s = new()
        {
            { "G", "Grenoble" },
            { "R", "Fontaine" },
            { "S", "Spip" },
            { "H", "Roanne" }
        };
        try
        { s.Add("G", "Grenoble"); }
        catch
        { WriteLine("�chec � l'ajout d'une cl� en double dans une SortedList"); }
        try
        { s.Add("g", "Grenoble"); }
        catch
        { WriteLine("�chec � l'ajout d'une m�me cl� MAJ/min dans une SortedList"); }

        WriteLine("SortedList: {0} �l�ment(s)", s.Count);
        PrintKeysAndValues(s);

        WriteLine("Cl�s tri�es par indice:");
        for (int i = 0; i < s.Count; i++)
            WriteLine("{0}: {1} {2}", i, s.GetKey(i), s.GetByIndex(i));
    }
}

internal class MyApp
{
    public static void Main()
    {
        TestCollections.TestHashtable();
        TestCollections.TestCaseInsensitiveHashtable();
        TestCollections.TestSortedList();

        _ = Console.ReadLine();
    }
}