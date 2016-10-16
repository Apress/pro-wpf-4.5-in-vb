Public Class DragAndDrop

    Private Sub lblSource_MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Dim lbl As Label = CType(sender, Label)
        DragDrop.DoDragDrop(lbl, lbl.Content, DragDropEffects.Copy)
    End Sub

    Private Sub lblTarget_Drop(ByVal sender As Object, ByVal e As DragEventArgs)
        CType(sender, Label).Content = e.Data.GetData(DataFormats.Text)
    End Sub

    Private Sub lblTarget_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effects = DragDropEffects.Copy
        Else
            e.Effects = DragDropEffects.None
        End If
    End Sub

End Class