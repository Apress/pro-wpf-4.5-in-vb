Imports Microsoft.Win32

Public Class WindowPositionHelper
    Public Shared RegPath As String = "Software\MyApp\"

    Public Shared Sub SaveSize(ByVal win As Window)
        ' Create or retrieve a reference to a key where the settings
        ' will be stored.
        Dim key As RegistryKey
        key = Registry.CurrentUser.CreateSubKey(RegPath & win.Name)

        key.SetValue("Bounds", win.RestoreBounds.ToString())
    End Sub

    Public Shared Sub SetSize(ByVal win As Window)
        Dim key As RegistryKey
        key = Registry.CurrentUser.OpenSubKey(RegPath & win.Name)

        If Not key Is Nothing Then
            Dim bounds As Rect = Rect.Parse(key.GetValue("Bounds").ToString())

            win.Top = bounds.Top
            win.Left = bounds.Left

            ' Only restore the size for a manually sized
            ' window.
            If win.SizeToContent = SizeToContent.Manual Then
                win.Width = bounds.Width
                win.Height = bounds.Height
            End If
        End If
    End Sub
End Class

Public Class WindowPositionHelperConfig
	Public Shared Sub SaveSize(ByVal win As Window)
        Settings.Default.WindowPosition = win.RestoreBounds
        Settings.Default.Save()
	End Sub

	Public Shared Sub SetSize(ByVal win As Window)
        Dim rect As Rect = Settings.Default.WindowPosition
		win.Top = rect.Top
		win.Left = rect.Left

		' Only restore the size for a manually sized
		' window.
		If win.SizeToContent = SizeToContent.Manual Then
			win.Width = rect.Width
			win.Height = rect.Height
		End If

	End Sub
End Class
