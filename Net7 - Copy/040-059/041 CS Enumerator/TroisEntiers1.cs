// Construction d'une classe �num�rable avec foreach en C#
// ThreeIntegers1 impl�mente une interface de type IEnumerator simple
// 2001-02-18   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;
using System.Collections;

internal class ThreeIntegers1 : IEnumerable
{
    private readonly int i1, i2, i3;

    public ThreeIntegers1(int i1, int i2, int i3)
    {
        this.i1 = i1;
        this.i2 = i2;
        this.i3 = i3;
    }

    public virtual IEnumerator GetEnumerator() => new MonEnumerateur(this);

    private class MonEnumerateur : IEnumerator
    {
        private int pos;
        private readonly ThreeIntegers1 tcur;

        public MonEnumerateur(ThreeIntegers1 t)
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

        public object Current => pos switch
        {
            0 => tcur.i1,
            1 => tcur.i2,
            2 => tcur.i3,
            _ => throw new InvalidOperationException(),
        };

        public void Reset() => pos = -1;
    }
}