Public Class WrapBreakPanel
    Inherits Panel

    Public Shared LineBreakBeforeProperty As DependencyProperty

    Shared Sub New()
        Dim metadata As New FrameworkPropertyMetadata()
        metadata.AffectsArrange = True
        metadata.AffectsMeasure = True
        LineBreakBeforeProperty = DependencyProperty.RegisterAttached("LineBreakBefore", GetType(Boolean), GetType(WrapBreakPanel), metadata)
    End Sub
    Public Shared Sub SetLineBreakBefore(ByVal element As UIElement, ByVal value As Boolean)
        element.SetValue(LineBreakBeforeProperty, value)
    End Sub
    Public Shared Function GetLineBreakBefore(ByVal element As UIElement) As Boolean
        Return CBool(element.GetValue(LineBreakBeforeProperty))
    End Function

    Protected Overrides Function MeasureOverride(ByVal constraint As Size) As Size
        Dim currentLineSize As New Size()
        Dim panelSize As New Size()

        For Each element As UIElement In MyBase.InternalChildren
            element.Measure(constraint)
            Dim desiredSize As Size = element.DesiredSize

            If GetLineBreakBefore(element) OrElse currentLineSize.Width + desiredSize.Width > constraint.Width Then
                ' Switch to a new line (either because the element has requested it
                ' or space has run out).
                panelSize.Width = Math.Max(currentLineSize.Width, panelSize.Width)
                panelSize.Height += currentLineSize.Height
                currentLineSize = desiredSize

                ' If the element is too wide to fit using the maximum width of the line,
                ' just give it a separate line.
                If desiredSize.Width > constraint.Width Then
                    panelSize.Width = Math.Max(desiredSize.Width, panelSize.Width)
                    panelSize.Height += desiredSize.Height
                    currentLineSize = New Size()
                End If
            Else
                ' Keep adding to the current line.
                currentLineSize.Width += desiredSize.Width

                ' Make sure the line is as tall as its tallest element.
                currentLineSize.Height = Math.Max(desiredSize.Height, currentLineSize.Height)
            End If
        Next

        ' Return the size required to fit all elements.
        ' Ordinarily, this is the width of the constraint, and the height
        ' is based on the size of the elements.
        ' However, if an element is wider than the width given to the panel,
        ' the desired width will be the width of that line.
        panelSize.Width = Math.Max(currentLineSize.Width, panelSize.Width)
        panelSize.Height += currentLineSize.Height
        Return panelSize
    End Function

    Protected Overrides Function ArrangeOverride(ByVal arrangeBounds As Size) As Size
        Dim firstInLine As Integer = 0

        Dim currentLineSize As New Size()

        Dim accumulatedHeight As Double = 0

        Dim elements As UIElementCollection = MyBase.InternalChildren
        For i As Integer = 0 To elements.Count - 1

            Dim desiredSize As Size = elements(i).DesiredSize

            If GetLineBreakBefore(elements(i)) OrElse currentLineSize.Width + desiredSize.Width > arrangeBounds.Width Then 'need to switch to another line
                arrangeLine(accumulatedHeight, currentLineSize.Height, firstInLine, i)

                accumulatedHeight += currentLineSize.Height
                currentLineSize = desiredSize

                If desiredSize.Width > arrangeBounds.Width Then 'the element is wider then the constraint - give it a separate line                   
                    arrangeLine(accumulatedHeight, desiredSize.Height, i, i + 1)
                    i += 1
                    accumulatedHeight += desiredSize.Height
                    currentLineSize = New Size()
                End If
                firstInLine = i
            Else
                currentLineSize.Width += desiredSize.Width
                currentLineSize.Height = Math.Max(desiredSize.Height, currentLineSize.Height)
            End If
        Next

        If firstInLine < elements.Count Then
            arrangeLine(accumulatedHeight, currentLineSize.Height, firstInLine, elements.Count)
        End If

        Return arrangeBounds
    End Function

    Private Sub arrangeLine(ByVal y As Double, ByVal lineHeight As Double, ByVal start As Integer, ByVal [end] As Integer)
        Dim x As Double = 0
        Dim children As UIElementCollection = InternalChildren
        For i As Integer = start To [end] - 1
            Dim child As UIElement = children(i)
            child.Arrange(New Rect(x, y, child.DesiredSize.Width, lineHeight))
            x += child.DesiredSize.Width
        Next
    End Sub

End Class


