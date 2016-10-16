Public Class FlowContent

    Private Sub cmdCreateDynamicDocument_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Create the first part of the sentence.
        Dim runFirst As New Run()
        runFirst.Text = "Hello world of "

        ' Create bolded text.
        Dim bold As New Bold()
        Dim runBold As New Run()
        runBold.Text = "dynamically generated"
        bold.Inlines.Add(runBold)

        ' Create last part of sentence.
        Dim runLast As New Run()
        runLast.Text = " documents"

        ' Add three parts of sentence to a paragraph, in order.
        Dim paragraph As New Paragraph()
        paragraph.Inlines.Add(runFirst)
        paragraph.Inlines.Add(bold)
        paragraph.Inlines.Add(runLast)

        ' Create a document and add this paragraph.
        Dim document As New FlowDocument()
        document.Blocks.Add(paragraph)

        ' Show the document.
        docViewer.Document = document
    End Sub
End Class