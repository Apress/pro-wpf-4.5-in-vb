Public Class PriceToBackgroundConverter
    Implements IValueConverter

    Private _minimumPriceToHighlight As Decimal
    Public Property MinimumPriceToHighlight() As Decimal
        Get
            Return _minimumPriceToHighlight
        End Get
        Set(ByVal value As Decimal)
            _minimumPriceToHighlight = value
        End Set
    End Property

    Private _highlightBrush As Brush
    Public Property HighlightBrush() As Brush
        Get
            Return _highlightBrush
        End Get
        Set(ByVal value As Brush)
            _highlightBrush = value
        End Set
    End Property

    Private _defaultBrush As Brush
    Public Property DefaultBrush() As Brush
        Get
            Return _defaultBrush
        End Get
        Set(ByVal value As Brush)
            _defaultBrush = value
        End Set
    End Property

    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Dim price As Decimal = CDec(value)
        If price >= MinimumPriceToHighlight Then
            Return HighlightBrush
        Else
            Return DefaultBrush
        End If
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotSupportedException()
    End Function
End Class


