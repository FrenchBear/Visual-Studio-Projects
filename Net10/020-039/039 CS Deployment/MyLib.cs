// 2001 PV
//
// 2006-10-01   PV      VS2005
// 2012-02-25   PV      VS2010
// 2021-09-18   PV      VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System.Reflection;
using static System.Console;

#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace CS039Lib;

public class MaClasse
{
    public MaClasse() => WriteLine("MaClasse.ctor()");

    public static void MyMeth() => WriteLine("MaClasse.MyMeth()");
}

public class MyLib
{
    public MyLib()
    {
        WriteLine("Constructeur de MyLib");
        WriteLine();
    }

    public void Test()
    {
        var a = Assembly.GetExecutingAssembly();

        WriteLine("Assembly:");
        //WriteLine("  CodeBase:       " + a.CodeBase);         // Obsolete
        WriteLine("  EntryPoint:     " + a.EntryPoint);
        WriteLine("  FullName:       " + a.FullName);
        WriteLine("  Location:       " + a.Location);
        WriteLine();

        var o1 = a.CreateInstance("MaClasse");
        MaClasse.MyMeth();

        WriteLine("GetCustomAttributes:");
        var tu = a.GetCustomAttributes(true);
        foreach (var u in tu)
            WriteLine("  " + u);
        WriteLine();

        WriteLine("GetExportedTypes:");
        foreach (var t1 in a.GetExportedTypes())
            WriteLine("  " + t1.FullName);
        WriteLine();

        WriteLine("GetManifestResourceNames:");
        foreach (var s in a.GetManifestResourceNames())
            WriteLine("  " + s);
        WriteLine();

        WriteLine("GetReferencedAssemblies:");
        foreach (var an in a.GetReferencedAssemblies())
            WriteLine("  " + an.FullName);
        WriteLine();

        // Accès direct
        var z1 = (AssemblyCompanyAttribute)a.GetCustomAttributes(typeof(AssemblyCompanyAttribute), true)[0];
        WriteLine(z1.Company);
        var z2 = (AssemblyCopyrightAttribute)a.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true)[0];
        WriteLine(z2.Copyright);
    }
}
