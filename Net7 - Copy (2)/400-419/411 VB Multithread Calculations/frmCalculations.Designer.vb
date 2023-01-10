Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class CalculationsForm
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
        Me.components = New Container()
        Me.Factorial1Label = New Label()
        Me.lblFactorial2 = New Label()
        Me.lblAddTwo = New Label()
        Me.lblRunLoops = New Label()
        Me.lblTotalCalculations = New Label()
        Me.Factorial1Button = New Button()
        Me.Factorial2Button = New Button()
        Me.AddTwoButton = New Button()
        Me.RunLoopsButton = New Button()
        Me.txtValue = New TextBox()
        Me.Calculator1 = New Calculator(Me.components)
        Me.SuspendLayout()
        '
        'lblFactorial1
        '
        Me.Factorial1Label.AutoSize = True
        Me.Factorial1Label.Location = New Point(9, 158)
        Me.Factorial1Label.Name = "lblFactorial1"
        Me.Factorial1Label.Size = New Size(63, 13)
        Me.Factorial1Label.TabIndex = 0
        Me.Factorial1Label.Text = "lblFactorial1"
        '
        'lblFactorial2
        '
        Me.lblFactorial2.AutoSize = True
        Me.lblFactorial2.Location = New Point(9, 171)
        Me.lblFactorial2.Name = "lblFactorial2"
        Me.lblFactorial2.Size = New Size(63, 13)
        Me.lblFactorial2.TabIndex = 1
        Me.lblFactorial2.Text = "lblFactorial2"
        '
        'lblAddTwo
        '
        Me.lblAddTwo.AutoSize = True
        Me.lblAddTwo.Location = New Point(9, 184)
        Me.lblAddTwo.Name = "lblAddTwo"
        Me.lblAddTwo.Size = New Size(57, 13)
        Me.lblAddTwo.TabIndex = 2
        Me.lblAddTwo.Text = "lblAddTwo"
        '
        'lblRunLoops
        '
        Me.lblRunLoops.AutoSize = True
        Me.lblRunLoops.Location = New Point(9, 197)
        Me.lblRunLoops.Name = "lblRunLoops"
        Me.lblRunLoops.Size = New Size(66, 13)
        Me.lblRunLoops.TabIndex = 3
        Me.lblRunLoops.Text = "lblRunLoops"
        '
        'lblTotalCalculations
        '
        Me.lblTotalCalculations.AutoSize = True
        Me.lblTotalCalculations.Location = New Point(9, 210)
        Me.lblTotalCalculations.Name = "lblTotalCalculations"
        Me.lblTotalCalculations.Size = New Size(98, 13)
        Me.lblTotalCalculations.TabIndex = 4
        Me.lblTotalCalculations.Text = "lblTotalCalculations"
        '
        'btnFactorial1
        '
        Me.Factorial1Button.Location = New Point(12, 38)
        Me.Factorial1Button.Name = "btnFactorial1"
        Me.Factorial1Button.Size = New Size(75, 23)
        Me.Factorial1Button.TabIndex = 5
        Me.Factorial1Button.Text = "Factorial"
        Me.Factorial1Button.UseVisualStyleBackColor = True
        '
        'btnFactorial2
        '
        Me.Factorial2Button.Location = New Point(12, 67)
        Me.Factorial2Button.Name = "btnFactorial2"
        Me.Factorial2Button.Size = New Size(75, 23)
        Me.Factorial2Button.TabIndex = 6
        Me.Factorial2Button.Text = "Factorial-1"
        Me.Factorial2Button.UseVisualStyleBackColor = True
        '
        'btnAddTwo
        '
        Me.AddTwoButton.Location = New Point(12, 95)
        Me.AddTwoButton.Name = "btnAddTwo"
        Me.AddTwoButton.Size = New Size(75, 23)
        Me.AddTwoButton.TabIndex = 7
        Me.AddTwoButton.Text = "Add Two"
        Me.AddTwoButton.UseVisualStyleBackColor = True
        '
        'btnRunLoops
        '
        Me.RunLoopsButton.Location = New Point(12, 124)
        Me.RunLoopsButton.Name = "btnRunLoops"
        Me.RunLoopsButton.Size = New Size(75, 23)
        Me.RunLoopsButton.TabIndex = 8
        Me.RunLoopsButton.Text = "Run a Loop"
        Me.RunLoopsButton.UseVisualStyleBackColor = True
        '
        'txtValue
        '
        Me.txtValue.Location = New Point(12, 12)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New Size(100, 20)
        Me.txtValue.TabIndex = 9
        '
        'Calculator1
        '
        '
        'frmCalculations
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(284, 262)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.RunLoopsButton)
        Me.Controls.Add(Me.AddTwoButton)
        Me.Controls.Add(Me.Factorial2Button)
        Me.Controls.Add(Me.Factorial1Button)
        Me.Controls.Add(Me.lblTotalCalculations)
        Me.Controls.Add(Me.lblRunLoops)
        Me.Controls.Add(Me.lblAddTwo)
        Me.Controls.Add(Me.lblFactorial2)
        Me.Controls.Add(Me.Factorial1Label)
        Me.Name = "frmCalculations"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Factorial1Label As Label
    Friend WithEvents lblFactorial2 As Label
    Friend WithEvents lblAddTwo As Label
    Friend WithEvents lblRunLoops As Label
    Friend WithEvents lblTotalCalculations As Label
    Friend WithEvents Factorial1Button As Button
    Friend WithEvents Factorial2Button As Button
    Friend WithEvents AddTwoButton As Button
    Friend WithEvents RunLoopsButton As Button
    Friend WithEvents txtValue As TextBox
    Friend WithEvents Calculator1 As Calculator

End Class
