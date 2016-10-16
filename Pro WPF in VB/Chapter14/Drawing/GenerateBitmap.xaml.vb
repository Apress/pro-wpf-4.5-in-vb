Public Class GenerateBitmap
    Private Sub cmdGenerate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Create the bitmap, with the dimensions of the image placeholder.
        Dim wb As New WriteableBitmap(CInt(img.Width), CInt(img.Height), 96, 96, PixelFormats.Bgra32, Nothing)

        ' Define the update square (which is as big as the entire image).
        Dim rect As New Int32Rect(0, 0, CInt(img.Width), CInt(img.Height))

        Dim pixels As Byte() = New Byte(CInt(img.Width * img.Height * wb.Format.BitsPerPixel / 8 - 1)) {}
        Dim rand As New Random()
        For y As Integer = 0 To wb.PixelHeight - 1
            For x As Integer = 0 To wb.PixelWidth - 1
                Dim alpha As Integer = 0
                Dim red As Integer = 0
                Dim green As Integer = 0
                Dim blue As Integer = 0

                ' Determine the pixel's color.
                If (x Mod 5 = 0) OrElse (y Mod 7 = 0) Then
                    red = CInt(y / wb.PixelHeight * 255)
                    green = rand.Next(100, 255)
                    blue = CInt(x / wb.PixelWidth * 255)
                    alpha = 255
                Else
                    red = CInt(x / wb.PixelWidth * 255)
                    green = rand.Next(100, 255)
                    blue = CInt(y / wb.PixelHeight * 255)
                    alpha = 50
                End If

                Dim pixelOffset As Integer = CInt((x + y * wb.PixelWidth) * wb.Format.BitsPerPixel / 8)
                pixels(pixelOffset) = CByte(blue)
                pixels(pixelOffset + 1) = CByte(green)
                pixels(pixelOffset + 2) = CByte(red)
                pixels(pixelOffset + 3) = CByte(alpha)


            Next

            Dim stride As Integer = CInt((wb.PixelWidth * wb.Format.BitsPerPixel) / 8)

            wb.WritePixels(rect, pixels, stride, 0)
        Next

        ' Show the bitmap in an Image element.
        img.Source = wb
    End Sub



    Private Sub cmdGenerate2_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)


        ' Create the bitmap, with the dimensions of the image placeholder.
        Dim wb As New WriteableBitmap(CInt(img.Width), CInt(img.Height), 96, 96, PixelFormats.Bgra32, Nothing)

        Dim rand As New Random()
        For x As Integer = 0 To wb.PixelWidth - 1
            For y As Integer = 0 To wb.PixelHeight - 1
                Dim alpha As Integer = 0
                Dim red As Integer = 0
                Dim green As Integer = 0
                Dim blue As Integer = 0

                ' Determine the pixel's color.
                If (x Mod 5 = 0) OrElse (y Mod 7 = 0) Then
                    red = CInt(y / wb.PixelHeight * 255)
                    green = rand.Next(100, 255)
                    blue = CInt(x / wb.PixelWidth * 255)
                    alpha = 255
                Else
                    red = CInt(x / wb.PixelWidth * 255)
                    green = rand.Next(100, 255)
                    blue = CInt(y / wb.PixelHeight * 255)
                    alpha = 50
                End If

                ' Set the pixel value.                    
                Dim colorData As Byte() = {CByte(blue), CByte(green), CByte(red), CByte(alpha)} ' B G R

                Dim rect As New Int32Rect(x, y, 1, 1)
                Dim stride As Integer = CInt((wb.PixelWidth * wb.Format.BitsPerPixel) / 8)
                wb.WritePixels(rect, colorData, stride, 0)
            Next
        Next

        ' Show the bitmap in an Image element.
        img.Source = wb
    End Sub

End Class
