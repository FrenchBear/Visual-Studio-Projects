' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

#Disable Warning IDE0052 ' Remove unread private members
#Disable Warning IDE1006 ' Naming Styles
#Disable Warning CA1822 ' Mark members as static

Friend Module Module1
    Public Sub Main()
        Dim t As New Toto
        t.Zap()
    End Sub

End Module

Partial Public Class Toto
    Public i1 As Integer
    Private ReadOnly j1 As Integer

    Public Sub s1()
    End Sub

    Public Event e1()

    Public Function f1() As Long
        Return 0
    End Function

    Public ReadOnly Property pr1() As String
        Get
            Return Str(k)
        End Get
    End Property

End Class
