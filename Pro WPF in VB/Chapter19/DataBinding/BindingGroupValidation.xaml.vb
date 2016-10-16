Imports StoreDatabase

Public Class BindingGroupValidation
    Private products As ICollection(Of Product)

    Private Sub cmdGetProducts_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        products = Application.StoreDB.GetProducts()
        lstProducts.ItemsSource = products
    End Sub

    Private Sub cmdUpdateProduct_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Make sure update has taken place.
        FocusManager.SetFocusedElement(Me, CType(sender, Button))
    End Sub

    Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As RoutedEventArgs)
        productBindingGroup.CommitEdit()
    End Sub

    Private Sub lstProducts_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        productBindingGroup.CommitEdit()
    End Sub

End Class
