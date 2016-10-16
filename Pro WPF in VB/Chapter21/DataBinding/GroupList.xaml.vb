Imports System.ComponentModel
Imports StoreDatabase

Public Class GroupList

    Private products As ICollection(Of Product)

    Private Sub cmdGetProducts_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        products = Application.StoreDB.GetProducts()
        lstProducts.ItemsSource = products

        Dim view As ICollectionView = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource)
        view.SortDescriptions.Add(New SortDescription("CategoryName", ListSortDirection.Ascending))
        view.SortDescriptions.Add(New SortDescription("ModelName", ListSortDirection.Ascending))

        view.GroupDescriptions.Add(New PropertyGroupDescription("CategoryName"))


    End Sub


End Class




