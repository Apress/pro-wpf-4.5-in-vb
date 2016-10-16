Imports System.AddIn.Hosting

Public Class Window1

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim path As String = Environment.CurrentDirectory
        AddInStore.Update(path)

        Dim tokens As IList(Of AddInToken) = AddInStore.FindAddIns(GetType(HostView.ImageProcessorHostView), path)
        lstAddIns.ItemsSource = tokens
    End Sub

    Private Sub cmdProcessImage_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim originalSource As BitmapSource = CType(img.Source, BitmapSource)
        Dim stride As Integer = CInt(originalSource.PixelWidth * originalSource.Format.BitsPerPixel / 8)
        stride = stride + (stride Mod 4) * 4
        Dim originalPixels As Byte() = New Byte(CInt(stride * originalSource.PixelHeight * originalSource.Format.BitsPerPixel / 8 - 1)) {}

        originalSource.CopyPixels(originalPixels, stride, 0)

        Dim token As AddInToken = CType(lstAddIns.SelectedItem, AddInToken)
        Dim addin As HostView.ImageProcessorHostView = token.Activate(Of HostView.ImageProcessorHostView)(AddInSecurityLevel.Internet)
        Dim changedPixels As Byte() = addin.ProcessImageBytes(originalPixels)

        Dim newSource As BitmapSource = BitmapSource.Create(originalSource.PixelWidth, originalSource.PixelHeight, originalSource.DpiX, originalSource.DpiY, originalSource.Format, originalSource.Palette, changedPixels, stride)
        img.Source = newSource
    End Sub

    Private Sub lstAddIns_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        cmdProcessImage.IsEnabled = (lstAddIns.SelectedIndex <> -1)
    End Sub
End Class

