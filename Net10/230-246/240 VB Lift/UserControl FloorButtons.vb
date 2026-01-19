' 240 VB Lift
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Public Class FloorButtonsUserControl

    Public Event FloorRequestUp(ucfb As FloorButtonsUserControl)

    Public Event FloorRequestDown(ucfb As FloorButtonsUserControl)

    Private Sub UpButton_Click(sender As Object, e As EventArgs) Handles UpButton.Click
        RaiseEvent FloorRequestUp(Me)
    End Sub

    Private Sub DownButton_Click(sender As Object, e As EventArgs) Handles DownButton.Click
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
            Return UpButton.BackColor <> SystemColors.Control
        End Get
        Set(value As Boolean)
            UpButton.BackColor = IIf(value, Color.Lime, SystemColors.Control)
        End Set
    End Property

    Public Property CallStatusDown() As Boolean
        Get
            Return DownButton.BackColor <> SystemColors.Control
        End Get
        Set(value As Boolean)
            DownButton.BackColor = IIf(value, Color.Lime, SystemColors.Control)
        End Set
    End Property

End Class
