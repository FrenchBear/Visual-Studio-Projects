// 608 CS φ and ϕ
// 2017-01-17   PV  Extract from CS601, to show the problem
//
// Display φ and ϕ, shown as ϕ and φ in Consolas (and Calibri), that's a known problem with old fonts...
//
// From Wikipedia, https://en.wikipedia.org/wiki/Phi:
//   Prior to Unicode version 3.0 (1998), the glyph assignments in the Unicode code charts were the reverse, 
//   and thus older fonts may still show a loopy form φ at U+03D5
//
// From Unicode® Technical Report #25, Unicode Support for Mathematics http://unicode.org/reports/tr25/:
//   2.3.1 Representative Glyphs for Greek Phi
//     With Unicode 3.0 and the concurrent second edition of ISO / IEC 10646 - 1, the representative
//     glyphs for U+03C6 GREEK LETTER SMALL PHI φ and U+03D5 GREEK PHI SYMBOL ϕ were exchanged.
//     In ordinary Greek text, the character U+03C6 φ is used exclusively, although this
//     character has considerable glyphic variation, sometimes represented with a glyph more like
//     the representative glyph shown for U+03C6(φ, the “loopy” form) and less often with a glyph
//     more like the representative glyph shown for U+03D5(ϕ, the “straight“ form).
//     See the Greek table in the character code charts http://www.unicode.org/charts/PDF/U0370.pdf


using System;
using System.Text;
using static System.Console;


namespace CS608
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = new UTF8Encoding();

            WriteLine("Display φ and ϕ, shown as ϕ and φ in Consolas (and Calibri)");

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }
}
