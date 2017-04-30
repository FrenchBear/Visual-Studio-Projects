' Labyrinthe .Net
' 2002-03-24    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class frmLabyrinthe
    Inherits System.Windows.Forms.Form

    Const kSize As Integer = 10
    Shared Largeur As Integer
    Shared Hauteur As Integer
    Shared g As Graphics
    Private iReste As Integer
    Shared tCell(,) As Cellule

#Region " Code g�n�r� par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()

    End Sub

    'La m�thode substitu�e Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE�: la proc�dure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'�diteur de code.
    Friend WithEvents btnG�n�re As System.Windows.Forms.Button
    Friend WithEvents pic As System.Windows.Forms.PictureBox
    Friend WithEvents lblDimensions As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnG�n�re = New System.Windows.Forms.Button()
        Me.pic = New System.Windows.Forms.PictureBox()
        Me.lblDimensions = New System.Windows.Forms.Label()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnG�n�re
        '
        Me.btnG�n�re.Location = New System.Drawing.Point(16, 15)
        Me.btnG�n�re.Name = "btnG�n�re"
        Me.btnG�n�re.Size = New System.Drawing.Size(150, 42)
        Me.btnG�n�re.TabIndex = 0
        Me.btnG�n�re.Text = "G�n�re"
        '
        'pic
        '
        Me.pic.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic.Location = New System.Drawing.Point(176, 15)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(336, 332)
        Me.pic.TabIndex = 2
        Me.pic.TabStop = False
        '
        'lblDimensions
        '
        Me.lblDimensions.Location = New System.Drawing.Point(16, 133)
        Me.lblDimensions.Name = "lblDimensions"
        Me.lblDimensions.Size = New System.Drawing.Size(144, 29)
        Me.lblDimensions.TabIndex = 3
        Me.lblDimensions.Text = "Taille"
        '
        'frmLabyrinthe
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(528, 358)
        Me.Controls.Add(Me.lblDimensions)
        Me.Controls.Add(Me.pic)
        Me.Controls.Add(Me.btnG�n�re)
        Me.Name = "frmLabyrinthe"
        Me.Text = "Labyrinthe"
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Enum ConstMur As Byte
        kmDroit = 0
        kmGauche = 1
        kmHaut = 2
        kmBas = 3
    End Enum


    Public Class Cellule
        Private m_bVisit� As Boolean
        Private m_tbMur(3) As Boolean
        Private m_l As Integer
        Private m_c As Integer

        Public Sub New(ByVal l As Integer, ByVal c As Integer)
            m_l = l
            m_c = c
            m_bVisit� = False
            m_tbMur(0) = True
            m_tbMur(1) = True
            m_tbMur(2) = True
            m_tbMur(3) = True
            Dessine()
        End Sub

        Public Sub Dessine()
            g.FillRectangle(IIf(m_bVisit�, Brushes.White, Brushes.Yellow), 1 + m_c * kSize, 1 + m_l * kSize, kSize, kSize)

            If m_tbMur(ConstMur.kmHaut) Then
                g.DrawLine(Pens.Black, 1 + m_c * kSize, 1 + m_l * kSize, 1 + m_c * kSize + kSize - 1, 1 + m_l * kSize)
            Else
                g.DrawLine(Pens.White, 1 + m_c * kSize + 1, 1 + m_l * kSize, 1 + m_c * kSize + kSize - 1, 1 + m_l * kSize)
            End If

            If m_tbMur(ConstMur.kmBas) Then
                g.DrawLine(Pens.Black, 1 + m_c * kSize, 1 + (m_l + 1) * kSize, 1 + m_c * kSize + kSize - 1, 1 + (m_l + 1) * kSize)
            Else
                g.DrawLine(Pens.White, 1 + m_c * kSize + 1, 1 + (m_l + 1) * kSize, 1 + m_c * kSize + kSize - 1, 1 + (m_l + 1) * kSize)
            End If

            If m_tbMur(ConstMur.kmGauche) Then
                g.DrawLine(Pens.Black, 1 + m_c * kSize, 1 + m_l * kSize, 1 + m_c * kSize, 1 + m_l * kSize + kSize - 1)
            Else
                g.DrawLine(Pens.White, 1 + m_c * kSize, 1 + m_l * kSize + 1, 1 + m_c * kSize, 1 + m_l * kSize + kSize - 1)
            End If

            If m_tbMur(ConstMur.kmDroit) Then
                g.DrawLine(Pens.Black, 1 + (m_c + 1) * kSize, 1 + m_l * kSize, 1 + (m_c + 1) * kSize, 1 + m_l * kSize + kSize - 1)
            Else
                g.DrawLine(Pens.White, 1 + (m_c + 1) * kSize, 1 + m_l * kSize + 1, 1 + (m_c + 1) * kSize, 1 + m_l * kSize + kSize - 1)
            End If
        End Sub

        Public Property bVisit�() As Boolean
            Get
                Return m_bVisit�
            End Get
            Set(ByVal Value As Boolean)
                m_bVisit� = Value
                Dessine()
            End Set
        End Property

        Public Property bMur(ByVal km As ConstMur) As Boolean
            Get
                Return m_tbMur(km)
            End Get
            Set(ByVal Value As Boolean)
                m_tbMur(km) = Value
                If km = ConstMur.kmHaut And m_l > 0 Then tCell(m_l - 1, m_c).m_tbMur(ConstMur.kmBas) = Value
                If km = ConstMur.kmBas And m_l < Hauteur - 1 Then tCell(m_l + 1, m_c).m_tbMur(ConstMur.kmHaut) = Value
                If km = ConstMur.kmGauche And m_c > 0 Then tCell(m_l, m_c - 1).m_tbMur(ConstMur.kmDroit) = Value
                If km = ConstMur.kmDroit And m_c < Largeur - 1 Then tCell(m_l, m_c + 1).m_tbMur(ConstMur.kmGauche) = Value
                Dessine()
            End Set
        End Property
    End Class

    Private Sub btnG�n�re_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnG�n�re.Click
        Dim l, c As Integer
        For l = 0 To Hauteur - 1
            For c = 0 To Largeur - 1
                tCell(l, c) = New Cellule(l, c)
            Next
        Next
        pic.Refresh()

        iReste = Largeur * Hauteur
        Dim i As Integer, j As Integer

        i = Int(Hauteur * Rnd())
        j = Int(Largeur * Rnd())
        iCreuse(i, j)
        Do While iReste > 0
            Do
                i = Int(Hauteur * Rnd())
                j = Int(Largeur * Rnd())
            Loop While tCell(i, j).bVisit� = False
            If iCreuse(i, j) > 0 Then pic.Refresh()
        Loop


        ' On efface l'entr�e et la sortie
        'Cells(2, Int(2 + Largeur * Rnd())).Borders(xlEdgeTop).LineStyle = xlNone
        'Cells(1 + Hauteur, Int(2 + Largeur * Rnd())).Borders(xlEdgeBottom).LineStyle = xlNone

        MsgBox("Termin�")

    End Sub


    ' Creusage d'une galerie
    Private Function iCreuse(ByVal il As Integer, ByVal ic As Integer) As Integer
        Dim iRet As Integer = 0

        ' Direction d'exploration (au hasard)
        Dim iDir As Integer
        ' 0 = Droite/Est (xlEdgeRight)
        ' 1 = Haut/Nord (xlEdgeTop)
        ' 2 = Gauche/Ouest (xlEdgeLeft)
        ' 3 = Bas/Sud (xlEdgeBottom)

        Do
            ' On marque la cellule visit�e et le compte de cellules restantes si n�cessaire
            ' La premi�re cellule d'une galerie est d�j� visit�e, sauf pour la 1�re galerie
            If tCell(il, ic).bVisit� = False Then
                tCell(il, ic).bVisit� = True
                iReste = iReste - 1
                iRet += 1
            End If

            ' 1�re direction au hasard
            iDir = Int(4 * Rnd())

            Dim ilt As Integer, ict As Integer    ' Cellule voisine � tester
            Dim iNbTest As Integer
            Dim b As ConstMur

            iNbTest = 1
            Do
                Select Case iDir
                    Case 0 ' Droite/Est (xlEdgeRight)
                        ilt = il
                        ict = ic + 1
                        b = ConstMur.kmDroit

                    Case 1 ' Haut/Nord (xlEdgeTop)
                        ilt = il - 1
                        ict = ic
                        b = ConstMur.kmHaut

                    Case 2 ' Gauche/Ouest (xlEdgeLeft)
                        ilt = il
                        ict = ic - 1
                        b = ConstMur.kmGauche

                    Case 3 ' Bas/Sud (xlEdgeBottom)
                        ilt = il + 1
                        ict = ic
                        b = ConstMur.kmBas
                End Select

                If ilt >= 0 And ilt <= Hauteur - 1 And ict >= 0 And ict <= Largeur - 1 Then
                    If tCell(ilt, ict).bVisit� = False Then
                        ' L'ouverture convient
                        Exit Do
                    End If
                End If

                ' Ne convient pas, on tourne
                iDir = (iDir + 1) Mod 4
                iNbTest = iNbTest + 1
                If iNbTest = 5 Then
                    ' Toutes les directions sont bloqu�es: la galerie est termin�e
                    'DoEvents()
                    Return iRet
                End If
            Loop

            ' On efface le bord
            tCell(il, ic).bMur(b) = False

            ' On passe � la nouvelle cellule
            il = ilt
            ic = ict
        Loop

    End Function

    Private Sub frmLabyrinthe_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Largeur = (pic.Size.Width - 4) \ kSize
        Hauteur = (pic.Size.Height - 4) \ kSize
        lblDimensions.Text = CStr(Hauteur) & " x " & CStr(Largeur)
        ReDim tCell(Hauteur - 1, Largeur - 1)
        Dim picBitmap As Bitmap
        picBitmap = New Bitmap(pic.Size.Width, pic.Size.Height, PixelFormat.Format24bppRgb)
        g = Graphics.FromImage(picBitmap)
        g.Clear(Color.FromKnownColor(KnownColor.Control))
        g.FillRectangle(Brushes.Black, 0, 0, kSize * Largeur + 3, kSize * Hauteur + 3)
        pic.BackgroundImage = picBitmap
    End Sub

End Class
