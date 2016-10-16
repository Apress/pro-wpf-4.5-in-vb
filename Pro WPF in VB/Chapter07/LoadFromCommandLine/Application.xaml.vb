Public Class Application

    Private Sub Application_Startup(ByVal sender As Object, ByVal e As System.Windows.StartupEventArgs) Handles Me.Startup
        ' Create, but don't show the main window.
        Dim win As New FileViewer()

        If e.Args.Length > 0 Then

            Dim file As String = e.Args(0)
            If System.IO.File.Exists(file) Then
                ' Configure the main window.
                win.LoadFile(file)
            End If

        Else

            ' (Perform alternate initialization here when
            '  no command-line arguments are supplied.)
        End If

        ' This window will automatically be set as the Application.MainWindow.
        win.Show()
    End Sub

End Class
