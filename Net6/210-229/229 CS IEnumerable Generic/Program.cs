// 229 CS IEnumerable Generic
//
// 2012-02-25   PV  VS2010
// 2021-09-19   PV  VS2022; Net6

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#pragma warning disable CA1822 // Mark members as static

namespace CS101_IEnumerable_Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        CityCollection cities = new();
        foreach (string city in cities.Reverse())
            Trace.WriteLine(city);

        //toto t = new toto();
        //Trace.WriteLine(t.zap(1));
    }
}

public class CityCollection : IEnumerable<string>
{
    private readonly string[] m_Cities = { "New York", "Paris", "London" };

    public IEnumerable<string> Reverse()
    {
        for (int i = m_Cities.Length; i-- != 0;)
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

    public class Internal : IMachin
    {
        private readonly int m_a, m_b;

        public Internal(int a, int b)
        {
            m_a = a;
            m_b = b;
        }

        int IMachin.Bidule(int i) => m_a * i + m_b;
    }

    public int Zap(int i) => MaFonction(2, 3).Bidule(i);
}

public class C2 : IMachin
{
    private readonly LinkedList<string> l = new();
    private readonly Dictionary<int, string> d = new();

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

        foreach (KeyValuePair<int, string> kv in d)
        {
        }

        return 0;
    }
}