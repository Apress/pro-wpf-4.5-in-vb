Public Class TextBoxTest

    Private Sub txt_SelectionChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If txtSelection Is Nothing Then
            Return
        End If
        txtSelection.Text = String.Format("Selection from {0} to {1} is ""{2}""", txt.SelectionStart, txt.SelectionLength, txt.SelectedText)
    End Sub
End Class