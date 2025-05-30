﻿// Essais de Path.ChangeExtension
//
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.IO;
using static System.Console;

namespace CS093;

/// <summary>
/// Description résumée de Class1.
/// </summary>
internal class Class1
{
    /// <summary>
    /// Point d'entrée principal de l'application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
        var sPath1 = "filename.ext";
        var sPath2 = Path.ChangeExtension(sPath1, ".zap");

        WriteLine("Path1: {0}\nPath2: {1}", sPath1, sPath2);
        //Console.ReadLine();
    }
}
