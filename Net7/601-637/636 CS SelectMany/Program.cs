// SelectMany
// Linq experiments
//
// SelectMany: Projects each element of a sequence to an IEnumerable<T> and flattens the resulting sequences into one sequence.
//
// 2017-08-09   PV
// 2021-14-13   PV      .Net FW 4.8
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace SelectMany;

class Program
{
    static void Main()
    {
        int[] odds = { 1, 3, 5, 7 };
        int[] evens = { 2, 4, 6, 8 };

        // 1 selector, no index
        // public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);
        var l1 = odds.SelectMany<int, (int, int)>(o => evens.Select(e => (o, e)));
        foreach (var item in l1)
            WriteLine(item);
        WriteLine();

        // 1 selector, 1 index
        // public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector);
        var l2 = odds.SelectMany<int, (int, int, int)>((o, index) => evens.Select(e => (index, o, e)));
        foreach (var item in l2)
            WriteLine(item);
        WriteLine();

        // 2 selectors, 1 intermediate type, no index
        // public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
        var l3 = odds.SelectMany<int, (int, double), (int, int, double)>(
            o => evens.Select(e => (e, (double)o / (double)e)),
            (o, t) => (o, t.Item1, t.Item2));
        foreach (var item in l3)
            WriteLine(item);
        WriteLine();

        // Framework version
        var l4 = odds.SelectMany(
            o => evens,
            (o, e) => (1000 + o, 1000 + e));
        foreach (var item in l4)
            WriteLine(item);
        WriteLine();

        // My version
        var l5 = odds.MySelectMany(
            o => evens,
            (o, e) => (1000 + o, 1000 + e));
        foreach (var item in l5)
            WriteLine(item);
        WriteLine();

    }
}

public static class Extensionmethods
{
    // A manual implementation of SelectMany
    public static IEnumerable<TOutput> MySelectMany<T1, T2, TOutput>(
        this IEnumerable<T1> src,
        Func<T1, IEnumerable<T2>> inputSelector,
        Func<T1, T2, TOutput> resultSelector)
    {
        foreach (var first in src)
        {
            foreach (var second in inputSelector(first))
                yield return resultSelector(first, second);
        }
    }
}
