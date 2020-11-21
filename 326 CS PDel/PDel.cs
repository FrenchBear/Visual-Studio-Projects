// PDel
// .Net version of old utility pdel that delele a file or a group of files to the trashcan
// 2009-08-03   PV  First version 2.0 rewritten in C#
// 2009-08-08   PV  Security adjusted for Windows 7
// 2012-02-25   PV  VS2010
// 2020-11-21   PV  CS2019; .Net 4.8; Options -v, -f and -r2.  Ignore SYSTEM+HIDDEN directories

using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

[assembly: CLSCompliant(true)]

#nullable enable


namespace pdel
{
    class Program
    {
        static bool isRecurseMode;      // True when option -s is used, delete files in subfolders too
        static bool isVerbose = false;  // Option -v
        static bool isFinal = false;    // Option -f
        static bool isReparsePointsFollowed = false;
        static readonly TextWriter errorWriter = Console.Error;  // stderr


        /// A private structure to store an input path and pattern
        private struct InputSource
        {
            public string path;
            public string pattern;
        }

        /// <summary>
        /// Main entry point of this tool
        /// Returns 0 if input was processed correctly, 1 in case of argument error
        /// </summary>
        static int Main(string[] args)
        {
            var inputSourceList = new List<InputSource>();
            bool isWithFinalPause = false;

            // Process arguments
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i][0] == '-' || args[i][0] == '/')
                    switch (args[i].Substring(1).ToLower())
                    {
                        case "?":
                        case "help":
                            ShowUsage();
                            return 0;

                        case "??":
                            ShowExtendedHelp();
                            return 0;

                        case "s":
                            isRecurseMode = true;
                            break;

                        case "v":
                            isVerbose = true;
                            break;

                        case "r2":
                            isReparsePointsFollowed = true;
                            break;

                        case "f":
                            isFinal = true;
                            break;

                        case "p":
                            isWithFinalPause = true;
                            break;

                        default:
                            errorWriter.WriteLine("PDel: Unknown option " + args[i] + "\n");
                            return 1;
                    }
                else
                {
                    // Not really an option, but still we allow some common exceptions
                    if (args[i] == "?" || args[i].ToLower() == "help")
                    {
                        ShowUsage();
                        return 0;
                    }

                    // Ok, check it's a valid path/pattern
                    string path = Path.GetDirectoryName(args[i]);
                    if (path.Length == 0) path = ".";
                    string pattern = Path.GetFileName(args[i]);
                    try
                    {
                        // For now just test if we can enumerate files, don't care about recursing
                        string[] files = System.IO.Directory.GetFiles(path, pattern);
                    }
                    catch (Exception ex)
                    {
                        errorWriter.Write("PDel: Failed to explore pattern " + args[i] + ": " + ex.Message);
                        return 2;
                    }

                    var myInputSource = new InputSource
                    {
                        path = path,
                        pattern = pattern
                    };

                    inputSourceList.Add(myInputSource);
                }
            }
            if (inputSourceList.Count == 0)
            {
                errorWriter.WriteLine("PDel: You should provide at least one path/pattern\n");
                return 1;
            }


            // Do the delete
            foreach (InputSource loopInputSource in inputSourceList)
                PDel(loopInputSource.path, loopInputSource.pattern);

            if (isWithFinalPause)
            {
                Console.WriteLine();
                Console.Write("(pause) ");
                Console.ReadLine();
            }

            return 0;
        }

        private static void PDel(string path, string pattern)
        {
            string[] files;

            try
            {
                files = System.IO.Directory.GetFiles(path, pattern, System.IO.SearchOption.TopDirectoryOnly /*isRecurseMode ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly*/ );
                foreach (string fileName in files)
                {
                    // Delete one file
                    try
                    {
                        if (isVerbose)
                            Console.WriteLine("DEL " + QuotedFile(fileName));
                        FileSystem.DeleteFile(fileName, UIOption.OnlyErrorDialogs, isFinal ? RecycleOption.DeletePermanently : RecycleOption.SendToRecycleBin);
                    }
                    catch (Exception ex)
                    {
                        errorWriter.Write("PDel: Can't delete file " + fileName + ": " + ex.Message + '\n');
                        //return 2;
                    }
                }
                if (isRecurseMode)
                {
                    string[] folders = System.IO.Directory.GetDirectories(path, "*.*", System.IO.SearchOption.TopDirectoryOnly);
                    foreach (string directoryName in folders)
                    {
                        // Ignore SYSTEM+HIDDEN folders
                        DirectoryInfo di = new DirectoryInfo(directoryName);
                        if ((di.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden && (di.Attributes & FileAttributes.System) == FileAttributes.System)
                            continue;
                        // Also ignore reparse points unless we use /r2 option
                        if ((!isReparsePointsFollowed) && (di.Attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint)
                            continue;

                        PDel(directoryName, pattern);

                        // If we are deleting all files, then delete folders too
                        if (pattern == "*.*")
                        {
                            // Delete one directory
                            try
                            {
                                if (isVerbose)
                                    Console.WriteLine("RD " + QuotedFile(directoryName));
                                FileSystem.DeleteDirectory(directoryName, UIOption.OnlyErrorDialogs, isFinal ? RecycleOption.DeletePermanently : RecycleOption.SendToRecycleBin);
                            }
                            catch (Exception)
                            {
                                //errorWriter.Write("PDel: Can't delete file " + directoryName + ": " + ex.Message + '\n');
                                //return 2;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                errorWriter.WriteLine("PDel: Can't access folder " + path + ": " + ex.Message);
            }
        }

        private static string QuotedFile(string fileName) => fileName.Contains(" ") ? "\"" + fileName + "\"" : fileName;

        private static void ShowUsage() => Console.WriteLine(HelpHeader(false) + "\n\n" + Usage());

        private static void ShowExtendedHelp() => Console.WriteLine(HelpHeader(true) + "\n");


        private static string HelpHeader(bool includeExtendedHelp)
        {
            // Get information for this assembly
            Assembly asm = Assembly.GetExecutingAssembly();
            AssemblyName asmName = asm.GetName();
            Version v = asmName.Version;
            string asmTitle = ((AssemblyTitleAttribute)asm.GetCustomAttributes(
                typeof(AssemblyTitleAttribute), false)[0]).Title;
            string asmDesc = ((AssemblyDescriptionAttribute)asm.GetCustomAttributes(
                typeof(AssemblyDescriptionAttribute), false)[0]).Description;

            string s = asmTitle + " " + v.Major + "." + v.Minor + ": " + asmDesc;

            if (includeExtendedHelp)
            {
                string asmCopyright = ((AssemblyCopyrightAttribute)asm.GetCustomAttributes(
                    typeof(AssemblyCopyrightAttribute), false)[0]).Copyright;
                s += "\n" + asmCopyright;
            }

            return s;
        }

        private static string Usage()
        {
            return "Usage: PDel [-?] [-??] [-p] [-s] [-v] [-f] [path\\]pattern [path\\]pattern]...\n"
                 + "-?     Shows version and usage\n"
                 + "-??    Shows extended information\n"
                 + "-p     Adds a final pause\n"
                 + "-s     Recursive mode, include subfolders\n"
                 + "-v     Verbose, shows deleted files\n"
                 + "-f     Forced/final delete, does not send the file to trash can\n"
                 + "-r2    Follow reparse points (by default, they're skipped)\n"
                 ;
        }

    }
}
