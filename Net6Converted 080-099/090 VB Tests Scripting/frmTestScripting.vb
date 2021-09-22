' Essais de scripting en .Net
' 2004-01-05    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010  + forçage en 32-bit

Option Strict Off
Option Explicit On

#Disable Warning IDE1006 ' Naming Styles

Friend Class frmTestScripting
    Inherits Form

#Region "Code généré par le Concepteur Windows Form "

    Private ReadOnly ScriptControl1 As New MSScriptControl.ScriptControl

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

        ScriptControl1.Language = "VBScript"
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
    Public WithEvents Command5 As Button
    Public WithEvents Command4 As Button
    Public WithEvents Command3 As Button
    Public WithEvents Command2 As Button
    Public WithEvents Command1 As Button

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Il peut être modifié à l'aide du Concepteur Windows Form.
    'Ne pas le modifier à l'aide de l'éditeur de code.
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New ComponentModel.Container
        Dim resources As New Resources.ResourceManager(GetType(frmTestScripting))
        Me.ToolTip1 = New ToolTip(Me.components)
        Me.Command5 = New Button
        Me.Command4 = New Button
        Me.Command3 = New Button
        Me.Command2 = New Button
        Me.Command1 = New Button
        Me.SuspendLayout()
        '
        'Command5
        '
        Me.Command5.BackColor = System.Drawing.SystemColors.Control
        Me.Command5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command5.Location = New Point(8, 168)
        Me.Command5.Name = "Command5"
        Me.Command5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command5.Size = New Size(81, 33)
        Me.Command5.TabIndex = 4
        Me.Command5.Text = "Word"
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.SystemColors.Control
        Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command4.Location = New Point(8, 128)
        Me.Command4.Name = "Command4"
        Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command4.Size = New Size(81, 33)
        Me.Command4.TabIndex = 3
        Me.Command4.Text = "Modules"
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New Point(8, 88)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New Size(81, 33)
        Me.Command3.TabIndex = 2
        Me.Command3.Text = "Eval"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New Point(8, 48)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New Size(81, 33)
        Me.Command2.TabIndex = 1
        Me.Command2.Text = "EvalFunc"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New Point(8, 8)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New Size(81, 33)
        Me.Command1.TabIndex = 0
        Me.Command1.Text = "sc.Run ""NameMe"""
        '
        'frmTestScripting
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New Size(312, 208)
        Me.Controls.Add(Me.Command5)
        Me.Controls.Add(Me.Command4)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New Point(4, 30)
        Me.Name = "frmTestScripting"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Tests Scripting"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Prise en charge de la mise à niveau "

    Private Shared m_vb6FormDefInstance As frmTestScripting
    Private Shared m_InitializingDefInstance As Boolean

    Public Shared Property DefInstance() As frmTestScripting
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmTestScripting
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(Value As frmTestScripting)
            m_vb6FormDefInstance = Value
        End Set
    End Property

#End Region

    ' frmTestScripting
    ' Essais avec le contrôle ScriptControl

    Private Sub Command1_Click(eventSender As System.Object, eventArgs As EventArgs) Handles Command1.Click
        ScriptControl1.Run("NameMe", Array.Empty(Of Object)())
    End Sub

    Private Sub Command2_Click(eventSender As System.Object, eventArgs As EventArgs) Handles Command2.Click
        EvalFunc()
    End Sub

    Private Sub Command3_Click(eventSender As System.Object, eventArgs As EventArgs) Handles Command3.Click
        ScriptControl1.ExecuteStatement("x = 100")
        MsgBox(ScriptControl1.Eval("x = 100")) ' True
        MsgBox(ScriptControl1.Eval("x = 100/2")) ' False
    End Sub

    Private Sub Command4_Click(eventSender As System.Object, eventArgs As EventArgs) Handles Command4.Click
        Dim modX As MSScriptControl.Module
        modX = ScriptControl1.Modules.Add("myMod")
        Dim strX As String
        strX = "Sub Hello" & vbCrLf & "MsgBox ""Bonjour!""" & vbCrLf & "End Sub"

        modX.AddCode(strX)
        Dim objX As Object
        ' Affecter le CodeObject à la variable, puis
        ' appeler la procédure.
        objX = modX.CodeObject
        objX.Hello()
    End Sub

    Private Sub Command5_Click(eventSender As System.Object, eventArgs As EventArgs) Handles Command5.Click
        Dim script As String
        script = "Sub TestWord()" & vbCrLf & "dim wd" & vbCrLf & "Set wd = CreateObject(""Word.application"")" & vbCrLf & "wd.Visible = True" & vbCrLf & "wd.Documents.Add" & vbCrLf & "wd.Selection.TypeText (""Il était un petit navire"")" & vbCrLf & "wd.Selection.TypeParagraph" & vbCrLf & "End Sub"

        Dim modW As MSScriptControl.Module
        modW = ScriptControl1.Modules.Add("modW")
        modW.AddCode(script)

        Dim omw As Object
        omw = modW.CodeObject
        omw.TestWord()
    End Sub

    Private Sub frmTestScripting_Load(eventSender As System.Object, eventArgs As EventArgs) Handles MyBase.Load
        Dim strCode As String
        strCode = "Sub NameMe()" & vbCrLf & " Dim strName" & vbCrLf & " strName = InputBox(""Nom?"")" & vbCrLf & " MsgBox ""Votre nom est "" & strName" & vbCrLf & "End Sub"
        ScriptControl1.AddCode(strCode)
    End Sub

    Private Sub EvalFunc()
        ' Créer la fonction.
        Dim strFonction As String
        strFonction = "Function ReturnThis(x, y)" & vbCrLf & " ReturnThis = x * y" & vbCrLf & "End Function"
        ' Ajouter le code puis exécuter la fonction.
        ScriptControl1.AddCode(strFonction)
        MsgBox(ScriptControl1.Run("ReturnThis", New Object() {3, 25}))
    End Sub

End Class