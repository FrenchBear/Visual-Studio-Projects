﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Configuration
Imports System.Runtime.CompilerServices


<CompilerGenerated(),
 GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0"),
 EditorBrowsable(EditorBrowsableState.Advanced)>
Partial Friend NotInheritable Class Settings
    Inherits ApplicationSettingsBase

    Private Shared defaultInstance As Settings = CType(Synchronized(New Settings()), Settings)

#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <DebuggerNonUserCode(), EditorBrowsable(EditorBrowsableState.Advanced)>
    Private Shared Sub AutoSaveSettings(sender As Object, e As EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region

    Public Shared ReadOnly Property [Default]() As Settings
        Get

#If _MyType = "WindowsForms" Then
            If Not addedHandler Then
                SyncLock addedHandlerLockObject
                    If Not addedHandler Then
                        AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                        addedHandler = True
                    End If
                End SyncLock
            End If
#End If
            Return defaultInstance
        End Get
    End Property
End Class

Namespace My

    <HideModuleName(),
     DebuggerNonUserCode(),
     CompilerGenerated()>
    Friend Module MySettingsProperty

        <HelpKeyword("My.Settings")>
        Friend ReadOnly Property Settings() As Settings
            Get
                Return Settings.Default
            End Get
        End Property
    End Module
End Namespace
