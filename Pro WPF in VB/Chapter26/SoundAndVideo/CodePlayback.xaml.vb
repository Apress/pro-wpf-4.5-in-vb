Imports System.Windows.Media.Animation


Public Class CodePlayback

    Private Sub sliderSpeed_ValueChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        media.SpeedRatio = (CType(sender, Slider)).Value
    End Sub

    Private Sub cmdPlay_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        media.Play()
    End Sub
    Private Sub cmdPause_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        media.Pause()
    End Sub
    Private Sub cmdStop_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        media.Stop()
        media.SpeedRatio = 1
    End Sub
    Private Sub media_MediaOpened(ByVal sender As Object, ByVal e As RoutedEventArgs)
        sliderPosition.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds
    End Sub
    Private Sub sliderPosition_ValueChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        media.Pause()
        media.Position = TimeSpan.FromSeconds(sliderPosition.Value)
        media.Play()
    End Sub

End Class