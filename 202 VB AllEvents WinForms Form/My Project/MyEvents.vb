Namespace My
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            MsgBox("MyApplication_Startup")
        End Sub

        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            MsgBox("MyApplication_Shutdown")
        End Sub

        'Use the editor window dropdowns in the Application pane of the Project Designer to handle MyApplication Events
        '
        'Startup: Raised when the application starts, before the startup form is created.
        'Shutdown: Raised after all application forms are closed.  This event is not raised if the application is terminating abnormally.
        'UnhandledException: Raised if the application encounters an unhandled exception.
        'StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
        'NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
            MsgBox("MyApplication.Finalize")
        End Sub

    End Class
End Namespace
