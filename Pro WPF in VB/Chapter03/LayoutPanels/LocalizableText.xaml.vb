Public Class LocalizableText

    Private Sub chkLongText_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        cmdPrev.Content = " <- Go to the Previous Window "
        cmdNext.Content = " Go to the Next Window -> "
    End Sub

    Private Sub chkLongText_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        cmdPrev.Content = "Prev"
        cmdNext.Content = "Next"
    End Sub
End Class