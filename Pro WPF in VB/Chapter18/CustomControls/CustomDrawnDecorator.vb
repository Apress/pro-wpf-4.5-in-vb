Public Class CustomDrawnDecorator
    Inherits Decorator

    Shared Sub New()
        CustomDrawnElement.BackgroundColorProperty.AddOwner(GetType(CustomDrawnDecorator))
    End Sub


    Public Property BackgroundColor() As Color
        Get
            Return CType(GetValue(CustomDrawnElement.BackgroundColorProperty), Color)
        End Get
        Set(ByVal value As Color)
            SetValue(CustomDrawnElement.BackgroundColorProperty, value)
        End Set
    End Property

    Private Function GetForegroundBrush() As Brush
        If (Not IsMouseOver) Then
            Return New SolidColorBrush(BackgroundColor)
        Else
            Dim brush As New RadialGradientBrush(Colors.White, BackgroundColor)
            Dim absoluteGradientOrigin As Point = Mouse.GetPosition(Me)
            Dim relativeGradientOrigin As New Point(absoluteGradientOrigin.X / MyBase.ActualWidth, absoluteGradientOrigin.Y / MyBase.ActualHeight)

            brush.GradientOrigin = relativeGradientOrigin
            brush.RadiusX = 0.2
            brush.Center = relativeGradientOrigin
            brush.Freeze()
            Return brush
        End If
    End Function
    Protected Overrides Sub OnRender(ByVal dc As DrawingContext)
        MyBase.OnRender(dc)

        Dim bounds As New Rect(0, 0, MyBase.ActualWidth, MyBase.ActualHeight)
        dc.DrawRectangle(GetForegroundBrush(), Nothing, bounds)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Me.InvalidateVisual()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As MouseEventArgs)
        MyBase.OnMouseLeave(e)
        Me.InvalidateVisual()
    End Sub

    Protected Overrides Function MeasureOverride(ByVal constraint As Size) As Size
        Dim child As UIElement = Me.Child
        If Not child Is Nothing Then
            child.Measure(constraint)
            Return child.DesiredSize
        Else
            Return New Size()
        End If

    End Function
End Class