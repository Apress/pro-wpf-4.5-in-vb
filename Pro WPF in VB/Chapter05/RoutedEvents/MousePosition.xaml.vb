Public Class MousePosition

    Private Sub cmdCapture_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.AddHandler(Mouse.LostMouseCaptureEvent, _
          New RoutedEventHandler(AddressOf Me.LostCapture))
        Mouse.Capture(rect)

        cmdCapture.Content = "[ Mouse is now captured ... ]"
    End Sub

    Private Sub MouseMoved(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim pt As Point = e.GetPosition(Me)
        lblInfo.Text = String.Format("You are at ({0},{1}) in window coordinates", pt.X, pt.Y)
    End Sub

    Private Sub LostCapture(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show("Lost capture")
        cmdCapture.Content = "Capture the Mouse"
    End Sub
End Class