// Construction d'une classe énumérable avec foreach en C#
// ThreeIntegers1 implémente une interface de type IEnumerator simple
// 2001-02-18   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010


using System;
using System.Collections;


class ThreeIntegers1 : IEnumerable
{
    private int i1, i2, i3;

    public ThreeIntegers1(int i1, int i2, int i3)
    {
        this.i1 = i1;
        this.i2 = i2;
        this.i3 = i3;
    }

    public virtual IEnumerator GetEnumerator()
    {
        return new MonEnumerateur(this);
    }

    private class MonEnumerateur : IEnumerator
    {
        private int pos;
        private ThreeIntegers1 tcur;

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

        public object Current
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

        public void Reset()
        {
            pos = -1;
        }

    }
}

