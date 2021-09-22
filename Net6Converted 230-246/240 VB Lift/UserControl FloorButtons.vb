' 240 VB Lift
'
' 2012-02-25	PV  VS2010
' 2021-09-20    PV  VS2022; Net6

Public Class ucFloorButtons

    Public Event FloorRequestUp(ucfb As ucFloorButtons)

    Public Event FloorRequestDown(ucfb As ucFloorButtons)

    Private Sub btnUp_Click(sender As System.Object, e As EventArgs) Handles btnUp.Click
        RaiseEvent FloorRequestUp(Me)
    End Sub

    Private Sub btnDown_Click(sender As System.Object, e As EventArgs) Handles btnDown.Click
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
            Return btnUp.BackColor <> System.Drawing.SystemColors.Control
        End Get
        Set(value As Boolean)
            btnUp.BackColor = IIf(value, Color.Lime, System.Drawing.SystemColors.Control)
        End Set
    End Property

    Public Property CallStatusDown() As Boolean
        Get
            Return btnDown.BackColor <> System.Drawing.SystemColors.Control
        End Get
        Set(value As Boolean)
            btnDown.BackColor = IIf(value, Color.Lime, System.Drawing.SystemColors.Control)
        End Set
    End Property

End Class