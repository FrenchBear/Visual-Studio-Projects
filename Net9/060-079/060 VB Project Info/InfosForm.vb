' VB Project Info
' Analyse des infos de la classe System.Diagnostics.FileVersionInfo
' Création dynamique de composants
' Atrribut privé d'assembly
'
' 2001-08-18    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
Imports System.Reflection

#Disable Warning IDE1006 ' Naming Styles


Public Class InfosForm
    Inherits Form

    Private _iRang As Integer = 0
    Private ReadOnly _iInitialWidth As Integer

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _iInitialWidth = Size.Width - 130
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents btnInfos As Button

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        btnInfos = New Button()
        SuspendLayout()
        '
        'btnInfos
        '
        btnInfos.Location = New Point(320, 8)
        btnInfos.Name = "btnInfos"
        btnInfos.TabIndex = 0
        btnInfos.Text = "Infos"
        '
        'InfosForm
        '
        AutoScaleBaseSize = New Size(5, 13)
        AutoScroll = True
        AutoScrollMargin = New Size(0, 6)
        ClientSize = New Size(544, 357)
        Controls.AddRange(New Control() {btnInfos})
        Name = "InfosForm"
        Text = "Infos sur l'assembly"
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnInfos_Click(sender As Object, e As EventArgs) Handles btnInfos.Click
        btnInfos.Visible = False

        Dim vi As FileVersionInfo
        vi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly.Location)

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
        Dim a As Assembly
        a = Assembly.GetExecutingAssembly
        Dim tPv As Object()
        tPv = a.GetCustomAttributes(GetType(AssemblyPvAttribute), False)
        If (tPv Is Nothing) Or tPv.Length = 0 Then
            Info("PV", "(nothing) ")
        Else
            Dim pv As AssemblyPvAttribute
            pv = tPv(0)
            Info("PV.iFlags", pv.Flags)
            Info("PV.Info", pv.Info)
        End If

        ' On recalibre les txtInfo après l'apparition de la ScrollBar
        Dim c As Control
        For Each c In Controls
            If TypeOf c Is TextBox Then
                '        Debug.WriteLine("Name: " & c.Name & " Width: " & c.Size.Width)
                c.Size = New Size(_iInitialWidth, c.Size.Height)
            End If
        Next
    End Sub

    Private Sub Info(sLabel As String, sValeur As String)
        _iRang += 1

        Dim l As New Label()
        Dim t As New TextBox()

        With l
            .AutoSize = True
            .Location = New Point(6, (22 * (_iRang - 1)) + 6)
            .Name = "lblInfo" & _iRang
            .Text = sLabel
        End With

        With t
            .Location = New Point(100, (22 * (_iRang - 1)) + 6)
            .Name = "txtInfo" & _iRang
            .Size = New Size(_iInitialWidth, 20)
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            .ReadOnly = True
            .Text = sValeur
        End With

        Controls.AddRange(New Control() {t, l})
    End Sub

End Class
