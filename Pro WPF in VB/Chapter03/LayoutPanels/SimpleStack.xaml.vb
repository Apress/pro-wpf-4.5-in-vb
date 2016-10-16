Public Class SimpleStack

    Private Sub chkVertical_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        stackPanel1.Orientation = Orientation.Horizontal
    End Sub

    Private Sub chkVertical_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        stackPanel1.Orientation = Orientation.Vertical
    End Sub
End Class