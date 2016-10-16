Public Class PrintFlowDocumentWithHeader

    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim printDialog As New PrintDialog()
        If printDialog.ShowDialog() = True Then
            ' Save all the existing settings.                                
            Dim pageHeight As Double = docReader.Document.PageHeight
            Dim pageWidth As Double = docReader.Document.PageWidth
            Dim pagePadding As Thickness = docReader.Document.PagePadding
            Dim columnGap As Double = docReader.Document.ColumnGap
            Dim columnWidth As Double = docReader.Document.ColumnWidth

            ' Make the FlowDocument page match the printed page.
            docReader.Document.PageHeight = printDialog.PrintableAreaHeight
            docReader.Document.PageWidth = printDialog.PrintableAreaWidth
            docReader.Document.PagePadding = New Thickness(50)

            ' Use two columns.
            docReader.Document.ColumnGap = 25
            docReader.Document.ColumnWidth = (docReader.Document.PageWidth - docReader.Document.ColumnGap - docReader.Document.PagePadding.Left - docReader.Document.PagePadding.Right) / 2

            Dim document As FlowDocument = docReader.Document
            docReader.Document = Nothing

            Dim paginator As New HeaderedFlowDocumentPaginator(document)
            printDialog.PrintDocument(paginator, "A Flow Document")

            docReader.Document = document

            ' Reapply the old settings.
            docReader.Document.PageHeight = pageHeight
            docReader.Document.PageWidth = pageWidth
            docReader.Document.PagePadding = pagePadding
            docReader.Document.ColumnGap = columnGap
            docReader.Document.ColumnWidth = columnWidth
        End If
    End Sub
End Class