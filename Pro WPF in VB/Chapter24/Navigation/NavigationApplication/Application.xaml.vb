Public Class Application

    Private Sub Application_NavigationFailed(ByVal sender As Object, ByVal e As System.Windows.Navigation.NavigationFailedEventArgs) Handles Me.NavigationFailed
        If TypeOf e.Exception Is System.Net.WebException Then
            MessageBox.Show("Website " & e.Uri.ToString() & " cannot be reached.")

            ' Neutralize the erorr so the application continues running.
            e.Handled = True
        End If
    End Sub
End Class