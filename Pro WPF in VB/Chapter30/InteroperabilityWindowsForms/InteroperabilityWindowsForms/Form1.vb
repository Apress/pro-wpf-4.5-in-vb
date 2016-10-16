Imports System.Windows.Forms.Integration

Public Class Form1

    Private Sub cmdShowWrong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowWrong.Click
        Dim win As New WPFWindowLibrary.Window1()
        win.Show()
    End Sub

    Private Sub cmdShowRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowRight.Click
        Dim win As New WPFWindowLibrary.Window1()
        ElementHost.EnableModelessKeyboardInterop(win)
        win.Show()
    End Sub

    Private Sub cmdShowMixedForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowMixedForm.Click
        Dim form As New MixedForm()
        form.Show()
    End Sub
End Class
