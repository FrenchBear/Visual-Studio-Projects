// 540 CS Synchronization
// Various multithreaded synchronization code
// From Improving .NET Performance, Intel Whitepaper - Hanchinmani
// 2016-07-31   PV

// Note: Try Parallel.Invoke(action, action, action)

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Interlocked;

namespace CS540
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAction("Synchro avec Monitor.Enter/.Exit",
                () =>
                {
                    var hs = new Queue<int>();
                    Enumerable.Range(0, 1000000).AsParallel().ForAll(
                        (int i) =>
                        {
                            Monitor.Enter(hs);
                            hs.Enqueue(i);
                            Monitor.Exit(hs);
                        });
                    for (int i = 0; i < 30; i++)
                        Write($"{hs.Dequeue()} ");
                    WriteLine();
                });

            TestAction("Synchro avec Lock",
                () =>
                {
                    var hs = new Queue<int>();
                    Enumerable.Range(0, 1000000).AsParallel().ForAll(
                        (int i) =>
                        {
                            lock (hs)
                            {
                                hs.Enqueue(i);
                            }
                        });
                    for (int i = 0; i < 30; i++)
                        Write($"{hs.Dequeue()} ");
                    WriteLine();
                });

            TestAction("Synchro avec SpinLock",
                () =>
                {
                    var hs = new Queue<int>();
                    var sl = new SpinLock();
                    Enumerable.Range(0, 1000000).AsParallel().ForAll(
                        (int i) =>
                        {
                            bool gotLock = false;
                            sl.Enter(ref gotLock);
                            hs.Enqueue(i);
                            sl.Exit();
                        });
                    for (int i = 0; i < 30; i++)
                        Write($"{hs.Dequeue()} ");
                    WriteLine();
                });

            TestAction("Synchro avec ConcurrentQueue",
                () =>
                {
                    var hs = new ConcurrentQueue<int>();
                    Enumerable.Range(0, 1000000).AsParallel().ForAll(
                        (int i) =>
                        {
                            hs.Enqueue(i);
                        });
                    for (int i = 0; i < 30; i++)
                    {
                        int n;
                        hs.TryDequeue(out n);   // Will always succeed, single-threaded here
                        Write($"{n} ");
                    }
                    WriteLine();
                });

            TestAction("1M ++ with lock",
                () =>
                {
                    var lockObject = new Object();
                    int sum = 0;
                    Enumerable.Range(0, 1000000).AsParallel().ForAll(
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
                    int sum = 0;
                    Enumerable.Range(0, 1000000).AsParallel().ForAll(
                        (int i) =>
                        {
                            Increment(ref sum);
                        });
                });

            TestAction("100K ++ with Mutex",
                () =>
                {
                    int sum = 0;
                    var m = new Mutex();
                    Enumerable.Range(0, 100000).AsParallel().ForAll(
                        (int i) =>
                        {
                            m.WaitOne();
                            sum++;
                            m.ReleaseMutex();
                        });
                });


            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        static void TestAction(string message, Action action)
        {
            WriteLine(message);
            var ti = Stopwatch.StartNew();
            action();
            long t0 = ti.ElapsedMilliseconds;
            WriteLine($"Durée: {(int)(t0 / 1000)}.{t0 % 1000:D4}\n");
        }
    }
}
