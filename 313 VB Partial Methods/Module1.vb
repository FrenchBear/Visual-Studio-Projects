' Partial Methods
' 2008-08-21    PV
' 2012-02-25	PV  VS2010

Module Module1

    Sub Main()
        Dim c = New TestClass

    End Sub

End Module

Class TestClass

    Partial Private Sub Toto(ByRef x As Integer)
    End Sub

    Private Sub Toto(ByRef x As Integer)
        MsgBox("Hello World " & CStr(x))
        x += 1
    End Sub

    Sub New()
        Dim a = 2
        Toto(a)
        MsgBox("a: " & a)
    End Sub

End Class