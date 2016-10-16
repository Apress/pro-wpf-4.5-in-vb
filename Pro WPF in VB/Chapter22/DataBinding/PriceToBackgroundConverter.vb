Imports System.Globalization
Imports StoreDatabase

Public Class PriceToBackgroundConverter
	Implements IValueConverter

    Private _highlightBrush As Brush
    Public Property HighlightBrush() As Brush
        Get
            Return _highlightBrush
        End Get
        Set(ByVal value As Brush)
            _highlightBrush = value
        End Set
    End Property

    Private _minPrice As Decimal
    Public Property MinPrice() As Decimal
        Get
            Return _minPrice
        End Get
        Set(ByVal value As Decimal)
            _minPrice = value
        End Set
    End Property

	Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
		Dim product As Product = CType(value, Product)

		If product.UnitCost >= MinPrice Then
			Return HighlightBrush
		Else
			Return Brushes.Transparent
		End If
	End Function

	Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
		Throw New NotSupportedException()
	End Function

End Class

