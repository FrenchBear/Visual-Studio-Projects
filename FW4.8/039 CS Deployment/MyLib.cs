// 2001 PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;
using System.Reflection;

public class MaClasse
{
    public MaClasse() => Console.WriteLine("MaClasse.ctor()");

    public void MyMeth() => Console.WriteLine("MaClasse.MyMeth()");
}

public class MyLib
{
    public MyLib()
    {
        Console.WriteLine("Constructeur de MyLib");
        Console.WriteLine();
    }

    public void Test()
    {
        var a = Assembly.GetExecutingAssembly();

        Console.WriteLine("Assembly:");
        Console.WriteLine("  CodeBase:       " + a.CodeBase);
        //	Console.WriteLine("  CopiedCodeBase: " + a.CopiedCodeBase);
        Console.WriteLine("  EntryPoint:     " + a.EntryPoint);
        Console.WriteLine("  Evidence:       " + a.Evidence);
        Console.WriteLine("  FullName:       " + a.FullName);
        Console.WriteLine("  Location:       " + a.Location);
        Console.WriteLine();

        object o1 = a.CreateInstance("MaClasse");
        ((MaClasse)o1).MyMeth();

        Console.WriteLine("GetCustomAttributes:");
        object[] tu = a.GetCustomAttributes(true);
        foreach (object u in tu)
            Console.WriteLine("  " + u.ToString());
        Console.WriteLine();

        Console.WriteLine("GetExportedTypes:");
        foreach (Type t1 in a.GetExportedTypes())
            Console.WriteLine("  " + t1.FullName);
        Console.WriteLine();

        Console.WriteLine("GetManifestResourceNames:");
        foreach (string s in a.GetManifestResourceNames())
            Console.WriteLine("  " + s);
        Console.WriteLine();

        Console.WriteLine("GetReferencedAssemblies:");
        foreach (AssemblyName an in a.GetReferencedAssemblies())
            Console.WriteLine("  " + an.FullName);
        Console.WriteLine();

        // Accès direct
        var z1 = (AssemblyCompanyAttribute)a.GetCustomAttributes(typeof(AssemblyCompanyAttribute), true)[0];
        Console.WriteLine(z1.Company);
        var z2 = (AssemblyCopyrightAttribute)a.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true)[0];
        Console.WriteLine(z2.Copyright);
    }
}