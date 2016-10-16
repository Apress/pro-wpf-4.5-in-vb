Imports System.AddIn.Hosting
Imports System.IO


Public Class Window1

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim path As String = Environment.CurrentDirectory
        AddInStore.Update(path)

        Dim tokens As IList(Of AddInToken) = AddInStore.FindAddIns(GetType(HostView.ImageProcessorHostView), path)
        lstAddIns.ItemsSource = tokens
    End Sub

    Private addin As HostView.ImageProcessorHostView
    Private Sub cmdProcessImage_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        Dim token As AddInToken = CType(lstAddIns.SelectedItem, AddInToken)
        addin = token.Activate(Of HostView.ImageProcessorHostView)(AddInSecurityLevel.Host)

        Dim imageStream As Stream = Application.GetResourceStream(New Uri("Forest.jpg", UriKind.RelativeOrAbsolute)).Stream

        pnlAddIn.Child = addin.GetVisual(imageStream)

    End Sub

    Private Sub lstAddIns_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        cmdProcessImage.IsEnabled = (lstAddIns.SelectedIndex <> -1)
    End Sub
End Class

