Public Class VistaGlassWindow1

    Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            VistaGlassHelper.ExtendGlass(Me, -1, -1, -1, -1)

            ' If not Vista, paint background white.
        Catch '(DllNotFoundException)
            Me.Background = Brushes.White
        End Try
    End Sub

End Class