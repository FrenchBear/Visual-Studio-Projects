' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

#Disable Warning CA1822 ' Mark members as static

Public Class MainClass

    Public Function Main(sCommand As String) As Integer
        WriteLine("Here is MainClass.Main:" & vbCrLf & sCommand)
        Return 0
    End Function

End Class
