Public Class BindProductObject

    Private Sub cmdGetProduct_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim ID As Integer
        If Int32.TryParse(txtID.Text, ID) Then
            Try
                gridProductDetails.DataContext = Application.StoreDB.GetProduct(ID)
            Catch
                MessageBox.Show("Error contacting database.")
            End Try
        Else
            MessageBox.Show("Invalid ID.")
        End If
    End Sub
End Class