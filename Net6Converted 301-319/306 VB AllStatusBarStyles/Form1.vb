' 306 VB AllStatusBarStyles
'
' 2012-02-25	PV  VS2010
' 2021-09-20    PV  VS2022; Net6

Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As EventArgs) Handles MyBase.Load
        'Application.RenderWithVisualStyles
        'Application.VisualStyleState = VisualStyles.VisualStyleState.NoneEnabled
        'Application.EnableVisualStyles()
        'Application.SetCompatibleTextRenderingDefault(False)

        Dim tStyles As Border3DStyle() = New Border3DStyle() {Border3DStyle.Bump, Border3DStyle.Etched, Border3DStyle.Flat, Border3DStyle.Raised, Border3DStyle.RaisedInner, Border3DStyle.RaisedOuter, Border3DStyle.Sunken, Border3DStyle.SunkenInner, Border3DStyle.SunkenOuter}
        Dim tSides As ToolStripStatusLabelBorderSides() = New ToolStripStatusLabelBorderSides() {ToolStripStatusLabelBorderSides.None, ToolStripStatusLabelBorderSides.All, ToolStripStatusLabelBorderSides.Top Or ToolStripStatusLabelBorderSides.Left, ToolStripStatusLabelBorderSides.Bottom Or ToolStripStatusLabelBorderSides.Right}
        For Each s As Border3DStyle In tStyles
            Dim tssl As ToolStripStatusLabel
            tssl = StatusStrip1.Items.Add(s.ToString)
            tssl.BorderSides = tSides(0)
            tssl.BorderStyle = s
            tssl = StatusStrip2.Items.Add(s.ToString)
            tssl.BorderSides = tSides(1)
            tssl.BorderStyle = s
            tssl = StatusStrip3.Items.Add(s.ToString)
            tssl.BorderSides = tSides(2)
            tssl.BorderStyle = s
            tssl = StatusStrip4.Items.Add(s.ToString)
            tssl.BorderSides = tSides(3)
            tssl.BorderStyle = s
        Next

    End Sub

End Class