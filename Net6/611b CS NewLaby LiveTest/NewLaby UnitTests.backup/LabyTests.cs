using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewLaby.Tests
{
    [TestClass()]
    public class LabyTests
    {
        [TestMethod()]
        public void LabyTest()
        {
            var l = new NewLaby.Laby(10, 20);
            Assert.IsNotNull(l);
            //Program.MethodToTest();
        }
    }
}