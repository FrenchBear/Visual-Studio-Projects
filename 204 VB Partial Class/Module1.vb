' 2012-02-25	PV  VS2010

Module Module1

    Sub Main()
        Dim t As Toto = New Toto
        t.zap()
    End Sub

End Module


Partial Public Class Toto
    Public i1 As Integer
    Private j1 As Integer
    Sub s1()
    End Sub
    Event e1()
    Function f1() As Int64
    End Function
    ReadOnly Property pr1() As String
        Get
            Return Str(k)
        End Get
    End Property
End Class
