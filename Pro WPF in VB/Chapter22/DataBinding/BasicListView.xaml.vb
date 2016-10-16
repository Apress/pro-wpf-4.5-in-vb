Public Class BasicListView
   
    Public Sub New()
        InitializeComponent()
        lstProducts.ItemsSource = Application.StoreDB.GetProducts()
    End Sub

End Class