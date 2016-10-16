Imports System.Windows.Media.Animation

Public Class CodeAnimation

    Private Sub cmdGrow_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim widthAnimation As New DoubleAnimation()
        widthAnimation.To = Me.Width - 30
        widthAnimation.Duration = TimeSpan.FromSeconds(5)
        AddHandler widthAnimation.Completed, AddressOf animation_Completed

        Dim heightAnimation As New DoubleAnimation()
        heightAnimation.To = (Me.Height - 50) / 3
        heightAnimation.Duration = TimeSpan.FromSeconds(5)

        cmdGrow.BeginAnimation(Button.WidthProperty, widthAnimation)
        cmdGrow.BeginAnimation(Button.HeightProperty, heightAnimation)
    End Sub
    Private Sub animation_Completed(ByVal sender As Object, ByVal e As EventArgs)
        'Dim currentWidth As Double = cmdGrow.Width
        'cmdGrow.BeginAnimation(Button.WidthProperty, Nothing)
        'cmdGrow.Width = currentWidth

        'MessageBox.Show("Completed!")
    End Sub

    Private Sub cmdShrink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim widthAnimation As New DoubleAnimation()
        widthAnimation.Duration = TimeSpan.FromSeconds(5)
        Dim heightAnimation As New DoubleAnimation()
        heightAnimation.Duration = TimeSpan.FromSeconds(5)

        cmdGrow.BeginAnimation(Button.WidthProperty, widthAnimation)
        cmdGrow.BeginAnimation(Button.HeightProperty, heightAnimation)
    End Sub

    Private Sub cmdGrowIncrementally_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim widthAnimation As New DoubleAnimation()
        widthAnimation.By = 10
        widthAnimation.Duration = TimeSpan.FromSeconds(0.5)

        cmdGrowIncrementally.BeginAnimation(Button.WidthProperty, widthAnimation)
    End Sub
End Class