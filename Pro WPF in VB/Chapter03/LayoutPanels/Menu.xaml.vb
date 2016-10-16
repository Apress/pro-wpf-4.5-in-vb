Public Class Window1

    Private Sub ButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Get the current button.
        Dim cmd As Button = CType(e.OriginalSource, Button)

        ' Create an instance of the window named
        ' by the current button.
        Dim type As Type = Me.GetType()
        Dim currentAssembly As System.Reflection.Assembly = type.Assembly
        Dim win As Window = CType(currentAssembly.CreateInstance(type.Namespace & "." & cmd.Content.ToString()), Window)

        ' Show the window.
        win.ShowDialog()
    End Sub
End Class