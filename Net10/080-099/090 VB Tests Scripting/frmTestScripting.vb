' Essais de scripting en .Net
'
' 2004-01-05    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010  + forçage en 32-bit
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Option Strict Off
Option Explicit On

Imports System.ComponentModel
Imports System.Reflection
Imports System.Resources
Imports MSScriptControl

#Disable Warning IDE1006 ' Naming Styles

Friend Class frmTestScripting
    Inherits Form

#Region "Code généré par le Concepteur Windows Form "

    Private ReadOnly ScriptControl1 As New ScriptControl

    Public Sub New()
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then
            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    'Pour le formulaire de démarrage, la première instance créée est l'instance par défaut.
                    If Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is [GetType]() Then
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
            components?.Dispose()
        End If
        MyBase.Dispose(Disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As Container

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
        components = New Container
        Dim resources As New ResourceManager(GetType(frmTestScripting))
        ToolTip1 = New ToolTip(components)
        Command5 = New Button
        Command4 = New Button
        Command3 = New Button
        Command2 = New Button
        Command1 = New Button
        SuspendLayout()
        '
        'Command5
        '
        Command5.BackColor = SystemColors.Control
        Command5.Cursor = Cursors.Default
        Command5.ForeColor = SystemColors.ControlText
        Command5.Location = New Point(8, 168)
        Command5.Name = "Command5"
        Command5.RightToLeft = RightToLeft.No
        Command5.Size = New Size(81, 33)
        Command5.TabIndex = 4
        Command5.Text = "Word"
        '
        'Command4
        '
        Command4.BackColor = SystemColors.Control
        Command4.Cursor = Cursors.Default
        Command4.ForeColor = SystemColors.ControlText
        Command4.Location = New Point(8, 128)
        Command4.Name = "Command4"
        Command4.RightToLeft = RightToLeft.No
        Command4.Size = New Size(81, 33)
        Command4.TabIndex = 3
        Command4.Text = "Modules"
        '
        'Command3
        '
        Command3.BackColor = SystemColors.Control
        Command3.Cursor = Cursors.Default
        Command3.ForeColor = SystemColors.ControlText
        Command3.Location = New Point(8, 88)
        Command3.Name = "Command3"
        Command3.RightToLeft = RightToLeft.No
        Command3.Size = New Size(81, 33)
        Command3.TabIndex = 2
        Command3.Text = "Eval"
        '
        'Command2
        '
        Command2.BackColor = SystemColors.Control
        Command2.Cursor = Cursors.Default
        Command2.ForeColor = SystemColors.ControlText
        Command2.Location = New Point(8, 48)
        Command2.Name = "Command2"
        Command2.RightToLeft = RightToLeft.No
        Command2.Size = New Size(81, 33)
        Command2.TabIndex = 1
        Command2.Text = "EvalFunc"
        '
        'Command1
        '
        Command1.BackColor = SystemColors.Control
        Command1.Cursor = Cursors.Default
        Command1.ForeColor = SystemColors.ControlText
        Command1.Location = New Point(8, 8)
        Command1.Name = "Command1"
        Command1.RightToLeft = RightToLeft.No
        Command1.Size = New Size(81, 33)
        Command1.TabIndex = 0
        Command1.Text = "sc.Run ""NameMe"""
        '
        'frmTestScripting
        '
        AutoScaleBaseSize = New Size(5, 13)
        BackColor = SystemColors.Control
        ClientSize = New Size(312, 208)
        Controls.Add(Command5)
        Controls.Add(Command4)
        Controls.Add(Command3)
        Controls.Add(Command2)
        Controls.Add(Command1)
        Cursor = Cursors.Default
        Location = New Point(4, 30)
        Name = "frmTestScripting"
        RightToLeft = RightToLeft.No
        Text = "Tests Scripting"
        ResumeLayout(False)

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

    Private Sub Command1_Click(eventSender As Object, eventArgs As EventArgs) Handles Command1.Click
        ScriptControl1.Run("NameMe", Array.Empty(Of Object)())
    End Sub

    Private Sub Command2_Click(eventSender As Object, eventArgs As EventArgs) Handles Command2.Click
        EvalFunc()
    End Sub

    Private Sub Command3_Click(eventSender As Object, eventArgs As EventArgs) Handles Command3.Click
        ScriptControl1.ExecuteStatement("x = 100")
        MsgBox(ScriptControl1.Eval("x = 100")) ' True
        MsgBox(ScriptControl1.Eval("x = 100/2")) ' False
    End Sub

    Private Sub Command4_Click(eventSender As Object, eventArgs As EventArgs) Handles Command4.Click
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

    Private Sub Command5_Click(eventSender As Object, eventArgs As EventArgs) Handles Command5.Click
        Dim script As String
        script = "Sub TestWord()" & vbCrLf & "dim wd" & vbCrLf & "Set wd = CreateObject(""Word.application"")" & vbCrLf & "wd.Visible = True" & vbCrLf & "wd.Documents.Add" & vbCrLf & "wd.Selection.TypeText (""Il était un petit navire"")" & vbCrLf & "wd.Selection.TypeParagraph" & vbCrLf & "End Sub"

        Dim modW As MSScriptControl.Module
        modW = ScriptControl1.Modules.Add("modW")
        modW.AddCode(script)

        Dim omw As Object
        omw = modW.CodeObject
        omw.TestWord()
    End Sub

    Private Sub frmTestScripting_Load(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Load
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
