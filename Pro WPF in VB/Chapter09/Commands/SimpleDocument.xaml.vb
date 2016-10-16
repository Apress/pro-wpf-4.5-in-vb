Public Class SimpleDocument
    
    Public Sub New()
        InitializeComponent()

        ' Create bindings.
        Dim binding As CommandBinding
        binding = New CommandBinding(ApplicationCommands.[New])
        AddHandler binding.Executed, AddressOf NewCommand
        Me.CommandBindings.Add(binding)

        binding = New CommandBinding(ApplicationCommands.Open)
        AddHandler binding.Executed, AddressOf OpenCommand
        Me.CommandBindings.Add(binding)

        binding = New CommandBinding(ApplicationCommands.Save)
        AddHandler binding.Executed, AddressOf SaveCommand_Executed
        AddHandler binding.CanExecute, AddressOf SaveCommand_CanExecute
        Me.CommandBindings.Add(binding)
    End Sub

    Private Sub NewCommand(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        MessageBox.Show("New command triggered with " & e.Source.ToString())
        isDirty = False
    End Sub

    Private Sub OpenCommand(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        isDirty = False
    End Sub

    Private Sub SaveCommand_Executed(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        MessageBox.Show("Save command triggered with " & e.Source.ToString())
        isDirty = False
    End Sub

    Private isDirty As Boolean = False
    Private Sub txt_TextChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        isDirty = True
    End Sub

    Private Sub SaveCommand_CanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = isDirty
    End Sub

End Class