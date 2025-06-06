﻿// 210 CS Type Characters
//
// 2012-02-25	PV		First version
// 2021-09-19	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace CS210_Type_Characters;

internal class Program
{
    private static void Main(string[] args)
    {
        // Ignore variable unused warning
#pragma warning disable 0219

        // Hover with mouse on var keyword to see inferred type
        var v_int = 1;
        var v_unsigned = 1u;
        var v_long = 1L;
        var v_unsignedlong = 1UL;

        var v_float = 3.14f;
        var v_double = 1.414d;
        var v_decimal = 6.55957m;
    }
}
