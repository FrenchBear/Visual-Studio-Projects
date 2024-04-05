// 635 CS IComparable and IComparer
// Learning code about comparison interfaces
// 2017-07-23   PV      First version -- finally!

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace CS635
{
    internal class Program
    {
        private static void Main()
        {
            // IComparable interface, implemented by the class being sorted
            var l1 = new List<Entier1>() { new Entier1(15), new Entier1(2), new Entier1(1), new Entier1(17), new Entier1(3) };
            l1.Sort();      // Sort with no argument needs IComparable
            WriteLine("l1: " + l1.ToString<Entier1>());

            // Comparison<T> delegate
            var l2 = new List<Entier>() { new Entier(15), new Entier(2), new Entier(1), new Entier(17), new Entier(3) };
            l2.Sort((it1, it2) => it1.Value - it2.Value);      // Sort using a Comparison<Entier> delegate provided by a lambda
            WriteLine("l2a: " + l2.ToString<Entier>());
            int alphaSorting(Entier it1, Entier it2) => string.Compare(it1.Value.ToString(), it2.Value.ToString(), StringComparison.Ordinal);
            Comparison<Entier> alphaSortingDeletage = alphaSorting;
            l2.Sort(alphaSortingDeletage);      // Sort using a traditional Comparison<Entier> delegate
            WriteLine("l2b: " + l2.ToString<Entier>());

            // IComparer<T> interface, implemented in a separate class
            l2.Sort(new EntierComparer());
            WriteLine("l2c: " + l2.ToString<Entier>());

            // Sort using OrderBy relies on result on Key (returned by lambda) being sorted using
            // System.Collections.Generic.Comparer<T> Default static member that returns a default
            // sort order comparer for the type specified by the generic argument.
            // Creates internally a comparer based on type T implementation of IComparable<T>,
            // then on IComparable
            var l3 = new List<Entier3>() { new Entier3(15), new Entier3(2), new Entier3(1), new Entier3(17), new Entier3(3) };
            l3 = l3.OrderBy(e => e).ToList();
            WriteLine("l3a: " + l3.ToString<Entier3>());
            // Now with a specific object implementing IComparer<TKey>to override default
            l3 = l3.OrderBy(e => e, new Entier3Comparer()).ToList();
            WriteLine("l3b: " + l3.ToString<Entier3>());

            // Comparison with operators
            var e21 = new Entier2(2);
            var e22 = new Entier2(5);
            bool b2 = e21 > e22;

            // Comparison with IComparable
            var e11 = new Entier1(2);
            var e12 = new Entier1(5);
            int i1 = e11.CompareTo(e12);

            // Comparison with IComparable<T>
            var e31 = new Entier3(2);
            var e32 = new Entier3(5);
            int i3 = e31.CompareTo(e32);

            // Comparison with Comparer<T>.Default
            Comparer<Entier3> myComparer = Comparer<Entier3>.Default;
            int i4 = myComparer.Compare(e31, e32);

            // Comparison using Comparison delegate
            int myComparison(Entier3 x3, Entier3 y3) => x3.Value - y3.Value;
            int i5 = myComparison(e31, e32);

            // String comparisons
            int si1 = string.Compare("sun", "dry");
            // Trick: StringComparison is just an enum, not a static member returning a Comparison!!!
            int si2 = string.Compare("sun", "dry", StringComparison.InvariantCultureIgnoreCase);
            var sl1 = new SortedSet<string>(StringComparer.InvariantCultureIgnoreCase);

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }

    // base class
    internal class Entier
    {
        private readonly int n;

        public Entier(int value) => n = value;

        public int Value => n;

        public override string ToString() => n.ToString();
    }

    // IComparable, for old code
    internal class Entier1 : Entier, IComparable
    {
        public Entier1(int value) : base(value)
        {
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Entier1 otherEntier)
                return Value - otherEntier.Value;
            else
                throw new ArgumentException("Object is not an Entier1");
        }
    }

    // IComparer<T>, to build objects that implements specific sorting
    internal class EntierComparer : IComparer<Entier>
    {
        public int Compare(Entier x, Entier y) => x.Value - y.Value;
    }

    // Implements operators >, >=, <, <=
    internal class Entier2 : Entier
    {
        public Entier2(int value) : base(value)
        {
        }

        public static bool operator >(Entier2 e1, Entier2 e2) => e1.Value > e2.Value;

        public static bool operator >=(Entier2 e1, Entier2 e2) => e1.Value >= e2.Value;

        public static bool operator <(Entier2 e1, Entier2 e2) => e1.Value < e2.Value;

        public static bool operator <=(Entier2 e1, Entier2 e2) => e1.Value <= e2.Value;
    }

    // IComparable<int>>
    // From help:
    // If you implement IComparable<T>, you should overload the op_GreaterThan, op_GreaterThanOrEqual,
    // op_LessThan, and op_LessThanOrEqual operators to return values that are consistent with CompareTo.
    // In addition, you should also implement IEquatable<T>.
    // See the IEquatable<T> article for complete information.
    internal class Entier3 : Entier, IComparable<Entier3>
    {
        public Entier3(int value) : base(value)
        {
        }

        public int CompareTo(Entier3 other) => Value - other.Value;
    }

    // IComparer<T>, to build objects that implements specific sorting
    // Here Entier3 is sorted using alphabetical sorting
    internal class Entier3Comparer : IComparer<Entier3>
    {
        public int Compare(Entier3 x, Entier3 y) => string.Compare(x.Value.ToString(), y.Value.ToString(), StringComparison.Ordinal);
    }

    internal static class ExtensionMethods
    {
        public static string ToString<T>(this IEnumerable<T> collection)
        {
            var sb = new StringBuilder();
            bool first = true;
            foreach (T item in collection)
                if (first)
                {
                    sb.Append('{').Append(item.ToString());
                    first = false;
                }
                else
                    sb.Append(", ").Append(item.ToString());
            return sb.Append('}').ToString();
        }
    }
}