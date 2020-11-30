' VB Project Info
' Analyse des infos de la classe System.Diagnostics.FileVersionInfo
' Création dynamique de composants
' Atrribut privé d'assembly
' 2001-08-18    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Public Class frmInfos
    Inherits System.Windows.Forms.Form

    Private iRang As Integer = 0
    Private ReadOnly iInitialWidth As Integer

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        iInitialWidth = Me.Size.Width - 130
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents btnInfos As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnInfos = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnInfos
        '
        Me.btnInfos.Location = New System.Drawing.Point(320, 8)
        Me.btnInfos.Name = "btnInfos"
        Me.btnInfos.TabIndex = 0
        Me.btnInfos.Text = "Infos"
        '
        'frmInfos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.AutoScrollMargin = New System.Drawing.Size(0, 6)
        Me.ClientSize = New System.Drawing.Size(544, 357)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnInfos})
        Me.Name = "frmInfos"
        Me.Text = "Infos sur l'assembly"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnInfos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfos.Click
        btnInfos.Visible = False

        Dim vi As System.Diagnostics.FileVersionInfo
        vi = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location)

        Info("FileName", vi.FileName)
        Info("Comments", vi.Comments)
        Info("CompanyName", vi.CompanyName)
        Info("FileDescription", vi.FileDescription)
        Info("FileMajorPart", vi.FileMajorPart)
        Info("FileMinorPart", vi.FileMinorPart)
        Info("FileBuildPart", vi.FileBuildPart)
        Info("FilePrivatePart", vi.FilePrivatePart)
        Info("FileVersion", vi.FileVersion)
        Info("InternalName", vi.InternalName)
        Info("IsDebug", vi.IsDebug)
        Info("IsPatched", vi.IsPatched)
        Info("IsPreRelease", vi.IsPreRelease)
        Info("IsPrivateBuild", vi.IsPrivateBuild)
        Info("IsSpecialBuild", vi.IsSpecialBuild)
        Info("Language", vi.Language)
        Info("LegalCopyright", vi.LegalCopyright)
        Info("LegalTrademarks", vi.LegalTrademarks)
        Info("OriginalFilename", vi.OriginalFilename)
        Info("PrivateBuild", vi.PrivateBuild)
        Info("ProductMajorPart", vi.ProductMajorPart)
        Info("ProductMinorPart", vi.ProductMinorPart)
        Info("ProductBuildPart", vi.ProductBuildPart)
        Info("ProductPrivatePart", vi.ProductPrivatePart)
        Info("ProductVersion", vi.ProductVersion)
        Info("SpecialBuild", vi.SpecialBuild)


        ' Attribut privé
        Dim a As System.Reflection.Assembly
        a = System.Reflection.Assembly.GetExecutingAssembly
        Dim tPV As Object()
        tPV = a.GetCustomAttributes(GetType(AssemblyPVAttribute), False)
        If (tPV Is Nothing) Or tPV.Length = 0 Then
            Info("PV", "(nothing) ")
        Else
            Dim PV As AssemblyPVAttribute
            PV = tPV(0)
            Info("PV.iFlags", PV.iFlags)
            Info("PV.Info", PV.Info)
        End If


        ' On recalibre les txtInfo après l'apparition de la ScrollBar
        Dim c As Windows.Forms.Control
        For Each c In Me.Controls
            If TypeOf c Is TextBox Then
                '        Debug.WriteLine("Name: " & c.Name & " Width: " & c.Size.Width)
                c.Size = New Size(iInitialWidth, c.Size.Height)
            End If
        Next
    End Sub


    Private Sub Info(ByVal sLabel As String, ByVal sValeur As String)
        iRang += 1

        Dim l As New Label()
        Dim t As New TextBox()

        With l
            .AutoSize = True
            .Location = New System.Drawing.Point(6, 22 * (iRang - 1) + 6)
            .Name = "lblInfo" & iRang
            .Text = sLabel
        End With

        With t
            .Location = New System.Drawing.Point(100, 22 * (iRang - 1) + 6)
            .Name = "txtInfo" & iRang
            .Size = New System.Drawing.Size(iInitialWidth, 20)
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            .ReadOnly = True
            .Text = sValeur
        End With

        Me.Controls.AddRange(New System.Windows.Forms.Control() {t, l})
    End Sub
End Class
