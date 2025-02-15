﻿// Arith2CSb, C# version of Arithmetic Doubler
//
// Generic arithmetic class doubling the capacity of a base class for Plus and Mult
// and recursive use example (of course, for each level computation time also double)
// Use decimal slicing to eliminate the complexity of base 2 <-> base 10 conversions
// Actually this is a test for ValueTuple introduced with Visual Studio 2017, and
// verity whether some metaprogramming can be done in C#
//
// This is version b that use a singleton MetaClass to provide static methods and constructors
// instead of forcing them into dynamic methods.  If also make these classes immutable.
// This is more efficient, test time on Int1024d is halh the one of Arith2CS
//
// 2017-01-21   PV      First version
// 2017-01-22   PV      Verification using BigInteger
// 2017-01-24   PV      Test timing
// 2017-01-25   PV      Version b with MétaClasses
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using static System.Console;

namespace CS609b;

#pragma warning disable CA1708 // Identifiers should differ by more than case

using Int1024d = DA<DA<DA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>, MetaDA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>>, MetaDA<DA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>, MetaDA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>>>;
using Int128d = DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>;

// Repacking for simplified use, arithmetic on 64 digits
// Note that using Int64d = DA<Int32d>; is not accepted
using Int16d = DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>;
using Int256d = DA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>;
using Int32d = DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>;
using Int512d = DA<DA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>, MetaDA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>>;
using Int64d = DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>;
using MetaInt1024d = MetaDA<DA<DA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>, MetaDA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>>, MetaDA<DA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>, MetaDA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>>>;
using MetaInt128d = MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>;
using MetaInt16d = MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>;
using MetaInt256d = MetaDA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>;
using MetaInt32d = MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>;
using MetaInt512d = MetaDA<DA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>, MetaDA<DA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>, MetaDA<DA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>, MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>>>>;
using MetaInt64d = MetaDA<DA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>, MetaDA<DA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>, MetaDA<DA<IntBase, MetaIntBase>, MetaDA<IntBase, MetaIntBase>>>>;

// Interface of a simple arithmetic class, actually just core functions since interesting ones
// are in the MetaClass.  Note that implementation must provide constructors that are not
// mentioned here
public interface ISimpleArith<T>
{
    int Digits { get; }

    bool IsZero();

    string ToString();

    string ToStringWithLeadingZeros();
}

// Interface of associated singleton MetaClass providing "static" methods and Factories
// to replace constructors since neither can be part of base interface.  Factories call
// contructors from base class
public interface IMetaSimpleArith<T>
{
    T FromString(string s);

    T FromOther(T other);

    (T high, T low) Plus(params T[] list);

    (T high, T low) Mult(T a, T b);

    string ToString2(T a, T b);
}

// MetaClass for IntBase
public class MetaIntBase: IMetaSimpleArith<IntBase>
{
    // Factory from string
    public IntBase FromString(string s) => string.IsNullOrEmpty(s) || s.Length > IntBase.digits || !int.TryParse(s, out var val)
            ? throw new ArgumentException("Invalid constructor call")
            : new IntBase(val);

    // Factory from other (copy constructor)
    public IntBase FromOther(IntBase other) => new(other.val);

    // Addition of a paramarray of IntBase, high part contains the overflow carry
    public (IntBase high, IntBase low) Plus(params IntBase[] list)
    {
        var x = list.First().val;
        foreach (var item in list.Skip(1))
            x += item.val;

        var h = x / IntBase.k;
        var l = x % IntBase.k;
        return (new IntBase(h), new IntBase(l));
    }

    // Multiplication of two IntBase.  Internally no need for long, an int can store 8 digits.
    public (IntBase high, IntBase low) Mult(IntBase a, IntBase b)
    {
        var x = a.val * b.val;
        var h = x / IntBase.k;
        var l = x % IntBase.k;
        return (new IntBase(h), new IntBase(l));
    }

    // Helper for testing, prints a pair of IntBase numbers as a singmle number
    public string ToString2(IntBase a, IntBase b) => a.val > 0 ? a.ToString() + b.ToStringWithLeadingZeros() : b.ToString();
}

// Base arithmetic class providing 4 decimal digits precision using
// native (processor) support of int
public class IntBase: ISimpleArith<IntBase>
{
    // Native storage for base class
    internal int val;

    // Implementation choice, could as well use long and 8 digits
    internal const int digits = 4;

    internal const int k = 10000;        // 10^digits

    // Instance property so that doubling class can retrieve it
    public int Digits => digits;

    // A public parameterless constructor is needed
    public IntBase() => val = 0;

    // Not part of interface, called by MetaClass
    internal IntBase(int x)
    {
        if (x is < 0 or > k)
            throw new ArgumentException("Invalid constructor call");
        val = x;
    }

    // Convenient helper for output formatting
    public bool IsZero() => val == 0;

    public override string ToString() => val.ToString();

    // Output always formatted using 'digits' digits
    public string ToStringWithLeadingZeros() => (val + k).ToString()[1..];
}

// Associated MetaClass of DA<T, MetaT>
public class MetaDA<T, TMeta>: IMetaSimpleArith<DA<T, TMeta>>
    where T : ISimpleArith<T>, new()
    where TMeta : IMetaSimpleArith<T>, new()
{
    // Metaclass is a singleton
    private static readonly TMeta m = new();

    public DA<T, TMeta> FromString(string s)
        => string.IsNullOrEmpty(s) || s.Length > DA<T, TMeta>.digits
            ? throw new ArgumentException("Invalid constructor call")
            : s.Length > DA<T, TMeta>.digits / 2
            ? new DA<T, TMeta>(m.FromString(s[..^(DA<T, TMeta>.digits / 2)]),
                m.FromString(s[^(DA<T, TMeta>.digits / 2)..]), true)
            : new DA<T, TMeta>(new T(), m.FromString(s), true);

    public DA<T, TMeta> FromOther(DA<T, TMeta> other) => new(other.high, other.low, true);

    public (DA<T, TMeta> high, DA<T, TMeta> low) Plus(params DA<T, TMeta>[] list)
    {
        var h = list.First().high;      // Not starting with 0 and adding 1st element is
        var l = list.First().low;       // A huuuuuuuuuge performance improvement (both C# and C++)
        var ovl = new T();
        //var ovh = list.Length == 1 ? new T() : throw new Exception("default value returned here");
        var ovh = list.Length == 1 ? new T() : default;

        foreach (var item in list.Skip(1))
        {
            T ov1, ov2;
            (ov1, l) = m.Plus(l, item.low);
            (ov2, h) = m.Plus(h, item.high, ov1);
            (ovh, ovl) = m.Plus(ovl, ov2);
        }

#pragma warning disable CS8604 // Possible null reference argument.
        return (new DA<T, TMeta>(ovh, ovl, true), new DA<T, TMeta>(h, l, true));
#pragma warning restore CS8604 // Possible null reference argument.
    }

    public (DA<T, TMeta> high, DA<T, TMeta> low) Mult(DA<T, TMeta> a, DA<T, TMeta> b)
    {
        T lowH, lowL;
        T highH, highL;

        (lowH, lowL) = m.Mult(a.low, b.low);
        (var t1h, var t1l) = m.Mult(a.high, b.low);
        (var t2h, var t2l) = m.Mult(a.low, b.high);
        (highH, highL) = m.Mult(a.high, b.high);

        T ov1, ov2;
        (ov1, lowH) = m.Plus(lowH, t1l, t2l);
        (ov2, highL) = m.Plus(highL, t1h, t2h, ov1);
        (_, highH) = m.Plus(highH, ov2);

        return (new DA<T, TMeta>(highH, highL, true), new DA<T, TMeta>(lowH, lowL, true));
    }

    public string ToString2(DA<T, TMeta> a, DA<T, TMeta> b) => a.IsZero() ? b.ToString() : a + b.ToStringWithLeadingZeros();
}

// Double Arithmetic: provides twice the capacity of type T that implements ISimpleArith
// and this class in turn also implements ISimpleArith
// so it's Ok to instantiate DA<Int4d>, DA<DA<Int4d>>, DA<DA<DA<Int4d>>>...
public class DA<T, TMeta>: ISimpleArith<DA<T, TMeta>>
    where T : ISimpleArith<T>, new()
    where TMeta : IMetaSimpleArith<T>, new()
{
    internal T high;
    internal T low;

    // Metaclass is a singleton
    private static readonly TMeta m = new();

    internal static int digits;
    public int Digits => digits;

    // Static constructor to initialize static variable returned by an instance property that can be included in interface...
    static DA() => digits = 2 * new T().Digits;

    public DA()
    {
        // An initialization to 0
        low = new T();
        high = new T();
    }

    // Private constructor for intermediate calculations, with "move optimisation" when
    // it's safe to refer to the same internal members as h and l (when h and l are rvalues)
    public DA(T h, T l, bool isMove = false)
    {
        if (isMove)
        {
            high = h;
            low = l;
        }
        else
        {
            high = m.FromOther(h);
            low = m.FromOther(l);
        }
    }

    public bool IsZero() => high.IsZero() && low.IsZero();

    public override string ToString() => high.IsZero() ? low.ToString() : high.ToString() + low.ToStringWithLeadingZeros();

    public string ToStringWithLeadingZeros() => high.ToStringWithLeadingZeros() + low.ToStringWithLeadingZeros();
}

internal class Program
{
    private static void Test<T, MetaT>()
        where T : ISimpleArith<T>, new()
        where MetaT : IMetaSimpleArith<T>, new()
    {
        var d = new T().Digits;
        var rnd = new Random();

        string GetRandomNumber()
        {
            var sb = new StringBuilder(d);
            for (var i = 0; i < d; i++)
                _ = sb.Append((char)(48 + rnd.Next(0, 10)));
            return sb.ToString();
        }

        WriteLine($"Test Int{d}d");
        var astr = GetRandomNumber();
        var bstr = GetRandomNumber();
        var sw = Stopwatch.StartNew();
        var m = new MetaT();
        var a = m.FromString(astr);
        var b = m.FromString(bstr);
        WriteLine($"a{d}: {a.ToString()}");
        WriteLine($"b{d}: {b.ToString()}");
        (var h, var l) = m.Plus(a, b);
        var sumstr = m.ToString2(h, l);
        WriteLine($"a{d}+b{d}: {sumstr}");
        (h, l) = m.Mult(a, b);
        var prodstr = m.ToString2(h, l);
        WriteLine($"a{d}.b{d}: {prodstr}");
        sw.Stop();

        // Check using BigInteger
        var swc = Stopwatch.StartNew();
        var abi = BigInteger.Parse(astr);
        var bbi = BigInteger.Parse(bstr);
        var sumbi = abi + bbi;
        var prodbi = abi * bbi;
        Write("Sum: " + (sumbi.ToString() == sumstr ? "Ok" : "Error"));
        WriteLine(",  Prod: " + (prodbi.ToString() == prodstr ? "Ok" : "Error"));
        WriteLine($"Elapsed: {sw.ElapsedMilliseconds} ms,  Check: {swc.ElapsedMilliseconds} ms");

        WriteLine();
    }

    private static void Main(string[] args)
    {
        MetaIntBase m = new();

        var a = m.FromString("8000");
        var b = m.FromString("7000");
        WriteLine($"a: {a}");
        WriteLine($"b: {b}");
        (var h, var l) = m.Plus(a, b);
        WriteLine($"a+b: " + m.ToString2(h, l));
        (h, l) = m.Mult(a, b);
        WriteLine($"a.b: " + m.ToString2(h, l));
        WriteLine();

        MetaDA<IntBase, MetaIntBase> m8 = new();
        var a8 = m8.FromString("12345678");
        var b8 = m8.FromString("87654321");
        WriteLine($"a8: {a8}");
        WriteLine($"b8: {b8}");
        (var h8, var l8) = m8.Plus(a8, b8);
        WriteLine($"a8+b8: " + m8.ToString2(h8, l8));
        (h8, l8) = m8.Mult(a8, b8);
        WriteLine($"a8.b8: " + m8.ToString2(h8, l8));
        WriteLine();

        Test<Int16d, MetaInt16d>();
        Test<Int32d, MetaInt32d>();
        Test<Int64d, MetaInt64d>();
        Test<Int128d, MetaInt128d>();
        Test<Int256d, MetaInt256d>();
        Test<Int512d, MetaInt512d>();
        Test<Int1024d, MetaInt1024d>();
    }
}
