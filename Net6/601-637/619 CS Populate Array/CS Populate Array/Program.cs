// CS Populate array
// Various tests to fill a C# array with a constant
// Verdict, unless array is huge (tenths of millions), simplest loop is best, otherwise parallel filling starts to be interesting
// Also example of use of SegmentArray
//
// From http://stackoverflow.com/questions/1014005/how-to-populate-instantiate-a-c-sharp-array-with-a-single-value
//
// 2017-05-01   PV
// 2021-09-26   PV      VS2022; Net6

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using static System.Console;

namespace CS_Populate_Array;

internal class Program
{
    private static void Main()
    {
        //int n = 1000000000;
        int n = 32000 * 8;
        var tb = new bool[n];

        var sw1 = Stopwatch.StartNew();
        tb.Populate(true);
        sw1.Stop();
        WriteLine("Populate: " + sw1.Elapsed);

        var sw2 = Stopwatch.StartNew();
        InitializeArrayUsingSegments(tb, true);
        sw2.Stop();
        WriteLine("InitializeArrayUsingSegments: " + sw2.Elapsed);

        var sw3 = Stopwatch.StartNew();
        tb.PopulateParallel(true);
        sw3.Stop();
        WriteLine("PopulateParallel: " + sw3.Elapsed);

        var sw4 = Stopwatch.StartNew();
        InitializeArray2(tb, true);
        sw4.Stop();
        WriteLine("InitializeArray2: " + sw4.Elapsed);
    }

    public static void InitializeArrayUsingSegments<T>(T[] array, T value)
    {
        var cores = Environment.ProcessorCount;

        var segments = new ArraySegment<T>[cores];

        var step = array.Length / cores;
        for (int i = 0; i < cores; i++)
        {
            segments[i] = new ArraySegment<T>(array, i * step, step);
        }
        var remaining = array.Length % cores;
        if (remaining != 0)
        {
            var lastIndex = segments.Length - 1;
            segments[lastIndex] = new ArraySegment<T>(array, lastIndex * step, array.Length - lastIndex * step);
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
        var cores = Environment.ProcessorCount - 1;
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
    // Simplest extension method, just fill value using a simple loop
    public static void Populate<T>(this T[] arr, T value)
    {
        for (int i = 0; i < arr.Length; i++)
            arr[i] = value;
    }

    // A bit more sophisticated, fill using n threads (n is the actual number of logical processors)
    // Since array is a direct, simple structure and there is no overlap between slices allocated to a thread,
    // there is no need for synchronization (but still have to wait that all threads are terminated to continue)
    public static void PopulateParallel<T>(this T[] array, T value)
    {
        var cores = Environment.ProcessorCount - 1;
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