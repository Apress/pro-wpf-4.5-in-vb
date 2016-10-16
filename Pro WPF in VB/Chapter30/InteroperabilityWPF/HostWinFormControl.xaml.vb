Public Class HostWinFormControl

    Private Sub maskedTextBox_MaskInputRejected(ByVal sender As Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)
        lblErrorText.Content = "Error: " & e.RejectionHint.ToString()
    End Sub
End Class