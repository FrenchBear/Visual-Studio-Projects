// Boxes
// Example of Unicode boxes characters (range 25)
// http://www.alanflavell.org.uk/unicode/unidata25.html

// 2015-05-04   PV
// 2021-09-26   PV      VS2022; Net6

using System;
using static System.Console;

namespace CS_529;

internal class Program
{
    private static void Main(string[] args)
    {
        for (var i = 0x2574; i < 0x257c; i++)
            Console.Write((char)i);
        WriteLine();
        WriteLine();

        var box_hz = '\u2500';
        var box_vt = '\u2502';
        var box_dr = '\u250c';
        var box_dl = '\u2510';
        var box_ur = '\u2514';
        var box_ul = '\u2518';

        var hz = "\u2500\u2500";
        var vt = "\u2502 ";
        var dr = "\u250c\u2500";
        var dl = "\u2510 ";
        var ur = "\u2514\u2500";
        var ul = "\u2518 ";
        var er = "\u2500 ";

        WriteLine(box_hz + " " + box_vt + " " + box_dr + " " + box_dl + " " + box_ur + " " + box_ul);
        WriteLine();
        WriteLine(hz + " " + vt + " " + dr + " " + dl + " " + ur + " " + ul);

        WriteLine(dr + dl + dr + dl);
        WriteLine(vt + ur + ul + vt);
        WriteLine(ur + dl + dr + ul);
        WriteLine(hz + ul + ur + er);
    }
}