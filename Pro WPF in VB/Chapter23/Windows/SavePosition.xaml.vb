Public Class SavePosition

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        WindowPositionHelper.SaveSize(Me)
    End Sub

    Private Sub cmdRestore_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        WindowPositionHelper.SetSize(Me)
    End Sub
End Class