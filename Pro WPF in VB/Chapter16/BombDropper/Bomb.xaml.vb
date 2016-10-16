Public Class Bomb
    Private _isFalling As Boolean
    Public Property IsFalling() As Boolean
        Get
            Return _isFalling
        End Get
        Set(ByVal value As Boolean)
            _isFalling = value
        End Set
    End Property


End Class
