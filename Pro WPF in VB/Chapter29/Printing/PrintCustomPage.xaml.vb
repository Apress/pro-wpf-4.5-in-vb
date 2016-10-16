Imports System.Globalization

Public Class PrintCustomPage

    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim printDialog As New PrintDialog()
        If printDialog.ShowDialog() = True Then
            ' Create a visual for the page.
            Dim visual As New DrawingVisual()

            ' Get the drawing context
            Using dc As DrawingContext = visual.RenderOpen()
                ' Define the text you want to print.
                Dim text As New FormattedText(txtContent.Text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, New Typeface("Calibri"), 20, Brushes.Black)

                ' You must pick a maximum width to use wrapping with a FormattedText object.
                text.MaxTextWidth = printDialog.PrintableAreaWidth / 2

                ' Get the size required for the text.
                Dim textSize As New Size(text.Width, text.Height)

                ' Find the top-left corner where you want to place the text.
                Dim margin As Double = 96 * 0.25
                Dim point As New Point((printDialog.PrintableAreaWidth - textSize.Width) / 2 - margin, (printDialog.PrintableAreaHeight - textSize.Height) / 2 - margin)

                ' Draw the content.
                dc.DrawText(text, point)

                ' Add a border (a rectangle with no background).
                dc.DrawRectangle(Nothing, New Pen(Brushes.Black, 1), New Rect(margin, margin, printDialog.PrintableAreaWidth - margin * 2, printDialog.PrintableAreaHeight - margin * 2))
            End Using

            ' Print the visual.
            printDialog.PrintVisual(visual, "A Custom-Printed Page")
        End If

    End Sub
End Class