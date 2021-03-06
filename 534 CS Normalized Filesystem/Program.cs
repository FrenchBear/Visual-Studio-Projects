﻿using System;
using System.IO;
using System.Text;
using static System.Console;

namespace Normalized_Filesystem
{
    internal class Program
    {
        private static readonly string normalizedName = @"Où ça, là!.txt";
        private static string denormalizedName;

        private static void Main(string[] args)
        {
            denormalizedName = normalizedName.Normalize(NormalizationForm.FormD);

            using (FileStream fs = File.Create(Path.Combine(@"c:\temp", normalizedName)))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                fs.Write(info, 0, info.Length);
            }

            if (File.Exists(Path.Combine(@"c:\temp", denormalizedName)))
                WriteLine("Denormalized exists");
            else
            {
                WriteLine("Denormalized does not exist");
                using (FileStream fs = File.Create(Path.Combine(@"c:\temp", denormalizedName)))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("Another file.");
                    fs.Write(info, 0, info.Length);
                }
            }

            WriteLine(string.Compare(normalizedName, denormalizedName, StringComparison.CurrentCulture));
            WriteLine(string.Compare(normalizedName, denormalizedName, StringComparison.CurrentCultureIgnoreCase));
            WriteLine(string.Compare(normalizedName, denormalizedName, StringComparison.InvariantCulture));
            WriteLine(string.Compare(normalizedName, denormalizedName, StringComparison.InvariantCultureIgnoreCase));
            WriteLine(string.Compare(normalizedName, denormalizedName, StringComparison.Ordinal));
            WriteLine(string.Compare(normalizedName, denormalizedName, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }
}