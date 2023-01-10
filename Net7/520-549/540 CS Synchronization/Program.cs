// 540 CS Synchronization
// Various multithreaded synchronization code
// From Improving .NET Performance, Intel Whitepaper - Hanchinmani
// 2016-07-31   PV
// 2023-01-10	PV		Net7

// Note: Try Parallel.Invoke(action, action, action)

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using static System.Console;
using static System.Threading.Interlocked;

namespace CS540;

internal class Program
{
    private static void Main()
    {
        TestAction("Synchro avec Monitor.Enter/.Exit",
            () =>
            {
                var hs = new Queue<int>();
                Enumerable.Range(0, 1_000_000).AsParallel().ForAll(
                    (int i) =>
                    {
                        Monitor.Enter(hs);
                        hs.Enqueue(i);
                        Monitor.Exit(hs);
                    });
                for (var i = 0; i < 30; i++)
                    Write($"{hs.Dequeue()} ");
                WriteLine();
            });

        TestAction("Synchro avec Lock",
            () =>
            {
                var hs = new Queue<int>();
                Enumerable.Range(0, 1_000_000).AsParallel().ForAll(
                    (int i) =>
                    {
                        lock (hs)
                        {
                            hs.Enqueue(i);
                        }
                    });
                for (var i = 0; i < 30; i++)
                    Write($"{hs.Dequeue()} ");
                WriteLine();
            });

        TestAction("Synchro avec SpinLock",
            () =>
            {
                var hs = new Queue<int>();
                var sl = new SpinLock();
                Enumerable.Range(0, 1_000_000).AsParallel().ForAll(
                    (int i) =>
                    {
                        var gotLock = false;
                        sl.Enter(ref gotLock);      // Enter blocks access if not available
                        hs.Enqueue(i);
                        sl.Exit();
                    });
                for (var i = 0; i < 30; i++)
                    Write($"{hs.Dequeue()} ");
                WriteLine();
            });

        TestAction("Synchro avec ConcurrentQueue",
            () =>
            {
                var hs = new ConcurrentQueue<int>();
                Enumerable.Range(0, 1_000_000).AsParallel().ForAll(
                    (int i) => hs.Enqueue(i));
                for (var i = 0; i < 30; i++)
                {
                    _ = hs.TryDequeue(out var n);   // Will always succeed, single-threaded here
                    Write($"{n} ");
                }
                WriteLine();
            });

        TestAction("1M ++ with lock",
            () =>
            {
                var lockObject = new object();
                var sum = 0;
                Enumerable.Range(0, 1_000_000).AsParallel().ForAll(
                    (int i) =>
                    {
                        lock (lockObject)
                        {
                            sum++;
                        }
                    });
            });

        TestAction("1M ++ with Increment",
            () =>
            {
                var sum = 0;
                Enumerable.Range(0, 1_000_000).AsParallel().ForAll(
                    (int i) => _ = Increment(ref sum));
            });

        TestAction("1M ++ with Mutex",
            () =>
            {
                var sum = 0;
                var m = new Mutex();
                Enumerable.Range(0, 1_000_000).AsParallel().ForAll(
                    (int i) =>
                    {
                        _ = m.WaitOne();
                        sum++;
                        m.ReleaseMutex();
                    });
            });
    }

    private static void TestAction(string message, Action action)
    {
        WriteLine(message);
        var ti = Stopwatch.StartNew();
        action();
        var t0 = ti.ElapsedMilliseconds;
        WriteLine($"Durée: {(int)(t0 / 1000)}.{t0 % 1000:D4}\n");
    }
}
