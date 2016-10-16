Imports System.IO
Imports System.Windows.Markup

Public Class Xaml2009Window
    Inherits Window
    Public Shared Function LoadWindowFromXaml(ByVal xamlFile As String) As Xaml2009Window
        ' Get the XAML content from an external file.            
        Using fs As New FileStream(xamlFile, FileMode.Open)
            Dim window As Xaml2009Window = CType(XamlReader.Load(fs), Xaml2009Window)
            Return window
        End Using
    End Function

    Private Sub lst_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        MessageBox.Show(e.AddedItems(0).ToString())
    End Sub
End Class

Public Class Person
    Private privateFirstName As String
    Public Property FirstName() As String
        Get
            Return privateFirstName
        End Get
        Set(ByVal value As String)
            privateFirstName = value
        End Set
    End Property
    Private privateLastName As String
    Public Property LastName() As String
        Get
            Return privateLastName
        End Get
        Set(ByVal value As String)
            privateLastName = value
        End Set
    End Property

    Public Sub New(ByVal firstName As String, ByVal lastName As String)
        Me.FirstName = firstName
        Me.LastName = lastName
    End Sub

    Public Overrides Function ToString() As String
        Return FirstName & " " & LastName
    End Function
End Class

