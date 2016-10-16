Public Class Video

    Private Sub cmdPlay_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        video.Position = TimeSpan.Zero
        video.Play()
    End Sub

End Class