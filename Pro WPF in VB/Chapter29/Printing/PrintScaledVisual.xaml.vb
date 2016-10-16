Public Class PrintScaledVisual

    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim printDialog As New PrintDialog()
        If printDialog.ShowDialog() = True Then
            ' Create the text.
            Dim run As New Run("This is a test of the printing functionality in the Windows Presentation Foundation.")

            ' Wrap it in a TextBlock.
            Dim visual As New TextBlock(run)
            visual.Margin = New Thickness(15)
            ' Allow wrapping to fit the page width.
            visual.TextWrapping = TextWrapping.Wrap

            ' Scale the TextBlock in both dimensions.
            Dim zoom As Double
            If Double.TryParse(txtScale.Text, zoom) Then
                visual.LayoutTransform = New ScaleTransform(zoom / 100, zoom / 100)

                ' Get the size of the page.
                Dim pageSize As New Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight)
                ' Trigger the sizing of the element.                
                visual.Measure(pageSize)
                visual.Arrange(New Rect(0, 0, pageSize.Width, pageSize.Height))

                ' Print the element.
                printDialog.PrintVisual(visual, "A Scaled Drawing")
            Else
                MessageBox.Show("Invalid scale value.")
            End If
        End If

    End Sub
End Class