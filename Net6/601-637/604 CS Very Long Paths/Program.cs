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

using System;
using System.IO;

namespace CS604;

internal class Program
{
    private static void Main()
    {
        string reallyLongDirectory = @"C:\Temp\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        reallyLongDirectory += @"\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        reallyLongDirectory += @"\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        Console.WriteLine($"Creating a directory that is {reallyLongDirectory.Length} characters long");
        Directory.CreateDirectory(reallyLongDirectory);
    }
}