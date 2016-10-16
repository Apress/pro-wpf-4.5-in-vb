Public Class PopupTest

    Private Sub cmdStart_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        DisableMainPage()
    End Sub

    Private Sub DisableMainPage()
        mainPage.IsEnabled = False
        Me.Background = Brushes.LightGray
        dialogPopUp.IsOpen = True
    End Sub

    Private Sub dialog_cmdOK_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Copy name from the Popup into the main page.
        lblName.Content = "You entered: " & txtName.Text
        EnableMainPage()
    End Sub

    Private Sub dialog_cmdCancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        EnableMainPage()
    End Sub

    Private Sub EnableMainPage()
        mainPage.IsEnabled = True
        Me.Background = Nothing
        dialogPopUp.IsOpen = False
    End Sub

    Private Sub cmdStartWF_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim form As New UserNameWinForm()
        If form.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            lblNameWF.Content = form.UserName
        End If
        form.Dispose()
    End Sub
End Class