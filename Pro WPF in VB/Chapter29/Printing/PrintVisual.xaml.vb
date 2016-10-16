Public Class PrintVisual

    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim printDialog As New PrintDialog()

        If printDialog.ShowDialog() = True Then
            ' Scale the TextBlock in both dimensions.
            Dim zoom As Double
            If Double.TryParse(txtScale.Text, zoom) Then
                grid.Visibility = Visibility.Hidden

                ' Add a background to make it easier to see the canvas bounds.
                canvas.Background = Brushes.LightSteelBlue

                ' Resize it.
                canvas.LayoutTransform = New ScaleTransform(zoom / 100, zoom / 100)

                ' Get the size of the page.
                Dim pageSize As New Size(printDialog.PrintableAreaWidth - 20, printDialog.PrintableAreaHeight - 20)

                ' Trigger the sizing of the element.                                    
                canvas.Measure(pageSize)
                canvas.Arrange(New Rect(10, 10, pageSize.Width, pageSize.Height))

                ' Print the element.
                printDialog.PrintVisual(canvas, "A Scaled Drawing")

                ' Reset the canvas.
                canvas.Background = Nothing
                canvas.LayoutTransform = Nothing
                grid.Visibility = Visibility.Visible

            Else
                MessageBox.Show("Invalid scale value.")
            End If

        End If

    End Sub
End Class