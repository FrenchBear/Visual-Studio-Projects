' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022; Net6
' 2023-01-10	PV		Net7

Class Form2
    Inherits Form

    Public Sub New2()
        ' Create a new ToolStrip control.
        Dim ts As New ToolStrip()

        ' Populate the ToolStrip control.
        ts.Items.Add("Apples")
        ts.Items.Add("Oranges")
        ts.Items.Add("Pears")
        ts.Items.Add("Change Colors", Nothing, New EventHandler(AddressOf ChangeColors_Click))

        ' Create a new MenuStrip.
        ' Dock the MenuStrip control to the top of the form.
        Dim ms As New MenuStrip With {
            .Dock = DockStyle.Top
        }

        ' Add the top-level menu items.
        ms.Items.Add("File")
        ms.Items.Add("Edit")
        ms.Items.Add("View")
        ms.Items.Add("Window")

        ' Add the ToolStrip to Controls collection.
        Me.Controls.Add(ts)

        ' Add the MenuStrip control last.
        ' This is important for correct placement in the z-order.
        Me.Controls.Add(ms)
    End Sub

    ' This event handler is invoked when the "Change colors"
    ' ToolStripItem is clicked. It assigns the Renderer
    ' property for the ToolStrip control.
    Sub ChangeColors_Click(sender As Object, e As EventArgs)
        'ToolStripManager.Renderer = New ToolStripProfessionalRenderer(New CustomProfessionalColors())
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        New2()
    End Sub

End Class
