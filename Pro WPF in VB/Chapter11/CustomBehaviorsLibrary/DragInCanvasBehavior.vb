Imports System.Windows.Interactivity

Public Class DragInCanvasBehavior
    Inherits Behavior(Of UIElement)

    Protected Overrides Sub OnAttached()
        MyBase.OnAttached()

        ' Hook up event handlers.
        AddHandler AssociatedObject.MouseLeftButtonDown, AddressOf AssociatedObject_MouseLeftButtonDown
        AddHandler AssociatedObject.MouseMove, AddressOf AssociatedObject_MouseMove
        AddHandler AssociatedObject.MouseLeftButtonUp, AddressOf AssociatedObject_MouseLeftButtonUp
    End Sub

    Protected Overrides Sub OnDetaching()
        MyBase.OnDetaching()

        ' Detach event handlers.
        RemoveHandler AssociatedObject.MouseLeftButtonDown, AddressOf AssociatedObject_MouseLeftButtonDown
        RemoveHandler AssociatedObject.MouseMove, AddressOf AssociatedObject_MouseMove
        RemoveHandler AssociatedObject.MouseLeftButtonUp, AddressOf AssociatedObject_MouseLeftButtonUp
    End Sub
    ' Keep track of the Canvas where this element is placed.
    Private canvas As Canvas

    ' Keep track of when the element is being dragged.
    Private isDragging As Boolean = False

    ' When the element is clicked, record the exact position
    ' where the click is made.
    Private mouseOffset As Point

    Private Sub AssociatedObject_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        ' Find the Canvas.
        If canvas Is Nothing Then
            canvas = CType(VisualTreeHelper.GetParent(Me.AssociatedObject), Canvas)
        End If

        ' Dragging mode begins.
        isDragging = True

        ' Get the position of the click relative to the element
        ' (so the top-left corner of the element is (0,0).
        mouseOffset = e.GetPosition(AssociatedObject)

        ' Capture the mouse. This way you'll keep receiving
        ' the MouseMove event even if the user jerks the mouse
        ' off the element.
        AssociatedObject.CaptureMouse()
    End Sub

    Private Sub AssociatedObject_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If isDragging Then
            ' Get the position of the element relative to the Canvas.
            Dim point As Point = e.GetPosition(canvas)

            ' Move the element.
            AssociatedObject.SetValue(Canvas.TopProperty, point.Y - mouseOffset.Y)
            AssociatedObject.SetValue(Canvas.LeftProperty, point.X - mouseOffset.X)
        End If
    End Sub

    Private Sub AssociatedObject_MouseLeftButtonUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        If isDragging Then
            AssociatedObject.ReleaseMouseCapture()
            isDragging = False
        End If
    End Sub

End Class
