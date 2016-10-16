Imports System.Globalization

Public Class CustomControlWithCommand

    Public Shared FontUpdateCommand As New RoutedCommand()

    'The ExecutedRoutedEvent Handler
    'if the command target is the TextBox, changes the fontsize to that
    'of the value passed in through the Command Parameter
    Public Sub SliderUpdateExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        Dim source As TextBox = TryCast(sender, TextBox)

        If Not source Is Nothing Then
            If Not e.Parameter Is Nothing Then
                Try
                    If CInt(Fix(e.Parameter)) > 0 AndAlso CInt(Fix(e.Parameter)) <= 60 Then
                        source.FontSize = CInt(Fix(e.Parameter))
                    End If
                Catch
                    MessageBox.Show("in Command " & Constants.vbLf & " Parameter: " & e.Parameter)
                End Try

            End If
        End If
    End Sub

    'The CanExecuteRoutedEvent Handler
    'if the Command Source is a TextBox, then set CanExecute to ture;
    'otherwise, set it to false
    Public Sub SliderUpdateCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        Dim source As TextBox = TryCast(sender, TextBox)

        If Not source Is Nothing Then
            If source.IsReadOnly Then
                e.CanExecute = False
            Else
                e.CanExecute = True
            End If
        End If
    End Sub

    'if the Readonly Box is checked, we need to force the CommandManager
    'to raise the RequerySuggested event.  This will cause the Command Source
    'to query the command to see if it can execute or not.
    Public Sub OnReadOnlyChecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not txtBoxTarget Is Nothing Then
            txtBoxTarget.IsReadOnly = True
            CommandManager.InvalidateRequerySuggested()
        End If
    End Sub

    'if the Readonly Box is checked, we need to force the CommandManager
    'to raise the RequerySuggested event.  This will cause the Command Source
    'to query the command to see if it can execute or not.
    Public Sub OnReadOnlyUnChecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not txtBoxTarget Is Nothing Then
            txtBoxTarget.IsReadOnly = False
            CommandManager.InvalidateRequerySuggested()
        End If
    End Sub
End Class


'Converter to convert the Slider value property to an int
<ValueConversion(GetType(Double), GetType(Integer))> _
Public Class FontStringValueConverter
    Implements IValueConverter
    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
        Dim fontSize As String = CStr(value)
        Dim intFont As Integer

        Try
            intFont = Int32.Parse(fontSize)
            Return intFont
        Catch e As FormatException
            Return Nothing
        End Try
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return Nothing
    End Function
End Class

'Converter to convert the Slider value property to an int
<ValueConversion(GetType(Double), GetType(Integer))> _
Public Class FontDoubleValueConverter
	Implements IValueConverter
	Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
		Dim fontSize As Double = CDbl(value)
		Return CInt(Fix(fontSize))
	End Function

	Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
		Return Nothing
	End Function
End Class