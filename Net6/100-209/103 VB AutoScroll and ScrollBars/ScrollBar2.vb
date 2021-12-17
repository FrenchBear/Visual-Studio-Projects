' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Public Class HScrollBarNew
    Inherits HScrollBar

    Private m_realMax As Integer

    Public Overloads Property Maximum() As Integer
        Get
            Maximum = m_realMax
        End Get
        Set(value As Integer)
            m_realMax = value
            MyBase.Maximum = m_realMax + MyBase.LargeChange - 1
        End Set
    End Property

    Public Overloads Property LargeChange() As Integer
        Get
            LargeChange = MyBase.LargeChange
        End Get
        Set(value As Integer)
            MyBase.LargeChange = value
            MyBase.Maximum = m_realMax + MyBase.LargeChange - 1
        End Set
    End Property

    Public Event ScrollNew()

    Private Sub HScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles Me.Scroll
        Static lastValue As Integer
        If Value <> lastValue Then
            lastValue = Value
            RaiseEvent ScrollNew()
        End If
    End Sub

End Class