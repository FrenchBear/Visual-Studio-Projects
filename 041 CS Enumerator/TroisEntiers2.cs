// Construction d'une classe énumérable avec foreach en C#
// ThreeIntegers2 implémente une fonction GetDictionaryEnumerator retournant un
// énumérateur de type IDictionaryEnumerator (key+value)
// 2001-02-18   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

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

    public virtual IEnumerator GetEnumerator()
    {
        return new MonEnumerateur(this);
    }

    public virtual IDictionaryEnumerator GetDictionaryEnumerator()
    {
        return new MonEnumerateur(this);
    }

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