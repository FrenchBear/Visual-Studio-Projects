// 635 CS IComparable and IComparer
// Learning code about comparison interfaces
//
// 2017-07-23   PV      First version -- finally!
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace CS635;

internal class Program
{
    private static void Main()
    {
        // IComparable interface, implemented by the class being sorted
        List<Entier1> l1 = [new Entier1(15), new Entier1(2), new Entier1(1), new Entier1(17), new Entier1(3)];
        l1.Sort();      // Sort with no argument needs IComparable
        WriteLine("l1: " + l1.ToString<Entier1>());

        // Comparison<T> delegate
        List<Entier> l2 = [new Entier(15), new Entier(2), new Entier(1), new Entier(17), new Entier(3)];
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
        List<Entier3> l3 = [new Entier3(15), new Entier3(2), new Entier3(1), new Entier3(17), new Entier3(3)];
        l3 = [.. l3.OrderBy(e => e)];
        WriteLine("l3a: " + l3.ToString<Entier3>());
        // Now with a specific object implementing IComparer<TKey>to override default
        l3 = [.. l3.OrderBy(e => e, new Entier3Comparer())];
        WriteLine("l3b: " + l3.ToString<Entier3>());

        // Comparison with operators
        var e21 = new Entier2(2);
        var e22 = new Entier2(5);
        var b2 = e21 > e22;

        // Comparison with IComparable
        var e11 = new Entier1(2);
        var e12 = new Entier1(5);
        var i1 = e11.CompareTo(e12);

        // Comparison with IComparable<T>
        var e31 = new Entier3(2);
        var e32 = new Entier3(5);
        var i3 = e31.CompareTo(e32);

        // Comparison with Comparer<T>.Default
        var myComparer = Comparer<Entier3>.Default;
        var i4 = myComparer.Compare(e31, e32);

        // Comparison using Comparison delegate
        int myComparison(Entier3 x3, Entier3 y3) => x3.Value - y3.Value;
        var i5 = myComparison(e31, e32);

        // String comparisons
        var si1 = string.Compare("sun", "dry");
        // Trick: StringComparison is just an enum, not a static member returning a Comparison!!!
        var si2 = string.Compare("sun", "dry", StringComparison.InvariantCultureIgnoreCase);
        SortedSet<string> sl1 = new(StringComparer.InvariantCultureIgnoreCase);
    }
}

// base class
internal class Entier(int value)
{
    private readonly int n = value;

    public int Value => n;

    public override string ToString() => n.ToString();
}

// IComparable, for old code
internal class Entier1(int value): Entier(value), IComparable
{
    public int CompareTo(object? obj) => obj == null
            ? 1
            : obj is Entier1 otherEntier ? Value - otherEntier.Value : throw new ArgumentException("Object is not an Entier1");
}

// IComparer<T>, to build objects that implements specific sorting
internal class EntierComparer: IComparer<Entier>
{
    public int Compare(Entier? x, Entier? y) => (x == null || y == null) ? 1 : x.Value - y.Value;
}

// Implements operators >, >=, <, <=
internal class Entier2(int value): Entier(value)
{
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
internal class Entier3(int value): Entier(value), IComparable<Entier3>
{
    public int CompareTo(Entier3? other) => other == null ? 1 : Value - other.Value;
}

// IComparer<T>, to build objects that implements specific sorting
// Here Entier3 is sorted using alphabetical sorting
internal class Entier3Comparer: IComparer<Entier3>
{
    public int Compare(Entier3? x, Entier3? y) => string.Compare(x?.Value.ToString(), y?.Value.ToString(), StringComparison.Ordinal);
}

internal static class ExtensionMethods
{
    public static string ToString<T>(this IEnumerable<T> collection)
    {
        StringBuilder sb = new();
        var first = true;
        foreach (var item in collection)
        {
            if (first)
            {
                _ = sb.Append('{').Append(item);
                first = false;
            }
            else
            {
                _ = sb.Append(", ").Append(item);
            }
        }

        return sb.Append('}').ToString();
    }
}
