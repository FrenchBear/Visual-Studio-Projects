' Radoteur
' Word-building application
'
' 2004-06-28    PV
' 2006-10-01 	PV		VS2005
' 2011-09-26	PV		VS2010 and reading words from a file --> doesn't work, should not be recursive...
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.ComponentModel
Imports System.IO

#Disable Warning IDE0059 ' Unnecessary assignment of a value
#Disable Warning IDE1006 ' Naming Styles

Public Class Form1
    Inherits Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents lstPropositions As ListBox

    Friend WithEvents lstWords As ListBox
    Friend WithEvents btnGo As Button

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        lstPropositions = New ListBox()
        btnGo = New Button()
        lstWords = New ListBox()
        SuspendLayout()
        '
        'lstPropositions
        '
        lstPropositions.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom _
            Or AnchorStyles.Left _
            Or AnchorStyles.Right
        lstPropositions.ItemHeight = 25
        lstPropositions.Location = New Point(364, 15)
        lstPropositions.Name = "lstPropositions"
        lstPropositions.Size = New Size(291, 429)
        lstPropositions.Sorted = True
        lstPropositions.TabIndex = 1
        '
        'btnGo
        '
        btnGo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnGo.Location = New Point(675, 15)
        btnGo.Name = "btnGo"
        btnGo.Size = New Size(150, 42)
        btnGo.TabIndex = 2
        btnGo.Text = "Go"
        '
        'lstWords
        '
        lstWords.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom _
            Or AnchorStyles.Left
        lstWords.ItemHeight = 25
        lstWords.Location = New Point(24, 15)
        lstWords.Name = "lstWords"
        lstWords.Size = New Size(326, 429)
        lstWords.Sorted = True
        lstWords.TabIndex = 3
        '
        'Form1
        '
        AcceptButton = btnGo
        AutoScaleBaseSize = New Size(10, 24)
        ClientSize = New Size(837, 485)
        Controls.Add(lstWords)
        Controls.Add(btnGo)
        Controls.Add(lstPropositions)
        Name = "Form1"
        Text = "Radoteur"
        ResumeLayout(False)

    End Sub

#End Region

    Private iMaxWords As Integer
    Private tsWords As List(Of String)

    Private Const isFromFile As Boolean = True

    ' Initialize words list and show it
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If isFromFile Then
            ' Read words from c:\radoteur.txt
            tsWords = New List(Of String)()
            Using sr As New StreamReader("..\..\..\Listes\prénoms_féminins.txt")
                Do Until sr.EndOfStream
                    Dim sLine As String = sr.ReadLine.ToLowerInvariant
                    For p As Integer = Len(sLine) - 1 To 0 Step -1
                        If Not Char.IsLetter(sLine.Chars(p)) And sLine.Chars(p) <> " "c Then sLine = sLine.Remove(p, 1)
                    Next
                    For Each aWord As String In sLine.Split
                        If aWord.Length > 2 Then tsWords.Add(aWord)
                    Next
                Loop
            End Using
        Else
            tsWords = New List(Of String) From {
                "laboratory",
                "chemistry",
                "information",
                "management",
                "system",
                "analyze",
                "tests",
                "molecule",
                "certificate",
                "testing",
                "analysis",
                "method",
                "eurofins",
                "report",
                "lims",
                "software",
                "reagent",
                "instrument",
                "data",
                "acquisition",
                "limit",
                "compliance",
                "regulation",
                "health",
                "frog",
                "france",
                "nantes",
                "commercial",
                "germany"
            }
        End If

        ' Show words
        Dim nw As Integer = 0, nm As Integer = 0
        For Each aWord As String In tsWords
            lstWords.Items.Add(aWord)
            nw += 1
            If aWord.EndsWith("ine") Then nm += 1
        Next

        Debug.WriteLine("Source: nm:" & nm.ToString & "  nw:" & nw.ToString & " = " & (nm / nw).ToString("0.00%"))
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        ' Radoteur
        iMaxWords = tsWords.Count - 1

        Dim sWord As String = ""
        Dim i As Integer

        i = 0
        Dim nw As Integer = 0, nm As Integer = 0

        Do
            sWord = sFindWord()
            If Len(sWord) >= 4 Then
                lstPropositions.Items.Add(sWord)
                i += 1
                nw += 1
                If sWord.EndsWith("ine") Then nm += 1
            End If
        Loop While i < 1000
        Debug.WriteLine("Generated: nm:" & nm.ToString & "  nw:" & nw.ToString & " = " & (nm / nw).ToString("0.00%"))
    End Sub

    Private Const lMatchSize As Integer = 1         ' This number of characters should match for a candidate
    Private Const lChunkSize As Integer = 2         ' When a match is found, take this number of characters

    Private Function sFindWord() As String
        Dim sPrefix As String = ""
        Do
            ' Don't return a word longer than 15 characters
            If Len(sPrefix) > 15 Then
                Return sPrefix
            End If

            ' Anchor
            Dim sAnchor As String = Microsoft.VisualBasic.Right(sPrefix, lMatchSize)

            ' Chose a random starting word
            Dim p0, p As Integer
            p0 = Int(Rnd() * iMaxWords)
            p = p0

            Do
                ' Position of anchor match
                Dim f As Integer

                If sAnchor = "" Then
                    ' Specific case for the beginning, we take the beginning of a word
                    f = 1
                Else
                    Dim p1, p2 As Integer
                    Dim lp As List(Of Integer) = Nothing
                    p1 = 1
                    Do
                        p2 = InStr(p1, tsWords(p), sAnchor, CompareMethod.Text)
                        If p2 = 0 Then Exit Do
                        If p2 + lChunkSize > Len(tsWords(p)) Then Exit Do
                        If lp Is Nothing Then lp = New List(Of Integer)
                        lp.Add(p2)
                        p1 = p2 + 1
                    Loop

                    ' Found anchoring point(s) in current word
                    If lp Is Nothing Then
                        f = -1
                    Else
                        ' Chose a random match
                        Dim iOcc As Integer = Int(lp.Count * Rnd())
                        f = lp(iOcc) + lMatchSize
                    End If
                End If

                ' Found a follow-up
                If f > 0 Then
                    sPrefix &= Mid(tsWords(p), f, lChunkSize)
                    ' if it's the end of an existing word, stop here
                    If f + lChunkSize > Len(tsWords(p)) Then
                        Return sPrefix
                    End If
                    GoTo ContinueExteralLoop
                End If

                ' Else look in next word
                p = (p + 1) Mod iMaxWords
            Loop While p <> p0

            ' No possible follow-up, stop here
            If p = p0 Then Return sPrefix

            ' Continue accumulation process
ContinueExteralLoop:
        Loop
    End Function

End Class
