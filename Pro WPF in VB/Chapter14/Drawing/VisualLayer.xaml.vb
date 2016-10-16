Public Class VisualLayer

    Public Sub New()
        InitializeComponent()
        Dim v As New DrawingVisual()
        DrawSquare(v, New Point(10, 10), False)
    End Sub

    ' Variables for dragging shapes.
    Private isDragging As Boolean = False
    Private clickOffset As Vector
    Private selectedVisual As DrawingVisual

    ' Variables for drawing the selection square.
    Private selectionSquare As DrawingVisual
    Private isMultiSelecting As Boolean = False
    Private selectionSquareTopLeft As Point

    Private Sub drawingSurface_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Dim pointClicked As Point = e.GetPosition(drawingSurface)

        If cmdAdd.IsChecked = True Then
            Dim visual As New DrawingVisual()
            DrawSquare(visual, pointClicked, False)
            drawingSurface.AddVisual(visual)
        ElseIf cmdDelete.IsChecked = True Then
            Dim visual As DrawingVisual = drawingSurface.GetVisual(pointClicked)
            If Not visual Is Nothing Then
                drawingSurface.DeleteVisual(visual)
            End If
        ElseIf cmdSelectMove.IsChecked = True Then
            Dim visual As DrawingVisual = drawingSurface.GetVisual(pointClicked)
            If Not visual Is Nothing Then
                ' Calculate the top-left corner of the square.
                ' This is done by looking at the current bounds and
                ' removing half the border (pen thickness).
                ' An alternate solution would be to store the top-left
                ' point of every visual in a collection in the 
                ' DrawingCanvas, and provide this point when hit testing.
                Dim topLeftCorner As New Point(visual.ContentBounds.TopLeft.X + drawingPen.Thickness / 2, visual.ContentBounds.TopLeft.Y + drawingPen.Thickness / 2)
                DrawSquare(visual, topLeftCorner, True)

                clickOffset = topLeftCorner - pointClicked
                isDragging = True

                If selectedVisual IsNot Nothing AndAlso selectedVisual IsNot visual Then
                    ' The selection has changed. Clear the previous selection.
                    ClearSelection()
                End If
                selectedVisual = visual
            End If
        ElseIf cmdSelectMultiple.IsChecked = True Then
            selectionSquare = New DrawingVisual()
            drawingSurface.AddVisual(selectionSquare)

            selectionSquareTopLeft = pointClicked
            isMultiSelecting = True

            ' Make sure we get the MouseLeftButtonUp event even if the user
            ' moves off the Canvas. Otherwise, two selection squares could be drawn at once.
            drawingSurface.CaptureMouse()
        End If
    End Sub

    ' Drawing constants.
    Private drawingBrush As Brush = Brushes.AliceBlue
    Private selectedDrawingBrush As Brush = Brushes.LightGoldenrodYellow
    Private drawingPen As New Pen(Brushes.SteelBlue, 3)
    Private squareSize As New Size(30, 30)

    ' Rendering the square.
    Private Sub DrawSquare(ByVal visual As DrawingVisual, ByVal topLeftCorner As Point, ByVal isSelected As Boolean)
        Using dc As DrawingContext = visual.RenderOpen()
            Dim brush As Brush = drawingBrush
            If isSelected Then
                brush = selectedDrawingBrush
            End If

            dc.DrawRectangle(brush, drawingPen, New Rect(topLeftCorner, squareSize))
        End Using
    End Sub

    Private Sub ClearSelection()
        Dim topLeftCorner As New Point(selectedVisual.ContentBounds.TopLeft.X + drawingPen.Thickness / 2, selectedVisual.ContentBounds.TopLeft.Y + drawingPen.Thickness / 2)
        DrawSquare(selectedVisual, topLeftCorner, False)
        selectedVisual = Nothing
    End Sub

    Private Sub drawingSurface_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If isDragging Then
            Dim pointDragged As Point = e.GetPosition(drawingSurface) + clickOffset
            DrawSquare(selectedVisual, pointDragged, True)
        ElseIf isMultiSelecting Then
            Dim pointDragged As Point = e.GetPosition(drawingSurface)
            DrawSelectionSquare(selectionSquareTopLeft, pointDragged)
        End If
    End Sub

    Private Sub drawingSurface_MouseLeftButtonUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        isDragging = False

        If isMultiSelecting Then
            ' Display all the squares in this region.
            Dim geometry As New RectangleGeometry(New Rect(selectionSquareTopLeft, e.GetPosition(drawingSurface)))
            Dim visualsInRegion As List(Of DrawingVisual) = drawingSurface.GetVisuals(geometry)
            MessageBox.Show(String.Format("You selected {0} square(s).", visualsInRegion.Count))

            isMultiSelecting = False
            drawingSurface.DeleteVisual(selectionSquare)
            drawingSurface.ReleaseMouseCapture()
        End If
    End Sub

    Private selectionSquareBrush As Brush = Brushes.Transparent
    Private selectionSquarePen As New Pen(Brushes.Black, 2)

    Private Sub DrawSelectionSquare(ByVal point1 As Point, ByVal point2 As Point)
        selectionSquarePen.DashStyle = DashStyles.Dash

        Using dc As DrawingContext = selectionSquare.RenderOpen()
            dc.DrawRectangle(selectionSquareBrush, selectionSquarePen, New Rect(point1, point2))
        End Using
    End Sub
End Class