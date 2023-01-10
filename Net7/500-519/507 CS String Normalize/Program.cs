// 507 CS String Normalize
// Simple test of string normalization (ex: combine a letter and an accent into an accentued letter)
//
// 2013-01-28   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using System.Diagnostics;

namespace CS;

internal class Program
{
    private static void Main(string[] args)
    {
        char[] chars = { '\u0061', '\u0308', '\u0078', '\u0304' };
        // \u0061 = lowercase a
        // \u0308 = " (combining diaeresis)
        // \u0078 = lowercase x
        // \u0304 = ̄  (combining macron)

        // First two characters can be combined into \u00E4 (latin small letter A with diaeresis)
        // Last two characters don't have a packed representation and remain two separate characters

        string combining = new(chars);
        Debug.WriteLine(combining + ' ' + combining.Length);

        combining = combining.Normalize();
        Debug.WriteLine(combining + ' ' + combining.Length);
    }
}
