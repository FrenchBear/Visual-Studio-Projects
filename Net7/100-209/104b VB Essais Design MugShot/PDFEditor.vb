' PDFEditor UserControl
' PDF edit/view control
'
' 2006-04-13 	PV		First version
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6 (Note: this doesn't work in Net6, will check it later)
' 2023-01-10	PV		Net7

Option Compare Text

Imports System.ComponentModel
Imports AcroPDFLib

Public Class PDFEditor
    Inherits GenericEditor

    Friend WithEvents PDFReader As AcroPDF

    ' Dynamic empirical loading of COM component AxAcroPDF
    ' When statically loaded on this UserControl, crashes VisualStudio every 30s...
    Private Sub MyInitializeComponent()
        Me.PDFReader = New AcroPDF
        CType(Me.PDFReader, ISupportInitialize).BeginInit()
        Me.PDFReader.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.PDFReader.Enabled = True
        Me.PDFReader.Location = New Point(3, 3)
        Me.PDFReader.Name = "PDFReader"
        'Me.PDFReader.OcxState = CType(resources.GetObject("PDFReader.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PDFReader.Size = New Size(Me.Width - 6, Me.Height - 6)
        Me.PDFReader.TabIndex = 0
        Me.Controls.Add(Me.PDFReader)
        CType(Me.PDFReader, ISupportInitialize).EndInit()
    End Sub

    Public Overrides Sub DoEdit(ed As EditDoc)
        MyBase.DoEdit(ed)
        OpenDoc()
    End Sub

    ' Initial load of a clean document
    Sub OpenDoc()
        If PDFReader Is Nothing Then MyInitializeComponent()
        PDFReader.LoadFile(m_doc.sPathName)
    End Sub

    Private Sub PDFEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
    End Sub

End Class
