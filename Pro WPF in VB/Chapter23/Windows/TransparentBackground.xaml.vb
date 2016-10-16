Public Class TransparentBackground

    Private Sub window_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Me.DragMove()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.Close()
    End Sub
End Class