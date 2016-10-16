Imports System.IO
Imports System.Windows.Markup

Public Class Window1
    Inherits Window

    Private WithEvents button1 As Button

    Public Sub New(ByVal xamlFile As String)
        InitializeComponent(xamlFile)
    End Sub

    Private Sub InitializeComponent(ByVal xamlFile As String)
        ' Configure the form.
        Me.Height = 285
        Me.Width = Me.Height
        Me.Top = 100
        Me.Left = Me.Top
        Me.Title = "Dynamically Loaded XAML"

        ' Get the XAML content from an external file.            
        Dim rootElement As DependencyObject
        Using fs As New FileStream(xamlFile, FileMode.Open)
            rootElement = CType(XamlReader.Load(fs), DependencyObject)
        End Using

        Me.Content = rootElement

        ' Find the control with the appropriate name.
        'button1 = (Button)LogicalTreeHelper.FindLogicalNode(rootElement, "button1");
        Dim frameworkElement As FrameworkElement = CType(rootElement, FrameworkElement)
        button1 = CType(frameworkElement.FindName("button1"), Button)
    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles button1.Click
        button1.Content = "Thank you."
    End Sub
End Class



