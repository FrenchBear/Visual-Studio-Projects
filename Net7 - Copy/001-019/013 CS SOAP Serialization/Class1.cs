// 2001         PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-17   PV  VS2022/Net6

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;

#pragma warning disable SYSLIB0011 // Type or member is obsolete

internal class TestSer
{
    [Serializable]
    private class MaClasse
    {
        private readonly int i;
        private readonly string s;

        public MaClasse(int i, string s)
        {
            this.i = i;
            this.s = s;
        }

        public override string ToString() 
            => "i:" + i + ", s:" + s;
    }

    public static void Main(string[] args)
    {
        var objects = 1000;

        WriteLine("Writing " + objects + " objects to a file stream");
        Stream s = File.Open("testser.xml", FileMode.Create);
        //SoapFormatter f = new SoapFormatter();
        BinaryFormatter f = new();
        for (var i = 1; i <= objects; i++)
        {
            f.Serialize(s, new MaClasse(i, "abcdddddddddddddddddddddddddddddddd"));
        }
        s.Close();
        WriteLine("Writing done.");

        WriteLine("Deserializing objects from file...");
        s = new BufferedStream(File.Open("testser.xml", FileMode.Open));
        MaClasse var = null;
        WriteLine("Start: " + DateTime.Now);
        try
        {
            for (var i = 1; i <= objects; i++)
            {
                var = (MaClasse)f.Deserialize(s);
            }
        }
        catch (Exception e)
        {
            WriteLine("Deserialization failed: " + e.Message);
        }
        s.Close();
        WriteLine("End: " + DateTime.Now);
        WriteLine("The last object is: " + var);

        _ = Console.ReadLine();
    }
}