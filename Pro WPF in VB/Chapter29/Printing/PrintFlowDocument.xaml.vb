Public Class PrintFlowDocument

    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim printDialog As New PrintDialog()
        If printDialog.ShowDialog() = True Then
            printDialog.PrintDocument((CType(docReader.Document, IDocumentPaginatorSource)).DocumentPaginator, "A Flow Document")
        End If
    End Sub

    Private Sub cmdPrintCustom_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim printDialog As New PrintDialog()
        If printDialog.ShowDialog() = True Then
            Dim doc As FlowDocument = docReader.Document

            ' Save all the existing settings.                                
            Dim pageHeight As Double = doc.PageHeight
            Dim pageWidth As Double = doc.PageWidth
            Dim pagePadding As Thickness = doc.PagePadding
            Dim columnGap As Double = doc.ColumnGap
            Dim columnWidth As Double = doc.ColumnWidth

            ' Make the FlowDocument page match the printed page.
            doc.PageHeight = printDialog.PrintableAreaHeight
            doc.PageWidth = printDialog.PrintableAreaWidth
            doc.PagePadding = New Thickness(50)

            ' Use two columns.
            doc.ColumnGap = 25
            doc.ColumnWidth = (doc.PageWidth - doc.ColumnGap - doc.PagePadding.Left - doc.PagePadding.Right) / 2

            printDialog.PrintDocument((CType(doc, IDocumentPaginatorSource)).DocumentPaginator, "A Flow Document")

            ' Reapply the old settings.
            doc.PageHeight = pageHeight
            doc.PageWidth = pageWidth
            doc.PagePadding = pagePadding
            doc.ColumnGap = columnGap
            doc.ColumnWidth = columnWidth
        End If
    End Sub
End Class