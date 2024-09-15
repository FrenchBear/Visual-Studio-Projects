// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using CS619;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CS619UT;

[TestClass()]
public class ArrayExtensionsUnitTests
{
    [TestMethod()]
    public void PopulateTest()
    {
        var ti = new int[10_000_000];
        ti.Populate(3);
        for (var i = 0; i < ti.GetLength(0); i++)
            Assert.AreEqual(ti[i], 3);
        ti.Populate(7);
        for (var i = 0; i < ti.GetLength(0); i++)
            Assert.AreEqual(ti[i], 7);
    }

    [TestMethod()]
    public void PopulateParallelTest()
    {
        var ti = new int[10_000_000];
        ti.PopulateParallel(3);
        for (var i = 0; i < ti.GetLength(0); i++)
            Assert.AreEqual(ti[i], 3);
        ti.PopulateParallel(7);
        for (var i = 0; i < ti.GetLength(0); i++)
            Assert.AreEqual(ti[i], 7);
    }
}
