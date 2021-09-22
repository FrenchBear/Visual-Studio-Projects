Public Class CDemo

    Public ReadOnly InstanceID As Integer

    Private Shared NextInstanceID As Integer = 0
    Private Shared ClassInstanceCount As Long = 0

    <DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        InstanceID = NextInstanceID
        NextInstanceID += 1
        ClassInstanceCount += 1
    End Sub

    Protected Overrides Sub Finalize()
        ClassInstanceCount -= 1
    End Sub

    Public Shared ReadOnly Property InstanceCount() As Long
        Get
            Return ClassInstanceCount
        End Get
    End Property

End Class