// 311 CS Extensions of IEnumerable(Of T)
//
// 2012-03-03   PV
// 2021-09-20	PV		VS2022; Net6
// 2023-01-10	PV		Net7

using System;
using System.Collections.Generic;

namespace ExtensionMethods;

public static class ExtensionMethodsClasses
{
    // Extension of IEnumerable<T>
    public static IEnumerable<T> DoubleListe<T>(this IEnumerable<T> source)
    {
        foreach (var item in source)
        {
            yield return item;
            yield return item;
        }
    }

    // Print an enumeration
    public static void Write<T>(this IEnumerable<T> source)
    {
        Console.Write("{");
        var first = true;
        foreach (var item in source)
        {
            if (first)
                first = false;
            else
                Console.Write(",");
            Console.Write(item);
        }
        Console.Write("}");
    }

    public static void WriteLine<T>(this IEnumerable<T> source)
    {
        source.Write();
        Console.WriteLine();
    }
}
