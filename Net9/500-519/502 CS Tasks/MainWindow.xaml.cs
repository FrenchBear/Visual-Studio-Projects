// 502 CS Task.Run
// From http://stackoverflow.com/questions/9334818/when-to-use-taskex-run
//
// 2012-03-19   PV
// 2013-06-29   PV      Second analysis
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

#pragma warning disable IDE1006 // Naming Styles

namespace CS502;

public partial class MainWindow: Window, IDisposable
{
    public MainWindow()
    {
        InitializeComponent();
        //button1.Click += button1_Click;
        //button3.Click += button3_Click;
        button4.Click += button4_Click;
        button5.Click += button5_Click;
    }

    private static void DoWork(CancellationToken cancelToken, IProgress<string> progress)
    {
        var i = 0;
        _ = Task.Run(async () =>
          {
              var t2 = Thread.CurrentThread;
              //Debugger.Break();

              while (!cancelToken.IsCancellationRequested)
              {
                  progress.Report(i++.ToString());
                  await Task.Delay(100, cancelToken);
              }
          }, cancelToken);
    }

    private CancellationTokenSource cts;

    // IDispose
    public void Dispose()
    {
        ((IDisposable)cts).Dispose();
        GC.SuppressFinalize(this);
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
        var t1 = Thread.CurrentThread;
        //Debugger.Break();

        if (button1.Content.ToString() == "Start")
        {
            button1.Content = "Stop";
            //cts.Dispose();
            cts = new CancellationTokenSource();
            listBox.Items.Clear();

            IProgress<string> progress = new Progress<string>(AddTrace);    // s => AddTrace(s)
            DoWork(cts.Token, progress);
        }
        else
        {
            button1.Content = "Start";
            cts.Cancel();
            AddTrace("-- stopped --");
        }
    }

    private void AddTrace(string s)
    {
        _ = listBox.Items.Add(s + "  " + DateTime.Now.ToString("HH:mm:ss.fff"));
        listBox.ScrollIntoView(listBox.Items[^1]);
    }

    private Task GetTask1(int w)
    {
        // We create a Task<Task> here, that should be unwrapped so it can be awaited
        Task<Task> t = new(/* async delegate */ async () =>
        {
            Debug.WriteLine("A task1 has started, waiting for {0}", w * 1000);
            await Task.Delay(1000 * w);
            //Thread.Sleep(1000 * w);
            Debug.WriteLine("A task1 has ended, waited for {0}", w * 1000);
        });
        // Note that you must start it before unwrapping it, doing the reverse
        // generates an InvalidOperationException: Start may not be called on a promise-style task.
        t.Start();
        return t.Unwrap();
    }

    private Task GetTask2(int w)
    {
        var tf = new TaskFactory();
        // t is Task<Task> as in GetTask1 and must be unwrapped
        var t = tf.StartNew(async () =>
        {
            Debug.WriteLine("A task2 has started, waiting for {0}", w * 1000);
            await Task.Delay(1000 * w);
            Debug.WriteLine("A task2 has ended, waited for {0}", w * 1000);
        });
        return t.Unwrap();
    }

    private Task GetTask3(int w) =>
        // Task.Run is smart enough to unwrap
        Task.Run(async () =>
        {
            Debug.WriteLine("A task3 has started, waiting for {0}", w * 1000);
            await Task.Delay(1000 * w);
            Debug.WriteLine("A task3 has ended, waited for {0}", w * 1000);
        });

    // And letting the compiler do the job is even easier
    // Doesn't work!
    private async Task GetTask4(int w)
    {
        Debug.WriteLine("A task4 has started, waiting for {0}", w * 1000);
        await Task.Delay(1000 * w);
        Debug.WriteLine("A task4 has ended, waited for {0}", w * 1000);
    }

    private delegate Task GetTask(int w);

    // Note that interface is frozen until 1st task is terminated if the 1st Task.WaitAny
    // is not executed using await
    private async void button3_Click(object sender, RoutedEventArgs e)
    {
        GetTask getTask = source3ListBox.SelectedIndex switch
        {
            1 => GetTask2,
            2 => GetTask3,
            3 => GetTask4,
            _ => GetTask1,
        };
        listBox.Items.Clear();
        AddTrace("Start T0, T1 and T2");

        var T = new Task[3];
        T[0] = getTask(1);
        T[1] = getTask(3);
        T[2] = getTask(2);
        AddTrace("T0.Status: " + T[0].Status);
        AddTrace("T1.Status: " + T[1].Status);
        AddTrace("T2.Status: " + T[2].Status);
        var j = listBox.Items.Count;

        //Debugger.Break();
        var i = await Task.Run(() => Task.WaitAny(T));
        //int i = Task.WaitAny(T);
        AddTrace($"T{i} terminated");
        await Task.Run(() => Task.WaitAll(T));
        AddTrace("All T terminated");
        /*
        await T1;
        AddTrace("T1 terminated");
        await T2;
        AddTrace("T2 terminated");
        await T3;
        AddTrace("T3 terminated");
        */
        AddTrace("-- done --");
    }

    private async Task Job4()
    {
        AddTrace("Job4 Start");
        await Task.Delay(1000);
        AddTrace("Job4 End");
    }

    private async void button4_Click(object sender, RoutedEventArgs e)
    {
        listBox.Items.Clear();
        AddTrace("Button4 Start");
        //await Task.Delay(1000);
        await Job4();
        AddTrace("Button4 End");
    }

    private static async Task<double> LongCalcAsync(Func<double, double> f, double input)
    {
        var r = await Task.Run(() => f(input));
        return r;
    }

    private static async Task<IEnumerable<double>> ParallelCalcAsync()
    {
        var tfunc = new List<Func<double, double>> { Math.Sin, Math.Cos, Math.Tan, d => 1.0 / d, Math.Abs };
        IEnumerable<double> tres = await Task.WhenAll(
            from f in tfunc select LongCalcAsync(f, Math.PI / 3));
        return tres;
    }

    private async void button5_Click(object sender, RoutedEventArgs e) => Array.ForEach((await ParallelCalcAsync()).ToArray(), d => AddTrace(d.ToString()));
}
