' 54 VB Graphiques
' Essais de programmation en GDI+
' 2001-08-11    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text

Public Class frmPaint
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pic As System.Windows.Forms.PictureBox

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pic = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pic
        '
        Me.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic.Location = New System.Drawing.Point(184, 8)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(280, 184)
        Me.pic.TabIndex = 1
        Me.pic.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(192, 200)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'frmPaint
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pic, Me.Button1})
        Me.Name = "frmPaint"
        Me.Text = "Paint Test"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub pic_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pic.Paint
        Dim g As Graphics

        g = e.Graphics
        ' Simply fill a rectangle with red.
        g.FillRectangle(New SolidBrush(Color.Red), 40, 10, 100, 140)
        g.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.Yellow)), 10, 40, 140, 100)


        ' Create a pen 5 pixels wide that is and purple and partially transparent.
        ' Make it a dashed pen.
        '    penExample.DashStyle = DashStyle.Dash
        ' Make the ends round.
        Dim penExample As New Pen(Color.FromArgb(150, Color.Purple), 5) With {
            .StartCap = LineCap.Round,
            .EndCap = LineCap.Round
        }

            ' Now draw a curve using the pen
        g.DrawCurve(penExample, New Point() {
                New Point(200, 14),
                New Point(70, 240),
                New Point(50, 34),
                New Point(140, 140),
                New Point(40, 34)
                })

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim newBitmap As Bitmap = New Bitmap(300, 300, PixelFormat.Format32bppArgb)
        Dim g As Graphics = Graphics.FromImage(newBitmap)
        g.Clear(Color.Aquamarine)
        'g.FillRectangle(New SolidBrush(Color.Red), 40, 40, 140, 140)

        g.TextRenderingHint = TextRenderingHint.AntiAlias
        '    g.FillRectangle(Brush, ClientRectangle)
        g.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.White)), ClientRectangle)

        Dim path As New GraphicsPath(New Point() {
            New Point(40, 140),
            New Point(275, 200),
            New Point(105, 225),
            New Point(190, 300),
            New Point(50, 350),
            New Point(20, 180)
            }, New Byte() {
                CType(PathPointType.Start, Byte),
                CType(PathPointType.Bezier, Byte),
                CType(PathPointType.Bezier, Byte),
                CType(PathPointType.Bezier, Byte),
                CType(PathPointType.Line, Byte),
                CType(PathPointType.Line, Byte)
                })

        Dim pgb As New PathGradientBrush(path) With {
            .SurroundColors = New Color() {
            Color.Green,
            Color.Yellow,
            Color.Red,
            Color.Blue,
            Color.Orange,
            Color.White
        }
        }

        g.FillPath(pgb, path)

        Me.BackgroundImage = newBitmap
    End Sub
End Class
