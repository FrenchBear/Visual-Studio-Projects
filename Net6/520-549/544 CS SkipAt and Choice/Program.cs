// CS544 SkipAt Choice GetRange Shuffle
//
// Implement a SkipAt extension of IEnumerable<T>
// "Remove" or skips a given number of items from a starting position in any enumeration
// Since this is not provided out-of-the-box, and several articles on StackOverflow state that "this is not possible"...
//
// Implement a Choice extension similar to Choice in Python, that is, select a random element, without knowing how many
// elements there are in the enumeration and without memorizing a full list
//
// 2016-08-05   PV      SkipAt
// 2016-08-06   PV      1.1 Choice
// 2016-08-13   PV      1.2 Shuffle and GetRange
// 2021-09-26   PV      VS2022; Net6

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;

namespace CS544SkipAtChoice;

internal class Program
{
    private static void Main(string[] args)
    {
        IEnumerable<int> e = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        WriteLine($"e: {e.AsString()}");
        WriteLine($"e.SkipAt(3, 2): {e.SkipAt(3, 2).AsString()}");
        WriteLine($"e.GetRange(3, 2): {e.GetRange(3, 2).AsString()}");
        WriteLine();

        WriteLine("e = Enumerable.Range(0, 1000)");
        e = Enumerable.Range(0, 1000);
        for (int i = 0; i < 3; i++)
        {
            WriteLine($"e.Choice1(): {e.Choice1()}");
            WriteLine($"e.Choice2(): {e.Choice2()}");
            WriteLine($"e.Choice3(): {e.Choice3()}");
        }
        var r = Enumerable.Range(0, 1000);
    }
}

public static class Extensions
{
    /// <summary>
    /// Internal enumerable class providing the object returned by SkipAt extension
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private class SkipAtEnumerator<T> : IEnumerable<T>
    {
        private readonly IEnumerator<T> originalEnumerator;
        private readonly int start, count;
        private int pos;

        public SkipAtEnumerator(IEnumerable<T> original, int start, int count)
        {
            this.originalEnumerator = original.GetEnumerator();
            this.start = start;
            this.count = count;
            pos = 0;
        }

        private IEnumerator<T> MyEnumerator()
        {
            for (; ; )
            {
                if (!originalEnumerator.MoveNext())
                    yield break;
                if (pos < start || pos >= start + count)
                    yield return originalEnumerator.Current;
                pos++;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => MyEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => MyEnumerator();
    }

    /// <summary>
    /// Returns the original enumeration without count items starting at position start (base 1)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">Original enumeration</param>
    /// <param name="start">Index of first element to skip, starting at 0</param>
    /// <param name="count">Number of elements to skip, default 1</param>
    /// <returns></returns>
    public static IEnumerable<T> SkipAt<T>(this IEnumerable<T> e, int start, int count = 1) => new SkipAtEnumerator<T>(e, start, count);

    private static readonly Random rnd = new();

    /// <summary>
    /// Returns a random element from the enumeration, version 1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">Original enumeration</param>
    /// <returns></returns>
    public static T Choice1<T>(this IEnumerable<T> e) =>
        // Not efficient method, one pass to count, one pass to retrieve element
        e.ElementAt(rnd.Next(e.Count()));

    /// <summary>
    /// Returns a random element from the enumeration, version 2
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">Original enumeration</param>
    /// <returns></returns>
    public static T Choice2<T>(this IEnumerable<T> e)
    {
        // Version in one pass, memorize a candidate valid if the list would terminate at this point.
        // If list contains 1 element, probability element 1 is selected = 1
        // If list contains 2 elements, probability element 2 is selected = 1/2
        // If list contains 3 elements, probability element 3 is selected = 1/3 (and 2/3 to remain the one chosen before)
        // ...
        int count = 0;
        T current = default;
        foreach (T item in e)
        {
            count++;
            if (rnd.NextDouble() > 1.0 - 1.0 / count)
                current = item;
        }
        return current;
    }

    /// <summary>
    /// Returns a random element from the enumeration, version 3
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">Original enumeration</param>
    /// <returns></returns>
    public static T Choice3<T>(this IEnumerable<T> e)
    {
        // Variant of Choice2 using Aggregate
        int count = 0;
        return e.Aggregate((T aggregated, T item) => (rnd.NextDouble() < 1.0 / ++count) ? item : aggregated);
    }

    /// <summary>
    /// Prints the enumeration including end-of-line
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">Original enumeration</param>
    public static void WriteLine<T>(this IEnumerable<T> e) => Console.WriteLine(e.AsString());

    /// <summary>
    /// Returns a string version of the enumeration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">Original enumeration</param>
    /// <returns></returns>
    public static string AsString<T>(this IEnumerable<T> e)
    {
        bool bFirst = true;
        var sb = new StringBuilder();
        foreach (T item in e)
        {
            if (bFirst)
            {
                _ = sb.Append('{');
                bFirst = false;
            }
            else
            {
                _ = sb.Append(", ");
            }

            _ = sb.Append(item);
        }
        _ = sb.Append('}');
        return sb.ToString();
    }

    /// <summary>
    /// A quick-and-dirty shuffler for an enumerable, but slow (needs a sort in n.log(n))
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">An enumerable in a given order</param>
    /// <returns>A shuffled version of source</returns>
    public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
    {
        Random rnd = new();
        return source.OrderBy((item) => rnd.Next());
    }

    /// <summary>
    /// A list shuffler in-place (no return value) using Fisher-Yates shuffle (swapping n random pairs).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">A list in a given order</param>
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }

    /// <summary>
    /// Internal enumerable class providing the object returned by GetRange extension
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private class GetRangeEnumerator<T> : IEnumerable<T>
    {
        private readonly IEnumerator<T> originalEnumerator;
        private readonly int start, count;
        private int pos;

        public GetRangeEnumerator(IEnumerable<T> original, int start, int count)
        {
            this.originalEnumerator = original.GetEnumerator();
            this.start = start;
            this.count = count;
            pos = 0;
        }

        private IEnumerator<T> MyEnumerator()
        {
            for (; ; )
            {
                if (pos >= start + count || !originalEnumerator.MoveNext())
                    yield break;
                if (pos >= start && pos < start + count)
                    yield return originalEnumerator.Current;
                pos++;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => MyEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => MyEnumerator();
    }

    /// <summary>
    /// Returns the original enumeration without count items starting at position start (base 1)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">Original enumeration</param>
    /// <param name="start">Index of first element to return, starting at 0</param>
    /// <param name="count">Number of elements to return</param>
    /// <returns></returns>
    public static IEnumerable<T> GetRange<T>(this IEnumerable<T> e, int start, int count) => new GetRangeEnumerator<T>(e, start, count);
}

/// <summary>
/// Helper to get a better random generator without using System.Security.Cryptography
/// and RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
/// </summary>
public static class ThreadSafeRandom
{
    [ThreadStatic]
    private static Random Local;

    public static Random ThisThreadsRandom 
        => Local ??= new Random(unchecked(Environment.TickCount * 31 + Environment.CurrentManagedThreadId));
}