// <copyright file="ProgramTest.cs">Copyright ©  2017</copyright>
using System;
using CS_Populate_Array;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CS_Populate_Array.Tests
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
            Program.InitializeArrayUsingSegments<T>(array, value);
            // TODO: add assertions to method ProgramTest.InitializeArrayUsingSegmentsTest(!!0[], !!0)
        }
    }
}
