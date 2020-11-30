' 095 VB MultiThread
' Essais de multithreading en VB
' 2004-04-17    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(184, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Thread.Start + classe spécifique"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(16, 72)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(184, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Thread pooling"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(16, 112)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(184, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Delegates"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Création de threads :"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(16, 176)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(184, 23)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Queue synchronisée"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Synchronisation :"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(16, 216)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(184, 23)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "Signalisation AutoResetEvent"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(256, 254)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Multithreading en VB.Net"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' 1. Utilisation d'une classe spécifique et de Thread.Start
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tskTâche As New clsTâches
        Dim Thread1 As New System.Threading.Thread(AddressOf tskTâche.UneTâche)

        tskTâche.sTexte = "Toto"
        Thread1.Start()
        Thread1.Join()
        MsgBox("Thread1 a retourné " & tskTâche.bValRet)
    End Sub


    ' 2. Thread pooling
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim stObj1 As New StateObjet
        Dim stObj2 As New StateObjet
        stObj1.iArg = 10 : stObj1.sArg = "toto"
        stObj2.iArg = 33 : stObj2.sArg = "titi"
        Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf MaTâche1), stObj1)
        Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf MaTâche2), stObj2)
        System.Threading.Thread.Sleep(1000)

    End Sub

    Sub MaTâche1(ByVal StateObjet As Object)
        Dim stObj As StateObjet
        stObj = CType(StateObjet, StateObjet)
        MsgBox("sArg: " & stObj.sArg)
        MsgBox("iArg: " & stObj.iArg)
        stObj.sValRet = "Retour de MaTâche1"
    End Sub

    Sub MaTâche2(ByVal StateObjet As Object)
        Dim stObj As StateObjet
        stObj = CType(StateObjet, StateObjet)
        MsgBox("sArg: " & stObj.sArg)
        MsgBox("iArg: " & stObj.iArg)
        stObj.sValRet = "Retour de MaTâche2"
    End Sub


    ' 3. Utilisation de delegates
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cb As New AsyncCallback(AddressOf Me.OnComplete)
        Dim del As New DelegateMaTâche(AddressOf MaTâche)
        del.BeginInvoke(cb, del)
    End Sub

    Sub MaTâche()
        MsgBox("MaTâche")
    End Sub

    Delegate Sub DelegateMaTâche()

    Sub OnComplete(ByVal ar As IAsyncResult)
        '...
    End Sub


    ' 4. Synchronisation
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
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
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim AT As New AsyncTest
        AT.StartTask()
    End Sub
End Class


' 1. Utilisation d'une classe spécifique et de Thread.Start
Class clsTâches
    Friend sTexte As String
    Friend bValRet As Boolean

    Sub UneTâche()
        MsgBox("sTexte: " & sTexte)
        bValRet = True
    End Sub
End Class


' 2. Thread pooling
Class StateObjet
    Friend sArg As String
    Friend iArg As Integer
    Friend sValRet As String
End Class

' 5. Synchronisation via Threading.AutoResetEvent
Class AsyncTest
    Private Shared ReadOnly AsyncOpOk As New System.Threading.AutoResetEvent(False)

    Sub StartTask()
        Dim arg As String = "toto"
        Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf Tâche), arg)
        AsyncOpOk.WaitOne()
        MsgBox("Fin du thread.")
    End Sub

    Sub Tâche(ByVal arg As Object)
        MsgBox("Début du thread")
        System.Threading.Thread.Sleep(4000)
        MsgBox("Argument: " & CStr(arg))
        AsyncOpOk.Set()
    End Sub
End Class