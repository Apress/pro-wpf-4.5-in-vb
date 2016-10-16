Imports System.Windows.Media.Animation

Public Class CustomEasingFunction

End Class

Public Class RandomJitterEase
    Inherits EasingFunctionBase
    ' Store a random number generator.
    Private rand As New Random()

    Protected Overrides Function EaseInCore(ByVal normalizedTime As Double) As Double
        'To see the values add code like this:
        'System.Diagnostics.Debug.WriteLine(...)

        ' Make sure there's no jitter in the final value.
        If normalizedTime = 1 Then
            Return 1
        End If

        ' Offset the value by a random amount.
        Return Math.Abs(normalizedTime - CDbl(rand.Next(0, 10)) / (2010 - Jitter))
    End Function

    Public Property Jitter() As Integer
        Get
            Return CInt(GetValue(JitterProperty))
        End Get
        Set(ByVal value As Integer)
            SetValue(JitterProperty, value)
        End Set
    End Property

    Public Shared ReadOnly JitterProperty As DependencyProperty = _
        DependencyProperty.Register("Jitter", GetType(Integer), GetType(RandomJitterEase), _
        New UIPropertyMetadata(1000), New ValidateValueCallback(AddressOf ValidateJitter))

    Private Shared Function ValidateJitter(ByVal value As Object) As Boolean
        Dim jitterValue As Integer = CInt(value)
        Return ((jitterValue <= 2000) AndAlso (jitterValue >= 0))
    End Function

    ' This required override simply provides a live instance of your easing function.
    Protected Overrides Function CreateInstanceCore() As Freezable
        Return New RandomJitterEase()
    End Function
End Class
