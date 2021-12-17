' 2021-09-23    PV  VS2022; Net6

#Disable Warning CA1822 ' Mark members as static

Public Class MainClass

    Public Function Main(sCommand As String) As Integer
        WriteLine("Here is MainClass.Main:" & vbCrLf & sCommand)
        Return 0
    End Function

End Class