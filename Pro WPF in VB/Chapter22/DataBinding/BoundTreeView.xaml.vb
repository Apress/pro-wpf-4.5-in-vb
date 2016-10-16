Public Class BoundTreeView

    Public Sub New()
        InitializeComponent()
        treeCategories.ItemsSource = Application.StoreDB.GetCategoriesAndProducts()
    End Sub

End Class