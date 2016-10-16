Public Class VirtualizationTest
    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        For i As Integer = 0 To 9999
            lstFast.Items.Add(i.ToString())
            lstSlow.Items.Add(i.ToString())
        Next
    End Sub

End Class
