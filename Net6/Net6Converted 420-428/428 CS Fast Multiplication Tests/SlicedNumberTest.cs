// 2021-09-23   PV  VS2022; Net6


using CS428;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    /// <summary>
    ///This is a test class for SlicedNumberTest and is intended
    ///to contain all SlicedNumberTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SlicedNumberTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

        //
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion Additional test attributes

        /// <summary>
        ///A test for SlicedNumber Constructor
        ///</summary>
        [TestMethod()]
        public void SlicedNumberConstructorTest()
        {
            SlicedNumber target = new("1");
            Assert.IsTrue(target.nslices == 1);
            Assert.IsTrue(target.slices[0] == 1);
            Assert.IsTrue(target.sign == 1);

            target = new SlicedNumber("123456789");
            Assert.IsTrue(target.nslices == 1);
            Assert.IsTrue(target.slices[0] == 123456789);
            Assert.IsTrue(target.sign == 1);

            target = new SlicedNumber("-123456789");
            Assert.IsTrue(target.nslices == 1);
            Assert.IsTrue(target.slices[0] == 123456789);
            Assert.IsTrue(target.sign == -1);

            target = new SlicedNumber("12345987654321123456789");
            Assert.IsTrue(target.nslices == 3);
            Assert.IsTrue(target.slices[0] == 123456789);
            Assert.IsTrue(target.slices[1] == 987654321);
            Assert.IsTrue(target.slices[2] == 12345);
            Assert.IsTrue(target.sign == 1);

            target = new SlicedNumber("-12345987654321123456789");
            Assert.IsTrue(target.nslices == 3);
            Assert.IsTrue(target.slices[0] == 123456789);
            Assert.IsTrue(target.slices[1] == 987654321);
            Assert.IsTrue(target.slices[2] == 12345);
            Assert.IsTrue(target.sign == -1);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            string s = "1";
            SlicedNumber target = new(s);
            Assert.AreEqual(s, target.ToString());

            s = "-1";
            target = new SlicedNumber(s);
            Assert.AreEqual(s, target.ToString());

            s = "12345987654321123456789";
            target = new SlicedNumber(s);
            Assert.AreEqual(s, target.ToString());

            s = "-12345987654321123456789";
            target = new SlicedNumber(s);
            Assert.AreEqual(s, target.ToString());
        }

        /// <summary>
        ///A test for NormalizeSlices
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CS428.exe")]
        public void NormalizeSlicesTest()
        {
            SlicedNumber target = new("123");
            target.NormalizeSlices();
            Assert.IsTrue(target.nslices == 1);
            Assert.IsTrue(target.slices[0] == 123);

            target.nslices = 2;
            target.slices = new long[2] { 123456789012, 1000 };
            target.NormalizeSlices();
            Assert.IsTrue(target.nslices == 2);
            Assert.IsTrue(target.slices[0] == 456789012);
            Assert.IsTrue(target.slices[1] == 1123);

            target.nslices = 1;
            target.slices = new long[1] { 123456789012 };
            target.NormalizeSlices();
            Assert.IsTrue(target.nslices == 2);
            Assert.IsTrue(target.slices[0] == 456789012);
            Assert.IsTrue(target.slices[1] == 123);

            target.nslices = 3;
            target.slices = new long[3] { -1000, 1000, 1 };
            target.NormalizeSlices();
            Assert.IsTrue(target.nslices == 3);
            Assert.IsTrue(target.slices[0] == 999999000);
            Assert.IsTrue(target.slices[1] == 999);
            Assert.IsTrue(target.slices[2] == 1);

            target.nslices = 3;
            target.slices = new long[3] { 1000, -1000, 1 };
            target.NormalizeSlices();
            Assert.IsTrue(target.nslices == 3);
            Assert.IsTrue(target.slices[0] == 1000);
            Assert.IsTrue(target.slices[1] == 999999000);
            Assert.IsTrue(target.slices[2] == 0);               // Non-significant 0, normal, NormalizeSlices doesn't trim
        }

        /// <summary>
        ///A test for TrimNonSignificantZeroes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CS428.exe")]
        public void TrimNonSignificantZeroesTest()
        {
            SlicedNumber target = new("123");
            target.TrimNonSignificantZeroes();
            Assert.IsTrue(target.nslices == 1);
            Assert.IsTrue(target.slices[0] == 123);

            // Special trimming case, just zero
            target.nslices = 1;
            target.slices = new long[1] { 0 };
            target.TrimNonSignificantZeroes();
            Assert.IsTrue(target.nslices == 1);
            Assert.IsTrue(target.slices[0] == 0);

            target.nslices = 2;
            target.slices = new long[2] { 123456, 0 };
            target.TrimNonSignificantZeroes();
            Assert.IsTrue(target.nslices == 1);
            Assert.IsTrue(target.slices[0] == 123456);
        }

        /// <summary>
        ///A test for MultSchool
        ///</summary>
        [TestMethod()]
        public void MultSchoolTest()
        {
            SlicedNumber n1 = new("8");
            SlicedNumber n2 = new("7");
            SlicedNumber expected = new("56");
            SlicedNumber actual;
            actual = SlicedNumber.MultSchool(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());

            n1 = new SlicedNumber("8000000004");
            n2 = new SlicedNumber("-7000000005");
            expected = new SlicedNumber("-56000000068000000020");
            actual = SlicedNumber.MultSchool(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());

            n1 = new SlicedNumber("-80770718247897006173513947002002154732581700703182");
            n2 = new SlicedNumber("-54379677336052447322745818122339104693580691211762");
            expected = new SlicedNumber("4392285596521842664204447462793927399439941228673302731866248928788747971650372307077123563069226684");
            actual = SlicedNumber.MultSchool(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        /// <summary>
        ///A test for SplitInTwo
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CS428.exe")]
        public void SplitInTwoTest()
        {
            SlicedNumber n = new("12345123456789");
            SlicedNumber.SplitInTwo(n, 1, out SlicedNumber a, out SlicedNumber b);
            Assert.AreEqual(new SlicedNumber("123456789").ToString(), a.ToString());
            Assert.AreEqual(new SlicedNumber("12345").ToString(), b.ToString());
        }

        /// <summary>
        ///A test for AbsCompare
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CS428.exe")]
        public void AbsCompareTest()
        {
            SlicedNumber n1 = new("8");
            SlicedNumber n2 = new("7");
            Assert.AreEqual(SlicedNumber.AbsCompare(n1, n2), 1);

            n1 = new SlicedNumber("1234567890");
            n2 = new SlicedNumber("123456789");
            Assert.AreEqual(SlicedNumber.AbsCompare(n1, n2), 1);

            n1 = new SlicedNumber("80770718247897006173513947002002154732581700703182");
            n2 = new SlicedNumber("80770718247897006173513947002002154732581700703183");
            Assert.AreEqual(SlicedNumber.AbsCompare(n1, n2), -1);

            n1 = new SlicedNumber("80770718247897006173513947002002154732581700703182");
            n2 = new SlicedNumber("80770718247897006173513947002002154732581700703182");
            Assert.AreEqual(SlicedNumber.AbsCompare(n1, n2), 0);
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            SlicedNumber n1 = new("8");
            SlicedNumber n2 = new("7");
            SlicedNumber expected = new("15");
            SlicedNumber actual;
            actual = SlicedNumber.Add(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());

            n1 = new SlicedNumber("8000000004");
            n2 = new SlicedNumber("-7000000005");
            expected = new SlicedNumber("999999999");
            actual = SlicedNumber.Add(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());

            n1 = new SlicedNumber("-8000000004");
            n2 = new SlicedNumber("7000000005");
            expected = new SlicedNumber("-999999999");
            actual = SlicedNumber.Add(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        /// <summary>
        ///A test for Subtract
        ///</summary>
        [TestMethod()]
        public void SubtractTest()
        {
            SlicedNumber n1 = new("8");
            SlicedNumber n2 = new("7");
            SlicedNumber expected = new("1");
            SlicedNumber actual;
            actual = SlicedNumber.Subtract(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());

            n1 = new SlicedNumber("-8000000004");
            n2 = new SlicedNumber("-7000000005");
            expected = new SlicedNumber("-999999999");
            actual = SlicedNumber.Subtract(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());

            n1 = new SlicedNumber("8000000004");
            n2 = new SlicedNumber("-7000000005");
            expected = new SlicedNumber("15000000009");
            actual = SlicedNumber.Subtract(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        /// <summary>
        ///A test for FastMult
        ///</summary>
        [TestMethod()]
        public void FastMultTest()
        {
            SlicedNumber n1 = new("8");
            SlicedNumber n2 = new("7");
            SlicedNumber expected = new("56");
            SlicedNumber actual;
            actual = SlicedNumber.FastMult(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());

            n1 = new SlicedNumber("8000000004");
            n2 = new SlicedNumber("7000000005");
            expected = new SlicedNumber("56000000068000000020");
            actual = SlicedNumber.FastMult(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());

            n1 = new SlicedNumber("4000000002000000001");
            n2 = new SlicedNumber("9000000006000000003");
            expected = new SlicedNumber("36000000042000000033000000012000000003");
            actual = SlicedNumber.FastMult(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());

            n1 = new SlicedNumber("8077071824");
            n2 = new SlicedNumber("5437967733");
            expected = new SlicedNumber("43922855956035454992");
            actual = SlicedNumber.FastMult(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());

            n1 = new SlicedNumber("80770718247897006173513947002002154732581700703182");
            n2 = new SlicedNumber("54379677336052447322745818122339104693580691211762");
            expected = new SlicedNumber("4392285596521842664204447462793927399439941228673302731866248928788747971650372307077123563069226684");
            actual = SlicedNumber.FastMult(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());

            n1 = new SlicedNumber("54379677336052447322745818122339104693580691211762");
            n2 = new SlicedNumber("-1");
            expected = new SlicedNumber("-54379677336052447322745818122339104693580691211762");
            actual = SlicedNumber.FastMult(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());

            n1 = new SlicedNumber("54379677336052447322745818122339104693580691211762");
            n2 = new SlicedNumber("0");
            expected = new SlicedNumber("0");
            actual = SlicedNumber.FastMult(n1, n2);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}