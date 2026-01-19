// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using CS619;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize]

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
            Assert.AreEqual(3, ti[i]);
        ti.Populate(7);
        for (var i = 0; i < ti.GetLength(0); i++)
            Assert.AreEqual(7, ti[i]);
    }

    [TestMethod()]
    public void PopulateParallelTest()
    {
        var ti = new int[10_000_000];
        ti.PopulateParallel(3);
        for (var i = 0; i < ti.GetLength(0); i++)
            Assert.AreEqual(3, ti[i]);
        ti.PopulateParallel(7);
        for (var i = 0; i < ti.GetLength(0); i++)
            Assert.AreEqual(7, ti[i]);
    }
}
