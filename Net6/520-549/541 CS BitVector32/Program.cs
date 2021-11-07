// CS 541 BitVector32
// Examples of use of BitVector32 Class
//
// 2016-08-01   PV
// 2021-09-26   PV      VS2022; Net6

using System;
using System.Collections.Specialized;

namespace CS541_BitVector32;

internal class Program
{
    private static void Main(string[] args)
    {
        // Creates and initializes a BitVector32 with all bit flags set to FALSE.
        BitVector32 myBVb = new(0);

        // Creates masks to isolate each of the first five bit flags.
        int myBit1 = BitVector32.CreateMask();
        int myBit2 = BitVector32.CreateMask(myBit1);
        int myBit3 = BitVector32.CreateMask(myBit2);
        int myBit4 = BitVector32.CreateMask(myBit3);
        int myBit5 = BitVector32.CreateMask(myBit4);
        Console.WriteLine("Initial:               \t{0}", myBVb.ToString());

        // Sets the third bit to TRUE.
        myBVb[myBit3] = true;
        Console.WriteLine("myBit3 = TRUE          \t{0}", myBVb.ToString());

        // Combines two masks to access multiple bits at a time.
        myBVb[myBit4 + myBit5] = true;
        Console.WriteLine("myBit4 + myBit5 = TRUE \t{0}", myBVb.ToString());
        myBVb[myBit1 | myBit2] = true;
        Console.WriteLine("myBit1 | myBit2 = TRUE \t{0}", myBVb.ToString());
        Console.WriteLine();

        // Creates and initializes a BitVector32.
        BitVector32 myBVs = new(0);

        // Creates four sections in the BitVector32 with maximum values 6, 3, 1, and 15.
        // mySect3, which uses exactly one bit, can also be used as a bit flag.
        BitVector32.Section mySect1 = BitVector32.CreateSection(6);
        BitVector32.Section mySect2 = BitVector32.CreateSection(3, mySect1);
        BitVector32.Section mySect3 = BitVector32.CreateSection(1, mySect2);
        BitVector32.Section mySect4 = BitVector32.CreateSection(15, mySect3);

        // Displays the values of the sections.
        Console.WriteLine("Initial values:");
        Console.WriteLine("\tmySect1: {0}", myBVs[mySect1]);
        Console.WriteLine("\tmySect2: {0}", myBVs[mySect2]);
        Console.WriteLine("\tmySect3: {0}", myBVs[mySect3]);
        Console.WriteLine("\tmySect4: {0}", myBVs[mySect4]);

        // Sets each section to a new value and displays the value of the BitVector32 at each step.
        Console.WriteLine("Changing the values of each section:");
        Console.WriteLine("\tInitial:    \t{0}", myBVs.ToString());
        myBVs[mySect1] = 5;
        Console.WriteLine("\tmySect1 = 5:\t{0}", myBVs.ToString());
        myBVs[mySect2] = 3;
        Console.WriteLine("\tmySect2 = 3:\t{0}", myBVs.ToString());
        myBVs[mySect3] = 1;
        Console.WriteLine("\tmySect3 = 1:\t{0}", myBVs.ToString());
        myBVs[mySect4] = 9;
        Console.WriteLine("\tmySect4 = 9:\t{0}", myBVs.ToString());

        // Displays the values of the sections.
        Console.WriteLine("New values:");
        Console.WriteLine("\tmySect1: {0}", myBVs[mySect1]);
        Console.WriteLine("\tmySect2: {0}", myBVs[mySect2]);
        Console.WriteLine("\tmySect3: {0}", myBVs[mySect3]);
        Console.WriteLine("\tmySect4: {0}", myBVs[mySect4]);
    }
}