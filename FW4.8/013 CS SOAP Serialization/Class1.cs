// 2001 PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//using System.Runtime.Serialization.Formatters.Soap;

internal class TestSer
{
    [Serializable]
    private class MaClasse
    {
        private readonly int i;
        private readonly String s;

        public MaClasse(int i, String s)
        {
            this.i = i;
            this.s = s;
        }

        public override String ToString() => "i:" + i + ", s:" + s;
    }

    public static void Main(string[] args)
    {
        int objects = 1000;

        Console.WriteLine("Writing " + objects + " objects to a file stream");
        Stream s = File.Open("testser.xml", FileMode.Create);
        //SoapFormatter f = new SoapFormatter();
        var f = new BinaryFormatter();
        for (int i = 1; i <= objects; i++)
        {
            f.Serialize(s, new MaClasse(i, "abcdddddddddddddddddddddddddddddddd"));
        }
        s.Close();
        Console.WriteLine("Writing done.");

        Console.WriteLine("Deserializing objects from file...");
        s = new BufferedStream(File.Open("testser.xml", FileMode.Open));
        MaClasse var = null;
        Console.WriteLine("Start: " + DateTime.Now);
        try
        {
            for (int i = 1; i <= objects; i++)
            {
                var = (MaClasse)f.Deserialize(s);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Deserialization failed: " + e.Message);
        }
        s.Close();
        Console.WriteLine("End: " + DateTime.Now);
        Console.WriteLine("The last object is: " + var);

        Console.ReadLine();
    }
}