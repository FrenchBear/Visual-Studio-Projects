// Arith2CS, C# version of Arithmetic Doubler
// Generic arithmetic class doubling the capacity of a base class for Plus and Mult
// and recursive use example (of course, for each level computation time also double)
// Use decimal slicing to eliminate the complexity of base 2 <-> base 10 conversions
// Actually this is a test for ValueTuple introduced with Visual Studio 2017, and
// verity whether some metaprogramming can be done in C#
//
// 2017-01-21   PV  First version
// 2017-01-22   PV  Verification using BigInteger
// 2017-01-24   PV  Chronométrage du test

using System;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using static System.Console;

namespace Arith2CS
{
    using Int1024d = DA<DA<DA<DA<DA<DA<DA<DA<Int4d>>>>>>>>;
    using Int128d = DA<DA<DA<DA<DA<Int4d>>>>>;
    using Int256d = DA<DA<DA<DA<DA<DA<Int4d>>>>>>;

    // Repacking for simplified use, arithmetic on 64 digits
    // Note that using Int64d = DA<Int32d>; is not accepted
    using Int32d = DA<DA<DA<Int4d>>>;
    using Int512d = DA<DA<DA<DA<DA<DA<DA<Int4d>>>>>>>;
    using Int64d = DA<DA<DA<DA<Int4d>>>>;

    // Interface of a simple arithmetic class providing support for Plus and Mult
    public interface ISimpleArith<T>
    {
        int Digits { get; }

        void FromString(string s);

        void FromOther(T other);

        bool IsZero();

        (T high, T low) Plus(params T[] list);

        (T high, T low) Mult(T other);

        string ToString();

        string ToStringWithLeadingZeros();

        string ToString2(T b);
    }

    // Base arithmetic class providing 4 decimal digits precision using
    // native (processor) support of Plus and Mult
    public class Int4d : ISimpleArith<Int4d>
    {
        // Native storage for base class
        private int val;

        // Just for example
        private const int digits = 4;

        private const int k = 10000;        // 10^digits
        public int Digits { get => digits; }

        // A public parameterless constructor is needed
        public Int4d() { val = 0; }

        // Not part of interface, just for base class
        private Int4d(int x)
        {
            if (x < 0 || x > k) throw new ArgumentException("Invalid constructor call");
            val = x;
        }

        // Actually this should be a constructor, but constructors can't be included in interfaces
        public void FromString(string x)
        {
            if (string.IsNullOrEmpty(x) || x.Length > digits || !int.TryParse(x, out val)) throw new ArgumentException("Invalid constructor call");
        }

        // Same here, actually copy constructor
        public void FromOther(Int4d other)
        {
            val = other.val;
        }

        // Addition 4d+4d -> (4d carry, 4d result)
        public (Int4d high, Int4d low) Plus(params Int4d[] list)
        {
            int x = val;
            // Assume we've less than 10000 items in list so result can be two Int4d
            foreach (Int4d item in list)
                x += item.val;

            int h = x / k;
            int l = x % k;
            return (new Int4d(h), new Int4d(l));
        }

        // Multiplication 4d*4d -> (4d high, 4d low)
        public (Int4d high, Int4d low) Mult(Int4d other)
        {
            int x = val * other.val;
            int h = x / k;
            int l = x % k;
            return (new Int4d(h), new Int4d(l));
        }

        // Convenient helper for output formatting
        public bool IsZero()
        {
            return val == 0;
        }

        public override string ToString()
        {
            return val.ToString();
        }

        // Output always formatted using 'digits' digits
        public string ToStringWithLeadingZeros() => (val + k).ToString().Substring(1);

        // Helper for testing, prints a pair of 4d numbers
        // This (instance calling) is the high half (first), parameter is the low half
        public string ToString2(Int4d b)
        {
            if (val > 0)
                return ToString() + b.ToStringWithLeadingZeros();
            else
                return b.ToString();
        }
    }

    // Double Arithmetic: provides twice the capacity of type T that implements ISimpleArith
    // and this class in turn also implements ISimpleArith
    // so it's Ok to instantiate DA<Int4d>, DA<DA<Int4d>>, DA<DA<DA<Int4d>>>...
    public class DA<T> : ISimpleArith<DA<T>> where T : ISimpleArith<T>, new()
    {
        protected T high;
        protected T low;

        private static readonly int digits;
        public int Digits { get => digits; }

        // Static constructore to initialize static variable returned by an instance property that can be included in interface...
        static DA()
        {
            digits = 2 * new T().Digits;
        }

        public DA()
        {
            // An initialization to 0
            low = new T();
            high = new T();
        }

        // Private constructor for intermediate calculations
        private DA(T h, T l)
        {
            (high = new T()).FromOther(h);
            (low = new T()).FromOther(l);
        }

        // Since parameterized constructors can't be put in an interface, this
        // function is a replacement for public DA(string x).  Note it makes the class mutable...
        public void FromString(string x)
        {
            if (string.IsNullOrEmpty(x) || x.Length > digits) throw new ArgumentException("Invalid constructor call");
            if (x.Length > digits / 2)
            {
                (high = new T()).FromString(x.Substring(0, x.Length - digits / 2));
                (low = new T()).FromString(x.Substring(x.Length - digits / 2));
            }
            else
            {
                high = new T();     //(high = new T()).FromString("0");
                (low = new T()).FromString(x);
            }
        }

        // Another substitute for a copy constructor
        // Although we can write code such as  high = (T)Activator.CreateInstance(typeof(T), new object[] {h});
        public void FromOther(DA<T> other)
        {
            (high = new T()).FromOther(other.high);
            (low = new T()).FromOther(other.low);
        }

        public (DA<T> high, DA<T> low) Plus(params DA<T>[] list)
        {
            T h, l, ovh, ovl;
            (h = new T()).FromOther(high);
            (l = new T()).FromOther(low);
            //(ovl = new T()).FromString("0");
            //(ovh = new T()).FromString("0");
            ovl = new T();
            ovh = new T();

            foreach (DA<T> item in list)
            {
                T ov1, ov2;
                (ov1, l) = l.Plus(item.low);
                (ov2, h) = h.Plus(item.high, ov1);
                (ovh, ovl) = ovl.Plus(ov2);
            }

            return (new DA<T>(ovh, ovl), new DA<T>(h, l));
        }

        public (DA<T> high, DA<T> low) Mult(DA<T> other)
        {
            T lowH, lowL;
            T highH, highL;

            (lowH, lowL) = low.Mult(other.low);
            (T t1h, T t1l) = high.Mult(other.low);
            (T t2h, T t2l) = low.Mult(other.high);
            (highH, highL) = high.Mult(other.high);

            T ov1, ov2;
            (ov1, lowH) = lowH.Plus(t1l, t2l);
            (ov2, highL) = highL.Plus(t1h, t2h, ov1);
            (_, highH) = highH.Plus(ov2);

            return (new DA<T>(highH, highL), new DA<T>(lowH, lowL));
        }

        public bool IsZero()
        {
            return high.IsZero() && low.IsZero();
        }

        public override string ToString()
        {
            if (high.IsZero())
                return low.ToString();
            else
                return high.ToString() + low.ToStringWithLeadingZeros();
        }

        public string ToStringWithLeadingZeros() => high.ToStringWithLeadingZeros() + low.ToStringWithLeadingZeros();

        public string ToString2(DA<T> b)
        {
            if (IsZero())
                return b.ToString();
            else
                return ToString() + b.ToStringWithLeadingZeros();
        }
    }

    internal class Program
    {
        private static void Test<T>() where T : ISimpleArith<T>, new()
        {
            int d = new T().Digits;
            var rnd = new Random();

            string GetRandomNumber()
            {
                var sb = new StringBuilder(d);
                for (int i = 0; i < d; i++)
                    sb.Append((char)(48 + rnd.Next(0, 10)));
                return sb.ToString();
            }

            WriteLine($"Test Int{d}d");
            string astr = GetRandomNumber();
            string bstr = GetRandomNumber();
            Stopwatch sw = Stopwatch.StartNew();
            T a, b;
            (a = new T()).FromString(astr);
            (b = new T()).FromString(bstr);
            WriteLine($"a{d}: {a.ToString()}");
            WriteLine($"b{d}: {b.ToString()}");
            (T h, T l) = a.Plus(b);
            string sumstr = h.ToString2(l);
            WriteLine($"a{d}+b{d}: {sumstr}");
            (h, l) = a.Mult(b);
            string prodstr = h.ToString2(l);
            WriteLine($"a{d}.b{d}: {prodstr}");
            sw.Stop();

            // Check using BigInteger
            Stopwatch swc = Stopwatch.StartNew();
            var abi = BigInteger.Parse(astr);
            var bbi = BigInteger.Parse(bstr);
            var sumbi = abi + bbi;
            var prodbi = abi * bbi;
            Write("Sum: " + (sumbi.ToString() == sumstr ? "Ok" : "Error"));
            WriteLine(",  Prod: " + (prodbi.ToString() == prodstr ? "Ok" : "Error"));
            WriteLine($"Elapsed: {sw.ElapsedMilliseconds} ms,  Check: {swc.ElapsedMilliseconds} ms");

            WriteLine();
        }

        private static void Main(string[] args)
        {
            Int4d a, b;
            (a = new Int4d()).FromString("8000");
            (b = new Int4d()).FromString("7000");
            WriteLine($"a: {a}");
            WriteLine($"b: {b}");
            (Int4d h, Int4d l) = a.Plus(b);
            WriteLine($"a+b: " + h.ToString2(l));
            (h, l) = a.Mult(b);
            WriteLine($"a.b: " + h.ToString2(l));
            WriteLine();

            DA<Int4d> a8, b8;
            (a8 = new DA<Int4d>()).FromString("12345678");
            (b8 = new DA<Int4d>()).FromString("87654321");
            WriteLine($"a8: {a8}");
            WriteLine($"b8: {b8}");
            (DA<Int4d> h8, DA<Int4d> l8) = a8.Plus(b8);
            WriteLine($"a8+b8: " + h8.ToString2(l8));
            (h8, l8) = a8.Mult(b8);
            WriteLine($"a8.b8: " + h8.ToString2(l8));
            WriteLine();

            DA<DA<Int4d>> a16, b16;
            (a16 = new DA<DA<Int4d>>()).FromString("1234567812345678");
            (b16 = new DA<DA<Int4d>>()).FromString("8765432187654321");
            WriteLine($"a16: {a16}");
            WriteLine($"b16: {b16}");
            (DA<DA<Int4d>> h16, DA<DA<Int4d>> l16) = a16.Plus(b16);
            WriteLine($"a16+b16: " + h16.ToString2(l16));
            (h16, l16) = a16.Mult(b16);
            WriteLine($"a16.b16: " + h16.ToString2(l16));
            WriteLine();

            Test<Int32d>();
            Test<Int64d>();
            Test<Int128d>();
            Test<Int256d>();
            Test<Int512d>();
            Test<Int1024d>();

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }
}