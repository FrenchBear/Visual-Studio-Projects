Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class MainForm
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New Container
        Me.Label1 = New Label
        Me.DrivesTextBox = New TextBox
        Me.PeriodTextBox = New TextBox
        Me.Label2 = New Label
        Me.StartStopButton = New Button
        Me.StatusTextBox = New TextBox
        Me.PingTimer = New Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Disques"
        '
        'DrivesTextBox
        '
        Me.DrivesTextBox.Location = New Point(143, 13)
        Me.DrivesTextBox.Name = "DrivesTextBox"
        Me.DrivesTextBox.Size = New Size(174, 20)
        Me.DrivesTextBox.TabIndex = 1
        '
        'PeriodTextBox
        '
        Me.PeriodTextBox.Location = New Point(143, 39)
        Me.PeriodTextBox.Name = "PeriodTextBox"
        Me.PeriodTextBox.Size = New Size(174, 20)
        Me.PeriodTextBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(126, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Durée entre deux ping (s)"
        '
        'StartStopButton
        '
        Me.StartStopButton.Location = New Point(15, 73)
        Me.StartStopButton.Name = "StartStopButton"
        Me.StartStopButton.Size = New Size(75, 23)
        Me.StartStopButton.TabIndex = 4
        Me.StartStopButton.Text = "Start"
        Me.StartStopButton.UseVisualStyleBackColor = True
        '
        'StatusTextBox
        '
        Me.StatusTextBox.Location = New Point(15, 111)
        Me.StatusTextBox.Multiline = True
        Me.StatusTextBox.Name = "StatusTextBox"
        Me.StatusTextBox.Size = New Size(302, 155)
        Me.StatusTextBox.TabIndex = 5
        '
        'PingTimer
        '
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(329, 278)
        Me.Controls.Add(Me.StatusTextBox)
        Me.Controls.Add(Me.StartStopButton)
        Me.Controls.Add(Me.PeriodTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DrivesTextBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Keep Tera Alive"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents DrivesTextBox As TextBox
    Friend WithEvents PeriodTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents StartStopButton As Button
    Friend WithEvents StatusTextBox As TextBox
    Friend WithEvents PingTimer As Timer

End Class
