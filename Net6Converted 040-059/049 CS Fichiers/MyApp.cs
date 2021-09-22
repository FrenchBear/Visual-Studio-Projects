// 2001 PV
//
// 2006-10-01   PV  VS2005  Directory --> DirectoryInfo
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;
using System.IO;

internal class MyApp
{
    public static void Main()
    {
        DirectoryInfo[] td = (new DirectoryInfo(@"C:\Program files")).GetDirectories();
        foreach (DirectoryInfo d in td)
            Console.WriteLine("{0}  {1}", d.Name, d.FullName);

        DirectoryInfo d0 = new(@"C:\Temp");
        DirectoryInfo d1 = d0.CreateSubdirectory("Essais de dossiers");

        FileStream f0 = File.Create(d1.FullName + @"\f0");
        f0.Close();
        f0.Dispose();
        FileStream f1 = File.Create(d1.FullName + @"\f1");
        f1.Close();
        File.Delete(f1.Name);
        d1.Delete(true);

        String sPath;
        sPath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\Debug\net6.0\", "").Replace(@"bin\Release\net6.0\", "");

        StreamReader s2 = File.OpenText(sPath + "MyApp.cs");
        string ligne;
        while ((ligne = s2.ReadLine()) != null)
            Console.WriteLine(ligne);
        s2.Close();

        //Console.ReadLine();
    }
}