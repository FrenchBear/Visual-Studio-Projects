﻿// 515 CS Equals and inheritance
// Implementation of a clean pattern for value comparison ob objects in the context of inheritance
// non-virtual (by design) version of Equals that is part of IEquatable<T> is not working with base class rerefences containing derived objects (it only calls Equals of the base class)
// Reading: example on Point3D in http://msdn.microsoft.com/en-us/library/bsc2ak47.aspx
// 2013-08-22   PV

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS515
{
    class Program
    {
        static void Main(string[] args)
        {
            RE_ExtraData e1 = new RE_ExtraData { BaseData = 3.14 };
            RE_ExtraData e2 = new RE_ExtraData { BaseData = 3.14 };
            Debug.Assert(e1.Equals(e2));

            RE_ExtraDataChemistry c1 = new RE_ExtraDataChemistry { BaseData = 3.14, Uncertainty = 1.23 };
            RE_ExtraDataChemistry c2 = new RE_ExtraDataChemistry { BaseData = 3.14, Uncertainty = 4.56 };
            Debug.Assert(!c1.Equals(c2));

            e1 = c1;
            e2 = c2;
            Debug.Assert(!e1.Equals(e2));

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }

    // Base class for LabValue extensions
    public class RE_ExtraData
    {
        public double BaseData { get; set; }


        public override bool Equals(Object obj)
        {
            RE_ExtraData other = obj as RE_ExtraData;
            if ((object)other == null) return false;
            return BaseData == other.BaseData;
        }

        public override int GetHashCode()
        {
            return BaseData.GetHashCode();
        }


    }

    // Specialized version for chemistry
    public class RE_ExtraDataChemistry : RE_ExtraData
    {
        public double Uncertainty { get; set; }


        public override bool Equals(Object obj)
        {
            RE_ExtraDataChemistry other = obj as RE_ExtraDataChemistry;
            if ((object)other == null) return false;
            if (!base.Equals(obj)) return false;

            return Uncertainty == other.Uncertainty;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Uncertainty.GetHashCode();
        }

    }


}
