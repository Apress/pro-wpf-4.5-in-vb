Partial Public Class MainWindow

    Private Sub cmdCreate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim doc As New Document()
        doc.Owner = Me
        doc.Show()
        CType(Application.Current, ApplicationCore).Documents.Add(doc)
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim app As ApplicationCore = CType(Application.Current, ApplicationCore)
        For Each doc As Document In app.Documents
            doc.SetContent("Refreshed at " & DateTime.Now.ToLongTimeString() & ".")
        Next
    End Sub
End Class