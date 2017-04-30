// 508 CS ReadOnly Collections
// 2013-01-29   PV
// Tests on ReadOnly collections

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS508
{
    class Program
    {
        static void Main(string[] args)
        {

            // ReadOnly Dictionary
            var d1 = getNumberDic1();
            foreach (var k in d1.Keys)
                Console.WriteLine(k.ToString() + " -> " + d1[k]);
            Console.WriteLine();

            var d2 = getNumberDic2();
            foreach (var k in d2.Keys)
                Console.WriteLine(k.ToString() + " -> " + d2[k]);
            Console.WriteLine();
            // Problem with just an interface is that you can still recast it to a real dictionary and add elements to it...
            var d3 = (Dictionary<int, string>)d2;
            d3.Add(4, "Four");


            // ReadOnly List
            var l = getList();
            //var l2 = (List<int>)l;
            //l2.Add(17);


            Console.Write("(Pause)");
            Console.ReadLine();
        }

        // Build a new ReadOnlyDictionary object, that is a wrapper around the original dictionary
        static ReadOnlyDictionary<int, string> getNumberDic1()
        {
            var d = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "Three" } };
            return new ReadOnlyDictionary<int, string>(d);
        }

        // Return IReadOnlyDictionary interface of a real dictionary
        static IReadOnlyDictionary<int, string> getNumberDic2()
        {
            var d = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "Three" } };
            return (IReadOnlyDictionary<int, string>)d;
        }


        static ReadOnlyObservableCollection<string> getObservableCollection1()
        {
            var c = new ObservableCollection<string> { "Once", "upon", "a", "time" };
            return new ReadOnlyObservableCollection<string>(c);
        }


        static IReadOnlyList<int> getList()
        {
            var l = new List<int> { 2, 3, 5, 7, 11, 13 };
            // There is no ReadOnlyList class, but a list can be exposed as a ReadOnly, with no way to cast it back
            // to a normal read/write list
            return (IReadOnlyList<int>)l.AsReadOnly();
        }

    }
}
