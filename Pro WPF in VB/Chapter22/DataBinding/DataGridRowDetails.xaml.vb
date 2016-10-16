Public Class DataGridRowDetails
    Public Sub New()
        InitializeComponent()

        gridProducts.ItemsSource = Application.StoreDB.GetProducts()
    End Sub
End Class
