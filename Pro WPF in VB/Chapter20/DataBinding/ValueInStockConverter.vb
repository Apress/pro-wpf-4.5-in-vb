Public Class ValueInStockConverter
    Implements IMultiValueConverter

    Public Function Convert(ByVal values As Object(), ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IMultiValueConverter.Convert
        ' Return the total value of all the items in stock.
        Dim unitCost As Decimal = CDec(values(0))
        Dim unitsInStock As Integer = CInt(Fix(values(1)))
        Return unitCost * unitsInStock
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetTypes As Type(), ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Throw New NotSupportedException()
    End Function
End Class
