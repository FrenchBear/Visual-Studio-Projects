// DoubleAlmostEqual
//
// Special implementation of double comparison insensitive to rounding errors, for units coefficients comparison
// knowing that range of values to compare may vary between 1e-24 and 1e24, so direct difference does not work.
// So remains dividing min by max or comparing logs...
//
// 2015-09-15   FPVI    First version


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleAlmostEqual
{
    class Program
    {
        static void Main(string[] args)
        {
            T(0.0, 0.0, true);
            T(0.0, 1.0, false);
            T(1.0, 1.0, true);
            T(1.0, 2.0, false);

            T(0.9999999999e-24, 1e-24, true);

            double[] values = new double[] { 0.0, 0.9999999999e-24, 1e-24, 1.00000000001e-24, 1e-23, 1e-15, 0.9999999999e-5, 1e-5, 1.00000000001e-5, 1e-1, 0.9999999999, 1.0, 1.00000000001, 1e1, 0.9999999999e5, 1e5, 1.00000000001e5, 1e15, 1e23, 0.9999999999e24, 1e24, 1.00000000001e24 };
            int[] classes = new int[] { 1, 2, 2, 2, 3, 4, 5, 5, 5, 6, 7, 7, 7, 8, 9, 9, 9, 10, 11, 12, 12, 12 };

            for (int i = 0; i < values.Length; i++)
            {
                double d1 = values[i];
                foreach (int s1 in new int[] { -1, 1 })
                    for (int j = 0; j < values.Length; j++)
                    {
                        double d2 = values[j];
                        foreach (int s2 in new int[] { -1, 1 })
                            T(d1 * s1, d2 * s2, ((s1 == s2 && classes[i] == classes[j])) || (d1 == 0.0 && d2 == 0.0));
                    }
            }

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        static void T(double d1, double d2, bool expectedresult)
        {
            if (DoubleAlmostEqual(d1, d2) != expectedresult)
                Console.WriteLine($"{d1}=={d2}, expected {expectedresult}, got {DoubleAlmostEqual(d1, d2)}");
        }

        // My own version of double comparison for units coefficients
        static bool DoubleAlmostEqual(double d1, double d2)
        {
            if (d1 == d2) return true;                              // simple case, if binary equality, done.
            if (d1 == 0.0 || d2 == 0.0) return false;               // 0.0 compared to not 0.0 s always false here
            if (Math.Sign(d1) != Math.Sign(d2)) return false;       // A positive is never equals to a negative
            if (d1 < 0) d1 = -d1;
            if (d2 < 0) d2 = -d2;
            return Math.Abs(Math.Log(d1) - Math.Log(d2)) < 1e-8;    // Compare based on magnitude
            // With natural log, if d1 and d2 differ on the 11th decimal, the difference in logs is ~1e-11 --> 1e-8 = match on ~8 significant digits
        }
    }
}
