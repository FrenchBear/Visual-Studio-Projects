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

Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Globalization
Imports System.Resources
Imports System.Runtime.CompilerServices

Namespace My.Resources

    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),
     DebuggerNonUserCode(),
     CompilerGenerated(),
     HideModuleName()>
    Friend Module MyResources

        Private resourceMan As ResourceManager

        Private resourceCulture As CultureInfo

        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend ReadOnly Property ResourceManager() As ResourceManager
            Get
                If ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As ResourceManager = New ResourceManager("MyResources", GetType(MyResources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property

        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Property Culture() As CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = Value
            End Set
        End Property
    End Module
End Namespace
