Public Class CustomListViewTest
    Public Sub New()
        InitializeComponent()

        lstProducts.ItemsSource = Application.StoreDB.GetProducts()

    End Sub
    Private Sub lstView_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        Dim selectedItem As ComboBoxItem = CType(lstView.SelectedItem, ComboBoxItem)
        lstProducts.View = CType(Me.FindResource(selectedItem.Content), ViewBase)
    End Sub

End Class
