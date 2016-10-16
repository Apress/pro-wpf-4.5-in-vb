Public Class ThumbnailButtons
    Private Sub cmdPlay_Click(ByVal sender As Object, ByVal e As EventArgs)
        taskBarItem.ProgressState = System.Windows.Shell.TaskbarItemProgressState.Indeterminate
        taskBarItem.Overlay = New BitmapImage(New Uri("pack://application:,,,/play.png"))
    End Sub

    Private Sub cmdPause_Click(ByVal sender As Object, ByVal e As EventArgs)
        taskBarItem.ProgressState = System.Windows.Shell.TaskbarItemProgressState.None
        taskBarItem.Overlay = New BitmapImage(New Uri("pack://application:,,,/pause.png"))
    End Sub


End Class
