Public Class AdvancedListView
   
    Public Sub New()
        InitializeComponent()
        lstProducts.ItemsSource = Application.StoreDB.GetProducts()
    End Sub

End Class