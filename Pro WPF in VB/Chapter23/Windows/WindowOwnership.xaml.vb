Public Class WindowOwnership

    Private Sub cmdCreate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim win As New WindowOwnership()
        win.Owner = Me
        win.Title = "Owned Window"
        win.Height = Me.Height / 2
        win.Width = Me.Width / 2
        win.WindowStartupLocation = WindowStartupLocation.CenterOwner
        win.Show()
    End Sub
End Class