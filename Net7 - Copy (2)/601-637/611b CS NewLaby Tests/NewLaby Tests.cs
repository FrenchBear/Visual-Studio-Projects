// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewLaby.Tests;

[TestClass()]
public class LabyTests
{
    [TestMethod()]
    public void LabyTest()
    {
        var l = new Laby(10, 20, false);
        Assert.IsNotNull(l);
        //Program.MethodToTest();
    }
}
