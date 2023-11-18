' Partial Methods
'
' 2008-08-21    PV
' 2012-02-25 	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6; MsgBox -> Console.WriteLine
' 2023-01-10	PV		Net7

#Disable Warning CA1822 ' Mark members as static


Module Module1

    Sub Main()
        Dim c = New TestClass
        Stop
    End Sub

End Module

Class TestClass

    Partial Private Sub Toto(ByRef x As Integer)
    End Sub

    Private Sub Toto(ByRef x As Integer)
        WriteLine("Hello World " & CStr(x))
        x += 1
    End Sub

    Sub New()
        Dim a = 2
        Toto(a)
        WriteLine("a: " & a)
    End Sub

End Class
