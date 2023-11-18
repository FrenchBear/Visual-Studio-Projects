// 515 CS Equals and inheritance
// Implementation of a clean pattern for value comparison ob objects in the context of inheritance
// non-virtual (by design) version of Equals that is part of IEquatable<T> is not working with base class rerefences containing derived objects (it only calls Equals of the base class)
// Reading: example on Point3D in http://msdn.microsoft.com/en-us/library/bsc2ak47.aspx
//
// 2013-08-22   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using System.Diagnostics;

namespace CS515;

internal class Program
{
    private static void Main(string[] args)
    {
        RE_ExtraData e1 = new() { BaseData = 3.14 };
        RE_ExtraData e2 = new() { BaseData = 3.14 };
        Debug.Assert(e1.Equals(e2));

        RE_ExtraDataChemistry c1 = new() { BaseData = 3.14, Uncertainty = 1.23 };
        RE_ExtraDataChemistry c2 = new() { BaseData = 3.14, Uncertainty = 4.56 };
        Debug.Assert(!c1.Equals(c2));

        e1 = c1;
        e2 = c2;
        Debug.Assert(!e1.Equals(e2));
    }
}

// Base class for LabValue extensions
public class RE_ExtraData
{
    public double BaseData { get; set; }

    public override bool Equals(object obj) => obj is RE_ExtraData other && BaseData == other.BaseData;

    public override int GetHashCode() => BaseData.GetHashCode();
}

// Specialized version for chemistry
public class RE_ExtraDataChemistry: RE_ExtraData
{
    public double Uncertainty { get; set; }

    public override bool Equals(object obj)
        => obj is RE_ExtraDataChemistry other && base.Equals(obj) && Uncertainty == other.Uncertainty;

    public override int GetHashCode() => base.GetHashCode() ^ Uncertainty.GetHashCode();
}
