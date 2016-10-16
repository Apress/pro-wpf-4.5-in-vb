Public Class DrawingCanvas
    Inherits Panel

    Private visuals As New List(Of Visual)()

    Protected Overrides Function GetVisualChild(ByVal index As Integer) As Visual
        Return visuals(index)
    End Function
    Protected Overrides ReadOnly Property VisualChildrenCount() As Integer
        Get
            Return visuals.Count
        End Get
    End Property

    Public Sub AddVisual(ByVal visual As Visual)
        visuals.Add(visual)

        MyBase.AddVisualChild(visual)
        MyBase.AddLogicalChild(visual)
    End Sub

    Public Sub DeleteVisual(ByVal visual As Visual)
        visuals.Remove(visual)

        MyBase.RemoveVisualChild(visual)
        MyBase.RemoveLogicalChild(visual)
    End Sub

    Public Function GetVisual(ByVal point As Point) As DrawingVisual
        Dim hitResult As HitTestResult = VisualTreeHelper.HitTest(Me, point)
        Return TryCast(hitResult.VisualHit, DrawingVisual)
    End Function

    Private hits As New List(Of DrawingVisual)()
    Public Function GetVisuals(ByVal region As Geometry) As List(Of DrawingVisual)
        hits.Clear()
        Dim parameters As New GeometryHitTestParameters(region)
        Dim callback As New HitTestResultCallback(AddressOf Me.HitTestCallback)
        VisualTreeHelper.HitTest(Me, Nothing, callback, parameters)
        Return hits
    End Function

    Private Function HitTestCallback(ByVal result As HitTestResult) As HitTestResultBehavior
        Dim geometryResult As GeometryHitTestResult = CType(result, GeometryHitTestResult)
        Dim visual As DrawingVisual = TryCast(result.VisualHit, DrawingVisual)
        If visual IsNot Nothing AndAlso geometryResult.IntersectionDetail = IntersectionDetail.FullyInside Then
            hits.Add(visual)
        End If
        Return HitTestResultBehavior.Continue
    End Function

End Class
