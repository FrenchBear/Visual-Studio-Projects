' Essais de Boxing/Unboxing en VB
'
' 2001-01-27    PV
' 2001-08-15    PV  Beta2
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010
' 2021-09-18    PV  VS2022, Net6
' 2023-01-10	PV		Net7

#Disable Warning IDE0059 ' Unnecessary assignment of a value

Module Module1

    Sub Main()
        Dim o As Object
        Dim i As Integer

        o = 3
        i = CInt(o)
        WriteLine("i = {0}", i)

        Dim p As New PileEntier()

        p.Empile(1)
        p.Empile(2)
        p.Empile(3)

        i = p.Dépile()
        i = p.Dépile()
        i = p.Dépile()

        Console.ReadLine()
    End Sub

End Module

Class PileEntier : Inherits Stack

    Public Sub Empile(i As Integer)
        MyBase.Push(i)
    End Sub

    Public Function Dépile() As Integer
        Return CInt(MyBase.Pop())
    End Function

End Class
