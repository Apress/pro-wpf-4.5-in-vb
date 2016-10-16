Public Class ThumbnailClipping
    Private Sub cmdShrinkPreview_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Find the position of the clicked button, in window coordinates.
        Dim cmd As Button = CType(sender, Button)
        Dim locationFromWindow As Point = cmd.TranslatePoint(New Point(0, 0), Me)

        ' Determine the width that should be added to every side.
        Dim left As Double = locationFromWindow.X
        Dim top As Double = locationFromWindow.Y
        Dim right As Double = LayoutRoot.ActualWidth - cmd.ActualWidth - left
        Dim bottom As Double = LayoutRoot.ActualHeight - cmd.ActualHeight - top

        ' Apply the clipping.
        taskBarItem.ThumbnailClipMargin = New Thickness(left, top, right, bottom)
    End Sub

End Class
