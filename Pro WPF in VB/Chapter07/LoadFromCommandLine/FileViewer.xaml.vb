Imports System.IO

Partial Public Class FileViewer

    Public Sub LoadFile(ByVal path As String)
        Me.Content = File.ReadAllText(path)
        Me.Title = path
    End Sub
End Class
