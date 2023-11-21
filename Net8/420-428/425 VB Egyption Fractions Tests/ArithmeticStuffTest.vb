' VB425TestProject - FractionTest
' Unit Tests for module ArithmeticStuff
'
' 2012-04-09    PV
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports VB425

'''<summary>
'''This is a test class for ArithmeticStuffTest and is intended
'''to contain all ArithmeticStuffTest Unit Tests
'''</summary>
<TestClass()>
<CLSCompliant(False)>
Public Class ArithmeticStuffTest
    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext As TestContext

#Region "Additional test attributes"

    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '

#End Region

    '''<summary>
    '''A test for gcd
    '''</summary>
    <TestMethod()>
    Public Sub GcdTest()
        Dim a As Long = 7 * 43
        Dim b As Long = 13 * 43
        Dim expected As Long = 43
        Dim actual As Long
        actual = Gcd(a, b)
        Assert.AreEqual(expected, actual)

        a = 13 * 43
        b = 7 * 43
        actual = Gcd(a, b)
        Assert.AreEqual(expected, actual)

        a = 7
        b = 13
        expected = 1
        actual = Gcd(a, b)
        Assert.AreEqual(expected, actual)

        a = 13
        b = 7
        actual = Gcd(a, b)
        Assert.AreEqual(expected, actual)

        b = -13
        Try
            actual = Gcd(a, b)
            Assert.Fail("gcd was expected to thow an exception and did not")
        Catch ex As Exception
            Assert.IsTrue(TypeOf ex Is ArgumentException)
        End Try
    End Sub

    '''<summary>
    '''A test for scm
    '''</summary>
    <TestMethod()>
    Public Sub ScmTest()
        Dim a As Long = 7 * 43
        Dim b As Long = 13 * 43
        Dim expected As Long = 7 * 13 * 43
        Dim actual As Long
        actual = Scm(a, b)
        Assert.AreEqual(expected, actual)

        a = 7
        b = 13
        expected = 7 * 13
        actual = Scm(a, b)
        Assert.AreEqual(expected, actual)

        'a = 0
        'Try
        '    actual = ArithmeticStuff.scm(a, b)
        '    Assert.Fail("scm was expected to thow an exception and did not")
        'Catch ex As Exception
        '    Assert.IsTrue(TypeOf ex Is ArgumentException)
        'End Try
    End Sub
End Class
