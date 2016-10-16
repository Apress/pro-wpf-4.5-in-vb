Public Class Window1

    Private Sub cmdAnswer_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Dramatic delay...
        Me.Cursor = Cursors.Wait
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1))

        Dim generator As New AnswerGenerator()
        txtAnswer.Text = generator.GetRandomAnswer(txtQuestion.Text)
        Me.Cursor = Nothing
    End Sub

End Class
