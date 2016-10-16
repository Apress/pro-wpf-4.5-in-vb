Public Class VistaGlassWindow2

    Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            VistaGlassHelper.ExtendGlass(Me, 5, 5, CInt(Fix(topBar.ActualHeight)) + 5, 5)

            ' If not Vista, paint background white.
        Catch '(DllNotFoundException)
            Me.Background = Brushes.White
        End Try
    End Sub

End Class