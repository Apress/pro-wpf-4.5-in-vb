Imports System.Collections.ObjectModel

Public Class Startup
    Public Shared Sub Main(ByVal args As String())
        Dim wrapper As New SingleInstanceApplicationWrapper()
        wrapper.Run(args)
    End Sub
End Class

Public Class SingleInstanceApplicationWrapper
    Inherits Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase

    Public Sub New()
        ' Enable single-instance mode.
        Me.IsSingleInstance = True
    End Sub

    ' Create the WPF application class.
    Private app As WpfApp

    Protected Overrides Function OnStartup(ByVal eventArgs As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) As Boolean
        
        Dim extension As String = ".testDoc"
        Dim title As String = "SingleInstanceApplication"
        Dim extensionDescription As String = "A Test Document"

        ' Uncomment this line to create the file registration.
        ' In Windows Vista, you'll need to run the application
        ' as an administrator.
        'FileRegistrationHelper.SetFileAssociation( _
        '  extension, title & "." & extensionDescription)

        app = New WpfApp()
        app.Run()

        Return False
    End Function


    ' Direct multiple instances
    Private Sub Application_StartupNextInstance(ByVal sender As Object, _
      ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) _
      Handles Me.StartupNextInstance

        If e.CommandLine.Count > 0 Then
            app.ShowDocument(e.CommandLine(0))
        End If
    End Sub
End Class

Public Class WpfApp
    Inherits System.Windows.Application

    Private Sub Application_Startup(ByVal sender As Object, _
      ByVal e As System.Windows.StartupEventArgs) _
      Handles Me.Startup

        ' Load the main window.
        Dim list As New DocumentList()
        Me.MainWindow = list
        list.Show()

        ' Load the document that was specified as an argument.
        If e.Args.Length > 0 Then
            ShowDocument(e.Args(0))
        End If
    End Sub

    ' An ObservableCollection is a List that provides notification
    ' when items are added, deleted, or removed. It's preferred for data binding.
    Private _documents As New ObservableCollection(Of DocumentReference)()
    Public Property Documents() As ObservableCollection(Of DocumentReference)
        Get
            Return _documents
        End Get
        Set(ByVal value As ObservableCollection(Of DocumentReference))
            _documents = value
        End Set
    End Property

    Public Sub ShowDocument(ByVal filename As String)
        Try
            Dim doc As New Document()
            Dim docRef As New DocumentReference(doc, filename)
            doc.LoadFile(docRef)
            doc.Owner = Me.MainWindow
            doc.Show()
            doc.Activate()
            Documents.Add(docRef)
        Catch
            MessageBox.Show("Could not load document.")
        End Try
    End Sub
End Class

