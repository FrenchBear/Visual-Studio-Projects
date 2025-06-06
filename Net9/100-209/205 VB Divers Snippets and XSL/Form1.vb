﻿' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2021-12-05 	PV		String marshalling
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0060 ' Remove unused parameter

Imports System.Runtime.InteropServices

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CallMessageBox()
    End Sub

    ' Defines the MessageBox function.
    Friend Declare Auto Function Win32MessageBox Lib "user32.dll" Alias "MessageBoxW" (hWnd As Integer, <MarshalAs(UnmanagedType.LPWStr)> txt As String, <MarshalAs(UnmanagedType.LPWStr)> caption As String, Type As Integer) As Integer

    ' Calls the MessageBox function.
    Public Shared Sub CallMessageBox()
        Dim ret = Win32MessageBox(0, "Here's a MessageBox\r\nAé♫山𝄞🐗 🐱‍💻 🧝‍♂️", "Platform Invoke Sample", 0)
    End Sub

    <Serializable()>
    Public Class YourProblemException
        Inherits Exception

        Public Sub New()
            ' Add other code for custom properties here.
        End Sub

        Public Sub New(message As String)
            MyBase.New(message)
            ' Add other code for custom properties here.
        End Sub

        Public Sub New(message As String, inner As Exception)
            MyBase.New(message, inner)
            ' Add other code for custom properties here.
        End Sub

        'Public Sub New(info As SerializationInfo, context As StreamingContext)
        '    MyBase.New(info, context)
        '    ' Insert code here for custom properties here.
        'End Sub

    End Class

    Public Structure Kustomer
        Public Property Name As String
    End Structure

    Public Enum EvenNumbers
        Two = 2
        Four = 4
        Six = 6
    End Enum

    Public Class Class1
        Private ReadOnly arrayOfStrings(25) As String

        Default Public Property MyProperty(Index As Integer) As String
            Get
                If Index < arrayOfStrings.Length AndAlso Index >= 0 Then
                    Return arrayOfStrings(Index)
                Else
                    Throw New ArgumentOutOfRangeException(NameOf(Index))
                End If
            End Get
            Set(Value As String)
                If Index < arrayOfStrings.Length AndAlso Index >= 0 Then
                    arrayOfStrings(Index) = Value
                Else
                    Throw New ArgumentOutOfRangeException(NameOf(Index))
                End If
            End Set
        End Property

    End Class

    Public Shared Sub toto()
        Dim x As New Class1
        x(1) = "toto"
    End Sub

    'Private ReadOnly d As New Djctionary(Of String, Integer)
    'Private ReadOnly e As New Djctionary(Of Integer, String)

    Public Class Djctionary(Of TEntry, TKey As IComparable)

        Public Sub Add(e As TEntry, k As TKey)
            ' Add code here to store the entryType instance, e,
            ' in a collection created and maintained by the
            ' class.
        End Sub

        Public Function Find(k As TKey) As TEntry
            ' Add code here to find the entryType instance
            ' associated with the key, k.
        End Function

    End Class

    'Private Shared Sub ParseAnEmailAddress(email As String, ByRef user As String, ByRef provider As String)
    '    Try
    '        Dim parts() As String = email.Split("@".ToCharArray, 2)
    '        user = parts(0)
    '        provider = parts(1)
    '    Catch
    '        user = Nothing
    '        provider = Nothing
    '        Throw New Exception("Email address is not valid. The expected format is user@provider.")
    '    End Try
    'End Sub

    Public Shared Sub CopyToClipboard()
        Dim c As New Customer With {
            .Name = "Maria"
        }
        Dim ido As IDataObject = New DataObject
        ido.SetData(Customer.Format.Name, False, c)
        Clipboard.SetDataObject(ido)
    End Sub

    Public Shared Sub RetrieveFromClipboard()
        Dim ido As IDataObject = Clipboard.GetDataObject()
        If ido.GetDataPresent(Customer.Format.Name) Then
            Dim c As Customer = CType(ido.GetData(Customer.Format.Name), Customer)
            MsgBox(c.Name)
        End If
    End Sub

    <Serializable()> Public Class Customer
        Private m As String

        Private Shared m_format As DataFormats.Format

        Public Shared Property Format() As DataFormats.Format
            Get
                Return m_format
            End Get
            Set(Value As DataFormats.Format)
                m_format = Value
            End Set
        End Property

        Shared Sub New()
            m_format = DataFormats.GetFormat(GetType(Customer).FullName)
        End Sub

        Public Property Name() As String
            Get
                Return m
            End Get
            Set(Value As String)
                m = Value
            End Set
        End Property

    End Class

End Class
