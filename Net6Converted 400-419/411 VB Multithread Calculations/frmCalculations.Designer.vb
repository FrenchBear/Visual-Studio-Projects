<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CalculationsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Factorial1Label = New System.Windows.Forms.Label()
        Me.lblFactorial2 = New System.Windows.Forms.Label()
        Me.lblAddTwo = New System.Windows.Forms.Label()
        Me.lblRunLoops = New System.Windows.Forms.Label()
        Me.lblTotalCalculations = New System.Windows.Forms.Label()
        Me.Factorial1Button = New System.Windows.Forms.Button()
        Me.Factorial2Button = New System.Windows.Forms.Button()
        Me.AddTwoButton = New System.Windows.Forms.Button()
        Me.RunLoopsButton = New System.Windows.Forms.Button()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.Calculator1 = New Calculations.Calculator(Me.components)
        Me.SuspendLayout()
        '
        'lblFactorial1
        '
        Me.Factorial1Label.AutoSize = True
        Me.Factorial1Label.Location = New System.Drawing.Point(9, 158)
        Me.Factorial1Label.Name = "lblFactorial1"
        Me.Factorial1Label.Size = New System.Drawing.Size(63, 13)
        Me.Factorial1Label.TabIndex = 0
        Me.Factorial1Label.Text = "lblFactorial1"
        '
        'lblFactorial2
        '
        Me.lblFactorial2.AutoSize = True
        Me.lblFactorial2.Location = New System.Drawing.Point(9, 171)
        Me.lblFactorial2.Name = "lblFactorial2"
        Me.lblFactorial2.Size = New System.Drawing.Size(63, 13)
        Me.lblFactorial2.TabIndex = 1
        Me.lblFactorial2.Text = "lblFactorial2"
        '
        'lblAddTwo
        '
        Me.lblAddTwo.AutoSize = True
        Me.lblAddTwo.Location = New System.Drawing.Point(9, 184)
        Me.lblAddTwo.Name = "lblAddTwo"
        Me.lblAddTwo.Size = New System.Drawing.Size(57, 13)
        Me.lblAddTwo.TabIndex = 2
        Me.lblAddTwo.Text = "lblAddTwo"
        '
        'lblRunLoops
        '
        Me.lblRunLoops.AutoSize = True
        Me.lblRunLoops.Location = New System.Drawing.Point(9, 197)
        Me.lblRunLoops.Name = "lblRunLoops"
        Me.lblRunLoops.Size = New System.Drawing.Size(66, 13)
        Me.lblRunLoops.TabIndex = 3
        Me.lblRunLoops.Text = "lblRunLoops"
        '
        'lblTotalCalculations
        '
        Me.lblTotalCalculations.AutoSize = True
        Me.lblTotalCalculations.Location = New System.Drawing.Point(9, 210)
        Me.lblTotalCalculations.Name = "lblTotalCalculations"
        Me.lblTotalCalculations.Size = New System.Drawing.Size(98, 13)
        Me.lblTotalCalculations.TabIndex = 4
        Me.lblTotalCalculations.Text = "lblTotalCalculations"
        '
        'btnFactorial1
        '
        Me.Factorial1Button.Location = New System.Drawing.Point(12, 38)
        Me.Factorial1Button.Name = "btnFactorial1"
        Me.Factorial1Button.Size = New System.Drawing.Size(75, 23)
        Me.Factorial1Button.TabIndex = 5
        Me.Factorial1Button.Text = "Factorial"
        Me.Factorial1Button.UseVisualStyleBackColor = True
        '
        'btnFactorial2
        '
        Me.Factorial2Button.Location = New System.Drawing.Point(12, 67)
        Me.Factorial2Button.Name = "btnFactorial2"
        Me.Factorial2Button.Size = New System.Drawing.Size(75, 23)
        Me.Factorial2Button.TabIndex = 6
        Me.Factorial2Button.Text = "Factorial-1"
        Me.Factorial2Button.UseVisualStyleBackColor = True
        '
        'btnAddTwo
        '
        Me.AddTwoButton.Location = New System.Drawing.Point(12, 95)
        Me.AddTwoButton.Name = "btnAddTwo"
        Me.AddTwoButton.Size = New System.Drawing.Size(75, 23)
        Me.AddTwoButton.TabIndex = 7
        Me.AddTwoButton.Text = "Add Two"
        Me.AddTwoButton.UseVisualStyleBackColor = True
        '
        'btnRunLoops
        '
        Me.RunLoopsButton.Location = New System.Drawing.Point(12, 124)
        Me.RunLoopsButton.Name = "btnRunLoops"
        Me.RunLoopsButton.Size = New System.Drawing.Size(75, 23)
        Me.RunLoopsButton.TabIndex = 8
        Me.RunLoopsButton.Text = "Run a Loop"
        Me.RunLoopsButton.UseVisualStyleBackColor = True
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(12, 12)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(100, 20)
        Me.txtValue.TabIndex = 9
        '
        'Calculator1
        '
        '
        'frmCalculations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
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
    Friend WithEvents Factorial1Label As System.Windows.Forms.Label
    Friend WithEvents lblFactorial2 As System.Windows.Forms.Label
    Friend WithEvents lblAddTwo As System.Windows.Forms.Label
    Friend WithEvents lblRunLoops As System.Windows.Forms.Label
    Friend WithEvents lblTotalCalculations As System.Windows.Forms.Label
    Friend WithEvents Factorial1Button As System.Windows.Forms.Button
    Friend WithEvents Factorial2Button As System.Windows.Forms.Button
    Friend WithEvents AddTwoButton As System.Windows.Forms.Button
    Friend WithEvents RunLoopsButton As System.Windows.Forms.Button
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents Calculator1 As Calculations.Calculator

End Class
