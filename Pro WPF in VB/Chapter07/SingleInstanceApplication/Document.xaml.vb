Imports System.IO

Partial Public Class Document

    Private docRef As DocumentReference

    Public Sub LoadFile(ByVal docRef As DocumentReference)
        Me.docRef = docRef
        Me.Content = File.ReadAllText(docRef.Name)
        Me.Title = docRef.Name
    End Sub

    Protected Overrides Sub OnClosed(ByVal e As EventArgs)
        MyBase.OnClosed(e)

        CType(Application.Current, WpfApp).Documents.Remove(docRef)
    End Sub
End Class