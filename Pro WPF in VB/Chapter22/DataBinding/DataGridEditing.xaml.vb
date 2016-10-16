Public Class DataGridEditing
    Public Sub New()
        InitializeComponent()

        categoryColumn.ItemsSource = Application.StoreDB.GetCategories()
        gridProducts.ItemsSource = Application.StoreDB.GetProducts()
    End Sub
End Class
