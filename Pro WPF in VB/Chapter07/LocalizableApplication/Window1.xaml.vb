Public Class Window1

    Protected Sub cmd_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show(Me.Resources("Error").ToString())
    End Sub
End Class