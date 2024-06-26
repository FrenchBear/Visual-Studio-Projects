// 419 CS LSystem
// 2012-02-05   PV

using System.Collections.Generic;
using System.Globalization;

namespace CS419
{
    internal class SourceSystem
    {
        public string Name { get; set; }
        public int Angle { get; set; }
        public string Axiom { get; set; }
        public string Comments { get; set; }
        public string Rules { get; set; }

        public override string ToString() => Name;
    }

    internal class SourceSystemComparer : IComparer<SourceSystem>
    {
        public int Compare(SourceSystem x, SourceSystem y) => string.Compare(x.Name, y.Name, true, CultureInfo.InvariantCulture);
    }
}