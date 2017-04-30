' 229 VB IEnumerable Generic
' 2012-02-25	PV  VS2010

Module Module1
    Sub Main()
        Dim cc As CityCollection = New CityCollection
        For Each city As String In cc
            Console.WriteLine(city)
        Next
        Console.ReadLine()
    End Sub
End Module


Class CityCollection
    Implements IEnumerable(Of String)

    Dim m_Cities() As String = {"New York", "Paris", "London"}

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of String) Implements System.Collections.Generic.IEnumerable(Of String).GetEnumerator
        Return New MyEnumerator(Me)
    End Function

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return New MyEnumerator(Me)
    End Function

    Class MyEnumerator
        Implements IEnumerator(Of String)

        Dim m_Collection As CityCollection
        Dim m_current As Integer

        Public Sub New(ByVal collection As CityCollection)
            m_Collection = collection        ' copie or clone ?
            m_current = -1
        End Sub

        Public ReadOnly Property Current() As String Implements System.Collections.Generic.IEnumerator(Of String).Current
            Get
                If m_current = -1 Then Throw New InvalidOperationException
                Return m_Collection.m_Cities(m_current)
            End Get
        End Property

        Public ReadOnly Property Current1() As Object Implements System.Collections.IEnumerator.Current
            Get
                Return Current()
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            m_current += 1
            Return m_current < m_Collection.m_Cities.Length
        End Function

        Public Sub Reset() Implements System.Collections.IEnumerator.Reset
            m_current = -1
        End Sub

        Private disposed As Boolean = False

        ' IDisposable
        Private Overloads Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposed Then
                If disposing Then
                    ' TODO: put code to dispose managed resources
                End If

                ' TODO: put code to free unmanaged resources here
            End If
            Me.disposed = True
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




Public Interface Machin
    Function Bidule(ByVal i As Integer) As Integer
End Interface


Partial Public Class toto
    Private Function MaFonction(ByVal a As Integer, ByVal b As Integer) As Machin
        Return New Internal(a, b)
    End Function

    Public Class Internal : Implements Machin
        Dim m_a, m_b As Integer

        Public Sub New(ByVal a As Integer, ByVal b As Integer)
            m_a = a
            m_b = b
        End Sub

        Function Bidule(ByVal i As Integer) As Integer Implements Machin.Bidule
            Return m_a * i + m_b
        End Function
    End Class

    Public Function zap(ByVal i As Integer) As Integer
        Dim x As IEnumerable
        x = (New AboutBox1()).Controls
        Dim c As Windows.Forms.Control
        For Each c In x

        Next

        'Dim k As Collection

        Return MaFonction(2, 3).Bidule(i)
    End Function

End Class
