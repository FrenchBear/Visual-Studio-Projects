// 229 CS IEnumerable Generic
// 2012-02-25   PV  VS2010

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace _101_CS_IEnumerable_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            CityCollection cities = new CityCollection();
            foreach (string city in cities.Reverse())
                Trace.WriteLine(city);

            //toto t = new toto();
            //Trace.WriteLine(t.zap(1));
        }
    }
}

public class CityCollection : IEnumerable<string>
{
    string[] m_Cities = { "New York", "Paris", "London" };

    public IEnumerable<string> Reverse()
    {
        for (int i = m_Cities.Length; i-- != 0;)
            yield return m_Cities[i];
    }

    IEnumerator<string> IEnumerable<string>.GetEnumerator()
    {
        for (int i = 0; i < m_Cities.Length; i++)
            yield return m_Cities[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<string>)this).GetEnumerator();
    }
}


public interface Machin
{
    int Bidule(int i);
}

public class toto
{
    private Machin MaFonction(int a, int b)
    {
        return new Internal(a, b);
    }

    public class Internal : Machin
    {
        int m_a, m_b;
        public Internal(int a, int b)
        {
            m_a = a;
            m_b = b;
        }

        int Machin.Bidule(int i)
        {
            return m_a * i + m_b;
        }
    }

    public int zap(int i)
    {
        return MaFonction(2, 3).Bidule(i);
    }
}

public class c2 : Machin
{
    LinkedList<string> l = new LinkedList<string>();
    Dictionary<int, string> d = new Dictionary<int, string>();

    public int Bidule(int i)
    {
        l.AddLast("This is");
        l.AddLast("a string");

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