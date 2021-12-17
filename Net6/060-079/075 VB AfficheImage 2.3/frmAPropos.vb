' 2021-09-19    PV  VS2022, Net6

Option Strict Off
Option Explicit On

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
                    If Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
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
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

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
        Me.components = New ComponentModel.Container()
        Dim resources As New ComponentModel.ComponentResourceManager(GetType(FrmAPropos))
        Me.ToolTip1 = New ToolTip(Me.components)
        Me.BtnOK = New Button()
        Me.Image1 = New PictureBox()
        Me.ImgAuteur = New PictureBox()
        Me.LblBuild = New Label()
        Me.Label3 = New Label()
        Me.Label1 = New Label()
        CType(Me.Image1, ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgAuteur, ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.BtnOK.BackColor = SystemColors.Control
        Me.BtnOK.Cursor = Cursors.Default
        Me.BtnOK.Font = New Font("Verdana", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOK.ForeColor = SystemColors.ControlText
        Me.BtnOK.Location = New Point(278, 83)
        Me.BtnOK.Name = "btnOK"
        Me.BtnOK.RightToLeft = RightToLeft.No
        Me.BtnOK.Size = New Size(86, 25)
        Me.BtnOK.TabIndex = 2
        Me.BtnOK.Text = "OK"
        Me.BtnOK.UseVisualStyleBackColor = False
        '
        'Image1
        '
        Me.Image1.Cursor = Cursors.Default
        Me.Image1.Image = CType(resources.GetObject("Image1.Image"), Image)
        Me.Image1.Location = New Point(19, 18)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New Size(78, 88)
        Me.Image1.SizeMode = PictureBoxSizeMode.StretchImage
        Me.Image1.TabIndex = 3
        Me.Image1.TabStop = False
        '
        'imgAuteur
        '
        Me.ImgAuteur.Cursor = Cursors.Default
        Me.ImgAuteur.Image = CType(resources.GetObject("imgAuteur.Image"), Image)
        Me.ImgAuteur.Location = New Point(29, 28)
        Me.ImgAuteur.Name = "imgAuteur"
        Me.ImgAuteur.Size = New Size(35, 44)
        Me.ImgAuteur.SizeMode = PictureBoxSizeMode.StretchImage
        Me.ImgAuteur.TabIndex = 4
        Me.ImgAuteur.TabStop = False
        Me.ImgAuteur.Visible = False
        '
        'lblBuild
        '
        Me.LblBuild.AutoSize = True
        Me.LblBuild.BackColor = SystemColors.Control
        Me.LblBuild.Cursor = Cursors.Default
        Me.LblBuild.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuild.ForeColor = SystemColors.ControlText
        Me.LblBuild.Location = New Point(120, 62)
        Me.LblBuild.Name = "lblBuild"
        Me.LblBuild.RightToLeft = RightToLeft.No
        Me.LblBuild.Size = New Size(53, 17)
        Me.LblBuild.TabIndex = 3
        Me.LblBuild.Text = "Build :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = SystemColors.Control
        Me.Label3.Cursor = Cursors.Default
        Me.Label3.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = SystemColors.ControlText
        Me.Label3.Location = New Point(120, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = RightToLeft.No
        Me.Label3.Size = New Size(194, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "(c) 1997-2012  P.VIOLENT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = SystemColors.Control
        Me.Label1.Cursor = Cursors.Default
        Me.Label1.Font = New Font("Verdana", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = SystemColors.ControlText
        Me.Label1.Location = New Point(120, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = RightToLeft.No
        Me.Label1.Size = New Size(463, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "AfficheImage - Programme d'affichage d'images simple"
        '
        'frmAPropos
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New Size(6, 15)
        Me.BackColor = SystemColors.Control
        Me.ClientSize = New Size(594, 124)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.Image1)
        Me.Controls.Add(Me.ImgAuteur)
        Me.Controls.Add(Me.LblBuild)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = Cursors.Default
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Me.Location = New Point(211, 144)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAPropos"
        Me.RightToLeft = RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = FormStartPosition.Manual
        Me.Text = "À propos d'AfficheImage"
        CType(Me.Image1, ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgAuteur, ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
        Me.Close()
    End Sub

    Private Sub FrmAPropos_Load(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Load
        LblBuild.Text = "Version " & GetVersion()
    End Sub

    Private Sub Image1_Click(eventSender As Object, eventArgs As EventArgs) Handles Image1.Click
        Image1.SizeMode = PictureBoxSizeMode.StretchImage
        Image1.Image = ImgAuteur.Image
    End Sub

End Class