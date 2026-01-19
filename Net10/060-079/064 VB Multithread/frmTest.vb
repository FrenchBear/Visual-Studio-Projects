' 64 VB Multithread
' Essais de programmation multithread en VB
' Utilisation de SyncLock
'
' 2001-08-19    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10
Imports System.Threading

#Disable Warning IDE1006 ' Naming Styles

Public Class frmTest
    Inherits Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents btnDelegate As Button
    Friend WithEvents btnThread As Button

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        btnThread = New Button()
        btnDelegate = New Button()
        SuspendLayout()
        '
        'btnThread
        '
        btnThread.Location = New Point(8, 52)
        btnThread.Name = "btnThread"
        btnThread.TabIndex = 1
        btnThread.Text = "Thread"
        '
        'btnDelegate
        '
        btnDelegate.Location = New Point(8, 12)
        btnDelegate.Name = "btnDelegate"
        btnDelegate.TabIndex = 1
        btnDelegate.Text = "Delegate"
        '
        'frmTest
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(296, 273)
        Controls.AddRange(New Control() {btnThread, btnDelegate})
        Name = "frmTest"
        Text = "Tests SyncLock"
        ResumeLayout(False)

    End Sub

#End Region

    Public Shared Sub Trace(sMsg As String)
        Debug.WriteLine(sMsg)
    End Sub

    Private Shared ReadOnly m As New Mutex()

    Public Shared Sub Proc1()
        Trace("Début Proc1")
        SyncLock m
            Trace("Début section critique Proc1")
            Thread.Sleep(4000)
            Trace("Fin section critique Proc1")
        End SyncLock
        Trace("Fin de Proc1")
    End Sub

    Public Shared Sub Proc2()
        Trace("Début Proc2")
        SyncLock m
            Trace("Début section critique Proc2")
            Thread.Sleep(4000)
            Trace("Fin section critique Proc2")
        End SyncLock
        Trace("Fin Proc2")
    End Sub

    Public Delegate Sub Procédure()

    Private Sub btnDelegate_Click(sender As Object, e As EventArgs) Handles btnDelegate.Click
        Dim p1 As Procédure = AddressOf Proc1
        Dim p2 As New Procédure(AddressOf Proc2)

        Trace("BeginInvoke Proc1")
        Dim ar1 As IAsyncResult = p1.BeginInvoke(Nothing, Nothing)
        Thread.Sleep(1000)
        Trace("BeginInvoke Proc2")
        Dim ar2 As IAsyncResult = p2.BeginInvoke(Nothing, Nothing)
        Thread.Sleep(1000)
        Trace("avant EndInvoke Proc1")
        p1.EndInvoke(ar1)
        Trace("après EndInvoke Proc1")
        Trace("avant EndInvoke Proc2")
        p2.EndInvoke(ar2)
        Trace("après EndInvoke Proc2")
        Trace("Terminé")
    End Sub

    Private Sub btnThread_Click(sender As Object, e As EventArgs) Handles btnThread.Click
        Dim t1, t2 As Thread
        t1 = New Thread(AddressOf Proc1)
        t2 = New Thread(AddressOf Proc2)

        Trace("Start Proc1")
        t1.Start()
        Thread.Sleep(1000)
        Trace("Start Proc2")
        t2.Start()
        Thread.Sleep(1000)

        Trace("attente fin Proc1")
        While t1.IsAlive
            Thread.Sleep(100)
        End While
        Trace("Proc1 terminé")

        Trace("attente fin Proc2")
        While t2.IsAlive
            Thread.Sleep(100)
        End While
        Trace("Proc2 terminé")

        Trace("Terminé")
    End Sub

End Class

Public Class Mutex

End Class
