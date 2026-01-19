// 638 CS LinkedList
// Play with LinkedList to understand what first/last means
//
// 2024-01-03   PV
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System;
using System.Collections.Generic;

namespace CS638;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("638 CS LinkedList\n");

        var l = new LinkedList<char>();
        l.AddLast('a');
        l.AddLast('b');
        l.AddLast('c');

        Console.WriteLine(string.Join(" ", l));
        l.AddLast('d');
        Console.WriteLine(string.Join(" ", l));

        var c = l.First;        // Without parentheses, otherwise we're callink a Link extension
        Console.WriteLine($"First: {c}");
        l.RemoveFirst();
        Console.WriteLine("After RemoveFirst");
        Console.WriteLine(string.Join(" ", l));
        l.RemoveLast();
        Console.WriteLine("After RemoveLast");
        Console.WriteLine(string.Join(" ", l));
    }
}
