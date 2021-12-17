﻿// 2021-09-23   PV  VS2022; Net6

using System;
using static System.Console;

namespace CS422;

internal class Program
{
    private static void Main(string[] args)
    {
        var sc = new SomeClass();

        Func<int, int> del = sc.GetDelegate();
        int i1 = del(10);
        int i2 = del(3);
        WriteLine(i1);
        WriteLine(i2);

        Func<int, int> del2 = sc.GetDelegate2();
        int j1 = del2(10);
        int j2 = del2(3);
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
        int sum = 0;
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
        DisplayClass1 locals2;
        locals2 = new DisplayClass1
        {
            __this = this,
            sum = 0
        };
        return (Func<int, int>)locals2.GetDelegate__0;
    }
}