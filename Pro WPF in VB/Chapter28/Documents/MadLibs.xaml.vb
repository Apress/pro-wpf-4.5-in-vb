Public Class MadLibs

    Private Sub WindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Clear grid of text entry controls.
        gridWords.Children.Clear()

        ' Look at paragraphs.
        For Each block As Block In document.Blocks
            Dim paragraph As Paragraph = TryCast(block, Paragraph)

            ' Look for spans.
            For Each inline As Inline In paragraph.Inlines
                Dim span As Span = TryCast(inline, Span)
                If Not span Is Nothing Then
                    Dim row As New RowDefinition()
                    gridWords.RowDefinitions.Add(row)

                    Dim lbl As New Label()
                    lbl.Content = inline.Tag.ToString() & ":"
                    Grid.SetColumn(lbl, 0)
                    Grid.SetRow(lbl, gridWords.RowDefinitions.Count - 1)
                    gridWords.Children.Add(lbl)

                    Dim txt As New TextBox()
                    Grid.SetColumn(txt, 1)
                    Grid.SetRow(txt, gridWords.RowDefinitions.Count - 1)
                    gridWords.Children.Add(txt)

                    txt.Tag = span.Inlines.FirstInline
                End If
            Next
        Next
    End Sub

    Private Sub cmdGenerate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        For Each child As UIElement In gridWords.Children
            If Grid.GetColumn(child) = 1 Then
                Dim txt As TextBox = CType(child, TextBox)

                If txt.Text <> "" Then
                    CType(txt.Tag, Run).Text = txt.Text
                End If
            End If
        Next
        docViewer.Visibility = Visibility.Visible
    End Sub
End Class