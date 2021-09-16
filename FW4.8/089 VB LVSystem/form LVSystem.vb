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
' 2003/11/11    PV  Première version
' 2006-10-01    PV  VS 2005
' 2010-07-19    PV  VS 2010
' 2012-02-05    PV  Nettoyage

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
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As System.ComponentModel.IContainer

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
        Me.btnGénère = New Button()
        Me.lblAngle = New Label()
        Me.txtAngle = New TextBox()
        Me.txtDépart = New TextBox()
        Me.lblDépart = New Label()
        Me.txtRègles = New TextBox()
        Me.lblRègles = New Label()
        Me.txtFinal = New TextBox()
        Me.lblFinal = New Label()
        Me.txtItérations = New TextBox()
        Me.lblItérations = New Label()
        Me.txtAnalyse = New TextBox()
        Me.lblAnalyse = New Label()
        Me.picOut = New PictureBox()
        Me.ExempleHilbertButton = New Button()
        Me.ExempleDragonButton = New Button()
        CType(Me.picOut, ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGénère
        '
        Me.btnGénère.Location = New Point(8, 192)
        Me.btnGénère.Name = "btnGénère"
        Me.btnGénère.Size = New Size(75, 23)
        Me.btnGénère.TabIndex = 0
        Me.btnGénère.Text = "Génère"
        '
        'lblAngle
        '
        Me.lblAngle.AutoSize = True
        Me.lblAngle.Location = New Point(8, 128)
        Me.lblAngle.Name = "lblAngle"
        Me.lblAngle.Size = New Size(41, 13)
        Me.lblAngle.TabIndex = 1
        Me.lblAngle.Text = "Angle :"
        '
        'txtAngle
        '
        Me.txtAngle.Location = New Point(64, 128)
        Me.txtAngle.Name = "txtAngle"
        Me.txtAngle.Size = New Size(56, 21)
        Me.txtAngle.TabIndex = 2
        Me.txtAngle.Text = "4"
        '
        'txtDépart
        '
        Me.txtDépart.Location = New Point(64, 8)
        Me.txtDépart.Name = "txtDépart"
        Me.txtDépart.Size = New Size(288, 21)
        Me.txtDépart.TabIndex = 4
        Me.txtDépart.Text = "+F-F-F+"
        '
        'lblDépart
        '
        Me.lblDépart.AutoSize = True
        Me.lblDépart.Location = New Point(8, 8)
        Me.lblDépart.Name = "lblDépart"
        Me.lblDépart.Size = New Size(47, 13)
        Me.lblDépart.TabIndex = 3
        Me.lblDépart.Text = "Départ :"
        '
        'txtRègles
        '
        Me.txtRègles.Location = New Point(64, 40)
        Me.txtRègles.Multiline = True
        Me.txtRègles.Name = "txtRègles"
        Me.txtRègles.Size = New Size(288, 80)
        Me.txtRègles.TabIndex = 6
        Me.txtRègles.Text = "S=+~SF-SFS-F~S+"
        '
        'lblRègles
        '
        Me.lblRègles.AutoSize = True
        Me.lblRègles.Location = New Point(8, 40)
        Me.lblRègles.Name = "lblRègles"
        Me.lblRègles.Size = New Size(46, 13)
        Me.lblRègles.TabIndex = 5
        Me.lblRègles.Text = "Règles :"
        '
        'txtFinal
        '
        Me.txtFinal.Location = New Point(64, 232)
        Me.txtFinal.Multiline = True
        Me.txtFinal.Name = "txtFinal"
        Me.txtFinal.ReadOnly = True
        Me.txtFinal.Size = New Size(288, 144)
        Me.txtFinal.TabIndex = 8
        '
        'lblFinal
        '
        Me.lblFinal.AutoSize = True
        Me.lblFinal.Location = New Point(8, 232)
        Me.lblFinal.Name = "lblFinal"
        Me.lblFinal.Size = New Size(36, 13)
        Me.lblFinal.TabIndex = 7
        Me.lblFinal.Text = "Final :"
        '
        'txtItérations
        '
        Me.txtItérations.Location = New Point(64, 160)
        Me.txtItérations.Name = "txtItérations"
        Me.txtItérations.Size = New Size(56, 21)
        Me.txtItérations.TabIndex = 10
        Me.txtItérations.Text = "1"
        '
        'lblItérations
        '
        Me.lblItérations.AutoSize = True
        Me.lblItérations.Location = New Point(8, 160)
        Me.lblItérations.Name = "lblItérations"
        Me.lblItérations.Size = New Size(61, 13)
        Me.lblItérations.TabIndex = 9
        Me.lblItérations.Text = "Itérations :"
        '
        'txtAnalyse
        '
        Me.txtAnalyse.Location = New Point(64, 384)
        Me.txtAnalyse.Multiline = True
        Me.txtAnalyse.Name = "txtAnalyse"
        Me.txtAnalyse.ReadOnly = True
        Me.txtAnalyse.Size = New Size(288, 80)
        Me.txtAnalyse.TabIndex = 12
        '
        'lblAnalyse
        '
        Me.lblAnalyse.AutoSize = True
        Me.lblAnalyse.Location = New Point(8, 384)
        Me.lblAnalyse.Name = "lblAnalyse"
        Me.lblAnalyse.Size = New Size(52, 13)
        Me.lblAnalyse.TabIndex = 11
        Me.lblAnalyse.Text = "Analyse :"
        '
        'picOut
        '
        Me.picOut.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.picOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picOut.Location = New Point(360, 8)
        Me.picOut.Name = "picOut"
        Me.picOut.Size = New Size(360, 456)
        Me.picOut.TabIndex = 13
        Me.picOut.TabStop = False
        '
        'ExempleHilbertButton
        '
        Me.ExempleHilbertButton.Location = New Point(238, 126)
        Me.ExempleHilbertButton.Name = "ExempleHilbertButton"
        Me.ExempleHilbertButton.Size = New Size(114, 23)
        Me.ExempleHilbertButton.TabIndex = 14
        Me.ExempleHilbertButton.Text = "Exemple Hilbert"
        Me.ExempleHilbertButton.UseVisualStyleBackColor = True
        '
        'ExempleDragonButton
        '
        Me.ExempleDragonButton.Location = New Point(238, 158)
        Me.ExempleDragonButton.Name = "ExempleDragonButton"
        Me.ExempleDragonButton.Size = New Size(114, 23)
        Me.ExempleDragonButton.TabIndex = 15
        Me.ExempleDragonButton.Text = "Exemple Dragon"
        Me.ExempleDragonButton.UseVisualStyleBackColor = True
        '
        'frmLVSystem
        '
        Me.AutoScaleBaseSize = New Size(5, 14)
        Me.ClientSize = New Size(728, 470)
        Me.Controls.Add(Me.ExempleDragonButton)
        Me.Controls.Add(Me.ExempleHilbertButton)
        Me.Controls.Add(Me.picOut)
        Me.Controls.Add(Me.txtAnalyse)
        Me.Controls.Add(Me.lblAnalyse)
        Me.Controls.Add(Me.txtItérations)
        Me.Controls.Add(Me.lblItérations)
        Me.Controls.Add(Me.txtFinal)
        Me.Controls.Add(Me.lblFinal)
        Me.Controls.Add(Me.txtRègles)
        Me.Controls.Add(Me.lblRègles)
        Me.Controls.Add(Me.txtDépart)
        Me.Controls.Add(Me.lblDépart)
        Me.Controls.Add(Me.txtAngle)
        Me.Controls.Add(Me.lblAngle)
        Me.Controls.Add(Me.btnGénère)
        Me.Font = New Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmLVSystem"
        Me.Text = "LVSystem, Application à la courbe de Hilbert"
        CType(Me.picOut, ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim iNbItérations As Integer
    Dim sChaîne As String
    Dim iAngle As Integer
    Dim tsRègles As String()

    Private Sub btnGénère_Click(sender As System.Object, e As EventArgs) Handles btnGénère.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

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

        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub frmLSystem_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        sAnalyseEtDessine(txtFinal.Text)
    End Sub

    Function sAppliqueRègles(s As String) As String
        For Each sr As String In tsRègles
            Dim tsr As String()
            tsr = sr.Split("=")
            If tsr.Length = 2 Then
                If tsr(1).IndexOf("~S") >= 0 Then tsr(1) = tsr(1).Replace("~S", sInverse(s))
                If tsr(1).IndexOf("S") >= 0 Then tsr(1) = tsr(1).Replace("S", s)
                If tsr(0) = "S" Then
                    s = tsr(1)
                Else
                    s = s.Replace(tsr(0), tsr(1))
                End If
            End If
        Next
        Return s
    End Function

    Private Function sInverse(s0 As String) As String
        Dim s As Text.StringBuilder
        s = New Text.StringBuilder
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

    Function sAnalyseEtDessine(s As String) As String
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

        bmpOut = New Bitmap(picOut.Size.Width, picOut.Size.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
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

    Private Sub ExempleHilbertButton_Click(sender As System.Object, e As EventArgs) Handles ExempleHilbertButton.Click
        txtDépart.Text = "+F-F-F+"
        txtRègles.Text = "S=+~SF-SFS-F~S+"
        txtAngle.Text = "4"
        txtItérations.Text = "5"
    End Sub

    Private Sub ExempleDragonButton_Click(sender As System.Object, e As EventArgs) Handles ExempleDragonButton.Click
        txtDépart.Text = "F"
        txtRègles.Text = "S=+S--~S+"
        txtAngle.Text = "8"
        txtItérations.Text = "10"
    End Sub

End Class