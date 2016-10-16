Public Class KeyPressEvents

    Private Sub KeyEvent(ByVal sender As Object, ByVal e As KeyEventArgs)
        If CBool(chkIgnoreRepeat.IsChecked) AndAlso e.IsRepeat Then
            Return
        End If

        Dim message As String = "Event: " & e.RoutedEvent.ToString() & " " & " Key: " & e.Key
        lstMessages.Items.Add(message)
    End Sub

    Private Sub TextInputPreview(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim message As String = "Event: " & e.RoutedEvent.ToString() & " " & " Text: " & e.Text
        lstMessages.Items.Add(message)
    End Sub

    Private Sub TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        Dim message As String = "Event: " & e.RoutedEvent.ToString()
        lstMessages.Items.Add(message)
    End Sub

    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        lstMessages.Items.Clear()
    End Sub
End Class