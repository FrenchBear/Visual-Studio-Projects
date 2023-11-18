' Generic Structure
'
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7

Structure Couple(Of t1)
    Dim x As t1
    Dim y As t1
End Structure

Structure NullableType(Of t As IComparable)
    Implements IComparable

    Private x As t
    Private Shared NullValue As t
    Private bIsNull As Boolean

    Shared Sub New()
        Dim ty As Type = GetType(t)
        Select Case ty.Name
            Case "Int16" : NullValue = CType(CType(-32768, Object), t)
            Case "Int32" : NullValue = CType(CType(-2147483648, Object), t)
            Case Else : Stop
        End Select
        Dim x As Object = ty.FullName
    End Sub

    Sub New(vNull As t)
        NullValue = vNull
    End Sub

    Public Property Value() As t
        Get
            Return x
        End Get
        Set(Value As t)
            x = Value
            bIsNull = NullValue.CompareTo(x) = 0
        End Set
    End Property

    Public ReadOnly Property IsNull() As Boolean
        Get
            Return bIsNull
        End Get
    End Property

    Public Sub SetToNull()
        bIsNull = True
        x = NullValue
    End Sub

    ' Complètement idiot comme conversion !
    Public Shared Widening Operator CType(v As Integer) As NullableType(Of t)
        Dim y As NullableType(Of t)
        y.Value = CType(CType(v, Object), t)                ' ?
        Return y
    End Operator

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Return x.CompareTo(obj)
    End Function

End Structure
