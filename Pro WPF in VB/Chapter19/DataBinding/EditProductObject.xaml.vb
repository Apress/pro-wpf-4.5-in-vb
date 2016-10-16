Imports StoreDatabase
Imports System.Text

Public Class EditProductObject

    Private product As Product

    Private Sub cmdGetProduct_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim ID As Integer
        If Int32.TryParse(txtID.Text, ID) Then
            Try
                product = Application.StoreDB.GetProduct(ID)
                gridProductDetails.DataContext = product
            Catch
                MessageBox.Show("Error contacting database.")
            End Try
        Else
            MessageBox.Show("Invalid ID.")
        End If
    End Sub

    Private Sub cmdUpdateProduct_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Make sure update has taken place.
        FocusManager.SetFocusedElement(Me, CType(sender, Button))

        MessageBox.Show(product.UnitCost.ToString())
    End Sub


    Private Sub cmdIncreasePrice_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        product.UnitCost *= 1.1D
    End Sub


  
End Class