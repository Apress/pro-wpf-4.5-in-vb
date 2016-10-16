Public Class ComboBoxSelectionBox
   
    Public Sub New()
        InitializeComponent()

        lstProducts.ItemsSource = Application.StoreDB.GetProducts()
        ' Select the first item.
        lstProducts.SelectedIndex = 0
    End Sub

    Private Sub txtTextSearchPath_TextChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Re-select the so the new TextSearch.TextPath is evaluated.
        Dim currentIndex As Integer = lstProducts.SelectedIndex
        lstProducts.SelectedIndex = -1
        lstProducts.SelectedIndex = currentIndex
    End Sub
End Class