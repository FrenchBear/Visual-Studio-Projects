' Exemple de CodeDom (doc MSDN sur CodeDomProvider Class)
'
' 2004-01-06    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

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
        Private Shared ReadOnly items As String() = New String() {"CSharp", "Visual Basic", "JScript"}

        Private Sub Generate_button_Click(sender As Object, e As EventArgs)
            Dim provider As CodeDomProvider = GetCurrentProvider()
            CodeDomExample.GenerateCode(provider, CodeDomExample.BuildHelloWorldGraph())

            ' Build the source file name with the appropriate
            ' language extension.
            Dim sourceFile = If(provider.FileExtension.StartsWith("."c), "TestGraph" + provider.FileExtension, "TestGraph." + provider.FileExtension)

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
            Dim sourceFile = If(provider.FileExtension.StartsWith("."c), "TestGraph" + provider.FileExtension, "TestGraph." + provider.FileExtension)

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
            Select Case CStr(comboBox1.SelectedItem)
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
            SuspendLayout()
            ' Set properties for label1.
            label1.Location = New Point(395, 20)
            label1.Size = New Size(180, 22)
            label1.Text = "Select a programming language:"
            ' Set properties for comboBox1.
            comboBox1.Location = New Point(560, 16)
            comboBox1.Size = New Size(190, 23)
            comboBox1.Name = "comboBox1"
            comboBox1.Items.AddRange(items)
            comboBox1.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            comboBox1.SelectedIndex = 0
            ' Set properties for generate_button.
            generate_button.Location = New Point(8, 16)
            generate_button.Name = "generate_button"
            generate_button.Size = New Size(120, 23)
            generate_button.Text = "Generate Code"
            AddHandler generate_button.Click, AddressOf Generate_button_Click
            ' Set properties for compile_button.
            compile_button.Location = New Point(136, 16)
            compile_button.Name = "compile_button"
            compile_button.Size = New Size(120, 23)
            compile_button.Text = "Compile"
            AddHandler compile_button.Click, AddressOf Compile_button_Click
            ' Set properties for run_button.
            run_button.Enabled = False
            run_button.Location = New Point(264, 16)
            run_button.Name = "run_button"
            run_button.Size = New Size(120, 23)
            run_button.Text = "Run"
            AddHandler run_button.Click, AddressOf Run_button_Click
            ' Set properties for textBox1.
            textBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
            textBox1.Location = New Point(8, 48)
            textBox1.Multiline = True
            textBox1.ScrollBars = ScrollBars.Vertical
            textBox1.Name = "textBox1"
            textBox1.Size = New Size(744, 280)
            textBox1.Text = ""
            ' Set properties for the CodeDomExampleForm.
            AutoScaleBaseSize = New Size(5, 13)
            ClientSize = New Size(768, 340)
            MinimumSize = New Size(750, 340)
            Controls.AddRange(New Control() {textBox1,
                run_button, compile_button, generate_button,
                comboBox1, label1})
            Name = "CodeDomExampleForm"
            Text = "CodeDom Hello World Example"
            ResumeLayout(False)
        End Sub

        Protected Overloads Sub Dispose(disposing As Boolean)
            MyBase.Dispose(disposing)
        End Sub

        <STAThread()>
        Public Shared Sub Main()
            Application.Run(New CodeDomExampleForm)
        End Sub

        Public Sub InitializeComponent()
            SuspendLayout()
            '
            'CodeDomExampleForm
            '
            ClientSize = New Size(672, 574)
            Name = "CodeDomExampleForm"
            ResumeLayout(False)

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
#Disable Warning CA1825 ' Avoid zero-length array allocations
            Dim csReadLine As New CodeMethodInvokeExpression(csSystemConsoleType, "ReadLine")
#Enable Warning CA1825 ' Avoid zero-length array allocations

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
            Dim sourceFile = If(provider.FileExtension.StartsWith("."c), "TestGraph" + provider.FileExtension, "TestGraph." + provider.FileExtension)

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
