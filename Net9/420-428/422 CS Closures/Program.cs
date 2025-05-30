﻿// 2021-09-23	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using static System.Console;

namespace CS422;

internal class Program
{
    private static void Main(string[] args)
    {
        var sc = new SomeClass();

        var del = sc.GetDelegate();
        var i1 = del(10);
        var i2 = del(3);
        WriteLine(i1);
        WriteLine(i2);

        var del2 = sc.GetDelegate2();
        var j1 = del2(10);
        var j2 = del2(3);
        WriteLine(j1);
        WriteLine(j2);
    }
}

internal class SomeClass
{
    private readonly int offset = 2;

    // test of a closure accessing instance local variable and instance class variable
    public Func<int, int> GetDelegate()
    {
        var sum = 0;
        return delegate (int x)
        {
            sum += x;
            return sum + offset;
        };
    }

    // Here is closure generated by compiler (symbols renamed):
    private sealed class DisplayClass1
    {
        // Fields
        public SomeClass __this;

        public int sum;

        // Methods
        public int GetDelegate__0(int x)
        {
            sum += x;
            return sum + __this.offset;
        }
    }

    public Func<int, int> GetDelegate2()
    {
        var locals2 = new DisplayClass1
        {
            __this = this,
            sum = 0
        };
        return locals2.GetDelegate__0;
    }
}
