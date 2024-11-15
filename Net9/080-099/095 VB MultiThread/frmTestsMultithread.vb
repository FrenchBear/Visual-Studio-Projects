' 095 VB MultiThread
' Essais de multithreading en VB
'
' 2004-04-17    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
Imports System.ComponentModel
Imports System.Threading

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
    Friend WithEvents Button1 As Button

    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button5 As Button

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Button1 = New Button
        Button2 = New Button
        Button3 = New Button
        Label1 = New Label
        Button4 = New Button
        Label2 = New Label
        Button5 = New Button
        SuspendLayout()
        '
        'Button1
        '
        Button1.Location = New Point(16, 32)
        Button1.Name = "Button1"
        Button1.Size = New Size(184, 23)
        Button1.TabIndex = 0
        Button1.Text = "Thread.Start + classe spécifique"
        '
        'Button2
        '
        Button2.Location = New Point(16, 72)
        Button2.Name = "Button2"
        Button2.Size = New Size(184, 23)
        Button2.TabIndex = 1
        Button2.Text = "Thread pooling"
        '
        'Button3
        '
        Button3.Location = New Point(16, 112)
        Button3.Name = "Button3"
        Button3.Size = New Size(184, 23)
        Button3.TabIndex = 2
        Button3.Text = "Delegates"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Label1.Location = New Point(8, 8)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 16)
        Label1.TabIndex = 3
        Label1.Text = "Création de threads :"
        '
        'Button4
        '
        Button4.Location = New Point(16, 176)
        Button4.Name = "Button4"
        Button4.Size = New Size(184, 23)
        Button4.TabIndex = 4
        Button4.Text = "Queue synchronisée"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Label2.Location = New Point(8, 152)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 16)
        Label2.TabIndex = 5
        Label2.Text = "Synchronisation :"
        '
        'Button5
        '
        Button5.Location = New Point(16, 216)
        Button5.Name = "Button5"
        Button5.Size = New Size(184, 23)
        Button5.TabIndex = 6
        Button5.Text = "Signalisation AutoResetEvent"
        '
        'Form1
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(256, 254)
        Controls.Add(Button5)
        Controls.Add(Label2)
        Controls.Add(Button4)
        Controls.Add(Label1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "Form1"
        Text = "Multithreading en VB.Net"
        ResumeLayout(False)

    End Sub

#End Region

    ' 1. Utilisation d'une classe spécifique et de Thread.Start
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tskTâche As New clsTâches
        Dim Thread1 As New Thread(AddressOf tskTâche.UneTâche)

        tskTâche.sTexte = "Toto"
        Thread1.Start()
        Thread1.Join()
        MsgBox("Thread1 a retourné " & tskTâche.bValRet)
    End Sub

    ' 2. Thread pooling
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim stObj1 As New StateObjet
        Dim stObj2 As New StateObjet
        stObj1.iArg = 10 : stObj1.sArg = "toto"
        stObj2.iArg = 33 : stObj2.sArg = "titi"
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf MaTâche1), stObj1)
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf MaTâche2), stObj2)
        Thread.Sleep(1000)

    End Sub

    Public Shared Sub MaTâche1(StateObjet As Object)
        Dim stObj As StateObjet
        stObj = CType(StateObjet, StateObjet)
        MsgBox("sArg: " & stObj.sArg)
        MsgBox("iArg: " & stObj.iArg)
        stObj.sValRet = "Retour de MaTâche1"
    End Sub

    Public Shared Sub MaTâche2(StateObjet As Object)
        Dim stObj As StateObjet
        stObj = CType(StateObjet, StateObjet)
        MsgBox("sArg: " & stObj.sArg)
        MsgBox("iArg: " & stObj.iArg)
        stObj.sValRet = "Retour de MaTâche2"
    End Sub

    ' 3. Utilisation de delegates
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cb As New AsyncCallback(AddressOf OnComplete)
        Dim del As New DelegateMaTâche(AddressOf MaTâche)
        del.BeginInvoke(cb, del)
    End Sub

    Public Shared Sub MaTâche()
        MsgBox("MaTâche")
    End Sub

    Public Delegate Sub DelegateMaTâche()

    Public Shared Sub OnComplete(ar As IAsyncResult)
        '...
    End Sub

    ' 4. Synchronisation
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim maQ As New Queue
        maQ.Enqueue("Il était")
        maQ.Enqueue("un petit")
        maQ.Enqueue("navire.")

        Dim maQS As Queue = Queue.Synchronized(maQ)
        MsgBox("maQ.IsSynchronized: " & maQ.IsSynchronized)
        MsgBox("maQS.IsSynchronized: " & maQS.IsSynchronized)

        SyncLock maQ.SyncRoot
            '... enum
        End SyncLock
    End Sub

    ' 5. Synchronisation via Threading.AutoResetEvent
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim AT As New AsyncTest
        AT.StartTask()
    End Sub

End Class

' 1. Utilisation d'une classe spécifique et de Thread.Start
Friend Class clsTâches
    Friend sTexte As String
    Friend bValRet As Boolean

    Public Sub UneTâche()
        MsgBox("sTexte: " & sTexte)
        bValRet = True
    End Sub

End Class

' 2. Thread pooling
Friend Class StateObjet
    Friend sArg As String
    Friend iArg As Integer
    Friend sValRet As String
End Class

' 5. Synchronisation via Threading.AutoResetEvent
Friend Class AsyncTest
    Private Shared ReadOnly AsyncOpOk As New AutoResetEvent(False)

    Public Sub StartTask()
        Dim arg As String = "toto"
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Tâche), arg)
        AsyncOpOk.WaitOne()
        MsgBox("Fin du thread.")
    End Sub

    Public Sub Tâche(arg As Object)
        MsgBox("Début du thread")
        Thread.Sleep(4000)
        MsgBox("Argument: " & CStr(arg))
        AsyncOpOk.Set()
    End Sub

End Class
