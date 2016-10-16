Imports System.Data

Public Class DataTemplateControls
    Public Sub New()
        InitializeComponent()
        lstCategories.ItemsSource = Application.StoreDBDataSet.GetCategoriesAndProducts().Tables("Categories").DefaultView
    End Sub

    Private Sub cmdView_Clicked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim cmd As Button = CType(sender, Button)
        Dim row As DataRowView = CType(cmd.Tag, DataRowView)
        lstCategories.SelectedItem = row


        MessageBox.Show("You chose category #" & row("CategoryID").ToString() & ": " & CStr(row("CategoryName")))
    End Sub

End Class
