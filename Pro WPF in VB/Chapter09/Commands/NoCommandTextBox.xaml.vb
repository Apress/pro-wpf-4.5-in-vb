Public Class NoCommandTextBox
    
    Public Sub New()
        InitializeComponent()

        txt.CommandBindings.Add(New CommandBinding(ApplicationCommands.Cut, Nothing, AddressOf SuppressCommand))
        txt.InputBindings.Add(New KeyBinding(ApplicationCommands.NotACommand, Key.C, ModifierKeys.Control))

    End Sub

    Private Sub SuppressCommand(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = False
        e.Handled = True
    End Sub
End Class