Partial Public Class DocumentList

    Public Sub New()
        InitializeComponent()

        ' Show the window names in a list.
        lstDocuments.DisplayMemberPath = "Name"
        lstDocuments.ItemsSource = (CType(Application.Current, WpfApp)).Documents
    End Sub
End Class