// Essais de Path.ChangeExtension
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;
using System.IO;

namespace CS_Path;

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
        string sPath1 = "filename.ext";
        string sPath2 = Path.ChangeExtension(sPath1, ".zap");

        Console.WriteLine("Path1: {0}\nPath2: {1}", sPath1, sPath2);
        //Console.ReadLine();
    }
}