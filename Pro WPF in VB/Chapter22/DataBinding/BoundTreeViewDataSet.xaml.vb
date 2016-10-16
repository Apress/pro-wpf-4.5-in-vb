Imports System.Data

Public Class BoundTreeViewDataSet

    Public Sub New()
        InitializeComponent()

        Dim ds As DataSet = Application.StoreDBDataSet.GetCategoriesAndProducts()
        treeCategories.ItemsSource = ds.Tables("Categories").DefaultView
    End Sub

End Class