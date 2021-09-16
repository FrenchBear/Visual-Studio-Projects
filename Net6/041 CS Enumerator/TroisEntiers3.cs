// Construction d'une classe énumérable avec foreach en C#
// ThreeIntegers3 implémente une interface IDictionary complète: nettement compliqué !!!
// 2001-02-21   PV
// 2001-08-19   PV	Beta2
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;
using System.Collections;

internal class ThreeIntegers3 : IDictionary
{
    private readonly int i1, i2, i3;

    public ThreeIntegers3(int i1, int i2, int i3)
    {
        this.i1 = i1;
        this.i2 = i2;
        this.i3 = i3;
    }

    // Interface IEnumerable (IDictionary implémente cette interface)
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)new MonEnumerateur(this);
    }

    //Interface ICollection (IDictionary implémente cette interface)
    int ICollection.Count { get { return 3; } }

    bool ICollection.IsSynchronized { get { return true; } }
    object ICollection.SyncRoot { get { return null; } }

    void ICollection.CopyTo(Array array, int index)
    {
    }

    // Interface IDictionary
    IDictionaryEnumerator IDictionary.GetEnumerator()
    {
        return new MonEnumerateur(this);
    }

    object IDictionary.this[object key] { get { return null; } set { } }
    ICollection IDictionary.Keys { get { return null; } }
    ICollection IDictionary.Values { get { return null; } }

    void IDictionary.Add(object key, object value)
    {
    }

    void IDictionary.Clear()
    {
    }

    bool IDictionary.Contains(object key)
    {
        return false;
    }

    void IDictionary.Remove(object key)
    {
    }

    bool IDictionary.IsFixedSize { get { return true; } }
    bool IDictionary.IsReadOnly { get { return true; } }

    // Trucs internes à la classe (énumérateur)
    private class MonEnumerateur : IDictionaryEnumerator
    {
        private int pos;
        private readonly ThreeIntegers3 tcur;

        public MonEnumerateur(ThreeIntegers3 t)
        {
            tcur = t;
            pos = -1;
        }

        public bool MoveNext()
        {
            if (pos < 2)
            {
                pos++;
                return true;
            }
            else
                return false;
        }

        public object Value
        {
            get
            {
                switch (pos)
                {
                    case 0: return tcur.i1;
                    case 1: return tcur.i2;
                    case 2: return tcur.i3;
                    default: throw new InvalidOperationException();
                }
            }
        }

        public object Current
        {
            get
            {
                return Value;
            }
        }

        public object Key
        {
            get
            {
                switch (pos)
                {
                    case 0: return 0;
                    case 1: return 1;
                    case 2: return 2;
                    default: throw new InvalidOperationException();
                }
            }
        }

        public DictionaryEntry Entry
        {
            get
            {
                return new DictionaryEntry(Key, Value);
            }
        }

        public void Reset()
        {
            pos = -1;
        }
    }
}