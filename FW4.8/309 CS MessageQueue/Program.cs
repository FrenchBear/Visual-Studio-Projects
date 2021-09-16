// 309 CS MessageQueue
// 2012-02-25   PV  VS2010

using System;
using System.Windows.Forms;

namespace FPVI.MessageQueueTest
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}