Imports System.Globalization

Public Class PriceRangeProductGrouper
    Implements IValueConverter

    Private _groupInterval As Integer
    Public Property GroupInterval() As Integer
        Get
            Return _groupInterval
        End Get
        Set(ByVal value As Integer)
            _groupInterval = value
        End Set
    End Property

    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
        Dim price As Decimal = CDec(value)
        If price < GroupInterval Then
            Return String.Format("Less than {0:C}", GroupInterval)
        Else
            Dim interval As Integer = CInt(price / GroupInterval)
            Dim lowerLimit As Integer = interval * GroupInterval
            Dim upperLimit As Integer = (interval + 1) * GroupInterval
            Return String.Format("{0:C} to {1:C}", lowerLimit, upperLimit)
        End If
    End Function

	Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
		Throw New NotSupportedException("This converter is for grouping only.")
	End Function
End Class


