Imports Microsoft.Win32
Imports System.IO
Imports System.Text

Public Class FileRegistrationHelper
    Public Shared Sub SetFileAssociation(ByVal extension As String, ByVal progID As String)
        ' Create extension subkey
        SetValue(Registry.ClassesRoot, extension, progID)

        ' Create progid subkey
        Dim assemblyFullPath As String = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("/", "\")
        Dim sbShellEntry As New StringBuilder()
        sbShellEntry.AppendFormat("""{0}"" ""%1""", assemblyFullPath)
        SetValue(Registry.ClassesRoot, progID & "\shell\open\command", sbShellEntry.ToString())
        Dim sbDefaultIconEntry As New StringBuilder()
        sbDefaultIconEntry.AppendFormat("""{0}"",0", assemblyFullPath)
        SetValue(Registry.ClassesRoot, progID & "\DefaultIcon", sbDefaultIconEntry.ToString())

        ' Create application subkey
        SetValue(Registry.ClassesRoot, "Applications\" & Path.GetFileName(assemblyFullPath), "", "NoOpenWith")
    End Sub

    Private Shared Sub SetValue(ByVal root As RegistryKey, ByVal subKey As String, ByVal keyValue As Object)
        SetValue(root, subKey, keyValue, Nothing)
    End Sub
    Private Shared Sub SetValue(ByVal root As RegistryKey, ByVal subKey As String, ByVal keyValue As Object, ByVal valueName As String)
        Dim hasSubKey As Boolean = ((Not subKey Is Nothing) AndAlso (subKey.Length > 0))
        Dim key As RegistryKey = root

        Try
            If hasSubKey Then
                key = root.CreateSubKey(subKey)
            End If
            key.SetValue(valueName, keyValue)
        Finally
            If hasSubKey AndAlso (Not key Is Nothing) Then
                key.Close()
            End If
        End Try
    End Sub
End Class
