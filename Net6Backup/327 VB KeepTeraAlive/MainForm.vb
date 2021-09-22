' KeepTeraAlive
' Small program to ping network drives on a regular basis
'
' 2009-09-30    PV
' 2012-02-25	PV  VS2010

Option Compare Text

Public Class MainForm

    Private colDrives As New Collection

    Private Sub Form1_Load(sender As System.Object, e As EventArgs) Handles MyBase.Load
        DrivesTextBox.Text = My.Settings.Drives
        PeriodTextBox.Text = My.Settings.Period.ToString
    End Sub

    Private Sub StartStopButton_Click(sender As System.Object, e As EventArgs) Handles StartStopButton.Click
        If StartStopButton.Text = "Start" Then
            ActionStart()
        Else
            ActionStop()
        End If
    End Sub

    Private Sub ActionStart()
        If Not IsNumeric(PeriodTextBox.Text) OrElse (CSng(PeriodTextBox.Text) < 1 Or CSng(PeriodTextBox.Text) > 2000) Then
            MsgBox("La période doit être numérique, entre 1 et 2000.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        PingTimer.Interval = 1000 * CSng(PeriodTextBox.Text)

        colDrives = New Collection
        For Each s As String In DrivesTextBox.Text.Split(" ")
            If s.Length > 0 Then
                If s Like "[A-Z]:" Then
                    colDrives.Add(s)
                Else
                    MsgBox("Invalid drive " & s)
                    Exit Sub
                End If
            End If
        Next

        StartStopButton.Text = "Stop"
        DrivesTextBox.Enabled = False
        PeriodTextBox.Enabled = False
        PingAction()
        PingTimer.Enabled = True
    End Sub

    Private Sub ActionStop()
        PingTimer.Enabled = False
        StartStopButton.Text = "Start"
        DrivesTextBox.Enabled = True
        PeriodTextBox.Enabled = True
        StatusTextBox.AppendText(vbCrLf & "*** Stopped")
    End Sub

    Private Sub PingTimer_Tick(sender As System.Object, e As EventArgs) Handles PingTimer.Tick
        PingAction()
    End Sub

    Private Sub PingAction()
        StatusTextBox.Clear()
        StatusTextBox.AppendText(Now.ToString & vbCrLf)
        For Each sDrive As String In colDrives
            Try
                Dim n As Integer
                n = My.Computer.FileSystem.GetFiles(sDrive).Count
                StatusTextBox.AppendText(sDrive & " " & n.ToString & " file(s)" & vbCrLf)
            Catch ex As Exception
                StatusTextBox.AppendText(sDrive & " " & ex.Message & vbCrLf)
            End Try
        Next
    End Sub

End Class