
// From http://stackoverflow.com/questions/1014005/how-to-populate-instantiate-a-c-sharp-array-with-a-single-value

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Populate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = 1000000000;
            int n = 32000 * 8;
            var tb = new bool[n];

            Stopwatch sw1 = Stopwatch.StartNew();
            tb.Populate(true);
            sw1.Stop();
            Console.WriteLine("Populate: " + sw1.Elapsed.ToString());

            Stopwatch sw2 = Stopwatch.StartNew();
            InitializeArrayUsingSegments(tb, true);
            sw2.Stop();
            Console.WriteLine("InitializeArrayUsingSegments: " + sw2.Elapsed.ToString());

            Stopwatch sw3 = Stopwatch.StartNew();
            tb.PopulateParallel(true);
            sw3.Stop();
            Console.WriteLine("PopulateParallel: " + sw3.Elapsed.ToString());

            Stopwatch sw4 = Stopwatch.StartNew();
            InitializeArray2(tb, true);
            sw4.Stop();
            Console.WriteLine("InitializeArray2: " + sw4.Elapsed.ToString());


            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        public static void InitializeArrayUsingSegments<T>(T[] array, T value)
        {
            var cores = Environment.ProcessorCount;

            ArraySegment<T>[] segments = new ArraySegment<T>[cores];

            var step = array.Length / cores;
            for (int i = 0; i < cores; i++)
            {
                segments[i] = new ArraySegment<T>(array, i * step, step);
            }
            var remaining = array.Length % cores;
            if (remaining != 0)
            {
                var lastIndex = segments.Length - 1;
                segments[lastIndex] = new ArraySegment<T>(array, lastIndex * step, array.Length - (lastIndex * step));
            }

            var initializers = new Task[cores];
            for (int i = 0; i < cores; i++)
            {
                var index = i;
                var t = new Task(() =>
                {
                    var s = segments[index];
                    for (int j = 0; j < s.Count; j++)
                    {
                        array[j + s.Offset] = value;
                    }
                });
                initializers[i] = t;
                t.Start();
            }

            Task.WaitAll(initializers);
        }


        public static void InitializeArray2<T>(T[] array, T value)
        {
            var cores = Environment.ProcessorCount;
            var al = array.Length;
            var step = al / cores;

            var tasks = new Task[cores];
            for (int i = 0; i < cores; i++)
            {
                var index = i;
                tasks[i] = new Task(() =>
                {
                    int low = step * index;
                    int high = (index == cores - 1) ? al - 1 : low + step - 1;
                    for (int j = low; j <= high; j++)
                        array[j] = value;
                });
                tasks[i].Start();
            }

            Task.WaitAll(tasks);
        }
    }

    public static class ArrayExtensions
    {
        public static void Populate<T>(this T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = value;
        }

        public static void PopulateParallel<T>(this T[] array, T value)
        {
            var cores = Environment.ProcessorCount;
            var al = array.Length;
            var step = al / cores;
            var tasks = new Task[cores];
            for (int i = 0; i < cores; i++)
            {
                var index = i;
                tasks[i] = new Task(() =>
                    {
                        var low = index * step;
                        int high = (index == cores - 1) ? al - 1 : low + step - 1;
                        for (int j = low; j <= high; j++)
                            array[j] = value;
                    });
                tasks[i].Start();
            }
            Task.WaitAll(tasks);
        }

    }
}
