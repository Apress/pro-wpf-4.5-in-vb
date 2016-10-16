Imports StoreDatabase

Public Class DataGridTest
    Public Sub New()
        InitializeComponent()

        gridProducts.ItemsSource = Application.StoreDB.GetProducts()
    End Sub

    ' Reuse brush objects for efficiency in large data displays.
    Private highlightBrush As New SolidColorBrush(Colors.Orange)
    Private normalBrush As New SolidColorBrush(Colors.White)

    Private Sub gridProducts_LoadingRow(ByVal sender As Object, ByVal e As DataGridRowEventArgs)
        Dim product As Product = CType(e.Row.DataContext, Product)
        If product.UnitCost > 100 Then
            e.Row.Background = highlightBrush
        Else
            e.Row.Background = normalBrush
        End If

    End Sub

    Private Sub FormatRow(ByVal row As DataGridRow)
        Dim product As Product = CType(row.DataContext, Product)
        If product.UnitCost > 100 Then
            row.Background = highlightBrush
        Else
            row.Background = normalBrush
        End If
    End Sub

End Class
