Imports System.ComponentModel

Public Class DataGridGrouping
    Public Sub New()
        InitializeComponent()

        gridProducts.ItemsSource = Application.StoreDB.GetProducts()
        Dim view As ICollectionView = CollectionViewSource.GetDefaultView(gridProducts.ItemsSource)

        view.GroupDescriptions.Add(New PropertyGroupDescription("CategoryName"))

    End Sub
End Class
