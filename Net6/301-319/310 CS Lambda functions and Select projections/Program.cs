﻿// 310 CS Lambda functions and Select projections
//
// 2012-03-04   PV
// 2021-09-20   PV  VS2022; Net6

using System;
using System.Collections.Generic;
using System.Linq;

namespace CS310;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] fruits = {
            "apple",
            "passionfruit",
            "banana",
            "mango",
            "orange",
            "blueberry",
            "grape",
            "strawberry"};

        // Project the length of each string and
        // put the length values into an enumerable object.
        IEnumerable<int> lengths;
        // With a lambda function
        lengths = fruits.Select(fruit => fruit.Length);

        // With a generic delegate
        // Note: a custom delegate does not work since there are no delegates conversions
        Func<string, int> selector = LengthOfString;
        lengths = fruits.Select(selector);

        // Display the results.
        System.Text.StringBuilder output = new();
        foreach (int length in lengths)
            output.AppendLine(length.ToString());

        Console.WriteLine(output.ToString());
    }

    private static int LengthOfString(string s) 
        => s.Length;
}