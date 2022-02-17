Imports System.ComponentModel
Imports VB202.My.Resources

Partial Public Class frmSplash
    Inherits Form

    <DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    '<System.Diagnostics.DebuggerStepThrough()> 
    Private Sub InitializeComponent()
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(frmSplash))
        '
        'frmSplash
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.BackgroundImage = GrizzlyPasContent
        Me.ClientSize = New Size(389, 385)
        Me.ControlBox = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Me.Name = "frmSplash"
        Me.Text = "Splash screen"

    End Sub
End Class
