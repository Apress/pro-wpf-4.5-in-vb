Public Class DynamicResource

    Private Sub cmdChange_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.Resources("TileBrush") = New SolidColorBrush(Colors.LightBlue)
    End Sub
End Class