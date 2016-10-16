Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Data
Imports System.Windows.Media.Imaging
Imports System.IO

Public Class ImagePathConverter
    Implements IValueConverter

    Private _imageDirectory As String = Directory.GetCurrentDirectory()
    Public Property ImageDirectory() As String
        Get
            Return _imageDirectory
        End Get
        Set(ByVal value As String)
            _imageDirectory = value
        End Set
    End Property

	Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
		Dim imagePath As String = Path.Combine(ImageDirectory, CStr(value))
		Return New BitmapImage(New Uri(imagePath))
	End Function

	Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
		Throw New NotSupportedException("The method or operation is not implemented.")
	End Function
End Class
