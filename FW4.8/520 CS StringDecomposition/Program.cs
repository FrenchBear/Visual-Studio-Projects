// 520 CS StringDecomposition
// Compare different forms of unicode string decoposition
// 2014-03-26   PV

using System;
using System.Text;

namespace StringDecomposition
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string s = "ắ";
            Decomp(s, NormalizationForm.FormC);
            Decomp(s, NormalizationForm.FormD);
            Decomp(s, NormalizationForm.FormKC);
            Decomp(s, NormalizationForm.FormKD);

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        private static void Decomp(string s, NormalizationForm nf)
        {
            string sd = s.Normalize(nf);
            Console.Write(nf.ToString() + ": ");
            foreach (char c in sd)
            {
                Console.Write("u+" + ((int)c).ToString("x4") + " ");
            }
            Console.WriteLine();
        }
    }
}