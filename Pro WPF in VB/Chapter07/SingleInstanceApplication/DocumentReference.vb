' This package contains a reference to a document window and its name.
' The purpose of this class is to make it easier to display the list
' of window names in DocumentList through data binding.
Public Class DocumentReference
    Private document_Renamed As Document
    Public Property Document() As Document
        Get
            Return document_Renamed
        End Get
        Set(ByVal value As Document)
            document_Renamed = value
        End Set
    End Property

    Private name_Renamed As String
    Public Property Name() As String
        Get
            Return name_Renamed
        End Get
        Set(ByVal value As String)
            name_Renamed = value
        End Set
    End Property

    Public Sub New(ByVal document As Document, ByVal name As String)
        Document = document
        Me.Name = name
    End Sub
End Class

