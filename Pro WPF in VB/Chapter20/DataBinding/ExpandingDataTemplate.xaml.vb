Public Class ExpandingDataTemplate
    Public Sub New()
        InitializeComponent()
        lstCategories.ItemsSource = Application.StoreDB.GetProducts()
    End Sub


End Class
