' 64 VB Multithread
' Essais de programmation multithread en VB
' Utilisation de SyncLock
' 2001-08-19    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010


Public Class frmTest
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents btnDelegate As System.Windows.Forms.Button
    Friend WithEvents btnThread As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnThread = New System.Windows.Forms.Button()
        Me.btnDelegate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnThread
        '
        Me.btnThread.Location = New System.Drawing.Point(8, 52)
        Me.btnThread.Name = "btnThread"
        Me.btnThread.TabIndex = 1
        Me.btnThread.Text = "Thread"
        '
        'btnDelegate
        '
        Me.btnDelegate.Location = New System.Drawing.Point(8, 12)
        Me.btnDelegate.Name = "btnDelegate"
        Me.btnDelegate.TabIndex = 1
        Me.btnDelegate.Text = "Delegate"
        '
        'frmTest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnThread, Me.btnDelegate})
        Me.Name = "frmTest"
        Me.Text = "Tests SyncLock"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Sub Trace(ByVal sMsg As String)
        Debug.WriteLine(sMsg)
    End Sub


    Shared m As New Mutex()

    Sub Proc1()
        Trace("D�but Proc1")
        SyncLock m
            Trace("D�but section critique Proc1")
            System.Threading.Thread.Sleep(4000)
            Trace("Fin section critique Proc1")
        End SyncLock
        Trace("Fin de Proc1")
    End Sub

    Sub Proc2()
        Trace("D�but Proc2")
        SyncLock m
            Trace("D�but section critique Proc2")
            System.Threading.Thread.Sleep(4000)
            Trace("Fin section critique Proc2")
        End SyncLock
        Trace("Fin Proc2")
    End Sub



    Delegate Sub Proc�dure()

    Private Sub btnDelegate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelegate.Click
        Dim p1 As Proc�dure = AddressOf Proc1
        Dim p2 As Proc�dure = New Proc�dure(AddressOf Proc2)

        Trace("BeginInvoke Proc1")
        Dim ar1 As IAsyncResult = p1.BeginInvoke(Nothing, Nothing)
        System.Threading.Thread.Sleep(1000)
        Trace("BeginInvoke Proc2")
        Dim ar2 As IAsyncResult = p2.BeginInvoke(Nothing, Nothing)
        System.Threading.Thread.Sleep(1000)
        Trace("avant EndInvoke Proc1")
        p1.EndInvoke(ar1)
        Trace("apr�s EndInvoke Proc1")
        Trace("avant EndInvoke Proc2")
        p2.EndInvoke(ar2)
        Trace("apr�s EndInvoke Proc2")
        Trace("Termin�")
    End Sub

    Private Sub btnThread_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThread.Click
        Dim t1, t2 As System.Threading.Thread
        t1 = New System.Threading.Thread(AddressOf Proc1)
        t2 = New System.Threading.Thread(AddressOf Proc2)

        Trace("Start Proc1")
        t1.Start()
        System.Threading.Thread.Sleep(1000)
        Trace("Start Proc2")
        t2.Start()
        System.Threading.Thread.Sleep(1000)

        Trace("attente fin Proc1")
        While t1.IsAlive
            System.Threading.Thread.Sleep(100)
        End While
        Trace("Proc1 termin�")

        Trace("attente fin Proc2")
        While t2.IsAlive
            System.Threading.Thread.Sleep(100)
        End While
        Trace("Proc2 termin�")

        Trace("Termin�")
    End Sub

End Class


Public Class Mutex

End Class
