using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewLaby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewLaby.Tests
{
    [TestClass()]
    public class LabyTests
    {
        [TestMethod()]
        public void LabyTest()
        {
            var l = new NewLaby.Laby(10, 20, false);
            Assert.IsNotNull(l);
            //Program.MethodToTest();
        }
    }
}