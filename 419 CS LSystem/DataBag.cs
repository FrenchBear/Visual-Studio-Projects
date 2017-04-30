// 419 CS LSystem
// 2012-02-05   PV  First version
// 2012-02-27   PV  Use clean data binding (DataBag class) and supports all .l files correctly


using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Diagnostics;

namespace CS419
{
    class DataBag
    {
        public ObservableCollection<string> SourceFiles { get; set; }
        public ObservableCollection<SourceSystem> SourceSystems { get; set; }

        public DataBag()
        {
            SourceFiles = new ObservableCollection<string>();
            foreach (string file in Directory.GetFiles(@"..\..", "*.l"))
                SourceFiles.Add(Path.GetFileName(file));

            SourceSystems = new ObservableCollection<SourceSystem>();
        }

        public void SelectFile(string file)
        {
            // Temporary sorted storage
            // Allows multiple elements with the same "key", although there is no key element strictly speaking
            // but a comparer: elements that compare to 0 are Ok
            SortedSet<SourceSystem> sl = new SortedSet<SourceSystem>(new SourceSystemComparer());

            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\" + file))
                {
                    string line;
                    SourceSystem ss = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string lineComment;
                        int startComment = line.IndexOf(';');
                        if (startComment >= 0)
                        {
                            lineComment = line.Substring(startComment);
                            if (startComment == 0)
                                line = "";
                            else
                                line = line.Substring(0, startComment);

                            if (ss != null)
                            {
                                if (ss.Comments == null)
                                    ss.Comments = lineComment;
                                else
                                    ss.Comments += "\r\n" + lineComment;
                            }
                        }
                        else
                            lineComment = "";

                        int p = line.IndexOf('{');
                        if (p >= 0)
                        {
                            line = line.Substring(0, p - 1).Trim();
                            if (ss != null) Debugger.Break();
                            ss = new SourceSystem();
                            ss.Name = line;
                            //if (ss.Name=="FlowSnake") Debugger.Break();
                            if (lineComment != "") ss.Comments = lineComment;
                            sl.Add(ss);
                            continue;
                        }

                        if (ss == null) continue;       // Eliminate comments or lines at the beginning of the file
                        if (line.Length == 0) continue;   // Ignore empty lines

                        line = line.Trim();
                        if (line.StartsWith("Angle", StringComparison.InvariantCultureIgnoreCase))
                        {
                            int a;
                            int p1 = 5;
                            while (char.IsWhiteSpace(line[p1]) || line[p1] == '=')
                                p1++;
                            if (int.TryParse(line.Substring(p1), out a))
                                ss.Angle = a;
                        }
                        else if (line.StartsWith("Axiom", StringComparison.InvariantCultureIgnoreCase))
                        {
                            ss.Axiom = line.Substring(5).Trim().ToUpperInvariant();
                        }
                        else if (line.IndexOf('=') >= 0)
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
}