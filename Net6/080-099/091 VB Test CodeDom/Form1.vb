' Exemple de CodeDom (doc MSDN sur CodeDomProvider Class)
' 2004-01-06    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.IO
Imports Microsoft.CSharp

' This example demonstrates building a Hello World program graph
' using System.CodeDom elements. It calls code generator and
' code compiler methods to build the program using CSharp, VB, or
' JScript.  A Windows Forms interface is included. Note: Code
' must be compiled and linked with the Microsoft.JScript assembly.
Namespace CodeDOMExample

    Public Class CodeDomExampleForm
        Inherits Form
        Private ReadOnly run_button As New Button
        Private ReadOnly compile_button As New Button
        Private ReadOnly generate_button As New Button
        Private ReadOnly textBox1 As New TextBox
        Private ReadOnly comboBox1 As New ComboBox
        Private ReadOnly label1 As New Label

        Private Sub Generate_button_Click(sender As Object, e As EventArgs)
            Dim provider As CodeDomProvider = GetCurrentProvider()
            CodeDomExample.GenerateCode(provider, CodeDomExample.BuildHelloWorldGraph())

            ' Build the source file name with the appropriate
            ' language extension.
            Dim sourceFile As String
            If provider.FileExtension.StartsWith(".") Then
                sourceFile = "TestGraph" + provider.FileExtension
            Else
                sourceFile = "TestGraph." + provider.FileExtension
            End If

            ' Read in the generated source file and
            ' display the source text.
            Dim sr As New StreamReader(sourceFile)
            textBox1.Text = sr.ReadToEnd()
            sr.Close()
        End Sub

        Private Sub Compile_button_Click(sender As Object, e As EventArgs)
            Dim provider As CodeDomProvider = GetCurrentProvider()

            ' Build the source file name with the appropriate
            ' language extension.
            Dim sourceFile As String
            If provider.FileExtension.StartsWith(".") Then
                sourceFile = "TestGraph" + provider.FileExtension
            Else
                sourceFile = "TestGraph." + provider.FileExtension
            End If

            Dim cr As CompilerResults = CodeDomExample.CompileCode(provider,
                                                                   sourceFile,
                                                                   "TestGraph.EXE")

            If cr.Errors.Count > 0 Then
                ' Display compilation errors.
                textBox1.Text = "Errors encountered while building " +
                                sourceFile + " into " +
                                cr.PathToAssembly + ": " + ControlChars.CrLf

                Dim ce As CompilerError
                For Each ce In cr.Errors
                    textBox1.AppendText(ce.ToString() + ControlChars.CrLf)
                Next ce
                run_button.Enabled = False
            Else
                textBox1.Text = "Source " + sourceFile + " built into " +
                                cr.PathToAssembly + " with no errors."
                run_button.Enabled = True
            End If
        End Sub

        Private Sub Run_button_Click(sender As Object, e As EventArgs)
            Process.Start("TestGraph.EXE")
        End Sub

        Private Function GetCurrentProvider() As CodeDomProvider

            Dim provider As CodeDomProvider
            Select Case CStr(Me.comboBox1.SelectedItem)
                Case "CSharp"
                    provider = New CSharpCodeProvider
                Case "Visual Basic"
                    provider = New VBCodeProvider
                    'Case "JScript"
                    '    provider = New JScriptCodeProvider
                Case Else
                    provider = New CSharpCodeProvider
            End Select
            Return provider
        End Function

        Public Sub New()
            Me.SuspendLayout()
            ' Set properties for label1.
            Me.label1.Location = New Point(395, 20)
            Me.label1.Size = New Size(180, 22)
            Me.label1.Text = "Select a programming language:"
            ' Set properties for comboBox1.
            Me.comboBox1.Location = New Point(560, 16)
            Me.comboBox1.Size = New Size(190, 23)
            Me.comboBox1.Name = "comboBox1"
            Me.comboBox1.Items.AddRange(New String() {"CSharp", "Visual Basic", "JScript"})
            Me.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right Or System.Windows.Forms.AnchorStyles.Top
            Me.comboBox1.SelectedIndex = 0
            ' Set properties for generate_button.
            Me.generate_button.Location = New Point(8, 16)
            Me.generate_button.Name = "generate_button"
            Me.generate_button.Size = New Size(120, 23)
            Me.generate_button.Text = "Generate Code"
            AddHandler generate_button.Click, AddressOf Me.Generate_button_Click
            ' Set properties for compile_button.
            Me.compile_button.Location = New Point(136, 16)
            Me.compile_button.Name = "compile_button"
            Me.compile_button.Size = New Size(120, 23)
            Me.compile_button.Text = "Compile"
            AddHandler compile_button.Click, AddressOf Me.Compile_button_Click
            ' Set properties for run_button.
            Me.run_button.Enabled = False
            Me.run_button.Location = New Point(264, 16)
            Me.run_button.Name = "run_button"
            Me.run_button.Size = New Size(120, 23)
            Me.run_button.Text = "Run"
            AddHandler run_button.Click, AddressOf Me.Run_button_Click
            ' Set properties for textBox1.
            Me.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
            Me.textBox1.Location = New Point(8, 48)
            Me.textBox1.Multiline = True
            Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.textBox1.Name = "textBox1"
            Me.textBox1.Size = New Size(744, 280)
            Me.textBox1.Text = ""
            ' Set properties for the CodeDomExampleForm.
            Me.AutoScaleBaseSize = New Size(5, 13)
            Me.ClientSize = New Size(768, 340)
            Me.MinimumSize = New Size(750, 340)
            Me.Controls.AddRange(New Control() {Me.textBox1,
                Me.run_button, Me.compile_button, Me.generate_button,
                Me.comboBox1, Me.label1})
            Me.Name = "CodeDomExampleForm"
            Me.Text = "CodeDom Hello World Example"
            Me.ResumeLayout(False)
        End Sub

        Protected Overloads Sub Dispose(disposing As Boolean)
            MyBase.Dispose(disposing)
        End Sub

        <STAThread()>
        Public Shared Sub Main()
            Application.Run(New CodeDomExampleForm)
        End Sub

        Public Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'CodeDomExampleForm
            '
            Me.ClientSize = New System.Drawing.Size(672, 574)
            Me.Name = "CodeDomExampleForm"
            Me.ResumeLayout(False)

        End Sub
    End Class

    Public Class CodeDomExample

        ' Build a Hello World program graph using
        ' System.CodeDom types.
        Public Shared Function BuildHelloWorldGraph() As CodeCompileUnit

            ' Create a new CodeCompileUnit to contain
            ' the program graph.
            Dim compileUnit As New CodeCompileUnit

            ' Declare a new namespace called Samples.
            Dim samples As New CodeNamespace("Samples")

            ' Add the new namespace to the compile unit.
            compileUnit.Namespaces.Add(samples)

            ' Add the new namespace import for the System namespace.
            samples.Imports.Add(New CodeNamespaceImport("System"))

            ' Declare a new type called Class1.
            Dim class1 As New CodeTypeDeclaration("Class1")

            ' Add the new type to the namespace type collection.
            samples.Types.Add(class1)

            ' Declare a new code entry point method.
            Dim start As New CodeEntryPointMethod

            ' Create a type reference for the System.Console class.
            Dim csSystemConsoleType As New CodeTypeReferenceExpression("System.Console")

            ' Build a Console.WriteLine statement.
            Dim cs1 As New CodeMethodInvokeExpression(csSystemConsoleType, "WriteLine", New CodePrimitiveExpression("Hello World!"))

            ' Add the WriteLine call to the statement collection.
            start.Statements.Add(cs1)

            ' Build another Console.WriteLine statement.
            Dim cs2 As New CodeMethodInvokeExpression(csSystemConsoleType, "WriteLine", New CodePrimitiveExpression("Press the Enter key to continue."))

            ' Add the WriteLine call to the statement collection.
            start.Statements.Add(cs2)

            ' Build a call to System.Console.ReadLine.
            Dim csReadLine As New CodeMethodInvokeExpression(csSystemConsoleType, "ReadLine")

            ' Add the ReadLine statement.
            start.Statements.Add(csReadLine)

            ' Add the code entry point method to
            ' the Members collection of the type.
            class1.Members.Add(start)

            Return compileUnit
        End Function

        Public Shared Sub GenerateCode(provider As CodeDomProvider, compileunit As CodeCompileUnit)

            ' Build the source file name with the appropriate
            ' language extension.
            Dim sourceFile As String
            If provider.FileExtension.StartsWith(".") Then
                sourceFile = "TestGraph" + provider.FileExtension
            Else
                sourceFile = "TestGraph." + provider.FileExtension
            End If

            ' Create an IndentedTextWriter, constructed with
            ' a StreamWriter to the source file.
            Dim tw As New IndentedTextWriter(New StreamWriter(sourceFile, False), "    ")
            ' Generate source code using the code generator.
            provider.GenerateCodeFromCompileUnit(compileunit, tw, New CodeGeneratorOptions)
            ' Close the output file.
            tw.Close()
        End Sub

        Public Shared Function CompileCode(provider As CodeDomProvider, sourceFile As String, exeFile As String) As CompilerResults
            ' Configure a CompilerParameters that links System.dll
            ' and produces the specified executable file.
            Dim referenceAssemblies As String() = {"System.dll"}
            ' Generate an executable rather than a DLL file.
            Dim cp As New CompilerParameters(referenceAssemblies, exeFile, False) With {
                .GenerateExecutable = True
            }

            ' Invoke compilation.
            Dim cr As CompilerResults = provider.CompileAssemblyFromFile(cp, sourceFile)
            ' Return the results of compilation.
            Return cr
        End Function

    End Class

End Namespace