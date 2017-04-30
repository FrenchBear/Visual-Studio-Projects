Public Class HScrollBarNew
    Inherits HScrollBar

    Private m_realMax As Integer

    Public Overloads Property Maximum() As Integer
        Get
            Maximum = m_realMax
        End Get
        Set(ByVal value As Integer)
            m_realMax = value
            MyBase.Maximum = m_realMax + MyBase.LargeChange - 1
        End Set
    End Property

    Public Overloads Property LargeChange() As Integer
        Get
            LargeChange = MyBase.LargeChange
        End Get
        Set(ByVal value As Integer)
            MyBase.LargeChange = value
            MyBase.Maximum = m_realMax + MyBase.LargeChange - 1
        End Set
    End Property

    Public Event ScrollNew()

    Private Sub HScrollBar_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Me.Scroll
        Static lastValue As Integer
        If MyBase.Value <> lastValue Then
            lastValue = MyBase.Value
            RaiseEvent ScrollNew()
        End If
    End Sub
End Class
