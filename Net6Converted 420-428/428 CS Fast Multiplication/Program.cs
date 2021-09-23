// 428 CS Fast Multiplication
// Big number multipication
// Mostly a programming exercise to explore algorithms, since using dynamic objects for multiplication kills any performance!
//
// 2012-05-01   PV
// 2021-09-23   PV  VS2022; Net6

using System;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace CS428
{
    public class Program
    {
        private static readonly Random rnd = new();

        private static void Main(string[] args)
        {
            const int digits = 50000;

            string n1string = GetRandomStringNumber(digits);
            string n2string = GetRandomStringNumber(digits);

            var sn1 = new SlicedNumber(n1string);
            var sn2 = new SlicedNumber(n2string);

            var bn1 = BigInteger.Parse(n1string);
            var bn2 = BigInteger.Parse(n2string);

            // Compare multiplication algorithms
            var swSchool = Stopwatch.StartNew();
            var snSchool = SlicedNumber.MultSchool(sn1, sn2);
            swSchool.Stop();
            var swFastMult = Stopwatch.StartNew();
            var snFastMult = SlicedNumber.FastMult(sn1, sn2);
            swFastMult.Stop();
            var swBigNumber = Stopwatch.StartNew();
            var bnBigBumber = bn1 * bn2;
            swBigNumber.Stop();

            // Verification using BigInteger class
            string s = bnBigBumber.ToString();
            Debug.Assert(snSchool.ToString() == s);
            Debug.Assert(snFastMult.ToString() == s);

            Console.WriteLine("School:    {0}ms", swSchool.ElapsedMilliseconds);
            Console.WriteLine("FastMult:  {0}ms", swFastMult.ElapsedMilliseconds);
            Console.WriteLine("BigNumber: {0}ms", swBigNumber.ElapsedMilliseconds);

            //Console.WriteLine("n1=" + n1string);
            //Console.WriteLine("n2=" + n2string);
            //Console.WriteLine("n1*n2=" + n3);

            //Console.WriteLine();
            //Console.Write("(Pause)");
            //Console.ReadLine();
        }

        private static string GetRandomStringNumber(int digits)
        {
            var sb = new StringBuilder();
            while (digits-- > 0)
                sb.Append((char)(48 + rnd.Next(10)));
            return sb.ToString();
        }
    }

    public class SlicedNumber
    {
        public long[] slices;
        public int nslices;
        public int sign;

        private const int digitsPerSlice = 9;
        private const long range = 1000000000;

        protected SlicedNumber(int nslices)
        {
            this.nslices = nslices;
            slices = new long[nslices];
            sign = 1;
        }

        public SlicedNumber(string s)
        {
            if (s[0] == '-')
            {
                sign = -1;
                s = s[1..];
            }
            else
                sign = 1;

            int p1 = s.Length - 1;
            int p2 = 1;
            nslices = p1 / 9 + 1;
            slices = new long[nslices];
            for (int i = 0; p2 > 0; i++)
            {
                p2 = p1 - digitsPerSlice + 1;
                if (p2 < 0) p2 = 0;
                slices[i] = long.Parse(s.Substring(p2, p1 - p2 + 1));
                p1 -= digitsPerSlice;
            }
        }

        // Return a clone of current number (deep copy)
        public SlicedNumber Copy()
        {
            var copy = new SlicedNumber(nslices);
            for (int i = 0; i < nslices; i++)
                copy.slices[i] = slices[i];
            copy.sign = sign;
            return copy;
        }

        private void Redim(int newNslices)
        {
            long[] newSlices = new long[newNslices];
            Array.Copy(slices, newSlices, Math.Min(newNslices, nslices));
            nslices = newNslices;
            slices = newSlices;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (sign < 0)
                sb.Append('-');
            for (int i = nslices - 1; i >= 0; i--)
                sb.Append(slices[i].ToString(i == nslices - 1 ? "D" : "D9"));
            return sb.ToString();
        }

        // Propagate carry if a |slice|>=range
        // Can generate non-significant zeroes
        // public for unit testing
        public void NormalizeSlices()
        {
            long carry = 0;
            for (int i = 0; i < nslices; i++)
            {
                if (carry != 0) slices[i] += carry;
                if (slices[i] < 0)
                {
                    carry = slices[i] / range - 1;
                    slices[i] -= range * carry;
                }
                else if (slices[i] >= range)
                {
                    carry = Math.DivRem(slices[i], range, out long rem);
                    slices[i] = rem;
                }
                else
                    carry = 0;
            }
            if (carry > 0)
            {
                Redim(nslices + 1);
                slices[nslices - 1] = carry;
            }
            else if (carry < 0)
                throw new Exception("Nagative carry at the end of normalization process, sign of SlicedNumber is incorrect");
            // Actually could have saved original slices, then change all slices sign and global sign, and restart the process
        }

        // Eliminate non-significant 0 slices (at the beginning)
        // public for unit testing
        public void TrimNonSignificantZeroes()
        {
            int nslices2 = nslices - 1;
            while (nslices2 >= 0 && slices[nslices2] == 0)
                nslices2--;
            if (nslices2 < 0) nslices2 = 0;
            if (nslices2 + 1 != nslices)
                Redim(nslices2 + 1);
        }

        // Traditional multiplication (school method), in t(n²)
        public static SlicedNumber MultSchool(SlicedNumber n1, SlicedNumber n2)
        {
            SlicedNumber res = new(n1.nslices + n2.nslices - 1);
            for (int i2 = 0; i2 < n2.nslices; i2++)
            {
                for (int i1 = 0; i1 < n1.nslices; i1++)
                    res.slices[i1 + i2] += n1.slices[i1] * n2.slices[i2];
                res.NormalizeSlices();
            }
            res.sign = n1.sign * n2.sign;
            return res;
        }

        // Compare two numbers in absolute value
        // If n1<n2 returns -1
        // If n1=n2 returns 0
        // if n1>n2 return 1
        // public for unit testing
        public static int AbsCompare(SlicedNumber n1, SlicedNumber n2)
        {
            if (n1.nslices < n2.nslices) return -1;
            if (n1.nslices > n2.nslices) return 1;
            int i = n1.nslices - 1;
            while (i >= 0)
            {
                if (n1.slices[i] < n2.slices[i]) return -1;
                if (n1.slices[i] > n2.slices[i]) return 1;
                i--;
            }
            return 0;
        }

        // Addition of numbers
        public static SlicedNumber Add(SlicedNumber n1, SlicedNumber n2)
        {
            SlicedNumber res = new(Math.Max(n1.nslices, n2.nslices));
            // When n1 and n2 have the same sign, it's easy
            if (n1.sign == n2.sign)
            {
                for (int i1 = 0; i1 < n1.nslices; i1++)
                    res.slices[i1] = n1.slices[i1];
                for (int i2 = 0; i2 < n2.nslices; i2++)
                    res.slices[i2] += n2.slices[i2];
                res.sign = n1.sign;
                return res;
            }

            // When opposite signs, need to know the highest value
            SlicedNumber max, min;
            if (AbsCompare(n1, n2) > 0)
            {
                max = n1;
                min = n2;
            }
            else
            {
                max = n2;
                min = n1;
            }
            for (int iMax = 0; iMax < max.nslices; iMax++)
                res.slices[iMax] = max.slices[iMax];
            for (int iMin = 0; iMin < min.nslices; iMin++)
                res.slices[iMin] -= min.slices[iMin];
            res.sign = max.sign;
            res.NormalizeSlices();
            res.TrimNonSignificantZeroes();         // Maybe this can be a problem when used internally to add temp numbers?
            return res;
        }

        // Return n1-n2
        public static SlicedNumber Subtract(SlicedNumber n1, SlicedNumber n2)
        {
            SlicedNumber n2opposite = n2.Copy();
            n2opposite.sign = -n2.sign;
            return Add(n1, n2opposite);
        }

        // More efficient algorithm, fast multiplication:
        // if S is a scale factor of half the length, then (a+bS)*(c+dS)=ac + ((a-b)(c-d)-ac-bd)S + bdS²,
        // this requires only three multiplications of half-length: ac, bd, and (a-b)*(c-d)
        public static SlicedNumber FastMult(SlicedNumber n1, SlicedNumber n2)
        {
            // Direct case if either input has 1 slice
            if (n1.nslices == 1)
            {
                if (n1.slices[0] == 0) return n1;           // Avoid a useless multiplication loop and a trim
                var res = new SlicedNumber(n2.nslices);
                for (int i2 = 0; i2 < n2.nslices; i2++)
                    res.slices[i2] = n2.slices[i2] * n1.slices[0];
                res.NormalizeSlices();
                res.sign = n1.sign * n2.sign;
                return res;
            }
            if (n2.nslices == 1)
            {
                if (n2.slices[0] == 0) return n2;           // Avoid a useless multiplication loop and a trim
                var res = new SlicedNumber(n1.nslices);
                for (int i1 = 0; i1 < n1.nslices; i1++)
                    res.slices[i1] = n1.slices[i1] * n2.slices[0];
                res.NormalizeSlices();
                res.sign = n1.sign * n2.sign;
                return res;
            }

            // Ok, now that trivial cases have been eliminated, the recursive algorithm
            int p = Math.Min(n1.nslices / 2, n2.nslices / 2);
            SplitInTwo(n1, p, out SlicedNumber a, out SlicedNumber b);
            SplitInTwo(n2, p, out SlicedNumber c, out SlicedNumber d);

            // Result
            SlicedNumber r = new(n1.nslices + n2.nslices - 1)
            {
                sign = n1.sign * n2.sign
            };

            // 1st product: ac
            SlicedNumber ac = SlicedNumber.FastMult(a, c);
            for (int i = 0; i < ac.nslices; i++)
                r.slices[i] = ac.slices[i];

            // 2nd product: bd
            SlicedNumber bd = SlicedNumber.FastMult(b, d);
            int nslices2 = bd.nslices + 2 * p;
            if (nslices2 > r.nslices)
                r.Redim(nslices2);
            for (int i = 0; i < bd.nslices; i++)
                r.slices[i + 2 * p] += bd.slices[i];

            // 3rd product
            var bma = SlicedNumber.Subtract(b, a);
            var cmd = SlicedNumber.Subtract(c, d);
            var p3 = SlicedNumber.Add(SlicedNumber.Add(SlicedNumber.FastMult(bma, cmd), ac), bd);
            for (int i = 0; i < p3.nslices; i++)
                r.slices[i + p] += p3.slices[i];

            r.NormalizeSlices();
            r.TrimNonSignificantZeroes();
            return r;
        }

        // public for unit testing
        public static void SplitInTwo(SlicedNumber n, int nslices1, out SlicedNumber a, out SlicedNumber b)
        {
            a = new SlicedNumber(nslices1);
            b = new SlicedNumber(n.nslices - nslices1);
            a.sign = n.sign;
            b.sign = n.sign;
            for (int i = 0; i < n.nslices; i++)
            {
                if (i < a.nslices)
                    a.slices[i] = n.slices[i];
                else
                    b.slices[i - a.nslices] = n.slices[i];
            }
        }
    }
}