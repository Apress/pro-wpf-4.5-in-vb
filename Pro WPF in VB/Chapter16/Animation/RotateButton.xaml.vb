Public Class RotateButton

    Private Sub cmd_Clicked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        lbl.Text = "You clicked: " & (CType(e.OriginalSource, Button)).Content.ToString()
    End Sub

End Class