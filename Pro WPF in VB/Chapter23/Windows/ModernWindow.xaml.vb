Public Class ModernWindow

    Private isWiden As Boolean = False

    Private Sub window_initiateWiden(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
        isWiden = True
    End Sub

    Private Sub window_Widen(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
        Dim rect As Rectangle = CType(sender, Rectangle)
        If isWiden Then
            rect.CaptureMouse()
            Dim newWidth As Double = e.GetPosition(Me).X + 5
            If newWidth > 0 Then Me.Width = newWidth
        End If
    End Sub

    Private Sub window_endWiden(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
        isWiden = False

        ' Make sure capture is released.
        Dim rect As Rectangle = CType(sender, Rectangle)
        rect.ReleaseMouseCapture()
    End Sub

    Private Sub titleBar_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Me.DragMove()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.Close()
    End Sub
End Class