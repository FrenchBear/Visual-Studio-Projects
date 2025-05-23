// Essais des collections de System.Collections
// Je fais pas encore bien la difference entre HashTable et Dictionary...
// 2001-02-21   PV  (ajout de SortedList)
// 2001-08-15   PV  Beta2; fin de Dictionnary: r�gle le probl�me !!!!!!!
// 2006-10-01   PV  VS2005: Found a substitute for Hashtable(hcp, comparer) which is now obsolete...
// 2012-02-25   PV  VS2010

using System;
using System.Collections;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

internal class TestCollections
{
    public static void PrintKeysAndValues(IDictionary myCollection)
    {
        IDictionaryEnumerator myEnumerator = myCollection.GetEnumerator();
        Console.WriteLine("-KEY-\t-VALUE-");
        while (myEnumerator.MoveNext())
        {
            Console.WriteLine("{0}\t{1}", myEnumerator.Key, myEnumerator.Value);
        }
        Console.WriteLine();
    }

    public static void TestHashtable()
    {
        var h = new Hashtable
        {
            { "G", "Grenoble" },
            { "R", "Fontaine" },
            { "S", "Spip" },
            { "H", "Roanne" }
        };
        try
        { h.Add("G", "Grenoble"); }
        catch
        { Console.WriteLine("�chec � l'ajout d'une Clé en double dans une Hashtable"); }
        try
        { h.Add("g", "grenoble"); }
        catch
        { Console.WriteLine("�chec � l'ajout d'une m�me Clé MAJ/min dans une Hashtable"); }

        Console.WriteLine("HashTable: {0} élément(s)", h.Count);
        PrintKeysAndValues(h);
    }

    private class MyComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y) => x.Equals(y);

        public int GetHashCode(object obj) => obj.ToString().ToLower().GetHashCode();
    }

    public static void TestCaseInsensitiveHashtable()
    {
        var h = new Hashtable(new MyComparer());

        // With IEqualityComparer:
        var h2 = new Hashtable(StringComparer.OrdinalIgnoreCase);
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
        { Console.WriteLine("�chec � l'ajout d'une Clé en double dans une CaseInsensitiveHashtable"); }
        try
        { h.Add("g", "grenoble"); }
        catch
        { Console.WriteLine("�chec � l'ajout d'une m�me Clé MAJ/min dans une CaseInsensitiveHashtable"); }

        Console.WriteLine("CaseInsensitiveHashtable: {0} élément(s)", h.Count);
        PrintKeysAndValues(h);
    }

    // Une SortedList est Triée en permanence
    public static void TestSortedList()
    {
        var s = new SortedList
        {
            { "G", "Grenoble" },
            { "R", "Fontaine" },
            { "S", "Spip" },
            { "H", "Roanne" }
        };
        try
        { s.Add("G", "Grenoble"); }
        catch
        { Console.WriteLine("�chec � l'ajout d'une Clé en double dans une SortedList"); }
        try
        { s.Add("g", "Grenoble"); }
        catch
        { Console.WriteLine("�chec � l'ajout d'une m�me Clé MAJ/min dans une SortedList"); }

        Console.WriteLine("SortedList: {0} élément(s)", s.Count);
        PrintKeysAndValues(s);

        Console.WriteLine("Clés Triées par indice:");
        for (int i = 0; i < s.Count; i++)
            Console.WriteLine("{0}: {1} {2}", i, s.GetKey(i), s.GetByIndex(i));
    }
}

internal class MyApp
{
    public static void Main()
    {
        TestCollections.TestHashtable();
        TestCollections.TestCaseInsensitiveHashtable();
        TestCollections.TestSortedList();

        Console.ReadLine();
    }
}