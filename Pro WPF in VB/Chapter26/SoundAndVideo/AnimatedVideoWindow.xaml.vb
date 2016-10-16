Imports System.Windows.Media.Animation

Public Class AnimatedVideoWindow

    Private Sub cmdPlayCode_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Create the MediaPlayer.
        Dim player As New MediaPlayer()
        player.Open(New Uri("test.mpg", UriKind.Relative))

        ' Create the VideoDrawing.
        Dim videoDrawing As New VideoDrawing()
        videoDrawing.Rect = New Rect(150, 0, 100, 100)
        videoDrawing.Player = player

        ' Assign the DrawingBrush.
        Dim brush As New DrawingBrush(videoDrawing)
        Me.Background = brush

        ' Start playback.
        player.Play()



    End Sub
End Class