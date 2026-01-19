' 209 VB Protected abuse
' Attempt to misuse protected... but doesn't work :-)
'
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Friend Module Module1
    Public Sub Main()
        Dim x As New C1
        CType(x, C2).Pp = 3         ' Can't cast to a more derived type of course!
    End Sub

    Public Class C2 : Inherits C1

        Public Property Pp() As Integer
            Get
                Return p
            End Get
            Set(value As Integer)
                p = value
            End Set
        End Property

    End Class

End Module

Friend Class C1
    Protected p As Integer
End Class
