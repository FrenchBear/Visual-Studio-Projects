// <copyright file="ProgramTest.cs">Copyright ©  2017</copyright>
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CS_Populate_Array.IntelliTests
{
    /// <summary>This class contains parameterized unit tests for Program</summary>
    [PexClass(typeof(Program))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ProgramTest
    {
        /// <summary>Test stub for InitializeArrayUsingSegments(!!0[], !!0)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        internal void InitializeArrayUsingSegmentsTest<T>(T[] array, T value)
        {
            var ti = new int[1000];
            Program.InitializeArrayUsingSegments<int>(ti, 3);
            // TODO: add assertions to method ProgramTest.InitializeArrayUsingSegmentsTest(!!0[], !!0)
            for (int i = 0; i < ti.GetLength(0); i++)
                Assert.AreEqual<int>(ti[i], 3);
        }
    }
}