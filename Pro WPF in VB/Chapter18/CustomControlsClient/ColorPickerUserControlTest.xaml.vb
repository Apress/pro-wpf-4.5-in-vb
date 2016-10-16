Public Class ColorPickerUserControlTest

    Private Sub cmdGet_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show(colorPicker.Color.ToString())
    End Sub

    Private Sub cmdSet_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        colorPicker.Color = Colors.Beige
    End Sub

    Private Sub colorPicker_ColorChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Color))
        If Not lblColor Is Nothing Then
            lblColor.Text = "The new color is " & e.NewValue.ToString()
        End If
    End Sub

End Class