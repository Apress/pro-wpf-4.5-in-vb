Public Class TunneledKeyPress

    Protected eventCounter As Integer = 0

    Private Sub SomeKeyPressed(ByVal sender As Object, ByVal e As RoutedEventArgs)
        eventCounter += 1
        Dim message As String = "#" & eventCounter.ToString() & ":" & _
          Constants.vbCrLf & " Sender: " & sender.ToString() & _
          Constants.vbCrLf & " Source: " & e.Source.ToString() & _
          Constants.vbCrLf & " Original Source: " & e.OriginalSource.ToString() & _
          Constants.vbCrLf & " Event: " & e.RoutedEvent.ToString()
        lstMessages.Items.Add(message)
        e.Handled = CBool(chkHandle.IsChecked)
    End Sub

    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        eventCounter = 0
        lstMessages.Items.Clear()
    End Sub
End Class