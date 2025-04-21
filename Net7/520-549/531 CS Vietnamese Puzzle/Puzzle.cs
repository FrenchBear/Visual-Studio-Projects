// 531 CS Vietnamese puzzle
// Solver for a problem published in the Guardian
// http://www.theguardian.com/science/alexs-adventures-in-numberland/2015/may/20/can-you-do-the-maths-puzzle-for-vietnamese-eight-year-olds-that-has-stumped-parents-and-teachers
// All you need to do is place the digits from 1 to 9 in the grid.
//
// 2015-05-22   PV      C# version
// 2015-06-27   PV      Added Test and ListOfPermut, slower than the two others...
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

/* Output (on THOR):
{1,2,6,4,7,8,3,5,9}
{1,2,6,4,7,8,5,3,9}
{1,3,2,4,5,8,7,9,6}
{1,3,2,4,5,8,9,7,6}
...
{9,8,6,2,4,1,5,7,3}
{9,8,6,2,4,1,7,5,3}
128  solution(s) found
362880 permutations analyzed in 0,71s
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;

namespace CS531;

internal class Program
{
    private static void Main(string[] args)
    {
        // For Vietnamese puzzle we have to use the digits from 1 to 9
        List<double> t = new() { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0 };

        Test(ListOfPermut, t);
        Test(GetStackPermutator, t);
        Test(IteratorPermutator, t);
    }

    // Relay helper to transform object creation in a function call to be usable by Test
    private static IEnumerable<List<T>> GetStackPermutator<T>(List<T> l) => new StackPermutator<T>(l);

    private static void Test(Func<List<double>, IEnumerable<List<double>>> f, List<double> l)
    {
        var np = 0;                  // Number of permutations
        var ns = 0;                  // Number of solutions
        var sw = Stopwatch.StartNew();

        foreach (var x in f(l))
        {
            np++;
            if (x[0] + 13.0 * x[1] / x[2] + x[3] + 12.0 * x[4] - x[5] - 11.0 + x[6] * x[7] / x[8] - 10.0 == 66.0)
            {
                // Found a solution!
                //x.WriteLine();
                ns++;
            }
        }
        sw.Stop();
        WriteLine("{0}: {1} solution(s) found on {2} permutations in {3}s", f.Method.Name, ns, np, Math.Round(sw.ElapsedMilliseconds / 1000.0, 2));

        // Just check that the number of permutations is equal to 9!
        if (np != Fact(l.Count))
            WriteLine("We have a problem!");
    }

    // Quick and dirty factorial
    private static long Fact(long n) => n <= 2 ? n : n * Fact(n - 1);

    // A recursive iterator to produce all possible permutations of a List<T>
    // Short and readable, but 3 times slower than the stack-based version...
    private static IEnumerable<List<T>> IteratorPermutator<T>(List<T> l)
    {
        if (l.Count == 1)
            // If there's only one element in the list, then the permutation is the list itself
            yield return l;
        else
        {
            // For each element of the list, return the element 1st, followed by all permutations of
            // the rest of the list
            for (var i = 0; i < l.Count; i++)
            {
                var element = l[i];
                var copy = new List<T>(l);
                copy.RemoveAt(i);
                foreach (var permut in IteratorPermutator(copy))
                {
                    permut.Insert(0, element);
                    yield return permut;
                }
            }
        }
    }

    // A simple permutator returning a list of permutations
    private static IEnumerable<List<T>> ListOfPermut<T>(List<T> l)
    {
        if (l.Count == 1)
            return new List<List<T>> { l };

        // Small optimization
        if (l.Count == 2)
            return new List<List<T>> { l, new List<T> { l[1], l[0] } };

        var r = new List<List<T>>();
        for (var i = 0; i < l.Count; i++)
        {
            var s = new List<T>(l);
            s.RemoveAt(i);
            foreach (var x in ListOfPermut(s))
            {
                x.Insert(0, l[i]);
                r.Add(x);
            }
        }
        return r;
    }
}

// Stack-based permutator
internal class StackPermutator<T>: IEnumerable<List<T>>
{
    // Just keep a copy of the list since enumerator is retrieved later
    private readonly List<T> list;

    public StackPermutator(List<T> l) => list = l;

    public virtual IEnumerator<List<T>> GetEnumerator() => new MyEnumerator(list);

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

    private class MyEnumerator: IEnumerator<List<T>>
    {
        // Stack to store elements not fully permuted
        private readonly Stack<ListLevel<T>> stack;

        // One element of the stack, with level items at the head of the list already permuted
        private class ListLevel<Z>
        {
            public List<Z> list;
            public int level;
        }

        public MyEnumerator(List<T> l)
        {
            stack = new Stack<ListLevel<T>>();
            stack.Push(new ListLevel<T> { level = 0, list = l });   // 1st ListLevel, 0 item has been permuted yet
            stack.Push(null);   // Just because the 1st call is to MoveNext, that will pop the top of the stack...
        }

        public List<T> Current
        {
            get
            {
                for (; ; )
                {
                    var x = stack.Peek() as ListLevel<T>;
                    // If all the elements of the list have been permuted,
                    // the element is valid and can be returned
                    if (x.level == x.list.Count - 1)
                        return x.list;
                    // Of, not valid.  Remove it from the stack
                    _ = stack.Pop();
                    // And take one by one all remaining elements not permuted in the list,
                    // and push a list with this element added to the list of already
                    // permuted elements, remaining one
                    // less element in the non-permuted part
                    for (var i = x.list.Count - 1; i >= x.level; i--)
                    {
                        var element = x.list[i];
                        var copy = new List<T>(x.list);
                        copy.RemoveAt(i);
                        copy.Insert(x.level, element);
                        // Push the list with one more permuted element on the stack
                        stack.Push(new ListLevel<T> { level = x.level + 1, list = copy });
                    }
                }
            }
        }

        public bool MoveNext()
        {
            // In theory should check that stack is not empty before dropping top element...
            _ = stack.Pop();
            return stack.Count > 0;
        }

        object System.Collections.IEnumerator.Current => Current;

        public void Dispose()
        {
            //nop
        }

        public void Reset()
        {
            // nop
        }
    }
}

internal static class ExtensionMethods
{
    // Print an enumeration
    public static void ConsoleWrite<T>(this IEnumerable<T> source)
    {
        Console.Write("{");
        var first = true;
        foreach (var item in source)
        {
            if (first)
                first = false;
            else
                Console.Write(", ");
            Console.Write(item);
        }
        Console.Write("}");
    }

    public static void ConsoleWriteLine<T>(this IEnumerable<T> source)
    {
        source.ConsoleWrite();
        WriteLine();
    }
}
