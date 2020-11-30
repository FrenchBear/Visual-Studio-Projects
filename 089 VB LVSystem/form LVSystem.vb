' Essai de moteur LVSystem de trac� de fractales, inspir� du L-System FractInt (Lindenmayer System)
' Par rapport au L-System original, il n'y a qu'une r�gle de transformation � chaque �tape, et
' S repr�sente la s�quence pr�c�dente, ~S la s�quence pr�c�dente invers�e (lecture ordre inverse,
' et permutation des - et +
'
' Dans les r�gles, S repr�sente la s�quence pr�c�dente, ~S la s�quence pr�c�dente invers�e
' + ou tourne dans le sens trigo, - dans le sens horaire, F dessine un trait
' Peano:  Angle 4, D�part: +F-F-F+, r�gle: S=+~SF-SFS-F~S+
' Dragon: Angle 8, D�part: F, r�gle: S=+S--~S+
'
' 2003/11/11    PV  Premi�re version
' 2006-10-01    PV  VS 2005
' 2010-07-19    PV  VS 2010
' 2012-02-05    PV  Nettoyage

#Disable Warning IDE1006 ' Naming Styles

Public Class LVSystemForm
    Inherits Form

#Region " Code g�n�r� par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()

    End Sub

    'La m�thode substitu�e Dispose du formulaire pour nettoyer la liste des composants.
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

    'REMARQUE�: la proc�dure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'�diteur de code.
    Friend WithEvents btnG�n�re As Button

    Friend WithEvents lblR�gles As Label
    Friend WithEvents txtD�part As TextBox
    Friend WithEvents lblD�part As Label
    Friend WithEvents txtR�gles As TextBox
    Friend WithEvents txtFinal As TextBox
    Friend WithEvents lblFinal As Label
    Friend WithEvents lblAngle As Label
    Friend WithEvents txtAngle As TextBox
    Friend WithEvents txtIt�rations As TextBox
    Friend WithEvents lblIt�rations As Label
    Friend WithEvents txtAnalyse As TextBox
    Friend WithEvents lblAnalyse As Label
    Friend WithEvents ExempleHilbertButton As Button
    Friend WithEvents ExempleDragonButton As Button
    Friend WithEvents picOut As PictureBox

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnG�n�re = New Button()
        Me.lblAngle = New Label()
        Me.txtAngle = New TextBox()
        Me.txtD�part = New TextBox()
        Me.lblD�part = New Label()
        Me.txtR�gles = New TextBox()
        Me.lblR�gles = New Label()
        Me.txtFinal = New TextBox()
        Me.lblFinal = New Label()
        Me.txtIt�rations = New TextBox()
        Me.lblIt�rations = New Label()
        Me.txtAnalyse = New TextBox()
        Me.lblAnalyse = New Label()
        Me.picOut = New PictureBox()
        Me.ExempleHilbertButton = New Button()
        Me.ExempleDragonButton = New Button()
        CType(Me.picOut, ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnG�n�re
        '
        Me.btnG�n�re.Location = New Point(8, 192)
        Me.btnG�n�re.Name = "btnG�n�re"
        Me.btnG�n�re.Size = New Size(75, 23)
        Me.btnG�n�re.TabIndex = 0
        Me.btnG�n�re.Text = "G�n�re"
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
        'txtD�part
        '
        Me.txtD�part.Location = New Point(64, 8)
        Me.txtD�part.Name = "txtD�part"
        Me.txtD�part.Size = New Size(288, 21)
        Me.txtD�part.TabIndex = 4
        Me.txtD�part.Text = "+F-F-F+"
        '
        'lblD�part
        '
        Me.lblD�part.AutoSize = True
        Me.lblD�part.Location = New Point(8, 8)
        Me.lblD�part.Name = "lblD�part"
        Me.lblD�part.Size = New Size(47, 13)
        Me.lblD�part.TabIndex = 3
        Me.lblD�part.Text = "D�part :"
        '
        'txtR�gles
        '
        Me.txtR�gles.Location = New Point(64, 40)
        Me.txtR�gles.Multiline = True
        Me.txtR�gles.Name = "txtR�gles"
        Me.txtR�gles.Size = New Size(288, 80)
        Me.txtR�gles.TabIndex = 6
        Me.txtR�gles.Text = "S=+~SF-SFS-F~S+"
        '
        'lblR�gles
        '
        Me.lblR�gles.AutoSize = True
        Me.lblR�gles.Location = New Point(8, 40)
        Me.lblR�gles.Name = "lblR�gles"
        Me.lblR�gles.Size = New Size(46, 13)
        Me.lblR�gles.TabIndex = 5
        Me.lblR�gles.Text = "R�gles :"
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
        'txtIt�rations
        '
        Me.txtIt�rations.Location = New Point(64, 160)
        Me.txtIt�rations.Name = "txtIt�rations"
        Me.txtIt�rations.Size = New Size(56, 21)
        Me.txtIt�rations.TabIndex = 10
        Me.txtIt�rations.Text = "1"
        '
        'lblIt�rations
        '
        Me.lblIt�rations.AutoSize = True
        Me.lblIt�rations.Location = New Point(8, 160)
        Me.lblIt�rations.Name = "lblIt�rations"
        Me.lblIt�rations.Size = New Size(61, 13)
        Me.lblIt�rations.TabIndex = 9
        Me.lblIt�rations.Text = "It�rations :"
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
        Me.Controls.Add(Me.txtIt�rations)
        Me.Controls.Add(Me.lblIt�rations)
        Me.Controls.Add(Me.txtFinal)
        Me.Controls.Add(Me.lblFinal)
        Me.Controls.Add(Me.txtR�gles)
        Me.Controls.Add(Me.lblR�gles)
        Me.Controls.Add(Me.txtD�part)
        Me.Controls.Add(Me.lblD�part)
        Me.Controls.Add(Me.txtAngle)
        Me.Controls.Add(Me.lblAngle)
        Me.Controls.Add(Me.btnG�n�re)
        Me.Font = New Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmLVSystem"
        Me.Text = "LVSystem, Application � la courbe de Hilbert"
        CType(Me.picOut, ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim iNbIt�rations As Integer
    Dim sCha�ne As String
    Dim iAngle As Integer
    Dim tsR�gles As String()

    Private Sub btnG�n�re_Click(sender As System.Object, e As EventArgs) Handles btnG�n�re.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

        sCha�ne = txtD�part.Text
        iNbIt�rations = Val(txtIt�rations.Text)
        If iNbIt�rations < 0 Or iNbIt�rations > 16 Then
            iNbIt�rations = 1
            txtIt�rations.Text = Format(iNbIt�rations)
        End If
        iAngle = Val(txtAngle.Text)
        If iAngle < 0 Or iAngle > 100 Then
            iAngle = 4
            txtIt�rations.Text = Format(iAngle)
        End If
        tsR�gles = txtR�gles.Text.Split(Chr(13))

        For i As Integer = 1 To iNbIt�rations
            sCha�ne = sAppliqueR�gles(sCha�ne)
        Next

        txtFinal.Text = sCha�ne
        txtAnalyse.Text = sAnalyseEtDessine(sCha�ne)

        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub frmLSystem_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        sAnalyseEtDessine(txtFinal.Text)
    End Sub

    Function sAppliqueR�gles(s As String) As String
        For Each sr As String In tsR�gles
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
        txtD�part.Text = "+F-F-F+"
        txtR�gles.Text = "S=+~SF-SFS-F~S+"
        txtAngle.Text = "4"
        txtIt�rations.Text = "5"
    End Sub

    Private Sub ExempleDragonButton_Click(sender As System.Object, e As EventArgs) Handles ExempleDragonButton.Click
        txtD�part.Text = "F"
        txtR�gles.Text = "S=+S--~S+"
        txtAngle.Text = "8"
        txtIt�rations.Text = "10"
    End Sub

End Class