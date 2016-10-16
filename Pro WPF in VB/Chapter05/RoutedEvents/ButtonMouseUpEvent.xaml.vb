Public Class ButtonMouseUpEvent

    Public Sub New()
        InitializeComponent()
        cmd.AddHandler(Button.MouseUpEvent, _
          New RoutedEventHandler(AddressOf Backdoor), True)
    End Sub

    Private Sub ButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show("The Button.Click event occurred. This may have been triggered with the keyboard.")
    End Sub

    Private Sub NeverCalled(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show("You didn't see this message. That would be impossible.")
    End Sub

    Private Sub Backdoor(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show("The (handled) Button.MouseUp event occurred.")
    End Sub

End Class