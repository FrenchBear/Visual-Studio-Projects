' PDFEditor UserControl
' PDF edit/view control
'
' 2006-04-13 	PV		First version
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6 (Note: this doesn't work in Net6, will check it later)
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Option Compare Text

Imports System.ComponentModel
Imports AcroPDFLib

Public Class PDFEditor
    Inherits GenericEditor

    Friend WithEvents PDFReader As AcroPDF

    ' Dynamic empirical loading of COM component AxAcroPDF
    ' When statically loaded on this UserControl, crashes VisualStudio every 30s...
    Private Sub MyInitializeComponent()
        PDFReader = New AcroPDF
        CType(PDFReader, ISupportInitialize).BeginInit()
        PDFReader.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom _
                    Or AnchorStyles.Left _
                    Or AnchorStyles.Right
        PDFReader.Enabled = True
        PDFReader.Location = New Point(3, 3)
        PDFReader.Name = "PDFReader"
        'Me.PDFReader.OcxState = CType(resources.GetObject("PDFReader.OcxState"), System.Windows.Forms.AxHost.State)
        PDFReader.Size = New Size(Width - 6, Height - 6)
        PDFReader.TabIndex = 0
        Controls.Add(PDFReader)
        CType(PDFReader, ISupportInitialize).EndInit()
    End Sub

    Public Overrides Sub DoEdit(ed As EditDoc)
        MyBase.DoEdit(ed)
        OpenDoc()
    End Sub

    ' Initial load of a clean document
    Public Sub OpenDoc()
        If PDFReader Is Nothing Then MyInitializeComponent()
        PDFReader.LoadFile(m_doc.sPathName)
    End Sub

    Private Sub PDFEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
    End Sub

End Class
