#If _MyType <> "Empty" Then

#Disable Warning IDE0051 ' Remove unused private members

Namespace My
    ''' <summary>
    ''' Module used to define the properties that are available in the My Namespace for WPF
    ''' </summary>
    ''' <remarks></remarks>
    <HideModuleName()>
    Module MyWpfExtension
        Private ReadOnly s_Computer As New ThreadSafeObjectProvider(Of Devices.Computer)
        Private ReadOnly s_User As New ThreadSafeObjectProvider(Of ApplicationServices.User)
        Private ReadOnly s_Windows As New ThreadSafeObjectProvider(Of MyWindows)
        Private ReadOnly s_Log As New ThreadSafeObjectProvider(Of Logging.Log)

        ''' <summary>
        ''' Returns the application object for the running application
        ''' </summary>
        Friend ReadOnly Property Application() As Application
            Get
                Return CType(Global.System.Windows.Application.Current, Application)
            End Get
        End Property

        ''' <summary>
        ''' Returns information about the host computer.
        ''' </summary>
        Friend ReadOnly Property Computer() As Devices.Computer
            Get
                Return s_Computer.GetInstance()
            End Get
        End Property

        ''' <summary>
        ''' Returns information for the current user.  If you wish to run the application with the current
        ''' Windows user credentials, call My.User.InitializeWithWindowsUser().
        ''' </summary>
        Friend ReadOnly Property User() As ApplicationServices.User
            Get
                Return s_User.GetInstance()
            End Get
        End Property

        ''' <summary>
        ''' Returns the application log. The listeners can be configured by the application's configuration file.
        ''' </summary>
        Friend ReadOnly Property Log() As Logging.Log
            Get
                Return s_Log.GetInstance()
            End Get
        End Property

        ''' <summary>
        ''' Returns the collection of Windows defined in the project.
        ''' </summary>
        Friend ReadOnly Property Windows() As MyWindows
            <DebuggerHidden()>
            Get
                Return s_Windows.GetInstance()
            End Get
        End Property

        <ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)>
        <MyGroupCollection("System.Windows.Window", "Create__Instance__", "Dispose__Instance__", "My.MyWpfExtenstionModule.Windows")>
        Friend NotInheritable Class MyWindows

            <DebuggerHidden()>
            Private Shared Function Create__Instance__(Of T As {New, Window})(Instance As T) As T
                If Instance Is Nothing Then
                    If s_WindowBeingCreated IsNot Nothing Then
                        If s_WindowBeingCreated.ContainsKey(GetType(T)) = True Then
                            Throw New InvalidOperationException("The window cannot be accessed via My.Windows from the Window constructor.")
                        End If
                    Else
                        s_WindowBeingCreated = New Hashtable()
                    End If
                    s_WindowBeingCreated.Add(GetType(T), Nothing)
                    Return New T()
                    s_WindowBeingCreated.Remove(GetType(T))
                Else
                    Return Instance
                End If
            End Function

            <DebuggerHidden()>
            Private Sub Dispose__Instance__(Of T As Window)(ByRef instance As T)
                instance = Nothing
            End Sub

            <DebuggerHidden()>
            <ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)>
            Public Sub New()
                MyBase.New()
            End Sub

            <ThreadStatic()> Private Shared s_WindowBeingCreated As Hashtable

            <ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> Public Overrides Function Equals(o As Object) As Boolean
                Return MyBase.Equals(o)
            End Function

            <ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> Public Overrides Function GetHashCode() As Integer
                Return MyBase.GetHashCode
            End Function

            <ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)>
            Friend Overloads Function [GetType]() As Type
                Return GetType(MyWindows)
            End Function

            <ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> Public Overrides Function ToString() As String
                Return MyBase.ToString
            End Function

        End Class

    End Module
End Namespace

Partial Class Application
    Inherits Windows.Application

    Friend ReadOnly Property Info() As ApplicationServices.AssemblyInfo
        <DebuggerHidden()>
        Get
            Return New ApplicationServices.AssemblyInfo(Global.System.Reflection.Assembly.GetExecutingAssembly())
        End Get
    End Property

End Class

#End If