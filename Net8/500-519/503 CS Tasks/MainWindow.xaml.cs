// 503 CS Tasks
//
// 2012-08-17   PV      Visual Studio 2012
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication3;

public partial class MainWindow: Window
{
    private readonly Random rnd = new();

    public MainWindow() => InitializeComponent();

    private async void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var lt = new List<Task<double>>();

        AddTrace("Begin All");
        for (var i = 1; i <= 6; i++)
        {
            var j = i;  // Avoid compiler bug with loop variables used in closures
            lt.Add(Task.Run(() => LongMethod(j)));
        }
        /*
        Task<double> t1 = Task.Run(() => LongMethod(1));
        Task<double> t2 = Task.Run(() => LongMethod(2));
        Task<double> t3 = Task.Run(() => LongMethod(3));
        Task<double> t4 = Task.Run(() => LongMethod(4));
        Task<double> t5 = Task.Run(() => LongMethod(5));
        Task<double> t6 = Task.Run(() => LongMethod(6));
        await Task.WhenAll( t1, t2, t3, t4, t5, t6);
         */
        _ = await Task.WhenAll(lt.ToArray());
        // With a Task.WaitAll, result is the same, but current thread is blocked waiting for completion of
        // tasks, and dispatcher cannot refreh UI
        //Task.WaitAll(lt.ToArray());
        AddTrace("End All");
    }

    private double LongMethod(int p)
    {
        AddTrace($"Begin {p}");
        var d = 0.0;
        var l = (int)(10000000 * (1.0 + 2.0 * rnd.NextDouble()));
        for (var i = 0; i < l; i++)
            d = Math.Asin(Math.Acos(Math.Atan(Math.Tan(Math.Cos(Math.Sin(9.0 / 180.0 * Math.PI)))))) * 180.0 / Math.PI - 9.0;
        AddTrace($"End {p}");
        return d;
    }

    private void AddTrace(string s)
    {
        var s1 = s + "  " + DateTime.Now.ToString("HH:mm:ss.fff");
        _ = Dispatcher.BeginInvoke(new Action(delegate
              {
                  _ = listBox.Items.Add(s1);
                  listBox.ScrollIntoView(listBox.Items[^1]);
              }
        ));
    }
}
