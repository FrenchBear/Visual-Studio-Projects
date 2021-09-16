<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    '<System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.UcInherited1 = New Test_Form_Inheritance.ucInherited
        Me.SuspendLayout()
        '
        'UcInherited1
        '
        Me.UcInherited1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcInherited1.Location = New System.Drawing.Point(21, 12)
        Me.UcInherited1.Name = "UcInherited1"
        Me.UcInherited1.Size = New System.Drawing.Size(413, 478)
        Me.UcInherited1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 620)
        Me.Controls.Add(Me.UcInherited1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcInherited1 As Test_Form_Inheritance.ucInherited

End Class
