' modRendu - Rendu graphique du convertisseur PCL -> TIF
' 2003-07-17    PV
' 2003-08-07 	PV		Calcul de la largeur avec MeasureCharacterRanges au lieu de MeasureString
' 2003-08-08 	PV		Optimisation pages en N&B et conversion 1 bit 'bestiale'
' 2012-02-25	PV		VS2010
' 2017-05-02 	PV		GitHub et VS2017
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7

Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Text

#Disable Warning IDE0059 ' Unnecessary assignment of a value

Module modRenduGraphique
    Public bTIFFCouleur As Boolean
    Public sNomficImage As String

    Private imgCurrentPage As Bitmap                  ' Page courante, System.Drawing.Bitmap
    Private graCurrentPage As Graphics                ' Page courante, System.Drawing.Graphics
    Private ReadOnly colPages As New Queue  ' Collection des pages sous forme System.Drawing.Bitmap

    Private Const iDPI As Integer = 200                                           ' Résolution X et Y du rendu

    '  Private Const iOutWidth As Integer = 1554, iOutHeight As Integer = 2386    ' A4 exact
    '  Private Const iOutWidth As Integer = 1550, iOutHeight As Integer = 2150    ' Image originale
    Private Const iOutWidth As Integer = 1550, iOutHeight As Integer = 2150

    Class UnePage
        Public imgPage As Bitmap
        Public bPageEnCouleur As Boolean

        Sub New()
            bPageEnCouleur = False
            imgPage = imgCurrentPage
        End Sub

    End Class

    Private PageEnCours As UnePage

    Private Sub CreateNewPage()
        imgCurrentPage = New Bitmap(iOutWidth, iOutHeight, PixelFormat.Format24bppRgb)
        PageEnCours = New UnePage

        imgCurrentPage.SetResolution(iDPI, iDPI)
        colPages.Enqueue(PageEnCours)
        graCurrentPage = Graphics.FromImage(imgCurrentPage)
        graCurrentPage.Clear(Color.White)

        'Dim f As System.Drawing.Font
        'f = New System.Drawing.Font("Arial", 6)
        'graCurrentPage.DrawString(String.Format("Page {0}", colPages.Count), f, System.Drawing.Brushes.Black, 1, 10)
    End Sub

    Sub RGFlushPage()
        graCurrentPage = Nothing
        imgCurrentPage = Nothing
    End Sub

    ' Génère le fichier tiff
    Sub RGOutput()
        If colPages.Count = 0 Then
            Try
                Kill(sNomficImage)
            Catch
            End Try
            Exit Sub
        End If

        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Imaging.Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters
        Dim multi As Bitmap

        Dim p As UnePage = CType(colPages.Dequeue, UnePage)
        If p.bPageEnCouleur Then
            multi = p.imgPage
        Else
            multi = ImgTo1Bit(p.imgPage)
        End If

        'Dim m2 As Bitmap
        'm2 = New Bitmap(iOutWidth, iOutHeight, PixelFormat.Format1bppIndexed)

        ' Get an ImageCodecInfo object that represents the TIFF codec.
        myImageCodecInfo = GetEncoderInfo("image/tiff")
        ' Create an Encoder object based on the GUID
        ' for the SaveFlag parameter category.
        myEncoder = Imaging.Encoder.SaveFlag
        ' Create an EncoderParameters object.
        ' An EncoderParameters object has an array of EncoderParameter
        ' objects. In this case, there is only one
        ' EncoderParameter object in the array.
        myEncoderParameters = New EncoderParameters(1)
        ' Save the first page (frame).
        myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.MultiFrame)
        myEncoderParameters.Param(0) = myEncoderParameter
        multi.Save(sNomficImage, myImageCodecInfo, myEncoderParameters)
        If bVerbose Then WriteLine("Page 1")

        Dim iPage As Integer = 2

        ' Save the second page (frame).
        While colPages.Count > 0
            Dim nextpage As UnePage = CType(colPages.Dequeue, UnePage)
            Dim nextbmp As Bitmap
            If nextpage.bPageEnCouleur Then
                nextbmp = nextpage.imgPage
            Else
                nextbmp = ImgTo1Bit(nextpage.imgPage)
            End If

            myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.FrameDimensionPage)
            myEncoderParameters.Param(0) = myEncoderParameter
            multi.SaveAdd(nextbmp, myEncoderParameters)
            If bVerbose Then WriteLine("Page {0}", iPage)
            iPage += 1
        End While

        ' Close the multiple-frame file.
        myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.Flush)
        myEncoderParameters.Param(0) = myEncoderParameter
        multi.SaveAdd(myEncoderParameters)
    End Sub

    Private Function GetEncoderInfo(mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders() As ImageCodecInfo
        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To UBound(encoders) - 1
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
        Next
        Return Nothing
    End Function

    Private fCurrentFont As Font
    Private sFontName As String
    Private fFontSize As Single
    Private bFontBold As Boolean
    Private bFontItalic As Boolean
    Private bFontUnderline As Boolean
    Private bFontNarrow As Boolean
    Private iGRHMI As Integer                 ' HMI moyen de la police
    Private iGRWMI As Integer

    Private Sub SetFontName(sNewFontName As String)
        If sNewFontName <> sFontName Then
            fCurrentFont = Nothing
            sFontName = sNewFontName
        End If
    End Sub

    Private Sub SetFontSize(fNewFontSize As Single)
        If fNewFontSize <> fFontSize Then
            fCurrentFont = Nothing
            fFontSize = fNewFontSize
        End If
    End Sub

    Private Sub SetFontBold(bNewFontBold As Boolean)
        If bNewFontBold <> bFontBold Then
            fCurrentFont = Nothing
            bFontBold = bNewFontBold
        End If
    End Sub

    Private Sub SetFontItalic(bNewFontItalic As Boolean)
        If bNewFontItalic <> bFontItalic Then
            fCurrentFont = Nothing
            bFontItalic = bNewFontItalic
        End If
    End Sub

    Private Sub SetFontUnderline(bNewFontUnderline As Boolean)
        If bNewFontUnderline <> bFontUnderline Then
            fCurrentFont = Nothing
            bFontUnderline = bNewFontUnderline
        End If
    End Sub

    Private Sub SetFontNarrow(bNewFontNarrow As Boolean)
        If bNewFontNarrow <> bFontNarrow Then
            fCurrentFont = Nothing
            bFontNarrow = bNewFontNarrow
        End If
    End Sub

    Private Function GetFont() As Font
        If fCurrentFont Is Nothing Then
            Dim fs As FontStyle = FontStyle.Regular
            If bFontBold Then fs = fs Or FontStyle.Bold
            If bFontItalic Then fs = fs Or FontStyle.Italic
            If bFontUnderline Then fs = fs Or FontStyle.Underline

            Dim sFN As String = sFontName
            If bFontNarrow And sFN = "Arial" Then sFN = "Arial Narrow"

            Dim rFontSize As Single = CSng(fFontSize * 0.96)
            fCurrentFont = New Font(sFN, rFontSize, fs, GraphicsUnit.Point, 255)

            Dim sf As SizeF
            sf = graCurrentPage.MeasureString(" ", fCurrentFont)
            iGRHMI = CInt(sf.Width)
            iGRWMI = CInt(sf.Height * 0.8)
        End If
        Return fCurrentFont
    End Function

    Function DpToPx(l As Integer) As Integer
        Return Int(0.5 + l / 720 * iDPI)
    End Function

    ' Retourne la taille horizontale du texte en decipoints
    Function RGTextOut(sFontName As String, fFontSize As Single, bFontBold As Boolean, bFontItalic As Boolean, bFontUnderline As Boolean, bFontNarrow As Boolean, x As Integer, y As Integer, sText As String) As Integer
        If imgCurrentPage Is Nothing Then CreateNewPage()
        SetFontName(sFontName)
        SetFontSize(fFontSize)
        SetFontBold(bFontBold)
        SetFontItalic(bFontItalic)
        SetFontUnderline(bFontUnderline)
        SetFontNarrow(bFontNarrow)
        Dim f As Font = GetFont()

        Dim xpx As Integer = DpToPx(x)
        Dim ypx As Integer = DpToPx(y) - iGRWMI

        ' Dessin du texte
        graCurrentPage.DrawString(sText, f, Brushes.Black, xpx, ypx)

        ' Calcul de la taille
        Dim l As Integer

        Dim fmt As New StringFormat
        Dim cr As CharacterRange() = {New CharacterRange(0, Len(sText))}
        fmt.SetMeasurableCharacterRanges(cr)
        Dim layoutRect As New RectangleF(xpx, ypx, iOutWidth, 200)

        Dim stringRegions(1) As Region
        stringRegions = graCurrentPage.MeasureCharacterRanges(sText, f, layoutRect, fmt)
        ' Draw rectangle for first measured range.
        Dim measureRect1 As RectangleF = stringRegions(0).GetBounds(graCurrentPage)
        'graCurrentPage.DrawRectangle(New Pen(Color.Red, 1), Rectangle.Round(measureRect1))
        l = Int(measureRect1.Width / iDPI * 720 + 0.5)

        ' Ancien calcul de la taille, mais MeasureString déborde...
        'Dim s As SizeF = graCurrentPage.MeasureString(sText, f)
        'l = Int(s.Width / iDPI * 720 + 0.5)

        Return l
    End Function

    Function RGNextTab(x As Integer) As Integer
        Dim xp As Integer = DpToPx(x)
        If xp Mod (8 * iGRHMI) <> 0 Then xp = (xp \ (8 * iGRHMI)) * (8 * iGRHMI)
        xp += 8 * iGRHMI
        Return Int(xp / iDPI * 720 + 0.5)
    End Function

    Sub RGRectangle(x As Integer, y As Integer, w As Integer, h As Integer, iFillType As Integer)
        If imgCurrentPage Is Nothing Then CreateNewPage()

        Dim br As Brush
        If iFillType = 1 Then
            br = Brushes.White
        Else
            br = Brushes.Black
        End If

        graCurrentPage.FillRectangle(br, New RectangleF(DpToPx(x), DpToPx(y), DpToPx(w), DpToPx(h)))
    End Sub

    Sub RGPaintBitmap(x As Integer, y As Integer, ByRef tbByte As ArrayList, iWidth As Integer, iHeight As Integer, iDPIRaster As Integer)
        Dim bmpImage3 As New Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb)
        bmpImage3.SetResolution(iDPIRaster, iDPIRaster)
        Dim bdaImage3 As BitmapData

        ' verrue 1: on remonte les images en 150 dpi...
        If iDPIRaster = 150 Then y -= 550

        bdaImage3 = bmpImage3.LockBits(New Rectangle(0, 0, iWidth, iHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
        Dim pData As IntPtr = bdaImage3.Scan0
        Dim RowByteSize As Integer = 3 * iWidth
        Dim pixBytes(RowByteSize) As Byte

        For l As Integer = 0 To tbByte.Count() - 1
            'System.Runtime.InteropServices.Marshal.Copy(pData, pixBytes, 0, RowByteSize)
            Dim r As Byte() = CType(tbByte(l), Byte())
            Dim c As Integer = 0
            Dim i As Integer = 0
            For Each b As Byte In r
                For p As Byte = 0 To 7
                    If b And 128 Then
                        pixBytes(i) = 0
                        pixBytes(i + 1) = 0
                        pixBytes(i + 2) = 0
                    Else
                        pixBytes(i) = 255
                        pixBytes(i + 1) = 255
                        pixBytes(i + 2) = 255
                    End If
                    i += 3
                    c += 1
                    If c >= iWidth Then Exit For
                    b <<= 1
                Next
            Next
            Marshal.Copy(pixBytes, 0, pData, RowByteSize)
            pData = IntPtr.op_Explicit(pData.ToInt32 + bdaImage3.Stride)
        Next
        bmpImage3.UnlockBits(bdaImage3)

        graCurrentPage.DrawImage(bmpImage3, DpToPx(x), DpToPx(y))
    End Sub

    Sub RGPaintBitmap(x As Integer, y As Integer, sNomfic As String)
        Dim bmpImage2 As Bitmap
        Try
            bmpImage2 = Image.FromFile(sNomfic)
        Catch ex As Exception
            WriteLine("Échec à la lecture de {0}: {1}", sNomfic, ex.ToString)
            Exit Sub
        End Try
        Dim k As Single = 850 / bmpImage2.Height
        graCurrentPage.DrawImage(bmpImage2, DpToPx(x), DpToPx(y), bmpImage2.Width * k, bmpImage2.Height * k)
        PageEnCours.bPageEnCouleur = True
    End Sub

End Module

Module modRenduPCL
    Private sPCLText As New StringBuilder

    Class PCLState
        Public posX, posY As Integer              ' Coordonnées en decipoints
        Public VMI As Integer                     ' Hauteur d'une ligne en decipoints
        Public HMI As Integer                     ' Largeur d'un caractère en décipoints
        Public iLeftOffset, iTopOffset As Integer ' Décalage de l'origine en décipoints
        Public sFont As String
        Public fFontSize As Single                ' Taille de la police en points
        Public bFontBold As Boolean
        Public bFontItalic As Boolean
        Public bFontUnderline As Boolean
        Public bFontNarrow As Boolean

        Public iLeftMargin, iTopMargin As Integer ' Marge sur une nouvelle page

        Public iRecWidth, iRectHeight As Integer  ' Taille du rectangle
    End Class

    Private staState As PCLState

    Sub PCLInitJob()
        staState = New PCLState
        With staState
            .iLeftMargin = 360
            .iTopMargin = 360

            .posX = .iLeftMargin
            .posY = .iTopMargin
            .iLeftOffset = .iTopOffset = 0
            .VMI = 720 / 6  ' 6LPI par défaut
            .HMI = 720 / 10 ' 10 CPI par défaut
            .sFont = "Courier New"
            .fFontSize = 10
            .bFontBold = False
            .bFontItalic = False
            .bFontUnderline = False
            .bFontNarrow = False
        End With
    End Sub

    Sub PCLInitPage()
        staState.posX = staState.iLeftMargin
        staState.posY = staState.iTopMargin
    End Sub

    ReadOnly d850 As Decoder = Encoding.GetEncoding(850).GetDecoder

    ' Imprime un caractère imprimable
    ' En pratique, bufférise le caractère
    Sub PCLPrint(b As Byte)
        Select Case b
            Case 12
                ' Saut de page
                PCLFlushText()
                PCLFlushPage()

            Case 9
                ' Tabs à étendre - pour l'instant, on simplifie
                PCLFlushText()
                staState.posX = RGNextTab(staState.posX)

            Case 13
                ' CR
                PCLFlushText()
                ' Retour du curseur à la marge texte de gauche
                staState.posX = staState.iLeftMargin

            Case 10
                ' LF
                PCLFlushText()
                ' Descente du curseur d'une ligne de texte
                staState.posY += staState.VMI

            Case Else
                If b >= 32 Then
                    Dim bytes1 As Byte() = {b}
                    Dim chars(1) As Char
                    Dim charLen As Integer = d850.GetChars(bytes1, 0, bytes1.Length, chars, 0)

                    sPCLText.Append(chars(0))
                Else
                    sPCLText.Append("^" & Chr(b + 64))
                End If
        End Select

    End Sub

    ' "Imprime" le texte bufférisé par PCLPrint
    Sub PCLFlushText()
        If sPCLText.Length = 0 Then Exit Sub

        TraceWrite(Chr(34))
        TraceWrite(sPCLText.ToString)
        TraceWriteLine(Chr(34))

        staState.posX += RGTextOut(staState.sFont, staState.fFontSize, staState.bFontBold, staState.bFontItalic, staState.bFontUnderline, staState.bFontNarrow, staState.iLeftOffset + staState.posX, staState.iTopOffset + staState.posY, sPCLText.ToString)

        sPCLText = New StringBuilder
    End Sub

    ' "Ejecte" la page PCL = ferme la page du rendu graphique, et met à jour l'état PCL
    Sub PCLFlushPage()
        TraceWriteLine("==Saut de page=============================================")
        RGFlushPage()
        PCLInitPage()
    End Sub

    ' <Esc>&a
    Sub PCL38A()
        TraceWrite("[Info: <Esc>&a]")
    End Sub

    Sub PCL38aH(sPosition As String)
        TraceWrite("[Horizontal position {0} decipoints]", sPosition)
        If Left(sPosition, 1) = "+" Or Left(sPosition, 1) = "-" Then
            staState.posX += Val(sPosition)
        Else
            staState.posX = Val(sPosition)
        End If
    End Sub

    Sub PCL38aV(sPosition As String)
        TraceWrite("[Vertical position {0} decipoints]", sPosition)
        If Left(sPosition, 1) = "+" Or Left(sPosition, 1) = "-" Then
            staState.posY += Val(sPosition)
        Else
            staState.posY = Val(sPosition)
        End If
    End Sub

    Sub PCL38aL(iMarge As Integer)
        TraceWrite("[Marge gauche texte = {0} caractères]", iMarge)
    End Sub

    ' <Esc>&l
    Sub PCL38L()
        TraceWrite("[Info: <Esc>&l]")
    End Sub

    Sub PCL38lX(iNbCopies As Integer)
        TraceWrite("[Nb Copies: {0}]", iNbCopies)
    End Sub

    Sub PCL38lD(fLineSpacing As Single)
        TraceWrite("[Set line spacing {0} lines/inch]", fLineSpacing)
        staState.VMI = 720 / fLineSpacing
    End Sub

    Sub PCL38lP(iTaillePage As Integer)
        TraceWrite("[Page size: {0} lines]", iTaillePage)
    End Sub

    Sub PCL38lU(iOffset As Integer)
        TraceWrite("[Long-Edge (Left) Offset Registration: {0} decipoints]", iOffset)
        staState.iLeftOffset = iOffset
    End Sub

    Sub PCL38lZ(iOffset As Integer)
        TraceWrite("[Short Edge (Top) Offset Registration: {0} decipoints]", iOffset)
        staState.iTopOffset = iOffset
    End Sub

    Sub PCL38lE(iTopMargin As Integer)
        TraceWrite("[Top Marginmargin: {0} lines]", iTopMargin)
    End Sub

    Sub PCL38lL(iSkip As Integer)
        Select Case iSkip
            Case 0 : TraceWrite("[Perforation Skip Disable]")
            Case 1 : TraceWrite("[Perforation Skip Enable]")
            Case Else : TraceWrite("[?]")
        End Select
    End Sub

    ' <Esc>&d
    Sub PCL38D()
        TraceWrite("[Info: <Esc>&d]")
    End Sub

    Sub PCL38dD(iTypeSoul As Integer)
        Select Case iTypeSoul
            Case 0
                TraceWrite("[Fixed Underline]")
                staState.bFontUnderline = True

            Case 3
                TraceWrite("[Floating Underline]")
                staState.bFontUnderline = True

            Case Else
                PCLError("Séquence <Esc>&d" & iTypeSoul & "D inconnue")
        End Select
    End Sub

    Sub PCL38dArobas()
        TraceWrite("[Disable Underline]")
        staState.bFontUnderline = False
    End Sub

    ' <Esc>(#U
    Sub PCL40U(iJeuCar As Integer)
        TraceWrite("[Jeu de caractères {0}]", iJeuCar)
        Select Case iJeuCar
            Case 10
                ' PC-8
            Case Else
                PCLError("Jeu de caractères <Esc>(" & iJeuCar & "U non pris en charge")
        End Select
    End Sub

    ' <Esc>(s
    Sub PCL40S()
        TraceWrite("[Info: <Esc>(s]")
    End Sub

    ' <Esc>(s#P
    Sub PCL40sP(iType As Integer)
        Select Case iType
            Case 0
                TraceWrite("[Sélection police fixe]")
                staState.sFont = "Courier New"
            Case 1
                TraceWrite("[Sélection police proportionnelle]")
                staState.sFont = "Arial"
            Case Else
                PCLError("Séquence <Esc>(s" & iType & "P inconnue")
        End Select
    End Sub

    ' <Esc>(s#H
    Sub PCL40sH(fPitch As Single)
        TraceWrite("[Sélection pas horizontal police {0} points/pouce]", fPitch)
        staState.fFontSize = 120 / fPitch
    End Sub

    ' <Esc>(s#V
    Sub PCL40sV(fHauteur As Single)
        TraceWrite("[Sélection hauteur police {0} points]", fHauteur)
        staState.fFontSize = fHauteur
    End Sub

    ' <Esc>(s#S
    Sub PCL40sS(iItalique As Single)
        Select Case iItalique
            Case 0
                TraceWrite("[Sélection police normale (pas italique)]")
                staState.bFontItalic = False
                staState.bFontNarrow = False
            Case 1
                TraceWrite("[Sélection police italique]")
                staState.bFontItalic = True
            Case 4
                TraceWrite("[Sélection police narrow]")
                staState.bFontNarrow = True
            Case Else
                PCLError("Séquence <Esc>(s" & iItalique & "S inconnue")
        End Select
    End Sub

    ' <Esc>(s#B
    Sub PCL40sB(iGraise As Integer)
        Select Case iGraise
            Case 0
                TraceWrite("[Sélection police normale (non grasse)]")
                staState.bFontBold = False

            Case 3
                TraceWrite("[Sélection police grasse")
                staState.bFontBold = True

            Case Else
                TraceWrite("[Selection police graisse {0}]", iGraise)
                PCLError("Séquence <Esc>(s" & iGraise & "B non prise en charge")
        End Select
    End Sub

    ' <Esc>(s#T
    Sub PCL40sT(iFont As Integer)
        TraceWrite("[Sélection police n° {0}]", iFont)
        ' On ignore pour l'instant
        ' Police fixe: courier new, Police proportionnelle: arial
    End Sub

    ' <Esc>*c
    Sub PCL42C()
        TraceWrite("[Info: <Esc>&c]")
    End Sub

    Sub PCL42cA(iSize As Integer)
        TraceWrite("[Rectangle width {0} dots]", iSize)
        staState.iRecWidth = iSize * 720 / 300
    End Sub

    Sub PCL42cB(iSize As Integer)
        TraceWrite("[Rectangle height {0} dots]", iSize)
        staState.iRectHeight = iSize * 720 / 300
    End Sub

    Sub PCL42cH(iSize As Integer)
        TraceWrite("[Rectangle width {0} decipoints]", iSize)
        staState.iRecWidth = iSize
    End Sub

    Sub PCL42cV(iSize As Integer)
        TraceWrite("[Rectangle height {0} decipoints]", iSize)
        staState.iRectHeight = iSize
    End Sub

    Sub PCL42cP(iFillType As Integer)
        TraceWrite("[Fill Rectangle, type {0}]", iFillType)
        If iFillType = 0 Or iFillType = 1 Then
            RGRectangle(staState.posX, staState.posY, staState.iRecWidth, staState.iRectHeight, iFillType)
        Else
            PCLError("Fill Rectangle, Fill type " & iFillType.ToString & " non pris en charge")
        End If
    End Sub

    ' <Esc>*t
    Sub PCL42T()
        TraceWrite("[Info: <Esc>*t]")
    End Sub

    Class RasterClass
        Public iResolution As Integer
        Public iWidth, iHeight As Integer
        Public tabLignes As ArrayList
    End Class

    ReadOnly rasRaster As New RasterClass

    Sub PCL42tR(iResolution As Integer)
        TraceWrite("[Raster Resolution {0} dpi]", iResolution)
        rasRaster.iResolution = iResolution
        rasRaster.iWidth = 0
        rasRaster.iHeight = 0
    End Sub

    ' <Esc>*p
    Sub PCL42P()
        TraceWrite("[Info: <Esc>*t]")
    End Sub

    ' dot = 1/300è de pouce
    Sub PCL42pX(sPosition As String)
        TraceWrite("[Cursor Horizontal Position {0} dots]", sPosition)
        If Left(sPosition, 1) = "+" Or Left(sPosition, 1) = "-" Then
            staState.posX += Val(sPosition) / 300 * 720
        Else
            staState.posX = Val(sPosition) / 300 * 720
        End If
    End Sub

    Sub PCL42pY(sPosition As Integer)
        TraceWrite("[Cursor Vertical Position {0} dots]", sPosition)
        If Left(sPosition, 1) = "+" Or Left(sPosition, 1) = "-" Then
            staState.posY += Val(sPosition) / 300 * 720
        Else
            staState.posY = Val(sPosition) / 300 * 720
        End If
    End Sub

    ' <Esc>*r
    Sub PCL42R()
        TraceWrite("[Info: <Esc>*r]")
    End Sub

    Sub PCL42rA(iLeftPos As Integer)
        Select Case iLeftPos
            Case 0 : TraceWrite("[Start Raster Graphics: Left Raster Graphics Margin]")
            Case 1 : TraceWrite("[Start Raster Graphics: Current Cursor]")
            Case Else
                PCLError("Séquence <Esc>*r" & iLeftPos & "A inconnue")
                Exit Sub
        End Select

        rasRaster.tabLignes = New ArrayList
    End Sub

    Sub PCL42rB()
        TraceWrite("[End Raster Graphics]")

        Dim lmax As Integer = -1
        For Each b As Byte() In rasRaster.tabLignes
            If b.GetLength(0) > lmax Then lmax = b.GetLength(0)
        Next
        If rasRaster.iWidth = 0 Then rasRaster.iWidth = 8 * lmax

        TraceWriteLine("Fin graphique, {0} lignes, largeur max {1} octets, raster width {2} pixels", rasRaster.tabLignes.Count, lmax, rasRaster.iWidth)
        RGPaintBitmap(staState.posX, staState.posY, rasRaster.tabLignes, rasRaster.iWidth, rasRaster.tabLignes.Count, rasRaster.iResolution)

        'Static iImage As Integer
        'Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter("image" & iImage.ToString & ".txt")
        'iImage += 1
        'Dim bVirgule As Boolean
        'For Each b In rasRaster.tabLignes
        '  sw.Write("    tbByte.Add(New Byte() {")
        '  bVirgule = False
        '  For Each by As Byte In CType(b, Byte())
        '    If bVirgule Then sw.Write(","c)
        '    sw.Write(by)
        '    bVirgule = True
        '  Next
        '  sw.WriteLine("})")
        'Next
        'sw.Close()

    End Sub

    Sub PCL42rS(iWidth As Integer)
        TraceWrite("[Raster Width: {0} pixels of specified resolution]", iWidth)
        rasRaster.iWidth = iWidth
    End Sub

    Sub PCL42rT(iHeight As Integer)
        TraceWrite("[Raster Height: {0} rows]", iHeight)
        rasRaster.iHeight = iHeight
    End Sub

    ' <Esc>*b
    Sub PCL42B()
        TraceWrite("[Info: <Esc>*b]")
    End Sub

    Sub PCL42bW(iBytes As Integer)
        TraceWrite("[Séquence graphique {0} octets]", iBytes)
    End Sub

    Sub PCL42bWData(ByRef tbData() As Byte)
        TraceWrite("[Data: ")
        For Each b As Byte In tbData
            TraceWrite("{0} ", b)
        Next
        TraceWriteLine("]")

        rasRaster.tabLignes.Add(tbData)
    End Sub

    Sub PCLTildaInsèrePhoto(sNomfic As String)
        RGPaintBitmap(staState.posX, staState.posY, sNomfic)
    End Sub

End Module

' Conversion 'bestiale' d'image 24 bits en 1 bit
' On travaille sur les séquences d'octets, c'est ce qu'il y a de plus rapide
' la fonction bmp.GetPixel(x,y) est d'une lenteur effroyable...

Module modConversionImage1Bit

    Public Function ImgTo1Bit(ByRef imgSource As Bitmap) As Bitmap
        If bTIFFCouleur Then Return imgSource

        Dim b1 As New Bitmap(imgSource.Width, imgSource.Height, PixelFormat.Format1bppIndexed)
        Dim b1d As BitmapData = b1.LockBits(New Rectangle(0, 0, b1.Width, b1.Height), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed)

        Dim b24d As BitmapData = imgSource.LockBits(New Rectangle(0, 0, b1.Width, b1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)

        Dim pData1 As IntPtr = b1d.Scan0
        Dim pData24 As IntPtr = b24d.Scan0

        Dim tbRow1(b1d.Stride) As Byte
        Dim tbRow24(b24d.Stride) As Byte

        Dim ibyte As Integer
        Dim mbit As Byte

        For y As Integer = 0 To b1.Height - 1
            ibyte = 0
            mbit = 128

            ' On remplit la ligne de sortie de blanc
            For i As Integer = 0 To b1d.Stride - 1
                tbRow1(i) = 255
            Next

            ' On récupère une ligne de l'image couleur
            Marshal.Copy(pData24, tbRow24, 0, b24d.Stride)

            For x As Integer = 0 To b1.Width - 1
                If tbRow24(3 * x) < 128 Then
                    tbRow1(ibyte) = tbRow1(ibyte) And Not mbit
                End If

                If mbit = 1 Then
                    mbit = 128
                    ibyte += 1
                Else
                    mbit >>= 1
                End If
            Next

            ' On dessine une ligne de sortie
            Marshal.Copy(tbRow1, 0, pData1, b1d.Stride)

            pData1 = IntPtr.op_Explicit(pData1.ToInt32 + b1d.Stride)
            pData24 = IntPtr.op_Explicit(pData24.ToInt32 + b24d.Stride)
        Next
        b1.UnlockBits(b1d)

        Return b1
    End Function

End Module
