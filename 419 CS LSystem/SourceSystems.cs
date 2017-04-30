// 419 CS LSystem
// 2012-02-05   PV


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace CS419
{
    class SourceSystem
    {
        public string Name { get; set; }
        public int Angle { get; set; }
        public string Axiom { get; set; }
        public string Comments { get; set; }
        public string Rules { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    class SourceSystemComparer : IComparer<SourceSystem>
    {
        public int Compare(SourceSystem x, SourceSystem y)
        {
            return string.Compare(x.Name, y.Name, true, CultureInfo.InvariantCulture);
        }
    }

}