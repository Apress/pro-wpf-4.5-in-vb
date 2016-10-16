Imports System.ComponentModel
Imports StoreDatabase

Public Class NavigateCollection

    Private products As ICollection(Of Product)
    Private view As ListCollectionView

    Public Sub New()
        InitializeComponent()

        products = Application.StoreDB.GetProducts()

        Me.DataContext = products
        view = CType(CollectionViewSource.GetDefaultView(Me.DataContext), ListCollectionView)
        AddHandler view.CurrentChanged, AddressOf view_CurrentChanged

        lstProducts.ItemsSource = products
    End Sub

    Private Sub cmdNext_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        view.MoveCurrentToNext()
    End Sub
    Private Sub cmdPrev_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        view.MoveCurrentToPrevious()
    End Sub

    Private Sub lstProducts_SelectionChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' view.MoveCurrentTo(lstProducts.SelectedItem);
    End Sub

    Private Sub view_CurrentChanged(ByVal sender As Object, ByVal e As EventArgs)
        lblPosition.Text = "Record " & (view.CurrentPosition + 1).ToString() & " of " & view.Count.ToString()
        cmdPrev.IsEnabled = view.CurrentPosition > 0
        cmdNext.IsEnabled = view.CurrentPosition < view.Count - 1
    End Sub
End Class