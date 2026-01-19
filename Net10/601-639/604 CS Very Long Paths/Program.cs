// CS604 Win10 DotNet 4.6.2 Long Paths
// Example of very long path using Windows 10, enabling long paths in local group policy and targeting .Net 4.6.2
// From https://blogs.msdn.microsoft.com/jeremykuhne/2016/07/30/net-4-6-2-and-long-paths-on-windows-10/
//
// In "local group policy editor" gpedit.msc:
// Computer Configuration\Administrative Templates\System\Filesystem\Enable Win32 long paths    is enabled
//
// Add an app.manifest file to project setting longPathAware to true:
//  <application xmlns="urn:schemas-microsoft-com:asm.v3">
//    <windowsSettings>
//      <longPathAware xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">true</longPathAware>
//    </windowsSettings>
//  </application>
//
// 2016-12-30   PV
// 2019-04-10   PV      Doesn't work anymore?  Should document config update more in detail and check it in the code...
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System.IO;
using static System.Console;

namespace CS604;

internal class Program
{
    private static void Main()
    {
        var reallyLongDirectory = @"C:\Temp\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        reallyLongDirectory += @"\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        reallyLongDirectory += @"\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        WriteLine($"Creating a directory that is {reallyLongDirectory.Length} characters long");
        _ = Directory.CreateDirectory(reallyLongDirectory);
    }
}
