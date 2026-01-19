' 2001 PV
'
' 2006-10-01    PV      VS2005
' 2012-02-25	PV      VS2010
' 2021-09-18    PV      VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Reflection
Imports System.Windows.Forms

#Disable Warning IDE1006 ' Naming Styles

Public Class Form1
    Inherits Form

    Private ReadOnly g As Graphics
    Private ReadOnly gp1 As Graphics
    Private ReadOnly gp2 As Graphics

    Private ReadOnly iNbCoul As Integer
    Private ReadOnly colCouleurs As New Hashtable()

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim picBitmap As Bitmap
        picBitmap = New Bitmap(pic.Size.Width, pic.Size.Height, PixelFormat.Format24bppRgb)
        g = Graphics.FromImage(picBitmap)
        g.Clear(Color.FromKnownColor(KnownColor.Control))
        pic.BackgroundImage = picBitmap

        Dim picBitmap1 As Bitmap
        picBitmap1 = New Bitmap(Panel1.Size.Width, 4 * Panel1.Size.Height, PixelFormat.Format24bppRgb)
        gp1 = Graphics.FromImage(picBitmap1)
        gp1.Clear(Color.FromKnownColor(KnownColor.PowderBlue))
        Panel1.AutoScrollMinSize = New Size(0, 4 * Panel1.Size.Height)
        Panel1.BackgroundImage = picBitmap1

        Dim t As Type
        t = GetType(KnownColor)
        Dim f As FieldInfo
        For Each f In t.GetFields(BindingFlags.Static Or BindingFlags.Public)
            colCouleurs.Add(CInt(f.GetValue(Nothing)), f.Name)
        Next
        iNbCoul = colCouleurs.Keys.Count
        Dim picBitmap2 As Bitmap
        picBitmap2 = New Bitmap(Panel2.Size.Width, 14 * (iNbCoul + 1), PixelFormat.Format24bppRgb)
        gp2 = Graphics.FromImage(picBitmap2)
        gp2.Clear(Color.FromKnownColor(KnownColor.Beige))
        Panel2.AutoScrollMinSize = New Size(0, 14 * (iNbCoul + 1))
        Panel2.BackgroundImage = picBitmap2
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then components?.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents btnDessine As Button
    Friend WithEvents pic As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        pic = New PictureBox()
        btnDessine = New Button()
        Panel1 = New Panel()
        Panel2 = New Panel()
        SuspendLayout()
        '
        'pic
        '
        pic.Location = New Point(8, 48)
        pic.Name = "pic"
        pic.Size = New Size(248, 312)
        pic.TabIndex = 1
        pic.TabStop = False
        '
        'btnDessine
        '
        btnDessine.Location = New Point(8, 8)
        btnDessine.Name = "btnDessine"
        btnDessine.TabIndex = 0
        btnDessine.Text = "Dessine"
        '
        'Panel1
        '
        Panel1.AutoScroll = True
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Location = New Point(272, 8)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(304, 200)
        Panel1.TabIndex = 2
        '
        'Panel2
        '
        Panel2.AutoScroll = True
        Panel2.Location = New Point(272, 216)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(304, 256)
        Panel2.TabIndex = 2
        '
        'Form1
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(584, 477)
        Controls.AddRange(New Control() {Panel2, Panel1, pic, btnDessine})
        Name = "Form1"
        Text = "Essais graphiques en VB - V2"
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnDessine_Click(sender As Object, e As EventArgs) Handles btnDessine.Click
        g.Clear(Color.FromKnownColor(KnownColor.MistyRose))
        g.FillRectangle(New SolidBrush(Color.Red), 40, 40, 140, 140)
        g.DrawString("Hello World", Font, New SolidBrush(Color.Black), 10, 10)
        pic.Refresh()

        Dim i As Integer
        For i = 0 To Panel1.AutoScrollMinSize.Height Step 20
            gp1.DrawLine(Pens.Black, 0, i, 8, i)
            gp1.DrawString(i.ToString, Font, Brushes.Black, 10, i - 6)
        Next
        Panel1.Refresh()

        Dim colCouleursTriée As New SortedList(colCouleurs)
        Dim de As DictionaryEntry
        i = 0
        For Each de In colCouleursTriée
            Dim sVal, sKey As String
            sKey = CType(de.Key, String)
            sVal = CType(de.Value, String)
            Dim iCoul As KnownColor
            iCoul = CType(sKey, KnownColor)
            gp2.DrawString(sKey, Font, Brushes.Black, 2, (14 * i) + 7)
            gp2.DrawString(sVal, Font, Brushes.Black, 25, (14 * i) + 7)
            gp2.FillRectangle(New SolidBrush(Color.FromKnownColor(iCoul)), 135, (14 * i) + 7, 140, 13)
            i += 1
        Next
        Panel2.Refresh()

    End Sub

End Class
