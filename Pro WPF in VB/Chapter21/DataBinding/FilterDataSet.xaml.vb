Imports System.ComponentModel
Imports System.Data

Public Class FilterDataSet

    Private products As DataTable

    Private Sub cmdGetProducts_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        products = Application.StoreDBDataSet.GetProducts()
        lstProducts.ItemsSource = products.DefaultView

        Dim view As ICollectionView = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource)
        view.SortDescriptions.Add(New SortDescription("ModelName", ListSortDirection.Ascending))
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim minimumPrice As Decimal
        If Decimal.TryParse(txtMinPrice.Text, minimumPrice) Then
            Dim view As BindingListCollectionView = TryCast(CollectionViewSource.GetDefaultView(lstProducts.ItemsSource), BindingListCollectionView)
            If Not view Is Nothing Then
                view.CustomFilter = "UnitCost > " & minimumPrice.ToString()
            End If
        End If
    End Sub

    Private Sub cmdRemoveFilter_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim view As BindingListCollectionView = TryCast(CollectionViewSource.GetDefaultView(lstProducts.ItemsSource), BindingListCollectionView)
        If Not view Is Nothing Then
            view.CustomFilter = ""
        End If
    End Sub
End Class