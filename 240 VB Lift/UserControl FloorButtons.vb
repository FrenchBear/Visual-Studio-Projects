' 240 VB Lift
' 2012-02-25	PV  VS2010

Public Class ucFloorButtons
    Public Event FloorRequestUp(ByVal ucfb As ucFloorButtons)
    Public Event FloorRequestDown(ByVal ucfb As ucFloorButtons)

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        RaiseEvent FloorRequestUp(Me)
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        RaiseEvent FloorRequestDown(Me)
    End Sub

    Public Property FloorLabel() As String
        Get
            Return lblFloorLabel.Text
        End Get
        Set(ByVal value As String)
            lblFloorLabel.Text = value
        End Set
    End Property

    Public Property CallStatusUp() As Boolean
        Get
            Return btnUp.BackColor <> System.Drawing.SystemColors.Control
        End Get
        Set(ByVal value As Boolean)
            btnUp.BackColor = IIf(value, Color.Lime, System.Drawing.SystemColors.Control)
        End Set
    End Property

    Public Property CallStatusDown() As Boolean
        Get
            Return btnDown.BackColor <> System.Drawing.SystemColors.Control
        End Get
        Set(ByVal value As Boolean)
            btnDown.BackColor = IIf(value, Color.Lime, System.Drawing.SystemColors.Control)
        End Set
    End Property

End Class
