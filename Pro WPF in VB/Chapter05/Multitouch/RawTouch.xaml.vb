Public Class RawTouch

    ' Store the active ellipses, each of which corresponds to a place the user is currently touching down.
    Private movingEllipses As Dictionary(Of Integer, Ellipse) = New Dictionary(Of Integer, Ellipse)()

    Private Sub canvas_TouchDown(ByVal sender As Object, ByVal e As TouchEventArgs)
        ' Create an ellipse to draw at the new touch-down point.
        Dim ellipse As Ellipse
        ellipse = New Ellipse()
        ellipse.Width = 30
        ellipse.Height = 30
        ellipse.Stroke = Brushes.White
        ellipse.Fill = Brushes.Green

        ' Position the ellipse at the touch-down point.
        Dim touchPoint As TouchPoint = e.GetTouchPoint(canvas)
        Canvas.SetTop(ellipse, touchPoint.Bounds.Top)
        Canvas.SetLeft(ellipse, touchPoint.Bounds.Left)

        ' Store the ellipse in the active collection.
        movingEllipses(e.TouchDevice.Id) = ellipse

        ' Add the ellipse to the Canvas.
        canvas.Children.Add(ellipse)
    End Sub

    Private Sub canvas_TouchMove(ByVal sender As Object, ByVal e As TouchEventArgs)
        ' Get the ellipse that corresponds to the current touch-down.
        Dim ellipse As Ellipse = movingEllipses(e.TouchDevice.Id)

        ' Move it to the new touch-down point.
        Dim touchPoint As TouchPoint = e.GetTouchPoint(canvas)
        Canvas.SetTop(ellipse, touchPoint.Bounds.Top)
        Canvas.SetLeft(ellipse, touchPoint.Bounds.Left)
    End Sub

    Private Sub canvas_TouchUp(ByVal sender As Object, ByVal e As TouchEventArgs)
        ' Remove the ellipse from the collection.
        movingEllipses.Remove(e.TouchDevice.Id)
        ' (You could also, optionally, remove the ellipse from the Canvas.)
    End Sub

End Class
