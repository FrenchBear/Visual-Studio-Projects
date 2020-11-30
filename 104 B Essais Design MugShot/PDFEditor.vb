' PDFEditor UserControl
' PDF edit/view control
' 2006-04-13    PV  First version
' 2012-02-25	PV  VS2010

Option Compare Text

Public Class PDFEditor
    Inherits GenericEditor

    Friend WithEvents pdfReader As AxAcroPDFLib.AxAcroPDF

    ' Dynamic empirical loading of COM component AxAcroPDF
    ' When statically loaded on this UserControl, crashes VisualStudio every 30s...
    Private Sub myInitializeComponent()
        Me.pdfReader = New AxAcroPDFLib.AxAcroPDF
        CType(Me.pdfReader, ComponentModel.ISupportInitialize).BeginInit()
        Me.pdfReader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.pdfReader.Enabled = True
        Me.pdfReader.Location = New Point(3, 3)
        Me.pdfReader.Name = "pdfReader"
        'Me.pdfReader.OcxState = CType(resources.GetObject("pdfReader.OcxState"), System.Windows.Forms.AxHost.State)
        Me.pdfReader.Size = New Size(Me.Width - 6, Me.Height - 6)
        Me.pdfReader.TabIndex = 0
        Me.Controls.Add(Me.pdfReader)
        CType(Me.pdfReader, ComponentModel.ISupportInitialize).EndInit()
    End Sub

    Public Overrides Sub DoEdit(ed As EditDoc)
        MyBase.DoEdit(ed)
        OpenDoc()
    End Sub

    ' Initial load of a clean document
    Sub OpenDoc()
        If pdfReader Is Nothing Then myInitializeComponent()
        pdfReader.LoadFile(m_doc.sPathName)
    End Sub

    Private Sub PDFEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
    End Sub

End Class