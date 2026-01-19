// 309 CS MessageQueue
//
// 2012-02-25	PV		VS2010
// 2021-09-20	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using FPVI.MessageQueueTest;
using System;
using System.Windows.Forms;

namespace MessageQueueTest;

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
