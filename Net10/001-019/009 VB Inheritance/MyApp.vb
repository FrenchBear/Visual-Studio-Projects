' 09 VB héritage
' Essais d'héritage de classes en VB
'
' 2001-10-27    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-17 	PV		VS2022/Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Friend Module Module1
    Public Sub Main()
        Dim d As New D()
        Console.ReadLine()
    End Sub

End Module

Friend Class B
    Public Sub New()
        WriteLine("B.ctor")
    End Sub

End Class

Friend Class D
    Inherits B

    Public Sub New()
        'MyBase.New()   'Inutile, appelé automatiquement
        WriteLine("D.ctor")
    End Sub

End Class
