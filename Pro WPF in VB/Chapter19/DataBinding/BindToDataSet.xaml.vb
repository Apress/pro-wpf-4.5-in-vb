Imports System.Data

Public Class BindToDataSet

    Private products As DataTable

    Private Sub cmdGetProducts_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        products = Application.StoreDBDataSet.GetProducts()
        lstProducts.ItemsSource = products.DefaultView
    End Sub

    Private Sub cmdDeleteProduct_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        CType(lstProducts.SelectedItem, DataRowView).Row.Delete()
    End Sub

End Class