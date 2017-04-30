// 503 CS Tasks
// 2012-08-17   PV  Visual Studio 2012 release

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var lt = new List<Task<double>>();

            AddTrace("Begin All");
            for (int i = 1; i <= 6; i++)
            {
                int j = i;  // Avoid compiler bug with loop variables used in closures
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
            await Task.WhenAll<double>(lt.ToArray());
            // With a Task.WaitAll, result is the same, but current thread is blocked waiting for completion of
            // tasks, and dispatcher cannot refreh UI
            //Task.WaitAll(lt.ToArray());
            AddTrace("End All");
        }

        double LongMethod(int p)
        {
            AddTrace(String.Format("Begin {0}", p));
            double d = 0.0;
            int l = (int)(10000000 * (1.0 + 2.0 * rnd.NextDouble()));
            for (int i = 0; i < l; i++)
                d = Math.Asin(Math.Acos(Math.Atan(Math.Tan(Math.Cos(Math.Sin(9.0 / 180.0 * Math.PI)))))) * 180.0 / Math.PI - 9.0;
            AddTrace(String.Format("End {0}", p));
            return d;
        }

        private void AddTrace(string s)
        {
            string s1 = s + "  " + DateTime.Now.ToString("HH:mm:ss.fff");
            Dispatcher.BeginInvoke(new Action(delegate
                {
                    listBox.Items.Add(s1);
                    listBox.ScrollIntoView(listBox.Items[listBox.Items.Count - 1]);
                }
            ));
        }

    }
}
