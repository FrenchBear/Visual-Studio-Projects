// Exemple d'utilisation de la classe complexe
// Résolution d'une équation du 3è degré
// 2004-01-25   PV
// 2006-10-01   PV  VS2005
// 2012-02-04   PV  VS2010

using System;

namespace CS92
{
    internal class Class1
    {
        [STAThread]
        private static void Main(string[] args)
        {
            P3(1.0, -6.0, 11.0, -6.0, out Complex r1, out Complex r2, out Complex r3);
            // 3 solutions réelles, 1, 2 et 3
            Console.WriteLine("x1={0}\nx2={1}\nx3={2}", r1, r2, r3);
            Console.ReadLine();
        }

        private static void P3(double a, double b, double c, double d, out Complex x1, out Complex x2, out Complex x3)
        {
            Complex i = new Complex(0, 1);

            x1 = Complex.Pow(36.0 * c * b * a - 108.0 * d * a * a - 8.0 * Complex.Pow(b, 3.0) + 12.0 * Complex.Sqrt(3.0) * Complex.Sqrt(4.0 * Complex.Pow(c, 3.0) * a - c * c * b * b - 18.0 * c * b * a * d + 27.0 * d * d * a * a + 4.0 * d * Complex.Pow(b, 3.0)) * a, 1.0 / 3.0) / a / 6.0 - 2.0 / 3.0 * (3.0 * c * a - b * b) / a * Complex.Pow(36.0 * c * b * a - 108.0 * d * a * a - 8.0 * Complex.Pow(b, 3.0) + 12.0 * Complex.Sqrt(3.0) * Complex.Sqrt(4.0 * Complex.Pow(c, 3.0) * a - c * c * b * b - 18.0 * c * b * a * d + 27.0 * d * d * a * a + 4.0 * d * Complex.Pow(b, 3.0)) * a, -1.0 / 3.0) - b / a / 3.0;
            x2 = -Complex.Pow(36.0 * c * b * a - 108.0 * d * a * a - 8.0 * Complex.Pow(b, 3.0) + 12.0 * Complex.Sqrt(3.0) * Complex.Sqrt(4.0 * Complex.Pow(c, 3.0) * a - c * c * b * b - 18.0 * c * b * a * d + 27.0 * d * d * a * a + 4.0 * d * Complex.Pow(b, 3.0)) * a, 1.0 / 3.0) / a / 12.0 + (3.0 * c * a - b * b) / a * Complex.Pow(36.0 * c * b * a - 108.0 * d * a * a - 8.0 * Complex.Pow(b, 3.0) + 12.0 * Complex.Sqrt(3.0) * Complex.Sqrt(4.0 * Complex.Pow(c, 3.0) * a - c * c * b * b - 18.0 * c * b * a * d + 27.0 * d * d * a * a + 4.0 * d * Complex.Pow(b, 3.0)) * a, -1.0 / 3.0) / 3.0 - b / a / 3.0 + i * Complex.Sqrt(3.0) * (Complex.Pow(36.0 * c * b * a - 108.0 * d * a * a - 8.0 * Complex.Pow(b, 3.0) + 12.0 * Complex.Sqrt(3.0) * Complex.Sqrt(4.0 * Complex.Pow(c, 3.0) * a - c * c * b * b - 18.0 * c * b * a * d + 27.0 * d * d * a * a + 4.0 * d * Complex.Pow(b, 3.0)) * a, 1.0 / 3.0) / a / 6.0 + 2.0 / 3.0 * (3.0 * c * a - b * b) / a * Complex.Pow(36.0 * c * b * a - 108.0 * d * a * a - 8.0 * Complex.Pow(b, 3.0) + 12.0 * Complex.Sqrt(3.0) * Complex.Sqrt(4.0 * Complex.Pow(c, 3.0) * a - c * c * b * b - 18.0 * c * b * a * d + 27.0 * d * d * a * a + 4.0 * d * Complex.Pow(b, 3.0)) * a, -1.0 / 3.0)) / 2.0;
            x3 = -Complex.Pow(36.0 * c * b * a - 108.0 * d * a * a - 8.0 * Complex.Pow(b, 3.0) + 12.0 * Complex.Sqrt(3.0) * Complex.Sqrt(4.0 * Complex.Pow(c, 3.0) * a - c * c * b * b - 18.0 * c * b * a * d + 27.0 * d * d * a * a + 4.0 * d * Complex.Pow(b, 3.0)) * a, 1.0 / 3.0) / a / 12.0 + (3.0 * c * a - b * b) / a * Complex.Pow(36.0 * c * b * a - 108.0 * d * a * a - 8.0 * Complex.Pow(b, 3.0) + 12.0 * Complex.Sqrt(3.0) * Complex.Sqrt(4.0 * Complex.Pow(c, 3.0) * a - c * c * b * b - 18.0 * c * b * a * d + 27.0 * d * d * a * a + 4.0 * d * Complex.Pow(b, 3.0)) * a, -1.0 / 3.0) / 3.0 - b / a / 3.0 - i * Complex.Sqrt(3.0) * (Complex.Pow(36.0 * c * b * a - 108.0 * d * a * a - 8.0 * Complex.Pow(b, 3.0) + 12.0 * Complex.Sqrt(3.0) * Complex.Sqrt(4.0 * Complex.Pow(c, 3.0) * a - c * c * b * b - 18.0 * c * b * a * d + 27.0 * d * d * a * a + 4.0 * d * Complex.Pow(b, 3.0)) * a, 1.0 / 3.0) / a / 6.0 + 2.0 / 3.0 * (3.0 * c * a - b * b) / a * Complex.Pow(36.0 * c * b * a - 108.0 * d * a * a - 8.0 * Complex.Pow(b, 3.0) + 12.0 * Complex.Sqrt(3.0) * Complex.Sqrt(4.0 * Complex.Pow(c, 3.0) * a - c * c * b * b - 18.0 * c * b * a * d + 27.0 * d * d * a * a + 4.0 * d * Complex.Pow(b, 3.0)) * a, -1.0 / 3.0)) / 2.0;
        }
    }
}