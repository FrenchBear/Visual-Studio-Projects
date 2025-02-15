﻿// 517 CS IsDerivedFromType
// Implementation of a clean IsDerivedFromType extension method
//
// 2013-09-05   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Reflection;
using static System.Console;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace CS517;

internal class Program
{
    private static readonly object b1 = true;

    private static void Main(string[] args)
    {
        bool? b2 = true;

        var t1 = b1 is bool;
        var t2 = b2 is bool;
        var x2 = b1.GetType();
        var x2b = x2.IsDerivedFromType(x2);
        var t3 = b1.GetType().IsDerivedFromType(typeof(bool));
        var t4 = b2.GetType().IsDerivedFromType(typeof(bool));
        // Beware, GetType on a T? variable returns type T, not T? !!!!

        WriteLine("typeof(bool).IsDerivedFromType(typeof(bool)): {0}", typeof(bool).IsDerivedFromType(typeof(bool)));
        WriteLine("typeof(bool).IsDerivedFromType(typeof(bool?)): {0}", typeof(bool).IsDerivedFromType(typeof(bool?)));
        WriteLine("typeof(bool?).IsDerivedFromType(typeof(bool?)): {0}", typeof(bool?).IsDerivedFromType(typeof(bool?)));

        var tni = typeof(Program).GetProperty("ni", BindingFlags.Static | BindingFlags.Public).PropertyType;
        WriteLine("tni.IsDerivedFromType(typeof(int)): {0}", tni.IsDerivedFromType(typeof(int)));
        WriteLine("tni.IsDerivedFromType(typeof(int?)): {0}", tni.IsDerivedFromType(typeof(int?)));
        WriteLine("tni.IsDerivedFromType(typeof(Nullable)): {0}", tni.IsDerivedFromType(typeof(Nullable)));

        WriteLine();
        WriteLine("t = typeof(Nullable)");
        var t = typeof(Nullable);
        WriteLine("t.IsGenericType: {0}", t.IsGenericType);
        WriteLine("t.IsGenericTypeDefinition: {0}", t.IsGenericTypeDefinition);
        WriteLine("t.IsConstructedGenericType: {0}", t.IsConstructedGenericType);
        WriteLine("t.BaseType.Name {0}", t.BaseType.Name);

        WriteLine();
        WriteLine("t = typeof(Nullable<int>)");
        t = typeof(int?);
        WriteLine("t.IsGenericType: {0}", t.IsGenericType);
        WriteLine("t.IsGenericTypeDefinition: {0}", t.IsGenericTypeDefinition);
        WriteLine("t.IsConstructedGenericType: {0}", t.IsConstructedGenericType);
        WriteLine("t.BaseType.Name {0}", t.BaseType.Name);
    }

    public static int? Ni { get; set; }
}

public static partial class ExtensionMethods
{
    // Returns true if current type inherits from t2
    public static bool IsDerivedFromType(this Type t1, Type t2) => t1 == t2 || t1.IsSubclassOf(t2);
}
