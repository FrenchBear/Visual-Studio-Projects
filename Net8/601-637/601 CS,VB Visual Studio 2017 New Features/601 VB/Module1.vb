' VB601 VB Visual Studio 2017 New Features
' Trying to replicate new C# features in VB
' 2017-01-17    PV      Not much is supported except ValueTuples (without deconstruction) and &B binary prefix
'                       Digits separators _ are sometimes automatically removed in code (ex: AvogadroConstant)
'                       Throw expressions are not supported
'                       Functions retuning reference not supported, local refs neither
'                       Pattern matching not supported
' 2021-09-26    PV      VS2022; Net6
' 2023-01-10	PV		Net7

Imports System.Console
Imports System.Runtime.CompilerServices
Imports System.Text

#Disable Warning IDE0059 ' Unnecessary assignment of a value

Module VB601
    ' Throw expressions not supported in VB
    'Private GlobalPoint As Point = If(New Point(5, 6), Throw New InvalidOperationException("Could not initialize " + NameOf(GlobalPoint)))

    Sub Main()
        OutputEncoding = New UTF8Encoding()
        WriteLine("Tests en VB 2017" + vbCrLf)

        Dim t1 = (r:=3.14, i:=-2.5)
        Dim t2 = (r:=2.718, j:=1.414)
        t1 = t2         ' This Is allowed, contrary To tuples created With Tuple<>
        WriteLine("t1: " + t1.ToString())
        t1.r += 1.0     ' mutable...
        Dim NamedStrings As (Alpha As String, Beta As String) = ("Hello", "World")

        ' Following conversions are Not supported...
        'Tuple(Of Integer, Integer) myTuple1 = (3, 4)
        'Tuple(Of Integer, Integer) myTuple2 = (Tuple(Of Integer, Integer))(3, 4)
        Dim myTuple3 As Tuple(Of Integer, Integer) = (3, 4).Construct()      ' An extension method can be used

        ' Actually, real type is ValueTuple
        Dim myValueTuple1 As ValueTuple(Of Integer, Integer) = (2, 7)
#Disable Warning BC41009
        Dim myValueTuple2 As ValueTuple(Of Integer, Integer) = (once:=2, upon:=7)
#Enable Warning BC41009
        ' Convoluted method to make a tuple enumerable, just to do it
        Dim t9 = ("once", "upon", "a", "time", "in", "a", "far", "away", "kingdom")
        For Each item As String In t9.GetT9Enumerator()
            Write(item + " ")
        Next
        WriteLine()

        ' Binary litterals and digit separators
        Dim numbers As Object() =
                {&B1, &B10, New Object() {&B100, &B1000},       ' binary literals
                  "Tally_Test", &B10_000, &B100_000}            ' digit separators
        Const AvogadroConstant As Double = 6.0221408577474741E+23   ' Automatically remove _ separators
        Const φ As Decimal = 1.6180339887498948482045868344D        ' Same
        Const Ø As Long = 123_456_789                          ' Ok, keep _ in integers
        WriteLine($"Avogadro: {AvogadroConstant}")
        WriteLine($"φ: {φ}")
        WriteLine($"Ø: {Ø}")

        ' Deconstruction
        Dim sum As Integer, count As Integer
        Tally(numbers).Deconstruct(sum, count)                  ' Tuple deconstruction via an extension method
        WriteLine($"Sum: {sum}, Count: {count}")
        ' Deconstruction using a tuple with named members
        Dim ttt As (sum As Integer, count As Integer) = Tally(numbers)
        WriteLine($"Sum: {ttt.sum}, Count: {ttt.count}")

        Dim p = New Point(3.14, 2.71)
        Dim X, Y As Double
        p.Deconstruct(X, Y)                           ' Class supporting a Deconstruct method
        WriteLine($"X={X}, Y={Y}")
        Dim t78 As New Tuple(Of Integer, Integer)(7, 8)
        Dim Z, T As Integer
        t78.Deconstruct(Z, T)                               ' Deconstruction using extension method
        WriteLine($"Z={Z}, T={T}")

        ' Function returning a reference (but intellisense does not show it)
        Dim s1 As String = "Hello"
        Dim s2 As String = "World"
        'Choose(True, s1, s2) = "Modified"          ' Do not work in VB
        WriteLine($"s1:{s1}, s2:{s2}")

        '' Local ref, does not work in VB
        'ref String rs = ref s2
        'rs = "String"
        'WriteLine($"After modifying rs, s2:{s2}")

        WriteLine()
        'TestPatternMatching()

        '' Out variables declared in method call
        'If Double.TryParse("3,1416", byref dval as double) Then
        '    WriteLine($"dval={dval}")
        'Else
        '    WriteLine("double.TryParse failed")
        'End If
    End Sub

    ' Pattern matching is not supported
    Function Tally(values As Object()) As (sum As Integer, count As Integer)        ' tuple types
        Dim r = (s:=0, c:=0)                                                        ' tuple literals
        For Each v In values
            If TypeOf v Is Integer Then
                Add(r, v, 1)
            ElseIf TypeOf v Is String Then                                          ' Just a stupid test
                WriteLine(CType(v, String))
            ElseIf TypeOf v Is Object() AndAlso CType(v, Object()).Length > 0 Then  ' case conditions
                Dim t = Tally(CType(v, Object()))
                Add(r, t.sum, t.count)
            Else
                Throw New InvalidOperationException("unknown item type")
            End If
        Next
        Return r
    End Function

    ' No local functions in VB
    Private Sub Add(ByRef r As (Integer, Integer), s As Integer, c As Integer)
        r.Item1 += s
        r.Item2 += c
    End Sub

    ' function returning a reference, does not work in VB...
    Public Function Choose(Of TValue)(condition As Boolean, ByRef left As TValue, ByRef right As TValue) As TValue
        If condition Then Return left
        Return right
    End Function

End Module

' Example of class supporting Tuple deconstruction
Public Class Point
    Public Property X As Double
    Public Property Y As Double

    Public Sub New(x As Double, y As Double)
        Me.X = x
        Me.Y = y
    End Sub

    ' Deconstruct method provides a set of out arguments for each of the properties you want to extract
    Public Sub Deconstruct(ByRef x As Double, ByRef y As Double)
        x = Me.X
        y = Me.Y
    End Sub

End Class

Module ExtensionMethods

    <Extension()>
    Public Sub Deconstruct(t As Tuple(Of Integer, Integer), ByRef Left As Integer, ByRef Right As Integer)
        Left = t.Item1
        Right = t.Item2
    End Sub

    <Extension()>
    Public Sub Deconstruct(t As ValueTuple(Of Integer, Integer), ByRef Left As Integer, ByRef Right As Integer)
        Left = t.Item1
        Right = t.Item2
    End Sub

    ' Also show expression-bodied member
    <Extension()>
    Public Function Construct(pair As (x As Integer, y As Integer)) As Tuple(Of Integer, Integer)
        Return New Tuple(Of Integer, Integer)(pair.x, pair.y)
    End Function

    ' Idem
    <Extension()>
    Public Function GetT9Enumerator(Of T)(bigTuple As (s1 As T, s2 As T, s3 As T, s4 As T, s5 As T, s6 As T, s7 As T, s8 As T, s9 As T)) As T9Enumerator(Of T)
        Return New T9Enumerator(Of T)(bigTuple)
    End Function

End Module

Public Class T9Enumerator(Of T) : Implements IEnumerable(Of T)
    Dim localTuple As (s1 As T, s2 As T, s3 As T, s4 As T, s5 As T, s6 As T, s7 As T, s8 As T, s9 As T)

    Public Sub New(bigTuple As (s1 As T, s2 As T, s3 As T, s4 As T, s5 As T, s6 As T, s7 As T, s8 As T, s9 As T))
        localTuple = bigTuple
    End Sub

    Private Iterator Function MyEnumerator() As IEnumerator(Of T)
        Yield localTuple.s1
        Yield localTuple.s2
        Yield localTuple.s3
        Yield localTuple.s4
        Yield localTuple.s5
        Yield localTuple.s6
        Yield localTuple.s7
        Yield localTuple.s8
        Yield localTuple.s9
        Return
    End Function

    Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
        Return MyEnumerator()
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return MyEnumerator()
    End Function

End Class
