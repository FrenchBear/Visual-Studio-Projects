﻿// Construction d'une classe énumérable avec foreach en C#
// ThreeIntegers4 utilise yield return, beaucoup plus simple que les autres implémentations!
//
// 2012-02-25	PV		VS2010   First implementation
// 2012-03-03	PV		Finally found a way to implement IEnumerable<T> (which implements IEnumerable> with an iterator
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System.Collections;
using System.Collections.Generic;

internal class ThreeIntegers4(int i1, int i2, int i3): IEnumerable<int>
{
    private readonly int i1 = i1, i2 = i2, i3 = i3;

    private IEnumerator<int> MyEnumerator()
    {
        yield return i1;
        yield return i2;
        yield return i3;
    }

    public IEnumerator GetEnumerator() => MyEnumerator();

    IEnumerator<int> IEnumerable<int>.GetEnumerator() => MyEnumerator();
}
