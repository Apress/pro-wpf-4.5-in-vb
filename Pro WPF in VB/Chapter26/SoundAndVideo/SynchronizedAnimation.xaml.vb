Imports System.Windows.Media.Animation


Public Class SynchronizedAnimation
   
    Private suppressSeek As Boolean
    Private Sub sliderPosition_ValueChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If (Not suppressSeek) Then
            mediaStoryboard.Storyboard.Seek(DocumentRoot, TimeSpan.FromSeconds(sliderPosition.Value), TimeSeekOrigin.BeginTime)
        End If
    End Sub
    Private Sub media_MediaOpened(ByVal sender As Object, ByVal e As RoutedEventArgs)
        sliderPosition.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds
    End Sub

    Private Sub storyboard_CurrentTimeInvalidated(ByVal sender As Object, ByVal e As EventArgs)
        ' Sender is the clock that was created for this storyboard.
        Dim storyboardClock As Clock = CType(sender, Clock)

        If storyboardClock.CurrentProgress Is Nothing Then
            lblTime.Text = "[[ stopped ]]"
        Else
            lblTime.Text = "Position: " & storyboardClock.CurrentTime.ToString()
            suppressSeek = True
            sliderPosition.Value = storyboardClock.CurrentTime.Value.TotalSeconds
            suppressSeek = False
        End If
    End Sub
End Class