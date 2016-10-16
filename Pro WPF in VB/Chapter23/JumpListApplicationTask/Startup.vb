Imports System.Windows.Shell

Public Class Startup
    Public Shared Sub Main(ByVal args As String())
        Dim wrapper As New JumpListApplicationTaskWrapper()
        wrapper.Run(args)
    End Sub
End Class

Public Class JumpListApplicationTaskWrapper
    Inherits Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    Public Sub New()
        ' Enable single-instance mode.
        Me.IsSingleInstance = True
    End Sub

    ' Create the WPF application class.
    Private app As WpfApp
    Protected Overrides Function OnStartup(ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) As Boolean
        app = New WpfApp()
        app.Run()

        Return False
    End Function

    ' Direct multiple instances
    Protected Overrides Sub OnStartupNextInstance(ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs)
        If e.CommandLine.Count > 0 Then
            app.ProcessMessage(e.CommandLine(0))
        End If
    End Sub
End Class


Public Class WpfApp
    Inherits System.Windows.Application
    Protected Overrides Sub OnStartup(ByVal e As System.Windows.StartupEventArgs)
        MyBase.OnStartup(e)

        ' Retrieve the current jump list.
        Dim jumpList As New JumpList()
        JumpList.SetJumpList(Application.Current, jumpList)

        ' Add a new JumpPath for an application task.            
        Dim jumpTask As New JumpTask()
        jumpTask.CustomCategory = "Tasks"
        jumpTask.Title = "Do Something"
        jumpTask.ApplicationPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        jumpTask.IconResourcePath = jumpTask.ApplicationPath
        jumpTask.Arguments = "@#StartOrder"
        jumpList.JumpItems.Add(jumpTask)

        ' Update the jump list.
        jumpList.Apply()

        ' Load the main window.
        Dim win As New MainWindow()
        win.Show()
    End Sub

    Public Sub ProcessMessage(ByVal message As String)
        MessageBox.Show("Message " & message & " received.")
    End Sub
End Class
