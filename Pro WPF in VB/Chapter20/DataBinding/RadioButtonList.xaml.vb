Public Class RadioButtonList
   
    Public Sub New()
        InitializeComponent()
        lstProducts.ItemsSource = Application.StoreDB.GetProducts()
    End Sub

    Private Sub cmdGetSelectedItem(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show(lstProducts.SelectedItem.ToString())
    End Sub
End Class