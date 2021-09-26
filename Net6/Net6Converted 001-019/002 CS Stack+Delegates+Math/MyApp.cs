// 002 CS Stack+Delegates+Math
// Essais divers en C#
// Structure de pile, delegates
//
// 2001 PV
// 2006-10-01   PV  VS2005
// 2010-05-01   PV  VS2010
// 2021-09-17   PV  VS2022/Net6

using System;

namespace CS002
{

    public class MyMath
    {
        public delegate double FR�elle(double arg);

        public static double Int�grale(double binf, double bsup, FR�elle f)
        {
            int i;
            double v;
            const int PAS = 1000;

            v = 0;
            for (i = 0; i < PAS; i++)
                v += f(binf + (bsup - binf) * (i + 0.5) / PAS);
            return v * (bsup - binf) / PAS;
        }

        public static double Carr�(double x)
        {
            return x * x;
        }
    }

    public class MyApp
    {
        private static void F(params int[] targ)
        {
            Console.WriteLine("# of arguments: {0}", targ.Length);
            for (int i = 0; i < targ.Length; i++)
            {
                Console.WriteLine("\tArg[{0}] = {1}", i, targ[i]);
            }
        }

        private static void Swap(ref object x, ref object y)
        {
            object temp = x;
            x = y;
            y = temp;
        }

        public static void Main()
        {
            Console.WriteLine("System.Int64.MaxValue = {0}", System.Int64.MaxValue);

            F();
            F(1, 2);
            F(new int[] { 1, 2, 3 });

            int a = 1, b = 2;

            Console.WriteLine("a={0}, b={1}", a, b);

            object oa = a;
            object ob = b;
            Swap(ref oa, ref ob);
            a = (int)oa;
            b = (int)ob;

            Console.WriteLine("a={0}, b={1}", a, b);

            Pile p = new();
            p.Empile(1);
            p.Empile(2);
            p.Empile(3);

            Console.WriteLine("D�pile: {0}", p.D�pile());
            Console.WriteLine("D�pile: {0}", p.D�pile());

            try
            {
                Console.WriteLine("D�pile: {0}", p.D�pile());
            }
            catch (Exception e)
            {
                Console.WriteLine("�chec au d�pile: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Bloc finally");
            }

            Console.WriteLine("12.3� = {0}", MyMath.Carr�(12.3));
            Console.WriteLine("Int�grale x�|0,1: {0}", MyMath.Int�grale(0.0, 1.0, new MyMath.FR�elle(MyMath.Carr�)));
            Console.WriteLine("Int�grale sin(x)|0,pi: {0}", MyMath.Int�grale(0.0, Math.PI, new MyMath.FR�elle(Math.Sin)));
        }
    }
}
