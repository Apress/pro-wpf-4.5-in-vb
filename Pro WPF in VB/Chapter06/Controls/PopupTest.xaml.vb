Public Class PopupTest

    Private Sub run_MouseEnter(ByVal sender As Object, ByVal e As MouseEventArgs)
        popLink.IsOpen = True
    End Sub

    Private Sub lnk_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Process.Start((CType(sender, Hyperlink)).NavigateUri.ToString())
    End Sub

End Class