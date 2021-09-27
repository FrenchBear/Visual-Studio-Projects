' 240 VB Lift
'
' 2012-02-25	PV  VS2010
' 2021-09-20    PV  VS2022; Net6

Public Class ucFloorButtons

    Public Event FloorRequestUp(ucfb As ucFloorButtons)

    Public Event FloorRequestDown(ucfb As ucFloorButtons)

    Private Sub UpButton_Click(sender As System.Object, e As EventArgs) Handles UpButton.Click
        RaiseEvent FloorRequestUp(Me)
    End Sub

    Private Sub DownButton_Click(sender As System.Object, e As EventArgs) Handles DownButton.Click
        RaiseEvent FloorRequestDown(Me)
    End Sub

    Public Property FloorLabel() As String
        Get
            Return lblFloorLabel.Text
        End Get
        Set(value As String)
            lblFloorLabel.Text = value
        End Set
    End Property

    Public Property CallStatusUp() As Boolean
        Get
            Return UpButton.BackColor <> System.Drawing.SystemColors.Control
        End Get
        Set(value As Boolean)
            UpButton.BackColor = IIf(value, Color.Lime, System.Drawing.SystemColors.Control)
        End Set
    End Property

    Public Property CallStatusDown() As Boolean
        Get
            Return DownButton.BackColor <> System.Drawing.SystemColors.Control
        End Get
        Set(value As Boolean)
            DownButton.BackColor = IIf(value, Color.Lime, System.Drawing.SystemColors.Control)
        End Set
    End Property

End Class