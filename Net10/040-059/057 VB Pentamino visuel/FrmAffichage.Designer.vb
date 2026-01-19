<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAffichage
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
        btnPause = New Button()
        Button1 = New Button()
        pic = New PictureBox()
        btnStop = New Button()
        btnAnalyse = New Button()
        txtSolution = New TextBox()
        vsSol = New VScrollBar()
        CType(pic, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnPause
        ' 
        btnPause.Enabled = False
        btnPause.Location = New Point(8, 40)
        btnPause.Name = "btnPause"
        btnPause.Size = New Size(75, 23)
        btnPause.TabIndex = 1
        btnPause.Text = "Pause"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(27, 136)
        Button1.Name = "Button1"
        Button1.Size = New Size(61, 23)
        Button1.TabIndex = 5
        Button1.Text = "Button1"
        Button1.Visible = False
        ' 
        ' pic
        ' 
        pic.BorderStyle = BorderStyle.FixedSingle
        pic.Location = New Point(96, 8)
        pic.Name = "pic"
        pic.Size = New Size(208, 424)
        pic.TabIndex = 1
        pic.TabStop = False
        ' 
        ' btnStop
        ' 
        btnStop.Enabled = False
        btnStop.Location = New Point(8, 72)
        btnStop.Name = "btnStop"
        btnStop.Size = New Size(75, 23)
        btnStop.TabIndex = 2
        btnStop.Text = "Stop"
        ' 
        ' btnAnalyse
        ' 
        btnAnalyse.Location = New Point(8, 8)
        btnAnalyse.Name = "btnAnalyse"
        btnAnalyse.Size = New Size(75, 23)
        btnAnalyse.TabIndex = 0
        btnAnalyse.Text = "&Analyse"
        ' 
        ' txtSolution
        ' 
        txtSolution.Location = New Point(8, 104)
        txtSolution.Name = "txtSolution"
        txtSolution.ReadOnly = True
        txtSolution.Size = New Size(80, 23)
        txtSolution.TabIndex = 3
        ' 
        ' vsSol
        ' 
        vsSol.Location = New Point(8, 136)
        vsSol.Name = "vsSol"
        vsSol.Size = New Size(16, 296)
        vsSol.TabIndex = 4
        vsSol.Visible = False
        ' 
        ' FrmAffichage
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(322, 445)
        Controls.Add(Button1)
        Controls.Add(vsSol)
        Controls.Add(btnStop)
        Controls.Add(btnPause)
        Controls.Add(txtSolution)
        Controls.Add(pic)
        Controls.Add(btnAnalyse)
        Name = "FrmAffichage"
        Text = "Analyseur Pentamino"
        CType(pic, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnPause As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents vsSol As VScrollBar
    Friend WithEvents Button1 As Button
	Friend WithEvents btnAnalyse As Button
    Friend WithEvents txtSolution As TextBox
    Friend WithEvents pic As PictureBox

End Class
