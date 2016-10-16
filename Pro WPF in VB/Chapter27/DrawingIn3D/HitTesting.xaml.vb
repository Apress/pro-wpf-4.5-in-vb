Imports System.Windows.Media.Media3D
Imports System.Windows.Media.Animation

Public Class HitTesting

    Private Sub ringVisual_MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Dim location As Point = e.GetPosition(viewport)

        Dim meshHitResult As RayMeshGeometry3DHitTestResult = CType(VisualTreeHelper.HitTest(viewport, location), RayMeshGeometry3DHitTestResult)

        axisRotation.Axis = New Vector3D(-meshHitResult.PointHit.Y, meshHitResult.PointHit.X, 0)

        Dim animation As New DoubleAnimation()
        animation.To = 40
        animation.DecelerationRatio = 1
        animation.Duration = TimeSpan.FromSeconds(0.15)
        animation.AutoReverse = True
        axisRotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, animation)
    End Sub

    ' Alternative implementation using the Viewport.MouseDown event.
    Private Sub viewport_MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Dim location As Point = e.GetPosition(viewport)
        Dim hitResult As HitTestResult = VisualTreeHelper.HitTest(viewport, location)

        If Not hitResult Is Nothing AndAlso hitResult.VisualHit Is ringVisual Then
            ' Hit the ring.
        End If

        Dim meshHitResult As RayMeshGeometry3DHitTestResult = TryCast(hitResult, RayMeshGeometry3DHitTestResult)
        If Not meshHitResult Is Nothing AndAlso meshHitResult.ModelHit Is ringModel Then
            ' Hit the ring.
        End If
        If (meshHitResult IsNot Nothing) AndAlso (meshHitResult.MeshHit Is ringMesh) Then
            axisRotation.Axis = New Vector3D(-meshHitResult.PointHit.Y, meshHitResult.PointHit.X, 0)

            Dim animation As New DoubleAnimation()
            animation.To = 40
            animation.DecelerationRatio = 1
            animation.Duration = TimeSpan.FromSeconds(0.15)
            animation.AutoReverse = True
            axisRotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, animation)
        End If
    End Sub
End Class
