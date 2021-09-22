' frmElimineDoublons
' Elimination des doublons des .mp3 de Bide-et-musique g�n�r�s par streamripper
'
' 2003-05-08    PV  Liste de trace
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022, Net6

Option Explicit On

#Disable Warning IDE1006 ' Naming Styles

Public Class frmElimineDoublons
    Inherits Form

#Region " Code g�n�r� par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()

    End Sub

    'La m�thode substitu�e Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As System.ComponentModel.IContainer

    'REMARQUE�: la proc�dure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'�diteur de code.
    Friend WithEvents btnEliminer As Button

    Friend WithEvents lstTrace As ListBox

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnEliminer = New Button()
        Me.lstTrace = New ListBox()
        Me.SuspendLayout()
        '
        'btnEliminer
        '
        Me.btnEliminer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.btnEliminer.Location = New Point(312, 9)
        Me.btnEliminer.Name = "btnEliminer"
        Me.btnEliminer.Size = New Size(90, 27)
        Me.btnEliminer.TabIndex = 0
        Me.btnEliminer.Text = "Eliminer !"
        '
        'lstTrace
        '
        Me.lstTrace.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.lstTrace.ItemHeight = 16
        Me.lstTrace.Location = New Point(10, 9)
        Me.lstTrace.Name = "lstTrace"
        Me.lstTrace.Size = New Size(292, 228)
        Me.lstTrace.TabIndex = 1
        '
        'frmElimineDoublons
        '
        Me.AutoScaleBaseSize = New Size(6, 15)
        Me.ClientSize = New Size(408, 266)
        Me.Controls.Add(Me.lstTrace)
        Me.Controls.Add(Me.btnEliminer)
        Me.Name = "frmElimineDoublons"
        Me.Text = "�limine doublons B&M"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Const sDirTemp As String = "D:\StreamRipper\Bide et Musique"
    Const sDirSave As String = "D:\StreamRipper\Save"
    Const sDirOld As String = "D:\StreamRipper\Old"

    <CLSCompliant(False)>
    Function sNomR�duit(f As Scripting.File) As String
        Dim sCl� As String
        sCl� = f.Name
        Dim p As Integer
        p = sCl�.LastIndexOf("("c)
        If p >= 0 Then
            Return RTrim(Microsoft.VisualBasic.Left(sCl�, p))
        Else
            Return Microsoft.VisualBasic.Left(sCl�, sCl�.Length - 4)
        End If
    End Function

    <CLSCompliant(False)>
    Sub DeplaceFichier(ByRef f1 As Scripting.File, ByRef sDest As String, ByRef fldDest As Scripting.Folder)
        Try
            f1.Move(sDest & "\")
        Catch ex As Exception
            Dim f2 As Scripting.File
            f2 = fldDest.Files(f1.Name)
            Debug.Assert(Not (f2 Is Nothing))
            If f1.Size > f2.Size Then
                Kill(sDest & "\" & f1.Name)
                Trace("Kill Sauve\" & f1.Name)
                f1.Move(sDest & "\")
                Trace("Move " & f1.Name & " --> Sauve")
            Else
                Trace("Kill Temp\" & f1.Name)
                f1.Delete()
            End If
        End Try
    End Sub

    Private Sub btnEliminer_Click(sender As Object, e As EventArgs) Handles btnEliminer.Click
        Dim dicFic As New Hashtable
        Dim lstFic As New Queue

        Dim fso As New Scripting.FileSystemObject
        Dim fldTemp, fldSave As Scripting.Folder
        fldTemp = fso.GetFolder(sDirTemp)
        fldSave = fso.GetFolder(sDirSave)
        Dim nbDoub As Integer

        btnEliminer.Enabled = False

        ' Partie 1: on d�place les fichiers de temp --> save
        ' En cas de conflit on garde le plus gros
        For Each f As Scripting.File In fldTemp.Files
            If StrComp(Microsoft.VisualBasic.Right(f.Name, 4), ".mp3", CompareMethod.Text) = 0 Then
                DeplaceFichier(f, sDirSave, fldSave)
            End If
        Next

        ' 2�me partie, �limination des doublons
        Dim sCl� As String
        For Each f As Scripting.File In fldSave.Files
            If StrComp(Microsoft.VisualBasic.Right(f.Name, 4), ".mp3", CompareMethod.Text) <> 0 Then GoTo [continue]
            sCl� = sNomR�duit(f)

            Try
                dicFic.Add(sCl�, f)
            Catch
                Dim f2 As Scripting.File
                f2 = dicFic(sCl�)
                Trace("Doublon possible: " & f2.Name & " (" & f2.Size & ") - " & f.Name & " (" & f.Size & ") - " & sCl�)
                nbDoub += 1

                If f2.Size > f.Size Then
                    Try
                        f.Move(sDirOld & "\" & f.Name)
                        Trace("Move Temp\" & f.Name & " -> old")
                    Catch
                        Kill(sDirOld & "\" & f.Name)
                        Trace("Kill old\" & f.Name)
                        f.Move(sDirOld & "\" & f.Name)
                        Trace(f.Name & " -> old")
                    End Try
                Else
                    Try
                        f2.Move(sDirOld & "\" & f2.Name)
                        Trace(f2.Name & " -> old")
                    Catch
                        Kill(sDirOld & "\" & f2.Name)
                        Trace("Kill old\" & f2.Name)
                        f2.Move(sDirOld & "\" & f2.Name)
                        Trace(f2.Name & " -> old")
                    End Try
                    dicFic.Remove(sCl�)
                    dicFic.Add(sCl�, f)
                End If
            End Try

[continue]:
        Next
        Trace("")
        Trace(dicFic.Count & " fichiers trouv�s, " & nbDoub & " doublons")
        btnEliminer.Enabled = True
    End Sub

    Private Sub Trace(sMsg As String)
        lstTrace.Items.Add(sMsg)
        lstTrace.SetSelected(lstTrace.Items.Count - 1, True)
        lstTrace.Refresh()
    End Sub

End Class