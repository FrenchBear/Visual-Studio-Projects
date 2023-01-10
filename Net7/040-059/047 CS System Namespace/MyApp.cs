// 2001 PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6
// 2023-01-10	PV		Net7

using System;
using System.Collections;
using System.IO;
using System.Reflection;
using static System.Console;

internal static class MyApp
{
    private static Hashtable dicMain;
    private static Hashtable dic;
    private static SortedList slNameSpaces;

    public static void Main()
    {
        dicMain = new Hashtable();
        slNameSpaces = new SortedList();

        AnalyseAssembly("mscorlib.dll");
        AnalyseAssembly("System.Collections.dll");
        //AnalyseAssembly("Microsoft.Win32.Interop.dll");
        //AnalyseAssembly("System.Timers.dll");
        //AnalyseAssembly("System.Configuration.Design.dll");
        //AnalyseAssembly("System.Configuration.dll");
        //AnalyseAssembly("System.Configuration.Install.dll");
        //AnalyseAssembly("System.Configuration.Objects.dll");
        //AnalyseAssembly("System.Data.Design.dll");
        //AnalyseAssembly("System.Data.dll");
        //AnalyseAssembly("System.Diagnostics.Design.dll");
        //AnalyseAssembly("System.Diagnostics.dll");
        //AnalyseAssembly("System.DirectoryServices.dll");
        //AnalyseAssembly("System.dll");
        //AnalyseAssembly("System.Drawing.Design.dll");
        //AnalyseAssembly("System.Drawing.dll");
        //AnalyseAssembly("System.Drawing.Printing.Design.dll");
        //AnalyseAssembly("System.IO.dll");
        //AnalyseAssembly("System.Messaging.dll");
        //AnalyseAssembly("System.Net.dll");
        //AnalyseAssembly("System.Runtime.Remoting.dll");
        //AnalyseAssembly("System.Runtime.Serialization.Formatters.Soap.dll");
        //AnalyseAssembly("System.Security.dll");
        //AnalyseAssembly("System.ServiceProcess.dll");
        //AnalyseAssembly("System.Text.RegularExpressions.dll");
        //AnalyseAssembly("System.ComponentModel.Design.dll");
        //AnalyseAssembly("System.Web.dll");
        //AnalyseAssembly("System.Web.Services.Design.dll");
        //AnalyseAssembly("System.Web.Services.dll");
        //AnalyseAssembly("System.Web.UI.Design.dll");
        //AnalyseAssembly("System.WinForms.Design.dll");
        //AnalyseAssembly("System.WinForms.dll");
        //AnalyseAssembly("System.XML.dll");
        //AnalyseAssembly("System.Xml.Serialization.dll");
        //AnalyseAssembly("System.Management.dll");

        StreamWriter writer;
        try
        {
            writer = File.CreateText(@"c:\temp\analyse.htm");
        }
        catch (Exception ex2)
        {
            WriteLine(ex2.Message);
            return;
        }

        writer.WriteLine("<HTML><TABLE BORDER=1 CELLSPACING=0 CELLPADDING=0><TR><TH></TH>");
        SortedList slMain = new(dicMain);
        var enuMain = slMain.GetEnumerator();
        while (enuMain.MoveNext())
            writer.Write("<TH>{0}</TH>", enuMain.Key);
        writer.WriteLine("</TD>");

        var enuNameSpaces = slNameSpaces.GetEnumerator();
        while (enuNameSpaces.MoveNext())
        {
            var ns = enuNameSpaces.Key.ToString();
            writer.WriteLine("<TR VAlign=\"Top\"><TD>{0}</TD>", ns);
            enuMain.Reset();
            while (enuMain.MoveNext())
            {
                writer.WriteLine("<TD>");
                var d = (Hashtable)enuMain.Value;
                if (d.Contains(ns))
                {
                    /*
                    IDictionaryEnumerator enuClasses = ((SortedList)d[ns]).GetEnumerator();
                    while (enuClasses.MoveNext())
                      writer.Write("{0}<BR>", enuClasses.Key.ToString());
                    */
                    writer.Write("X");
                }
                else
                {
                    writer.Write("&nbsp;");
                }

                writer.WriteLine("</TD>");
            }
            writer.WriteLine("</TR>");
        }

        writer.Close();

        WriteLine(@"Fichier c:\analyse.htm généré");    //, entrée pour continuer...");
        //Console.ReadLine();
    }

    private static void AnalyseAssembly(string sNomAssembly)
    {
        dic = new Hashtable();
        dicMain.Add(sNomAssembly, dic);

        var a = Assembly.LoadFrom(Path.Join(@"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\5.0.10", sNomAssembly ));

        foreach (var m in a.GetModules())
            AnalyseModule(m);
    }

    private static void AnalyseModule(Module m)
    {
        WriteLine("Module {0}", m.Name);

        foreach (var t in m.GetTypes())
            AnalyseType(t);
    }

    private static void AnalyseType(Type t)
    {
        /*
        Console.Write("  ");
        if (t.IsClass) Console.Write("class ");
        if (t.IsValueType) Console.Write("struct ");
        if (t.IsEnum) Console.Write("enum ");
        if (t.IsInterface) Console.Write("interface ");

        if (t.IsAbstract) Console.Write("abstract ");
        if (t.IsAnsiClass) Console.Write("ansi ");
        if (t.IsArray) Console.Write("array ");
        if (t.IsAutoClass) Console.Write("autoclass ");
        if (t.IsAutoLayout) Console.Write("autolayout ");
        if (t.IsCOMObject) Console.Write("COMObject ");
        if (t.IsContextful) Console.Write("contextful ");
        if (t.IsExplicitLayout) Console.Write("explicitlayout ");
        if (t.IsImport) Console.Write("import ");
        if (t.IsLayoutSequential) Console.Write("layoutsequential ");
        if (t.IsMarshalByRef) Console.Write("marshalbyref ");
        if (t.IsNestedAssembly) Console.Write("NestedAssembly ");
        if (t.IsNestedFamANDAssem) Console.Write("NestedFamANDAssem ");
        if (t.IsNestedFamily) Console.Write("NestedFamily ");
        if (t.IsNestedFamORAssem) Console.Write("NestedFamORAssem ");
        if (t.IsNestedPrivate) Console.Write("NestedPrivate ");
        if (t.IsNestedPublic) Console.Write("NestedPublic ");
        if (t.IsNotPublic) Console.Write("notpublic ");
        if (t.IsPointer) Console.Write("pointer ");
        if (t.IsPrimitive) Console.Write("primitive ");
        if (t.IsPublic) Console.Write("public ");
        if (t.IsSealed) Console.Write("sealed ");
        if (t.IsSerializable) Console.Write("serializable ");
        if (t.IsServicedComponent) Console.Write("ServicedComponent ");
        if (t.IsSpecialName) Console.Write("SpecialName ");
        if (t.IsUnicodeClass) Console.Write("UnicodeClass ");
        if (t.IsUnmanagedValueType) Console.Write("UnmanagedValueType ");

        WriteLine("  {0}/{1}", t.FullName);
        */

        if (!t.IsPublic) return;

        /*
        int p;
        p = t.FullName.LastIndexOf(".");
        string ns = t.FullName.Substring(0,p);  // namespace
        string bn = t.FullName.Substring(p+1);	  // basename
        */

        var ns = t.Namespace;
        var bn = t.Name;

        if (t.IsClass) bn = "class " + bn;
        if (t.IsValueType && !t.IsEnum) bn = "struct " + bn;
        if (t.IsEnum) bn = "enum " + bn;
        if (t.IsInterface) bn = "interface " + bn;

        // Collection globale des namespaces
        ns ??= "(global)";  // if (ns == null) ns = "(global)";
        if (!slNameSpaces.Contains(ns))
            slNameSpaces.Add(ns, null);

        SortedList s;
        if (dic.Contains(ns))
        {
            s = (SortedList)dic[ns];
        }
        else
        {
            s = new SortedList();
            dic.Add(ns, s);
        }

        s.Add(bn, null);
    }
}
