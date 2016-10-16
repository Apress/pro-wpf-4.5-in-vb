Imports System.Globalization

<ValueConversion(GetType(Decimal), GetType(String))> _
Public Class PriceConverter
    Implements IValueConverter

	Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
		Dim price As Decimal = CDec(value)
        Return price.ToString("c", culture)
	End Function

	Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
		Dim price As String = value.ToString()

		Dim result As Decimal
        If Decimal.TryParse(price, System.Globalization.NumberStyles.Any, culture, result) Then
            Return result
        End If
		Return value
	End Function
End Class


