' 240 VB Lift
' 2012-02-25	PV  VS2010

Public Class ucCarButtons
    Private ReadOnly m_iIndex As Integer

    Public ReadOnly Property iIndex() As Integer
        Get
            Return m_iIndex
        End Get
    End Property

    Public Event CarRequest(uccb As ucCarButtons, iFloor As Integer)

    Public Sub New(iIndex As Integer)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        m_iIndex = iIndex

        ' Add any initialization after the InitializeComponent() call.
        For i As Integer = 0 To NumberOfFloors - 1
            Dim cb As Button
            cb = New Button With {
                .BackColor = System.Drawing.SystemColors.Control,
                .Font = New Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)),
                .Location = New Point(3, 60 + 36 * i),
                .Name = "btn" & CStr(NumberOfFloors - 1 - i),
                .Size = New Size(42, 33),
                .Text = CStr(NumberOfFloors - 1 - i),
                .TextAlign = System.Drawing.ContentAlignment.TopCenter,
                .UseVisualStyleBackColor = False
            }

            Me.Controls.Add(cb)

            AddHandler cb.Click, AddressOf CarButton_Click
        Next
    End Sub

    Private Sub CarButton_Click(sender As System.Object, e As EventArgs)
        RaiseEvent CarRequest(Me, Val(CType(sender, Button).Text))
    End Sub

    Public Property sLabel() As String
        Get
            Return lblCar.Text
        End Get
        Set(value As String)
            lblCar.Text = value
        End Set
    End Property

    Public WriteOnly Property iDoorStatus() As Integer
        Set(value As Integer)
            Select Case value
                Case 0 : lblDoorStatus.Text = "Closed"
                Case 1 : lblDoorStatus.Text = "Closing"
                Case 2 : lblDoorStatus.Text = "Opening"
                Case 3 : lblDoorStatus.Text = "Open"
                Case Else : lblDoorStatus.Text = "? " & CStr(value)
            End Select
        End Set
    End Property

    Public WriteOnly Property sCarPosition() As String
        Set(value As String)
            lblCarPosition.Text = value
        End Set
    End Property

    Public WriteOnly Property iDirection() As Integer
        Set(value As Integer)
            Select Case value
                Case -1 : lblDirection.Text = "Down"
                Case 0 : lblDirection.Text = "-"
                Case 1 : lblDirection.Text = "Up"
                Case Else : lblDirection.Text = "? " & CStr(value)
            End Select
        End Set
    End Property

    Public Property bCallStatus(iFloor As Integer) As Boolean
        Get
            Return Me.Controls("btn" & CStr(iFloor)).BackColor <> System.Drawing.SystemColors.Control
        End Get
        Set(value As Boolean)
            Me.Controls("btn" & CStr(iFloor)).BackColor = IIf(value, Color.Lime, System.Drawing.SystemColors.Control)
        End Set
    End Property

End Class