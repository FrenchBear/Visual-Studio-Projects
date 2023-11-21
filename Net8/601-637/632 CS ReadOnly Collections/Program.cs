// 632 CS ReadOnly Collections
// Tests on ReadOnly collections
//
// 2013-01-29   FPVI
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using System.Collections.Generic;
using System.Collections.ObjectModel;           // Namespace for RO interfaces and collections
using static System.Console;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable CA1859 // Use concrete types when possible for improved performance

namespace CS612;

internal class Program
{
    private static void Main(string[] args)
    {
        // ReadOnly Dictionary
        var d1 = GetNumberDic1();
        foreach (var k in d1.Keys)
            WriteLine(k + " -> " + d1[k]);
        WriteLine();

        var d2 = GetNumberDic2();
        foreach (var k in d2.Keys)
            WriteLine(k + " -> " + d2[k]);
        WriteLine();
        // Problem with just an interface is that you can still recast it to a real dictionary and add elements to it...
        var d3 = (Dictionary<int, string>)d2;
        d3.Add(4, "Four");

        // ReadOnly List
        var l = GetList();
        //var l2 = (List<int>)l;        // This fails
        //l2.Add(17);
    }

    // Build a new ReadOnlyDictionary object, that is a wrapper around the original dictionary
    private static ReadOnlyDictionary<int, string> GetNumberDic1()
    {
        var d = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" } };
        return new ReadOnlyDictionary<int, string>(d);
    }

    // Return IReadOnlyDictionary interface of a real dictionary
    private static IReadOnlyDictionary<int, string> GetNumberDic2()
    {
        var d = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "Three" } };
        return (IReadOnlyDictionary<int, string>)d;
    }

    private static IReadOnlyList<int> GetList()
    {
        var l = new List<int> { 2, 3, 5, 7, 11, 13 };
        // There is no ReadOnlyList class, but a list can be exposed as a ReadOnly, with no way to cast it back
        // to a normal read/write list
        return (IReadOnlyList<int>)l.AsReadOnly();
    }
}
