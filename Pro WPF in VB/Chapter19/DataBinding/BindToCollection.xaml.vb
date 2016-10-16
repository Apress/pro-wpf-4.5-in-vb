Imports StoreDatabase

Public Class BindToCollection

    Private products As ICollection(Of Product)

    Private Sub cmdGetProducts_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        products = Application.StoreDB.GetProducts()
        lstProducts.ItemsSource = products
    End Sub

    Private Sub cmdDeleteProduct_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        products.Remove(CType(lstProducts.SelectedItem, Product))
    End Sub

    Private Sub cmdAddProduct_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        products.Add(New Product("00000", "?", 0, "?"))
    End Sub

    Private isDirty As Boolean = False
    Private Sub txt_TextChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        isDirty = True
    End Sub

    Private Sub lstProducts_SelectionChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        isDirty = False
    End Sub

End Class