Public Class TimeSpanConverter
    Implements IValueConverter
    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Try
            Dim time As TimeSpan = CType(value, TimeSpan)
            Return time.TotalSeconds
        Catch
            Return 0
        End Try
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Dim seconds As Double = CDbl(value)
        Return TimeSpan.FromSeconds(seconds)
    End Function
End Class

