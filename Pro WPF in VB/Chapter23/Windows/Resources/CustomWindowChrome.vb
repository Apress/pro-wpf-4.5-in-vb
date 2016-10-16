Public Class CustomWindowChrome

    Private isResizing As Boolean = False
    <Flags()> _
    Private Enum ResizeType
        Width
        Height
    End Enum
    Private resizingType As ResizeType

    Private Sub window_initiateResizeWE(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
        isResizing = True
        resizingType = ResizeType.Width
    End Sub
    Private Sub window_initiateResizeNS(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
        isResizing = True
        resizingType = ResizeType.Height
    End Sub

    Private Sub window_endResize(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
        isResizing = False

        ' Make sure capture is released.
        Dim rect As Rectangle = CType(sender, Rectangle)
        rect.ReleaseMouseCapture()
    End Sub

    Private Sub window_Resize(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
        Dim rect As Rectangle = CType(sender, Rectangle)
        Dim win As Window = CType(rect.TemplatedParent, Window)

        If isResizing Then
            rect.CaptureMouse()
            If resizingType = ResizeType.Width Then
                Dim width As Double = e.GetPosition(win).X + 5
                If width > 0 Then
                    win.Width = width
                End If
            End If
            If resizingType = ResizeType.Height Then
                Dim height As Double = e.GetPosition(win).Y + 5
                If height > 0 Then
                    win.Height = height
                End If
            End If
        End If
    End Sub

    Private Sub titleBar_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Dim win As Window = CType((CType(sender, FrameworkElement)).TemplatedParent, Window)
        win.DragMove()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim win As Window = CType((CType(sender, FrameworkElement)).TemplatedParent, Window)
        win.Close()
    End Sub
End Class
