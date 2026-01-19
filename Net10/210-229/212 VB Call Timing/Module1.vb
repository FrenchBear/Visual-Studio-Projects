' 212 VB Call Timing
'
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10
Imports System.Timers

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning CA1822 ' Mark members as static

Friend Module Module1
    Private WithEvents t As Timer
    Private bStop As Boolean
    Private sGlobalRes As String

    Public Sub LocalMachin()
    End Sub

    Public Sub Main()
        Dim c As Long

        Dim k1 As MaClasse
        k1 = New MaClasse
        c = 0
        t = New Timer With {
            .AutoReset = False,
            .Interval = 1000,
            .Enabled = True
        }
        Do
            LocalMachin()
            c += 1
        Loop Until bStop
        AddRes("Direct local call", c)

        bStop = False : c = 0 : t.Enabled = True
        Do
            k1.Machin()
            c += 1
        Loop Until bStop
        AddRes("Early binding, direct call, simple object", c)

        Dim k2 As New MaClasse
        bStop = False : c = 0 : t.Enabled = True
        Do
            k2.Machin()
            c += 1
        Loop Until bStop
        AddRes("Early binding, direct call, object declared with new", c)

        Dim k3 As Object = New MaClasse
        bStop = False : c = 0 : t.Enabled = True
        Do
            k3.Machin()
            c += 1
        Loop Until bStop
        AddRes("Late binding", c)

        bStop = False : c = 0 : t.Enabled = True
        Do
            CallByName(k3, "Machin", CallType.Method)
            c += 1
        Loop Until bStop
        AddRes("CallByName", c)

        bStop = False : c = 0 : t.Enabled = True
        Dim sSwitch As String = "Choice10"
        Do
            Select Case sSwitch
                Case "Choice1" : LocalMachin()
                Case "Choice2" : LocalMachin()
                Case "Choice3" : LocalMachin()
                Case "Choice4" : LocalMachin()
                Case "Choice5" : LocalMachin()
                Case "Choice6" : LocalMachin()
                Case "Choice7" : LocalMachin()
                Case "Choice8" : LocalMachin()
                Case "Choice9" : LocalMachin()
                Case "Choice10" : LocalMachin()
            End Select
            c += 1
        Loop Until bStop
        AddRes("Call (Early binding) with Select Case (5th Match)", c)

        Dim k4 As MaClasse = New MaClasse3
        bStop = False : c = 0 : t.Enabled = True
        Do
            k4.Virtual()
            c += 1
        Loop Until bStop
        AddRes("Virtual function call", c)

        Dim k5 As New MaClasse3
        bStop = False : c = 0 : t.Enabled = True
        Do
            k5.Virtual()
            c += 1
        Loop Until bStop
        AddRes("Virtual function call in a NotInheritable class", c)

        bStop = False : c = 0 : t.Enabled = True
        Do
            MaClasse.TrucShared()
            c += 1
        Loop Until bStop
        AddRes("Shared member function call", c)

        MsgBox(sGlobalRes)
    End Sub

    Private Sub t_Elapsed(sender As Object, e As ElapsedEventArgs) Handles t.Elapsed
        bStop = True
    End Sub

    Public Sub AddRes(sMsg As String, nb As Long)
        sGlobalRes &= sMsg & ": " & Format(nb, "#,##0") & vbCrLf
    End Sub

End Module

Friend Class MaClasse
    Public Sub Machin()
    End Sub

    Public Shared Sub TrucShared()
    End Sub

    Public Overridable Sub Virtual()
    End Sub

End Class

Friend Class MaClasse2 : Inherits MaClasse

    Public Overrides Sub Virtual()
    End Sub

End Class

Friend NotInheritable Class MaClasse3 : Inherits MaClasse2

    Public Overrides Sub Virtual()
    End Sub

End Class
