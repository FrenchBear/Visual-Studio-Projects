' Essais de Boxing/Unboxing en VB
' 2001-01-27    PV
' 2001-08-15    PV  Beta2
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Imports System.Collections


#Disable Warning IDE0059 ' Unnecessary assignment of a value

Module Module1

    Sub Main()
        Dim o As Object
        Dim i As Integer

        o = 3
        i = CInt(o)
        Console.WriteLine("i = {0}", i)


        Dim p As New PileEntier()

        p.Empile(1)
        p.Empile(2)
        p.Empile(3)

        i = p.D�pile()
        i = p.D�pile()
        i = p.D�pile()

        Console.ReadLine()
    End Sub

End Module


Class PileEntier : Inherits Stack
    Public Sub Empile(ByVal i As Integer)
        MyBase.Push(i)
    End Sub

    Public Function D�pile() As Integer
        Return CInt(MyBase.Pop())
    End Function
End Class
