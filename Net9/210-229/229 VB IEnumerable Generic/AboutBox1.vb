' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
Imports System.IO

Public Class AboutBox1

    Private Sub AboutBox1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle = If(My.Application.Info.Title <> "",
            My.Application.Info.Title,
            Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName))
        Text = $"About {ApplicationTitle }"
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project
        '    properties dialog (under the "Project" menu).
        LabelProductName.Text = My.Application.Info.ProductName
        LabelVersion.Text = $"Version {My.Application.Info.Version }"
        LabelCopyright.Text = My.Application.Info.Copyright
        LabelCompanyName.Text = My.Application.Info.CompanyName
        TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Close()
    End Sub

End Class

Partial Public Class Toto
    Public P2 As Integer

    Public Shared Function Pif() As String
        Pif = ""
    End Function

End Class
