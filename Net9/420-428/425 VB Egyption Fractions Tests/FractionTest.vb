' VB425TestProject - FractionTest
' Unit Tests for class Fraction
'
' 2012-04-09    PV
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports VB425

'''<summary>
'''This is a test class for FractionTest and is intended
'''to contain all FractionTest Unit Tests
'''</summary>
<TestClass()>
<CLSCompliant(False)>
Public Class FractionTest
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
    '''A test for Fraction Constructor
    '''</summary>
    <TestMethod()>
    Public Sub FractionConstructorTest()
        Dim target As New Fraction(7)
        Assert.AreEqual(target.Numerator, 7L)
        Assert.AreEqual(target.Denominator, 1L)
    End Sub

    '''<summary>
    '''A test for Fraction Constructor
    '''</summary>
    <TestMethod()>
    Public Sub FractionConstructorTest1()
        Dim target As New Fraction(7 * 43, 11 * 43)
        Assert.AreEqual(target.Numerator, 7L)
        Assert.AreEqual(target.Denominator, 11L)
    End Sub

    ' '''<summary>
    ' '''A test for Decompose
    ' '''</summary>
    '<TestMethod()> _
    'Public Sub DecomposeTest()
    '    Dim n As Long = 0 ' TODO: Initialize to an appropriate value
    '    Dim target As Fraction = New Fraction(n) ' TODO: Initialize to an appropriate value
    '    Dim expected As List(Of Fraction) = Nothing ' TODO: Initialize to an appropriate value
    '    Dim actual As List(Of Fraction)
    '    actual = target.Decompose
    '    Assert.AreEqual(expected, actual)
    '    Assert.Inconclusive("Verify the correctness of this test method.")
    'End Sub

    '''<summary>
    '''A test for ToString
    '''</summary>
    <TestMethod()>
    Public Sub ToStringTest()
        Dim target As IFormattable = New Fraction(7, 11)
        Dim expected As String = "7/11"
        Dim actual As String
        actual = target.ToString("G", Nothing)
        Assert.AreEqual(expected, actual)

        target = New Fraction(3, 4)
        Dim d As Double = 0.75
        expected = d.ToString("F")
        actual = target.ToString("F", Nothing)
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for ToString
    '''</summary>
    <TestMethod()>
    Public Sub ToStringTest1()
        Dim target As New Fraction(5, 13)
        Dim expected As String = "5/13"
        Dim actual As String
        actual = target.ToString
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for op_Addition
    '''</summary>
    <TestMethod()>
    Public Sub Op_AdditionTest()
        Dim f1 As New Fraction(1, 2)
        Dim f2 As New Fraction(3, 4)
        Dim expected As New Fraction(5, 4)
        Dim actual As Fraction
        actual = f1 + f2
        Assert.AreEqual(expected, actual)

        f2 = New Fraction(0, 5)
        expected = f1
        actual = f1 + f2
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for op_Subtraction
    '''</summary>
    <TestMethod()>
    Public Sub Op_SubtractionTest()
        Dim f1 As New Fraction(4, 3)
        Dim f2 As New Fraction(1, 2)
        Dim expected As New Fraction(5, 6)
        Dim actual As Fraction
        actual = f1 - f2
        Assert.AreEqual(expected, actual)

        f2 = New Fraction(0, 5)
        expected = f1
        actual = f1 - f2
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for both Numerator and Denominator
    '''</summary>
    <TestMethod()>
    Public Sub NumeratorAndDenominatorTest()
        Dim target As New Fraction(7, 11)
        Assert.AreEqual(target.Numerator, 7L)
        Assert.AreEqual(target.Denominator, 11L)
    End Sub

    '''<summary>
    '''A test for op_Equality and op_Inequality
    '''</summary>
    <TestMethod()>
    Public Sub Op_EqualityTest()
        Dim f1 As New Fraction(7, 11)
        Dim f2 As New Fraction(14, 22)
        Assert.AreEqual(True, f1 = f2)
        Assert.AreEqual(False, f1 <> f2)

        f2 = New Fraction(1, 5)
        Assert.AreEqual(False, f1 = f2)
        Assert.AreEqual(True, f1 <> f2)

        f1 = New Fraction(0, 5)
        f2 = New Fraction(0, 7)
        Assert.AreEqual(True, f1 = f2)
        Assert.AreEqual(False, f1 <> f2)
    End Sub
End Class
