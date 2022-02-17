// 549 CS Strcmp Accent and Case insensitive
// Comparison and searches both case and accent insensitive
// Note: Do not bother about special case of I in Turkish (İ I i ı)
//
// 2016-09-26   PV
// 2018-09-01   PV      œ example
// 2021-09-26   PV      VS2022; Net6

using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using static System.Console;

namespace CS549;

internal class Program
{
    private const string file = @"Colorisation de BD - Du traditionnel au numérique (2005) - Cœur de Presse - Baril, Naïts.pdf";

    private static void Main()
    {
        var s1 = "MaÏs";
        var s2 = "Mais";

        //string s1 = "Cœur";
        //string s2 = "Coeur";

        var cmp = string.Compare(s1, s2, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase);

        WriteLine($"cmp(\"{s1}\", \"{s2}\"): {cmp}");
        WriteLine($"ContainsAICI ITS:   {ContainsAICI(file, "ITS")}");
        WriteLine($"ContainsAICI Coeur: {ContainsAICI(file, "Coeur")}");

        WriteLine();
        TimeExec(RemoveDiacritics);
        TimeExec(RemoveDiacritics2);
    }

    // StringContains both Accent Insensitive and Case Insensitive
    // Note that oe=œ because of InvariantCulture locale, not because of RemoveDiacritics
    private static bool ContainsAICI(string searched, string value) 
        => RemoveDiacritics(searched).Contains(RemoveDiacritics(value), StringComparison.InvariantCultureIgnoreCase);

    private delegate string StringToString(string s);

    private static void TimeExec(StringToString f)
    {
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < 100000; i++)
        {
            var sSource = file;
            var sRes = f(sSource);
        }
        WriteLine($"Time: {sw.Elapsed}");
    }

    private static string RemoveDiacritics(string text)
    {
        StringBuilder sb = new();
        foreach (var ch in text.Normalize(NormalizationForm.FormD))
        {
            if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                _ = sb.Append(ch);
        }

        return sb.ToString().Normalize(NormalizationForm.FormC);
    }

    private static string RemoveDiacritics2(string text) => string.Concat(
            text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                             UnicodeCategory.NonSpacingMark)
        ).Normalize(NormalizationForm.FormC);
}