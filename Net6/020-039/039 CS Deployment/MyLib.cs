// 2001 PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;
using System.Reflection;
using static System.Console;

#pragma warning disable CA1822 // Mark members as static

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

        object o1 = a.CreateInstance("MaClasse");
        MaClasse.MyMeth();

        WriteLine("GetCustomAttributes:");
        object[] tu = a.GetCustomAttributes(true);
        foreach (object u in tu)
            WriteLine("  " + u);
        WriteLine();

        WriteLine("GetExportedTypes:");
        foreach (Type t1 in a.GetExportedTypes())
            WriteLine("  " + t1.FullName);
        WriteLine();

        WriteLine("GetManifestResourceNames:");
        foreach (string s in a.GetManifestResourceNames())
            WriteLine("  " + s);
        WriteLine();

        WriteLine("GetReferencedAssemblies:");
        foreach (AssemblyName an in a.GetReferencedAssemblies())
            WriteLine("  " + an.FullName);
        WriteLine();

        // Accès direct
        var z1 = (AssemblyCompanyAttribute)a.GetCustomAttributes(typeof(AssemblyCompanyAttribute), true)[0];
        WriteLine(z1.Company);
        var z2 = (AssemblyCopyrightAttribute)a.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true)[0];
        WriteLine(z2.Copyright);
    }
}