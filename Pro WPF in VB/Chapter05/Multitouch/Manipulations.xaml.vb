Public Class Manipulations

    Private Sub image_ManipulationStarting(ByVal sender As Object, ByVal e As ManipulationStartingEventArgs)
        ' Set the container (used for coordinates.)
        e.ManipulationContainer = canvas

        ' Choose what manipulations to allow.
        e.Mode = ManipulationModes.All
    End Sub

    Private Sub image_ManipulationDelta(ByVal sender As Object, ByVal e As ManipulationDeltaEventArgs)
        ' Get the image that's being manipulated.            
        Dim element As FrameworkElement = CType(e.Source, FrameworkElement)

        ' Use the matrix to manipulate the element.
        Dim matrix As Matrix = (CType(element.RenderTransform, MatrixTransform)).Matrix

        Dim deltaManipulation = e.DeltaManipulation
        ' Find the old center, and apply the old manipulations.
        Dim center As New Point(element.ActualWidth / 2, element.ActualHeight / 2)
        center = matrix.Transform(center)

        ' Apply zoom manipulations.
        matrix.ScaleAt(deltaManipulation.Scale.X, deltaManipulation.Scale.Y, center.X, center.Y)

        ' Apply rotation manipulations.
        matrix.RotateAt(e.DeltaManipulation.Rotation, center.X, center.Y)

        ' Apply panning.
        matrix.Translate(e.DeltaManipulation.Translation.X, e.DeltaManipulation.Translation.Y)

        ' Set the final matrix.
        CType(element.RenderTransform, MatrixTransform).Matrix = matrix

    End Sub

End Class
