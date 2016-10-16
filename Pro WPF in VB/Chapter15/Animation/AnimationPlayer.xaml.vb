Imports System.Windows.Media.Animation

Public Class AnimationPlayer

    Private Sub storyboard_CurrentTimeInvalidated(ByVal sender As Object, ByVal e As EventArgs)
        ' Sender is the clock that was created for this storyboard.
        Dim storyboardClock As Clock = CType(sender, Clock)

        If storyboardClock.CurrentProgress Is Nothing Then
            lblTime.Text = "[[ stopped ]]"
            progressBar.Value = 0
        Else
            lblTime.Text = storyboardClock.CurrentTime.ToString()
            progressBar.Value = CDbl(storyboardClock.CurrentProgress)
        End If
    End Sub

    Private Sub sldSpeed_ValueChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        fadeStoryboard.SetSpeedRatio(Me, sldSpeed.Value)
    End Sub
End Class