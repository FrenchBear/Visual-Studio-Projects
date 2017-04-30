Option Strict Off
Option Explicit On

Friend Class frmAPropos
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
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents Image1 As System.Windows.Forms.PictureBox
    Public WithEvents imgAuteur As System.Windows.Forms.PictureBox
    Public WithEvents lblBuild As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Il peut être modifié à l'aide du Concepteur Windows Form.
    'Ne pas le modifier à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAPropos))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.imgAuteur = New System.Windows.Forms.PictureBox()
        Me.lblBuild = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgAuteur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(278, 83)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(86, 25)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
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
        Me.imgAuteur.Cursor = System.Windows.Forms.Cursors.Default
        Me.imgAuteur.Image = CType(resources.GetObject("imgAuteur.Image"), System.Drawing.Image)
        Me.imgAuteur.Location = New System.Drawing.Point(29, 28)
        Me.imgAuteur.Name = "imgAuteur"
        Me.imgAuteur.Size = New System.Drawing.Size(35, 44)
        Me.imgAuteur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgAuteur.TabIndex = 4
        Me.imgAuteur.TabStop = False
        Me.imgAuteur.Visible = False
        '
        'lblBuild
        '
        Me.lblBuild.AutoSize = True
        Me.lblBuild.BackColor = System.Drawing.SystemColors.Control
        Me.lblBuild.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBuild.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuild.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBuild.Location = New System.Drawing.Point(120, 62)
        Me.lblBuild.Name = "lblBuild"
        Me.lblBuild.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBuild.Size = New System.Drawing.Size(53, 17)
        Me.lblBuild.TabIndex = 3
        Me.lblBuild.Text = "Build :"
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
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(593, 127)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Image1)
        Me.Controls.Add(Me.imgAuteur)
        Me.Controls.Add(Me.lblBuild)
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
        CType(Me.imgAuteur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Prise en charge de la mise à niveau "
    Private Shared m_vb6FormDefInstance As frmAPropos
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmAPropos
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmAPropos
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmAPropos)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region

    Private Sub btnOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub frmAPropos_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        lblBuild.Text = "Version " & sGetVersion()
    End Sub

    Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
        Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Image1.Image = imgAuteur.Image
    End Sub
End Class