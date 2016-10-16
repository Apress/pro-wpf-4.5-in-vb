Imports mshtml

Public Class BrowseDOM
    Private Sub cmdAnalyzeDOM_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        cmdBuildTree_Click(Nothing, Nothing)
    End Sub

    Private Sub cmdBuildTree_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Analyzing a page takes a nontrivial amount of time.
        ' Use the hourglass cursor to warn the user.
        Me.Cursor = Cursors.Wait

        Dim dom As HTMLDocument = CType(webBrowser.Document, HTMLDocument)

        ' Process all the HTML elements on the page.
        ProcessElement(dom.documentElement, treeDOM.Items)

        Me.Cursor = Nothing
    End Sub

    Private Sub ProcessElement(ByVal parentElement As IHTMLElement, ByVal nodes As ItemCollection)
        ' Scan through the collection of elements.
        For Each element As IHTMLElement In parentElement.children
            ' Create a new node that shows the tag name.
            Dim node As New TreeViewItem()
            node.Header = "<" & element.tagName & ">"
            nodes.Add(node)

            If element.children.length = 0 And element.innerText IsNot Nothing Then
                ' If this element doesn't contain any other elements, add
                ' any leftover text content as a new node.
                node.Items.Add(element.innerText)
            Else
                ' If this element contains other elements, process them recursively.
                ProcessElement(element, node.Items)
            End If
        Next
    End Sub

End Class
