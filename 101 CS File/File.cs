// File Application
// Determines type of a text file
// 2004-11-29   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;
using System.IO;

namespace NSFile
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class ClsFile
    {
        static bool isAscii(byte c)
        {
            return c >= 1 && c < 127;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string sType;
            bool bRename = false;

            //string[] tsFiles = Directory.GetFiles(@"C:\Development\Eurofins\Dvpt France\Eurodat 4.5\ProcSql", "*.sql");
            string[] tsFiles = Directory.GetFiles(@"C:\SVN\eLIMS\Trunk\eLims\SE Implementation\Stored Procedures\Eurodat4", "E4*.sql");

            foreach (string s in tsFiles)
            {
                string sFilename;
                sFilename = System.IO.Path.GetFileName(s);
                bRename = false;

                using (FileStream fs = new FileStream(s, FileMode.Open, FileAccess.Read))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] tbBuffer;
                    int l = (int)fs.Length;

                    tbBuffer = br.ReadBytes(l);

                    if (tbBuffer[0] == 0xFF && tbBuffer[1] == 0xFE)
                        sType = "Unicode";
                    else if (isAscii(tbBuffer[0]) && isAscii(tbBuffer[1]) && isAscii(tbBuffer[2]) && isAscii(tbBuffer[3]))
                        sType = "ASCII";
                    else if (isAscii(tbBuffer[0]) && tbBuffer[1] == 0 && isAscii(tbBuffer[2]) && tbBuffer[3] == 0)
                        sType = "Unicode";
                    else
                        sType = "?";

                    if (sType == "Unicode")
                        for (int i = 0; i < l; i++)
                            if (tbBuffer[i] == 13 && tbBuffer[i + 1] == 10)
                            {
                                sType += " Bad";
                                break;
                            }

                    Console.WriteLine("{0,-50} {1}", sFilename, sType);

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
            Console.ReadLine();
        }
    }
}
