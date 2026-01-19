// Construction d'une classe énumérable avec foreach en C#
// ThreeIntegers2 implémente une fonction GetDictionaryEnumerator retournant un
// énumérateur de type IDictionaryEnumerator (key+value)
//
// 2001-02-18   PV
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System;
using System.Collections;

internal class ThreeIntegers2(int i1, int i2, int i3): IEnumerable
{
    private readonly int i1 = i1, i2 = i2, i3 = i3;

    public virtual IEnumerator GetEnumerator() => new MonEnumerateur(this);

    public virtual IDictionaryEnumerator GetDictionaryEnumerator() => new MonEnumerateur(this);

    private class MonEnumerateur(ThreeIntegers2 t): IDictionaryEnumerator
    {
        private int pos = -1;
        private readonly ThreeIntegers2 tcur = t;

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
