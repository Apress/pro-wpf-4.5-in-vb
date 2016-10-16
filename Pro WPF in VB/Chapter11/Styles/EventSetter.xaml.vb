Public Class EventSetter

    Private Sub element_MouseEnter(ByVal sender As Object, ByVal e As MouseEventArgs)
        CType(sender, TextBlock).Background = New SolidColorBrush(Colors.LightGoldenrodYellow)
    End Sub
    Private Sub element_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs)
        CType(sender, TextBlock).Background = Nothing
    End Sub
End Class