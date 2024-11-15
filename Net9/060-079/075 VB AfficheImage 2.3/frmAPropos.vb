' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Option Strict Off
Option Explicit On

Imports System.ComponentModel
Imports System.Reflection

Friend Class FrmAPropos
    Inherits Form

#Region "Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then
            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    'Pour le formulaire de démarrage, la première instance créée est l'instance par défaut.
                    If Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is [GetType] Then
                        m_vb6FormDefInstance = Me
                    End If
                Catch
                End Try
            End If
        End If
        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(Disposing As Boolean)
        If Disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(Disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As Container

    Public ToolTip1 As ToolTip
    Public WithEvents BtnOK As Button
    Public WithEvents Image1 As PictureBox
    Public WithEvents ImgAuteur As PictureBox
    Public WithEvents LblBuild As Label
    Public WithEvents Label3 As Label
    Public WithEvents Label1 As Label

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Il peut être modifié à l'aide du Concepteur Windows Form.
    'Ne pas le modifier à l'aide de l'éditeur de code.
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New Container()
        Dim resources = New ComponentResourceManager(GetType(FrmAPropos))
        ToolTip1 = New ToolTip(components)
        BtnOK = New Button()
        Image1 = New PictureBox()
        ImgAuteur = New PictureBox()
        LblBuild = New Label()
        Label3 = New Label()
        Label1 = New Label()
        CType(Image1, ISupportInitialize).BeginInit()
        CType(ImgAuteur, ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'BtnOK
        '
        BtnOK.BackColor = SystemColors.Control
        BtnOK.Font = New Font("Verdana", 9.0!, FontStyle.Regular, GraphicsUnit.Point)
        BtnOK.ForeColor = SystemColors.ControlText
        BtnOK.Location = New Point(417, 133)
        BtnOK.Name = "BtnOK"
        BtnOK.RightToLeft = RightToLeft.No
        BtnOK.Size = New Size(129, 40)
        BtnOK.TabIndex = 2
        BtnOK.Text = "OK"
        BtnOK.UseVisualStyleBackColor = False
        '
        'Image1
        '
        Image1.Image = CType(resources.GetObject("Image1.Image"), Image)
        Image1.InitialImage = CType(resources.GetObject("Image1.InitialImage"), Image)
        Image1.Location = New Point(28, 29)
        Image1.Name = "Image1"
        Image1.Size = New Size(118, 141)
        Image1.SizeMode = PictureBoxSizeMode.StretchImage
        Image1.TabIndex = 3
        Image1.TabStop = False
        '
        'ImgAuteur
        '
        ImgAuteur.Image = CType(resources.GetObject("ImgAuteur.Image"), Image)
        ImgAuteur.Location = New Point(44, 45)
        ImgAuteur.Name = "ImgAuteur"
        ImgAuteur.Size = New Size(52, 70)
        ImgAuteur.SizeMode = PictureBoxSizeMode.StretchImage
        ImgAuteur.TabIndex = 4
        ImgAuteur.TabStop = False
        ImgAuteur.Visible = False
        '
        'LblBuild
        '
        LblBuild.AutoSize = True
        LblBuild.BackColor = SystemColors.Control
        LblBuild.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point)
        LblBuild.ForeColor = SystemColors.ControlText
        LblBuild.Location = New Point(180, 99)
        LblBuild.Name = "LblBuild"
        LblBuild.RightToLeft = RightToLeft.No
        LblBuild.Size = New Size(67, 20)
        LblBuild.TabIndex = 3
        LblBuild.Text = "Build :"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = SystemColors.ControlText
        Label3.Location = New Point(180, 59)
        Label3.Name = "Label3"
        Label3.RightToLeft = RightToLeft.No
        Label3.Size = New Size(238, 20)
        Label3.TabIndex = 1
        Label3.Text = "(c) 1997-2012  P.VIOLENT"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.Control
        Label1.Font = New Font("Verdana", 9.0!, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.ControlText
        Label1.Location = New Point(180, 22)
        Label1.Name = "Label1"
        Label1.RightToLeft = RightToLeft.No
        Label1.Size = New Size(578, 22)
        Label1.TabIndex = 0
        Label1.Text = "AfficheImage - Programme d'affichage d'images simple"
        '
        'FrmAPropos
        '
        AcceptButton = BtnOK
        AutoScaleBaseSize = New Size(9, 24)
        BackColor = SystemColors.Control
        ClientSize = New Size(776, 196)
        Controls.Add(BtnOK)
        Controls.Add(Image1)
        Controls.Add(ImgAuteur)
        Controls.Add(LblBuild)
        Controls.Add(Label3)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Location = New Point(211, 144)
        MaximizeBox = False
        MinimizeBox = False
        Name = "FrmAPropos"
        RightToLeft = RightToLeft.No
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "À propos d'AfficheImage"
        CType(Image1, ISupportInitialize).EndInit()
        CType(ImgAuteur, ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

#End Region

#Region "Prise en charge de la mise à niveau "

    Private Shared m_vb6FormDefInstance As FrmAPropos
    Private Shared m_InitializingDefInstance As Boolean

    Public Shared Property DefInstance() As FrmAPropos
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New FrmAPropos
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(Value As FrmAPropos)
            m_vb6FormDefInstance = Value
        End Set
    End Property

#End Region

    Private Sub BtnOK_Click(eventSender As Object, eventArgs As EventArgs) Handles BtnOK.Click
        Close()
    End Sub

    Private Sub FrmAPropos_Load(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Load
        LblBuild.Text = "Version " & GetVersion()
    End Sub

    Private Sub Image1_Click(eventSender As Object, eventArgs As EventArgs) Handles Image1.Click
        Image1.SizeMode = PictureBoxSizeMode.StretchImage
        Image1.Image = ImgAuteur.Image
    End Sub

End Class
