Imports System.Media
Imports System.ComponentModel
Imports System.IO
Imports Microsoft.VisualBasic

Public Class SoundPlayerTest

    Private Sub cmdPlayAudio_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim player As New SoundPlayer()
        player.Stream = My.Resources.chimes
        Try
            player.Load()
            player.PlaySync()
        Catch err As System.IO.FileNotFoundException
            ' An error will occur here if the file can't be found.
        Catch err As FormatException
            ' A FormatException will occur here if the file doesn't
            ' contain valid WAV audio.
        End Try
    End Sub

    Private Sub cmdPlayAudioAsync_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim player As New SoundPlayer()
        player.SoundLocation = "test.wav"
        Try
            player.Load()
            player.Play()
        Catch err As System.IO.FileNotFoundException
            ' An error will occur here if the file can't be found.
        Catch err As FormatException
            ' A FormatException will occur here if the file doesn't
            ' contain valid WAV audio.
        End Try
    End Sub

    Private player As New MediaPlayer()

    Private Sub cmdPlayWithMediaPlayer_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        player.Open(New Uri("test.mp3", UriKind.Relative))
        player.Play()
    End Sub

    Private Sub window_Closed(ByVal sender As Object, ByVal e As EventArgs)
        player.Close()
    End Sub
End Class