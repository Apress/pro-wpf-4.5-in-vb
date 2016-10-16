Public Class CenterScreen

    Private Sub cmdCenter_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim height As Double = SystemParameters.WorkArea.Height
        Dim width As Double = SystemParameters.WorkArea.Width
        Me.Top = (height - Me.Height) / 2
        Me.Left = (width - Me.Width) / 2
    End Sub
End Class