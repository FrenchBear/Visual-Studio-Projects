// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewLaby;

[assembly: Parallelize]

namespace CS611LT;

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
