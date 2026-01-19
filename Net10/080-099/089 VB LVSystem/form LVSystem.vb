' Essai de moteur LVSystem de tracé de fractales, inspiré du L-System FractInt (Lindenmayer System)
' Par rapport au L-System original, il n'y a qu'une règle de transformation à chaque étape, et
' S représente la séquence précédente, ~S la séquence précédente inversée (lecture ordre inverse,
' et permutation des - et +
'
' Dans les règles, S représente la séquence précédente, ~S la séquence précédente inversée
' + ou tourne dans le sens trigo, - dans le sens horaire, F dessine un trait
' Peano:  Angle 4, Départ: +F-F-F+, règle: S=+~SF-SFS-F~S+
' Dragon: Angle 8, Départ: F, règle: S=+S--~S+
'
' 2003/11/11 	PV		Première version
'
' 2006-10-01 	PV		VS 2005
' 2010-07-19 	PV		VS 2010
' 2012-02-05 	PV		Nettoyage
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10
Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.Text

#Disable Warning IDE1006 ' Naming Styles

Public Class LVSystemForm
    Inherits Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents btnGénère As Button

    Friend WithEvents lblRègles As Label
    Friend WithEvents txtDépart As TextBox
    Friend WithEvents lblDépart As Label
    Friend WithEvents txtRègles As TextBox
    Friend WithEvents txtFinal As TextBox
    Friend WithEvents lblFinal As Label
    Friend WithEvents lblAngle As Label
    Friend WithEvents txtAngle As TextBox
    Friend WithEvents txtItérations As TextBox
    Friend WithEvents lblItérations As Label
    Friend WithEvents txtAnalyse As TextBox
    Friend WithEvents lblAnalyse As Label
    Friend WithEvents ExempleHilbertButton As Button
    Friend WithEvents ExempleDragonButton As Button
    Friend WithEvents picOut As PictureBox

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        btnGénère = New Button()
        lblAngle = New Label()
        txtAngle = New TextBox()
        txtDépart = New TextBox()
        lblDépart = New Label()
        txtRègles = New TextBox()
        lblRègles = New Label()
        txtFinal = New TextBox()
        lblFinal = New Label()
        txtItérations = New TextBox()
        lblItérations = New Label()
        txtAnalyse = New TextBox()
        lblAnalyse = New Label()
        picOut = New PictureBox()
        ExempleHilbertButton = New Button()
        ExempleDragonButton = New Button()
        CType(picOut, ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'btnGénère
        '
        btnGénère.Location = New Point(8, 192)
        btnGénère.Name = "btnGénère"
        btnGénère.Size = New Size(75, 23)
        btnGénère.TabIndex = 0
        btnGénère.Text = "Génère"
        '
        'lblAngle
        '
        lblAngle.AutoSize = True
        lblAngle.Location = New Point(8, 128)
        lblAngle.Name = "lblAngle"
        lblAngle.Size = New Size(41, 13)
        lblAngle.TabIndex = 1
        lblAngle.Text = "Angle :"
        '
        'txtAngle
        '
        txtAngle.Location = New Point(64, 128)
        txtAngle.Name = "txtAngle"
        txtAngle.Size = New Size(56, 21)
        txtAngle.TabIndex = 2
        txtAngle.Text = "4"
        '
        'txtDépart
        '
        txtDépart.Location = New Point(64, 8)
        txtDépart.Name = "txtDépart"
        txtDépart.Size = New Size(288, 21)
        txtDépart.TabIndex = 4
        txtDépart.Text = "+F-F-F+"
        '
        'lblDépart
        '
        lblDépart.AutoSize = True
        lblDépart.Location = New Point(8, 8)
        lblDépart.Name = "lblDépart"
        lblDépart.Size = New Size(47, 13)
        lblDépart.TabIndex = 3
        lblDépart.Text = "Départ :"
        '
        'txtRègles
        '
        txtRègles.Location = New Point(64, 40)
        txtRègles.Multiline = True
        txtRègles.Name = "txtRègles"
        txtRègles.Size = New Size(288, 80)
        txtRègles.TabIndex = 6
        txtRègles.Text = "S=+~SF-SFS-F~S+"
        '
        'lblRègles
        '
        lblRègles.AutoSize = True
        lblRègles.Location = New Point(8, 40)
        lblRègles.Name = "lblRègles"
        lblRègles.Size = New Size(46, 13)
        lblRègles.TabIndex = 5
        lblRègles.Text = "Règles :"
        '
        'txtFinal
        '
        txtFinal.Location = New Point(64, 232)
        txtFinal.Multiline = True
        txtFinal.Name = "txtFinal"
        txtFinal.ReadOnly = True
        txtFinal.Size = New Size(288, 144)
        txtFinal.TabIndex = 8
        '
        'lblFinal
        '
        lblFinal.AutoSize = True
        lblFinal.Location = New Point(8, 232)
        lblFinal.Name = "lblFinal"
        lblFinal.Size = New Size(36, 13)
        lblFinal.TabIndex = 7
        lblFinal.Text = "Final :"
        '
        'txtItérations
        '
        txtItérations.Location = New Point(64, 160)
        txtItérations.Name = "txtItérations"
        txtItérations.Size = New Size(56, 21)
        txtItérations.TabIndex = 10
        txtItérations.Text = "1"
        '
        'lblItérations
        '
        lblItérations.AutoSize = True
        lblItérations.Location = New Point(8, 160)
        lblItérations.Name = "lblItérations"
        lblItérations.Size = New Size(61, 13)
        lblItérations.TabIndex = 9
        lblItérations.Text = "Itérations :"
        '
        'txtAnalyse
        '
        txtAnalyse.Location = New Point(64, 384)
        txtAnalyse.Multiline = True
        txtAnalyse.Name = "txtAnalyse"
        txtAnalyse.ReadOnly = True
        txtAnalyse.Size = New Size(288, 80)
        txtAnalyse.TabIndex = 12
        '
        'lblAnalyse
        '
        lblAnalyse.AutoSize = True
        lblAnalyse.Location = New Point(8, 384)
        lblAnalyse.Name = "lblAnalyse"
        lblAnalyse.Size = New Size(52, 13)
        lblAnalyse.TabIndex = 11
        lblAnalyse.Text = "Analyse :"
        '
        'picOut
        '
        picOut.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom _
            Or AnchorStyles.Left _
            Or AnchorStyles.Right
        picOut.BorderStyle = BorderStyle.FixedSingle
        picOut.Location = New Point(360, 8)
        picOut.Name = "picOut"
        picOut.Size = New Size(360, 456)
        picOut.TabIndex = 13
        picOut.TabStop = False
        '
        'ExempleHilbertButton
        '
        ExempleHilbertButton.Location = New Point(238, 126)
        ExempleHilbertButton.Name = "ExempleHilbertButton"
        ExempleHilbertButton.Size = New Size(114, 23)
        ExempleHilbertButton.TabIndex = 14
        ExempleHilbertButton.Text = "Exemple Hilbert"
        ExempleHilbertButton.UseVisualStyleBackColor = True
        '
        'ExempleDragonButton
        '
        ExempleDragonButton.Location = New Point(238, 158)
        ExempleDragonButton.Name = "ExempleDragonButton"
        ExempleDragonButton.Size = New Size(114, 23)
        ExempleDragonButton.TabIndex = 15
        ExempleDragonButton.Text = "Exemple Dragon"
        ExempleDragonButton.UseVisualStyleBackColor = True
        '
        'frmLVSystem
        '
        AutoScaleBaseSize = New Size(5, 14)
        ClientSize = New Size(728, 470)
        Controls.Add(ExempleDragonButton)
        Controls.Add(ExempleHilbertButton)
        Controls.Add(picOut)
        Controls.Add(txtAnalyse)
        Controls.Add(lblAnalyse)
        Controls.Add(txtItérations)
        Controls.Add(lblItérations)
        Controls.Add(txtFinal)
        Controls.Add(lblFinal)
        Controls.Add(txtRègles)
        Controls.Add(lblRègles)
        Controls.Add(txtDépart)
        Controls.Add(lblDépart)
        Controls.Add(txtAngle)
        Controls.Add(lblAngle)
        Controls.Add(btnGénère)
        MyBase.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
        Name = "frmLVSystem"
        Text = "LVSystem, Application à la courbe de Hilbert"
        CType(picOut, ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

#End Region

    Private iNbItérations As Integer
    Private sChaîne As String
    Private iAngle As Integer
    Private tsRègles As String()

    Private Sub btnGénère_Click(sender As Object, e As EventArgs) Handles btnGénère.Click
        Cursor.Current = Cursors.WaitCursor

        sChaîne = txtDépart.Text
        iNbItérations = Val(txtItérations.Text)
        If iNbItérations < 0 Or iNbItérations > 16 Then
            iNbItérations = 1
            txtItérations.Text = Format(iNbItérations)
        End If
        iAngle = Val(txtAngle.Text)
        If iAngle < 0 Or iAngle > 100 Then
            iAngle = 4
            txtItérations.Text = Format(iAngle)
        End If
        tsRègles = txtRègles.Text.Split(Chr(13))

        For i As Integer = 1 To iNbItérations
            sChaîne = sAppliqueRègles(sChaîne)
        Next

        txtFinal.Text = sChaîne
        txtAnalyse.Text = sAnalyseEtDessine(sChaîne)

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub frmLSystem_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        sAnalyseEtDessine(txtFinal.Text)
    End Sub

    Public Function sAppliqueRègles(s As String) As String
        For Each sr As String In tsRègles
            Dim tsr As String()
            tsr = sr.Split("=")
            If tsr.Length = 2 Then
                If tsr(1).Contains("~S", StringComparison.CurrentCulture) Then tsr(1) = tsr(1).Replace("~S", sInverse(s))
                If tsr(1).Contains("S"c, StringComparison.CurrentCulture) Then tsr(1) = tsr(1).Replace("S", s)
                s = If(tsr(0) = "S", tsr(1), s.Replace(tsr(0), tsr(1)))
            End If
        Next
        Return s
    End Function

    Private Shared Function sInverse(s0 As String) As String
        Dim s As StringBuilder
        s = New StringBuilder
        For i As Integer = s0.Length - 1 To 0 Step -1
            Select Case s0.Chars(i)
                Case "+"c
                    s.Append("-"c)
                Case "-"c
                    s.Append("+"c)
                Case Else
                    s.Append(s0.Chars(i))
            End Select
        Next
        Return s.ToString
    End Function

    Public Function sAnalyseEtDessine(s As String) As String
        Dim px As Double = 0.0
        Dim py As Double = 0.0
        Dim a As Integer = 0
        Dim ar As Double = 2 * Math.PI / iAngle

        Dim xmax, xmin As Double
        Dim ymax, ymin As Double

        For Each c As Char In s
            Select Case c
                Case "+"c
                    a += 1
                Case "-"c
                    a -= 1
                Case "F"c
                    px += Math.Cos(a * ar)
                    py += Math.Sin(a * ar)
                    xmax = Math.Max(xmax, px)
                    ymax = Math.Max(ymax, py)
                    xmin = Math.Min(xmin, px)
                    ymin = Math.Min(ymin, py)
            End Select
        Next

        sAnalyseEtDessine = "x min/max: " & Format(xmin, "0.000") & " / " & Format(xmax, "0.000") & vbCrLf &
                   "y min/max: " & Format(ymin, "0.000") & " / " & Format(ymax, "0.000")

        Dim r, rx, ry As Double

        If xmax = xmin Then
            rx = 100000
        Else
            rx = picOut.Size.Width / (1.1 * (xmax - xmin))
            xmin -= 0.05 * (xmax - xmin)
        End If
        If ymax = ymin Then
            ry = 100000
        Else
            ry = picOut.Size.Height / (1.1 * (ymax - ymin))
            ymin -= 0.05 * (ymax - ymin)
        End If
        r = Math.Min(rx, ry)

        Dim bmpOut As Bitmap
        If picOut.Size.Width <= 1 Or picOut.Size.Height <= 1 Then Return "Zone de dessin trop petite"

        bmpOut = New Bitmap(picOut.Size.Width, picOut.Size.Height, PixelFormat.Format24bppRgb)
        Dim graOut As Graphics
        graOut = Graphics.FromImage(bmpOut)
        graOut.Clear(Color.White)

        picOut.Image = bmpOut

        px = 0.0
        py = 0.0
        a = 0
        Dim nx, ny As Double

        For Each c As Char In s
            Select Case c
                Case "+"c
                    a += 1
                Case "-"c
                    a -= 1
                Case "F"c
                    nx = px + Math.Cos(a * ar)
                    ny = py + Math.Sin(a * ar)
                    graOut.DrawLine(Pens.Black, CInt((px - xmin) * r), CInt((py - ymin) * r), CInt((nx - xmin) * r), CInt((ny - ymin) * r))
                    px = nx
                    py = ny
            End Select
        Next
    End Function

    Private Sub ExempleHilbertButton_Click(sender As Object, e As EventArgs) Handles ExempleHilbertButton.Click
        txtDépart.Text = "+F-F-F+"
        txtRègles.Text = "S=+~SF-SFS-F~S+"
        txtAngle.Text = "4"
        txtItérations.Text = "5"
    End Sub

    Private Sub ExempleDragonButton_Click(sender As Object, e As EventArgs) Handles ExempleDragonButton.Click
        txtDépart.Text = "F"
        txtRègles.Text = "S=+S--~S+"
        txtAngle.Text = "8"
        txtItérations.Text = "10"
    End Sub

End Class
