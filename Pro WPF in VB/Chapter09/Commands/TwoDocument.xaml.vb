Public Class TwoDocument
    
    Private Sub SaveCommand(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        Dim text As String = (CType(sender, TextBox)).Text
        MessageBox.Show("About to save: " & text)
        isDirty(sender) = False
    End Sub

    Private isDirty As New Dictionary(Of Object, Boolean)()

    Private Sub txt_TextChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        isDirty(sender) = True
    End Sub

    Private Sub SaveCommand_CanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        If isDirty.ContainsKey(sender) AndAlso isDirty(sender) = True Then
            e.CanExecute = True
        Else
            e.CanExecute = False
        End If
    End Sub
End Class