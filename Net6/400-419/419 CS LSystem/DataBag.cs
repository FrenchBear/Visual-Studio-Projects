// 419 CS LSystem
//
// 2012-02-05   PV  First version
// 2012-02-27   PV  Use clean data binding (DataBag class) and supports all .l files correctly
// 2021-09-23   PV  VS2022; Net6; Move .l and links into subfolders
// 2021-12-11   PV  (new) support for interactive edition of rules

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace CS419;

internal class DataBag
{
    public ObservableCollection<string> SourceFiles { get; set; }
    public ObservableCollection<SourceSystem> SourceSystems { get; set; }

    public DataBag()
    {
        SourceFiles = new ObservableCollection<string>();
        foreach (string file in Directory.GetFiles("Systems", "*.l"))
            SourceFiles.Add(Path.GetFileName(file));
        SourceFiles.Add("(new)");

        SourceSystems = new ObservableCollection<SourceSystem>();
    }

    public void SelectFile(string file)
    {
        // Temporary sorted storage
        // Allows multiple elements with the same "key", although there is no key element strictly speaking
        // but a comparer: elements that compare to 0 are Ok
        SortedSet<SourceSystem> sl = new(new SourceSystemComparer());

        if (file == "(new)")
        {
            var ss = new SourceSystem { Angle = 4, Axiom = "F", Name = "(new)", Comments = "Test your own design!", Rules = "" };
            sl.Add(ss);
        }
        else
            try
            {
                using StreamReader sr = new(Path.Join("Systems", file));
                string line;
                SourceSystem ss = null;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineComment;
                    int startComment = line.IndexOf(';');
                    if (startComment >= 0)
                    {
                        lineComment = line[startComment..];
                        line = startComment == 0 ? "" : line[..startComment];

                        if (ss != null)
                        {
                            if (ss.Comments == null)
                                ss.Comments = lineComment;
                            else
                                ss.Comments += "\r\n" + lineComment;
                        }
                    }
                    else
                    {
                        lineComment = "";
                    }

                    int p = line.IndexOf('{');
                    if (p >= 0)
                    {
                        line = line[..(p - 1)].Trim();
                        if (ss != null)
                            Debugger.Break();
                        ss = new SourceSystem
                        {
                            Name = line
                        };
                        //if (ss.Name=="FlowSnake") Debugger.Break();
                        if (lineComment != "")
                            ss.Comments = lineComment;
                        _ = sl.Add(ss);
                        continue;
                    }

                    if (ss == null)
                        continue;       // Eliminate comments or lines at the beginning of the file
                    if (line.Length == 0)
                        continue;   // Ignore empty lines

                    line = line.Trim();
                    if (line.StartsWith("Angle", StringComparison.InvariantCultureIgnoreCase))
                    {
                        int p1 = 5;
                        while (char.IsWhiteSpace(line[p1]) || line[p1] == '=')
                            p1++;
                        if (int.TryParse(line[p1..], out int a))
                            ss.Angle = a;
                    }
                    else if (line.StartsWith("Axiom", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ss.Axiom = line[5..].Trim().ToUpperInvariant();
                    }
                    else if (line.Contains('='))
                    {
                        if (ss.Rules == null)
                            ss.Rules = line.ToUpperInvariant();
                        else
                            ss.Rules += "\r\n" + line.ToUpperInvariant();
                    }
                    else if (line == "}")
                    {
                        ss = null;
                    }
                }
            }
            catch (Exception)
            {
                // nop;
            }

        // Finally add to exposed (inherited) list
        SourceSystems.Clear();
        foreach (SourceSystem sourceSystem in sl)
            SourceSystems.Add(sourceSystem);
    }
}