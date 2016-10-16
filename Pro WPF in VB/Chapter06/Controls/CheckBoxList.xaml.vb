Imports System.Text

Public Class CheckBoxList

    Private Sub lst_SelectionChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Select when checkbox portion is clicked (optional).
        If TypeOf e.OriginalSource Is CheckBox Then
            lst.SelectedItem = e.OriginalSource
        End If

        If lst.SelectedItem Is Nothing Then
            Return
        End If
        txtSelection.Text = String.Format("You chose item at position {0}." & Constants.vbCrLf & "Checked state is {1}.", lst.SelectedIndex, (CType(lst.SelectedItem, CheckBox)).IsChecked)
    End Sub

    Private Sub cmd_CheckAllItems(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim sb As New StringBuilder()
        For Each item As CheckBox In lst.Items
            If item.IsChecked = True Then
                sb.Append(item.Content.ToString() & " is checked.")
                sb.Append(Constants.vbCrLf)
            End If
        Next
        txtSelection.Text = sb.ToString()
    End Sub
End Class