Imports System.Collections.ObjectModel
Imports StoreDatabase

Public Class VariedTemplates
    Private products As ICollection(Of Product)

    Private Sub cmdGetProducts_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        products = Application.StoreDB.GetProducts()
        lstProducts.ItemsSource = products
    End Sub

    Private Sub cmdApplyChange_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        CType(products, ObservableCollection(Of Product))(1).CategoryName = "Travel"
        Dim selector As DataTemplateSelector = lstProducts.ItemTemplateSelector
        lstProducts.ItemTemplateSelector = Nothing
        lstProducts.ItemTemplateSelector = selector

    End Sub
End Class
