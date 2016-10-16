Imports System.Windows.Media.Animation
Imports System.Windows.Threading

Class MainWindow
    Public Sub New()
        InitializeComponent()
        AddHandler bombTimer.Tick, AddressOf bombTimer_Tick
    End Sub

    Private Sub canvasBackground_SizeChanged(ByVal sender As Object, ByVal e As SizeChangedEventArgs)
        Dim rect As New RectangleGeometry()
        rect.Rect = New Rect(0, 0, canvasBackground.ActualWidth, canvasBackground.ActualHeight)
        canvasBackground.Clip = rect
    End Sub

    ' "Adjustments" happen periodically, increasing the speed of bomb
    ' falling and shortening the time between bombs.
    Private lastAdjustmentTime As DateTime = DateTime.MinValue

    ' Perform an adjustment every 15 seconds.
    Private secondsBetweenAdjustments As Double = 15

    ' Initially, bombs fall every 1.3 seconds, and hit the ground after 3.5 seconds.
    Private initialSecondsBetweenBombs As Double = 1.3
    Private initialSecondsToFall As Double = 3.5
    Private secondsBetweenBombs As Double
    Private secondsToFall As Double

    ' After every adjustment, shave 0.1 seconds off both.
    Private secondsBetweenBombsReduction As Double = 0.1
    Private secondsToFallReduction As Double = 0.1

    ' Make it possible to look up a storyboard based on a bomb.
    Private storyboards As Dictionary(Of Bomb, Storyboard) = New Dictionary(Of Bomb, Storyboard)()

    ' Fires events on the user interface thread.
    Private bombTimer As New DispatcherTimer()

    ' Start the game.
    Private Sub cmdStart_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        cmdStart.IsEnabled = False

        ' Reset the game.
        droppedCount = 0
        savedCount = 0
        secondsBetweenBombs = initialSecondsBetweenBombs
        secondsToFall = initialSecondsToFall

        ' Start bomb dropping events.            
        bombTimer.Interval = TimeSpan.FromSeconds(secondsBetweenBombs)
        bombTimer.Start()
    End Sub

    ' Drop a bomb.
    Private Sub bombTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        ' Perform an "adjustment" when needed.
        If (DateTime.Now.Subtract(lastAdjustmentTime).TotalSeconds > secondsBetweenAdjustments) Then
            lastAdjustmentTime = DateTime.Now

            secondsBetweenBombs -= secondsBetweenBombsReduction
            secondsToFall -= secondsToFallReduction

            ' (Technically, you should check for 0 or negative values.
            ' However, in practice these won't occur because the game will
            ' always end first.)

            ' Set the timer to drop the next bomb at the appropriate time.
            bombTimer.Interval = TimeSpan.FromSeconds(secondsBetweenBombs)

            ' Update the status message.
            lblRate.Text = String.Format("A bomb is released every {0} seconds.", secondsBetweenBombs)
            lblSpeed.Text = String.Format("Each bomb takes {0} seconds to fall.", secondsToFall)
        End If

        ' Create the bomb.
        Dim bomb As New Bomb()
        bomb.IsFalling = True

        ' Position the bomb.            
        Dim random As New Random()
        bomb.SetValue(Canvas.LeftProperty, CDbl(random.Next(0, CInt(Fix(canvasBackground.ActualWidth - 50)))))
        bomb.SetValue(Canvas.TopProperty, -100.0)

        ' Attach mouse click event (for defusing the bomb).
        AddHandler bomb.MouseLeftButtonDown, AddressOf bomb_MouseLeftButtonDown

        ' Create the animation for the falling bomb.
        Dim storyboard As New Storyboard()
        Dim fallAnimation As New DoubleAnimation()
        fallAnimation.To = canvasBackground.ActualHeight
        fallAnimation.Duration = TimeSpan.FromSeconds(secondsToFall)

        storyboard.SetTarget(fallAnimation, bomb)
        storyboard.SetTargetProperty(fallAnimation, New PropertyPath("(Canvas.Top)"))
        storyboard.Children.Add(fallAnimation)

        ' Create the animation for the bomb "wiggle."
        Dim wiggleAnimation As New DoubleAnimation()
        wiggleAnimation.To = 30
        wiggleAnimation.Duration = TimeSpan.FromSeconds(0.2)
        wiggleAnimation.RepeatBehavior = RepeatBehavior.Forever
        wiggleAnimation.AutoReverse = True

        storyboard.SetTarget(wiggleAnimation, (CType(bomb.RenderTransform, TransformGroup)).Children(0))
        storyboard.SetTargetProperty(wiggleAnimation, New PropertyPath("Angle"))
        storyboard.Children.Add(wiggleAnimation)

        ' Add the bomb to the Canvas.
        canvasBackground.Children.Add(bomb)

        ' Add the storyboard to the tracking collection.            
        storyboards.Add(bomb, storyboard)

        ' Configure and start the storyboard.
        storyboard.Duration = fallAnimation.Duration
        AddHandler storyboard.Completed, AddressOf storyboard_Completed
        storyboard.Begin()
    End Sub

    Private Sub bomb_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        ' Get the bomb.
        Dim bomb As Bomb = CType(sender, Bomb)
        bomb.IsFalling = False

        ' Get the bomb's current position.
        Dim storyboard As Storyboard = storyboards(bomb)
        Dim currentTop As Double = Canvas.GetTop(bomb)

        ' Stop the bomb from falling.
        storyboard.Stop()

        ' Reuse the existing storyboard, but with new animations.
        ' Send the bomb on a new trajectory by animating Canvas.Top
        ' and Canvas.Left.
        storyboard.Children.Clear()

        Dim riseAnimation As New DoubleAnimation()
        riseAnimation.From = currentTop
        riseAnimation.To = 0
        riseAnimation.Duration = TimeSpan.FromSeconds(2)

        storyboard.SetTarget(riseAnimation, bomb)
        storyboard.SetTargetProperty(riseAnimation, New PropertyPath("(Canvas.Top)"))
        storyboard.Children.Add(riseAnimation)

        Dim slideAnimation As New DoubleAnimation()
        Dim currentLeft As Double = Canvas.GetLeft(bomb)
        ' Throw the bomb off the closest side.
        If currentLeft < canvasBackground.ActualWidth / 2 Then
            slideAnimation.To = -100
        Else
            slideAnimation.To = canvasBackground.ActualWidth + 100
        End If
        slideAnimation.Duration = TimeSpan.FromSeconds(1)
        storyboard.SetTarget(slideAnimation, bomb)
        storyboard.SetTargetProperty(slideAnimation, New PropertyPath("(Canvas.Left)"))
        storyboard.Children.Add(slideAnimation)

        ' Start the new animation.
        storyboard.Duration = slideAnimation.Duration
        storyboard.Begin()
    End Sub

    ' Keep track of how many are dropped and stopped.
    Private droppedCount As Integer = 0
    Private savedCount As Integer = 0

    ' End the game at maxDropped.
    Private maxDropped As Integer = 5

    Private Sub storyboard_Completed(ByVal sender As Object, ByVal e As EventArgs)
        Dim clockGroup As ClockGroup = CType(sender, ClockGroup)

        ' Get the first animation in the storyboard, and use it to find the
        ' bomb that's being animated.
        Dim completedAnimation As DoubleAnimation = CType(clockGroup.Children(0).Timeline, DoubleAnimation)
        Dim completedBomb As Bomb = CType(Storyboard.GetTarget(completedAnimation), Bomb)

        ' Determine if a bomb fell or flew off the Canvas after being clicked.
        If completedBomb.IsFalling Then
            droppedCount += 1
        Else
            savedCount += 1
        End If

        ' Update the display.
        lblStatus.Text = String.Format("You have dropped {0} bombs and saved {1}.", droppedCount, savedCount)

        ' Check if it's game over.
        If droppedCount >= maxDropped Then
            bombTimer.Stop()
            lblStatus.Text += Constants.vbCrLf & Constants.vbCrLf & "Game over."

            ' Find all the storyboards that are underway.
            For Each item As KeyValuePair(Of Bomb, Storyboard) In storyboards
                Dim storyboard As Storyboard = item.Value
                Dim bomb As Bomb = item.Key

                storyboard.Stop()
                canvasBackground.Children.Remove(bomb)
            Next
            ' Empty the tracking collection.
            storyboards.Clear()

            ' Allow the user to start a new game.
            cmdStart.IsEnabled = True
        Else
            Dim storyboard As Storyboard = CType(clockGroup.Timeline, Storyboard)
            storyboard.Stop()

            storyboards.Remove(completedBomb)
            canvasBackground.Children.Remove(completedBomb)
        End If
    End Sub




End Class
