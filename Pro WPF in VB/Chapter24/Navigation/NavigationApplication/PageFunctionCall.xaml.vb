Public Class PageFunctionCall

    Private Sub cmdSelect_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim pageFunction As New SelectProductPageFunction()
        AddHandler pageFunction.Return, AddressOf SelectProductPageFunction_Returned
        Me.NavigationService.Navigate(pageFunction)
    End Sub

    Private Sub SelectProductPageFunction_Returned(ByVal sender As Object, ByVal e As ReturnEventArgs(Of Product))
        If Not e Is Nothing Then
            lblStatus.Content = "You chose: " & e.Result.Name
        End If
    End Sub

End Class