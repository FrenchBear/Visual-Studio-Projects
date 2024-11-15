// 520 CS StringDecomposition
// Compare different forms of Unicode string decomposition
//
// 2014-03-26   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System.Text;
using static System.Console;

namespace StringDecomposition;

internal class Program
{
    private static void Main(string[] args)
    {
        var s = "ắ";
        Decomp(s, NormalizationForm.FormC);
        Decomp(s, NormalizationForm.FormD);
        Decomp(s, NormalizationForm.FormKC);
        Decomp(s, NormalizationForm.FormKD);
    }

    private static void Decomp(string s, NormalizationForm nf)
    {
        var sd = s.Normalize(nf);
        Write(nf + ": ");
        foreach (var c in sd)
        {
            Write("u+" + ((int)c).ToString("x4") + " ");
        }
        WriteLine();
    }
}
