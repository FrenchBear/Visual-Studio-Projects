' 2001 PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Imports System.Drawing.Imaging
Imports System.Reflection

#Disable Warning IDE1006 ' Naming Styles

Public Class Form1
    Inherits Form

    ReadOnly g As Graphics
    ReadOnly gp1 As Graphics
    ReadOnly gp2 As Graphics

    ReadOnly iNbCoul As Integer
    ReadOnly colCouleurs As New Hashtable()

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
        If disposing Then
            components?.Dispose()
        End If
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
        Me.pic = New PictureBox()
        Me.btnDessine = New Button()
        Me.Panel1 = New Panel()
        Me.Panel2 = New Panel()
        Me.SuspendLayout()
        '
        'pic
        '
        Me.pic.Location = New Point(8, 48)
        Me.pic.Name = "pic"
        Me.pic.Size = New Size(248, 312)
        Me.pic.TabIndex = 1
        Me.pic.TabStop = False
        '
        'btnDessine
        '
        Me.btnDessine.Location = New Point(8, 8)
        Me.btnDessine.Name = "btnDessine"
        Me.btnDessine.TabIndex = 0
        Me.btnDessine.Text = "Dessine"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New Point(272, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(304, 200)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Location = New Point(272, 216)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(304, 256)
        Me.Panel2.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(584, 477)
        Me.Controls.AddRange(New Control() {Me.Panel2, Me.Panel1, Me.pic, Me.btnDessine})
        Me.Name = "Form1"
        Me.Text = "Essais graphiques en VB - V2"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnDessine_Click(sender As System.Object, e As EventArgs) Handles btnDessine.Click
        g.Clear(Color.FromKnownColor(KnownColor.MistyRose))
        g.FillRectangle(New SolidBrush(Color.Red), 40, 40, 140, 140)
        g.DrawString("Hello World", Me.Font, New SolidBrush(Color.Black), 10, 10)
        pic.Refresh()

        Dim i As Integer
        For i = 0 To Panel1.AutoScrollMinSize.Height Step 20
            gp1.DrawLine(Pens.Black, 0, i, 8, i)
            gp1.DrawString(i.ToString, Me.Font, Brushes.Black, 10, i - 6)
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
            gp2.DrawString(sKey, Me.Font, Brushes.Black, 2, 14 * i + 7)
            gp2.DrawString(sVal, Me.Font, Brushes.Black, 25, 14 * i + 7)
            gp2.FillRectangle(New SolidBrush(Color.FromKnownColor(iCoul)), 135, 14 * i + 7, 140, 13)
            i += 1
        Next
        Panel2.Refresh()

    End Sub

End Class