Imports System.Collections.ObjectModel
Imports StoreDatabase

Public Class VariedStyles
    Private products As ICollection(Of Product)

    Private Sub cmdGetProducts_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        products = Application.StoreDB.GetProducts()
        lstProducts.ItemsSource = products
    End Sub

    Private Sub cmdApplyChange_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        CType(products, ObservableCollection(Of Product))(1).CategoryName = "Travel"
        Dim selector As StyleSelector = lstProducts.ItemContainerStyleSelector
        lstProducts.ItemContainerStyleSelector = Nothing
        lstProducts.ItemContainerStyleSelector = selector
    End Sub

End Class
