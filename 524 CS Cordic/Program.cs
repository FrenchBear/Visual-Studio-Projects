// CS 524 Cordic
// 2014-10-21   PV
// Sine, Cosine calculations using CORDIC algorithm

using System;

namespace Cordic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int n = 15;
            double[] ta, tsin, tcos;
            ta = new double[n];
            tsin = new double[n];
            tcos = new double[n];

            // Build a table of cos and sin for 1, 0.1, 0.01, 0.001, ...
            // Of course, for the real algorithm, we should use predefined constants
            // and probably better distributed than that -- now what's the optimal?
            double a = 1.0;
            for (int i = 0; i < n; i++)
            {
                ta[i] = a;
                tsin[i] = Math.Sin(a);
                tcos[i] = Math.Cos(a);
                a /= 10.0;
            }

            // Take a random angle (0..Pi/2)
            double a0 = 1.1823614786;

            a = a0;
            // Start with non-rotated vector (1,0)
            double x = 1.0;
            double y = 0.0;
            // Do incremental rotation of 1, 0.1, 0.01.. to rotate the value of a
            for (int i = 0; i < n; i++)
                while (a >= ta[i])
                {
                    // Coordinates before rotation
                    double x0 = x;
                    double y0 = y;

                    // We do an incremental rotation of ta[i]
                    a -= ta[i];

                    // Standard rotation matrix times vector (x,y)
                    x = x0 * tcos[i] - y0 * tsin[i];
                    y = x0 * tsin[i] + y0 * tcos[i];
                }

            Console.WriteLine("a={0}", a0);
            Console.WriteLine("c={0}\ts={1}", Math.Cos(a0), Math.Sin(a0));
            Console.WriteLine("x={0}\ty={1}\t", x, y);

            // Maple answer with 30 digits
            // cos = 0.378740326955891541643393287014
            // sin = 0.925502979323861698653734026619

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }
}