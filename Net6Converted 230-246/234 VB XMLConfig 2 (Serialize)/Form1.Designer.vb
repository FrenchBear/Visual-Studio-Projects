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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboConfigurations = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSPExclusions = New System.Windows.Forms.TextBox
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.lblServer = New System.Windows.Forms.Label
        Me.lblDatabase = New System.Windows.Forms.Label
        Me.txtDatabase = New System.Windows.Forms.TextBox
        Me.txtDBPassword = New System.Windows.Forms.TextBox
        Me.lblDBUser = New System.Windows.Forms.Label
        Me.lblDBPassword = New System.Windows.Forms.Label
        Me.txtDBUser = New System.Windows.Forms.TextBox
        Me.btnExecute = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Configurations"
        '
        'cboConfigurations
        '
        Me.cboConfigurations.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboConfigurations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConfigurations.FormattingEnabled = True
        Me.cboConfigurations.Location = New System.Drawing.Point(92, 6)
        Me.cboConfigurations.Name = "cboConfigurations"
        Me.cboConfigurations.Size = New System.Drawing.Size(410, 21)
        Me.cboConfigurations.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "SP E&xclusions:"
        '
        'txtSPExclusions
        '
        Me.txtSPExclusions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSPExclusions.BackColor = System.Drawing.SystemColors.Window
        Me.txtSPExclusions.Location = New System.Drawing.Point(92, 156)
        Me.txtSPExclusions.Multiline = True
        Me.txtSPExclusions.Name = "txtSPExclusions"
        Me.txtSPExclusions.Size = New System.Drawing.Size(410, 75)
        Me.txtSPExclusions.TabIndex = 28
        '
        'txtServer
        '
        Me.txtServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServer.Location = New System.Drawing.Point(92, 52)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(410, 20)
        Me.txtServer.TabIndex = 20
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(7, 55)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(41, 13)
        Me.lblServer.TabIndex = 19
        Me.lblServer.Text = "&Server:"
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Location = New System.Drawing.Point(7, 81)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(56, 13)
        Me.lblDatabase.TabIndex = 21
        Me.lblDatabase.Text = "&Database:"
        '
        'txtDatabase
        '
        Me.txtDatabase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatabase.Location = New System.Drawing.Point(92, 78)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(410, 20)
        Me.txtDatabase.TabIndex = 22
        '
        'txtDBPassword
        '
        Me.txtDBPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDBPassword.Location = New System.Drawing.Point(92, 130)
        Me.txtDBPassword.Name = "txtDBPassword"
        Me.txtDBPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtDBPassword.Size = New System.Drawing.Size(410, 20)
        Me.txtDBPassword.TabIndex = 26
        '
        'lblDBUser
        '
        Me.lblDBUser.AutoSize = True
        Me.lblDBUser.Location = New System.Drawing.Point(7, 107)
        Me.lblDBUser.Name = "lblDBUser"
        Me.lblDBUser.Size = New System.Drawing.Size(50, 13)
        Me.lblDBUser.TabIndex = 23
        Me.lblDBUser.Text = "DB &User:"
        '
        'lblDBPassword
        '
        Me.lblDBPassword.AutoSize = True
        Me.lblDBPassword.Location = New System.Drawing.Point(7, 133)
        Me.lblDBPassword.Name = "lblDBPassword"
        Me.lblDBPassword.Size = New System.Drawing.Size(74, 13)
        Me.lblDBPassword.TabIndex = 25
        Me.lblDBPassword.Text = "DB &Password:"
        '
        'txtDBUser
        '
        Me.txtDBUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDBUser.Location = New System.Drawing.Point(92, 104)
        Me.txtDBUser.Name = "txtDBUser"
        Me.txtDBUser.Size = New System.Drawing.Size(410, 20)
        Me.txtDBUser.TabIndex = 24
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(10, 248)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(151, 23)
        Me.btnExecute.TabIndex = 29
        Me.btnExecute.Text = "Execute (Validate Config)"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 359)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSPExclusions)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.lblServer)
        Me.Controls.Add(Me.lblDatabase)
        Me.Controls.Add(Me.txtDatabase)
        Me.Controls.Add(Me.txtDBPassword)
        Me.Controls.Add(Me.lblDBUser)
        Me.Controls.Add(Me.lblDBPassword)
        Me.Controls.Add(Me.txtDBUser)
        Me.Controls.Add(Me.cboConfigurations)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboConfigurations As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSPExclusions As System.Windows.Forms.TextBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents lblDatabase As System.Windows.Forms.Label
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents txtDBPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblDBUser As System.Windows.Forms.Label
    Friend WithEvents lblDBPassword As System.Windows.Forms.Label
    Friend WithEvents txtDBUser As System.Windows.Forms.TextBox
    Friend WithEvents btnExecute As System.Windows.Forms.Button

End Class
