// Construction d'une classe énumérable avec foreach en C#
// ThreeIntegers2 implémente une fonction GetDictionaryEnumerator retournant un
// énumérateur de type IDictionaryEnumerator (key+value)
// 2001-02-18   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;
using System.Collections;

internal class ThreeIntegers2 : IEnumerable
{
    private readonly int i1, i2, i3;

    public ThreeIntegers2(int i1, int i2, int i3)
    {
        this.i1 = i1;
        this.i2 = i2;
        this.i3 = i3;
    }

    public virtual IEnumerator GetEnumerator() => new MonEnumerateur(this);

    public virtual IDictionaryEnumerator GetDictionaryEnumerator() => new MonEnumerateur(this);

    private class MonEnumerateur : IDictionaryEnumerator
    {
        private int pos;
        private readonly ThreeIntegers2 tcur;

        public MonEnumerateur(ThreeIntegers2 t)
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