Imports System.Windows.Forms.Integration

Public Class MnemonicTest2

    Private Sub MnemonicTest2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim host As New ElementHost()
        Dim button As New System.Windows.Controls.Button()
        button.Content = "Alt+_A"
        host.Child = button
        AddHandler button.Click, AddressOf button1_Click
        AddHandler button.PreviewKeyDown, AddressOf button_preview
        host.Location = New System.Drawing.Point(10, 10)
        host.Size = New System.Drawing.Size(100, 50)
        Me.Controls.Add(host)
    End Sub

    Private Sub button_preview(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs)
        e.Handled = True
    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        MessageBox.Show(sender.ToString())
    End Sub
End Class