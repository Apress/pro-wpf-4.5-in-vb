Imports System.IO

Public Class DirectoryTreeView

    Public Sub New()
        InitializeComponent()
        BuildTree()
    End Sub

    Private Sub BuildTree()
        treeFileSystem.Items.Clear()

        For Each drive As DriveInfo In DriveInfo.GetDrives()
            Dim item As New TreeViewItem()
            item.Tag = drive
            item.Header = drive.ToString()

            ' This placeholder string is never shown,
            ' because the node begins in collapsed state.
            item.Items.Add("*")
            treeFileSystem.Items.Add(item)
        Next
    End Sub

    Private Sub item_Expanded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim item As TreeViewItem = CType(e.OriginalSource, TreeViewItem)

        ' Perform a refresh every time item is expanded.
        ' Optionally, you could perform this only the first
        ' time, when the placeholder is found (less refreshes),
        ' every time an item is selected (more refreshes)
        ' or when a message is received by the FileSystemWatcher
        ' (intelligent refreshes, requiring the most overhead).
        item.Items.Clear()

        Dim dir As DirectoryInfo
        If TypeOf item.Tag Is DriveInfo Then
            Dim drive As DriveInfo = CType(item.Tag, DriveInfo)
            dir = drive.RootDirectory
        Else
            dir = CType(item.Tag, DirectoryInfo)
        End If

        Try
            For Each subDir As DirectoryInfo In dir.GetDirectories()
                Dim newItem As New TreeViewItem()
                newItem.Tag = subDir
                newItem.Header = subDir.ToString()
                newItem.Items.Add("*")
                item.Items.Add(newItem)
            Next
        Catch
            ' An exception could be thrown in this code if you don't
            ' have sufficient security permissions for a file or directory.
            ' You can catch and then ignore this exception.
        End Try
    End Sub

End Class

