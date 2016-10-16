Public Class ScrollableTextBoxColumn

    Private Sub LineUp(ByVal sender As Object, ByVal e As RoutedEventArgs)
        scroller.LineUp()
    End Sub
    Private Sub LineDown(ByVal sender As Object, ByVal e As RoutedEventArgs)
        scroller.LineDown()
    End Sub
    Private Sub PageUp(ByVal sender As Object, ByVal e As RoutedEventArgs)
        scroller.PageUp()
    End Sub
    Private Sub PageDown(ByVal sender As Object, ByVal e As RoutedEventArgs)
        scroller.PageDown()
    End Sub
End Class