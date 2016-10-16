Imports System.Resources
Imports System.Globalization
Imports System.IO

Public Class Window1

    Private Sub cmdPlay_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        img.Source = New BitmapImage(New Uri("images/winter.jpg", UriKind.Relative))
        'img.Source = New BitmapImage(New Uri("pack://application:,,,/images/winter.jpg"))
        Sound.Stop()
        Sound.Play()

    End Sub
End Class