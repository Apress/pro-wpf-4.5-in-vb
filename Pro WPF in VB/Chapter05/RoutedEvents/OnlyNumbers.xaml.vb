Public Class OnlyNumbers
   
    Private Sub pnl_PreviewTextInput(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim val As Short
        If (Not Int16.TryParse(e.Text, val)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub pnl_PreviewKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.Key = Key.Space Then
            e.Handled = True
        End If
    End Sub

End Class