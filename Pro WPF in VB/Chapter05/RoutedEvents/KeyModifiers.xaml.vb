Public Class KeyModifiers

    Private Sub KeyEvent(ByVal sender As Object, ByVal e As KeyEventArgs)
        lblInfo.Text = "Modifiers: " & e.KeyboardDevice.Modifiers.ToString()
        If (e.KeyboardDevice.Modifiers And ModifierKeys.Control) = ModifierKeys.Control Then
            lblInfo.Text += Constants.vbCrLf & "You held the Control key."
        End If
    End Sub

    Private Sub CheckShift(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Keyboard.IsKeyDown(Key.LeftShift) Then
            lblInfo.Text = "The left Shift is held down."
        Else
            lblInfo.Text = "The left Shift is not held down."
        End If
    End Sub
End Class