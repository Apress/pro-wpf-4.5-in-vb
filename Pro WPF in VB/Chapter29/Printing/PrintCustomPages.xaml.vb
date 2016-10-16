Imports System.Data

Public Class PrintCustomPages

    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim printDialog As New PrintDialog()
        If printDialog.ShowDialog() = True Then
            Dim ds As New DataSet()
            ds.ReadXmlSchema("store.xsd")
            ds.ReadXml("store.xml")

            Dim paginator As New StoreDataSetPaginator(ds.Tables(0), New Typeface("Calibri"), 24, 96 * 0.75, New Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight))

            printDialog.PrintDocument(paginator, "Custom-Printed Pages")
        End If

    End Sub
End Class