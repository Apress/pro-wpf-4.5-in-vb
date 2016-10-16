Public Class TestNewCommand
    
    Private Sub NewCommand(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        MessageBox.Show("New command triggered by " & e.Source.ToString())
    End Sub

    Private Sub cmdDoCommand_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.CommandBindings(0).Command.Execute(Nothing)
    End Sub

End Class