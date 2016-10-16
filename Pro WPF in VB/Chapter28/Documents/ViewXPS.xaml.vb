Imports System.Windows.Xps.Packaging
Imports System.IO

Public Class ViewXPS

    Private Sub window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim doc As New XpsDocument("ch19.xps", FileAccess.Read)
        docViewer.Document = doc.GetFixedDocumentSequence()
        doc.Close()
    End Sub
End Class