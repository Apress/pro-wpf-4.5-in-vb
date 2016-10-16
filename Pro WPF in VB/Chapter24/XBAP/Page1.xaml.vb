Imports System.Security.Permissions
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Security

Public Class Page1

    Private Sub cmdWrite_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        System.IO.File.WriteAllText("c:\test.txt", "This isn't allowed.")
    End Sub

    Private Sub cmdWriteSafely_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim content As String = "This is a test"

        ' Create a permission that represents writing to a file.
        Dim filePath As String = "c:\highscores.txt"
        Dim permission As New FileIOPermission(FileIOPermissionAccess.Write, filePath)

        ' Check for this permission.
        If CheckPermission(permission) Then
            ' Write to local hard drive.
            Try
                Using fs As FileStream = File.Create(filePath)
                    WriteHighScores(fs, content)
                End Using
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        Else
            ' Write to isolated storage.
            Try
                Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
                Using fs As New IsolatedStorageFileStream("highscores.txt", FileMode.Create, store)
                    WriteHighScores(fs, content)
                End Using
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End If
    End Sub

    Private Sub cmdReadSafely_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim content As String = ""

        ' Create a permission that represents writing to a file.
        Dim filePath As String = "c:\highscores.txt"
        Dim permission As New FileIOPermission(FileIOPermissionAccess.Write, filePath)

        ' Check for this permission.
        If CheckPermission(permission) Then
            Try
                Using fs As FileStream = File.Open(filePath, FileMode.Open)
                    content = ReadHighScores(fs)
                End Using
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        Else
            ' Read from isolated storage.
            Try
                Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
                Using fs As New IsolatedStorageFileStream("highscores.txt", FileMode.Open, store)
                    content = ReadHighScores(fs)
                End Using
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End If

        If content <> "" Then
            MessageBox.Show(content)
        End If
    End Sub

    ' A better implementation would cache this information over the lifetime of the application,
    ' so the permission only needs to be evaluated once.
    Private Function CheckPermission(ByVal requestedPermission As CodeAccessPermission) As Boolean
        Try
            ' Try to get this permission.
            requestedPermission.Demand()
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Sub WriteHighScores(ByVal fs As FileStream, ByVal content As String)
        Dim w As New StreamWriter(fs)
        w.WriteLine(content)
        w.Close()
        fs.Close()
    End Sub

    Private Function ReadHighScores(ByVal fs As FileStream) As String
        Dim r As New StreamReader(fs)
        Dim content As String = r.ReadToEnd()
        r.Close()
        fs.Close()
        Return content
    End Function
End Class