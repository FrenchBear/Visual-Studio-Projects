' 230 VB Inheritance (Zoo) v2
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports Microsoft.VisualBasic.CompilerServices

#Disable Warning CA1822 ' Mark members as static
#Disable Warning CA1861 ' Avoid constant arrays as arguments

Friend Module Module1
    Public Sub Main()
        Test1()
    End Sub

    Public Sub Test2()
        Dim Savane As New List(Of Animal) From {
            New Girafe("Lea"),
            New Lion("Mufasa"),
            New Lion("Sarabi"),
            New Lionceau("Simba")
        }

        Dim x As Animal
        For Each x In Savane
            WriteLine(TypeName(x))
        Next

        Dim iez As List(Of Animal).Enumerator  ' IEnumerator(Of Animal)
        iez = Savane.GetEnumerator
        Do While iez.MoveNext
            iez.Current.Crier(1)
        Loop

        Dim z As IEnumerable(Of Animal)
        z = Savane
        For Each x In z
            WriteLine(TypeName(x))
        Next
    End Sub

    Public Sub Test1()
        Dim l As Lion = New Lionceau("Simba")
        l.Crier(1)

        Dim MethodName As String = "Crier"
        Dim MethodArgList As New List(Of Object) From {
            "iNb"
        }

        Dim MethodArgs As Object() = MethodArgList.ToArray()

        'Dim Result = NewLateBinding.LateCall(l, Nothing, MethodName, New Object() {1}, New String() {"iNb"}, New System.Type() {1.GetType}, New Boolean() {False}, True)
        Dim Result = NewLateBinding.LateCall(l, Nothing, MethodName, New Object() {1}, New String() {"iNb"}, Nothing, New Boolean() {False}, True)
    End Sub

End Module

Friend Class Animal
    Public Name As String
    Public isMale As Boolean

    Public Sub New(newName As String)
        Name = newName
    End Sub

    Public Sub Dormir()
    End Sub

    Public Sub Manger()
    End Sub

    Public Overridable Sub Crier(iNb As Integer)
    End Sub

End Class

Friend Class Girafe
    Inherits Animal

    Public Sub New(newName As String)
        MyBase.New(newName)
    End Sub

End Class

Friend Class Lion
    Inherits Animal

    Public Sub New(newName As String)
        MyBase.New(newName)
    End Sub

    Public Overrides Sub Crier(iNb As Integer)
        For i As Integer = 1 To iNb
            WriteLine("{0}: Roaaaar!", Name)
        Next
    End Sub

End Class

Friend Class Lionceau
    Inherits Lion

    Public Sub New(newName As String)
        MyBase.New(newName)
    End Sub

    Public Overrides Sub Crier(iNb As Integer)
        For i As Integer = 1 To iNb
            WriteLine("{0}: Miaooow!", Name)
        Next
    End Sub

End Class
