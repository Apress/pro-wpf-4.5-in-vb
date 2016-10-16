Imports Microsoft.Win32

Public Class OpenFileTest

    Private Sub cmdOpen_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim myDialog As New OpenFileDialog()

        myDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF" & "|All files (*.*)|*.*"
        myDialog.CheckFileExists = True
        myDialog.Multiselect = True

        If myDialog.ShowDialog() = True Then
            lstFiles.Items.Clear()
            For Each file As String In myDialog.FileNames
                lstFiles.Items.Add(file)
            Next
        End If
    End Sub
End Class