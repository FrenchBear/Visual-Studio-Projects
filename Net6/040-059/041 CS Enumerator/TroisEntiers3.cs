// Construction d'une classe énumérable avec foreach en C#
// ThreeIntegers3 implémente une interface IDictionary complète: nettement compliqué !!!
// 2001-02-21   PV
// 2001-08-19   PV	Beta2
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

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
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)new MonEnumerateur(this);

    //Interface ICollection (IDictionary implémente cette interface)
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

        public object Value => pos switch
        {
            0 => tcur.i1,
            1 => tcur.i2,
            2 => tcur.i3,
            _ => throw new InvalidOperationException(),
        };

        public object Current => Value;

        public object Key => pos switch
        {
            0 => 0,
            1 => 1,
            2 => 2,
            _ => throw new InvalidOperationException(),
        };

        public DictionaryEntry Entry => new(Key, Value);

        public void Reset() => pos = -1;
    }
}