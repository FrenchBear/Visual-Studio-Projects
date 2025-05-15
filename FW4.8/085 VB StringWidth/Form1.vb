' 85 VB StringWidth
' Essais de mesure de Chaîne de caract�res
' 2003-08-07    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

#Disable Warning IDE0059 ' Unnecessary assignment of a value

Public Class Form1
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
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As System.ComponentModel.IContainer

    'REMARQUE�: la Procédure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'�diteur de code.
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(428, 430)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        MeasureStringSizeFFormatInts(e)
        MeasureCharacterRangesRegions(e)
    End Sub

    Public Sub MeasureStringSizeFFormatInts(e As PaintEventArgs)
        ' Set up string.
        Dim measureString As String = "Measure String"
        Dim stringFont As New Font("Arial", 16)
        ' Set maximum layout size.
        Dim layoutSize As New SizeF(100.0F, 200.0F)
        ' Set string format.
        Dim newStringFormat As New StringFormat With {
            .FormatFlags = StringFormatFlags.DirectionVertical
        }
        ' Measure string.
        Dim charactersFitted As Integer
        Dim linesFilled As Integer
        Dim stringSize As New SizeF
        stringSize = e.Graphics.MeasureString(measureString, stringFont, layoutSize, newStringFormat, charactersFitted, linesFilled)
        ' Draw rectangle representing size of string.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), 0.0F, 0.0F, stringSize.Width, stringSize.Height)
        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, New PointF(0, 0), newStringFormat)
        ' Draw output parameters to screen.
        Dim outString As String = "chars " & charactersFitted & ", lines " & linesFilled
        e.Graphics.DrawString(outString, stringFont, Brushes.Black, New PointF(100, 0))
    End Sub

    Public Sub MeasureCharacterRangesRegions(e As PaintEventArgs)
        ' Set up string.
        Dim measureString As String = "First and Second ranges"
        Dim stringFont As New Font("Times New Roman", 16.0F)
        ' Set character ranges to "First" and "Second".
        Dim characterRanges As CharacterRange() = {New CharacterRange(0, 5), New CharacterRange(10, 6)}
        ' Create rectangle for layout.
        Dim x As Single = 50.0F
        Dim y As Single = 50.0F
        Dim width As Single = 35.0F
        Dim height As Single = 200.0F
        Dim layoutRect As New RectangleF(x, y, width, height)
        ' Set string format.
        Dim stringFormat As New StringFormat With {
            .FormatFlags = StringFormatFlags.DirectionVertical
        }
        stringFormat.SetMeasurableCharacterRanges(characterRanges)
        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, x, y, stringFormat)
        ' Measure two ranges in string.
        Dim stringRegions(2) As Region
        stringRegions = e.Graphics.MeasureCharacterRanges(measureString, stringFont, layoutRect, stringFormat)
        ' Draw rectangle for first measured range.
        Dim measureRect1 As RectangleF = stringRegions(0).GetBounds(e.Graphics)
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), Rectangle.Round(measureRect1))
        ' Draw rectangle for second measured range.
        Dim measureRect2 As RectangleF = stringRegions(1).GetBounds(e.Graphics)
        e.Graphics.DrawRectangle(New Pen(Color.Blue, 1), Rectangle.Round(measureRect2))
    End Sub

End Class