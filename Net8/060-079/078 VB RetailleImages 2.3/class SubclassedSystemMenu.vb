' SubclassedSystemMenu
' A convenient way to subclass system menu commands
' From http://www.codeproject.com/vb/net/SubclassedSystemMenu.asp
'
' 2006-05-03    PV
' 2021-12-05    PV      AppendMenuW and parameter marshalling
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8

Imports System.Runtime.InteropServices
''' <summary>
''' A convenient class to manage system menu commands
''' </summary>
''' <remarks>From http://www.codeproject.com/vb/net/SubclassedSystemMenu.asp</remarks>
Public Class SubclassedSystemMenu
    Inherits NativeWindow
    Implements IDisposable

#Region "Win32 API Declares"
    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal bRevert As Boolean) As Integer

    Private Declare Function AppendMenu Lib "user32" Alias "AppendMenuW" (hMenu As Int32, wFlags As Int32, wIDNewItem As Int32, <MarshalAs(UnmanagedType.LPWStr)> lpNewItem As String) As Int32
#End Region

#Region "Constants"
    Private Const MF_STRING As Integer = &H0       ' Menu string format
    Private Const MF_SEPARATOR As Integer = &H800  ' Menu separator
    Private Const WM_SYSCOMMAND As Integer = &H112 ' System menu 
    Private Const ID_ABOUT As Integer = 1000       ' Our ID for the new menu item
#End Region

#Region "Member Variables"
    Private ReadOnly mintSystemMenu As Integer = 0                 ' Parent system menu handle
    Private ReadOnly mintHandle As Integer = 0                     ' Local parent window handle
    Private ReadOnly mstrMenuItemText As String = String.Empty   ' New menu item text
#End Region

#Region "Events"
    Public Event LaunchDialog()
#End Region

#Region "Constructor"
    '========================================================
    '
    '   Method Name:        New
    '	Description:	    Constructor. Creates menu items and assigns subclass
    '
    '   Inputs:             intWindowHandle : Parent window handle for message 
    '                                         subclass and adding new menu items 
    '                                         to parent system menu
    '
    '   Return Value:       None
    '
    '========================================================
    Public Sub New(ByVal intWindowHandle As Integer,
                   ByVal strMenuItemText As String)

        Me.AssignHandle(New IntPtr(intWindowHandle))

        mintHandle = intWindowHandle
        mstrMenuItemText = strMenuItemText

        ' Retrieve the system menu handle
        mintSystemMenu = GetSystemMenu(mintHandle, 0)

        If AddNewSystemMenuItem() = False Then
            Throw New Exception("Unable to add new system menu items")
        End If

    End Sub
#End Region

#Region "Methods"
    <DebuggerStepThrough()>
    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case WM_SYSCOMMAND

                MyBase.WndProc(m)

                If m.WParam.ToInt32 = ID_ABOUT Then
                    If mintSystemMenu <> 0 Then
                        RaiseEvent LaunchDialog()
                    End If
                End If

            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

    <DebuggerStepThrough()>
    Public Sub Dispose() Implements IDisposable.Dispose
        If Not Me.Handle.Equals(IntPtr.Zero) Then
            GC.SuppressFinalize(Me)
            Me.ReleaseHandle()
        End If
    End Sub

    ''' <summary>
    ''' Adds system menu items
    ''' </summary>
    ''' <returns>True if successful, False else</returns>
    Private Function AddNewSystemMenuItem() As Boolean
        Try
            ' Append the extra system menu items
            Return AppendToSystemMenu(mintSystemMenu, mstrMenuItemText)

        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Adds system menu items (Separator and About...?)
    ''' </summary>
    ''' <param name="intHandle">System Menu handle</param>
    ''' <param name="strText">Text for new menu item</param>
    ''' <returns>True if successful, False else</returns>
    Private Shared Function AppendToSystemMenu(ByVal intHandle As Integer, ByVal strText As String) As Boolean
        Try
            ' Add the seperator menu item
            Dim intRet As Integer = AppendMenu(intHandle, MF_SEPARATOR, 0, String.Empty)

            ' Add the About... menu item
            intRet = AppendMenu(intHandle, MF_STRING, ID_ABOUT, strText)

            If intRet = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

End Class

