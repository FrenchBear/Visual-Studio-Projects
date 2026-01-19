// 2021-09-19	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System;
using System.Collections.ObjectModel;

#pragma warning disable IDE0051 // Remove unused private members

namespace CS203;

internal class Meute<T> where T : Animal
{
    private readonly Collection<T> mCol;

    public Meute() => mCol = [];

    public Meute(T a1) =>
        // Using a Collection Initializer
        mCol = [a1];

    public void Add(T a1) => mCol.Add(a1);

    public void Enerver()
    {
        foreach (var a in mCol)
        {
            a.Enerver();
        }
    }
}

// Custom Event Handler in C#
internal class Events
{
    private event EventHandler PreDrawEvent;

    private event EventHandler OnDraw
    {
        add
        {
            lock (PreDrawEvent)
            {
                PreDrawEvent += value;
            }
        }
        remove
        {
            lock (PreDrawEvent)
            {
                PreDrawEvent -= value;
            }
        }
    }
}
