﻿// 2021-09-23   PV  VS2022; Net6

using System;
using System.Collections.Generic;

namespace CS421;

internal class Program
{
    private static void Main(string[] args)
    {
        // Old style (pedestrian, has-been, ...)
        var r = new Random();
        var s = new SortedSet<double>();

        for (int i = 0; i < 10; i++)
            _ = s.Add(r.NextDouble());
        foreach (double d in s)
            Console.WriteLine(d);

        // New style
        _ = new SortedSet<double>()
            .Add(Generate(10, () => r.NextDouble()))
            .ForEach(Console.WriteLine);
    }

    private static IEnumerable<T> Generate<T>(int count, Func<T> generator)
    {
        while (count-- > 0)
            yield return generator();
    }
}

internal static class ExtensionMethods
{
    public static SortedSet<T> Add<T>(this SortedSet<T> set, IEnumerable<T> tlist)
    {
        _ = tlist.ForEach(set.Add);
        return set;
    }

    // Repack Sorted.Set returning a boolean into an Action
    public static void Add<T>(this SortedSet<T> set, T item) => set.Add(item);

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (T item in collection)
            action(item);
        return collection;
    }
}