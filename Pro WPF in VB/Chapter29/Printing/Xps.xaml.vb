Imports System.Windows.Markup
Imports System.Windows.Xps
Imports System.Printing
Imports System.IO.Packaging
Imports System.Windows.Xps.Packaging
Imports System.IO

Public Class Xps

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As EventArgs)
        Dim doc As New XpsDocument("test.xps", FileAccess.ReadWrite)
        docViewer.Document = doc.GetFixedDocumentSequence()

        doc.Close()
    End Sub

    Private printDialog As New PrintDialog()
    Private Sub cmdPrintXps_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If printDialog.ShowDialog() = True Then
            printDialog.PrintDocument(docViewer.Document.DocumentPaginator, "A Fixed Document")
        End If
    End Sub

    Private Sub cmdPrintFlow_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim filePath As String = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "FlowDocument1.xaml")
        If printDialog.ShowDialog() = True Then
            Dim queue As PrintQueue = printDialog.PrintQueue
            Dim writer As XpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(queue)

            Using fs As FileStream = File.Open(filePath, FileMode.Open)
                Dim flowDocument As FlowDocument = CType(XamlReader.Load(fs), FlowDocument)
                writer.Write((CType(flowDocument, IDocumentPaginatorSource)).DocumentPaginator)
            End Using
        End If
    End Sub

    Private Sub cmdShowFlow_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        If File.Exists("test2.xps") Then
            File.Delete("test2.xps")
        End If

        Using fs As FileStream = File.Open("FlowDocument1.xaml", FileMode.Open)
            Dim doc As FlowDocument = CType(XamlReader.Load(fs), FlowDocument)

            Dim xpsDocument As New XpsDocument("test2.xps", FileAccess.ReadWrite)
            Dim writer As XpsDocumentWriter = xpsDocument.CreateXpsDocumentWriter(xpsDocument)

            writer.Write((CType(doc, IDocumentPaginatorSource)).DocumentPaginator)

            ' Display the new XPS document in a viewer.
            docViewer.Document = xpsDocument.GetFixedDocumentSequence()
            xpsDocument.Close()
        End Using
    End Sub
End Class