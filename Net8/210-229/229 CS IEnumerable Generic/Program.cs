// 229 CS IEnumerable Generic
//
// 2012-02-25   PV      VS2010
// 2021-09-19   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CA1859 // Use concrete types when possible for improved performance

namespace CS101_IEnumerable_Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        CityCollection cities = new();
        foreach (var city in cities.Reverse())
            Trace.WriteLine(city);

        //toto t = new toto();
        //Trace.WriteLine(t.zap(1));
    }
}

public class CityCollection: IEnumerable<string>
{
    private readonly string[] m_Cities = ["New York", "Paris", "London"];

    public IEnumerable<string> Reverse()
    {
        for (var i = m_Cities.Length; i-- != 0;)
            yield return m_Cities[i];
    }

    IEnumerator<string> IEnumerable<string>.GetEnumerator()
    {
        foreach (var t in m_Cities)
            yield return t;
    }

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<string>)this).GetEnumerator();
}

public interface IMachin
{
    int Bidule(int i);
}

public class Toto
{
    private IMachin MaFonction(int a, int b) => new Internal(a, b);

    public class Internal(int a, int b): IMachin
    {
        private readonly int m_a = a, m_b = b;

        int IMachin.Bidule(int i) => m_a * i + m_b;
    }

    public int Zap(int i) => MaFonction(2, 3).Bidule(i);
}

public class C2: IMachin
{
    private readonly LinkedList<string> l = new();
    private readonly Dictionary<int, string> d = [];

    public int Bidule(int i)
    {
        _ = l.AddLast("This is");
        _ = l.AddLast("a string");

        //foreach (string s in d)
        //{
        //}

        //foreach (int j in d)
        //{
        //}

#pragma warning disable IDE0059 // Unnecessary assignment of a value
        foreach (var kv in d)
        {
        }
#pragma warning restore IDE0059 // Unnecessary assignment of a value

        return 0;
    }
}
