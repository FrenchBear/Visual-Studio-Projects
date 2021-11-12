// 2021-09-26   PV      VS2022; Net6

using System;
using System.Collections.Generic;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable CS0219 // Variable is assigned but its value is never used

namespace CS547;

internal class Program
{
    private static void Main(string[] args)
    {
        var f1 = 3.14d;     // double
        var f2 = 3.14f;     // float
        var f3 = 3.14m;     // decimal
        var x = f1 + f2;
        var ts1 = new[] { "A", "B", "C" };                   // Initialization of an array implicitly declared
        var ts2 = new List<string> { "A", "B", "C" };
        string[] ts3 = { "A", "B" };
        int[] t3 = new int[3] { 0, 1, 2 };                  // Explicit initialization of an array (though dimension cannot be put in LHS)
        int[] t4 = { 1, 2, 3, 4 };
    }
}

internal interface I1
{
    void Method1();

    void Method2();

    void Method3();
}

internal interface I2
{
    void Method1();

    void Method2();

    void Method4();
}

public class MyClass : I1, I2
{
    // Common for I1 and I2 interfaces, implicit implementation
    public void Method1() => throw new NotImplementedException();

    // With explicit implementation of interface member, public is implicit (and forbidden)
    void I1.Method2() => throw new NotImplementedException();

    public void Method3() => throw new NotImplementedException();

    void I2.Method1() => throw new NotImplementedException();

    void I2.Method2() => throw new NotImplementedException();

    void I2.Method4() => throw new NotImplementedException();
}