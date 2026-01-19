' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop.Word.WdBuiltInProperty

#Disable Warning IDE1006 ' Naming Styles

Public Class Form1
    Private app As Application
    Private doc As Document

    Private Sub Form1_FormClosing(
sender As Object,
e As FormClosingEventArgs) _
      Handles Me.FormClosing

        My.Settings.Size = Size
        My.Settings.Location = Location
        My.Settings.Save()
    End Sub

    Private Sub Form1_Load(
sender As Object,
e As EventArgs) _
     Handles MyBase.Load

        MySettingsBindingSource.DataSource = My.Settings

        ' Binding the form's properties to these settings
        ' doesn't work as you might expect.
        If Not My.Settings.Location.IsEmpty Then
            Location = My.Settings.Location
        End If
        If Not My.Settings.Size.IsEmpty Then
            Size = My.Settings.Size
        End If

        ' Set up control property bindings:
        titleTextBox.DataBindings.Add(
         "Visible", useTitleCheckbox, "Checked")
        subjectTextBox.DataBindings.Add(
         "Visible", useSubjectCheckBox, "Checked")
        authorTextBox.DataBindings.Add(
         "Visible", useAuthorCheckBox, "Checked")
        managerTextBox.DataBindings.Add(
         "Visible", useManagerCheckBox, "Checked")
        companyTextBox.DataBindings.Add(
         "Visible", useCompanyCheckBox, "Checked")
        categoryTextBox.DataBindings.Add(
         "Visible", useCategoryCheckBox, "Checked")
        keywordsTextBox.DataBindings.Add(
         "Visible", useKeywordsCheckBox, "Checked")
        commentsTextBox.DataBindings.Add(
         "Visible", useCommentsCheckBox, "Checked")
        hyperlinkBaseTextBox.DataBindings.Add(
         "Visible", useHyperlinkBaseCheckBox, "Checked")
        useDocNameCheckBox.DataBindings.Add(
         "Visible", useTitleCheckbox, "Checked")

        ' Make sure the Cancel button is disabled:
        cancelSearchButton.Enabled = False
    End Sub

    Private Sub folderButton_Click(
sender As Object,
e As EventArgs) _
     Handles folderButton.Click

        ' Select the folder for the document
        ' files to be modified.
        fbd.ShowNewFolderButton = False
        fbd.SelectedPath = folderLabel.Text
        If fbd.ShowDialog() = DialogResult.OK Then
            folderLabel.Text = fbd.SelectedPath
        End If
        My.Settings.Folder = fbd.SelectedPath
    End Sub

    Private Sub HandleDocs(path As String,
e As DoWorkEventArgs)

        Try
            If bgw.CancellationPending Then
                e.Cancel = True
                Exit Sub
            End If

            ' Handle subfolders, if required.
            Dim diLocal As New DirectoryInfo(path)
            If LookInSubfoldersCheckBox.Checked Then
                For Each di As DirectoryInfo In diLocal.GetDirectories
                    HandleDocs(di.FullName, e)
                Next
            End If

            ' Search for matching file names.
            For Each fi As FileInfo In diLocal.GetFiles("*.doc")
                ' Cancellation pending? Cancel and get out.
                If bgw.CancellationPending Then
                    e.Cancel = True
                    Exit Sub
                End If
                OnFileFound(fi)
            Next
        Catch ex As UnauthorizedAccessException
            ' Don't do anything at all, just quietly
            ' get out. This means you weren't meant to
            ' be in this folder.
            ' All other exceptions will bubble back out
            ' to the caller.
        End Try
    End Sub

    Private Sub OnFileFound(fi As FileInfo)
        Try
            bgw.ReportProgress(0, fi.Name)

            ' Open the document.
            doc = app.Documents.Open(fi.FullName)

            If doc.ReadOnlyRecommended Then
                ' Deal with stupid ReadOnlyRecommended problem:
                Dim docName As String = fi.FullName & "x"
                ' Save the doc with a new name,
                ' with ReadOnlyRecommended set to False.
                doc.SaveAs(docName, , , , , , False)
                doc.Close()
                ' Open the new document.
                doc = app.Documents.Open(docName)
                doc.SaveAs(fi.FullName)
                doc.Close()
                File.Delete(docName)
                doc = app.Documents.Open(fi.FullName)
            End If

            ' Title is a special case:
            If useTitleCheckbox.Checked Then
                doc.BuiltInDocumentProperties(
                     wdPropertyTitle).Value = If(useDocNameCheckBox.Checked, Path.GetFileNameWithoutExtension(doc.Name), titleTextBox.Text)
            End If

            ' Handle all the rest of the properties:
            SetProperty(useSubjectCheckBox,
             wdPropertySubject, subjectTextBox)
            SetProperty(useAuthorCheckBox,
             wdPropertyAuthor, authorTextBox)
            SetProperty(useManagerCheckBox,
             wdPropertyManager, managerTextBox)
            SetProperty(useCompanyCheckBox,
             wdPropertyCompany, companyTextBox)
            SetProperty(useCategoryCheckBox,
             wdPropertyCategory, categoryTextBox)
            SetProperty(useKeywordsCheckBox,
             wdPropertyKeywords, keywordsTextBox)
            SetProperty(useCommentsCheckBox,
             wdPropertyComments, commentsTextBox)
            SetProperty(useHyperlinkBaseCheckBox,
             wdPropertyHyperlinkBase, hyperlinkBaseTextBox)

            ' Fix up the rest of the cleanup issues:

            ' Accept revisions:
            doc.Revisions.AcceptAll()

            ' Delete all comments:
            For Each cmt As Comment In doc.Comments
                cmt.Delete()
            Next

            ' Add any other final cleanup you want to
            ' do here, as well.

            ' Close the document and save changes.
            doc.Close(True)
        Catch ex As Exception
            MessageBox.Show("Unable to change properties: " & ex.Message)
        End Try
    End Sub

    Private Shared Function FixPath(path As String) As String
        Return If(path.EndsWith("\"c), path, path & "\")
    End Function

    Private Sub makeChangesButton_Click(
sender As Object,
e As EventArgs) _
     Handles makeChangesButton.Click
        makeChangesButton.Enabled = False
        cancelSearchButton.Enabled = True
        bgw.RunWorkerAsync()
    End Sub

    Private Sub cancelButton_Click(
sender As Object,
e As EventArgs) Handles cancelSearchButton.Click

        bgw.CancelAsync()
    End Sub

    Private Sub bgw_DoWork(
sender As Object,
e As DoWorkEventArgs) _
     Handles bgw.DoWork

        ' Open Word, and handle the documents
        ' in the specified folder.
        Try
            app = New Application
            HandleDocs(folderLabel.Text, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            app.Quit()
            Marshal.ReleaseComObject(app)
        End Try
    End Sub

    Private Sub bgw_ProgressChanged(
sender As Object,
e As ProgressChangedEventArgs) _
     Handles bgw.ProgressChanged

        statusLabel.Text = "Updating " & e.UserState.ToString
    End Sub

    Private Sub bgw_RunWorkerCompleted(
sender As Object,
e As RunWorkerCompletedEventArgs) _
     Handles bgw.RunWorkerCompleted

        Dim statusText As String = "Ready"
        If e.Cancelled Then
            statusText &= ". Previous operation cancelled."
        End If
        statusLabel.Text = statusText
        makeChangesButton.Enabled = True
        cancelSearchButton.Enabled = False
    End Sub

    Private Sub SetProperty(
chk As System.Windows.Forms.CheckBox,
prop As WdBuiltInProperty,
txt As TextBox)

        ' If the supplied CheckBox control is checked,
        ' then set the Word property to the supplied value.
        If chk.Checked Then
            doc.BuiltInDocumentProperties(prop).Value = txt.Text
        End If
    End Sub

End Class
