Public Class FrameBasedAnimation

    Private rendering As Boolean = False
    Private Sub cmdStart_Clicked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If (Not rendering) Then
            ellipses.Clear()
            canvas.Children.Clear()

            AddHandler CompositionTarget.Rendering, AddressOf RenderFrame
            rendering = True
        End If
    End Sub
    Private Sub cmdStop_Clicked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        StopRendering()
    End Sub

    Private Sub StopRendering()
        RemoveHandler CompositionTarget.Rendering, AddressOf RenderFrame
        rendering = False
    End Sub

    Private ellipses As List(Of EllipseInfo) = New List(Of EllipseInfo)()

    Private accelerationY As Double = 0.1
    Private minStartingSpeed As Integer = 1
    Private maxStartingSpeed As Integer = 50
    Private speedRatio As Double = 0.1
    Private minEllipses As Integer = 20
    Private maxEllipses As Integer = 100
    Private ellipseRadius As Integer = 10

    Private Sub RenderFrame(ByVal sender As Object, ByVal e As EventArgs)
        If ellipses.Count = 0 Then
            ' Animation just started. Create the ellipses.
            Dim halfCanvasWidth As Integer = CInt(Fix(canvas.ActualWidth)) / 2

            Dim rand As New Random()
            Dim ellipseCount As Integer = rand.Next(minEllipses, maxEllipses + 1)
            For i As Integer = 0 To ellipseCount - 1
                Dim ellipse As New Ellipse()
                ellipse.Fill = Brushes.LimeGreen
                ellipse.Width = ellipseRadius
                ellipse.Height = ellipseRadius
                canvas.SetLeft(ellipse, halfCanvasWidth + rand.Next(-halfCanvasWidth, halfCanvasWidth))
                canvas.SetTop(ellipse, 0)
                canvas.Children.Add(ellipse)

                Dim info As New EllipseInfo(ellipse, speedRatio * rand.Next(minStartingSpeed, maxStartingSpeed))
                ellipses.Add(info)
            Next
        Else
            For i As Integer = ellipses.Count - 1 To 0 Step -1
                Dim info As EllipseInfo = ellipses(i)
                Dim top As Double = canvas.GetTop(info.Ellipse)
                canvas.SetTop(info.Ellipse, top + 1 * info.VelocityY)

                If top >= (canvas.ActualHeight - ellipseRadius * 2 - 10) Then
                    ' This circle has reached the bottom.
                    ' Stop animating it.
                    ellipses.Remove(info)
                Else
                    ' Increase the velocity.
                    info.VelocityY += accelerationY
                End If

                If ellipses.Count = 0 Then
                    ' End the animation.
                    ' There's no reason to keep calling this method
                    ' if it has no work to do.
                    StopRendering()
                End If
            Next
        End If
    End Sub
End Class

Public Class EllipseInfo
    Private _ellipse As Ellipse
    Public Property Ellipse() As Ellipse
        Get
            Return _ellipse
        End Get
        Set(ByVal value As Ellipse)
            _ellipse = value
        End Set
    End Property

    Private _velocityY As Double
    Public Property VelocityY() As Double
        Get
            Return _velocityY
        End Get
        Set(ByVal value As Double)
            _velocityY = value
        End Set
    End Property

	Public Sub New(ByVal ellipse As Ellipse, ByVal velocityY As Double)
		Me.VelocityY = velocityY
		Me.Ellipse = ellipse
	End Sub
End Class