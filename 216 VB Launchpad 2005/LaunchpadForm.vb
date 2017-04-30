' LauchPad.Net 2005
' 2004-10-03    PV
' 2012-02-25	PV  VS2010

Option Compare Text

Imports vb = Microsoft.VisualBasic

Public Class LaunchpadForm
    Dim colMenus As New Generic.Dictionary(Of String, MenuCommand)

    Private Sub GenericClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mc As MenuCommand = colMenus(sender.tag)

        'If mc.iType = MenuCommand.MenuCommandTypeEnum.mctCommand Then
        'Shell(mc.Command)
        'End If
        MsgBox("GenericClick on " & sender.tag & vbCrLf & "Command: " & mc.sCommand)
    End Sub

    Private Sub GenericMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        sbMain.Text = colMenus(sender.tag).sToolTip
    End Sub

    Private Sub GenericMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        sbMain.Text = ""
    End Sub


    Private Sub LaunchpadForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim reader As New System.Xml.XmlTextReader("..\Menu.xml")
        Dim mc As MenuCommand
        While reader.Read()
            reader.MoveToContent()
            If reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "Info" Then
                ' nop
            ElseIf reader.NodeType = Xml.XmlNodeType.Element And reader.Name = "MenuCommand" Then
                Dim iNiv As Integer = 0
                mc = New MenuCommand
                mc.iType = CInt(reader.GetAttribute("Type"))
                mc.iLevel = CInt(reader.GetAttribute("Level"))
                While reader.Read
                    If reader.NodeType = Xml.XmlNodeType.Element Then
                        iNiv += 1
                        Select Case reader.Name
                            Case "UserKey"
                                reader.Read()
                                mc.UserKey = reader.Value
                            Case "Caption"
                                reader.Read()
                                mc.sCaption = reader.Value
                            Case "Command"
                                reader.Read()
                                mc.sCommand = reader.Value
                            Case "ToolTip"
                                reader.Read()
                                mc.sToolTip = reader.Value
                            Case "IconFile"
                                reader.Read()
                                mc.sIconFile = reader.Value
                            Case "Enabled"
                                reader.Read()
                                mc.bEnabled = CBool(reader.Value)
                            Case "VisibleInUserMode"
                                reader.Read()
                                mc.bVisibleInUserMode = CBool(reader.Value)
                        End Select
                    End If
                    If reader.NodeType = Xml.XmlNodeType.EndElement Then
                        iNiv -= 1
                        If iNiv < 0 Then Exit While
                    End If
                End While
                colMenus.Add(mc.UserKey, mc)
            End If
        End While
        reader.Close()
        'reader.Dispose()

        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitterToolStripMenuItem})

        'MsgBox("Found: " & colMenus.Count & " menus")
        Dim tsmiHead(4), tsmiCommand As ToolStripMenuItem
        Dim bSepButton As Boolean = False
        For Each x As Generic.KeyValuePair(Of String, MenuCommand) In colMenus
            mc = x.Value
            Select Case mc.iType
                Case MenuCommand.MenuCommandTypeEnum.mctMenuHeader, MenuCommand.MenuCommandTypeEnum.mctCommand, MenuCommand.MenuCommandTypeEnum.mctInternal, MenuCommand.MenuCommandTypeEnum.mctPlugIn, MenuCommand.MenuCommandTypeEnum.mctVBASub, MenuCommand.MenuCommandTypeEnum.mctVBScript
                    tsmiCommand = New ToolStripMenuItem
                    tsmiCommand.Text = sGetCaption(mc.sCaption)
                    tsmiCommand.ToolTipText = sGetCaption(mc.sToolTip)
                    If mc.sIconFile <> "" Then
                        If My.Computer.FileSystem.FileExists("..\Etc\" & mc.sIconFile) Then
                            If mc.sIconFile.EndsWith(".bmp") Then
                                tsmiCommand.Image = Bitmap.FromFile("..\Etc\" & mc.sIconFile)
                            Else
                                tsmiCommand.Image = New Icon("..\Etc\" & mc.sIconFile).ToBitmap
                            End If
                        End If
                    End If
                    tsmiCommand.Enabled = mc.bEnabled
                    If mc.iType = MenuCommand.MenuCommandTypeEnum.mctMenuHeader Then
                        tsmiHead(mc.iLevel) = tsmiCommand
                        If mc.iLevel = 0 Then
                            Me.MenuStrip1.Items.Add(tsmiHead(0))
                        Else
                            tsmiHead(mc.iLevel - 1).DropDownItems.Add(tsmiCommand)
                        End If
                        bSepButton = True
                    Else
                        tsmiHead(mc.iLevel - 1).DropDownItems.Add(tsmiCommand)

                        ' Add click handler
                        tsmiCommand.Tag = mc.UserKey
                        AddHandler tsmiCommand.Click, AddressOf GenericClick
                        AddHandler tsmiCommand.MouseEnter, AddressOf GenericMouseEnter
                        AddHandler tsmiCommand.MouseLeave, AddressOf GenericMouseLeave

                        ' Add a button
                        If mc.bVisibleInUserMode And mc.sIconFile <> "" Then
                            If bSepButton Then
                                bSepButton = False
                                tsMain.Items.Add(New ToolStripSeparator)
                            End If
                            Dim b As ToolStripButton
                            b = New ToolStripButton
                            b.Tag = mc.UserKey
                            b.ToolTipText = sGetCaption(mc.sCaption)

                            If My.Computer.FileSystem.FileExists("..\Etc\" & mc.sIconFile) Then
                                If mc.sIconFile.EndsWith(".bmp") Then
                                    b.Image = Bitmap.FromFile("..\Etc\" & mc.sIconFile)
                                Else
                                    b.Image = New Icon("..\Etc\" & mc.sIconFile).ToBitmap
                                End If
                            End If

                            b.DisplayStyle = ToolStripItemDisplayStyle.Image
                            b.Enabled = mc.bEnabled
                            tsMain.Items.Add(b)

                            AddHandler b.Click, AddressOf GenericClick
                            AddHandler b.MouseEnter, AddressOf GenericMouseEnter
                            AddHandler b.MouseLeave, AddressOf GenericMouseLeave
                        End If
                    End If

                Case MenuCommand.MenuCommandTypeEnum.mctSeparator
                    Dim sep As ToolStripSeparator
                    sep = New ToolStripSeparator
                    tsmiHead(mc.iLevel - 1).DropDownItems.Add(sep)
                    If mc.bVisibleInUserMode Then bSepButton = True

            End Select
        Next
    End Sub

    Private Function sGetCaption(ByVal sName As String) As String
        Dim myCastedTag As String
        Dim isCastedTag, isLastCarCaps, isNextCarCaps As Boolean
        isCastedTag = False
        If vb.Left(sName, 4) = "vbei" Then
            sName = vb.Right(sName, Len(sName) - 4)
            myCastedTag = vb.Left(sName, 1)
            isLastCarCaps = True
            For j As Integer = 2 To Len(sName)
                If j < Len(sName) Then isNextCarCaps = (Asc(Mid(sName, j + 1, 1)) >= 65 And Asc(Mid(sName, j + 1, 1)) <= 90) Or (Asc(Mid(sName, j + 1, 1)) >= 48 And Asc(Mid(sName, j + 1, 1)) <= 57) Else isNextCarCaps = False
                If (Asc(Mid(sName, j, 1)) >= 65 And Asc(Mid(sName, j, 1)) <= 90) Or (Asc(Mid(sName, j, 1)) >= 48 And Asc(Mid(sName, j, 1)) <= 57) Then
                    If isLastCarCaps And isNextCarCaps Then
                        myCastedTag = myCastedTag + Mid(sName, j, 1)
                    ElseIf Not isLastCarCaps And isNextCarCaps Then
                        myCastedTag = myCastedTag + " " + Mid(sName, j, 1)
                        isLastCarCaps = True
                    Else
                        myCastedTag = myCastedTag + " " + LCase(Mid(sName, j, 1))
                        isLastCarCaps = True
                    End If
                Else
                    myCastedTag = myCastedTag + Mid(sName, j, 1)
                    isLastCarCaps = False
                End If
            Next j
            sGetCaption = myCastedTag
        Else
            sGetCaption = sName
        End If

    End Function

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class


Class MenuCommand
    ' Type of command in a IMenuCommand object
    Public Enum MenuCommandTypeEnum
        mctNothing = 0
        mctMenuHeader = 1       ' Top level menu or menu group
        mctSeparator = 2        ' ----------
        mctCommand = 3          ' External command
        mctInternal = 4         ' Launchpad Internal Sub
        mctPlugIn = 5           ' eLIMS plug-in
        mctVBScript = 6         ' VBScript
        mctVBASub = 7           ' VBA Sub (not implanted yet)
    End Enum

    Public UserKey As String
    Public iType As MenuCommandTypeEnum
    Public iLevel As Integer
    Public bEnabled As Boolean
    Public bVisibleInUserMode As Boolean
    Public sCaption As String
    Public sToolTip As String
    Public sIconFile As String
    Public sCommand As String
End Class