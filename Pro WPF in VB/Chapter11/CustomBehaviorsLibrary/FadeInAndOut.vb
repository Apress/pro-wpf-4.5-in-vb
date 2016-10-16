Imports System.Windows.Interactivity
Imports System.Windows.Media.Animation

Public Class FadeOutAction
    Inherits TargetedTriggerAction(Of UIElement)

    ' The default fade out time is 2 seconds.
    Public Shared ReadOnly DurationProperty As DependencyProperty = _
      DependencyProperty.Register("Duration", GetType(TimeSpan), _
      GetType(FadeOutAction), New PropertyMetadata(TimeSpan.FromSeconds(2)))

    Public Property Duration() As TimeSpan
        Get
            Return CType(GetValue(FadeOutAction.DurationProperty), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            SetValue(FadeOutAction.DurationProperty, value)
        End Set
    End Property

    Private fadeStoryboard As New Storyboard()
    Private fadeAnimation As New DoubleAnimation()

    Public Sub New()
        fadeStoryboard.Children.Add(fadeAnimation)
    End Sub

    Protected Overrides Sub Invoke(ByVal args As Object)
        ' Make sure the storyboard isn't already running.
        fadeStoryboard.Stop()

        ' Set up the storyboard.            
        Storyboard.SetTarget(fadeAnimation, Me.Target)
        Storyboard.SetTargetProperty(fadeAnimation, New PropertyPath("Opacity"))

        ' Set up the animation.
        ' It's important to do this at the last possible instant,
        ' in case the value for the Duration property changes.
        fadeAnimation.To = 0
        fadeAnimation.Duration = Duration

        fadeStoryboard.Begin()
    End Sub
End Class

Public Class FadeInAction
    Inherits TargetedTriggerAction(Of UIElement)

    ' The default fade in is 0.5 seconds.
    Public Shared ReadOnly DurationProperty As DependencyProperty = _
      DependencyProperty.Register("Duration", GetType(TimeSpan), _
      GetType(FadeInAction), New PropertyMetadata(TimeSpan.FromSeconds(0.5)))

    Public Property Duration() As TimeSpan
        Get
            Return CType(GetValue(FadeInAction.DurationProperty), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            SetValue(FadeInAction.DurationProperty, value)
        End Set
    End Property

    Private fadeStoryboard As New Storyboard()
    Private fadeAnimation As New DoubleAnimation()

    Public Sub New()
        fadeStoryboard.Children.Add(fadeAnimation)
    End Sub

    Protected Overrides Sub Invoke(ByVal args As Object)
        ' Make sure the storyboard isn't already running.
        fadeStoryboard.Stop()

        ' Set up the storyboard.            
        Storyboard.SetTarget(fadeAnimation, Me.Target)
        Storyboard.SetTargetProperty(fadeAnimation, New PropertyPath("Opacity"))

        ' Set up the animation.            
        fadeAnimation.To = 1
        fadeAnimation.Duration = Duration

        fadeStoryboard.Begin()
    End Sub
End Class
