<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCalculations
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
        Me.lblFactorial1 = New System.Windows.Forms.Label()
        Me.lblFactorial2 = New System.Windows.Forms.Label()
        Me.lblAddTwo = New System.Windows.Forms.Label()
        Me.lblRunLoops = New System.Windows.Forms.Label()
        Me.lblTotalCalculations = New System.Windows.Forms.Label()
        Me.btnFactorial1 = New System.Windows.Forms.Button()
        Me.btnFactorial2 = New System.Windows.Forms.Button()
        Me.btnAddTwo = New System.Windows.Forms.Button()
        Me.btnRunLoops = New System.Windows.Forms.Button()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.Calculator1 = New Calculations.Calculator(Me.components)
        Me.SuspendLayout()
        '
        'lblFactorial1
        '
        Me.lblFactorial1.AutoSize = True
        Me.lblFactorial1.Location = New System.Drawing.Point(9, 158)
        Me.lblFactorial1.Name = "lblFactorial1"
        Me.lblFactorial1.Size = New System.Drawing.Size(63, 13)
        Me.lblFactorial1.TabIndex = 0
        Me.lblFactorial1.Text = "lblFactorial1"
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
        Me.btnFactorial1.Location = New System.Drawing.Point(12, 38)
        Me.btnFactorial1.Name = "btnFactorial1"
        Me.btnFactorial1.Size = New System.Drawing.Size(75, 23)
        Me.btnFactorial1.TabIndex = 5
        Me.btnFactorial1.Text = "Factorial"
        Me.btnFactorial1.UseVisualStyleBackColor = True
        '
        'btnFactorial2
        '
        Me.btnFactorial2.Location = New System.Drawing.Point(12, 67)
        Me.btnFactorial2.Name = "btnFactorial2"
        Me.btnFactorial2.Size = New System.Drawing.Size(75, 23)
        Me.btnFactorial2.TabIndex = 6
        Me.btnFactorial2.Text = "Factorial-1"
        Me.btnFactorial2.UseVisualStyleBackColor = True
        '
        'btnAddTwo
        '
        Me.btnAddTwo.Location = New System.Drawing.Point(12, 95)
        Me.btnAddTwo.Name = "btnAddTwo"
        Me.btnAddTwo.Size = New System.Drawing.Size(75, 23)
        Me.btnAddTwo.TabIndex = 7
        Me.btnAddTwo.Text = "Add Two"
        Me.btnAddTwo.UseVisualStyleBackColor = True
        '
        'btnRunLoops
        '
        Me.btnRunLoops.Location = New System.Drawing.Point(12, 124)
        Me.btnRunLoops.Name = "btnRunLoops"
        Me.btnRunLoops.Size = New System.Drawing.Size(75, 23)
        Me.btnRunLoops.TabIndex = 8
        Me.btnRunLoops.Text = "Run a Loop"
        Me.btnRunLoops.UseVisualStyleBackColor = True
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
        Me.Controls.Add(Me.btnRunLoops)
        Me.Controls.Add(Me.btnAddTwo)
        Me.Controls.Add(Me.btnFactorial2)
        Me.Controls.Add(Me.btnFactorial1)
        Me.Controls.Add(Me.lblTotalCalculations)
        Me.Controls.Add(Me.lblRunLoops)
        Me.Controls.Add(Me.lblAddTwo)
        Me.Controls.Add(Me.lblFactorial2)
        Me.Controls.Add(Me.lblFactorial1)
        Me.Name = "frmCalculations"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFactorial1 As System.Windows.Forms.Label
    Friend WithEvents lblFactorial2 As System.Windows.Forms.Label
    Friend WithEvents lblAddTwo As System.Windows.Forms.Label
    Friend WithEvents lblRunLoops As System.Windows.Forms.Label
    Friend WithEvents lblTotalCalculations As System.Windows.Forms.Label
    Friend WithEvents btnFactorial1 As System.Windows.Forms.Button
    Friend WithEvents btnFactorial2 As System.Windows.Forms.Button
    Friend WithEvents btnAddTwo As System.Windows.Forms.Button
    Friend WithEvents btnRunLoops As System.Windows.Forms.Button
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents Calculator1 As Calculations.Calculator

End Class
