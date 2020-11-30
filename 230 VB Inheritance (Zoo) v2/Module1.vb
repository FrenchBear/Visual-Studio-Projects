' 230 VB Inheritance (Zoo) v2
' 2012-02-25	PV  VS2010

Imports Microsoft.VisualBasic.CompilerServices

Module Module1

    Sub Main()
        Test1()

        Console.WriteLine()
        Console.Write("(Pause)")
        Console.ReadLine()
    End Sub

    Sub Test2()
        Dim Savane As New List(Of Animal) From {
            New Girafe("Lea"),
            New Lion("Mufasa"),
            New Lion("Sarabi"),
            New Lionceau("Simba")
        }

        Dim x As Animal
        For Each x In Savane
            Console.WriteLine(TypeName(x))
        Next

        Dim iez As IEnumerator(Of Animal)
        iez = Savane.GetEnumerator
        Do While iez.MoveNext
            iez.Current.Crier(1)
        Loop

        Dim z As IEnumerable(Of Animal)
        z = Savane
        For Each x In z
            Console.WriteLine(TypeName(x))
        Next
    End Sub

    Sub Test1()
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

Class Animal
    Public Name As String
    Public isMale As Boolean

    Sub New(newName As String)
        Name = newName
    End Sub

    Public Sub Dormir()
    End Sub

    Public Sub Manger()
    End Sub

    Public Overridable Sub Crier(iNb As Integer)
    End Sub

End Class

Class Girafe
    Inherits Animal

    Sub New(newName As String)
        MyBase.New(newName)
    End Sub

End Class

Class Lion
    Inherits Animal

    Sub New(newName As String)
        MyBase.New(newName)
    End Sub

    Public Overrides Sub Crier(iNb As Integer)
        For i As Integer = 1 To iNb
            Console.WriteLine("{0}: Roaaaar!", Name)
        Next
    End Sub

End Class

Class Lionceau
    Inherits Lion

    Sub New(newName As String)
        MyBase.New(newName)
    End Sub

    Public Overrides Sub Crier(iNb As Integer)
        For i As Integer = 1 To iNb
            Console.WriteLine("{0}: Miaooow!", Name)
        Next
    End Sub

End Class