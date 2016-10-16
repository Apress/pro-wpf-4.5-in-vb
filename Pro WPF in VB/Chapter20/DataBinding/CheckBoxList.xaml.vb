Imports StoreDatabase

Public Class CheckBoxList

    Public Sub New()
        InitializeComponent()
        lstProducts.ItemsSource = Application.StoreDB.GetProducts()
    End Sub

    Private Sub cmdGetSelectedItems(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If lstProducts.SelectedItems.Count > 0 Then
            Dim items As String = "You selected: "
            For Each product As Product In lstProducts.SelectedItems
                items &= Constants.vbLf & "  * " & product.ModelName
            Next
            MessageBox.Show(items)
        End If
    End Sub
End Class