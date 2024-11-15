﻿' Labyrinthe .Net
'
' 2002-03-24    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.ComponentModel
Imports System.Drawing.Imaging

#Disable Warning IDE1006 ' Naming Styles

Public Class frmLabyrinthe
    Inherits Form

    Private Const kSize As Integer = 10
    Private Shared Largeur As Integer
    Private Shared Hauteur As Integer
    Private Shared g As Graphics
    Private iReste As Integer
    Private Shared tCell(,) As Cellule

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

    Friend WithEvents pic As PictureBox
    Friend WithEvents lblDimensions As Label

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        btnGénère = New Button()
        pic = New PictureBox()
        lblDimensions = New Label()
        CType(pic, ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'btnGénère
        '
        btnGénère.Location = New Point(16, 15)
        btnGénère.Name = "btnGénère"
        btnGénère.Size = New Size(150, 42)
        btnGénère.TabIndex = 0
        btnGénère.Text = "Génère"
        '
        'pic
        '
        pic.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom _
            Or AnchorStyles.Left _
            Or AnchorStyles.Right
        pic.Location = New Point(176, 15)
        pic.Name = "pic"
        pic.Size = New Size(336, 332)
        pic.TabIndex = 2
        pic.TabStop = False
        '
        'lblDimensions
        '
        lblDimensions.Location = New Point(16, 133)
        lblDimensions.Name = "lblDimensions"
        lblDimensions.Size = New Size(144, 29)
        lblDimensions.TabIndex = 3
        lblDimensions.Text = "Taille"
        '
        'frmLabyrinthe
        '
        AutoScaleBaseSize = New Size(10, 24)
        ClientSize = New Size(528, 358)
        Controls.Add(lblDimensions)
        Controls.Add(pic)
        Controls.Add(btnGénère)
        Name = "frmLabyrinthe"
        Text = "Labyrinthe"
        CType(pic, ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

#End Region

    Public Enum ConstMur As Byte
        kmDroit = 0
        kmGauche = 1
        kmHaut = 2
        kmBas = 3
    End Enum

    Public Class Cellule
        Private m_bVisité As Boolean
        Private ReadOnly m_tbMur(3) As Boolean
        Private ReadOnly m_l As Integer
        Private ReadOnly m_c As Integer

        Public Sub New(l As Integer, c As Integer)
            m_l = l
            m_c = c
            m_bVisité = False
            m_tbMur(0) = True
            m_tbMur(1) = True
            m_tbMur(2) = True
            m_tbMur(3) = True
            Dessine()
        End Sub

        Public Sub Dessine()
            g.FillRectangle(IIf(m_bVisité, Brushes.White, Brushes.Yellow), 1 + (m_c * kSize), 1 + (m_l * kSize), kSize, kSize)

            If m_tbMur(ConstMur.kmHaut) Then
                g.DrawLine(Pens.Black, 1 + (m_c * kSize), 1 + (m_l * kSize), 1 + (m_c * kSize) + kSize - 1, 1 + (m_l * kSize))
            Else
                g.DrawLine(Pens.White, 1 + (m_c * kSize) + 1, 1 + (m_l * kSize), 1 + (m_c * kSize) + kSize - 1, 1 + (m_l * kSize))
            End If

            If m_tbMur(ConstMur.kmBas) Then
                g.DrawLine(Pens.Black, 1 + (m_c * kSize), 1 + ((m_l + 1) * kSize), 1 + (m_c * kSize) + kSize - 1, 1 + ((m_l + 1) * kSize))
            Else
                g.DrawLine(Pens.White, 1 + (m_c * kSize) + 1, 1 + ((m_l + 1) * kSize), 1 + (m_c * kSize) + kSize - 1, 1 + ((m_l + 1) * kSize))
            End If

            If m_tbMur(ConstMur.kmGauche) Then
                g.DrawLine(Pens.Black, 1 + (m_c * kSize), 1 + (m_l * kSize), 1 + (m_c * kSize), 1 + (m_l * kSize) + kSize - 1)
            Else
                g.DrawLine(Pens.White, 1 + (m_c * kSize), 1 + (m_l * kSize) + 1, 1 + (m_c * kSize), 1 + (m_l * kSize) + kSize - 1)
            End If

            If m_tbMur(ConstMur.kmDroit) Then
                g.DrawLine(Pens.Black, 1 + ((m_c + 1) * kSize), 1 + (m_l * kSize), 1 + ((m_c + 1) * kSize), 1 + (m_l * kSize) + kSize - 1)
            Else
                g.DrawLine(Pens.White, 1 + ((m_c + 1) * kSize), 1 + (m_l * kSize) + 1, 1 + ((m_c + 1) * kSize), 1 + (m_l * kSize) + kSize - 1)
            End If
        End Sub

        Public Property bVisité() As Boolean
            Get
                Return m_bVisité
            End Get
            Set(Value As Boolean)
                m_bVisité = Value
                Dessine()
            End Set
        End Property

        Public Property bMur(km As ConstMur) As Boolean
            Get
                Return m_tbMur(km)
            End Get
            Set(Value As Boolean)
                m_tbMur(km) = Value
                If km = ConstMur.kmHaut And m_l > 0 Then tCell(m_l - 1, m_c).m_tbMur(ConstMur.kmBas) = Value
                If km = ConstMur.kmBas And m_l < Hauteur - 1 Then tCell(m_l + 1, m_c).m_tbMur(ConstMur.kmHaut) = Value
                If km = ConstMur.kmGauche And m_c > 0 Then tCell(m_l, m_c - 1).m_tbMur(ConstMur.kmDroit) = Value
                If km = ConstMur.kmDroit And m_c < Largeur - 1 Then tCell(m_l, m_c + 1).m_tbMur(ConstMur.kmGauche) = Value
                Dessine()
            End Set
        End Property

    End Class

    Private Sub btnGénère_Click(sender As Object, e As EventArgs) Handles btnGénère.Click
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
            Loop While Not tCell(i, j).bVisité

            If iCreuse(i, j) > 0 Then pic.Refresh()
        Loop

        ' On efface l'entrée et la sortie
        'Cells(2, Int(2 + Largeur * Rnd())).Borders(xlEdgeTop).LineStyle = xlNone
        'Cells(1 + Hauteur, Int(2 + Largeur * Rnd())).Borders(xlEdgeBottom).LineStyle = xlNone

        MsgBox("Terminé")

    End Sub

    ' Creusage d'une galerie
    Private Function iCreuse(il As Integer, ic As Integer) As Integer
        Dim iRet As Integer = 0

        ' Direction d'exploration (au hasard)
        Dim iDir As Integer
        ' 0 = Droite/Est (xlEdgeRight)
        ' 1 = Haut/Nord (xlEdgeTop)
        ' 2 = Gauche/Ouest (xlEdgeLeft)
        ' 3 = Bas/Sud (xlEdgeBottom)

        Do
            ' On marque la cellule visitée et le compte de cellules restantes si nécessaire
            ' La première cellule d'une galerie est déjà visitée, sauf pour la 1ère galerie
            If Not tCell(il, ic).bVisité Then
                tCell(il, ic).bVisité = True
                iReste -= 1
                iRet += 1
            End If

            ' 1ère direction au hasard
            iDir = Int(4 * Rnd())

            Dim ilt As Integer, ict As Integer    ' Cellule voisine à tester
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
                    If Not tCell(ilt, ict).bVisité Then
                        ' L'ouverture convient
                        Exit Do
                    End If
                End If

                ' Ne convient pas, on tourne
                iDir = (iDir + 1) Mod 4
                iNbTest += 1
                If iNbTest = 5 Then
                    ' Toutes les directions sont bloquées: la galerie est terminée
                    'DoEvents()
                    Return iRet
                End If
            Loop

            ' On efface le bord
            tCell(il, ic).bMur(b) = False

            ' On passe à la nouvelle cellule
            il = ilt
            ic = ict
        Loop

    End Function

    Private Sub frmLabyrinthe_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Largeur = (pic.Size.Width - 4) \ kSize
        Hauteur = (pic.Size.Height - 4) \ kSize
        lblDimensions.Text = Hauteur & " x " & Largeur
        ReDim tCell(Hauteur - 1, Largeur - 1)
        Dim picBitmap As Bitmap
        picBitmap = New Bitmap(pic.Size.Width, pic.Size.Height, PixelFormat.Format24bppRgb)
        g = Graphics.FromImage(picBitmap)
        g.Clear(Color.FromKnownColor(KnownColor.Control))
        g.FillRectangle(Brushes.Black, 0, 0, (kSize * Largeur) + 3, (kSize * Hauteur) + 3)
        pic.BackgroundImage = picBitmap
    End Sub

End Class
