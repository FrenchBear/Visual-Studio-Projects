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
    Friend Module Resources

        Private resourceMan As ResourceManager

        Private resourceCulture As CultureInfo

        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend ReadOnly Property ResourceManager() As ResourceManager
            Get
                If ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As ResourceManager = New ResourceManager("AfficheImage2.Resources", GetType(Resources).Assembly)
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

        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property APropos() As Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("APropos", resourceCulture)
                Return CType(obj, Bitmap)
            End Get
        End Property

        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property AuHasard() As Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("AuHasard", resourceCulture)
                Return CType(obj, Bitmap)
            End Get
        End Property

        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Dernier() As Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Dernier", resourceCulture)
                Return CType(obj, Bitmap)
            End Get
        End Property

        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Ouvrir() As Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Ouvrir", resourceCulture)
                Return CType(obj, Bitmap)
            End Get
        End Property

        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Précédent() As Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Précédent", resourceCulture)
                Return CType(obj, Bitmap)
            End Get
        End Property

        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Premier() As Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Premier", resourceCulture)
                Return CType(obj, Bitmap)
            End Get
        End Property

        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Retour() As Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Retour", resourceCulture)
                Return CType(obj, Bitmap)
            End Get
        End Property

        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Suivant() As Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Suivant", resourceCulture)
                Return CType(obj, Bitmap)
            End Get
        End Property

        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Supprimer() As Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Supprimer", resourceCulture)
                Return CType(obj, Bitmap)
            End Get
        End Property
    End Module
End Namespace
