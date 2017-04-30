' frmLogoEtiq
' Décodage/Encodage de logos pour imprimante Facit
' 2003-08-05    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Public Class frmAnalyse
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents btnAnalyse As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnEncode As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnVérifie As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnAnalyse = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.btnEncode = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnVérifie = New System.Windows.Forms.Button
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'btnAnalyse
        '
        Me.btnAnalyse.Location = New System.Drawing.Point(128, 24)
        Me.btnAnalyse.Name = "btnAnalyse"
        Me.btnAnalyse.TabIndex = 0
        Me.btnAnalyse.Text = "Analyse"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(8, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(112, 112)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(8, 168)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(112, 112)
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'btnEncode
        '
        Me.btnEncode.Location = New System.Drawing.Point(128, 168)
        Me.btnEncode.Name = "btnEncode"
        Me.btnEncode.TabIndex = 3
        Me.btnEncode.Text = "Encode"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Décodage logo original"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(8, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Encodage logo SGS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(216, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(195, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Décodage du nouveau logo généré"
        '
        'btnVérifie
        '
        Me.btnVérifie.Location = New System.Drawing.Point(336, 168)
        Me.btnVérifie.Name = "btnVérifie"
        Me.btnVérifie.TabIndex = 7
        Me.btnVérifie.Text = "Vérifie"
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(216, 168)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(112, 112)
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'frmAnalyse
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 286)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnVérifie)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEncode)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnAnalyse)
        Me.Name = "frmAnalyse"
        Me.Text = "Analyse Image Etiq"
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region " Définition tsBmp "

    Dim tsBmp() As String = {
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFF87E1FFFC07FFC007F1FFFE3FFF",
  "800EFF87E1FFF801FFC007F1FFFE3FFF",
  "800EFF83E0FFE1F0FFC007F1FFFE3FFF",
  "800EFF83E0FFE3FC7FC7FFF1FFFE3FFF",
  "800EFF23ECFFE3FC7FC7FFF1FFFE3FFF",
  "800EFF31CC7FC7FE3FC7FFF1FFFE3FFF",
  "800EFE31CE7FC7FE3FC7FFF1FFFE3FFF",
  "800EFE39CE7FC7FE3FC7FFF001FE003F",
  "800EFC398E7FC7FE3FC7FFF001FE003F",
  "800EFC798F7FC7FE3FC7FFF1FFFE3FFF",
  "800EFC7D8F3FC3FC3FC7FFF1FFFE3FFF",
  "800EFCFD9F3FE3FC7FC7FFF1FFFE3FFF",
  "800EFCFC1F1FF0F0FFC7FFF1FFFE3FFF",
  "800EFCFC1F1FF000FFC7FFF000FE003F",
  "800EF8FC3F8FFE07FFC7FFF000FE003F",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFF7FFFDDFFFFFF",
  "800EFFFFFFFFFFFFFFEF7FFF9CFFFFFF",
  "800EFFFFFFFFFFFFFFEF3FFF9CFFFFFF",
  "800EFFFFFFFFFFFFFFCF0FFE1C7FFFFF",
  "800EFFFFFFFFFFFFFF8F0FFE1C3FFFFF",
  "800EFFFFFFFFFFFFFF0F03F81C3FFFFF",
  "800EFFFFFFFFFFFFFF0F03F01C1FFFFF",
  "800EFFFFFFFFFFFFFE0F01F01C0FFFFF",
  "800EFFFFFFFFFFFFFC0F01E01C07FFFF",
  "800EFFFFFFFFFFFFF80F01E01C07FFFF",
  "800EFFFFFFFFFFFFF00F01E01C01FFFF",
  "800EFFFFFFFFFFFFE00F01E01C01FFFF",
  "800EFFFFFFFFFFFFE00F01E01C00FFFF",
  "800EFFFFFFFFFFFFC00F01E01C007FFF",
  "800EFFFFFFFFFFFF800F01E01C003FFF",
  "800EFFFFFFFFFFFF000F01E01C001FFF",
  "800EFFFFFFFFFFFF000F01E01C001FFF",
  "800EFFFFFFFFFFFE000F01E01C000FFF",
  "800EFFFFFFFBFFFC000F01E01C0007FF",
  "800EFFFFFF7BFFF8000F01E01C0003FF",
  "800EFFFFFF78FFF0000F01E01C0001FF",
  "800EFFFFFE787FF0000F01E01C0001FF",
  "800EFFFFF8783FC0000F81E03C00007F",
  "800EFFFFF8781FC0001FC1E07E00007F",
  "800EFFFFF8781F80003FE1E0FF00007F",
  "800EFFFFE0780F80003FF1E1FF80003F",
  "800EFFFFE0780F8000FFF9E3FFC0003F",
  "800EFFFFC0780F8001FFF9E7FFE0003F",
  "800EFFFF80780F8001FFFDEFFFE0003F",
  "800EFFFF00780F8003FFFFFFFFF0003F",
  "800EFFFF00780F8007FFFFFFFFF8003F",
  "800EFFFE00780F8007FFFFFFFFFC003F",
  "800EFFFC00780F800FFFFFFFFFFE003F",
  "800EFFF800780F801FFFFFFFFFFE003F",
  "800EFFF800780F803FFFFFFFFFFF003F",
  "800EFFE000780F803FFFFFFFFFFF803F",
  "800EFFE000780F80FFFFFFFFFFFFC03F",
  "800EFFC000780F80FFFFFFFFFFFFE03F",
  "800EFF8000780F80FFFFFFFFFFFFE03F",
  "800EFF8000780F83FFFFFFFFFFFFF83F",
  "800EFE00007C0F87FFFFFFFFFFFFF83F",
  "800EFE0001FE0F87FFFFFFFFFFFFFC3F",
  "800EFC0001FF0F8FFFFFFFFFFFFFFE3F",
  "800EFC0001FF8F9FFFFFFFFFFFFFFF3F",
  "800EFC0007FFCFBFFFFFFFFFFFFFFFBF",
  "800EFC000FFFCFBFFFFFFFFFFFFFFFBF",
  "800EFC000FFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC001FFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC003FFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC003FFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC007FFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC01FFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC01FFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC01FFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC07FFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC07FFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC0FFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC1FFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC3FFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC3FFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFC7FFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFCFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFDFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFDFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF"}

    Dim tsBmp2() As String = {
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800EFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
  "800E000001FFFF8007FFFFF07FFFF180",
  "800E000003FFFFE00FFFFFF0FFFFF980",
  "800E000007FFFFF01FFFFFF1FFFFFD80",
  "800E00000FFFFFF03FFFFFF1FFFFFF80",
  "800E00000FFFFFF87FFFFFF3FFFFFF80",
  "800E00001FFFFFF87FF8FFF3FFFFFF80",
  "800E00001FF81FFCFFE03FF7FF03FF80",
  "800E00001FF80FFCFFC03FF7FE03FF80",
  "800E00001FF00FFCFFC03FF7FE01FF80",
  "800E00001FF00FFCFF803FF7FE01FF80",
  "800E00001FF00FFDFF803FF7FE01FF80",
  "800E00001FF00FFDFF803FF7FE03FF80",
  "800E00001FF01FFDFF803FF7FE03FF80",
  "800E000000003FFDFF803FF00007FF80",
  "800E000000007FFDFF87FFF0001FFF80",
  "800E00000000FFF9FF87FFF0003FFF80",
  "800E00000003FFF9FF87FFF000FFFF80",
  "800E0000000FFFF1FF87FFF001FFFD80",
  "800E0000001FFFE1FF87FFF007FFFD80",
  "800E0000007FFFC1FF87FFF00FFFF980",
  "800E000000FFFF81FF87FFF03FFFE180",
  "800E000001FFFF01FF87FFF07FFFC180",
  "800E000003FFFC01FF800000FFFF8180",
  "800E000007FFF801FF800000FFFE0180",
  "800E000007FFE001FF800001FFF80180",
  "800E00000FFF8001FF800003FFE00180",
  "800E00000FFE0001FF800003FFC00180",
  "800E00000FFC0001FF800003FF800180",
  "800E00001FFC0001FF803FF3FF000180",
  "800E00001FF80FFDFF803FF7FF01FF80",
  "800E00001FF80FFCFF803FF7FE01FF80",
  "800E00001FF80FFCFFC03FF3FE01FF80",
  "800E00001FF80FFCFFC03FE3FE03FF80",
  "800E00000FF81FF8FFE07FE3FF03FF80",
  "800E00000FFE3FF87FF1FFE3FF87FF80",
  "800E00000FFFFFF87FFFFFC1FFFFFF80",
  "800E000007FFFFF03FFFFFC1FFFFFF80",
  "800E000003FFFFF01FFFFF80FFFFFD80",
  "800E000003FFFFE00FFFFF007FFFF980",
  "800E000000FFFFC007FFFE003FFFF180",
  "800E0000007FFF0001FFF8000FFFE180",
  "800E00000007F800003FC00001FF0180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000180",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000",
  "800E0000000000000000000000000000"}

#End Region

    Private Sub btnAnalyse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyse.Click
        Dim bmp As New Bitmap(112, 112, Imaging.PixelFormat.Format24bppRgb)

        Dim l, c, c2, col As Integer
        For l = 0 To 111
            col = 0
            For c = 5 To 31 Step 2
                Dim b As Byte = Val("&H" & Mid(tsBmp(l), c, 2))
                For c2 = 0 To 7
                    bmp.SetPixel(col, l, IIf(b And 128, Color.Black, Color.White))
                    col += 1
                    b <<= 1
                Next
            Next
        Next

        bmp.RotateFlip(RotateFlipType.Rotate180FlipX)
        Dim sPath As String = My.Application.Info.DirectoryPath.Replace("\bin", "")
        bmp.Save(sPath & "\oldImage.gif", System.Drawing.Imaging.ImageFormat.Gif)

        PictureBox1.Image = bmp
    End Sub

    Private Sub btnEncode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncode.Click
        Dim sPath As String = My.Application.Info.DirectoryPath.Replace("\bin", "")
        Dim sw As New System.IO.StreamWriter(sPath & "\LogoSGS.txt")
        Dim bmp As Bitmap
        bmp = PictureBox2.Image
        bmp.RotateFlip(RotateFlipType.Rotate180FlipX)
        For l As Integer = 0 To 111
            sw.Write("800E")
            Dim b As Byte
            For c As Integer = 0 To 111
                If (c Mod 8) = 0 Then b = 0 Else b <<= 1
                If bmp.GetPixel(c, l).B() < 128 Then b += 1
                If (c Mod 8) = 7 Then sw.Write("{0:X2}", b)
            Next
            sw.WriteLine()
        Next
        sw.Close()
    End Sub

    Private Sub frmAnalyse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sPath As String = My.Application.Info.DirectoryPath.Replace("\bin", "")
        PictureBox2.Image = Image.FromFile(sPath & "\LogoSGS.bmp")
    End Sub

    Private Sub btnVérifie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVérifie.Click
        Dim bmp As New Bitmap(112, 112, Imaging.PixelFormat.Format24bppRgb)

        Dim l, c, c2, col As Integer
        For l = 0 To 111
            col = 0
            For c = 5 To 31 Step 2
                Dim b As Byte = Val("&H" & Mid(tsBmp2(l), c, 2))
                For c2 = 0 To 7
                    bmp.SetPixel(col, l, IIf(b And 128, Color.Black, Color.White))
                    col += 1
                    b <<= 1
                Next
            Next
        Next

        bmp.RotateFlip(RotateFlipType.Rotate180FlipX)
        PictureBox3.Image = bmp

    End Sub
End Class
