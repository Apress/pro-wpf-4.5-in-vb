Public Class CachingTest

    Public Sub New()
        InitializeComponent()

        Dim pathGeometry As New PathGeometry()
        Dim pathFigure As New PathFigure()

        pathFigure.StartPoint = New Point(0, 0)

        Dim pathSegmentCollection As New PathSegmentCollection()

        Dim maxHeight As Integer = CInt(Me.Height)
        Dim maxWidth As Integer = CInt(Me.Width)
        Dim rand As New Random()
        For i As Integer = 0 To 499
            Dim newSegment As New LineSegment()
            newSegment.Point = New Point(rand.Next(0, maxWidth), rand.Next(0, maxHeight))
            pathSegmentCollection.Add(newSegment)
        Next

        pathFigure.Segments = pathSegmentCollection
        pathGeometry.Figures.Add(pathFigure)

        pathBackground.Data = pathGeometry


    End Sub

    Private Sub chkCache_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If chkCache.IsChecked = True Then
            Dim bitmapCache As New BitmapCache()
            pathBackground.CacheMode = New BitmapCache()
        Else
            pathBackground.CacheMode = Nothing
        End If
    End Sub

End Class
