' 212 VB Call Timing
' 2012-02-25	PV  VS2010

#Disable Warning IDE1006 ' Naming Styles

Module Module1
    Dim WithEvents t As Timers.Timer
    Dim bStop As Boolean
    Dim sGlobalRes As String

    Sub LocalMachin()
    End Sub

    Sub Main()
        Dim c As Long

        Dim k1 As MaClasse
        k1 = New MaClasse
        c = 0
        t = New Timers.Timer With {
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

        Dim k5 As MaClasse3 = New MaClasse3
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

    Private Sub t_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles t.Elapsed
        bStop = True
    End Sub

    Sub AddRes(sMsg As String, nb As Long)
        sGlobalRes &= sMsg & ": " & Format(nb, "#,##0") & vbCrLf
    End Sub

End Module

Class MaClasse

    Sub Machin()
    End Sub

    Shared Sub TrucShared()
    End Sub

    Overridable Sub Virtual()
    End Sub

End Class

Class MaClasse2 : Inherits MaClasse

    Public Overrides Sub Virtual()
    End Sub

End Class

NotInheritable Class MaClasse3 : Inherits MaClasse2

    Public Overrides Sub Virtual()
    End Sub

End Class