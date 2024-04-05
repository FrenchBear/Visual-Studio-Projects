// PDel
// .Net version of old utility pdel that delele a file or a group of files to the trashcan
// 2009-08-03   PV      First version 2.0 rewritten in C#
// 2009-08-08   PV      Security adjusted for Windows 7
// 2012-02-25   PV      VS2010
// 2020-11-21   PV      CS2019; .Net 4.8; Options -v, -f and -r2.  Ignore SYSTEM+HIDDEN directories
// 2020-11-24   PV      WidePath to support paths longer than 256 chars; Option -n
//
// Debug on long paths:
// /s /p /f /v /n "\\TERAZ\BACKUP_SKULL\C\Eurofins\Eurofins\US\eLIMS-FGS-Trunk\Fitnesse\FitNesseRoot\FitNesse\SuiteAcceptanceTests\SuiteSlimTests\ScenarioLibraryTestSuite\ScenarioLibariesOrderTests\ScenarioLibraryOrderSuite\ScenarioLibraryOrderTestParent\ScenarioLibrary\thumbs.db"

using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#nullable enable

namespace PDel
{
    internal class Program
    {
        private static bool isRecurseMode;          // True when option -s is used, delete files in subfolders too
        private static bool isVerbose = false;      // Option -v
        private static bool isNoAction = false;     // Option -n
        private static bool isFinal = false;        // Option -f
        private static bool isReparsePointsFollowed = false;
        private static readonly TextWriter errorWriter = Console.Error;  // stderr

        // A private structure to store an input path and pattern
        private struct InputSource
        {
            public string path;
            public string pattern;
        }

        /// <summary>
        /// Main entry point of this tool
        /// Returns 0 if input was processed correctly, 1 in case of argument error
        /// </summary>
        private static int Main(string[] args)
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

                        case "n":
                            isNoAction = true;
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
                        string[] files = Directory.GetFiles(WidePath(path), pattern);
                    }
                    catch (Exception ex)
                    {
                        errorWriter.Write("PDel: Failed to explore pattern " + args[i] + ": " + ex.Message);
                        return 2;
                    }

                    // Check that we're not just passing a directory without a file part
                    if (Directory.Exists(args[i]))
                    {
                        errorWriter.Write("PDel: Parameter " + args[i] + " is just a directory.  A file/pattern part is required.");
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

        /// <summary>
        /// Function to use filenames up to 32000 characters.  According to Win32 help:
        /// The Unicode versions of several functions permit paths that exceed the MAX_PATH length if the path has the "\\?\" prefix.
        /// The "\\?\" tells the function to turn off path parsing. However, each component in the path cannot be more than MAX_PATH
        /// characters long. Use the "\\?\" prefix with paths for local storage devices and the "\\?\UNC\" prefix with paths having
        /// the Universal Naming Convention (UNC) format. The "\\?\" is ignored as part of the path. For example, "\\?\C:\myworld\private"
        /// is seen as "C:\myworld\private", and "\\?\UNC\bill_g_1\hotstuff\coolapps" is seen as "\\bill_g_1\hotstuff\coolapps".
        /// </summary>
        private static string WidePath(string path)
        {
            if (path.StartsWith(@"\\?\"))               // Already widened
                return path;
            if (path.Length >= 1 && path[1] == ':')     // Local drive
                return @"\\?\" + path;
            if (path.StartsWith(@"\\"))                 // UNC path
                return @"\\?\UNC" + path.Substring(1);
            return path;            // For local relative/no drive names, keep name as is
        }

        private static string UnwidePath(string path)
        {
            if (!path.StartsWith(@"\\?\"))              // Not a wide path
                return path;
            if (path.StartsWith(@"\\?\UNC"))            // UNC wide path
                return @"\" + path.Substring(7);
            if (path.StartsWith(@"\\?\"))               // Other wide path
                return path.Substring(4);
            return path;                                // Other shuff (?)
        }

        private const int MAX_PATH = 260;

        private static void PDel(string path, string pattern)
        {
            string[] files;

            try
            {
                files = Directory.GetFiles(WidePath(path), pattern, System.IO.SearchOption.TopDirectoryOnly);
                foreach (string fileName in files)
                {
                    string normalFileName = UnwidePath(fileName);

                    // Delete one file
                    if (normalFileName.Length < MAX_PATH)
                    {
                        try
                        {
                            if (isVerbose)
                                Console.WriteLine((isFinal ? "DEL " : "PDEL ") + QuotedFile(normalFileName));
                            if (!isNoAction)
                                FileSystem.DeleteFile(normalFileName, UIOption.OnlyErrorDialogs, isFinal ? RecycleOption.DeletePermanently : RecycleOption.SendToRecycleBin);
                        }
                        catch (Exception ex)
                        {
                            errorWriter.Write("PDel: Can't delete file " + normalFileName + ": " + ex.Message + '\n');
                        }
                    }
                    else
                    {
                        try
                        {
                            if (isVerbose)
                                Console.WriteLine("DEL " + QuotedFile(fileName));
                            if (!isNoAction)
                                File.Delete(fileName);
                        }
                        catch (Exception ex)
                        {
                            errorWriter.Write("PDel: Can't delete long file " + fileName + ": " + ex.Message + '\n');
                        }
                    }
                }

                if (isRecurseMode)
                {
                    string[] folders = Directory.GetDirectories(WidePath(path), "*.*", System.IO.SearchOption.TopDirectoryOnly);
                    foreach (string directoryName in folders)
                    {
                        // Ignore SYSTEM+HIDDEN folders
                        var di = new DirectoryInfo(directoryName);
                        if ((di.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden && (di.Attributes & FileAttributes.System) == FileAttributes.System)
                            continue;
                        // Also ignore reparse points unless we use /r2 option
                        if ((!isReparsePointsFollowed) && (di.Attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint)
                            continue;

                        PDel(directoryName, pattern);

                        // If we are deleting all files, then delete folders too
                        if (pattern == "*.*")
                        {
                            string normalDirectoryName = UnwidePath(directoryName);

                            // Delete one directory
                            if (normalDirectoryName.Length < MAX_PATH)
                            {
                                try
                                {
                                    if (isVerbose)
                                        Console.WriteLine((isFinal ? "RD " : "PRD ") + QuotedFile(normalDirectoryName));
                                    if (!isNoAction)
                                        FileSystem.DeleteDirectory(normalDirectoryName, UIOption.OnlyErrorDialogs, isFinal ? RecycleOption.DeletePermanently : RecycleOption.SendToRecycleBin);
                                }
                                catch (Exception ex)
                                {
                                    errorWriter.Write("PDel: Can't delete directory " + normalDirectoryName + ": " + ex.Message + '\n');
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (isVerbose)
                                        Console.WriteLine("RD " + QuotedFile(directoryName));
                                    if (!isNoAction)
                                        Directory.Delete(directoryName);
                                }
                                catch (Exception ex)
                                {
                                    errorWriter.Write("PDel: Can't delete long directory " + directoryName + ": " + ex.Message + '\n');
                                }
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

        //// Win32 file delete
        //[DllImport("kernel32.dll", EntryPoint = "DeleteFileW", SetLastError = true, CharSet = CharSet.Unicode)]
        //static extern bool DeleteFile(string lpFileName);

        private static string QuotedFile(string fileName) => fileName.Contains(" ") ? "\"" + fileName + "\"" : fileName;

        private static void ShowUsage() => Console.WriteLine(HelpHeader(false) + "\n\n" + Usage());

        private static void ShowExtendedHelp() => Console.WriteLine(HelpHeader(true) + "\n");

        private static string HelpHeader(bool includeExtendedHelp)
        {
            // Get information for this assembly
            var asm = Assembly.GetExecutingAssembly();
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

        private static string Usage() => "Usage: PDel [-?] [-??] [-p] [-s] [-v] [-f] [path\\]pattern [path\\]pattern]...\n"
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