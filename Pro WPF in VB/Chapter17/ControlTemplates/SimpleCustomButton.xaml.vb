Public Class SimpleCustomButton

    Private Sub Clicked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show("You clicked " & (CType(sender, Button)).Name)
    End Sub

End Class