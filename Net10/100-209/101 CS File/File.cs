// File Application
// Determines type of a text file
//
// 2004-11-29   PV
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-19	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System;
using System.IO;
using static System.Console;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace NSFile;

/// <summary>
/// Summary description for Class1.
/// </summary>
internal class ClsFile
{
    private static bool IsAscii(byte c) => c is >= 1 and < 127;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
        string sType;
        var bRename = false;

        //string[] tsFiles = Directory.GetFiles(@"C:\Development\Eurofins\Dvpt France\Eurodat 4.5\ProcSql", "*.sql");
        var tsFiles = Directory.GetFiles(@"C:\SVN\eLIMS\Trunk\eLims\SE Implementation\Stored Procedures\Eurodat4", "E4*.sql");

        foreach (var s in tsFiles)
        {
            var sFilename = Path.GetFileName(s);
            bRename = false;

            using (FileStream fs = new(s, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new(fs))
            {
                var l = (int)fs.Length;
                var tbBuffer = br.ReadBytes(l);

                sType = tbBuffer[0] == 0xFF && tbBuffer[1] == 0xFE
                    ? "Unicode"
                    : IsAscii(tbBuffer[0]) && IsAscii(tbBuffer[1]) && IsAscii(tbBuffer[2]) && IsAscii(tbBuffer[3])
                    ? "ASCII"
                    : IsAscii(tbBuffer[0]) && tbBuffer[1] == 0 && IsAscii(tbBuffer[2]) && tbBuffer[3] == 0 ? "Unicode" : "?";

                if (sType == "Unicode")
                {
                    for (var i = 0; i < l; i++)
                    {
                        if (tbBuffer[i] == 13 && tbBuffer[i + 1] == 10)
                        {
                            sType += " Bad";
                            break;
                        }
                    }
                }

                WriteLine("{0,-50} {1}", sFilename, sType);

                /*
                if (sType=="Unicode Bad")
                {
                    using(FileStream fn = new FileStream(s + ".new", FileMode.Create, System.IO.FileAccess.Write))
                    using(BinaryWriter bw = new BinaryWriter(fn))
                    {
                        for (int i=0 ; i<l ; i++)
                        {
                            bw.Write(tbBuffer[i]);
                            if (tbBuffer[i]==13 && tbBuffer[i+1]==10)
                                bw.Write((char)0);
                        }
                    }

                    bRename=true;
                }
                */
            }

            if (bRename)
            {
                File.Move(s, s + ".old");
                File.Move(s + ".new", s);
            }
        }
    }
}
