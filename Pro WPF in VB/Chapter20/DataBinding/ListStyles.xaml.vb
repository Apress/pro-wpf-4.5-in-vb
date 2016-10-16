Imports StoreDatabase

Public Class ListStyles
    Private products As ICollection(Of Product)

    Private Sub cmdGetProducts_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        products = Application.StoreDB.GetProducts()
        lstProducts.ItemsSource = products
    End Sub

End Class
