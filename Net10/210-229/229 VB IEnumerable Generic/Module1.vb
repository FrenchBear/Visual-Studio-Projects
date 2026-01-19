' 229 VB IEnumerable Generic
'
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Friend Module Module1
    Public Sub Main()
        Dim cc As New CityCollection
        For Each city As String In cc
            WriteLine(city)
        Next
    End Sub

End Module

Friend Class CityCollection
    Implements IEnumerable(Of String)

    Private ReadOnly m_Cities() As String = {"New York", "Paris", "London"}

    Public Function GetEnumerator() As IEnumerator(Of String) Implements IEnumerable(Of String).GetEnumerator
        Return New MyEnumerator(Me)
    End Function

    Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return New MyEnumerator(Me)
    End Function

    Public Class MyEnumerator
        Implements IEnumerator(Of String)

        Private ReadOnly m_Collection As CityCollection
        Private m_current As Integer

        Public Sub New(collection As CityCollection)
            m_Collection = collection        ' copie or clone ?
            m_current = -1
        End Sub

        Public ReadOnly Property Current() As String Implements IEnumerator(Of String).Current
            Get
                If m_current = -1 Then Throw New InvalidOperationException
                Return m_Collection.m_Cities(m_current)
            End Get
        End Property

        Public ReadOnly Property Current1() As Object Implements IEnumerator.Current
            Get
                Return Current()
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            m_current += 1
            Return m_current < m_Collection.m_Cities.Length
        End Function

        Public Sub Reset() Implements IEnumerator.Reset
            m_current = -1
        End Sub

        Private disposed As Boolean '= False

        ' IDisposable
        Private Overloads Sub Dispose(disposing As Boolean)
            If Not disposed Then
                If disposing Then
                    ' TODO: put code to dispose managed resources
                End If

                ' TODO: put code to free unmanaged resources here
            End If
            disposed = True
        End Sub

#Region " IDisposable Support "

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overrides Sub Finalize()
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(False)
            MyBase.Finalize()
        End Sub

#End Region

    End Class

End Class

Public Interface IMachin

    Function Bidule(i As Integer) As Integer

End Interface

Partial Public Class Toto

    Private Shared Function MaFonction(a As Integer, b As Integer) As IMachin
        Return New Internal(a, b)
    End Function

    Public Class Internal : Implements IMachin

        Private ReadOnly m_a, m_b As Integer

        Public Sub New(a As Integer, b As Integer)
            m_a = a
            m_b = b
        End Sub

        Public Function Bidule(i As Integer) As Integer Implements IMachin.Bidule
            Return (m_a * i) + m_b
        End Function

    End Class

    Public Shared Function Zap(i As Integer) As Integer
        Dim x As IEnumerable
        x = New AboutBox1().Controls
        Dim c As Control
        For Each c In x

        Next

        'Dim k As Collection

        Return MaFonction(2, 3).Bidule(i)
    End Function

End Class
