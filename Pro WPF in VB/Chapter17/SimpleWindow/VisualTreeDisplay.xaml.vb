Public Class VisualTreeDisplay

    Public Sub ShowVisualTree(ByVal element As DependencyObject)
        ' Clear the tree.
        treeElements.Items.Clear()

        ' Start processing elements, begin at the root.
        ProcessElement(element, Nothing)
    End Sub

    Private Sub ProcessElement(ByVal element As DependencyObject, ByVal previousItem As TreeViewItem)
        ' Create a TreeViewItem for the current element.
        Dim item As New TreeViewItem()
        item.Header = element.GetType().Name
        item.IsExpanded = True

        ' Check whether this item should be added to the root of the tree
        '(if it's the first item), or nested under another item.
        If previousItem Is Nothing Then
            treeElements.Items.Add(item)
        Else
            previousItem.Items.Add(item)
        End If

        ' Check if this element contains other elements.
        For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(element) - 1
            ' Process each contained element recursively.
            ProcessElement(VisualTreeHelper.GetChild(element, i), item)
        Next
    End Sub
End Class