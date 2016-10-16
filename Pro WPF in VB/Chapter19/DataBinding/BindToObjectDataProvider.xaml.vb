Imports StoreDatabase
Imports System.Collections.ObjectModel

Public Class BindToObjectDataProvider

    Private Sub cmdDeleteProduct_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim products As ObservableCollection(Of Product) = CType(lstProducts.ItemsSource, ObservableCollection(Of Product))
        products.Remove(CType(lstProducts.SelectedItem, Product))
    End Sub

End Class