﻿' Extensions of IEnumerable(Of T)
' 2008-08-20    PV
' 2008-12-03    PV  Compte (efficient implementation of count)
' 2012-02-25	PV  VS2010

Imports System.Runtime.CompilerServices


Module Module1

    Sub Main()
        Dim fruits() As String =
            {"apple", "passionfruit", "banana", "mango",
             "orange", "blueberry", "grape", "strawberry"}

        Dim ExtendedList As IEnumerable(Of String) = fruits.AddHeadElement("pinapple")

        ' Display the results.
        Dim output As New System.Text.StringBuilder
        For Each fruit As String In ExtendedList
            output.AppendLine(fruit)
        Next
        MsgBox(output.ToString() & "(count=" & ExtendedList.Compte.ToString & ")")


        ' Create a collection of sequential integers
        ' from 1 to 10 and project their squares.
        ' Then insert element 473 at the head of this list
        Dim squares As IEnumerable(Of Integer) =
            Enumerable.Range(1, 10).Select(Function(x) x * x).AddHeadElement(473)

        ' Display the output.
        output = New System.Text.StringBuilder
        For Each num As Integer In squares
            output.AppendLine(num)
        Next
        MsgBox(output.ToString())


        ' Filter this list to retain even numbers
        'Dim FindEvenNumber As Predicate(Of Integer) = AddressOf IsEvenInteger
        'Dim EvenList As IEnumerable(Of Integer) = squares.Filter(FindEvenNumber)
        Dim EvenList As IEnumerable(Of Integer) = squares.Filter(Function(n As Integer) (n And 1) = 0)

        output = New System.Text.StringBuilder
        For Each num As Integer In EvenList
            output.AppendLine(num)
        Next
        MsgBox(output.ToString())

        'Dim P As Predicate(Of Integer) = AddressOf IsEvenInteger
        'Dim Q As Func(Of Integer, Boolean) = AddressOf IsEvenInteger
        'P = Q

        'Dim P2 As Predicate(Of Integer)
        'Dim PP = Function(n As Integer) n <> 0
        'P2 = Function(n As Integer) n <> 0
    End Sub

    Function IsEvenInteger(ByVal n As Integer) As Boolean
        Return (n And 1) = 0
    End Function



    ' Extension of IEnumerable(T)

    <ExtensionAttribute()>
    Public Function AddHeadElement(Of TSource)(ByVal source As IEnumerable(Of TSource), ByVal HeadElement As TSource) As IEnumerable(Of TSource)
        Return New ExtendedEnumeration(Of TSource)(source, HeadElement)
    End Function

    Public Class ExtendedEnumeration(Of TSource)
        Implements IEnumerable(Of TSource)
        Implements IDisposable


        Private _Source As IEnumerable(Of TSource)
        Private _HeadElement As TSource

        Public Sub New(ByVal Source As IEnumerable(Of TSource), ByVal HeadElement As TSource)
            _Source = Source
            _HeadElement = HeadElement
        End Sub

        Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of TSource) Implements System.Collections.Generic.IEnumerable(Of TSource).GetEnumerator
            Return New ExtendedEnumerator(Of TSource)(_Source, _HeadElement)
        End Function

        Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return New ExtendedEnumerator(Of TSource)(_Source, _HeadElement)
        End Function


        Private Class ExtendedEnumerator(Of T)
            Implements IEnumerator(Of T)
            Implements IDisposable

            Private _SourceEnumerator As IEnumerator(Of T)
            Private _HeadElement As T
            Private _Position As Integer

            Public Sub New(ByVal Source As IEnumerable(Of T), ByVal HeadElement As T)
                _SourceEnumerator = Source.GetEnumerator
                _HeadElement = HeadElement
                _Position = -2
            End Sub


            Public ReadOnly Property Current() As T Implements System.Collections.Generic.IEnumerator(Of T).Current
                Get
                    If _Position = -2 Then
                        Throw New InvalidOperationException("InvalidOperation_EnumNotStarted")
                    End If
                    If _Position = -1 Then
                        _Position = 0
                        Return _HeadElement
                    End If
                    Return _SourceEnumerator.Current
                End Get
            End Property

            Public ReadOnly Property Current1() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return Current
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                If _Position = -2 Then
                    _Position = -1
                    Return True             ' HeadElement can always be returned
                End If
                Return _SourceEnumerator.MoveNext
            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                _Position = -2
                _SourceEnumerator.Reset()
            End Sub


            Private disposedValue As Boolean = False        ' To detect redundant calls

            ' IDisposable
            Protected Overridable Sub Dispose(ByVal disposing As Boolean)
                If Not Me.disposedValue Then
                    If disposing Then
                        ' TODO: free other state (managed objects).
                    End If

                    ' TODO: free your own state (unmanaged objects).
                    ' TODO: set large fields to null.
                End If
                Me.disposedValue = True
            End Sub

#Region " IDisposable Support "
            ' This code added by Visual Basic to correctly implement the disposable pattern.
            Public Sub Dispose() Implements IDisposable.Dispose
                ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
                Dispose(True)
                GC.SuppressFinalize(Me)
            End Sub
#End Region

        End Class


        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class



    ' Extension of IEnumerable(Of T)
    ' Returns only elements that match a given predicate

    <ExtensionAttribute()>
    Public Function Filter(Of TSource)(ByVal source As IEnumerable(Of TSource), ByVal FilterPredicate As Predicate(Of TSource)) As IEnumerable(Of TSource)
        Return New FilteredEnumeration(Of TSource)(source, FilterPredicate)
    End Function

    Public Class FilteredEnumeration(Of TSource)
        Implements IEnumerable(Of TSource)
        Implements IDisposable


        Private _Source As IEnumerable(Of TSource)
        Private _FilterPredicate As Predicate(Of TSource)

        Public Sub New(ByVal Source As IEnumerable(Of TSource), ByVal FilterPredicate As Predicate(Of TSource))
            _Source = Source
            _FilterPredicate = FilterPredicate
        End Sub


        Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of TSource) Implements System.Collections.Generic.IEnumerable(Of TSource).GetEnumerator
            Return New FilteredEnumerator(Of TSource)(_Source, _FilterPredicate)
        End Function

        Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return New FilteredEnumerator(Of TSource)(_Source, _FilterPredicate)
        End Function


        Private Class FilteredEnumerator(Of T)
            Implements IEnumerator(Of T)
            Implements IDisposable

            Private _SourceEnumerator As IEnumerator(Of T)
            Private _FilterPredicate As Predicate(Of T)
            Private _Position As Integer

            Public Sub New(ByVal Source As IEnumerable(Of T), ByVal FilterPredicate As Predicate(Of T))
                _SourceEnumerator = Source.GetEnumerator
                _FilterPredicate = FilterPredicate
                _Position = -1
            End Sub


            Public ReadOnly Property Current() As T Implements System.Collections.Generic.IEnumerator(Of T).Current
                Get
                    If _Position = -1 Then
                        Throw New InvalidOperationException("InvalidOperation_EnumNotStarted")
                    End If
                    ' By convention, _SourceEnumerator is always positionned on an element
                    ' that matches _FilterPredicate
                    Return _SourceEnumerator.Current
                End Get
            End Property

            Public ReadOnly Property Current1() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return Current
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                If _Position = 1 Then Return False ' Already reached end of list
                _Position = 0
                Do
                    If Not _SourceEnumerator.MoveNext Then
                        ' Just reached end of list
                        _Position = 1
                        Return False
                    End If

                    If _FilterPredicate(_SourceEnumerator.Current) Then
                        ' Found a matching element, yield return it
                        Return True
                    End If
                Loop
            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                _Position = -1
                _SourceEnumerator.Reset()
            End Sub


            Private disposedValue As Boolean = False        ' To detect redundant calls

            ' IDisposable
            Protected Overridable Sub Dispose(ByVal disposing As Boolean)
                If Not Me.disposedValue Then
                    If disposing Then
                        ' TODO: free other state (managed objects).
                    End If

                    ' TODO: free your own state (unmanaged objects).
                    ' TODO: set large fields to null.
                End If
                Me.disposedValue = True
            End Sub

#Region " IDisposable Support "
            ' This code added by Visual Basic to correctly implement the disposable pattern.
            Public Sub Dispose() Implements IDisposable.Dispose
                ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
                Dispose(True)
                GC.SuppressFinalize(Me)
            End Sub
#End Region

        End Class



        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class


    ' Efficient implementation of count
    <ExtensionAttribute()>
    Public Function Compte(Of TSource)(ByVal source As IEnumerable(Of TSource)) As Integer
        If source Is Nothing Then Throw New ArgumentNullException("source")

        ' If the real object supports ICollection then it implements count, use it
        Dim is2 As ICollection(Of TSource) = TryCast(source, ICollection(Of TSource))
        If (Not is2 Is Nothing) Then Return is2.Count
        ' Non-generic version
        Dim is3 As ICollection = TryCast(source, ICollection)
        If (Not is3 Is Nothing) Then Return is3.Count

        Dim num As Integer = 0
        Using enumerator As IEnumerator(Of TSource) = source.GetEnumerator
            Do While enumerator.MoveNext
                num += 1
            Loop
        End Using
        Return num
    End Function

End Module