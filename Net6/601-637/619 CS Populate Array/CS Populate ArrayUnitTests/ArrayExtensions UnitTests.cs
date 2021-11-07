// 2021-09-26   PV      VS2022; Net6

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CS_Populate_Array.Unit_Tests;

[TestClass()]
public class ArrayExtensionsUnitTests
{
    [TestMethod()]
    public void PopulateTest()
    {
        var ti = new int[10_000_000];
        ti.Populate(3);
        for (int i = 0; i < ti.GetLength(0); i++)
            Assert.AreEqual<int>(ti[i], 3);
        ti.Populate(7);
        for (int i = 0; i < ti.GetLength(0); i++)
            Assert.AreEqual<int>(ti[i], 7);
    }

    [TestMethod()]
    public void PopulateParallelTest()
    {
        var ti = new int[10_000_000];
        ti.PopulateParallel(3);
        for (int i = 0; i < ti.GetLength(0); i++)
            Assert.AreEqual<int>(ti[i], 3);
        ti.PopulateParallel(7);
        for (int i = 0; i < ti.GetLength(0); i++)
            Assert.AreEqual<int>(ti[i], 7);
    }
}