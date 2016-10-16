Public Class CustomCommand

    Private Sub RequeryCommand(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        MessageBox.Show("Requery")
    End Sub

End Class

Public Class DataCommands
	Private Shared requery_Renamed As RoutedUICommand
	Shared Sub New()
		Dim inputs As New InputGestureCollection()
		inputs.Add(New KeyGesture(Key.R, ModifierKeys.Control, "Ctrl+R"))
		requery_Renamed = New RoutedUICommand("Requery", "Requery", GetType(DataCommands), inputs)
	End Sub

	Public Shared ReadOnly Property Requery() As RoutedUICommand
		Get
			Return requery_Renamed
		End Get
	End Property
End Class
