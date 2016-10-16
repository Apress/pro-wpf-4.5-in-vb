Imports System.ComponentModel
Imports StoreDatabase

Public Class GroupInRanges

    Private products As ICollection(Of Product)

    Private Sub cmdGetProducts_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        products = Application.StoreDB.GetProducts()
        Dim viewSource As CollectionViewSource = CType(Me.FindResource("GroupByRangeView"), CollectionViewSource)
        viewSource.Source = products
    End Sub
End Class