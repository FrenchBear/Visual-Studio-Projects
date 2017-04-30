Option Strict Off
Option Explicit On

Friend Class FrmAPropos
    Inherits System.Windows.Forms.Form
#Region "Code généré par le Concepteur Windows Form "
    Public Sub New()
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then
            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    'Pour le formulaire de démarrage, la première instance créée est l'instance par défaut.
                    If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
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
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents BtnOK As System.Windows.Forms.Button
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    Public WithEvents ImgAuteur As System.Windows.Forms.PictureBox
    Public WithEvents LblBuild As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Il peut être modifié à l'aide du Concepteur Windows Form.
    'Ne pas le modifier à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAPropos))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.ImgAuteur = New System.Windows.Forms.PictureBox()
        Me.LblBuild = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgAuteur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.BtnOK.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnOK.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnOK.Location = New System.Drawing.Point(278, 83)
        Me.BtnOK.Name = "btnOK"
        Me.BtnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnOK.Size = New System.Drawing.Size(86, 25)
        Me.BtnOK.TabIndex = 2
        Me.BtnOK.Text = "OK"
        Me.BtnOK.UseVisualStyleBackColor = False
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
        Me.Image1.Location = New System.Drawing.Point(19, 18)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(78, 88)
        Me.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Image1.TabIndex = 3
        Me.Image1.TabStop = False
        '
        'imgAuteur
        '
        Me.ImgAuteur.Cursor = System.Windows.Forms.Cursors.Default
        Me.ImgAuteur.Image = CType(resources.GetObject("imgAuteur.Image"), System.Drawing.Image)
        Me.ImgAuteur.Location = New System.Drawing.Point(29, 28)
        Me.ImgAuteur.Name = "imgAuteur"
        Me.ImgAuteur.Size = New System.Drawing.Size(35, 44)
        Me.ImgAuteur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgAuteur.TabIndex = 4
        Me.ImgAuteur.TabStop = False
        Me.ImgAuteur.Visible = False
        '
        'lblBuild
        '
        Me.LblBuild.AutoSize = True
        Me.LblBuild.BackColor = System.Drawing.SystemColors.Control
        Me.LblBuild.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblBuild.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuild.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblBuild.Location = New System.Drawing.Point(120, 62)
        Me.LblBuild.Name = "lblBuild"
        Me.LblBuild.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblBuild.Size = New System.Drawing.Size(53, 17)
        Me.LblBuild.TabIndex = 3
        Me.LblBuild.Text = "Build :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(120, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(194, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "(c) 1997-2012  P.VIOLENT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(120, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(463, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "AfficheImage - Programme d'affichage d'images simple"
        '
        'frmAPropos
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(594, 124)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.Image1)
        Me.Controls.Add(Me.ImgAuteur)
        Me.Controls.Add(Me.LblBuild)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(211, 144)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAPropos"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "À propos d'AfficheImage"
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgAuteur, System.ComponentModel.ISupportInitialize).EndInit()
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
        Set(ByVal Value As FrmAPropos)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region

    Private Sub BtnOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BtnOK.Click
        Me.Close()
    End Sub

    Private Sub FrmAPropos_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        LblBuild.Text = "Version " & sGetVersion()
    End Sub

    Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
        Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Image1.Image = ImgAuteur.Image
    End Sub
End Class