' 308 VB Splitter.Net
' 2012-02-25	PV  VS2010

Option Strict Off
Option Explicit On

#Disable Warning IDE0059 ' Unnecessary assignment of a value
#Disable Warning IDE1006 ' Naming Styles

Friend Class Form1
    Inherits Form

    Private mbMoving As Boolean
    Private y0 As Integer

    Private Sub imgSplitter_MouseDown(eventSender As System.Object, eventArgs As MouseEventArgs) Handles imgSplitter.MouseDown
        With imgSplitter
            picSplitter.SetBounds(.Left, .Top, .Width, .Height)
        End With
        picSplitter.Visible = True
        y0 = eventArgs.Y
        mbMoving = True
    End Sub

    Private Sub imgSplitter_MouseMove(eventSender As System.Object, eventArgs As MouseEventArgs) Handles imgSplitter.MouseMove
        Dim iPos As Integer
        Dim iTableTop As Integer = 100
        Dim iSplitLimit As Integer = 10

        If mbMoving Then
            iPos = eventArgs.Y - y0 + imgSplitter.Top
            If iPos < iTableTop + iSplitLimit Then
                picSplitter.Top = iTableTop + iSplitLimit
            Else
                picSplitter.Top = iPos
            End If
        End If
    End Sub

    Private Sub imgSplitter_MouseUp(eventSender As System.Object, eventArgs As MouseEventArgs) Handles imgSplitter.MouseUp
        Dim iPos As Integer

        Dim iTableTop As Integer = 100
        Dim iSplitLimit As Integer = 10

        picSplitter.Visible = False
        mbMoving = False
        ' Do resizing
        iPos = eventArgs.Y - y0 + imgSplitter.Top
        If iPos < iTableTop + iSplitLimit Then iPos = iTableTop + iSplitLimit
        'ucTable.Height = 15 * ((sglPos - ucTableTop) \ 15)
        'Redisplay
    End Sub

End Class