' 2012-02-25	PV  VS2010

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0052 ' Remove unread private members
#Disable Warning IDE0051 ' Remove unused private members
#Disable Warning IDE0060 ' Remove unused parameter

Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        CallMessageBox()
    End Sub

    ' Defines the MessageBox function.
    Declare Auto Function Win32MessageBox Lib "user32.dll" Alias "MessageBox" (hWnd As Integer,
txt As String, caption As String, Type As Integer) As Integer

    ' Calls the MessageBox function.
    Public Sub CallMessageBox()
        Win32MessageBox(0, "Here's a MessageBox", "Platform Invoke Sample", 0)
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

        Public Sub New(
info As Runtime.Serialization.SerializationInfo,
context As Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
            ' Insert code here for custom properties here.
        End Sub

    End Class

    Structure Kustomer
        Private nameValue As String

        Public Property Name() As String
            Get
                Return nameValue
            End Get
            Set(value As String)
                nameValue = value
            End Set
        End Property

    End Structure

    Enum EvenNumbers
        Two = 2
        Four = 4
        Six = 6
    End Enum

    Public Class Class1
        Private ReadOnly arrayOfStrings(25) As String

        Default Property MyProperty(Index As Integer) As String
            Get
                If Index < arrayOfStrings.Length AndAlso Index >= 0 Then
                    Return arrayOfStrings(Index)
                Else
                    Throw New ArgumentOutOfRangeException
                End If
            End Get
            Set(Value As String)
                If Index < arrayOfStrings.Length AndAlso Index >= 0 Then
                    arrayOfStrings(Index) = Value
                Else
                    Throw New ArgumentOutOfRangeException
                End If
            End Set
        End Property

    End Class

    Sub toto()
        Dim x As Class1 = New Class1
        x(1) = "toto"
    End Sub

    ReadOnly d As New Djctionary(Of String, Integer)
    ReadOnly e As New Djctionary(Of Integer, String)

    Public Class Djctionary(Of entryType, keyType As IComparable)

        Public Sub Add(e As entryType, k As keyType)
            ' Add code here to store the entryType instance, e,
            ' in a collection created and maintained by the
            ' class.
        End Sub

        Public Function Find(k As keyType) As entryType
            ' Add code here to find the entryType instance
            ' associated with the key, k.
        End Function

    End Class

    Private Sub ParseAnEmailAddress(email As String, ByRef user As String, ByRef provider As String)
        Try
            Dim parts() As String = email.Split("@".ToCharArray, 2)
            user = parts(0)
            provider = parts(1)
        Catch
            user = Nothing
            provider = Nothing
            Throw New Exception("Email address is not valid. The expected format is user@provider.")
        End Try
    End Sub

    Sub CopyToClipboard()
        Dim c As New Customer With {
            .Name = "Maria"
        }
        Dim ido As IDataObject = New DataObject
        ido.SetData(Customer.Format.Name, False, c)
        Clipboard.SetDataObject(ido)
    End Sub

    Sub RetrieveFromClipboard()
        Dim ido As IDataObject = Clipboard.GetDataObject()
        If ido.GetDataPresent(Customer.Format.Name) Then
            Dim c As Customer = CType(ido.GetData(Customer.Format.Name), Customer)
            MsgBox(c.Name)
        End If
    End Sub

    <Serializable()> Public Class Customer
        Private m As String

        Shared m_format As DataFormats.Format

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