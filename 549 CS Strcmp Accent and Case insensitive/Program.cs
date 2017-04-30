// 549 CS Strcmp Accent and Case insensitive
// Comparison and searches both case and accent insensitive
// Note: Do not bother about special case of I in Turkish (İ I i ı)

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using static System.Console;


namespace CS549
{
    class Program
    {
        const string file = @"W:\Livres\Art\Colorisation de BD - Du traditionnel au numérique (2005) - Baril, Naïts.pdf";
        static void Main(string[] args)
        {
            string s1 = "MaÏs";
            string s2 = "Mais";

            int cmp = string.Compare(s1, s2, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase);

            WriteLine($"cmp(\"{s1}\", \"{s2}\"): {cmp}");
            WriteLine($"ContainsAICI: {ContainsAICI(file, "ITS")}");

            WriteLine();
            TimeExec(RemoveDiacritics);
            TimeExec(RemoveDiacritics2);

            WriteLine();
            Write("(Pause)");
            ReadLine();

        }

        // StringContains both Accent Insensitive and Case Insensitive
        private static bool ContainsAICI(string searched, string value)
        {
            return RemoveDiacritics(searched).IndexOf(RemoveDiacritics(value), StringComparison.InvariantCultureIgnoreCase) >= 0;
        }


        delegate string StringToString(string s);

        static void TimeExec(StringToString f)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                string sSource = file;
                string sRes = f(sSource);
            }
            WriteLine($"Time: {sw.Elapsed}");
        }


        static string RemoveDiacritics(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char ch in text.Normalize(NormalizationForm.FormD))
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
        static string RemoveDiacritics2(string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                                              UnicodeCategory.NonSpacingMark)
              ).Normalize(NormalizationForm.FormC);
        }
    }
}
