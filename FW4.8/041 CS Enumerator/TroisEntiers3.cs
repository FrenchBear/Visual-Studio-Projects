// Construction d'une classe �num�rable avec foreach en C#
// ThreeIntegers3 impl�mente une interface IDictionary compl�te: nettement compliqu� !!!
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

    // Interface IEnumerable (IDictionary impl�mente cette interface)
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)new MonEnumerateur(this);

    //Interface ICollection (IDictionary impl�mente cette interface)
    int ICollection.Count => 3;

    bool ICollection.IsSynchronized => true;
    object ICollection.SyncRoot => null;

    void ICollection.CopyTo(Array array, int index)
    {
    }

    // Interface IDictionary
    IDictionaryEnumerator IDictionary.GetEnumerator() => new MonEnumerateur(this);

    object IDictionary.this[object key] { get => null; set { } }
    ICollection IDictionary.Keys => null;
    ICollection IDictionary.Values => null;

    void IDictionary.Add(object key, object value)
    {
    }

    void IDictionary.Clear()
    {
    }

    bool IDictionary.Contains(object key) => false;

    void IDictionary.Remove(object key)
    {
    }

    bool IDictionary.IsFixedSize => true;
    bool IDictionary.IsReadOnly => true;

    // Trucs internes � la classe (�num�rateur)
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

        public object Current => Value;

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

        public DictionaryEntry Entry => new DictionaryEntry(Key, Value);

        public void Reset() => pos = -1;
    }
}