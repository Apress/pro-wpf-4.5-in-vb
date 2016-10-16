Public Class Window1

    Private Sub cmd_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim treeDisplay As New VisualTreeDisplay()
        treeDisplay.ShowVisualTree(Me)
        treeDisplay.Show()
    End Sub
End Class